using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOF.Models
{
    public class CommentsModel
    {
        public string Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public DateTime PostDate { get; set; }
        public string QuestionId { get; set; }
        public string AnswerId { get; set; }

        public CommentsModel()
        {
        }
    }
}