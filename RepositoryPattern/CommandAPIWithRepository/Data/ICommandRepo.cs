using CommandAPINoRepository.Models;

namespace CommandAPIWithRepository.Data
{
    public interface ICommandRepo
    {
        Task<IEnumerable<Command>> GetAllAsync();
        Task<Command> GetByIdAsync(int id);
        Task CreateAsync(Command command);

        void Delete(Command command);

        Task SaveChanges();
    }
}