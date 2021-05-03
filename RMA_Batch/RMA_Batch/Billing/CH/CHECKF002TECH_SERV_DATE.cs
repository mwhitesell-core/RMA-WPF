
#region "Screen Comments"

// 2010/Nov/03 M.C. - check  clmdtl-amt-tech-billed from all details including
// adjust detail to see if match with clmhdr-amt-tech-billed.
// - check if clmhdr-serv-date = 0


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

public class CHECKF002TECH_SERV_DATE : BaseClassControl
{
    private CHECKF002TECH_SERV_DATE m_CHECKF002TECH_SERV_DATE;

    public CHECKF002TECH_SERV_DATE(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public CHECKF002TECH_SERV_DATE(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if ((m_CHECKF002TECH_SERV_DATE != null))
        {
            m_CHECKF002TECH_SERV_DATE.CloseTransactionObjects();
            m_CHECKF002TECH_SERV_DATE = null;
        }
    }

    public CHECKF002TECH_SERV_DATE GetCHECKF002TECH_SERV_DATE(int Level)
    {
        if (m_CHECKF002TECH_SERV_DATE == null)
        {
            m_CHECKF002TECH_SERV_DATE = new CHECKF002TECH_SERV_DATE("CHECKF002TECH_SERV_DATE", Level);
        }
        else
        {
            m_CHECKF002TECH_SERV_DATE.ResetValues();
        }
        return m_CHECKF002TECH_SERV_DATE;
    }

    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;

    #endregion

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {
        try
        {
            CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1 EXTRACT_CLAIM_CLMHDR_1 = new CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1(Name, Level);
            EXTRACT_CLAIM_CLMHDR_1.Run();
            EXTRACT_CLAIM_CLMHDR_1.Dispose();
            EXTRACT_CLAIM_CLMHDR_1 = null;

            return true;
        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;
        }
        catch (Exception ex)
        {
            WriteError(ex);
            return false;
        }
    }

    #endregion

    #endregion

}

public class CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1 : CHECKF002TECH_SERV_DATE
{
    public CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    #region "Standard Generated Procedures(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1)"
    
