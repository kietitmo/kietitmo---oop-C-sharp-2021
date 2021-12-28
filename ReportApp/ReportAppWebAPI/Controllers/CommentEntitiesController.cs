using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Interfaces;
using ReportApp.DTO;

namespace ReportApp.ReportAppWebAPI.Controllers
{
    public class CommentEntitiesController : Controller
    {
        private readonly ICommentServices _commentServices;

        public CommentEntitiesController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }

        [HttpGet("GetAllComment")]
        public List<CommentDto> GetAll()
        {
            return _commentServices.GetAll();
        }

        [HttpGet("GetCommentById/{id}")]
        public CommentDto GetById(Guid id)
        {
            return _commentServices.GetById(id);
        }

        [HttpPost("UpdateComment")]
        public void Update(CommentDto entity)
        {
            _commentServices.Update(entity);
        }
    }
}
