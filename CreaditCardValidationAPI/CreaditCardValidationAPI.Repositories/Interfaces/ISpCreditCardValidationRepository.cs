using CreditCardValidationAPI.Domain.Context;
using CreditCardValidationAPI.Domain.Generics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationAPI.Repositories.Interfaces
{
    public interface ISpCreditCardValidationRepository : IRepository<SP_CREDIT_CARD_VALIDATION_Result>
    {
        SP_CREDIT_CARD_VALIDATION_Result ValidateCreditCard(string cardNumber);
    }
}
