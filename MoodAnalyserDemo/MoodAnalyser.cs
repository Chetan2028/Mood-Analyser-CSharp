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
        /// </summary>
        /// <param name="mood">The mood.</param>
        public MoodAnalyser(string mood)
        {
            this.mood = mood;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// </summary>
        public MoodAnalyser()
        {

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
                if (mood.Equals(string.Empty))
                {
                    throw new MoodAnalysisException(MoodAnalysisException.MoodAnalysisEnum.EMPTY_MESSAGE, "Mood cannot be empty");
                }
                if (mood.Contains("Sad"))
                {
                    return "Sad";
                }
                else
                {
                    return "Happy";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.MoodAnalysisEnum.NULL_MESSAGE, "Mood cannot be null");
            }

        }
    }
}
