using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller
{
    class ResponseValidator
    {
        private List<string> validResponses;
        private string response;
        private int intResponse;

        public string CheckIfAnswerEntered(string question)
        {
            response = AskQuestionAndGetResponse(question);

            while (response == "")
            {
                response = AskQuestionAndGetResponse(question);
            }
            return response;
        }

        private string CheckIfValidString(string question, List<string> validValues)
        {
            response = AskQuestionAndGetResponse(question);

            while (validValues.IndexOf(response.ToLower()) == -1)
            {
                response = CheckIfAnswerEntered(question);
            }
            return response;
        }

        public string CheckIfValidString(string question, string validResponse1, string validResponse2)
        {
            return CheckIfValidString(question, validResponses = new List<string> { validResponse1.ToLower(), validResponse2.ToLower() });
        }

        public int CheckIfValidInt(string question)
        {
            response = AskQuestionAndGetResponse(question);

            while (!int.TryParse(response, out intResponse))
            {
                response = CheckIfAnswerEntered(question);
            }
            return intResponse;
        }

        public double CheckIfValidDouble(string question)
        {
            string response = AskQuestionAndGetResponse(question);
            double doubleResponse;

            while (!double.TryParse(response, out doubleResponse))
            {
                response = CheckIfAnswerEntered(question);
            }
            return doubleResponse;
        }

        public int CheckIfIntValueBetween(string question, int lowestValue, int highestValue)
        {
            lowestValue -= 1;
            highestValue += 1;

            int intResponse = CheckIfValidInt(question);

            while (intResponse <= lowestValue || intResponse >= highestValue)
            {
                intResponse = CheckIfValidInt(question);
            }
            return intResponse;
        }

        private string AskQuestionAndGetResponse(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}