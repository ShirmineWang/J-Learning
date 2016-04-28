using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace J_LearingSystem.Models
{
    public class Schedule
    {
        [Key][Required]
        public string ScheduleId;
        [Required]
        public DateTime StartTime;
        [Required]
        public DateTime StopTime;

        private List<Course> courses = new List<Course>();
        public virtual List<Course> Courses
        {
            get
            {
                return courses;
            }
            set
            {
                courses = value;
            }
        }
    }
}
