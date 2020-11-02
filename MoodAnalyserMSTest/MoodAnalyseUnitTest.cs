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
            Assert.AreEqual("Sad", actualMood);
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

        /// <summary>
        /// Given the null mood should return happy.
        /// </summary>
        [TestMethod]
        [DataRow(null)]
        public void Given_NullMood_Should_Throw_MoodAnalysisException(string message)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                string mood = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalysisException exception)
            {
                Assert.AreEqual("Mood cannot be null", exception.Message);
            }
        }
        /// <summary>
        /// Givens the empty mood should throw invalidmood exception.
        /// </summary>
        [TestMethod]
        public void Given_EmptyMood_Should_Throw_MoodAnalysisException()
        {
            try
            {
                string message = "";
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                string mood = moodAnalyser.AnalyseMood();
            }
            catch(MoodAnalysisException exception)
            {
                Assert.AreEqual("Mood cannot be empty", exception.Message);
            }
        }

        /// <summary>
        /// T.C ->  4.1
        /// Givens the mood analyse class name should return mood analyse object.
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturn_MoodAnalyseObject()
        {
            object expected = new MoodAnalyser();
            object obj = MoodAnalyseFactory.CreateMoodAnalyserObject("MoodAnalyserDemo.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
    }
}
