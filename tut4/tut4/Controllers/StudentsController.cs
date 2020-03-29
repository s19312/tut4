using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using tut4.DAL;
using tut4.Models;

namespace tut4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            this._dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var result = new List<Student>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19312;Integrated Security=True"))
            using (var com = new SqlCommand()) {
                com.Connection = con;
                com.CommandText = "select * from Student";

                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read()) {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.IdEnrollment = dr["IdEnrollment"].ToString();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    result.Add(st);
                }
            }
            return Ok(result);
        }


        [HttpGet("entries/{id}")]
        public IActionResult GetSemesterEntries(int id)
        {
            var result = new List<string>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19312;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT e.semester " +
                                  "FROM enrollment e " +
                                  "WHERE e.idenrollment = (SELECT s.idenrollment FROM student s " +
                                  $"WHERE s.indexnumber=@id)";
                com.Parameters.AddWithValue("id", id);
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {                 
                    string semester = dr["Semester"].ToString();
                    result.Add(semester);
                }
            }
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if(id ==1 )
            return Ok("nice");
            return Ok("yggy");
        }

      

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Delete completed");
        }
    }
}
