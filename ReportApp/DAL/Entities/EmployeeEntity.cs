using System;
using System.ComponentModel.DataAnnotations.Schema;
using ReportApp.DTO.Tools;

namespace ReportApp.DAL.Entities
{
    public class EmployeeEntity
    {
        public EmployeeEntity(string name, Guid superiorId)
        {
            Name = name;
            Id = Guid.NewGuid();
            SuperiorId = superiorId;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EmployeeType EmployeeType { get; set; } = EmployeeType.NormalMember;
        public Guid SuperiorId { get; set; } = Guid.Empty;
    }
}
