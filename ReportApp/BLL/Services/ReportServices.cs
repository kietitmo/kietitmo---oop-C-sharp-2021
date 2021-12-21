using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ReportApp.BLL.Interfaces;
using ReportApp.DAL.Entities;
using ReportApp.DAL.UnitOfWork;
using ReportApp.DTO;
using ReportApp.DTO.Tools;

namespace ReportApp.BLL.Services
{
    public class ReportServices : IReportServices
    {
        private IUnitOfWork _dataBase;
        private IMapper _mapper;

        public ReportServices(IUnitOfWork database, IMapper mapper)
        {
            _dataBase = database;
            _mapper = mapper;
        }

        public void Add(ReportDto entity)
        {
            _dataBase.ReportRepository.Add(_mapper.Map<ReportEntity>(entity));
            _dataBase.ReportRepository.Save();
        }

        public void AddTasksToReport(Guid reportId, List<TaskDto> tasks)
        {
            tasks.ForEach(task => { 
                task.Id = reportId;
                _dataBase.TaskRepository.Add(_mapper.Map<TaskEntity>(task));                        
            });
            _dataBase.ReportRepository.Save();
        }

        public void CreateWeeklyReport()
        {
            var newWeekleReport = new ReportEntity(ReportType.Weekly);
            _dataBase.ReportRepository.Add(newWeekleReport);
            _dataBase.ReportRepository.Save();
        }

        public void Delete(Guid id)
        {
            _dataBase.ReportRepository.Delete(id);
            _dataBase.ReportRepository.Save();
        }

        public List<ReportDto> GetAll()
        {
            return _mapper.Map<List<ReportDto>>(_dataBase.ReportRepository.GetAll());
        }

        public ReportDto GetById(Guid id)
        {
            return _mapper.Map<ReportDto>(_dataBase.ReportRepository.GetById(id));
        }

        public List<ReportDto> GetDailyReportsFromSubordinates(Guid employeeId)
        {
            List<EmployeeEntity> allEmployees = _dataBase.EmployeeRepository.GetAll();
            List<ReportEntity> allReport = _dataBase.ReportRepository.GetAll();
            var listReport = new List<ReportEntity>();

            foreach(EmployeeEntity employee in allEmployees)
            {
                if (employee.SuperiorId == employeeId)
                {
                    allReport.ForEach(report => { if (report.EmployeeId == employee.Id) listReport.Add(report); });
                }
            }
                               
            return _mapper.Map<List<ReportDto>>(listReport);
        }

        public void Save()
        {
            _dataBase.ReportRepository.Save();
        }

        public List<TaskDto> GetTasksOfReportForWeek(Guid reportId)
        {
             return _mapper.Map<List<TaskDto>>(_dataBase.TaskRepository.GetAll().Where(task => (task.StartDate >= DateTime.Now.AddDays(-7)) && (task.ReportID == reportId)).ToList());
        }

        public void Update(ReportDto entity)
        {
            _dataBase.ReportRepository.Update(_mapper.Map<ReportEntity>(entity));
        }

        public void UpdateReportDescription(Guid reportId, string description)
        {
            ReportEntity report = _dataBase.ReportRepository.GetById(reportId);
            report.DescriptionOfReport = description;
            _dataBase.ReportRepository.Save();
        }

        public void UpdateReportState(Guid reportId, ReportState state)
        {
            ReportEntity report = _dataBase.ReportRepository.GetById(reportId);
            report.StateOfReport = state;
            _dataBase.ReportRepository.Save();
        }
    }
}