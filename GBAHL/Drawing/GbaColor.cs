﻿using System;
using System.Drawing;

namespace GBAHL.Drawing
{
    public class GbaColor
    {
        private Color rgbColor;
        private ushort shortColor;

        public Color RgbColor
        {
            get => rgbColor;
            set
            {
                rgbColor = value;
                shortColor = ToGbaColor();
            }
        }
        public ushort Gba555Color
        {
            get => shortColor;
            set
            {
                shortColor = value;
                rgbColor = ToRgbColor();
            }
        }

        // Constructor
        public GbaColor(Color rgb)
        {
            RgbColor = rgb;
        }

        public GbaColor(ushort gba)
        {
            Gba555Color = gba;
        }

        public GbaColor()
        {
            RgbColor = Color.Black;
        }

        public ushort ToGbaColor()
        {
            // GBA color format layout, for reference
            // Little endian: 0BBB'BBGG'GGGR'RRRR
            // Big endian (what APE uses): GGGR'RRRR'0BBB'BBGG
            // Unless anyone wants big really bad, I'm going with little endian for this.

            // Shifting right 3 makes every color 5-bit like it needs to be.
            ushort g = 0x0000;
            g |= (ushort)((rgbColor.B >> 3) << 10);
            g |= (ushort)((rgbColor.G >> 3) << 5);
            g |= (ushort)((rgbColor.R >> 3));

            return g;
        }

        public Color ToRgbColor()
        {
            // TODO: Figure out what arcane magic mGBA uses. It's slightly off compared to this.
            var red = (shortColor & 0x1F) * 255 / 31;
            var green = ((shortColor >> 5) & 0x1F) * 255 / 31;
            var blue = ((shortColor >> 10) & 0x1F) * 255 / 31;
            return Color.FromArgb(red, green, blue);
        }
    }
}
