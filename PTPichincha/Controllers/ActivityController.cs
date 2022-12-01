using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTPichincha.Bussiness.Bussines;
using PTPichincha.Bussiness.Interfaces;
using PTPichincha.Models.DTO;
using PTPichincha.Models.Response;

namespace PTPichincha.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityBussines activityBussines;
        private readonly IMapper _mapper;

        public ActivityController(IActivityBussines _activityBussines,
            IMapper mapper)
        {
            activityBussines = _activityBussines;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetActivities")]
        public async Task<IEnumerable<ActivityRP>> Get()
        {
            return await activityBussines.GetAll();
        }

        [HttpPost(Name = "AddActivity")]
        public async Task Post(ActivityDto customer)
        {
            await activityBussines.Add(customer);
        }

        [HttpPut(Name = "UpdateActivity/{id}")]
        public async Task Put(ActivityDto customer, int id)
        {
            await activityBussines.Update(customer, id);
        }
        [HttpDelete(Name = "DeleteActivity/{id}")]
        public async Task Delete(int id)
        {
            await activityBussines.Remove(id);
        }
    }
}
