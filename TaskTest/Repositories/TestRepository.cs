namespace TaskTest.Repositories
{
    public interface ITestRepository
    {
        Task AddTest(IEnumerable<Tests> data);
        Task<IEnumerable<Tests>> GetAllTest();

    }

    public class TestRepository : ITestRepository
    {
        public readonly AppDbContext _dbContext;
        public TestRepository(AppDbContext dbContext)
        {

            _dbContext = dbContext;

        }


        public async Task AddTest(IEnumerable<Tests> data)
        {
            foreach(var test in data) 
                _dbContext.Tests.Add(test);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tests>> GetAllTest()
        {
            return await _dbContext.Tests.ToArrayAsync();
        }

    }
}
