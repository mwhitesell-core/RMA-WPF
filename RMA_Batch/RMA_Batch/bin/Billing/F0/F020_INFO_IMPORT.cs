
#region "Screen Comments"

// program: f020_info_import
// purpose: brings in new/updated f020 information (currently from MP) and updates
// the live (currently 101c) doctor master
// 2006/01/18  M.C. - update doc-name when f020 record exists
// 2006/03/16  M.C. - update doc-name-soundex from doc-name in f020
// 2006/06/15    b.e. - uncomment (ie re-activate) the lock record update stmt
// 2011/06/01    MC1     - do not update f027, update f028 only if the address fields are not blank


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class F020_INFO_IMPORT : BaseClassControl
{

    private F020_INFO_IMPORT m_F020_INFO_IMPORT;

    public F020_INFO_IMPORT(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public F020_INFO_IMPORT(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_F020_INFO_IMPORT != null))
        {
            m_F020_INFO_IMPORT.CloseTransactionObjects();
            m_F020_INFO_IMPORT = null;
        }
    }

    public F020_INFO_IMPORT GetF020_INFO_IMPORT(int Level)
    {
        if (m_F020_INFO_IMPORT == null)
        {
            m_F020_INFO_IMPORT = new F020_INFO_IMPORT("F020_INFO_IMPORT", Level);
        }
        else
        {
            m_F020_INFO_IMPORT.ResetValues();
        }
        return m_F020_INFO_IMPORT;
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

            F020_INFO_IMPORT_ONE_1 ONE_1 = new F020_INFO_IMPORT_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

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



public class F020_INFO_IMPORT_ONE_1 : F020_INFO_IMPORT
{

    public F020_INFO_IMPORT_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_INFO_EXPORT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F020_INFO_EXPORT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF027_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F027_CONTACTS_MSTR", "F027_DOC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF028_DOC_HOME = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "F028_DOC_HOME", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF028_DOC_OFFICE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "F028_DOC_OFFICE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "F020_DOCTOR_MSTR_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "F020_DOCTOR_MSTR_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF027_DOC_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F027_CONTACTS_MSTR", "F027_DOC_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF028_DOC_HOME_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "F028_DOC_HOME_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF028_DOC_HOME_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "F028_DOC_HOME_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF028_DOC_OFFICE_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "F028_DOC_OFFICE_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF028_DOC_OFFICE_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "F028_DOC_OFFICE_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF020_DOCTOR_MSTR_ADD.SetItemFinals += fleF020_DOCTOR_MSTR_ADD_SetItemFinals;
        fleF020_DOCTOR_MSTR_UPDATE.SetItemFinals += fleF020_DOCTOR_MSTR_UPDATE_SetItemFinals;
        fleF027_DOC_ADD.SetItemFinals += fleF027_DOC_ADD_SetItemFinals;
        fleF028_DOC_HOME_ADD.SetItemFinals += fleF028_DOC_HOME_ADD_SetItemFinals;
        fleF028_DOC_HOME_UPDATE.SetItemFinals += fleF028_DOC_HOME_UPDATE_SetItemFinals;
        fleF028_DOC_OFFICE_ADD.SetItemFinals += fleF028_DOC_OFFICE_ADD_SetItemFinals;
        fleF028_DOC_OFFICE_UPDATE.SetItemFinals += fleF028_DOC_OFFICE_UPDATE_SetItemFinals;
        fleF027_DOC.InitializeItems += fleF027_DOC_AutomaticItemInitialization;
        fleF028_DOC_HOME.InitializeItems += fleF028_DOC_HOME_AutomaticItemInitialization;
        fleF028_DOC_OFFICE.InitializeItems += fleF028_DOC_OFFICE_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR_ADD.InitializeItems += fleF020_DOCTOR_MSTR_ADD_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR_UPDATE.InitializeItems += fleF020_DOCTOR_MSTR_UPDATE_AutomaticItemInitialization;
        fleF027_DOC_ADD.InitializeItems += fleF027_DOC_ADD_AutomaticItemInitialization;
        fleF028_DOC_HOME_ADD.InitializeItems += fleF028_DOC_HOME_ADD_AutomaticItemInitialization;
        fleF028_DOC_HOME_UPDATE.InitializeItems += fleF028_DOC_HOME_UPDATE_AutomaticItemInitialization;
        fleF028_DOC_OFFICE_ADD.InitializeItems += fleF028_DOC_OFFICE_ADD_AutomaticItemInitialization;
        fleF028_DOC_OFFICE_UPDATE.InitializeItems += fleF028_DOC_OFFICE_UPDATE_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(F020_INFO_IMPORT_ONE_1)"

    private SqlFileObject fleF020_INFO_EXPORT;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF027_DOC;
    private SqlFileObject fleF028_DOC_HOME;
    private SqlFileObject fleF028_DOC_OFFICE;
    private SqlFileObject fleF020_DOCTOR_MSTR_ADD;

    private void fleF020_DOCTOR_MSTR_ADD_SetItemFinals()
    {

        try
        {
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_NAME_SOUNDEX", QDesign.Soundex(fleF020_INFO_EXPORT.GetStringValue("DOC_NAME")));


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

    private SqlFileObject fleF020_DOCTOR_MSTR_UPDATE;

    private void fleF020_DOCTOR_MSTR_UPDATE_SetItemFinals()
    {

        try
        {
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_OHIP_NBR", fleF020_INFO_EXPORT.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DEPT", fleF020_INFO_EXPORT.GetDecimalValue("DOC_DEPT"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_NAME", fleF020_INFO_EXPORT.GetStringValue("DOC_NAME"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_NAME_SOUNDEX", QDesign.Soundex(fleF020_INFO_EXPORT.GetStringValue("DOC_NAME")));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_INIT1", (fleF020_INFO_EXPORT.GetStringValue("DOC_INITS")).PadRight(3).Substring(0, 1));
            
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_INIT2", (fleF020_INFO_EXPORT.GetStringValue("DOC_INITS")).PadRight(3).Substring(1, 1));
            
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_INIT3", (fleF020_INFO_EXPORT.GetStringValue("DOC_INITS")).PadRight(3).Substring(2, 1));
            
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_CLINIC_NBR", fleF020_INFO_EXPORT.GetDecimalValue("DOC_CLINIC_NBR"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_FULL_PART_IND", fleF020_INFO_EXPORT.GetStringValue("DOC_FULL_PART_IND"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_START_YY", (fleF020_INFO_EXPORT.GetNumericDateValue("DOC_DATE_FAC_START")).ToString().PadRight(8).Substring(0, 4));
            
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_START_MM", (fleF020_INFO_EXPORT.GetNumericDateValue("DOC_DATE_FAC_START")).ToString().PadRight(8).Substring(4, 2));
            
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_START_DD", (fleF020_INFO_EXPORT.GetNumericDateValue("DOC_DATE_FAC_START")).ToString().PadRight(8).Substring(6, 2));
            
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_YY", (fleF020_INFO_EXPORT.GetNumericDateValue("DOC_DATE_FAC_TERM")).ToString().PadRight(8).Substring(0, 4));
            
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_MM", (fleF020_INFO_EXPORT.GetNumericDateValue("DOC_DATE_FAC_TERM")).ToString().PadRight(8).Substring(4, 2));
            
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_DD", (fleF020_INFO_EXPORT.GetNumericDateValue("DOC_DATE_FAC_TERM")).ToString().PadRight(8).Substring(6, 2));
            


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

    private SqlFileObject fleF027_DOC_ADD;

    private void fleF027_DOC_ADD_SetItemFinals()
    {

        try
        {
            fleF027_DOC_ADD.set_SetValue("FILLER", " ");
            fleF027_DOC_ADD.set_SetValue("DOC_NBR", fleF020_INFO_EXPORT.GetStringValue("DOC_NBR"));
            fleF027_DOC_ADD.set_SetValue("CONTACTS_TYPE", "D");
            fleF027_DOC_ADD.set_SetValue("CONTACTS_SURNAME", fleF020_INFO_EXPORT.GetStringValue("DOC_NAME"));
            fleF027_DOC_ADD.set_SetValue("CONTACTS_GIVEN_NAMES", fleF020_INFO_EXPORT.GetStringValue("DOC_INITS"));
            fleF027_DOC_ADD.set_SetValue("CONTACTS_INIT_S1", (fleF020_INFO_EXPORT.GetStringValue("DOC_INITS")).PadRight(3).Substring(0, 1));
            //Parent:CONTACTS_INITS
            fleF027_DOC_ADD.set_SetValue("CONTACTS_INIT_S2", (fleF020_INFO_EXPORT.GetStringValue("DOC_INITS")).PadRight(3).Substring(1, 1));
            //Parent:CONTACTS_INITS
            fleF027_DOC_ADD.set_SetValue("CONTACTS_INIT_S3", (fleF020_INFO_EXPORT.GetStringValue("DOC_INITS")).PadRight(3).Substring(2, 1));
            //Parent:CONTACTS_INITS
            fleF027_DOC_ADD.set_SetValue("CONTACTS_TITLE", "Dr.");


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

    private SqlFileObject fleF028_DOC_HOME_ADD;

    private void fleF028_DOC_HOME_ADD_SetItemFinals()
    {

        try
        {
            fleF028_DOC_HOME_ADD.set_SetValue("FILLER", " ");
            fleF028_DOC_HOME_ADD.set_SetValue("DOC_NBR", fleF020_INFO_EXPORT.GetStringValue("DOC_NBR"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_TYPE", "D");
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_LOCATION", "H");
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_ADDR_1", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_1"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_ADDR_2", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_2"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_ADDR_3", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_3"));
            fleF028_DOC_HOME_ADD.set_SetValue("POSTAL_CODE", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_PC"));


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

    private SqlFileObject fleF028_DOC_HOME_UPDATE;

    private void fleF028_DOC_HOME_UPDATE_SetItemFinals()
    {

        try
        {
            if (QDesign.NULL(fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_1")) != QDesign.NULL(" "))
            {
                fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_ADDR_1", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_1"));
            }
            if (QDesign.NULL(fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_1")) != QDesign.NULL(" "))
            {
                fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_ADDR_2", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_2"));
            }
            if (QDesign.NULL(fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_3")) != QDesign.NULL(" "))
            {
                fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_ADDR_3", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_3"));
            }
            if (QDesign.NULL(fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_PC")) != QDesign.NULL(" "))
            {
                fleF028_DOC_HOME_UPDATE.set_SetValue("POSTAL_CODE", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_HOME_PC"));
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

    }

    private SqlFileObject fleF028_DOC_OFFICE_ADD;

    private void fleF028_DOC_OFFICE_ADD_SetItemFinals()
    {

        try
        {
            fleF028_DOC_OFFICE_ADD.set_SetValue("FILLER", " ");
            fleF028_DOC_OFFICE_ADD.set_SetValue("DOC_NBR", fleF020_INFO_EXPORT.GetStringValue("DOC_NBR"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_TYPE", "D");
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_LOCATION", "O");
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_ADDR_1", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_1"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_ADDR_2", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_2"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_ADDR_3", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_3"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("POSTAL_CODE", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_PC"));


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

    private SqlFileObject fleF028_DOC_OFFICE_UPDATE;

    private void fleF028_DOC_OFFICE_UPDATE_SetItemFinals()
    {

        try
        {
            if (QDesign.NULL(fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_1")) != QDesign.NULL(" "))
            {
                fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_ADDR_1", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_1"));
            }
            if (QDesign.NULL(fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_2")) != QDesign.NULL(" "))
            {
                fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_ADDR_2", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_2"));
            }
            if (QDesign.NULL(fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_3")) != QDesign.NULL(" "))
            {
                fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_ADDR_3", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_3"));
            }
            if (QDesign.NULL(fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_PC")) != QDesign.NULL(" "))
            {
                fleF028_DOC_OFFICE_UPDATE.set_SetValue("POSTAL_CODE", fleF020_INFO_EXPORT.GetStringValue("DOC_ADDR_OFFICE_PC"));
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

    }


    #endregion


    #region "Standard Generated Procedures(F020_INFO_IMPORT_ONE_1)"


    #region "Automatic Item Initialization(F020_INFO_IMPORT_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:35 PM

    //#-----------------------------------------
    //# fleF027_DOC_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:02:28 PM
    //#-----------------------------------------
    private void fleF027_DOC_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF027_DOC.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));

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
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:02:28 PM
    //#-----------------------------------------
    private void fleF028_DOC_HOME_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME.set_SetValue("FILLER", !Fixed, fleF027_DOC.GetStringValue("FILLER"));
            fleF028_DOC_HOME.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));

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
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:02:29 PM
    //#-----------------------------------------
    private void fleF028_DOC_OFFICE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE.set_SetValue("FILLER", !Fixed, fleF027_DOC.GetStringValue("FILLER"));
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_LOCATION", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_LOCATION"));
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_ADDR_1", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_1"));
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_ADDR_2", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_2"));
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_ADDR_3", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_3"));
            fleF028_DOC_OFFICE.set_SetValue("POSTAL_CODE", !Fixed, fleF028_DOC_HOME.GetStringValue("POSTAL_CODE"));
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_EMAIL_ADDR", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_EMAIL_ADDR"));
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_PHONE_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PHONE_NBR"));
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_PHONE_EXT", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PHONE_EXT"));
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_PAGER_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PAGER_NBR"));
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_CELL_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_CELL_NBR"));
            fleF028_DOC_OFFICE.set_SetValue("CONTACTS_FAX_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_FAX_NBR"));
            fleF028_DOC_OFFICE.set_SetValue("NEWSLETTER_FLAG", !Fixed, fleF028_DOC_HOME.GetStringValue("NEWSLETTER_FLAG"));

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
    //# fleF020_DOCTOR_MSTR_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:02:31 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_SIN_123", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_SIN_456", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_SIN_789", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_HOSP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_HOSP_NBR"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_NAME_SOUNDEX", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME_SOUNDEX"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_INIT1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_INIT2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_INIT3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_OFFICE_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_OFFICE_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_OFFICE_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_OFFICE_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_OFFICE_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_OFFICE_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_OFFICE_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC4"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_OFFICE_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_OFFICE_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC6"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_HOME_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_HOME_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_HOME_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_HOME_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_HOME_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_HOME_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_HOME_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC4"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_HOME_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADDR_HOME_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC6"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_BANK_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_BANK_BRANCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_BANK_ACCT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_DATE_FAC_START_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_DATE_FAC_START_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_DATE_FAC_START_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_DATE_FAC_TERM_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_DATE_FAC_TERM_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_DATE_FAC_TERM_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YTDGUA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YTDGUB", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YTDGUC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YTDGUD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YTDCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YTDCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YTDEAR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YTDINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YTDEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_TOTINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_EP_DATE_DEPOSIT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_TOTINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_EP_CEIEXP", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADJCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_ADJCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_CEICEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_CEICEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("CEICEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("CEICEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("YTDCEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("YTDCEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_SPEC_CD_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_SPEC_CD_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YTDINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_DEPT_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_IND_PAYS_GST", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_NX_AVAIL_BATCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_NX_AVAIL_BATCH_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_NX_AVAIL_BATCH_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_NX_AVAIL_BATCH_4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_NX_AVAIL_BATCH_5", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_NX_AVAIL_BATCH_6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_SUB_SPECIALTY", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_PAYEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_YTDDED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_EP_PED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_EP_PAY_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_EP_PAY_SUB_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_PARTNERSHIP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_PARTNERSHIP"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_IND_HOLDBACK_ACTIVE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("GROUP_REGULAR_SERVICE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("GROUP_OVER_SERVICED", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_1_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_1_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_1_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_2_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_2_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_2_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_3_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_3_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_3_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_4_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_4_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_4_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_5_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_5_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_5_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_6_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_6_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_6_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_7_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_7_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_7_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_8_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_8_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_8_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_9_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_9_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_9_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_10_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_10_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_10_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_11_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_11_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_11_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_12_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_12_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_12_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_13_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_13_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_13_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_14_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_14_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_14_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_15_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_15_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_15_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_16_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_16_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_16_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_17_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_17_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_17_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_18_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_18_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_18_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_19_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_19_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_19_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_20_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_20_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_20_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_21_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_21_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_21_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_22_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_22_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_22_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_23_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_23_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_23_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_24_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_24_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_24_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_25_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_25_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_25_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_26_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_26_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_26_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_27_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_27_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_27_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_28_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_28_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_28_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_29_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_29_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_29_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_30_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_30_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2"));
            fleF020_DOCTOR_MSTR_ADD.set_SetValue("DOC_LOC_30_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3"));

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
    //# fleF020_DOCTOR_MSTR_UPDATE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:02:32 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_UPDATE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_SIN_123", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_SIN_456", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_SIN_789", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_HOSP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_HOSP_NBR"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_NAME_SOUNDEX", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME_SOUNDEX"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_INIT1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_INIT2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_INIT3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_OFFICE_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_OFFICE_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_OFFICE_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC4"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC6"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_HOME_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_HOME_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_HOME_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_HOME_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_HOME_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_HOME_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_HOME_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC4"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_HOME_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADDR_HOME_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC6"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_BANK_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_BANK_BRANCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_BANK_ACCT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_START_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_START_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_START_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YTDGUA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YTDGUB", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YTDGUC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YTDGUD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YTDCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YTDCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YTDEAR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YTDINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YTDEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_TOTINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_EP_DATE_DEPOSIT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_TOTINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_EP_CEIEXP", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADJCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_ADJCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_CEICEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_CEICEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("CEICEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("CEICEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("YTDCEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("YTDCEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_SPEC_CD_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_SPEC_CD_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YTDINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DEPT_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_IND_PAYS_GST", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_5", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_SUB_SPECIALTY", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_PAYEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_YTDDED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_EP_PED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_EP_PAY_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_EP_PAY_SUB_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_PARTNERSHIP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_PARTNERSHIP"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_IND_HOLDBACK_ACTIVE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("GROUP_REGULAR_SERVICE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("GROUP_OVER_SERVICED", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_1_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_1_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_1_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_2_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_2_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_2_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_3_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_3_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_3_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_4_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_4_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_4_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_5_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_5_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_5_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_6_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_6_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_6_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_7_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_7_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_7_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_8_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_8_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_8_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_9_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_9_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_9_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_10_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_10_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_10_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_11_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_11_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_11_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_12_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_12_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_12_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_13_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_13_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_13_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_14_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_14_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_14_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_15_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_15_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_15_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_16_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_16_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_16_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_17_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_17_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_17_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_18_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_18_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_18_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_19_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_19_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_19_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_20_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_20_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_20_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_21_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_21_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_21_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_22_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_22_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_22_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_23_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_23_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_23_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_24_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_24_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_24_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_25_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_25_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_25_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_26_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_26_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_26_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_27_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_27_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_27_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_28_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_28_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_28_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_29_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_29_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_29_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_30_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_30_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2"));
            fleF020_DOCTOR_MSTR_UPDATE.set_SetValue("DOC_LOC_30_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3"));

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
    //# fleF027_DOC_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:02:33 PM
    //#-----------------------------------------
    private void fleF027_DOC_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF027_DOC_ADD.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF027_DOC_ADD.set_SetValue("FILLER", !Fixed, fleF027_DOC.GetStringValue("FILLER"));
            fleF027_DOC_ADD.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));
            fleF027_DOC_ADD.set_SetValue("CONTACTS_GIVEN_NAMES", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_GIVEN_NAMES"));
            fleF027_DOC_ADD.set_SetValue("CONTACTS_SURNAME", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_SURNAME"));
            fleF027_DOC_ADD.set_SetValue("CONTACTS_INIT_S1", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_INIT_S1"));
            fleF027_DOC_ADD.set_SetValue("CONTACTS_INIT_S2", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_INIT_S2"));
            fleF027_DOC_ADD.set_SetValue("CONTACTS_INIT_S3", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_INIT_S3"));
            fleF027_DOC_ADD.set_SetValue("CONTACTS_TITLE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TITLE"));
            fleF027_DOC_ADD.set_SetValue("CONTACTS_SEX", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_SEX"));
            fleF027_DOC_ADD.set_SetValue("BILLING_ENTRY_FLAG", !Fixed, fleF027_DOC.GetStringValue("BILLING_ENTRY_FLAG"));
            fleF027_DOC_ADD.set_SetValue("LOGON_USERNAME", !Fixed, fleF027_DOC.GetStringValue("LOGON_USERNAME"));

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
    //# fleF028_DOC_HOME_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:02:34 PM
    //#-----------------------------------------
    private void fleF028_DOC_HOME_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME_ADD.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME_ADD.set_SetValue("FILLER", !Fixed, fleF027_DOC.GetStringValue("FILLER"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_LOCATION", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_LOCATION"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_ADDR_1", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_1"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_ADDR_2", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_2"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_ADDR_3", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_3"));
            fleF028_DOC_HOME_ADD.set_SetValue("POSTAL_CODE", !Fixed, fleF028_DOC_HOME.GetStringValue("POSTAL_CODE"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_EMAIL_ADDR", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_EMAIL_ADDR"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_PHONE_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PHONE_NBR"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_PHONE_EXT", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PHONE_EXT"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_PAGER_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PAGER_NBR"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_CELL_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_CELL_NBR"));
            fleF028_DOC_HOME_ADD.set_SetValue("CONTACTS_FAX_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_FAX_NBR"));
            fleF028_DOC_HOME_ADD.set_SetValue("NEWSLETTER_FLAG", !Fixed, fleF028_DOC_HOME.GetStringValue("NEWSLETTER_FLAG"));

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
    //# fleF028_DOC_HOME_UPDATE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:02:34 PM
    //#-----------------------------------------
    private void fleF028_DOC_HOME_UPDATE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME_UPDATE.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME_UPDATE.set_SetValue("FILLER", !Fixed, fleF027_DOC.GetStringValue("FILLER"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));
            //TODO: Manual steps may be required.
            fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_LOCATION", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_LOCATION"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_ADDR_1", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_1"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_ADDR_2", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_2"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_ADDR_3", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_3"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("POSTAL_CODE", !Fixed, fleF028_DOC_HOME.GetStringValue("POSTAL_CODE"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_EMAIL_ADDR", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_EMAIL_ADDR"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_PHONE_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PHONE_NBR"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_PHONE_EXT", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PHONE_EXT"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_PAGER_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PAGER_NBR"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_CELL_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_CELL_NBR"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("CONTACTS_FAX_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_FAX_NBR"));
            fleF028_DOC_HOME_UPDATE.set_SetValue("NEWSLETTER_FLAG", !Fixed, fleF028_DOC_HOME.GetStringValue("NEWSLETTER_FLAG"));

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
    //# fleF028_DOC_OFFICE_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:02:35 PM
    //#-----------------------------------------
    private void fleF028_DOC_OFFICE_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE_ADD.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE_ADD.set_SetValue("FILLER", !Fixed, fleF027_DOC.GetStringValue("FILLER"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_LOCATION", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_LOCATION"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_ADDR_1", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_1"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_ADDR_2", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_2"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_ADDR_3", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_3"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("POSTAL_CODE", !Fixed, fleF028_DOC_HOME.GetStringValue("POSTAL_CODE"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_EMAIL_ADDR", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_EMAIL_ADDR"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_PHONE_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PHONE_NBR"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_PHONE_EXT", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PHONE_EXT"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_PAGER_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PAGER_NBR"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_CELL_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_CELL_NBR"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("CONTACTS_FAX_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_FAX_NBR"));
            fleF028_DOC_OFFICE_ADD.set_SetValue("NEWSLETTER_FLAG", !Fixed, fleF028_DOC_HOME.GetStringValue("NEWSLETTER_FLAG"));

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
    //# fleF028_DOC_OFFICE_UPDATE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:02:35 PM
    //#-----------------------------------------
    private void fleF028_DOC_OFFICE_UPDATE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("FILLER", !Fixed, fleF027_DOC.GetStringValue("FILLER"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_TYPE", !Fixed, fleF027_DOC.GetStringValue("CONTACTS_TYPE"));
            //TODO: Manual steps may be required.
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_LOCATION", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_LOCATION"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_ADDR_1", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_1"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_ADDR_2", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_2"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_ADDR_3", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_ADDR_3"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("POSTAL_CODE", !Fixed, fleF028_DOC_HOME.GetStringValue("POSTAL_CODE"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_EMAIL_ADDR", !Fixed, fleF028_DOC_HOME.GetStringValue("CONTACTS_EMAIL_ADDR"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_PHONE_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PHONE_NBR"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_PHONE_EXT", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PHONE_EXT"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_PAGER_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_PAGER_NBR"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_CELL_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_CELL_NBR"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("CONTACTS_FAX_NBR", !Fixed, fleF028_DOC_HOME.GetDecimalValue("CONTACTS_FAX_NBR"));
            fleF028_DOC_OFFICE_UPDATE.set_SetValue("NEWSLETTER_FLAG", !Fixed, fleF028_DOC_HOME.GetStringValue("NEWSLETTER_FLAG"));

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


    #region "Transaction Management Procedures(F020_INFO_IMPORT_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:27 PM

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
        fleF020_INFO_EXPORT.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF027_DOC.Transaction = m_trnTRANS_UPDATE;
        fleF028_DOC_HOME.Transaction = m_trnTRANS_UPDATE;
        fleF028_DOC_OFFICE.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR_ADD.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR_UPDATE.Transaction = m_trnTRANS_UPDATE;
        fleF027_DOC_ADD.Transaction = m_trnTRANS_UPDATE;
        fleF028_DOC_HOME_ADD.Transaction = m_trnTRANS_UPDATE;
        fleF028_DOC_HOME_UPDATE.Transaction = m_trnTRANS_UPDATE;
        fleF028_DOC_OFFICE_ADD.Transaction = m_trnTRANS_UPDATE;
        fleF028_DOC_OFFICE_UPDATE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(F020_INFO_IMPORT_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:27 PM

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
            fleF020_INFO_EXPORT.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF027_DOC.Dispose();
            fleF028_DOC_HOME.Dispose();
            fleF028_DOC_OFFICE.Dispose();
            fleF020_DOCTOR_MSTR_ADD.Dispose();
            fleF020_DOCTOR_MSTR_UPDATE.Dispose();
            fleF027_DOC_ADD.Dispose();
            fleF028_DOC_HOME_ADD.Dispose();
            fleF028_DOC_HOME_UPDATE.Dispose();
            fleF028_DOC_OFFICE_ADD.Dispose();
            fleF028_DOC_OFFICE_UPDATE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(F020_INFO_IMPORT_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF020_INFO_EXPORT.QTPForMissing())
            {
                // --> GET F020_INFO_EXPORT <--

                fleF020_INFO_EXPORT.GetData();
                // --> End GET F020_INFO_EXPORT <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

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

                        while (fleF028_DOC_HOME.QTPForMissing("3"))
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
                            m_strWhere.Append(Common.StringToField("H"));

                            fleF028_DOC_HOME.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F028_DOC_HOME <--

                            while (fleF028_DOC_OFFICE.QTPForMissing("4"))
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
                                m_strWhere.Append(Common.StringToField("O"));

                                fleF028_DOC_OFFICE.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F028_DOC_OFFICE <--


                                if (Transaction())
                                {




                                    fleF020_DOCTOR_MSTR_ADD.OutPut(OutPutType.Add, null, !fleF020_DOCTOR_MSTR.Exists());







                                    fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update, null, fleF020_DOCTOR_MSTR.Exists());
                                    






                                    fleF027_DOC_ADD.OutPut(OutPutType.Add, null, !fleF027_DOC.Exists());
                                    






                                    fleF028_DOC_HOME_ADD.OutPut(OutPutType.Add, null, !fleF028_DOC_HOME.Exists());
                                    


                                    while (fleF028_DOC_HOME_UPDATE.QTPForMissing())
                                    {
                                        // --> GET F028_DOC_HOME_UPDATE <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleF028_DOC_HOME_UPDATE.ElementOwner("DOC_NBR")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleF020_INFO_EXPORT.GetStringValue("DOC_NBR")));
                                        m_strWhere.Append(" And ").Append(fleF028_DOC_HOME_UPDATE.ElementOwner("FILLER")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(" "));
                                        m_strWhere.Append(" And ").Append(fleF028_DOC_HOME_UPDATE.ElementOwner("CONTACTS_TYPE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField("D"));
                                        m_strWhere.Append(" And ").Append(fleF028_DOC_HOME_UPDATE.ElementOwner("CONTACTS_LOCATION")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField("H"));

                                        fleF028_DOC_HOME_UPDATE.GetData(m_strWhere.ToString());
                                        // --> End GET F028_DOC_HOME_UPDATE <--






                                        fleF028_DOC_HOME_UPDATE.OutPut(OutPutType.Update, null, fleF028_DOC_HOME.Exists());
                                        


                                    }






                                    fleF028_DOC_OFFICE_ADD.OutPut(OutPutType.Add, null, !fleF028_DOC_OFFICE.Exists());
                                    


                                    while (fleF028_DOC_OFFICE_UPDATE.QTPForMissing())
                                    {
                                        // --> GET F028_DOC_OFFICE_UPDATE <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleF028_DOC_OFFICE_UPDATE.ElementOwner("DOC_NBR")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleF020_INFO_EXPORT.GetStringValue("DOC_NBR")));
                                        m_strWhere.Append(" And ").Append(fleF028_DOC_OFFICE_UPDATE.ElementOwner("FILLER")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(" "));
                                        m_strWhere.Append(" And ").Append(fleF028_DOC_OFFICE_UPDATE.ElementOwner("CONTACTS_TYPE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField("D"));
                                        m_strWhere.Append(" And ").Append(fleF028_DOC_OFFICE_UPDATE.ElementOwner("CONTACTS_LOCATION")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField("O"));

                                        m_strOrderBy = new StringBuilder(" ORDER BY ");
                                        m_strOrderBy.Append(fleF028_DOC_OFFICE_UPDATE.ElementOwner("FILLER"));
                                        m_strOrderBy.Append(", ").Append(fleF028_DOC_OFFICE_UPDATE.ElementOwner("DOC_NBR"));
                                        m_strOrderBy.Append(", ").Append(fleF028_DOC_OFFICE_UPDATE.ElementOwner("CONTACTS_TYPE"));
                                        m_strOrderBy.Append(", ").Append(fleF028_DOC_OFFICE_UPDATE.ElementOwner("CONTACTS_LOCATION"));

                                        fleF028_DOC_OFFICE_UPDATE.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                                        // --> End GET F028_DOC_OFFICE_UPDATE <--






                                        fleF028_DOC_OFFICE_UPDATE.OutPut(OutPutType.Update, null, fleF028_DOC_OFFICE.Exists());
                                        

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
            EndRequest("ONE_1");

        }

    }




    #endregion


}
//ONE_1




