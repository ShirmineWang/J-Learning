using J_LearingSystem.Models;
using J_Learning.Web.Models;
using J_LearningSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace J_Learning.Web.Controllers
{
    public class TopicController : BaseController
    {

        // GET: Topic/Details/5
        public ActionResult Details(string id)
        {
            var model = UnitOfWork.GetRepository<Topic>().GetById(id);
            return View(model);
        }

        // GET: Topic/Create
        public ActionResult Create(string courseId)
        {
            var model = new CreateTopicModel() { CourseId = courseId };
            return View(model);
        }

        // POST: Topic/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateTopicModel model)
        {
            if (ModelState.IsValid)
            {
                var topic = new Topic()
                {
                    Course = UnitOfWork.GetRepository<Course>().GetById(model.CourseId),
                    Person = await ApplicationUserManager.FindByNameAsync(User.Identity.Name),
                    Time = DateTime.Now,
                    Title = model.Title
                };
                UnitOfWork.GetRepository<Topic>().Add(topic);
                UnitOfWork.Save();
                return RedirectToAction("Details", "Course", new { id = topic.Course.Id });
            }
            return View(model);
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(string id)
        {
            var model = UnitOfWork.GetRepository<Topic>().GetById(id);
            return View("Create", new CreateTopicModel()
            {
                Id = model.Id,
                Title = model.Title,
                CourseId = model.Course.Id
            });
        }

        // POST: Quiz/Edit/5
        [HttpPost]
        public ActionResult Edit(CreateTopicModel model)
        {
            if (ModelState.IsValid)
            {
                var topic = UnitOfWork.GetRepository<Topic>().GetById(model.Id);

                topic.Title = model.Title;

                UnitOfWork.GetRepository<Topic>().Update(topic);
                UnitOfWork.Save();
                return RedirectToAction("Details", new { id = topic.Course.Id });
            }
            return View("Create", model);
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
            return RedirectToAction("Details", new { id = model.Course.Id });
        }
    }
}
