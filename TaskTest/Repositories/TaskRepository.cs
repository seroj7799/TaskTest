using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace TaskTest.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddTask(Tasks data)
        {
            _context.Tasks.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tasks>> GetAllTasks()
        {
            return await _context.Tasks.Include(a => a.Category).
                Include(a => a.Difficulty)
                .Include(a => a.Tests)
                .Include(a => (a as Tasks).TaskImages)
                .ToArrayAsync();
        }

        public async Task<Tasks?> GetLatest()
        {
            return await _context.Tasks.OrderBy(e => e.CreatedAt).LastOrDefaultAsync();
        }

        public async Task<IEnumerable<TaskTitleAndId>> GetNameOfTasks()
        {
            var result = await (from tasks in _context.Tasks
                    select new TaskTitleAndId() { Id = tasks.Id, Title = tasks.Title }).ToListAsync();

            return result;

        }

    }
}
