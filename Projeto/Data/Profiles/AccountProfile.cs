using AutoMapper;
using Projeto.Models.DTOs;
using Projeto.Models.Entities;

namespace Projeto.Data.Profiles {
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
