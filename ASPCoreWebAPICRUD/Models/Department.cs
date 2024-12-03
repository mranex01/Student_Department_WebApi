using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreWebAPICRUD.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = string.Empty;

        public string? HeadOfDepartment {  get; set; }

        

    }
}
