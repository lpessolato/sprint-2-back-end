using senai_Filmes2_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Filmes2_webAPI.Interfaces
{
    interface IFilmeRepository
    {
        List<FilmeDomain> ListarFilmes();

        void Cadastrar(FilmeDomain novoFilme);



    }
}
