using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FiscalBr.EFDFiscal.BlocoC;

namespace Import_XML_NFS.AcessoDados
{
    public class SpedDAO
    {
        private ConexaoBD conexao;


        public SpedDAO(ConexaoBD conexao)
        {
            this.conexao = conexao;
        }

        public int Incluir_RegC100(RegistroC100 registroC100)
        {
            int id_gerado = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SPED_REGC100");
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IndOper", registroC100.IndOper);
                cmd.Parameters.AddWithValue("@IndEmit", registroC100.IndEmit);
                cmd.Parameters.AddWithValue("@CodPart", registroC100.CodPart);
                cmd.Parameters.AddWithValue("@CodMod", registroC100.CodMod);
                cmd.Parameters.AddWithValue("@CodSit", registroC100.CodSit);
                cmd.Parameters.AddWithValue("@Ser", registroC100.Ser);
                cmd.Parameters.AddWithValue("@NumDoc", registroC100.NumDoc);
                cmd.Parameters.AddWithValue("@ChvNfe", registroC100.ChvNfe);
                cmd.Parameters.AddWithValue("@DtDoc", registroC100.DtDoc);
                cmd.Parameters.AddWithValue("@DtEs", registroC100.DtEs);
                cmd.Parameters.AddWithValue("@VlDoc", registroC100.VlDoc);
                cmd.Parameters.AddWithValue("@IndPgto", registroC100.IndPgto);
                cmd.Parameters.AddWithValue("@VlDesc", registroC100.VlDesc);
                cmd.Parameters.AddWithValue("@VlAbatNt", registroC100.VlAbatNt);
                cmd.Parameters.AddWithValue("@VlMerc", registroC100.VlMerc);
                cmd.Parameters.AddWithValue("@IndFrt", registroC100.IndFrt);
                cmd.Parameters.AddWithValue("@VlFrt", registroC100.VlFrt);
                cmd.Parameters.AddWithValue("@VlSeg", registroC100.VlSeg);
                cmd.Parameters.AddWithValue("@VlOutDa", registroC100.VlOutDa);
                cmd.Parameters.AddWithValue("@VlBcIcms", registroC100.VlBcIcms);
                cmd.Parameters.AddWithValue("@VlIcms", registroC100.VlIcms);
                cmd.Parameters.AddWithValue("@VlBcIcmsSt", registroC100.VlBcIcmsSt);
                cmd.Parameters.AddWithValue("@VlIcmsSt", registroC100.VlIcmsSt);
                cmd.Parameters.AddWithValue("@VlIpi", registroC100.VlIpi);
                cmd.Parameters.AddWithValue("@VlPis", registroC100.VlPis);
                cmd.Parameters.AddWithValue("@VlCofins", registroC100.VlCofins);
                cmd.Parameters.AddWithValue("@VlPisSt", registroC100.VlPisSt);
                cmd.Parameters.AddWithValue("@VlCofinsSt", registroC100.VlCofinsSt);
       
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

        public void Incluir_RegC101(RegistroC101 registroC101, int id_reg100)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SPED_REGC101");
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_regc100", id_reg100);
                cmd.Parameters.AddWithValue("@VlFcpUfDest", registroC101.VlFcpUfDest);
                cmd.Parameters.AddWithValue("@VlIcmsUfDest", registroC101.VlIcmsUfDest);
                cmd.Parameters.AddWithValue("@VlIcmsUfRem", registroC101.VlIcmsUfRem);
                conexao.Conectar();
                cmd.CommandTimeout = 900;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Incluir_RegC110(RegistroC110 registroC110, int id_reg100)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SPED_REG110");
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_regc100", id_reg100);
                cmd.Parameters.AddWithValue("@CodInf", registroC110.CodInf);
                cmd.Parameters.AddWithValue("@TxtCompl", registroC110.TxtCompl);
                conexao.Conectar();
                cmd.CommandTimeout = 900;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Incluir_RegC113(RegistroC113 registroC113, int id_reg100)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SPED_REG113");
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_regc100", id_reg100);
                cmd.Parameters.AddWithValue("@IndOper", registroC113.IndOper);
                cmd.Parameters.AddWithValue("@IndEmit", registroC113.IndEmit);
                cmd.Parameters.AddWithValue("@CodPart", registroC113.CodPart);
                cmd.Parameters.AddWithValue("@CodMod", registroC113.CodMod);
                cmd.Parameters.AddWithValue("@Ser", registroC113.Ser);
                cmd.Parameters.AddWithValue("@Sub", registroC113.Sub);
                cmd.Parameters.AddWithValue("@NumDoc", registroC113.NumDoc);
                cmd.Parameters.AddWithValue("@DtDoc", registroC113.DtDoc);
                cmd.Parameters.AddWithValue("@ChvDoc", registroC113.ChvDoc);
                conexao.Conectar();
                cmd.CommandTimeout = 900;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Incluir_RegC170(RegistroC170 registroC170, int id_reg100)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SPED_REG170");
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_regc100", id_reg100);
                cmd.Parameters.AddWithValue("@NumItem", registroC170.NumItem);
                cmd.Parameters.AddWithValue("@CodItem", registroC170.CodItem);
                cmd.Parameters.AddWithValue("@DescrCompl", registroC170.DescrCompl);
                cmd.Parameters.AddWithValue("@Qtd", registroC170.Qtd);
                cmd.Parameters.AddWithValue("@Unid", registroC170.Unid);
                cmd.Parameters.AddWithValue("@VlItem", registroC170.VlItem);

                cmd.Parameters.AddWithValue("@VlDesc", registroC170.VlDesc);

                cmd.Parameters.AddWithValue("@IndMov", registroC170.IndMov);
                cmd.Parameters.AddWithValue("@CstIcms", registroC170.CstIcms);
                cmd.Parameters.AddWithValue("@Cfop", registroC170.Cfop);
                cmd.Parameters.AddWithValue("@CodNat", registroC170.CodNat);
                cmd.Parameters.AddWithValue("@VlBcIcms", registroC170.VlBcIcms);
                cmd.Parameters.AddWithValue("@AliqIcms", registroC170.AliqIcms);

                cmd.Parameters.AddWithValue("@VlIcms", registroC170.VlIcms);
                cmd.Parameters.AddWithValue("@VlBcIcmsSt", registroC170.VlBcIcmsSt);
                cmd.Parameters.AddWithValue("@AliqSt", registroC170.AliqSt);

                cmd.Parameters.AddWithValue("@VlIcmsSt", registroC170.VlBcIcmsSt);

                cmd.Parameters.AddWithValue("@IndApur", registroC170.IndApur);
                cmd.Parameters.AddWithValue("@CstIpi", registroC170.CstIpi);
                cmd.Parameters.AddWithValue("@CodEnq", registroC170.CodEnq);

                cmd.Parameters.AddWithValue("@VlBcIpi", registroC170.VlBcIpi);

                cmd.Parameters.AddWithValue("@AliqIpi", registroC170.AliqIpi);

                cmd.Parameters.AddWithValue("@VlIpi", registroC170.VlIpi);

                cmd.Parameters.AddWithValue("@CstPis", registroC170.CstPis);

                cmd.Parameters.AddWithValue("@VlBcPis", registroC170.VlBcPis);
                cmd.Parameters.AddWithValue("@AliqPis", registroC170.AliqPis);

                cmd.Parameters.AddWithValue("@QuantBcPis", registroC170.QuantBcPis);

                cmd.Parameters.AddWithValue("@AliqPisReais", registroC170.AliqPisReais);

                cmd.Parameters.AddWithValue("@VlPis", registroC170.VlPis);

                cmd.Parameters.AddWithValue("@CstCofins", registroC170.CstCofins);

                cmd.Parameters.AddWithValue("@VlBcCofins", registroC170.VlBcCofins);

                cmd.Parameters.AddWithValue("@AliqCofins", registroC170.AliqCofins);

                cmd.Parameters.AddWithValue("@QuantBcCofins", registroC170.QuantBcCofins);

                cmd.Parameters.AddWithValue("@AliqCofinsReais", registroC170.AliqCofinsReais);

                cmd.Parameters.AddWithValue("@VlCofins", registroC170.VlCofins);
                cmd.Parameters.AddWithValue("@CodCta", registroC170.CodCta);

                cmd.Parameters.AddWithValue("@VlAbatNt", registroC170.VlAbatNt);

                conexao.Conectar();
                cmd.CommandTimeout = 900;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }


        public void Incluir_RegC190(RegistroC190 registroC190, int id_reg100)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SPED_REG190");
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_regc100", id_reg100);
                cmd.Parameters.AddWithValue("@CstIcms", registroC190.CstIcms);
                cmd.Parameters.AddWithValue("@Cfop", registroC190.Cfop);
                cmd.Parameters.AddWithValue("@AliqIcms", registroC190.AliqIcms);
                cmd.Parameters.AddWithValue("@VlOpr", registroC190.VlOpr);

                cmd.Parameters.AddWithValue("@VlBcIcms", registroC190.VlBcIcms);
                cmd.Parameters.AddWithValue("@VlIcms", registroC190.VlIcms);
                cmd.Parameters.AddWithValue("@VlBcIcmsSt", registroC190.VlBcIcmsSt);
                cmd.Parameters.AddWithValue("@VlIcmsSt", registroC190.VlIcmsSt);

                cmd.Parameters.AddWithValue("@VlRedBc", registroC190.VlRedBc);

                cmd.Parameters.AddWithValue("@VlIpi", registroC190.VlIpi);
                cmd.Parameters.AddWithValue("@CodObs", registroC190.CodObs);

                conexao.Conectar();
                cmd.CommandTimeout = 900;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }
    }
}
