using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_LearingSystem.Models
{
    public class Student:Person
    {
        public virtual ICollection<QuestionOption> Answers { get; set; } = new HashSet<QuestionOption>();
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        [NotMapped]
        public IEnumerable<Course> EnrolledCourses
        {
            get
            {
                return Courses.Where(x => x.Schedule.StartTime <= DateTime.Now && x.Schedule.StopTime >= DateTime.Now);
            }
        }

        [NotMapped]
        public IEnumerable<Quiz> OpenQuizzes
        {
            get
            {
                var allQuizzes = EnrolledCourses.SelectMany(x => x.Quizs);
                var answerdQuizzes = Answers.Select(x => x.Question.Quiz);
                return allQuizzes.Except(answerdQuizzes);
            }
        }
    }
}
