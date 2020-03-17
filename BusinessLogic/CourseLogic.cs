using AccessDataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CourseLogic
    {
        CourseAccessData courseLogic = new CourseAccessData();

        public List<CourseEntity> listCourse()
        {
            return courseLogic.listCourse();

        }

        public bool addCourse(CourseEntity course)
        {
            return courseLogic.addCourse(course);
        }

        public CourseEntity searchTeacher(int id)
        {
            return courseLogic.searchTeacher(id);
        }

        public bool updateTeacher(CourseEntity course)
        {
            return courseLogic.updateTeacher(course);
        }
    }
}
