using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTPichincha.Bussiness.Bussines;
using PTPichincha.Bussiness.Interfaces;
using PTPichincha.Models.DTO;

namespace PTPichincha.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBussines accountBussines;
        private readonly IMapper _mapper;

        public AccountController(IAccountBussines _accountBussines,
            IMapper mapper)
        {
            accountBussines = _accountBussines;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAccounts")]
        public async Task<IEnumerable<AccountDto>> Get()
        {
            return await accountBussines.GetAll();
        }

        [HttpPost(Name = "AddAccount")]
        public async Task Post(AccountDto customer)
        {
            await accountBussines.Add(customer);
        }

        [HttpPut(Name = "UpdateAccount/{id}")]
        public async Task Put(AccountDto customer, int id)
        {
            await accountBussines.Update(customer, id);
        }
        [HttpDelete(Name = "DeleteAccount/{id}")]
        public async Task Delete(int id)
        {
            await accountBussines.Remove(id);
        }
    }
}
