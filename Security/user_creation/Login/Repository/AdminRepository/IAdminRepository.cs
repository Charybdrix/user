using System;
using Login.Entities;

namespace Login.Repository.AdminRepository;

public interface IAdminRepository{
    Task<List<Admin>> GetAllAsync();
    Task<Admin> GetByIdAsync(int id);
    Task<Admin> CreateAsync(Admin admin);   
}
