using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace EmployeeData.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual int DeptId { get; set; }
        [ForeignKey("DeptId")]
        
        //public virtual Dept Departments { get; set; }



        public int Salary { get; set; }
        public int Age { get; set; }

        
       
    }


}
