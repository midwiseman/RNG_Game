using System;

public class Score
{
	private double CorrectAnswers = 0;
	private double TotalAttempts = 0;

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
