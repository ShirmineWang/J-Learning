using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public abstract class Person
    {
        [Key][Required]
        public string MatricId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
