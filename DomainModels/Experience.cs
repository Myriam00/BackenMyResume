using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
    public enum ExperienceType { Academic, Professional };

    public class Experience
    {
        public int ExperienceID { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ExperienceType ExperienceType { get; set; }

    }
}
