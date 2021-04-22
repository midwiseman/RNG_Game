using System;

namespace RNG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            double correctAnswers = 0;
            double totalAttempts = 0;
            while (true)
            {   var welcome = "Welcome to a new game of, \"GUESS... THE... NUMBER!\"";
                var exit = "Type 'r' to start over and reset your score. Type 'e' to exit.";
                var question = "What will be the next random number generated?";
                var hint = "Hint: It's between 1 and 5 and is a whole number.";
                Random rnd = new Random();
                double randomNumber = rnd.Next(1, 5);
                if (totalAttempts == 0)
                {
                    Console.WriteLine(welcome);
                    System.Threading.Thread.Sleep(2000);

                }
                Console.WriteLine(question);
                Console.WriteLine(hint);
                Console.WriteLine(exit);
                var userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "e")
                {
                    break;
                }
                if (userAnswer == "r")
                {
                    totalAttempts = 0;
                    correctAnswers = 0;
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
                        totalAttempts++;
                        correctAnswers++;
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
                        totalAttempts++;
                    }

                }

                catch(FormatException) {
                    Console.WriteLine("'" + userAnswer + "' is not a number. Please try again using a whole number between 1 and 5.");
                    totalAttempts++;
                }


                //Scoreboard();
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("***Current Score***");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Correct Answers: " + correctAnswers);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Total Attempts: " + totalAttempts);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("******************");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("... Generating next number... This usually takes like 3-4 seconds... ");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
            }
        }

        // either use global variables for correctAnswers and totalAttempts or pass as params to this function
        //static void Scoreboard ()
    }
}
