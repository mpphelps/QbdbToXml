using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.UniSim.Operations.Toolkit.Utilities.Shared_Toolkit_and_Interface_classes.ScadaAdapter
{
    
    public static class ScadaDataFormatter
    {
        /// <summary>
        ///  Scales the value from counts stored in the PLC to engineering unit
        /// </summary>
        /// <param name="value">Unscaled value</param>
        /// <param name="rangeHi">Value high range</param>
        /// <param name="rangeLo">Value low range</param>
        /// <param name="dataFormat">Value data format</param>
        /// <returns>float</returns>
        public static float Scale(float value, float rangeHi, float rangeLo, ScadaDataFormat dataFormat)
        {
            // Data format C16 is meant to be read as raw no scaling
            if (dataFormat == ScadaDataFormat.C16)
                return value;

            long countHi, countLo;
            // todo: handle data format correctly for BCD types
            (countHi, countLo) = GetDataFormatRange(dataFormat);

            // Cap the value if it's outside the count range
            if (value < countLo) value = countLo;
            if (value > countHi) value = countHi;
            // Convert value from value from counts to 0-100% range, than multiply by 0 base EU Range and then add the low range 
            return ((value - countLo) / (countHi - countLo)) * (rangeHi - rangeLo) + rangeLo;
        }

        /// <summary>
        ///  Descales the value from engineering unit to counts stored in the PLC
        /// </summary>
        /// <param name="value">Scaled value</param>
        /// <param name="rangeHi">Value high range</param>
        /// <param name="rangeLo">Value low range</param>
        /// <param name="dataFormat">Value data format</param>
        /// <returns>float</returns>
        public static float Descale(float value, float rangeHi, float rangeLo, ScadaDataFormat dataFormat)
        {
            if (dataFormat == ScadaDataFormat.C16)
                return value;

            long countHi, countLo;
            (countHi, countLo) = GetDataFormatRange(dataFormat);

            return ((value - rangeLo) / (rangeHi - rangeLo)) * (countHi - countLo) + countLo;
        }

        private static (long countHi, long countLo) GetDataFormatRange(ScadaDataFormat dataFormat)
        {
            long countHi;
            long countLo;
            switch (dataFormat)
            {
                case ScadaDataFormat.U4095:
                    countHi = 4095;
                    countLo = 0;
                    break;
                case ScadaDataFormat.U100:
                    countHi = 100;
                    countLo = 0;
                    break;
                case ScadaDataFormat.U999:
                    countHi = 999;
                    countLo = 0;
                    break;
                case ScadaDataFormat.U1023:
                    countHi = 1023;
                    countLo = 0;
                    break;
                case ScadaDataFormat.U9998:
                    countHi = 9998;
                    countLo = 0;
                    break;
                case ScadaDataFormat.U9999:
                    countHi = 9999;
                    countLo = 0;
                    break;
                case ScadaDataFormat.S9999:
                    countHi = 9999;
                    countLo = -9999;
                    break;
                case ScadaDataFormat.U8B:
                    countHi = 255;
                    countLo = 0;
                    break;
                case ScadaDataFormat.S8B:
                    countHi = 127;
                    countLo = -128;
                    break;
                case ScadaDataFormat.U14B:
                    countHi = 16383;
                    countLo = 0;
                    break;
                case ScadaDataFormat.U15B:
                    countHi = 32767;
                    countLo = 0;
                    break;
                case ScadaDataFormat.U16B:
                    countHi = 65535;
                    countLo = 0;
                    break;
                case ScadaDataFormat.S16B:
                    countHi = 32767;
                    countLo = -32768;
                    break;
                case ScadaDataFormat.U32B:
                case ScadaDataFormat.U32BS:
                case ScadaDataFormat.U32BB:
                case ScadaDataFormat.U32BSB:
                    countHi = 4294967295;
                    countLo = 0;
                    break;
                case ScadaDataFormat.S32B:
                case ScadaDataFormat.S32BS:
                case ScadaDataFormat.S32BB:
                case ScadaDataFormat.S32BSB:
                    countHi = 2147483647;
                    countLo = -2147483648;
                    break;
                case ScadaDataFormat.SM020MA:
                case ScadaDataFormat.FSC020MA:
                case ScadaDataFormat.U16B0TO20MA:
                    countHi = 20;
                    countLo = 0;
                    break;
                case ScadaDataFormat.SM420MA:
                case ScadaDataFormat.FSC420MA:
                case ScadaDataFormat.U16B4TO20MA:
                    countHi = 20;
                    countLo = 4;
                    break;
                case ScadaDataFormat.SM05V:
                case ScadaDataFormat.FSC05V:
                case ScadaDataFormat.U16B0TO5V:
                    countHi = 5;
                    countLo = 0;
                    break;
                case ScadaDataFormat.SM15V:
                case ScadaDataFormat.FSC15V:
                case ScadaDataFormat.U16B1TO5V:
                    countHi = 5;
                    countLo = 1;
                    break;
                case ScadaDataFormat.SM010V:
                case ScadaDataFormat.FSC010V:
                case ScadaDataFormat.U16B0TO10V:
                    countHi = 10;
                    countLo = 0;
                    break;
                case ScadaDataFormat.SM210V:
                case ScadaDataFormat.FSC210V:
                case ScadaDataFormat.U16B2TO10V:
                    countHi = 10;
                    countLo = 2;
                    break;
                case ScadaDataFormat.U3BCD:
                    countHi = 999;
                    countLo = 0;
                    break;
                case ScadaDataFormat.U4BCD:
                    countHi = 9999;
                    countLo = 0;
                    break;
                case ScadaDataFormat.U6BCD:
                    countHi = 999999;
                    countLo = 0;
                    break;
                case ScadaDataFormat.U8BCD:
                    countHi = 99999999;
                    countLo = 0;
                    break;
                case ScadaDataFormat.UBCD12:
                    countHi = 409;
                    countLo = 0;
                    break;
                case ScadaDataFormat.UBCD16:
                    countHi = 4095;
                    countLo = 0;
                    break;
                case ScadaDataFormat.D9999:
                    countHi = 9999;
                    countLo = 0;
                    break;
                case ScadaDataFormat.SLC_AI:
                    countHi = 16387;
                    countLo = 3277;
                    break;
                case ScadaDataFormat.SLC_AO:
                    countHi = 31208;
                    countLo = 6242;
                    break;
                default:
                    countHi = 100;
                    countLo = 0;
                    break;
            }

            return (countHi, countLo);
        }

    }
}
