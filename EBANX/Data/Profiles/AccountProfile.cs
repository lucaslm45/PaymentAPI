using AutoMapper;
using EBANX.Models.DTOs;
using EBANX.Models.Entities;

namespace EBANX.Data.Profiles {
    public class AccountProfile : Profile {
        public AccountProfile() {
            CreateMap<AccountDto, AccountEntity>();
            CreateMap<AccountEntity, AccountDto>();
        }

    }
}
