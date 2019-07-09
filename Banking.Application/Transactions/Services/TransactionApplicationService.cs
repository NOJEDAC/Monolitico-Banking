using Banking.Application.Transactions.Constants;
using Banking.Application.Transactions.Contracts;
using Banking.Application.Transactions.Dtos;
using Banking.Domain.Accounts.Contracts;
using Banking.Domain.Accounts.Entities;
using Banking.Domain.Transactions.Contracts;
using Microsoft.AspNetCore.Http;
using Common;
using System;

namespace Banking.Application.Transactions.Services
{
    public class TransactionApplicationService : ITransactionApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly ITransferDomainService _transferDomainService;

        public TransactionApplicationService(
            IUnitOfWork unitOfWork,
            IAccountRepository accountRepository,
            ITransferDomainService transferDomainService)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
            _transferDomainService = transferDomainService;
        }

        public NewTransferResponseDto PerformTransfer(NewTransferDto newTransferDto)
        {
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                Account originAccount = _accountRepository.GetByNumberWithUpgradeLock(newTransferDto.FromAccountNumber);
                Account destinationAccount = _accountRepository.GetByNumberWithUpgradeLock(newTransferDto.ToAccountNumber);
                _transferDomainService.PerformTransfer(originAccount, destinationAccount, newTransferDto.Amount);
                _accountRepository.SaveOrUpdate(originAccount);
                _accountRepository.SaveOrUpdate(destinationAccount);
                _unitOfWork.Commit(uowStatus);
                return new NewTransferResponseDto
                {
                    HttpStatusCode = StatusCodes.Status201Created,
                    StringResponse = new ApiStringResponse(TransactionAppConstants.TransferPerformed)
                };
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewTransferResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    StringResponse = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
    }
}
