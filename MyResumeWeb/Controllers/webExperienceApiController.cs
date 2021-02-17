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
    [Route("api/Experiences")]
    [ApiController]
    public class webExperienceApiController : ControllerBase
    {
        public IExperienceRepository experienceRepository;
        public IUnitOfWork unitofwork { get; set; }

        public webExperienceApiController(IExperienceRepository experienceRepository, IUnitOfWork unitOfWork)
        {
            this.experienceRepository = experienceRepository;
            unitofwork = unitOfWork;

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Experience>> Get()
        {
            var experience = experienceRepository.GetAll();
            return Ok(experience);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Experience experience)
        {

            experienceRepository.Create(experience);
            unitofwork.commit();
            return Ok(experience);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var experience = experienceRepository.GetById(id);
            if (experience == null)
            {
                return NotFound();
            }
            experienceRepository.Delete(experience);
            unitofwork.commit();

            return NoContent();
        }
    }
}
