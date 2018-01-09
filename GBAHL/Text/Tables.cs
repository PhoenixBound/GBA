﻿using System;

namespace GBAHL.Text
{
    internal static class Tables
    {
        // see for more information:
        // http://bulbapedia.bulbagarden.net/wiki/Character_encoding_in_Generation_III

        private static readonly string[] internationalCharacters = new string[256]
        {
            " ", "À", "Á", "Â", "Ç", "È", "É", "Ê", "Ë", "Ì", "こ", "Î", "Ï", "Ò", "Ó", "Ô",
            "Œ", "Ù", "Ú", "Û", "Ñ", "ß", "à", "á", "ね", "ç", "è", "é", "ê", "ë", "ì", "ま",
            "î", "ï", "ò", "ó", "ô", "œ", "ù", "ú", "û", "ñ", "º", "ª", "\\h2C", "&", "+", "あ",
            "ぃ", "ぅ", "ぇ", "ぉ", "[lv]", "=", "ょ", "が", "ぎ", "ぐ", "げ", "ご", "ざ", "じ", "ず", "ぜ",
            "ぞ", "だ", "ぢ", "づ", "で", "ど", "ば", "び", "ぶ", "べ", "ぼ", "ぱ", "ぴ", "ぷ", "ぺ", "ぽ",
            "っ", "¿", "¡", "[pk]", "[mn]", "[po]", "[ke]", "[bl]", "[oc]", "[k]", "Í", "%", "(", ")", "セ", "ソ",
            "タ", "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "â", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "í",
            "ミ", "ム", "メ", "モ", "ヤ", "ユ", "ヨ", "ラ", "リ", "[u]", "[d]", "[l]", "[r]", "ヲ", "ン", "ァ",
            "ィ", "ゥ", "ェ", "ォ", "ャ", "ュ", "ョ", "ガ", "ギ", "グ", "ゲ", "ゴ", "ザ", "ジ", "ズ", "ゼ",
            "ゾ", "ダ", "ヂ", "ヅ", "デ", "ド", "バ", "ビ", "ブ", "ベ", "ボ", "パ", "ピ", "プ", "ペ", "ポ",
            "ッ", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "!", "?", ".", "-", "[.]",
            "[...]", "[\"]", "\"", "[']", "'", "[m]", "[f]", "$", ",", "×", "/", "A", "B", "C", "D", "E",
            "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
            "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k",
            "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "[>]",
            ":", "Ä", "Ö", "Ü", "ä", "ö", "ü", "[^]", "[v]", "[<]", "\\l", "\\p", "\\c", "\\v", "\\n", "\\x",
        };

        private static readonly string[] japaneseCharacters = new string[256]
        {
            " ", "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ",
            "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま",
            "み", "む", "め", "も", "や", "ゆ", "よ", "ら", "り", "る", "れ", "ろ", "わ", "を", "ん", "ぁ",
            "ぃ", "ぅ", "ぇ", "ぉ", "ゃ", "ゅ", "ょ", "が", "ぎ", "ぐ", "げ", "ご", "ざ", "じ", "ず", "ぜ",
            "ぞ", "だ", "ぢ", "づ", "で", "ど", "ば", "び", "ぶ", "べ", "ぼ", "ぱ", "ぴ", "ぷ", "ぺ", "ぽ",
            "っ", "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス	", "セ", "ソ",
            "タ", "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "マ",
            "ミ", "ム", "メ", "モ", "ヤ", "ユ", "ヨ", "ラ", "リ", "ル", "レ", "ロ", "ワ", "ヲ", "ン", "ァ",
            "ィ", "ゥ", "ェ", "ォ", "ャ", "ュ", "ョ", "ガ", "ギ", "グ", "ゲ", "ゴ", "ザ", "ジ", "ズ", "ゼ",
            "ゾ", "ダ", "ヂ", "ヅ", "デ", "ド", "バ", "ビ", "ブ", "ベ", "ボ", "パ", "ピ", "プ", "ペ", "ポ",
            "ッ", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "！", "？", "。", "ー", "・",
            "[・・]", "『", "』", "「", "」", "[m]", "[f]", "円", ".", "×", "/", "A", "B", "C", "D", "E",
            "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
            "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k",
            "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "[>]",
            ":", "Ä", "Ö", "Ü", "ä", "ö", "ü", "[^]", "[v]", "[<]", "\\l", "\\p", "\\c", "\\v", "\\n", "\\x",
        };

        // Singleton table instances
        private static Table international = null;
        private static Table japanese = null;

        // Singleton getters
        public static Table International =>
            international ?? (international = new Table(internationalCharacters));

        public static Table Japanese =>
            japanese ?? (japanese = new Table(japaneseCharacters));

