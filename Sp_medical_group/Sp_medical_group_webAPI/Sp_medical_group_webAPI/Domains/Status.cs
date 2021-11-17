using System;
using System.Collections.Generic;

#nullable disable

namespace Sp_medical_group_webAPI.Domains
{
    public partial class Status
    {
        public Status()
        {
            Atendimentos = new HashSet<Atendimento>();
        }

        public byte IdStatus { get; set; }
        public string Status1 { get; set; }

        public virtual ICollection<Atendimento> Atendimentos { get; set; }
    }
}
