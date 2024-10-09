
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quiz_maker
{
    public class UserInterface
    {

        public static void PrintInstructionMenu()
        {
            Console.WriteLine($"Welcome to our game!\r\nYou have 2 options:\r\nQuizmaker mode - where you can build up your quiz with questions and answers\r\nPlay mode - where you can play with the quiz you created\r\n" +
                $"Please, press {Constants.QUIZ_MAKER} for Quizmaker mode and {Constants.PLAY} for Play mode\r\n" +
                $"To close the application please select {Constants.CLOSE}\r\n");
        }


        public static void PrintInstructionQuizMaker()
        {
            Console.WriteLine($"Welcome to our Quiz Maker game!\r\n" +
                $"You will be asked to give us some questions, with {Constants.NUMBER_OF_ALL_ANSWERS} answer options for each question.\r\n" +
                $"{Constants.NUMBER_OF_CORRECT_ANSWERS} of those answers have to be correct!\r\n");
        }

        public static int AskUserHowManyQuestionsQuizMaker(int numberOfQuestions)
        {
            Console.WriteLine($"Please give me the number, how many questions you would like to add this time: \r\n");
            string answer = string.Empty;
            answer = Console.ReadLine();
            bool success = false;
            do
            {
                success = int.TryParse(answer, out numberOfQuestions);
                if (success)
                {
                    numberOfQuestions = Convert.ToInt32(numberOfQuestions);
                }
                if (!success)
                {
                    Console.WriteLine("Please give me a valid number: ");
                    answer = Console.ReadLine();
                }
            } while (!success);
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

        public static string GetQuestionFromUserQuizMaker()
        {
            Console.WriteLine($"Please give me your next question: ");
            string question = Console.ReadLine();
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


        public static List<Quiz> CreateQuiz(int numberOfQuestions)
        {

            List<Quiz> listOfAllQuizzes = new List<Quiz>();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Quiz Data = new Quiz();
                string question = string.Empty;
                List<string> correctAnswers = new List<string>();
                List<string> wrongAnswers = new List<string>();

                question = GetQuestionFromUserQuizMaker();

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


        public static void PrintQuestionGameMode(string question)
        {
            Console.WriteLine($"Question: {question}");
        }

        public static void PrintAnswersGameMode(List<string> listOfAllAnswers)
        {
            Console.WriteLine($"Answers: ");
            foreach (string answer in listOfAllAnswers)
            {
                Console.WriteLine(answer);
            }

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
