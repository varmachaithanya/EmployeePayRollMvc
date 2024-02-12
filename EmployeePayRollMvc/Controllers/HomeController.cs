using System.Diagnostics;
using BussinessLayer.Interfaces;
using CommonLayer.Models;
using EmployeePayRollMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayRollMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //List<string> Courses = new List<string>();
            //Courses.Add("java");
            //Courses.Add("python");
            //Courses.Add("dotnet");
            //ViewBag.Courses = Courses;

            //List<Employee> studentList = new List<Employee>();
            //studentList.Add(new Employee() { Name = "chaithanya" });
            //studentList.Add(new Employee() { Name = "varma" });
            //studentList.Add(new Employee() { Name = "penumathsa" });

            //ViewData["students"] = studentList;

            //TempData["Name"] = "kumar";
            //TempData.Keep("Name");


            return View();
        }

        public IActionResult Privacy()
        {
            //if (TempData.ContainsKey("Name"))
            //{
            //    ViewBag.Name = TempData["Name"] as string;
            //}
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
