using System;
using System.Collections.Generic;
using System.Text;

namespace Vital_Models
{
    public class PatientVisitModel
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public string Dcode { get; set; }
        public string Pcode { get; set; }
        public int? Medid { get; set; }
    }
}
