using System.Reflection.Metadata.Ecma335;
using Dtos;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Models;

namespace Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<TaskDto> GetAllTasks()
        {

            return _repository.GetAll().Select(MapEntityToDto);
        }

        public TaskDto GetTaskById(Guid id)
        {
            TaskItem task = _repository.GetById(id);
            return MapEntityToDto(task);
        }

        public void CreateTask(TaskDto taskDto)
        {
            _repository.CreateTask(MapDtoToEntity(taskDto));
        }

        public void UpdateTask(TaskDto taskDto, Guid id)
        {
            _repository.UpdateTask(MapDtoToEntity(taskDto), id);
        }

        public void DeleteTask(Guid id)
        {
            _repository.DeleteTask(id);
        }

        public static TaskDto MapEntityToDto(TaskItem task) => new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Category = task.Category,
            Description = task.Description,
            IsCompleted = task.IsCompleted
        };

        public static TaskItem MapDtoToEntity(TaskDto taskDto) => new TaskItem
        {
            Id = taskDto.Id,
            Title = taskDto.Title,
            Category = taskDto.Category,
            Description = taskDto.Description,
            IsCompleted = taskDto.IsCompleted
        };

    }

}