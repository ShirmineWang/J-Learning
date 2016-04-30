using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using J_LearingSystem.Models;
using J_LearningSystem.Data;

namespace J_LearningSystem.Controllers
{
    public class StaffController : Controller
    {
        StaffRepository rep = new StaffRepository();

        // GET: Staff
        public ActionResult Index()
        {
            IEnumerable<Staff> staffs = rep.GetAllStaff();
            return View(staffs);
        }

        // GET: Staff/Details/5
        public ActionResult Details(string id)
        {
            Staff staff = rep.GetStaff(id);
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
                rep.Add(staff);
                rep.Save();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(staff);
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(string id)
        {
            Staff staff = rep.GetStaff(id);
            return View(staff);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                Staff staff = rep.GetStaff(id);
                UpdateModel(staff);

                rep.Save();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(string id)
        {
            return View(rep.GetStaff(id));
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                rep.Delete(id);
                rep.Save();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}