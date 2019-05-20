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

            response = responseValidator.CheckIfValidString("Do you want to roll dice (Y/N)?", responseYes, responseNo);
            while (response == responseYes)
            {
                diceDataStore = new DiceDataStore();
            }
        }
    }
}
