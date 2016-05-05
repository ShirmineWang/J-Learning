using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using J_LearingSystem.Models;
using J_LearningSystem.Data;

namespace J_Learning.Web.Controllers
{
    public class ScheduleController : BaseController
    {
        public ActionResult Index()
        {
            var list = UnitOfWork.GetRepository<Schedule>().GetAll();
            return View(list);
        }

        public ActionResult Details(string id)
        {
            var model = UnitOfWork.GetRepository<Schedule>().GetById(id);
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new Schedule()
            {
                 StartTime = DateTime.Now,
                 StopTime = DateTime.Now.AddMonths(1)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Schedule model)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.GetRepository<Schedule>().Add(model);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var model = UnitOfWork.GetRepository<Schedule>().GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                var model = UnitOfWork.GetRepository<Schedule>().GetById(schedule.Id);
                model.StartTime = schedule.StartTime;
                model.StopTime = schedule.StopTime;
                UnitOfWork.GetRepository<Schedule>().Update(model);
                UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        public ActionResult Delete(string id)
        {
            var model = UnitOfWork.GetRepository<Schedule>().GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(string id)
        {
            var model = UnitOfWork.GetRepository<Schedule>().GetById(id);
            UnitOfWork.GetRepository<Schedule>().Remove(model);
            UnitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
