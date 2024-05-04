using ecoapp.Models;
using Microsoft.EntityFrameworkCore;

namespace ecoapp.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private DbContextApp DbContext;
        public AuthenticationRepository(DbContextApp dbContext) 
        {
            DbContext = dbContext;
        }
        public async Task<UserModel?> Login(UserModel user)
        {
            try
            {
                var login = await DbContext.Users.FirstOrDefaultAsync(u => (u.Email == user.Email || u.Name == user.Name) && u.PasswordUser == user.PasswordUser);
                if (login != null)
                {
                    DbContext.Logs.Add(new LogModel()
                    {
                        Id = 0,
                        Action = "LOGIN",
                        DateRegistered = DateTime.UtcNow,
                        TableRegitered = "USER",
                        Detail = $"Logeo del usuario {user.Email}, {user.Name}.",
                        UserId = 2,
                        User = await DbContext.Users.FirstAsync(u => u.Id == 2)
                    });
                    await DbContext.SaveChangesAsync();
                }
                return login;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
