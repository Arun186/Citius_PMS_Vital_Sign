using System;
using System.Collections.Generic;
using System.Text;

namespace Vital_Models
{
    public class VitalSignModel
    {
        public int Id { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodPressure { get; set; }
        public string BodyTemperature { get; set; }
        public string RespirationRate { get; set; }
        public int? Patientid { get; set; }
    }
}
