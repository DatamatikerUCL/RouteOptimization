using RelateITWorking.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelateITWorking.Helpers
{
    public class ConvertKommaToDot : IHelperConverter
    {

        public string IHelperConverter.ConvertKommaToDot(double value)
        {
            string tempDouble = "";
       
            tempDouble = value.ToString();
            tempDouble = tempDouble.Replace(",", ".");
          

            return tempDouble;
        }
    }
}
