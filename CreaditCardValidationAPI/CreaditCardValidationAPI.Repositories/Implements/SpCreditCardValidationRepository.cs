using CreditCardValidationAPI.Domain.Context;
using CreditCardValidationAPI.Domain.Generics.Implements;
using CreditCardValidationAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationAPI.Repositories.Implements
{
    public class SpCreditCardValidationRepository : Repository<SP_CREDIT_CARD_VALIDATION_Result>, ISpCreditCardValidationRepository
    {
        public SpCreditCardValidationRepository(CreditDBEntities context) : base(context)
        {

        }

        public SP_CREDIT_CARD_VALIDATION_Result ValidateCreditCard(string cardNumber)
        {
            SP_CREDIT_CARD_VALIDATION_Result result = new SP_CREDIT_CARD_VALIDATION_Result();
            decimal input = decimal.Zero;
            if (cardNumber.Length > 16 || !decimal.TryParse(cardNumber, out input))
            {
                result.Result = "Invalid";
                return result;
            }
            else
            {
                return _entities.SP_CREDIT_CARD_VALIDATION(input).FirstOrDefault();
            }

        }
    }
}
