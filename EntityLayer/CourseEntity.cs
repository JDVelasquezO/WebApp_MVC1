using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CourseEntity
    {
        public int id_course { get; set; }
        public string course { get; set; }
        public TeacherEntity teacher = new TeacherEntity();
    }
}
