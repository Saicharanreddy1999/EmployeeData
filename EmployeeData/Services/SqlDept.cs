using EmployeeData.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Services
{
    public class SqlDept : IDeptData
    {

        EmployeeDbContext db;

        public SqlDept(EmployeeDbContext db)
        {
            this.db = db;
        }

        public void AddDepartment(Dept department)
        {
            using (var data = new EmployeeDbContext())
            {
                data.Database.EnsureCreated();
                db.Department.Add(department);
            }
            db.SaveChanges();
        }




        public string DeleteDepartment(int DeptId)
        {
            var dept = db.Employees.Find(DeptId);
            if (dept != null)
            {
                db.Employees.Remove(dept);
                db.SaveChanges();
                return "Successfully Deleted";
            }
            return "Not Found";
        }



        public void EditDepartment(Dept Dept)
        {
            var entry = db.Entry(Dept);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }



        public IEnumerable<Dept> GetAllDepartments()
        {
              var data= from d in db.Department orderby d.DeptId select d;
                return data;
        }

        public Dept GetDepartment(int DeptId)
        {
            return db.Department.Find(DeptId);
        }

       
    }
}
