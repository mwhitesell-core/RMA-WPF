
#region "Screen Comments"

// program-id. u708.qts
// program purpose: To set the status to  + ompleted if detail and
// header records have valid values or have been
// marked as `D`elete/to be `I`gnored
// MODIFICATION HISTORY
// DATE    SMS # WHO DESCRIPTION
// 90.10.18   000          D.B.    ORIGINAL
// 93.07.21   142  M.C. CHECK ON DIAG-CD-ALPHA,
// NBR-SERV-ALPHA,
// FEE-OMA-ALPHA, FEE-OHIP-ALPHA
// 93.09.20   142          M.C.    ADD THE SELECTION CRITERIA THE
// STATUS NOT EQUAL TO  R  IN THE
// SECOND REQUEST  U708_UPDATE_HEADER 
// 1999/jan/28           B.E.    - y2k 
// 1999/May/27   S.B.    - Added the use file
// def_clmhdr_status.def to 
// prevent hardcoding of clmhdr-status.
// 2000/oct/02  B.E.  - don`t update status to `not complete` if current hdr
// status is `i`gnore or `d`elete.
// 2014/Apr/01 MC1 - include the check of clinic nbr <> 00
// 2016/May/03   MC2     - add a new request to final check to make sure the clinic nbr
// is valid for the doctor 
// 2017/Jan/24   MC3     - include the check of clmdtl-status <> `D` in the first request


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U708 : BaseClassControl
{

    private U708 m_U708;

    public U708(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U708(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U708 != null))
        {
            m_U708.CloseTransactionObjects();
            m_U708 = null;
        }
    }

    public U708 GetU708(int Level)
    {
        if (m_U708 == null)
        {
            m_U708 = new U708("U708", Level);
        }
        else
        {
            m_U708.ResetValues();
        }
        return m_U708;
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

            U708_CHECK_DETAIL_1 CHECK_DETAIL_1 = new U708_CHECK_DETAIL_1(Name, Level);
            CHECK_DETAIL_1.Run();
            CHECK_DETAIL_1.Dispose();
            CHECK_DETAIL_1 = null;

            U708_UPDATE_HEADER_2 UPDATE_HEADER_2 = new U708_UPDATE_HEADER_2(Name, Level);
            UPDATE_HEADER_2.Run();
            UPDATE_HEADER_2.Dispose();
            UPDATE_HEADER_2 = null;

            U708_F708_CHECK_HEADER_3 F708_CHECK_HEADER_3 = new U708_F708_CHECK_HEADER_3(Name, Level);
            F708_CHECK_HEADER_3.Run();
            F708_CHECK_HEADER_3.Dispose();
            F708_CHECK_HEADER_3 = null;

            U708_F708_CHECK_HEADER_CLINIC_4 F708_CHECK_HEADER_CLINIC_4 = new U708_F708_CHECK_HEADER_CLINIC_4(Name, Level);
            F708_CHECK_HEADER_CLINIC_4.Run();
            F708_CHECK_HEADER_CLINIC_4.Dispose();
            F708_CHECK_HEADER_CLINIC_4 = null;

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



public class U708_CHECK_DETAIL_1 : U708
{

    public U708_CHECK_DETAIL_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU708 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U708", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U708_CHECK_DETAIL_1)"

    private SqlFileObject fleF002_SUSPEND_DTL;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) != "D" & (QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD"), 1, 1)) == "?" | QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_SUFF"), 1, 1)) == "?" | QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_AGENT_CD_ALPHA"), 1, 1)) == "?" | QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_NBR_SERV_ALPHA"), 1, 1)) == "?" | QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_SV_YY_ALPHA"), 1, 1)) == "?" | QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_SV_MM_ALPHA"), 1, 1)) == "?" | QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_SV_DD_ALPHA"), 1, 1)) == "?" | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSECUTIVE_SV_DAYS" + (1).ToString())) == "???" | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSECUTIVE_SV_DAYS" + (2).ToString())) == "???" | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSECUTIVE_SV_DAYS" + (3).ToString())) == "???" | QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_FEE_OMA_ALPHA" + (3).ToString()), 1, 1)) == "?" | QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_FEE_OHIP_ALPHA" + (3).ToString()), 1, 1)) == "?" | QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD_ALPHA" + (3).ToString()), 1, 1)) == "?"))
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











    private SqlFileObject fleU708;


    #endregion


    #region "Standard Generated Procedures(U708_CHECK_DETAIL_1)"


    #region "Automatic Item Initialization(U708_CHECK_DETAIL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U708_CHECK_DETAIL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:46 PM

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
        fleF002_SUSPEND_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU708.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U708_CHECK_DETAIL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:46 PM

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
            fleF002_SUSPEND_DTL.Dispose();
            fleU708.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U708_CHECK_DETAIL_1)"


    public void Run()
    {

        try
        {
            Request("CHECK_DETAIL_1");

            while (fleF002_SUSPEND_DTL.QTPForMissing())
            {
                // --> GET F002_SUSPEND_DTL <--

                fleF002_SUSPEND_DTL.GetData();
                // --> End GET F002_SUSPEND_DTL <--


                if (Transaction())
                {

                     if (Select_If())
                    {










                        SubFile(ref m_trnTRANS_UPDATE, ref fleU708, SubFileType.Keep, fleF002_SUSPEND_DTL, "CLMDTL_DOC_OHIP_NBR", "CLMDTL_ACCOUNTING_NBR");



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
            EndRequest("CHECK_DETAIL_1");

        }

    }




    #endregion


}
//CHECK_DETAIL_1



public class U708_UPDATE_HEADER_2 : U708
{

    public U708_UPDATE_HEADER_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU708 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U708", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_SUSPEND_HDR.SetItemFinals += fleF002_SUSPEND_HDR_SetItemFinals;
        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U708_UPDATE_HEADER_2)"

    private SqlFileObject fleU708;
    private SqlFileObject fleF002_SUSPEND_HDR;

    private void fleF002_SUSPEND_HDR_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", CLMHDR_STATUS_NOT_COMPLETE.Value);


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

    private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter("CLMHDR_STATUS_COMPLETE", 1);
    private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "C";


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
    private DCharacter CLMHDR_STATUS_DELETE = new DCharacter("CLMHDR_STATUS_DELETE", 1);
    private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
    {

        try
        {
            Value = "D";


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
    private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter("CLMHDR_STATUS_CANCEL", 1);
    private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
    {

        try
        {
            Value = "Y";


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
    private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter("CLMHDR_STATUS_RESUBMIT", 1);
    private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
    {

        try
        {
            Value = "R";


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
    private DCharacter CLMHDR_STATUS_ERROR = new DCharacter("CLMHDR_STATUS_ERROR", 1);
    private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
    {

        try
        {
            Value = "X";


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
    private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter("CLMHDR_STATUS_NOT_COMPLETE", 1);
    private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter("CLMHDR_STATUS_DEFAULT", 1);
    private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter UPDATED = new DCharacter("UPDATED", 1);
    private void UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
    private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter("CLMHDR_STATUS_IGNOR", 1);
    private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
    {

        try
        {
            Value = "I";


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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_ERROR.Value) & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_RESUBMIT.Value) & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_DELETE.Value) & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_IGNOR.Value))
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


    #endregion


    #region "Standard Generated Procedures(U708_UPDATE_HEADER_2)"


    #region "Automatic Item Initialization(U708_UPDATE_HEADER_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U708_UPDATE_HEADER_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:46 PM

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
        fleU708.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U708_UPDATE_HEADER_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:46 PM

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
            fleU708.Dispose();
            fleF002_SUSPEND_HDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U708_UPDATE_HEADER_2)"


    public void Run()
    {

        try
        {
            Request("UPDATE_HEADER_2");

            while (fleU708.QTPForMissing())
            {
                // --> GET U708 <--

                fleU708.GetData();
                // --> End GET U708 <--

                while (fleF002_SUSPEND_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleU708.GetDecimalValue("CLMDTL_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU708.GetStringValue("CLMDTL_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_HDR <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {










                            fleF002_SUSPEND_HDR.OutPut(OutPutType.Update);


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
            EndRequest("UPDATE_HEADER_2");

        }

    }




    #endregion


}
//UPDATE_HEADER_2



public class U708_F708_CHECK_HEADER_3 : U708
{

    public U708_F708_CHECK_HEADER_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_SUSPEND_HDR.SetItemFinals += fleF002_SUSPEND_HDR_SetItemFinals;
        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U708_F708_CHECK_HEADER_3)"

    private SqlFileObject fleF002_SUSPEND_HDR;

    private void fleF002_SUSPEND_HDR_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", CLMHDR_STATUS_COMPLETE.Value);


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

    private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter("CLMHDR_STATUS_COMPLETE", 1);
    private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "C";


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
    private DCharacter CLMHDR_STATUS_DELETE = new DCharacter("CLMHDR_STATUS_DELETE", 1);
    private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
    {

        try
        {
            Value = "D";


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
    private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter("CLMHDR_STATUS_CANCEL", 1);
    private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
    {

        try
        {
            Value = "Y";


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
    private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter("CLMHDR_STATUS_RESUBMIT", 1);
    private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
    {

        try
        {
            Value = "R";


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
    private DCharacter CLMHDR_STATUS_ERROR = new DCharacter("CLMHDR_STATUS_ERROR", 1);
    private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
    {

        try
        {
            Value = "X";


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
    private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter("CLMHDR_STATUS_NOT_COMPLETE", 1);
    private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter("CLMHDR_STATUS_DEFAULT", 1);
    private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter UPDATED = new DCharacter("UPDATED", 1);
    private void UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
    private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter("CLMHDR_STATUS_IGNOR", 1);
    private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
    {

        try
        {
            Value = "I";


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
            if ((QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_DEFAULT.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(UPDATED.Value)) & QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_CLINIC_NBR_1_2")) != 0 & QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_REFER_DOC_NBR_ALPHA"), 1, 1)) != "?" & QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_DIAG_CD_ALPHA"), 1, 1)) != "?" & QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_LOC"), 1, 1)) != "?" & QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_HOSP"), 1, 1)) != "?" & QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_AGENT_CD_ALPHA"), 1, 1)) != "?" & QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_I_O_PAT_IND"), 1, 1)) != "?" & QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE"), 1, 1)) != "?" & QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE"), 1, 1)) != "O" & QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_DOC_SPEC_CD_ALPHA"), 1, 1)) != "?" & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_MSG_NBR")) != "?" & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_REPRINT_FLAG")) != "?" & QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_SUB_NBR"), 1, 1)) != "?" & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_AUTO_LOGOUT")) != "?" & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_FEE_COMPLEX")) != "?" & QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_DATE_ADMIT"), 1, 1)) != "?")
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




    #endregion


    #region "Standard Generated Procedures(U708_F708_CHECK_HEADER_3)"


    #region "Automatic Item Initialization(U708_F708_CHECK_HEADER_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U708_F708_CHECK_HEADER_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:46 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U708_F708_CHECK_HEADER_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:46 PM

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
            fleF002_SUSPEND_HDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U708_F708_CHECK_HEADER_3)"


    public void Run()
    {

        try
        {
            Request("F708_CHECK_HEADER_3");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--

                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--


                if (Transaction())
                {

                     if (Select_If())
                    {










                        fleF002_SUSPEND_HDR.OutPut(OutPutType.Update);


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
            EndRequest("F708_CHECK_HEADER_3");

        }

    }




    #endregion


}
//F708_CHECK_HEADER_3



public class U708_F708_CHECK_HEADER_CLINIC_4 : U708
{

    public U708_F708_CHECK_HEADER_CLINIC_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU708_INVALID_CLINIC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U708_INVALID_CLINIC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_SUSPEND_HDR.SetItemFinals += fleF002_SUSPEND_HDR_SetItemFinals;
        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U708_F708_CHECK_HEADER_CLINIC_4)"

    private SqlFileObject fleF002_SUSPEND_HDR;

    private void fleF002_SUSPEND_HDR_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", CLMHDR_STATUS_ERROR.Value);


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

    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter("CLMHDR_STATUS_COMPLETE", 1);
    private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "C";


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
    private DCharacter CLMHDR_STATUS_DELETE = new DCharacter("CLMHDR_STATUS_DELETE", 1);
    private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
    {

        try
        {
            Value = "D";


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
    private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter("CLMHDR_STATUS_CANCEL", 1);
    private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
    {

        try
        {
            Value = "Y";


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
    private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter("CLMHDR_STATUS_RESUBMIT", 1);
    private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
    {

        try
        {
            Value = "R";


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
    private DCharacter CLMHDR_STATUS_ERROR = new DCharacter("CLMHDR_STATUS_ERROR", 1);
    private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
    {

        try
        {
            Value = "X";


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
    private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter("CLMHDR_STATUS_NOT_COMPLETE", 1);
    private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
    private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter("CLMHDR_STATUS_DEFAULT", 1);
    private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DCharacter UPDATED = new DCharacter("UPDATED", 1);
    private void UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "U";


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
    private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter("CLMHDR_STATUS_IGNOR", 1);
    private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
    {

        try
        {
            Value = "I";


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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_COMPLETE.Value) & (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_CLINIC_NBR_1_2")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR"))) & (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_CLINIC_NBR_1_2")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_2"))) & (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_CLINIC_NBR_1_2")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_3"))) & (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_CLINIC_NBR_1_2")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_4"))) & (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_CLINIC_NBR_1_2")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_5"))) & (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_CLINIC_NBR_1_2")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_6"))))
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











    private SqlFileObject fleU708_INVALID_CLINIC;


    #endregion


    #region "Standard Generated Procedures(U708_F708_CHECK_HEADER_CLINIC_4)"


    #region "Automatic Item Initialization(U708_F708_CHECK_HEADER_CLINIC_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U708_F708_CHECK_HEADER_CLINIC_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:46 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU708_INVALID_CLINIC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U708_F708_CHECK_HEADER_CLINIC_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:46 PM

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
            fleF002_SUSPEND_HDR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleU708_INVALID_CLINIC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U708_F708_CHECK_HEADER_CLINIC_4)"


    public void Run()
    {

        try
        {
            Request("F708_CHECK_HEADER_CLINIC_4");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--

                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {










                            SubFile(ref m_trnTRANS_UPDATE, ref fleU708_INVALID_CLINIC, SubFileType.Keep, fleF002_SUSPEND_HDR);












                            fleF002_SUSPEND_HDR.OutPut(OutPutType.Update);


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
            EndRequest("F708_CHECK_HEADER_CLINIC_4");

        }

    }




    #endregion


}
//F708_CHECK_HEADER_CLINIC_4




