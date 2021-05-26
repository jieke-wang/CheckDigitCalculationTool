using System;
using System.Collections.Generic;
using System.Text;

namespace CheckDigitCalculationTool.Libs
{
    public class Checksum
    {
        public static byte GetChecksum(params byte[] data)
        {
            byte cs = 0;
            for (int i = 0; i < data.Length; i++)
            {
                cs += data[i];
            }

            return cs;
        }
    }
}
