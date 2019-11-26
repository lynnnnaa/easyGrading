﻿using easyGrading.Services.Interface;
using easyGrading.Services.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Services
{
    public class DbQueries: IDbQueries
    {
        private EasyGradingContext _dbContext;
        public DbQueries(EasyGradingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Student> returnStudentInfoWithUserID(string userID) {

            int result = 0;
            
            if (Int32.TryParse(userID, out result))
            {
                var query =
                $@"SELECT *
                    FROM dbo.student st
                    WHERE st.Id = {result}";

                var student = _dbContext.Students
                    .FromSqlRaw(query)
                    .ToList();

                return student;
            }
            else {
                return new List<Student>();
            }
            
        }
    }
}