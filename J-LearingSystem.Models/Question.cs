using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Question
    {
        [Key][Required]
        public string QuestionId { get; set; }
        public string Text { get; set; }
        public char RightOption { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; } = new HashSet<QuestionOption>();
    }
}
