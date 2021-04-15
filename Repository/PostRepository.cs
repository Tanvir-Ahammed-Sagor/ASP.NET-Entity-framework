using Microsoft.EntityFrameworkCore;
using Product_API2.Models;
using Product_API2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_API2.Repository
{
    public class PostRepository : IPostRepository
    {
        ModelContext db;
        public PostRepository(ModelContext _db)
        {
            db = _db;
        }



        public async Task<List<Employee>> GetEmployee()
        {
            if (db != null)
            {
                return await (from p in db.Employees

                              select new Employee
                              {
                                  Id = p.Id,
                                  Empname = p.Empname,
                                  Salary = p.Salary,
                                  Address = p.Address,

                              }).ToListAsync();
            }

            return null;
        }


        public async Task<Employee> GetEmployee(int Id)
        {
            if (db != null)
            {
                return await (from p in db.Employees
                              
                              where p.Id == Id
                              select new Employee
                              {
                                  Id = p.Id,
                                  Empname = p.Empname,
                                  Salary = p.Salary,
                                  Address = p.Address,
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            if (db != null)
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();

                return employee.Id;
            }

            return 0;
        }

        public async Task<int> DeleteEmployee(int? Id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var employee = await db.Employees.FirstOrDefaultAsync(x => x.Id == Id);

                if (employee != null)
                {
                    //Delete that post
                    db.Employees.Remove(employee);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdateEmployee(Employee employee)
        {
            if (db != null)
            {
                //Delete that post
                db.Employees.Update(employee);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }


    }
}
