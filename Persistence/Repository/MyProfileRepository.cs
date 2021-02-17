using DomainModels;
using Repository.Interfaces;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public class MyProfileRepository : Repository<MyProfile>, IMyProfileRepository
    {
        public MyProfileRepository(MyResumeContext context) : base(context)
        {
        }
    }
}
