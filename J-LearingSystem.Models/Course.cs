using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace J_LearingSystem.Models
{
    public class Course : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public virtual Staff Staff { get; set; }

        [Required]
        public virtual Schedule Schedule { get; set; } 

        public virtual ICollection<Quiz> Quizs { get; set; } = new HashSet<Quiz>();

        public virtual ICollection<Video> Videos { get; set; } = new HashSet<Video>();

        public virtual ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
       

        [NotMapped]
        public bool IsInCurrentSchedule
        {
            get
            {
                if (Schedule == null) return false;
                return (Schedule.StartTime <= DateTime.Now && Schedule.StopTime >= DateTime.Now);
            }
        }
    }
}
