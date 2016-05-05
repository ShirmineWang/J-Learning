using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace J_LearingSystem.Models
{
    public class Staff : Person {
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        [NotMapped]
        public IEnumerable<Quiz> Quizzes {
            get {
                return Courses
                    .SelectMany(x => x.Quizs)
                    .Where(x=>x.Course.IsInCurrentSchedule)
                    .OrderByDescending(x=>x.TimeCreated)
                    .Take(10);
            }
        }
    }
}