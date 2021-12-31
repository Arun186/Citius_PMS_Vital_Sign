using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vital_Models;

namespace Vital_BusinessLogic.Interface
{
    public interface IPatientVisitBusiness
    {
        Task<VisitDetailsModel> GetAll();
        Task<VisitDetailsModel> GetByPatientId(int patientId);
        Task<bool> AddPatientTreatmentDetails(PatientVisitModel treatmentDetails);
        Task<bool> UpdatePatientTreatmentDetails(PatientVisitModel treatmentDetails);
    }
}
