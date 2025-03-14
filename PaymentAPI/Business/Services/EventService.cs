using AutoMapper;
using PaymentAPI.Business.Services.Interfaces;
using PaymentAPI.Data.Repositories.Interfaces;
using PaymentAPI.Models.DTOs;
using PaymentAPI.Models.Entities;
using PaymentAPI.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace PaymentAPI.Business.Services {
    public class EventService : IEventService {

        private readonly IAccountRepository _repository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="EventService"/> com as dependências necessárias.
        /// </summary>
        /// <param name="repository">Repositório de eventos para acesso aos dados das contas.</param>
        /// <param name="transactionRepository">Repositório de transações para registrar movimentações financeiras.</param>
        /// <param name="mapper">Mapper para conversão entre entidades e DTOs.</param>
        public EventService(IAccountRepository repository, ITransactionRepository transactionRepository, IMapper mapper) {
            _repository = repository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Processa um evento financeiro, determinando a ação correspondente com base no tipo de evento informado.
        /// </summary>
        /// <param name="eventDto">Objeto DTO contendo os dados do evento a ser processado.</param>
        /// <returns>Retorna um <see cref="IActionResult"/> com o resultado da operação.</returns>
        public async Task<IActionResult> ProcessEvent(EventDto eventDto) {
            try {
                if (eventDto.Amount <= 0)
                    throw new Exception("Valor incorreto.");

                var eventType = GetEventType(eventDto.Type);
                if (eventType is null)
                    throw new Exception("Tipo de evento inválido.");

                return eventType switch {
                    ETypeEvent.Deposit => await HandleDeposit(eventDto.Destination!, eventDto.Amount),
                    ETypeEvent.Withdraw => await HandleWithdraw(eventDto.Origin!, eventDto.Amount),
                    ETypeEvent.Transfer => await HandleTransfer(eventDto.Origin!, eventDto.Destination!, eventDto.Amount),
                    _ => throw new Exception("Tipo de evento não suportado.")
                };
            }
            catch (Exception) {
                return new NotFoundObjectResult(0);
            }
        }

        /// <summary>
        /// Converte uma string para um valor do enum <see cref="ETypeEvent"/>.
        /// </summary>
        /// <param name="type">String representando o tipo do evento.</param>
        /// <returns>O valor correspondente do enum <see cref="ETypeEvent"/>, ou null se a conversão falhar.</returns>
        private static ETypeEvent? GetEventType(string type) {
            return Enum.TryParse<ETypeEvent>(type, true, out var result) ? result : null;
        }

        /// <summary>
        /// Realiza um depósito em uma conta. Caso a conta não exista, ela será criada.
        /// </summary>
        /// <param name="destinationId">Identificador da conta de destino.</param>
        /// <param name="amount">Valor a ser depositado.</param>
        /// <returns>Retorna um <see cref="IActionResult"/> com os detalhes da conta após o depósito.</returns>
        private async Task<IActionResult> HandleDeposit(string destinationId, decimal amount) {
            var account = await _repository.GetById(destinationId);

            if (account == null) {
                // Criar nova conta caso não exista
                account = new AccountEntity { Id = destinationId, Balance = amount };
                await _repository.Create(account);
            }
            else {
                // Atualizar saldo da conta existente
                account.Balance += amount;
                await _repository.Update(account);
            }

            // Registrar a transação
            var transaction = new TransactionEntity {
                DestinationId = destinationId,
                Amount = amount,
                Type = ETypeEvent.Deposit
            };
            await _transactionRepository.Create(transaction);

            return new CreatedResult(string.Empty, new DepositDto {
                Destination = _mapper.Map<AccountDto>(account)
            });
        }

        /// <summary>
        /// Realiza um saque em uma conta, validando se há saldo suficiente.
        /// </summary>
        /// <param name="originId">Identificador da conta de origem.</param>
        /// <param name="amount">Valor a ser sacado.</param>
        /// <returns>Retorna um <see cref="IActionResult"/> com os detalhes da conta após o saque.</returns>
        /// <exception cref="Exception">Lançado se a conta não existir ou se não houver saldo suficiente.</exception>
        private async Task<IActionResult> HandleWithdraw(string originId, decimal amount) {
            var account = await _repository.GetById(originId);
            if (account == null)
                throw new Exception("Conta de origem não encontrada.");

            if (account.Balance < amount)
                throw new Exception("Saldo insuficiente.");

            // Atualizar saldo
            account.Balance -= amount;

            // Registrar a transação
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

        /// <summary>
        /// Realiza uma transferência entre duas contas, garantindo que a conta de origem tenha saldo suficiente.
        /// </summary>
        /// <param name="originId">Identificador da conta de origem.</param>
        /// <param name="destinationId">Identificador da conta de destino.</param>
        /// <param name="amount">Valor a ser transferido.</param>
        /// <returns>Retorna um <see cref="IActionResult"/> com os detalhes das contas após a transferência.</returns>
        /// <exception cref="Exception">Lançado se a conta de origem não existir, não tiver saldo suficiente ou ocorrer outro erro.</exception>
        private async Task<IActionResult> HandleTransfer(string originId, string destinationId, decimal amount) {
            var originAccount = await _repository.GetById(originId);
            if (originAccount == null)
                throw new Exception("Conta de origem não encontrada.");

            if (originAccount.Balance < amount)
                throw new Exception("Saldo insuficiente para transferência.");

            var destinationAccount = await _repository.GetById(destinationId);
            if (destinationAccount == null) {
                // Criar conta de destino se não existir
                destinationAccount = new AccountEntity { Id = destinationId };
                await _repository.Create(destinationAccount);
            }

            // Atualizar saldos das contas
            originAccount.Balance -= amount;
            destinationAccount.Balance += amount;

            // Registrar a transação
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
