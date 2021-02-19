
#region "Screen Comments"

// -----------------------------------------------------------------------
// /T/ YEAREND PURGE PART 1
// /A/ 
// /P/ Dyad Systems Inc.
// /Q/ QTP
// /M/ Modification History
// /M/ --------------------
// /M/ Date Programmer Description
// /M/
// /M/ 950627 B. LANGENDOCK Creation
// /M/ 951106     M. CHAN  - NO LONGER NEEDED TO MOVE TO F020 &
// /M/      F119 HISTORY FILES, THESE SHOULD BE
// /M/      DONE AT MONTHEND
// /M/ 970711 M. CHAN  - MODIFY REQUEST SETUP_F113_NEXT_YEAR
// /M/      TO INCLUDE CHOOSE, SORTED STMT AND
// /M/      ADD AT COMP-CODE WITH ON ERRORS REPORT
// /M/      CHANGE EP-NBR-TO TO SET 13TH MONTH
// /M/ 1999/May/16 S.B.  - Y2K checked.
// /M/ 2003/dec/24 A.A.  - alpha doctor nbr
// /M/ 2006/may/23 M.C.      - modify  REQUEST SETUP_F113_NEXT_YEAR
// /M/      TO change ep-nbr-to to set 1 year ahead
// /M/ 2011/Jun/22 MC1       - create records for next year  into f112 or f113 only if
// /M/      doctors terminated < 3 years or still active
// /M/ 2012/Jun/19 MC2       - add `set lock record update` and `on calculation/edit erros report`
// /M/ 2016/Jul/12 MC3            - do not roll over for comp code CANCEL, BILL, MANPY, CPPDED, EXEHON, KEYHRS          
// in f113 as Helena requested
// -----------------------------------------------------------------------
// /D/                       TRADE SECRET NOTICE
// /D/
// /D/  The techniques, algorithms, and processes contained herein, or
// /D/  any modification, extraction, or extrapolation thereof, are the
// /D/  proprietary property and trade secrets of Dyad Systems Inc.
// /D/  and except as provided for by a License Agreement, shall not be
// /D/  duplicated, used, or disclosed for any purpose, in whole or part
// /D/  without the express written permission of Dyad Systems Inc.
// -----------------------------------------------------------------------


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Mp_YEAREND_1 : BaseClassControl
{

    private Mp_YEAREND_1 m_Mp_YEAREND_1;

    public Mp_YEAREND_1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        T_CURRENT_EP_NBR = new CoreDecimal("T_CURRENT_EP_NBR", 1, this, ResetTypes.ResetAtStartup);
        T_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("T_CURRENT_EP_NBR_MINUS1", 1, this, ResetTypes.ResetAtStartup);
        T_NEXT_YR_YY = new CoreDecimal("T_NEXT_YR_YY", 1, this, ResetTypes.ResetAtStartup);
        T_NEXT_YR_FIRST_EP_NBR = new CoreDecimal("T_NEXT_YR_FIRST_EP_NBR", 1, this, ResetTypes.ResetAtStartup);


    }

    public Mp_YEAREND_1(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        T_CURRENT_EP_NBR = new CoreDecimal("T_CURRENT_EP_NBR", 1, this, ResetTypes.ResetAtStartup);
        T_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("T_CURRENT_EP_NBR_MINUS1", 1, this, ResetTypes.ResetAtStartup);
        T_NEXT_YR_YY = new CoreDecimal("T_NEXT_YR_YY", 1, this, ResetTypes.ResetAtStartup);
        T_NEXT_YR_FIRST_EP_NBR = new CoreDecimal("T_NEXT_YR_FIRST_EP_NBR", 1, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_Mp_YEAREND_1 != null))
        {
            m_Mp_YEAREND_1.CloseTransactionObjects();
            m_Mp_YEAREND_1 = null;
        }
    }

    public Mp_YEAREND_1 GetMp_YEAREND_1(int Level)
    {
        if (m_Mp_YEAREND_1 == null)
        {
            m_Mp_YEAREND_1 = new Mp_YEAREND_1("Mp_YEAREND_1", Level);
        }
        else
        {
            m_Mp_YEAREND_1.ResetValues();
        }
        return m_Mp_YEAREND_1;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal T_CURRENT_EP_NBR;
    protected CoreDecimal T_CURRENT_EP_NBR_MINUS1;
    protected CoreDecimal T_NEXT_YR_YY;

    protected CoreDecimal T_NEXT_YR_FIRST_EP_NBR;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            Mp_YEAREND_1_GET_CONST_EP_NBR_1 GET_CONST_EP_NBR_1 = new Mp_YEAREND_1_GET_CONST_EP_NBR_1(Name, Level);
            GET_CONST_EP_NBR_1.Run();
            GET_CONST_EP_NBR_1.Dispose();
            GET_CONST_EP_NBR_1 = null;

            Mp_YEAREND_1_MOVE_F110_TO_HISTORY_2 MOVE_F110_TO_HISTORY_2 = new Mp_YEAREND_1_MOVE_F110_TO_HISTORY_2(Name, Level);
            MOVE_F110_TO_HISTORY_2.Run();
            MOVE_F110_TO_HISTORY_2.Dispose();
            MOVE_F110_TO_HISTORY_2 = null;

            Mp_YEAREND_1_SETUP_F113_NEXT_YEAR_3 SETUP_F113_NEXT_YEAR_3 = new Mp_YEAREND_1_SETUP_F113_NEXT_YEAR_3(Name, Level);
            SETUP_F113_NEXT_YEAR_3.Run();
            SETUP_F113_NEXT_YEAR_3.Dispose();
            SETUP_F113_NEXT_YEAR_3 = null;

            Mp_YEAREND_1_SPLIT_F113_YEAR_INTO_SUBFILES_4 SPLIT_F113_YEAR_INTO_SUBFILES_4 = new Mp_YEAREND_1_SPLIT_F113_YEAR_INTO_SUBFILES_4(Name, Level);
            SPLIT_F113_YEAR_INTO_SUBFILES_4.Run();
            SPLIT_F113_YEAR_INTO_SUBFILES_4.Dispose();
            SPLIT_F113_YEAR_INTO_SUBFILES_4 = null;

            Mp_YEAREND_1_RESET_F020_VALUES_5 RESET_F020_VALUES_5 = new Mp_YEAREND_1_RESET_F020_VALUES_5(Name, Level);
            RESET_F020_VALUES_5.Run();
            RESET_F020_VALUES_5.Dispose();
            RESET_F020_VALUES_5 = null;

            Mp_YEAREND_1_SETUP_F112_NEXT_YEAR_6 SETUP_F112_NEXT_YEAR_6 = new Mp_YEAREND_1_SETUP_F112_NEXT_YEAR_6(Name, Level);
            SETUP_F112_NEXT_YEAR_6.Run();
            SETUP_F112_NEXT_YEAR_6.Dispose();
            SETUP_F112_NEXT_YEAR_6 = null;

            Mp_YEAREND_1_SPLIT_F112_YEAR_INTO_SUBFILESI_7 SPLIT_F112_YEAR_INTO_SUBFILESI_7 = new Mp_YEAREND_1_SPLIT_F112_YEAR_INTO_SUBFILESI_7(Name, Level);
            SPLIT_F112_YEAR_INTO_SUBFILESI_7.Run();
            SPLIT_F112_YEAR_INTO_SUBFILESI_7.Dispose();
            SPLIT_F112_YEAR_INTO_SUBFILESI_7 = null;

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



public class Mp_YEAREND_1_GET_CONST_EP_NBR_1 : Mp_YEAREND_1
{

    public Mp_YEAREND_1_GET_CONST_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_YEAREND_1_GET_CONST_EP_NBR_1)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;

    private void fleCONSTANTS_MSTR_REC_6_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
            strSQL.Append(6);


            ChooseClause = strSQL.ToString();


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


    #region "Standard Generated Procedures(Mp_YEAREND_1_GET_CONST_EP_NBR_1)"


    #region "Automatic Item Initialization(Mp_YEAREND_1_GET_CONST_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_YEAREND_1_GET_CONST_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:44 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Mp_YEAREND_1_GET_CONST_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:44 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_YEAREND_1_GET_CONST_EP_NBR_1)"


    public void Run()
    {

        try
        {
            Request("GET_CONST_EP_NBR_1");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                if (Transaction())
                {
                    T_CURRENT_EP_NBR.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR");
                    T_CURRENT_EP_NBR_MINUS1.Value = (fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1);
                    T_NEXT_YR_YY.Value = (QDesign.Floor(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") / 100) + 1);
                    T_NEXT_YR_FIRST_EP_NBR.Value = (T_NEXT_YR_YY.Value * 100) + 1;

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
            EndRequest("GET_CONST_EP_NBR_1");

        }

    }







    #endregion


}
//GET_CONST_EP_NBR_1



public class Mp_YEAREND_1_MOVE_F110_TO_HISTORY_2 : Mp_YEAREND_1
{

    public Mp_YEAREND_1_MOVE_F110_TO_HISTORY_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF110_COMPENSATION_HISTORY.SetItemFinals += FleF110_COMPENSATION_HISTORY_SetItemFinals;
    }


    #region "Declarations (Variables, Files and Transactions)(Mp_YEAREND_1_MOVE_F110_TO_HISTORY_2)"

    private SqlFileObject fleF110_COMPENSATION;
    private SqlFileObject fleF110_COMPENSATION_HISTORY;

    private void FleF110_COMPENSATION_HISTORY_SetItemFinals()
    {
        try
        {
            fleF110_COMPENSATION_HISTORY.set_SetValue("DOC_NBR", fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("EP_NBR", fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("PROCESS_SEQ", fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("COMP_CODE", fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("COMP_TYPE", fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("FACTOR", fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("FACTOR_OVERRIDE", fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("COMP_UNITS", fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("AMT_GROSS", fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("AMT_NET", fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("EP_NBR_ENTRY", fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("COMPENSATION_STATUS", fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("LAST_MOD_DATE", fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("LAST_MOD_TIME", fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("LAST_MOD_USER_ID", fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_COMPENSATION_HISTORY.set_SetValue("FILLER", fleF110_COMPENSATION.GetStringValue("FILLER"));
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


    #region "Standard Generated Procedures(Mp_YEAREND_1_MOVE_F110_TO_HISTORY_2)"


    #region "Automatic Item Initialization(Mp_YEAREND_1_MOVE_F110_TO_HISTORY_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_YEAREND_1_MOVE_F110_TO_HISTORY_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:44 PM

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
        fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
        fleF110_COMPENSATION_HISTORY.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Mp_YEAREND_1_MOVE_F110_TO_HISTORY_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:44 PM

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
            fleF110_COMPENSATION.Dispose();
            fleF110_COMPENSATION_HISTORY.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_YEAREND_1_MOVE_F110_TO_HISTORY_2)"


    public void Run()
    {

        try
        {
            Request("MOVE_F110_TO_HISTORY_2");

            while (fleF110_COMPENSATION.QTPForMissing())
            {
                // --> GET F110_COMPENSATION <--

                fleF110_COMPENSATION.GetData();
                // --> End GET F110_COMPENSATION <--


                if (Transaction())
                {




                    fleF110_COMPENSATION_HISTORY.OutPut(OutPutType.Add);
                    //Parent:DOC_DATE_FAC_TERM)    'Parent:F113_DEFAULT_COMP_KEY)    'Parent:DOC_DATE_FAC_TERM)    'Parent:PYCDCEILING_KEY

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
            EndRequest("MOVE_F110_TO_HISTORY_2");

        }

    }




    #endregion


}
//MOVE_F110_TO_HISTORY_2



public class Mp_YEAREND_1_SETUP_F113_NEXT_YEAR_3 : Mp_YEAREND_1
{

    public Mp_YEAREND_1_SETUP_F113_NEXT_YEAR_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF113_DEFAULT_COMP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF113_NEXT_YR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "F113_NEXT_YR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF113_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "F113_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        TERMINATED_DAYS.GetValue += TERMINATED_DAYS_GetValue;
        DOC_DATE_FAC_TERM.GetValue += DOC_DATE_FAC_TERM_GetValue;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF113_NEXT_YR.InitializeItems += fleF113_NEXT_YR_AutomaticItemInitialization;
        fleF113_ADD.InitializeItems += fleF113_ADD_AutomaticItemInitialization;

    }

    #region "Declarations (Variables, Files and Transactions)(Mp_YEAREND_1_SETUP_F113_NEXT_YEAR_3)"

    private SqlFileObject fleF113_DEFAULT_COMP;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF113_NEXT_YR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_TO")) == QDesign.NULL(T_CURRENT_EP_NBR.Value) | QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_TO")) == QDesign.NULL(T_CURRENT_EP_NBR_MINUS1.Value) & (QDesign.NULL(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")) != "CANCEL" & QDesign.NULL(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")) != "BILL" & QDesign.NULL(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")) != "MANPY" & QDesign.NULL(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")) != "CPPDED" & QDesign.NULL(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")) != "EXEHON" & QDesign.NULL(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")) != "KEYHRS"))
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

    private DDecimal DOC_DATE_FAC_TERM = new DDecimal("DOC_DATE_FAC_TERM", 8);
    private void DOC_DATE_FAC_TERM_GetValue(ref decimal Value)
    {
        try
        {
            Value = QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"), 2));
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

    private DDecimal TERMINATED_DAYS = new DDecimal("TERMINATED_DAYS", 5);
    private void TERMINATED_DAYS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (DOC_DATE_FAC_TERM.Value != 0)
            {
                CurrentValue = QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(DOC_DATE_FAC_TERM.Value);
            }

            Value = CurrentValue;

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
    private SqlFileObject fleF113_ADD;


    #endregion


    #region "Standard Generated Procedures(Mp_YEAREND_1_SETUP_F113_NEXT_YEAR_3)"


    #region "Automatic Item Initialization(Mp_YEAREND_1_SETUP_F113_NEXT_YEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:46 PM

    //#-----------------------------------------
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:45 PM
    //#-----------------------------------------
    private void fleF190_COMP_CODES_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("COMP_CODE", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE"));
            fleF190_COMP_CODES.set_SetValue("FACTOR", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("FACTOR"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_DATE", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_DATE"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_TIME", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_TIME"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:45 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR"));

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
    //# fleF113_NEXT_YR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:45 PM
    //#-----------------------------------------
    private void fleF113_NEXT_YR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF113_NEXT_YR.set_SetValue("DOC_NBR", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR"));
            fleF113_NEXT_YR.set_SetValue("EP_NBR_FROM", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_FROM"));
            fleF113_NEXT_YR.set_SetValue("COMP_CODE", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE"));
            fleF113_NEXT_YR.set_SetValue("EP_NBR_TO", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_TO"));
            fleF113_NEXT_YR.set_SetValue("FACTOR", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("FACTOR"));
            fleF113_NEXT_YR.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("FACTOR_OVERRIDE"));
            fleF113_NEXT_YR.set_SetValue("COMP_UNITS", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("COMP_UNITS"));
            fleF113_NEXT_YR.set_SetValue("AMT_GROSS", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS"));
            fleF113_NEXT_YR.set_SetValue("AMT_NET", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET"));
            fleF113_NEXT_YR.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_ENTRY"));
            fleF113_NEXT_YR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_DATE"));
            fleF113_NEXT_YR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_TIME"));
            fleF113_NEXT_YR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("LAST_MOD_USER_ID"));
            fleF113_NEXT_YR.set_SetValue("CORE_COMMENT", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("CORE_COMMENT"));
            fleF113_NEXT_YR.set_SetValue("FILLER", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("FILLER"));

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
    //# fleF113_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:45 PM
    //#-----------------------------------------
    private void fleF113_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF113_ADD.set_SetValue("DOC_NBR", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR"));
            fleF113_ADD.set_SetValue("EP_NBR_FROM", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_FROM"));
            fleF113_ADD.set_SetValue("COMP_CODE", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE"));
            fleF113_ADD.set_SetValue("EP_NBR_TO", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_TO"));
            fleF113_ADD.set_SetValue("FACTOR", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("FACTOR"));
            fleF113_ADD.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("FACTOR_OVERRIDE"));
            fleF113_ADD.set_SetValue("COMP_UNITS", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("COMP_UNITS"));
            fleF113_ADD.set_SetValue("AMT_GROSS", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS"));
            fleF113_ADD.set_SetValue("AMT_NET", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET"));
            fleF113_ADD.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_ENTRY"));
            fleF113_ADD.set_SetValue("LAST_MOD_DATE", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_DATE"));
            fleF113_ADD.set_SetValue("LAST_MOD_TIME", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_TIME"));
            fleF113_ADD.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("LAST_MOD_USER_ID"));
            fleF113_ADD.set_SetValue("CORE_COMMENT", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("CORE_COMMENT"));
            fleF113_ADD.set_SetValue("FILLER", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(Mp_YEAREND_1_SETUP_F113_NEXT_YEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:44 PM

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
        fleF113_DEFAULT_COMP.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF113_NEXT_YR.Transaction = m_trnTRANS_UPDATE;
        fleF113_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Mp_YEAREND_1_SETUP_F113_NEXT_YEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:44 PM

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
            fleF113_DEFAULT_COMP.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF113_NEXT_YR.Dispose();
            fleF113_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_YEAREND_1_SETUP_F113_NEXT_YEAR_3)"


    public void Run()
    {

        try
        {
            Request("SETUP_F113_NEXT_YEAR_3");

            while (fleF113_DEFAULT_COMP.QTPForMissing())
            {
                // --> GET F113_DEFAULT_COMP <--

                fleF113_DEFAULT_COMP.GetData();
                // --> End GET F113_DEFAULT_COMP <--

                while (fleF190_COMP_CODES.QTPForMissing("1"))
                {
                    // --> GET F190_COMP_CODES <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")));

                    fleF190_COMP_CODES.GetData(m_strWhere.ToString());
                    // --> End GET F190_COMP_CODES <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF113_NEXT_YR.QTPForMissing("3"))
                        {
                            // --> GET F113_NEXT_YR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF113_NEXT_YR.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")));
                            m_strWhere.Append(" And ").Append(fleF113_NEXT_YR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" And ").Append(fleF113_NEXT_YR.ElementOwner("EP_NBR_FROM")).Append(" = ");
                            m_strWhere.Append((T_NEXT_YR_FIRST_EP_NBR.Value));

                            fleF113_NEXT_YR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F113_NEXT_YR <--


                            if (Transaction())
                            {

                                 if (Select_If())
                                {

                                    Sort(fleF113_DEFAULT_COMP.GetSortValue("DOC_NBR"), fleF113_DEFAULT_COMP.GetSortValue("EP_NBR_FROM"), fleF113_DEFAULT_COMP.GetSortValue("COMP_CODE"));



                                }

                            }

                        }

                    }

                }

            }


            while (Sort(fleF113_DEFAULT_COMP, fleF190_COMP_CODES, fleF020_DOCTOR_MSTR, fleF113_NEXT_YR))
            {
                fleF113_ADD.set_SetValue("DOC_NBR", fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR"));


                fleF113_ADD.set_SetValue("EP_NBR_FROM", T_NEXT_YR_FIRST_EP_NBR.Value);


                fleF113_ADD.set_SetValue("EP_NBR_TO", (fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_TO") + 100));


                fleF113_ADD.set_SetValue("EP_NBR_ENTRY", T_CURRENT_EP_NBR.Value);


                fleF113_ADD.set_SetValue("COMP_CODE", fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE"));


                fleF113_ADD.set_SetValue("FACTOR", fleF113_DEFAULT_COMP.GetDecimalValue("FACTOR"));


                fleF113_ADD.set_SetValue("FACTOR_OVERRIDE", fleF113_DEFAULT_COMP.GetStringValue("FACTOR_OVERRIDE"));


                fleF113_ADD.set_SetValue("COMP_UNITS", fleF113_DEFAULT_COMP.GetDecimalValue("COMP_UNITS"));


                fleF113_ADD.set_SetValue("AMT_GROSS", fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS"));


                fleF113_ADD.set_SetValue("AMT_NET", fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET"));


                fleF113_ADD.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF113_ADD.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF113_ADD.set_SetValue("LAST_MOD_USER_ID", "Comp.YrEndRoll");





                fleF113_ADD.OutPut(OutPutType.Add, fleF113_DEFAULT_COMP.At("DOC_NBR") || fleF113_DEFAULT_COMP.At("EP_NBR_FROM") || fleF113_DEFAULT_COMP.At("COMP_CODE"), !fleF113_NEXT_YR.Exists() & TERMINATED_DAYS.Value <= 730);
                //Parent:DOC_DATE_FAC_TERM)    'Parent:F113_DEFAULT_COMP_KEY)    'Parent:DOC_DATE_FAC_TERM)    'Parent:PYCDCEILING_KEY

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
            EndRequest("SETUP_F113_NEXT_YEAR_3");

        }

    }




    #endregion


}
//SETUP_F113_NEXT_YEAR_3



public class Mp_YEAREND_1_SPLIT_F113_YEAR_INTO_SUBFILES_4 : Mp_YEAREND_1
{

    public Mp_YEAREND_1_SPLIT_F113_YEAR_INTO_SUBFILES_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF113_DEFAULT_COMP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        T_EP_NBR_FROM_YY = new CoreDecimal("T_EP_NBR_FROM_YY", 1, this);
        fleF113_YEAREND_OLD = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F113_YEAREND_OLD", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF113_YEAREND_NEW = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F113_YEAREND_NEW", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(Mp_YEAREND_1_SPLIT_F113_YEAR_INTO_SUBFILES_4)"

    private SqlFileObject fleF113_DEFAULT_COMP;

    private CoreDecimal T_EP_NBR_FROM_YY;



    private SqlFileObject fleF113_YEAREND_OLD;




    private SqlFileObject fleF113_YEAREND_NEW;


    #endregion


    #region "Standard Generated Procedures(Mp_YEAREND_1_SPLIT_F113_YEAR_INTO_SUBFILES_4)"


    #region "Automatic Item Initialization(Mp_YEAREND_1_SPLIT_F113_YEAR_INTO_SUBFILES_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_YEAREND_1_SPLIT_F113_YEAR_INTO_SUBFILES_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:44 PM

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
        fleF113_DEFAULT_COMP.Transaction = m_trnTRANS_UPDATE;
        fleF113_YEAREND_OLD.Transaction = m_trnTRANS_UPDATE;
        fleF113_YEAREND_NEW.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Mp_YEAREND_1_SPLIT_F113_YEAR_INTO_SUBFILES_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:44 PM

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
            fleF113_DEFAULT_COMP.Dispose();
            fleF113_YEAREND_OLD.Dispose();
            fleF113_YEAREND_NEW.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_YEAREND_1_SPLIT_F113_YEAR_INTO_SUBFILES_4)"


    public void Run()
    {

        try
        {
            Request("SPLIT_F113_YEAR_INTO_SUBFILES_4");

            while (fleF113_DEFAULT_COMP.QTPForMissing())
            {
                // --> GET F113_DEFAULT_COMP <--

                fleF113_DEFAULT_COMP.GetData();
                // --> End GET F113_DEFAULT_COMP <--


                if (Transaction())
                {
                    T_EP_NBR_FROM_YY.Value = QDesign.Floor(fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_FROM") / 100);




                    SubFile(ref m_trnTRANS_UPDATE, ref fleF113_YEAREND_OLD, QDesign.NULL(T_EP_NBR_FROM_YY.Value) < QDesign.NULL(T_NEXT_YR_YY.Value), SubFileType.Keep, fleF113_DEFAULT_COMP);
                    //Parent:DOC_DATE_FAC_TERM)    'Parent:F113_DEFAULT_COMP_KEY)    'Parent:DOC_DATE_FAC_TERM)    'Parent:PYCDCEILING_KEY





                    SubFile(ref m_trnTRANS_UPDATE, ref fleF113_YEAREND_NEW, T_EP_NBR_FROM_YY.Value >= T_NEXT_YR_YY.Value, SubFileType.Keep, fleF113_DEFAULT_COMP);
                    //Parent:DOC_DATE_FAC_TERM)    'Parent:F113_DEFAULT_COMP_KEY)    'Parent:DOC_DATE_FAC_TERM)    'Parent:PYCDCEILING_KEY


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
            EndRequest("SPLIT_F113_YEAR_INTO_SUBFILES_4");

        }

    }




    #endregion


}
//SPLIT_F113_YEAR_INTO_SUBFILES_4



public class Mp_YEAREND_1_RESET_F020_VALUES_5 : Mp_YEAREND_1
{

    public Mp_YEAREND_1_RESET_F020_VALUES_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "F020_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF020_DOCTOR_MSTR.SetItemFinals += fleF020_UPDATE_SetItemFinals;
        fleF020_UPDATE.InitializeItems += fleF020_UPDATE_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_YEAREND_1_RESET_F020_VALUES_5)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020_UPDATE;

    private void fleF020_UPDATE_SetItemFinals()
    {

        try
        {
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDGUA", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDGUB", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDGUC", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDGUC", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDCEA", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDCEX", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDEAR", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDINC", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDEFT", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_TOTINC_G", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDINC_G", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_TOTINC", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADJCEA", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_ADJCEX", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_CEICEA", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_CEICEX", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_PAYEFT", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("CEICEA_PRT_FORMAT", " ");
            fleF020_DOCTOR_MSTR.set_SetValue("CEICEX_PRT_FORMAT", " ");
            fleF020_DOCTOR_MSTR.set_SetValue("YTDCEA_PRT_FORMAT", " ");
            fleF020_DOCTOR_MSTR.set_SetValue("YTDCEX_PRT_FORMAT", " ");
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_EP_DATE_DEPOSIT", 0);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_EP_PED", 0);


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


    #region "Standard Generated Procedures(Mp_YEAREND_1_RESET_F020_VALUES_5)"


    #region "Automatic Item Initialization(Mp_YEAREND_1_RESET_F020_VALUES_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:47 PM

    //#-----------------------------------------
    //# fleF020_UPDATE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:47 PM
    //#-----------------------------------------
    private void fleF020_UPDATE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleF020_UPDATE.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_123", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_456", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_789", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleF020_UPDATE.set_SetValue("DOC_HOSP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_HOSP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleF020_UPDATE.set_SetValue("DOC_NAME_SOUNDEX", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME_SOUNDEX"));
            fleF020_UPDATE.set_SetValue("DOC_INIT1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1"));
            fleF020_UPDATE.set_SetValue("DOC_INIT2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2"));
            fleF020_UPDATE.set_SetValue("DOC_INIT3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_BRANCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_ACCT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUB", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEAR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_EP_DATE_DEPOSIT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
            fleF020_UPDATE.set_SetValue("DOC_EP_CEIEXP", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
            fleF020_UPDATE.set_SetValue("CEICEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("CEICEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_UPDATE.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_2"));
            fleF020_UPDATE.set_SetValue("DOC_IND_PAYS_GST", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_5", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_SUB_SPECIALTY", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY"));
            fleF020_UPDATE.set_SetValue("DOC_PAYEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
            fleF020_UPDATE.set_SetValue("DOC_YTDDED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_SUB_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_PARTNERSHIP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_PARTNERSHIP"));
            fleF020_UPDATE.set_SetValue("DOC_IND_HOLDBACK_ACTIVE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE"));
            fleF020_UPDATE.set_SetValue("GROUP_REGULAR_SERVICE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE"));
            fleF020_UPDATE.set_SetValue("GROUP_OVER_SERVICED", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3"));

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


    #region "Transaction Management Procedures(Mp_YEAREND_1_RESET_F020_VALUES_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:44 PM

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
        fleF020_UPDATE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Mp_YEAREND_1_RESET_F020_VALUES_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:44 PM

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
            fleF020_UPDATE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_YEAREND_1_RESET_F020_VALUES_5)"


    public void Run()
    {

        try
        {
            Request("RESET_F020_VALUES_5");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--


                if (Transaction())
                {




                    fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update);
                    //Parent:DOC_DATE_FAC_TERM)    'Parent:F113_DEFAULT_COMP_KEY)    'Parent:DOC_DATE_FAC_TERM)    'Parent:PYCDCEILING_KEY

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
            EndRequest("RESET_F020_VALUES_5");

        }

    }




    #endregion


}
//RESET_F020_VALUES_5



public class Mp_YEAREND_1_SETUP_F112_NEXT_YEAR_6 : Mp_YEAREND_1
{

    public Mp_YEAREND_1_SETUP_F112_NEXT_YEAR_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_NEXT_YR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "F112_NEXT_YR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "F112_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "F020_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");

        D_NEXT_PAY_CODE.GetValue += D_NEXT_PAY_CODE_GetValue;
        TERMINATED_DAYS.GetValue += TERMINATED_DAYS_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF112_NEXT_YR.InitializeItems += fleF112_NEXT_YR_AutomaticItemInitialization;
        fleF112_ADD.InitializeItems += fleF112_ADD_AutomaticItemInitialization;
        fleF020_UPDATE.InitializeItems += fleF020_UPDATE_AutomaticItemInitialization;

        fleF112_PYCDCEILINGS.SelectIf += fleF112_PYCDCEILINGS_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_YEAREND_1_SETUP_F112_NEXT_YEAR_6)"

    private SqlFileObject fleF112_PYCDCEILINGS;

    private void fleF112_PYCDCEILINGS_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" =  ").Append(T_CURRENT_EP_NBR.Value).Append(" )");


            SelectIfClause = strSQL.ToString();


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
    private SqlFileObject fleF112_NEXT_YR;
    private DCharacter D_NEXT_PAY_CODE = new DCharacter("D_NEXT_PAY_CODE", 1);
    private void D_NEXT_PAY_CODE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "4" & QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "A")
            {
                CurrentValue = "1";
            }
            else
            {
                CurrentValue = fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE");
            }

            Value = CurrentValue;

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
    private DDecimal TERMINATED_DAYS = new DDecimal("TERMINATED_DAYS", 5);
    private void TERMINATED_DAYS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(DOC_DATE_FAC_TERM.Value) != 0)
            {
                CurrentValue = QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(QDesign.GetDateFromYYYYMMDDDecimal(DOC_DATE_FAC_TERM.Value));
            }

            Value = CurrentValue;

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
    private SqlFileObject fleF112_ADD;
    private SqlFileObject fleF020_UPDATE;

    private DDecimal DOC_DATE_FAC_TERM = new DDecimal("DOC_DATE_FAC_TERM", 8);

    #endregion


    #region "Standard Generated Procedures(Mp_YEAREND_1_SETUP_F112_NEXT_YEAR_6)"


    #region "Automatic Item Initialization(Mp_YEAREND_1_SETUP_F112_NEXT_YEAR_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:48 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:47 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));

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
    //# fleF112_NEXT_YR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:48 PM
    //#-----------------------------------------
    private void fleF112_NEXT_YR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF112_NEXT_YR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF112_NEXT_YR.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF112_NEXT_YR.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF112_NEXT_YR.set_SetValue("DOC_PAY_CODE", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE"));
            fleF112_NEXT_YR.set_SetValue("DOC_PAY_SUB_CODE", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));
            fleF112_NEXT_YR.set_SetValue("RETRO_TO_EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_CEILING", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_CEILING_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_ADJUSTED"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_EXPENSE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_EXPENSE_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_ADJUSTED"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_EXPN_ALLOC_PERS", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPN_ALLOC_PERS"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_CEIL_GUAR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEIL_GUAR"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_CEILING_GUAR_PERC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_GUAR_PERC"));
            fleF112_NEXT_YR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF112_NEXT_YR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF112_NEXT_YR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            fleF112_NEXT_YR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF112_NEXT_YR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF112_NEXT_YR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF112_NEXT_YR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_REQREV", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_REQREV_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_ADJUSTED"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_REQREV_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_COMPUTED"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_TARREV", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_TARREV_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_ADJUSTED"));
            fleF112_NEXT_YR.set_SetValue("DOC_YRLY_TARREV_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_COMPUTED"));
            fleF112_NEXT_YR.set_SetValue("RETRO_TO_EP_NBR_REQ", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_REQ"));
            fleF112_NEXT_YR.set_SetValue("RETRO_TO_EP_NBR_TAR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_TAR"));

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
    //# fleF112_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:48 PM
    //#-----------------------------------------
    private void fleF112_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF112_ADD.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF112_ADD.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF112_ADD.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF112_ADD.set_SetValue("DOC_PAY_CODE", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE"));
            fleF112_ADD.set_SetValue("DOC_PAY_SUB_CODE", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));
            fleF112_ADD.set_SetValue("RETRO_TO_EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR"));
            fleF112_ADD.set_SetValue("DOC_YRLY_CEILING", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING"));
            fleF112_ADD.set_SetValue("DOC_YRLY_CEILING_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_ADJUSTED"));
            fleF112_ADD.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF112_ADD.set_SetValue("DOC_YRLY_EXPENSE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE"));
            fleF112_ADD.set_SetValue("DOC_YRLY_EXPENSE_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_ADJUSTED"));
            fleF112_ADD.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF112_ADD.set_SetValue("DOC_YRLY_EXPN_ALLOC_PERS", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPN_ALLOC_PERS"));
            fleF112_ADD.set_SetValue("DOC_YRLY_CEIL_GUAR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEIL_GUAR"));
            fleF112_ADD.set_SetValue("DOC_YRLY_CEILING_GUAR_PERC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_GUAR_PERC"));
            fleF112_ADD.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF112_ADD.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF112_ADD.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            fleF112_ADD.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF112_ADD.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF112_ADD.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF112_ADD.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF112_ADD.set_SetValue("DOC_YRLY_REQREV", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV"));
            fleF112_ADD.set_SetValue("DOC_YRLY_REQREV_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_ADJUSTED"));
            fleF112_ADD.set_SetValue("DOC_YRLY_REQREV_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_COMPUTED"));
            fleF112_ADD.set_SetValue("DOC_YRLY_TARREV", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV"));
            fleF112_ADD.set_SetValue("DOC_YRLY_TARREV_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_ADJUSTED"));
            fleF112_ADD.set_SetValue("DOC_YRLY_TARREV_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_COMPUTED"));
            fleF112_ADD.set_SetValue("RETRO_TO_EP_NBR_REQ", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_REQ"));
            fleF112_ADD.set_SetValue("RETRO_TO_EP_NBR_TAR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_TAR"));

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
    //# fleF020_UPDATE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:48 PM
    //#-----------------------------------------
    private void fleF020_UPDATE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleF020_UPDATE.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_123", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_456", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_789", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleF020_UPDATE.set_SetValue("DOC_HOSP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_HOSP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleF020_UPDATE.set_SetValue("DOC_NAME_SOUNDEX", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME_SOUNDEX"));
            fleF020_UPDATE.set_SetValue("DOC_INIT1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1"));
            fleF020_UPDATE.set_SetValue("DOC_INIT2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2"));
            fleF020_UPDATE.set_SetValue("DOC_INIT3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_BRANCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_ACCT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUB", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEAR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_EP_DATE_DEPOSIT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
            fleF020_UPDATE.set_SetValue("DOC_EP_CEIEXP", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
            fleF020_UPDATE.set_SetValue("CEICEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("CEICEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_2"));
            fleF020_UPDATE.set_SetValue("DOC_IND_PAYS_GST", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_5", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6"));
            fleF020_UPDATE.set_SetValue("DOC_SUB_SPECIALTY", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY"));
            fleF020_UPDATE.set_SetValue("DOC_PAYEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
            fleF020_UPDATE.set_SetValue("DOC_YTDDED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_SUB_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_PARTNERSHIP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_PARTNERSHIP"));
            fleF020_UPDATE.set_SetValue("DOC_IND_HOLDBACK_ACTIVE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE"));
            fleF020_UPDATE.set_SetValue("GROUP_REGULAR_SERVICE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE"));
            fleF020_UPDATE.set_SetValue("GROUP_OVER_SERVICED", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3"));

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


    #region "Transaction Management Procedures(Mp_YEAREND_1_SETUP_F112_NEXT_YEAR_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:44 PM

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
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF112_NEXT_YR.Transaction = m_trnTRANS_UPDATE;
        fleF112_ADD.Transaction = m_trnTRANS_UPDATE;
        fleF020_UPDATE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Mp_YEAREND_1_SETUP_F112_NEXT_YEAR_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:45 PM

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
            fleF112_PYCDCEILINGS.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF112_NEXT_YR.Dispose();
            fleF112_ADD.Dispose();
            fleF020_UPDATE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_YEAREND_1_SETUP_F112_NEXT_YEAR_6)"


    public void Run()
    {

        try
        {
            Request("SETUP_F112_NEXT_YEAR_6");

            while (fleF112_PYCDCEILINGS.QTPForMissing())
            {
                // --> GET F112_PYCDCEILINGS <--

                fleF112_PYCDCEILINGS.GetData();
                // --> End GET F112_PYCDCEILINGS <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF112_NEXT_YR.QTPForMissing("2"))
                    {
                        // --> GET F112_NEXT_YR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF112_NEXT_YR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                        m_strWhere.Append(" And ").Append(fleF112_NEXT_YR.ElementOwner("EP_NBR")).Append(" = ");
                        m_strWhere.Append((T_NEXT_YR_FIRST_EP_NBR.Value));

                        fleF112_NEXT_YR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F112_NEXT_YR <--


                        if (Transaction())
                        {

                            fleF112_ADD.set_SetValue("DOC_NBR", fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));


                            fleF112_ADD.set_SetValue("EP_NBR", T_NEXT_YR_FIRST_EP_NBR.Value);


                            fleF112_ADD.set_SetValue("DOC_PAY_CODE", D_NEXT_PAY_CODE.Value);


                            fleF112_ADD.set_SetValue("DOC_PAY_SUB_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));


                            fleF112_ADD.set_SetValue("FACTOR", fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));


                            fleF112_ADD.set_SetValue("RETRO_TO_EP_NBR", 0);


                            fleF112_ADD.set_SetValue("DOC_YRLY_CEILING", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING"));


                            fleF112_ADD.set_SetValue("DOC_YRLY_CEILING_ADJUSTED", 0);


                            fleF112_ADD.set_SetValue("DOC_YRLY_CEILING_COMPUTED", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING"));


                            fleF112_ADD.set_SetValue("DOC_YRLY_EXPENSE", 0);


                            fleF112_ADD.set_SetValue("DOC_YRLY_EXPENSE_ADJUSTED", 0);


                            fleF112_ADD.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", 0);


                            fleF112_ADD.set_SetValue("DOC_YRLY_EXPN_ALLOC_PERS", 0);


                            fleF112_ADD.set_SetValue("DOC_YRLY_CEIL_GUAR", 0);


                            fleF112_ADD.set_SetValue("DOC_YRLY_CEILING_GUAR_PERC", 0);


                            fleF112_ADD.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", 0);


                            fleF112_ADD.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", 0);


                            fleF112_ADD.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", 0);


                            fleF112_ADD.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", 0);


                            fleF112_ADD.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                            fleF112_ADD.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                            fleF112_ADD.set_SetValue("LAST_MOD_USER_ID", "Comp.YrEndRoll");





                            fleF112_ADD.OutPut(OutPutType.Add, null, !fleF112_NEXT_YR.Exists() & TERMINATED_DAYS.Value <= 730);
                            //Parent:DOC_DATE_FAC_TERM)    'Parent:F113_DEFAULT_COMP_KEY)    'Parent:DOC_DATE_FAC_TERM)    'Parent:PYCDCEILING_KEY



                            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", 100 * fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING"));





                            fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update);
                            //Parent:DOC_DATE_FAC_TERM)    'Parent:F113_DEFAULT_COMP_KEY)    'Parent:DOC_DATE_FAC_TERM)    'Parent:PYCDCEILING_KEY

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
            EndRequest("SETUP_F112_NEXT_YEAR_6");

        }

    }




    #endregion


}
//SETUP_F112_NEXT_YEAR_6



public class Mp_YEAREND_1_SPLIT_F112_YEAR_INTO_SUBFILESI_7 : Mp_YEAREND_1
{

    public Mp_YEAREND_1_SPLIT_F112_YEAR_INTO_SUBFILESI_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        T_EP_NBR_YY = new CoreDecimal("T_EP_NBR_YY", 1, this);
        fleF112_YEAREND_OLD = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F112_YEAREND_OLD", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF112_YEAREND_NEW = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F112_YEAREND_NEW", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(Mp_YEAREND_1_SPLIT_F112_YEAR_INTO_SUBFILESI_7)"

    private SqlFileObject fleF112_PYCDCEILINGS;

    private CoreDecimal T_EP_NBR_YY;



    private SqlFileObject fleF112_YEAREND_OLD;




    private SqlFileObject fleF112_YEAREND_NEW;


    #endregion


    #region "Standard Generated Procedures(Mp_YEAREND_1_SPLIT_F112_YEAR_INTO_SUBFILESI_7)"


    #region "Automatic Item Initialization(Mp_YEAREND_1_SPLIT_F112_YEAR_INTO_SUBFILESI_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_YEAREND_1_SPLIT_F112_YEAR_INTO_SUBFILESI_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:45 PM

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
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF112_YEAREND_OLD.Transaction = m_trnTRANS_UPDATE;
        fleF112_YEAREND_NEW.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Mp_YEAREND_1_SPLIT_F112_YEAR_INTO_SUBFILESI_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:45 PM

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
            fleF112_PYCDCEILINGS.Dispose();
            fleF112_YEAREND_OLD.Dispose();
            fleF112_YEAREND_NEW.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_YEAREND_1_SPLIT_F112_YEAR_INTO_SUBFILESI_7)"


    public void Run()
    {

        try
        {
            Request("SPLIT_F112_YEAR_INTO_SUBFILESI_7");

            while (fleF112_PYCDCEILINGS.QTPForMissing())
            {
                // --> GET F112_PYCDCEILINGS <--

                fleF112_PYCDCEILINGS.GetData();
                // --> End GET F112_PYCDCEILINGS <--


                if (Transaction())
                {
                    T_EP_NBR_YY.Value = QDesign.Floor(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR") / 100);




                    SubFile(ref m_trnTRANS_UPDATE, ref fleF112_YEAREND_OLD, QDesign.NULL(T_EP_NBR_YY.Value) < QDesign.NULL(T_NEXT_YR_YY.Value), SubFileType.Keep, fleF112_PYCDCEILINGS);
                    //Parent:DOC_DATE_FAC_TERM)    'Parent:F113_DEFAULT_COMP_KEY)    'Parent:DOC_DATE_FAC_TERM)    'Parent:PYCDCEILING_KEY





                    SubFile(ref m_trnTRANS_UPDATE, ref fleF112_YEAREND_NEW, T_EP_NBR_YY.Value >= T_NEXT_YR_YY.Value, SubFileType.Keep, fleF112_PYCDCEILINGS);
                    //Parent:DOC_DATE_FAC_TERM)    'Parent:F113_DEFAULT_COMP_KEY)    'Parent:DOC_DATE_FAC_TERM)    'Parent:PYCDCEILING_KEY


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
            EndRequest("SPLIT_F112_YEAR_INTO_SUBFILESI_7");

        }

    }




    #endregion


}
//SPLIT_F112_YEAR_INTO_SUBFILESI_7




