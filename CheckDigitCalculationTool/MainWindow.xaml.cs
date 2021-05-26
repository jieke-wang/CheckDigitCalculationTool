using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CheckDigitCalculationTool.Libs;
using CheckDigitCalculationTool.Models;

namespace CheckDigitCalculationTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel model;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = model = new MainWindowViewModel();
        }

        private void btnChecksum_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = model.ChecksumRes.ConvertStringToHexArray();
                var cs = Checksum.GetChecksum(data);

                model.ChecksumDes = $"{data.ConvertByteArrayToHexString()} {cs:X2}";
            }
            catch (Exception)
            {
                MessageBox.Show("请检查你的输入");
            }
        }

        private void btnModbus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = model.ModbusRes.ConvertStringToHexArray();
                var cs = Modbus.CalculateCRC16(data);

                var csBytes = BitConverter.GetBytes(cs);
                Array.Reverse(csBytes);

                model.ModbusDes = $"{data.ConvertByteArrayToHexString()} {csBytes.ConvertByteArrayToHexString()}";
            }
            catch (Exception)
            {
                MessageBox.Show("请检查你的输入");
            }
        }
    }
}
