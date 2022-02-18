using Day18.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Day18.Controllers
{
    public class StudentsController : ApiController
    {
        // GET: api/Students
        public IEnumerable<Student> Get()
        {
            List<Student> lstStudents = new List<Student>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ak47;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "Select * from Student";
            try
            {
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    lstStudents.Add(new Student { StudentId = (int)dr["StudentId"], Name = dr["Name"].ToString(), Marks = (decimal)dr["Marks"] }) ; 

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();

         

            return lstStudents;
        }

        // GET: api/Students/5
        public Student Get(int id)
        {
            Student lstStudents = new Student();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ak47;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "Select * from Student where StudentId=@StudentId";
            cmdInsert.Parameters.AddWithValue("@StudentId", id);
            try
            {
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {

                    lstStudents.StudentId = (int)dr["StudentId"];
                    lstStudents.Name = dr["Name"].ToString();
                    lstStudents.Marks = (decimal) dr["Marks"];
                    
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();

            return lstStudents;
        }

        // POST: api/Students
        public void Post([FromBody]Student obj )
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ak47;Integrated Security=True";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "insert into Student values(@Name,@Marks)";
            //cmdInsert.CommandText = "update Employees set Name=@Name, Basic=@Basic, DeptNo=@DeptNo  where EmpNo=@EmpNo";
            //cmdInsert.CommandText = "delete from Employees where EmpNo=@EmpNo";


            //cmdInsert.Parameters.AddWithValue("@StudentId", obj.StudentId);
            cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
            cmdInsert.Parameters.AddWithValue("@Marks", obj.Marks);
           

            try
            {
                cmdInsert.ExecuteNonQuery();
                //Console.WriteLine("no errors");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();

        }

        // PUT: api/Students/5
        public void Put([FromBody]Student obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ak47;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "update Student set Name=@Name, Marks=@Marks where StudentId=@StudentId";
            cmdInsert.Parameters.AddWithValue("@StudentId", obj.StudentId);
            cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
            cmdInsert.Parameters.AddWithValue("@Marks", obj.Marks);



            try
            {
                cmdInsert.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }

        // DELETE: api/Students/5
        public void Delete(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ak47;Integrated Security=True";
            cn.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "delete from Student  where StudentId=@StudentId ";
            cmdInsert.Parameters.AddWithValue("@StudentId", id);




            try
            {
                cmdInsert.ExecuteNonQuery();
                //Console.WriteLine("No Erros");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();
        }
    }
}
