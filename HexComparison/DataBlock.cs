using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexComparison
{
    public class DataBlock
    {
        public enum DiffType
        {
            NotEvaluated,
            NotFound,
            Identical,
            Different
        }
        private string _startAddress;
        private List<byte> _listOfBytes;
        private List<DiffType> _blockDiffs;

        public string StartAddress { get { return _startAddress; } set { _startAddress = value; } }
        public string EndAddress {
            get
            {
                if (BlockEndAddressUInt32 == 0) { return ""; }
                return BlockEndAddressUInt32.ToString("X8");
            } 
        }
        public List<byte> HexDataBuilder { get { return _listOfBytes; }}
        public UInt32 BytesDataLength
        {
            get
            {
                return Convert.ToUInt32(_listOfBytes.Count());
            }
        }
        public UInt32 BlockStartAddressUInt32
        {
            get
            {
                if (string.IsNullOrEmpty(_startAddress)) return 0;
                return Convert.ToUInt32(_startAddress, 16);
            }
        }

        public UInt32 BlockEndAddressUInt32
        {
            get
            {
                if (IsBlockEmpty()) return 0;
                return Convert.ToUInt32(_startAddress, 16) + Convert.ToUInt32(_listOfBytes.Count()) - 1;
            }
        }

        public int NumberOfLines
        {
            get
            {
                if (IsBlockEmpty()) { return 0; }
                return Convert.ToInt32(Math.Ceiling((double)BytesDataLength / Properties.Settings.Default.numberOfBytesPerLine));
            }
        }

        public List<DiffType> BlockDiffs { get { return _blockDiffs; }}

        public void ClearBlockDifferences()
        {
            _blockDiffs = new List<DiffType>();
        }

        public List<string> GetHexDataList()
        {
            List<string> hexList = new List<string>();
            if (_listOfBytes.Count() == 0) { return hexList; }
            foreach (byte dataByte in _listOfBytes)
            {
                hexList.Add(dataByte.ToString("X2"));
            }
            return hexList;
        }

        public void AppendHexData(string hexData)
        {
            for (int i = 0; i < hexData.Length; i = i + 2)
            {
                _listOfBytes.Add(Convert.ToByte(hexData.Substring(i,2), 16));
            }
        }

        public bool IsBlockEmpty()
        {
            if (string.IsNullOrEmpty(_startAddress)) return true;
            if (_listOfBytes.Count() == 0) return true;
            return false;
        }

        public bool ContainsBlock(DataBlock block)
        {
            if (IsBlockEmpty()) return false;
            if (block == null) return false;
            if (block.IsBlockEmpty()) return false;
            if (block.BlockEndAddressUInt32 < BlockStartAddressUInt32) return false;
            if (block.BlockStartAddressUInt32 > BlockEndAddressUInt32) return false;
            return true;
        }

        public bool ContainsAddress(string address)
        {
            if (IsBlockEmpty()) return false;
            if (address == null) return false;
            if (!Helper.IsHexadecimal(address)) return false;
            if (address.Length > 8) return false;
            UInt32 convertedAddress = Convert.ToUInt32(address, 16);
            if (convertedAddress < BlockStartAddressUInt32) return false;
            if (convertedAddress > BlockEndAddressUInt32) return false;
            return true;
        }

        public int LineNumberFoundAddress(string address)
        {
            if (IsBlockEmpty()) { return -1; }
            if (!ContainsAddress(address)) { return -1; }
            if (!Helper.IsHexadecimal(address)) { return -1; }
            UInt32 convertedAddress = Convert.ToUInt32(address, 16);
            UInt32 offset = convertedAddress - BlockStartAddressUInt32 + 1;
            return Convert.ToInt32(Math.Ceiling((double)offset / Properties.Settings.Default.numberOfBytesPerLine));
        }

        public string LineStartAddress(int lineIndex)
        {
            if (lineIndex + 1 > NumberOfLines) { return string.Empty; }
            UInt32 lineStartAddress = BlockStartAddressUInt32 + Convert.ToUInt32(lineIndex * Properties.Settings.Default.numberOfBytesPerLine);
            return lineStartAddress.ToString("X8");
        }

        public string CellValue(int lineIndex, int columnIndex)
        {
            if (lineIndex + 1 > NumberOfLines) { return string.Empty; }
            UInt32 dataCellIndex = Convert.ToUInt32(lineIndex * Properties.Settings.Default.numberOfBytesPerLine + columnIndex);
            if (dataCellIndex > BytesDataLength - 1) { return string.Empty; }
            return _listOfBytes[Convert.ToInt32(dataCellIndex)].ToString("X2");
        }

        public DiffType CellDiffType(int lineIndex, int columnIndex)
        {
            if (_blockDiffs.Count == 0) { return DiffType.NotEvaluated; }
            if (lineIndex + 1 > NumberOfLines) { return DiffType.NotEvaluated; }
            UInt32 dataCellIndex = Convert.ToUInt32(lineIndex * Properties.Settings.Default.numberOfBytesPerLine + columnIndex);
            if (dataCellIndex > BytesDataLength - 1) { return DiffType.NotEvaluated; }
            return _blockDiffs[Convert.ToInt32(dataCellIndex)];
        }

        public string LineASCIIString(int lineIndex)
        {
            if (lineIndex + 1 > NumberOfLines) { return string.Empty; }
            UInt32 startIndex = Convert.ToUInt32(lineIndex * Properties.Settings.Default.numberOfBytesPerLine);
            UInt32 endIndex = startIndex + Convert.ToUInt32(Properties.Settings.Default.numberOfBytesPerLine - 1);
            if (endIndex > BytesDataLength - 1)
            {
                endIndex = BytesDataLength - 1;
            }
            List<byte> lineBytes = _listOfBytes.GetRange(Convert.ToInt32(startIndex), Convert.ToInt32(endIndex - startIndex + 1));
            return Helper.ConvertByteListToCharString(lineBytes);
        }

        public List<DiffType> CheckDifferences(List<DataBlock> blocks)
        {
            _blockDiffs = new List<DiffType>();
            if (IsBlockEmpty() || blocks.Count == 0) { return _blockDiffs; }
            _blockDiffs = Enumerable.Repeat(DiffType.NotFound, _listOfBytes.Count()).ToList();
            foreach (DataBlock block in blocks)
            {
                if (block.ContainsBlock(this))
                {
                    int startOffset = 0;
                    int endOffset = Convert.ToInt32(BytesDataLength);
                    int startOffsetCompared = 0;
                    int endOffsetCompared = Convert.ToInt32(block.BytesDataLength);

                    if (block.BlockStartAddressUInt32 < BlockStartAddressUInt32)
                    {
                        startOffsetCompared = Convert.ToInt32(BlockStartAddressUInt32 - block.BlockStartAddressUInt32);
                    }

                    if (BlockStartAddressUInt32 < block.BlockStartAddressUInt32)
                    {
                        startOffset = Convert.ToInt32(block.BlockStartAddressUInt32 - BlockStartAddressUInt32);
                    }
                    
                    if (block.BlockEndAddressUInt32 < BlockEndAddressUInt32)
                    {
                        endOffset = Convert.ToInt32(endOffset - (BlockEndAddressUInt32 - block.BlockEndAddressUInt32));
                    }

                    if (BlockEndAddressUInt32 < block.BlockEndAddressUInt32)
                    {
                        endOffsetCompared = Convert.ToInt32(endOffsetCompared - (block.BlockEndAddressUInt32 - BlockEndAddressUInt32));
                    }

                    for (int i = startOffset; i < endOffset; i++)
                    {
                        if (HexDataBuilder[i] == block.HexDataBuilder[i - startOffset + startOffsetCompared]) 
                        {
                            _blockDiffs[i] = DiffType.Identical;
                        } else
                        {
                            _blockDiffs[i] = DiffType.Different;
                        }
                    }
                }
            }
            return _blockDiffs;
        }

        public DataBlock()
        {
            _startAddress = string.Empty;
            _listOfBytes = new List<byte>();
            _blockDiffs = new List<DiffType>();
        }
    }
}
