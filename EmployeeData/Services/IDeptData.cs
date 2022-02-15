using EmployeeData.Models;

namespace EmployeeData.Services
{
    public interface IDeptData
    {
        IEnumerable<Dept> GetAllDepartments();

         Dept GetDepartment(int DeptId);
        
        void AddDepartment(Dept Department);
        
        void EditDepartment(Dept Department);

        string DeleteDepartment(int DepartmentId);

        
    }
}
