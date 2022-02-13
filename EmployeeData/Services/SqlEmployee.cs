using EmployeeData.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Services
{
    public class SqlEmployee : IEmployeeData
    {
        private EmployeeDbContext db;
        public List<Employee> employees;

        public SqlEmployee(EmployeeDbContext db)
        {
            this.db = db;
        }
        public void Add(Employee employee)
        {

            using(var data=new EmployeeDbContext())
            {
                data.Database.EnsureCreated();
                db.Employees.Add(employee);
            }

               // db.Employees.Add(employee);
            db.SaveChanges();
            
        }
        public string Delete(int EmpId)
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

        public Employee Get(int EmpId)
        {

            return db.Employees.Find(EmpId);
        }

        public IEnumerable<Employee> GetAll()
        {
            return from e in db.Employees orderby e.EmpId select e;
        }

        public void Update(Employee employee)
        {
            var entry = db.Entry(employee);
            entry.State=EntityState.Modified;
            db.SaveChanges();
        }

        public string EditId(int OldEmpId, int NewEmpID)
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
