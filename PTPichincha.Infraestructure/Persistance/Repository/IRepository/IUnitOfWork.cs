using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Infraestructure.Persistance.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IAccountRepository AccountRepository { get; }
        IActivityRepository ActivityRepository { get; }
    }
}
