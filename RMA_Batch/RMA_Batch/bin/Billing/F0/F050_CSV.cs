
#region "Screen Comments"

// DOC: F050_CSV.QZS
// DOC: PHYSICIAN REVENUE ANALYSIS with delimiter and column heading (requested by Brad)
// DOC: RUN FOR: ROSS
// PROGRAM PURPOSE : REVENUE ANALYSIS BY CLINIC
// DATE           WHO     DESCRIPTION
// 2015/Dec/11    MC      - original (clone from r011_csv.qts and f050ma1.qts and f050_bi.qts)
// - this report would be run in next monthend; MUST be run after r011_csv.qts
// because this program uses r011_ped.sf which is generated from r011_csv.qts 
// to determine what the previous ped should be


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class F050_CSV : BaseClassControl
{

    private F050_CSV m_F050_CSV;

    public F050_CSV(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public F050_CSV(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_F050_CSV != null))
        {
            m_F050_CSV.CloseTransactionObjects();
            m_F050_CSV = null;
        }
    }

    public F050_CSV GetF050_CSV(int Level)
    {
        if (m_F050_CSV == null)
        {
            m_F050_CSV = new F050_CSV("F050_CSV", Level);
        }
        else
        {
            m_F050_CSV.ResetValues();
        }
        return m_F050_CSV;
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

            F050_CSV_EXTRACT_F050HST_1 EXTRACT_F050HST_1 = new F050_CSV_EXTRACT_F050HST_1(Name, Level);
            EXTRACT_F050HST_1.Run();
            EXTRACT_F050HST_1.Dispose();
            EXTRACT_F050HST_1 = null;

            F050_CSV_CREATE_2 CREATE_2 = new F050_CSV_CREATE_2(Name, Level);
            CREATE_2.Run();
            CREATE_2.Dispose();
            CREATE_2 = null;

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



public class F050_CSV_EXTRACT_F050HST_1 : F050_CSV
{

    public F050_CSV_EXTRACT_F050HST_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR011_PED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R011_PED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF050_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF050A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F050A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        NAME.GetValue += NAME_GetValue;
        DOC_NBR.GetValue += DOC_NBR_GetValue;
        FIXED_DOCREV_OMA_CD.GetValue += FIXED_DOCREV_OMA_CD_GetValue;
        OMA_CD_DESC.GetValue += OMA_CD_DESC_GetValue;
        OMA_CODE_ONLY.GetValue += OMA_CODE_ONLY_GetValue;
        RPT_SORT_SEQ.GetValue += RPT_SORT_SEQ_GetValue;
        PRESORT_CODE.GetValue += PRESORT_CODE_GetValue;
        GROUPING.GetValue += GROUPING_GetValue;
        fleF040_OMA_FEE_MSTR.InitializeItems += fleF040_OMA_FEE_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(F050_CSV_EXTRACT_F050HST_1)"

    private SqlFileObject fleR011_PED;
    private SqlFileObject fleF050_DOC_REVENUE_MSTR_HISTORY;
    private SqlFileObject fleF070_DEPT_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF040_OMA_FEE_MSTR;
    private DCharacter NAME = new DCharacter("NAME", 30);
    private void NAME_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR")) != "301")
            {
                CurrentValue = QDesign.Pack(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME") + "," + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3") + "(" + fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR") + ")");

            }
            else
            {
                CurrentValue = "BARNES,CC (481)";
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
    private DCharacter DOC_NBR = new DCharacter("DOC_NBR", 3);
    private void DOC_NBR_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR")) != "301")
            {
                CurrentValue = fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR");
            }
            else
            {
                CurrentValue = "481";
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
    private DCharacter FIXED_DOCREV_OMA_CD = new DCharacter("FIXED_DOCREV_OMA_CD", 5);
    private void FIXED_DOCREV_OMA_CD_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE"), 5, 1)) == "M")
            {
                CurrentValue= QDesign.Substring(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE"), 1, 4) + "A";

            }
            else
            {
                CurrentValue = fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE");

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
    private DCharacter OMA_CD_DESC = new DCharacter("OMA_CD_DESC", 55);
    private void OMA_CD_DESC_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (fleF040_OMA_FEE_MSTR.Exists())
            {
                CurrentValue = QDesign.Pack(FIXED_DOCREV_OMA_CD.Value + " - " + fleF040_OMA_FEE_MSTR.GetStringValue("FEE_DESC"));
            }
            else
            {
                CurrentValue = QDesign.Pack(FIXED_DOCREV_OMA_CD.Value + " - UNKNOWN FEE CODE");
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
    private DCharacter OMA_CODE_ONLY = new DCharacter("OMA_CODE_ONLY", 4);
    private void OMA_CODE_ONLY_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE"), 1, 4);



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
    private DCharacter RPT_SORT_SEQ = new DCharacter("RPT_SORT_SEQ", 4);
    private void RPT_SORT_SEQ_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A135")
            {
                CurrentValue = "E001";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A435")
            {
                CurrentValue = "E002";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A136")
            {
                CurrentValue = "E003";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A133")
            {
                CurrentValue = "E004";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A134")
            {
                CurrentValue = "E005";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A138")
            {
                CurrentValue = "E006";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K990")
            {
                CurrentValue = "E007";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K991")
            {
                CurrentValue = "E008";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K992")
            {
                CurrentValue = "E009";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K993")
            {
                CurrentValue = "E010";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K994")
            {
                CurrentValue = "E011";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K995")
            {
                CurrentValue = "E012";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K996")
            {
                CurrentValue = "E013";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K997")
            {
                CurrentValue = "E014";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C135")
            {
                CurrentValue = "D001";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C435")
            {
                CurrentValue = "D002";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C136")
            {
                CurrentValue = "D003";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C133")
            {
                CurrentValue = "D004";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C134")
            {
                CurrentValue = "D005";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C132")
            {
                CurrentValue = "D006";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C137")
            {
                CurrentValue = "D007";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C139")
            {
                CurrentValue = "D008";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C138")
            {
                CurrentValue = "D009";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C121")
            {
                CurrentValue = "D010";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C101")
            {
                CurrentValue = "D011";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C990")
            {
                CurrentValue = "D012";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C991")
            {
                CurrentValue = "D013";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C992")
            {
                CurrentValue = "D014";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C993")
            {
                CurrentValue = "D015";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C994")
            {
                CurrentValue = "D016";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C995")
            {
                CurrentValue = "D017";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C996")
            {
                CurrentValue = "D018";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C997")
            {
                CurrentValue = "D019";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "R849")
            {
                CurrentValue = "A001";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G325")
            {
                CurrentValue = "A002";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G323")
            {
                CurrentValue = "A003";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G330")
            {
                CurrentValue = "A004";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G331")
            {
                CurrentValue = "A005";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G860")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G862")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G863")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G864")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G865")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G866")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G408")
            {
                CurrentValue = "C000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G409")
            {
                CurrentValue = "C000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G412")
            {
                CurrentValue = "C000";
            }
            else if (QDesign.NULL(QDesign.Substring(OMA_CODE_ONLY.Value, 1, 3)) == "MIS")
            {
                CurrentValue = "G000";
            }
            else
            {
                CurrentValue = "F000";
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
    private DCharacter PRESORT_CODE = new DCharacter("PRESORT_CODE", 8);
    private void PRESORT_CODE_GetValue(ref string Value)
    {

        try
        {
            Value = RPT_SORT_SEQ.Value + OMA_CODE_ONLY.Value;


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
    private DCharacter GROUPING = new DCharacter("GROUPING", 1);
    private void GROUPING_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(RPT_SORT_SEQ.Value, 1, 1);


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



    private SqlFileObject fleF050A;


    #endregion


    #region "Standard Generated Procedures(F050_CSV_EXTRACT_F050HST_1)"


    #region "Automatic Item Initialization(F050_CSV_EXTRACT_F050HST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:25 PM

    //#-----------------------------------------
    //# fleF040_OMA_FEE_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:02:22 PM
    //#-----------------------------------------
    private void fleF040_OMA_FEE_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF040_OMA_FEE_MSTR.set_SetValue("FILLER", !Fixed, fleF070_DEPT_MSTR.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(F050_CSV_EXTRACT_F050HST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:20 PM

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
        fleR011_PED.Transaction = m_trnTRANS_UPDATE;
        fleF050_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleF070_DEPT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF050A.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(F050_CSV_EXTRACT_F050HST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:20 PM

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
            fleR011_PED.Dispose();
            fleF050_DOC_REVENUE_MSTR_HISTORY.Dispose();
            fleF070_DEPT_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF040_OMA_FEE_MSTR.Dispose();
            fleF050A.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(F050_CSV_EXTRACT_F050HST_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_F050HST_1");

            while (fleR011_PED.QTPForMissing())
            {
                // --> GET R011_PED <--

                fleR011_PED.GetData();
                // --> End GET R011_PED <--

                while (fleF050_DOC_REVENUE_MSTR_HISTORY.QTPForMissing("1"))
                {
                    // --> GET F050_DOC_REVENUE_MSTR_HISTORY <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("EP_YR")).Append(" = ");
                    m_strWhere.Append((fleR011_PED.GetDecimalValue("X_EP_YR")));
                    m_strWhere.Append(GetWhereClauseString(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("ICONST_DATE_PERIOD_END"), "=", fleR011_PED.GetDecimalValue("X_PREV_PED")));

                    fleF050_DOC_REVENUE_MSTR_HISTORY.GetData(m_strWhere.ToString());
                    // --> End GET F050_DOC_REVENUE_MSTR_HISTORY <--

                    while (fleF070_DEPT_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F070_DEPT_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ");
                        m_strWhere.Append((fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_DEPT")));

                        fleF070_DEPT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F070_DEPT_MSTR <--

                        while (fleF020_DOCTOR_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR")));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F020_DOCTOR_MSTR <--

                            while (fleF040_OMA_FEE_MSTR.QTPForMissing("4"))
                            {
                                // --> GET F040_OMA_FEE_MSTR <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                                m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(4).Substring(0, 1)));

                                m_strWhere.Append(" AND ").Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                                m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(4).Substring(1, 1)));


                                fleF040_OMA_FEE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F040_OMA_FEE_MSTR <--


                                if (Transaction())
                                {

                                    SubFile(ref m_trnTRANS_UPDATE, ref fleF050A, SubFileType.Keep, fleF070_DEPT_MSTR, "DEPT_COMPANY", fleF050_DOC_REVENUE_MSTR_HISTORY, "DOCREV_CLINIC_1_2", "DOCREV_DEPT", DOC_NBR, "DOCREV_LOCATION",
                                    FIXED_DOCREV_OMA_CD, PRESORT_CODE, GROUPING, OMA_CD_DESC, "DOCREV_MTD_IN_REC", "DOCREV_MTD_IN_SVC", "DOCREV_MTD_OUT_REC", "DOCREV_MTD_OUT_SVC", "DOCREV_YTD_IN_REC", "DOCREV_YTD_IN_SVC",
                                    "DOCREV_YTD_OUT_REC", "DOCREV_YTD_OUT_SVC", NAME);



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
            EndRequest("EXTRACT_F050HST_1");

        }

    }




    #endregion


}
//EXTRACT_F050HST_1



public class F050_CSV_CREATE_2 : F050_CSV
{

    public F050_CSV_CREATE_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F050A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleBI_F050_CSV = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "BI_F050_CSV", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_CR_LF.GetValue += X_CR_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;
        PED.GetValue += PED_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(F050_CSV_CREATE_2)"

    private SqlFileObject fleF050A;
    private DInteger X_NUM_CR = new DInteger("X_NUM_CR", 4);
    private void X_NUM_CR_GetValue(ref decimal Value)
    {

        try
        {
            Value = 13;


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
    private DCharacter X_CR = new DCharacter("X_CR", 1);
    private void X_CR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_CR.Value);


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
    private DCharacter X_CR_LF = new DCharacter("X_CR_LF", 2);
    private void X_CR_LF_GetValue(ref string Value)
    {

        try
        {
            Value = X_CR.Value + X_LF.Value;


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
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
    private DCharacter PED = new DCharacter("PED", 10);
    private void PED_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(QDesign.ASCII(fleF050A.GetDecimalValue("X_PREV_PED")), 1, 4) + "-" + QDesign.Substring(QDesign.ASCII(fleF050A.GetDecimalValue("X_PREV_PED")), 5, 2) + "-" + QDesign.Substring(QDesign.ASCII(fleF050A.GetDecimalValue("X_PREV_PED")), 7, 2);


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



    private SqlFileObject fleBI_F050_CSV;


    #endregion


    #region "Standard Generated Procedures(F050_CSV_CREATE_2)"


    #region "Automatic Item Initialization(F050_CSV_CREATE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(F050_CSV_CREATE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:20 PM

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
        fleF050A.Transaction = m_trnTRANS_UPDATE;
        fleBI_F050_CSV.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(F050_CSV_CREATE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:20 PM

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
            fleF050A.Dispose();
            fleBI_F050_CSV.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(F050_CSV_CREATE_2)"


    public void Run()
    {

        try
        {
            Request("CREATE_2");

            while (fleF050A.QTPForMissing())
            {
                // --> GET F050A <--

                fleF050A.GetData();
                // --> End GET F050A <--


                if (Transaction())
                {



                    SubFile(ref m_trnTRANS_UPDATE, ref fleBI_F050_CSV, SubFileType.Portable, PED, X_DELIMITER, fleF050A, X_LF);



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
            EndRequest("CREATE_2");

        }

    }




    #endregion


}
//CREATE_2




