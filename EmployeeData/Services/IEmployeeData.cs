using EmployeeData.Models;

namespace EmployeeData.Services
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAllEmployees();

        EmployeeDept GetEmployee(int EmpId);
        
        string AddEmployee(Employee employee);
        
        void EditEmployee(Employee employee);
        
        string DeleteEmployee(int EmpId);
        
        string EditEmployeeId(int OldEmpId, int NewEmpID);
      
    }
}
