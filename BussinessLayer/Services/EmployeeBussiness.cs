using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;

namespace BussinessLayer.Services
{
    public class EmployeeBussiness:IEmployeeBussiness
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeBussiness(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        public bool AddEmployee(EmployeeModel employee)
        {
            return employeeRepository.AddEmployee(employee);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return employeeRepository.UpdateEmployee(employee);
        }

        public bool DeleteEmployee(int id)
        {
            return employeeRepository.DeleteEmployee(id);
        }

        public Employee GetEmployeeById(int id)
        {
            return employeeRepository.GetEmployeeById(id);
        }

        public Employee Login(LoginModel loginModel)
        {
            return employeeRepository.Login(loginModel);
        }

        public IEnumerable<Employee> GetEmployeeByChar(string letter)
        {
            return employeeRepository.GetEmployeeByChar(letter);
        }

        public IEnumerable<Employee> GetEmployeeByDate(DateTime date)
        {
            return employeeRepository.GetEmployeeByDate(date);
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            return employeeRepository.GetEmployeeByName(name);
        }



    }
}
