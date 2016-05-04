using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Course : BaseEntity
    {

        [Required]
        public string Name { get; set; }
        public string StaffID { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<Quiz> Quizs { get; set; } = new HashSet<Quiz>();

        public virtual ICollection<Video> Videos { get; set; } = new HashSet<Video>();
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual Schedule Schedule { get; set; } 
//        public virtual Forum Forum { get; set; }
    }
}
