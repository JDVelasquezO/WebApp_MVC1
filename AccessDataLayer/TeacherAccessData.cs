using EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AccessDataLayer
{
    public class TeacherAccessData
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<TeacherEntity> listTeachers()
        {
            List<TeacherEntity> list = new List<TeacherEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_teachers", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    TeacherEntity teacher = new TeacherEntity();
                    teacher.id_teacher = Convert.ToInt32(sqlDataReader["Identificador"]);
                    teacher.first = sqlDataReader["Nombre"].ToString();
                    teacher.last = sqlDataReader["Apellido"].ToString();

                    list.Add(teacher);
                }
            }
            catch(Exception e)
            {
                throw;
            }

            return list;
        }

        public bool addTeacher(TeacherEntity teacher)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("add_teacher", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_first = new SqlParameter();
                p_first.ParameterName = "@Nombre";
                p_first.SqlDbType = SqlDbType.VarChar;
                p_first.Size = 20;
                p_first.Value = teacher.first;

                SqlParameter p_last = new SqlParameter();
                p_last.ParameterName = "@Apellido";
                p_last.SqlDbType = SqlDbType.VarChar;
                p_last.Size = 20;
                p_last.Value = teacher.last;

                sqlCommand.Parameters.Add(p_first);
                sqlCommand.Parameters.Add(p_last);

                sqlCommand.ExecuteNonQuery();

                response = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return response;
        }

        public TeacherEntity searchTeacher(int id)
        {
            TeacherEntity teacher = new TeacherEntity();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("search_teacher", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;   
                
                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@Identificador";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                {
                    teacher.id_teacher = Convert.ToInt32(sqlDataReader["id_teacher"]);
                    teacher.first = sqlDataReader["first"].ToString();
                    teacher.last = sqlDataReader["last"].ToString();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return teacher;
        }

        public bool updateTeacher(TeacherEntity teacher)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("update_teacher", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@Identificador";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = teacher.id_teacher;

                SqlParameter p_first = new SqlParameter();
                p_first.ParameterName = "@Nombre";
                p_first.SqlDbType = SqlDbType.VarChar;
                p_first.Size = 20;
                p_first.Value = teacher.first;

                SqlParameter p_last = new SqlParameter();
                p_last.ParameterName = "@Apellido";
                p_last.SqlDbType = SqlDbType.VarChar;
                p_last.Size = 20;
                p_last.Value = teacher.last;

                sqlCommand.Parameters.Add(id_parameter);
                sqlCommand.Parameters.Add(p_first);
                sqlCommand.Parameters.Add(p_last);

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
