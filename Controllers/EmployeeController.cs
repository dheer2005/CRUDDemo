
using CRUDDemo.Interfaces;
using CRUDDemo.Models;
using CRUDDemo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CRUDDemo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IToastNotification _toasty;

        public EmployeeController(IEmployeeService employeeService, IToastNotification toasty)
        {
            _employeeService = employeeService;
            _toasty = toasty;
        }


        [HttpGet]
        public ViewResult Index() 
        {
            var emp = _employeeService.GetAllEmployeeDetails();
            return View(emp);
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeView(int id)
        {
            var emp = _employeeService.GetEmployeeDetail(id);
            EmployeeViewModel employeeViewModel = new();
            if (emp != null)
            {
                employeeViewModel = new EmployeeViewModel()
                {
                    Id = emp.empId,
                    empName = emp.empName,
                    empAge = emp.empAge,
                    empNumber = emp.empNumber,
                    empDepartment = emp.empDepartment,
                };
            }

            return View(employeeViewModel);
            
        }

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
                _toasty.AddSuccessToastMessage("Employee Created Successfully");
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




        [HttpPost("[action]/{id}")]
        public IActionResult Edit([FromForm]EmployeeEditViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeService.GetEmployeeDetail(id);
                employee.empId = id;    
                employee.empName = model.empName;
                employee.empAge = model.empAge;
                employee.empNumber = model.empNumber;
                employee.empDepartment = model.empDepartment;

                _employeeService.UpdateEmployee(employee);
                _toasty.AddSuccessToastMessage("Successfully edited");
                return RedirectToAction("Index");

            }
            return View(model);
        }


        [HttpGet("[action]/{id}")]
        public ViewResult DeletePage(int id)
        {
            var emp = _employeeService.GetEmployeeDetail(id);
            EmployeeDeleteViewModel employeeCreateViewModel = new();
            if (emp != null)
            {
                employeeCreateViewModel = new EmployeeDeleteViewModel()
                {
                    Id = emp.empId,
                    empName = emp.empName,
                    empAge = emp.empAge,
                    empNumber = emp.empNumber,
                    empDepartment = emp.empDepartment,
                };
            }
            return View(employeeCreateViewModel);  
        }


        [HttpPost("[action]/{id}")]
        public IActionResult Delete(int id) 
        {
            
            var res = _employeeService.DeleteEmployee(id);
            if (res)
            {
                _toasty.AddSuccessToastMessage("Employee Deleted Successfully");
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
