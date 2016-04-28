using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_LearingSystem.Models
{
    public class Student:Person
    {
        private List<Answer> answers;
        public virtual List<Answer> Answers
        {
            get
            {
                return answers;
            }
            set
            {
                answers = value;
            }
        }
        private List<Course> courses;
        public virtual List<Course> Courses
        {
            get
            {
                return courses;
            }
            set
            {
                courses = value;
            }
        }
    }
}
