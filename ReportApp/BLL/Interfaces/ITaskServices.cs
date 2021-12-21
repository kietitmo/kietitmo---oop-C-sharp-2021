using System;
using System.Collections.Generic;
using ReportApp.DTO;
using ReportApp.DTO.Tools;

namespace ReportApp.BLL.Interfaces
{
    public interface ITaskServices : IServices<TaskDto>
    {
        public TaskDto GetTaskByCreationTime(DateTime datetime);
        public TaskDto GetTaskByLastModifiedTime(DateTime datetime);
        public List<TaskDto> GetTasksOfEmployee(Guid employeeId);
        public List<TaskDto> GetChangedTasks(Guid employeeId);
        public void CreateTask(string name, Guid employeeId);
        public void ChangeStateOfTask(Guid taskId, TaskState state);
        public void AddCommentToTask(Guid taskId, CommentDto comment);
        public void ChangeEmployeeOfTask(Guid taskId, Guid employeeId);
        public List<TaskDto> GetTasksFromSubordinates(Guid employeeId);
        public void ChangeTaskDescription(Guid taskId, string newDescription);
    }
}
