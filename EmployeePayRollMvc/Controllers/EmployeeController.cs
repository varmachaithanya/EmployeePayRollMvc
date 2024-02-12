using BussinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace EmployeePayRollMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBussiness business;

        public EmployeeController(IEmployeeBussiness business)
        {
            this.business = business;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
           List<Employee> employee = new List<Employee>() ;
            employee = business.GetAllEmployees().ToList();

            return View(employee);
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Create() 
        {
            ViewBag.data = "Add Employee Payroll UI/UX Design";

            return View();
        }

        [HttpPost]
        [Route("Register")]

        public IActionResult Create(EmployeeModel employee)
        {
            var result=business.AddEmployee(employee);
            if (result)
            {
                return RedirectToAction("Details");
            }
            return NotFound("Something Went Wrong...");
        }

        [HttpGet]
        //[Route("Update/{id}")]
        public IActionResult Edit(int id)
        {
            //id = (int)HttpContext.Session.GetInt32("Id");

            if (id == null)
            {
                return NotFound();
            }
            Employee employee=business.GetEmployeeById(id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee) 
        {
           
            var result=business.UpdateEmployee(employee);
            if(result)
            {
                return RedirectToAction("Details");
            }
            
            return NotFound("Something Went Wrong...");
        }
        [HttpGet]
        public IActionResult GetEmpById(int id) 
        {
            //id = (int)HttpContext.Session.GetInt32("Id");
            if (id == null)
            {
                return NotFound();
            }
            Employee employee =business.GetEmployeeById(id);
            if(employee == null)
            {
                return NotFound("Something went Wrong....");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee= business.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult Delete(Employee employee)
        {
            var result=business.DeleteEmployee(employee.Id);
            if (result)
            {
                return RedirectToAction("Details");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(LoginModel model)
        {
            var result=business.Login(model);
            if(result==null)
            {
                return Content("Invalid Credentials");
            }
            else
            {
                
                HttpContext.Session.SetInt32("Id",result.Id);
               return RedirectToAction("GetEmpById",new { Id = result.Id });
            }
        }

        [HttpGet]
        public IActionResult GetByChar(string letter)
        {
            List<Employee> employees = new List<Employee>();

            employees =business.GetEmployeeByChar(letter).ToList();
            if (employees == null)
            {
                return Content("Not Found");
            }
            return View(employees);
        }

        [HttpGet]
        public IActionResult GetByDate(DateTime date) 
        {
            List<Employee> employee=new List<Employee>();
            employee=business.GetEmployeeByDate(date).ToList();
            if(employee == null)
            {
                return Content("Not Found");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            List<Employee> employees=new List<Employee>();
            employees=business.GetEmployeeByName(name).ToList();
            if(employees == null)
            {
                return Content("Not found");
            }
            return View(employees);
        }
    }
}
