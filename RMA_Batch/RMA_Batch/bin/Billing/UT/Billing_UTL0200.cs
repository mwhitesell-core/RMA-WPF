
#region "Screen Comments"

// #> PROGRAM-ID.   utl0200.qts
// ((C)) Dyad Technologies
// R.M.A. VERSION
// PROGRAM PURPOSE :
// - extract data from the doctor master, doctor extra and contact and
// contact info files to build a file so download to the PC
// where the doctor master excel workbook is built using the data
// MODIFICATION HISTORY
// DATE   WHO   DESCRIPTION
// 2005/Jul/14 b.e - original
// -------------------------------------------------------------------------------


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Billing_UTL0200 : BaseClassControl
{

    private Billing_UTL0200 m_Billing_UTL0200;

    public Billing_UTL0200(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public Billing_UTL0200(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_Billing_UTL0200 != null))
        {
            m_Billing_UTL0200.CloseTransactionObjects();
            m_Billing_UTL0200 = null;
        }
    }

    public Billing_UTL0200 GetBilling_UTL0200(int Level)
    {
        if (m_Billing_UTL0200 == null)
        {
            m_Billing_UTL0200 = new Billing_UTL0200("Billing_UTL0200", Level);
        }
        else
        {
            m_Billing_UTL0200.ResetValues();
        }
        return m_Billing_UTL0200;
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

            Billing_UTL0200_DOWNLOAD_DOC_1_1 DOWNLOAD_DOC_1_1 = new Billing_UTL0200_DOWNLOAD_DOC_1_1(Name, Level);
            DOWNLOAD_DOC_1_1.Run();
            DOWNLOAD_DOC_1_1.Dispose();
            DOWNLOAD_DOC_1_1 = null;

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



public class Billing_UTL0200_DOWNLOAD_DOC_1_1 : Billing_UTL0200
{

    public Billing_UTL0200_DOWNLOAD_DOC_1_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF027_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F027_CONTACTS_MSTR", "F027_DOC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF028_DOC_OFFICE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "F028_DOC_OFFICE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF028_DOC_HOME = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "F028_DOC_HOME", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF027_SEC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F027_CONTACTS_MSTR", "F027_SEC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF028_SEC_OFFICE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "F028_SEC_OFFICE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF028_SEC_HOME = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "F028_SEC_HOME", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleBilling_UTL0200 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "Billing_UTL0200", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMINER.GetValue += X_DELIMINER_GetValue;
        fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;
        fleF027_DOC.InitializeItems += fleF027_DOC_AutomaticItemInitialization;
        fleF028_DOC_OFFICE.InitializeItems += fleF028_DOC_OFFICE_AutomaticItemInitialization;
        fleF028_DOC_HOME.InitializeItems += fleF028_DOC_HOME_AutomaticItemInitialization;
        fleF027_SEC.InitializeItems += fleF027_SEC_AutomaticItemInitialization;
        fleF028_SEC_OFFICE.InitializeItems += fleF028_SEC_OFFICE_AutomaticItemInitialization;
        fleF028_SEC_HOME.InitializeItems += fleF028_SEC_HOME_AutomaticItemInitialization;
        fleF070_DEPT_MSTR.InitializeItems += fleF070_DEPT_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_UTL0200_DOWNLOAD_DOC_1_1)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020_DOCTOR_EXTRA;
    private SqlFileObject fleF027_DOC;
    private SqlFileObject fleF028_DOC_OFFICE;
    private SqlFileObject fleF028_DOC_HOME;
    private SqlFileObject fleF027_SEC;
    private SqlFileObject fleF028_SEC_OFFICE;
    private SqlFileObject fleF028_SEC_HOME;
    private SqlFileObject fleF070_DEPT_MSTR;
    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_DELIMINER = new DCharacter("X_DELIMINER", 1);
    private void X_DELIMINER_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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





    private SqlFileObject fleBilling_UTL0200;


    #endregion


    #region "Standard Generated Procedures(Billing_UTL0200_DOWNLOAD_DOC_1_1)"


    #region "Automatic Item Initialization(Billing_UTL0200_DOWNLOAD_DOC_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:32 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_EXTRA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:52:27 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_EXTRA_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));

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
    //# fleF027_DOC_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:52:27 PM
    //#-----------------------------------------
    private void fleF027_DOC_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF027_DOC.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF027_DOC.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));

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
    //# fleF028_DOC_OFFICE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:52:27 PM
    //#-----------------------------------------
    private void fleF028_DOC_OFFICE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));

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
    //# fleF028_DOC_HOME_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:52:27 PM
    //#-----------------------------------------
    private void fleF028_DOC_HOME_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME.set_SetValue("CONTACTS_LOCATION", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_LOCATION"));
            fleF028_DOC_HOME.set_SetValue("CONTACTS_ADDR_1", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_ADDR_1"));
            fleF028_DOC_HOME.set_SetValue("CONTACTS_ADDR_2", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_ADDR_2"));
            fleF028_DOC_HOME.set_SetValue("CONTACTS_ADDR_3", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_ADDR_3"));
            fleF028_DOC_HOME.set_SetValue("POSTAL_CODE", !Fixed, fleF028_DOC_OFFICE.GetStringValue("POSTAL_CODE"));
            fleF028_DOC_HOME.set_SetValue("CONTACTS_EMAIL_ADDR", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_EMAIL_ADDR"));
            fleF028_DOC_HOME.set_SetValue("CONTACTS_PHONE_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_PHONE_NBR"));
            fleF028_DOC_HOME.set_SetValue("CONTACTS_PHONE_EXT", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_PHONE_EXT"));
            fleF028_DOC_HOME.set_SetValue("CONTACTS_PAGER_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_PAGER_NBR"));
            fleF028_DOC_HOME.set_SetValue("CONTACTS_CELL_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_CELL_NBR"));
            fleF028_DOC_HOME.set_SetValue("CONTACTS_FAX_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_FAX_NBR"));
            fleF028_DOC_HOME.set_SetValue("NEWSLETTER_FLAG", !Fixed, fleF028_DOC_OFFICE.GetStringValue("NEWSLETTER_FLAG"));

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
    //# fleF027_SEC_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:52:27 PM
    //#-----------------------------------------
    private void fleF027_SEC_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF027_SEC.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF027_SEC.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF027_SEC.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));
            fleF027_SEC.set_SetValue("CONTACTS_GIVEN_NAMES", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_GIVEN_NAMES"));
            fleF027_SEC.set_SetValue("CONTACTS_SURNAME", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_SURNAME"));
            fleF027_SEC.set_SetValue("CONTACTS_INIT_S1", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_INIT_S1"));
            fleF027_SEC.set_SetValue("CONTACTS_INIT_S2", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_INIT_S2"));
            fleF027_SEC.set_SetValue("CONTACTS_INIT_S3", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_INIT_S3"));
            fleF027_SEC.set_SetValue("CONTACTS_TITLE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TITLE"));
            fleF027_SEC.set_SetValue("CONTACTS_SEX", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_SEX"));
            fleF027_SEC.set_SetValue("BILLING_ENTRY_FLAG", !Fixed, fleF027_DOC.GetStringValue("BILLING_ENTRY_FLAG"));
            fleF027_SEC.set_SetValue("LOGON_USERNAME", !Fixed, fleF027_DOC.GetStringValue("LOGON_USERNAME"));

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
    //# fleF028_SEC_OFFICE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:52:27 PM
    //#-----------------------------------------
    private void fleF028_SEC_OFFICE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF028_SEC_OFFICE.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF028_SEC_OFFICE.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF028_SEC_OFFICE.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));
            //TODO: Manual steps may be required.
            fleF028_SEC_OFFICE.set_SetValue("CONTACTS_LOCATION", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_LOCATION"));
            fleF028_SEC_OFFICE.set_SetValue("CONTACTS_ADDR_1", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_ADDR_1"));
            fleF028_SEC_OFFICE.set_SetValue("CONTACTS_ADDR_2", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_ADDR_2"));
            fleF028_SEC_OFFICE.set_SetValue("CONTACTS_ADDR_3", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_ADDR_3"));
            fleF028_SEC_OFFICE.set_SetValue("POSTAL_CODE", !Fixed, fleF028_DOC_OFFICE.GetStringValue("POSTAL_CODE"));
            fleF028_SEC_OFFICE.set_SetValue("CONTACTS_EMAIL_ADDR", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_EMAIL_ADDR"));
            fleF028_SEC_OFFICE.set_SetValue("CONTACTS_PHONE_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_PHONE_NBR"));
            fleF028_SEC_OFFICE.set_SetValue("CONTACTS_PHONE_EXT", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_PHONE_EXT"));
            fleF028_SEC_OFFICE.set_SetValue("CONTACTS_PAGER_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_PAGER_NBR"));
            fleF028_SEC_OFFICE.set_SetValue("CONTACTS_CELL_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_CELL_NBR"));
            fleF028_SEC_OFFICE.set_SetValue("CONTACTS_FAX_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_FAX_NBR"));
            fleF028_SEC_OFFICE.set_SetValue("NEWSLETTER_FLAG", !Fixed, fleF028_DOC_OFFICE.GetStringValue("NEWSLETTER_FLAG"));

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
    //# fleF028_SEC_HOME_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:52:28 PM
    //#-----------------------------------------
    private void fleF028_SEC_HOME_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF028_SEC_HOME.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF028_SEC_HOME.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF028_SEC_HOME.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));
            //TODO: Manual steps may be required.
            fleF028_SEC_HOME.set_SetValue("CONTACTS_LOCATION", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_LOCATION"));
            fleF028_SEC_HOME.set_SetValue("CONTACTS_ADDR_1", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_ADDR_1"));
            fleF028_SEC_HOME.set_SetValue("CONTACTS_ADDR_2", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_ADDR_2"));
            fleF028_SEC_HOME.set_SetValue("CONTACTS_ADDR_3", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_ADDR_3"));
            fleF028_SEC_HOME.set_SetValue("POSTAL_CODE", !Fixed, fleF028_DOC_OFFICE.GetStringValue("POSTAL_CODE"));
            fleF028_SEC_HOME.set_SetValue("CONTACTS_EMAIL_ADDR", !Fixed, fleF028_DOC_OFFICE.GetStringValue("CONTACTS_EMAIL_ADDR"));
            fleF028_SEC_HOME.set_SetValue("CONTACTS_PHONE_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_PHONE_NBR"));
            fleF028_SEC_HOME.set_SetValue("CONTACTS_PHONE_EXT", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_PHONE_EXT"));
            fleF028_SEC_HOME.set_SetValue("CONTACTS_PAGER_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_PAGER_NBR"));
            fleF028_SEC_HOME.set_SetValue("CONTACTS_CELL_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_CELL_NBR"));
            fleF028_SEC_HOME.set_SetValue("CONTACTS_FAX_NBR", !Fixed, fleF028_DOC_OFFICE.GetDecimalValue("CONTACTS_FAX_NBR"));
            fleF028_SEC_HOME.set_SetValue("NEWSLETTER_FLAG", !Fixed, fleF028_DOC_OFFICE.GetStringValue("NEWSLETTER_FLAG"));

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
    //# fleF070_DEPT_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:52:28 PM
    //#-----------------------------------------
    private void fleF070_DEPT_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF070_DEPT_MSTR.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(Billing_UTL0200_DOWNLOAD_DOC_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:27 PM

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
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleF027_DOC.Transaction = m_trnTRANS_UPDATE;
        fleF028_DOC_OFFICE.Transaction = m_trnTRANS_UPDATE;
        fleF028_DOC_HOME.Transaction = m_trnTRANS_UPDATE;
        fleF027_SEC.Transaction = m_trnTRANS_UPDATE;
        fleF028_SEC_OFFICE.Transaction = m_trnTRANS_UPDATE;
        fleF028_SEC_HOME.Transaction = m_trnTRANS_UPDATE;
        fleF070_DEPT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleBilling_UTL0200.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_UTL0200_DOWNLOAD_DOC_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:27 PM

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
            fleF020_DOCTOR_MSTR.Dispose();
            fleF020_DOCTOR_EXTRA.Dispose();
            fleF027_DOC.Dispose();
            fleF028_DOC_OFFICE.Dispose();
            fleF028_DOC_HOME.Dispose();
            fleF027_SEC.Dispose();
            fleF028_SEC_OFFICE.Dispose();
            fleF028_SEC_HOME.Dispose();
            fleF070_DEPT_MSTR.Dispose();
            fleBilling_UTL0200.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_UTL0200_DOWNLOAD_DOC_1_1)"


    public void Run()
    {

        try
        {
            Request("DOWNLOAD_DOC_1_1");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--

                while (fleF020_DOCTOR_EXTRA.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_EXTRA <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_EXTRA <--

                    while (fleF027_DOC.QTPForMissing("2"))
                    {
                        // --> GET F027_DOC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF027_DOC.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                        m_strWhere.Append(" And ").Append(fleF027_DOC.ElementOwner("FILLER")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(" "));
                        m_strWhere.Append(" And ").Append(fleF027_DOC.ElementOwner("CONTACTS_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("D"));

                        fleF027_DOC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F027_DOC <--

                        while (fleF028_DOC_OFFICE.QTPForMissing("3"))
                        {
                            // --> GET F028_DOC_OFFICE <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF028_DOC_OFFICE.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" And ").Append(fleF028_DOC_OFFICE.ElementOwner("FILLER")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(" "));
                            m_strWhere.Append(" And ").Append(fleF028_DOC_OFFICE.ElementOwner("CONTACTS_TYPE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("D"));
                            m_strWhere.Append(" And ").Append(fleF028_DOC_OFFICE.ElementOwner("CONTACTS_LOCATION")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("H"));

                            fleF028_DOC_OFFICE.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F028_DOC_OFFICE <--

                            while (fleF028_DOC_HOME.QTPForMissing("4"))
                            {
                                // --> GET F028_DOC_HOME <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF028_DOC_HOME.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                                m_strWhere.Append(" And ").Append(fleF028_DOC_HOME.ElementOwner("FILLER")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(" "));
                                m_strWhere.Append(" And ").Append(fleF028_DOC_HOME.ElementOwner("CONTACTS_TYPE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField("D"));
                                m_strWhere.Append(" And ").Append(fleF028_DOC_HOME.ElementOwner("CONTACTS_LOCATION")).Append(" = ");
                                m_strWhere.Append(Common.StringToField("O"));

                                fleF028_DOC_HOME.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F028_DOC_HOME <--

                                while (fleF027_SEC.QTPForMissing("5"))
                                {
                                    // --> GET F027_SEC <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF027_SEC.ElementOwner("DOC_NBR")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                                    m_strWhere.Append(" And ").Append(fleF027_SEC.ElementOwner("FILLER")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(" "));
                                    m_strWhere.Append(" And ").Append(fleF027_SEC.ElementOwner("CONTACTS_TYPE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField("S"));

                                    fleF027_SEC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F027_SEC <--

                                    while (fleF028_SEC_OFFICE.QTPForMissing("6"))
                                    {
                                        // --> GET F028_SEC_OFFICE <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleF028_SEC_OFFICE.ElementOwner("DOC_NBR")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                                        m_strWhere.Append(" And ").Append(fleF028_SEC_OFFICE.ElementOwner("FILLER")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(" "));
                                        m_strWhere.Append(" And ").Append(fleF028_SEC_OFFICE.ElementOwner("CONTACTS_TYPE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField("S"));
                                        m_strWhere.Append(" And ").Append(fleF028_SEC_OFFICE.ElementOwner("CONTACTS_LOCATION")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField("H"));

                                        fleF028_SEC_OFFICE.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                        // --> End GET F028_SEC_OFFICE <--

                                        while (fleF028_SEC_HOME.QTPForMissing("7"))
                                        {
                                            // --> GET F028_SEC_HOME <--
                                            m_strWhere = new StringBuilder(" WHERE ");
                                            m_strWhere.Append(" ").Append(fleF028_SEC_HOME.ElementOwner("DOC_NBR")).Append(" = ");
                                            m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                                            m_strWhere.Append(" And ").Append(fleF028_SEC_HOME.ElementOwner("FILLER")).Append(" = ");
                                            m_strWhere.Append(Common.StringToField(" "));
                                            m_strWhere.Append(" And ").Append(fleF028_SEC_HOME.ElementOwner("CONTACTS_TYPE")).Append(" = ");
                                            m_strWhere.Append(Common.StringToField("S"));
                                            m_strWhere.Append(" And ").Append(fleF028_SEC_HOME.ElementOwner("CONTACTS_LOCATION")).Append(" = ");
                                            m_strWhere.Append(Common.StringToField("O"));

                                            fleF028_SEC_HOME.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                            // --> End GET F028_SEC_HOME <--

                                            while (fleF070_DEPT_MSTR.QTPForMissing("8"))
                                            {
                                                // --> GET F070_DEPT_MSTR <--
                                                m_strWhere = new StringBuilder(" WHERE ");
                                                m_strWhere.Append(" ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ");
                                                m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")));

                                                fleF070_DEPT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                // --> End GET F070_DEPT_MSTR <--


                                                if (Transaction())
                                                {





                                                    SubFile(ref m_trnTRANS_UPDATE, ref fleBilling_UTL0200, SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_NBR", X_DELIMINER, "DOC_DEPT", fleF070_DEPT_MSTR, "DEPT_COMPANY", fleF020_DOCTOR_MSTR,
                                                    "DOC_OHIP_NBR", "DOC_SIN_NBR", "DOC_CLINIC_NBR", "DOC_SPEC_CD", "DOC_HOSP_NBR", "DOC_NAME", "DOC_INITS", "DOC_FULL_PART_IND", "DOC_DATE_FAC_START", "DOC_DATE_FAC_TERM",
                                                    "DOC_CLINIC_NBR_2", "DOC_CLINIC_NBR_3", "DOC_CLINIC_NBR_4", "DOC_CLINIC_NBR_5", "DOC_CLINIC_NBR_6", "DOC_SPEC_CD_2", "DOC_SPEC_CD_3", "DOC_RMA_EXPENSE_PERCENT_MISC", "DOC_AFP_PAYM_GROUP", "DOC_IND_PAYS_GST",
                                                    "DOC_RMA_EXPENSE_PERCENT_REG", "DOC_SUB_SPECIALTY", "DOC_DEPT_EXPENSE_PERCENT_MISC", "DOC_DEPT_EXPENSE_PERCENT_REG", fleF020_DOCTOR_EXTRA, "BILLING_VIA_PAPER_FLAG", "BILLING_VIA_DISKETTE_FLAG", "BILLING_VIA_WEB_TEST_FLAG", "BILLING_VIA_WEB_LIVE_FLAG", "BILLING_VIA_RMA_DATA_ENTRY",
                                                    "DATE_START_RMA_DATA_ENTRY", "DATE_START_DISKETTE", "DATE_START_PAPER", "DATE_START_WEB_LIVE", "DATE_START_WEB_TEST", "LEAVE_DESCRIPTION", "LEAVE_DATE_START", "LEAVE_DATE_END", "WEB_USER_REVENUE_ONLY_FLAG", "MANAGER_FLAG",
                                                    "CHAIR_FLAG", "ABE_USER_FLAG", "YELLOW_PAGES_FLAG", "CPSO_NBR", "CMPA_NBR", "OMA_NBR", "CFPC_NBR", "RCPSC_NBR", "DOC_MED_PROF_CORP", "MCMASTER_EMPLOYEE_ID",
                                                    fleF027_DOC, "CONTACTS_GIVEN_NAMES", "CONTACTS_SURNAME", "CONTACTS_INITS", "CONTACTS_TITLE", "CONTACTS_SEX", "BILLING_ENTRY_FLAG", "LOGON_USERNAME", fleF028_DOC_OFFICE, "CONTACTS_ADDR_1",
                                                    "CONTACTS_ADDR_2", "CONTACTS_ADDR_3", "POSTAL_CODE", "CONTACTS_EMAIL_ADDR", "CONTACTS_PHONE_NBR", "CONTACTS_PHONE_EXT", "CONTACTS_PAGER_NBR", "CONTACTS_CELL_NBR", "CONTACTS_FAX_NBR", "NEWSLETTER_FLAG",
                                                    X_LF);



                                                }

                                            }

                                        }

                                    }

                                }

                            }

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
            EndRequest("DOWNLOAD_DOC_1_1");

        }

    }




    #endregion


}
//DOWNLOAD_DOC_1_1




