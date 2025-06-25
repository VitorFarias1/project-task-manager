using Dtos;

namespace Interfaces.Services 
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAll();
        TaskDto GetTaskByAId();
        void CreateTask(TaskDto task);
        void UpdateTask(TaskDto task, Guid Id);
        void DeleteTask(Guid Id);
    }
}