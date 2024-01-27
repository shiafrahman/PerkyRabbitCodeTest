using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeCertificateManagement.Library.Domain
{
    public class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? EmpName { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }
        [JsonIgnore]
        public Department? Department { get; set; }

        public int CertificateId { get; set; }
        [JsonIgnore]
        public Certificate? Certificate { get; set; }



        
    }
}
