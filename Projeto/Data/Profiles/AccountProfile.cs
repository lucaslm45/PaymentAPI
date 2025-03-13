using AutoMapper;
using Projeto.Models.DTOs;
using Projeto.Models.Entities;

namespace Projeto.Data.Profiles {
    public class AccountProfile : Profile {
        public AccountProfile() {
            CreateMap<AccountDto, AccountEntity>();
            CreateMap<AccountEntity, AccountDto>();
        }

    }
}
