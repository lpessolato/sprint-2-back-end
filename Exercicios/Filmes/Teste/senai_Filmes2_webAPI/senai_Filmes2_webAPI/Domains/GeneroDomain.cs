using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Filmes2_webAPI.Domains
{
    public class GeneroDomain
    {
        public int idGenero { get; set; }

        [Required(ErrorMessage = "O nome do genero é obrigatorio!")]
        public string nomeGenero { get; set; }

    }
}
