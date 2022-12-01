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
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace PTPichincha.Bussiness.Bussines
{
    
    public class CustomerBussines : ICustomerBussines
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public CustomerBussines(IUnitOfWork _UnitOfWork, IMapper mapper)
        {
            unitOfWork = _UnitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomerRP> Add(CustomerDto Entity)
        {
            CustomerRP resp = new CustomerRP();


            try
            {
                var entity = new Customer
                {
                    Id = Entity.Id,
                    Name = Entity.Name,
                    Address = Entity.Address,
                    Age = Entity.Age,  
                    Gender = Entity.Gender,
                    Password = Entity.Password,
                    Phone = Entity.Phone,
                    Status = Entity.Status


                };
                //var CustomEntity = _mapper.Map<Customer>(Entity);
                var response = await unitOfWork.CustomerRepository.Add(entity);
                await unitOfWork.CustomerRepository.SaveChanger();

                resp.data = _mapper.Map<CustomerDto>(response);
                resp.Status = true;
                return resp;
            }
            catch (Exception ex)
            {
                resp.Error = "Error al agregar un cliente" + ex.Message;
                resp.Status = false;
                return resp;
            }
            
        }

        public async Task<CustomerRP> Update(CustomerDto Entity, int id)
        {
            CustomerRP resp = new CustomerRP();
            try
            {
                var customer = await FindById(id);

                var entity = new Customer
                {
                    Id = id,
                    Name = Entity.Name,
                    Address = Entity.Address,
                    Age = Entity.Age,
                    Gender = Entity.Gender,
                    Password = Entity.Password,
                    Phone = Entity.Phone,
                    Status = Entity.Status

                };
                //var CustomEntity = _mapper.Map<Customer>(Entity);
                var response = await unitOfWork.CustomerRepository.Update(entity);
                await unitOfWork.CustomerRepository.SaveChanger();
                resp.data = _mapper.Map<CustomerDto>(response);
                resp.Status = true;
                return resp;
            }
            catch (Exception ex)
            {
                resp.Error = "Error al actualizar el cliente " + ex.Message;
                resp.Status = false;
                return resp;
            }

        }
        private async Task<CustomerDto>FindById(int Id)
        {
            var customer = await unitOfWork.CustomerRepository.FindById(x=> x.Id == Id);
            return _mapper.Map<CustomerDto>(customer);

        }


        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            CustomerRP resp = new CustomerRP();

            try
            {
                var listcustomers = await unitOfWork.CustomerRepository.GetAll();
                return _mapper.Map<IEnumerable<CustomerDto>>(listcustomers);
            }
            catch (Exception ex)
            {
                List<CustomerDto> listcustomers = new List<CustomerDto>();
                CustomerDto Entity = new CustomerDto();
                resp.Error = "Error al actualizar el cliente " + ex.Message;
                resp.Status = false;
                listcustomers.Add(Entity);
                return listcustomers.AsEnumerable(); 
            }
        }

        public async Task Remove(int id)
        {
            try
            {
                var customer = await FindById(id);
                var CustomEntity = _mapper.Map<Customer>(customer);
                await unitOfWork.CustomerRepository.Remove(CustomEntity);
                await unitOfWork.CustomerRepository.SaveChanger();

            }
            catch (Exception ex )
            {

            }
           
        }

    }
}
