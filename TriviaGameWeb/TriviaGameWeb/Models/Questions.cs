using System;
using System.Linq;
using AppDomain;

namespace TriviaGameWeb.Models
{
    public class Questions
    {
        private AppDomain.Models.TriviaQuestionsContext _context = new AppDomain.Models.TriviaQuestionsContext();
        private AppDomain.Models.Triviaquestion question = new AppDomain.Models.Triviaquestion();
        //public List<String> questions { get; set; } 

        /*public Questions()
        {
        }*/

        public List<AppDomain.Models.Triviaquestion> getQuestions()
        {
            var quest =  _context.Triviaquestions.ToList();

            /*for(var idx = 0; idx < quest.Count; idx++)
            {
                questions.Insert(idx, quest[idx]);
            }*/
            return quest;    
        }
    }
}

