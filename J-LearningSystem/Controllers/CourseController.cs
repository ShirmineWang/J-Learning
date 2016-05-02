using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using J_LearningSystem.Data;
using J_LearingSystem.Models;
using System.Data.Entity.Validation;

namespace J_LearningSystem.Controllers
{
    public class CourseController : Controller
    {
        UnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

        // GET: Course
        public ActionResult Index()
        {
            IEnumerable<Course> courses = uow.CourseRepository.GetAll();
            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(string id)
        {
            Course course = uow.CourseRepository.GetById(id);
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            /*
            Course course = new Course();
            */
            PopulateStaffDropDownList();
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                // TODO: Add insert logic here
                //if (ModelState.IsValid)
                //{
                    Staff staff= uow.StaffRepository.GetById(course.StaffID);
                    course.Staff = staff;
                    staff.Courses.Add(course);
                    uow.CourseRepository.Add(course);
                    uow.CourseRepository.Save();
                    uow.StaffRepository.Save();
                    return RedirectToAction("Index");
               // }
                
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof(DbEntityValidationException))
                {
                    if (this.HttpContext.IsDebuggingEnabled)
                    {
                        ModelState.AddModelError(string.Empty, e.ToString());
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Some technical error happened.");
                    }
                }
                PopulateStaffDropDownList(course.Staff.MatricId);
                return View(course);
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(string id)
        {
            Course course = uow.CourseRepository.GetById(id);
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Course course = uow.CourseRepository.GetById(id);
                UpdateModel(course);

                uow.CourseRepository.Save();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof(DbEntityValidationException))
                {
                    if (this.HttpContext.IsDebuggingEnabled)
                    {
                        ModelState.AddModelError(string.Empty, e.ToString());
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Some technical error happened.");
                    }
                }
                return View();
            }
        }

        private void PopulateStaffDropDownList(object selectedStaff = null)
        {
            var staffQuery = from d in uow.getSystemContext().Staffs
                                   orderby d.Name
                                   select d;
            ViewBag.staffID = new SelectList(staffQuery,"MatricId","Name",selectedStaff);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(string id)
        {
            return View(uow.CourseRepository.GetById(id));
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                uow.CourseRepository.Remove(uow.CourseRepository.GetById(id));
                uow.CourseRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
