using APIPartnerGroup.AcessoDados;
using APIPartnerGroup.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIPartnerGroup.Repositorios
{
    public class RepositorioPatrimonio : IRepositorio<Patrimonio>
    {
        public void Alterar(int id,Patrimonio tipo)
        {
            DbConnection conexao = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(conexao);
            cmd.CommandText = @"UPDATE PAT_PATRIMONIO SET NOME = @NOME,
                                MARCAID = @MARCAID, DESCRICAO = @DESCRICAO WHERE NUMEROTOMBO = @ID;";
            cmd.Parameters.Add(new SqlParameter("@NOME", tipo.Nome));
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.Parameters.Add(new SqlParameter("@DESCRICAO", tipo.Descricao));
            cmd.Parameters.Add(new SqlParameter("@MARCAID", tipo.MarcaId));
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            DbConnection cn = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(cn);
            cmd.CommandText = "DELETE FROM PAT_PATRIMONIO WHERE NUMEROTOMBO = @ID";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.ExecuteNonQuery();
        }

        public void Inserir(Patrimonio tipo)
        {
            DbConnection cn = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(cn);
            cmd.CommandText = @"INSERT INTO PAT_PATRIMONIO (NOME, MARCAID, DESCRICAO)
                                VALUES (@NOME, @MARCAID, @DESCRICAO);";
            cmd.Parameters.Add(new SqlParameter("@NOME", tipo.Nome));
            cmd.Parameters.Add(new SqlParameter("@MARCAID", tipo.MarcaId));
            cmd.Parameters.Add(new SqlParameter("@DESCRICAO", tipo.Descricao));

            cmd.ExecuteNonQuery();
        }

        public List<Patrimonio> SelecionarTodos()
        {
            List<Patrimonio> patrimonios = new List<Patrimonio>();
            DbConnection cn = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(cn);
            cmd.CommandText = "SELECT * FROM PAT_PATRIMONIO";
            DbDataReader leitor = AcessoDadosADONet.GetReader(cmd);



            while (leitor.Read())
            {
                patrimonios.Add(new Patrimonio()
                {
                    Nome = leitor["NOME"].ToString(),
                    Descricao = leitor["DESCRICAO"].ToString(),
                    MarcaId = Convert.ToInt32(leitor["MARCAID"]),
                    NumeroTombo = Convert.ToInt32(leitor["NUMEROTOMBO"])
                    
                });
            }
            leitor.Close();
            return patrimonios;
        }

        public Patrimonio Selecionar(int id)
        {
            DbConnection cn = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(cn);
            cmd.CommandText = "SELECT * FROM PAT_PATRIMONIO WHERE NUMEROTOMBO = @ID";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            DbDataReader reader = AcessoDadosADONet.GetReader(cmd);
            Patrimonio patrimonio = new Patrimonio();
            if (reader.Read())
            {
                patrimonio.Nome = reader["NOME"].ToString();
                patrimonio.MarcaId = Convert.ToInt32(reader["MARCAID"]);
                patrimonio.Descricao = reader["DESCRICAO"].ToString();
                patrimonio.NumeroTombo = Convert.ToInt32(reader["NUMEROTOMBO"]);

            }
            id = patrimonio.NumeroTombo;
            reader.Close();
            return patrimonio;
        }

        public List<Patrimonio> SelecionarPatrimoniosMarca(Patrimonio patrimonio)
        {
            throw new NotImplementedException();
        }
    }
}