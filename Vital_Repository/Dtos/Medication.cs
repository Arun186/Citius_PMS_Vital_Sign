using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Vital_Repository.Dtos
{
    public partial class Medication
    {
        public Medication()
        {
            PatientVisit = new HashSet<PatientVisit>();
        }

        public int Id { get; set; }
        public string ApplNo { get; set; }
        public string ProductNo { get; set; }
        public string ProductForm { get; set; }
        public string DrugName { get; set; }
        public string DrugStrength { get; set; }
        public string ActiveIngredient { get; set; }
        public string ReferenceDrug { get; set; }
        public string ReferenceStandard { get; set; }

        public virtual ICollection<PatientVisit> PatientVisit { get; set; }
    }
}
