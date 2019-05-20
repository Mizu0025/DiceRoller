using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller
{
    class DiceDataStore
    {
        Random random = new Random();
        int diceSides = 0;
        int diceNumber = 0;
        string phrase;
        string response;
        string responseYes = "y";
        string responseNo = "n";

        public DiceDataStore()
        {
            response = ResponseValidator.CheckIfValidString("Do you want to roll dice (Y/N)?", responseYes, responseNo);
            while (response == responseYes)
            {
                phrase = ResponseValidator.CheckIfAnswerEntered("Enter your dice roll (eg; 1d8)");
                string[] words = phrase.Split('d');

                for (int i = 0; i < words.Length; i++)
                {
                    if (i == 0)
                    {
                        diceNumber = int.Parse(words[i]);
                    }
                    else
                    {
                        diceSides = int.Parse(words[i]);
                    }
                }

                for (int i = 0; i < diceNumber; i++)
                {
                    int diceGen = random.Next(1, diceSides);
                    Console.Write(diceGen + " ");
                }
                Console.WriteLine();
                Console.Read();
            }
        }
    }
}
