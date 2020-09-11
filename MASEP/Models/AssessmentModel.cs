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
        [Required(ErrorMessage ="Gender is required.")]
        public string Gender { get; set; } = null;
        public string Race { get; set; } = null;
        public string MaritalStat { get; set; } = null;
        public string Income { get; set; } = null;

        [Required(ErrorMessage = "Date of birth is required.")]
        public string DOB { get; set; } = "MM/dd/yyyy";

        public string Age { get; set; } = null;

        public string Education { get; set; } = null;
        public string EmpStat { get; set; } = null;
        public string Q74a { get; set; } = null;
        public string Q74b { get; set; } = null;
        public string Q74c { get; set; } = null;
        public string Q74d { get; set; } = null;
        public string Q74e { get; set; } = null;

        public List<Observation> Observations { get; set; }
    }
    public class Observation
    {
        public int ObsId { get; set; }
        public string ObsText { get; set; }
        public int ResponseId { get; set; }
    }
}
