using Product_API2.Models;
using Product_API2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_API2.Repository
{
    public interface IPostRepository
    {


        Task<List<Employee>> GetEmployee();

        Task<Employee> GetEmployee(int Id);

        Task<int> AddEmployee(Employee employee);

        Task<int> DeleteEmployee(int? Id);

        Task UpdateEmployee(Employee employee);
    }
}
