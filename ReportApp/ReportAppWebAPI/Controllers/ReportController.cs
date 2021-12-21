using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Interfaces;
using ReportApp.DTO;
using ReportApp.DTO.Tools;
namespace ReportApp.ReportAppWebAPI.Controllers
{
    public class ReportController : ControllerBase
    {
        private readonly IReportServices _reportServices;

        public ReportController(IReportServices reportServices)
        {
            _reportServices = reportServices;
        }

        [HttpPost("CreateWeeklyReport")]
        public void CreateWeeklyReport()
        {
            _reportServices.CreateWeeklyReport();
        }

        [HttpDelete("DeleteReport")]
        public void Delete(Guid id)
        {
            _reportServices.Delete(id);
        }

        [HttpGet("GetAllReport")]
        public List<ReportDto> GetAll()
        {
            return _reportServices.GetAll();
        }

        [HttpGet("GetReportById/{id}")]
        public ReportDto GetById(Guid id)
        {
            return _reportServices.GetById(id);
        }

        [HttpGet("GetDailyReportsFromSubordinates/{employeeId}")]
        public List<ReportDto> GetDailyReportsFromSubordinates(Guid employeeId)
        {
            return _reportServices.GetDailyReportsFromSubordinates(employeeId);
        }

        [HttpGet("GetTasksOfReportForWeek/{reportId}")]
        public List<TaskDto> GetTasksOfReportForWeek(Guid reportId)
        {
            return _reportServices.GetTasksOfReportForWeek(reportId);
        }

        [HttpPost("UpdateReport")]
        public void Update(ReportDto entity)
        {
            _reportServices.Update(entity);
        }

        [HttpPost("UpdateReportDescription")]
        public void UpdateReportDescription(Guid reportId, string description)
        {
            _reportServices.UpdateReportDescription(reportId, description);
        }

        [HttpPost("UpdateReportState")]
        public void UpdateReportState(Guid reportId, ReportState state)
        {
            _reportServices.UpdateReportState(reportId, state);
        }
    }
}
