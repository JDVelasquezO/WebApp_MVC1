using BusinessLogic;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class CourseController : Controller
    {
        CourseLogic courseLogic = new CourseLogic();

        // GET: Course
        public ActionResult ListCourse()
        {
            return View(courseLogic.listCourse());
        }

        public ActionResult AddCourse()
        {
            List<TeacherEntity> listTeacher = new List<TeacherEntity>();
            TeacherLogic teacherLogic = new TeacherLogic();
            listTeacher = teacherLogic.listTeacher(); // Obtenemos la lista de todos los profesores
            ViewBag.ListTeachers = listTeacher; // Lo guardamos en un ViewBag

            return View();
        }

        public ActionResult InsertCourse(string cbxTeacher, string txtCourse)
        {
            CourseEntity course = new CourseEntity();
            course.teacher.id_teacher = Convert.ToInt32(cbxTeacher);
            course.course = txtCourse;

            String script = "";

            if (courseLogic.addCourse(course))
            {
                script = "<script languaje='javascript'>" +
                            "window.location.href='/Course/ListCourse'; " +
                         "</script>";
            }
            else
            {
                script = "<script languaje='javascript'>" +
                            "alert('Registro no agregado'); " +
                         "</script>";
            }

            return Content(script);
        }
    }
}