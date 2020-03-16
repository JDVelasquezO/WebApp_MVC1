using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EntityLayer;
using BusinessLogic;

namespace PresentationLayer.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        TeacherLogic teacher = new TeacherLogic();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListTeachers()
        {
            return View(teacher.listTeacher());
        }
    }
}