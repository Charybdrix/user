using System;
using AutoMapper;
using Login.DTO.UserDTOs;
using Login.Entities;
using Login.Repository.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UserController : ControllerBase{

    private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;

public UserController(IUserRepository userRepo, IMapper mapper){
    _userRepo = userRepo;
    _mapper = mapper;
}

[HttpGet]
public async Task<IActionResult> GetAll(){
    var users = await _userRepo.GetAllAsync();
    var user_dto = _mapper.Map<List<UserDTO>>(users);
    return Ok(user_dto);
}

[HttpGet("{id}")]
public async Task<IActionResult> GetById(int id){
    var users = await _userRepo.GetByIdAsync(id);
    if(users == null){
        return NotFound(new {message = "Id not found"});
    }

    var user_dto = _mapper.Map<UserDTO>(users);
    return Ok(user_dto);
}

[HttpPost]
public async Task<IActionResult> AddUser([FromBody] createUserDTO createUserDTO){
    var user = _mapper.Map<User>(createUserDTO);
    var user_id = await _userRepo.CreateAsync(user);

    return CreatedAtAction(nameof(GetById), new {id = user_id}, user);
}
}
