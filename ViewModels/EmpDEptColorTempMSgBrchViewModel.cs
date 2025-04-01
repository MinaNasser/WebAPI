using System.ComponentModel.DataAnnotations.Schema;


namespace WebAPI.ViewModels
{
    public class EmpDEptColorTempMSgBrchViewModel
    {
        public string EmployeeName { get; set; }
        public string DeptName { get; set; }
        public List<string> Branches { get; set; }

        public int  Temprtuer { get; set; }

        public string Msg { get; set; }

        public string Color { get; set; }
    }
}
