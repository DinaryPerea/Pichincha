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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CustomerRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
