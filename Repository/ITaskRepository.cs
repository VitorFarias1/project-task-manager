using Models;

public interface ITaskRepository
{
    IEnumerable<TaskItem> GetAll();
    TaskItem GetById(Guid Id);
    void CreateTask(TaskItem item);
    void UpdateTask(TaskItem item, Guid id);
    void DeleteTask(Guid id);
    
}