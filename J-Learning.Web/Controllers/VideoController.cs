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
    public class VideoController : BaseController
    {

        public ActionResult Details(string id)
        {
            var model = UnitOfWork.GetRepository<Video>().GetById(id);
            return View(model);
        }

        public ActionResult Create(string courseId)
        {
            var model = new CreateVideoModel() { CourseId = courseId };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateVideoModel model, HttpPostedFileBase videoFile)
        {
            if (!System.IO.Path.GetExtension(videoFile.FileName).ToLower().Equals(".mp4")) {
                ModelState.AddModelError("videoFile", "File should be .mp4 Only!");
            }

            if (ModelState.IsValid) {
                var fileName = Guid.NewGuid().ToString("N") + System.IO.Path.GetExtension(videoFile.FileName);

                videoFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Content/Uploads"), fileName));

                var Video = new Video()
                {
                    Course = UnitOfWork.GetRepository<Course>().GetById(model.CourseId),
                    Time = DateTime.Now,
                    Title = model.Title,
                    FileName = fileName
                };
                UnitOfWork.GetRepository<Video>().Add(Video);
                UnitOfWork.Save();
                return RedirectToAction("Details", "Course", new { id = Video.Course.Id });
            }
            return View(model);
        }
        
        public ActionResult Delete(string id)
        {
            var model = UnitOfWork.GetRepository<Video>().GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(string id)
        {
            var model = UnitOfWork.GetRepository<Video>().GetById(id);
            UnitOfWork.GetRepository<Video>().Remove(model);
            UnitOfWork.Save();
            System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath("~/Content/Upload"), model.FileName));
            return RedirectToAction("Details", new { id = model.Course.Id });
        }
    }
}
