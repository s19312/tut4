using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut4.Models;

namespace tut4.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{ FirstName="Vova", LastName="Grady", IndexNumber="s1234",},
                new Student{ FirstName="Anna", LastName="Folic", IndexNumber="s3446"},
                new Student{ FirstName="Max", LastName="Smith", IndexNumber="s5644"}
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

    }
}
