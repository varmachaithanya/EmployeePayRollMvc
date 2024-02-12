using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer.Models;

namespace RepositoryLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees();

        public bool AddEmployee(EmployeeModel employee);

        public bool UpdateEmployee(Employee employee);

        public bool DeleteEmployee(int id);

        public Employee GetEmployeeById(int id);
        public Employee Login(LoginModel loginModel);

        public IEnumerable<Employee> GetEmployeeByChar(string letter);

        public IEnumerable<Employee> GetEmployeeByDate(DateTime date);

        public IEnumerable<Employee> GetEmployeeByName(string name);




    }
}
