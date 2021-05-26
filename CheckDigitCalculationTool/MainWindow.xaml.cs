using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                var data = txtChecksumResFormat.Text.ConvertStringToHexArray();
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
                var data = txtModbusResFormat.Text.ConvertStringToHexArray();
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

        private void txtChecksumRes_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(e);
        }

        private void txtModbusRes_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(e);
        }

        private void HandleKeyDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0:
                case Key.NumPad0:
                case Key.D1:
                case Key.NumPad1:
                case Key.D2:
                case Key.NumPad2:
                case Key.D3:
                case Key.NumPad3:
                case Key.D4:
                case Key.NumPad4:
                case Key.D5:
                case Key.NumPad5:
                case Key.D6:
                case Key.NumPad6:
                case Key.D7:
                case Key.NumPad7:
                case Key.D8:
                case Key.NumPad8:
                case Key.D9:
                case Key.NumPad9:
                case Key.A:
                case Key.B:
                case Key.C:
                case Key.D:
                case Key.E:
                case Key.F:
                    break;
                case Key.Space:
                default:
                    e.Handled = true;
                    return;
            }
        }

        private string FormatString(string res)
        {
            res = Regex.Replace(res, @"\s", string.Empty).ToUpper();
            res = Regex.Replace(res, @"(.{2})", "$1 ").Trim();
            res = Regex.Replace(res, @"([ ]{2,})", " ").Trim();
            return res;
        }

        private void txtChecksumRes_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtChecksumResFormat.Text = FormatString(model.ChecksumRes);
        }

        private void txtModbusRes_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtModbusResFormat.Text = FormatString(model.ModbusRes);
        }
    }
}

// js 校验规则 -- 去空格、加空格
// https://www.cnblogs.com/yeqrblog/p/10711240.html