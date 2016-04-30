using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J_LearingSystem.Models;

namespace J_LearningSystem.Data
{
    public class CourseRepository : Repository<Course>
    {
        public CourseRepository(SystemContext db) : base(db)
        {

        }
    }
}
