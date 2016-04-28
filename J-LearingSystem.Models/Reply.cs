using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Reply
    {
        [Key][Required]
        public string ReplyId { get; set; }
        public string ReplyText { get; set; }
        public DateTime ReplyTime { get; set; }
        public virtual Person Person { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
