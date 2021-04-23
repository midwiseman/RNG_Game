using System;

public class Score
{
	private double CorrectAnswers;
	private double TotalAttempts;

    public Score(int correctAnswers, int totalAttempts)
    {
        CorrectAnswers = correctAnswers;
        TotalAttempts = totalAttempts;
    }
	public void printScores()
    {
        Console.WriteLine("Correct Answers: " + CorrectAnswers);
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Total Attempts: " + TotalAttempts);
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("******************");
    }

    public double[] getScores()
    { double[] scorePackage = new double[2];
        scorePackage[0] = CorrectAnswers;
        scorePackage[1] = TotalAttempts;
        return scorePackage;
    }

    public void addToScores(double correctIncrement, double totalIncrement)
    {
        CorrectAnswers += correctIncrement;
        TotalAttempts += totalIncrement;
    }

    public void resetScores()
    {
        CorrectAnswers = 0;
        TotalAttempts = 0;
    }
}
