using Dtos;

namespace Interfaces.Services 
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAllTasks();
        TaskDto GetTaskById(Guid id);
        void CreateTask(TaskDto task);
        void UpdateTask(TaskDto task, Guid Id);
        void DeleteTask(Guid Id);
    }
}