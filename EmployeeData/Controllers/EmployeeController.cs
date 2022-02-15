using EmployeeData.Models;
using EmployeeData.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeData.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeData db;


        public EmployeeController(IEmployeeData db)
        {
            this.db = db;
        }



        [HttpGet("GetAllEmployees")]
        public IEnumerable<Employee> GetAllEmployees()
        {
            
            return db.GetAllEmployees();
        }



        [HttpGet("GetEmployee")]
        public EmployeeDept GetEmployee(int EmpId)
        {
            
           var e=db.GetEmployee(EmpId);
             if(e!=null)
            return e;
            else
               return new EmployeeDept();
        }



        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                return Content(db.AddEmployee(employee));
               
            }
            return Content("Fail");
;        }



        [HttpPost("DeleteEmployee")]
        public IActionResult DeleteEmployee(int EmpId)
        {
            
            return Content(db.DeleteEmployee(EmpId));
        }



        [HttpPost("EditEmployee")]
        public IActionResult EditEmployee(Employee Emp)
        {
            db.EditEmployee(Emp);
            return Content("Success");
        }



        [HttpPost("EditEmployeeId")]
        public IActionResult EditEmployeeId(int OldEmpID, int NewEmpID)
        {
            return Content(db.EditEmployeeId(OldEmpID, NewEmpID));
        }

        
    }
}
