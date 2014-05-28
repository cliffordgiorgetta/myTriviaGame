using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TriviaGame
{
    class Program
    {


        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to my trivia game!");
            Console.WriteLine();
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Do you want to play!?");
            Console.WriteLine();
            System.Threading.Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Green;
            System.Threading.Thread.Sleep(1000);
            Console.Write("Yes");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" or ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("No ?");
            Console.ResetColor();
            Console.WriteLine();

            string yesorno = Console.ReadLine();
            if (yesorno.ToLower() == "yes")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Lets begin! :-)");
                Console.ResetColor();
                Console.WriteLine();
            }
            else if (yesorno.ToLower() == "no")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry for wasting your time! :-(");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1500);
                Environment.Exit(0);
                Console.Clear();
            }
            list();
            GetTriviaList();

            Console.ReadKey();
        }





        static void list()
        {



            var category = new List<string>() { "80's Film", "Lyrics", "Geography", "Capitols of", "Random" };

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please choose one category");
            Console.WriteLine("Example: 80's Film");
            Console.ResetColor();
            Console.WriteLine("1. 80's Film");
            Console.WriteLine("2. Lyrics");
            Console.WriteLine("3. Geography");
            Console.WriteLine("4. Capitol of");
            Console.WriteLine("5. Random");




            List<string> contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();
            var Film = category.Where(x => x.Contains("80's Film"));
            foreach (var item in Film)
            {
                if (item == "80's Film")
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
            contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();
            var Lyrics = category.Where(x => x.Contains("Lyrics"));
            foreach (var item in Lyrics)
            {
                if (item == "Lyrics")
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
            contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();
            var Geography = category.Where(x => x.Contains("Geography"));
            foreach (var item in Geography)
            {
                if (item == "Geography")
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
            contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();
            var capitolsOf = category.Where(x => x.Contains("Capitols of"));
            foreach (var item in capitolsOf)
            {
                if (item == "Capitols of")
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
            contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();
            var Random = category.Where(x => x.Contains("Random"));
            foreach (var item in Random)
            {
                if (item == "Random")
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }


        }








        static List<Trivia> GetTriviaList()
        {
            //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
            List<string> contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();
            //Each item in list "contents" is now one line of the Trivia.txt document.

            bool playing = true;

            while (playing)
            {

                var random = new Random();
                var newRandom = random.Next(1, contents.Count());
                var randomQuestion = contents[newRandom];

                var question = randomQuestion.Split('*')[0];
                var answer = randomQuestion.Split('*')[1];


                Console.WriteLine(question);
                var input = Console.ReadLine();

                if (input == answer)
                {
                    Console.Clear();
                    Console.WriteLine("Good Job");
                    Console.WriteLine();
                    Console.WriteLine("Answer is: " + answer);
                    Console.WriteLine();
                    Console.WriteLine("Question is: ");
                }
                else if (input != answer)
                {
                    Console.WriteLine();
                    Console.Clear();
                    Console.WriteLine("Try again!");
                    Console.WriteLine();
                    Console.WriteLine("Answer is: " + answer);
                    Console.WriteLine();
                    Console.WriteLine("Question is: ");
                }
                playing = false;
            }
            return new List<Trivia>();
        }

    }

}

