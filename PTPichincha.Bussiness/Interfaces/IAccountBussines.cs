using PTPichincha.Models.DTO;
using PTPichincha.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Bussiness.Interfaces
{
    public interface  IAccountBussines
    {
        Task<IEnumerable<AccountDto>> GetAll();
        Task<AccountRP> Add(AccountDto Entity);
        Task<AccountRP> Update(AccountDto Entity, int id);

        //Task<IEnumerable<CustomerDto>> FindById(int Id);
        Task Remove(int Id);
        Task<List<ReportDto>> Reports(int idCustomer, DateTime start, DateTime end);

    }
}
