using Angular_DotNet_API_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_DotNet_API_CRUD.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();

        Task<User> GetUser(int? userId);

        Task<int> AddUser(User user);

        Task<int> DeleteUser(int? userId);

        Task UpdateUser(User user);
    }
}
