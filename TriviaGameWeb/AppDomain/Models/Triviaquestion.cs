using System;
using System.Collections.Generic;

namespace AppDomain.Models
{
    public partial class Triviaquestion
    {
        public Triviaquestion()
        {
            Triviaanswers = new HashSet<Triviaanswer>();
        }

        public int Id { get; set; }
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public int Difficulty { get; set; }
        public int Point { get; set; }

        public virtual ICollection<Triviaanswer> Triviaanswers { get; set; }
    }
}
