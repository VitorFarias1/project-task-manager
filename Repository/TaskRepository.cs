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

    public void UpdateTask(TaskItem item)
    {
        _dbContext.Update(item); 
        _dbContext.SaveChanges();
    }

    public void DeleteTask(Guid id)
    {
        var item = _dbContext.TasksItems.Find(id);
        if (item != null)
        {
            _dbContext.TasksItems.Remove(item);
            _dbContext.SaveChanges();
        }
    }

}