using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityLayer;
using AccessDataLayer;

namespace BusinessLogic
{
    public class TeacherLogic
    {
        TeacherAccessData teacherData = new TeacherAccessData();

        public List<TeacherEntity> listTeacher()
        {
            return teacherData.listTeachers();
        }

        public bool addTeacher(TeacherEntity teacher)
        {
            return teacherData.addTeacher(teacher);
        }

        public TeacherEntity searchTeacher(int id)
        {
            return teacherData.searchTeacher(id);
        }

        public bool updateTeacher(TeacherEntity teacher)
        {
            return teacherData.updateTeacher(teacher);
        }

        public bool deleteTeacher(int id)
        {
            return teacherData.deleteTeacher(id);
        }
    }
}
