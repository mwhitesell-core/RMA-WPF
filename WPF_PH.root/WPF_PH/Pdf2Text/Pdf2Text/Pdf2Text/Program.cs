using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;

namespace Pdf2Text
{
    class Program
    {
        private const string PAGE_CHAR = ""; // ""; // Linefeed character.

        static void Main(string[] args)
        {
            try
            {
                string fileName = RemoveQuotes(args[0]);
                GenerateTextFile(fileName);
            }
            catch (Exception ex)
            {
                string fileName = null;
                if (args.Length == 0)
                    fileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                else
                    fileName = RemoveQuotes(args[0]);

                string logFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(fileName), System.IO.Path.GetFileNameWithoutExtension(fileName) + ".log");

                using (StreamWriter sw = File.CreateText(logFile))
                {
                    sw.WriteLine(ex.ToString());
                }
            }
        }

        private static string RemoveQuotes(string value)
        {
            return value.Replace("\"", "");
        }

        // Generate the .txt file.
        public static void GenerateTextFile(string path)
        {
            List<TextElement> data = null;
            string outputFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), System.IO.Path.GetFileNameWithoutExtension(path) + ".txt");

            if (File.Exists(outputFile))
                File.Delete(outputFile);

            using (var r = new PdfReader(path))
            {
                for (int i = 1; i <= r.NumberOfPages; i++)
                {
                    data = new List<TextElement>();

                    var t = new MyLocationTextExtractionStrategy();
                    var ex = PdfTextExtractor.GetTextFromPage(r, i, t);

                    //Loop through each chunk found
                    foreach (var p in t.myPoints)
                    {
                        int row = GetRow(p.Rect.Top);
                        int column = GetColumn(p.Rect.Left);

                        if (row == -1 || column == -1)
                        {
                            string x = p.Rect.Top + "," + p.Rect.Left + "," + p.Text;
                        }
                        else
                        {
                            string err = null;
                            var existing = data.Where(x => x.Row == row && x.Column == column);
                            if (existing.Count() == 0)
                                data.Add(new TextElement(row, column, p.Text));
                            else
                                err = p.Text; //data.Add(new TextElement(row, column, p.Text)); //existing.FirstOrDefault().Text = p.Text;
                        }
                    }

                    // Now write out each page.
                    WritePage(data, outputFile, i == 1);
                }
            }
        }

        // Loop through controls and write out page to text file.
        private static void WritePage(List<TextElement> data, string outputFile, bool isFirstWrite)
        {
            StringBuilder text = new StringBuilder(PAGE_CHAR);
            StringBuilder line = new StringBuilder(string.Empty);

            var sortedList = data.OrderBy(x => x.Row).ThenBy(x => x.Column);

            int previousRow = 0;            //int totalLength = 0; // Used to determine total string length.  Used to append trailing spaces to previous text value.

            foreach (var item in sortedList)
            {
                // If we're on a new line, add the linefeed.
                if (previousRow != 0 && previousRow != item.Row)
                {
                    text.AppendLine(line.ToString());
                    line.Remove(0, line.Length);

                    // See if we need to add blank lines.
                    for (int i = previousRow; i < item.Row - 1; i++)
                    {
                        text.AppendLine(string.Empty);
                    }
                }

                // Pad with trailing spaces.
                if (item.Column - 1 > line.Length)
                    line.Append(" ".PadLeft((item.Column - 1) - line.Length));

                line.Append(item.Text);

                previousRow = item.Row;
            }

            // Append the last line.
            text.AppendLine(line.ToString());

            if (isFirstWrite)
            {
                using (StreamWriter sw = File.CreateText(outputFile))
                {
                    sw.Write(text.ToString());
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(outputFile))
                {
                    sw.Write(text.ToString());
                }
            }
        }

        // Get the row value based on Top coordinate from Pdf.
        // Assumes 10pt font and was created using Text_Template.pdf as reference.
        private static int GetRow(float top)
        {
            string value = Math.Round(top, 4).ToString();

            switch (value)
            {
                case "35.3774":
                    return 63;
                case "47.2574":
                    return 62;
                case "59.1374":
                    return 61;
                case "71.0174":
                    return 60;
                case "82.8974":
                    return 59;
                case "94.7774":
                    return 58;
                case "106.6574":
                    return 57;
                case "118.5374":
                    return 56;
                case "130.4174":
                    return 55;
                case "142.2974":
                    return 54;
                case "154.1774":
                    return 53;
                case "166.0574":
                    return 52;
                case "177.9374":
                    return 51;
                case "189.8174":
                    return 50;
                case "201.6974":
                    return 49;
                case "213.5774":
                    return 48;
                case "225.4574":
                    return 47;
                case "237.3374":
                    return 46;
                case "249.2174":
                    return 45;
                case "261.0974":
                    return 44;
                case "272.9774":
                    return 43;
                case "284.8574":
                    return 42;
                case "296.7374":
                    return 41;
                case "308.6174":
                    return 40;
                case "320.4974":
                    return 39;
                case "332.3774":
                    return 38;
                case "344.2574":
                    return 37;
                case "356.1374":
                    return 36;
                case "368.0174":
                    return 35;
                case "379.8974":
                    return 34;
                case "391.7774":
                    return 33;
                case "403.6574":
                    return 32;
                case "415.5374":
                    return 31;
                case "427.4174":
                    return 30;
                case "439.2974":
                    return 29;
                case "451.1774":
                    return 28;
                case "463.0574":
                    return 27;
                case "474.9374":
                    return 26;
                case "486.8174":
                    return 25;
                case "498.6974":
                    return 24;
                case "510.5774":
                    return 23;
                case "522.4574":
                    return 22;
                case "534.3373":
                    return 21;
                case "546.2173":
                    return 20;
                case "558.0974":
                    return 19;
                case "569.9774":
                    return 18;
                case "581.8574":
                    return 17;
                case "593.7374":
                    return 16;
                case "605.6174":
                    return 15;
                case "617.4974":
                    return 14;
                case "629.3774":
                    return 13;
                case "641.2574":
                    return 12;
                case "653.1374":
                    return 11;
                case "665.0174":
                    return 10;
                case "676.8973":
                    return 9;
                case "688.7773":
                    return 8;
                case "700.6573":
                    return 7;
                case "712.5374":
                    return 6;
                case "724.4174":
                    return 5;
                case "736.2974":
                    return 4;
                case "748.1774":
                    return 3;
                case "760.0574":
                    return 2;
                case "771.9374":
                    return 1;
                default:
                    return GetRowVariance(top);
            }
        }

        // Get the row value if not found using GetRow based on Top coordinate from Pdf.
        private static int GetRowVariance(float top)
        {
            if (top < 35.3774)
                return 63;
            else if (top > 35.3774 && top < 47.2574)
                return (top < 35.3774 + 5.9400) ? 63 : 62;
            else if (top > 47.2574 && top < 59.1374)
                return (top < 47.2574 + 5.9400) ? 62 : 61;
            else if (top > 59.1374 && top < 71.0174)
                return (top < 59.1374 + 5.9400) ? 61 : 60;
            else if (top > 71.0174 && top < 82.8974)
                return (top < 71.0174 + 5.9400) ? 60 : 59;
            else if (top > 82.8974 && top < 94.7774)
                return (top < 82.8974 + 5.9400) ? 59 : 58;
            else if (top > 94.7774 && top < 106.6574)
                return (top < 94.7774 + 5.9400) ? 58 : 57;
            else if (top > 106.6574 && top < 118.5374)
                return (top < 106.6574 + 5.9400) ? 57 : 56;
            else if (top > 118.5374 && top < 130.4174)
                return (top < 118.5374 + 5.9400) ? 56 : 55;
            else if (top > 130.4174 && top < 142.2974)
                return (top < 130.4174 + 5.9400) ? 55 : 54;
            else if (top > 142.2974 && top < 154.1774)
                return (top < 142.2974 + 5.9400) ? 54 : 53;
            else if (top > 154.1774 && top < 166.0574)
                return (top < 154.1774 + 5.9400) ? 53 : 52;
            else if (top > 166.0574 && top < 177.9374)
                return (top < 166.0574 + 5.9400) ? 52 : 51;
            else if (top > 177.9374 && top < 189.8174)
                return (top < 177.9374 + 5.9400) ? 51 : 50;
            else if (top > 189.8174 && top < 201.6974)
                return (top < 189.8174 + 5.9400) ? 50 : 49;
            else if (top > 201.6974 && top < 213.5774)
                return (top < 201.6974 + 5.9400) ? 49 : 48;
            else if (top > 213.5774 && top < 225.4574)
                return (top < 213.5774 + 5.9400) ? 48 : 47;
            else if (top > 225.4574 && top < 237.3374)
                return (top < 225.4574 + 5.9400) ? 47 : 46;
            else if (top > 237.3374 && top < 249.2174)
                return (top < 237.3374 + 5.9400) ? 46 : 45;
            else if (top > 249.2174 && top < 261.0974)
                return (top < 249.2174 + 5.9400) ? 45 : 44;
            else if (top > 261.0974 && top < 272.9774)
                return (top < 261.0974 + 5.9400) ? 44 : 43;
            else if (top > 272.9774 && top < 284.8574)
                return (top < 272.9774 + 5.9400) ? 43 : 42;
            else if (top > 284.8574 && top < 296.7374)
                return (top < 284.8574 + 5.9400) ? 42 : 41;
            else if (top > 296.7374 && top < 308.6174)
                return (top < 296.7374 + 5.9400) ? 41 : 40;
            else if (top > 308.6174 && top < 320.4974)
                return (top < 308.6174 + 5.9400) ? 40 : 39;
            else if (top > 320.4974 && top < 332.3774)
                return (top < 320.4974 + 5.9400) ? 39 : 38;
            else if (top > 332.3774 && top < 344.2574)
                return (top < 332.3774 + 5.9400) ? 38 : 37;
            else if (top > 344.2574 && top < 356.1374)
                return (top < 344.2574 + 5.9400) ? 37 : 36;
            else if (top > 356.1374 && top < 368.0174)
                return (top < 356.1374 + 5.9400) ? 36 : 35;
            else if (top > 368.0174 && top < 379.8974)
                return (top < 368.0174 + 5.9400) ? 35 : 34;
            else if (top > 379.8974 && top < 391.7774)
                return (top < 379.8974 + 5.9400) ? 34 : 33;
            else if (top > 391.7774 && top < 403.6574)
                return (top < 391.7774 + 5.9400) ? 33 : 32;
            else if (top > 403.6574 && top < 415.5374)
                return (top < 403.6574 + 5.9400) ? 32 : 31;
            else if (top > 415.5374 && top < 427.4174)
                return (top < 415.5374 + 5.9400) ? 31 : 30;
            else if (top > 427.4174 && top < 439.2974)
                return (top < 427.4174 + 5.9400) ? 30 : 29;
            else if (top > 439.2974 && top < 451.1774)
                return (top < 439.2974 + 5.9400) ? 29 : 28;
            else if (top > 451.1774 && top < 463.0574)
                return (top < 451.1774 + 5.9400) ? 28 : 27;
            else if (top > 463.0574 && top < 474.9374)
                return (top < 463.0574 + 5.9400) ? 27 : 26;
            else if (top > 474.9374 && top < 486.8174)
                return (top < 474.9374 + 5.9400) ? 26 : 25;
            else if (top > 486.8174 && top < 498.6974)
                return (top < 486.8174 + 5.9400) ? 25 : 24;
            else if (top > 498.6974 && top < 510.5774)
                return (top < 498.6974 + 5.9400) ? 24 : 23;
            else if (top > 510.5774 && top < 522.4574)
                return (top < 510.5774 + 5.9400) ? 23 : 22;
            else if (top > 522.4574 && top < 534.3373)
                return (top < 522.4574 + 5.93995) ? 22 : 21;
            else if (top > 534.3373 && top < 546.2173)
                return (top < 534.3373 + 5.9400) ? 21 : 20;
            else if (top > 546.2173 && top < 558.0974)
                return (top < 546.2173 + 5.94005) ? 20 : 19;
            else if (top > 558.0974 && top < 569.9774)
                return (top < 558.0974 + 5.9400) ? 19 : 18;
            else if (top > 569.9774 && top < 581.8574)
                return (top < 569.9774 + 5.9400) ? 18 : 17;
            else if (top > 581.8574 && top < 593.7374)
                return (top < 581.8574 + 5.9400) ? 17 : 16;
            else if (top > 593.7374 && top < 605.6174)
                return (top < 593.7374 + 5.9400) ? 16 : 15;
            else if (top > 605.6174 && top < 617.4974)
                return (top < 605.6174 + 5.9400) ? 15 : 14;
            else if (top > 617.4974 && top < 629.3774)
                return (top < 617.4974 + 5.9400) ? 14 : 13;
            else if (top > 629.3774 && top < 641.2574)
                return (top < 629.3774 + 5.9400) ? 13 : 12;
            else if (top > 641.2574 && top < 653.1374)
                return (top < 641.2574 + 5.9400) ? 12 : 11;
            else if (top > 653.1374 && top < 665.0174)
                return (top < 653.1374 + 5.9400) ? 11 : 10;
            else if (top > 665.0174 && top < 676.8973)
                return (top < 665.0174 + 5.93995) ? 10 : 9;
            else if (top > 676.8973 && top < 688.7773)
                return (top < 676.8973 + 5.9400) ? 9 : 8;
            else if (top > 688.7773 && top < 700.6573)
                return (top < 688.7773 + 5.9400) ? 8 : 7;
            else if (top > 700.6573 && top < 712.5374)
                return (top < 700.6573 + 5.94005) ? 7 : 6;
            else if (top > 712.5374 && top < 724.4174)
                return (top < 712.5374 + 5.9400) ? 6 : 5;
            else if (top > 724.4174 && top < 736.2974)
                return (top < 724.4174 + 5.9400) ? 5 : 4;
            else if (top > 736.2974 && top < 748.1774)
                return (top < 736.2974 + 5.9400) ? 4 : 3;
            else if (top > 748.1774 && top < 760.0574)
                return (top < 748.1774 + 5.9400) ? 3 : 2;
            else if (top > 760.0574 && top < 771.9374)
                return (top < 760.0574 + 5.9400) ? 2 : 1;
            else
                return -1;
        }

        // Get the column value based on Left coordinate from Pdf.
        // Assumes 10pt font and was created using Text_Template.pdf as reference.
        private static int GetColumn(float left)
        {
            string value = string.Format("{0:0.0000}", Math.Round(left, 4)).ToString();

            switch (value)
            {
                case "18.0000":
                    return 1;
                case "23.9760":
                    return 2;
                case "30.0240":
                    return 3;
                case "36.0000":
                    return 4;
                case "42.0480":
                    return 5;
                case "48.0240":
                    return 6;
                case "54.0720":
                    return 7;
                case "60.1200":
                    return 8;
                case "66.0960":
                    return 9;
                case "72.1440":
                    return 10;
                case "78.1200":
                    return 11;
                case "84.1680":
                    return 12;
                case "90.1440":
                    return 13;
                case "96.1200":
                    return 14;
                case "102.1680":
                    return 15;
                case "108.2160":
                    return 16;
                case "114.1920":
                    return 17;
                case "120.2400":
                    return 18;
                case "126.2160":
                    return 19;
                case "132.2640":
                    return 20;
                case "138.2400":
                    return 21;
                case "144.2160":
                    return 22;
                case "150.2640":
                    return 23;
                case "156.3120":
                    return 24;
                case "162.2880":
                    return 25;
                case "168.3360":
                    return 26;
                case "174.3120":
                    return 27;
                case "180.2880":
                    return 28;
                case "186.3360":
                    return 29;
                case "192.3120":
                    return 30;
                case "198.3600":
                    return 31;
                case "204.4080":
                    return 32;
                case "210.3840":
                    return 33;
                case "216.4320":
                    return 34;
                case "222.4080":
                    return 35;
                case "228.3840":
                    return 36;
                case "234.4320":
                    return 37;
                case "240.4080":
                    return 38;
                case "246.4560":
                    return 39;
                case "252.5040":
                    return 40;
                case "258.4800":
                    return 41;
                case "264.5280":
                    return 42;
                case "270.5040":
                    return 43;
                case "276.4800":
                    return 44;
                case "282.5280":
                    return 45;
                case "288.5040":
                    return 46;
                case "294.5520":
                    return 47;
                case "300.5280":
                    return 48;
                case "306.5760":
                    return 49;
                case "312.5520":
                    return 50;
                case "318.6000":
                    return 51;
                case "324.6480":
                    return 52;
                case "330.6960":
                    return 53;
                case "336.6000":
                    return 54;
                case "342.6480":
                    return 55;
                case "348.6960":
                    return 56;
                case "354.6720":
                    return 57;
                case "360.7200":
                    return 58;
                case "366.6960":
                    return 59;
                case "372.6720":
                    return 60;
                case "378.7200":
                    return 61;
                case "384.7680":
                    return 62;
                case "390.7440":
                    return 63;
                case "396.7200":
                    return 64;
                case "402.7680":
                    return 65;
                case "408.7440":
                    return 66;
                case "414.7920":
                    return 67;
                case "420.7680":
                    return 68;
                case "426.8160":
                    return 69;
                case "432.8640":
                    return 70;
                case "438.8400":
                    return 71;
                case "444.8880":
                    return 72;
                case "450.8640":
                    return 73;
                case "456.8400":
                    return 74;
                case "462.8880":
                    return 75;
                case "468.8640":
                    return 76;
                case "474.9120":
                    return 77;
                case "480.8880":
                    return 78;
                case "486.9360":
                    return 79;
                case "492.9840":
                    return 80;
                case "498.9600":
                    return 81;
                case "505.0080":
                    return 82;
                case "510.9840":
                    return 83;
                case "516.9600":
                    return 84;
                case "523.0080":
                    return 85;
                case "528.9840":
                    return 86;
                case "535.0320":
                    return 87;
                case "541.0800":
                    return 88;
                case "547.0560":
                    return 89;
                case "553.1040":
                    return 90;
                case "559.0800":
                    return 91;
                case "565.0560":
                    return 92;
                case "571.1040":
                    return 93;
                case "577.0800":
                    return 94;
                case "583.1280":
                    return 95;
                case "589.1760":
                    return 96;
                case "595.1520":
                    return 97;
                case "601.1280":
                    return 98;
                case "607.1760":
                    return 99;
                case "613.2240":
                    return 100;
                case "619.2000":
                    return 101;
                case "625.2480":
                    return 102;
                case "631.2240":
                    return 103;
                case "637.2000":
                    return 104;
                case "643.2480":
                    return 105;
                case "649.2960":
                    return 106;
                case "655.2720":
                    return 107;
                case "661.2480":
                    return 108;
                case "667.2960":
                    return 109;
                case "673.2720":
                    return 110;
                case "679.3200":
                    return 111;
                case "685.3680":
                    return 112;
                case "691.3440":
                    return 113;
                case "697.3200":
                    return 114;
                case "703.3680":
                    return 115;
                case "709.4160":
                    return 116;
                case "715.3920":
                    return 117;
                case "721.3680":
                    return 118;
                case "727.4160":
                    return 119;
                case "733.3920":
                    return 120;
                case "739.4400":
                    return 121;
                case "745.4880":
                    return 122;
                case "751.4640":
                    return 123;
                case "757.4400":
                    return 124;
                case "763.4880":
                    return 125;
                case "769.4640":
                    return 126;
                case "775.5120":
                    return 127;
                case "781.5600":
                    return 128;
                case "787.5360":
                    return 129;
                case "793.5120":
                    return 130;
                case "799.5600":
                    return 131;
                case "805.6080":
                    return 132;
                case "811.5840":
                    return 133;
                case "817.6320":
                    return 134;
                case "823.6080":
                    return 135;
                case "829.6560":
                    return 136;
                case "835.6320":
                    return 137;
                case "841.6080":
                    return 138;
                case "847.6560":
                    return 139;
                case "853.6320":
                    return 140;
                case "859.6800":
                    return 141;
                case "865.7280":
                    return 142;
                case "871.7040":
                    return 143;
                case "877.6800":
                    return 144;
                case "883.7280":
                    return 145;
                case "889.7040":
                    return 146;
                case "895.7520":
                    return 147;
                case "901.8000":
                    return 148;
                case "907.7760":
                    return 149;
                case "913.7520":
                    return 150;
                case "919.8000":
                    return 151;
                case "925.7760":
                    return 152;
                case "931.8240":
                    return 153;
                case "937.8720":
                    return 154;
                case "943.8480":
                    return 155;
                case "949.8960":
                    return 156;
                case "955.8720":
                    return 157;
                case "961.8480":
                    return 158;
                case "967.8960":
                    return 159;
                case "973.8720":
                    return 160;
                case "979.9200":
                    return 161;
                case "985.8960":
                    return 162;
                case "991.9440":
                    return 163;
                case "997.9200":
                    return 164;
                case "1003.9680":
                    return 165;
                case "1010.0160":
                    return 166;
                case "1015.9920":
                    return 167;
                case "1022.0400":
                    return 168;
                case "1028.0160":
                    return 169;
                case "1033.9920":
                    return 170;
                case "1040.0400":
                    return 171;
                case "1046.0160":
                    return 172;
                case "1052.0640":
                    return 173;
                case "1058.1120":
                    return 174;
                case "1064.0880":
                    return 175;
                case "1070.1360":
                    return 176;
                case "1076.1120":
                    return 177;
                case "1082.0880":
                    return 178;
                case "1088.1360":
                    return 179;
                case "1094.1120":
                    return 180;
                case "1100.1600":
                    return 181;
                case "1106.2080":
                    return 182;
                case "1112.1840":
                    return 183;
                case "1118.2320":
                    return 184;
                case "1124.2080":
                    return 185;
                case "1130.2560":
                    return 186;
                case "1136.2320":
                    return 187;
                case "1142.2800":
                    return 188;
                case "1148.2560":
                    return 189;
                case "1154.2320":
                    return 190;
                case "1160.2800":
                    return 191;
                case "1166.2560":
                    return 192;
                case "1172.3040":
                    return 193;
                case "1178.2800":
                    return 194;
                case "1184.3280":
                    return 195;
                case "1190.3040":
                    return 196;
                case "1196.3520":
                    return 197;
                case "1202.3280":
                    return 198;
                case "1208.3760":
                    return 199;
                case "1214.4240":
                    return 200;
                case "1220.4000":
                    return 201;
                case "1226.4480":
                    return 202;
                case "1232.4240":
                    return 203;
                case "1238.4720":
                    return 204;
                case "1244.4480":
                    return 205;
                case "1250.4960":
                    return 206;
                case "1256.4720":
                    return 207;
                case "1262.5200":
                    return 208;
                case "1268.4960":
                    return 209;
                case "1274.4720":
                    return 210;
                case "1280.5200":
                    return 211;
                case "1286.4960":
                    return 212;
                case "1292.5440":
                    return 213;
                case "1298.5200":
                    return 214;
                case "1304.5680":
                    return 215;
                case "1310.5440":
                    return 216;
                case "1316.5920":
                    return 217;
                case "1322.5680":
                    return 218;
                case "1328.6160":
                    return 219;
                case "1334.6640":
                    return 220;
                case "1340.6400":
                    return 221;
                case "1346.6880":
                    return 222;
                case "1352.6640":
                    return 223;
                case "1358.7120":
                    return 224;
                case "1364.6880":
                    return 225;
                case "1370.7360":
                    return 226;
                case "1376.7120":
                    return 227;
                case "1382.7600":
                    return 228;
                case "1388.7360":
                    return 229;
                case "1394.7120":
                    return 230;
                case "1400.7600":
                    return 231;
                case "1406.7360":
                    return 232;
                case "1412.7840":
                    return 233;
                case "1418.7600":
                    return 234;
                case "1424.8080":
                    return 235;
                case "1430.7840":
                    return 236;
                case "1436.8320":
                    return 237;
                case "1442.8080":
                    return 238;
                case "1448.8560":
                    return 239;
                case "1454.8320":
                    return 240;
                case "1460.8800":
                    return 241;
                case "1466.9280":
                    return 242;
                case "1472.9040":
                    return 243;
                case "1478.9520":
                    return 244;
                case "1484.9280":
                    return 245;
                case "1490.9040":
                    return 246;
                case "1496.9520":
                    return 247;
                case "1503.0000":
                    return 248;
                case "1508.9760":
                    return 249;
                case "1515.0240":
                    return 250;
                case "1521.0000":
                    return 251;
                case "1526.9760":
                    return 252;
                case "1533.0240":
                    return 253;
                case "1539.0720":
                    return 254;
                case "1545.0480":
                    return 255;
                case "1551.0240":
                    return 256;
                case "1557.0720":
                    return 257;
                case "1563.0480":
                    return 258;
                case "1569.0960":
                    return 259;
                case "1575.0720":
                    return 260;
                case "1581.1200":
                    return 261;
                case "1587.1680":
                    return 262;
                case "1593.1440":
                    return 263;
                case "1599.1200":
                    return 264;
                default:
                    return GetColumnVariance(left);
            }
        }

        // Get the column value if not found using GetRow based on Left coordinate from Pdf.
        private static int GetColumnVariance(float left)
        {
            if (left < 18.0000)
                return 1;
            else if (left > 18.0000 && left < 23.9760)
                return (left < 18.0000 + 2.9880) ? 1 : 2;
            else if (left > 23.9760 && left < 30.0240)
                return (left < 23.9760 + 3.0240) ? 2 : 3;
            else if (left > 30.0240 && left < 36.0000)
                return (left < 30.0240 + 2.9880) ? 3 : 4;
            else if (left > 36.0000 && left < 42.0480)
                return (left < 36.0000 + 3.0240) ? 4 : 5;
            else if (left > 42.0480 && left < 48.0240)
                return (left < 42.0480 + 2.9880) ? 5 : 6;
            else if (left > 48.0240 && left < 54.0720)
                return (left < 48.0240 + 3.0240) ? 6 : 7;
            else if (left > 54.0720 && left < 60.1200)
                return (left < 54.0720 + 3.0240) ? 7 : 8;
            else if (left > 60.1200 && left < 66.0960)
                return (left < 60.1200 + 2.9880) ? 8 : 9;
            else if (left > 66.0960 && left < 72.1440)
                return (left < 66.0960 + 3.0240) ? 9 : 10;
            else if (left > 72.1440 && left < 78.1200)
                return (left < 72.1440 + 2.9880) ? 10 : 11;
            else if (left > 78.1200 && left < 84.1680)
                return (left < 78.1200 + 3.0240) ? 11 : 12;
            else if (left > 84.1680 && left < 90.1440)
                return (left < 84.1680 + 2.9880) ? 12 : 13;
            else if (left > 90.1440 && left < 96.1200)
                return (left < 90.1440 + 2.9880) ? 13 : 14;
            else if (left > 96.1200 && left < 102.1680)
                return (left < 96.1200 + 3.0240) ? 14 : 15;
            else if (left > 102.1680 && left < 108.2160)
                return (left < 102.1680 + 3.0240) ? 15 : 16;
            else if (left > 108.2160 && left < 114.1920)
                return (left < 108.2160 + 2.9880) ? 16 : 17;
            else if (left > 114.1920 && left < 120.2400)
                return (left < 114.1920 + 3.0240) ? 17 : 18;
            else if (left > 120.2400 && left < 126.2160)
                return (left < 120.2400 + 2.9880) ? 18 : 19;
            else if (left > 126.2160 && left < 132.2640)
                return (left < 126.2160 + 3.0240) ? 19 : 20;
            else if (left > 132.2640 && left < 138.2400)
                return (left < 132.2640 + 2.9880) ? 20 : 21;
            else if (left > 138.2400 && left < 144.2160)
                return (left < 138.2400 + 2.9880) ? 21 : 22;
            else if (left > 144.2160 && left < 150.2640)
                return (left < 144.2160 + 3.0240) ? 22 : 23;
            else if (left > 150.2640 && left < 156.3120)
                return (left < 150.2640 + 3.0240) ? 23 : 24;
            else if (left > 156.3120 && left < 162.2880)
                return (left < 156.3120 + 2.9880) ? 24 : 25;
            else if (left > 162.2880 && left < 168.3360)
                return (left < 162.2880 + 3.0240) ? 25 : 26;
            else if (left > 168.3360 && left < 174.3120)
                return (left < 168.3360 + 2.9880) ? 26 : 27;
            else if (left > 174.3120 && left < 180.2880)
                return (left < 174.3120 + 2.9880) ? 27 : 28;
            else if (left > 180.2880 && left < 186.3360)
                return (left < 180.2880 + 3.0240) ? 28 : 29;
            else if (left > 186.3360 && left < 192.3120)
                return (left < 186.3360 + 2.9880) ? 29 : 30;
            else if (left > 192.3120 && left < 198.3600)
                return (left < 192.3120 + 3.0240) ? 30 : 31;
            else if (left > 198.3600 && left < 204.4080)
                return (left < 198.3600 + 3.0240) ? 31 : 32;
            else if (left > 204.4080 && left < 210.3840)
                return (left < 204.4080 + 2.9880) ? 32 : 33;
            else if (left > 210.3840 && left < 216.4320)
                return (left < 210.3840 + 3.0240) ? 33 : 34;
            else if (left > 216.4320 && left < 222.4080)
                return (left < 216.4320 + 2.9880) ? 34 : 35;
            else if (left > 222.4080 && left < 228.3840)
                return (left < 222.4080 + 2.9880) ? 35 : 36;
            else if (left > 228.3840 && left < 234.4320)
                return (left < 228.3840 + 3.0240) ? 36 : 37;
            else if (left > 234.4320 && left < 240.4080)
                return (left < 234.4320 + 2.9880) ? 37 : 38;
            else if (left > 240.4080 && left < 246.4560)
                return (left < 240.4080 + 3.0240) ? 38 : 39;
            else if (left > 246.4560 && left < 252.5040)
                return (left < 246.4560 + 3.0240) ? 39 : 40;
            else if (left > 252.5040 && left < 258.4800)
                return (left < 252.5040 + 2.9880) ? 40 : 41;
            else if (left > 258.4800 && left < 264.5280)
                return (left < 258.4800 + 3.0240) ? 41 : 42;
            else if (left > 264.5280 && left < 270.5040)
                return (left < 264.5280 + 2.9880) ? 42 : 43;
            else if (left > 270.5040 && left < 276.4800)
                return (left < 270.5040 + 2.9880) ? 43 : 44;
            else if (left > 276.4800 && left < 282.5280)
                return (left < 276.4800 + 3.0240) ? 44 : 45;
            else if (left > 282.5280 && left < 288.5040)
                return (left < 282.5280 + 2.9880) ? 45 : 46;
            else if (left > 288.5040 && left < 294.5520)
                return (left < 288.5040 + 3.0240) ? 46 : 47;
            else if (left > 294.5520 && left < 300.5280)
                return (left < 294.5520 + 2.9880) ? 47 : 48;
            else if (left > 300.5280 && left < 306.5760)
                return (left < 300.5280 + 3.0240) ? 48 : 49;
            else if (left > 306.5760 && left < 312.5520)
                return (left < 306.5760 + 2.9880) ? 49 : 50;
            else if (left > 312.5520 && left < 318.6000)
                return (left < 312.5520 + 3.0240) ? 50 : 51;
            else if (left > 318.6000 && left < 324.6480)
                return (left < 318.6000 + 3.0240) ? 51 : 52;
            else if (left > 324.6480 && left < 330.6960)
                return (left < 324.6480 + 3.0240) ? 52 : 53;
            else if (left > 330.6960 && left < 336.6000)
                return (left < 330.6960 + 2.9520) ? 53 : 54;
            else if (left > 336.6000 && left < 342.6480)
                return (left < 336.6000 + 3.0240) ? 54 : 55;
            else if (left > 342.6480 && left < 348.6960)
                return (left < 342.6480 + 3.0240) ? 55 : 56;
            else if (left > 348.6960 && left < 354.6720)
                return (left < 348.6960 + 2.9880) ? 56 : 57;
            else if (left > 354.6720 && left < 360.7200)
                return (left < 354.6720 + 3.0240) ? 57 : 58;
            else if (left > 360.7200 && left < 366.6960)
                return (left < 360.7200 + 2.9880) ? 58 : 59;
            else if (left > 366.6960 && left < 372.6720)
                return (left < 366.6960 + 2.9880) ? 59 : 60;
            else if (left > 372.6720 && left < 378.7200)
                return (left < 372.6720 + 3.0240) ? 60 : 61;
            else if (left > 378.7200 && left < 384.7680)
                return (left < 378.7200 + 3.0240) ? 61 : 62;
            else if (left > 384.7680 && left < 390.7440)
                return (left < 384.7680 + 2.9880) ? 62 : 63;
            else if (left > 390.7440 && left < 396.7200)
                return (left < 390.7440 + 2.9880) ? 63 : 64;
            else if (left > 396.7200 && left < 402.7680)
                return (left < 396.7200 + 3.0240) ? 64 : 65;
            else if (left > 402.7680 && left < 408.7440)
                return (left < 402.7680 + 2.9880) ? 65 : 66;
            else if (left > 408.7440 && left < 414.7920)
                return (left < 408.7440 + 3.0240) ? 66 : 67;
            else if (left > 414.7920 && left < 420.7680)
                return (left < 414.7920 + 2.9880) ? 67 : 68;
            else if (left > 420.7680 && left < 426.8160)
                return (left < 420.7680 + 3.0240) ? 68 : 69;
            else if (left > 426.8160 && left < 432.8640)
                return (left < 426.8160 + 3.0240) ? 69 : 70;
            else if (left > 432.8640 && left < 438.8400)
                return (left < 432.8640 + 2.9880) ? 70 : 71;
            else if (left > 438.8400 && left < 444.8880)
                return (left < 438.8400 + 3.0240) ? 71 : 72;
            else if (left > 444.8880 && left < 450.8640)
                return (left < 444.8880 + 2.9880) ? 72 : 73;
            else if (left > 450.8640 && left < 456.8400)
                return (left < 450.8640 + 2.9880) ? 73 : 74;
            else if (left > 456.8400 && left < 462.8880)
                return (left < 456.8400 + 3.0240) ? 74 : 75;
            else if (left > 462.8880 && left < 468.8640)
                return (left < 462.8880 + 2.9880) ? 75 : 76;
            else if (left > 468.8640 && left < 474.9120)
                return (left < 468.8640 + 3.0240) ? 76 : 77;
            else if (left > 474.9120 && left < 480.8880)
                return (left < 474.9120 + 2.9880) ? 77 : 78;
            else if (left > 480.8880 && left < 486.9360)
                return (left < 480.8880 + 3.0240) ? 78 : 79;
            else if (left > 486.9360 && left < 492.9840)
                return (left < 486.9360 + 3.0240) ? 79 : 80;
            else if (left > 492.9840 && left < 498.9600)
                return (left < 492.9840 + 2.9880) ? 80 : 81;
            else if (left > 498.9600 && left < 505.0080)
                return (left < 498.9600 + 3.0240) ? 81 : 82;
            else if (left > 505.0080 && left < 510.9840)
                return (left < 505.0080 + 2.9880) ? 82 : 83;
            else if (left > 510.9840 && left < 516.9600)
                return (left < 510.9840 + 2.9880) ? 83 : 84;
            else if (left > 516.9600 && left < 523.0080)
                return (left < 516.9600 + 3.0240) ? 84 : 85;
            else if (left > 523.0080 && left < 528.9840)
                return (left < 523.0080 + 2.9880) ? 85 : 86;
            else if (left > 528.9840 && left < 535.0320)
                return (left < 528.9840 + 3.0240) ? 86 : 87;
            else if (left > 535.0320 && left < 541.0800)
                return (left < 535.0320 + 3.0240) ? 87 : 88;
            else if (left > 541.0800 && left < 547.0560)
                return (left < 541.0800 + 2.9880) ? 88 : 89;
            else if (left > 547.0560 && left < 553.1040)
                return (left < 547.0560 + 3.0240) ? 89 : 90;
            else if (left > 553.1040 && left < 559.0800)
                return (left < 553.1040 + 2.9880) ? 90 : 91;
            else if (left > 559.0800 && left < 565.0560)
                return (left < 559.0800 + 2.9880) ? 91 : 92;
            else if (left > 565.0560 && left < 571.1040)
                return (left < 565.0560 + 3.0240) ? 92 : 93;
            else if (left > 571.1040 && left < 577.0800)
                return (left < 571.1040 + 2.9880) ? 93 : 94;
            else if (left > 577.0800 && left < 583.1280)
                return (left < 577.0800 + 3.0240) ? 94 : 95;
            else if (left > 583.1280 && left < 589.1760)
                return (left < 583.1280 + 3.0240) ? 95 : 96;
            else if (left > 589.1760 && left < 595.1520)
                return (left < 589.1760 + 2.9880) ? 96 : 97;
            else if (left > 595.1520 && left < 601.1280)
                return (left < 595.1520 + 2.9880) ? 97 : 98;
            else if (left > 601.1280 && left < 607.1760)
                return (left < 601.1280 + 3.0240) ? 98 : 99;
            else if (left > 607.1760 && left < 613.2240)
                return (left < 607.1760 + 3.0240) ? 99 : 100;
            else if (left > 613.2240 && left < 619.2000)
                return (left < 613.2240 + 2.9880) ? 100 : 101;
            else if (left > 619.2000 && left < 625.2480)
                return (left < 619.2000 + 3.0240) ? 101 : 102;
            else if (left > 625.2480 && left < 631.2240)
                return (left < 625.2480 + 2.9880) ? 102 : 103;
            else if (left > 631.2240 && left < 637.2000)
                return (left < 631.2240 + 2.9880) ? 103 : 104;
            else if (left > 637.2000 && left < 643.2480)
                return (left < 637.2000 + 3.0240) ? 104 : 105;
            else if (left > 643.2480 && left < 649.2960)
                return (left < 643.2480 + 3.0240) ? 105 : 106;
            else if (left > 649.2960 && left < 655.2720)
                return (left < 649.2960 + 2.9880) ? 106 : 107;
            else if (left > 655.2720 && left < 661.2480)
                return (left < 655.2720 + 2.9880) ? 107 : 108;
            else if (left > 661.2480 && left < 667.2960)
                return (left < 661.2480 + 3.0240) ? 108 : 109;
            else if (left > 667.2960 && left < 673.2720)
                return (left < 667.2960 + 2.9880) ? 109 : 110;
            else if (left > 673.2720 && left < 679.3200)
                return (left < 673.2720 + 3.0240) ? 110 : 111;
            else if (left > 679.3200 && left < 685.3680)
                return (left < 679.3200 + 3.0240) ? 111 : 112;
            else if (left > 685.3680 && left < 691.3440)
                return (left < 685.3680 + 2.9880) ? 112 : 113;
            else if (left > 691.3440 && left < 697.3200)
                return (left < 691.3440 + 2.9880) ? 113 : 114;
            else if (left > 697.3200 && left < 703.3680)
                return (left < 697.3200 + 3.0240) ? 114 : 115;
            else if (left > 703.3680 && left < 709.4160)
                return (left < 703.3680 + 3.0240) ? 115 : 116;
            else if (left > 709.4160 && left < 715.3920)
                return (left < 709.4160 + 2.9880) ? 116 : 117;
            else if (left > 715.3920 && left < 721.3680)
                return (left < 715.3920 + 2.9880) ? 117 : 118;
            else if (left > 721.3680 && left < 727.4160)
                return (left < 721.3680 + 3.0240) ? 118 : 119;
            else if (left > 727.4160 && left < 733.3920)
                return (left < 727.4160 + 2.9880) ? 119 : 120;
            else if (left > 733.3920 && left < 739.4400)
                return (left < 733.3920 + 3.0240) ? 120 : 121;
            else if (left > 739.4400 && left < 745.4880)
                return (left < 739.4400 + 3.0240) ? 121 : 122;
            else if (left > 745.4880 && left < 751.4640)
                return (left < 745.4880 + 2.9880) ? 122 : 123;
            else if (left > 751.4640 && left < 757.4400)
                return (left < 751.4640 + 2.9880) ? 123 : 124;
            else if (left > 757.4400 && left < 763.4880)
                return (left < 757.4400 + 3.0240) ? 124 : 125;
            else if (left > 763.4880 && left < 769.4640)
                return (left < 763.4880 + 2.9880) ? 125 : 126;
            else if (left > 769.4640 && left < 775.5120)
                return (left < 769.4640 + 3.0240) ? 126 : 127;
            else if (left > 775.5120 && left < 781.5600)
                return (left < 775.5120 + 3.0240) ? 127 : 128;
            else if (left > 781.5600 && left < 787.5360)
                return (left < 781.5600 + 2.9880) ? 128 : 129;
            else if (left > 787.5360 && left < 793.5120)
                return (left < 787.5360 + 2.9880) ? 129 : 130;
            else if (left > 793.5120 && left < 799.5600)
                return (left < 793.5120 + 3.0240) ? 130 : 131;
            else if (left > 799.5600 && left < 805.6080)
                return (left < 799.5600 + 3.0240) ? 131 : 132;
            else if (left > 805.6080 && left < 811.5840)
                return (left < 805.6080 + 2.9880) ? 132 : 133;
            else if (left > 811.5840 && left < 817.6320)
                return (left < 811.5840 + 3.0240) ? 133 : 134;
            else if (left > 817.6320 && left < 823.6080)
                return (left < 817.6320 + 2.9880) ? 134 : 135;
            else if (left > 823.6080 && left < 829.6560)
                return (left < 823.6080 + 3.0240) ? 135 : 136;
            else if (left > 829.6560 && left < 835.6320)
                return (left < 829.6560 + 2.9880) ? 136 : 137;
            else if (left > 835.6320 && left < 841.6080)
                return (left < 835.6320 + 2.9880) ? 137 : 138;
            else if (left > 841.6080 && left < 847.6560)
                return (left < 841.6080 + 3.0240) ? 138 : 139;
            else if (left > 847.6560 && left < 853.6320)
                return (left < 847.6560 + 2.9880) ? 139 : 140;
            else if (left > 853.6320 && left < 859.6800)
                return (left < 853.6320 + 3.0240) ? 140 : 141;
            else if (left > 859.6800 && left < 865.7280)
                return (left < 859.6800 + 3.0240) ? 141 : 142;
            else if (left > 865.7280 && left < 871.7040)
                return (left < 865.7280 + 2.9880) ? 142 : 143;
            else if (left > 871.7040 && left < 877.6800)
                return (left < 871.7040 + 2.9880) ? 143 : 144;
            else if (left > 877.6800 && left < 883.7280)
                return (left < 877.6800 + 3.0240) ? 144 : 145;
            else if (left > 883.7280 && left < 889.7040)
                return (left < 883.7280 + 2.9880) ? 145 : 146;
            else if (left > 889.7040 && left < 895.7520)
                return (left < 889.7040 + 3.0240) ? 146 : 147;
            else if (left > 895.7520 && left < 901.8000)
                return (left < 895.7520 + 3.0240) ? 147 : 148;
            else if (left > 901.8000 && left < 907.7760)
                return (left < 901.8000 + 2.9880) ? 148 : 149;
            else if (left > 907.7760 && left < 913.7520)
                return (left < 907.7760 + 2.9880) ? 149 : 150;
            else if (left > 913.7520 && left < 919.8000)
                return (left < 913.7520 + 3.0240) ? 150 : 151;
            else if (left > 919.8000 && left < 925.7760)
                return (left < 919.8000 + 2.9880) ? 151 : 152;
            else if (left > 925.7760 && left < 931.8240)
                return (left < 925.7760 + 3.0240) ? 152 : 153;
            else if (left > 931.8240 && left < 937.8720)
                return (left < 931.8240 + 3.0240) ? 153 : 154;
            else if (left > 937.8720 && left < 943.8480)
                return (left < 937.8720 + 2.9880) ? 154 : 155;
            else if (left > 943.8480 && left < 949.8960)
                return (left < 943.8480 + 3.0240) ? 155 : 156;
            else if (left > 949.8960 && left < 955.8720)
                return (left < 949.8960 + 2.9880) ? 156 : 157;
            else if (left > 955.8720 && left < 961.8480)
                return (left < 955.8720 + 2.9880) ? 157 : 158;
            else if (left > 961.8480 && left < 967.8960)
                return (left < 961.8480 + 3.0240) ? 158 : 159;
            else if (left > 967.8960 && left < 973.8720)
                return (left < 967.8960 + 2.9880) ? 159 : 160;
            else if (left > 973.8720 && left < 979.9200)
                return (left < 973.8720 + 3.0240) ? 160 : 161;
            else if (left > 979.9200 && left < 985.8960)
                return (left < 979.9200 + 2.9880) ? 161 : 162;
            else if (left > 985.8960 && left < 991.9440)
                return (left < 985.8960 + 3.0240) ? 162 : 163;
            else if (left > 991.9440 && left < 997.9200)
                return (left < 991.9440 + 2.9880) ? 163 : 164;
            else if (left > 997.9200 && left < 1003.9680)
                return (left < 997.9200 + 3.0240) ? 164 : 165;
            else if (left > 1003.9680 && left < 1010.0160)
                return (left < 1003.9680 + 3.0240) ? 165 : 166;
            else if (left > 1010.0160 && left < 1015.9920)
                return (left < 1010.0160 + 2.9880) ? 166 : 167;
            else if (left > 1015.9920 && left < 1022.0400)
                return (left < 1015.9920 + 3.0240) ? 167 : 168;
            else if (left > 1022.0400 && left < 1028.0160)
                return (left < 1022.0400 + 2.9880) ? 168 : 169;
            else if (left > 1028.0160 && left < 1033.9920)
                return (left < 1028.0160 + 2.9880) ? 169 : 170;
            else if (left > 1033.9920 && left < 1040.0400)
                return (left < 1033.9920 + 3.0240) ? 170 : 171;
            else if (left > 1040.0400 && left < 1046.0160)
                return (left < 1040.0400 + 2.9880) ? 171 : 172;
            else if (left > 1046.0160 && left < 1052.0640)
                return (left < 1046.0160 + 3.0240) ? 172 : 173;
            else if (left > 1052.0640 && left < 1058.1120)
                return (left < 1052.0640 + 3.0240) ? 173 : 174;
            else if (left > 1058.1120 && left < 1064.0880)
                return (left < 1058.1120 + 2.9880) ? 174 : 175;
            else if (left > 1064.0880 && left < 1070.1360)
                return (left < 1064.0880 + 3.0240) ? 175 : 176;
            else if (left > 1070.1360 && left < 1076.1120)
                return (left < 1070.1360 + 2.9880) ? 176 : 177;
            else if (left > 1076.1120 && left < 1082.0880)
                return (left < 1076.1120 + 2.9880) ? 177 : 178;
            else if (left > 1082.0880 && left < 1088.1360)
                return (left < 1082.0880 + 3.0240) ? 178 : 179;
            else if (left > 1088.1360 && left < 1094.1120)
                return (left < 1088.1360 + 2.9880) ? 179 : 180;
            else if (left > 1094.1120 && left < 1100.1600)
                return (left < 1094.1120 + 3.0240) ? 180 : 181;
            else if (left > 1100.1600 && left < 1106.2080)
                return (left < 1100.1600 + 3.0240) ? 181 : 182;
            else if (left > 1106.2080 && left < 1112.1840)
                return (left < 1106.2080 + 2.9880) ? 182 : 183;
            else if (left > 1112.1840 && left < 1118.2320)
                return (left < 1112.1840 + 3.0240) ? 183 : 184;
            else if (left > 1118.2320 && left < 1124.2080)
                return (left < 1118.2320 + 2.9880) ? 184 : 185;
            else if (left > 1124.2080 && left < 1130.2560)
                return (left < 1124.2080 + 3.0240) ? 185 : 186;
            else if (left > 1130.2560 && left < 1136.2320)
                return (left < 1130.2560 + 2.9880) ? 186 : 187;
            else if (left > 1136.2320 && left < 1142.2800)
                return (left < 1136.2320 + 3.0240) ? 187 : 188;
            else if (left > 1142.2800 && left < 1148.2560)
                return (left < 1142.2800 + 2.9880) ? 188 : 189;
            else if (left > 1148.2560 && left < 1154.2320)
                return (left < 1148.2560 + 2.9880) ? 189 : 190;
            else if (left > 1154.2320 && left < 1160.2800)
                return (left < 1154.2320 + 3.0240) ? 190 : 191;
            else if (left > 1160.2800 && left < 1166.2560)
                return (left < 1160.2800 + 2.9880) ? 191 : 192;
            else if (left > 1166.2560 && left < 1172.3040)
                return (left < 1166.2560 + 3.0240) ? 192 : 193;
            else if (left > 1172.3040 && left < 1178.2800)
                return (left < 1172.3040 + 2.9880) ? 193 : 194;
            else if (left > 1178.2800 && left < 1184.3280)
                return (left < 1178.2800 + 3.0240) ? 194 : 195;
            else if (left > 1184.3280 && left < 1190.3040)
                return (left < 1184.3280 + 2.9880) ? 195 : 196;
            else if (left > 1190.3040 && left < 1196.3520)
                return (left < 1190.3040 + 3.0240) ? 196 : 197;
            else if (left > 1196.3520 && left < 1202.3280)
                return (left < 1196.3520 + 2.9880) ? 197 : 198;
            else if (left > 1202.3280 && left < 1208.3760)
                return (left < 1202.3280 + 3.0240) ? 198 : 199;
            else if (left > 1208.3760 && left < 1214.4240)
                return (left < 1208.3760 + 3.0240) ? 199 : 200;
            else if (left > 1214.4240 && left < 1220.4000)
                return (left < 1214.4240 + 2.9880) ? 200 : 201;
            else if (left > 1220.4000 && left < 1226.4480)
                return (left < 1220.4000 + 3.0240) ? 201 : 202;
            else if (left > 1226.4480 && left < 1232.4240)
                return (left < 1226.4480 + 2.9880) ? 202 : 203;
            else if (left > 1232.4240 && left < 1238.4720)
                return (left < 1232.4240 + 3.0240) ? 203 : 204;
            else if (left > 1238.4720 && left < 1244.4480)
                return (left < 1238.4720 + 2.9880) ? 204 : 205;
            else if (left > 1244.4480 && left < 1250.4960)
                return (left < 1244.4480 + 3.0240) ? 205 : 206;
            else if (left > 1250.4960 && left < 1256.4720)
                return (left < 1250.4960 + 2.9880) ? 206 : 207;
            else if (left > 1256.4720 && left < 1262.5200)
                return (left < 1256.4720 + 3.0240) ? 207 : 208;
            else if (left > 1262.5200 && left < 1268.4960)
                return (left < 1262.5200 + 2.9880) ? 208 : 209;
            else if (left > 1268.4960 && left < 1274.4720)
                return (left < 1268.4960 + 2.9880) ? 209 : 210;
            else if (left > 1274.4720 && left < 1280.5200)
                return (left < 1274.4720 + 3.0240) ? 210 : 211;
            else if (left > 1280.5200 && left < 1286.4960)
                return (left < 1280.5200 + 2.9880) ? 211 : 212;
            else if (left > 1286.4960 && left < 1292.5440)
                return (left < 1286.4960 + 3.0240) ? 212 : 213;
            else if (left > 1292.5440 && left < 1298.5200)
                return (left < 1292.5440 + 2.9880) ? 213 : 214;
            else if (left > 1298.5200 && left < 1304.5680)
                return (left < 1298.5200 + 3.0240) ? 214 : 215;
            else if (left > 1304.5680 && left < 1310.5440)
                return (left < 1304.5680 + 2.9880) ? 215 : 216;
            else if (left > 1310.5440 && left < 1316.5920)
                return (left < 1310.5440 + 3.0240) ? 216 : 217;
            else if (left > 1316.5920 && left < 1322.5680)
                return (left < 1316.5920 + 2.9880) ? 217 : 218;
            else if (left > 1322.5680 && left < 1328.6160)
                return (left < 1322.5680 + 3.0240) ? 218 : 219;
            else if (left > 1328.6160 && left < 1334.6640)
                return (left < 1328.6160 + 3.0240) ? 219 : 220;
            else if (left > 1334.6640 && left < 1340.6400)
                return (left < 1334.6640 + 2.9880) ? 220 : 221;
            else if (left > 1340.6400 && left < 1346.6880)
                return (left < 1340.6400 + 3.0240) ? 221 : 222;
            else if (left > 1346.6880 && left < 1352.6640)
                return (left < 1346.6880 + 2.9880) ? 222 : 223;
            else if (left > 1352.6640 && left < 1358.7120)
                return (left < 1352.6640 + 3.0240) ? 223 : 224;
            else if (left > 1358.7120 && left < 1364.6880)
                return (left < 1358.7120 + 2.9880) ? 224 : 225;
            else if (left > 1364.6880 && left < 1370.7360)
                return (left < 1364.6880 + 3.0240) ? 225 : 226;
            else if (left > 1370.7360 && left < 1376.7120)
                return (left < 1370.7360 + 2.9880) ? 226 : 227;
            else if (left > 1376.7120 && left < 1382.7600)
                return (left < 1376.7120 + 3.0240) ? 227 : 228;
            else if (left > 1382.7600 && left < 1388.7360)
                return (left < 1382.7600 + 2.9880) ? 228 : 229;
            else if (left > 1388.7360 && left < 1394.7120)
                return (left < 1388.7360 + 2.9880) ? 229 : 230;
            else if (left > 1394.7120 && left < 1400.7600)
                return (left < 1394.7120 + 3.0240) ? 230 : 231;
            else if (left > 1400.7600 && left < 1406.7360)
                return (left < 1400.7600 + 2.9880) ? 231 : 232;
            else if (left > 1406.7360 && left < 1412.7840)
                return (left < 1406.7360 + 3.0240) ? 232 : 233;
            else if (left > 1412.7840 && left < 1418.7600)
                return (left < 1412.7840 + 2.9880) ? 233 : 234;
            else if (left > 1418.7600 && left < 1424.8080)
                return (left < 1418.7600 + 3.0240) ? 234 : 235;
            else if (left > 1424.8080 && left < 1430.7840)
                return (left < 1424.8080 + 2.9880) ? 235 : 236;
            else if (left > 1430.7840 && left < 1436.8320)
                return (left < 1430.7840 + 3.0240) ? 236 : 237;
            else if (left > 1436.8320 && left < 1442.8080)
                return (left < 1436.8320 + 2.9880) ? 237 : 238;
            else if (left > 1442.8080 && left < 1448.8560)
                return (left < 1442.8080 + 3.0240) ? 238 : 239;
            else if (left > 1448.8560 && left < 1454.8320)
                return (left < 1448.8560 + 2.9880) ? 239 : 240;
            else if (left > 1454.8320 && left < 1460.8800)
                return (left < 1454.8320 + 3.0240) ? 240 : 241;
            else if (left > 1460.8800 && left < 1466.9280)
                return (left < 1460.8800 + 3.0240) ? 241 : 242;
            else if (left > 1466.9280 && left < 1472.9040)
                return (left < 1466.9280 + 2.9880) ? 242 : 243;
            else if (left > 1472.9040 && left < 1478.9520)
                return (left < 1472.9040 + 3.0240) ? 243 : 244;
            else if (left > 1478.9520 && left < 1484.9280)
                return (left < 1478.9520 + 2.9880) ? 244 : 245;
            else if (left > 1484.9280 && left < 1490.9040)
                return (left < 1484.9280 + 2.9880) ? 245 : 246;
            else if (left > 1490.9040 && left < 1496.9520)
                return (left < 1490.9040 + 3.0240) ? 246 : 247;
            else if (left > 1496.9520 && left < 1503.0000)
                return (left < 1496.9520 + 3.0240) ? 247 : 248;
            else if (left > 1503.0000 && left < 1508.9760)
                return (left < 1503.0000 + 2.9880) ? 248 : 249;
            else if (left > 1508.9760 && left < 1515.0240)
                return (left < 1508.9760 + 3.0240) ? 249 : 250;
            else if (left > 1515.0240 && left < 1521.0000)
                return (left < 1515.0240 + 2.9880) ? 250 : 251;
            else if (left > 1521.0000 && left < 1526.9760)
                return (left < 1521.0000 + 2.9880) ? 251 : 252;
            else if (left > 1526.9760 && left < 1533.0240)
                return (left < 1526.9760 + 3.0240) ? 252 : 253;
            else if (left > 1533.0240 && left < 1539.0720)
                return (left < 1533.0240 + 3.0240) ? 253 : 254;
            else if (left > 1539.0720 && left < 1545.0480)
                return (left < 1539.0720 + 2.9880) ? 254 : 255;
            else if (left > 1545.0480 && left < 1551.0240)
                return (left < 1545.0480 + 2.9880) ? 255 : 256;
            else if (left > 1551.0240 && left < 1557.0720)
                return (left < 1551.0240 + 3.0240) ? 256 : 257;
            else if (left > 1557.0720 && left < 1563.0480)
                return (left < 1557.0720 + 2.9880) ? 257 : 258;
            else if (left > 1563.0480 && left < 1569.0960)
                return (left < 1563.0480 + 3.0240) ? 258 : 259;
            else if (left > 1569.0960 && left < 1575.0720)
                return (left < 1569.0960 + 2.9880) ? 259 : 260;
            else if (left > 1575.0720 && left < 1581.1200)
                return (left < 1575.0720 + 3.0240) ? 260 : 261;
            else if (left > 1581.1200 && left < 1587.1680)
                return (left < 1581.1200 + 3.0240) ? 261 : 262;
            else if (left > 1587.1680 && left < 1593.1440)
                return (left < 1587.1680 + 2.9880) ? 262 : 263;
            else if (left > 1593.1440 && left < 1599.1200)
                return (left < 1593.1440 + 2.9880) ? 263 : 264;
            else
                return -1;
        }
    }
}