        /*
        public static string GetString(byte[] bytes, Encoding encoding)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                // get byte
                var b = bytes[i];

                // deal with special characters or proceed as normal
                if (b == 0xFC)
                {
                    // functions
                    var cmd = bytes[++i];

                    switch (cmd)
                    {
                        case 0x1: // text color
                            {
                                var color = bytes[++i];

                                // TODO: fancy color names by version
                                sb.AppendFormat("\\c\\h{0:X2}\\h{1:X2}", cmd, color);
                            }
                            break;
                        case 0x2: // highlight color
                            {
                                var color = bytes[++i];

                                sb.AppendFormat("\\c\\h{0:X2}\\h{1:X2}", cmd, color);
                            }
                            break;
                        case 0x3: // text shadow color
                            {
                                var color = bytes[++i];

                                sb.AppendFormat("\\c\\h{0:X2}\\h{1:X2}", cmd, color);
                            }
                            break;
                        case 0x4: // text highlight and shadow color
                            {
                                var shadow = bytes[++i];
                                var highlight = bytes[++i];

                                sb.AppendFormat("\\c\\h{0:X2}\\h{1:X2}\\h{2:X2}", cmd, shadow, highlight);
                            }
                            break;

                        case 0x06: // size
                            if (bytes[++i] == 0x00)
                            {
                                sb.Append("[small]");
                            }
                            else
                            {
                                sb.Append("[normal]");
                            }
                            break;

                        case 0x08: // pause
                            {
                                var pause = bytes[++i];

                                sb.AppendFormat("\\c\\h{0:X2}\\h{1:X2}", cmd, pause);
                            }
                            break;

                        case 0x09:
                            sb.Append("[waitbutton]");
                            break;

                        case 0x0C: // escape characters
                                   // FA -> ➡
                                   // FB -> +
                                   // other -> nothing
                            {
                                var escape = bytes[++i];

                                sb.AppendFormat("\\c\\h{0:X2}\\h{1:X2}", cmd, escape);
                            }
                            break;

                        case 0x0D: // shift text X pixels right
                            {
                                var shift = bytes[++i];

                                sb.AppendFormat("\\c\\h{0:X2}\\h{1:X2}", cmd, shift);
                            }
                            break;

                        case 0x10: // play song
                            {
                                // two bytes, little endian song #
                                var song1 = bytes[++i];
                                var song2 = bytes[++i];

                                sb.AppendFormat("\\c\\h{0:X2}\\h{1:X2}\\h{2:X2}", cmd, song1, song2);
                            }
                            break;

                        case 0x15: // font change
                            sb.Append("[western]");
                            break;
                        case 0x16: // normal font
                            sb.Append("[eastern]");
                            break;
                        case 0x17: // stop music
                            sb.Append("[stop_music]");
                            break;
                        case 0x18: // resume music
                            sb.Append("[resume_music]");
                            break;

                        default:
                            sb.AppendFormat("\\c\\h{0:X2}", cmd);
                            break;
                    }
                }
                else if (b == 0xFD)
                {
                    // variables
                    var cmd = bytes[++i];

                    switch (cmd)
                    {
                        case 0x1:
                            sb.Append("[player]");
                            break;
                        case 0x2:
                            sb.Append("[buffer1]");
                            break;
                        case 0x3:
                            sb.Append("[buffer2]");
                            break;
                        case 0x4:
                            sb.Append("[buffer3]");
                            break;

                        case 0x6:
                            sb.Append("[rival]");
                            break;

                        // TODO: team names, etc.

                        default:
                            sb.AppendFormat("\\v\\h{0:X2}", cmd);
                            break;
                    }
                }
                else if (b == 0xFF)
                {
                    break;
                }
                else
                {
                    //sb.Append(encoding == CharacterEncoding.Japanese ? JapaneseTable[b] : EnglishTable[b]);
                    sb.Append(GetCharacter(b, encoding));
                }
            }

            return sb.ToString();
        }

        public static byte[] GetConstant(string constant)
        {
            switch (constant)
            {
                // FC
                case "small":
                    return new byte[] { 0xFC, 0x06, 0x00 };
                case "normal":
                    return new byte[] { 0xFC, 0x06, 0x01 };

                case "waitbutton":
                case "wait_button":
                    return new byte[] { 0xFC, 0x09 };

                case "western":
                    return new byte[] { 0xFC, 0x15 };
                case "eastern":
                    return new byte[] { 0xFC, 0x16 };
                case "stopmusic":
                case "stop_music":
                    return new byte[] { 0xFC, 0x17 };
                case "resumemusic":
                case "resume_music":
                    return new byte[] { 0xFC, 0x18 };

                // FD - variables
                case "player":
                    return new byte[] { 0xFD, 0x01 };
                case "buffer1":
                    return new byte[] { 0xFD, 0x02 };
                case "buffer2":
                    return new byte[] { 0xFD, 0x03 };
                case "buffer3":
                    return new byte[] { 0xFD, 0x04 };
                case "rival":
                    return new byte[] { 0xFD, 0x06 };

                default:
                    return null;
            }
        }
        */
    }
}
