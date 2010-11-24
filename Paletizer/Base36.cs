using System;
using System.Collections.Generic;
using System.Text;

namespace Paletizer
{
    public class Base36
    {

        public static char[] base36chars = 
                                    { '0', '1', '2', '3' , '4' , '5', 
                                      '6', '7', '8', '9', 'A', 'B', 'C', 
                                      'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 
                                      'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
                                      'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };



        public static long getB36Index(char token)
        {
            long _result = -1;
            if (token < 'A')
            {
                _result = long.Parse(token.ToString());
            }
            else if (token <= 'Z')
            {
                _result = 10 + (token - 'A');
            }
            return _result;
        }

        public static string encodeBase36(long decimal_number)
        {
            string encoded_result = "";

            long moduo = 0;
            long base10_value = decimal_number;

            while (true)
            {
                if (base10_value > 36)
                {

                    moduo = base10_value % 36;
                    encoded_result += Base36.base36chars[moduo] + "";
                    base10_value = (long)(base10_value / 36);
                }
                else
                {
                    encoded_result += Base36.base36chars[base10_value] + "";
                    base10_value = 0;
                    break;
                }
            }

            string _result = "";
            for (int i = encoded_result.Length - 1; i >= 0; i--)
            {
                _result += encoded_result[i];
            }

            return _result;
        }

        public static long decodeBase36(string base36_number)
        {
            long _result = 0;
            long multiplier = 1;
            for (int i = base36_number.Length - 1; i >= 0; i--)
            {
                long fraction = Base36.getB36Index(base36_number[i]);

                _result += fraction * multiplier;

                multiplier *= 36;
            }

            return _result;
        }

    }
}
