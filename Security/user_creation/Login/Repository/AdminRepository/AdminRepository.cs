using System;
using AutoMapper;
using Login.Data;
using Login.Entities;
using Microsoft.EntityFrameworkCore;

namespace Login.Repository.AdminRepository;


public class AdminRepository : IAdminRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AdminRepository(ApplicationDbContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Admin>> GetAllAsync()
    {
        return await _context.Admins.ToListAsync();
    }

       public async Task<Admin> GetByIdAsync(int id)
    {
         return await _context.Admins.FindAsync(id);
    }

    public async Task<Admin> CreateAsync (Admin admin){
        await _context.Admins.AddAsync(admin);
        await _context.SaveChangesAsync();
        return admin;
    }
}
