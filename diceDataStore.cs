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
        int[] currentValues;
        string phrase;
        List<int> generatedNumber = new List<int>();
        Dictionary<char, int> stringPhaseDict = new Dictionary<char, int>();

        public DiceDataStore()
        {
            phrase = responseValidator.CheckIfAnswerEntered("Please enter a dice number:");
            char[] phraseChars = phrase.ToCharArray();
            CalculatePhrasePositions(phraseChars);

            if(stringPhaseDict.ContainsKey('d'))
            {
                stringPhaseDict.TryGetValue('d', out int currentPos);
                int nextPos = CalculateNextPos(currentPos);

                CalculateCurrentValues(phraseChars, 0, currentPos);
                diceNumber = int.Parse(string.Join("", currentValues));
                CalculateCurrentValues(phraseChars, currentPos, nextPos);
                diceSides = int.Parse(string.Join("", currentValues));
            }

            if(stringPhaseDict.ContainsKey('+'))
            {
                stringPhaseDict.TryGetValue('+', out int currentPos);
                int nextPos = CalculateNextPos(currentPos);

                CalculateCurrentValues(phraseChars, currentPos, nextPos);
                additionAmount = int.Parse(string.Join("", currentValues));
            }

            if (stringPhaseDict.ContainsKey('-'))
            {
                stringPhaseDict.TryGetValue('-', out int currentPos);
                int nextPos = CalculateNextPos(currentPos);

                CalculateCurrentValues(phraseChars, currentPos, nextPos);
                subtractionAmount = int.Parse(string.Join("", currentValues));
            }

            if (stringPhaseDict.ContainsKey('*'))
            {
                stringPhaseDict.TryGetValue('*', out int currentPos);
                int nextPos = CalculateNextPos(currentPos);

                CalculateCurrentValues(phraseChars, currentPos, nextPos);
                multiplicationAmount = int.Parse(string.Join("", currentValues));
            }

            CalculateDice();
            CalculateDiceResultAddition();
            CalculateDiceResultSubtraction();
            CalculateDiceResultMultiplier();
        }

        private int CalculateNextPos(int currentPos)
        {
            stringPhaseDict.TryGetValue('d', out int diceValue);
            stringPhaseDict.TryGetValue('+', out int plusValue);
            stringPhaseDict.TryGetValue('-', out int minusValue);
            stringPhaseDict.TryGetValue('*', out int multiplierValue);
            int[] stringPosValues = new int[] { diceValue, plusValue, minusValue, multiplierValue };
            Array.Sort(stringPosValues);
            int nextPos = 0;

            for(int pos = 0; pos < stringPosValues.Length; pos++)
            {
                if(currentPos < stringPosValues[pos])
                {
                    nextPos = stringPosValues[pos];
                    break;
                }
                else if (currentPos == stringPosValues[pos] && pos == (stringPosValues.Length-1))
                {
                    nextPos = phrase.Length;
                    break;
                }
            }
            return nextPos;
        }

        private void CalculateCurrentValues(char[] phraseChars, int startPos, int endPos)
        {
            int currentPos;

            if (phraseChars[startPos] == 'd' || phraseChars[startPos] == '+' || phraseChars[startPos] == '-' || phraseChars[startPos] == '*')
            {
                int posRange = endPos - (startPos + 1);
                currentValues = new int[posRange];
                currentPos = startPos + 1;
            }
            else
            {
                int posRange = endPos - startPos;
                currentValues = new int[posRange];
                currentPos = startPos;
            }

            for (int beforePos = 0; beforePos < currentValues.Length; beforePos++)
            {
                currentValues[beforePos] = int.Parse(phraseChars[currentPos].ToString());
                currentPos++;
            }
        }

        private bool DictContainsCheck(char key)
        {
            if(stringPhaseDict.ContainsKey(key))
            {
                return true;
            }
            else
            {
                return false;
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

        private void CalculateDiceResultAddition()
        {
            if(additionAmount != 0)
            {
                for (int numCount = 0; numCount < generatedNumber.Count; numCount++)
                {
                    generatedNumber[numCount] += additionAmount;
                }
            }
        }

        private void CalculateDiceResultSubtraction()
        {
            if(subtractionAmount != 0)
            {
                for (int numCount = 0; numCount < generatedNumber.Count; numCount++)
                {
                    generatedNumber[numCount] -= subtractionAmount;
                }
            }
        }

        private void CalculateDiceResultMultiplier()
        {
            if(multiplicationAmount != 0)
            {
                for (int numCount = 0; numCount < generatedNumber.Count; numCount++)
                {
                    generatedNumber[numCount] *= multiplicationAmount;
                }
            }
        }

        private void CalculatePhrasePositions(char[] phraseChars)
        {
            for (int phrasePos = 0; phrasePos < phraseChars.Length; phrasePos++)
            {
                if (phraseChars[phrasePos] == 'd')
                {
                    stringPhaseDict.Add('d', phrasePos);
                }
                else if (phraseChars[phrasePos] == '+')
                {
                    stringPhaseDict.Add('+', phrasePos);
                }
                else if (phraseChars[phrasePos] == '-')
                {
                    stringPhaseDict.Add('-', phrasePos);
                }
                else if (phraseChars[phrasePos] == '*')
                {
                    stringPhaseDict.Add('*', phrasePos);
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
