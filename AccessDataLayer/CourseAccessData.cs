using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace AccessDataLayer
{
    public class CourseAccessData
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<CourseEntity> listCourse()
        {
            List<CourseEntity> list = new List<CourseEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_course", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    CourseEntity course = new CourseEntity();
                    course.id_course = Convert.ToInt32(sqlDataReader["Identificador"]);
                    course.course = sqlDataReader["Curso"].ToString();
                    course.teacher.fullname = sqlDataReader["Catedratico"].ToString();

                    list.Add(course);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public bool addCourse(CourseEntity course)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("add_course", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_course = new SqlParameter();
                p_course.ParameterName = "@Curso";
                p_course.SqlDbType = SqlDbType.VarChar;
                p_course.Size = 20;
                p_course.Value = course.course;

                SqlParameter p_id_teacher = new SqlParameter();
                p_id_teacher.ParameterName = "@idTeacher";
                p_id_teacher.SqlDbType = SqlDbType.VarChar;
                p_id_teacher.Size = 20;
                p_id_teacher.Value = course.teacher.id_teacher;

                sqlCommand.Parameters.Add(p_course);
                sqlCommand.Parameters.Add(p_id_teacher);

                sqlCommand.ExecuteNonQuery();

                response = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return response;
        }

        public CourseEntity searchTeacher(int id)
        {
            CourseEntity course = new CourseEntity();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("search_course", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idCourse";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                {
                    course.id_course = Convert.ToInt32(sqlDataReader["ID"]);
                    course.course = sqlDataReader["Nombre"].ToString();
                    course.teacher.fullname = sqlDataReader["Profesor"].ToString();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return course;
        }

        public bool updateTeacher(CourseEntity course)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("update_course", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idCourse";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = course.id_course;

                SqlParameter p_course = new SqlParameter();
                p_course.ParameterName = "@Course";
                p_course.SqlDbType = SqlDbType.VarChar;
                p_course.Size = 20;
                p_course.Value = course.course;

                SqlParameter p_id_teacher = new SqlParameter();
                p_id_teacher.ParameterName = "@idTeacher";
                p_id_teacher.SqlDbType = SqlDbType.Int;
                p_id_teacher.Value = course.teacher.id_teacher;

                sqlCommand.Parameters.Add(id_parameter);
                sqlCommand.Parameters.Add(p_course);
                sqlCommand.Parameters.Add(p_id_teacher);

                sqlCommand.ExecuteNonQuery();

                response = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return response;
        }
    }
}
