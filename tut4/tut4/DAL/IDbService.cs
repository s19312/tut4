﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut4.Models;

namespace tut4.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
