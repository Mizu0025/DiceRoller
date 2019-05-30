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
        int diceAddition = 0;
        int diceMultiplier = 0;
        string phrase;

        public DiceDataStore()
        {
            phrase = responseValidator.CheckIfAnswerEntered("Enter your dice roll (eg; 1d8, 1*100, 1d8+10):");
            string[] diceSplitter = phrase.Split('d');
            string[] diceAdditionSplitter = phrase.Split('+');
            string[] diceMultiplierSplitter = phrase.Split('*');
            ParseDiceNumbers(diceSplitter);
            ParseDiceAddition(diceAdditionSplitter);
            ParseDiceMultiplier(diceMultiplierSplitter);
            CalculateDice();
        }

        private void ParseDiceNumbers(string[] diceSplitter)
        {
            for (int wordCount = 0; wordCount < diceSplitter.Length; wordCount++)
            {
                if (wordCount == 0)
                {
                    diceNumber = int.Parse(diceSplitter[wordCount]);
                }
                else
                {
                    diceSides = int.Parse(diceSplitter[wordCount]);
                }
            }
        }

        private void ParseDiceAddition(string[] diceAddition)
        {
            
        }

        private void ParseDiceMultiplier(string[] diceMultiplier)
        {
            //code
        }

        private void CalculateDice()
        {
            if(diceNumber == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                for (int i = 0; i < diceNumber; i++)
                {
                    int diceGen = random.Next(1, diceSides);
                    Console.Write(diceGen + " ");
                }
                Console.WriteLine();
            }
        }

        private void Display()
        {
            Console.WriteLine(diceGen + " ");
        }
    }
}
