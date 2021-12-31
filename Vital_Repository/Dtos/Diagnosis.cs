using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Vital_Repository.Dtos
{
    public partial class Diagnosis
    {
        public string Dcode { get; set; }
        public string Ddescription { get; set; }
        public byte? Ddepricated { get; set; }
        public int Id { get; set; }
    }
}
