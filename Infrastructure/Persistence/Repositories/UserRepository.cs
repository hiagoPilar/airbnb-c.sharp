
using airbnb_c_.Domain.Entities;
using airbnb_c_.Domain.Interfaces;
using airbnb_c_.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

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
            var user = await _appDbContext.Users.FindAsync(id);
            if(user != null)
            {
                _appDbContext.Users.Remove(user);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var normalizeEmail = email.ToLowerInvariant();

            return await _appDbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.Address == normalizeEmail);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
            var existingUser = await _appDbContext.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (existingUser == null)
                throw new ArgumentException("User not found.");

            //atualiza somente as propriedades que mudaram
            _appDbContext.Entry(existingUser).CurrentValues.SetValues(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
