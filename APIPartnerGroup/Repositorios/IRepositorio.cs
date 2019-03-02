using APIPartnerGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPartnerGroup.Repositorios
{
    public interface IRepositorio<TTipo>
    {
        void Inserir(TTipo tipo);
        void Alterar(int id,TTipo tipo);
        void Excluir(int id);
        List<TTipo> SelecionarTodos();
        TTipo Selecionar(int id);
        List<TTipo> SelecionarPatrimoniosMarca(TTipo tipo);
    }
}
