using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Quiz : BaseEntity
    {
        [Required]
        public virtual Course Course { get; set; }

        [Required]
        public DateTime TimeCreated { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>(); 

        public Quiz() {
            TimeCreated = DateTime.Now;
        }
    }
}
