using Persistence.Interfaces;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyResumeContext _context;


      
        public IExperienceRepository Experiences { get;  set; }

        public ISkillRepository Skills { get;  set; }

        public IMyProfileRepository MyProfile { get;  set; }

        public UnitOfWork(MyResumeContext context)
        {
            _context = context;    
            Experiences = new ExperienceRepository(_context);
            Skills = new SkillRepository(_context);
            MyProfile = new MyProfileRepository(_context);
            
        }

        public int commit()
        {
            return _context.SaveChanges();
        }

        //public Task<int> commitAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
