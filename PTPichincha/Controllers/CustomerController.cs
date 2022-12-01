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
    public class CustomerController :  ControllerBase
    {
        private readonly ICustomerBussines customerBussines;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerBussines _customerBussines,
            IMapper mapper)
        {
            customerBussines = _customerBussines;
            _mapper = mapper;
        }
        // GET: Customer
        [HttpGet(Name = "GetCustomers")]
        public async Task<IEnumerable<CustomerDto>> Get()
        {
            return await customerBussines.GetAll();
        }

        [HttpPost(Name = "AddCustomers")]
        public async Task Post(CustomerDto customer)
        {
            await customerBussines.Add(customer);
        }

        [HttpPut(Name = "UpdateCustomers/{id}")]
        public async Task Put(CustomerDto customer,int id)
        {
            await customerBussines.Update(customer, id);
        }

        [HttpDelete(Name = "DeleteCustomers/{id}")]
        public async Task Delete(int id)
        {
            await customerBussines.Remove(id);
        }
    }
}
