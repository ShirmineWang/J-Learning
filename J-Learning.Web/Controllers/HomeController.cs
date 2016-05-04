using J_LearingSystem.Models;
using J_LearningSystem.BL;
using J_LearningSystem.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace J_Learning.Web.Controllers {
    public class HomeController : Controller {

        public async Task<ActionResult> Index() {
            SystemContext db = HttpContext.GetOwinContext().Get<SystemContext>();
            ApplicationUserManager manager = HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            if (!db.Roles.Any()) {
                db.Roles.Add(new IdentityRole() { Id = "1", Name = "Admin" });
                db.Roles.Add(new IdentityRole() { Id = "2", Name = "Staff" });
                db.Roles.Add(new IdentityRole() { Id = "3", Name = "Student" });
                await db.SaveChangesAsync();

                var admin = new Staff()
                {
                    Id = "1",
                    Name = "Admin",
                    Email = "admin@test.com",
                    UserName = "admin@test.com",
                    PhoneNumber = "+6512345678"
                };
                var result = await manager.CreateAsync(admin, "Test*123");

                await manager.AddToRoleAsync(admin.Id, "Admin");
                
            }
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}