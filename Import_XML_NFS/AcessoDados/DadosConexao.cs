using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import_XML_NFS.AcessoDados
{
   public  class DadosConexao
    {

        public static String servidor = Import_XML_NFS.Properties.Settings.Default.ConexaoBD;
        public static String banco = Import_XML_NFS.Properties.Settings.Default.Nome_Base;
        public static String usuario = "sa";
        public static String senha = "832285";
        //public static String StringDeConexao;

        public static String string_Conexao
        {
            get
            {
                return @"Data Source=" + servidor + ";Initial Catalog=" + banco + ";User ID=" + usuario + ";Password=" + senha;
            }
        }
    }
}
