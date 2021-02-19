
#region "Screen Comments"

// Program: u716c.qts
// Purpose: To create a flat file of modified description records to upload
// back to the web
// - this pgm creates the subfile of concatenated descriptions with
// 1 long description text for all f002-suspend-desc recs
// if any of the description records have been changed then all description
// records must be processed and sent back to web.
// the 1st request identifies claims with a changed detail and creates
// driver file that the 2nd request uses to get all description recs
// Modification History
// YY/MMM/DD  who  Why
// 00/oct/05  B.E. - original
// **********************************************************************


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U716C : BaseClassControl
{

    private U716C m_U716C;

    public U716C(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U716C(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U716C != null))
        {
            m_U716C.CloseTransactionObjects();
            m_U716C = null;
        }
    }

    public U716C GetU716C(int Level)
    {
        if (m_U716C == null)
        {
            m_U716C = new U716C("U716C", Level);
        }
        else
        {
            m_U716C.ResetValues();
        }
        return m_U716C;
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

            U716C_IDENT_CLAIMS_WITH_CHANGED_DESC_1 IDENT_CLAIMS_WITH_CHANGED_DESC_1 = new U716C_IDENT_CLAIMS_WITH_CHANGED_DESC_1(Name, Level);
            IDENT_CLAIMS_WITH_CHANGED_DESC_1.Run();
            IDENT_CLAIMS_WITH_CHANGED_DESC_1.Dispose();
            IDENT_CLAIMS_WITH_CHANGED_DESC_1 = null;

            U716C_GET_ALL_DESC_FOR_CHANGED_CLAIMS_2 GET_ALL_DESC_FOR_CHANGED_CLAIMS_2 = new U716C_GET_ALL_DESC_FOR_CHANGED_CLAIMS_2(Name, Level);
            GET_ALL_DESC_FOR_CHANGED_CLAIMS_2.Run();
            GET_ALL_DESC_FOR_CHANGED_CLAIMS_2.Dispose();
            GET_ALL_DESC_FOR_CHANGED_CLAIMS_2 = null;

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



public class U716C_IDENT_CLAIMS_WITH_CHANGED_DESC_1 : U716C
{

    public U716C_IDENT_CLAIMS_WITH_CHANGED_DESC_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU716C1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U716C1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        CLMDTL_STATUS_DELETE.GetValue += CLMDTL_STATUS_DELETE_GetValue;
        CLMDTL_STATUS_NEW.GetValue += CLMDTL_STATUS_NEW_GetValue;
        CLMDTL_STATUS_ACTIVE.GetValue += CLMDTL_STATUS_ACTIVE_GetValue;
        CLMDTL_STATUS_UPDATED.GetValue += CLMDTL_STATUS_UPDATED_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U716C_IDENT_CLAIMS_WITH_CHANGED_DESC_1)"

    private SqlFileObject fleF002_SUSPEND_DESC;
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

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_STATUS")) == QDesign.NULL(CLMDTL_STATUS_UPDATED.Value) | QDesign.NULL(fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_STATUS")) == QDesign.NULL(CLMDTL_STATUS_NEW.Value))
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

    private SqlFileObject fleU716C1;


    #endregion


    #region "Standard Generated Procedures(U716C_IDENT_CLAIMS_WITH_CHANGED_DESC_1)"


    #region "Automatic Item Initialization(U716C_IDENT_CLAIMS_WITH_CHANGED_DESC_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U716C_IDENT_CLAIMS_WITH_CHANGED_DESC_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:42 PM

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
        fleF002_SUSPEND_DESC.Transaction = m_trnTRANS_UPDATE;
        fleU716C1.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U716C_IDENT_CLAIMS_WITH_CHANGED_DESC_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:42 PM

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
            fleF002_SUSPEND_DESC.Dispose();
            fleU716C1.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U716C_IDENT_CLAIMS_WITH_CHANGED_DESC_1)"


    public void Run()
    {

        try
        {
            Request("IDENT_CLAIMS_WITH_CHANGED_DESC_1");

            while (fleF002_SUSPEND_DESC.QTPForMissing())
            {
                // --> GET F002_SUSPEND_DESC <--

                fleF002_SUSPEND_DESC.GetData();
                // --> End GET F002_SUSPEND_DESC <--


                if (Transaction())
                {

                     if (Select_If())
                    {

                        Sort(fleF002_SUSPEND_DESC.GetSortValue("CLMDTL_DOC_OHIP_NBR"), fleF002_SUSPEND_DESC.GetSortValue("CLMDTL_ACCOUNTING_NBR"));


                    }

                }

            }

            while (Sort(fleF002_SUSPEND_DESC))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleU716C1, fleF002_SUSPEND_DESC.At("CLMDTL_DOC_OHIP_NBR") || fleF002_SUSPEND_DESC.At("CLMDTL_ACCOUNTING_NBR"), SubFileType.Keep, fleF002_SUSPEND_DESC, "CLMHDR_DOC_OHIP_NBR", "CLMHDR_ACCOUNTING_NBR");


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
            EndRequest("IDENT_CLAIMS_WITH_CHANGED_DESC_1");

        }

    }







    #endregion


}
//IDENT_CLAIMS_WITH_CHANGED_DESC_1



