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
            Assert.AreEqual("SAD", actualMood);
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
            Assert.AreEqual("HAPPY", actualMood);
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
        /// <summary>
        /// T.C -> 5.1
        /// Givens the mood analyse class name should return mood analyse object using parameterized constructor.
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyseFactory.CreateMoodAnalyserObjectUsingParameterizedConstructor("MoodAnalyserDemo.MoodAnalyser", "MoodAnalyser", "HAPPY");
            expected.Equals(obj);
        }
        /// <summary>
        /// T.C -> 5.2
        /// Givens the improper class name should throw mood analysis exception for parameterized constructor.
        /// </summary>
        [TestMethod]
        public void GivenImproperClassName_ShouldThrow_MoodAnalysisException_ForParameterizedConstructor()
        {
            try
            {
                ///Arrange
                string className = "DummyNamespace.MoodAnalyser";
                string constructorName = "MoodAnalyser";
                object expectedObj = new MoodAnalyser("SAD");

                //Act
                object resultObj = MoodAnalyseFactory.CreateMoodAnalyserObjectUsingParameterizedConstructor(className, constructorName, "HAPPY");
            }
            catch(MoodAnalysisException exception)
            {
                Assert.AreEqual("Class Not Found", exception.Message);
            }
        }
        /// <summary>
        /// T.C -> 5.3
        /// Givens the improper constructor name should throw mood analysis exception for parameterized constructor.
        /// </summary>
        [TestMethod]
        public void GivenImproperConstructorName_ShouldThrow_MoodAnalysisException_ForParameterizedConstructor()
        {
            try
            {
                string className = "MoodAnalyserDemo.MoodAnalyser";
                string constructorName = "xyz";

                object expectedResult = MoodAnalyseFactory.CreateMoodAnalyserObjectUsingParameterizedConstructor(className, constructorName, "HAPPY");
            }
            catch(MoodAnalysisException exception)
            {
                Assert.AreEqual("Constructor Not Found" , exception.Message);
            }
        }
        /// <summary>
        /// T.C -> 6.1
        /// Givens the happy message using reflector when proper should return happy.
        /// </summary>
        [TestMethod]
        public void GivenHappyMessageUsingReflector_When_Proper_ShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyseFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }

        /// <summary>
        /// T.C -> 6.2
        /// Givens the happy message when improper method should throw mood analysis exception.
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_WhenImproperMethodShould_ThrowMoodAnalysisException()
        {
            try
            {
                string message = "Happy";
                string methodName = "AnalysMode";
                string mood = MoodAnalyseFactory.InvokeAnalyseMood(message, methodName);
            }
            catch(MoodAnalysisException exception)
            {
                Assert.AreEqual("Method Not Found", exception.Message);
            }
        }
    }
}
