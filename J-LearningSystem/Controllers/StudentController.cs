using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using J_LearningSystem.Models;
using J_LearningSystem.Data;
using J_LearingSystem.Models;
using System.Data.Entity.Validation;

namespace J_LearningSystem.Controllers
{
    public class StudentController : Controller
    {
        //        SystemContext sc = new SystemContext();

        UnitOfWork uow = new UnitOfWork();
       
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<Student> students = uow.StudentRepository.GetAll(); 
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            Student student = uow.StudentRepository.GetById(id);
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            Student student = new Student();
            return View(student);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                uow.StudentRepository.Add(student);
                uow.StudentRepository.Save();
                return RedirectToAction("Index");
            }
            catch(Exception e)
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
                return View(student);
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            Student student = uow.StudentRepository.GetById(id);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Student student = uow.StudentRepository.GetById(id);
                UpdateModel(student);

                uow.StudentRepository.Save();
                return RedirectToAction("Index");
            }
            catch(Exception e)
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

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            return View(uow.StudentRepository.GetById(id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(string id,FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                uow.StudentRepository.Remove(uow.StudentRepository.GetById(id));
                uow.StudentRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
