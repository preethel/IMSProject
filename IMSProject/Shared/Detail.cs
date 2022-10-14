using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSProject.Shared
{
    public abstract class Detail
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty ;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UdatedAt { get; set; } = string.Empty;
        public bool DomainStatus { get; set; } = false;

    }
}
