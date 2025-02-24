using System;
using Login.Entities;

namespace Login.Repository.UserRepository;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
}
