using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vital_Repository.Dtos;

namespace Vital_Repository.Interface
{
    public interface IPatientVisitRepository
    {
        Task<IEnumerable<Diagnosis>> GetAllDiagnosis();
        Task<IEnumerable<Pprocedure>> GetAllPprocedures();
        Task<IEnumerable<Medication>> GetAllMedications();
        Task<IEnumerable<Diagnosis>> GetDiagnosisByDrugCode(string code);
        Task<IEnumerable<Pprocedure>> GetPprocedureByDrugCode(string code);
        Task<IEnumerable<Medication>> GetMedicationById(int id);
        Task<PatientVisit> GetByPatientId(int patientId);
        Task<int> AddPatientTreatmentDetails(PatientVisit treatmentDetails);
        Task<int> UpdatePatientTreatmentDetails(PatientVisit treatmentDetails);
    }
}
