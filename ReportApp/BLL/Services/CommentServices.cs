using AutoMapper;
using ReportApp.DAL.Entities;
using ReportApp.DAL.UnitOfWork;
using ReportApp.BLL.Interfaces;
using ReportApp.DTO;
using System;
using System.Collections.Generic;

namespace ReportApp.BLL.Services
{
    public class CommentServices : ICommentServices
    {
        private IUnitOfWork _database;
        private IMapper _mapper;
        public CommentServices(IUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public void Add(CommentDto entity)
        {
            _database.CommentRepository.Add(_mapper.Map<CommentEntity>(entity));
            _database.CommentRepository.Save();
        }

        public void Delete(Guid id)
        {
            _database.CommentRepository.Delete(id);
            _database.CommentRepository.Save();
        }

        public List<CommentDto> GetAll()
        {
            return _mapper.Map<List<CommentDto>>(_database.CommentRepository.GetAll());
        }

        public CommentDto GetById(Guid id)
        {
            return _mapper.Map<CommentDto>(_database.CommentRepository.GetById(id));
        }

        public void Save()
        {
            _database.CommentRepository.Save();
        }

        public void Update(CommentDto entity)
        {
            _database.CommentRepository.Update(_mapper.Map<CommentEntity>(entity));
            _database.CommentRepository.Save();
        }
    }
}
