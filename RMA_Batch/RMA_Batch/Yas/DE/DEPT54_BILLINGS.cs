
#region "Screen Comments"

// doc     : dept54.qts
// purpose : create a detail claims report for dept54 docs     
// rep claim#,dept,doc,name,health#,ped,servicedate,billingcode,desc         
// who     : for the dep54 manager site                        
// *************************************************************
// Date  Who  Description
// 2016/03/31 Yasemin         geriatric


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class DEPT54_BILLINGS : BaseClassControl
{

    private DEPT54_BILLINGS m_DEPT54_BILLINGS;

    public DEPT54_BILLINGS(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public DEPT54_BILLINGS(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_DEPT54_BILLINGS != null))
        {
            m_DEPT54_BILLINGS.CloseTransactionObjects();
            m_DEPT54_BILLINGS = null;
        }
    }

    public DEPT54_BILLINGS GetDEPT54_BILLINGS(int Level)
    {
        if (m_DEPT54_BILLINGS == null)
        {
            m_DEPT54_BILLINGS = new DEPT54_BILLINGS("DEPT54_BILLINGS", Level);
        }
        else
        {
            m_DEPT54_BILLINGS.ResetValues();
        }
        return m_DEPT54_BILLINGS;
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

            DEPT54_BILLINGS_ONE_1 ONE_1 = new DEPT54_BILLINGS_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            DEPT54_BILLINGS_TWO_2 TWO_2 = new DEPT54_BILLINGS_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

            DEPT54_BILLINGS_THREE_3 THREE_3 = new DEPT54_BILLINGS_THREE_3(Name, Level);
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



public class DEPT54_BILLINGS_ONE_1 : DEPT54_BILLINGS
{

    public DEPT54_BILLINGS_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEPT54 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT54", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

        CLMHDR_CLAIM_ID.GetValue += CLMHDR_CLAIM_ID_GetValue;
        CLMHDR_PAT_OHIP_ID_OR_CHART.GetValue += CLMHDR_PAT_OHIP_ID_OR_CHART_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(DEPT54_BILLINGS_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" =  'C' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  54)");


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

    private SqlFileObject fleDEPT54;


    #endregion


    #region "Standard Generated Procedures(DEPT54_BILLINGS_ONE_1)"


    #region "Automatic Item Initialization(DEPT54_BILLINGS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEPT54_BILLINGS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:40 PM

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
        fleDEPT54.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEPT54_BILLINGS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:40 PM

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
            fleDEPT54.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEPT54_BILLINGS_ONE_1)"


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
                    SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT54, SubFileType.Keep, CLMHDR_CLAIM_ID, fleF002_CLAIMS_MSTR,  "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_LOC", "CLMHDR_HOSP", "CLMHDR_DATE_PERIOD_END",
                    CLMHDR_PAT_OHIP_ID_OR_CHART);
                    //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:PAT_OHIP_MMYY)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD)    'Parent:DOC_INITS
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



public class DEPT54_BILLINGS_TWO_2 : DEPT54_BILLINGS
{

