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
        List<int> generatedNumber = new List<int>();
        string phrase;

        public DiceDataStore()
        {
            phrase = responseValidator.CheckIfAnswerEntered("Enter your dice roll (eg; 1d8, 1*100, 1d8+10):");
            string[] diceSplitter = phrase.Split('d', '+', '-', '*');
            ParseDiceNumbers(diceSplitter);
            ParseDiceResultAddition(diceSplitter);
            ParseDiceResultSubtraction(diceSplitter);
            ParseDiceResultMultiplier(diceSplitter);
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
                else if(wordCount == 1)
                {
                    diceSides = int.Parse(diceSplitter[wordCount]);
                }
            }
        }

        private void ParseDiceResultAddition(string[] diceAddition)
        {
            //code
        }

        private void ParseDiceResultSubtraction(string[] diceSubtraction)
        {
            //code
        }

        private void ParseDiceResultMultiplier(string[] diceMultiplier)
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
                    generatedNumber.Add(random.Next(1, diceSides+1));
                }
            }
        }

        public void Display()
        {
            for(int numCount = 0; numCount < generatedNumber.Count; numCount++)
            {
                Console.Write(generatedNumber[numCount] + " ");
            }
            Console.WriteLine();
        }
    }
}
