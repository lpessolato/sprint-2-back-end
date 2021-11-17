using System;
using System.Collections.Generic;

#nullable disable

namespace Sp_medical_group_webAPI.Domains
{
    public partial class Departamento
    {
        public Departamento()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdDepartamento { get; set; }
        public string NomeDepartamento { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
