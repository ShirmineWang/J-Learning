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
        public string StaffID { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<Quiz> Quizs { get; set; } = new HashSet<Quiz>();
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();
//        public virtual Forum Forum { get; set; }
    }
}
