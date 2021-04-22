using System;
using System.IO;
using System.Collections.Generic;

namespace RNG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string errorPath = Directory.GetCurrentDirectory() + "\\ErrorLogs.txt";
            StreamWriter streamWriter = new StreamWriter(errorPath);
            DateTime date = new DateTime();
            List<string> errorList = new List<string>();
            streamWriter.WriteLine("New Game initiated on " + date);
            var score = new Score();
            while (true)
            {   var welcome = "Welcome to a new game of, \"GUESS... THE... NUMBER!\"";
                var exit = "Type 'r' to start over and reset your score. Type 'e' to exit.";
                var question = "What will be the next random number generated?";
                var hint = "Hint: It's between 1 and 5 and is a whole number.";
                Random rnd = new Random();
                double randomNumber = rnd.Next(1, 5);
                if (score.TotalAttempts == 0)
                {
                    Console.WriteLine(welcome);
                    System.Threading.Thread.Sleep(1000);

                }
                Console.WriteLine(question);
                Console.WriteLine(hint);
                Console.WriteLine(exit);
                var userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "e")
                {
                    string[] errors = errorList.ToArray();
                    foreach (string error in errors)
                    { 
                        Console.WriteLine("Error:", error.ToString());
                        streamWriter.WriteLine(error);
                    }
                    streamWriter.Close();
                    break;
                }
                if (userAnswer == "r")
                {
                    score.TotalAttempts = 0;
                    score.CorrectAnswers = 0;
                    Console.WriteLine("Got it! Your score has been reset.");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("... Generating new game... This usually takes like 3-4 seconds... ");
                    System.Threading.Thread.Sleep(3500);
                    Console.Clear();
                    continue;
                }
                try
                {
                    double number = double.Parse(userAnswer);
                    if (number == randomNumber)
                    {
                        Console.WriteLine("'" + userAnswer + "' is correct! Good job!");
                        score.TotalAttempts++;
                        score.CorrectAnswers++;
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
                        score.TotalAttempts++;
                    }

                }

                catch(FormatException ex) {
                    errorList.Add(ex.Message.ToString());
                    Console.WriteLine("'" + userAnswer + "' is not a number. Please try again using a whole number between 1 and 5.");
                    score.TotalAttempts++;
                }


                //Scoreboard();
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("***Current Score***");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Correct Answers: " + score.CorrectAnswers);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Total Attempts: " + score.TotalAttempts);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("******************");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("... Generating next number... This usually takes like 3-4 seconds... ");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
            }
        }

        // either use global variables for score.CorrectAnswers and score.TotalAttempts or pass as params to this function
        //static void Scoreboard ()
    }
}
