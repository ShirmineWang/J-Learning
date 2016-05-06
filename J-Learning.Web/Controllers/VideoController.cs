using J_LearingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace J_Learning.Web.Controllers
{
    public class VideoController: BaseController
    {
        public ActionResult Index()
        {
            var list = UnitOfWork.GetRepository<Video>().GetAll();
            return View(list);
        }

        public ActionResult Create(string courseId)
        {
            var course = UnitOfWork.GetRepository<Course>().GetById(courseId);
            if (course == null) return HttpNotFound();

            var model = new Video()
            {
                Course  = new Course() { Id = courseId }
            };
            //StaffDropDownList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Video video)
        {
            if (ModelState.IsValid)
            {
                video.Course = UnitOfWork.GetRepository<Course>().GetById(video.Course.Id);
                //video.Staff = UnitOfWork.GetRepository<Staff>().GetById(course.Staff.Id);
                UnitOfWork.GetRepository<Video>().Add(video);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            //StaffDropDownList(course.Staff.Id);
            return View(video);
        }

        public ActionResult Edit(string id)
        {
            var model = UnitOfWork.GetRepository<Video>().GetById(id);
            return View(model);
        }

        public ActionResult Edit(Video video)
        {
            if (ModelState.IsValid)
            {
                var model = UnitOfWork.GetRepository<Video>().GetById(video.Id);
                model.FileName = video.FileName;
                model.Time = video.Time;
                model.Course = video.Course;
                UnitOfWork.GetRepository<Video>().Update(model);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(video);
        }

        public ActionResult Delete(string id)
        {
            var model = UnitOfWork.GetRepository<Video>().GetById(id);
            return View(model);
        }

        public ActionResult ConfirmDelete(string id)
        {
            var model = UnitOfWork.GetRepository<Video>().GetById(id);
            UnitOfWork.GetRepository<Video>().Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}