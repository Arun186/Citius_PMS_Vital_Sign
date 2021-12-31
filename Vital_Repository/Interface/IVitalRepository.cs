using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vital_Repository.Dtos;

namespace Vital_Repository.Interface
{
    public interface IVitalRepository
    {
        Task<IEnumerable<VitalSigns>> GetAll();

        Task<VitalSigns> GetVitalSignById(int id);

        Task<int> AddVitalSigns(VitalSigns vitals);

        Task<bool> RemoveVitalSigns(int id);

        Task<int> UpdateVitalSigns(VitalSigns patient);
    }
}
