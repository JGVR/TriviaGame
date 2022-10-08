using System;
using AppDomain.Models;
namespace TriviaGameWeb.Models
{
	public class Question
	{
		TriviaQuestionsContext _context = new TriviaQuestionsContext();
		public String Questions { get; set; }
		public String CorrectAnswer { get; set; }
		public List<String> IncorrectAnswers { get; set; } = new List<string>();

		public void GetQuestions(int? Id)
		{
			if(Id != null)
			{ 
                Questions = _context.Triviaquestions.Find(Id).Question;
				CorrectAnswer = _context.Triviaquestions.Find(Id).Answer;
				return;
            }
            Questions = _context.Triviaquestions.Find(1).Question;
			CorrectAnswer = _context.Triviaquestions.Find(1).Answer;
        }

		public void GetAnswer(int? questionId)
		{
			var possibleAnswers = _context.Triviaanswers.ToList();
			if( questionId != null)
            {
				foreach(var answers in possibleAnswers)
                {
					if(answers.Questionid != questionId)
                    {
						continue;
                    }
					IncorrectAnswers.Add(answers.Answer);
                }
				return;
            }

            foreach (var answers in possibleAnswers)
            {
                if (answers.Questionid != 1)
                {
                    continue;
                }
                IncorrectAnswers.Add(answers.Answer);
            }
			return;
        }
	}
}

