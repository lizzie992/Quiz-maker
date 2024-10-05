using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quiz_maker
{
    public class UserInterface
    {

        public static void PrintInstructionMenu()
        {
            Console.WriteLine($"Welcome to our game!\r\nYou have 2 options:\r\nQuizmaker mode - where you can build up your quiz with questions and answers\r\nPlay mode - where you can play with the quiz you created\r\n" +
                $"Please, press {Constants.QUIZMAKER} for Quizmaker mode and {Constants.PLAY} for Play mode\r\n" +
                $"To close the application please select {Constants.CLOSE}\r\n");
        }


        public static void PrintInstructionQuizMaker(int numberOfAllAnswers, int numberOfCorrectAnswers)
        {
            Console.WriteLine($"Welcome to our Quiz Maker game!\r\n" +
                $"You will be asked to give us some questions, with {numberOfAllAnswers} answer options for each question.\r\n" +
                $"{numberOfCorrectAnswers} of those answers have to be correct!\r\n");
        }

        public static int AskUserHowManyQuestionsQuizMaker(int numberOfQuestions)
        {
            Console.WriteLine($"Please give me the number, how many questions you would like to add this time: \r\n");
            numberOfQuestions = Convert.ToInt32(Console.ReadLine());
            return numberOfQuestions;
        }

        public static void PressKeyToMoveOn()
        {
            Console.WriteLine("Please press a button to move on!");
            Console.ReadKey();
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static string GetQuestionFromUserQuizMaker(string question)
        {
            Console.WriteLine($"Please give me your next question: ");
            question = Console.ReadLine();
            return question;
        }

        public static string GetCorrectAnswerQuizMaker()
        {
            Console.WriteLine($"Please give me a correct answer to this question: ");
            string correctAnswer = Console.ReadLine();
            return correctAnswer;
        }
        public static string GetWrongAnswerQuizMaker()
        {
            Console.WriteLine($"Please give me a wrong answer to this question: ");
            string wrongAnswer = Console.ReadLine();
            return wrongAnswer;
        }


        public static Quiz Data = new Quiz();
        public static List<Quiz> CreateQuiz(int numberOfQuestions)
        {

            List<Quiz> listOfAllQuizzes = new List<Quiz>();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Data = new Quiz();
                string question = string.Empty;
                List<string> correctAnswers = new List<string>();
                List<string> wrongAnswers = new List<string>();

                question = GetQuestionFromUserQuizMaker(question);

                for (int j = 0; j < Constants.NUMBER_OF_CORRECT_ANSWERS; j++)
                {
                    correctAnswers.Add(GetCorrectAnswerQuizMaker().ToLower());
                }
                for (int j = 0; j < Constants.NUMBER_OF_WRONG_ANSWERS; j++)
                {
                    wrongAnswers.Add(GetWrongAnswerQuizMaker().ToLower());
                }

                Data.question = question;
                Data.correctAnswers.AddRange(correctAnswers);
                Data.wrongAnswers.AddRange(wrongAnswers);

                listOfAllQuizzes.Add(Data);
                Console.Clear();
            }
            return listOfAllQuizzes;
        }


        public static void PrintQuizzesGameMode(List<Quiz> listOfAllQuizzes)
        {
            Console.WriteLine($"Here are the questions and answers you gave us, memorize them well!\r\n");
            foreach (Quiz Data in listOfAllQuizzes)
            {
                Console.WriteLine($"Question: {Data.question}\r\n");
                foreach (string correctAnswer in Data.correctAnswers)
                {
                    Console.WriteLine($"Correct Answers: {correctAnswer}\r\n");
                }
                Console.Write($"Wrong answers: \r\n");
                foreach (string wrongAnswers in Data.wrongAnswers)
                {
                    Console.Write($"{wrongAnswers}\r\n");
                }
                Console.Write($"\r\n");
            }
        }


        public static void PrintQuestionGameMode(string question)
        {
            Console.WriteLine($"Question: {question}");
        }

        public static void PrintInstructionGameMode()
        {
            Console.WriteLine("Welcome to the game! You will get random questions from the ones you gave us, and you need to give us the correct answer" +
                $"\r\nWith every win, you will get {Constants.WIN_POINTS} points, and with every mistake, you will lose {Constants.LOSE_POINTS} points");
        }

        public static string PrintMessageStayingInPlayerMode(string input)
        {
            Console.WriteLine($"Please select from the following options:\r\nPress N for Next Question\r\nPress Q to Quit Player Mode!");
            input = Console.ReadLine().ToLower();
            return input;
        }


        public static void PrintQuizIsEmptyMessage()
        {
            Console.WriteLine("You have not added any questions! Please, select Quizmaker mode and add some questions and answers!");
        }

        public static string GetAnswerFromPlayerGameMode(string answer)
        {
            Console.WriteLine("Give us the correct answer:");
            answer = Console.ReadLine().ToLower();
            return answer;
        }

        public static void PrintWinMessageGameMode()
        {
            Console.WriteLine("Good answer, you won!\r\n");
        }

        public static void PrintLoseMessageGameMode()
        {
            Console.WriteLine("This is not the correct answer, try again!\r\n");
        }

        public static void PrintPointsGameMode(int points)
        {
            Console.WriteLine($"You have {points} points at the moment!\r\n");
        }


    }
}
