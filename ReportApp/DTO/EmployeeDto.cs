using System;
using ReportApp.DTO.Tools;

namespace ReportApp.DTO
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public Guid SuperiorId { get; set; }
    }
}
