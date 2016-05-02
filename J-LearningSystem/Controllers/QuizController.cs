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
    public class QuizController : Controller
    {
            UnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

        // GET: Quiz
        public ActionResult Index()
            {
                IEnumerable<Quiz> quizs = uow.QuizRepository.GetAll();
                return View(quizs);
            }

        // GET: Quiz/Details/5
        public ActionResult Details(string id)
            {
            Quiz quiz = uow.QuizRepository.GetById(id);
                return View(quiz);
            }

        // GET: Quiz/Create
        public ActionResult Create()
            {
            Quiz quiz = new Quiz();
                return View(quiz);
            }

        // POST: Quiz/Create
        [HttpPost]
            public ActionResult Create(Quiz quiz)
            {
                try
                {
                    // TODO: Add insert logic here
                    uow.QuizRepository.Add(quiz);
                    uow.QuizRepository.Save();
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
                    return View(quiz);
                }
            }

        // GET: Quiz/Edit/5
        public ActionResult Edit(string id)
            {
            Quiz quiz = uow.QuizRepository.GetById(id);
                return View(quiz);
            }

        // POST: Quiz/Edit/5
        [HttpPost]
            public ActionResult Edit(string id, FormCollection collection)
            {
                try
                {
                // TODO: Add update logic here
                Quiz quiz = uow.QuizRepository.GetById(id);
                    UpdateModel(quiz);

                    uow.QuizRepository.Save();
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

        // GET: Quiz/Delete/5
        public ActionResult Delete(string id)
            {
                return View(uow.QuizRepository.GetById(id));
            }

        // POST: Quiz/Delete/5
        [HttpPost]
            public ActionResult Delete(string id, FormCollection collection)
            {
                try
                {
                    // TODO: Add delete logic here
                    uow.QuizRepository.Remove(uow.QuizRepository.GetById(id));
                    uow.QuizRepository.Save();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }
}
