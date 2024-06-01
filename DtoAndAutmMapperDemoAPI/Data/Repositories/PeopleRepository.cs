using DtoAndAutmMapperDemoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DtoAndAutmMapperDemoAPI.Data.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppDbContext _appDbContext;

        public PeopleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Person person)
        {
            await _appDbContext.People.AddAsync(person);
            await _appDbContext.SaveChangesAsync();
        }

        public void Delete(Person person)
        {
            _appDbContext.People.Remove(person);            
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _appDbContext.People.ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            return await _appDbContext.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}