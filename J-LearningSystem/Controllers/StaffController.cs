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
    public class StaffController : Controller
    {
        UnitOfWork uow = UnitOfWorkHelper.GetUnitOfWork();

        // GET: Staff
        public ActionResult Index()
        {
            IEnumerable<Staff> staffs = uow.StaffRepository.GetAll();
            return View(staffs);
        }

        // GET: Staff/Details/5
        public ActionResult Details(string id)
        {
            Staff staff = uow.StaffRepository.GetById(id);
            return View(staff);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            Staff staff = new Staff();
            return View(staff);
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            try
            {
                // TODO: Add insert logic here
                uow.StaffRepository.Add(staff);
                uow.StaffRepository.Save();
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
                return View(staff);
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(string id)
        {
            Staff staff = uow.StaffRepository.GetById(id);
            return View(staff);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Staff staff = uow.StaffRepository.GetById(id);
                UpdateModel(staff);

                uow.StaffRepository.Save();
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

        // GET: Staff/Delete/5
        public ActionResult Delete(string id)
        {
            return View(uow.StaffRepository.GetById(id));
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                uow.StaffRepository.Remove(uow.StaffRepository.GetById(id));
                uow.StaffRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
