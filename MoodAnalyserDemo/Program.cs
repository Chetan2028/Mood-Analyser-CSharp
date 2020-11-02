using System;

namespace MoodAnalyserDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyser problem");
            Console.WriteLine("Enter either happy or sad mood");
            string userInputForMood = Console.ReadLine();
            MoodAnalyser moodAnalyser = new MoodAnalyser(userInputForMood);
            Console.WriteLine(moodAnalyser.AnalyseMood());
        }
    }
}
