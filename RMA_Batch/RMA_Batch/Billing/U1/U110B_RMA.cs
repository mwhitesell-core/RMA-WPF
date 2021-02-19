
#region "Screen Comments"

// PROGRAM: u110b_rma.qts
// PROGRAM PURPOSE: 
// new diagnostic clinics - take `professional` values from
// revenue (originally reported on from utl0007.qzs and entered 
// into f002) and merge these with values picked up by u110
// into AFPOUT transactions, creating a single AFPOUT transaction
// for doctors to upload via u111 to payroll subsystem
// DATE       WHO       DESCRIPTION
// 1992/02/25   Y.B.      ORIGINAL
// 2007/mar/28 b.e. - clone from yas`s utl0007 
// 2007/mar/28 b.e. - clinic`s changed from 60 to 70 range
// - since payroll run after 70 ME changed program
// to access f050tp history instead of f050tp
// 2007/may/29 b.e. - change in select to pick if AGENT <> 6
// 2007/jul/23 b.e. - use PED of payroll system to select f050tp records
// rather than PED of clinic
// 2012/jul/09 MC1 - modify to use yearend PED as yyyy0630 if ep-nbr = yyyy13


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U110B_RMA : BaseClassControl
{

    private U110B_RMA m_U110B_RMA;

    public U110B_RMA(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_FISCAL_START_YYMMDD = new CoreDate("W_CURRENT_FISCAL_START_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_FISCAL_END_YYMMDD = new CoreDate("W_CURRENT_FISCAL_END_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_CUTOFF_YYMMDD = new CoreDate("W_CURRENT_COSTING_CUTOFF_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED = new CoreDate("W_CURRENT_COSTING_PED", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED_YYMM = new CoreDecimal("W_CURRENT_COSTING_PED_YYMM", 6, this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_START_YYMMDD = new CoreDate("W_PREVIOUS_FISCAL_START_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_END_YYMMDD = new CoreDate("W_PREVIOUS_FISCAL_END_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_EP_YR = new CoreDecimal("W_EP_YR", 2, this, ResetTypes.ResetAtStartup);
        AFPIN_SEQ = new CoreDecimal("AFPIN_SEQ", 2, this, ResetTypes.ResetAtStartup);
        AFPIN_TYPE = new CoreCharacter("AFPIN_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        AFPIN_FACTOR = new CoreDecimal("AFPIN_FACTOR", 6, this, ResetTypes.ResetAtStartup);


    }

    public U110B_RMA(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_FISCAL_START_YYMMDD = new CoreDate("W_CURRENT_FISCAL_START_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_FISCAL_END_YYMMDD = new CoreDate("W_CURRENT_FISCAL_END_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_CUTOFF_YYMMDD = new CoreDate("W_CURRENT_COSTING_CUTOFF_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED = new CoreDate("W_CURRENT_COSTING_PED", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED_YYMM = new CoreDecimal("W_CURRENT_COSTING_PED_YYMM", 6, this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_START_YYMMDD = new CoreDate("W_PREVIOUS_FISCAL_START_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_END_YYMMDD = new CoreDate("W_PREVIOUS_FISCAL_END_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_EP_YR = new CoreDecimal("W_EP_YR", 2, this, ResetTypes.ResetAtStartup);
        AFPIN_SEQ = new CoreDecimal("AFPIN_SEQ", 2, this, ResetTypes.ResetAtStartup);
        AFPIN_TYPE = new CoreCharacter("AFPIN_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        AFPIN_FACTOR = new CoreDecimal("AFPIN_FACTOR", 6, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_U110B_RMA != null))
        {
            m_U110B_RMA.CloseTransactionObjects();
            m_U110B_RMA = null;
        }
    }

    public U110B_RMA GetU110B_RMA(int Level)
    {
        if (m_U110B_RMA == null)
        {
            m_U110B_RMA = new U110B_RMA("U110B_RMA", Level);
        }
        else
        {
            m_U110B_RMA.ResetValues();
        }
        return m_U110B_RMA;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDate W_CURRENT_FISCAL_START_YYMMDD;
    protected CoreDate W_CURRENT_FISCAL_END_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_CUTOFF_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_PED;
    protected CoreDecimal W_CURRENT_COSTING_PED_YYMM;
    protected CoreDate W_PREVIOUS_FISCAL_START_YYMMDD;
    protected CoreDate W_PREVIOUS_FISCAL_END_YYMMDD;
    protected CoreDecimal W_EP_YR;
    protected CoreDecimal AFPIN_SEQ;
    protected CoreCharacter AFPIN_TYPE;

    protected CoreDecimal AFPIN_FACTOR;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U110B_RMA_RUN_U110B_GET_AFPIN_1 RUN_U110B_GET_AFPIN_1 = new U110B_RMA_RUN_U110B_GET_AFPIN_1(Name, Level);
            RUN_U110B_GET_AFPIN_1.Run();
            RUN_U110B_GET_AFPIN_1.Dispose();
            RUN_U110B_GET_AFPIN_1 = null;

            U110B_RMA_U110B_PROCESS_2 U110B_PROCESS_2 = new U110B_RMA_U110B_PROCESS_2(Name, Level);
            U110B_PROCESS_2.Run();
            U110B_PROCESS_2.Dispose();
            U110B_PROCESS_2 = null;

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



public class U110B_RMA_RUN_U110B_GET_AFPIN_1 : U110B_RMA
{

    public U110B_RMA_RUN_U110B_GET_AFPIN_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110B_RMA_RUN_U110B_GET_AFPIN_1)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("AFPIN"));


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


    #region "Standard Generated Procedures(U110B_RMA_RUN_U110B_GET_AFPIN_1)"


    #region "Automatic Item Initialization(U110B_RMA_RUN_U110B_GET_AFPIN_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110B_RMA_RUN_U110B_GET_AFPIN_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:27 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110B_RMA_RUN_U110B_GET_AFPIN_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:27 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110B_RMA_RUN_U110B_GET_AFPIN_1)"


    public void Run()
    {

        try
        {
            Request("RUN_U110B_GET_AFPIN_1");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    if (AtFinal())
                    {
                        AFPIN_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                        AFPIN_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                        AFPIN_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("RUN_U110B_GET_AFPIN_1");

        }

    }







    #endregion


}
//RUN_U110B_GET_AFPIN_1



public class U110B_RMA_U110B_PROCESS_2 : U110B_RMA
{

    public U110B_RMA_U110B_PROCESS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050TP_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        MTD_AFPIN_PROF = new CoreDecimal("MTD_AFPIN_PROF", 8, this);
        COMP_CODE = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        COMP_TYPE = new CoreCharacter("COMP_TYPE", 1, this, Common.cEmptyString);
        PROCESS_SEQ = new CoreDecimal("PROCESS_SEQ", 2, this);
        FACTOR = new CoreDecimal("FACTOR", 6, this);
        MTD_AFPINING = new CoreDecimal("MTD_AFPINING", 8, this);
        fleU110_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU110_AUDIT_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110_AUDIT_DOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU110 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        EP_MM.GetValue += EP_MM_GetValue;
        X_ICONST_DATE_PERIOD_END.GetValue += X_ICONST_DATE_PERIOD_END_GetValue;
        fleF191_EARNINGS_PERIOD.InitializeItems += fleF191_EARNINGS_PERIOD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U110B_RMA_U110B_PROCESS_2)"

    private SqlFileObject fleF050TP_DOC_REVENUE_MSTR_HISTORY;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF191_EARNINGS_PERIOD;
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
    private DDecimal X_ICONST_DATE_PERIOD_END = new DDecimal("X_ICONST_DATE_PERIOD_END", 6);
    private void X_ICONST_DATE_PERIOD_END_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(EP_MM.Value) != 13)
            {
                CurrentValue = QDesign.NConvert(QDesign.ASCII((fleF191_EARNINGS_PERIOD.GetNumericDateValue("ICONST_DATE_PERIOD_END") / 100), 6) + "01");
            }
            else
            {
                CurrentValue = fleF191_EARNINGS_PERIOD.GetNumericDateValue("ICONST_DATE_PERIOD_END");
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

    public override bool SelectIf()
    {


        try
        {
            if (fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_CLINIC_NBR") >= 71 
                & fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_CLINIC_NBR") <= 75 
                & QDesign.NULL(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_AGENT_CD")) != "6" 
                & QDesign.NULL(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetNumericDateValue("ICONST_DATE_PERIOD_END")) == QDesign.NULL(X_ICONST_DATE_PERIOD_END.Value))
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

    private CoreDecimal MTD_AFPIN_PROF;
    private CoreCharacter COMP_CODE;
    private CoreCharacter COMP_TYPE;
    private CoreDecimal PROCESS_SEQ;
    private CoreDecimal FACTOR;

    private CoreDecimal MTD_AFPINING;
    private SqlFileObject fleU110_AUDIT;

    private SqlFileObject fleU110_AUDIT_DOC;

    private SqlFileObject fleU110;


    #endregion


    #region "Standard Generated Procedures(U110B_RMA_U110B_PROCESS_2)"


    #region "Automatic Item Initialization(U110B_RMA_U110B_PROCESS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:36 PM

    //#-----------------------------------------
    //# fleF191_EARNINGS_PERIOD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:22:28 PM
    //#-----------------------------------------
    private void fleF191_EARNINGS_PERIOD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF191_EARNINGS_PERIOD.set_SetValue("ICONST_DATE_PERIOD_END", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("ICONST_DATE_PERIOD_END"));

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


    #region "Transaction Management Procedures(U110B_RMA_U110B_PROCESS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:27 PM

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
        fleF050TP_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF191_EARNINGS_PERIOD.Transaction = m_trnTRANS_UPDATE;
        fleU110_AUDIT.Transaction = m_trnTRANS_UPDATE;
        fleU110_AUDIT_DOC.Transaction = m_trnTRANS_UPDATE;
        fleU110.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110B_RMA_U110B_PROCESS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:27 PM

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
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF191_EARNINGS_PERIOD.Dispose();
            fleU110_AUDIT.Dispose();
            fleU110_AUDIT_DOC.Dispose();
            fleU110.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110B_RMA_U110B_PROCESS_2)"


    public void Run()
    {

        try
        {
            Request("U110B_PROCESS_2");

            while (fleF050TP_DOC_REVENUE_MSTR_HISTORY.QTPForMissing())
            {
                // --> GET F050TP_DOC_REVENUE_MSTR_HISTORY <--

                fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetData();
                // --> End GET F050TP_DOC_REVENUE_MSTR_HISTORY <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleCONSTANTS_MSTR_REC_6.QTPForMissing("2"))
                    {
                        // --> GET CONSTANTS_MSTR_REC_6 <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                        m_strWhere.Append(((6)));

                        fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString());
                        // --> End GET CONSTANTS_MSTR_REC_6 <--

                        while (fleF191_EARNINGS_PERIOD.QTPForMissing("3"))
                        {
                            // --> GET F191_EARNINGS_PERIOD <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ");
                            m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                            fleF191_EARNINGS_PERIOD.GetData(m_strWhere.ToString());
                            // --> End GET F191_EARNINGS_PERIOD <--


                            if (Transaction())
                            {

                                 if (Select_If())
                                {

                                    Sort(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREVTP_DOC_NBR"), fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREVTP_CLINIC_NBR"), fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREVTP_OMA_CODE"), fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREVTP_OMA_SUFFIX"));




                                }

                            }

                        }

                    }

                }

            }

            while (Sort(fleF050TP_DOC_REVENUE_MSTR_HISTORY, fleF020_DOCTOR_MSTR, fleCONSTANTS_MSTR_REC_6, fleF191_EARNINGS_PERIOD))
            {
                MTD_AFPIN_PROF.Value = MTD_AFPIN_PROF.Value + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_PROF_AMT_BILLED" + (1).ToString()) + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_BILLED" + (1).ToString()) + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_PROF_AMT_ADJUSTS" + (1).ToString()) + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS" + (1).ToString());
                COMP_CODE.Value = "AFPIN";
                COMP_TYPE.Value = QDesign.NULL(AFPIN_TYPE.Value);
                PROCESS_SEQ.Value = AFPIN_SEQ.Value;
                FACTOR.Value = AFPIN_FACTOR.Value;
                MTD_AFPINING.Value = MTD_AFPIN_PROF.Value;


                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_AUDIT, SubFileType.Keep, SubFileMode.Append, fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_AFP_PAYM_GROUP", MTD_AFPINING, COMP_CODE, FACTOR,
                PROCESS_SEQ, COMP_TYPE);



                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_AUDIT_DOC, fleF050TP_DOC_REVENUE_MSTR_HISTORY.At("DOCREVTP_DOC_NBR"), SubFileType.Keep, SubFileMode.Append, fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_AFP_PAYM_GROUP", MTD_AFPINING, COMP_CODE,
                FACTOR, PROCESS_SEQ, COMP_TYPE);

                SubFile(ref m_trnTRANS_UPDATE, ref fleU110, fleF050TP_DOC_REVENUE_MSTR_HISTORY.At("DOCREVTP_DOC_NBR"), SubFileType.Keep, SubFileMode.Append, fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_DOC_NBR", COMP_CODE, COMP_TYPE, PROCESS_SEQ, FACTOR,
                MTD_AFPINING);



                Reset(ref MTD_AFPIN_PROF, fleF050TP_DOC_REVENUE_MSTR_HISTORY.At("DOCREVTP_DOC_NBR"));

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
            EndRequest("U110B_PROCESS_2");

        }

    }




    #endregion


}
//U110B_PROCESS_2




