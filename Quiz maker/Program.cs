using System.Net.Quic;

namespace Quiz_maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface.printInstructionQuizMaker(Constants.NUMBER_OF_QUESTIONS, Constants.NUMBER_OF_ALL_ANSWERS, Constants.NUMBER_OF_CORRECT_ANSWERS);
            UserInterface.pressKeyToMoveOn();
            UserInterface.clearScreen();

            //building the quiz:
            Quiz quiz = new Quiz();
            for (int i = 0; i < Constants.NUMBER_OF_QUESTIONS; i++)
            {
                quiz.question = UserInterface.getQuestionFromUser();

                for (int j = 0; j < Constants.NUMBER_OF_CORRECT_ANSWERS; j++)
                {
                    quiz.correctAnswers.Add(UserInterface.getCorrectAnswer().ToLower());
                }
                for (int j = 0; j < Constants.NUMBER_OF_WRONG_ANSWERS; j++)
                {
                    quiz.wrongAnswers.Add(UserInterface.getWrongAnswer().ToLower());
                }
                LogicalCode.Serializer(Constants.FILEPATH, quiz.question, quiz.correctAnswers, quiz.wrongAnswers);
                UserInterface.pressKeyToMoveOn();
                UserInterface.clearScreen();

            }

            //playing the quiz:
            quiz.allAnswers.AddRange(quiz.correctAnswers);
            quiz.allAnswers.AddRange(quiz.wrongAnswers);
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
                }
                else
                {
                    UserInterface.PrintLoseMessage();
                    points = LogicalCode.LosePoints(points);
                    UserInterface.PrintPoints(points);
                }
            } while (!LogicalCode.CheckIfAnswerIsCorrect(answer, quiz.allAnswers, quiz.correctAnswers));

        }
}
}
