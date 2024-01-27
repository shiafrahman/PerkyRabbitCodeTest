using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeCertificateManagement.Library.Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string? DeptName { get; set; }
        [JsonIgnore]
        public ICollection<Employee>? Employees { get; set; }
    }
}
