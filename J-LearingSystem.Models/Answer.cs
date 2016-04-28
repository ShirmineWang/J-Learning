using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Answer
    {
        [Key][Required]
        public string AnswerId { get; set; }
        public virtual QuestionOption QuestionOption { get; set; }

        private List<Student> students = new List<Student>();
        public virtual List<Student> Students {
            get
            {
                return students;
            }
            set
            {
                students = value;
            }
        }
    }
}
