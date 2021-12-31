using System;
using System.Collections.Generic;
using System.Text;

namespace Vital_Models
{
    public class VisitDetailsModel
    {
        public virtual IEnumerable<DiagnosisModel> DiagnosisModel { get; set; }
        public virtual IEnumerable<PprocedureModel> PprocedureModel { get; set; }
        public virtual IEnumerable<MedicationModel> MedicationModel { get; set; }
    }
}
