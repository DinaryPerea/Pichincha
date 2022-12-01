using PTPichincha.Domain.Entity;
using PTPichincha.Infraestructure.Persistance.Data;
using PTPichincha.Infraestructure.Persistance.Repository.IRepository;
using PTPichincha.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Infraestructure.Persistance.Repository
{
    public class AccountRepository: Repository<Account>, IAccountRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public AccountRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ReportDto>> GetReports(int IdCustomer, DateTime start, DateTime end)
        {
            List<ReportDto> result = (from c in _dbContext.Customers
                                      join a in _dbContext.Accounts on c.Id equals a.IdPerson
                                      join ac in _dbContext.Activities on c.Id equals ac.IdAccount
                                      where c.Id == IdCustomer
                                      && ac.DateActivity >= start && ac.DateActivity <= end
                                      select new ReportDto
                                      {
                                          AccountNumber = a.AccountNumber,
                                          Activity = ac.Type,
                                          Balance = Convert.ToInt32(ac.Balance),
                                          Customer = c.Name,
                                          Date = ac.DateActivity,
                                          Status =  a.Status,
                                          Type  = a.Type
                                      }).ToList();
            return result;
        }
    }
}
