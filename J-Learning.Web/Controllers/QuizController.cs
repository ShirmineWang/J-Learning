using J_LearingSystem.Models;
using J_Learning.Web.Models;
using J_LearningSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace J_Learning.Web.Controllers
{
    public class QuizController : BaseController
    {
        public ActionResult Details(string id)
        {
            var model = UnitOfWork.GetRepository<Quiz>().GetById(id);
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new Quiz();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateQuizModel model)
        {
            if (ModelState.IsValid)
            {
                var quiz = new Quiz()
                {
                    Course = UnitOfWork.GetRepository<Course>().GetById(model.CourseId),
                    TimeCreated = DateTime.Now,
                    Title = model.Title
                };
                UnitOfWork.GetRepository<Quiz>().Add(quiz);
                UnitOfWork.Save();
                return RedirectToAction("Details", "Course", new { id = quiz.Course.Id });
            }
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var model = UnitOfWork.GetRepository<Quiz>().GetById(id);
            return View("Create", new CreateQuizModel()
            {
                Id = model.Id,
                Title = model.Title,
                CourseId = model.Course.Id
            });
        }

        [HttpPost]
        public ActionResult Edit(CreateQuizModel model)
        {
            if (ModelState.IsValid) {
                var quiz = UnitOfWork.GetRepository<Quiz>().GetById(model.Id);

                quiz.Title = model.Title;

                UnitOfWork.GetRepository<Quiz>().Update(quiz);
                UnitOfWork.Save();
                return RedirectToAction("Details", new { id = quiz.Course.Id });
            }
            return View("Create", model);
        }

        public ActionResult Delete(string id)
        {
            var model = UnitOfWork.GetRepository<Quiz>().GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(string id)
        {
            var model = UnitOfWork.GetRepository<Quiz>().GetById(id);
            UnitOfWork.GetRepository<Quiz>().Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Details", new { id = model.Course.Id });
        }
    }
}
