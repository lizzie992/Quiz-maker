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
                $"Please, press 'Q' for Quizmaker mode and 'P' for Play mode\r\n" +
                $"To close the application please select 'C'\r\n");
        }


        public static void printInstructionQuizMaker(int numberOfAllAnswers, int numberOfCorrectAnswers)
        {
            Console.WriteLine($"Welcome to our Quiz Maker game!\r\n" +
                $"You will be asked to give us some questions, with {numberOfAllAnswers} answer options for each question.\r\n" +
                $"{numberOfCorrectAnswers} of those answers have to be correct!\r\n");
        }

        public static int  askUserHowManyQuestions(int numberOfQuestions)
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

        public static string getQuestionFromUser()
        {
            Console.WriteLine($"Please give me your next question: ");
            string question = Console.ReadLine();
            return question;
        }

        public static string getCorrectAnswer()
        {
            Console.WriteLine($"Please give me a correct answer to this question: ");
            string correctAnswer = Console.ReadLine();
            return correctAnswer;
        }
        public static string getWrongAnswer()
        {
            Console.WriteLine($"Please give me a wrong answer to this question: ");
            string wrongAnswer = Console.ReadLine();
            return wrongAnswer;
        }

        public static void PrintQuestion(string question)
        {
            Console.WriteLine(question);
        }

        public static void PrintListOfAnswers(int numberOfAnswers, List<string> List)
        {
            for (int i = 0; i < numberOfAnswers; i++)
            {
                Console.WriteLine(List[i]);
            }
        }


        public static void PrintInstructionGame()
        {
            Console.WriteLine("Welcome to the game! You will get random questions from the ones you gave us, and you need to give us the number of the correct answer" +
                $"\r\nWith every win, you will get {Constants.WIN_POINTS} points, and with every mistake, you will lose {Constants.LOSE_POINTS} points");
        }


        public static string GetAnswerFromPlayer()
        {
            Console.WriteLine("Give us the number of the correct answer: \r\n");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void PrintWinMessage()
        {
            Console.WriteLine("Good answer, you won!");
        }

        public static void PrintLoseMessage()
        {
            Console.WriteLine("This is not the correct answer, try again!");
        }

        public static void PrintPoints(int points)
        {
            Console.WriteLine($"You have {points} points at the moment!");
        }


    }
}
