using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IntegerToHex.IntToHex(61453));
            Console.ReadKey();
        }
    }

    public class IntegerToHex
    {
        public static string IntToHex(int value)
        {
            //*****THIS LINE IS DONE FOR TESTING PURPOSES TO ASSERT THAT THE ANSWER IS EQUAL TO THE BUILT IN .NET FUNCTIONALITY FOR INT TO HEX CONVERSION'S ANSWER AT THE END OF THIS METHOD
            string hexValue = value.ToString("X");
            //END TESTING LINES
            // Convert the hex string back to the number //use this for debug.assertion in hextointeger
            // int intAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);

            int quotient = 1;
            int remainder;
            List<int> list = new List<int>();
            string answer = "";
            string thisString;
            char thisChar;
            List<int> listReversed = new List<int>();

            //populate the list with the correct integer values as per the necessary calculations
            while (quotient != 0)
            {
                quotient = value / 16;
                remainder = value % 16;
                list.Add(remainder);
                value = quotient;
            }

            //if a value in the list is greater than 9 then convert it to the apropriate letter
            for (int i = 0; i< list.Count(); i++)
            {
                if(list[i] > 9)
                {
                    int numChar = (list[i] - 10 + 65);
                    list[i] = (char)numChar;
                }
            }
       
            //reverse the list to be in proper hexadecimal order
            for(int i = 0; i < list.Count(); i++)
            {
                listReversed.Add(list[list.Count() - 1 - i]); 
            }
            list = listReversed;

            //concatenate the whole list into a string and then return that string
            foreach (int n in list)
            {
                if (n < 10)
                {
                    thisString = n.ToString();
                }
                else
                {
                    thisChar = (char)n;
                    thisString = thisChar.ToString();
                }
                answer += thisString;  
            }

            Debug.Assert(answer == hexValue);

            return answer;
        }
    }
}