    #region "Automatic Item Initialization(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:15 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {

        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetSqlConnectionString());


        }
        catch (CustomApplicationException ex)
        {
            throw ex;


        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;

        }

    }

    //#-----------------------------------------
    //# CloseTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void CloseTransactionObjects()
    {

        try
        {
            CloseFiles();

            if ((m_trnTRANS_UPDATE != null))
                m_trnTRANS_UPDATE.Dispose();
            if ((m_cnnTRANS_UPDATE != null))
                m_cnnTRANS_UPDATE.Close();
            if ((m_cnnTRANS_UPDATE != null))
                m_cnnTRANS_UPDATE.Dispose();
            if ((m_cnnQUERY != null))
                m_cnnQUERY.Close();
            if ((m_cnnQUERY != null))
                m_cnnQUERY.Dispose();


        }
        catch (CustomApplicationException ex)
        {
            throw ex;


        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;

        }

    }


    protected override void TRANS_UPDATE(TransactionMethods Method)
    {
        if (Method == TransactionMethods.Rollback)
        {
            m_trnTRANS_UPDATE.Rollback();
        }
        else
        {
            m_trnTRANS_UPDATE.Commit();
        }

        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        Initialize_TRANS_UPDATE();

    }


    private void Initialize_TRANS_UPDATE()
    {
        //fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        //fleEXTF002HDR.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion
    
    #region "FILE Management Procedures(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:15 PM

    //#-----------------------------------------
    //# InitializeFiles Procedure.
    //#-----------------------------------------

    protected override void InitializeFiles()
    {

        try
        {
            Initialize_TRANS_UPDATE();


        }
        catch (CustomApplicationException ex)
        {
            throw ex;


        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;

        }

    }

    //#-----------------------------------------
    //# CloseFiles Procedure.
    //#-----------------------------------------

    protected override void CloseFiles()
    {

        try
        {
            //fleF002_CLAIMS_MSTR.Dispose();
            //fleEXTF002HDR.Dispose();


        }
        catch (CustomApplicationException ex)
        {
            throw ex;


        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;

        }

    }

    #endregion

    #endregion

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1)"
    public void Run()
    {
        Int64 F002_CLAIMS_MSTR_HDR_COUNT = 0;
        Int64 F002_CLAIMS_MSTR_DTL_COUNT = 0;
        Int64 EXTF002HDR_COUNT = 0;
        Int64 F002_ORIG_DTL_COUNT = 0;
        Int64 DIFF_AMTS_SEL_COUNT = 0;
        Int64 DIFF_SV_DATE_SEL_COUNT = 0;
        DateTime START_TIME_REQUEST1;
        DateTime END_TIME_REQUEST1;
        DateTime START_TIME_REQUEST2;
        DateTime END_TIME_REQUEST2;
        DateTime START_TIME_REQUEST3;
        DateTime END_TIME_REQUEST3;
        string log_file = string.Empty;

        try
        {
            Request("EXTRACT_CLAIM_CLMHDR_1");

            log_file = Directory.GetCurrentDirectory() + "\\CHECKF002TECH_SERV_DATE.log";

            //Write output to log file
            if (File.Exists(log_file))
            {
                File.Delete(log_file);
            }

            using (SqlConnection conn = new SqlConnection(Common.GetSqlConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("INDEXED.sp_CHECKF002TECH_SERV_DATE", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@outF002_CLAIMS_MSTR_HDR_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outF002_CLAIMS_MSTR_DTL_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outEXTF002HDR_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outF002_ORIG_DTL_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outDIFF_AMTS_SEL_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outDIFF_SV_DATE_SEL_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outSTART_TIME_REQUEST1", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outEND_TIME_REQUEST1", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outSTART_TIME_REQUEST2", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outEND_TIME_REQUEST2", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outSTART_TIME_REQUEST3", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outEND_TIME_REQUEST3", SqlDbType.DateTime).Direction = ParameterDirection.Output;
                    cmd.CommandTimeout = 0;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    F002_CLAIMS_MSTR_HDR_COUNT = (Int64)cmd.Parameters["@outF002_CLAIMS_MSTR_HDR_COUNT"].Value;
                    F002_CLAIMS_MSTR_DTL_COUNT = (Int64)cmd.Parameters["@outF002_CLAIMS_MSTR_DTL_COUNT"].Value;
                    EXTF002HDR_COUNT = (Int64)cmd.Parameters["@outEXTF002HDR_COUNT"].Value;
                    F002_ORIG_DTL_COUNT = (Int64)cmd.Parameters["@outF002_ORIG_DTL_COUNT"].Value;
                    DIFF_AMTS_SEL_COUNT = (Int64)cmd.Parameters["@outDIFF_AMTS_SEL_COUNT"].Value;
                    DIFF_SV_DATE_SEL_COUNT = (Int64)cmd.Parameters["@outDIFF_SV_DATE_SEL_COUNT"].Value;
                    START_TIME_REQUEST1 = (DateTime)cmd.Parameters["@outSTART_TIME_REQUEST1"].Value;
                    END_TIME_REQUEST1 = (DateTime)cmd.Parameters["@outEND_TIME_REQUEST1"].Value;
                    START_TIME_REQUEST2 = (DateTime)cmd.Parameters["@outSTART_TIME_REQUEST2"].Value;
                    END_TIME_REQUEST2 = (DateTime)cmd.Parameters["@outEND_TIME_REQUEST2"].Value;
                    START_TIME_REQUEST3 = (DateTime)cmd.Parameters["@outSTART_TIME_REQUEST2"].Value;
                    END_TIME_REQUEST3 = (DateTime)cmd.Parameters["@outEND_TIME_REQUEST2"].Value;

                    StreamWriter sw = new StreamWriter(log_file, true, System.Text.Encoding.Default);
                    sw.WriteLine("Run:     CHECKF002TECH_SERV_DATE");
                    sw.WriteLine("Request: EXTRACT_CLAIM_CLMHDR     " + START_TIME_REQUEST1.ToString("dd/MM/yyyy h:mm:ss tt"));
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("Records read:");
                    sw.WriteLine("  F002_CLAIMS_MSTR_HDR            " + F002_CLAIMS_MSTR_HDR_COUNT.ToString().PadLeft(10, ' '));
                    sw.WriteLine("");
                    sw.WriteLine("Transactions Processed:           " + F002_CLAIMS_MSTR_HDR_COUNT.ToString().PadLeft(10, ' '));
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("Records processed:                Added     Updated     Unchanged     Deleted");
                    sw.WriteLine("  EXTF002HDR" + " ".PadLeft(27 - EXTF002HDR_COUNT.ToString().Trim().Length, ' ') + EXTF002HDR_COUNT.ToString().Trim() + " ".PadLeft(11, ' ') + "0" + " ".PadLeft(13, ' ') + "0" + " ".PadLeft(11, ' ') + "0");
                    sw.WriteLine("");
                    sw.WriteLine("End Request: EXTRACT_CLAIM_CLMHDR " + END_TIME_REQUEST1.ToString("dd/MM/yyyy h:mm:ss tt"));
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("Run:     CHECKF002TECH_SERV_DATE");
                    sw.WriteLine("Request: EXTRACT_CLAIM_CLMDTL     " + START_TIME_REQUEST2.ToString("dd/MM/yyyy h:mm:ss tt"));
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("Records read:");
                    sw.WriteLine("  EXTF002HDR                      " + EXTF002HDR_COUNT.ToString().PadLeft(10, ' '));
                    sw.WriteLine("  F002_CLAIMS_MSTR_DTL            " + F002_CLAIMS_MSTR_DTL_COUNT.ToString().PadLeft(10, ' '));
                    sw.WriteLine("");
                    sw.WriteLine("Transactions Processed:           " + F002_CLAIMS_MSTR_DTL_COUNT.ToString().PadLeft(10, ' '));
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("Records processed:                Added     Updated     Unchanged     Deleted");
                    sw.WriteLine("  F002_ORIG_DTL" + " ".PadLeft(24 - F002_ORIG_DTL_COUNT.ToString().Trim().Length, ' ') + F002_ORIG_DTL_COUNT.ToString().Trim() + " ".PadLeft(11, ' ') + "0" + " ".PadLeft(13, ' ') + "0" + " ".PadLeft(11, ' ') + "0");
                    sw.WriteLine("");
                    sw.WriteLine("End Request: EXTRACT_CLAIM_CLMDTL      " + END_TIME_REQUEST2.ToString("dd/MM/yyyy h:mm:ss tt"));
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("Run:     CHECKF002TECH_SERV_DATE");
                    sw.WriteLine("Request: SEL_DIFF_TECH_SERV_DATE       " + START_TIME_REQUEST3.ToString("dd/MM/yyyy h:mm:ss tt"));
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("Records read:");
                    sw.WriteLine("  F002_ORIG_DTL                   " + F002_ORIG_DTL_COUNT.ToString().PadLeft(10, ' '));
                    sw.WriteLine("");
                    sw.WriteLine("Transactions Processed:           " + F002_ORIG_DTL_COUNT.ToString().PadLeft(10, ' '));
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("Records processed:                Added     Updated     Unchanged     Deleted");
                    sw.WriteLine("  DIFF_AMTS_SEL" + " ".PadLeft(24 - DIFF_AMTS_SEL_COUNT.ToString().Trim().Length, ' ') + DIFF_AMTS_SEL_COUNT.ToString().Trim() + " ".PadLeft(11, ' ') + "0" + " ".PadLeft(13, ' ') + "0" + " ".PadLeft(11, ' ') + "0");
                    sw.WriteLine("  DIFF_SV_DATE_SEL" + " ".PadLeft(21 - DIFF_SV_DATE_SEL_COUNT.ToString().Trim().Length, ' ') + DIFF_SV_DATE_SEL_COUNT.ToString().Trim() + " ".PadLeft(11, ' ') + "0" + " ".PadLeft(13, ' ') + "0" + " ".PadLeft(11, ' ') + "0");
                    sw.WriteLine("");
                    sw.WriteLine("End Request: EXTRACT_CLAIM_CLMDTL      " + END_TIME_REQUEST3.ToString("dd/MM/yyyy h:mm:ss tt"));

                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
        catch (CustomApplicationException ex)
        {
            StreamWriter sw = new StreamWriter(log_file, true, System.Text.Encoding.Default);
            sw.WriteLine(ex.Message);
            sw.Flush();
            sw.Close();
            sw.Dispose();

            WriteError(ex);
        }
        catch (Exception ex)
        {
            StreamWriter sw = new StreamWriter(log_file, true, System.Text.Encoding.Default);
            sw.WriteLine(ex.Message);
            sw.Flush();
            sw.Close();
            sw.Dispose();

            WriteError(ex);
        }
        finally
        {
            var sr = new StreamReader(log_file);
            var stats = sr.ReadToEnd();
            Console.WriteLine(stats);
            sr.Dispose();

            File.Delete(log_file);
        }
    }

    #endregion
}
//EXTRACT_CLAIM_CLMHDR_1




