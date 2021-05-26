using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CheckDigitCalculationTool.Models
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _checksumRes;
        public string ChecksumRes
        {
            get { return _checksumRes; }
            set { _checksumRes = value; OnPropertyChanged(nameof(ChecksumRes)); }
        }

        private string _checksumDes;
        public string ChecksumDes
        {
            get { return _checksumDes; }
            set { _checksumDes = value; OnPropertyChanged(nameof(ChecksumDes)); }
        }

        private string _modbusRes;
        public string ModbusRes
        {
            get { return _modbusRes; }
            set { _modbusRes = value; OnPropertyChanged(nameof(ModbusRes)); }
        }

        private string _modbusDes;
        public string ModbusDes
        {
            get { return _modbusDes; }
            set { _modbusDes = value; OnPropertyChanged(nameof(ModbusDes)); }
        }
    }
}
