using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J_LearingSystem.Models;

namespace J_LearningSystem.Data
{
    public class StudentRepository
    {
        SystemContext db = new SystemContext();

        public Student GetStudent(string id)
        {
            return db.Students.Single(s => s.MatricId == id);
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return db.Students;
        }
        public void Add(Student student)
        {
            for(int i = 0; i < student.Courses.Count; i++)
            {
                string courseId = student.Courses[i].CourseId;
                Course existingCourse = db.Courses.SingleOrDefault(e => e.CourseId == courseId);
                if(existingCourse!=null)
                {
                    student.Courses[i] = existingCourse;
                }
            }
            for(int i = 0; i < student.Answers.Count; i++)
            {
                string answerId = student.Answers[i].AnswerId;
                Answer existingAnswer = db.Answers.SingleOrDefault(e => e.AnswerId == answerId);
                if (existingAnswer != null)
                {
                    student.Answers[i] = existingAnswer;
                }
            }
            db.Students.Add(student);              
        }
        public IEnumerable<Course> GetAllCourses()
        {
            return db.Courses;
        }
        public IEnumerable<Answer> GetAllAnswers()
        {
            return db.Answers;
        }
        public void Delete(string id)
        {
            Student student = db.Students.Single(s => s.MatricId == id);
            db.Students.Remove(student);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
