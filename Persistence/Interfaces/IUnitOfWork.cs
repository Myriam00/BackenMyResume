using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
   public interface IUnitOfWork : IDisposable
    {
        IExperienceRepository Experiences { get; }
        ISkillRepository Skills { get; }
        IMyProfileRepository MyProfile { get; }
       

        int commit();
        //Task<int> commitAsync();
    }
}
