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
        TeacherLogic teacherLogic = new TeacherLogic();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListTeachers()
        {
            return View(teacherLogic.listTeacher());
        }

        // Método para ir al formulario
        public ActionResult AddTeachers()
        {
            return View();
        }

        // Método para recibir datos del formulario
        public ActionResult InsertTeacher(string txtFirst, string txtLast)
        {
            TeacherEntity teacher = new TeacherEntity();
            teacher.first = txtFirst;
            teacher.last = txtLast;

            String script = "";

            if (teacherLogic.addTeacher(teacher))
            {
                script = "<script languaje='javascript'>" +
                            "window.location.href='/Teacher/ListTeachers'; " +
                         "</script>";
            } else
            {
                script = "<script languaje='javascript'>" +
                            "alert('Registro no agregado'); " +
                         "</script>";
            }

            return Content(script);
        }

        public ActionResult EditTeacher(int idTeacher)
        {
            return View(teacherLogic.searchTeacher(idTeacher));
        }
        
        public ActionResult DeleteTeacher(int idTeacher)
        {
            string script = "";

            if (teacherLogic.deleteTeacher(idTeacher))
            {
                script = "<script languaje='javascript'>" +
                            "alert('Profesor eliminado correctamente')" +
                            "window.location.href='/Teacher/ListTeachers'; " +
                         "</script>";
            }
            else
            {
                script = "<script languaje='javascript'>" +
                            "alert('No se pudo eliminar'); " +
                         "</script>";
            }

            return Content(script);
        }
    }
}
