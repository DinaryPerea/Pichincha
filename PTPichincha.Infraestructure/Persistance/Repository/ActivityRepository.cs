using Microsoft.EntityFrameworkCore;
using PTPichincha.Domain.Entity;
using PTPichincha.Infraestructure.Persistance.Data;
using PTPichincha.Infraestructure.Persistance.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Infraestructure.Persistance.Repository
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public ActivityRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
