using AutoMapper;
using PaymentAPI.Models.DTOs;
using PaymentAPI.Models.Entities;

namespace PaymentAPI.Data.Profiles {
    /// <summary>
    /// Perfil de mapeamento entre AccountDto e AccountEntity.
    /// </summary>
    public class AccountProfile : Profile {
        public AccountProfile() {
            // Mapeamento bidirecional entre AccountDto e AccountEntity
            CreateMap<AccountDto, AccountEntity>().ReverseMap();
        }
    }
}
