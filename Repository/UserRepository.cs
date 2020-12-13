using Angular_DotNet_API_CRUD.Data;
using Angular_DotNet_API_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_DotNet_API_CRUD.Repository
{
    public class UserRepository : IUserRepository
    {
        ClientDbContext db;
        public UserRepository(ClientDbContext _db)
        {
            db = _db;
        }


        public async Task<List<User>> GetUsers()
        {
            if (db != null)
            {
                var users = await Task.FromResult(db.Users.ToList());
                return users;
            }

            return null;
        }

        public async Task<User> GetUser(int? userId)
        {
            if (db != null)
            {
                var user = await Task.FromResult(db.Users.Where(f => f.ID == userId).FirstOrDefault());
                return user;
            }

            return null;
        }

        public async Task<int> AddUser(User user)
        {
            if (db != null)
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();

                return user.ID;
            }

            return 0;
        }

        public async Task<int> DeleteUser(int? userId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var user = await Task.FromResult(db.Users.FirstOrDefault(x => x.ID == userId));

                if (user != null)
                {
                    //Delete that post
                    db.Users.Remove(user);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdateUser(User user)
        {
            if (db != null)
            {
                //Delete that post
                db.Users.Update(user);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}

