using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Vital_Repository.Dtos
{
    public partial class Pprocedure
    {
        public string Pcode { get; set; }
        public string Pdescription { get; set; }
        public byte? Pdepricated { get; set; }
        public int Id { get; set; }
    }
}
