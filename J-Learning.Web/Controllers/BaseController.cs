using J_LearningSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace J_Learning.Web.Controllers
{
    public class BaseController : Controller
    {

        
        public BaseController()
        {
           
        }

        private SystemContext _db;
        private SystemContext Db
        {
            get
            {
                if(_db == null) _db = HttpContext.GetOwinContext().Get<SystemContext>();
                return _db;
            }
        }

        private UnitOfWork _unitOfWork;
        public UnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork == null) _unitOfWork = new UnitOfWork(Db);
                return _unitOfWork;
            }
        }
    }
}