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
    }
}
