using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace J_LearingSystem.Models
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }

        public string CorrectOption { get; set; }

        public virtual Quiz Quiz { get; set; }

        public virtual ICollection<QuestionOption> QuestionOptions { get; set; } = new HashSet<QuestionOption>();
    }
}
