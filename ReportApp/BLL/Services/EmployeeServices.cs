using AutoMapper;
using ReportApp.DAL.Entities;
using ReportApp.DAL.UnitOfWork;
using ReportApp.BLL.Interfaces;
using ReportApp.DTO;
using System;
using System.Collections.Generic;

namespace ReportApp.BLL.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private IUnitOfWork _database;
        private IMapper _mapper;
        public EmployeeServices(IUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public void Add(EmployeeDto entity)
        {
            _database.EmployeeRepository.Add(_mapper.Map<EmployeeEntity>(entity));
            _database.EmployeeRepository.Save();
        }

        public void Delete(Guid id)
        {
            _database.EmployeeRepository.Delete(id);
            _database.EmployeeRepository.Save();
        }

        public List<EmployeeDto> GetAll()
        {
            return _mapper.Map<List<EmployeeDto>>(_database.EmployeeRepository.GetAll());
        }

        public EmployeeDto GetById(Guid id)
        {
            return _mapper.Map<EmployeeDto>(_database.EmployeeRepository.GetById(id));
        }

        public void Save()
        {
            _database.EmployeeRepository.Save();
        }

        public void Update(EmployeeDto entity)
        {
            _database.EmployeeRepository.Update(_mapper.Map<EmployeeEntity>(entity));
            _database.EmployeeRepository.Save();
        }
    }
}
