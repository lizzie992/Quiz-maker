using System.Net.Quic;

namespace Quiz_maker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string gameMode = string.Empty;
            string quizmaker = "q";
            string play = "p";
            string close = "c";
            Quiz quiz = new Quiz();

            do
            {
                UserInterface.PrintInstructionMenu();
                gameMode = Console.ReadLine().ToLower();

                if (gameMode == quizmaker)
                {
                    UserInterface.clearScreen();
                    UserInterface.printInstructionQuizMaker(Constants.NUMBER_OF_QUESTIONS, Constants.NUMBER_OF_ALL_ANSWERS, Constants.NUMBER_OF_CORRECT_ANSWERS);
                    UserInterface.pressKeyToMoveOn();
                    UserInterface.clearScreen();


                    for (int i = 0; i < Constants.NUMBER_OF_QUESTIONS; i++)
                    {
                        quiz.question = UserInterface.getQuestionFromUser();

                        for (int j = 0; j < Constants.NUMBER_OF_CORRECT_ANSWERS; j++)
                        {
                            quiz.correctAnswers.Add(UserInterface.getCorrectAnswer().ToLower());
                        }
                        for (int j = 0; j < Constants.NUMBER_OF_WRONG_ANSWERS; j++)
                        {
                            quiz.allAnswers.Add(UserInterface.getWrongAnswer().ToLower());
                        }
                        LogicalCode.SaveQuizToFile(Constants.FILEPATH, quiz.question, quiz.correctAnswers, quiz.allAnswers);
                        UserInterface.pressKeyToMoveOn();
                        UserInterface.clearScreen();
                    }
                }

                if (gameMode == play)
                {
                    UserInterface.clearScreen();
                    quiz.allAnswers.AddRange(quiz.correctAnswers);
                    quiz.allAnswers = LogicalCode.ShuffleTheList(Constants.NUMBER_OF_ALL_ANSWERS, quiz.allAnswers);
                    int points = 0;
                    UserInterface.PrintInstructionGame();
                    //here comes the part where I get a random question out of the file which is not clear for me yet:) so I am working with the 1 set of questions/answers
                    UserInterface.PrintQuestion(quiz.question);
                    UserInterface.PrintListOfAnswers(Constants.NUMBER_OF_ALL_ANSWERS, quiz.allAnswers);
                    int answer = 0;
                    do
                    {
                        answer = Convert.ToInt32(UserInterface.GetAnswerFromPlayer());
                        if (LogicalCode.CheckIfAnswerIsCorrect(answer, quiz.allAnswers, quiz.correctAnswers))
                        {
                            UserInterface.PrintWinMessage();
                            points = LogicalCode.WinPoints(points);
                            UserInterface.PrintPoints(points);
                            UserInterface.pressKeyToMoveOn();
                            UserInterface.clearScreen();
                        }
                        else
                        {
                            UserInterface.PrintLoseMessage();
                            points = LogicalCode.LosePoints(points);
                            UserInterface.PrintPoints(points);
                        }
                    } while (!LogicalCode.CheckIfAnswerIsCorrect(answer, quiz.allAnswers, quiz.correctAnswers));
                }

                if (gameMode == close)
                {
                    break;
                }
            } while (gameMode != close);
        }
    }
}
