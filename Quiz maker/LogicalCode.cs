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
            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
            using (FileStream file = File.OpenWrite(Constants.PATH))
            {
                serializer.Serialize(file, listOfAllObjects);
            }
        }

        public static List<Quiz> GetQuizFromFile()
        {
            List<Quiz> listOfAllObjects = new List<Quiz>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
            using (FileStream file = File.OpenRead(Constants.PATH))
            {
                listOfAllObjects = serializer.Deserialize(file) as List<Quiz>;
            }
            return listOfAllObjects;
        }


        public static bool DoesQuizFileExist()
        {
            bool DoesQuizFileExist = true;
            if (!File.Exists(Constants.PATH))
            {
                DoesQuizFileExist = false;
            }
            return DoesQuizFileExist;
        }

        public static bool StayInPlayerMode(string input)
        {
            bool StayInPlayerMode = true;
            if (input == Constants.NEXT_QUESTION)
            {
                StayInPlayerMode = true;
            }
            if (input == Constants.QUIT_PLAYERMODE)
            {
                StayInPlayerMode = false;
            }
            return StayInPlayerMode;
        }

        public static Quiz GetRandomQuestionFromList(int numberOfQuestions, List<Quiz> listOfAllObjects)
        {
            Random random = new Random();
            int number = random.Next(0, numberOfQuestions);
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
