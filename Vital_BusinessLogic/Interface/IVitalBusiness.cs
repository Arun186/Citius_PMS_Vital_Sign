using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vital_Models;

namespace Vital_BusinessLogic.Interface
{
    public interface IVitalBusiness
    {
        Task<IEnumerable<VitalSignModel>> GetAll();

        Task<VitalSignModel> GetVitalSignById(int id);

        Task<int> AddVitalSigns(VitalSignModel vitals);

        Task<bool> RemoveVitalSigns(int id);

        Task<int> UpdateVitalSigns(VitalSignModel patient);
    }
}
