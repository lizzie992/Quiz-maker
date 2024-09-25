using System.Net.Quic;

namespace Quiz_maker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string gameMode = string.Empty;

            Quiz quiz = new Quiz();

            do
            {
                UserInterface.PrintInstructionMenu();
                gameMode = Console.ReadLine().ToLower();
                UserInterface.PressKeyToMoveOn();
                UserInterface.ClearScreen();

                if (gameMode == Constants.QUIZMAKER)
                {
                    UserInterface.PrintInstructionQuizMaker(Constants.NUMBER_OF_ALL_ANSWERS, Constants.NUMBER_OF_CORRECT_ANSWERS);
                    UserInterface.PressKeyToMoveOn(); 
                    UserInterface.ClearScreen();

                    int numberOfQuestions = 0;
                    numberOfQuestions = UserInterface.AskUserHowManyQuestionsQuizMaker(numberOfQuestions);
                    UserInterface.PressKeyToMoveOn();
                    UserInterface.ClearScreen();

                    Quiz quizData = UserInterface.CreateQuiz(numberOfQuestions);
                    LogicalCode.SaveQuizToFile(quizData);
                    UserInterface.PressKeyToMoveOn();
                    UserInterface.ClearScreen();
                }

                if (gameMode == Constants.PLAY)
                {
                    quiz.allAnswers.AddRange(quiz.correctAnswers);
                    quiz.allAnswers = LogicalCode.ShuffleTheList(Constants.NUMBER_OF_ALL_ANSWERS, quiz.allAnswers);
                    int points = 0;
                    UserInterface.PrintInstructionGameMode();
                    //here comes the part where I get a random question out of the file which is not clear for me yet:) so I am working with the 1 set of questions/answers
                    UserInterface.PrintQuestionGameMode(quiz.question);
                    UserInterface.PrintListOfAnswersGameMode(Constants.NUMBER_OF_ALL_ANSWERS, quiz.allAnswers);
                    int answer = 0;
                    do
                    {
                        answer = Convert.ToInt32(UserInterface.GetAnswerFromPlayerGameMode());
                        if (LogicalCode.CheckIfAnswerIsCorrect(answer, quiz.allAnswers, quiz.correctAnswers))
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
                    } while (!LogicalCode.CheckIfAnswerIsCorrect(answer, quiz.allAnswers, quiz.correctAnswers));
                }

                if (gameMode == Constants.CLOSE)
                {
                    break;
                }
            } while (gameMode != Constants.CLOSE);
        }
    }
}
