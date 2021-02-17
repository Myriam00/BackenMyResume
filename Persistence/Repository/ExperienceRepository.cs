using DomainModels;
using Repository.Interfaces;
using Repository.Repository;
using System;

namespace Repository
{
    public class ExperienceRepository : Repository<Experience>, IExperienceRepository
    {

        public ExperienceRepository(MyResumeContext context) : base(context)
        {
        }
        
    }
}
