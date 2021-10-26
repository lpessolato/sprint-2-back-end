using senai_Filmes2_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Filmes2_webAPI.Interfaces
{
    interface IGeneroRepository
    {
        List<GeneroDomain> ListarTodos();

        void Cadastrar(GeneroDomain novoGenero);

        GeneroDomain BuscarPorId(int idGenero);

        void AtualizarIdCorpo(GeneroDomain generoAtualizado);

        void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado);

        void Deletar(int idGenero);


    }
}
