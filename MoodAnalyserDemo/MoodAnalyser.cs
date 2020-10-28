using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserDemo
{
    public class MoodAnalyser
    {
        /// <summary>
        /// Analyses the mood.
        /// </summary>
        /// <param name="mood">The mood.</param>
        /// <returns></returns>
        public string AnalyseMood(string mood)
        {
            if (mood.Contains("Sad"))
            {
                return "Sad";
            }
            return "Happy";
        }
    }
}
