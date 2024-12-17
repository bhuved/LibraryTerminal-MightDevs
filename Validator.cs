using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTerminal_MightyDevs
{
    internal static class Validator
    {
        public static string IsValidString()
        {
            string userResponse = "";
            while(true)
            {
                userResponse = Console.ReadLine().ToLower().Trim();
                if (userResponse == "t" || userResponse == "a" || userResponse == "q")
                {
                    return userResponse;
                }
                else
                {
                    Console.WriteLine("Invalid string. Enter T or A");
                }
            }
        }
    }
}
