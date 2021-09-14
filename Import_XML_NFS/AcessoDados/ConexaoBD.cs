using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import_XML_NFS.AcessoDados
{
    public class ConexaoBD
    {

        private String _stringConexao;
        private SqlConnection _conexao;

        public ConexaoBD(String dadosConexao)
        {
            _conexao = new SqlConnection();
            StringConexao = dadosConexao;
            _conexao.ConnectionString = dadosConexao;
        }

        public String StringConexao
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }
        }

        public SqlConnection ObjetoConexao
        {
            get { return this._conexao; }
            set { this._conexao = value; }

        }
        public void Conectar()
        {
            this._conexao.Open();
        }

        public void Desconectar()
        {
            this._conexao.Close();
        }
    }
}
