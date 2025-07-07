using System.Data.Common;
using Context;
using Microsoft.EntityFrameworkCore;
using Models;

public class TaskRepository : ITaskRepository
{
    
    private readonly AppDbContext _dbContext;

    public TaskRepository(AppDbContext dbContext) {
        _dbContext = dbContext;
    }
    public IEnumerable<TaskItem> GetAll()
    {
        return _dbContext.TasksItems.ToList();
    }
}