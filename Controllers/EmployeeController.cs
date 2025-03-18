using CRUDDemo.Interfaces;
using CRUDDemo.Models;
using CRUDDemo.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUDDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet("[action]")]
        public ViewResult Index() 
        {
            var emp = _employeeService.GetAllEmployeeDetails();
            return View(emp);
        }

        //[HttpGet("{id}")]
        //public ViewResult GetById(int id)
        //{
        //    var emp = _employeeService.GetEmployeeDetail(id);
        //    return View(emp);
        //}

        [HttpGet("[action]")]
        public ViewResult Create()
        {
            return View();
        }



        [HttpPost("[action]")]
        
        public IActionResult Create([FromForm]EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee newEmp = new Employee
                {
                    empId = 0,
                    empName = model.empName,
                    empAge = model.empAge,
                    empNumber = model.empNumber,
                    empDepartment = model.empDepartment,
                };


                Employee newEm = _employeeService.AddEmployee(newEmp);
                return RedirectToAction("Index", new {id = newEm.empId});
            }
            return View();
        }



        [HttpGet("[action]/{id}")]
        public ViewResult Edit(int id) 
        {
            var emp = _employeeService.GetEmployeeDetail(id);
            EmployeeEditViewModel employeeEditViewModel = new();
            if (emp != null) 
            {
                employeeEditViewModel = new EmployeeEditViewModel()
                {
                    Id = emp.empId,
                    empName = emp.empName,
                    empAge = emp.empAge,
                    empNumber = emp.empNumber,
                    empDepartment = emp.empDepartment,
                };
            }
            
            return View(employeeEditViewModel);
        }




        [HttpPut("[action]")]
        public IActionResult Edit([FromForm]EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeService.GetEmployeeDetail(model.Id);
                employee.empName = model.empName;
                employee.empAge = model.empAge;
                employee.empNumber = model.empNumber;
                employee.empDepartment = model.empDepartment;

                _employeeService.UpdateEmployee(employee);

                return RedirectToAction("Index");

            }
            return View(model);
        }





        [HttpDelete("{id}")]
        public ViewResult Delete(int id) 
        {
            var isDeleted = _employeeService.DeleteEmployee(id);
            return View(isDeleted);
        }
    }
}
