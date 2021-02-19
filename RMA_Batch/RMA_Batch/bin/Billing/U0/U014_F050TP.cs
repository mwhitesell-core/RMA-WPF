
#region "Screen Comments"

// #> PROGRAM-ID.     u014_f050tp.qts
// ((C)) Dyad Technologies
// PURPOSE: transfer the current status of the f050tp revenue files
// to the appropriate history files to keep a snapshot of the
// revenue at the end of the month.
// MODIFICATION HISTORY
// DATE     WHO      DESCRIPTION
// 2000/jan/10  B.E. - original
// 2000/jan/18  B.E. - constants master PED has yyyymmdd but each dd
// is different for each clinic and we want all
// clinic data to be easily accessible for the
// same period. Therefore the `dd` portion of the
// clinic`s PED is ignored and `01` is used. For
// the 13th month the `update` action on the output
// statement is will 12th monthend values.
// 2000/apr/27 B.E.      - changed output on f050tp-history to have separate
// output statements for add and update
// 2000/jun/18 B.E. - for clinic 61-65 the passed parameter is 60 so 
// the match for clinic-nbr must be only on 1st digitS
// 2000/jul/08 B.E. - corrected bug on item statuement for output to file `f050tp-hist-update`
// where the items statement for incorrectly set for file `f050tp-hist-add` 
// 2003/jun/15 M.C. - corrected bug on MTD item statement for output to file `f050-hist-update`
// 2007/apr/10 M.C. - for clinic 71-75 the passed parameter is 70 so 
// the match for clinic-nbr must be only on 1st digit
// 2009/sep/29 M.C.      - correct the criteria for clinic 60 and clinic 70 when updating to
// f050tp history file via u014_f050tp subfile
// 2010/feb/10 MC1 - include clinic 66
// 2011/feb/28 MC2       - comment out set stacksize 10000, change from set lock file update
// to set lock record update, remove alias f050-hist-update on output update statement
// hopefully this clear out  the data conversion error for selected clinics even though
// the records were created properly.
// 2012/jul/09 MC3        - use PED of payroll system to select f050tp records
// rather than PED of clinic
// - modify to use yearend PED as yyyy0630 if ep-nbr = yyyy13
// 2012/aug/23 MC4       - undo MC3 - cannot use ep-nbr of the payroll system since this program will only execute
// after the payroll run which will increase ep-nbr by 1 at the end of the run
// - assuming yearend ped should be the last day of June ie yyyy0630 and 12 monthend ped
// should not = yyyymm30 (usually third week of the month)
// 2011/02/28 - MC2
// set stacksize 10000
// 2011/02/28 -  end
// 2011/02/28 - MC2
// set lock file update
// 2011/02/28 - end


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U014_F050TP : BaseClassControl
{

    private U014_F050TP m_U014_F050TP;

    public U014_F050TP(string Name, int Level) : base(Name, Level)
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
        X_SELECTED_CLINIC = new CoreDecimal("X_SELECTED_CLINIC", 2, this, ResetTypes.ResetAtStartup, (Prompt(1)));
        X_SELECTED_CLINIC_ALPHA = new CoreCharacter("X_SELECTED_CLINIC_ALPHA", 2, this, ResetTypes.ResetAtStartup, Common.cEmptyString);


    }

    public U014_F050TP(string Name, int Level, bool Request) : base(Name, Level, Request)
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
        X_SELECTED_CLINIC = new CoreDecimal("X_SELECTED_CLINIC", 2, this, ResetTypes.ResetAtStartup, (Prompt(1)));
        X_SELECTED_CLINIC_ALPHA = new CoreCharacter("X_SELECTED_CLINIC_ALPHA", 2, this, ResetTypes.ResetAtStartup, Common.cEmptyString);


    }

    public override void Dispose()
    {
        if ((m_U014_F050TP != null))
        {
            m_U014_F050TP.CloseTransactionObjects();
            m_U014_F050TP = null;
        }
    }

    public U014_F050TP GetU014_F050TP(int Level)
    {
        if (m_U014_F050TP == null)
        {
            m_U014_F050TP = new U014_F050TP("U014_F050TP", Level);
        }
        else
        {
            m_U014_F050TP.ResetValues();
        }
        return m_U014_F050TP;
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
    protected CoreDecimal X_SELECTED_CLINIC;

    protected CoreCharacter X_SELECTED_CLINIC_ALPHA;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U014_F050TP_COSTING1_GET_REC_7_1 COSTING1_GET_REC_7_1 = new U014_F050TP_COSTING1_GET_REC_7_1(Name, Level);
            COSTING1_GET_REC_7_1.Run();
            COSTING1_GET_REC_7_1.Dispose();
            COSTING1_GET_REC_7_1 = null;

            U014_F050TP_U014_TRANSFER_F050TP_TO_F050_HISTTP_2 U014_TRANSFER_F050TP_TO_F050_HISTTP_2 = new U014_F050TP_U014_TRANSFER_F050TP_TO_F050_HISTTP_2(Name, Level);
            U014_TRANSFER_F050TP_TO_F050_HISTTP_2.Run();
            U014_TRANSFER_F050TP_TO_F050_HISTTP_2.Dispose();
            U014_TRANSFER_F050TP_TO_F050_HISTTP_2 = null;

            U014_F050TP_U014_TRANSFER_F050TP_TO_F050TP_HIST_3 U014_TRANSFER_F050TP_TO_F050TP_HIST_3 = new U014_F050TP_U014_TRANSFER_F050TP_TO_F050TP_HIST_3(Name, Level);
            U014_TRANSFER_F050TP_TO_F050TP_HIST_3.Run();
            U014_TRANSFER_F050TP_TO_F050TP_HIST_3.Dispose();
            U014_TRANSFER_F050TP_TO_F050TP_HIST_3 = null;

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



public class U014_F050TP_COSTING1_GET_REC_7_1 : U014_F050TP
{

    public U014_F050TP_COSTING1_GET_REC_7_1(string Name, int Level) : base(Name, Level, true)
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
        X_SELECTED_CLINIC = new CoreDecimal("X_SELECTED_CLINIC", 2, this, ResetTypes.ResetAtStartup);
        X_SELECTED_CLINIC_ALPHA = new CoreCharacter("X_SELECTED_CLINIC_ALPHA", 2, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        fleCONSTANTS_MSTR_REC_7 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F090_CONSTANTS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(U014_F050TP_COSTING1_GET_REC_7_1)"

    protected CoreDate W_CURRENT_FISCAL_START_YYMMDD;
    protected CoreDate W_CURRENT_FISCAL_END_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_CUTOFF_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_PED;
    protected CoreDecimal W_CURRENT_COSTING_PED_YYMM;
    protected CoreDate W_PREVIOUS_FISCAL_START_YYMMDD;
    protected CoreDate W_PREVIOUS_FISCAL_END_YYMMDD;
    protected CoreDecimal W_EP_YR;
    protected CoreDecimal X_SELECTED_CLINIC;
    protected CoreCharacter X_SELECTED_CLINIC_ALPHA;
    private SqlFileObject fleCONSTANTS_MSTR_REC_7;


    #endregion


    #region "Standard Generated Procedures(U014_F050TP_COSTING1_GET_REC_7_1)"


    #region "Automatic Item Initialization(U014_F050TP_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U014_F050TP_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/12/2017 9:35:22 AM

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


    #region "FILE Management Procedures(U014_F050TP_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/12/2017 9:35:22 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_F050TP_COSTING1_GET_REC_7_1)"


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
                    X_SELECTED_CLINIC_ALPHA.Value = QDesign.ASCII(X_SELECTED_CLINIC.Value, 2);

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



public class U014_F050TP_U014_TRANSFER_F050TP_TO_F050_HISTTP_2 : U014_F050TP
{

    public U014_F050TP_U014_TRANSFER_F050TP_TO_F050_HISTTP_2(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050TP_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F090_CONSTANTS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU014_F050TP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U014_F050TP", "", false, false, false, 0,     	"m_trnTRANS_UPDATE", FileType.SubFile); 

        PED_DD.GetValue += PED_DD_GetValue;
        X_SELECTED_CLINIC_1.GetValue += X_SELECTED_CLINIC_1_GetValue;
        X_DOCREVTP_CLINIC_1.GetValue += X_DOCREVTP_CLINIC_1_GetValue;
        X_ICONST_DATE_PERIOD_END.GetValue += X_ICONST_DATE_PERIOD_END_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U014_F050TP_U014_TRANSFER_F050TP_TO_F050_HISTTP_2)"

    private SqlFileObject fleF050TP_DOC_REVENUE_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    private DDecimal PED_DD = new DDecimal("PED_DD", 2);
    private void PED_DD_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleICONST_MSTR_REC.GetNumericDateValue("ICONST_DATE_PERIOD_END"), 100);


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
    private DDecimal X_SELECTED_CLINIC_1 = new DDecimal("X_SELECTED_CLINIC_1", 6);
    private void X_SELECTED_CLINIC_1_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(X_SELECTED_CLINIC.Value, 2), 1, 1));


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
    private DDecimal X_DOCREVTP_CLINIC_1 = new DDecimal("X_DOCREVTP_CLINIC_1", 6);
    private void X_DOCREVTP_CLINIC_1_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2), 1, 1));


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

    private bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR")) == QDesign.NULL(X_SELECTED_CLINIC.Value) | (QDesign.NULL(X_SELECTED_CLINIC.Value) == 60 & (fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR") >= 61 & fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR") <= 66)) | (QDesign.NULL(X_SELECTED_CLINIC.Value) == 70 & (fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR") >= 71 & fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR") <= 75)))
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

    private DDecimal X_ICONST_DATE_PERIOD_END = new DDecimal("X_ICONST_DATE_PERIOD_END");
    private void X_ICONST_DATE_PERIOD_END_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(PED_DD.Value) != 30)
            {
                CurrentValue = QDesign.NConvert(QDesign.ASCII((fleICONST_MSTR_REC.GetNumericDateValue("ICONST_DATE_PERIOD_END") / 100), 6) + "01");
            }
            else
            {
                CurrentValue = fleICONST_MSTR_REC.GetNumericDateValue("ICONST_DATE_PERIOD_END");
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





    private SqlFileObject fleU014_F050TP;


    #endregion


    #region "Standard Generated Procedures(U014_F050TP_U014_TRANSFER_F050TP_TO_F050_HISTTP_2)"


    #region "Automatic Item Initialization(U014_F050TP_U014_TRANSFER_F050TP_TO_F050_HISTTP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U014_F050TP_U014_TRANSFER_F050TP_TO_F050_HISTTP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/12/2017 9:35:23 AM

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
        fleF050TP_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleU014_F050TP.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U014_F050TP_U014_TRANSFER_F050TP_TO_F050_HISTTP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/12/2017 9:35:23 AM

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
            fleF050TP_DOC_REVENUE_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleU014_F050TP.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_F050TP_U014_TRANSFER_F050TP_TO_F050_HISTTP_2)"


    public void Run()
    {

        try
        {
            Request("U014_TRANSFER_F050TP_TO_F050_HISTTP_2");

            while (fleF050TP_DOC_REVENUE_MSTR.QTPForMissing())
            {
                // --> GET F050TP_DOC_REVENUE_MSTR <--

                fleF050TP_DOC_REVENUE_MSTR.GetData();
                // --> End GET F050TP_DOC_REVENUE_MSTR <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append((X_SELECTED_CLINIC.Value));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--


                    if (Transaction())
                    {

                        if (SelectIf())
                        {





                            SubFile(ref m_trnTRANS_UPDATE, "U014_F050TP", SubFileType.Keep, X_ICONST_DATE_PERIOD_END, fleF050TP_DOC_REVENUE_MSTR);
                           


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
            EndRequest("U014_TRANSFER_F050TP_TO_F050_HISTTP_2");

        }

    }




    #endregion


}
//U014_TRANSFER_F050TP_TO_F050_HISTTP_2



public class U014_F050TP_U014_TRANSFER_F050TP_TO_F050TP_HIST_3 : U014_F050TP
{

    public U014_F050TP_U014_TRANSFER_F050TP_TO_F050TP_HIST_3(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU014_F050TP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U014_F050TP", "", false, false, false, 0,     	"m_trnTRANS_UPDATE", FileType.SubFile); 
        fleF050TP_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF050TP_HIST_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR_HISTORY", "F050TP_HIST_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF050TP_DOC_REVENUE_MSTR_HISTORY.SetItemFinals += fleF050TP_DOC_REVENUE_MSTR_HISTORY_SetItemFinals;
        fleF050TP_HIST_ADD.InitializeItems += fleF050TP_HIST_ADD_InitializeItems;
        fleF050TP_HIST_ADD.InitializeItems += fleF050TP_HIST_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U014_F050TP_U014_TRANSFER_F050TP_TO_F050TP_HIST_3)"

    private SqlFileObject fleU014_F050TP;
    private SqlFileObject fleF050TP_DOC_REVENUE_MSTR_HISTORY;

    private void fleF050TP_DOC_REVENUE_MSTR_HISTORY_SetItemFinals()
    {

        try
        {
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_TECH_AMT_BILLED", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_TECH_AMT_BILLED" + (2).ToString()));
            // TODO: DOCREVTP_IN_TECH_AMT_BILLED occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_TECH_AMT_ADJUSTS", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_TECH_AMT_ADJUSTS" + (2).ToString()));
            // TODO: DOCREVTP_IN_TECH_AMT_ADJUSTS occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_TECH_NBR_SVC", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_TECH_NBR_SVC" + (2).ToString()));
            // TODO: DOCREVTP_IN_TECH_NBR_SVC occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_PROF_AMT_BILLED", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_PROF_AMT_BILLED" + (2).ToString()));
            // TODO: DOCREVTP_IN_PROF_AMT_BILLED occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_PROF_AMT_ADJUSTS", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_PROF_AMT_ADJUSTS" + (2).ToString()));
            // TODO: DOCREVTP_IN_PROF_AMT_ADJUSTS occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_IN_PROF_NBR_SVC", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_PROF_NBR_SVC" + (2).ToString()));
            // TODO: DOCREVTP_IN_PROF_NBR_SVC occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_TECH_AMT_BILLED", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_BILLED" + (2).ToString()));
            // TODO: DOCREVTP_OUT_TECH_AMT_BILLED occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS" + (2).ToString()));
            // TODO: DOCREVTP_OUT_TECH_AMT_ADJUSTS occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_TECH_NBR_SVC", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_TECH_NBR_SVC" + (2).ToString()));
            // TODO: DOCREVTP_OUT_TECH_NBR_SVC occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_PROF_AMT_BILLED", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_BILLED" + (2).ToString()));
            // TODO: DOCREVTP_OUT_PROF_AMT_BILLED occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS" + (2).ToString()));
            // TODO: DOCREVTP_OUT_PROF_AMT_ADJUSTS occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREVTP_OUT_PROF_NBR_SVC", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_PROF_NBR_SVC" + (2).ToString()));
            // TODO: DOCREVTP_OUT_PROF_NBR_SVC occurs 2.  Manual steps may be required.


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

    private SqlFileObject fleF050TP_HIST_ADD;

    private void fleF050TP_HIST_ADD_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF050TP_HIST_ADD.set_SetValue("EP_YR", true, W_EP_YR.Value);
            if (!Fixed)
                fleF050TP_HIST_ADD.set_SetValue("ICONST_DATE_PERIOD_END", true, fleU014_F050TP.GetNumericDateValue("X_ICONST_DATE_PERIOD_END"));


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


    #region "Standard Generated Procedures(U014_F050TP_U014_TRANSFER_F050TP_TO_F050TP_HIST_3)"


    #region "Automatic Item Initialization(U014_F050TP_U014_TRANSFER_F050TP_TO_F050TP_HIST_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/12/2017 9:35:23 AM

    //#-----------------------------------------
    //# fleF050TP_HIST_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 10/12/2017 9:35:23 AM
    //#-----------------------------------------
    private void fleF050TP_HIST_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_CLINIC_NBR", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_CLINIC_NBR"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_AGENT_CD", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_AGENT_CD"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_LOC_CD", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_LOC_CD"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OMA_CODE", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_CODE"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OMA_SUFFIX", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_SUFFIX"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_DOC_NBR", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_DOC_NBR"));
            fleF050TP_HIST_ADD.set_SetValue("EP_YR", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("EP_YR"));
            fleF050TP_HIST_ADD.set_SetValue("ICONST_DATE_PERIOD_END", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("ICONST_DATE_PERIOD_END"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_TECH_AMT_BILLED1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_TECH_AMT_BILLED1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_TECH_AMT_BILLED2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_TECH_AMT_BILLED2"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_TECH_AMT_ADJUSTS1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_TECH_AMT_ADJUSTS1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_TECH_AMT_ADJUSTS2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_TECH_AMT_ADJUSTS2"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_TECH_NBR_SVC1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_TECH_NBR_SVC1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_TECH_NBR_SVC2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_TECH_NBR_SVC2"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_PROF_AMT_BILLED1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_PROF_AMT_BILLED1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_PROF_AMT_BILLED2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_PROF_AMT_BILLED2"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_PROF_AMT_ADJUSTS1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_PROF_AMT_ADJUSTS1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_PROF_AMT_ADJUSTS2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_PROF_AMT_ADJUSTS2"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_PROF_NBR_SVC1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_PROF_NBR_SVC1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_IN_PROF_NBR_SVC2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_IN_PROF_NBR_SVC2"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_TECH_AMT_BILLED1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_BILLED1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_TECH_AMT_BILLED2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_BILLED2"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS2"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_TECH_NBR_SVC1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_TECH_NBR_SVC1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_TECH_NBR_SVC2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_TECH_NBR_SVC2"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_PROF_AMT_BILLED1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_BILLED1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_PROF_AMT_BILLED2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_BILLED2"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS2"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_PROF_NBR_SVC1", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_PROF_NBR_SVC1"));
            fleF050TP_HIST_ADD.set_SetValue("DOCREVTP_OUT_PROF_NBR_SVC2", !Fixed, fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_OUT_PROF_NBR_SVC2"));

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


    #region "Transaction Management Procedures(U014_F050TP_U014_TRANSFER_F050TP_TO_F050TP_HIST_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/12/2017 9:35:23 AM

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
        fleU014_F050TP.Transaction = m_trnTRANS_UPDATE;
        fleF050TP_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleF050TP_HIST_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U014_F050TP_U014_TRANSFER_F050TP_TO_F050TP_HIST_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/12/2017 9:35:23 AM

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
            fleU014_F050TP.Dispose();
            fleF050TP_DOC_REVENUE_MSTR_HISTORY.Dispose();
            fleF050TP_HIST_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_F050TP_U014_TRANSFER_F050TP_TO_F050TP_HIST_3)"


    public void Run()
    {

        try
        {
            Request("U014_TRANSFER_F050TP_TO_F050TP_HIST_3");

            while (fleU014_F050TP.QTPForMissing())
            {
                // --> GET U014_F050TP <--

                fleU014_F050TP.GetData();
                // --> End GET U014_F050TP <--

                while (fleF050TP_DOC_REVENUE_MSTR_HISTORY.QTPForMissing("1"))
                {
                    // --> GET F050TP_DOC_REVENUE_MSTR_HISTORY <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR_HISTORY.ElementOwner("EP_YR")).Append(" = ");
                    m_strWhere.Append((W_EP_YR.Value));
                    m_strWhere.Append(GetWhereClauseString(fleF050TP_DOC_REVENUE_MSTR_HISTORY.ElementOwner("ICONST_DATE_PERIOD_END"), "=", fleU014_F050TP.GetNumericDateValue("X_ICONST_DATE_PERIOD_END"), false));
                    m_strWhere.Append(" AND ").Append(fleF050TP_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREVTP_CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(0, 2)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY
                    m_strWhere.Append(" AND ").Append(fleF050TP_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREVTP_AGENT_CD")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(2, 1)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY
                    m_strWhere.Append(" AND ").Append(fleF050TP_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREVTP_LOC_CD")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(3, 4)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY
                    m_strWhere.Append(" AND ").Append(fleF050TP_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREVTP_OMA_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(7, 4)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY
                    m_strWhere.Append(" AND ").Append(fleF050TP_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREVTP_OMA_SUFFIX")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(11, 1)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY
                    m_strWhere.Append(" AND ").Append(fleF050TP_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREVTP_DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(12, 3)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY

                    fleF050TP_DOC_REVENUE_MSTR_HISTORY.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F050TP_DOC_REVENUE_MSTR_HISTORY <--


                    if (Transaction())
                    {

                        fleF050TP_HIST_ADD.OutPut(OutPutType.Add, null, !fleF050TP_DOC_REVENUE_MSTR_HISTORY.Exists());
                       


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_IN_TECH_AMT_BILLED", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_TECH_AMT_BILLED"));


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_IN_TECH_AMT_ADJUSTS", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_TECH_AMT_ADJUSTS"));


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_IN_TECH_NBR_SVC", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_TECH_NBR_SVC"));


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_IN_PROF_AMT_BILLED", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_PROF_AMT_BILLED"));


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_IN_PROF_AMT_ADJUSTS", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_PROF_AMT_ADJUSTS"));


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_IN_PROF_NBR_SVC", fleU014_F050TP.GetDecimalValue("DOCREVTP_IN_PROF_NBR_SVC"));


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_OUT_TECH_AMT_BILLED", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_BILLED"));


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_OUT_TECH_AMT_ADJUSTS", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS"));


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_OUT_TECH_NBR_SVC", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_TECH_NBR_SVC"));


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_OUT_PROF_AMT_BILLED", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_BILLED"));


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_OUT_PROF_AMT_ADJUSTS", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS"));


                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR_HISTORY, "DOCREVTP_OUT_PROF_NBR_SVC", fleU014_F050TP.GetDecimalValue("DOCREVTP_OUT_PROF_NBR_SVC"));


                        fleF050TP_DOC_REVENUE_MSTR_HISTORY.OutPut(OutPutType.Update, null, fleF050TP_DOC_REVENUE_MSTR_HISTORY.Exists());
                       

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
            EndRequest("U014_TRANSFER_F050TP_TO_F050TP_HIST_3");

        }

    }




    #endregion


}
//U014_TRANSFER_F050TP_TO_F050TP_HIST_3




