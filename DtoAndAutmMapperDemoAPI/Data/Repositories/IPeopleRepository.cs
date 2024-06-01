using DtoAndAutmMapperDemoAPI.Models;

namespace DtoAndAutmMapperDemoAPI.Data.Repositories
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(int id);
        Task Create(Person person);
        void Delete(Person person);

        Task SaveChangesAsync();
    }
}