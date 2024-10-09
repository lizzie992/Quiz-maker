

namespace Quiz_maker
{
    class Constants
    {
        public const int NUMBER_OF_ALL_ANSWERS = 4;
        public const int NUMBER_OF_CORRECT_ANSWERS = 1; //in case we have multiple correct answers for extra difficulty
        public const int NUMBER_OF_WRONG_ANSWERS = NUMBER_OF_ALL_ANSWERS - NUMBER_OF_CORRECT_ANSWERS;
        public const int WIN_POINTS = 3;
        public const int LOSE_POINTS = 1;
        public const string QUIZ_MAKER = "q";
        public const string PLAY = "p";
        public const string CLOSE = "c";
        public const string PATH = @"..\..\..\..\QuizData.xml";
        public const string NEXT_QUESTION = "n";
    }
}
