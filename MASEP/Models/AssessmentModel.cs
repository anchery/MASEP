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
        public int Gender { get; set; }
        public int Race { get; set; } = -1;
        public int MaritalStat { get; set; } = -1;
        public int Income { get; set; } = -1;
        [Required]
        public DateTime DOB { get; set; } = DateTime.Today;
        public int Age { get; set; }

        public int Education { get; set; } = -1;
        public int EmpStat { get; set; } = -1;
    }
}
