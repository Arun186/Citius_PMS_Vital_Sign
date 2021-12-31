using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vital_BusinessLogic.Interface;
using Vital_Models;
using Vital_Repository.Interface;
using AutoMapper;
using Vital_Repository.Dtos;

namespace Vital_BusinessLogic.Implementation
{
    public class VitalBusiness : IVitalBusiness
    {
        private readonly IVitalRepository _vitalRepository;

        private readonly IMapper _imapper;

        public VitalBusiness(IVitalRepository vitalRepository,IMapper mapper)
        {
            _vitalRepository = vitalRepository;
            _imapper = mapper;
        }

        public async Task<int> AddVitalSigns(VitalSignModel vitals)
        {
            var vitalsign = _imapper.Map<VitalSigns>(vitals);
            int id = await _vitalRepository.AddVitalSigns(vitalsign);
            return id;
        }

        public async Task<IEnumerable<VitalSignModel>> GetAll()
        {
            var vitals = await _vitalRepository.GetAll();
            return _imapper.Map<IEnumerable<VitalSignModel>>(vitals);
        }

        public Task<VitalSignModel> GetVitalSignById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveVitalSigns(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateVitalSigns(VitalSignModel patient)
        {
            throw new NotImplementedException();
        }
    }
}
