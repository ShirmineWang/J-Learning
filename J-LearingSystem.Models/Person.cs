using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public abstract class Person : BaseEntity
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();

        public virtual ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();

    }
}
