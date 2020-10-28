using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserDemo;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class MoodAnalyseUnitTest
    {
        /// <summary>
        /// Checks for sad mood and return sad.
        /// </summary>
        [TestMethod]
        public void CheckFor_SadMood_And_ReturnSad()
        {
            ///Create a reference of MoodAnalyser Class
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Sad Mood");
            string actualMood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("Sad",actualMood);

        }

        /// <summary>
        /// Checks for sad else return happy.
        /// </summary>
        [TestMethod]
        public void CheckFor_Sad_Else_ReturnHappy()
        {
            ///create a reference of MoodAnalyser class
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Any mood");
            string actualMood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("Happy", actualMood);
        }
    }
}