    public DEPT54_BILLINGS_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleDEPT54 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT54", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEPT541 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT541", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDEPT54_SVC2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT541", "DEPT54_SVC2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDEPT54_SVC3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT541", "DEPT54_SVC3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDEPT54_SVC4 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT541", "DEPT54_SVC4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_YYYYMM.GetValue += X_YYYYMM_GetValue;
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
        CLMDTL_ID.GetValue += CLMDTL_ID_GetValue;
        KEY_CLM_CLAIM_NBR.GetValue += KEY_CLM_CLAIM_NBR_GetValue;
        CLMHDR_DATE_PERIOD_END.GetValue += CLMHDR_DATE_PERIOD_END_GetValue;
        CLMDTL_DIAG_CD.GetValue += CLMDTL_DIAG_CD_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }

    #region "Declarations (Variables, Files and Transactions)(DEPT54_BILLINGS_TWO_2)"

    private SqlFileObject fleDEPT54;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (SUBSTRING(").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_DATE_PERIOD_END")).Append(", 1, 6) = '").Append(X_YYYYMM.Value).Append("' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  '0000' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'ZZZZ' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'PAID' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICM' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MISJ' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MISC' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICV' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MISP' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MOHR' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICB' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MIBR' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MINH' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MHSC' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'NHSC' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'DHSC' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'AGEP')");


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

    private DCharacter X_YYYYMM = new DCharacter("X_YYYYMM", 6);
    private void X_YYYYMM_GetValue(ref string Value)
    {

        try
        {
            Value = Prompt(1).ToString();


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
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0  " & 
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != " 00" & 
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "000" & 
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "00 " & 
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "   ")
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
    private DDecimal X_FEE = new DDecimal("X_FEE", 6);
    private void X_FEE_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.Divide(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP"), X_NBR_SVCS.Value);


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
            Value = X_SV_NBR1.Value * X_FEE.Value;


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
            //Parent:CLMDTL_SV_DATE


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
                CurrentValue= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + 
                                                QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + 
                                                QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + 
                              QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2);
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
                CurrentValue= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + 
                                                QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + 
                                                QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + 
                              QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 5, 2);
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
                CurrentValue= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + 
                                                QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + 
                                                QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + 
                              QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 8, 2);
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

    private DCharacter CLMDTL_ID = new DCharacter("CLMDTL_ID", 16);
    private void CLMDTL_ID_GetValue(ref string Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_NBR");
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

    private DCharacter KEY_CLM_CLAIM_NBR = new DCharacter("KEY_CLM_CLAIM_NBR", 3);
    private void KEY_CLM_CLAIM_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = "+" + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("KEY_CLM_CLAIM_NBR"), 2);
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

    private DCharacter CLMDTL_DIAG_CD = new DCharacter("CLMDTL_DIAG_CD", 4);
    private void CLMDTL_DIAG_CD_GetValue(ref string Value)
    {

        try
        {
            Value = "+" + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_DIAG_CD"), 3);
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

    private DCharacter CLMHDR_DATE_PERIOD_END = new DCharacter("CLMHDR_DATE_PERIOD_END", 9);
    private void CLMHDR_DATE_PERIOD_END_GetValue(ref string Value)
    {

        try
        {
            Value = "+" + QDesign.ASCII(fleDEPT54.GetDecimalValue("CLMHDR_DATE_PERIOD_END"), 8);
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

    private SqlFileObject fleDEPT541;
    private SqlFileObject fleDEPT54_SVC2;
    private SqlFileObject fleDEPT54_SVC3;
    private SqlFileObject fleDEPT54_SVC4;


    #endregion


    #region "Standard Generated Procedures(DEPT54_BILLINGS_TWO_2)"


    #region "Automatic Item Initialization(DEPT54_BILLINGS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEPT54_BILLINGS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:40 PM

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
        fleDEPT54.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDEPT541.Transaction = m_trnTRANS_UPDATE;
        fleDEPT54_SVC2.Transaction = m_trnTRANS_UPDATE;
        fleDEPT54_SVC3.Transaction = m_trnTRANS_UPDATE;
        fleDEPT54_SVC4.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEPT54_BILLINGS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:40 PM

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
            fleDEPT54.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleDEPT541.Dispose();
            fleDEPT54_SVC2.Dispose();
            fleDEPT54_SVC3.Dispose();
            fleDEPT54_SVC4.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEPT54_BILLINGS_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleDEPT54.QTPForMissing())
            {
                // --> GET DEPT54 <--

                fleDEPT54.GetData();
                // --> End GET DEPT54 <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleDEPT54.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleDEPT54.GetDecimalValue("KEY_CLM_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {
                        Sort(CLMDTL_ID.Value);
                    }
                }
            }

            while (Sort(fleDEPT54, fleF002_CLAIMS_MSTR))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT541, SubFileType.Keep, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", KEY_CLM_CLAIM_NBR, X_CLMDTL_FEE_OHIP_1, X_SV_DATE_1, CLMDTL_DIAG_CD,
                "CLMDTL_OMA_CD", fleDEPT54, "CLMHDR_LOC", "CLMHDR_HOSP", CLMHDR_DATE_PERIOD_END, "CLMHDR_PAT_OHIP_ID_OR_CHART");
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:PAT_OHIP_MMYY)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD)    'Parent:DOC_INITS

                SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT54_SVC2, QDesign.NULL(X_SV_NBR2.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", KEY_CLM_CLAIM_NBR, X_CLMDTL_FEE_OHIP_2, X_SV_DATE_2,
                CLMDTL_DIAG_CD, "CLMDTL_OMA_CD", fleDEPT54, "CLMHDR_LOC", "CLMHDR_HOSP", CLMHDR_DATE_PERIOD_END, "CLMHDR_PAT_OHIP_ID_OR_CHART");
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:PAT_OHIP_MMYY)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD)    'Parent:DOC_INITS

                SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT54_SVC3, QDesign.NULL(X_SV_NBR3.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", KEY_CLM_CLAIM_NBR, X_CLMDTL_FEE_OHIP_3, X_SV_DATE_3,
                CLMDTL_DIAG_CD, "CLMDTL_OMA_CD", fleDEPT54, "CLMHDR_LOC", "CLMHDR_HOSP", CLMHDR_DATE_PERIOD_END, "CLMHDR_PAT_OHIP_ID_OR_CHART");
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:PAT_OHIP_MMYY)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD)    'Parent:DOC_INITS

                SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT54_SVC4, QDesign.NULL(X_SV_NBR4.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", KEY_CLM_CLAIM_NBR, X_CLMDTL_FEE_OHIP_4, X_SV_DATE_4,
                CLMDTL_DIAG_CD, "CLMDTL_OMA_CD", fleDEPT54, "CLMHDR_LOC", "CLMHDR_HOSP", CLMHDR_DATE_PERIOD_END, "CLMHDR_PAT_OHIP_ID_OR_CHART");
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:PAT_OHIP_MMYY)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD)    'Parent:DOC_INITS
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



