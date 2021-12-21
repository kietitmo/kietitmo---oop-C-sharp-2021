using System;
using ReportApp.DTO.Tools;

namespace ReportApp.DTO
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public ReportState StateOfReport { get; set; }
        public ReportType Type { get; set; }
        public string DescriptionOfReport { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastChangeDate { get; set; }
    }
}
