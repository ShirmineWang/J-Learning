using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class QuestionOption : BaseEntity
    {
        public string Text { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

    }
}
