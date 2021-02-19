
#region "Screen Comments"

// Program: u716a
// Purpose: The service date may have been updated in the suspend-dtl
// file. For web claims this date is the same on all detail records.
// This pgm creates a subfile with only 1 detail record per claim
// that contains the key info (doc nbr + accounting nbr) and the
// service date. This subfile then becomes the driver file for
// accessing the header file and creating the r716a header file
// for upload to the web. The service date becomes the visit header`s
// visit date.
// Modification History
// YY/MMM/DD  By whom    Why
// 00/oct/03  B.E. - original
// 00/oct/10  B.E. - send back deleted claims to web


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U716A : BaseClassControl
{

    private U716A m_U716A;

    public U716A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU716A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U716A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;
        CLMDTL_STATUS_DELETE.GetValue += CLMDTL_STATUS_DELETE_GetValue;
        CLMDTL_STATUS_NEW.GetValue += CLMDTL_STATUS_NEW_GetValue;
        CLMDTL_STATUS_ACTIVE.GetValue += CLMDTL_STATUS_ACTIVE_GetValue;
        CLMDTL_STATUS_UPDATED.GetValue += CLMDTL_STATUS_UPDATED_GetValue;
        CLMDTL_SV_DATE.GetValue += CLMDTL_SV_DATE_GetValue;

    }

    public U716A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU716A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U716A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;
        CLMDTL_STATUS_DELETE.GetValue += CLMDTL_STATUS_DELETE_GetValue;
        CLMDTL_STATUS_NEW.GetValue += CLMDTL_STATUS_NEW_GetValue;
        CLMDTL_STATUS_ACTIVE.GetValue += CLMDTL_STATUS_ACTIVE_GetValue;
        CLMDTL_STATUS_UPDATED.GetValue += CLMDTL_STATUS_UPDATED_GetValue;
        CLMDTL_SV_DATE.GetValue += CLMDTL_SV_DATE_GetValue;

    }

    public override void Dispose()
    {
        if ((m_U716A != null))
        {
            m_U716A.CloseTransactionObjects();
            m_U716A = null;
        }
    }

    public U716A GetU716A(int Level)
    {
        if (m_U716A == null)
        {
            m_U716A = new U716A("U716A", Level);
        }
        else
        {
            m_U716A.ResetValues();
        }
        return m_U716A;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleF002_SUSPEND_DTL;
    private SqlFileObject fleF002_SUSPEND_HDR;
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
    private DCharacter CLMDTL_STATUS_DELETE = new DCharacter("CLMDTL_STATUS_DELETE", 1);
    private void CLMDTL_STATUS_DELETE_GetValue(ref string Value)
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
    private DCharacter CLMDTL_STATUS_NEW = new DCharacter("CLMDTL_STATUS_NEW", 1);
    private void CLMDTL_STATUS_NEW_GetValue(ref string Value)
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
    private DCharacter CLMDTL_STATUS_ACTIVE = new DCharacter("CLMDTL_STATUS_ACTIVE", 1);
    private void CLMDTL_STATUS_ACTIVE_GetValue(ref string Value)
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
    private DCharacter CLMDTL_STATUS_UPDATED = new DCharacter("CLMDTL_STATUS_UPDATED", 1);
    private void CLMDTL_STATUS_UPDATED_GetValue(ref string Value)
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

    // GW2018. Jul 31. Added for parent
    private DCharacter CLMDTL_SV_DATE = new DCharacter("CLMDTL_SV_DATE", 8);
    private void CLMDTL_SV_DATE_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2);
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
            if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) == QDesign.NULL(UPDATED.Value) | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) == QDesign.NULL(CLMDTL_STATUS_DELETE.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(UPDATED.Value) | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_DELETE.Value))
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


    private SqlFileObject fleU716A;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("U716A");

            while (fleF002_SUSPEND_DTL.QTPForMissing())
            {
                // --> GET F002_SUSPEND_DTL <--

                fleF002_SUSPEND_DTL.GetData();
                // --> End GET F002_SUSPEND_DTL <--

                while (fleF002_SUSPEND_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_HDR <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleF002_SUSPEND_DTL.GetSortValue("CLMDTL_DOC_OHIP_NBR"), fleF002_SUSPEND_DTL.GetSortValue("CLMDTL_ACCOUNTING_NBR"));


                        }

                    }

                }

            }


            while (Sort(fleF002_SUSPEND_DTL, fleF002_SUSPEND_HDR))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleU716A, fleF002_SUSPEND_DTL.At("CLMDTL_DOC_OHIP_NBR") || fleF002_SUSPEND_DTL.At("CLMDTL_ACCOUNTING_NBR"), SubFileType.Keep, fleF002_SUSPEND_DTL, "CLMDTL_DOC_OHIP_NBR", "CLMDTL_ACCOUNTING_NBR", CLMDTL_SV_DATE);



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
            EndRequest("U716A");

        }

    }


    #region "Standard Generated Procedures(U716A_U716A)"

    #region "Transaction Management Procedures(U716A_U716A)"

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleU716A.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U716A_U716A)"

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
            fleF002_SUSPEND_HDR.Dispose();
            fleU716A.Dispose();


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

