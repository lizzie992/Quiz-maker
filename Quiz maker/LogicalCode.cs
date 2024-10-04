using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz_maker
{
    public class LogicalCode
    {

        

        public static void SaveQuizToFile(List<object> listOfAllObjects)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<object>), new[] { typeof(Quiz) });
            using (FileStream file = File.OpenWrite(Constants.PATH))
            {
                serializer.Serialize(file, listOfAllObjects);
            }
        }

        public static List<object> GetQuizFromFile(List<object> listOfAllObjects)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<object>));
            using (FileStream file = File.OpenRead(Constants.PATH))
            {
                listOfAllObjects = serializer.Deserialize(file) as List<object>;
            }
            return listOfAllObjects;
        }



        Random random = new Random();
        public int GetRandom(int numberOfQuestions)
        {
            int number = random.Next(0, numberOfQuestions + 1);
            return number;
        }


        public static void GetRandomQuestionFromList(List<object> listOfAllObjects)
        {

        }



        public static bool CheckIfAnswerIsCorrect(int answer, List<string> allAnswers, List<string> correctAnswers)
        {
            bool checkAnswer = false;
            if (correctAnswers.Contains(allAnswers[answer - 1]))
            {
                checkAnswer = true;
            }
            return checkAnswer;
        }

        public static int WinPoints(int points)
        {
            points = points + Constants.WIN_POINTS;
            return points;
        }

        public static int LosePoints(int points)
        {
            points = points - Constants.LOSE_POINTS;
            return points;
        }
    }
}
