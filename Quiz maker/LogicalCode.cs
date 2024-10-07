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
        public static Quiz Data = new Quiz();

        public static XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));

        public static Random random = new Random();

        public static void SaveQuizToFile(List<Quiz> listOfAllObjects)
        {
            using (FileStream file = File.OpenWrite(Constants.PATH))
            {
                serializer.Serialize(file, listOfAllObjects);
            }
        }

        public static List<Quiz> GetQuizFromFile()
        {
            List<Quiz> listOfAllObjects = new List<Quiz>();
            using (FileStream file = File.OpenRead(Constants.PATH))
            {
                listOfAllObjects = serializer.Deserialize(file) as List<Quiz>;
            }
            return listOfAllObjects;
        }


        public static bool DoesQuizFileExist()
        {
            return File.Exists(Constants.PATH);
        }

        public static List<string> GetAllAnswersInRandomOrder(List<string> correctAnswers, List<string> wrongAnswers)
        {
            List<string> listOfAllAnswers = new List<string>();
            listOfAllAnswers.AddRange(correctAnswers);
            listOfAllAnswers.AddRange(wrongAnswers);
            listOfAllAnswers = listOfAllAnswers.OrderBy(x => Random.Shared.Next()).ToList();
            return listOfAllAnswers;
        }


        public static bool StayInPlayerMode(string input)
        {
            return input == Constants.NEXT_QUESTION;
        }

        public static Quiz GetRandomQuestionFromList(int numberOfQuestions, List<Quiz> listOfAllObjects)
        {
            int number = random.Next(0, numberOfQuestions);
            Data = listOfAllObjects[number];
            return Data;
        }



        public static bool CheckIfAnswerIsCorrect(string answer, List<string> correctAnswers)
        {
            return correctAnswers.Contains(answer);
        }

        public static int WinPoints(int points)
        {
            points += Constants.WIN_POINTS;
            return points;
        }

        public static int LosePoints(int points)
        {
            points -= Constants.LOSE_POINTS;
            return points;
        }
    }
}
