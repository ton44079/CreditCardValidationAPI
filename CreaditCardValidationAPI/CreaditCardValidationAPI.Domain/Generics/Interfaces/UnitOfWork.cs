using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaditCardValidationAPI.Domain.Generics.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
