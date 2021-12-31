using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vital_BusinessLogic.Interface;
using Vital_Models;
using Vital_Repository.Dtos;
using Vital_Repository.Interface;

namespace Vital_BusinessLogic.Implementation
{
    public class PatientVisitBusiness: IPatientVisitBusiness
    {
        private readonly IPatientVisitRepository _patientVisitRepository;

        private readonly IMapper _imapper;

        public PatientVisitBusiness(IPatientVisitRepository patientVisitRepository, IMapper mapper)
        {
                _patientVisitRepository = patientVisitRepository;
                _imapper = mapper;
        }
        public async Task<bool> AddPatientTreatmentDetails(PatientVisitModel treatmentDetails)
        {
            try
            {
                var patientVisit = _imapper.Map<PatientVisit>(treatmentDetails);
                return (await _patientVisitRepository.AddPatientTreatmentDetails(patientVisit) > 0);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<VisitDetailsModel> GetAll()
        {
            try
            {
                VisitDetailsModel visitDetailsModels = new VisitDetailsModel();
                var diagnosis = await _patientVisitRepository.GetAllDiagnosis();
                var pprocedures = await _patientVisitRepository.GetAllPprocedures();
                var medications = await _patientVisitRepository.GetAllMedications();
                visitDetailsModels.DiagnosisModel = _imapper.Map<IEnumerable<DiagnosisModel>>(diagnosis);
                visitDetailsModels.PprocedureModel = _imapper.Map<IEnumerable<PprocedureModel>>(pprocedures);
                visitDetailsModels.MedicationModel = _imapper.Map<IEnumerable<MedicationModel>>(medications);
                return visitDetailsModels;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<VisitDetailsModel> GetByPatientId(int patientId)
        {
            try
            {
                VisitDetailsModel visitDetailsModels = new VisitDetailsModel();
                var patientvisit = await _patientVisitRepository.GetByPatientId(patientId);
                var diagnosis = await _patientVisitRepository.GetDiagnosisByDrugCode(patientvisit.Dcode);
                var pprocedures = await _patientVisitRepository.GetPprocedureByDrugCode(patientvisit.Pcode);
                var medications = await _patientVisitRepository.GetMedicationById(Convert.ToInt32(patientvisit.Medid));
                visitDetailsModels.DiagnosisModel = _imapper.Map<IEnumerable<DiagnosisModel>>(diagnosis);
                visitDetailsModels.PprocedureModel = _imapper.Map<IEnumerable<PprocedureModel>>(pprocedures);
                visitDetailsModels.MedicationModel = _imapper.Map<IEnumerable<MedicationModel>>(medications);
                return visitDetailsModels;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> UpdatePatientTreatmentDetails(PatientVisitModel treatmentDetails)
        {
            try
            {
                var patientVisit = _imapper.Map<PatientVisit>(treatmentDetails);
                return (await _patientVisitRepository.UpdatePatientTreatmentDetails(patientVisit) > 0);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
