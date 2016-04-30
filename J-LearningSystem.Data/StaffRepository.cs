using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J_LearingSystem.Models;

namespace J_LearningSystem.Data
{
    public class StaffRepository : BaseRepository<Staff>
    {
        public StaffRepository() : base()
        {

        }
    }
    /*
    public class StaffRepository
    {
        SystemContext db = new SystemContext();
        
        public Staff GetStaff(string id)
        {
            return db.Staffs.Single(s => s.MatricId == id);
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            return db.Staffs;
        }

        public void Add(Staff staff)
        {
            for (int i = 0; i < staff.Courses.Count; i++)
            {
                string courseId = staff.Courses[i].CourseId;
                Course existingCourse = db.Courses.SingleOrDefault(e => e.CourseId == courseId);
                if (existingCourse != null)
                {
                    staff.Courses[i] = existingCourse;
                }
            }
            db.Staffs.Add(staff);
        }
        public IEnumerable<Course> GetAllCourses()
        {
            return db.Courses;
        }
        public void Delete(string id)
        {
            Staff staff = db.Staffs.Single(s => s.MatricId == id);
            db.Staffs.Remove(staff);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
    */
}
