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
        private List<QuestionOption> questionOptions = new List<QuestionOption>();
        public virtual List<QuestionOption> QuestionOptions
        {
            get
            {
                return questionOptions;
            }
            set
            {
                questionOptions = value;
            }
        }

    }
}
