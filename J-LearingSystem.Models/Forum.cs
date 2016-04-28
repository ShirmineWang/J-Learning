using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Forum
    {
        [Key][Required]
        public string ForumId { get; set; }
        [Required]
        public DateTime OpenTime { get; set; }
        public DateTime ExpiryTime { get; set; }
        public virtual Course Course { get; set; }
        private List<Topic> topics = new List<Topic>();
        public virtual List<Topic> Topics
        {
            get
            {
                return topics;
            }
            set
            {
                topics = value;
            }
        }
    }
}
