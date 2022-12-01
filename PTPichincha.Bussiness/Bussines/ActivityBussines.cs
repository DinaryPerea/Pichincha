using AutoMapper;
using Microsoft.Identity.Client;
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
    public class ActivityBussines : IActivityBussines
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public ActivityBussines(IUnitOfWork _UnitOfWork, IMapper mapper)
        {
            unitOfWork = _UnitOfWork;
            _mapper = mapper;
        }
        public async Task<ActivityRP> Add(ActivityDto Entity)
        {
            ActivityRP resp = new ActivityRP();
            try
            {
                var cuenta = new Activity
                {
                   Balance = Entity.Balance,
                   DateActivity = Entity.DateActivity,
                   Id = Entity.Id,
                   IdAccount = Entity.Id,
                   Type = Entity.Type,
                   Value = Entity.Value
                };
                var response = await unitOfWork.ActivityRepository.Add(cuenta);
                await unitOfWork.ActivityRepository.SaveChanger();
                var activityCreated = new ActivityDto
                {

                    Balance = response.Balance,
                    DateActivity = response.DateActivity,
                    Id = response.Id,
                    IdAccount = response.IdAccount,
                    Type = response.Type,
                    Value = response.Value
                };
                resp.data = activityCreated;
                resp.Status = true;
                return resp;
            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Error = "Error al crear el movimiento" + ex.Message;
                return resp;
            }
        }

        public async Task<IEnumerable<ActivityRP>> GetAll()
        {
            try
            {
                var listcustomers = await unitOfWork.ActivityRepository.GetAll();
                return _mapper.Map<IEnumerable<ActivityRP>>(listcustomers);
            }
            catch (Exception ex)
            {
                List<ActivityRP> listcustomers = new List<ActivityRP>();
                ActivityRP Entity = new ActivityRP();
                Entity.Error = "Error al obtener los movimientos "+ ex.Message;
                Entity.Status = false;
                listcustomers.Add(Entity);
                return listcustomers.AsEnumerable();
            }
        }

        public async Task Remove(int Id)
        {
            var entity = await FindById(Id);
            var activity = new Activity
            {
                Balance = entity.Balance,
                DateActivity = entity.DateActivity,
                Id = entity.Id,
                IdAccount = entity.Id,
                Type = entity.Type,
                Value = entity.Value
            };
            await unitOfWork.ActivityRepository.Remove(activity);
            await unitOfWork.ActivityRepository.SaveChanger();

        }

        public async Task<ActivityRP> Update(ActivityDto Entity, int id)
        {
            ActivityRP resp = new ActivityRP();

            try
            {
                var entity = await FindById(id);
                var activity = new Activity
                {
                    
                    Balance = entity.Balance,
                    DateActivity = entity.DateActivity,
                    Id = entity.Id,
                    IdAccount = entity.Id,
                    Type = entity.Type,
                    Value = entity.Value
                };
                var response = await unitOfWork.ActivityRepository.Update(activity);
                await unitOfWork.ActivityRepository.SaveChanger();
                var activityUpdated = new ActivityDto
                {

                    Balance = response.Balance,
                    DateActivity = response.DateActivity,
                    Id = response.Id,
                    IdAccount = response.IdAccount,
                    Type = response.Type,
                    Value = response.Value
                };
                resp.data = activityUpdated;
                resp.Status = true;
                return resp;
            }
            catch (Exception ex)
            {
                resp.Error = "Error al actualizar el movimiento " + ex.Message;
                resp.Status = false;
                return resp;
            }
        }

        private async Task<ActivityDto> FindById(int Id)
        {
            var customer = await unitOfWork.ActivityRepository.FindById(x => x.Id == Id);
            return _mapper.Map<ActivityDto>(customer);

        }

       
    }
}
