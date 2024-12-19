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

        public static string IsValidIndex(int indexCount)
        {
            string userResponse = "";
            while (true)
            {
                userResponse = Console.ReadLine().ToLower().Trim();
                try
                {
                    if (userResponse == "s")
                    {
                        return userResponse;
                    }
                    else
                    {
                        int userIndexNo = int.Parse(userResponse);
                        if (userIndexNo <= indexCount && userIndexNo > 0)
                        {
                            return userResponse;
                            //Console.WriteLine("Enter Valid Index No :");
                        }
                        else
                        {
                            Console.WriteLine("Index No. not exist. Enter Valid Index to Select book, S - Search Again");
                        }
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid entry. Enter Index to Select book, S - Search Again");
                }
            }
        }

        public static string IsValidCheckOut()
        {
            string userResponse = "";
            while (true)
            {
                userResponse = Console.ReadLine().ToLower().Trim();
                if (userResponse == "s" || userResponse == "r" || userResponse == "c")
                {
                    return userResponse;
                }
                else
                {
                    Console.Write("Invalid entry. Enter R-Return, C-Checkout, S-Search Again :");
                }
            }
        }

        public static string IsEmptySearch()
        {
            string userResponse = "";
            while (true)
            {
                userResponse = Console.ReadLine().ToLower().Trim();
                if (userResponse == "s")
                {
                    return userResponse;
                }
                else
                {
                    Console.Write("Invalid entry. Enter S-Search Again :");
                }
            }
        }
    }
}
