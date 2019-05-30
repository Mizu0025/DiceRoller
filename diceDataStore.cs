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
        int diceSubtraction = 0;
        int diceMultiplier = 0;
        List<int> generatedNumber = new List<int>();
        string phrase;

        public DiceDataStore()
        {
            phrase = responseValidator.CheckIfAnswerEntered("Enter your dice roll (eg; 1d8, 1*100, 1d8+10):");
            string[] diceSplitter = phrase.Split('d', '+', '-', '*');
            string[] sumAdditionSplitter = phrase.Split('+');
            string[] sumSubstractionSplitter = phrase.Split('-');
            string[] sumMultiplierSplitter = phrase.Split('*');
            //need parser to handle phrase in any combo of parse values (eg; 1d8*100+20 as well as 1d8+20*100)
            ParseDiceNumbers(diceSplitter);
            CalculateDice();
            if(sumAdditionSplitter.Length > 1)
            {
                ParseDiceResultAddition(sumAdditionSplitter);
            }
            if(sumSubstractionSplitter.Length > 1)
            {
                ParseDiceResultSubtraction(sumSubstractionSplitter);
            }
            if(sumMultiplierSplitter.Length > 1)
            {
                ParseDiceResultMultiplier(sumMultiplierSplitter);
            }
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
            for(int numCount = 0; numCount < generatedNumber.Count; numCount++)
            {
                generatedNumber[numCount] += int.Parse(diceAddition[1]);
            }
        }

        private void ParseDiceResultSubtraction(string[] diceSubtraction)
        {
            for (int numCount = 0; numCount < generatedNumber.Count; numCount++)
            {
                generatedNumber[numCount] -= int.Parse(diceSubtraction[1]);
            }
        }

        private void ParseDiceResultMultiplier(string[] diceMultiplier)
        {
            for (int numCount = 0; numCount < generatedNumber.Count; numCount++)
            {
                generatedNumber[numCount] *= int.Parse(diceMultiplier[1]);
            }
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
