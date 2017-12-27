using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlShortener
{
    public class Utility
    {
        public long ConvertStringToNumberRepresentation(string input)
        {
            long number = 0;
            byte[] value = Encoding.UTF8.GetBytes(input);
            foreach (var byteNumber in value)
            {
                number += byteNumber;
            }
            return number;
        }

        public string ConvertHashValueBytesToBase64String(byte[] hashValue)
        {
            string base64String = Convert.ToBase64String(hashValue);
            return base64String;
        }

        public byte[] ConvertBase64toHashByte(string base64String)
        {
            byte[] hashValue = Convert.FromBase64String(base64String);
            return hashValue;
        }

        private const string Base62 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Base36 = "0123456789abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Encode the given number into a Base62 string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Encode(long input)
        {
            if (input < 0) throw new ArgumentOutOfRangeException("input", input, "input cannot be negative");

            char[] BaseCharacters = Base62.ToCharArray();
            var result = new Stack<char>();
            while (input != 0)
            {
                result.Push(BaseCharacters[input % 62]);
                input /= 62;
            }
            return new string(result.ToArray());
        }

        /// <summary>
        /// Decode the Base36 Encoded string into a number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Int64 Decode(string input)
        {
            var reversed = input.ToLower().Reverse();
            long result = 0;
            int PowerNumber = 0;
            foreach (char c in reversed)
            {
                result += Base36.IndexOf(c) * (long)Math.Pow(36, PowerNumber);
                PowerNumber++;
            }
            return result;
        }
    }
}