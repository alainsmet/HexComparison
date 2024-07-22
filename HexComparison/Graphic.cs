using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexComparison
{
    public partial class Graphic : Form
    {

        private int marginTopBottom = 50;
        private int marginLeftRight = 50;
        private double minLineHeight = 0.5;
        private List<Tuple<bool, uint, uint>> listOfBlocks = new List<Tuple<bool, uint, uint>>();

        private uint GetStartAddress()
        {
            uint startAddress = uint.MaxValue;
            foreach (Tuple<bool, uint, uint> block in listOfBlocks)
            {
                if (block.Item2 <= startAddress)
                {
                    startAddress = block.Item2;
                }
            }
            return startAddress;
        }

        private uint GetEndAddress()
        {
            uint endAddress = 0;
            foreach (Tuple<bool, uint, uint> block in listOfBlocks)
            {
                if (endAddress <= (block.Item2 + block.Item3 - 1))
                {
                    endAddress = block.Item2 + block.Item3 - 1;
                }
            }
            return endAddress;
        }

        private double GetDataLineHeight()
        {
            uint startAddress = GetStartAddress();
            uint endAddress = GetEndAddress();
            int nbOfLines = Convert.ToInt32(Math.Ceiling((double)(endAddress - startAddress) / Properties.Settings.Default.numberOfBytesPerLine));

            return (double)(pictureBox1.ClientSize.Height - 2 * marginTopBottom) / nbOfLines;
        }

        public Graphic()
        {
            InitializeComponent();
        }

        private void Graphic_Paint(object sender, PaintEventArgs e)
        {
            uint startAddress = GetStartAddress();
            uint endAddress = GetEndAddress();
            double lineHeight = Math.Max(minLineHeight, GetDataLineHeight());
            Size newPictureSize = pictureBox1.ClientSize;
            newPictureSize.Height = Convert.ToInt32(lineHeight * Math.Ceiling((double)(endAddress - startAddress) / Properties.Settings.Default.numberOfBytesPerLine));
            newPictureSize.Height += 2 * marginTopBottom;
            pictureBox1.Size = newPictureSize;
            int blockWidth = (pictureBox1.ClientSize.Width - 3 * marginLeftRight) / 2;

            Graphics graphics = e.Graphics;

            Pen pen = new Pen(Color.Black, 1);
            Pen pen2 = new Pen(Color.Black, 2);
            Font addressFont = new Font("Consolas", 10);
            Brush brush = new SolidBrush(Color.Black);

            foreach (Tuple<bool, uint, uint> block in listOfBlocks)
            {
                int x = marginLeftRight;
                if (block.Item1 == false)
                {
                    x += blockWidth + marginLeftRight;
                }
                int y = marginTopBottom + Convert.ToInt32(Math.Ceiling((double)(block.Item2 - startAddress) / Properties.Settings.Default.numberOfBytesPerLine) * lineHeight);
                int blockHeight = Convert.ToInt32(Math.Ceiling((double)block.Item3 / Properties.Settings.Default.numberOfBytesPerLine) * lineHeight);

                string addressString = block.Item2.ToString("X8");
                graphics.DrawString(addressString, addressFont, brush, marginLeftRight, y - 20);
                graphics.DrawLine(pen2, marginLeftRight, y, marginLeftRight + 20, y);

                addressString = (block.Item2 + block.Item3).ToString("X8");
                graphics.DrawString(addressString, addressFont, brush, marginLeftRight, y + blockHeight - 20);
                graphics.DrawLine(pen2, marginLeftRight, y + blockHeight, marginLeftRight + 20, y + blockHeight);
                graphics.DrawRectangle(pen, x, y, blockWidth, blockHeight);
            }

            pen = new Pen(Color.Black, 2);

            pen.Dispose();
        }

        private void Graphic_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            string refFilePath = Helper.GetFilePath(true);
            string comparedFilePath = Helper.GetFilePath(false);
            List<HexFile> files = Helper.GetHexFileList();
            foreach (HexFile file in files)
            {
                if (file.FilePath == refFilePath)
                {
                    foreach (DataBlock block in file.Blocks)
                    {
                        listOfBlocks.Add(new Tuple<bool, uint, uint>(true, block.BlockStartAddressUInt32, block.BytesDataLength));
                    }
                }
                else if (file.FilePath == comparedFilePath)
                {
                    foreach (DataBlock block in file.Blocks)
                    {
                        listOfBlocks.Add(new Tuple<bool, uint, uint>(false, block.BlockStartAddressUInt32, block.BytesDataLength));
                    }
                }
            }
        }

        private void Graphic_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}
