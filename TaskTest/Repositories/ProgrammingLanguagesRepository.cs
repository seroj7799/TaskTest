namespace TaskTest.Repositories
{

    public interface IProgrammingLanguagesRepository
    {
        Task<IEnumerable<ProgrammingLanguages>> GetProgrammingLanguages();
    }

    public class ProgrammingLanguagesRepository : IProgrammingLanguagesRepository
    {
        private readonly AppDbContext _context;
        public ProgrammingLanguagesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgrammingLanguages>> GetProgrammingLanguages()
        {
            return await _context.ProgrammingLanguages.ToListAsync();
        }
        

    }
}
