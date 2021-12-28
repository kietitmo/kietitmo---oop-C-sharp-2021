using System;
using System.Collections.Generic;
using ReportApp.DTO.Tools;

namespace ReportApp.DTO
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskState TaskState { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ReportID { get; set; }
        public string DescriptionOfTask { get; set; }
        public List<CommentDto> Comment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
