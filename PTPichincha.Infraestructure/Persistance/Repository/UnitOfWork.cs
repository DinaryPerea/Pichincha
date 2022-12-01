using PTPichincha.Domain.Entity;
using PTPichincha.Infraestructure.Persistance.Data;
using PTPichincha.Infraestructure.Persistance.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Infraestructure.Persistance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _db;
        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            CustomerRepository = new CustomerRepository(db);
            AccountRepository = new AccountRepository(db);
            ActivityRepository = new ActivityRepository(db);
        }

        public ICustomerRepository CustomerRepository { get; private set;}

        public IAccountRepository AccountRepository { get; private set; }

        public IActivityRepository ActivityRepository { get; private set; }
    }
}
