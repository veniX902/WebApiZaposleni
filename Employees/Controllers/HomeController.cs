using Employees.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string firstName, string lastName, DateTime dateOfBirth)
        {
            Person person = new Person();
            person.FirstName = firstName;
            person.LastName = lastName;
            person.BirthDate = dateOfBirth;

            Attendance.AddAttendant(person);
            TempData["FirstName"] = firstName + " " + lastName;
            return RedirectToAction("Index");
        }
    }
}
