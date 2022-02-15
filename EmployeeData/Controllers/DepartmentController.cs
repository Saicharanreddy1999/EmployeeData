using EmployeeData.Models;
using EmployeeData.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeData.Controllers
{
    public class DepartmentController : Controller
    {
        private IDeptData db;



        public DepartmentController(IDeptData db)
        {
            this.db = db;
        }



        [HttpGet("GetAllDepartments")]
        public IEnumerable<Dept> GetAllDepartments()
        {
            return db.GetAllDepartments();
        }



        [HttpGet("GetDepartment")]
        public Dept GetDepartment(int DeptId)
        {

            var d = db.GetDepartment(DeptId);
            if (d != null)
                return d;
            else
                return new Dept();
        }



        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment(Dept Dept)
        {
            if (ModelState.IsValid)
            {
                db.AddDepartment(Dept);
                return Content("Successfully Added");
            }
            return Content("Fail");
            
        }


        [HttpPost("DeleteDepartment")]
        public IActionResult DeleteDepartment(int DeptId)
        {

            return Content(db.DeleteDepartment(DeptId));
        }


        [HttpPost("EditDepartment")]
        public IActionResult EditEmployee(Dept Dept)
        {
            db.EditDepartment(Dept);
            return Content("Success");
        }

    }
}
