using J_LearingSystem.Models;
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
        // GET: Quiz
        public ActionResult Index()
        {
            var list = UnitOfWork.GetRepository<Quiz>().GetAll();
            return View(list);
        }

        // GET: Quiz/Details/5
        public ActionResult Details(string id)
        {
            var model = UnitOfWork.GetRepository<Quiz>().GetById(id);
            return View(model);
        }

        // GET: Quiz/Create
        public ActionResult Create()
        {
            var model = new Quiz();
            return View(model);
        }

        // POST: Quiz/Create
        [HttpPost]
        public ActionResult Create(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.GetRepository<Quiz>().Add(quiz);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(quiz);
        }

        // GET: Quiz/Edit/5
        public ActionResult Edit(string id)
        {
            var model = UnitOfWork.GetRepository<Quiz>().GetById(id);
            return View(model);
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        public ActionResult Edit(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                var model = UnitOfWork.GetRepository<Quiz>().GetById(quiz.Id);
                model.TimeCreated.ToString();
                model.Course = UnitOfWork.GetRepository<Course>().GetById(quiz.Course.Id);
                UnitOfWork.GetRepository<Quiz>().Update(model);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(quiz);
        }

        // GET: Quiz/Delete/5
        public ActionResult Delete(string id)
        {
            var model = UnitOfWork.GetRepository<Quiz>().GetById(id);
            return View(model);
        }

        // POST: Quiz/Delete/5
        [HttpPost]
        public ActionResult ConfirmDelete(string id)
        {
            var model = UnitOfWork.GetRepository<Quiz>().GetById(id);
            UnitOfWork.GetRepository<Quiz>().Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
