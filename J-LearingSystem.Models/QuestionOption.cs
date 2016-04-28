using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class QuestionOption
    {
        [Key][Required]
        public string QuestionOptionId { get; set; }
        public string OptionText { get; set; }
        public char Option { get; set; }
        public virtual Question Question { get; set; }
    }
}
