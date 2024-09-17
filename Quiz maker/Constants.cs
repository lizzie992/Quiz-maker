using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_maker
{
    class Constants
    {
        public const int NUMBER_OF_QUESTIONS = 1;
        public const int NUMBER_OF_ALL_ANSWERS = 4;
        public const int NUMBER_OF_CORRECT_ANSWERS = 1; //in case we have multiple correct answers for extra difficulty
        public const int NUMBER_OF_WRONG_ANSWERS = NUMBER_OF_ALL_ANSWERS - NUMBER_OF_CORRECT_ANSWERS;
        public const string FILEPATH = "..."; //to be added:)
        public const int WIN_POINTS = 3;
        public const int LOSE_POINTS = 1;

    }
}