public class DEPT54_BILLINGS_THREE_3 : DEPT54_BILLINGS
{

    public DEPT54_BILLINGS_THREE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleDEPT541 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT541", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEPT542 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT542", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_CLINIC.GetValue += X_CLINIC_GetValue;
        X_DOC.GetValue += X_DOC_GetValue;
        X_CLAIM.GetValue += X_CLAIM_GetValue;
        X_HEALTH_OHIP.GetValue += X_HEALTH_OHIP_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        DOC_INITS.GetValue += DOC_INITS_GetValue;
        DETAIL_LINE.GetValue += DETAIL_LINE_GetValue;
        X_CLMDTL_FEE_OHIP_1.GetValue += X_CLMDTL_FEE_OHIP_1_GetValue;

        fleF040_OMA_FEE_MSTR.InitializeItems += fleF040_OMA_FEE_MSTR_AutomaticItemInitialization;

    }

    #region "Declarations (Variables, Files and Transactions)(DEPT54_BILLINGS_THREE_3)"

    private SqlFileObject fleDEPT541;
    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleF040_OMA_FEE_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DCharacter X_CLINIC = new DCharacter("X_CLINIC", 2);
    private void X_CLINIC_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleDEPT541.GetStringValue("CLMDTL_ID"), 1, 2);


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
            Value= QDesign.Substring(fleDEPT541.GetStringValue("CLMDTL_ID"), 3, 3);


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
    private DCharacter X_CLAIM = new DCharacter("X_CLAIM", 10);
    private void X_CLAIM_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleDEPT541.GetStringValue("CLMDTL_ID"), 1, 10);


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
    private DCharacter X_HEALTH_OHIP = new DCharacter("X_HEALTH_OHIP", 15);
    private void X_HEALTH_OHIP_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR")) != 0)
            {
                CurrentValue = QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR"), 10);
            }
            else
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_ALPHA")  + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_YY"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_MM"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_DD"), 2) + fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_LAST_6");
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

    private DCharacter DOC_INITS = new DCharacter("DOC_INITS", 3);
    private void DOC_INITS_GetValue(ref string Value)
    {
        try
        {
            Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3");
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

    private DCharacter DETAIL_LINE = new DCharacter("DETAIL_LINE", 200);
    private void DETAIL_LINE_GetValue(ref string Value)
    {
        try
        {
            Value = X_CLAIM.Value + COMMA.Value + X_CLINIC.Value + COMMA.Value + X_DOC.Value + COMMA.Value + fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME") + COMMA.Value + DOC_INITS.Value + COMMA.Value + X_HEALTH_OHIP.Value + COMMA.Value + fleDEPT541.GetStringValue("X_SV_DATE_1") + COMMA.Value + "+" + QDesign.ASCII(fleDEPT541.GetDecimalValue("CLMHDR_DATE_PERIOD_END"), 8) + COMMA.Value + X_CLMDTL_FEE_OHIP_1.Value + COMMA.Value + fleDEPT541.GetStringValue("CLMDTL_OMA_CD") + COMMA.Value + fleF040_OMA_FEE_MSTR.GetStringValue("FEE_DESC");
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

    private DCharacter X_CLMDTL_FEE_OHIP_1 = new DCharacter("X_CLMDTL_FEE_OHIP_1", 8);
    private void X_CLMDTL_FEE_OHIP_1_GetValue(ref string Value)
    {
        try
        {
            if (fleDEPT541.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") >= 0)
            {
                Value = "+" + QDesign.ASCII(fleDEPT541.GetDecimalValue("X_CLMDTL_FEE_OHIP_1"), 7);
            }
            else
            {
                Value = QDesign.ASCII(fleDEPT541.GetDecimalValue("X_CLMDTL_FEE_OHIP_1"), 7);
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
    }

    private SqlFileObject fleDEPT542;


    #endregion


    #region "Standard Generated Procedures(DEPT54_BILLINGS_THREE_3)"


    #region "Automatic Item Initialization(DEPT54_BILLINGS_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:53 PM

    //#-----------------------------------------
    //# fleF040_OMA_FEE_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:33:51 PM
    //#-----------------------------------------
    private void fleF040_OMA_FEE_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF040_OMA_FEE_MSTR.set_SetValue("FILLER", !Fixed, fleF010_PAT_MSTR.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(DEPT54_BILLINGS_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:40 PM

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
        fleDEPT541.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDEPT542.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEPT54_BILLINGS_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:40 PM

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
            fleDEPT541.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleF040_OMA_FEE_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleDEPT542.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEPT54_BILLINGS_THREE_3)"


    public void Run()
    {

        try
        {
            Request("THREE_3");

            while (fleDEPT541.QTPForMissing())
            {
                // --> GET DEPT541 <--

                fleDEPT541.GetData();
                // --> End GET DEPT541 <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleDEPT541.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(0, 1)));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert((fleDEPT541.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(1, 2)));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert((fleDEPT541.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(3, 12)));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleDEPT541.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(15, 1)));
                    //Parent:KEY_PAT_MSTR

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F010_PAT_MSTR <--

                    while (fleF040_OMA_FEE_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F040_OMA_FEE_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((fleDEPT541.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(0, 1)));
                        //Parent:FEE_OMA_CD
                        m_strWhere.Append(" AND ").Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((fleDEPT541.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(1, 3)));
                        //Parent:FEE_OMA_CD

                        fleF040_OMA_FEE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F040_OMA_FEE_MSTR <--

                        while (fleF020_DOCTOR_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(QDesign.Substring(fleDEPT541.GetStringValue("CLMDTL_ID"), 3, 3)));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F020_DOCTOR_MSTR <--


                            if (Transaction())
                            {
                                Sort(fleF020_DOCTOR_MSTR.GetSortValue("DOC_NAME"), fleDEPT541.GetSortValue("X_SV_DATE_1"), X_CLAIM.Value);
                            }
                        }
                    }
                }
            }

            while (Sort(fleDEPT541, fleF010_PAT_MSTR, fleF040_OMA_FEE_MSTR, fleF020_DOCTOR_MSTR))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT542, SubFileType.Portable, DETAIL_LINE);
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



