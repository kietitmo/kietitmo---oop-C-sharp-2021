using System;
using System.Collections.Generic;

namespace ReportApp.BLL.Interfaces
{
    public interface IServices<TDto> where TDto : class
    {
            public TDto GetById(Guid id);
            public void Add(TDto entity);
            public void Update(TDto entity);
            public void Delete(Guid id);
            public List<TDto> GetAll();
            public void Save();
    }
}
