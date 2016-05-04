using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Reply : BaseEntity
    {
        public string Text { get; set; }

        public DateTime Time { get; set; }

        public virtual Person Person { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
