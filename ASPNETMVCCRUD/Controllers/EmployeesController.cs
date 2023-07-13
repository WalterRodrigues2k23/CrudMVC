using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDbContext mvcDbContext;
        public EmployeesController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var Employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
            };

            await mvcDbContext.Employees.AddAsync(Employee);
            await mvcDbContext.SaveChangesAsync();
            return RedirectToAction("Add");

        }
    }
}
