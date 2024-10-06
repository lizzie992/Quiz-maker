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


        public static void SaveQuizToFile(List<Quiz> listOfAllObjects)
        {
            using (FileStream file = File.OpenWrite(Constants.PATH))
            {
                Serializer.serializer.Serialize(file, listOfAllObjects);
            }
        }

        public static List<Quiz> GetQuizFromFile()
        {
            List<Quiz> listOfAllObjects = new List<Quiz>();
            using (FileStream file = File.OpenRead(Constants.PATH))
            {
                listOfAllObjects = Serializer.serializer.Deserialize(file) as List<Quiz>;
            }
            return listOfAllObjects;
        }


        public static bool DoesQuizFileExist()
        {
            return File.Exists(Constants.PATH);
        }

        public static bool StayInPlayerMode(string input)
        {
            return input == Constants.NEXT_QUESTION;
        }

        public static Quiz GetRandomQuestionFromList(int numberOfQuestions, List<Quiz> listOfAllObjects)
        {
            int number = RandomClass.random.Next(0, numberOfQuestions);
            Quiz Data = new Quiz();
            Data = listOfAllObjects[number];
            return Data;
        }



        public static bool CheckIfAnswerIsCorrect(string answer, List<string> correctAnswers)
        {
            bool checkAnswer = false;
            if (correctAnswers.Contains(answer))
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
