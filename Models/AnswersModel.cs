using System;
using SOF.Models;

namespace SOF.Models
{
    public class AnswersModel
    {
        public string Id { get; set; }
        public string AnswerText { get; set; }
        public DateTime AnswerTime { get; set; } = DateTime.Now;

        public int yesVote { get; set; }

        public int noVote { get; set; }

        public bool IsCorrectAnsw { get; set; }

        //FK :User
        public string ApplicationUserID { get; set; }
        public  virtual ApplicationUser ApplicationUser {get; set;}

        //FK: Questions 

        public int QuestionId { get; set; }
        public QuestionsModel Question { get; set; }
        public AnswersModel()
        {
        }
    }
}