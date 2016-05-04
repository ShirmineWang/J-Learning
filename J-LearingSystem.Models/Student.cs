using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_LearingSystem.Models
{
    public class Student:Person
    {
        public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
