using System;
using System.Collections.Generic;
using ReportApp.DTO;
using ReportApp.DTO.Tools;

namespace ReportApp.BLL.Interfaces
{
    public interface IReportServices : IServices<ReportDto>
    {
        public void CreateWeeklyReport();
        public List<TaskDto> GetTasksOfReportForWeek(Guid reportId);
        public List<ReportDto> GetDailyReportsFromSubordinates(Guid employeeId);
        public void AddTasksToReport(Guid reportId, List<TaskDto> tasks);
        public void UpdateReportState(Guid reportId, ReportState state);
        public void UpdateReportDescription(Guid reportId, string description);
    }
}
