namespace TaskTest.Repositories
{

    public interface ITaskImageRepository
    {
        Task AddImage(TaskImages image);
    }

    public class TaskImageRepository : ITaskImageRepository
    {
        public readonly AppDbContext _context;
        public TaskImageRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddImage(TaskImages image)
        { 
            _context.TaskImages.Add(image);
            await _context.SaveChangesAsync(); 
        }
    }
}
