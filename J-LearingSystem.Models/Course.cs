using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Course
    {
        [Key] [Required]
        public string CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public virtual Staff Staff { get; set; }
        private List<Quiz> quizs = new List<Quiz>();
        public virtual List<Quiz> Quizs
        {
            get
            {
                return quizs;
            }
            set
            {
                quizs = value;
            }
        }
        private List<Student> students = new List<Student>();
        public virtual List<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
            }
        }

        private List<Schedule> schedules = new List<Schedule>();
        public virtual List<Schedule> Schedules
        {
            get {
                return schedules;
            }
            set {
                schedules = value;
            }
        }
        public virtual Forum Forum { get; set; }
    }
}
