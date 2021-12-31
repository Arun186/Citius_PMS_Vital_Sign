using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vital_Repository.Dtos;
using Vital_Repository.Interface;
using System.Linq;

namespace Vital_Repository.Implementation
{
    public class PatientVisitRepository: IPatientVisitRepository
    {
        private readonly UnitOfWork.UnitOfWork _unitOfWork;


        public PatientVisitRepository()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork();
        }
        public async Task<int> AddPatientTreatmentDetails(PatientVisit treatmentDetails)
        {
            try
            {
                _unitOfWork.PatientVisitRepository.Insert(treatmentDetails);
                return await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<IEnumerable<Diagnosis>> GetAllDiagnosis()
        {
            try
            {
                return await _unitOfWork.DiagnosisRepository.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Pprocedure>> GetAllPprocedures()
        {
            try
            {
                return await _unitOfWork.PprocudureRepository.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Medication>> GetAllMedications()
        {
            try
            {
                return await _unitOfWork.MedicationRepository.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Diagnosis>> GetDiagnosisByDrugCode(string code)
        {
            try
            {
                var listDiagnosis = await _unitOfWork.DiagnosisRepository.GetAll();
                return listDiagnosis.Where(x => x.Dcode == code).ToList(); ;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Pprocedure>> GetPprocedureByDrugCode(string code)
        {
            try
            {
                var listPprocedure = await _unitOfWork.PprocudureRepository.GetAll();
                return listPprocedure.Where(x => x.Pcode == code).ToList(); ;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Medication>> GetMedicationById(int id)
        {
            try
            {
                var listMedications = await _unitOfWork.MedicationRepository.GetAll();
                return listMedications.Where(x => x.Id == id).ToList(); ;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PatientVisit> GetByPatientId(int patientId)
        {
            try
            {
                var listPatientVisit = await _unitOfWork.PatientVisitRepository.GetAll();
                return listPatientVisit.Where(x => x.Pid == patientId).FirstOrDefault(); 
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> UpdatePatientTreatmentDetails(PatientVisit treatmentDetails)
        {
            try
            {
                _unitOfWork.PatientVisitRepository.Update(treatmentDetails);
                return await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
