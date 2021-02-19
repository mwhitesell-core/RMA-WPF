
#region "Screen Comments"

// doc     : peds_diag_codes.qts      
// *************************************************************
// Date           Who             Description
// 2011/07/12     Yasemin         clinic_89_diag.qts
// 2012/07/25     Yasemin         add department 76


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class PEDS_DIAG_CODES : BaseClassControl
{

    private PEDS_DIAG_CODES m_PEDS_DIAG_CODES;

    public PEDS_DIAG_CODES(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public PEDS_DIAG_CODES(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_PEDS_DIAG_CODES != null))
        {
            m_PEDS_DIAG_CODES.CloseTransactionObjects();
            m_PEDS_DIAG_CODES = null;
        }
    }

    public PEDS_DIAG_CODES GetPEDS_DIAG_CODES(int Level)
    {
        if (m_PEDS_DIAG_CODES == null)
        {
            m_PEDS_DIAG_CODES = new PEDS_DIAG_CODES("PEDS_DIAG_CODES", Level);
        }
        else
        {
            m_PEDS_DIAG_CODES.ResetValues();
        }
        return m_PEDS_DIAG_CODES;
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

            PEDS_DIAG_CODES_ONE_1 ONE_1 = new PEDS_DIAG_CODES_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            PEDS_DIAG_CODES_TWO_2 TWO_2 = new PEDS_DIAG_CODES_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

            PEDS_DIAG_CODES_THREE_3 THREE_3 = new PEDS_DIAG_CODES_THREE_3(Name, Level);
            THREE_3.Run();
            THREE_3.Dispose();
            THREE_3 = null;

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

public class PEDS_DIAG_CODES_ONE_1 : PEDS_DIAG_CODES
{

    public PEDS_DIAG_CODES_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePEDSDIAG = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSDIAG", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;
        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;
        CLMHDR_CLAIM_ID.GetValue += CLMHDR_CLAIM_ID_GetValue;
        CLMHDR_PAT_OHIP_ID_OR_CHART.GetValue += CLMHDR_PAT_OHIP_ID_OR_CHART_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(PEDS_DIAG_CODES_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append("((").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" =  'C' ) AND ");
            strSQL.Append("(").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  7 OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  70 OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  71 OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  72 OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  73 OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  74 OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  75 OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  76 ))");

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

    private void fleF002_CLAIMS_MSTR_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("B"));

            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("00000"));

            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField("0"));

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

    private SqlFileObject flePEDSDIAG;

    private DCharacter CLMHDR_CLAIM_ID = new DCharacter("CLMHDR_CLAIM_ID", 16);
    private void CLMHDR_CLAIM_ID_GetValue(ref string Value)
    {
        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR");
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

    private DCharacter CLMHDR_PAT_OHIP_ID_OR_CHART = new DCharacter("CLMHDR_PAT_OHIP_ID_OR_CHART", 16);
    private void CLMHDR_PAT_OHIP_ID_OR_CHART_GetValue(ref string Value)
    {
        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA");
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


    #region "Standard Generated Procedures(PEDS_DIAG_CODES_ONE_1)"


    #region "Automatic Item Initialization(PEDS_DIAG_CODES_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(PEDS_DIAG_CODES_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:52 PM

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
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePEDSDIAG.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(PEDS_DIAG_CODES_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:52 PM

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
            fleF002_CLAIMS_MSTR.Dispose();
            flePEDSDIAG.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PEDS_DIAG_CODES_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--
                fleF002_CLAIMS_MSTR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--

                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref flePEDSDIAG, SubFileType.Keep,  CLMHDR_CLAIM_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_LOC", "CLMHDR_HOSP", "CLMHDR_AGENT_CD", CLMHDR_PAT_OHIP_ID_OR_CHART);
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

public class PEDS_DIAG_CODES_TWO_2 : PEDS_DIAG_CODES
{
    public PEDS_DIAG_CODES_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePEDSDIAG = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSDIAG", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePEDSDIAG1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSDIAG1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePEDSDIAG_SVC2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSDIAG1", "PEDSDIAG_SVC2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePEDSDIAG_SVC3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSDIAG1", "PEDSDIAG_SVC3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePEDSDIAG_SVC4 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSDIAG1", "PEDSDIAG_SVC4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        CONSEC_FLAG.GetValue += CONSEC_FLAG_GetValue;
        X_SV_NBR1.GetValue += X_SV_NBR1_GetValue;
        X_SV_NBR2.GetValue += X_SV_NBR2_GetValue;
        X_SV_NBR3.GetValue += X_SV_NBR3_GetValue;
        X_SV_NBR4.GetValue += X_SV_NBR4_GetValue;
        X_NBR_SVCS.GetValue += X_NBR_SVCS_GetValue;
        X_FEE.GetValue += X_FEE_GetValue;
        X_CLMDTL_FEE_OHIP_1.GetValue += X_CLMDTL_FEE_OHIP_1_GetValue;
        X_CLMDTL_FEE_OHIP_2.GetValue += X_CLMDTL_FEE_OHIP_2_GetValue;
        X_CLMDTL_FEE_OHIP_3.GetValue += X_CLMDTL_FEE_OHIP_3_GetValue;
        X_CLMDTL_FEE_OHIP_4.GetValue += X_CLMDTL_FEE_OHIP_4_GetValue;
        X_SV_DATE_1.GetValue += X_SV_DATE_1_GetValue;
        X_SV_DATE_2.GetValue += X_SV_DATE_2_GetValue;
        X_SV_DATE_3.GetValue += X_SV_DATE_3_GetValue;
        X_SV_DATE_4.GetValue += X_SV_DATE_4_GetValue;
        X_DOC.GetValue += X_DOC_GetValue;
        CLMDTL_ID.GetValue += CLMDTL_ID_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;
    }

    #region "Declarations (Variables, Files and Transactions)(PEDS_DIAG_CODES_TWO_2)"

    private SqlFileObject flePEDSDIAG;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            //strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_SV_YY")).Append(" >=  2016 AND ");
            //strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_SV_MM")).Append(" >=  4 AND ");
            //strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_SV_DD")).Append(" >=  1 AND ");
            //strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_CONSEC_DATES_R")).Append(" <=  '20170331' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  '0000' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'ZZZZ' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'PAID' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICM' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MISJ' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MISC' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICV' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MISP' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MOHR' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICB' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MIBR' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MINH' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MHSC' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'NHSC' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'DHSC' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'AGEP' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICA' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICC' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICD' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICE' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICF' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICG' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICH' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICJ' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICK' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICL' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'T995'");

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

    private DCharacter CONSEC_FLAG = new DCharacter("CONSEC_FLAG", 1);
    private void CONSEC_FLAG_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0OP" & 
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0MR" & 
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0BI" & 
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0" & 
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != " 00" & 
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "000" & 
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != QDesign.NULL("   "))
            {
                CurrentValue = "Y";
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

    private DDecimal X_SV_NBR1 = new DDecimal("X_SV_NBR1", 2);
    private void X_SV_NBR1_GetValue(ref decimal Value)
    {
        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV");
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

    private DDecimal X_SV_NBR2 = new DDecimal("X_SV_NBR2", 2);
    private void X_SV_NBR2_GetValue(ref decimal Value)
    {
        try
        {
            decimal CurrentValue = 0m;

            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 1));
            }
            else
            {
                CurrentValue = 0;
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

    private DDecimal X_SV_NBR3 = new DDecimal("X_SV_NBR3", 2);
    private void X_SV_NBR3_GetValue(ref decimal Value)
    {
        try
        {
            decimal CurrentValue = 0m;

            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 4, 1));
            }
            else
            {
                CurrentValue = 0;
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

    private DDecimal X_SV_NBR4 = new DDecimal("X_SV_NBR4", 2);
    private void X_SV_NBR4_GetValue(ref decimal Value)
    {
        try
        {
            decimal CurrentValue = 0m;


            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 7, 1));
            }
            else
            {
                CurrentValue = 0;
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

    private DDecimal X_NBR_SVCS = new DDecimal("X_NBR_SVCS", 2);
    private void X_NBR_SVCS_GetValue(ref decimal Value)
    {
        try
        {
            Value = X_SV_NBR1.Value + X_SV_NBR2.Value + X_SV_NBR3.Value + X_SV_NBR4.Value;
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

    private DDecimal X_FEE = new DDecimal("X_FEE", 7);
    private void X_FEE_GetValue(ref decimal Value)
    {
        try
        {
            decimal CurrentValue = 0m;

            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = QDesign.Divide(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP"), X_NBR_SVCS.Value);
            }
            else
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP");
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

    private DDecimal X_CLMDTL_FEE_OHIP_1 = new DDecimal("X_CLMDTL_FEE_OHIP_1", 7);
    private void X_CLMDTL_FEE_OHIP_1_GetValue(ref decimal Value)
    {
        try
        {
            decimal CurrentValue = 0m;

            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = X_SV_NBR1.Value * X_FEE.Value;
            }
            else
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP");
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

    private DDecimal X_CLMDTL_FEE_OHIP_2 = new DDecimal("X_CLMDTL_FEE_OHIP_2", 7);
    private void X_CLMDTL_FEE_OHIP_2_GetValue(ref decimal Value)
    {
        try
        {
            Value = X_SV_NBR2.Value * X_FEE.Value;
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

    private DDecimal X_CLMDTL_FEE_OHIP_3 = new DDecimal("X_CLMDTL_FEE_OHIP_3", 7);
    private void X_CLMDTL_FEE_OHIP_3_GetValue(ref decimal Value)
    {
        try
        {
            Value = X_SV_NBR3.Value * X_FEE.Value;
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

    private DDecimal X_CLMDTL_FEE_OHIP_4 = new DDecimal("X_CLMDTL_FEE_OHIP_4", 7);
    private void X_CLMDTL_FEE_OHIP_4_GetValue(ref decimal Value)
    {
        try
        {
            Value = X_SV_NBR4.Value * X_FEE.Value;
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

    private DCharacter X_SV_DATE_1 = new DCharacter("X_SV_DATE_1", 8);
    private void X_SV_DATE_1_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2);
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

    private DCharacter X_SV_DATE_2 = new DCharacter("X_SV_DATE_2", 8);
    private void X_SV_DATE_2_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2);
            }
            else
            {
                CurrentValue = " ";
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

    private DCharacter X_SV_DATE_3 = new DCharacter("X_SV_DATE_3", 8);
    private void X_SV_DATE_3_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 5, 2);
            }
            else
            {
                CurrentValue = " ";
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

    private DCharacter X_SV_DATE_4 = new DCharacter("X_SV_DATE_4", 8);
    private void X_SV_DATE_4_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_RSV_NBR"), 8, 2);
            }
            else
            {
                CurrentValue = " ";
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

    private DCharacter X_DOC = new DCharacter("X_DOC", 3);
    private void X_DOC_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR"), 1), 3, 3);
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

    private SqlFileObject flePEDSDIAG1;
    private SqlFileObject flePEDSDIAG_SVC2;
    private SqlFileObject flePEDSDIAG_SVC3;
    private SqlFileObject flePEDSDIAG_SVC4;

    private DCharacter CLMDTL_ID = new DCharacter("CLMDTL_ID", 16);
    private void CLMDTL_ID_GetValue(ref string Value)
    {
        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR"), 1);
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
            if (QDesign.NConvert(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2)) >= 20160401 && QDesign.NConvert(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2)) <= 20170331)
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

    #region "Standard Generated Procedures(PEDS_DIAG_CODES_TWO_2)"


    #region "Automatic Item Initialization(PEDS_DIAG_CODES_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(PEDS_DIAG_CODES_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:53 PM

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
        flePEDSDIAG.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePEDSDIAG1.Transaction = m_trnTRANS_UPDATE;
        flePEDSDIAG_SVC2.Transaction = m_trnTRANS_UPDATE;
        flePEDSDIAG_SVC3.Transaction = m_trnTRANS_UPDATE;
        flePEDSDIAG_SVC4.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(PEDS_DIAG_CODES_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:53 PM

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
            flePEDSDIAG.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            flePEDSDIAG1.Dispose();
            flePEDSDIAG_SVC2.Dispose();
            flePEDSDIAG_SVC3.Dispose();
            flePEDSDIAG_SVC4.Dispose();


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
    
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PEDS_DIAG_CODES_TWO_2)"

    public void Run()
    {
        try
        {
            Request("TWO_2");

            while (flePEDSDIAG.QTPForMissing())
            {
                // --> GET PEDSDIAG <--
                flePEDSDIAG.GetData();
                // --> End GET PEDSDIAG <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(flePEDSDIAG.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((flePEDSDIAG.GetDecimalValue("KEY_CLM_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {
                        if (Select_If())
                        {
                            SubFile(ref m_trnTRANS_UPDATE, ref flePEDSDIAG1, SubFileType.Keep, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_DOC, X_CLMDTL_FEE_OHIP_1, X_SV_DATE_1,
                            X_SV_NBR1, "CLMDTL_DIAG_CD", "CLMDTL_OMA_CD", flePEDSDIAG, "CLMHDR_CLAIM_ID", "CLMHDR_LOC", "CLMHDR_HOSP", "CLMHDR_AGENT_CD", "CLMHDR_PAT_OHIP_ID_OR_CHART");

                            SubFile(ref m_trnTRANS_UPDATE, ref flePEDSDIAG_SVC2, QDesign.NULL(X_SV_NBR2.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_DOC, X_CLMDTL_FEE_OHIP_2,
                            X_SV_DATE_2, X_SV_NBR2, "CLMDTL_DIAG_CD", "CLMDTL_OMA_CD", flePEDSDIAG, "CLMHDR_CLAIM_ID", "CLMHDR_LOC", "CLMHDR_HOSP", "CLMHDR_AGENT_CD", "CLMHDR_PAT_OHIP_ID_OR_CHART");

                            SubFile(ref m_trnTRANS_UPDATE, ref flePEDSDIAG_SVC3, QDesign.NULL(X_SV_NBR3.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_DOC, X_CLMDTL_FEE_OHIP_3,
                            X_SV_DATE_3, X_SV_NBR3, "CLMDTL_DIAG_CD", "CLMDTL_OMA_CD", flePEDSDIAG, "CLMHDR_CLAIM_ID", "CLMHDR_LOC", "CLMHDR_HOSP", "CLMHDR_AGENT_CD", "CLMHDR_PAT_OHIP_ID_OR_CHART");

                            SubFile(ref m_trnTRANS_UPDATE, ref flePEDSDIAG_SVC4, QDesign.NULL(X_SV_NBR4.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_DOC, X_CLMDTL_FEE_OHIP_4,
                            X_SV_DATE_4, X_SV_NBR4, "CLMDTL_DIAG_CD", "CLMDTL_OMA_CD", flePEDSDIAG, "CLMHDR_CLAIM_ID", "CLMHDR_LOC", "CLMHDR_HOSP", "CLMHDR_AGENT_CD", "CLMHDR_PAT_OHIP_ID_OR_CHART");
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
            EndRequest("TWO_2");
        }
    }

    #endregion
}
//TWO_2

public class PEDS_DIAG_CODES_THREE_3 : PEDS_DIAG_CODES
{
    public PEDS_DIAG_CODES_THREE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePEDSDIAG1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSDIAG1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF091_DIAG_CODES_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F091_DIAG_CODES_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_DIAG = new CoreDecimal("X_DIAG", 7, this);
        flePEDSDIAG2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSDIAG2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        CLINIC.GetValue += CLINIC_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        DETAIL_LINE.GetValue += DETAIL_LINE_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(PEDS_DIAG_CODES_THREE_3)"

    private SqlFileObject flePEDSDIAG1;
    private SqlFileObject fleF091_DIAG_CODES_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DCharacter CLINIC = new DCharacter("CLINIC", 2);
    private void CLINIC_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(flePEDSDIAG1.GetStringValue("CLMDTL_ID"), 1, 2);
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

    private CoreDecimal X_DIAG;

    private DCharacter COMMA = new DCharacter("COMMA", 1);
    private void COMMA_GetValue(ref string Value)
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

    private DCharacter X_CR = new DCharacter("X_CR", 2);
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

    private DCharacter DETAIL_LINE = new DCharacter("DETAIL_LINE", 170);
    private void DETAIL_LINE_GetValue(ref string Value)
    {
        try
        {
            Value = CLINIC.Value + COMMA.Value + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"), 2) + COMMA.Value + flePEDSDIAG1.GetStringValue("X_DOC") + COMMA.Value + fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME") + COMMA.Value + flePEDSDIAG1.GetStringValue("CLMDTL_DIAG_CD").PadLeft(3, '0') + COMMA.Value + fleF091_DIAG_CODES_MSTR.GetStringValue("DIAG_CD_DESC") + COMMA.Value + X_DIAG.Value;
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

    private SqlFileObject flePEDSDIAG2;

    #endregion

    #region "Standard Generated Procedures(PEDS_DIAG_CODES_THREE_3)"


    #region "Automatic Item Initialization(PEDS_DIAG_CODES_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(PEDS_DIAG_CODES_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:53 PM

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
        flePEDSDIAG1.Transaction = m_trnTRANS_UPDATE;
        fleF091_DIAG_CODES_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePEDSDIAG2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(PEDS_DIAG_CODES_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:53 PM

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
            flePEDSDIAG1.Dispose();
            fleF091_DIAG_CODES_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            flePEDSDIAG2.Dispose();


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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PEDS_DIAG_CODES_THREE_3)"

    public void Run()
    {
        try
        {
            Request("THREE_3");

            while (flePEDSDIAG1.QTPForMissing())
            {
                // --> GET PEDSDIAG1 <--

                flePEDSDIAG1.GetData();
                // --> End GET PEDSDIAG1 <--

                while (fleF091_DIAG_CODES_MSTR.QTPForMissing("1"))
                {
                    // --> GET F091_DIAG_CODES_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF091_DIAG_CODES_MSTR.ElementOwner("DIAG_CD")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(flePEDSDIAG1.GetDecimalValue("CLMDTL_DIAG_CD"), 3))));

                    fleF091_DIAG_CODES_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F091_DIAG_CODES_MSTR <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(flePEDSDIAG1.GetStringValue("X_DOC")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        if (Transaction())
                        {
                            Sort(flePEDSDIAG1.GetSortValue("X_DOC"), CLINIC.Value, flePEDSDIAG1.GetSortValue("CLMDTL_DIAG_CD"));
                        }
                    }
                }
            }

            while (Sort(flePEDSDIAG1, fleF091_DIAG_CODES_MSTR, fleF020_DOCTOR_MSTR))
            {
                X_DIAG.Value = X_DIAG.Value + 1;

                SubFile(ref m_trnTRANS_UPDATE, ref flePEDSDIAG2, flePEDSDIAG1.At("X_DOC") || At(CLINIC) || flePEDSDIAG1.At("CLMDTL_DIAG_CD"), SubFileType.Portable, DETAIL_LINE);

                Reset(ref X_DIAG, flePEDSDIAG1.At("X_DOC") || At(CLINIC) || flePEDSDIAG1.At("CLMDTL_DIAG_CD"));
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
            EndRequest("THREE_3");
        }
    }

    #endregion
}
//THREE_3




