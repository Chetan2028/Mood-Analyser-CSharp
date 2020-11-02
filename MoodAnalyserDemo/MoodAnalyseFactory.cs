using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
namespace MoodAnalyserDemo
{
    public class MoodAnalyseFactory
    {
        /// <summary>
        /// Creates the mood analyser object.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException">
        /// class not found
        /// or
        /// constructor not found
        /// </exception>
        public static object CreateMoodAnalyserObject(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.MoodAnalysisEnum.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.MoodAnalysisEnum.NO_SUCH_METHOD, "Constructor Not Found");
            }
        }

        /// <summary>
        /// UC5- For paramterized constructor by passsing message parameter to class method
        /// Creates the mood analyser object using parameterized constructor.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        public static object CreateMoodAnalyserObjectUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { "HAPPY" });
                    return instance;
                }
                else
                {
                    throw new MoodAnalysisException(MoodAnalysisException.MoodAnalysisEnum.NO_SUCH_METHOD, "Constructor Not Found");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.MoodAnalysisEnum.NO_SUCH_CLASS, "Class Not Found");
            }
        }
        /// <summary>
        /// Invokes the analyse mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalysisException">Method Not Found</exception>
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserDemo.MoodAnalyser");
                object moodAnalyserObject = MoodAnalyseFactory.CreateMoodAnalyserObjectUsingParameterizedConstructor("MoodAnalyserDemo.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyserObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.MoodAnalysisEnum.NO_SUCH_METHOD, "Method Not Found");
            }
        }
    }
}

