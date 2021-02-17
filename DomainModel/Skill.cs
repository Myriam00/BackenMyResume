using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    public class Skill
    {
     
        public int SkillID { get; set; }
        public String Name { get; set; }
        public float Rating { get; set; }

    }
}
