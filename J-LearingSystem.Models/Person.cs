using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace J_LearingSystem.Models
{
    public abstract class Person : IdentityUser, IBaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Reply> Replies { get; set; } = new HashSet<Reply>();

        public virtual ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();

    }
}
