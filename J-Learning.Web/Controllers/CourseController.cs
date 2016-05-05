using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using J_LearingSystem.Models;
using J_LearningSystem.Data;

namespace J_Learning.Web.Controllers
{
    public class CourseController : BaseController
    {
        
        public ActionResult Index()
        {
            var list = UnitOfWork.GetRepository<Course>().GetAll();
            return View(list);
        }

        public ActionResult Details(string id)
        {
            var model = UnitOfWork.GetRepository<Course>().GetById(id);
            return View(model);
        }

        protected void StaffDropDownList(string selectedId = null)
        {
            if (string.IsNullOrEmpty(selectedId))
                ViewBag.StaffSelectList = new SelectList(UnitOfWork.GetRepository<Staff>().GetAll(), "Id", "Name").AsEnumerable();
            else
                ViewBag.StaffSelectList = new SelectList(UnitOfWork.GetRepository<Staff>().GetAll(), "Id", "Name", selectedId).AsEnumerable();
        }


        public ActionResult Create(string scheduleId)
        {
            var schedule  = UnitOfWork.GetRepository<Schedule>().GetById(scheduleId);
            if (schedule == null) return HttpNotFound();

            var model = new Course()
            {
                 Schedule = new Schedule() { Id = scheduleId }
            };
            StaffDropDownList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                course.Schedule = UnitOfWork.GetRepository<Schedule>().GetById(course.Schedule.Id);
                course.Staff = UnitOfWork.GetRepository<Staff>().GetById(course.Staff.Id);
                UnitOfWork.GetRepository<Course>().Add(course);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            StaffDropDownList(course.Staff.Id);
            return View(course);
        }

        public ActionResult Edit(string id)
        {
            var model = UnitOfWork.GetRepository<Course>().GetById(id);
            StaffDropDownList(model.Staff.Id);
            return View(model);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                var model = UnitOfWork.GetRepository<Course>().GetById(course.Id);
                model.Name = course.Name;
                model.Number = course.Number;
                model.Staff = UnitOfWork.GetRepository<Staff>().GetById(course.Staff.Id);
                model.Schedule.ToString();
                UnitOfWork.GetRepository<Course>().Update(model);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            StaffDropDownList(course.Staff.Id);
            return View(course);
        }

        public ActionResult Delete(string id)
        {
            var model = UnitOfWork.GetRepository<Course>().GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(string id)
        {
            var model = UnitOfWork.GetRepository<Course>().GetById(id);
            UnitOfWork.GetRepository<Course>().Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
