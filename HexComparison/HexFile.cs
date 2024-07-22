using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HexComparison
{
    public class HexFile
    {
        private string _filePath;
        private FileType _recordType;
        private List<DataBlock> _blocks;
        private List<Tuple<int, int>> _listOfDifferences;

        public enum FileType
        {
            S19Record,
            IntelHex
        }
        public string FilePath { get { return _filePath; }  set { _filePath = value; } }
        public FileType RecordType { get { return _recordType; } set { _recordType = value; } }
        public List<DataBlock> Blocks { get { return _blocks; } }

        public int NumberOfLines
        {
            get
            {
                int numberLines = 0;
                foreach (DataBlock block in _blocks)
                {
                    numberLines += block.NumberOfLines;
                }
                return numberLines;
            }
        }

        public List<Tuple<int, int>> ListOfDifferences
        {
            get { return _listOfDifferences; }
        }

        public void AddDataBlock(DataBlock block)
        {
            _blocks.Add(block);
        }

        public void ClearDataBlocks()
        {
            _blocks = new List<DataBlock>();
        }

        public void ClearDataBlocksDifferences()
        {
            foreach (DataBlock block in _blocks)
            {
                block.ClearBlockDifferences();
            }
            _listOfDifferences = new List<Tuple<int, int>>();
        }

        public void CheckFileDifferences(HexFile comparedFile)
        {
            if (comparedFile == null) { return; }
            if (comparedFile.Blocks.Count() == 0) { return; }
            foreach (DataBlock block in Blocks)
            {
                block.CheckDifferences(comparedFile.Blocks);
            }
            _listOfDifferences = GetListOfDifferences();
        }

        public void ReadFile()
        {
            if (!File.Exists(_filePath)) return;
            StreamReader fileReader = new StreamReader(_filePath);

            DataBlock block = new DataBlock();

            while (!fileReader.EndOfStream)
            {
                string line = fileReader.ReadLine();
                if (line == null) return;
                
                if (RecordType == FileType.S19Record)
                {
                    string lineType = line.Substring(0, 2);
                    if (lineType == "S1" || lineType == "S2" || lineType == "S3")
                    {
                        int addressLength = 2 + 2 * Convert.ToInt32(lineType.Substring(1, 1));
                        int dataLength = Convert.ToInt32(line.Substring(2, 2), 16) * 2 - addressLength - 2;
                        string address = line.Substring(4, addressLength);
                        string data = line.Substring(4 + addressLength, dataLength);

                        if (block.StartAddress == string.Empty)
                        {
                            block.StartAddress = address;
                            block.AppendHexData(data);
                        } else if (block.BlockEndAddressUInt32 + 1 == Convert.ToUInt32(address, 16))
                        {
                            block.AppendHexData(data);
                        } else
                        {
                            AddDataBlock(block);
                            block = new DataBlock();
                            block.StartAddress = address;
                            block.AppendHexData(data);
                        }
                    }
                }
            }

            if (block.StartAddress != string.Empty)
            {
                AddDataBlock(block);
            }

            fileReader.Close();
        }

        public string GetDgvRowStartAddress(int dgvRowIndex)
        {
            string dgvRowStartAddress = string.Empty;
            int cumulatedLines = 0;
            foreach (DataBlock block in _blocks)
            {
                cumulatedLines += block.NumberOfLines;
                if (cumulatedLines >= dgvRowIndex + 1)
                {
                    int blockLineIndex = dgvRowIndex - (cumulatedLines - block.NumberOfLines);
                    dgvRowStartAddress = block.LineStartAddress(blockLineIndex);
                    break;
                }
            }
            return dgvRowStartAddress;
        }

        public string GetDgvDataCellValue(int dgvRowIndex, int dgvColDataIndex)
        {
            string cellValue = string.Empty;
            int cumulatedLines = 0;
            foreach (DataBlock block in _blocks)
            {
                cumulatedLines += block.NumberOfLines;
                if (cumulatedLines >= dgvRowIndex + 1)
                {
                    int blockLineIndex = dgvRowIndex - (cumulatedLines - block.NumberOfLines);
                    cellValue = block.CellValue(blockLineIndex, dgvColDataIndex);
                    break;
                }   
            }
            return cellValue;
        }

        public DataBlock.DiffType GetDgvDataCellDiffType(int dgvRowIndex, int dgvColDataIndex)
        {
            DataBlock.DiffType cellDiffType = DataBlock.DiffType.NotEvaluated;
            int cumulatedLines = 0;
            foreach (DataBlock block in _blocks)
            {
                cumulatedLines += block.NumberOfLines;
                if (cumulatedLines >= dgvRowIndex + 1)
                {
                    int blockLineIndex = dgvRowIndex - (cumulatedLines - block.NumberOfLines);
                    cellDiffType = block.CellDiffType(blockLineIndex, dgvColDataIndex);
                    break;
                }
            }
            return cellDiffType;
        }

        public string GetDgvTextViewString(int dgvRowIndex)
        {
            string textViewString = string.Empty;
            int cumulatedLines = 0;
            foreach (DataBlock block in _blocks)
            {
                cumulatedLines += block.NumberOfLines;
                if (cumulatedLines >= dgvRowIndex + 1)
                {
                    int blockLineIndex = dgvRowIndex - (cumulatedLines - block.NumberOfLines);
                    textViewString = block.LineASCIIString(blockLineIndex);
                    break;
                }
            }
            return textViewString;
        }

        public List<Tuple<int,int>> GetListOfDifferences()
        {
            List <Tuple<int, int>> differencesList = new List<Tuple<int, int>>();
            int cumulatedLines = 0;
            foreach (DataBlock block in _blocks)
            {
                DataBlock.DiffType previousDiffType = DataBlock.DiffType.Identical;

                for (int i = 0; i < block.BlockDiffs.Count; i++)
                {
                    DataBlock.DiffType currentDiffType = block.BlockDiffs[i];
                    switch (currentDiffType)
                    {
                        case DataBlock.DiffType.NotFound:
                        case DataBlock.DiffType.Different:
                            if (previousDiffType != currentDiffType)
                            {
                                int currentRowIndex = cumulatedLines + i / Properties.Settings.Default.numberOfBytesPerLine;
                                int currentColumnIndex = i - (i / Properties.Settings.Default.numberOfBytesPerLine) * Properties.Settings.Default.numberOfBytesPerLine + 1;
                                differencesList.Add(new Tuple<int, int>(currentRowIndex, currentColumnIndex));
                            }
                            break;
                    }
                    previousDiffType = currentDiffType;
                }

                cumulatedLines += block.NumberOfLines;
            }
            return differencesList;
        }

        public HexFile(string path)
        { 
            FilePath = path;
            RecordType = FileType.S19Record;
            ClearDataBlocks();
        }
    }
}
