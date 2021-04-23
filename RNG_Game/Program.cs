using System;
using System.IO;

namespace RNG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string errorPath = Directory.GetCurrentDirectory() + "\\ErrorLogs.txt";
            StreamWriter streamWriter = new StreamWriter(errorPath);
            DateTime date = DateTime.Now;
            var score = new Score(0,0);
            while (true)
            {   var welcome = "Welcome to a new game of, \"GUESS... THE... NUMBER!\"";
                var exit = "Type 'r' to start over and reset your score. Type 'e' to exit.";
                var question = "What will be the next random number generated?";
                var hint = "Hint: It's between 1 and 5 and is a whole number.";
                Random rnd = new Random();
                double randomNumber = rnd.Next(1, 5);
                if (score.getScores()[1] == 0)
                {
                    Console.WriteLine(welcome);
                    System.Threading.Thread.Sleep(500);

                }
                Console.WriteLine(question);
                Console.WriteLine(hint);
                Console.WriteLine(exit);
                var userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "e")
                {
                    Console.WriteLine("*~*~*~*Final Score*~*~*~*");
                    score.printScores();
                    System.Threading.Thread.Sleep(500);
                    Console.WriteLine("Thanks for playing! Exiting now...");
                    System.Threading.Thread.Sleep(500);
                    streamWriter.Close();
                    StreamReader streamReader = new StreamReader(errorPath);
                    string savedErrors = streamReader.ReadToEnd();
                    if (savedErrors != null)
                    {
                        Console.WriteLine("Errors were reported and saved!");
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("Fetching saved errors now...");
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("*** Errors:");
                        Console.WriteLine(savedErrors);
                        Console.WriteLine("Errors were saved at '" + errorPath + "'");
                        System.Threading.Thread.Sleep(500);
                    }
                    break;
                }
                if (userAnswer == "r")
                {
                    score.resetScores();
                    Console.WriteLine("Got it! Your score has been reset.");
                    System.Threading.Thread.Sleep(500);
                    Console.WriteLine("... Generating new game... This usually takes like 2 seconds... ");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }
                try
                {
                    double number = double.Parse(userAnswer);
                    if (number == randomNumber)
                    {
                        Console.WriteLine("'" + userAnswer + "' is correct! Good job!");
                        score.addToScores(1, 1);
                    }
                    else {
                        Console.WriteLine("*Womp-womp*...'" + userAnswer + "' is incorrect. The correct answer was '" + randomNumber + ".' Please, try again.");
                        if (number < 1 || number > 5)
                        {
                            Console.WriteLine("*** Remember, the correct answer is between 1 and 5, and is a whole number!");
                        } else if (number % 1 != 0)
                        {
                            Console.WriteLine("*** Hint: The answer will always be a whole number.");
                        }
                        score.addToScores(0, 1);
                    }

                }

                catch(FormatException ex) {
                    streamWriter.WriteLine($"On {date}, User entered '" + userAnswer + "'. Error Message: " + ex.Message);
                    Console.WriteLine("'" + userAnswer + "' is not a number. Please try again using a whole number between 1 and 5.");
                    score.addToScores(0, 1);
                }


                Console.WriteLine("***Current Score***");
                System.Threading.Thread.Sleep(500);
                score.printScores();
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("... Generating next number... This usually takes like 2 seconds... ");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
        }

        // either use global variables for score.CorrectAnswers and score.TotalAttempts or pass as params to this function
        //static void Scoreboard ()
    }
}
