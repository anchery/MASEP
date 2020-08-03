using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MASEP.Models
{
    public class AssessmentModel
    {
        [Required]
        public int Gender { get; set; } = -1;
        public int Race { get; set; } = -1;
        public int MaritalStat { get; set; } = -1;
        public int Income { get; set; } = -1;
        
        [Required(ErrorMessage ="Date of birth is required.")]
        public DateTime DOB { get; set; }

        public int Age { get; set; } = -1;

        public int Education { get; set; } = -1;
        public int EmpStat { get; set; } = -1;

        public List<Observation> Observations { get; set; }
    }
    public class Observation
    {
        public int ObsId { get; set; }
        public string ObsText { get; set; }
        public int ResponseId { get; set; }
    }
}
