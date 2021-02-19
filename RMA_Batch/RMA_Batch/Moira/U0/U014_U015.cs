
#region "Screen Comments"

// #> PROGRAM-ID.     u014_u015.qts
// ((C)) Dyad Infosys Ltd  
// PURPOSE: transfer the current status of the f050 revenue files & f050tp files
// to the appropriate history files to keep a snapshot of the
// revenue at the end of the month.  Reset MTD to zero in f050/f050tp & f051 files
// MODIFICATION HISTORY
// DATE     WHO      DESCRIPTION
// 2015/Jun/22  M.C. - original
// - clone/combine from u014_f050.qts, u014_f050tp.qts &
// u015.qts & u015tp.qts


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U014_U015 : BaseClassControl
{

    private U014_U015 m_U014_U015;

    public U014_U015(string Name, int Level)
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
        X_SELECT_MONTHEND = new CoreCharacter("X_SELECT_MONTHEND", 1, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());


    }

    public U014_U015(string Name, int Level, bool Request)
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
        X_SELECT_MONTHEND = new CoreCharacter("X_SELECT_MONTHEND", 1, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());


    }

    public override void Dispose()
    {
        if ((m_U014_U015 != null))
        {
            m_U014_U015.CloseTransactionObjects();
            m_U014_U015 = null;
        }
    }

    public U014_U015 GetU014_U015(int Level)
    {
        if (m_U014_U015 == null)
        {
            m_U014_U015 = new U014_U015("U014_U015", Level);
        }
        else
        {
            m_U014_U015.ResetValues();
        }
        return m_U014_U015;
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

    protected CoreCharacter X_SELECT_MONTHEND;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U014_U015_COSTING1_GET_REC_7_1 COSTING1_GET_REC_7_1 = new U014_U015_COSTING1_GET_REC_7_1(Name, Level);
            COSTING1_GET_REC_7_1.Run();
            COSTING1_GET_REC_7_1.Dispose();
            COSTING1_GET_REC_7_1 = null;

            U014_U015_U014_EXTRACT_F050_2 U014_EXTRACT_F050_2 = new U014_U015_U014_EXTRACT_F050_2(Name, Level);
            U014_EXTRACT_F050_2.Run();
            U014_EXTRACT_F050_2.Dispose();
            U014_EXTRACT_F050_2 = null;

            U014_U015_U014_TRANSFER_F050_TO_F050HIST_3 U014_TRANSFER_F050_TO_F050HIST_3 = new U014_U015_U014_TRANSFER_F050_TO_F050HIST_3(Name, Level);
            U014_TRANSFER_F050_TO_F050HIST_3.Run();
            U014_TRANSFER_F050_TO_F050HIST_3.Dispose();
            U014_TRANSFER_F050_TO_F050HIST_3 = null;

            U014_U015_U014_EXTRACT_F050TP_4 U014_EXTRACT_F050TP_4 = new U014_U015_U014_EXTRACT_F050TP_4(Name, Level);
            U014_EXTRACT_F050TP_4.Run();
            U014_EXTRACT_F050TP_4.Dispose();
            U014_EXTRACT_F050TP_4 = null;

            U014_U015_U014_TRANSFER_F050TP_TO_F050TPHIST_5 U014_TRANSFER_F050TP_TO_F050TPHIST_5 = new U014_U015_U014_TRANSFER_F050TP_TO_F050TPHIST_5(Name, Level);
            U014_TRANSFER_F050TP_TO_F050TPHIST_5.Run();
            U014_TRANSFER_F050TP_TO_F050TPHIST_5.Dispose();
            U014_TRANSFER_F050TP_TO_F050TPHIST_5 = null;

            U014_U015_UPDATE_F050_6 UPDATE_F050_6 = new U014_U015_UPDATE_F050_6(Name, Level);
            UPDATE_F050_6.Run();
            UPDATE_F050_6.Dispose();
            UPDATE_F050_6 = null;

            U014_U015_UPDATE_F050TP_7 UPDATE_F050TP_7 = new U014_U015_UPDATE_F050TP_7(Name, Level);
            UPDATE_F050TP_7.Run();
            UPDATE_F050TP_7.Dispose();
            UPDATE_F050TP_7 = null;

            U014_U015_UPDATE_F051_8 UPDATE_F051_8 = new U014_U015_UPDATE_F051_8(Name, Level);
            UPDATE_F051_8.Run();
            UPDATE_F051_8.Dispose();
            UPDATE_F051_8 = null;

            U014_U015_UPDATE_F051TP_9 UPDATE_F051TP_9 = new U014_U015_UPDATE_F051TP_9(Name, Level);
            UPDATE_F051TP_9.Run();
            UPDATE_F051TP_9.Dispose();
            UPDATE_F051TP_9 = null;

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



public class U014_U015_COSTING1_GET_REC_7_1 : U014_U015
{

    public U014_U015_COSTING1_GET_REC_7_1(string Name, int Level)
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
        X_SELECT_MONTHEND = new CoreCharacter("X_SELECT_MONTHEND", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        fleCONSTANTS_MSTR_REC_7 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F090_CONSTANTS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(U014_U015_COSTING1_GET_REC_7_1)"

    protected CoreDate W_CURRENT_FISCAL_START_YYMMDD;
    protected CoreDate W_CURRENT_FISCAL_END_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_CUTOFF_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_PED;
    protected CoreDecimal W_CURRENT_COSTING_PED_YYMM;
    protected CoreDate W_PREVIOUS_FISCAL_START_YYMMDD;
    protected CoreDate W_PREVIOUS_FISCAL_END_YYMMDD;
    protected CoreDecimal W_EP_YR;
    protected CoreCharacter X_SELECT_MONTHEND;
    private SqlFileObject fleCONSTANTS_MSTR_REC_7;


    #endregion


    #region "Standard Generated Procedures(U014_U015_COSTING1_GET_REC_7_1)"


    #region "Automatic Item Initialization(U014_U015_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U014_U015_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:20 PM

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


    #region "FILE Management Procedures(U014_U015_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:20 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_U015_COSTING1_GET_REC_7_1)"


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



public class U014_U015_U014_EXTRACT_F050_2 : U014_U015
{

    public U014_U015_U014_EXTRACT_F050_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU014_F050 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U014_F050", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        PED_DD.GetValue += PED_DD_GetValue;
        X_ICONST_DATE_PERIOD_END.GetValue += X_ICONST_DATE_PERIOD_END_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U014_U015_U014_EXTRACT_F050_2)"

    private SqlFileObject fleF050_DOC_REVENUE_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_MONTHEND")) == QDesign.NULL(QDesign.NULL(X_SELECT_MONTHEND.Value)))
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













    private SqlFileObject fleU014_F050;


    #endregion


    #region "Standard Generated Procedures(U014_U015_U014_EXTRACT_F050_2)"


    #region "Automatic Item Initialization(U014_U015_U014_EXTRACT_F050_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U014_U015_U014_EXTRACT_F050_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:20 PM

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
        fleF050_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleU014_F050.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U014_U015_U014_EXTRACT_F050_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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
            fleF050_DOC_REVENUE_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleU014_F050.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_U015_U014_EXTRACT_F050_2)"


    public void Run()
    {

        try
        {
            Request("U014_EXTRACT_F050_2");

            while (fleF050_DOC_REVENUE_MSTR.QTPForMissing())
            {
                // --> GET F050_DOC_REVENUE_MSTR <--

                fleF050_DOC_REVENUE_MSTR.GetData();
                // --> End GET F050_DOC_REVENUE_MSTR <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2"))));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {













                            SubFile(ref m_trnTRANS_UPDATE, ref fleU014_F050, SubFileType.Keep, X_ICONST_DATE_PERIOD_END, fleF050_DOC_REVENUE_MSTR);
                            //Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREVTP_KEY)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY


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
            EndRequest("U014_EXTRACT_F050_2");

        }

    }




    #endregion


}
//U014_EXTRACT_F050_2



public class U014_U015_U014_TRANSFER_F050_TO_F050HIST_3 : U014_U015
{

    public U014_U015_U014_TRANSFER_F050_TO_F050HIST_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU014_F050 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U014_F050", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF050_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF050_HIST_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR_HISTORY", "F050_HIST_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF050_DOC_REVENUE_MSTR_HISTORY.SetItemFinals += fleF050_DOC_REVENUE_MSTR_HISTORY_SetItemFinals;
        fleF050_HIST_ADD.InitializeItems += fleF050_HIST_ADD_InitializeItems;
        fleF050_HIST_ADD.InitializeItems += fleF050_HIST_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U014_U015_U014_TRANSFER_F050_TO_F050HIST_3)"

    private SqlFileObject fleU014_F050;
    private SqlFileObject fleF050_DOC_REVENUE_MSTR_HISTORY;

    private void fleF050_DOC_REVENUE_MSTR_HISTORY_SetItemFinals()
    {

        try
        {
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_YTD_IN_REC", fleU014_F050.GetDecimalValue("DOCREV_YTD_IN_REC"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_YTD_IN_SVC", fleU014_F050.GetDecimalValue("DOCREV_YTD_IN_SVC"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_YTD_OUT_REC", fleU014_F050.GetDecimalValue("DOCREV_YTD_OUT_REC"));
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_YTD_OUT_SVC", fleU014_F050.GetDecimalValue("DOCREV_YTD_OUT_SVC"));


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

    private SqlFileObject fleF050_HIST_ADD;

    private void fleF050_HIST_ADD_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF050_HIST_ADD.set_SetValue("EP_YR", true, W_EP_YR.Value);
            if (!Fixed)
                fleF050_HIST_ADD.set_SetValue("ICONST_DATE_PERIOD_END", true, fleU014_F050.GetNumericDateValue("X_ICONST_DATE_PERIOD_END"));


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


    #region "Standard Generated Procedures(U014_U015_U014_TRANSFER_F050_TO_F050HIST_3)"


    #region "Automatic Item Initialization(U014_U015_U014_TRANSFER_F050_TO_F050HIST_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:24 PM

    //#-----------------------------------------
    //# fleF050_HIST_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:47:24 PM
    //#-----------------------------------------
    private void fleF050_HIST_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF050_HIST_ADD.set_SetValue("DOCREV_CLINIC_1_2", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_DEPT", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_DEPT"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_DOC_NBR", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_LOCATION", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_OMA_CODE", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_OMA_SUFF", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF"));
            fleF050_HIST_ADD.set_SetValue("EP_YR", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("EP_YR"));
            fleF050_HIST_ADD.set_SetValue("ICONST_DATE_PERIOD_END", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("ICONST_DATE_PERIOD_END"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_MTD_IN_REC", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_MTD_IN_REC"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_MTD_IN_SVC", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_MTD_IN_SVC"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_MTD_OUT_REC", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_MTD_OUT_REC"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_MTD_OUT_SVC", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_MTD_OUT_SVC"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_YTD_IN_REC", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_IN_REC"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_YTD_IN_SVC", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_IN_SVC"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_YTD_OUT_REC", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_OUT_REC"));
            fleF050_HIST_ADD.set_SetValue("DOCREV_YTD_OUT_SVC", !Fixed, fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_OUT_SVC"));

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


    #region "Transaction Management Procedures(U014_U015_U014_TRANSFER_F050_TO_F050HIST_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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
        fleU014_F050.Transaction = m_trnTRANS_UPDATE;
        fleF050_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleF050_HIST_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U014_U015_U014_TRANSFER_F050_TO_F050HIST_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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
            fleU014_F050.Dispose();
            fleF050_DOC_REVENUE_MSTR_HISTORY.Dispose();
            fleF050_HIST_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_U015_U014_TRANSFER_F050_TO_F050HIST_3)"


    public void Run()
    {

        try
        {
            Request("U014_TRANSFER_F050_TO_F050HIST_3");

            while (fleU014_F050.QTPForMissing())
            {
                // --> GET U014_F050 <--

                fleU014_F050.GetData();
                // --> End GET U014_F050 <--

                while (fleF050_DOC_REVENUE_MSTR_HISTORY.QTPForMissing("1"))
                {
                    // --> GET F050_DOC_REVENUE_MSTR_HISTORY <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("EP_YR")).Append(" = ");
                    m_strWhere.Append((W_EP_YR.Value));
                    m_strWhere.Append(GetWhereClauseString(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("ICONST_DATE_PERIOD_END"), "=", fleU014_F050.GetNumericDateValue("X_ICONST_DATE_PERIOD_END")));
                    m_strWhere.Append(" AND ").Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREV_CLINIC_1_2")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREV_DEPT")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(2, 2)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREV_DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(4, 3)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREV_LOCATION")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(7, 4)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREV_OMA_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(11, 4)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREV_OMA_SUFF")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(15, 1)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("DOCREV_ADJ_CD_SUB_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(16, 1)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY

                    fleF050_DOC_REVENUE_MSTR_HISTORY.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F050_DOC_REVENUE_MSTR_HISTORY <--


                    if (Transaction())
                    {








                        fleF050_HIST_ADD.OutPut(OutPutType.Add, null, !fleF050_DOC_REVENUE_MSTR_HISTORY.Exists());
                       

                        SubTotal(ref fleF050_DOC_REVENUE_MSTR_HISTORY, "DOCREV_MTD_IN_REC", fleU014_F050.GetDecimalValue("DOCREV_MTD_IN_REC"));


                        SubTotal(ref fleF050_DOC_REVENUE_MSTR_HISTORY, "DOCREV_MTD_IN_SVC", fleU014_F050.GetDecimalValue("DOCREV_MTD_IN_SVC"));


                        SubTotal(ref fleF050_DOC_REVENUE_MSTR_HISTORY, "DOCREV_MTD_OUT_REC", fleU014_F050.GetDecimalValue("DOCREV_MTD_OUT_REC"));


                        SubTotal(ref fleF050_DOC_REVENUE_MSTR_HISTORY, "DOCREV_MTD_OUT_SVC", fleU014_F050.GetDecimalValue("DOCREV_MTD_OUT_SVC"));









                        fleF050_DOC_REVENUE_MSTR_HISTORY.OutPut(OutPutType.Update, null, fleF050_DOC_REVENUE_MSTR_HISTORY.Exists());
                      
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
            EndRequest("U014_TRANSFER_F050_TO_F050HIST_3");

        }

    }




    #endregion


}
//U014_TRANSFER_F050_TO_F050HIST_3



public class U014_U015_U014_EXTRACT_F050TP_4 : U014_U015
{

    public U014_U015_U014_EXTRACT_F050TP_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050TP_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU014_F050TP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U014_F050TP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        PED_DD.GetValue += PED_DD_GetValue;
        X_ICONST_DATE_PERIOD_END.GetValue += X_ICONST_DATE_PERIOD_END_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U014_U015_U014_EXTRACT_F050TP_4)"

    private SqlFileObject fleF050TP_DOC_REVENUE_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_MONTHEND")) == QDesign.NULL(QDesign.NULL(X_SELECT_MONTHEND.Value)))
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


    #region "Standard Generated Procedures(U014_U015_U014_EXTRACT_F050TP_4)"


    #region "Automatic Item Initialization(U014_U015_U014_EXTRACT_F050TP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U014_U015_U014_EXTRACT_F050TP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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


    #region "FILE Management Procedures(U014_U015_U014_EXTRACT_F050TP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_U015_U014_EXTRACT_F050TP_4)"


    public void Run()
    {

        try
        {
            Request("U014_EXTRACT_F050TP_4");

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
                    m_strWhere.Append((fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR")));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {













                            SubFile(ref m_trnTRANS_UPDATE, ref fleU014_F050TP, SubFileType.Keep, X_ICONST_DATE_PERIOD_END, fleF050TP_DOC_REVENUE_MSTR);
                            //Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREVTP_KEY)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY


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
            EndRequest("U014_EXTRACT_F050TP_4");

        }

    }




    #endregion


}
//U014_EXTRACT_F050TP_4



public class U014_U015_U014_TRANSFER_F050TP_TO_F050TPHIST_5 : U014_U015
{

    public U014_U015_U014_TRANSFER_F050TP_TO_F050TPHIST_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU014_F050TP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U014_F050TP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF050TP_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF050TP_HIST_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR_HISTORY", "F050TP_HIST_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF050TP_DOC_REVENUE_MSTR_HISTORY.SetItemFinals += fleF050TP_DOC_REVENUE_MSTR_HISTORY_SetItemFinals;
        fleF050TP_HIST_ADD.InitializeItems += fleF050TP_HIST_ADD_InitializeItems;
        fleF050TP_HIST_ADD.InitializeItems += fleF050TP_HIST_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U014_U015_U014_TRANSFER_F050TP_TO_F050TPHIST_5)"

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


    #region "Standard Generated Procedures(U014_U015_U014_TRANSFER_F050TP_TO_F050TPHIST_5)"


    #region "Automatic Item Initialization(U014_U015_U014_TRANSFER_F050TP_TO_F050TPHIST_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:27 PM

    //#-----------------------------------------
    //# fleF050TP_HIST_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:47:26 PM
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


    #region "Transaction Management Procedures(U014_U015_U014_TRANSFER_F050TP_TO_F050TPHIST_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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


    #region "FILE Management Procedures(U014_U015_U014_TRANSFER_F050TP_TO_F050TPHIST_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_U015_U014_TRANSFER_F050TP_TO_F050TPHIST_5)"


    public void Run()
    {

        try
        {
            Request("U014_TRANSFER_F050TP_TO_F050TPHIST_5");

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
                    m_strWhere.Append(GetWhereClauseString(fleF050TP_DOC_REVENUE_MSTR_HISTORY.ElementOwner("ICONST_DATE_PERIOD_END"), "=", fleU014_F050TP.GetNumericDateValue("X_ICONST_DATE_PERIOD_END")));
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
                        //Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREVTP_KEY)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY


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
            EndRequest("U014_TRANSFER_F050TP_TO_F050TPHIST_5");

        }

    }




    #endregion


}
//U014_TRANSFER_F050TP_TO_F050TPHIST_5



public class U014_U015_UPDATE_F050_6 : U014_U015
{

    public U014_U015_UPDATE_F050_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU014_F050 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U014_F050", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF050_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF050_DOC_REVENUE_MSTR.SetItemFinals += fleF050_DOC_REVENUE_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U014_U015_UPDATE_F050_6)"

    private SqlFileObject fleU014_F050;
    private SqlFileObject fleF050_DOC_REVENUE_MSTR;

    private void fleF050_DOC_REVENUE_MSTR_SetItemFinals()
    {

        try
        {
            fleF050_DOC_REVENUE_MSTR.set_SetValue("DOCREV_MTD_IN_REC", 0);
            fleF050_DOC_REVENUE_MSTR.set_SetValue("DOCREV_MTD_IN_SVC", 0);
            fleF050_DOC_REVENUE_MSTR.set_SetValue("DOCREV_MTD_OUT_REC", 0);
            fleF050_DOC_REVENUE_MSTR.set_SetValue("DOCREV_MTD_OUT_SVC", 0);


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


    #region "Standard Generated Procedures(U014_U015_UPDATE_F050_6)"


    #region "Automatic Item Initialization(U014_U015_UPDATE_F050_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U014_U015_UPDATE_F050_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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
        fleU014_F050.Transaction = m_trnTRANS_UPDATE;
        fleF050_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U014_U015_UPDATE_F050_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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
            fleU014_F050.Dispose();
            fleF050_DOC_REVENUE_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_U015_UPDATE_F050_6)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F050_6");

            while (fleU014_F050.QTPForMissing())
            {
                // --> GET U014_F050 <--

                fleU014_F050.GetData();
                // --> End GET U014_F050 <--

                while (fleF050_DOC_REVENUE_MSTR.QTPForMissing("1"))
                {
                    // --> GET F050_DOC_REVENUE_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_CLINIC_1_2")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_DEPT")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(2, 2)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(4, 3)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_LOCATION")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(7, 4)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_OMA_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(11, 4)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_OMA_SUFF")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(15, 1)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_ADJ_CD_SUB_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2") + QDesign.ASCII(fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_DEPT"), 2) + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(16).Substring(16, 1)));
                    //Parent:DOCREV_KEY    'Parent:DOCREV_KEY

                    fleF050_DOC_REVENUE_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F050_DOC_REVENUE_MSTR <--


                    if (Transaction())
                    {













                        fleF050_DOC_REVENUE_MSTR.OutPut(OutPutType.Update);
                        //Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREVTP_KEY)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY

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
            EndRequest("UPDATE_F050_6");

        }

    }




    #endregion


}
//UPDATE_F050_6



public class U014_U015_UPDATE_F050TP_7 : U014_U015
{

    public U014_U015_UPDATE_F050TP_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU014_F050TP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U014_F050TP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF050TP_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF050TP_DOC_REVENUE_MSTR.SetItemFinals += fleF050TP_DOC_REVENUE_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U014_U015_UPDATE_F050TP_7)"

    private SqlFileObject fleU014_F050TP;
    private SqlFileObject fleF050TP_DOC_REVENUE_MSTR;

    private void fleF050TP_DOC_REVENUE_MSTR_SetItemFinals()
    {

        try
        {
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_TECH_AMT_BILLED", 0);
            // TODO: DOCREVTP_IN_TECH_AMT_BILLED occurs 2.  Manual steps may be required.' TODO: DOCREVTP_IN_TECH_AMT_BILLED occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_TECH_AMT_ADJUSTS", 0);
            // TODO: DOCREVTP_IN_TECH_AMT_ADJUSTS occurs 2.  Manual steps may be required.' TODO: DOCREVTP_IN_TECH_AMT_ADJUSTS occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_TECH_NBR_SVC", 0);
            // TODO: DOCREVTP_IN_TECH_NBR_SVC occurs 2.  Manual steps may be required.' TODO: DOCREVTP_IN_TECH_NBR_SVC occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_PROF_AMT_BILLED", 0);
            // TODO: DOCREVTP_IN_PROF_AMT_BILLED occurs 2.  Manual steps may be required.' TODO: DOCREVTP_IN_PROF_AMT_BILLED occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_PROF_AMT_ADJUSTS", 0);
            // TODO: DOCREVTP_IN_PROF_AMT_ADJUSTS occurs 2.  Manual steps may be required.' TODO: DOCREVTP_IN_PROF_AMT_ADJUSTS occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_PROF_NBR_SVC", 0);
            // TODO: DOCREVTP_IN_PROF_NBR_SVC occurs 2.  Manual steps may be required.' TODO: DOCREVTP_IN_PROF_NBR_SVC occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_TECH_AMT_BILLED", 0);
            // TODO: DOCREVTP_OUT_TECH_AMT_BILLED occurs 2.  Manual steps may be required.' TODO: DOCREVTP_OUT_TECH_AMT_BILLED occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS", 0);
            // TODO: DOCREVTP_OUT_TECH_AMT_ADJUSTS occurs 2.  Manual steps may be required.' TODO: DOCREVTP_OUT_TECH_AMT_ADJUSTS occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_TECH_NBR_SVC", 0);
            // TODO: DOCREVTP_OUT_TECH_NBR_SVC occurs 2.  Manual steps may be required.' TODO: DOCREVTP_OUT_TECH_NBR_SVC occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_PROF_AMT_BILLED", 0);
            // TODO: DOCREVTP_OUT_PROF_AMT_BILLED occurs 2.  Manual steps may be required.' TODO: DOCREVTP_OUT_PROF_AMT_BILLED occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS", 0);
            // TODO: DOCREVTP_OUT_PROF_AMT_ADJUSTS occurs 2.  Manual steps may be required.' TODO: DOCREVTP_OUT_PROF_AMT_ADJUSTS occurs 2.  Manual steps may be required.
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_PROF_NBR_SVC", 0);
            // TODO: DOCREVTP_OUT_PROF_NBR_SVC occurs 2.  Manual steps may be required.' TODO: DOCREVTP_OUT_PROF_NBR_SVC occurs 2.  Manual steps may be required.


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


    #region "Standard Generated Procedures(U014_U015_UPDATE_F050TP_7)"


    #region "Automatic Item Initialization(U014_U015_UPDATE_F050TP_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U014_U015_UPDATE_F050TP_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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
        fleF050TP_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U014_U015_UPDATE_F050TP_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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
            fleF050TP_DOC_REVENUE_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_U015_UPDATE_F050TP_7)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F050TP_7");

            while (fleU014_F050TP.QTPForMissing())
            {
                // --> GET U014_F050TP <--

                fleU014_F050TP.GetData();
                // --> End GET U014_F050TP <--

                while (fleF050TP_DOC_REVENUE_MSTR.QTPForMissing("1"))
                {
                    // --> GET F050TP_DOC_REVENUE_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(0, 2)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_AGENT_CD")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(2, 1)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_LOC_CD")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(3, 4)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_OMA_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(7, 4)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_OMA_SUFFIX")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(11, 1)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleF050TP_DOC_REVENUE_MSTR.GetDecimalValue("DOCREVTP_CLINIC_NBR"), 2) + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_AGENT_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_LOC_CD") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_CODE") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_OMA_SUFFIX") + fleF050TP_DOC_REVENUE_MSTR.GetStringValue("DOCREVTP_DOC_NBR")).PadRight(15).Substring(12, 3)));
                    //Parent:DOCREVTP_KEY    'Parent:DOCREVTP_KEY

                    fleF050TP_DOC_REVENUE_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F050TP_DOC_REVENUE_MSTR <--


                    if (Transaction())
                    {







                        fleF050TP_DOC_REVENUE_MSTR.OutPut(OutPutType.Update);
                        //Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREVTP_KEY)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY

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
            EndRequest("UPDATE_F050TP_7");

        }

    }




    #endregion


}
//UPDATE_F050TP_7



public class U014_U015_UPDATE_F051_8 : U014_U015
{

    public U014_U015_UPDATE_F051_8(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF051_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF051_DOC_CASH_MSTR.SetItemFinals += fleF051_DOC_CASH_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U014_U015_UPDATE_F051_8)"

    private SqlFileObject fleF051_DOC_CASH_MSTR;

    private void fleF051_DOC_CASH_MSTR_SetItemFinals()
    {

        try
        {
            fleF051_DOC_CASH_MSTR.set_SetValue("DOCASH_MTD_IN_REC", 0);
            fleF051_DOC_CASH_MSTR.set_SetValue("DOCASH_MTD_IN_SVC", 0);


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

    private SqlFileObject fleICONST_MSTR_REC;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_MONTHEND")) == QDesign.NULL(QDesign.NULL(X_SELECT_MONTHEND.Value)))
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




    #endregion


    #region "Standard Generated Procedures(U014_U015_UPDATE_F051_8)"


    #region "Automatic Item Initialization(U014_U015_UPDATE_F051_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U014_U015_UPDATE_F051_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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
        fleF051_DOC_CASH_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U014_U015_UPDATE_F051_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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
            fleF051_DOC_CASH_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_U015_UPDATE_F051_8)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F051_8");

            while (fleF051_DOC_CASH_MSTR.QTPForMissing())
            {
                // --> GET F051_DOC_CASH_MSTR <--

                fleF051_DOC_CASH_MSTR.GetData();
                // --> End GET F051_DOC_CASH_MSTR <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(fleF051_DOC_CASH_MSTR.GetStringValue("DOCASH_CLINIC_1_2"))));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {













                            fleF051_DOC_CASH_MSTR.OutPut(OutPutType.Update);
                            //Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREVTP_KEY)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY

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
            EndRequest("UPDATE_F051_8");

        }

    }




    #endregion


}
//UPDATE_F051_8



public class U014_U015_UPDATE_F051TP_9 : U014_U015
{

    public U014_U015_UPDATE_F051TP_9(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF051TP_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051TP_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF051TP_DOC_CASH_MSTR.SetItemFinals += fleF051TP_DOC_CASH_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U014_U015_UPDATE_F051TP_9)"

    private SqlFileObject fleF051TP_DOC_CASH_MSTR;

    private void fleF051TP_DOC_CASH_MSTR_SetItemFinals()
    {

        try
        {
            fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_TECH_IN_MTD", 0);
            fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_PROF_IN_MTD", 0);
            fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_TECH_OUT_MTD", 0);
            fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_PROF_OUT_MTD", 0);


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

    private SqlFileObject fleICONST_MSTR_REC;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_MONTHEND")) == QDesign.NULL(QDesign.NULL(X_SELECT_MONTHEND.Value)))
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




    #endregion


    #region "Standard Generated Procedures(U014_U015_UPDATE_F051TP_9)"


    #region "Automatic Item Initialization(U014_U015_UPDATE_F051TP_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U014_U015_UPDATE_F051TP_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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
        fleF051TP_DOC_CASH_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U014_U015_UPDATE_F051TP_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:47:21 PM

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
            fleF051TP_DOC_CASH_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U014_U015_UPDATE_F051TP_9)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F051TP_9");

            while (fleF051TP_DOC_CASH_MSTR.QTPForMissing())
            {
                // --> GET F051TP_DOC_CASH_MSTR <--

                fleF051TP_DOC_CASH_MSTR.GetData();
                // --> End GET F051TP_DOC_CASH_MSTR <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append((fleF051TP_DOC_CASH_MSTR.GetDecimalValue("DOCASHTP_CLINIC_NBR")));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {













                            fleF051TP_DOC_CASH_MSTR.OutPut(OutPutType.Update);
                            //Parent:DOCREV_KEY)    'Parent:DOCREV_OMA_CD)    'Parent:DOCREV_MONTH_TO_DATE)    'Parent:DOCREV_YEAR_TO_DATE)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY)    'Parent:DOCREVTP_OMA_CD)    'Parent:DOCREVTP_MTD_YTD)    'Parent:ICONST_DATE_PERIOD_END)    'Parent:DOCREVTP_KEY)    'Parent:DOCREV_KEY)    'Parent:DOCREVTP_KEY

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
            EndRequest("UPDATE_F051TP_9");

        }

    }




    #endregion


}
//UPDATE_F051TP_9




