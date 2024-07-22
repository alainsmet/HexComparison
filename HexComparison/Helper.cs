using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data;

namespace HexComparison
{
    internal class Helper
    {
        public static bool IsHexadecimal(string input)
        {
            return uint.TryParse(input, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _);
        }

        public static bool IsPrintableAscii(byte value)
        {
            return value >= 32 && value <= 126;
        }

        public static string ConvertHexListToCharString(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in list)
            {
                if (str.Length == 0) { sb.Append('.'); }
                if (str.Length > 2) { sb.Append('.'); }
                if (!IsHexadecimal(str)) { sb.Append('.'); }
                if (byte.TryParse(str, System.Globalization.NumberStyles.HexNumber, null, out byte outputByte))
                {
                    if (IsPrintableAscii(outputByte))
                    {
                        sb.Append((char)outputByte);
                    } else
                    { 
                        sb.Append(".");
                    }
                } else
                {
                    sb.Append('.');
                }
            }
            return sb.ToString();
        }

        public static string ConvertByteListToCharString(List<byte> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte dataByte in list)
            {
                if (IsPrintableAscii(dataByte))
                {
                    sb.Append((char)dataByte);
                }
                else
                {
                    sb.Append(".");
                }
            }
            return sb.ToString();
        }

        public static string GetFilePath(bool isReference)
        {
            string filePath = string.Empty;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.GetType() == typeof(MainForm))
                {
                    MainForm mainForm = (MainForm)openForm;
                    Control[] foundControl;
                    if (isReference)
                    {
                        foundControl = mainForm.Controls.Find("tbReferenceFile", true);
                    } else
                    {
                        foundControl = mainForm.Controls.Find("tbComparedFile", true);
                    }
                    if (foundControl.Length > 0) 
                    { 
                        System.Windows.Forms.TextBox textBox = (TextBox)foundControl[0];
                        filePath = textBox.Text;
                    }
                    break;
                }
            }
            return filePath;
        }

        public static List<HexFile> GetHexFileList()
        {
            List<HexFile> hexFiles = new List<HexFile>();
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.GetType() == typeof(MainForm))
                {
                    MainForm mainForm = (MainForm)openForm;
                    hexFiles = mainForm.ListOfFiles;
                    break;
                }
            }
            return hexFiles;
        }
    }
}
