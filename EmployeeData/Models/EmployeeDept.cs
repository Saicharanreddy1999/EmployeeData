namespace EmployeeData.Models
{
    public class EmployeeDept
    {
       public Employee Employee { get; set; }
       public Dept Dept { get; set; }


        public EmployeeDept(Employee emp, Dept dept)
        {
            Employee = emp;
            Dept = dept;
        }
        public EmployeeDept()
        {
            
        }
    }
}
