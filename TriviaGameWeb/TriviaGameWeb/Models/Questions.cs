using System;
using AppDomain.Models;
namespace TriviaGameWeb.Models
{
	public class Question
	{
		TriviaQuestionsContext _context = new TriviaQuestionsContext();
		public String Questions { get; set; }
		public String Answer { get; set; }

		public void GetQuestions(int? Id)
		{
			if(Id != null)
			{ 
                Questions = _context.Triviaquestions.Find(Id).Question;
				Answer = _context.Triviaquestions.Find(Id).Answer;
				return;
            }
            Questions = _context.Triviaquestions.Find(1).Question;
			Answer = _context.Triviaquestions.Find(1).Answer;
        }
	}
}

