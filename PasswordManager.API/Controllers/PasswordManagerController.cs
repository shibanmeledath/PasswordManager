using AutoMapper;
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
        public async Task<IActionResult> Create (AddPasswordDto passwordDto)
        {
           var passwordDomain= mapper.Map<Passwords>(passwordDto);

           passwordDomain= await passwordManagerRepository.AddPasswordasync(passwordDomain);

            return Ok(mapper.Map<PasswordDto>(passwordDomain));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            var passwords = await passwordManagerRepository.GetPasswordsAsync();
            return Ok(mapper.Map<IEnumerable<PasswordDto>>(passwords));
        }
        [HttpGet("{id:guid}")]

        public async Task<IActionResult> GetById (Guid id)
        {
            var passwordDomain = await passwordManagerRepository.GetPasswordByIdAsync(id);
            if (passwordDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PasswordDto>(passwordDomain));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, EditPasswordDto passwordDto)
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
        public async Task<IActionResult> Delete(Guid id)
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
