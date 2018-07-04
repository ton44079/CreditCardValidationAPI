using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationAPI.Domain.Generics.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
