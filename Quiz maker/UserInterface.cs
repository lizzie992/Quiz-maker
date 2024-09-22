using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public static void printInstructionQuizMaker(int numberOfAllAnswers, int numberOfCorrectAnswers)
        {
            Console.WriteLine($"Welcome to our Quiz Maker game!\r\n" +
                $"You will be asked to give us some questions, with {numberOfAllAnswers} answer options for each question.\r\n" +
                $"{numberOfCorrectAnswers} of those answers have to be correct!\r\n");
        }

        public static int  askUserHowManyQuestionsQuizMaker(int numberOfQuestions)
        {
            Console.WriteLine($"Please give me the number, how many questions you would like to add this time: \r\n");
            numberOfQuestions = Convert.ToInt32(Console.ReadLine());
            return numberOfQuestions;
        }

        public static void pressKeyToMoveOn()
        {
            Console.WriteLine("Please press a button to move on!");
            Console.ReadKey();
        }

        public static void clearScreen()
        {
            Console.Clear();
        }

        public static string getQuestionFromUserQuizMaker()
        {
            Console.WriteLine($"Please give me your next question: ");
            string question = Console.ReadLine();
            return question;
        }

        public static string getCorrectAnswerQuizMaker()
        {
            Console.WriteLine($"Please give me a correct answer to this question: ");
            string correctAnswer = Console.ReadLine();
            return correctAnswer;
        }
        public static string getWrongAnswerQuizMaker()
        {
            Console.WriteLine($"Please give me a wrong answer to this question: ");
            string wrongAnswer = Console.ReadLine();
            return wrongAnswer;
        }


        public static void CreateQuiz(int numberOfQuestions, string question, List<string> correctAnswers, List<string> allAnswers)
        {
            question = getQuestionFromUserQuizMaker();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                for (int j = 0; j < Constants.NUMBER_OF_CORRECT_ANSWERS; j++)
                {
                    correctAnswers.Add(getCorrectAnswerQuizMaker().ToLower());
                }
                for (int j = 0; j < Constants.NUMBER_OF_WRONG_ANSWERS; j++)
                {
                    allAnswers.Add(getWrongAnswerQuizMaker().ToLower());
                }
            }
                
        }


        public static void PrintQuestionGameMode(string question)
        {
            Console.WriteLine(question);
        }

        public static void PrintListOfAnswersGameMode(int numberOfAnswers, List<string> List)
        {
            for (int i = 0; i < numberOfAnswers; i++)
            {
                Console.WriteLine(List[i]);
            }
        }


        public static void PrintInstructionGameMode()
        {
            Console.WriteLine("Welcome to the game! You will get random questions from the ones you gave us, and you need to give us the number of the correct answer" +
                $"\r\nWith every win, you will get {Constants.WIN_POINTS} points, and with every mistake, you will lose {Constants.LOSE_POINTS} points");
        }


        public static string GetAnswerFromPlayerGameMode()
        {
            Console.WriteLine("Give us the number of the correct answer: \r\n");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void PrintWinMessageGameMode()
        {
            Console.WriteLine("Good answer, you won!");
        }

        public static void PrintLoseMessageGameMode()
        {
            Console.WriteLine("This is not the correct answer, try again!");
        }

        public static void PrintPointsGameMode(int points)
        {
            Console.WriteLine($"You have {points} points at the moment!");
        }


    }
}
