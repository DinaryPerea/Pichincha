using PTPichincha.Infraestructure.Persistance.Repository.IRepository;
using PTPichincha.Models.DTO;
using PTPichincha.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Bussiness.Interfaces
{
    public interface ICustomerBussines
    {
        Task<IEnumerable<CustomerDto>> GetAll();
        Task<CustomerRP> Add(CustomerDto Entity);
        Task<CustomerRP> Update(CustomerDto Entity, int id);

        //Task<IEnumerable<CustomerDto>> FindById(int Id);
        Task  Remove(int Id);
    }
}
