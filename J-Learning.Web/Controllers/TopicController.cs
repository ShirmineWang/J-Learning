using J_LearingSystem.Models;
using J_LearningSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace J_Learning.Web.Controllers
{
    public class TopicController : BaseController
    {
        // GET: Topic
        public ActionResult Index()
        {
            var list = UnitOfWork.GetRepository<Topic>().GetAll();
            return View(list);
        }

        // GET: Topic/Details/5
        public ActionResult Details(string id)
        {
            var model = UnitOfWork.GetRepository<Topic>().GetById(id);
            return View(model);
        }

        // GET: Topic/Create
        public ActionResult Create()
        {
            var model = new Topic();
            return View(model);
        }

        // POST: Topic/Create
        [HttpPost]
        public ActionResult Create(Topic topic)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.GetRepository<Topic>().Add(topic);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(string id)
        {
            var model = UnitOfWork.GetRepository<Topic>().GetById(id);
            return View(model);
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        public ActionResult Edit(Topic topic)
        {
            if (ModelState.IsValid)
            {
                var model = UnitOfWork.GetRepository<Topic>().GetById(topic.Id);
                //model.TimeCreated.ToString();
                model.Course = UnitOfWork.GetRepository<Course>().GetById(topic.Course.Id);
                UnitOfWork.GetRepository<Topic>().Update(model);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        // GET: Quiz/Delete/5
        public ActionResult Delete(string id)
        {
            var model = UnitOfWork.GetRepository<Topic>().GetById(id);
            return View(model);
        }

        // POST: Quiz/Delete/5
        [HttpPost]
        public ActionResult ConfirmDelete(string id)
        {
            var model = UnitOfWork.GetRepository<Topic>().GetById(id);
            UnitOfWork.GetRepository<Topic>().Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
