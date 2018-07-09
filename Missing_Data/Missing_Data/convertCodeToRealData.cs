using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Data
{
    class convertCodeToRealData
    {
        public static float checkNameOfAtrributeForConvert(string name, float value)
        {
            float result = 0;

            if (name.Equals("DustStorm"))
                result = convertDustStorm(value);

            else if (name.Equals("SuspendDust"))
                result = convertSuspendedDust(value);

            else if (name.Equals("RisingDust"))
                result = convertRisingDust(value);

            else if (name.Equals("Rain"))
                result = convertRain(value);

            else if (name.Equals("SunShine"))
                result = convertSunShine(value);

            else if (name.Equals("DryTemperature"))
                result = convertDryTemp(value);

            else if (name.Equals("MaxTemperature"))
                result = convertMaxTemp( value);

            else if (name.Equals("MinTemperature"))
                result = convertMinTemp(value);

            else if (name.Equals("Humidity"))
                result = convertHumidity(value);

            else if (name.Equals("Evaporation"))
                result = convertEvaporation( value);

            else if (name.Equals("Pressure"))
                result = convertPressure( value);


            return result;
        }
        public static float convertPressure( float value)
        {

            if (value == 1)
                return new Random().Next(995,1003);
            else if (value == 2 )
                return new Random().Next(1003,1011);
            else if (value == 3)
                return new Random().Next(1011,1019);
            else
                return new Random().Next(1019, 1027);
        }
        public static float convertDryTemp( float value)
        {

            if (value == 1)
                return new Random().Next(5, 12);
            else if (value == 2)
                return new Random().Next(12, 19);
            else if (value == 3)
                return new Random().Next(19, 26);
            else if (value == 4)
                return new Random().Next(26, 33);
            else
                return new Random().Next(33, 40);
        }
        public static float convertMaxTemp( float value)
        {

            if (value == 1)
                return new Random().Next(12, 19);
            else if (value == 2)
                return new Random().Next(19, 26);
            else if (value == 3)
                return new Random().Next(26, 33);
            else if (value == 4)
                return new Random().Next(33, 40);
            else
                return new Random().Next(40, 48);
        }
        public static float convertMinTemp( float value)
        {

            if (value == 1)
                return new Random().Next(0, 7);
            else if (value == 2)
                return new Random().Next(7, 14);
            else if (value == 3)
                return new Random().Next(14, 21);
            else if (value == 4)
                return new Random().Next(21, 28);
            else
                return new Random().Next(28, 36);
        }
        public static float convertRain( float value)
        {

            if (value == 0)
                return 0;
            else if (value == 1)
                return new Random().Next(0, 5);
            else if (value == 2)
                return new Random().Next(5, 40);
            else
                return new Random().Next(40, 103);
        }
        public static float convertHumidity( float value)
        {

            if (value == 1)
                return new Random().Next(20, 35);
            else if (value == 2)
                return new Random().Next(36, 51);
            else if (value == 3)
                return new Random().Next(52, 67);
            else
                return new Random().Next(67, 83);
        }
        public static float convertEvaporation( float value)
        {

            if (value == 1)
                return new Random().Next(48, 198);
            else if (value == 2)
                return new Random().Next(198, 338);
            else if (value == 3)
                return new Random().Next(338, 488);
            else
                return new Random().Next(488, 638);
        }
        public static float convertSunShine( float value)
        {

            if (value == 1)
                return new Random().Next(2, 5);
            else if (value == 2)
                return new Random().Next(5, 8);
            else if (value == 3)
                return new Random().Next(8, 11);
            else
                return new Random().Next(11, 14);
        }
        public static float convertDustStorm( float value)
        {

            if (value == 0)
                return 0;
            else if (value == 1)
                return new Random().Next(1, 4);
            else
                return new Random().Next(4, 10);
        }
        public static float convertSuspendedDust( float value)
        {

            if (value == 1)
                return new Random().Next(1, 11);
            else if (value == 2)
                return new Random().Next(12, 22);
            else
                return new Random().Next(22, 33);
        }

        public static float convertRisingDust( float value)
        {

            if (value == 0)
                return 0;
            else if (value == 1)
                return new Random().Next(1, 7);
            else
                return new Random().Next(7, 22);
        }
    }
}
