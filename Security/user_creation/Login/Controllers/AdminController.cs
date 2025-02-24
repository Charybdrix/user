using System;
using AutoMapper;
using Login.DTO.AdminDTOs;
using Login.Entities;
using Login.Repository.AdminRepository;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IAdminRepository _adminRepo;
    private readonly IMapper _mapper;

    public AdminController(IAdminRepository adminRepo, IMapper mapper){
        _adminRepo = adminRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        var admin = await _adminRepo.GetAllAsync();
        var admin_dto = _mapper.Map<List<AdminDTO>>(admin);
        return Ok(admin_dto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id){
    var admin = await _adminRepo.GetByIdAsync(id);
    if(admin == null){
        return NotFound(new {message = "Id not found"});
    }

    var admin_dto = _mapper.Map<AdminDTO>(admin);
    return Ok(admin_dto);
}
    [HttpPost]
    public async Task<IActionResult> AddAdmin([FromBody] createAdminDTO createAdminDTO){
    var admin = _mapper.Map<Admin>(createAdminDTO);
    var admin_id = await _adminRepo.CreateAsync(admin);

    return CreatedAtAction(nameof(GetById), new {id = admin_id}, admin);
}

}
