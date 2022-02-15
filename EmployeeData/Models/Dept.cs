using System.ComponentModel.DataAnnotations;

namespace EmployeeData.Models
{
    public class Dept
    {
        [Key]
        [Required]
        public int DeptId { get; set; }
        [Required]
        public string DeptName { get; set;}
        public string Location { get; set;}
        public int DeptSize { get; set; }
       
    }


    public class GetDept
    {
        public Dept Dept { get; set; }
        public int count { get; set; }
    }
}
