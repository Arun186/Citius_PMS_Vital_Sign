using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Vital_Repository.Dtos
{
    public partial class PatientVisit
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public string Dcode { get; set; }
        public string Pcode { get; set; }
        public int? Medid { get; set; }

        public virtual Medication Med { get; set; }
    }
}
