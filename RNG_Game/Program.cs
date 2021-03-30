using System;

namespace RNG_Game
{
    class Program
    {
        static string randomNumberGeneration()
        {
            var question = "What will be the next random number generated?";
            var hint = "Hint: It's between 1 and 5.";
            var exit = "Type 'e' to exit.";
            Console.WriteLine(question);
            Console.WriteLine(hint);
            Console.WriteLine(exit);
            var userAnswer = Console.ReadLine();
            var userAnswerParsed = int.Parse(userAnswer);
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 5);
            var success = "Correct! You got it right! Good job!";
            var failure = "Incorrect. The correct answer was ";
            if (randomNumber == userAnswerParsed)
            {
                return success;
            } else { return failure + randomNumber;  }
        }
        static void Main(string[] args)
        {
            var correctAnswers = 0;
            var totalAttempts = 0;
            bool running = true;
            while (running)
            {
                var cycle = randomNumberGeneration();
                if (cycle.StartsWith("Correct!"))
                {
                    correctAnswers = correctAnswers + 1;
                    totalAttempts = totalAttempts + 1;
                } else { totalAttempts = totalAttempts + 1; }
                Console.WriteLine(cycle);
                Console.WriteLine("***Current Score***");
                Console.WriteLine("Correct Answers: " + correctAnswers);
                Console.WriteLine("Total Attempts: " + totalAttempts);
            }
        }
    }
}
