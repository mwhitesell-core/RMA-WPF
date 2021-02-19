
#region "Screen Comments"

// #> PROGRAM-ID.     U121.QTS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// - update doctor mstr values that will be printed on Statement
// with the appropriate printer control characters
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 93/Apr/19  ____   B.E.     - original
// 93/JUL/06  ____   B.E.     - COMPUTED Ceilings now have cents
// 93/SEP/15  ____   B.E.     - update F020 with F090/F191 Current
// PED and EFT DATE OF DEPOSIT
// 95/NOV/17  ----   M.C.     - ADD A NEW REQUEST FOR THE PRT FORMAT
// OF THE NEW ITEM IN F020-DOCTOR-EXTRA
// 1999/Feb/18         S.B.     - Checked for Y2K.
// 1999/apr/30  B.E.  - w-current-ped and w-current-date-eft-deposit
// changed from zoned to zoned*8
// 2003/dec/24      A.A.  - alpha doctor nbr
// 2006/may/10 b.e.      - $1M payroll changes to size of calculated fields
// 2014/Apr/28 MC1 - include different invoice withdrawl date(last day of the month) for paycode 7
// - include f112 & f191 files in the access to determine the doc-pay-code in
// request u121_run_0
// 2014/May/20 MC2 - use ep-date-closed of f191-earnings-period for paycode 7
// to set doc-ep-date-deposit for withdrawal date
// 99/apr/30 B.E. changed definition from zoned to zoned*8


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U121 : BaseClassControl
{

    private U121 m_U121;

    public U121(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_PED = new CoreDecimal("W_CURRENT_PED", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_DATE_EFT_DEPOSIT = new CoreDecimal("W_CURRENT_DATE_EFT_DEPOSIT", 8, this, ResetTypes.ResetAtStartup);


    }

    public U121(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_PED = new CoreDecimal("W_CURRENT_PED", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_DATE_EFT_DEPOSIT = new CoreDecimal("W_CURRENT_DATE_EFT_DEPOSIT", 8, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_U121 != null))
        {
            m_U121.CloseTransactionObjects();
            m_U121 = null;
        }
    }

    public U121 GetU121(int Level)
    {
        if (m_U121 == null)
        {
            m_U121 = new U121("U121", Level);
        }
        else
        {
            m_U121.ResetValues();
        }
        return m_U121;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_PED;

    protected CoreDecimal W_CURRENT_DATE_EFT_DEPOSIT;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U121_U114_CONST_VALUES_GET_EP_NBR_1 U114_CONST_VALUES_GET_EP_NBR_1 = new U121_U114_CONST_VALUES_GET_EP_NBR_1(Name, Level);
            U114_CONST_VALUES_GET_EP_NBR_1.Run();
            U114_CONST_VALUES_GET_EP_NBR_1.Dispose();
            U114_CONST_VALUES_GET_EP_NBR_1 = null;

            U121_RUN_0_2 RUN_0_2 = new U121_RUN_0_2(Name, Level);
            RUN_0_2.Run();
            RUN_0_2.Dispose();
            RUN_0_2 = null;

            U121_RUN_1_3 RUN_1_3 = new U121_RUN_1_3(Name, Level);
            RUN_1_3.Run();
            RUN_1_3.Dispose();
            RUN_1_3 = null;

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



public class U121_U114_CONST_VALUES_GET_EP_NBR_1 : U121
{

    public U121_U114_CONST_VALUES_GET_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U121_U114_CONST_VALUES_GET_EP_NBR_1)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF191_EARNINGS_PERIOD;

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


    #region "Standard Generated Procedures(U121_U114_CONST_VALUES_GET_EP_NBR_1)"


    #region "Automatic Item Initialization(U121_U114_CONST_VALUES_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U121_U114_CONST_VALUES_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:17 PM

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
        fleF191_EARNINGS_PERIOD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U121_U114_CONST_VALUES_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:17 PM

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
            fleF191_EARNINGS_PERIOD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U121_U114_CONST_VALUES_GET_EP_NBR_1)"


    public void Run()
    {

        try
        {
            Request("U114_CONST_VALUES_GET_EP_NBR_1");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF191_EARNINGS_PERIOD.QTPForMissing("1"))
                {
                    // --> GET F191_EARNINGS_PERIOD <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    fleF191_EARNINGS_PERIOD.GetData(m_strWhere.ToString());
                    // --> End GET F191_EARNINGS_PERIOD <--

                    if (Transaction())
                    {
                        W_CURRENT_PED.Value = fleF191_EARNINGS_PERIOD.GetNumericDateValue("ICONST_DATE_PERIOD_END");
                        W_CURRENT_DATE_EFT_DEPOSIT.Value = fleF191_EARNINGS_PERIOD.GetNumericDateValue("DATE_EFT_DEPOSIT");

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
            EndRequest("U114_CONST_VALUES_GET_EP_NBR_1");

        }

    }







    #endregion


}
//U114_CONST_VALUES_GET_EP_NBR_1



public class U121_RUN_0_2 : U121
{

    public U121_RUN_0_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "F020_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEBUGU121 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU121", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_PERIOD.GetValue += X_PERIOD_GetValue;
        X_CEICEA_DOLLARS.GetValue += X_CEICEA_DOLLARS_GetValue;
        X_CEICEA_CENTS.GetValue += X_CEICEA_CENTS_GetValue;
        X_CEICEX_DOLLARS.GetValue += X_CEICEX_DOLLARS_GetValue;
        X_CEICEX_CENTS.GetValue += X_CEICEX_CENTS_GetValue;
        X_YTDCEA_DOLLARS.GetValue += X_YTDCEA_DOLLARS_GetValue;
        X_YTDCEA_CENTS.GetValue += X_YTDCEA_CENTS_GetValue;
        X_YTDCEX_DOLLARS.GetValue += X_YTDCEX_DOLLARS_GetValue;
        X_YTDCEX_CENTS.GetValue += X_YTDCEX_CENTS_GetValue;
        X_CEICEA_DOLLARS_A.GetValue += X_CEICEA_DOLLARS_A_GetValue;
        X_CEICEA_DOLLARS_B.GetValue += X_CEICEA_DOLLARS_B_GetValue;
        X_CEICEX_DOLLARS_A.GetValue += X_CEICEX_DOLLARS_A_GetValue;
        X_CEICEX_DOLLARS_B.GetValue += X_CEICEX_DOLLARS_B_GetValue;
        X_YTDCEA_DOLLARS_A.GetValue += X_YTDCEA_DOLLARS_A_GetValue;
        X_YTDCEA_DOLLARS_B.GetValue += X_YTDCEA_DOLLARS_B_GetValue;
        X_YTDCEX_DOLLARS_A.GetValue += X_YTDCEX_DOLLARS_A_GetValue;
        X_YTDCEX_DOLLARS_B.GetValue += X_YTDCEX_DOLLARS_B_GetValue;
        X_CEICEA_DOLLARS_CHAR.GetValue += X_CEICEA_DOLLARS_CHAR_GetValue;
        X_CEICEA_PRT_DOLLARS.GetValue += X_CEICEA_PRT_DOLLARS_GetValue;
        X_CEICEA_PRT_CENTS.GetValue += X_CEICEA_PRT_CENTS_GetValue;
        X_CEICEX_DOLLARS_CHAR.GetValue += X_CEICEX_DOLLARS_CHAR_GetValue;
        X_CEICEX_PRT_DOLLARS.GetValue += X_CEICEX_PRT_DOLLARS_GetValue;
        X_CEICEX_PRT_CENTS.GetValue += X_CEICEX_PRT_CENTS_GetValue;
        X_YTDCEA_DOLLARS_CHAR.GetValue += X_YTDCEA_DOLLARS_CHAR_GetValue;
        X_YTDCEA_PRT_DOLLARS.GetValue += X_YTDCEA_PRT_DOLLARS_GetValue;
        X_YTDCEA_PRT_CENTS.GetValue += X_YTDCEA_PRT_CENTS_GetValue;
        X_YTDCEX_DOLLARS_CHAR.GetValue += X_YTDCEX_DOLLARS_CHAR_GetValue;
        X_YTDCEX_PRT_DOLLARS.GetValue += X_YTDCEX_PRT_DOLLARS_GetValue;
        X_YTDCEX_PRT_CENTS.GetValue += X_YTDCEX_PRT_CENTS_GetValue;
        X_CEICEA_CTR1.GetValue += X_CEICEA_CTR1_GetValue;
        X_CEICEX_CTR1.GetValue += X_CEICEX_CTR1_GetValue;
        X_YTDCEA_CTR1.GetValue += X_YTDCEA_CTR1_GetValue;
        X_YTDCEX_CTR1.GetValue += X_YTDCEX_CTR1_GetValue;
        X_CEICEA_CTR2.GetValue += X_CEICEA_CTR2_GetValue;
        X_CEICEX_CTR2.GetValue += X_CEICEX_CTR2_GetValue;
        X_YTDCEA_CTR2.GetValue += X_YTDCEA_CTR2_GetValue;
        X_YTDCEX_CTR2.GetValue += X_YTDCEX_CTR2_GetValue;
        fleF112_PYCDCEILINGS.InitializeItems += fleF112_PYCDCEILINGS_AutomaticItemInitialization;
        fleF020_UPDATE.InitializeItems += fleF020_UPDATE_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U121_RUN_0_2)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF191_EARNINGS_PERIOD;
    private SqlFileObject fleF112_PYCDCEILINGS;
    private DCharacter X_PERIOD = new DCharacter("X_PERIOD", 1);
    private void X_PERIOD_GetValue(ref string Value)
    {

        try
        {
            Value = ".";


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
    private DDecimal X_CEICEA_DOLLARS = new DDecimal("X_CEICEA_DOLLARS", 9);
    private void X_CEICEA_DOLLARS_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA") / 100;


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
    private DDecimal X_CEICEA_CENTS = new DDecimal("X_CEICEA_CENTS", 6);
    private void X_CEICEA_CENTS_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"), 100);


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
    private DDecimal X_CEICEX_DOLLARS = new DDecimal("X_CEICEX_DOLLARS", 9);
    private void X_CEICEX_DOLLARS_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX") / 100;


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
    private DDecimal X_CEICEX_CENTS = new DDecimal("X_CEICEX_CENTS", 6);
    private void X_CEICEX_CENTS_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"), 100);


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
    private DDecimal X_YTDCEA_DOLLARS = new DDecimal("X_YTDCEA_DOLLARS", 9);
    private void X_YTDCEA_DOLLARS_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED") / 100;


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
    private DDecimal X_YTDCEA_CENTS = new DDecimal("X_YTDCEA_CENTS", 6);
    private void X_YTDCEA_CENTS_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"), 100);


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
    private DDecimal X_YTDCEX_DOLLARS = new DDecimal("X_YTDCEX_DOLLARS", 9);
    private void X_YTDCEX_DOLLARS_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED") / 100;


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
    private DDecimal X_YTDCEX_CENTS = new DDecimal("X_YTDCEX_CENTS", 6);
    private void X_YTDCEX_CENTS_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"), 100);


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
    private DCharacter X_CEICEA_DOLLARS_A = new DCharacter("X_CEICEA_DOLLARS_A", 7);
    private void X_CEICEA_DOLLARS_A_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_CEICEA_DOLLARS.Value, 7);


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
    private DCharacter X_CEICEA_DOLLARS_B = new DCharacter("X_CEICEA_DOLLARS_B", 7);
    private void X_CEICEA_DOLLARS_B_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_CEICEA_DOLLARS.Value) >999999)
            {
                CurrentValue = X_CEICEA_DOLLARS_A.Value;
            }
            else if (QDesign.NULL(X_CEICEA_DOLLARS.Value) >99999)
            {
                CurrentValue= QDesign.Substring(X_CEICEA_DOLLARS_A.Value, 2, 6);
            }
            else if (QDesign.NULL(X_CEICEA_DOLLARS.Value) >9999)
            {
                CurrentValue= QDesign.Substring(X_CEICEA_DOLLARS_A.Value, 3, 5);
            }
            else if (QDesign.NULL(X_CEICEA_DOLLARS.Value) >999)
            {
                CurrentValue= QDesign.Substring(X_CEICEA_DOLLARS_A.Value, 4, 4);
            }
            else if (QDesign.NULL(X_CEICEA_DOLLARS.Value) > 99)
            {
                CurrentValue= QDesign.Substring(X_CEICEA_DOLLARS_A.Value, 5, 3);
            }
            else if (QDesign.NULL(X_CEICEA_DOLLARS.Value) > 9)
            {
                CurrentValue= QDesign.Substring(X_CEICEA_DOLLARS_A.Value, 6, 2);
            }
            else
            {
                CurrentValue= QDesign.Substring(X_CEICEA_DOLLARS_A.Value, 7, 1);
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
    private DCharacter X_CEICEX_DOLLARS_A = new DCharacter("X_CEICEX_DOLLARS_A", 7);
    private void X_CEICEX_DOLLARS_A_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_CEICEX_DOLLARS.Value, 7);


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
    private DCharacter X_CEICEX_DOLLARS_B = new DCharacter("X_CEICEX_DOLLARS_B", 7);
    private void X_CEICEX_DOLLARS_B_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_CEICEX_DOLLARS.Value) >999999)
            {
                CurrentValue = X_CEICEX_DOLLARS_A.Value;
            }
            else if (QDesign.NULL(X_CEICEX_DOLLARS.Value) >99999)
            {
                CurrentValue= QDesign.Substring(X_CEICEX_DOLLARS_A.Value, 2, 6);
            }
            else if (QDesign.NULL(X_CEICEX_DOLLARS.Value) >9999)
            {
                CurrentValue= QDesign.Substring(X_CEICEX_DOLLARS_A.Value, 3, 5);
            }
            else if (QDesign.NULL(X_CEICEX_DOLLARS.Value) >999)
            {
                CurrentValue= QDesign.Substring(X_CEICEX_DOLLARS_A.Value, 4, 4);
            }
            else if (QDesign.NULL(X_CEICEX_DOLLARS.Value) > 99)
            {
                CurrentValue= QDesign.Substring(X_CEICEX_DOLLARS_A.Value, 5, 3);
            }
            else if (QDesign.NULL(X_CEICEX_DOLLARS.Value) > 9)
            {
                CurrentValue= QDesign.Substring(X_CEICEX_DOLLARS_A.Value, 6, 2);
            }
            else
            {
                CurrentValue= QDesign.Substring(X_CEICEX_DOLLARS_A.Value, 7, 1);
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
    private DCharacter X_YTDCEA_DOLLARS_A = new DCharacter("X_YTDCEA_DOLLARS_A", 7);
    private void X_YTDCEA_DOLLARS_A_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_YTDCEA_DOLLARS.Value, 7);


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
    private DCharacter X_YTDCEA_DOLLARS_B = new DCharacter("X_YTDCEA_DOLLARS_B", 7);
    private void X_YTDCEA_DOLLARS_B_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) >999999)
            {
                CurrentValue = X_YTDCEA_DOLLARS_A.Value;
            }
            else if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) >99999)
            {
                CurrentValue= QDesign.Substring(X_YTDCEA_DOLLARS_A.Value, 2, 6);
            }
            else if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) >9999)
            {
                CurrentValue= QDesign.Substring(X_YTDCEA_DOLLARS_A.Value, 3, 5);
            }
            else if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) >999)
            {
                CurrentValue= QDesign.Substring(X_YTDCEA_DOLLARS_A.Value, 4, 4);
            }
            else if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) > 99)
            {
                CurrentValue= QDesign.Substring(X_YTDCEA_DOLLARS_A.Value, 5, 3);
            }
            else if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) > 9)
            {
                CurrentValue= QDesign.Substring(X_YTDCEA_DOLLARS_A.Value, 6, 2);
            }
            else
            {
                CurrentValue= QDesign.Substring(X_YTDCEA_DOLLARS_A.Value, 7, 1);
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
    private DCharacter X_YTDCEX_DOLLARS_A = new DCharacter("X_YTDCEX_DOLLARS_A", 7);
    private void X_YTDCEX_DOLLARS_A_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_YTDCEX_DOLLARS.Value, 7);


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
    private DCharacter X_YTDCEX_DOLLARS_B = new DCharacter("X_YTDCEX_DOLLARS_B", 7);
    private void X_YTDCEX_DOLLARS_B_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) >999999)
            {
                CurrentValue = X_YTDCEX_DOLLARS_A.Value;
            }
            else if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) >99999)
            {
                CurrentValue= QDesign.Substring(X_YTDCEX_DOLLARS_A.Value, 2, 6);
            }
            else if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) >9999)
            {
                CurrentValue= QDesign.Substring(X_YTDCEX_DOLLARS_A.Value, 3, 5);
            }
            else if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) >999)
            {
                CurrentValue= QDesign.Substring(X_YTDCEX_DOLLARS_A.Value, 4, 4);
            }
            else if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) > 99)
            {
                CurrentValue= QDesign.Substring(X_YTDCEX_DOLLARS_A.Value, 5, 3);
            }
            else if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) > 9)
            {
                CurrentValue= QDesign.Substring(X_YTDCEX_DOLLARS_A.Value, 6, 2);
            }
            else
            {
                CurrentValue= QDesign.Substring(X_YTDCEX_DOLLARS_A.Value, 7, 1);
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
    private DCharacter X_CEICEA_DOLLARS_CHAR = new DCharacter("X_CEICEA_DOLLARS_CHAR", 7);
    private void X_CEICEA_DOLLARS_CHAR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.RightJustify(X_CEICEA_DOLLARS_B.Value);


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
    private DCharacter X_CEICEA_PRT_DOLLARS = new DCharacter("X_CEICEA_PRT_DOLLARS", 8);
    private void X_CEICEA_PRT_DOLLARS_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_CEICEA_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_CEICEA_DOLLARS_CHAR.Value;
            }
            else
            {
                CurrentValue= QDesign.Substring(X_CEICEA_DOLLARS_CHAR.Value, 1, 4) + "," + QDesign.Substring(X_CEICEA_DOLLARS_CHAR.Value, 5, 3);
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
    private DCharacter X_CEICEA_PRT_CENTS = new DCharacter("X_CEICEA_PRT_CENTS", 2);
    private void X_CEICEA_PRT_CENTS_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_CEICEA_CENTS.Value, 2);


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
    private DCharacter X_CEICEX_DOLLARS_CHAR = new DCharacter("X_CEICEX_DOLLARS_CHAR", 7);
    private void X_CEICEX_DOLLARS_CHAR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.RightJustify(X_CEICEX_DOLLARS_B.Value);


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
    private DCharacter X_CEICEX_PRT_DOLLARS = new DCharacter("X_CEICEX_PRT_DOLLARS", 8);
    private void X_CEICEX_PRT_DOLLARS_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_CEICEX_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_CEICEX_DOLLARS_CHAR.Value;
            }
            else
            {
                CurrentValue= QDesign.Substring(X_CEICEX_DOLLARS_CHAR.Value, 1, 4) + "," + QDesign.Substring(X_CEICEX_DOLLARS_CHAR.Value, 5, 3);
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
    private DCharacter X_CEICEX_PRT_CENTS = new DCharacter("X_CEICEX_PRT_CENTS", 2);
    private void X_CEICEX_PRT_CENTS_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_CEICEX_CENTS.Value, 2);


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
    private DCharacter X_YTDCEA_DOLLARS_CHAR = new DCharacter("X_YTDCEA_DOLLARS_CHAR", 7);
    private void X_YTDCEA_DOLLARS_CHAR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.RightJustify(X_YTDCEA_DOLLARS_B.Value);


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
    private DCharacter X_YTDCEA_PRT_DOLLARS = new DCharacter("X_YTDCEA_PRT_DOLLARS", 8);
    private void X_YTDCEA_PRT_DOLLARS_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_YTDCEA_DOLLARS_CHAR.Value;
            }
            else
            {
                CurrentValue= QDesign.Substring(X_YTDCEA_DOLLARS_CHAR.Value, 1, 4) + "," + QDesign.Substring(X_YTDCEA_DOLLARS_CHAR.Value, 5, 3);
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
    private DCharacter X_YTDCEA_PRT_CENTS = new DCharacter("X_YTDCEA_PRT_CENTS", 2);
    private void X_YTDCEA_PRT_CENTS_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_YTDCEA_CENTS.Value, 2);


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
    private DCharacter X_YTDCEX_DOLLARS_CHAR = new DCharacter("X_YTDCEX_DOLLARS_CHAR", 7);
    private void X_YTDCEX_DOLLARS_CHAR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.RightJustify(X_YTDCEX_DOLLARS_B.Value);


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
    private DCharacter X_YTDCEX_PRT_DOLLARS = new DCharacter("X_YTDCEX_PRT_DOLLARS", 8);
    private void X_YTDCEX_PRT_DOLLARS_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_YTDCEX_DOLLARS_CHAR.Value;
            }
            else
            {
                CurrentValue= QDesign.Substring(X_YTDCEX_DOLLARS_CHAR.Value, 1, 4) + "," + QDesign.Substring(X_YTDCEX_DOLLARS_CHAR.Value, 5, 3);
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
    private DCharacter X_YTDCEX_PRT_CENTS = new DCharacter("X_YTDCEX_PRT_CENTS", 2);
    private void X_YTDCEX_PRT_CENTS_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_YTDCEX_CENTS.Value, 2);


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
    private DDecimal X_CEICEA_CTR1 = new DDecimal("X_CEICEA_CTR1", 1);
    private void X_CEICEA_CTR1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_CEICEA_DOLLARS.Value) < 10)
            {
                CurrentValue = 21;
            }
            else if (QDesign.NULL(X_CEICEA_DOLLARS.Value) < 100)
            {
                CurrentValue = 42;
            }
            else if (QDesign.NULL(X_CEICEA_DOLLARS.Value) < 1000)
            {
                CurrentValue = 63;
            }
            else if (QDesign.NULL(X_CEICEA_DOLLARS.Value) < 10000)
            {
                CurrentValue = 84;
            }
            else if (QDesign.NULL(X_CEICEA_DOLLARS.Value) < 100000)
            {
                CurrentValue = 105;
            }
            else
            {
                CurrentValue = 126;
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
    private DDecimal X_CEICEX_CTR1 = new DDecimal("X_CEICEX_CTR1", 1);
    private void X_CEICEX_CTR1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_CEICEX_DOLLARS.Value) < 10)
            {
                CurrentValue = 21;
            }
            else if (QDesign.NULL(X_CEICEX_DOLLARS.Value) < 100)
            {
                CurrentValue = 42;
            }
            else if (QDesign.NULL(X_CEICEX_DOLLARS.Value) < 1000)
            {
                CurrentValue = 63;
            }
            else if (QDesign.NULL(X_CEICEX_DOLLARS.Value) < 10000)
            {
                CurrentValue = 84;
            }
            else if (QDesign.NULL(X_CEICEX_DOLLARS.Value) < 100000)
            {
                CurrentValue = 105;
            }
            else
            {
                CurrentValue = 126;
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
    private DDecimal X_YTDCEA_CTR1 = new DDecimal("X_YTDCEA_CTR1", 1);
    private void X_YTDCEA_CTR1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) < 10)
            {
                CurrentValue = 21;
            }
            else if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) < 100)
            {
                CurrentValue = 42;
            }
            else if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) < 1000)
            {
                CurrentValue = 63;
            }
            else if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) < 10000)
            {
                CurrentValue = 84;
            }
            else if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) < 100000)
            {
                CurrentValue = 105;
            }
            else
            {
                CurrentValue = 126;
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
    private DDecimal X_YTDCEX_CTR1 = new DDecimal("X_YTDCEX_CTR1", 1);
    private void X_YTDCEX_CTR1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) < 10)
            {
                CurrentValue = 21;
            }
            else if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) < 100)
            {
                CurrentValue = 42;
            }
            else if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) < 1000)
            {
                CurrentValue = 63;
            }
            else if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) < 10000)
            {
                CurrentValue = 84;
            }
            else if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) < 100000)
            {
                CurrentValue = 105;
            }
            else
            {
                CurrentValue = 126;
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
    private DDecimal X_CEICEA_CTR2 = new DDecimal("X_CEICEA_CTR2", 1);
    private void X_CEICEA_CTR2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_CEICEA_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_CEICEA_CTR1.Value;
            }
            else
            {
                CurrentValue = X_CEICEA_CTR1.Value + 14;
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
    private DDecimal X_CEICEX_CTR2 = new DDecimal("X_CEICEX_CTR2", 1);
    private void X_CEICEX_CTR2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_CEICEX_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_CEICEX_CTR1.Value;
            }
            else
            {
                CurrentValue = X_CEICEX_CTR1.Value + 14;
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
    private DDecimal X_YTDCEA_CTR2 = new DDecimal("X_YTDCEA_CTR2", 1);
    private void X_YTDCEA_CTR2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_YTDCEA_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_YTDCEA_CTR1.Value;
            }
            else
            {
                CurrentValue = X_YTDCEA_CTR1.Value + 14;
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
    private DDecimal X_YTDCEX_CTR2 = new DDecimal("X_YTDCEX_CTR2", 1);
    private void X_YTDCEX_CTR2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_YTDCEX_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_YTDCEX_CTR1.Value;
            }
            else
            {
                CurrentValue = X_YTDCEX_CTR1.Value + 14;
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
    private SqlFileObject fleF020_UPDATE;
    private SqlFileObject fleDEBUGU121;


    #endregion


    #region "Standard Generated Procedures(U121_RUN_0_2)"


    #region "Automatic Item Initialization(U121_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:20 PM

    //#-----------------------------------------
    //# fleF112_PYCDCEILINGS_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:18 PM
    //#-----------------------------------------
    private void fleF112_PYCDCEILINGS_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF112_PYCDCEILINGS.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            //TODO: Manual steps may be required.
            fleF112_PYCDCEILINGS.set_SetValue("EP_NBR", !Fixed, fleF191_EARNINGS_PERIOD.GetDecimalValue("EP_NBR"));
            fleF112_PYCDCEILINGS.set_SetValue("LAST_MOD_DATE", !Fixed, fleF191_EARNINGS_PERIOD.GetDecimalValue("LAST_MOD_DATE"));
            fleF112_PYCDCEILINGS.set_SetValue("LAST_MOD_TIME", !Fixed, fleF191_EARNINGS_PERIOD.GetDecimalValue("LAST_MOD_TIME"));
            fleF112_PYCDCEILINGS.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF191_EARNINGS_PERIOD.GetStringValue("LAST_MOD_USER_ID"));

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
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:18 PM
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


    #region "Transaction Management Procedures(U121_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:17 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF191_EARNINGS_PERIOD.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF020_UPDATE.Transaction = m_trnTRANS_UPDATE;
        fleDEBUGU121.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U121_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:17 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF191_EARNINGS_PERIOD.Dispose();
            fleF112_PYCDCEILINGS.Dispose();
            fleF020_UPDATE.Dispose();
            fleDEBUGU121.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U121_RUN_0_2)"


    public void Run()
    {

        try
        {
            Request("RUN_0_2");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--

                while (fleCONSTANTS_MSTR_REC_6.QTPForMissing("1"))
                {
                    // --> GET CONSTANTS_MSTR_REC_6 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                    m_strWhere.Append((6));

                    fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString());
                    // --> End GET CONSTANTS_MSTR_REC_6 <--

                    while (fleF191_EARNINGS_PERIOD.QTPForMissing("2"))
                    {
                        // --> GET F191_EARNINGS_PERIOD <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ");
                        m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                        fleF191_EARNINGS_PERIOD.GetData(m_strWhere.ToString());
                        // --> End GET F191_EARNINGS_PERIOD <--

                        while (fleF112_PYCDCEILINGS.QTPForMissing("3"))
                        {
                            // --> GET F112_PYCDCEILINGS <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                            m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));
                            m_strWhere.Append(" And ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                            fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F112_PYCDCEILINGS <--


                            if (Transaction())
                            {

                                fleF020_DOCTOR_MSTR.set_SetValue("CEICEA_PRT_FORMAT", QDesign.ASCII(X_CEICEA_CTR2.Value, 3) + QDesign.RTrim(QDesign.LeftJustify(X_CEICEA_PRT_DOLLARS.Value)) + X_PERIOD.Value + X_CEICEA_PRT_CENTS.Value);


                                fleF020_DOCTOR_MSTR.set_SetValue("CEICEX_PRT_FORMAT", QDesign.ASCII(X_CEICEX_CTR2.Value, 3) + QDesign.RTrim(QDesign.LeftJustify(X_CEICEX_PRT_DOLLARS.Value)) + X_PERIOD.Value + X_CEICEX_PRT_CENTS.Value);


                                fleF020_DOCTOR_MSTR.set_SetValue("YTDCEA_PRT_FORMAT", QDesign.ASCII(X_YTDCEA_CTR2.Value, 3) + QDesign.RTrim(QDesign.LeftJustify(X_YTDCEA_PRT_DOLLARS.Value)) + X_PERIOD.Value + X_YTDCEA_PRT_CENTS.Value);


                                fleF020_DOCTOR_MSTR.set_SetValue("YTDCEX_PRT_FORMAT", QDesign.ASCII(X_YTDCEX_CTR2.Value, 3) + QDesign.RTrim(QDesign.LeftJustify(X_YTDCEX_PRT_DOLLARS.Value)) + X_PERIOD.Value + X_YTDCEX_PRT_CENTS.Value);


                                fleF020_DOCTOR_MSTR.set_SetValue("DOC_EP_PED", W_CURRENT_PED.Value);

                                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) != "7")
                                {
                                    fleF020_DOCTOR_MSTR.set_SetValue("DOC_EP_DATE_DEPOSIT", W_CURRENT_DATE_EFT_DEPOSIT.Value);

                                }
                                else if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "7")
                                {
                                    fleF020_DOCTOR_MSTR.set_SetValue("DOC_EP_DATE_DEPOSIT", fleF191_EARNINGS_PERIOD.GetNumericDateValue("EP_DATE_CLOSED"));

                                }
                                fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update);


                                SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU121, SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_NBR", fleF020_DOCTOR_MSTR, "YTDCEA_PRT_FORMAT", "DOC_YTDCEA", X_YTDCEA_DOLLARS_A, X_YTDCEA_DOLLARS_B,
                                X_YTDCEA_DOLLARS);


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
            EndRequest("RUN_0_2");

        }

    }







    #endregion


}
//RUN_0_2



