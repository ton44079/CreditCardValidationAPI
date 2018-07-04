using CreditCardValidationAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationAPI.Services.Interfaces
{
    public interface ICreditCardService
    {
        ValidateResultModel Validatie(string input);
    }
}
