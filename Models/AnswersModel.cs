using System;
using SOF.Models;

namespace SOF.Models
{
    public class AnswersModel
    {
        public string Id { get; set; }
        public int VoteCount { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public DateTime PostDate { get; set; }
        public string QuestionId { get; set; }
        public AnswersModel()
        {
        }
    }
}