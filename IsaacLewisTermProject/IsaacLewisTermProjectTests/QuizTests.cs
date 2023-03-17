using IsaacLewisTermProject.Models;
using System;
using Xunit;

namespace IsaacLewisTermProjectTests
{
    public class QuizTests
    {
        [Fact]
        public void RightAnswerTest()
        {
            var correct = "Correct";
            var quiz = new QuizVM()
            {
                UserAnswer1 = "rage",
                UserAnswer2 = "chromatic",
                UserAnswer3 = "illithid",
                UserAnswer4 = "hp"
            };

            quiz.CheckAnswers();

            Assert.True(correct == quiz.RightOrWrong1 && correct == quiz.RightOrWrong2 && correct == quiz.RightOrWrong3 && 
                correct == quiz.RightOrWrong4);
        }

        [Fact]
        public void WrongAnswerTest()
        {
            var incorrect = "Incorrect";
            var quiz = new QuizVM()
            {
                UserAnswer1 = "intimidation",
                UserAnswer2 = "aberrant",
                UserAnswer3 = "malcanthet",
                UserAnswer4 = "ac"
            };

            quiz.CheckAnswers();

            Assert.True(incorrect == quiz.RightOrWrong1 && incorrect == quiz.RightOrWrong2 && incorrect == quiz.RightOrWrong3 &&
                incorrect == quiz.RightOrWrong4);
        }
    }
}
