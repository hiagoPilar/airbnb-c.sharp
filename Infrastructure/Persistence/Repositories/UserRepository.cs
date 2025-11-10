
using airbnb_c_.Domain.Entities;
using airbnb_c_.Domain.Interfaces;
using airbnb_c_.Infrastructure.Persistence.Context;

namespace airbnb_c_.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _appDbContext.Users.findAsync(id);
            if(user != null)
            {
                _appDbContext.Users.DeleteAsync(user);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _appDbContext.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.Email.Address.ToLower() == email.ToLower());
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
            await _appDbContext.Users.UpdateAsync(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
