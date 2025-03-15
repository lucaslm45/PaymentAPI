using AutoMapper;
using PaymentAPI.Models.DTOs;
using PaymentAPI.Models.Entities;

namespace PaymentAPI.Data.Profiles {
    /// <summary>
    /// Mapping profile between AccountDto and AccountEntity.
    /// </summary>
    public class AccountProfile : Profile {
        public AccountProfile() {
            // Bidirectional mapping between AccountDto and AccountEntity
            CreateMap<AccountDto, AccountEntity>().ReverseMap();
        }
    }
}
