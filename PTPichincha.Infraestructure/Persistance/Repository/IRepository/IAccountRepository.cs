using PTPichincha.Domain.Entity;
using PTPichincha.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Infraestructure.Persistance.Repository.IRepository
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<List<ReportDto>> GetReports(int IdCustomer, DateTime start, DateTime end);

    }
}
