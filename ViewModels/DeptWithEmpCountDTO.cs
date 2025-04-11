namespace WebAPIDotNet.DTO
{
    public class DeptWithEmpCountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? ManagerName { get; set; }
        public int EmpCount { get; set; }
    }
}
