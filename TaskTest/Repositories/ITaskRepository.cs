using System.Collections;

namespace TaskTest.Repositories
{
    public interface ITaskRepository
    {
         Task AddTask(Tasks data);
         Task<IEnumerable<Tasks>> GetAllTasks();
         Task<Tasks?> GetLatest();
         Task<IEnumerable<TaskTitleAndId>> GetNameOfTasks();


    }
}
 