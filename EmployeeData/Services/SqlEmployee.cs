using EmployeeData.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Services
{
    public class SqlEmployee : IEmployeeData
    {
        private EmployeeDbContext db;
       

        public SqlEmployee(EmployeeDbContext db)
        {
            this.db = db;
        }



        public string AddEmployee(Employee employee)
        {

            using(var data=new EmployeeDbContext())
            {
                data.Database.EnsureCreated();
                if (db.Department.Find(employee.DeptId) == null)
                {
                    return "Add Department "+employee.DeptId+" First";   
                }
                db.Employees.Add(employee);
            }
            db.SaveChanges();
            return "Successfully Added";
            
        }



        public string DeleteEmployee(int EmpId)
        {
            var emp = db.Employees.Find(EmpId);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                return "Successfully Deleted";
            }
                return "Not Found";
        }
        



        public EmployeeDept GetEmployee(int EmpId)
        {

            var emp = db.Employees.Find(EmpId);
            var dept=db.Department.Find(emp.DeptId);
            return new EmployeeDept(emp,dept);

        }



        public IEnumerable<Employee> GetAllEmployees()
        {
            return from e in db.Employees orderby e.EmpId select e;
        }



        public void EditEmployee(Employee employee)
        {
            var entry = db.Entry(employee);
            entry.State=EntityState.Modified;
            db.SaveChanges();
        }



        public string EditEmployeeId(int OldEmpId, int NewEmpID)
        {
            var emp = db.Employees.Find(OldEmpId);
            if(emp!=null)
             {
                Employee employee=new Employee();
                employee.EmpId = NewEmpID;
                employee.DeptId=emp.DeptId;
                employee.Name=emp.Name;
                db.Employees.Add(employee);
                db.SaveChanges();
                db.Employees.Remove(emp);
                db.SaveChanges();
            return "'Success";
                }
            return "Not Found";
        }

    }
}
