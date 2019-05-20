using System;

namespace DiceRoll
{
    public class DiceRoller
    {
        static void Main(string[] args)
        {
            int diceSides = 0;
            int diceNumber = 0;
            Random random = new Random();
            string phrase;
            //use args to assign values to diceSides & diceNumber when running program from commandline
            //if args[] != "" then skip asking for input
            //learn what is at each args[] index, so as to know where Phrase shall be found when entering input from commandline

            Console.WriteLine("Enter your dice roll:");
            phrase = Console.ReadLine();
            string[] words = phrase.Split('d');

            for (int i = 0; i<words.Length; i++)
            {
                if(i == 0)
                {
                    diceNumber = int.Parse(words[i]);
            }
                else
                {
                    diceSides = int.Parse(words[i]);
                }
            }

            for(int i = 0; i < diceNumber; i++)
            {
                int diceGen = random.Next(1, diceSides);
                Console.Write(diceGen + " ");
            }
            Console.WriteLine();
            Console.Read();
        }
    }
}
