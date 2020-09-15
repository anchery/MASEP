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
        
        [Required(ErrorMessage = "Race is required.")]
        public string Race { get; set; } = null;
        
        [Required(ErrorMessage = "Marital Status is required.")]
        public string MaritalStat { get; set; } = null;
        
        [Required(ErrorMessage = "Household Income is required.")]
        public string Income { get; set; } = null;

        [Required(ErrorMessage = "Date of birth is required.")]
        public string DOB { get; set; } = "MM/dd/yyyy";

        [Required(ErrorMessage = "Age is required.")]
        public string Age { get; set; } = null;

        [Required(ErrorMessage = "Education is required.")]
        public string Education { get; set; } = null;
        
        [Required(ErrorMessage = "Employment Status is required.")]
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
