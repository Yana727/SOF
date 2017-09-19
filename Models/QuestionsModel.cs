using System;
namespace SOF.Models
{
    public class QuestionsModel
    {
		public string Id { get; set; }
		public int VoteCount { get; set; }
		public string Title { get; set; } 
        public string Body { get; set; }  
        public string ApplicationUserId { get; set; } //added this to reference in controller
		public DateTime PostDate { get; set; } = DateTime.Now; 
        public QuestionsModel()
        {
        }
    }
}