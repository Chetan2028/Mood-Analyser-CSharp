using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserDemo
{
    public class MoodAnalyser
    {
        public string mood;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// Default Constructor
        /// </summary>
        public MoodAnalyser()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// </summary>
        /// <param name="mood">The mood.</param>
        public MoodAnalyser(string mood)
        {
            this.mood = mood;
        }

        /// <summary>
        /// Analyses the mood.
        /// </summary>
        /// <param name="mood">The mood.</param>
        /// <returns></returns>
        public string AnalyseMood()
        {
            try
            {
                if (mood.Contains("Sad"))
                {
                    return "Sad";
                }
                else
                {
                    return "Happy";
                }
            }
            catch (NullReferenceException exception)
            {
                return "Happy";
            }

        }
    }
}
