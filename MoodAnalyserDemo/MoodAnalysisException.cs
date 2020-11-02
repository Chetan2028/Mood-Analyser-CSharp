using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserDemo
{
    public class MoodAnalysisException : Exception
    {
        /// <summary>
        /// Create a enum for a group of named constants
        /// </summary>
        public enum MoodAnalysisEnum
        {
            EMPTY_MESSAGE , NULL_MESSAGE , NO_SUCH_CLASS , NO_SUCH_METHOD,NO_SUCH_FIELD , OBJECT_CREATION_ISSUE
        }

        public MoodAnalysisEnum moodAnalysisEnum;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalysisException"/> class.
        /// </summary>
        /// <param name="moodAnalysisEnum">The mood analysis enum.</param>
        /// <param name="message">The message.</param>
        public MoodAnalysisException(MoodAnalysisEnum moodAnalysisEnum , string message) : base(message)
        {
            this.moodAnalysisEnum = moodAnalysisEnum;
        }
    }
}
