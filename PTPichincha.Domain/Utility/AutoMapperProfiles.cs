using AutoMapper;
using PTPichincha.Domain.Entity;
using PTPichincha.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Domain.Utility
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<AccountDto, Account>();
            CreateMap<Account, AccountDto>();
            CreateMap<Activity, ActivityDto>();
            CreateMap<ActivityDto, Activity>();

        }
    }
}
