using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Forum : BaseEntity
    {
        [Required]
        public DateTime OpenTime { get; set; }

        public DateTime ExpiryTime { get; set; }

        public virtual Course Course { get; set; }
  
        public virtual ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();
    }
}
