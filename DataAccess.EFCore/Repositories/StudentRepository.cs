using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EFCore.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore.Repositories
{
    public class StudentRepository : GenericRepository<Student>,IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Student> GetStudentOfTheYear()
        {
            return await _dbContext.Set<Student>().Where(x=>x.Age>20).FirstOrDefaultAsync();
        }
    }
}