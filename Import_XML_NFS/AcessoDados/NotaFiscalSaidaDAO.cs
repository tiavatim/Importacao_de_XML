using NFe.Classes.Informacoes;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;
using NFe.Utils.Tributacao.Federal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import_XML_NFS.AcessoDados
{
    public class NotaFiscalSaidaDAO
    {

        private ConexaoBD conexao;


        public NotaFiscalSaidaDAO(ConexaoBD conexao)
        {
            this.conexao = conexao;
        }

        public int Incluir_Notafiscal(NFe.Classes.NFe nf, string xmlStr)
        {
            int id_gerado = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_XML_NOTAFISCAL_INS");
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cuf", nf.infNFe.ide.cUF);
                cmd.Parameters.AddWithValue("@cnf", nf.infNFe.ide.cNF);
                cmd.Parameters.AddWithValue("@natope", nf.infNFe.ide.natOp);
                cmd.Parameters.AddWithValue("@modelo", nf.infNFe.ide.mod);
                cmd.Parameters.AddWithValue("@serie", nf.infNFe.ide.serie);
                cmd.Parameters.AddWithValue("@nnf", nf.infNFe.ide.nNF);
                cmd.Parameters.AddWithValue("@dhemi", nf.infNFe.ide.dhEmi);
                cmd.Parameters.AddWithValue("@dhsaient", nf.infNFe.ide.dhSaiEnt);
                cmd.Parameters.AddWithValue("@tpnf", nf.infNFe.ide.tpNF);
                cmd.Parameters.AddWithValue("@iddest", nf.infNFe.ide.idDest);
                cmd.Parameters.AddWithValue("@cmunfg", nf.infNFe.ide.cMunFG);
                cmd.Parameters.AddWithValue("@tpimp", nf.infNFe.ide.tpImp);
                cmd.Parameters.AddWithValue("@tpemis", nf.infNFe.ide.tpEmis);
                cmd.Parameters.AddWithValue("@cdv", nf.infNFe.ide.cDV);
                cmd.Parameters.AddWithValue("@tpamb", nf.infNFe.ide.tpAmb);
                cmd.Parameters.AddWithValue("@finnfe", nf.infNFe.ide.finNFe);
                cmd.Parameters.AddWithValue("@indfinal", nf.infNFe.ide.indFinal);
                cmd.Parameters.AddWithValue("@indpres", nf.infNFe.ide.indPres);
                cmd.Parameters.AddWithValue("@procemi", nf.infNFe.ide.procEmi);
                cmd.Parameters.AddWithValue("@verproc", nf.infNFe.ide.verProc);
                cmd.Parameters.AddWithValue("@dhcont", nf.infNFe.ide.dhCont);
                cmd.Parameters.AddWithValue("@xjust", nf.infNFe.ide.xJust);
                cmd.Parameters.AddWithValue("@cnpjemi", nf.infNFe.emit.CNPJ);
                cmd.Parameters.AddWithValue("@cpfemi", nf.infNFe.emit.CPF);
                cmd.Parameters.AddWithValue("@xnomeemi", nf.infNFe.emit.xNome);
                cmd.Parameters.AddWithValue("@xfant", nf.infNFe.emit.xFant);
                cmd.Parameters.AddWithValue("@xlgremi", nf.infNFe.emit.enderEmit.xLgr);
                cmd.Parameters.AddWithValue("@nroemi", nf.infNFe.emit.enderEmit.nro);
                cmd.Parameters.AddWithValue("@xcplemi", nf.infNFe.emit.enderEmit.xCpl);
                cmd.Parameters.AddWithValue("@xbairroemi", nf.infNFe.emit.enderEmit.xBairro);
                cmd.Parameters.AddWithValue("@cmunemi", nf.infNFe.emit.enderEmit.cMun);
                cmd.Parameters.AddWithValue("@xmunemi", nf.infNFe.emit.enderEmit.xMun);
                cmd.Parameters.AddWithValue("@ufemi", nf.infNFe.emit.enderEmit.UF);
                cmd.Parameters.AddWithValue("@cepemi", nf.infNFe.emit.enderEmit.CEP);
                cmd.Parameters.AddWithValue("@cpaisemi", nf.infNFe.emit.enderEmit.cPais);
                cmd.Parameters.AddWithValue("@xpaisemi", nf.infNFe.emit.enderEmit.xPais);
                cmd.Parameters.AddWithValue("@foneemi", nf.infNFe.emit.enderEmit.fone);
                cmd.Parameters.AddWithValue("@ieemi", nf.infNFe.emit.IE);
                cmd.Parameters.AddWithValue("@iest", nf.infNFe.emit.IEST);
                cmd.Parameters.AddWithValue("@imemi", nf.infNFe.emit.IM);
                cmd.Parameters.AddWithValue("@cnae", nf.infNFe.emit.CNAE);
                cmd.Parameters.AddWithValue("@crt", nf.infNFe.emit.CRT);
                if(nf.infNFe.dest != null)
                {
                    cmd.Parameters.AddWithValue("@cpfdest", nf.infNFe.dest.CPF);
                    cmd.Parameters.AddWithValue("@cnpjdest", nf.infNFe.dest.CNPJ);
                    cmd.Parameters.AddWithValue("@idestrangeiro", nf.infNFe.dest.idEstrangeiro);
                    cmd.Parameters.AddWithValue("@xlgrdest", nf.infNFe.dest.enderDest.xLgr);
                    cmd.Parameters.AddWithValue("@nrodest", nf.infNFe.dest.enderDest.nro);
                    cmd.Parameters.AddWithValue("@xcpldest", nf.infNFe.dest.enderDest.xCpl);
                    cmd.Parameters.AddWithValue("@xbairrodest", nf.infNFe.dest.enderDest.xBairro);
                    cmd.Parameters.AddWithValue("@cmundest", nf.infNFe.dest.enderDest.cMun);
                    cmd.Parameters.AddWithValue("@xmundest", nf.infNFe.dest.enderDest.xMun);
                    cmd.Parameters.AddWithValue("@ufdest", nf.infNFe.dest.enderDest.UF);
                    cmd.Parameters.AddWithValue("@cepdest", nf.infNFe.dest.enderDest.CEP);

                    cmd.Parameters.AddWithValue("@cpaisdest", nf.infNFe.dest.enderDest.cPais);
                    cmd.Parameters.AddWithValue("@xpaisdest", nf.infNFe.dest.enderDest.xPais);
                    cmd.Parameters.AddWithValue("@fonedest", nf.infNFe.dest.enderDest.fone);
                    cmd.Parameters.AddWithValue("@indiedest", nf.infNFe.dest.indIEDest);
                    cmd.Parameters.AddWithValue("@iedest", nf.infNFe.dest.IE);
                    cmd.Parameters.AddWithValue("@isuf", nf.infNFe.dest.ISUF);
                    cmd.Parameters.AddWithValue("@imdest", nf.infNFe.dest.IM);
                    cmd.Parameters.AddWithValue("@email", nf.infNFe.dest.email);
                }
               
  
                cmd.Parameters.AddWithValue("@vbc", nf.infNFe.total.ICMSTot.vBC);
                cmd.Parameters.AddWithValue("@vicms", nf.infNFe.total.ICMSTot.vICMS);
                cmd.Parameters.AddWithValue("@vbcst", nf.infNFe.total.ICMSTot.vBCST);
                cmd.Parameters.AddWithValue("@vst", nf.infNFe.total.ICMSTot.vST);
                cmd.Parameters.AddWithValue("@vprod", nf.infNFe.total.ICMSTot.vProd);
                cmd.Parameters.AddWithValue("@vfrete", nf.infNFe.total.ICMSTot.vFrete);
                cmd.Parameters.AddWithValue("@vseg", nf.infNFe.total.ICMSTot.vSeg);
                cmd.Parameters.AddWithValue("@vdesc", nf.infNFe.total.ICMSTot.vDesc);
                cmd.Parameters.AddWithValue("@vii", nf.infNFe.total.ICMSTot.vII);
                cmd.Parameters.AddWithValue("@vipi", nf.infNFe.total.ICMSTot.vIPI);
                cmd.Parameters.AddWithValue("@vpis", nf.infNFe.total.ICMSTot.vPIS);
                cmd.Parameters.AddWithValue("@vcofins", nf.infNFe.total.ICMSTot.vCOFINS);
                cmd.Parameters.AddWithValue("@voutro", nf.infNFe.total.ICMSTot.vOutro);
                cmd.Parameters.AddWithValue("@vnf", nf.infNFe.total.ICMSTot.vNF);
                cmd.Parameters.AddWithValue("@vtottrib", nf.infNFe.total.ICMSTot.vTotTrib);
                cmd.Parameters.AddWithValue("@vicmsdeson", nf.infNFe.total.ICMSTot.vICMSDeson);
                cmd.Parameters.AddWithValue("@vicmsufdestopc", nf.infNFe.total.ICMSTot.vICMSUFDest);
                cmd.Parameters.AddWithValue("@vicmsufremet", nf.infNFe.total.ICMSTot.vICMSUFRemet);
                cmd.Parameters.AddWithValue("@vfcpufdestopc", nf.infNFe.total.ICMSTot.vFCPUFDest);
                cmd.Parameters.AddWithValue("@vfcp", nf.infNFe.total.ICMSTot.vFCP);
                cmd.Parameters.AddWithValue("@vfcpst", nf.infNFe.total.ICMSTot.vFCPST);
                cmd.Parameters.AddWithValue("@vfcpstret", nf.infNFe.total.ICMSTot.vFCPSTRet);
                cmd.Parameters.AddWithValue("@vipidevol", nf.infNFe.total.ICMSTot.vIPIDevol);
                cmd.Parameters.AddWithValue("@modfrete", nf.infNFe.transp.modFrete);

                var transporta = new NFe.Classes.Informacoes.Transporte.transporta();
                transporta = nf.infNFe.transp.transporta;


                if (transporta != null)
                {
                    cmd.Parameters.AddWithValue("@cnpjtransp", transporta.CNPJ);
                    cmd.Parameters.AddWithValue("@cpftransp", transporta.CPF);
                    cmd.Parameters.AddWithValue("@xnometransp", transporta.xNome);
                    cmd.Parameters.AddWithValue("@ietransp", transporta.IE);
                    cmd.Parameters.AddWithValue("@xender", transporta.xEnder);
                    cmd.Parameters.AddWithValue("@xmuntransp", transporta.xMun);
                    cmd.Parameters.AddWithValue("@uftransp", transporta.UF);
                }

                var veicTransp = new NFe.Classes.Informacoes.Transporte.veicTransp();
                veicTransp = nf.infNFe.transp.veicTransp;
                if (veicTransp != null)
                {
                    cmd.Parameters.AddWithValue("@placa", veicTransp.placa);
                    cmd.Parameters.AddWithValue("@ufveic", veicTransp.UF);
                    cmd.Parameters.AddWithValue("@rntc", veicTransp.RNTC);
                }

                if (nf.infNFe.transp.vol.Count() > 0)
                {
                    var volume = nf.infNFe.transp.vol.First();
                    if (volume != null)
                    {


                        cmd.Parameters.AddWithValue("@qvol", volume.qVol);
                        cmd.Parameters.AddWithValue("@esp", volume.esp);
                        cmd.Parameters.AddWithValue("@pesol", volume.pesoL);
                        cmd.Parameters.AddWithValue("@pesob", volume.pesoB);
                        cmd.Parameters.AddWithValue("@infadfisco", nf.infNFe.infAdic.infAdFisco);
                        cmd.Parameters.AddWithValue("@infcpl", nf.infNFe.infAdic.infCpl);
                    }
                }

                var fat = new NFe.Classes.Informacoes.Cobranca.fat();

                if (nf.infNFe.cobr != null)
                {
                    cmd.Parameters.AddWithValue("@nfat", nf.infNFe.cobr.fat.nFat);
                    cmd.Parameters.AddWithValue("@vorig", nf.infNFe.cobr.fat.vOrig);
                    cmd.Parameters.AddWithValue("@vdescfatura", nf.infNFe.cobr.fat.vDesc);
                    cmd.Parameters.AddWithValue("@vliq", nf.infNFe.cobr.fat.vLiq);
                }


                cmd.Parameters.AddWithValue("@versao", nf.infNFe.ide.verProc);
                cmd.Parameters.AddWithValue("@chavenf", nf.infNFe.Id.Replace("NFe", ""));
                cmd.Parameters.AddWithValue("@statusnfe", "");
                cmd.Parameters.AddWithValue("@XML_STRING", xmlStr);

                conexao.Conectar();
                cmd.CommandTimeout = 900;
                id_gerado = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
            return id_gerado;
        }

        public int Incluir_Itens_Notafiscal(NFe.Classes.Informacoes.Detalhe.det nf, int id_notafiscal)
        {
            int id_gerado = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_XM_ITEMNOTAFISCAL_INS");
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@notafiscal_idpk", id_notafiscal);
                cmd.Parameters.AddWithValue("@cprod", nf.prod.cProd);
                cmd.Parameters.AddWithValue("@cean", nf.prod.cEAN);
                cmd.Parameters.AddWithValue("@xprod", nf.prod.xProd);
                cmd.Parameters.AddWithValue("@ncm", nf.prod.NCM);
                cmd.Parameters.AddWithValue("@cestopc", nf.prod.CEST);
                cmd.Parameters.AddWithValue("@indescalaopc", nf.prod.indEscala);
                cmd.Parameters.AddWithValue("@cnpjfabopc", nf.prod.CNPJFab);
                cmd.Parameters.AddWithValue("@cbenfopc", nf.prod.cBenef);
                cmd.Parameters.AddWithValue("@extipi", nf.prod.EXTIPI);
                cmd.Parameters.AddWithValue("@cfop", nf.prod.CFOP);
                cmd.Parameters.AddWithValue("@ucom", nf.prod.uCom);
                cmd.Parameters.AddWithValue("@qcom", nf.prod.qCom);
                cmd.Parameters.AddWithValue("@vuncom", nf.prod.vUnCom);
                cmd.Parameters.AddWithValue("@vprod", nf.prod.vProd);
                cmd.Parameters.AddWithValue("@ceantrib", nf.prod.cEANTrib);
                cmd.Parameters.AddWithValue("@utrib", nf.prod.uTrib);
                cmd.Parameters.AddWithValue("@vuntrib", nf.prod.vUnTrib);
                cmd.Parameters.AddWithValue("@vfrete", nf.prod.vFrete);
                cmd.Parameters.AddWithValue("@vseg", nf.prod.vSeg);
                cmd.Parameters.AddWithValue("@voutro", nf.prod.vOutro);
                cmd.Parameters.AddWithValue("@indtot", nf.prod.indTot);

                NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.ICMS iCMS = new NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.ICMS();
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS00))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMS00;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CST);
                    cmd.Parameters.AddWithValue("@modbc", ICMS.modBC);
                    cmd.Parameters.AddWithValue("@predbc", 0);
                    cmd.Parameters.AddWithValue("@vbcicms", ICMS.vBC);
                    cmd.Parameters.AddWithValue("@picms", ICMS.pICMS);
                    cmd.Parameters.AddWithValue("@vicms", ICMS.vICMS);
                    cmd.Parameters.AddWithValue("@modbcst", 0);
                    cmd.Parameters.AddWithValue("@pmvast", 0);
                    cmd.Parameters.AddWithValue("@predbcst", 0);
                    cmd.Parameters.AddWithValue("@vbcst", 0);
                    cmd.Parameters.AddWithValue("@picmsst", 0);
                    cmd.Parameters.AddWithValue("@vicmsst", 0);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", 0);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", 0);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", 0);
                    cmd.Parameters.AddWithValue("@pfcp", ICMS.pFCP);
                    cmd.Parameters.AddWithValue("@vfcp", ICMS.vFCP);
                    cmd.Parameters.AddWithValue("@vbcfcpst", 0);
                    cmd.Parameters.AddWithValue("@pfcpst", 0);
                    cmd.Parameters.AddWithValue("@vfcpst", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);
                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS10))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMS10;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CST);
                    cmd.Parameters.AddWithValue("@modbc", ICMS.modBC);
                    cmd.Parameters.AddWithValue("@predbc", 0);
                    cmd.Parameters.AddWithValue("@vbcicms", ICMS.vBC);
                    cmd.Parameters.AddWithValue("@picms", ICMS.pICMS);
                    cmd.Parameters.AddWithValue("@vicms", ICMS.vICMS);
                    cmd.Parameters.AddWithValue("@modbcst", ICMS.modBCST);
                    cmd.Parameters.AddWithValue("@pmvast", ICMS.pMVAST);
                    cmd.Parameters.AddWithValue("@predbcst", ICMS.pRedBCST);
                    cmd.Parameters.AddWithValue("@vbcst", ICMS.vBCST);
                    cmd.Parameters.AddWithValue("@picmsst", ICMS.pICMSST);
                    cmd.Parameters.AddWithValue("@vicmsst", ICMS.vICMSST);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", 0);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", 0);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", ICMS.vBCFCP);
                    cmd.Parameters.AddWithValue("@pfcp", ICMS.pFCP);
                    cmd.Parameters.AddWithValue("@vfcp", ICMS.vFCP);
                    cmd.Parameters.AddWithValue("@vbcfcpst", ICMS.vBCFCPST);
                    cmd.Parameters.AddWithValue("@pfcpst", ICMS.pFCPST);
                    cmd.Parameters.AddWithValue("@vfcpst", ICMS.vFCPST);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);
                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS20))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMS20;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CST);
                    cmd.Parameters.AddWithValue("@modbc", ICMS.modBC);
                    cmd.Parameters.AddWithValue("@predbc", 0);
                    cmd.Parameters.AddWithValue("@vbcicms", ICMS.vBC);
                    cmd.Parameters.AddWithValue("@picms", ICMS.pICMS);
                    cmd.Parameters.AddWithValue("@vicms", ICMS.vICMS);
                    cmd.Parameters.AddWithValue("@modbcst", 0);
                    cmd.Parameters.AddWithValue("@pmvast", 0);
                    cmd.Parameters.AddWithValue("@predbcst", 0);
                    cmd.Parameters.AddWithValue("@vbcst", 0);
                    cmd.Parameters.AddWithValue("@picmsst", 0);
                    cmd.Parameters.AddWithValue("@vicmsst", 0);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", 0);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", 0);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", ICMS.vBCFCP);
                    cmd.Parameters.AddWithValue("@pfcp", ICMS.pFCP);
                    cmd.Parameters.AddWithValue("@vfcp", ICMS.vFCP);
                    cmd.Parameters.AddWithValue("@vbcfcpst", 0);
                    cmd.Parameters.AddWithValue("@pfcpst", 0);
                    cmd.Parameters.AddWithValue("@vfcpst", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);
                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS30))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMS30;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CST);
                    cmd.Parameters.AddWithValue("@modbc", 0);
                    cmd.Parameters.AddWithValue("@predbc", 0);
                    cmd.Parameters.AddWithValue("@vbcicms", 0);
                    cmd.Parameters.AddWithValue("@picms", 0);
                    cmd.Parameters.AddWithValue("@vicms", 0);
                    cmd.Parameters.AddWithValue("@modbcst", ICMS.modBCST);
                    cmd.Parameters.AddWithValue("@pmvast", ICMS.pMVAST);
                    cmd.Parameters.AddWithValue("@predbcst", ICMS.pRedBCST);
                    cmd.Parameters.AddWithValue("@vbcst", ICMS.vBCST);
                    cmd.Parameters.AddWithValue("@picmsst", ICMS.pICMSST);
                    cmd.Parameters.AddWithValue("@vicmsst", ICMS.vICMSST);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", ICMS.motDesICMS);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", ICMS.vICMSDeson);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", 0);
                    cmd.Parameters.AddWithValue("@pfcp", 0);
                    cmd.Parameters.AddWithValue("@vfcp", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpst", ICMS.vBCFCPST);
                    cmd.Parameters.AddWithValue("@pfcpst", ICMS.pFCPST);
                    cmd.Parameters.AddWithValue("@vfcpst", ICMS.vFCPST);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);
                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS40))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMS40;
                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CST);
                    cmd.Parameters.AddWithValue("@modbc", 0);
                    cmd.Parameters.AddWithValue("@predbc", 0);
                    cmd.Parameters.AddWithValue("@vbcicms", 0);
                    cmd.Parameters.AddWithValue("@picms", 0);
                    cmd.Parameters.AddWithValue("@vicms", 0);
                    cmd.Parameters.AddWithValue("@modbcst", 0);
                    cmd.Parameters.AddWithValue("@pmvast", 0);
                    cmd.Parameters.AddWithValue("@predbcst", 0);
                    cmd.Parameters.AddWithValue("@vbcst", 0);
                    cmd.Parameters.AddWithValue("@picmsst", 0);
                    cmd.Parameters.AddWithValue("@vicmsst", 0);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", ICMS.motDesICMS);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", ICMS.vICMSDeson);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", 0);
                    cmd.Parameters.AddWithValue("@pfcp", 0);
                    cmd.Parameters.AddWithValue("@vfcp", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpst", 0);
                    cmd.Parameters.AddWithValue("@pfcpst", 0);
                    cmd.Parameters.AddWithValue("@vfcpst", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);
                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS51))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMS51;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CST);
                    cmd.Parameters.AddWithValue("@modbc", ICMS.modBC);
                    cmd.Parameters.AddWithValue("@predbc", ICMS.pRedBC);
                    cmd.Parameters.AddWithValue("@vbcicms", ICMS.vBC);
                    cmd.Parameters.AddWithValue("@picms", ICMS.pICMS);
                    cmd.Parameters.AddWithValue("@vicms", ICMS.vICMS);
                    cmd.Parameters.AddWithValue("@modbcst", 0);
                    cmd.Parameters.AddWithValue("@pmvast", 0);
                    cmd.Parameters.AddWithValue("@predbcst", 0);
                    cmd.Parameters.AddWithValue("@vbcst", 0);
                    cmd.Parameters.AddWithValue("@picmsst", 0);
                    cmd.Parameters.AddWithValue("@vicmsst", 0);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", 0);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", 0);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", ICMS.vBCFCP);
                    cmd.Parameters.AddWithValue("@pfcp", ICMS.pFCP);
                    cmd.Parameters.AddWithValue("@vfcp", ICMS.vFCP);
                    cmd.Parameters.AddWithValue("@vbcfcpst", 0);
                    cmd.Parameters.AddWithValue("@pfcpst", 0);
                    cmd.Parameters.AddWithValue("@vfcpst", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);

                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS60))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMS60;
                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CST);
                    cmd.Parameters.AddWithValue("@modbc", 0);
                    cmd.Parameters.AddWithValue("@predbc", 0);
                    cmd.Parameters.AddWithValue("@vbcicms", 0);
                    cmd.Parameters.AddWithValue("@picms", 0);
                    cmd.Parameters.AddWithValue("@vicms", 0);
                    cmd.Parameters.AddWithValue("@modbcst", 0);
                    cmd.Parameters.AddWithValue("@pmvast", 0);
                    cmd.Parameters.AddWithValue("@predbcst", 0);
                    cmd.Parameters.AddWithValue("@vbcst", 0);
                    cmd.Parameters.AddWithValue("@picmsst", 0);
                    cmd.Parameters.AddWithValue("@vicmsst", 0);
                    cmd.Parameters.AddWithValue("@vbcstret", ICMS.vBCSTRet);
                    cmd.Parameters.AddWithValue("@vicmsstret", ICMS.vICMSSTRet);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", 0);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", 0);
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", 0);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", 0);
                    cmd.Parameters.AddWithValue("@pfcp", 0);
                    cmd.Parameters.AddWithValue("@vfcp", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpst", 0);
                    cmd.Parameters.AddWithValue("@pfcpst", 0);
                    cmd.Parameters.AddWithValue("@vfcpst", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);
                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS70))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMS70;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CST);
                    cmd.Parameters.AddWithValue("@modbc", ICMS.modBC);
                    cmd.Parameters.AddWithValue("@predbc", ICMS.pRedBC);
                    cmd.Parameters.AddWithValue("@vbcicms", ICMS.vBC);
                    cmd.Parameters.AddWithValue("@picms", ICMS.pICMS);
                    cmd.Parameters.AddWithValue("@vicms", ICMS.vICMS);
                    cmd.Parameters.AddWithValue("@modbcst", ICMS.modBCST);
                    cmd.Parameters.AddWithValue("@pmvast", ICMS.pMVAST);
                    cmd.Parameters.AddWithValue("@predbcst", ICMS.pRedBCST);
                    cmd.Parameters.AddWithValue("@vbcst", ICMS.vBCST);
                    cmd.Parameters.AddWithValue("@picmsst", ICMS.pICMSST);
                    cmd.Parameters.AddWithValue("@vicmsst", ICMS.vICMSST);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", ICMS.motDesICMS);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", ICMS.vICMSDeson);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", ICMS.vBCFCP);
                    cmd.Parameters.AddWithValue("@pfcp", ICMS.pFCP);
                    cmd.Parameters.AddWithValue("@vfcp", ICMS.vFCP);
                    cmd.Parameters.AddWithValue("@vbcfcpst", ICMS.vBCFCPST);
                    cmd.Parameters.AddWithValue("@pfcpst", ICMS.pFCPST);
                    cmd.Parameters.AddWithValue("@vfcpst", ICMS.vFCPST);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);

                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMS90))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMS90;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CST);
                    cmd.Parameters.AddWithValue("@modbc", ICMS.modBC);
                    cmd.Parameters.AddWithValue("@predbc", ICMS.pRedBC);
                    cmd.Parameters.AddWithValue("@vbcicms", ICMS.vBC);
                    cmd.Parameters.AddWithValue("@picms", ICMS.pICMS);
                    cmd.Parameters.AddWithValue("@vicms", ICMS.vICMS);
                    cmd.Parameters.AddWithValue("@modbcst", ICMS.modBCST);
                    cmd.Parameters.AddWithValue("@pmvast", ICMS.pMVAST);
                    cmd.Parameters.AddWithValue("@predbcst", ICMS.pRedBCST);
                    cmd.Parameters.AddWithValue("@vbcst", ICMS.vBCST);
                    cmd.Parameters.AddWithValue("@picmsst", ICMS.pICMSST);
                    cmd.Parameters.AddWithValue("@vicmsst", ICMS.vICMSST);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", ICMS.motDesICMS);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", ICMS.vICMSDeson);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", ICMS.vBCFCP);
                    cmd.Parameters.AddWithValue("@pfcp", ICMS.pFCP);
                    cmd.Parameters.AddWithValue("@vfcp", ICMS.vFCP);
                    cmd.Parameters.AddWithValue("@vbcfcpst", ICMS.vBCFCPST);
                    cmd.Parameters.AddWithValue("@pfcpst", ICMS.pFCPST);
                    cmd.Parameters.AddWithValue("@vfcpst", ICMS.vFCPST);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);

                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMSSN101))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMSSN101;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CSOSN);
                    cmd.Parameters.AddWithValue("@modbc", 0);
                    cmd.Parameters.AddWithValue("@predbc", 0);
                    cmd.Parameters.AddWithValue("@vbcicms", 0);
                    cmd.Parameters.AddWithValue("@picms", 0);
                    cmd.Parameters.AddWithValue("@vicms", 0);
                    cmd.Parameters.AddWithValue("@modbcst", 0);
                    cmd.Parameters.AddWithValue("@pmvast", 0);
                    cmd.Parameters.AddWithValue("@predbcst", 0);
                    cmd.Parameters.AddWithValue("@vbcst", 0);
                    cmd.Parameters.AddWithValue("@picmsst", 0);
                    cmd.Parameters.AddWithValue("@vicmsst", 0);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", 0);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", ICMS.pCredSN);
                    cmd.Parameters.AddWithValue("@vcredicmssn", ICMS.vCredICMSSN);
                    cmd.Parameters.AddWithValue("@vicmsdeson", 0);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", 0);
                    cmd.Parameters.AddWithValue("@pfcp", 0);
                    cmd.Parameters.AddWithValue("@vfcp", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpst", 0);
                    cmd.Parameters.AddWithValue("@pfcpst", 0);
                    cmd.Parameters.AddWithValue("@vfcpst", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);

                }

                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMSSN102))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMSSN102;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CSOSN);
                    cmd.Parameters.AddWithValue("@modbc", 0);
                    cmd.Parameters.AddWithValue("@predbc", 0);
                    cmd.Parameters.AddWithValue("@vbcicms", 0);
                    cmd.Parameters.AddWithValue("@picms", 0);
                    cmd.Parameters.AddWithValue("@vicms", 0);
                    cmd.Parameters.AddWithValue("@modbcst", 0);
                    cmd.Parameters.AddWithValue("@pmvast", 0);
                    cmd.Parameters.AddWithValue("@predbcst", 0);
                    cmd.Parameters.AddWithValue("@vbcst", 0);
                    cmd.Parameters.AddWithValue("@picmsst", 0);
                    cmd.Parameters.AddWithValue("@vicmsst", 0);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", 0);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", 0);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", 0);
                    cmd.Parameters.AddWithValue("@pfcp", 0);
                    cmd.Parameters.AddWithValue("@vfcp", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpst", 0);
                    cmd.Parameters.AddWithValue("@pfcpst", 0);
                    cmd.Parameters.AddWithValue("@vfcpst", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);

                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMSSN201))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMSSN201;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CSOSN);
                    cmd.Parameters.AddWithValue("@modbc", 0);
                    cmd.Parameters.AddWithValue("@predbc", 0);
                    cmd.Parameters.AddWithValue("@vbcicms", 0);
                    cmd.Parameters.AddWithValue("@picms", 0);
                    cmd.Parameters.AddWithValue("@vicms", 0);
                    cmd.Parameters.AddWithValue("@modbcst", ICMS.modBCST);
                    cmd.Parameters.AddWithValue("@pmvast", ICMS.pMVAST);
                    cmd.Parameters.AddWithValue("@predbcst", ICMS.pRedBCST);
                    cmd.Parameters.AddWithValue("@vbcst", ICMS.vBCST);
                    cmd.Parameters.AddWithValue("@picmsst", ICMS.pICMSST);
                    cmd.Parameters.AddWithValue("@vicmsst", ICMS.vICMSST);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", 0);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", ICMS.pCredSN);
                    cmd.Parameters.AddWithValue("@vcredicmssn", ICMS.vCredICMSSN);
                    cmd.Parameters.AddWithValue("@vicmsdeson", 0);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", 0);
                    cmd.Parameters.AddWithValue("@pfcp", 0);
                    cmd.Parameters.AddWithValue("@vfcp", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpst", ICMS.vBCFCPST);
                    cmd.Parameters.AddWithValue("@pfcpst", ICMS.pFCPST);
                    cmd.Parameters.AddWithValue("@vfcpst", ICMS.vFCPST);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);

                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMSSN202))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMSSN202;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CSOSN);
                    cmd.Parameters.AddWithValue("@modbc", 0);
                    cmd.Parameters.AddWithValue("@predbc", 0);
                    cmd.Parameters.AddWithValue("@vbcicms", 0);
                    cmd.Parameters.AddWithValue("@picms", 0);
                    cmd.Parameters.AddWithValue("@vicms", 0);
                    cmd.Parameters.AddWithValue("@modbcst", ICMS.modBCST);
                    cmd.Parameters.AddWithValue("@pmvast", ICMS.pMVAST);
                    cmd.Parameters.AddWithValue("@predbcst", ICMS.pRedBCST);
                    cmd.Parameters.AddWithValue("@vbcst", ICMS.vBCST);
                    cmd.Parameters.AddWithValue("@picmsst", ICMS.pICMSST);
                    cmd.Parameters.AddWithValue("@vicmsst", ICMS.vICMSST);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", 0);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", 0);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", 0);
                    cmd.Parameters.AddWithValue("@pfcp", 0);
                    cmd.Parameters.AddWithValue("@vfcp", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpst", ICMS.vBCFCPST);
                    cmd.Parameters.AddWithValue("@pfcpst", ICMS.pFCPST);
                    cmd.Parameters.AddWithValue("@vfcpst", ICMS.vFCPST);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);
                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMSSN500))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMSSN500;


                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CSOSN);
                    cmd.Parameters.AddWithValue("@modbc", 0);
                    cmd.Parameters.AddWithValue("@predbc", 0);
                    cmd.Parameters.AddWithValue("@vbcicms", 0);
                    cmd.Parameters.AddWithValue("@picms", 0);
                    cmd.Parameters.AddWithValue("@vicms", 0);
                    cmd.Parameters.AddWithValue("@modbcst", 0);
                    cmd.Parameters.AddWithValue("@pmvast", 0);
                    cmd.Parameters.AddWithValue("@predbcst", 0);
                    cmd.Parameters.AddWithValue("@vbcst", 0);
                    cmd.Parameters.AddWithValue("@picmsst", 0);
                    cmd.Parameters.AddWithValue("@vicmsst", 0);
                    cmd.Parameters.AddWithValue("@vbcstret", ICMS.vBCSTRet);
                    cmd.Parameters.AddWithValue("@vicmsstret", ICMS.vICMSSTRet);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", 0);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", 0);
                    cmd.Parameters.AddWithValue("@vcredicmssn", 0);
                    cmd.Parameters.AddWithValue("@vicmsdeson", 0);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", 0);
                    cmd.Parameters.AddWithValue("@pfcp", 0);
                    cmd.Parameters.AddWithValue("@vfcp", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpst", 0);
                    cmd.Parameters.AddWithValue("@pfcpst", 0);
                    cmd.Parameters.AddWithValue("@vfcpst", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", ICMS.vBCFCPSTRet);
                    cmd.Parameters.AddWithValue("@pfcpstret", ICMS.pFCPSTRet);
                    cmd.Parameters.AddWithValue("@vfcpstret", ICMS.vICMSEfet);

                }
                if (nf.imposto.ICMS.TipoICMS.GetType() == typeof(ICMSSN900))
                {
                    var ICMS = nf.imposto.ICMS.TipoICMS as ICMSSN900;

                    cmd.Parameters.AddWithValue("@orig", ICMS.orig);
                    cmd.Parameters.AddWithValue("@csticms", ICMS.CSOSN);
                    cmd.Parameters.AddWithValue("@modbc", ICMS.modBC);
                    cmd.Parameters.AddWithValue("@predbc", ICMS.pRedBC);
                    cmd.Parameters.AddWithValue("@vbcicms", ICMS.vBC);
                    cmd.Parameters.AddWithValue("@picms", ICMS.pICMS);
                    cmd.Parameters.AddWithValue("@vicms", ICMS.vICMS);
                    cmd.Parameters.AddWithValue("@modbcst", ICMS.modBCST);
                    cmd.Parameters.AddWithValue("@pmvast", ICMS.pMVAST);
                    cmd.Parameters.AddWithValue("@predbcst", ICMS.pRedBCST);
                    cmd.Parameters.AddWithValue("@vbcst", ICMS.vBCST);
                    cmd.Parameters.AddWithValue("@picmsst", ICMS.pICMSST);
                    cmd.Parameters.AddWithValue("@vicmsst", ICMS.vICMSST);
                    cmd.Parameters.AddWithValue("@vbcstret", 0);
                    cmd.Parameters.AddWithValue("@vicmsstret", 0);
                    cmd.Parameters.AddWithValue("@vbcstdest", 0);
                    cmd.Parameters.AddWithValue("@motdesicms", 0);
                    cmd.Parameters.AddWithValue("@pbcop", 0);
                    cmd.Parameters.AddWithValue("@ufst", "");
                    cmd.Parameters.AddWithValue("@pcredsn", ICMS.pCredSN);
                    cmd.Parameters.AddWithValue("@vcredicmssn", ICMS.vCredICMSSN);
                    cmd.Parameters.AddWithValue("@vicmsdeson", 0);
                    cmd.Parameters.AddWithValue("@vicmsop", 0);
                    cmd.Parameters.AddWithValue("@pdif", 0);
                    cmd.Parameters.AddWithValue("@vicmsdif", 0);
                    cmd.Parameters.AddWithValue("@vbcfcp", 0);
                    cmd.Parameters.AddWithValue("@pfcp", 0);
                    cmd.Parameters.AddWithValue("@vfcp", 0);
                    cmd.Parameters.AddWithValue("@vbcfcpst", ICMS.vBCFCPST);
                    cmd.Parameters.AddWithValue("@pfcpst", ICMS.pFCPST);
                    cmd.Parameters.AddWithValue("@vfcpst", ICMS.vFCPST);
                    cmd.Parameters.AddWithValue("@vbcfcpstret", 0);
                    cmd.Parameters.AddWithValue("@pfcpstret", 0);
                    cmd.Parameters.AddWithValue("@vfcpstret", 0);
                }

                cmd.Parameters.AddWithValue("@pst", 0);

                if (nf.imposto.IPI != null)
                {
                    cmd.Parameters.AddWithValue("@cselo", nf.imposto.IPI.cSelo);
                    cmd.Parameters.AddWithValue("@qselo", nf.imposto.IPI.qSelo);
                    cmd.Parameters.AddWithValue("@cenq", nf.imposto.IPI.cEnq);

                    if (nf.imposto.IPI.TipoIPI.GetType() == typeof(IPITrib))
                    {
                        var ipi = nf.imposto.IPI.TipoIPI as IPITrib;


                        cmd.Parameters.AddWithValue("@cstipi", ipi.CST);
                        cmd.Parameters.AddWithValue("@vbcipi", ipi.vBC);
                        cmd.Parameters.AddWithValue("@pipi", ipi.pIPI);
                        cmd.Parameters.AddWithValue("@vipi", ipi.vIPI);
                        cmd.Parameters.AddWithValue("@qunid", ipi.qUnid);
                        cmd.Parameters.AddWithValue("@vunid", ipi.vUnid);
                    }


                    if (nf.imposto.IPI.TipoIPI.GetType() == typeof(IPINT))
                    {
                        var ipi = nf.imposto.IPI.TipoIPI as IPINT;
                        List<CSTIPI> cs = new List<CSTIPI>();


                        cmd.Parameters.AddWithValue("@cstipi", ipi.CST.ToString().Replace("ipi", ""));
                        //cmd.Parameters.AddWithValue("@vbcipi", ipi.vBC);
                        //cmd.Parameters.AddWithValue("@pipi", ipi.pIPI);
                        //cmd.Parameters.AddWithValue("@vipi", ipi.vIPI);
                        //cmd.Parameters.AddWithValue("@qunid", ipi.qUnid);
                        //cmd.Parameters.AddWithValue("@vunid", ipi.vUnid);
                    }

                }

                if(nf.imposto.PIS != null)
                {
                    if (nf.imposto.PIS.TipoPIS.GetType() == typeof(PISOutr))
                    {
                        var pis = nf.imposto.PIS.TipoPIS as PISOutr;
                        cmd.Parameters.AddWithValue("@cstpis", pis.CST.ToString().Replace("pis", ""));
                        cmd.Parameters.AddWithValue("@vbcpis", pis.vBC);
                        cmd.Parameters.AddWithValue("@ppis", pis.pPIS);
                        cmd.Parameters.AddWithValue("@vpis", pis.vPIS);
                        cmd.Parameters.AddWithValue("@qbcprodpis", pis.qBCProd);
                        cmd.Parameters.AddWithValue("@valiqprodpis", pis.vAliqProd);
                    }

                    if (nf.imposto.PIS.TipoPIS.GetType() == typeof(PISNT))
                    {
                        var pis = nf.imposto.PIS.TipoPIS as PISNT;
                        cmd.Parameters.AddWithValue("@cstpis", pis.CST.ToString().Replace("pis", ""));

                    }
                    if (nf.imposto.PIS.TipoPIS.GetType() == typeof(PISST))
                    {
                        var pis = nf.imposto.PIS.TipoPIS as PISST;
                        //cmd.Parameters.AddWithValue("@cstpis", pis.CST);
                        cmd.Parameters.AddWithValue("@vbcpis", pis.vBC);
                        cmd.Parameters.AddWithValue("@ppis", pis.pPIS);
                        cmd.Parameters.AddWithValue("@vpis", pis.vPIS);
                        cmd.Parameters.AddWithValue("@qbcprodpis", pis.qBCProd);
                        cmd.Parameters.AddWithValue("@valiqprodpis", pis.vAliqProd);

                    }
                    if (nf.imposto.PIS.TipoPIS.GetType() == typeof(PISQtde))
                    {
                        var pis = nf.imposto.PIS.TipoPIS as PISQtde;
                        cmd.Parameters.AddWithValue("@cstpis", pis.CST.ToString().Replace("pis", ""));
                        cmd.Parameters.AddWithValue("@vpis", pis.vPIS);
                        cmd.Parameters.AddWithValue("@qbcprodpis", pis.qBCProd);
                        cmd.Parameters.AddWithValue("@valiqprodpis", pis.vAliqProd);
                    }

                    if (nf.imposto.PIS.TipoPIS.GetType() == typeof(PISAliq))
                    {
                        var pis = nf.imposto.PIS.TipoPIS as PISAliq;
                        cmd.Parameters.AddWithValue("@cstpis", pis.CST.ToString().Replace("pis", ""));

                        cmd.Parameters.AddWithValue("@ppis", pis.pPIS);
                        cmd.Parameters.AddWithValue("@vpis", pis.vPIS);
                        cmd.Parameters.AddWithValue("@vbcpis", pis.vBC);

                    }
                }

                if(nf.imposto.COFINS != null)
                {
                    if (nf.imposto.COFINS.TipoCOFINS.GetType() == typeof(COFINSOutr))
                    {
                        var cofins = nf.imposto.COFINS.TipoCOFINS as COFINSOutr;
                        cmd.Parameters.AddWithValue("@cstcofins", cofins.CST.ToString().Replace("cofins", ""));
                        cmd.Parameters.AddWithValue("@vbccofins", cofins.vBC);
                        cmd.Parameters.AddWithValue("@pcofins", cofins.pCOFINS);
                        cmd.Parameters.AddWithValue("@vcofins", cofins.vCOFINS);

                        cmd.Parameters.AddWithValue("@qbcprodcofins", cofins.qBCProd);
                        cmd.Parameters.AddWithValue("@valiqprodcofins", cofins.vAliqProd);
                    }
                    if (nf.imposto.COFINS.TipoCOFINS.GetType() == typeof(COFINSNT))
                    {
                        var cofins = nf.imposto.COFINS.TipoCOFINS as COFINSNT;
                        cmd.Parameters.AddWithValue("@cstcofins", cofins.CST.ToString().Replace("cofins", ""));
                    }
                    if (nf.imposto.COFINS.TipoCOFINS.GetType() == typeof(COFINSST))
                    {
                        var cofins = nf.imposto.COFINS.TipoCOFINS as COFINSST;
                        //cmd.Parameters.AddWithValue("@cstcofins", cofins.CST.ToString().Replace("confins", ""));
                        cmd.Parameters.AddWithValue("@vbccofins", cofins.vBC);
                        cmd.Parameters.AddWithValue("@pcofins", cofins.pCOFINS);
                        cmd.Parameters.AddWithValue("@vcofins", cofins.vCOFINS);

                        cmd.Parameters.AddWithValue("@qbcprodcofins", cofins.qBCProd);
                        cmd.Parameters.AddWithValue("@valiqprodcofins", cofins.vAliqProd);
                    }


                    if (nf.imposto.COFINS.TipoCOFINS.GetType() == typeof(COFINSQtde))
                    {
                        var cofins = nf.imposto.COFINS.TipoCOFINS as COFINSQtde;
                        cmd.Parameters.AddWithValue("@cstcofins", cofins.CST.ToString().Replace("cofins", ""));

                        cmd.Parameters.AddWithValue("@vcofins", cofins.vCOFINS);

                        cmd.Parameters.AddWithValue("@qbcprodcofins", cofins.qBCProd);
                        cmd.Parameters.AddWithValue("@valiqprodcofins", cofins.vAliqProd);
                    }
                    if (nf.imposto.COFINS.TipoCOFINS.GetType() == typeof(COFINSAliq))
                    {
                        var cofins = nf.imposto.COFINS.TipoCOFINS as COFINSAliq;
                        cmd.Parameters.AddWithValue("@cstcofins", cofins.CST.ToString().Replace("cofins", ""));
                        cmd.Parameters.AddWithValue("@vbccofins", cofins.vBC);
                        cmd.Parameters.AddWithValue("@pcofins", cofins.pCOFINS);
                        cmd.Parameters.AddWithValue("@vcofins", cofins.vCOFINS);
                    }
                }

                if(nf.imposto.ICMSUFDest != null)
                {
                    if (nf.imposto.ICMSUFDest != null)
                    {
                        cmd.Parameters.AddWithValue("@vbcufdest", nf.imposto.ICMSUFDest.vBCUFDest);
                        cmd.Parameters.AddWithValue("@vbcfcpufdestopc", nf.imposto.ICMSUFDest.vBCFCPUFDest);
                        cmd.Parameters.AddWithValue("@pfcpufdest", nf.imposto.ICMSUFDest.pFCPUFDest);
                        cmd.Parameters.AddWithValue("@picmsufdest", nf.imposto.ICMSUFDest.pICMSUFDest);
                        cmd.Parameters.AddWithValue("@picmsinter", nf.imposto.ICMSUFDest.pICMSInter);
                        cmd.Parameters.AddWithValue("@picmsinterpart", nf.imposto.ICMSUFDest.pICMSInterPart);
                        cmd.Parameters.AddWithValue("@vfcpufdest", nf.imposto.ICMSUFDest.vFCPUFDest);
                        cmd.Parameters.AddWithValue("@vicmsufdest", nf.imposto.ICMSUFDest.vICMSUFDest);
                        cmd.Parameters.AddWithValue("@vicmsufremet", nf.imposto.ICMSUFDest.vICMSUFRemet);
                    }
                }



                conexao.Conectar();
                cmd.CommandTimeout = 900;
                id_gerado = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
            return id_gerado;
        }


        public DataTable LocalizarImportados()
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(" select * from VW_NFS_IMPORTADA  ORDER BY DT_IMPORTACAO DESC", conexao.StringConexao);
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
