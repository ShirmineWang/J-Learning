using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Topic
    {
        [Key]
        [Required]
        public string TopicId { get; set; }

        public string TopicTitle { get; set; }

        public DateTime TopicTime { get; set; }

        public virtual Forum Forum{ get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();
    }
}
