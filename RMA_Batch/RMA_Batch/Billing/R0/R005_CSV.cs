
#region "Screen Comments"

// DOC: R005_CSV.QTS
// DOC: MONTHLY CASH APPLIED RECONCILIATION
// DOC: SORT BY CLINIC
// DOC: RUN FOR: Ross  
// PROGRAM PURPOSE : CASH ANALYSIS BY CLINIC   (DETAIL REPORT)
// DATE           WHO       DESCRIPTION
// 2015/Jun/16 MC   ORIGINAL (first pass)


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class R005_CSV : BaseClassControl
{

    private R005_CSV m_R005_CSV;

    public R005_CSV(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF051_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
         fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        AGENT_MTD_AMT = new CoreDecimal("AGENT_MTD_AMT", 10, this);
        AGENT_YTD_AMT = new CoreDecimal("AGENT_YTD_AMT", 10, this);
        DEPT_MTD_AMT = new CoreDecimal("DEPT_MTD_AMT", 10, this);
        DEPT_YTD_AMT = new CoreDecimal("DEPT_YTD_AMT", 10, this);
        fleR005_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R005_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleR005_SUMM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R005_SUMM", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_MONTHEND.GetValue += X_MONTHEND_GetValue;

    }

    public R005_CSV(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF051_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
         fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        AGENT_MTD_AMT = new CoreDecimal("AGENT_MTD_AMT", 10, this);
        AGENT_YTD_AMT = new CoreDecimal("AGENT_YTD_AMT", 10, this);
        DEPT_MTD_AMT = new CoreDecimal("DEPT_MTD_AMT", 10, this);
        DEPT_YTD_AMT = new CoreDecimal("DEPT_YTD_AMT", 10, this);
        fleR005_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R005_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleR005_SUMM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R005_SUMM", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_MONTHEND.GetValue += X_MONTHEND_GetValue;

    }

    public override void Dispose()
    {
        if ((m_R005_CSV != null))
        {
            m_R005_CSV.CloseTransactionObjects();
            m_R005_CSV = null;
        }
    }

    public R005_CSV GetR005_CSV(int Level)
    {
        if (m_R005_CSV == null)
        {
            m_R005_CSV = new R005_CSV("R005_CSV", Level);
        }
        else
        {
            m_R005_CSV.ResetValues();
        }
        return m_R005_CSV;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleF051_DOC_CASH_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    private SqlFileObject fleF070_DEPT_MSTR;
    private DCharacter X_MONTHEND = new DCharacter("X_MONTHEND", 1);
    private void X_MONTHEND_GetValue(ref string Value)
    {

        try
        {
            Value = Prompt(1).ToString();


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(X_MONTHEND.Value) == QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_MONTHEND")))
            {
                return true;
            }

            return false;


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

    private CoreDecimal AGENT_MTD_AMT;
    private CoreDecimal AGENT_YTD_AMT;
    private CoreDecimal DEPT_MTD_AMT;
    private CoreDecimal DEPT_YTD_AMT;
    private SqlFileObject fleR005_DTL;
    private SqlFileObject fleR005_SUMM;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("R005_CSV");

            while (fleF051_DOC_CASH_MSTR.QTPForMissing())
            {
                // --> GET F051_DOC_CASH_MSTR <--

                fleF051_DOC_CASH_MSTR.GetData();
                // --> End GET F051_DOC_CASH_MSTR <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(fleF051_DOC_CASH_MSTR.GetStringValue("DOCASH_CLINIC_1_2"))));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET ICONST_MSTR_REC <--

                    while (fleF070_DEPT_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F070_DEPT_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ");
                        m_strWhere.Append((fleF051_DOC_CASH_MSTR.GetDecimalValue("DOCASH_DEPT")));

                        fleF070_DEPT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F070_DEPT_MSTR <--


                        if (Transaction())
                        {

                             if (Select_If())
                            {

                                Sort(fleF051_DOC_CASH_MSTR.GetSortValue("DOCASH_CLINIC_1_2"), fleF051_DOC_CASH_MSTR.GetSortValue("DOCASH_DEPT"), fleF051_DOC_CASH_MSTR.GetSortValue("DOCASH_DOC_NBR"), fleF051_DOC_CASH_MSTR.GetSortValue("DOCASH_AGENCY_TYPE"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleF051_DOC_CASH_MSTR, fleICONST_MSTR_REC, fleF070_DEPT_MSTR))
            {
                AGENT_MTD_AMT.Value = AGENT_MTD_AMT.Value + fleF051_DOC_CASH_MSTR.GetDecimalValue("DOCASH_MTD_IN_REC");
                AGENT_YTD_AMT.Value = AGENT_YTD_AMT.Value + fleF051_DOC_CASH_MSTR.GetDecimalValue("DOCASH_YTD_IN_REC");
                DEPT_MTD_AMT.Value = DEPT_MTD_AMT.Value + fleF051_DOC_CASH_MSTR.GetDecimalValue("DOCASH_MTD_IN_REC");
                DEPT_YTD_AMT.Value = DEPT_YTD_AMT.Value + fleF051_DOC_CASH_MSTR.GetDecimalValue("DOCASH_YTD_IN_REC");

                SubFile(ref m_trnTRANS_UPDATE, ref fleR005_DTL, fleF051_DOC_CASH_MSTR.At("DOCASH_CLINIC_1_2") || fleF051_DOC_CASH_MSTR.At("DOCASH_DEPT") || fleF051_DOC_CASH_MSTR.At("DOCASH_DOC_NBR") || fleF051_DOC_CASH_MSTR.At("DOCASH_AGENCY_TYPE"), SubFileType.Keep, fleF051_DOC_CASH_MSTR, "DOCASH_CLINIC_1_2", "DOCASH_DEPT", fleF070_DEPT_MSTR, "DEPT_COMPANY", fleF051_DOC_CASH_MSTR,
                "DOCASH_DOC_NBR", "DOCASH_AGENCY_TYPE", AGENT_MTD_AMT, AGENT_YTD_AMT);

                SubFile(ref m_trnTRANS_UPDATE, ref fleR005_SUMM, fleF051_DOC_CASH_MSTR.At("DOCASH_CLINIC_1_2") || fleF051_DOC_CASH_MSTR.At("DOCASH_DEPT"), SubFileType.Keep, fleF051_DOC_CASH_MSTR, "DOCASH_CLINIC_1_2", "DOCASH_DEPT", fleF070_DEPT_MSTR, "DEPT_COMPANY", DEPT_MTD_AMT,
                DEPT_YTD_AMT);


                Reset(ref AGENT_MTD_AMT, fleF051_DOC_CASH_MSTR.At("DOCASH_CLINIC_1_2") || fleF051_DOC_CASH_MSTR.At("DOCASH_DEPT") || fleF051_DOC_CASH_MSTR.At("DOCASH_DOC_NBR") || fleF051_DOC_CASH_MSTR.At("DOCASH_AGENCY_TYPE"));
                Reset(ref AGENT_YTD_AMT, fleF051_DOC_CASH_MSTR.At("DOCASH_CLINIC_1_2") || fleF051_DOC_CASH_MSTR.At("DOCASH_DEPT") || fleF051_DOC_CASH_MSTR.At("DOCASH_DOC_NBR") || fleF051_DOC_CASH_MSTR.At("DOCASH_AGENCY_TYPE"));
                Reset(ref DEPT_MTD_AMT, fleF051_DOC_CASH_MSTR.At("DOCASH_CLINIC_1_2") || fleF051_DOC_CASH_MSTR.At("DOCASH_DEPT"));
                Reset(ref DEPT_YTD_AMT, fleF051_DOC_CASH_MSTR.At("DOCASH_CLINIC_1_2") || fleF051_DOC_CASH_MSTR.At("DOCASH_DEPT"));

            }



        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);


        }
        finally
        {
            EndRequest("R005_CSV");

        }

    }


    #region "Standard Generated Procedures(R005_CSV_R005_CSV)"

    #region "Transaction Management Procedures(R005_CSV_R005_CSV)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:04 PM

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
        fleF051_DOC_CASH_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF070_DEPT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleR005_DTL.Transaction = m_trnTRANS_UPDATE;
        fleR005_SUMM.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R005_CSV_R005_CSV)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:04 PM

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
            fleF051_DOC_CASH_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF070_DEPT_MSTR.Dispose();
            fleR005_DTL.Dispose();
            fleR005_SUMM.Dispose();


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


    public override bool RunQTP()
    {


        try
        {

            Run();

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

