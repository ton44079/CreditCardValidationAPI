using CreditCardValidationAPI.Repositories.Interfaces;
using CreditCardValidationAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCardValidationAPI.Services.Models;

namespace CreditCardValidationAPI.Services.Implements
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ISpCreditCardValidationRepository _spCreditCardValidationRepository;

        public CreditCardService(ISpCreditCardValidationRepository spCreditCardValidationRepository)
        {
            _spCreditCardValidationRepository = spCreditCardValidationRepository;
        }

        public ValidateResultModel Validatie(string input)
        {
            var spResult = _spCreditCardValidationRepository.ValidateCreditCard(input);
            ValidateResultModel result = new ValidateResultModel();
            result.Result = spResult.Result;
            result.CardType = spResult.CardType;

            return result;
        }
    }
}
