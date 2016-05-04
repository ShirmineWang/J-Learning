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

        public string Title { get; set; }

        public DateTime Time { get; set; }

        public virtual Forum Forum{ get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();
    }
}
