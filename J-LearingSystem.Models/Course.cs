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

        [Required]
        public string Number { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual Schedule Schedule { get; set; } 

        public virtual ICollection<Quiz> Quizs { get; set; } = new HashSet<Quiz>();

        public virtual ICollection<Video> Videos { get; set; } = new HashSet<Video>();

        public virtual ICollection<Forum> Forums { get; set; } = new HashSet<Forum>();

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
       

    }
}
