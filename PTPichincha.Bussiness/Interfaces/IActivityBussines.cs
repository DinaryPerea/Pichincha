using PTPichincha.Models.DTO;
using PTPichincha.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Bussiness.Interfaces
{
    public interface IActivityBussines
    {
        Task<IEnumerable<ActivityRP>> GetAll();
        Task<ActivityRP> Add(ActivityDto Entity);
        Task<ActivityRP> Update(ActivityDto Entity, int id);

        //Task<IEnumerable<CustomerDto>> FindById(int Id);
        Task Remove(int Id);

    }
}
