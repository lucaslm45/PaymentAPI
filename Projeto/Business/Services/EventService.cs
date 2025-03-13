using AutoMapper;
using Projeto.Business.Services.Interfaces;
using Projeto.Data.Repositories.Interfaces;
using Projeto.Models.DTOs;
using Projeto.Models.Entities;
using Projeto.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Projeto.Business.Services {
    public class EventService : IEventService {

        private readonly IEventRepository _repository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository repository, ITransactionRepository transactionRepository, IMapper mapper) {
            _repository = repository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> ProcessEvent(EventDto eventDto) {
            try {
                var eventType = GetEventType(eventDto.Type);
                if (eventType is null)
                    throw new Exception();

                switch (eventType) {
                    case ETypeEvent.Deposit:
                        return await HandleDeposit(eventDto.Destination!, eventDto.Amount);
                    case ETypeEvent.Withdraw:
                        return await HandleWithdraw(eventDto.Origin!, eventDto.Amount);
                    case ETypeEvent.Transfer:
                        return await HandleTransfer(eventDto.Origin!, eventDto.Destination!, eventDto.Amount);
                    default:
                        throw new Exception();
                }
            }
            catch (Exception ex) {
                return new NotFoundObjectResult(ex.Message);
            }
        }
        // Método auxiliar para conversão segura do enum
        private static ETypeEvent? GetEventType(string type) {
            return Enum.TryParse<ETypeEvent>(type, true, out var result) ? result : null;
        }
        private async Task<IActionResult> HandleDeposit(string destinationId, decimal amount) {
            var account = await _repository.GetById(destinationId);

            if (account == null) {
                account = new AccountEntity { Id = destinationId, Balance = amount };
                await _repository.Create(account);
            }
            else {
                account.Balance += amount;
                await _repository.Update(account);
            }

            return new CreatedResult(string.Empty, new DepositDto {
                Destination = _mapper.Map<AccountDto>(account)
            });
        }
        private async Task<IActionResult> HandleWithdraw(string originId, decimal amount) {
            var account = await _repository.GetById(originId);
            if (account == null)
                return new NotFoundObjectResult(0);

            account.Balance -= amount;

            var transaction = new TransactionEntity {
                OriginId = originId,
                Amount = amount,
                Type = ETypeEvent.Withdraw
            };

            await _repository.Update(account);
            await _transactionRepository.Create(transaction);

            return new CreatedResult(string.Empty, new WithdrawDto {
                Origin = _mapper.Map<AccountDto>(account)
            });
        }

        private async Task<IActionResult> HandleTransfer(string originId, string destinationId, decimal amount) {
            var originAccount = await _repository.GetById(originId);
            if (originAccount == null)
                return new NotFoundObjectResult(0);

            var destinationAccount = await _repository.GetById(destinationId);
            if (destinationAccount == null) {
                destinationAccount = new AccountEntity {
                    Id = destinationId,
                    Balance = 0
                };
                await _repository.Create(destinationAccount);
            }

            originAccount.Balance -= amount;
            destinationAccount.Balance += amount;

            var transaction = new TransactionEntity {
                OriginId = originId,
                DestinationId = destinationId,
                Amount = amount,
                Type = ETypeEvent.Transfer
            };

            await _repository.Update(originAccount);
            await _repository.Update(destinationAccount);
            await _transactionRepository.Create(transaction);

            return new CreatedResult(string.Empty, new TransferDto {
                Origin = _mapper.Map<AccountDto>(originAccount),
                Destination = _mapper.Map<AccountDto>(destinationAccount)
            });
        }
    }
}
