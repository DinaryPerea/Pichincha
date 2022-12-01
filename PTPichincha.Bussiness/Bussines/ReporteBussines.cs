using AutoMapper;
using PTPichincha.Bussiness.Interfaces;
using PTPichincha.Infraestructure.Persistance.Repository;
using PTPichincha.Infraestructure.Persistance.Repository.IRepository;
using PTPichincha.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Bussiness.Bussines
{
    public class ReporteBussines : IReporteBussines
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public ReporteBussines(IUnitOfWork _UnitOfWork, IMapper mapper)
        {
            unitOfWork = _UnitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReportDto>> GetReporte(int idCustomer, DateTime start, DateTime end)
        {
                return await unitOfWork.AccountRepository.GetReports(idCustomer, start, end); ;
            
        }
    }
}
