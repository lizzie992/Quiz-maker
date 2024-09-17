using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_maker
{
    public class LogicalCode
    {
        public static void Serializer(string path, string question, List<string> correctAnswers, List<string> wrongAnswers)
        {
            //to be continued on a later phase :)
        }

        public static int GetRandom(int numberOfQuestions)
        {
            var random = new Random();
            int number = random.Next(0, numberOfQuestions+1);
            return number;
        }

        public static List<string> ShuffleTheList(int numberOfAnswers, List<string> allAnswers)
        {
            var random = new Random();
            int number = random.Next(0, numberOfAnswers);
            var shuffledList = allAnswers.OrderBy(_ => random.Next()).ToList();
            return shuffledList;
        }

        public static bool CheckIfAnswerIsCorrect(int answer, List<string> allAnswers, List<string> correctAnswers)
        {
            bool checkAnswer = false;
            if (correctAnswers.Contains(allAnswers[answer-1]))
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
