using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckDigitCalculationTool.Libs
{
    public static class Extentions
    {
        public static byte[] ConvertStringToHexArray(this string input)
        {
            var arrayInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var hexArray = new byte[arrayInput.Length];

            for (int i = 0; i < arrayInput.Length; i++)
            {
                hexArray[i] = Convert.ToByte(arrayInput[i], 16);
            }

            return hexArray;
        }

        public static string ConvertByteArrayToHexString(this byte[] data)
        {
            return string.Join(" ", data.Select(x => x.ToString("X2")));
        }
    }
}
