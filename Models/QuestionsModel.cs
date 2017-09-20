using System;
namespace SOF.Models
{
    public class QuestionsModel
    {
		public string Id { get; set; }
		public int VoteCount { get; set; }
		public string Title { get; set; } 
        public string Body { get; set; }  
        public string ApplicationUserId { get; set; } //makes Id's unique
        public ApplicationUser ApplicationUser {get; set;} // same? ^
		public DateTime PostDate { get; set; } = DateTime.Now; 
        public int yesVote { get; set; }
        public int noVote { get; set; }
        public QuestionsModel()
        {
        }
    }
}