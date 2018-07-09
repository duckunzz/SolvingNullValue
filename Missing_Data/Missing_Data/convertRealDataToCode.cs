using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Missing_Data
{
    class convertRealDataToCode
    {
        public static float checkNameOfAtrributeForConvert(DataTable data, string name, float value)
        {
            float result = 0;
           
                if (name.Equals("DustStorm"))
                    result = convertDustStorm(data, value);
                    
                else if (name.Equals("SuspendDust"))
                    result = convertSuspendedDust(data, value);
                    
                else if (name.Equals("RisingDust"))
                    result = convertRisingDust(data, value);
                 
                else if (name.Equals("Rain"))
                    result = convertRain(data, value);
                  
                else if (name.Equals("SunShine"))
                    result = convertSunShine(data, value);

                else if (name.Equals("DryTemperature"))
                    result = convertDryTemp(data, value);
                   
                else if (name.Equals("MaxTemperature"))
                    result = convertMaxTemp(data, value);
                    
                else if (name.Equals("MinTemperature"))
                    result = convertMinTemp(data, value);
                   
                else if (name.Equals("Humidity"))
                    result = convertHumidity(data, value);
                    
                else if (name.Equals("Evaporation"))
                    result = convertEvaporation(data, value);
                    
                else if (name.Equals("Pressure"))
                    result = convertPressure(data, value);
                   
            
            return result;
        }
        public static float convertPressure(DataTable data, float value)
        {

            if (value >= 995 && value <= 1003)
                return 1;
            else if (value >= 1003.1 && value <= 1011)
                return 2;
            else if (value >= 1011.1 && value <= 1019)
                return 3;
            else
                return 4;
        }
        public static float convertDryTemp(DataTable data, float value)
        {

            if (value >= 5 && value <= 12)
                return 1;
            else if (value >= 12.1 && value <= 19)
                return 2;
            else if (value >= 19.1 && value <= 26)
                return 3;
            else if (value >= 26.1 && value <= 33)
                return 4;
            else
                return 5;
        }
        public static float convertMaxTemp(DataTable data, float value)
        {

            if (value >= 12 && value <= 19)
                return 1;
            else if (value >= 19.1 && value <= 26)
                return 2;
            else if (value >= 26.1 && value <= 33)
                return 3;
            else if (value >= 33.1 && value <= 40)
                return 4;
            else
                return 5;
        }
        public static float convertMinTemp(DataTable data, float value)
        {

            if (value >= 0 && value <= 7)
                return 1;
            else if (value >= 7.1 && value <= 14)
                return 2;
            else if (value >= 14.1 && value <= 21)
                return 3;
            else if (value >= 21.1 && value <= 28)
                return 4;
            else
                return 5;
        }
        public static float convertRain(DataTable data, float value)
        {

            if (value == 0)
                return 0;
            else if (value >= 0.1 && value <= 5)
                return 1;
            else if (value >= 5.1 && value <= 40)
                return 2;
            else
                return 3;
        }
        public static float convertHumidity(DataTable data, float value)
        {

            if (value >= 20 && value <= 35)
                return 1;
            else if (value >= 36 && value <= 51)
                return 2;
            else if (value >= 52 && value <= 67)
                return 3;
            else
                return 4;
        }
        public static float convertEvaporation(DataTable data, float value)
        {

            if (value >= 48 && value <= 198)
                return 1;
            else if (value >= 198.1 && value <= 338)
                return 2;
            else if (value >= 338.1 && value <= 488)
                return 3;
            else
                return 4;
        }
        public static float convertSunShine(DataTable data, float value)
        {

            if (value >= 2 && value <= 5)
                return 1;
            else if (value >= 5.1 && value <= 8)
                return 2;
            else if (value >= 8.1 && value <= 11)
                return 3;
            else
                return 4;
        }
        public static float convertDustStorm(DataTable data, float value)
        {

            if (value == 0)
                return 0;
            else if (value >= 1 && value <= 4)
                return 1;
            else
                return 2;
        }
        public static float convertSuspendedDust(DataTable data, float value)
        {

            if (value >= 1 && value <= 11)
                return 1;
            else if (value >= 12 && value <= 22)
                return 2;
            else
                return 3;
        }

        public static float convertRisingDust(DataTable data, float value)
        {

            if (value == 0)
                return 0;
            else if (value >= 1 && value <= 7)
                return 1;
            else
                return 2;
        }
    }
}
