using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCertificateManagement.Library.DTOs
{
    public class CertificateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }


        public int DeptId { get; set; }
        public int CertificationId { get; set; }


        public string DeptName { get; set; }
        public DateTime date { get; set; }
    }
}
