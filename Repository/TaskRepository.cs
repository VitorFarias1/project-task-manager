using System.Data.Common;
using Context;
using Microsoft.EntityFrameworkCore;
using Models;

public class TaskRepository : ITaskRepository
{

    private readonly AppDbContext _dbContext;

    public TaskRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<TaskItem> GetAll()
    {
        return _dbContext.TasksItems.ToList();
    }

    public TaskItem GetById(Guid id)
    {
        var taskItem = _dbContext.TasksItems.FirstOrDefault(i => i.Id == id);
        if (taskItem == null)
        {
            throw new Exception("Não foi possível encontrar a Tarefa informada");
        }

        return taskItem;
    }

    public void CreateTask(TaskItem item)
    {
        _dbContext.Add(item);
        _dbContext.SaveChanges();
    }

    public void UpdateTask(TaskItem item, Guid id)
    {
        var taskTobeUpdated = _dbContext.TasksItems.FirstOrDefault(i => i.Id == id);

        if (taskTobeUpdated == null)
        {
            throw new Exception("Não foi possível atualizar a tarefa especificada");
        }
        
        taskTobeUpdated.Title = item.Title;
        taskTobeUpdated.Category = item.Category;
        taskTobeUpdated.Description = item.Description;
        taskTobeUpdated.IsCompleted = item.IsCompleted;

        _dbContext.SaveChanges();
    }

    public void DeleteTask(Guid id)
    {
        var taskToBeDeleted = _dbContext.TasksItems.Find(id);
        if (taskToBeDeleted != null)
        {
            _dbContext.TasksItems.Remove(taskToBeDeleted);
            _dbContext.SaveChanges();
        }
    }

}