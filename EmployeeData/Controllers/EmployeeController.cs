using EmployeeData.Models;
using EmployeeData.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeData db;



        public EmployeeController(IEmployeeData db)
        {
            this.db = db;
        }
        [HttpGet("GetAll")]
        public IEnumerable<Employee> GetAll()
        {
            return db.GetAll();
        }
        [HttpGet("Get")]
        public Employee Get(int EmpId)
        {
            
           var e=db.Get(EmpId);
           if(e!=null)
            return e;
           else
                return new Employee();
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Add(employee);
                return Content("Successfully Added");
            }
            return Content("Fail");
;        }
        [HttpPost("DeleteEmployee")]
        public IActionResult DeleteEmployee(int EmpId)
        {
            
            return Content(db.Delete(EmpId));
        }
        [HttpPost("EditEmployee")]
        public IActionResult EditEmployee(Employee Emp)
        {
            db.Update(Emp);
            return Content("Success");
        }
        [HttpPost("EditEmployeeId")]
        public IActionResult EditEmployeeId(int OldEmpID, int NewEmpID)
        {
            return Content(db.EditId(OldEmpID, NewEmpID));
        }

        
    }
}
