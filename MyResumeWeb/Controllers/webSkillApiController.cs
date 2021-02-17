using DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Persistence.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyResumeWeb.Controllers
{
    [Route("api/Skills")]
    [ApiController]
    public class webSkillApiController : ControllerBase
    {
        public ISkillRepository skillRepository;
        public IUnitOfWork unitofwork { get; set; }
        public webSkillApiController(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
        {
            this.skillRepository = skillRepository;
            unitofwork = unitOfWork;

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Skill>> Get()
        {
            var skills = skillRepository.GetAll();
            return Ok(skills);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Skill skill)
        {

            skillRepository.Create(skill);
            unitofwork.commit();
            return Ok(skill);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var skill = skillRepository.GetById(id);
            if (skill == null)
            {
                return NotFound();
            }
            skillRepository.Delete(skill);
            unitofwork.commit();

            return NoContent();
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Skill skill)
        //{
        //    var skill = skillRepository.GetById(id);

        //    skillRepository.Update(skill);
        //    unitofwork.commit();

        //    return Ok(skill);
        //}
    }
}
