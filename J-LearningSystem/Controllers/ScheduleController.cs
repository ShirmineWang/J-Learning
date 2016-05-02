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
    public class ScheduleController : Controller
    {
        UnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

        // GET: Schedule
        public ActionResult Index()
        {
            IEnumerable<Schedule> schedules = uow.ScheduleRepository.GetAll();
            return View(schedules);
        }

        // GET: Schedule/Details/5
        public ActionResult Details(string id)
        {
            Schedule schedule = uow.ScheduleRepository.GetById(id);
            return View(schedule);
        }

        // GET: Schedule/Create
        public ActionResult Create()
        {
            Schedule schedule = new Schedule();
            return View(schedule);
        }

        // POST: Schedule/Create
        [HttpPost]
        public ActionResult Create(Schedule schedule)
        {
            try
            {
                // TODO: Add insert logic here
                uow.ScheduleRepository.Add(schedule);
                uow.ScheduleRepository.Save();
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
                return View(schedule);
            }
        }

        // GET: Schedule/Edit/5
        public ActionResult Edit(string id)
        {
            Schedule schedule = uow.ScheduleRepository.GetById(id);
            return View(schedule);
        }

        // POST: Schedule/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Schedule schedule = uow.ScheduleRepository.GetById(id);
                UpdateModel(schedule);

                uow.ScheduleRepository.Save();
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

        // GET: Schedule/Delete/5
        public ActionResult Delete(string id)
        {
            return View(uow.ScheduleRepository.GetById(id));
        }

        // POST: Schedule/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                uow.ScheduleRepository.Remove(uow.ScheduleRepository.GetById(id));
                uow.ScheduleRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
