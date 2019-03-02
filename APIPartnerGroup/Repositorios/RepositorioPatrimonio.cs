using APIPartnerGroup.AcessoDados;
using APIPartnerGroup.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace APIPartnerGroup.Repositorios
{
    public class RepositorioPatrimonio : IRepositorio<Patrimonio>
    {
        public void Alterar(int id,Patrimonio tipo)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Patrimonio tipo)
        {
            throw new NotImplementedException();
        }

        public List<Patrimonio> SelecionarTodos()
        {
            List<Patrimonio> patrimonios = new List<Patrimonio>();
            DbConnection cn = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(cn);
            cmd.CommandText = "SELECT * FROM MAR_MARCA";
            DbDataReader leitor = AcessoDadosADONet.GetReader(cmd);



            while (leitor.Read())
            {
                patrimonios.Add(new Patrimonio()
                {
                    Nome = leitor["NOME"].ToString()
                });
            }
            leitor.Close();
            return patrimonios;
        }

        public Patrimonio Selecionar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Patrimonio> SelecionarPatrimoniosMarca(Patrimonio patrimonio)
        {
            throw new NotImplementedException();
        }
    }
}