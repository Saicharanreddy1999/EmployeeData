using EmployeeData.Models;

namespace EmployeeData.Services
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int EmpId);
       void Add(Employee employee);
        void Update(Employee employee);
        string Delete(int EmpId);
        string EditId(int OldEmpId, int NewEmpID);

    }
}
