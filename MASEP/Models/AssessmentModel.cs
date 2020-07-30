using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASEP.Models
{
    public class AssessmentModel
    {
        public int Gender { get; set; }
        public int Race { get; set; }
        public int MaritalStat { get; set; }
        public int Income { get; set; }
        public DateTime DOB { get; set; }
        public int Education { get; set; }
        public int EmpStat { get; set; }
    }
}
