using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;

namespace APIPartnerGroup.AcessoDados
{
    public static class AcessoDadosADONet
    {
        public static DbConnection GetConexao()
        {
            DbConnection cn = new SqlConnection(@"Server=DESKTOP-4J27LU3\SQLEXPRESS;Database=PARTNERGROUP;Trusted_Connection=True;");
            cn.Open();
            return cn;
        }

        public static DbCommand GetComando(DbConnection cn)
        {
            DbCommand cmd = cn.CreateCommand();
            return cmd;
        }

        public static DbDataReader GetReader(DbCommand cmd)
        {
            return cmd.ExecuteReader();
        }
    }
}