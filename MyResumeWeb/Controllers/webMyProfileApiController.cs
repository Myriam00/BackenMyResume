using DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyResumeWeb.Controllers
{
    [Route("api/MyProfile")]
    [ApiController]
    public class webMyProfileApiController : ControllerBase
    {
        public IMyProfileRepository myProfileRepository;
        public IUnitOfWork unitofwork { get; set; }
        public webMyProfileApiController(IMyProfileRepository myProfileRepository, IUnitOfWork unitOfWork)
        {
            this.myProfileRepository = myProfileRepository;
            unitofwork = unitOfWork;

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<MyProfile>> Get()
        {
            var experience = myProfileRepository.GetAll();
            return Ok(experience);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var myProfile = myProfileRepository.GetById(id);
            if (myProfile == null)
            {
                return NotFound();
            }
            myProfileRepository.Delete(myProfile);
            unitofwork.commit();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MyProfile myProfile)
        {
            var profile = myProfileRepository.GetById(id);

            myProfileRepository.Update(profile);
            unitofwork.commit();

            return Ok(myProfile);
        }
    }
}
