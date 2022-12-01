using AutoMapper;
using PTPichincha.Bussiness.Interfaces;
using PTPichincha.Domain.Entity;
using PTPichincha.Infraestructure.Persistance.Repository;
using PTPichincha.Infraestructure.Persistance.Repository.IRepository;
using PTPichincha.Models.DTO;
using PTPichincha.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Bussiness.Bussines
{
    public class AccountBussines : IAccountBussines
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public AccountBussines(IUnitOfWork _UnitOfWork, IMapper mapper)
        {
            unitOfWork = _UnitOfWork;
            _mapper = mapper;
        }
        public async Task<AccountRP> Add(AccountDto Entity)
        {
            AccountRP accountRP = new AccountRP();
            try
            {
                var customer = await FindById(Entity.Idusuario);
                var cuenta = new Account
                {
                    AccountNumber = Entity.AccountNumber,
                    Type = Entity.Type,
                    IdPerson = Entity.Idusuario,
                    InitialBalance = Entity.InitialBalance,
                    Status = Entity.Status
                };
                var response = await unitOfWork.AccountRepository.Add(cuenta);
                await unitOfWork.AccountRepository.SaveChanger();
                accountRP.data = _mapper.Map<AccountDto>(response);
                accountRP.Status = true;
                return accountRP;
            }
            catch (Exception ex)
            {
                accountRP.Status = false;
                accountRP.Error = "Error al crear la cuenta " + ex.Message;
                return accountRP;
            }
            
        }

        public async Task<IEnumerable<AccountDto>> GetAll()
        {

            try
            {
                var listcustomers = await unitOfWork.AccountRepository.GetAll();
                return _mapper.Map<IEnumerable<AccountDto>>(listcustomers);
            }
            catch (Exception ex)
            {
                List<AccountDto> listcustomers = new List<AccountDto>();
                AccountDto Entity = new AccountDto();
                //Entity.resp.messageError = ex.Message;
                //Entity.resp.status = false;
                listcustomers.Add(Entity);
                return listcustomers.AsEnumerable();
            }
        }

        public async Task Remove(int Id)
        {
            var Entity = await FindById(Id);
            var CustomEntity = new Account
            {
                AccountNumber = Entity.AccountNumber,
                Type = Entity.Type,
                IdPerson = Entity.Idusuario,
                InitialBalance = Entity.InitialBalance,
                Status = Entity.Status
            };
            await unitOfWork.AccountRepository.Remove(CustomEntity);
        }

        public async Task<List<ReportDto>> Reports(int idCustomer, DateTime start, DateTime end)
        {
            return await unitOfWork.AccountRepository.GetReports(idCustomer, start, end); ;
        }

        public async Task<AccountRP> Update(AccountDto Entity, int id)
        {
            AccountRP accountRP = new AccountRP();

            try
            {
                var findent = await FindById(id);
                var CustomEntity = new Account
                {
                    Id = id,
                    AccountNumber = Entity.AccountNumber,
                    Type = Entity.Type,
                    IdPerson = Entity.Idusuario,
                    InitialBalance = Entity.InitialBalance,
                    Status = Entity.Status
                };
                //var CustomEntity = _mapper.Map<Customer>(Entity);
                var response = await unitOfWork.AccountRepository.Update(CustomEntity);
                await unitOfWork.AccountRepository.SaveChanger();
                accountRP.data = _mapper.Map<AccountDto>(response);
                accountRP.Status = true;
                return accountRP;
            }
            catch (Exception ex)
            {
                accountRP.Error = "Error al actualizar la cuenta " + ex.Message;
                accountRP.Status = false;
                return accountRP;
            }
        }

        private async Task<AccountDto> FindById(int Id)
        {
            var customer = await unitOfWork.AccountRepository.FindById(x => x.Id == Id);
            return _mapper.Map<AccountDto>(customer);

        }
    }
}
