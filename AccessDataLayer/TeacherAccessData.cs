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
    }
}
