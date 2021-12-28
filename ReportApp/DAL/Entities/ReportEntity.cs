using System;
using System.ComponentModel.DataAnnotations.Schema;
using ReportApp.DTO.Tools;

namespace ReportApp.DAL.Entities
{
    public class ReportEntity
    {
        public ReportEntity(Guid employeeInChargeId, ReportType type)
        {
            EmployeeId = employeeInChargeId;
            CreationDate = DateTime.Now;
            LastChangeDate = DateTime.Now;
            Id = Guid.NewGuid();
            StateOfReport = ReportState.Open;
            Type = type;
        }
        public ReportEntity(ReportType type)
        {
            CreationDate = DateTime.Now;
            LastChangeDate = DateTime.Now;
            Id = Guid.NewGuid();
            StateOfReport = ReportState.Open;
            Type = type;
        }

        public ReportEntity(Guid employeeInChargeId, ReportType type, DateTime timeCreation)
        {
            EmployeeId = employeeInChargeId;
            CreationDate = timeCreation;
            LastChangeDate = DateTime.Now;
            Id = Guid.NewGuid();
            StateOfReport = ReportState.Open;
            Type = type;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public ReportState StateOfReport { get; set; } = ReportState.Open;
        public ReportType Type { get; set; }
        public string DescriptionOfReport { get; set; } = null;
        public DateTime CreationDate { get; set; }
        public DateTime LastChangeDate { get; set; }
    }
}
