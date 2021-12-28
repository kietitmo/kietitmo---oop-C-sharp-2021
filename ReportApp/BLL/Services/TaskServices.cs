using AutoMapper;
using ReportApp.BLL.Interfaces;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Entities.Commit;
using ReportApp.DAL.UnitOfWork;
using ReportApp.DTO;
using ReportApp.DTO.Tools;
using System;
using System.Collections.Generic;

namespace ReportApp.BLL.Services
{
    public class TaskServices : ITaskServices
    {
        private IUnitOfWork _database;
        private IMapper _mapper;

        public TaskServices(IUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public void Add(TaskDto entity)
        {
            _database.TaskRepository.Add(_mapper.Map<TaskEntity>(entity));
            _database.TaskRepository.Save();
        }

        public void AddCommentToTask(Guid taskId, CommentDto comment)
        {
            TaskEntity task = _database.TaskRepository.GetById(taskId);
            task.Comment.Add(_mapper.Map<CommentEntity>(comment));
            _database.CommitRepository.Add(new TaskCommentCommit(taskId, _mapper.Map<CommentEntity>(comment), "feat: Add new comment"));
            _database.TaskRepository.Save();
        }

        public void ChangeEmployeeOfTask(Guid taskId, Guid employeeId)
        {
            TaskEntity task = _database.TaskRepository.GetById(taskId);
            _database.CommitRepository.Add(new TaskEmployeeIdCommit(taskId,employeeId, "fix: Changed EmployeeId of Task"));
            task.EmployeeId = employeeId;
            _database.TaskRepository.Save();   
        }

        public void ChangeStateOfTask(Guid taskId, TaskState state)
        {
            TaskEntity task = _database.TaskRepository.GetById(taskId);
            _database.CommitRepository.Add(new TaskStateCommit(taskId, state, "fix: Changed State of Task"));
            task.TaskState = state;
            _database.TaskRepository.Save();
        }

        public void ChangeTaskDescription(Guid taskId, string newDescription)
        {
            TaskEntity task = _database.TaskRepository.GetById(taskId);
            _database.CommitRepository.Add(new TaskDescriptionCommit(taskId, newDescription, "fix: Changed State of Task"));
            task.DescriptionOfTask = newDescription;
            _database.TaskRepository.Save();
        }

        public void CreateTask(string name, Guid employeeId)
        {
            var newTask = new TaskEntity(name, employeeId);
            _database.TaskRepository.Add(newTask);
            _database.TaskRepository.Save();
        }

        public void Delete(Guid id)
        {
            _database.TaskRepository.Delete(id);
            _database.TaskRepository.Save();
        }

        public List<TaskDto> GetAll()
        {
            return _mapper.Map<List<TaskDto>>(_database.TaskRepository.GetAll());
        }

        public TaskDto GetById(Guid id)
        {
            return _mapper.Map<TaskDto>(_database.TaskRepository.GetById(id));
        }

        public List<TaskDto> GetChangedTasks(Guid employeeId)
        {
            List<AbstractCommit> allCommits = _database.CommitRepository.GetAll();
            List<TaskEntity> allTasks = _database.TaskRepository.GetAll();
            var listTaskResult = new List<TaskDto>();

            foreach (AbstractCommit commit in allCommits)
            {
                allTasks.ForEach(task => { if (task.Id == commit.TaskId) listTaskResult.Add(_mapper.Map<TaskDto>(task)); });
            }

            return listTaskResult;
        }

        public TaskDto GetTaskByCreationTime(DateTime datetime)
        {
            foreach(TaskEntity task in (_database.TaskRepository.GetAll()))
            {
                if(task.StartDate == datetime)
                {
                    return _mapper.Map<TaskDto>(task);
                }
            }
            return null;
        }

        public TaskDto GetTaskByLastModifiedTime(DateTime datetime)
        {
            foreach (TaskEntity task in (_database.TaskRepository.GetAll()))
            {
                if (task.FinishDate == datetime)
                {
                    return _mapper.Map<TaskDto>(task);
                }
            }
            return null;
        }

        public List<TaskDto> GetTasksFromSubordinates(Guid employeeId)
        {
            List<EmployeeEntity> allEmployees = _database.EmployeeRepository.GetAll();
            List<TaskEntity> allTasks = _database.TaskRepository.GetAll();
            var taskList = new List<TaskEntity>();

            foreach (EmployeeEntity employee in allEmployees)
            {
                if (employee.SuperiorId == employeeId)
                {
                    allTasks.ForEach(task => { if (task.EmployeeId == employee.Id) taskList.Add(task); });
                }
            }

            return _mapper.Map<List<TaskDto>>(taskList);
        }

        public List<TaskDto> GetTasksOfEmployee(Guid employeeId)
        {
            var taskList = new List<TaskDto>();
            foreach (TaskEntity task in (_database.TaskRepository.GetAll()))
            {
                if (task.EmployeeId == employeeId)
                {
                    taskList.Add(_mapper.Map<TaskDto>(task));
                }
            }
            return taskList;
        }

        public void Save()
        {
            _database.TaskRepository.Save();
        }

        public void Update(TaskDto entity)
        {
            _database.TaskRepository.Update(_mapper.Map<TaskEntity>(entity));
            _database.TaskRepository.Save();
        }
    }
}
