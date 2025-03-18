using CRUDDemo.Interfaces;
using CRUDDemo.Models;

namespace CRUDDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeService(EmployeeDbContext employeeDbContext) 
        {
            _employeeDbContext = employeeDbContext;
        }

        public Employee AddEmployee(Employee employee) 
        {
            var emp = _employeeDbContext.Employees.Add(employee);
            _employeeDbContext.SaveChanges();   
            return emp.Entity;
        }

        public bool DeleteEmployee(int id) 
        {
            try
            {
                var emp = _employeeDbContext.Employees.SingleOrDefault(s => s.empId == id);
                if (emp == null)
                {
                    throw new Exception("Employee not found");
                }
                else
                {
                    _employeeDbContext.Employees.Remove(emp);
                    _employeeDbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public IEnumerable<Employee> GetAllEmployeeDetails() 
        {
            var employees = _employeeDbContext.Employees;
            return employees;
        }

        public Employee GetEmployeeDetail(int id) 
        {
            var emp = _employeeDbContext.Employees.SingleOrDefault(s => s.empId == id);
            return emp;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var updated = _employeeDbContext.Employees.Update(employee);
            _employeeDbContext.SaveChanges();
            return updated.Entity;
        }
    }
}
