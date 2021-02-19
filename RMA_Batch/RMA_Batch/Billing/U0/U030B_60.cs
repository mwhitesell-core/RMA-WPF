
#region "Screen Comments"

// #> PROGRAM-ID.     U030B_60.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : THIRD  PASS OF U030 - ONLY FOR CLINIC 60
// THIS IS THE MAIN PROGRAM OF THE ORIGINAL
// U030.CB
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 91/FEB/20 M.C.         - ORIGINAL (SMS 138)
// 91/OCT/08 M.C.      - PDR 520 - TAKE OUT SECOND REQUEST
// - IT IS INCLUDED IN U030B.QTS
// 92/JUL/20 M.C.      - SMS 139 - INCLUDE CLINIC 61 TO 65
// 96/OCT/09 M.C.      - USE `CLMHDR-AGENT-CD` INSTEAD OF `0`
// TO LINK F051TP-DOC-CASH-MSTR
// 97/DEC/03 M.C.      - PDR 663 - SUBSTITUTE RAT-145-GROUP-NBR
// TO X-GROUP-NBR
// 03/Jan/06 M.C.      - alpha doc nbr
// 07/May/09 M.C.      - include clinic 71 to 75
// 2010/feb/10 MC1      - include clinic 66 
// 2014/Mar/06 MC2      - add set lock record update
// MC2
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U030B_60 : BaseClassControl
{

    private U030B_60 m_U030B_60;

    public U030B_60(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U030B_60(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U030B_60 != null))
        {
            m_U030B_60.CloseTransactionObjects();
            m_U030B_60 = null;
        }
    }

    public U030B_60 GetU030B_60(int Level)
    {
        if (m_U030B_60 == null)
        {
            m_U030B_60 = new U030B_60("U030B_60", Level);
        }
        else
        {
            m_U030B_60.ResetValues();
        }
        return m_U030B_60;
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

            U030B_60_UPDATE_AMT_PAID_1 UPDATE_AMT_PAID_1 = new U030B_60_UPDATE_AMT_PAID_1(Name, Level);
            UPDATE_AMT_PAID_1.Run();
            UPDATE_AMT_PAID_1.Dispose();
            UPDATE_AMT_PAID_1 = null;

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



public class U030B_60_UPDATE_AMT_PAID_1 : U030B_60
{

    public U030B_60_UPDATE_AMT_PAID_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_PAID_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_PAID_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF051TP_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051TP_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
        X_TECH_PAID.GetValue += X_TECH_PAID_GetValue;
        X_PROF_PAID.GetValue += X_PROF_PAID_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_60_UPDATE_AMT_PAID_1)"

    private SqlFileObject fleU030_PAID_AMT;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_AMT_TECH_PAID", X_TECH_PAID.Value);


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

    private DInteger X_TECH_PAID = new DInteger("X_TECH_PAID", 7);
    private void X_TECH_PAID_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = (fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED") * fleU030_PAID_AMT.GetDecimalValue("X_TOT_AMT_PAID")) / fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");


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
    private DInteger X_PROF_PAID = new DInteger("X_PROF_PAID", 7);
    private void X_PROF_PAID_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleU030_PAID_AMT.GetDecimalValue("X_TOT_AMT_PAID") - X_TECH_PAID.Value;


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
    private SqlFileObject fleF051TP_DOC_CASH_MSTR;


    #endregion


    #region "Standard Generated Procedures(U030B_60_UPDATE_AMT_PAID_1)"


    #region "Automatic Item Initialization(U030B_60_UPDATE_AMT_PAID_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_60_UPDATE_AMT_PAID_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:45 PM

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
        fleU030_PAID_AMT.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF051TP_DOC_CASH_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_60_UPDATE_AMT_PAID_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:45 PM

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
            fleU030_PAID_AMT.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF051TP_DOC_CASH_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_60_UPDATE_AMT_PAID_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_AMT_PAID_1");

            while (fleU030_PAID_AMT.QTPForMissing())
            {
                // --> GET U030_PAID_AMT <--

                fleU030_PAID_AMT.GetData();
                // --> End GET U030_PAID_AMT <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR") + QDesign.Substring(fleU030_PAID_AMT.GetStringValue("RAT_145_ACCOUNT_NBR"), 1, 6))));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_PAID_AMT.GetStringValue("RAT_145_ACCOUNT_NBR"), 7, 2))));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {
                        fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update);


                        while (fleF051TP_DOC_CASH_MSTR.QTPForMissing())
                        {
                            // --> GET F051TP_DOC_CASH_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF051TP_DOC_CASH_MSTR.ElementOwner("DOCASHTP_KEY")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD"), 1) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_LOC") + QDesign.Substring(fleU030_PAID_AMT.GetStringValue("RAT_145_ACCOUNT_NBR"), 1, 3)));

                            m_strOrderBy = new StringBuilder(" ORDER BY ");
                            m_strOrderBy.Append(fleF051TP_DOC_CASH_MSTR.ElementOwner("DOCASHTP_KEY"));

                            fleF051TP_DOC_CASH_MSTR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                            // --> End GET F051TP_DOC_CASH_MSTR <--



                            SubTotal(ref fleF051TP_DOC_CASH_MSTR, "DOCASHTP_TECH_OUT_MTD", X_TECH_PAID.Value);


                            SubTotal(ref fleF051TP_DOC_CASH_MSTR, "DOCASHTP_TECH_OUT_YTD", X_TECH_PAID.Value);


                            SubTotal(ref fleF051TP_DOC_CASH_MSTR, "DOCASHTP_PROF_OUT_MTD", X_PROF_PAID.Value);


                            SubTotal(ref fleF051TP_DOC_CASH_MSTR, "DOCASHTP_PROF_OUT_YTD", X_PROF_PAID.Value);

                            fleF051TP_DOC_CASH_MSTR.OutPut(OutPutType.Add_Update, null, QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "60" | QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "61" | QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "62" | QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "63" | QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "64" | QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "65" | QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "66" | QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "71" | QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "72" | QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "73" | QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "74" | QDesign.NULL(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR")) == "75");

                        }


                    }

                }

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
            EndRequest("UPDATE_AMT_PAID_1");

        }

    }







    #endregion


}
//UPDATE_AMT_PAID_1




