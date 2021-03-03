using System;
using System.Data;

namespace luckyticket
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool repeat = true;

            Console.WriteLine("please enter your ticket number ");
            do
            {
                string strres = null;
                int fh = 0; //first half
                int sh = 0; //second half
                bool result = false; //result
                bool check = true;
                while (check) //check input number,if it has 4-5 digits, add 0 if number contains an odd number of digits
                {
                    strres = Console.ReadLine();
                    strres=strres.Replace(" ", String.Empty);//ignore spacebar
                    if (strres=="end" || strres=="End"|| strres == "exit") { return; } //repeat or not
                    if (strres.Length > 8 || strres.Length < 4) Console.WriteLine("please enter valid ticket number(4-8 digits) ");
                    else if (strres.Length % 2 != 0) {strres = "0" + strres; Console.WriteLine("0 was added at the beggining of your number"); check = false; }
                    else check = false;
                }
                //transform input number into int array
                int[] res= new int[8];
                int i = 0;
                foreach (char c in strres)
                    { 
                        check = Int32.TryParse(c.ToString(), out res[i]);
                        i++;
                    }
                int counter = strres.Length / 2;
                for (int ii = 0; ii < counter; ii++)//first half sum
                {
                    fh += res[ii];
                }
                for (int ii = counter; ii < strres.Length; ii++) //second half sum
                {
                    sh += res[ii];
                }
                if (fh == sh) { result = true; Console.WriteLine("Congratulations,  your ticket is lucky"); }
                else { result = false; Console.WriteLine("Your ticket is not lucky"); }
                Console.WriteLine("waiting for the the next ticket number (or end to exit)");
            } while (repeat == true);
        }
    }

   }
