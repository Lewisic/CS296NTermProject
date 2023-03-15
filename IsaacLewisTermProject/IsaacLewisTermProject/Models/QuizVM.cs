namespace IsaacLewisTermProject.Models
{
    public class QuizVM
    {
        const string RIGHT = "Correct";
        const string WRONG = "Incorrect";
        public string UserAnswer1 { get; set; }
        public string RightOrWrong1 { get; set; }

        public string UserAnswer2 { get; set; }
        public string RightOrWrong2 { get; set; }

        public string UserAnswer3 { get; set; }
        public string RightOrWrong3 { get; set; }

        public string UserAnswer4 { get; set; }
        public string RightOrWrong4 { get; set; }

        public void CheckAnswers()
        {
            RightOrWrong1 = UserAnswer1 == "rage" ? RIGHT : WRONG;
            RightOrWrong2 = UserAnswer2 == "chromatic" ? RIGHT : WRONG;
            RightOrWrong3 = UserAnswer3 == "illithid" ? RIGHT : WRONG;
            RightOrWrong4 = UserAnswer4 == "hp" ? RIGHT : WRONG;
        }
    }
}
