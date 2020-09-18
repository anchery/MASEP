using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MASEP.Models
{
    public class AssessmentModel
    {
        public string LithoCode { get; set; }
        public string ParticipantsID { get; set; }
        public DateTime ScanDate { get; set; }

        [Required(ErrorMessage ="Gender is required.")]
        public string Gender { get; set; } = null;
        
        [Required(ErrorMessage = "Race is required.")]
        public string Ethnicity { get; set; } = null;
        
        [Required(ErrorMessage = "Marital Status is required.")]
        public string Marital { get; set; } = null;
        
        [Required(ErrorMessage = "Household Income is required.")]
        public string Income { get; set; } = null;

        [Required(ErrorMessage = "Invalid Date of birth.")]
        //[Range(17,80)]
        public string DateOfBirth { get; set; } = null; //= "MM/dd/yyyy";

        [Required(ErrorMessage = "Age is required.")]
        public string Age { get; set; } = null;

        [Required(ErrorMessage = "Education is required.")]
        public string Education { get; set; } = null;
        
        [Required(ErrorMessage = "Employment Status is required.")]
        public string EmpStatus { get; set; } = null;
        public string DUIMonthsAgo { get; set; } = null;
        public string AgeFirstDrink { get; set; } = null;
        public string AgeFirstArrest { get; set; } = null;
        public string TimesArrestedDUI { get; set; } = null;

        public string Q63 { get; set; } = "99";
        public string Q64 { get; set; } = "99";
        public string Q65 { get; set; } = "99";
        public string Q66 { get; set; } = "99";
        public string Q67 { get; set; } = "99";
        public string Q68 { get; set; } = "99";
        public string Q69 { get; set; } = "99";
        public string Q70 { get; set; } = "99";
        public string Q71 { get; set; } = "99";
        public string Q72 { get; set; } = "99";
        public string Q73 { get; set; } = "99";
        public string Q75 { get; set; } = "99";
        public string Q76 { get; set; } = "99";
        public string Q77 { get; set; } = "99";
        public string Q78 { get; set; } = "99";
        public string Q79 { get; set; } = "99";
        public string Q80 { get; set; } = "99";
        public string Q81 { get; set; } = "99";
        public string Q82 { get; set; } = "99";
        public string Q83 { get; set; } = "99";


        public string Q74a { get; set; } = "0";
        public string Q74b { get; set; } = "0";
        public string Q74c { get; set; } = "0";
        public string Q74d { get; set; } = "0";
        public string Q74e { get; set; } = "0";

        //public List<Observation> Observations { get; set; }
    }
}
