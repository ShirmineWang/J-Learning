using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Quiz
    {
        [Key][Required]
        public string QuizId { get; set; }
        public virtual Course Course { get; set; }
        private List<Question> questions;
        public virtual List<Question> Questions
        {
            get
            {
                return questions;
            }
            set
            {
                questions = value;
            }
        } 
    }
}
