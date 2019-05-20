using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller
{
    class DiceDataStore
    {
        Random random = new Random();
        ResponseValidator responseValidator = new ResponseValidator();
        int diceSides = 0;
        int diceNumber = 0;
        string phrase;

        public DiceDataStore()
        {
            phrase = responseValidator.CheckIfAnswerEntered("Enter your dice roll (eg; 1d8)");
            string[] words = phrase.Split('d');
            ParseDiceNumbers(words);
            CalculateDice();
        }

        private void ParseDiceNumbers(string[] words)
        {
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
        }

        private void CalculateDice()
        {
            for (int i = 0; i < diceNumber; i++)
            {
                int diceGen = random.Next(1, diceSides);
                Console.Write(diceGen + " ");
            }
            Console.WriteLine();
        }
    }
}