public class U121_RUN_1_3 : U121
{

    public U121_RUN_1_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "F020_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");

        X_PERIOD.GetValue += X_PERIOD_GetValue;
        X_CEIREQ_DOLLARS.GetValue += X_CEIREQ_DOLLARS_GetValue;
        X_CEIREQ_CENTS.GetValue += X_CEIREQ_CENTS_GetValue;
        X_CEITAR_DOLLARS.GetValue += X_CEITAR_DOLLARS_GetValue;
        X_CEITAR_CENTS.GetValue += X_CEITAR_CENTS_GetValue;
        X_YTDREQ_DOLLARS.GetValue += X_YTDREQ_DOLLARS_GetValue;
        X_YTDREQ_CENTS.GetValue += X_YTDREQ_CENTS_GetValue;
        X_YTDTAR_DOLLARS.GetValue += X_YTDTAR_DOLLARS_GetValue;
        X_YTDTAR_CENTS.GetValue += X_YTDTAR_CENTS_GetValue;
        X_CEIREQ_DOLLARS_A.GetValue += X_CEIREQ_DOLLARS_A_GetValue;
        X_CEIREQ_DOLLARS_B.GetValue += X_CEIREQ_DOLLARS_B_GetValue;
        X_CEITAR_DOLLARS_A.GetValue += X_CEITAR_DOLLARS_A_GetValue;
        X_CEITAR_DOLLARS_B.GetValue += X_CEITAR_DOLLARS_B_GetValue;
        X_YTDREQ_DOLLARS_A.GetValue += X_YTDREQ_DOLLARS_A_GetValue;
        X_YTDREQ_DOLLARS_B.GetValue += X_YTDREQ_DOLLARS_B_GetValue;
        X_YTDTAR_DOLLARS_A.GetValue += X_YTDTAR_DOLLARS_A_GetValue;
        X_YTDTAR_DOLLARS_B.GetValue += X_YTDTAR_DOLLARS_B_GetValue;
        X_CEIREQ_DOLLARS_CHAR.GetValue += X_CEIREQ_DOLLARS_CHAR_GetValue;
        X_CEIREQ_PRT_DOLLARS.GetValue += X_CEIREQ_PRT_DOLLARS_GetValue;
        X_CEIREQ_PRT_CENTS.GetValue += X_CEIREQ_PRT_CENTS_GetValue;
        X_CEITAR_DOLLARS_CHAR.GetValue += X_CEITAR_DOLLARS_CHAR_GetValue;
        X_CEITAR_PRT_DOLLARS.GetValue += X_CEITAR_PRT_DOLLARS_GetValue;
        X_CEITAR_PRT_CENTS.GetValue += X_CEITAR_PRT_CENTS_GetValue;
        X_YTDREQ_DOLLARS_CHAR.GetValue += X_YTDREQ_DOLLARS_CHAR_GetValue;
        X_YTDREQ_PRT_DOLLARS.GetValue += X_YTDREQ_PRT_DOLLARS_GetValue;
        X_YTDREQ_PRT_CENTS.GetValue += X_YTDREQ_PRT_CENTS_GetValue;
        X_YTDTAR_DOLLARS_CHAR.GetValue += X_YTDTAR_DOLLARS_CHAR_GetValue;
        X_YTDTAR_PRT_DOLLARS.GetValue += X_YTDTAR_PRT_DOLLARS_GetValue;
        X_YTDTAR_PRT_CENTS.GetValue += X_YTDTAR_PRT_CENTS_GetValue;
        X_CEIREQ_CTR1.GetValue += X_CEIREQ_CTR1_GetValue;
        X_CEITAR_CTR1.GetValue += X_CEITAR_CTR1_GetValue;
        X_YTDREQ_CTR1.GetValue += X_YTDREQ_CTR1_GetValue;
        X_YTDTAR_CTR1.GetValue += X_YTDTAR_CTR1_GetValue;
        X_CEIREQ_CTR2.GetValue += X_CEIREQ_CTR2_GetValue;
        X_CEITAR_CTR2.GetValue += X_CEITAR_CTR2_GetValue;
        X_YTDREQ_CTR2.GetValue += X_YTDREQ_CTR2_GetValue;
        X_YTDTAR_CTR2.GetValue += X_YTDTAR_CTR2_GetValue;
        fleF020_UPDATE.InitializeItems += fleF020_UPDATE_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U121_RUN_1_3)"

    private SqlFileObject fleF020_DOCTOR_EXTRA;
    private DCharacter X_PERIOD = new DCharacter("X_PERIOD", 1);
    private void X_PERIOD_GetValue(ref string Value)
    {

        try
        {
            Value = ".";


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
    private DDecimal X_CEIREQ_DOLLARS = new DDecimal("X_CEIREQ_DOLLARS", 9);
    private void X_CEIREQ_DOLLARS_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEIREQ") / 100;


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
    private DDecimal X_CEIREQ_CENTS = new DDecimal("X_CEIREQ_CENTS", 6);
    private void X_CEIREQ_CENTS_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEIREQ"), 100);


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
    private DDecimal X_CEITAR_DOLLARS = new DDecimal("X_CEITAR_DOLLARS", 9);
    private void X_CEITAR_DOLLARS_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEITAR") / 100;


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
    private DDecimal X_CEITAR_CENTS = new DDecimal("X_CEITAR_CENTS", 6);
    private void X_CEITAR_CENTS_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEITAR"), 100);


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
    private DDecimal X_YTDREQ_DOLLARS = new DDecimal("X_YTDREQ_DOLLARS", 9);
    private void X_YTDREQ_DOLLARS_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE") / 100;


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
    private DDecimal X_YTDREQ_CENTS = new DDecimal("X_YTDREQ_CENTS", 6);
    private void X_YTDREQ_CENTS_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE"), 100);


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
    private DDecimal X_YTDTAR_DOLLARS = new DDecimal("X_YTDTAR_DOLLARS", 9);
    private void X_YTDTAR_DOLLARS_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_TARGET_REVENUE") / 100;


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
    private DDecimal X_YTDTAR_CENTS = new DDecimal("X_YTDTAR_CENTS", 6);
    private void X_YTDTAR_CENTS_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_TARGET_REVENUE"), 100);


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
    private DCharacter X_CEIREQ_DOLLARS_A = new DCharacter("X_CEIREQ_DOLLARS_A", 7);
    private void X_CEIREQ_DOLLARS_A_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_CEIREQ_DOLLARS.Value, 7);


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
    private DCharacter X_CEIREQ_DOLLARS_B = new DCharacter("X_CEIREQ_DOLLARS_B", 7);
    private void X_CEIREQ_DOLLARS_B_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) >999999)
            {
                CurrentValue = X_CEIREQ_DOLLARS_A.Value;
            }
            else if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) >99999)
            {
                CurrentValue= QDesign.Substring(X_CEIREQ_DOLLARS_A.Value, 2, 6);
            }
            else if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) >9999)
            {
                CurrentValue= QDesign.Substring(X_CEIREQ_DOLLARS_A.Value, 3, 5);
            }
            else if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) >999)
            {
                CurrentValue= QDesign.Substring(X_CEIREQ_DOLLARS_A.Value, 4, 4);
            }
            else if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) > 99)
            {
                CurrentValue= QDesign.Substring(X_CEIREQ_DOLLARS_A.Value, 5, 3);
            }
            else if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) > 9)
            {
                CurrentValue= QDesign.Substring(X_CEIREQ_DOLLARS_A.Value, 6, 2);
            }
            else
            {
                CurrentValue= QDesign.Substring(X_CEIREQ_DOLLARS_A.Value, 7, 1);
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
    private DCharacter X_CEITAR_DOLLARS_A = new DCharacter("X_CEITAR_DOLLARS_A", 7);
    private void X_CEITAR_DOLLARS_A_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_CEITAR_DOLLARS.Value, 7);


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
    private DCharacter X_CEITAR_DOLLARS_B = new DCharacter("X_CEITAR_DOLLARS_B", 7);
    private void X_CEITAR_DOLLARS_B_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_CEITAR_DOLLARS.Value) >999999)
            {
                CurrentValue = X_CEITAR_DOLLARS_A.Value;
            }
            else if (QDesign.NULL(X_CEITAR_DOLLARS.Value) >99999)
            {
                CurrentValue= QDesign.Substring(X_CEITAR_DOLLARS_A.Value, 2, 6);
            }
            else if (QDesign.NULL(X_CEITAR_DOLLARS.Value) >9999)
            {
                CurrentValue= QDesign.Substring(X_CEITAR_DOLLARS_A.Value, 3, 5);
            }
            else if (QDesign.NULL(X_CEITAR_DOLLARS.Value) >999)
            {
                CurrentValue= QDesign.Substring(X_CEITAR_DOLLARS_A.Value, 4, 4);
            }
            else if (QDesign.NULL(X_CEITAR_DOLLARS.Value) > 99)
            {
                CurrentValue= QDesign.Substring(X_CEITAR_DOLLARS_A.Value, 5, 3);
            }
            else if (QDesign.NULL(X_CEITAR_DOLLARS.Value) > 9)
            {
                CurrentValue= QDesign.Substring(X_CEITAR_DOLLARS_A.Value, 6, 2);
            }
            else
            {
                CurrentValue= QDesign.Substring(X_CEITAR_DOLLARS_A.Value, 7, 1);
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
    private DCharacter X_YTDREQ_DOLLARS_A = new DCharacter("X_YTDREQ_DOLLARS_A", 7);
    private void X_YTDREQ_DOLLARS_A_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_YTDREQ_DOLLARS.Value, 7);


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
    private DCharacter X_YTDREQ_DOLLARS_B = new DCharacter("X_YTDREQ_DOLLARS_B", 7);
    private void X_YTDREQ_DOLLARS_B_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) >999999)
            {
                CurrentValue = X_YTDREQ_DOLLARS_A.Value;
            }
            else if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) >99999)
            {
                CurrentValue= QDesign.Substring(X_YTDREQ_DOLLARS_A.Value, 2, 6);
            }
            else if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) >9999)
            {
                CurrentValue= QDesign.Substring(X_YTDREQ_DOLLARS_A.Value, 3, 5);
            }
            else if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) >999)
            {
                CurrentValue= QDesign.Substring(X_YTDREQ_DOLLARS_A.Value, 4, 4);
            }
            else if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) > 99)
            {
                CurrentValue= QDesign.Substring(X_YTDREQ_DOLLARS_A.Value, 5, 3);
            }
            else if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) > 9)
            {
                CurrentValue= QDesign.Substring(X_YTDREQ_DOLLARS_A.Value, 6, 2);
            }
            else
            {
                CurrentValue= QDesign.Substring(X_YTDREQ_DOLLARS_A.Value, 7, 1);
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
    private DCharacter X_YTDTAR_DOLLARS_A = new DCharacter("X_YTDTAR_DOLLARS_A", 7);
    private void X_YTDTAR_DOLLARS_A_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_YTDTAR_DOLLARS.Value, 7);


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
    private DCharacter X_YTDTAR_DOLLARS_B = new DCharacter("X_YTDTAR_DOLLARS_B", 7);
    private void X_YTDTAR_DOLLARS_B_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) >999999)
            {
                CurrentValue = X_YTDTAR_DOLLARS_A.Value;
            }
            else if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) >99999)
            {
                CurrentValue= QDesign.Substring(X_YTDTAR_DOLLARS_A.Value, 2, 5);
            }
            else if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) >9999)
            {
                CurrentValue= QDesign.Substring(X_YTDTAR_DOLLARS_A.Value, 2, 5);
            }
            else if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) >999)
            {
                CurrentValue= QDesign.Substring(X_YTDTAR_DOLLARS_A.Value, 3, 4);
            }
            else if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) > 99)
            {
                CurrentValue= QDesign.Substring(X_YTDTAR_DOLLARS_A.Value, 4, 3);
            }
            else if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) > 9)
            {
                CurrentValue= QDesign.Substring(X_YTDTAR_DOLLARS_A.Value, 5, 2);
            }
            else
            {
                CurrentValue= QDesign.Substring(X_YTDTAR_DOLLARS_A.Value, 6, 1);
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
    private DCharacter X_CEIREQ_DOLLARS_CHAR = new DCharacter("X_CEIREQ_DOLLARS_CHAR", 7);
    private void X_CEIREQ_DOLLARS_CHAR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.RightJustify(X_CEIREQ_DOLLARS_B.Value);


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
    private DCharacter X_CEIREQ_PRT_DOLLARS = new DCharacter("X_CEIREQ_PRT_DOLLARS", 8);
    private void X_CEIREQ_PRT_DOLLARS_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_CEIREQ_DOLLARS_CHAR.Value;
            }
            else
            {
                CurrentValue= QDesign.Substring(X_CEIREQ_DOLLARS_CHAR.Value, 1, 4) + "," + QDesign.Substring(X_CEIREQ_DOLLARS_CHAR.Value, 5, 3);
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
    private DCharacter X_CEIREQ_PRT_CENTS = new DCharacter("X_CEIREQ_PRT_CENTS", 2);
    private void X_CEIREQ_PRT_CENTS_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_CEIREQ_CENTS.Value, 2);


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
    private DCharacter X_CEITAR_DOLLARS_CHAR = new DCharacter("X_CEITAR_DOLLARS_CHAR", 7);
    private void X_CEITAR_DOLLARS_CHAR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.RightJustify(X_CEITAR_DOLLARS_B.Value);


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
    private DCharacter X_CEITAR_PRT_DOLLARS = new DCharacter("X_CEITAR_PRT_DOLLARS", 8);
    private void X_CEITAR_PRT_DOLLARS_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_CEITAR_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_CEITAR_DOLLARS_CHAR.Value;
            }
            else
            {
                CurrentValue= QDesign.Substring(X_CEITAR_DOLLARS_CHAR.Value, 1, 4) + "," + QDesign.Substring(X_CEITAR_DOLLARS_CHAR.Value, 5, 3);
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
    private DCharacter X_CEITAR_PRT_CENTS = new DCharacter("X_CEITAR_PRT_CENTS", 2);
    private void X_CEITAR_PRT_CENTS_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_CEITAR_CENTS.Value, 2);


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
    private DCharacter X_YTDREQ_DOLLARS_CHAR = new DCharacter("X_YTDREQ_DOLLARS_CHAR", 7);
    private void X_YTDREQ_DOLLARS_CHAR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.RightJustify(X_YTDREQ_DOLLARS_B.Value);


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
    private DCharacter X_YTDREQ_PRT_DOLLARS = new DCharacter("X_YTDREQ_PRT_DOLLARS", 8);
    private void X_YTDREQ_PRT_DOLLARS_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_YTDREQ_DOLLARS_CHAR.Value;
            }
            else
            {
                CurrentValue= QDesign.Substring(X_YTDREQ_DOLLARS_CHAR.Value, 1, 4) + "," + QDesign.Substring(X_YTDREQ_DOLLARS_CHAR.Value, 5, 3);
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
    private DCharacter X_YTDREQ_PRT_CENTS = new DCharacter("X_YTDREQ_PRT_CENTS", 2);
    private void X_YTDREQ_PRT_CENTS_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_YTDREQ_CENTS.Value, 2);


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
    private DCharacter X_YTDTAR_DOLLARS_CHAR = new DCharacter("X_YTDTAR_DOLLARS_CHAR", 7);
    private void X_YTDTAR_DOLLARS_CHAR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.RightJustify(X_YTDTAR_DOLLARS_B.Value);


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
    private DCharacter X_YTDTAR_PRT_DOLLARS = new DCharacter("X_YTDTAR_PRT_DOLLARS", 8);
    private void X_YTDTAR_PRT_DOLLARS_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_YTDTAR_DOLLARS_CHAR.Value;
            }
            else
            {
                CurrentValue= QDesign.Substring(X_YTDTAR_DOLLARS_CHAR.Value, 1, 4) + "," + QDesign.Substring(X_YTDTAR_DOLLARS_CHAR.Value, 5, 3);
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
    private DCharacter X_YTDTAR_PRT_CENTS = new DCharacter("X_YTDTAR_PRT_CENTS", 2);
    private void X_YTDTAR_PRT_CENTS_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(X_YTDTAR_CENTS.Value, 2);


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
    private DDecimal X_CEIREQ_CTR1 = new DDecimal("X_CEIREQ_CTR1", 1);
    private void X_CEIREQ_CTR1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) < 10)
            {
                CurrentValue = 21;
            }
            else if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) < 100)
            {
                CurrentValue = 42;
            }
            else if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) < 1000)
            {
                CurrentValue = 63;
            }
            else if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) < 10000)
            {
                CurrentValue = 84;
            }
            else if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) < 100000)
            {
                CurrentValue = 105;
            }
            else
            {
                CurrentValue = 126;
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
    private DDecimal X_CEITAR_CTR1 = new DDecimal("X_CEITAR_CTR1", 1);
    private void X_CEITAR_CTR1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_CEITAR_DOLLARS.Value) < 10)
            {
                CurrentValue = 21;
            }
            else if (QDesign.NULL(X_CEITAR_DOLLARS.Value) < 100)
            {
                CurrentValue = 42;
            }
            else if (QDesign.NULL(X_CEITAR_DOLLARS.Value) < 1000)
            {
                CurrentValue = 63;
            }
            else if (QDesign.NULL(X_CEITAR_DOLLARS.Value) < 10000)
            {
                CurrentValue = 84;
            }
            else if (QDesign.NULL(X_CEITAR_DOLLARS.Value) < 100000)
            {
                CurrentValue = 105;
            }
            else
            {
                CurrentValue = 126;
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
    private DDecimal X_YTDREQ_CTR1 = new DDecimal("X_YTDREQ_CTR1", 1);
    private void X_YTDREQ_CTR1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) < 10)
            {
                CurrentValue = 21;
            }
            else if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) < 100)
            {
                CurrentValue = 42;
            }
            else if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) < 1000)
            {
                CurrentValue = 63;
            }
            else if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) < 10000)
            {
                CurrentValue = 84;
            }
            else if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) < 100000)
            {
                CurrentValue = 105;
            }
            else
            {
                CurrentValue = 126;
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
    private DDecimal X_YTDTAR_CTR1 = new DDecimal("X_YTDTAR_CTR1", 1);
    private void X_YTDTAR_CTR1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) < 10)
            {
                CurrentValue = 21;
            }
            else if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) < 100)
            {
                CurrentValue = 42;
            }
            else if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) < 1000)
            {
                CurrentValue = 63;
            }
            else if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) < 10000)
            {
                CurrentValue = 84;
            }
            else if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) < 100000)
            {
                CurrentValue = 105;
            }
            else
            {
                CurrentValue = 126;
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
    private DDecimal X_CEIREQ_CTR2 = new DDecimal("X_CEIREQ_CTR2", 1);
    private void X_CEIREQ_CTR2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_CEIREQ_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_CEIREQ_CTR1.Value;
            }
            else
            {
                CurrentValue = X_CEIREQ_CTR1.Value + 14;
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
    private DDecimal X_CEITAR_CTR2 = new DDecimal("X_CEITAR_CTR2", 1);
    private void X_CEITAR_CTR2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_CEITAR_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_CEITAR_CTR1.Value;
            }
            else
            {
                CurrentValue = X_CEITAR_CTR1.Value + 14;
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
    private DDecimal X_YTDREQ_CTR2 = new DDecimal("X_YTDREQ_CTR2", 1);
    private void X_YTDREQ_CTR2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_YTDREQ_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_YTDREQ_CTR1.Value;
            }
            else
            {
                CurrentValue = X_YTDREQ_CTR1.Value + 14;
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
    private DDecimal X_YTDTAR_CTR2 = new DDecimal("X_YTDTAR_CTR2", 1);
    private void X_YTDTAR_CTR2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_YTDTAR_DOLLARS.Value) < 1000)
            {
                CurrentValue = X_YTDTAR_CTR1.Value;
            }
            else
            {
                CurrentValue = X_YTDTAR_CTR1.Value + 14;
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
    private SqlFileObject fleF020_UPDATE;


    #endregion


    #region "Standard Generated Procedures(U121_RUN_1_3)"


    #region "Automatic Item Initialization(U121_RUN_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:20 PM

    //#-----------------------------------------
    //# fleF020_UPDATE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:20 PM
    //#-----------------------------------------
    private void fleF020_UPDATE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("DOC_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_TARGET_REVENUE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_TARGET_REVENUE"));
            fleF020_UPDATE.set_SetValue("DOC_CEIREQ", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEIREQ"));
            fleF020_UPDATE.set_SetValue("DOC_YTDREQ", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDREQ"));
            fleF020_UPDATE.set_SetValue("DOC_CEITAR", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_CEITAR"));
            fleF020_UPDATE.set_SetValue("DOC_YTDTAR", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDTAR"));
            fleF020_UPDATE.set_SetValue("CEIREQ_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("CEIREQ_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDREQ_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("YTDREQ_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("CEITAR_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("CEITAR_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDTAR_PRT_FORMAT", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("YTDTAR_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("BILLING_VIA_PAPER_FLAG", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_PAPER_FLAG"));
            fleF020_UPDATE.set_SetValue("BILLING_VIA_DISKETTE_FLAG", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_DISKETTE_FLAG"));
            fleF020_UPDATE.set_SetValue("BILLING_VIA_WEB_TEST_FLAG", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_WEB_TEST_FLAG"));
            fleF020_UPDATE.set_SetValue("BILLING_VIA_WEB_LIVE_FLAG", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_WEB_LIVE_FLAG"));
            fleF020_UPDATE.set_SetValue("BILLING_VIA_RMA_DATA_ENTRY", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("BILLING_VIA_RMA_DATA_ENTRY"));
            fleF020_UPDATE.set_SetValue("DATE_START_RMA_DATA_ENTRY", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DATE_START_RMA_DATA_ENTRY"));
            fleF020_UPDATE.set_SetValue("DATE_START_DISKETTE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DATE_START_DISKETTE"));
            fleF020_UPDATE.set_SetValue("DATE_START_PAPER", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DATE_START_PAPER"));
            fleF020_UPDATE.set_SetValue("DATE_START_WEB_LIVE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DATE_START_WEB_LIVE"));
            fleF020_UPDATE.set_SetValue("DATE_START_WEB_TEST", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DATE_START_WEB_TEST"));
            fleF020_UPDATE.set_SetValue("LEAVE_DESCRIPTION", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("LEAVE_DESCRIPTION"));
            fleF020_UPDATE.set_SetValue("LEAVE_DATE_START", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("LEAVE_DATE_START"));
            fleF020_UPDATE.set_SetValue("LEAVE_DATE_END", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("LEAVE_DATE_END"));
            fleF020_UPDATE.set_SetValue("WEB_USER_REVENUE_ONLY_FLAG", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("WEB_USER_REVENUE_ONLY_FLAG"));
            fleF020_UPDATE.set_SetValue("MANAGER_FLAG", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("MANAGER_FLAG"));
            fleF020_UPDATE.set_SetValue("CHAIR_FLAG", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("CHAIR_FLAG"));
            fleF020_UPDATE.set_SetValue("ABE_USER_FLAG", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("ABE_USER_FLAG"));
            fleF020_UPDATE.set_SetValue("CPSO_NBR", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("CPSO_NBR"));
            fleF020_UPDATE.set_SetValue("CMPA_NBR", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("CMPA_NBR"));
            fleF020_UPDATE.set_SetValue("OMA_NBR", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("OMA_NBR"));
            fleF020_UPDATE.set_SetValue("CFPC_NBR", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("CFPC_NBR"));
            fleF020_UPDATE.set_SetValue("RCPSC_NBR", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("RCPSC_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_MED_PROF_CORP", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("DOC_MED_PROF_CORP"));
            fleF020_UPDATE.set_SetValue("MCMASTER_EMPLOYEE_ID", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("MCMASTER_EMPLOYEE_ID"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_EFF_DATE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_SPEC_CD_EFF_DATE"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_2_EFF_DATE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_SPEC_CD_2_EFF_DATE"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_3_EFF_DATE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_SPEC_CD_3_EFF_DATE"));
            fleF020_UPDATE.set_SetValue("FACTOR_GST_INCOME_REG", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("FACTOR_GST_INCOME_REG"));
            fleF020_UPDATE.set_SetValue("FACTOR_GST_INCOME_MISC", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("FACTOR_GST_INCOME_MISC"));
            fleF020_UPDATE.set_SetValue("YELLOW_PAGES_FLAG", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("YELLOW_PAGES_FLAG"));
            fleF020_UPDATE.set_SetValue("REPLACED_BY_DOC_NBR", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("REPLACED_BY_DOC_NBR"));
            fleF020_UPDATE.set_SetValue("PRIOR_DOC_NBR", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("PRIOR_DOC_NBR"));
            fleF020_UPDATE.set_SetValue("COP_NBR", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("COP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_FLAG_PRIMARY", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("DOC_FLAG_PRIMARY"));
            fleF020_UPDATE.set_SetValue("HAS_VALID_CURRENT_PAYROLL_RECORD", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("HAS_VALID_CURRENT_PAYROLL_RECORD"));
            fleF020_UPDATE.set_SetValue("PAY_THIS_DOCTOR_OHIP_PREMIUM", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("PAY_THIS_DOCTOR_OHIP_PREMIUM"));
            fleF020_UPDATE.set_SetValue("DOC_FISCAL_YR_START_MONTH", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_FISCAL_YR_START_MONTH"));
            fleF020_UPDATE.set_SetValue("CASH_FLOW_FLAG", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("CASH_FLOW_FLAG"));
            fleF020_UPDATE.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(U121_RUN_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:17 PM

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
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleF020_UPDATE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U121_RUN_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:17 PM

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
            fleF020_DOCTOR_EXTRA.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U121_RUN_1_3)"


    public void Run()
    {

        try
        {
            Request("RUN_1_3");

            while (fleF020_DOCTOR_EXTRA.QTPForMissing())
            {
                // --> GET F020_DOCTOR_EXTRA <--

                fleF020_DOCTOR_EXTRA.GetData();
                // --> End GET F020_DOCTOR_EXTRA <--


                if (Transaction())
                {

                    fleF020_DOCTOR_EXTRA.set_SetValue("CEIREQ_PRT_FORMAT", QDesign.ASCII(X_CEIREQ_CTR2.Value, 3) + QDesign.RTrim(QDesign.LeftJustify(X_CEIREQ_PRT_DOLLARS.Value)) + X_PERIOD.Value + X_CEIREQ_PRT_CENTS.Value);


                    fleF020_DOCTOR_EXTRA.set_SetValue("CEITAR_PRT_FORMAT", QDesign.ASCII(X_CEITAR_CTR2.Value, 3) + QDesign.RTrim(QDesign.LeftJustify(X_CEITAR_PRT_DOLLARS.Value)) + X_PERIOD.Value + X_CEITAR_PRT_CENTS.Value);


                    fleF020_DOCTOR_EXTRA.set_SetValue("YTDREQ_PRT_FORMAT", QDesign.ASCII(X_YTDREQ_CTR2.Value, 3) + QDesign.RTrim(QDesign.LeftJustify(X_YTDREQ_PRT_DOLLARS.Value)) + X_PERIOD.Value + X_YTDREQ_PRT_CENTS.Value);


                    fleF020_DOCTOR_EXTRA.set_SetValue("YTDTAR_PRT_FORMAT", QDesign.ASCII(X_YTDTAR_CTR2.Value, 3) + QDesign.RTrim(QDesign.LeftJustify(X_YTDTAR_PRT_DOLLARS.Value)) + X_PERIOD.Value + X_YTDTAR_PRT_CENTS.Value);

                    fleF020_DOCTOR_EXTRA.OutPut(OutPutType.Update);

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
            EndRequest("RUN_1_3");

        }

    }







    #endregion


}
//RUN_1_3




