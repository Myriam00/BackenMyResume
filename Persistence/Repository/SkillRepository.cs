using DomainModels;
using Repository.Interfaces;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(MyResumeContext context) : base(context)
        {
        }
    }
}
