using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Vital_Repository.Dtos;
using Vital_Models;

namespace Vital_BusinessLogic
{
    class AutoMapperProfiler:Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<VitalSignModel, VitalSigns>().ReverseMap();
            CreateMap<DiagnosisModel, Diagnosis>().ReverseMap();
            CreateMap<PprocedureModel, Pprocedure>().ReverseMap();
            CreateMap<MedicationModel, Medication>().ReverseMap();
            CreateMap<PatientVisitModel, PatientVisit>().ReverseMap();
        }
    }
}
