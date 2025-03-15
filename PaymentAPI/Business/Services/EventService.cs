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
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="EventService"/> with the required dependencies.
        /// </summary>
        /// <param name="repository">Event repository for accessing account data.</param>
        /// <param name="transactionRepository">Transaction repository for recording financial transactions.</param>
        /// <param name="mapper">Mapper for converting between entities and DTOs.</param>
        public EventService(IAccountRepository repository, ITransactionRepository transactionRepository, IAccountTransactionRepository accountTransactionRepository, IMapper mapper) {
            _repository = repository;
            _transactionRepository = transactionRepository;
            _accountTransactionRepository = accountTransactionRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Processes a financial event, determining the corresponding action based on the provided event type.
        /// </summary>
        /// <param name="eventDto">DTO object containing the event data to be processed.</param>
        /// <returns>Returns an <see cref="IActionResult"/> with the operation result.</returns>
        public async Task<IActionResult> ProcessEvent(EventDto eventDto) {
            try {
                if (eventDto.Amount <= 0)
                    throw new Exception("Invalid amount.");

                var eventType = GetEventType(eventDto.Type);
                if (eventType is null)
                    throw new Exception("Invalid event type.");

                return eventType switch {
                    ETypeEvent.Deposit => await HandleDeposit(eventDto.Destination, eventDto.Amount),
                    ETypeEvent.Withdraw => await HandleWithdraw(eventDto.Origin, eventDto.Amount),
                    ETypeEvent.Transfer => await HandleTransfer(eventDto.Origin, eventDto.Destination, eventDto.Amount),
                    _ => throw new Exception("Unsupported event type.")
                };
            }
            catch (Exception) {
                return new NotFoundObjectResult(0);
            }
        }

        /// <summary>
        /// Converts a string to an <see cref="ETypeEvent"/> enum value.
        /// </summary>
        /// <param name="type">String representing the event type.</param>
        /// <returns>The corresponding <see cref="ETypeEvent"/> value, or null if conversion fails.</returns>
        private static ETypeEvent? GetEventType(string type) {
            return Enum.TryParse<ETypeEvent>(type, true, out var result) ? result : null;
        }

        /// <summary>
        /// Performs a deposit into an account. If the account does not exist, it will be created.
        /// </summary>
        /// <param name="destinationId">Identifier of the destination account.</param>
        /// <param name="amount">Amount to be deposited.</param>
        /// <returns>Returns an <see cref="IActionResult"/> with account details after the deposit.</returns>
        private async Task<IActionResult> HandleDeposit(int destinationId, decimal amount) {
            var account = await _repository.GetById(destinationId);

            if (account == null) {
                // Create a new account if it does not exist
                account = new AccountEntity { Id = destinationId, Balance = amount };
                await _repository.Create(account);
            }
            else {
                // Update balance of existing account
                account.Balance += amount;
                await _repository.Update(account);
            }

            // Record the transaction
            var transaction = new TransactionEntity {
                Amount = amount
            };
            await _transactionRepository.Create(transaction);

            // Create AccountTransactionEntity
            var accountTransaction = new AccountTransactionEntity {
                AccountId = destinationId,
                TransactionId = transaction.Id,
                Type = ETypeEvent.Deposit
            };
            await _accountTransactionRepository.Create(accountTransaction);

            return new CreatedResult(string.Empty, new DepositDto {
                Destination = _mapper.Map<AccountDto>(account)
            });
        }

        /// <summary>
        /// Performs a withdrawal from an account, validating if there is sufficient balance.
        /// </summary>
        /// <param name="originId">Identifier of the origin account.</param>
        /// <param name="amount">Amount to be withdrawn.</param>
        /// <returns>Returns an <see cref="IActionResult"/> with account details after the withdrawal.</returns>
        /// <exception cref="Exception">Thrown if the account does not exist or if there is insufficient balance.</exception>
        private async Task<IActionResult> HandleWithdraw(int originId, decimal amount) {
            var account = await _repository.GetById(originId);
            if (account == null)
                throw new Exception("Origin account not found.");

            if (account.Balance < amount)
                throw new Exception("Insufficient balance.");

            // Update balance
            account.Balance -= amount;

            // Record the transaction
            var transaction = new TransactionEntity {
                Amount = amount
            };

            await _repository.Update(account);
            await _transactionRepository.Create(transaction);

            var accountTransaction = new AccountTransactionEntity {
                AccountId = originId,
                TransactionId = transaction.Id,
                Type = ETypeEvent.Withdraw
            };
            await _accountTransactionRepository.Create(accountTransaction);

            return new CreatedResult(string.Empty, new WithdrawDto {
                Origin = _mapper.Map<AccountDto>(account)
            });
        }

        /// <summary>
        /// Performs a transfer between two accounts, ensuring that the origin account has sufficient balance.
        /// </summary>
        /// <param name="originId">Identifier of the origin account.</param>
        /// <param name="destinationId">Identifier of the destination account.</param>
        /// <param name="amount">Amount to be transferred.</param>
        /// <returns>Returns an <see cref="IActionResult"/> with account details after the transfer.</returns>
        /// <exception cref="Exception">Thrown if the origin account does not exist, has insufficient balance, or another error occurs.</exception>
        private async Task<IActionResult> HandleTransfer(int originId, int destinationId, decimal amount) {
            var originAccount = await _repository.GetById(originId);
            if (originAccount == null)
                throw new Exception("Origin account not found.");

            if (originAccount.Balance < amount)
                throw new Exception("Insufficient balance for transfer.");

            var destinationAccount = await _repository.GetById(destinationId);
            if (destinationAccount == null) {
                // Create destination account if it does not exist
                destinationAccount = new AccountEntity { Id = destinationId };
                await _repository.Create(destinationAccount);
            }

            // Update balances of both accounts
            originAccount.Balance -= amount;
            destinationAccount.Balance += amount;

            // Record the transaction
            var transaction = new TransactionEntity {
                Amount = amount
            };

            await _repository.Update(originAccount);
            await _repository.Update(destinationAccount);
            await _transactionRepository.Create(transaction);

            // Create AccountTransactionEntity for both accounts
            var accountTransactionOrigin = new AccountTransactionEntity {
                AccountId = originId,
                TransactionId = transaction.Id,
                Type = ETypeEvent.Withdraw
            };
            await _accountTransactionRepository.Create(accountTransactionOrigin);

            var accountTransactionDestination = new AccountTransactionEntity {
                AccountId = destinationId,
                TransactionId = transaction.Id,
                Type = ETypeEvent.Deposit
            };
            await _accountTransactionRepository.Create(accountTransactionDestination);

            return new CreatedResult(string.Empty, new TransferDto {
                Origin = _mapper.Map<AccountDto>(originAccount),
                Destination = _mapper.Map<AccountDto>(destinationAccount)
            });
        }
    }
}
