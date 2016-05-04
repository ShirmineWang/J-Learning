using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_LearingSystem.Models
{

    public interface IBaseEntity {
        string Id { get; set; }
    }

    public abstract class BaseEntity : IBaseEntity {

        [Key]
        public string Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString("N"); // 128 bit
        }
    }
}
