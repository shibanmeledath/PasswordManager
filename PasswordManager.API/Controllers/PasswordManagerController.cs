﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.API.Models.Domain;
using PasswordManager.API.Models.Dto;
using PasswordManager.API.Repositories;

namespace PasswordManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordManagerController(IMapper mapper, IPasswordManagerRepository passwordManagerRepository) : ControllerBase
    {
        private readonly IMapper mapper = mapper;
        private readonly IPasswordManagerRepository passwordManagerRepository = passwordManagerRepository;

        [HttpPost]
        public async Task<ActionResult<Passwords>> Create (AddPasswordDto passwordDto)
        {
           var passwordDomain= mapper.Map<Passwords>(passwordDto);

           passwordDomain= await passwordManagerRepository.AddPasswordasync(passwordDomain);

            return Ok(mapper.Map<PasswordDto>(passwordDomain));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passwords>>> GetAll([FromQuery] int pageNumber , [FromQuery] int pageSize)
        {
           
            var totalCount = await passwordManagerRepository.GetTotalPasswordsCountAsync();

            var passwords = await passwordManagerRepository.GetPasswordsAsync(pageNumber, pageSize);

            return Ok(new
            {
                items = mapper.Map<IEnumerable<PasswordDto>>(passwords),
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize)
        });
        }
        [HttpGet("{id:guid}")]

        public async Task<ActionResult<Passwords>> GetById (Guid id)
        {
            var passwordDomain = await passwordManagerRepository.GetPasswordByIdAsync(id);
            if (passwordDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PasswordDto>(passwordDomain));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Passwords>> Update(Guid id, EditPasswordDto passwordDto)
        {
            var passwordDomain = await passwordManagerRepository.GetPasswordByIdAsync(id);
            if (passwordDomain == null)
            {
                return NotFound();
            }
            mapper.Map(passwordDto, passwordDomain);
            await passwordManagerRepository.UpdateChangesAsync();
            return Ok(mapper.Map<PasswordDto>(passwordDomain));
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Passwords>> Delete(Guid id)
        {
            var passwordDomain = await passwordManagerRepository.GetPasswordByIdAsync(id);
            if (passwordDomain == null)
            {
                return NotFound();
            }
            await passwordManagerRepository.DeleteChangesAsync(passwordDomain);
            return Ok(mapper.Map<PasswordDto>(passwordDomain));
        }
    }
}
