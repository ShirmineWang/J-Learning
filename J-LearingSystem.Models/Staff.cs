using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Staff : Person {
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}