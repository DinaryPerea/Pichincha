using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTPichincha.Bussiness.Bussines;
using PTPichincha.Bussiness.Interfaces;
using PTPichincha.Infraestructure.Persistance.Repository.IRepository;
using PTPichincha.Models.DTO;
using System.Collections.Generic;

namespace PTPichincha.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReporteBussines reportBussines;
        private readonly IMapper _mapper;

        public ReportController(IReporteBussines _reportBussines,
            IMapper mapper)
        {
            reportBussines = _reportBussines;
            _mapper = mapper;
        }
        // GET: Customer
        [HttpGet(Name = "GetReport")]
        public async Task<IEnumerable<ReportDto>> Get(int idCustomer, DateTime start, DateTime end)
        {
            return await reportBussines.GetReporte( idCustomer,  start,  end);
        }

       
    }
}
