using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeCertificateManagement.Library.Domain
{
    public class Certificate
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        [JsonIgnore]
        public ICollection<Employee>? Employees { get; set; }
    }
}
