
using CommandAPINoRepository.Data;
using CommandAPINoRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandAPIWithRepository.Data
{
    public class SqlCommandRepo : ICommandRepo
    {

        private readonly AppDbContext _appDbContext;

        public SqlCommandRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateAsync(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            
            await _appDbContext.Commands.AddAsync(command);
        }

        public void Delete(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            _appDbContext.Remove(command);
        }

        public async Task<IEnumerable<Command>> GetAllAsync()
        {
            return await _appDbContext.Commands.ToListAsync();
        }

        public async Task<Command?> GetByIdAsync(int id)
        {
            return await _appDbContext.Commands.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChanges()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}