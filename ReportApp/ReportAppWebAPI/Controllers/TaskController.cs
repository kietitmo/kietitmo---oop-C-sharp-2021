using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Interfaces;
using ReportApp.DTO;
using ReportApp.DTO.Tools;
namespace ReportApp.ReportAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;

        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet("GetAllTask")]
        public List<TaskDto> GetAll()
        {
            return _taskServices.GetAll();
        }

        [HttpGet("GetTaskById/{id}")]
        public TaskDto GetById(Guid id)
        {
            return _taskServices.GetById(id);
        }

        [HttpPost("UpdateTask")]
        public void Update(TaskDto entity)
        {
            _taskServices.Update(entity);
        }

        [HttpGet("GetTaskByCreationTime/{dateTime}")]
        public TaskDto GetTaskByCreationTime(DateTime dateTime)
        {
            return _taskServices.GetTaskByCreationTime(dateTime);
        }

        [HttpGet("GetTaskByLastModifiedTime/{dateTime}")]
        public TaskDto GetTaskByLastModifiedTime(DateTime dateTime)
        {
            return _taskServices.GetTaskByLastModifiedTime(dateTime);
        }

        [HttpGet("GetTasksOfEmployee/{employeeId}")]
        public List<TaskDto> GetTasksOfEmployee(Guid employeeId)
        {
            return _taskServices.GetTasksOfEmployee(employeeId);
        }

        [HttpGet("GetChangedTasks/{employeeId}")]
        public List<TaskDto> GetChangedTasks(Guid employeeId)
        {
            return _taskServices.GetChangedTasks(employeeId);
        }

        [HttpPost("CreateTask")]
        public void CreateTask(string name, Guid employeeId)
        {
            _taskServices.CreateTask(name, employeeId);
        }

        [HttpPost("ChangeStateOfTask")]
        public void ChangeStateOfTask(Guid taskId, TaskState state)
        {
            _taskServices.ChangeStateOfTask(taskId, state);
        }

        [HttpPost("AddCommentToTask")]
        public void AddCommentToTask(Guid taskId, CommentDto comment)
        {
            _taskServices.AddCommentToTask(taskId, comment);
        }

        [HttpPost("ChangeEmployeeOfTask")]
        public void ChangeEmployeeOfTask(Guid taskId, Guid employeeId)
        {
            _taskServices.ChangeEmployeeOfTask(taskId, employeeId);
        }

        [HttpGet("GetTasksFromSubordinates/{employeeId}")]
        public List<TaskDto> GetTasksFromSubordinates(Guid employeeId)
        {
            return _taskServices.GetTasksFromSubordinates(employeeId);
        }

        [HttpPost("ChangeTaskDescription")]
        public void ChangeTaskDescription(Guid taskId, string newDescription)
        {
            _taskServices.ChangeTaskDescription(taskId, newDescription);
        }
    }
}
