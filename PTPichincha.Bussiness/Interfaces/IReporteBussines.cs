using PTPichincha.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Bussiness.Interfaces
{
    public  interface IReporteBussines
    {
        Task<IEnumerable<ReportDto>> GetReporte(int idCustomer, DateTime start, DateTime end);
    }
}