public class U716C_GET_ALL_DESC_FOR_CHANGED_CLAIMS_2 : U716C
{

    public U716C_GET_ALL_DESC_FOR_CHANGED_CLAIMS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU716C1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U716C1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_TEXT = new CoreCharacter("X_TEXT", 255, this, Common.cEmptyString);
        fleU716C2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U716C2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

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

    }


    #region "Declarations (Variables, Files and Transactions)(U716C_GET_ALL_DESC_FOR_CHANGED_CLAIMS_2)"

    private SqlFileObject fleU716C1;
    private SqlFileObject fleF002_SUSPEND_HDR;
    private SqlFileObject fleF002_SUSPEND_DESC;
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

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_DELETE.Value) & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_CANCEL.Value) & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_RESUBMIT.Value) & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_IGNOR.Value))
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

    private CoreCharacter X_TEXT;
    private SqlFileObject fleU716C2;


    #endregion


    #region "Standard Generated Procedures(U716C_GET_ALL_DESC_FOR_CHANGED_CLAIMS_2)"


    #region "Automatic Item Initialization(U716C_GET_ALL_DESC_FOR_CHANGED_CLAIMS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U716C_GET_ALL_DESC_FOR_CHANGED_CLAIMS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:42 PM

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
        fleU716C1.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DESC.Transaction = m_trnTRANS_UPDATE;
        fleU716C2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U716C_GET_ALL_DESC_FOR_CHANGED_CLAIMS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:42 PM

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
            fleU716C1.Dispose();
            fleF002_SUSPEND_HDR.Dispose();
            fleF002_SUSPEND_DESC.Dispose();
            fleU716C2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U716C_GET_ALL_DESC_FOR_CHANGED_CLAIMS_2)"


    public void Run()
    {

        try
        {
            Request("GET_ALL_DESC_FOR_CHANGED_CLAIMS_2");

            while (fleU716C1.QTPForMissing())
            {
                // --> GET U716C1 <--

                fleU716C1.GetData();
                // --> End GET U716C1 <--

                while (fleF002_SUSPEND_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_HDR <--

                    while (fleF002_SUSPEND_DESC.QTPForMissing("2"))
                    {
                        // --> GET F002_SUSPEND_DESC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                        m_strWhere.Append((fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                        fleF002_SUSPEND_DESC.GetData(m_strWhere.ToString());
                        // --> End GET F002_SUSPEND_DESC <--


                        if (Transaction())
                        {

                             if (Select_If())
                            {

                                Sort(fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_DOC_OHIP_NBR"), fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_ACCOUNTING_NBR"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleU716C1, fleF002_SUSPEND_HDR, fleF002_SUSPEND_DESC))
            {
                X_TEXT.Value = (QDesign.Pack(X_TEXT.Value)).TrimEnd() + QDesign.RTrim(QDesign.Pack(fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_SUSPEND_DESC")));

                SubFile(ref m_trnTRANS_UPDATE, ref fleU716C2, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_ACCOUNTING_NBR"), SubFileType.Keep, fleF002_SUSPEND_DESC, "CLMHDR_DOC_OHIP_NBR", "CLMHDR_ACCOUNTING_NBR", X_TEXT);


                Reset(ref X_TEXT, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_ACCOUNTING_NBR"));

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
            EndRequest("GET_ALL_DESC_FOR_CHANGED_CLAIMS_2");

        }

    }







    #endregion


}
//GET_ALL_DESC_FOR_CHANGED_CLAIMS_2




