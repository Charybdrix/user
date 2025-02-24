using System;
using AutoMapper;
using Login.Data;
using Login.Entities;
using Microsoft.EntityFrameworkCore;

namespace Login.Repository.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(ApplicationDbContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }
  
    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task<User> GetByIdAsync(int id)
    {
         return await _context.Users.FindAsync(id);
    }

}
