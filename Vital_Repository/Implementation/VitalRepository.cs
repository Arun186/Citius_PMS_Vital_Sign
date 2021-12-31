using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Vital_Repository.Dtos;
using Vital_Repository.Interface;
using Vital_Repository.UnitOfWork;

namespace Vital_Repository.Implementation
{
    public class VitalRepository : IVitalRepository
    {
        private readonly UnitOfWork.UnitOfWork _unitOfWork;

        public VitalRepository()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork();
        }
        public async Task<int> AddVitalSigns(VitalSigns vitals)
        {
            _unitOfWork.VitalRepository.Insert(vitals);
            return await _unitOfWork.Save();
        }

        public async Task<IEnumerable<VitalSigns>> GetAll()
        {
            IEnumerable<VitalSigns> vitalSigns = await _unitOfWork.VitalRepository.GetAll();
            return vitalSigns;
        }

        public async Task<VitalSigns> GetVitalSignById(int id)
        {
            var vital = await _unitOfWork.VitalRepository.GetByID(id);
            if (vital != null)
            {
                return vital;
            }
            return null;
        }

        public async Task<bool> RemoveVitalSigns(int id)
        {
            bool result = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var patient = await _unitOfWork.VitalRepository.GetByID(id);
                    if (patient != null)
                    {
                        _unitOfWork.PatientRepository.Delete(patient);
                        await _unitOfWork.Save();
                        scope.Complete();
                        result = true;

                    }
                }
            }
            return result;
        }

        public Task<int> UpdateVitalSigns(VitalSigns patient)
        {
            throw new NotImplementedException();
        }
    }
}
