using Import_XML_NFS.AcessoDados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FiscalBr.EFDFiscal;

namespace Import_XML_NFS
{
    public partial class frmImportSped : Form
    {
        public frmImportSped()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fi = new FolderBrowserDialog();
            fi.RootFolder = Environment.SpecialFolder.Desktop;
            fi.Description = "Selecione a Pasta dos arquivos";
            fi.ShowNewFolderButton = false;
            if (fi.ShowDialog() == DialogResult.OK)
            {
                txtPastaAcesso.Text = fi.SelectedPath;
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                ConexaoBD conexaoBD = new ConexaoBD(DadosConexao.string_Conexao);
                NotaFiscalSaidaDAO notaFiscalSaidaDAO = new NotaFiscalSaidaDAO(conexaoBD);
                if (String.IsNullOrEmpty(txtPastaAcesso.Text))
                {

                    MessageBox.Show("Selecione uma pasta para ler os arquivos.", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DirectoryInfo diretorioRaiz = new DirectoryInfo(txtPastaAcesso.Text);
                FileInfo[] arquivos = diretorioRaiz.GetFiles("*.txt*");
                if (arquivos.Count() <= 0)
                {

                    MessageBox.Show("A pasta selecionada esta vazia.", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (FileInfo arq in arquivos)
                {

                    SpedDAO spedDAO = new SpedDAO(new ConexaoBD(DadosConexao.string_Conexao));
                    var sped = new ArquivoEFDFiscal();
                    //sped.BlocoC.
                    
                    
                    sped.Ler(arq.FullName, null);
                    var reg00 = sped.Bloco0;

                    var regc = sped.BlocoC.RegC001.RegC100s;
                    foreach (var item in regc)
                    {
                      
                        var retorno = spedDAO.Incluir_RegC100(item);
                        if (retorno > 0)
                        {
                            if (item.RegC101 != null)
                            {
                                spedDAO.Incluir_RegC101(item.RegC101, retorno);
                            }

                            if (item.RegC110s != null)
                            {
                                foreach (var itemRegC110s in item.RegC110s)
                                {
                                    spedDAO.Incluir_RegC110(itemRegC110s, retorno);

                                    if (itemRegC110s.RegC113s != null)
                                    {
                                        foreach (var itemRegC113s in itemRegC110s.RegC113s)
                                        {
                                            spedDAO.Incluir_RegC113(itemRegC113s, retorno);

                                        }
                                    }
                                }
                            }

                            if (item.RegC170s != null)
                            {
                                foreach (var itemRegC170s in item.RegC170s)
                                {
                                    spedDAO.Incluir_RegC170(itemRegC170s, retorno);

                                }
                            }
                            if (item.RegC190s != null)
                            {
                                foreach (var itemRegC190s in item.RegC190s)
                                {
                                    spedDAO.Incluir_RegC190(itemRegC190s, retorno);
                                }
                            }

                        }


                    }
                    MessageBox.Show("SPED Importado com Sucesso.", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro" + ex.Message);
            }

        }
    }
}
