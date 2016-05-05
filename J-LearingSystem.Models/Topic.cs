using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Topic : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public virtual Course Course { get; set; }

        [Required]
        public virtual Person Person { get; set; }

        public virtual ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();

        public Topic() {
            Time = DateTime.Now;
        }
    }
}
