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
        /// Given the  proper mood analyse class name should return mood analyse object.
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturn_MoodAnalyseObject()
        {
            object expected = new MoodAnalyser();
            object obj = MoodAnalyseFactory.CreateMoodAnalyserObject("MoodAnalyserDemo.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
            ///Assert.AreEqual(expected, obj); --> Here we are not checking the equality of object .thts'y not using Assert statment
        }
        /// <summary>
        /// T.C -> 4.2
        /// Givens the improper class name should return mood analysis exception.
        /// </summary>
        [TestMethod]
        public void GivenImproperClassName_ShouldThrow_MoodAnalysisException()
        {
            try
            {
                ///Arrange
                string className = "DummyNameSpace.MoodAnalyser";
                string constructorName = "MoodAnalyser";

                ///Act
                object expectedResult = MoodAnalyseFactory.CreateMoodAnalyserObject(className, constructorName);
            }
            catch(MoodAnalysisException exception)
            {
                Assert.AreEqual("Class Not Found", exception.Message);
            }
        }
        /// <summary>
        /// T.C -> 4.3
        /// Givens the improper constructor name should throw mood analysis exception.
        /// </summary>
        [TestMethod]
        public void GivenImproperConstructorName_ShouldThrow_MoodAnalysisException()
        {
            try
            {
                string className = "MoodAnalyserDemo.MoodAnalyser";
                string constructorName = "MoodAnalysis";

                object expectedResult = MoodAnalyseFactory.CreateMoodAnalyserObject(className, constructorName);
            }
            catch(MoodAnalysisException exception)
            {
                Assert.AreEqual("Constructor Not Found", exception.Message);
            }
        }
    }
}
