using System;
using System.Collections.Generic;

namespace AppDomain.Models
{
    public partial class Triviaanswer
    {
        public int Id { get; set; }
        public int Questionid { get; set; }
        public string Answer { get; set; } = null!;
        public int Points { get; set; }

        public virtual Triviaquestion Question { get; set; } = null!;
    }
}
