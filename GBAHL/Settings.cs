﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace GBAHL
{
    using Section = Dictionary<string, string>;

    // basic ini/xml settings data
    // TODO: comment this
    public class Settings
    {
        public enum Format
        {
            INI, XML,
        }

        Dictionary<string, Section> sections = new Dictionary<string, Section>();
        public Settings()
        { }

        // copy constructor
        public Settings(Settings parent)
        {
            foreach (var section in parent.sections.Keys)
            {
                sections[section] = new Section(parent.sections[section]);
            }
        }

        public Settings(Settings parent, string[] sections)
        {
            foreach (var section in parent.sections.Keys)
            {
                if (sections.Contains(section))
                    this.sections[section] = new Section(parent.sections[section]);
            }
        }

        public static Settings FromFile(string filePath, Format format)
        {
            var settings = new Settings();


            switch (format)
            {
                case Format.INI:
                    settings.LoadINI(filePath);
                    break;
                case Format.XML:
                    settings.LoadXML(filePath);
                    break;

                default:
                    throw new NotSupportedException($"Settings format {format} is not supported!");
            }

            return settings;
        }

        void LoadINI(string filePath)
        {
            using (var reader = File.OpenText(filePath))
            {
                int n = 0;
                string section = string.Empty;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().TrimStart();
                    n++;

                    // skip comment lines
                    if (line.StartsWith(";") || line.StartsWith("#")) continue;

                    // parse line, ignoring empty ones
                    if (line.StartsWith("["))
                    {
                        // new section
                        var end = line.IndexOf(']');
                        if (end <= 0) throw new Exception($"line {n}: Invalid section header!");

                        var header = line.Substring(1, end - 1);
                        if (sections.ContainsKey(header)) throw new Exception($"line {n}: Repeated section header!");

                        section = header;
                        sections[header] = new Section();
                    }
                    else if (line.Contains('='))
                    {
                        // new key-value pair
                        var index = line.IndexOf('=');
                        if (index <= 0) throw new Exception($"line {n}: Invalid key!");

                        var key = line.Substring(0, index);
                        var value = line.Substring(index + 1);

                        if (section == string.Empty) throw new Exception($"line {n}: Found key-value pair outside section!");
                        sections[section][key] = value; // overwrites any existing kvp
                    }
                }
            }
        }

        void LoadXML(string filePath)
        {
            // load the file into an xml document
            var doc = new XmlDocument();
            doc.Load(filePath);

            // TODO: allow custom root node?
            var root = doc.SelectSingleNode("/settings");

            // get the root node 'settings'
            foreach (XmlElement x in root.ChildNodes)
            {
                // create the next section
                var header = x.LocalName;
                if (sections.ContainsKey(header)) throw new Exception($"Section {header} already exists!");
                sections[header] = new Section();

                // get all elements
                foreach (XmlElement kvp in x.ChildNodes)
                {
                    var key = kvp.LocalName;
                    var value = kvp.InnerText;

                    sections[header][key] = value;
                }
            }
        }

        /// <summary>
        /// Writes the settings to the specified file in the specified format.
        /// </summary>
        /// <param name="filename">The file to write to.</param>
        /// <param name="format">The format of the settings.</param>
        public void Save(string filename, Format format)
        {
            switch (format)
            {
                case Format.INI:
                    SaveINI(filename);
                    break;
                case Format.XML:
                    SaveXML(filename);
                    break;

                default:
                    throw new NotSupportedException($"Settings format {format} is not supported!");
            }
        }

        void SaveINI(string filename)
        {
            using (var writer = File.CreateText(filename))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF - 8\"?>");
                foreach (var section in sections.Keys)
                {
                    writer.WriteLine("[{0}]", section);
                    foreach (var entry in sections[section].Keys)
                    {
                        writer.WriteLine("{0}={1}", entry, sections[section][entry]);
                    }
                    writer.WriteLine();
                }
            }
        }

        void SaveXML(string filename)
        {
            // don't bother with xml classes
            using (var writer = File.CreateText(filename))
            {
                writer.WriteLine("<settings>");
                foreach (var section in sections.Keys)
                {
                    writer.WriteLine("<{0}>", section);
                    foreach (var entry in sections[section].Keys)
                    {
                        writer.WriteLine("    <{0}>{1}</{0}>", entry, sections[section][entry]);
                    }
                    writer.WriteLine("</{0}>", section);
                }
                writer.WriteLine("</settings>");
            }
        }

        public string GetString(string section, string key)
        {
            if (sections.ContainsKey(section) && sections[section].ContainsKey(key))
                return sections[section][key];
            return string.Empty;
        }

        public bool GetBoolean(string section, string key)
        {
            if (GetString(section, key).ToLower() == "true")
                return true;
            else
                return false;
        }

        public int GetInt32(string section, string key, int fromBase = 10)
        {
            try
            {
                return Convert.ToInt32(GetString(section, key), fromBase);
            }
            catch
            {
                return 0;
            }
        }

        public double GetDouble(string section, string key)
        {
            double d;
            if (double.TryParse(GetString(section, key), out d)) return d;
            return 0d;
        }

        public string[] GetStrings(string section, string key)
        {
            return GetString(section, key).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public void Set(string section, string key, string value)
        {
            if (!sections.ContainsKey(section)) sections[section] = new Section();
            sections[section][key] = value;
        }

        public void Set(string section, string key, bool value)
        {
            Set(section, key, value ? "true" : "false");
        }

        public void Set(string section, string key, int value, string format = "")
        {
            Set(section, key, value.ToString(format));
        }

        public void Set(string section, string key, double value)
        {
            Set(section, key, value.ToString());
        }

        public void Set(string section, string key, string[] values)
        {
            Set(section, key, string.Join(",", values));
        }

        public bool ContainsSection(string section)
        {
            return sections.ContainsKey(section);
        }

        public bool ContainsKey(string section, string key)
        {
            if (ContainsSection(section))
                return sections[section].ContainsKey(key);

            return false;
        }

        public Section GetSection(string section)
        {
            if (sections.ContainsKey(section))
                return sections[section];

            return null;
        }
    }
}