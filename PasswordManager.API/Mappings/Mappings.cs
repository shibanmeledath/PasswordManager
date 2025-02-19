using AutoMapper;
using PasswordManager.API.Models.Domain;
using PasswordManager.API.Models.Dto;

namespace PasswordManager.API.Mappings
{
    public class Mappings: Profile
    {
        public Mappings()
        {
            CreateMap<AddPasswordDto, Passwords>().ReverseMap();
            CreateMap<PasswordDto, Passwords>().ReverseMap();
            CreateMap<EditPasswordDto, Passwords>().ReverseMap();
        }
    }
}
