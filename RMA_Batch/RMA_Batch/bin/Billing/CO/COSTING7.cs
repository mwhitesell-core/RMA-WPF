
#region "Screen Comments"

// Program: costing7.qts
// Purpose: - calculates number of months doctor was active during the
// costing year   
// DATE     BY WHOM     DESCRIPTION
// 00/jul/13  B.E. - original
// 03/dec/17  A.A. - alpha doctor nbr
// 16/Nov/28  MC1  - use set lock record update
// MC1
// set lock file update


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class COSTING7 : BaseClassControl
{

    private COSTING7 m_COSTING7;

    public COSTING7(string Name, int Level)
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


    }

    public COSTING7(string Name, int Level, bool Request)
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


    }

    public override void Dispose()
    {
        if ((m_COSTING7 != null))
        {
            m_COSTING7.CloseTransactionObjects();
            m_COSTING7 = null;
        }
    }

    public COSTING7 GetCOSTING7(int Level)
    {
        if (m_COSTING7 == null)
        {
            m_COSTING7 = new COSTING7("COSTING7", Level);
        }
        else
        {
            m_COSTING7.ResetValues();
        }
        return m_COSTING7;
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

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            COSTING7_COSTING1_GET_REC_7_1 COSTING1_GET_REC_7_1 = new COSTING7_COSTING1_GET_REC_7_1(Name, Level);
            COSTING1_GET_REC_7_1.Run();
            COSTING1_GET_REC_7_1.Dispose();
            COSTING1_GET_REC_7_1 = null;

            COSTING7_1_2 C1_2 = new COSTING7_1_2(Name, Level);
            C1_2.Run();
            C1_2.Dispose();
            C1_2 = null;

            COSTING7_2_3 C2_3 = new COSTING7_2_3(Name, Level);
            C2_3.Run();
            C2_3.Dispose();
            C2_3 = null;

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



public class COSTING7_COSTING1_GET_REC_7_1 : COSTING7
{

    public COSTING7_COSTING1_GET_REC_7_1(string Name, int Level)
        : base(Name, Level, true)
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
        fleCONSTANTS_MSTR_REC_7 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F090_CONSTANTS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(COSTING7_COSTING1_GET_REC_7_1)"

    protected CoreDate W_CURRENT_FISCAL_START_YYMMDD;
    protected CoreDate W_CURRENT_FISCAL_END_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_CUTOFF_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_PED;
    protected CoreDecimal W_CURRENT_COSTING_PED_YYMM;
    protected CoreDate W_PREVIOUS_FISCAL_START_YYMMDD;
    protected CoreDate W_PREVIOUS_FISCAL_END_YYMMDD;
    protected CoreDecimal W_EP_YR;
    private SqlFileObject fleCONSTANTS_MSTR_REC_7;


    #endregion


    #region "Standard Generated Procedures(COSTING7_COSTING1_GET_REC_7_1)"


    #region "Automatic Item Initialization(COSTING7_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(COSTING7_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:55 PM

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
        fleCONSTANTS_MSTR_REC_7.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(COSTING7_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:55 PM

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
            fleCONSTANTS_MSTR_REC_7.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING7_COSTING1_GET_REC_7_1)"


    public void Run()
    {

        try
        {
            Request("COSTING1_GET_REC_7_1");

            while (fleCONSTANTS_MSTR_REC_7.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_7 <--

                fleCONSTANTS_MSTR_REC_7.GetData();
                // --> End GET CONSTANTS_MSTR_REC_7 <--

                if (Transaction())
                {
                    W_CURRENT_FISCAL_START_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_FISCAL_START_YYMMDD");
                    W_CURRENT_FISCAL_END_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_FISCAL_END_YYMMDD");
                    W_CURRENT_COSTING_CUTOFF_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_COSTING_CUTOFF_YYMMDD");
                    W_CURRENT_COSTING_PED.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_COSTING_PED");
                    W_CURRENT_COSTING_PED_YYMM.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_COSTING_PED") / 100;
                    W_PREVIOUS_FISCAL_START_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("PREVIOUS_FISCAL_START_YYMMDD");
                    W_PREVIOUS_FISCAL_END_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("PREVIOUS_FISCAL_END_YYMMDD");
                    W_EP_YR.Value = fleCONSTANTS_MSTR_REC_7.GetDecimalValue("EP_YR");

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
            EndRequest("COSTING1_GET_REC_7_1");

        }

    }







    #endregion


}
//COSTING1_GET_REC_7_1



public class COSTING7_1_2 : COSTING7
{

    public COSTING7_1_2(string Name, int Level)
        : base(Name, Level, true)
	{
		this.ScreenType = ScreenTypes.QTP;
fleCOSTING2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING2", "", false, false, false, 0,		"m_trnTRANS_UPDATE", FileType.SubFile); 
fleCOSTING7 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING7", "", false, false, false, 0,		"m_trnTRANS_UPDATE", FileType.SubFile); 


	}


    #region "Declarations (Variables, Files and Transactions)(COSTING7_1_2)"

    private SqlFileObject fleCOSTING2;


    private SqlFileObject fleCOSTING7;


    #endregion


    #region "Standard Generated Procedures(COSTING7_1_2)"


    #region "Automatic Item Initialization(COSTING7_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(COSTING7_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:55 PM

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
        fleCOSTING2.Transaction = m_trnTRANS_UPDATE;
        fleCOSTING7.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(COSTING7_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:55 PM

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
            fleCOSTING2.Dispose();
            fleCOSTING7.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING7_1_2)"


    public void Run()
    {

        try
        {
            Request("1_2");

            while (fleCOSTING2.QTPForMissing())
            {
                // --> GET COSTING2 <--

                fleCOSTING2.GetData();
                // --> End GET COSTING2 <--


                if (Transaction())
                {

                    Sort(fleCOSTING2.GetSortValue("DOC_NBR"));


                }

            }


            while (Sort(fleCOSTING2))
            {

                SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING7, fleCOSTING2.At("DOC_NBR"), SubFileType.Keep, fleCOSTING2);
                


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
            EndRequest("1_2");

        }

    }




    #endregion


}
//1_2



public class COSTING7_2_3 : COSTING7
{

    public COSTING7_2_3(string Name, int Level)
        : base(Name, Level, true)
	{
		this.ScreenType = ScreenTypes.QTP;
fleCOSTING7 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING7", "", false, false, false, 0,		"m_trnTRANS_UPDATE", FileType.SubFile); 
fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0,	"m_trnTRANS_UPDATE"); 
fleTMP_COUNTERS_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_ALPHA", "", false, false, false, 0,	"m_trnTRANS_UPDATE"); 

X_START.GetValue += X_START_GetValue;
X_START_MTH.GetValue += X_START_MTH_GetValue;
X_TERM.GetValue += X_TERM_GetValue;
X_TERM_MTH.GetValue += X_TERM_MTH_GetValue;
X_RENUMBERED_START.GetValue += X_RENUMBERED_START_GetValue;
X_RENUMBERED_TERM.GetValue += X_RENUMBERED_TERM_GetValue;
X_NBR_ACTIVE_MTHS.GetValue += X_NBR_ACTIVE_MTHS_GetValue;
fleTMP_COUNTERS_ALPHA.SetItemFinals += fleTMP_COUNTERS_ALPHA_SetItemFinals;

	}


    #region "Declarations (Variables, Files and Transactions)(COSTING7_2_3)"

    private SqlFileObject fleCOSTING7;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DCharacter X_START = new DCharacter("X_START", 8);
    private void X_START_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_START"), 8);


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
    private DDecimal X_START_MTH = new DDecimal("X_START_MTH", 6);
    private void X_START_MTH_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.Substring(X_START.Value, 5, 2));


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
    private DCharacter X_TERM = new DCharacter("X_TERM", 8);
    private void X_TERM_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM"), 8);


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
    private DDecimal X_TERM_MTH = new DDecimal("X_TERM_MTH", 6);
    private void X_TERM_MTH_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.Substring(X_TERM.Value, 5, 2));


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
    private DDecimal X_RENUMBERED_START = new DDecimal("X_RENUMBERED_START", 6);
    private void X_RENUMBERED_START_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_START") <= W_CURRENT_FISCAL_START_YYMMDD.Value)
            {
                CurrentValue = 1;
            }
            else if (fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_START") >= W_CURRENT_FISCAL_END_YYMMDD.Value)
            {
                CurrentValue = 0;
            }
            else if (QDesign.NULL(X_START_MTH.Value) > 6)
            {
                CurrentValue = X_START_MTH.Value - 6;
            }
            else
            {
                CurrentValue = X_START_MTH.Value + 6;
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
    private DDecimal X_RENUMBERED_TERM = new DDecimal("X_RENUMBERED_TERM", 6);
    private void X_RENUMBERED_TERM_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM") >= W_CURRENT_FISCAL_END_YYMMDD.Value | QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) == 0)
            {
                CurrentValue = 12;
            }
            else if (fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM") <= W_CURRENT_FISCAL_START_YYMMDD.Value)
            {
                CurrentValue = 0;
            }
            else if (QDesign.NULL(X_TERM_MTH.Value) > 6)
            {
                CurrentValue = X_TERM_MTH.Value - 6;
            }
            else
            {
                CurrentValue = X_TERM_MTH.Value + 6;
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
    private DDecimal X_NBR_ACTIVE_MTHS = new DDecimal("X_NBR_ACTIVE_MTHS", 6);
    private void X_NBR_ACTIVE_MTHS_GetValue(ref decimal Value)
    {

        try
        {
            Value = X_RENUMBERED_TERM.Value - X_RENUMBERED_START.Value + 1;


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
    private SqlFileObject fleTMP_COUNTERS_ALPHA;

    private void fleTMP_COUNTERS_ALPHA_SetItemFinals()
    {

        try
        {
            fleTMP_COUNTERS_ALPHA.set_SetValue("TMP_COUNTER_KEY_ALPHA", fleCOSTING7.GetStringValue("DOC_NBR"));
            fleTMP_COUNTERS_ALPHA.set_SetValue("TMP_COUNTER_1", fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_START"));
            fleTMP_COUNTERS_ALPHA.set_SetValue("TMP_COUNTER_2", fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM"));
            fleTMP_COUNTERS_ALPHA.set_SetValue("TMP_COUNTER_3", X_RENUMBERED_START.Value);
            fleTMP_COUNTERS_ALPHA.set_SetValue("TMP_COUNTER_4", X_RENUMBERED_TERM.Value);
            fleTMP_COUNTERS_ALPHA.set_SetValue("TMP_COUNTER_5", X_NBR_ACTIVE_MTHS.Value);


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


    #region "Standard Generated Procedures(COSTING7_2_3)"


    #region "Automatic Item Initialization(COSTING7_2_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(COSTING7_2_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:55 PM

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
        fleCOSTING7.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS_ALPHA.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(COSTING7_2_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:55 PM

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
            fleCOSTING7.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleTMP_COUNTERS_ALPHA.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING7_2_3)"


    public void Run()
    {

        try
        {
            Request("2_3");

            while (fleCOSTING7.QTPForMissing())
            {
                // --> GET COSTING7 <--

                fleCOSTING7.GetData();
                // --> End GET COSTING7 <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {


                        fleTMP_COUNTERS_ALPHA.OutPut(OutPutType.Add);
                        

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
            EndRequest("2_3");

        }

    }




    #endregion


}
//2_3




