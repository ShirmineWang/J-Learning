using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace J_LearingSystem.Models
{
    public class QuestionOption : BaseEntity
    {
        public string Text { get; set; }

        public virtual Question Question { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

    }
}
