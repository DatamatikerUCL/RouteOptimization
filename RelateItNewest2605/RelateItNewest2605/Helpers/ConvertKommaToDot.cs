using RelateItNewest2605.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelateITWorking.Helpers
{
    public class ConvertKommaToDot : IHelperConverter
    {

        public string ConvertKommaToDots(double value)
        {
            string tempDouble = "";

            tempDouble = value.ToString();
            tempDouble = tempDouble.Replace(",", ".");


            return tempDouble;
        }
    }
}
