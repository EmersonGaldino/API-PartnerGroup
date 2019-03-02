using APIPartnerGroup.AcessoDados;
using APIPartnerGroup.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIPartnerGroup.Repositorios
{
    public class RepositorioMarca : IRepositorio<Marca>
    {
        public void Alterar(int id,Marca tipo)
        {
            DbConnection conexao = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(conexao);
            cmd.CommandText = @"UPDATE MAR_MARCA SET NOME = @NOME WHERE MARCAID = @MARCAID;";
            cmd.Parameters.Add(new SqlParameter("@NOME", tipo.Nome));
            cmd.Parameters.Add(new SqlParameter("@MARCAID", id));
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            DbConnection conexao = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(conexao);
            cmd.CommandText = @"DELETE FROM MAR_MARCA WHERE MARCAID = @MARCAID;";
            cmd.Parameters.Add(new SqlParameter("@MARCAID", id));
            cmd.ExecuteNonQuery();
        }
        //METODO STATICO PARA INSERIR UMA MARCA
        public void Inserir(Marca tipo)
        {
            DbConnection conexao = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(conexao);
            cmd.CommandText = @"INSERT INTO MAR_MARCA (NOME) VALUES (@NOME);";
            cmd.Parameters.Add(new SqlParameter("@NOME", tipo.Nome));
            cmd.ExecuteNonQuery();
        }

        public List<Marca> SelecionarTodos()
        {
            List<Marca> marcas = new List<Marca>();
            DbConnection cn = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(cn);
            cmd.CommandText = "SELECT * FROM MAR_MARCA";
            DbDataReader leitor = AcessoDadosADONet.GetReader(cmd);
            
            

            while (leitor.Read())
            {
                marcas.Add(new Marca()
                {
                    MarcaId = Convert.ToInt32(leitor["MARCAID"]),
                    Nome = leitor["NOME"].ToString()
                });
            }
            leitor.Close();
            return marcas;
        }

        public Marca Selecionar(int id)
        {
            DbConnection cn = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(cn);
            cmd.CommandText = "SELECT * FROM MAR_MARCA WHERE MARCAID = @MARCAID";
            cmd.Parameters.Add(new SqlParameter("@MARCAID", id));
            DbDataReader leitor = AcessoDadosADONet.GetReader(cmd);
            Marca marcas = new Marca();
            if (leitor.Read())
            {

                marcas.MarcaId = Convert.ToInt32(leitor["MARCAID"]);
                marcas.Nome = leitor["NOME"].ToString();
                
            }
            id = marcas.MarcaId;
            leitor.Close();
            return marcas;
        }

        public List<Marca> SelecionarPatrimoniosMarca(Marca marca)
        {
            List<Marca> marcas = new List<Marca>();
            DbConnection cn = AcessoDadosADONet.GetConexao();
            DbCommand cmd = AcessoDadosADONet.GetComando(cn);
            cmd.CommandText = @"SELECT P.NOME, P.DESCRICAO, P.NUMEROTOMBO, M.NOME 
                                FROM PAT_PATRIMONIO P
                                INNER JOIN MAR_MARCA M ON P.MARCAID = M.MARCAID
                                WHERE M.MARCAID = @MARCAID";
            cmd.Parameters.Add(new SqlParameter("@MARCAID", marca.MarcaId));
            DbDataReader leitor = AcessoDadosADONet.GetReader(cmd);



            while (leitor.Read())
            {
                marcas.Add(new Marca()
                {
                    MarcaId = Convert.ToInt32(leitor["MARCAID"]),
                    Nome = leitor["NOME"].ToString()
                    
                });
            }
            leitor.Close();
            return marcas;
        }
    }
}