using System.Net.Quic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quiz_maker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string gameMode = string.Empty;

            Quiz Data = new Quiz();

            do
            {
                UserInterface.PrintInstructionMenu();
                gameMode = Console.ReadLine().ToLower();
                UserInterface.PressKeyToMoveOn();
                UserInterface.ClearScreen();

                if (gameMode == Constants.QUIZMAKER)
                {
                    UserInterface.PrintInstructionQuizMaker(Constants.NUMBER_OF_ALL_ANSWERS, Constants.NUMBER_OF_CORRECT_ANSWERS);

                    int numberOfQuestions = 0;
                    numberOfQuestions = UserInterface.AskUserHowManyQuestionsQuizMaker(numberOfQuestions);
                    UserInterface.PressKeyToMoveOn();
                    UserInterface.ClearScreen();

                    Data = UserInterface.CreateQuiz(numberOfQuestions, Data);
                    LogicalCode.SaveQuizToFile(Data);
                    UserInterface.PressKeyToMoveOn();
                    UserInterface.ClearScreen(); 
                }

                if (gameMode == Constants.PLAY)
                {
                    Data.allAnswers.AddRange(Data.correctAnswers);
                    int points = 0;
                    UserInterface.PrintInstructionGameMode();
                    //here comes the part where I get a random question out of the file which is not clear for me yet:) so I am working with the 1 set of questions/answers
                    UserInterface.PrintQuestionGameMode();
                    UserInterface.PrintListOfAnswersGameMode(Constants.NUMBER_OF_ALL_ANSWERS, Data.allAnswers);
                    int answer = 0;
                    do
                    {
                        answer = Convert.ToInt32(UserInterface.GetAnswerFromPlayerGameMode());
                        if (LogicalCode.CheckIfAnswerIsCorrect(answer, Data.allAnswers, Data.correctAnswers))
                        {
                            UserInterface.PrintWinMessageGameMode();
                            points = LogicalCode.WinPoints(points);
                            UserInterface.PrintPointsGameMode(points);
                            UserInterface.PressKeyToMoveOn();
                            UserInterface.ClearScreen();
                        }
                        else
                        {
                            UserInterface.PrintLoseMessageGameMode();
                            points = LogicalCode.LosePoints(points);
                            UserInterface.PrintPointsGameMode(points);
                        }
                    } while (!LogicalCode.CheckIfAnswerIsCorrect(answer, Data.allAnswers, Data.correctAnswers));
                }

                if (gameMode == Constants.CLOSE)
                {
                    break;
                }
            } while (gameMode != Constants.CLOSE);
        }
    }
}
