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
        int additionAmount = 0;
        int subtractionAmount = 0;
        int multiplicationAmount = 0;
        List<int> generatedNumber = new List<int>();
        string phrase = "100d88+1*5-2";
        int[] currentValues;

        public DiceDataStore()
        {
            char[] phraseChars = phrase.ToCharArray();
            //need to add way to calc. each value before checkedValue and up until next checked value (eg; 10d200+20 need to add 10 as diceNum, not 0)

            for(int pos = 0; pos < phraseChars.Length; pos++)
            {
                if (phraseChars[pos] == 'd')
                {
                    CalculateBeforeCurrentPos(phraseChars, pos);
                    diceNumber = int.Parse(string.Join("", currentValues));
                    CalculateAfterCurrentPos(phraseChars, pos);
                    diceSides = int.Parse(string.Join("", currentValues));
                }
                else if(phraseChars[pos] == '+')
                {
                    additionAmount = int.Parse(phraseChars[pos + 1].ToString());
                }
                else if (phraseChars[pos] == '-')
                {
                    subtractionAmount = int.Parse(phraseChars[pos + 1].ToString());
                }
                else if (phraseChars[pos] == '*')
                {
                    multiplicationAmount = int.Parse(phraseChars[pos + 1].ToString());
                }
            }

            CalculateDice();
            CalculateDiceResultAddition();
            CalculateDiceResultSubtraction();
            CalculateDiceResultMultiplier();
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

        private void CalculateDiceResultAddition()
        {
            for (int numCount = 0; numCount < generatedNumber.Count; numCount++)
            {
                generatedNumber[numCount] += additionAmount;
            }
        }

        private void CalculateDiceResultSubtraction()
        {
            for (int numCount = 0; numCount < generatedNumber.Count; numCount++)
            {
                generatedNumber[numCount] -= subtractionAmount;
            }
        }

        private void CalculateDiceResultMultiplier()
        {
            for (int numCount = 0; numCount < generatedNumber.Count; numCount++)
            {
                generatedNumber[numCount] *= multiplicationAmount;
            }
        }

        private void CalculateBeforeCurrentPos(char[] phraseChars, int pos)
        {
            currentValues = new int[pos];

            for (int beforePos = 0; beforePos < currentValues.Length; beforePos++)
            {
                currentValues[beforePos] = int.Parse(phraseChars[beforePos].ToString());
            }
        }

        private void CalculateAfterCurrentPos(char[] phraseChars, int pos)
        {
            currentValues = new int[pos];

            for (int afterPos = 0; afterPos < currentValues.Length; afterPos++)
            {
                currentValues[afterPos] = int.Parse(phraseChars[afterPos].ToString());
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
