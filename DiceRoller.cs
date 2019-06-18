using System;

namespace DiceRoller
{
    public class DiceRoller
    {
        static void Main(string[] args)
        {
            DiceDataStore diceDataStore;
            ResponseValidator responseValidator = new ResponseValidator();
            string response;
            string responseYes = "y";
            string responseNo = "n";
            //use args to assign values to diceSides & diceNumber when running program from commandline
            //if args[] != "" then skip asking for input
            //learn what is at each args[] index, so as to know where Phrase shall be found when entering input from commandline

            diceDataStore = new DiceDataStore();
            diceDataStore.Display();

            //response = responseValidator.CheckIfValidString("Do you want to roll dice (Y/N)?", responseYes, responseNo);
            //while (response == responseYes)
            //{
            //    try
            //    {
            //        diceDataStore = new DiceDataStore();
            //        diceDataStore.Display();
            //    }
            //    catch(ArgumentOutOfRangeException)
            //    {
            //        Console.WriteLine("Please enter numbers above 0 for both how many times you plan to roll, and how many sides each dice has (eg; 1d8)");
            //    }
            //    catch(FormatException)
            //    {
            //        Console.WriteLine("Please enter the command in the correct format (eg; 1d8, 1*100, 1d8+10)");
            //    }
            //    catch(Exception generalError)
            //    {
            //        Console.WriteLine(generalError.Message);
            //    }
            //}
        }
    }
}
