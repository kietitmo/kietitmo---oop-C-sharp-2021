using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ReportApp.DTO.Tools;

namespace ReportApp.DAL.Entities
{
    public class TaskEntity
    {
        public TaskEntity(string name, Guid employeeId)
        {
            Name = name;
            EmployeeId = employeeId;
            Id = Guid.NewGuid();
            StartDate = DateTime.Now;
            FinishDate = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskState TaskState { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ReportID { get; set; }
        public string DescriptionOfTask { get; set; }
        public List<CommentEntity> Comment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
