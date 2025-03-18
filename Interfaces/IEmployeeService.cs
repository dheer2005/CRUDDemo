using CRUDDemo.Controllers;
using CRUDDemo.Models;

namespace CRUDDemo.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployeeDetails();
        Employee GetEmployeeDetail(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
    }
}
