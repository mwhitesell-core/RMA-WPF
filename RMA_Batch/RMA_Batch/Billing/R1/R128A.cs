
#region "Screen Comments"

// #> PROGRAM-ID.     r128a.qts 
// ((C)) Dyad Infosys LTD 
// PURPOSE: first pass for inactive doctors that do not have earnings for 3 most recent months
// STAGE 1 - create subfile of values from f119-doctor-ytd-history
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 2014/Jul/16  ____   M.C.     - original 
// - Doctor terminated and do not notify RMA.  This is especially a problem
// with the non-GFT physicians
// 2015/Jun/18  MC1  - change the selection criteria as requested by Brad
// - select on  no activity  - if BILL and AFPIN and AFPOUT <= 0 for the
// current EP and 2 previous EP`s for all dept and pay code
// - only doctors with claims balance due <> 0
// - this program will be run as part of $cmd/teb3 instead of $cmd/teb2
// because current-ep-nbr has increased by 1 from u126.qts
// 2015/Oct/26  MC2  - apply the same selection criteria as in u110_rma_1/2.qts  when determine
// claims that have balance due because we only consider the claims for the clinics
// that go into payroll subsystem


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class R128A : BaseClassControl
{

    private R128A m_R128A;

    public R128A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_LAST_3_EP_NBR = new CoreDecimal("W_LAST_3_EP_NBR", 6, this, ResetTypes.ResetAtStartup);


    }

    public R128A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_LAST_3_EP_NBR = new CoreDecimal("W_LAST_3_EP_NBR", 6, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_R128A != null))
        {
            m_R128A.CloseTransactionObjects();
            m_R128A = null;
        }
    }

    public R128A GetR128A(int Level)
    {
        if (m_R128A == null)
        {
            m_R128A = new R128A("R128A", Level);
        }
        else
        {
            m_R128A.ResetValues();
        }
        return m_R128A;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_EP_NBR;

    protected CoreDecimal W_LAST_3_EP_NBR;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            R128A_GET_CONSTANTS_VALUES_EP_NBR_1 GET_CONSTANTS_VALUES_EP_NBR_1 = new R128A_GET_CONSTANTS_VALUES_EP_NBR_1(Name, Level);
            GET_CONSTANTS_VALUES_EP_NBR_1.Run();
            GET_CONSTANTS_VALUES_EP_NBR_1.Dispose();
            GET_CONSTANTS_VALUES_EP_NBR_1 = null;

            R128A_ACCESS_F119_HIST_2 ACCESS_F119_HIST_2 = new R128A_ACCESS_F119_HIST_2(Name, Level);
            ACCESS_F119_HIST_2.Run();
            ACCESS_F119_HIST_2.Dispose();
            ACCESS_F119_HIST_2 = null;

            R128A_SELECT_INACTIVE_3 SELECT_INACTIVE_3 = new R128A_SELECT_INACTIVE_3(Name, Level);
            SELECT_INACTIVE_3.Run();
            SELECT_INACTIVE_3.Dispose();
            SELECT_INACTIVE_3 = null;

            R128A_CHECK_CLAIM_BALANCE_4 CHECK_CLAIM_BALANCE_4 = new R128A_CHECK_CLAIM_BALANCE_4(Name, Level);
            CHECK_CLAIM_BALANCE_4.Run();
            CHECK_CLAIM_BALANCE_4.Dispose();
            CHECK_CLAIM_BALANCE_4 = null;

            R128A_SELECT_INACTIVE_DOC_WITH_CLM_5 SELECT_INACTIVE_DOC_WITH_CLM_5 = new R128A_SELECT_INACTIVE_DOC_WITH_CLM_5(Name, Level);
            SELECT_INACTIVE_DOC_WITH_CLM_5.Run();
            SELECT_INACTIVE_DOC_WITH_CLM_5.Dispose();
            SELECT_INACTIVE_DOC_WITH_CLM_5 = null;

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



public class R128A_GET_CONSTANTS_VALUES_EP_NBR_1 : R128A
{

    public R128A_GET_CONSTANTS_VALUES_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        EP_MM.GetValue += EP_MM_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(R128A_GET_CONSTANTS_VALUES_EP_NBR_1)"

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

    private DDecimal EP_MM = new DDecimal("EP_MM", 6);
    private void EP_MM_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"), 100);


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


    #region "Standard Generated Procedures(R128A_GET_CONSTANTS_VALUES_EP_NBR_1)"


    #region "Automatic Item Initialization(R128A_GET_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R128A_GET_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:48 PM

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


    #region "FILE Management Procedures(R128A_GET_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:48 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R128A_GET_CONSTANTS_VALUES_EP_NBR_1)"


    public void Run()
    {

        try
        {
            Request("GET_CONSTANTS_VALUES_EP_NBR_1");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--


                if (Transaction())
                {
                    W_CURRENT_EP_NBR.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR");
                    if (EP_MM.Value >= 4)
                    {
                        W_LAST_3_EP_NBR.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 3;
                    }
                    else if (EP_MM.Value <= 3)
                    {
                        W_LAST_3_EP_NBR.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 90;
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
            EndRequest("GET_CONSTANTS_VALUES_EP_NBR_1");

        }

    }







    #endregion


}
//GET_CONSTANTS_VALUES_EP_NBR_1



public class R128A_ACCESS_F119_HIST_2 : R128A
{

    public R128A_ACCESS_F119_HIST_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_BILL = new CoreDecimal("X_BILL", 6, this);
        X_AFPIN = new CoreDecimal("X_AFPIN", 6, this);
        X_AFPOUT = new CoreDecimal("X_AFPOUT", 6, this);
        fleR128A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R128A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD_HISTORY.Choose += fleF119_DOCTOR_YTD_HISTORY_Choose;
        X_BILL_AFPIN_AFPOUT.GetValue += X_BILL_AFPIN_AFPOUT_GetValue;

        fleF119_DOCTOR_YTD_HISTORY.SelectIf += fleF119_DOCTOR_YTD_HISTORY_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(R128A_ACCESS_F119_HIST_2)"

    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;

    private void fleF119_DOCTOR_YTD_HISTORY_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" ( (    ").Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("COMP_CODE")).Append(" =  'BILL' ) OR ");
            strSQL.Append(" (    ").Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("COMP_CODE")).Append(" =  'AFPIN' ) OR ");
            strSQL.Append(" (    ").Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("COMP_CODE")).Append(" =  'AFPOUT' ))");


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

    private void fleF119_DOCTOR_YTD_HISTORY_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("EP_NBR"));
            strSQL.Append(" BETWEEN ");
            strSQL.Append(W_LAST_3_EP_NBR.Value).Append(" AND ").Append(W_CURRENT_EP_NBR.Value);

            strSQL.Append(" AND ");
            strSQL.Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("REC_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("A"));


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

    private CoreDecimal X_BILL;
    private CoreDecimal X_AFPIN;
    private CoreDecimal X_AFPOUT;
    private DDecimal X_BILL_AFPIN_AFPOUT = new DDecimal("X_BILL_AFPIN_AFPOUT", 6);
    private void X_BILL_AFPIN_AFPOUT_GetValue(ref decimal Value)
    {

        try
        {
            Value = X_BILL.Value + X_AFPIN.Value + X_AFPOUT.Value;


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


    private SqlFileObject fleR128A;


    #endregion


    #region "Standard Generated Procedures(R128A_ACCESS_F119_HIST_2)"


    #region "Automatic Item Initialization(R128A_ACCESS_F119_HIST_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R128A_ACCESS_F119_HIST_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:48 PM

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
        fleF119_DOCTOR_YTD_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleR128A.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R128A_ACCESS_F119_HIST_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:48 PM

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
            fleF119_DOCTOR_YTD_HISTORY.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleR128A.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R128A_ACCESS_F119_HIST_2)"


    public void Run()
    {

        try
        {
            Request("ACCESS_F119_HIST_2");

            while (fleF119_DOCTOR_YTD_HISTORY.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD_HISTORY <--

                fleF119_DOCTOR_YTD_HISTORY.GetData();
                // --> End GET F119_DOCTOR_YTD_HISTORY <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                        Sort(fleF119_DOCTOR_YTD_HISTORY.GetSortValue("DOC_NBR"), fleF119_DOCTOR_YTD_HISTORY.GetSortValue("EP_NBR"));



                    }

                }

            }

            while (Sort(fleF119_DOCTOR_YTD_HISTORY, fleF020_DOCTOR_MSTR))
            {
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "BILL" & QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_MTD")) > 0)
                {
                    X_BILL.Value = X_BILL.Value + 1;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "AFPIN" & QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_MTD")) > 0)
                {
                    X_AFPIN.Value = X_AFPIN.Value + 1;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "AFPOUT" & QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_MTD")) > 0)
                {
                    X_AFPOUT.Value = X_AFPOUT.Value + 1;
                }



                SubFile(ref m_trnTRANS_UPDATE, ref fleR128A, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"), SubFileType.Keep, 
                    fleF119_DOCTOR_YTD_HISTORY, "DOC_NBR", 
                    fleF020_DOCTOR_MSTR, "DOC_DEPT", "DOC_NAME", "DOC_DATE_FAC_START_YY", "DOC_DATE_FAC_START_MM", "DOC_DATE_FAC_START_DD",
                        "DOC_DATE_FAC_TERM_YY", "DOC_DATE_FAC_TERM_MM", "DOC_DATE_FAC_TERM_DD", "DOC_EP_PAY_CODE", "DOC_EP_PAY_SUB_CODE", X_BILL, X_AFPIN, X_AFPOUT, X_BILL_AFPIN_AFPOUT);



                Reset(ref X_BILL, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref X_AFPIN, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref X_AFPOUT, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));

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
            EndRequest("ACCESS_F119_HIST_2");

        }

    }




    #endregion


}
//ACCESS_F119_HIST_2



public class R128A_SELECT_INACTIVE_3 : R128A
{

    public R128A_SELECT_INACTIVE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR128A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R128A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleR128A_INACTIVE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R128A_INACTIVE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(R128A_SELECT_INACTIVE_3)"

    private SqlFileObject fleR128A;

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleR128A.GetDecimalValue("X_BILL_AFPIN_AFPOUT")) == 0)
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



    private SqlFileObject fleR128A_INACTIVE;


    #endregion


    #region "Standard Generated Procedures(R128A_SELECT_INACTIVE_3)"


    #region "Automatic Item Initialization(R128A_SELECT_INACTIVE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R128A_SELECT_INACTIVE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:48 PM

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
        fleR128A.Transaction = m_trnTRANS_UPDATE;
        fleR128A_INACTIVE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R128A_SELECT_INACTIVE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:48 PM

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
            fleR128A.Dispose();
            fleR128A_INACTIVE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R128A_SELECT_INACTIVE_3)"


    public void Run()
    {

        try
        {
            Request("SELECT_INACTIVE_3");

            while (fleR128A.QTPForMissing())
            {
                // --> GET R128A <--

                fleR128A.GetData();
                // --> End GET R128A <--


                if (Transaction())
                {

                    if (Select_If())
                    {


                        SubFile(ref m_trnTRANS_UPDATE, ref fleR128A_INACTIVE, SubFileType.Keep, fleR128A);



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
            EndRequest("SELECT_INACTIVE_3");

        }

    }




    #endregion


}
//SELECT_INACTIVE_3



public class R128A_CHECK_CLAIM_BALANCE_4 : R128A
{

    public R128A_CHECK_CLAIM_BALANCE_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_OUTSTANDING = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "VW_OUTSTANDING_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CLAIM_BAL = new CoreDecimal("X_CLAIM_BAL", 10, this);
        fleTMP_COUNTERS_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR128A_CLAIM_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R128A_CLAIM_DOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        DOC_NBR.GetValue += DOC_NBR_GetValue;
        CLINIC_NBR.GetValue += CLINIC_NBR_GetValue;
        fleTMP_COUNTERS_ALPHA.SetItemFinals += fleTMP_COUNTERS_ALPHA_SetItemFinals;

    }




    #region "Declarations (Variables, Files and Transactions)(R128A_CHECK_CLAIM_BALANCE_4)"

    private SqlFileObject fleF002_OUTSTANDING;






    private DCharacter DOC_NBR = new DCharacter("DOC_NBR", 3);
    private void DOC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleF002_OUTSTANDING.GetStringValue("KEY_CLM_BATCH_NBR"), 3, 3);


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
    private DCharacter CLINIC_NBR = new DCharacter("CLINIC_NBR", 2);
    private void CLINIC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleF002_OUTSTANDING.GetStringValue("KEY_CLM_BATCH_NBR"), 1, 2);


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



    private CoreDecimal X_CLAIM_BAL;
    private SqlFileObject fleTMP_COUNTERS_ALPHA;

    private void fleTMP_COUNTERS_ALPHA_SetItemFinals()
    {

        try
        {
            fleTMP_COUNTERS_ALPHA.set_SetValue("TMP_COUNTER_KEY_ALPHA", DOC_NBR.Value);
            fleTMP_COUNTERS_ALPHA.set_SetValue("TMP_COUNTER_1", X_CLAIM_BAL.Value);


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



    private SqlFileObject fleR128A_CLAIM_DOC;


    #endregion


    #region "Standard Generated Procedures(R128A_CHECK_CLAIM_BALANCE_4)"


    #region "Automatic Item Initialization(R128A_CHECK_CLAIM_BALANCE_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R128A_CHECK_CLAIM_BALANCE_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:48 PM

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
        fleF002_OUTSTANDING.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS_ALPHA.Transaction = m_trnTRANS_UPDATE;
        fleR128A_CLAIM_DOC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R128A_CHECK_CLAIM_BALANCE_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:49 PM

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
            fleF002_OUTSTANDING.Dispose();
            fleTMP_COUNTERS_ALPHA.Dispose();
            fleR128A_CLAIM_DOC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R128A_CHECK_CLAIM_BALANCE_4)"


    public void Run()
    {

        try
        {
            Request("CHECK_CLAIM_BALANCE_4");

            while (fleF002_OUTSTANDING.QTPForMissing())
            {
                // --> GET F002_OUTSTANDING <--

                fleF002_OUTSTANDING.GetData();
                // --> End GET F002_OUTSTANDING <--               


                if (Transaction())
                {
                    Sort(DOC_NBR.Value);

                }

            }

            while (Sort(fleF002_OUTSTANDING))
            {
                X_CLAIM_BAL.Value = X_CLAIM_BAL.Value + fleF002_OUTSTANDING.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_OUTSTANDING.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");



                fleTMP_COUNTERS_ALPHA.OutPut(OutPutType.Add, At(DOC_NBR), null);




                SubFile(ref m_trnTRANS_UPDATE, ref fleR128A_CLAIM_DOC, At(DOC_NBR), SubFileType.Keep, DOC_NBR, X_CLAIM_BAL);



                Reset(ref X_CLAIM_BAL, At(DOC_NBR));

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
            EndRequest("CHECK_CLAIM_BALANCE_4");

        }

    }




    #endregion


}
//CHECK_CLAIM_BALANCE_4



public class R128A_SELECT_INACTIVE_DOC_WITH_CLM_5 : R128A
{

    public R128A_SELECT_INACTIVE_DOC_WITH_CLM_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR128A_INACTIVE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R128A_INACTIVE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_COUNTERS_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR128A_INACTIVE_DOC_WITH_CLM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R128A_INACTIVE_DOC_WITH_CLM", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_CLAIM_BAL.GetValue += X_CLAIM_BAL_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(R128A_SELECT_INACTIVE_DOC_WITH_CLM_5)"

    private SqlFileObject fleR128A_INACTIVE;
    private SqlFileObject fleTMP_COUNTERS_ALPHA;

    private SqlFileObject fleR128A_INACTIVE_DOC_WITH_CLM;

    private DDecimal X_CLAIM_BAL = new DDecimal("X_CLAIM_BAL", 10);
    private void X_CLAIM_BAL_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleTMP_COUNTERS_ALPHA.GetDecimalValue("TMP_COUNTER_1");


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


    #region "Standard Generated Procedures(R128A_SELECT_INACTIVE_DOC_WITH_CLM_5)"


    #region "Automatic Item Initialization(R128A_SELECT_INACTIVE_DOC_WITH_CLM_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R128A_SELECT_INACTIVE_DOC_WITH_CLM_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:49 PM

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
        fleR128A_INACTIVE.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS_ALPHA.Transaction = m_trnTRANS_UPDATE;
        fleR128A_INACTIVE_DOC_WITH_CLM.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R128A_SELECT_INACTIVE_DOC_WITH_CLM_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:49 PM

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
            fleR128A_INACTIVE.Dispose();
            fleTMP_COUNTERS_ALPHA.Dispose();
            fleR128A_INACTIVE_DOC_WITH_CLM.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R128A_SELECT_INACTIVE_DOC_WITH_CLM_5)"


    public void Run()
    {

        try
        {
            Request("SELECT_INACTIVE_DOC_WITH_CLM_5");

            while (fleR128A_INACTIVE.QTPForMissing())
            {
                // --> GET R128A_INACTIVE <--

                fleR128A_INACTIVE.GetData();
                // --> End GET R128A_INACTIVE <--

                while (fleTMP_COUNTERS_ALPHA.QTPForMissing("1"))
                {
                    // --> GET TMP_COUNTERS_ALPHA <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleTMP_COUNTERS_ALPHA.ElementOwner("TMP_COUNTER_KEY_ALPHA")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleR128A_INACTIVE.GetStringValue("DOC_NBR")));

                    fleTMP_COUNTERS_ALPHA.GetData(m_strWhere.ToString());
                    // --> End GET TMP_COUNTERS_ALPHA <--


                    if (Transaction())
                    {

                        SubFile(ref m_trnTRANS_UPDATE, ref fleR128A_INACTIVE_DOC_WITH_CLM, SubFileType.Keep, X_CLAIM_BAL, fleR128A_INACTIVE);



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
            EndRequest("SELECT_INACTIVE_DOC_WITH_CLM_5");

        }

    }




    #endregion


}
//SELECT_INACTIVE_DOC_WITH_CLM_5




