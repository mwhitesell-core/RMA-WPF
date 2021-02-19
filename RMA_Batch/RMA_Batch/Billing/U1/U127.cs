
#region "Screen Comments"

// #V PROGRAM-ID.     U127.QTS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// - Transfer F020-DOCTOR-MSTR and F119-DOCTOR-YTD to their
// history files with current ep nbr
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 95/NOV/17  ____   M.C.     - original
// 1999/Feb/18          S.B.     - Checked for Y2K.
// 2003/dec/24  A.A.  - alpha doctor nbr
// 2006/mar/06  M.C.  - change process limit to 20000
// 2006/jun/07  b.e.  - change process limit to 30000
// 2015/Jan/07  MC1  - add to select if rec-type <> `B` ie exclude message records from f119
// 2015/Sep/10  MC2  - exclude doc-nbr `000`  when transfer record to f119-history
// - add `on errors report` when output f119-history
// set process limit 10000
// set process limit 20000


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U127 : BaseClassControl
{

    private U127 m_U127;

    public U127(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U127(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U127 != null))
        {
            m_U127.CloseTransactionObjects();
            m_U127 = null;
        }
    }

    public U127 GetU127(int Level)
    {
        if (m_U127 == null)
        {
            m_U127 = new U127("U127", Level);
        }
        else
        {
            m_U127.ResetValues();
        }
        return m_U127;
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

            U127_RUN_0_1 RUN_0_1 = new U127_RUN_0_1(Name, Level);
            RUN_0_1.Run();
            RUN_0_1.Dispose();
            RUN_0_1 = null;

            U127_RUN_1_2 RUN_1_2 = new U127_RUN_1_2(Name, Level);
            RUN_1_2.Run();
            RUN_1_2.Dispose();
            RUN_1_2 = null;

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



public class U127_RUN_0_1 : U127
{

    public U127_RUN_0_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOC_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOC_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOC_MSTR_HISTORY", "F020_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF020_ADD.SetItemFinals += fleF020_ADD_SetItemFinals;
        fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;
        fleF020_DOC_MSTR_HISTORY.InitializeItems += fleF020_DOC_MSTR_HISTORY_AutomaticItemInitialization;
        fleF020_ADD.InitializeItems += fleF020_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U127_RUN_0_1)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020_DOCTOR_EXTRA;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF020_DOC_MSTR_HISTORY;
    private SqlFileObject fleF020_ADD;

    private void fleF020_ADD_SetItemFinals()
    {

        try
        {
            fleF020_ADD.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


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


    #region "Standard Generated Procedures(U127_RUN_0_1)"


    #region "Automatic Item Initialization(U127_RUN_0_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:53 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_EXTRA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:53 PM
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
    //# fleF020_DOC_MSTR_HISTORY_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:53 PM
    //#-----------------------------------------
    private void fleF020_DOC_MSTR_HISTORY_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_BANK_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_BANK_BRANCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_BANK_ACCT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDGUA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDGUB", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDGUC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDGUD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDEAR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_TOTINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_EP_DATE_DEPOSIT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_TOTINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_EP_CEIEXP", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_ADJCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_ADJCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_CEICEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_CEICEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("CEICEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("CEICEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("YTDCEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("YTDCEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_PAYEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDDED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_EP_PED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_EP_PAY_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_EP_PAY_SUB_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            //TODO: Manual steps may be required.
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YRLY_TARGET_REVENUE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_TARGET_REVENUE"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_CEIREQ", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEIREQ"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDREQ", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDREQ"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_CEITAR", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEITAR"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("DOC_YTDTAR", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDTAR"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("CEIREQ_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("CEIREQ_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("YTDREQ_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("YTDREQ_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("CEITAR_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("CEITAR_PRT_FORMAT"));
            fleF020_DOC_MSTR_HISTORY.set_SetValue("YTDTAR_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("YTDTAR_PRT_FORMAT"));

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
    //# fleF020_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:53 PM
    //#-----------------------------------------
    private void fleF020_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_ADD.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF020_ADD.set_SetValue("DOC_BANK_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_ADD.set_SetValue("DOC_BANK_BRANCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_ADD.set_SetValue("DOC_BANK_ACCT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
            fleF020_ADD.set_SetValue("DOC_YTDGUA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
            fleF020_ADD.set_SetValue("DOC_YTDGUB", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
            fleF020_ADD.set_SetValue("DOC_YTDGUC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
            fleF020_ADD.set_SetValue("DOC_YTDGUD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
            fleF020_ADD.set_SetValue("DOC_YTDCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
            fleF020_ADD.set_SetValue("DOC_YTDCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
            fleF020_ADD.set_SetValue("DOC_YTDEAR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
            fleF020_ADD.set_SetValue("DOC_YTDINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
            fleF020_ADD.set_SetValue("DOC_YTDEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
            fleF020_ADD.set_SetValue("DOC_TOTINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_ADD.set_SetValue("DOC_EP_DATE_DEPOSIT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_ADD.set_SetValue("DOC_TOTINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
            fleF020_ADD.set_SetValue("DOC_EP_CEIEXP", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_ADD.set_SetValue("DOC_ADJCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
            fleF020_ADD.set_SetValue("DOC_ADJCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
            fleF020_ADD.set_SetValue("DOC_CEICEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
            fleF020_ADD.set_SetValue("DOC_CEICEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
            fleF020_ADD.set_SetValue("CEICEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_ADD.set_SetValue("CEICEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_ADD.set_SetValue("YTDCEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_ADD.set_SetValue("YTDCEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_ADD.set_SetValue("DOC_YTDINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_ADD.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_ADD.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_ADD.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_ADD.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_ADD.set_SetValue("DOC_PAYEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
            fleF020_ADD.set_SetValue("DOC_YTDDED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
            fleF020_ADD.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF020_ADD.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_ADD.set_SetValue("DOC_EP_PED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED"));
            fleF020_ADD.set_SetValue("DOC_EP_PAY_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_ADD.set_SetValue("DOC_EP_PAY_SUB_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            //TODO: Manual steps may be required.
            fleF020_ADD.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE"));
            fleF020_ADD.set_SetValue("DOC_YRLY_TARGET_REVENUE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_TARGET_REVENUE"));
            fleF020_ADD.set_SetValue("DOC_CEIREQ", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEIREQ"));
            fleF020_ADD.set_SetValue("DOC_YTDREQ", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDREQ"));
            fleF020_ADD.set_SetValue("DOC_CEITAR", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEITAR"));
            fleF020_ADD.set_SetValue("DOC_YTDTAR", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDTAR"));
            fleF020_ADD.set_SetValue("CEIREQ_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("CEIREQ_PRT_FORMAT"));
            fleF020_ADD.set_SetValue("YTDREQ_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("YTDREQ_PRT_FORMAT"));
            fleF020_ADD.set_SetValue("CEITAR_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("CEITAR_PRT_FORMAT"));
            fleF020_ADD.set_SetValue("YTDTAR_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("YTDTAR_PRT_FORMAT"));
            //TODO: Manual steps may be required.
            fleF020_ADD.set_SetValue("EP_NBR", !Fixed, fleF020_DOC_MSTR_HISTORY.GetDecimalValue("EP_NBR"));

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


    #region "Transaction Management Procedures(U127_RUN_0_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:53 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOC_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleF020_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U127_RUN_0_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:53 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF020_DOC_MSTR_HISTORY.Dispose();
            fleF020_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U127_RUN_0_1)"


    public void Run()
    {

        try
        {
            Request("RUN_0_1");



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

                    while (fleCONSTANTS_MSTR_REC_6.QTPForMissing("2"))
                    {
                        // --> GET CONSTANTS_MSTR_REC_6 <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                        m_strWhere.Append((6));

                        fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET CONSTANTS_MSTR_REC_6 <--

                        while (fleF020_DOC_MSTR_HISTORY.QTPForMissing("3"))
                        {
                            // --> GET F020_DOC_MSTR_HISTORY <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOC_MSTR_HISTORY.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" And ").Append(fleF020_DOC_MSTR_HISTORY.ElementOwner("EP_NBR")).Append(" = ");
                            m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                            fleF020_DOC_MSTR_HISTORY.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F020_DOC_MSTR_HISTORY <--


                            if (Transaction())
                            {
                                fleF020_ADD.OutPut(OutPutType.Add, null, !fleF020_DOC_MSTR_HISTORY.Exists());

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
            EndRequest("RUN_0_1");

        }

    }







    #endregion


}
//RUN_0_1



public class U127_RUN_1_2 : U127
{

    public U127_RUN_1_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(U127_RUN_1_2)"

    private SqlFileObject fleF119_DOCTOR_YTD;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("REC_TYPE")) != "B" & QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")) != "000")
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

    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;


    #endregion


    #region "Standard Generated Procedures(U127_RUN_1_2)"


    #region "Automatic Item Initialization(U127_RUN_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U127_RUN_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:53 PM

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
        fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF119_DOCTOR_YTD_HISTORY.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U127_RUN_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:53 PM

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
            fleF119_DOCTOR_YTD.Dispose();
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF119_DOCTOR_YTD_HISTORY.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U127_RUN_1_2)"


    public void Run()
    {

        try
        {
            Request("RUN_1_2");

            while (fleF119_DOCTOR_YTD.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD <--

                fleF119_DOCTOR_YTD.GetData();
                // --> End GET F119_DOCTOR_YTD <--

                while (fleCONSTANTS_MSTR_REC_6.QTPForMissing("1"))
                {
                    // --> GET CONSTANTS_MSTR_REC_6 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                    m_strWhere.Append((6));

                    fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString());
                    // --> End GET CONSTANTS_MSTR_REC_6 <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("DOC_NBR", fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR"));


                            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("COMP_CODE", fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE"));


                            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("PROCESS_SEQ", fleF119_DOCTOR_YTD.GetDecimalValue("PROCESS_SEQ"));


                            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("COMP_CODE_GROUP", fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE_GROUP"));


                            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("REC_TYPE", fleF119_DOCTOR_YTD.GetStringValue("REC_TYPE"));


                            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("AMT_MTD", fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD"));


                            fleF119_DOCTOR_YTD_HISTORY.set_SetValue("AMT_YTD", fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD"));

                            fleF119_DOCTOR_YTD_HISTORY.OutPut(OutPutType.Add);

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
            EndRequest("RUN_1_2");

        }

    }







    #endregion


}
//RUN_1_2




