using NFe.Classes.Informacoes.Destinatario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFe.Utils.NFe;
using NFe.Classes;
using System.Windows.Forms;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using Import_XML_NFS.AcessoDados;

namespace Import_XML_NFS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

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
                FileInfo[] arquivos = diretorioRaiz.GetFiles("*.xml*");
                if (arquivos.Count() <= 0)
                {

                    MessageBox.Show("A pasta selecionada esta vazia.", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (FileInfo arq in arquivos)
                {

            
                    int id_gerado = 0;
                    var nf = new NFe.Classes.NFe().CarregarDeArquivoXml(arq.FullName);
                    id_gerado = notaFiscalSaidaDAO.Incluir_Notafiscal(nf, nf.ObterXmlString());

                    foreach (var item in nf.infNFe.det)
                    {

                        if (id_gerado > 0)
                        {
                            notaFiscalSaidaDAO.Incluir_Itens_Notafiscal(item, id_gerado);

                        }
                    }                 

                }
                CarregarGrid(dgvConsultar ,notaFiscalSaidaDAO.LocalizarImportados());
                MessageBox.Show("XMLS Importados com Sucesso.", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro" + ex.Message);
            }
        }

        public void CarregarGrid(DataGridView dgvConsultar, DataTable dataTable)
        {
            try
            {

                dgvConsultar.DataSource = dataTable;
                dgvConsultar.Columns[0].HeaderText = "N° Importação";
                dgvConsultar.Columns[0].Width = 100;

                dgvConsultar.Columns[1].HeaderText = "CHAVE NF";
                dgvConsultar.Columns[1].Width = 260;

                dgvConsultar.Columns[2].HeaderText = "N° NF";
                dgvConsultar.Columns[2].Width = 80;

                dgvConsultar.Columns[3].HeaderText = "DT EMISSÃO";
                dgvConsultar.Columns[3].Width = 100;

                dgvConsultar.Columns[4].HeaderText = "OPERACÃO";
                dgvConsultar.Columns[4].Width = 350;

                dgvConsultar.Columns[5].HeaderText = "CNPJ EMITENTE";
                dgvConsultar.Columns[5].Width = 100;

                dgvConsultar.Columns[6].HeaderText = "EMITENTE";
                dgvConsultar.Columns[6].Width = 200;

                dgvConsultar.Columns[7].HeaderText = "DT IPORTAÇÃO";
                dgvConsultar.Columns[7].Width = 100;
                //dgvConsultar.Columns[7].HeaderText = "TP_SEXO";
                //dgvConsultar.Columns[7].Width = 200;


                //dgvConsultar.Columns[8].HeaderText = "TP_ESTADOCIVIL";
                //dgvConsultar.Columns[8].Width = 200;

                //dgvConsultar.Columns[9].HeaderText = "ID_SYS";
                //dgvConsultar.Columns[9].Width = 60;

                //dgvConsultar.Columns[10].HeaderText = "ATIVO";
                //dgvConsultar.Columns[10].Width = 100;

                //dgvConsultar.Columns[11].HeaderText = "CONTATO";
                //dgvConsultar.Columns[11].Width = 160;

                //dgvConsultar.Columns[12].HeaderText = "TELEFONE";
                //dgvConsultar.Columns[12].Width = 160;

                //dgvConsultar.Columns[13].HeaderText = "DS_INTERNET";
                //dgvConsultar.Columns[13].Width = 200;


                //dgvConsultar.Columns[14].HeaderText = "EMAIL";
                //dgvConsultar.Columns[14].Width = 200;


                //dgvConsultar.Columns[15].HeaderText = "ID_TIPOCONTATO";
                //dgvConsultar.Columns[15].Width = 250;

                //dgvConsultar.Columns[16].HeaderText = "LOGRADOURO";
                //dgvConsultar.Columns[16].Width = 200;

                //dgvConsultar.Columns[17].HeaderText = "BAIRRO";
                //dgvConsultar.Columns[17].Width = 160;

                //dgvConsultar.Columns[18].HeaderText = "CIDADE";
                //dgvConsultar.Columns[18].Width = 200;

                //dgvConsultar.Columns[19].HeaderText = "CEP";
                //dgvConsultar.Columns[19].Width = 160;


                //dgvConsultar.Columns[20].HeaderText = "ID_CONTATO";
                //dgvConsultar.Columns[20].Width = 50;

                //dgvConsultar.Columns[21].HeaderText = "N°";
                //dgvConsultar.Columns[21].Width = 100;

                //dgvConsultar.Columns[22].HeaderText = "ID_ESTADO";
                //dgvConsultar.Columns[22].Width = 120;

                //dgvConsultar.Columns[23].HeaderText = "COMPLEMENTO";
                //dgvConsultar.Columns[23].Width = 200;



                //dgvConsultar.Columns[24].HeaderText = "TP_COBRANCA";
                //dgvConsultar.Columns[24].Width = 120;

                //dgvConsultar.Columns[25].HeaderText = "ID_CLIENTE";
                //dgvConsultar.Columns[25].Width = 120;

                //dgvConsultar.Columns[26].HeaderText = "ID_VENDEDOR";
                //dgvConsultar.Columns[26].Width = 120;

                //dgvConsultar.Columns[27].HeaderText = "VL_LIMITECREDITO";
                //dgvConsultar.Columns[27].Width = 120;

                //dgvConsultar.Columns[28].HeaderText = "ID_TABELAPRECO";
                //dgvConsultar.Columns[28].Width = 120;

                //dgvConsultar.Columns[29].HeaderText = "ID_TIPOCLIENTE";
                //dgvConsultar.Columns[29].Width = 120;

                //dgvConsultar.Columns[30].HeaderText = "CD_CNPJCPF_FORMAT";
                //dgvConsultar.Columns[30].Width = 120;

                //dgvConsultar.Columns[31].HeaderText = "ESTADO";
                //dgvConsultar.Columns[31].Width = 180;

                //dgvConsultar.Columns[32].HeaderText = "TIPO CLIENTE";
                //dgvConsultar.Columns[32].Width = 200;

                //dgvConsultar.Columns[33].HeaderText = "ID_FILIAL";
                //dgvConsultar.Columns[33].Width = 120;

                //dgvConsultar.Columns["ID_PESSOA"].Visible = false;
                //dgvConsultar.Columns["ID_SYS"].Visible = false;
                //dgvConsultar.Columns["TP_ESTADOCIVIL"].Visible = false;
                //dgvConsultar.Columns["TP_SEXO"].Visible = false;
                //dgvConsultar.Columns["ID_TIPOCONTATO"].Visible = false;
                //dgvConsultar.Columns["ID_ESTADO"].Visible = false;

                //dgvConsultar.Columns["ID_CLIENTE"].Visible = false;

                //dgvConsultar.Columns["ID_VENDEDOR"].Visible = false;

                //dgvConsultar.Columns["VL_LIMITECREDITO"].Visible = false;

                //dgvConsultar.Columns["ID_TABELAPRECO"].Visible = false;

                //dgvConsultar.Columns["ID_TIPOCLIENTE"].Visible = false;

                //dgvConsultar.Columns["CD_CNPJCPF_FORMAT"].Visible = false;
                //dgvConsultar.Columns["ID_FILIAL"].Visible = false;

                //dgvConsultar.Columns["TP_COBRANCA"].Visible = false;

                //dgvConsultar.Columns["ID_CONTATO"].Visible = false;

                //dgvConsultar.Columns["DS_SITEINTERNET"].Visible = false;

                //dgvConsultar.Columns["DT_NASCIMENTO"].Visible = false;
                //if (dgvConsultar.SelectedRows.Count > 0)
                //{
                //    int index = dgvConsultar.SelectedRows[0].Index;

                //    if (index >= 0)
                //        dgvConsultar.Rows[index].Selected = false;
                //}

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPastaAcesso_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
