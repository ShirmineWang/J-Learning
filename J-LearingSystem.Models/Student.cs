using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_LearingSystem.Models
{
    public class Student:Person
    {
        public virtual ICollection<QuestionOption> Answers { get; set; } = new HashSet<QuestionOption>();
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
