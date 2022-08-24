namespace FirstMVCProj.Models
{
    public class Emp
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public decimal Salary { get; set; }

        public static void AddEmployee(Emp e)
        {
            return;
        }

    }
}
