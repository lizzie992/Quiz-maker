using System.Net.Quic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quiz_maker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string gameMode = string.Empty;
            List<Quiz> listOfAllQuizzes = new List<Quiz>();
            Quiz Data = new Quiz();
            int numberOfQuestions = 0;

            do
            {
                UserInterface.PrintInstructionMenu();
                gameMode = Console.ReadLine().ToLower();
                UserInterface.PressKeyToMoveOn();
                UserInterface.ClearScreen();

                if (gameMode == Constants.QUIZMAKER)
                {
                    UserInterface.PrintInstructionQuizMaker();

                    numberOfQuestions = UserInterface.AskUserHowManyQuestionsQuizMaker(numberOfQuestions);
                    UserInterface.PressKeyToMoveOn();
                    UserInterface.ClearScreen();

                    listOfAllQuizzes.AddRange(UserInterface.CreateQuiz(numberOfQuestions));
                    LogicalCode.SaveQuizToFile(listOfAllQuizzes);
                    UserInterface.ClearScreen();
                }

                if (gameMode == Constants.PLAY)
                {

                    if (!LogicalCode.DoesQuizFileExist())
                    {
                        UserInterface.PrintQuizIsEmptyMessage();
                        UserInterface.PressKeyToMoveOn();
                        UserInterface.ClearScreen();
                        continue;
                    }

                    int points = 0;
                    UserInterface.PrintInstructionGameMode();
                    listOfAllQuizzes = LogicalCode.GetQuizFromFile();

                    UserInterface.PrintQuizzesGameMode(listOfAllQuizzes);
                    UserInterface.PressKeyToMoveOn();
                    UserInterface.ClearScreen();

                    string input = string.Empty;
                    do
                    {
                        Data = LogicalCode.GetRandomQuestionFromList(listOfAllQuizzes.Count, listOfAllQuizzes);

                        UserInterface.PrintQuestionGameMode(Data.question);
                        string answer = string.Empty;

                        do
                        {
                            answer = UserInterface.GetAnswerFromPlayerGameMode(answer);
                            if (LogicalCode.CheckIfAnswerIsCorrect(answer, Data.correctAnswers))
                            {
                                points = LogicalCode.WinPoints(points);
                                UserInterface.PrintWinMessageGameMode();
                                UserInterface.PrintPointsGameMode(points);
                            }
                            else
                            {
                                points = LogicalCode.LosePoints(points);
                                UserInterface.PrintLoseMessageGameMode();
                                UserInterface.PrintPointsGameMode(points);
                            }
                        } while (!LogicalCode.CheckIfAnswerIsCorrect(answer, Data.correctAnswers));

                        input = UserInterface.PrintMessageStayingInPlayerMode(input);
                        UserInterface.ClearScreen();

                    } while (LogicalCode.StayInPlayerMode(input));

                    UserInterface.ClearScreen();
                }

                if (gameMode == Constants.CLOSE)
                {
                    break;
                }
            } while (gameMode != Constants.CLOSE);
        }
    }
}
