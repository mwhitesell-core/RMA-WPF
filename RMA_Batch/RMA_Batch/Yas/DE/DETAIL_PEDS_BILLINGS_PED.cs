
#region "Screen Comments"

// doc     : detail_peds_billings_ped.qts   
// purpose : create a detail claims report for all claims all clinics for         
// department of pediatrics docs                                        
// clinic 60 prof amount is recorded in 22 for under code T995 but T995
// does not include the #services or what code it is   
// included just clinic 61-65 prof fee and took out T995 
// ******* INCLUDE ADJUSTMENTS *******
// ***  ADJUSTMENT is included for if you select service date otherwise you have to change it for the PED selection
// who     : For Pediatric manager and Vanessa Pauli
// *************************************************************
// Date  Who        Description
// 2006/10/18 Yasemin        cardio_codes_adjust_payment.qts
// 2010/01/07     MC        to extract regular claim detail, adjustment detail 
// 2010/02/04     MC        Regular claim detail will have 0 in clmdtl-adj-nbr and key-clm-adj-nbr
// Adjustment claim detail will have 1 in clmdtl-adj-nbr and key-clm-adj-nbr
// Original adjustment claim detail will have 1 in clmdtl-adj-nbr and 0 in key-clm-adj-nbr
// All Adjustment claim detail will have the same service date as the original claim detail
// but the period date will be different (usaully later than the original claim detail one)
// Note:  It is okay to select regular or adjustment claim details by either service date or PED from the second pass below
// 2010/03/02                   copied from pediatric_total_billing_ped.qts  detail_peds_billings_ped.qts
// change ped and run it every month (prompt for PED) 
// 2012/07/25 yas       add department 76 
// 2015/03/02 yas       add location code 


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class DETAIL_PEDS_BILLINGS_PED : BaseClassControl
{

    private DETAIL_PEDS_BILLINGS_PED m_DETAIL_PEDS_BILLINGS_PED;

    public DETAIL_PEDS_BILLINGS_PED(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public DETAIL_PEDS_BILLINGS_PED(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_DETAIL_PEDS_BILLINGS_PED != null))
        {
            m_DETAIL_PEDS_BILLINGS_PED.CloseTransactionObjects();
            m_DETAIL_PEDS_BILLINGS_PED = null;
        }
    }

    public DETAIL_PEDS_BILLINGS_PED GetDETAIL_PEDS_BILLINGS_PED(int Level)
    {
        if (m_DETAIL_PEDS_BILLINGS_PED == null)
        {
            m_DETAIL_PEDS_BILLINGS_PED = new DETAIL_PEDS_BILLINGS_PED("DETAIL_PEDS_BILLINGS_PED", Level);
        }
        else
        {
            m_DETAIL_PEDS_BILLINGS_PED.ResetValues();
        }
        return m_DETAIL_PEDS_BILLINGS_PED;
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

            DETAIL_PEDS_BILLINGS_PED_ONE_1 ONE_1 = new DETAIL_PEDS_BILLINGS_PED_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            DETAIL_PEDS_BILLINGS_PED_TWO_2 TWO_2 = new DETAIL_PEDS_BILLINGS_PED_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

            DETAIL_PEDS_BILLINGS_PED_THREE_3 THREE_3 = new DETAIL_PEDS_BILLINGS_PED_THREE_3(Name, Level);
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



public class DETAIL_PEDS_BILLINGS_PED_ONE_1 : DETAIL_PEDS_BILLINGS_PED
{

    public DETAIL_PEDS_BILLINGS_PED_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePEDIATRIC_PED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDIATRIC_PED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

        CLMHDR_CLAIM_ID.GetValue += CLMHDR_CLAIM_ID_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(DETAIL_PEDS_BILLINGS_PED_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" ( (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" =  'C' ) AND ");
            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  7 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  70 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  71 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  72 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  73 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  74 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  75 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  76 ))");


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

    private SqlFileObject flePEDIATRIC_PED;


    #endregion


    #region "Standard Generated Procedures(DETAIL_PEDS_BILLINGS_PED_ONE_1)"


    #region "Automatic Item Initialization(DETAIL_PEDS_BILLINGS_PED_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DETAIL_PEDS_BILLINGS_PED_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:05 PM

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
        flePEDIATRIC_PED.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DETAIL_PEDS_BILLINGS_PED_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:05 PM

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
            flePEDIATRIC_PED.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DETAIL_PEDS_BILLINGS_PED_ONE_1)"


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







                    SubFile(ref m_trnTRANS_UPDATE, ref flePEDIATRIC_PED, SubFileType.Keep, CLMHDR_CLAIM_ID, fleF002_CLAIMS_MSTR,  "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_LOC");
                    //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:FEE_OMA_CD)    'Parent:DOC_INITS


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



public class DETAIL_PEDS_BILLINGS_PED_TWO_2 : DETAIL_PEDS_BILLINGS_PED
{

    public DETAIL_PEDS_BILLINGS_PED_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePEDIATRIC_PED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDIATRIC_PED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePEDIATRIC1_PED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDIATRIC1_PED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePEDIATRIC_SVC2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDIATRIC1_PED", "PEDIATRIC_SVC2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePEDIATRIC_SVC3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDIATRIC1_PED", "PEDIATRIC_SVC3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePEDIATRIC_SVC4 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDIATRIC1_PED", "PEDIATRIC_SVC4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_YYYYMM.GetValue += X_YYYYMM_GetValue;
        CONSEC_FLAG.GetValue += CONSEC_FLAG_GetValue;
        X_SV_NBR1.GetValue += X_SV_NBR1_GetValue;
        X_SV_NBR2.GetValue += X_SV_NBR2_GetValue;
        X_SV_NBR3.GetValue += X_SV_NBR3_GetValue;
        X_SV_NBR4.GetValue += X_SV_NBR4_GetValue;
        X_NBR_SVCS.GetValue += X_NBR_SVCS_GetValue;
        X_PROF_FEE.GetValue += X_PROF_FEE_GetValue;
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

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(DETAIL_PEDS_BILLINGS_PED_TWO_2)"

    private SqlFileObject flePEDIATRIC_PED;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (SUBSTRING(CONVERT(varchar(8),  ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_DATE_PERIOD_END")).Append("), 1, 6) = '").Append( X_YYYYMM.Value).Append("' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  '0000' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'ZZZZ' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'PAID' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICM' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MISJ' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MISC' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICV' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MISP' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICB' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MIBR' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MINH' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MHSC' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'NHSC' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'DHSC' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICA' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICC' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICD' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICE' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICF' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICG' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICH' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICJ' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICK' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MICL' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'MOHR' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'AGEP' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'T995' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_ADJ_NBR")).Append(" =  0)");


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
    private DDecimal X_PROF_FEE = new DDecimal("X_PROF_FEE", 6);
    private void X_PROF_FEE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if ((string.Compare(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"), 1, 2), "61") >=0 & string.Compare(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"), 1, 2) , "66")<=0) | (string.Compare(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"), 1, 2), "71") >= 0 & string.Compare(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"), 1, 2) , "75") <=0))
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") - fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_AMT_TECH_BILLED");
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
    private DDecimal X_FEE = new DDecimal("X_FEE", 6);
    private void X_FEE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;

            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = QDesign.Divide(X_PROF_FEE.Value, X_NBR_SVCS.Value);
            }
            else
            {
                CurrentValue = X_PROF_FEE.Value;
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
                CurrentValue = QDesign.Round(X_SV_NBR1.Value * X_FEE.Value, 0);
            }
            else
            {
                CurrentValue = X_PROF_FEE.Value;
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
            Value = QDesign.Round(X_SV_NBR2.Value * X_FEE.Value, 0);


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
            Value = QDesign.Round(X_SV_NBR3.Value * X_FEE.Value);


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
            Value = QDesign.Round(X_SV_NBR4.Value * X_FEE.Value);


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
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) +
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
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + 
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
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + 
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

    private SqlFileObject flePEDIATRIC1_PED;
    private SqlFileObject flePEDIATRIC_SVC2;
    private SqlFileObject flePEDIATRIC_SVC3;
    private SqlFileObject flePEDIATRIC_SVC4;


    #endregion


    #region "Standard Generated Procedures(DETAIL_PEDS_BILLINGS_PED_TWO_2)"


    #region "Automatic Item Initialization(DETAIL_PEDS_BILLINGS_PED_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DETAIL_PEDS_BILLINGS_PED_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:05 PM

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
        flePEDIATRIC_PED.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePEDIATRIC1_PED.Transaction = m_trnTRANS_UPDATE;
        flePEDIATRIC_SVC2.Transaction = m_trnTRANS_UPDATE;
        flePEDIATRIC_SVC3.Transaction = m_trnTRANS_UPDATE;
        flePEDIATRIC_SVC4.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DETAIL_PEDS_BILLINGS_PED_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:05 PM

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
            flePEDIATRIC_PED.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            flePEDIATRIC1_PED.Dispose();
            flePEDIATRIC_SVC2.Dispose();
            flePEDIATRIC_SVC3.Dispose();
            flePEDIATRIC_SVC4.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DETAIL_PEDS_BILLINGS_PED_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (flePEDIATRIC_PED.QTPForMissing())
            {
                // --> GET PEDIATRIC_PED <--

                flePEDIATRIC_PED.GetData();
                // --> End GET PEDIATRIC_PED <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(flePEDIATRIC_PED.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((flePEDIATRIC_PED.GetDecimalValue("KEY_CLM_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {
                        SubFile(ref m_trnTRANS_UPDATE, ref flePEDIATRIC1_PED, SubFileType.Keep, CLMDTL_ID, fleF002_CLAIMS_MSTR,  "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_1, X_SV_DATE_1, X_SV_NBR1,
                        "CLMDTL_DIAG_CD", "CLMDTL_OMA_CD", flePEDIATRIC_PED, "CLMHDR_CLAIM_ID", "CLMHDR_LOC");
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:FEE_OMA_CD)    'Parent:DOC_INITS

                        SubFile(ref m_trnTRANS_UPDATE, ref flePEDIATRIC_SVC2, QDesign.NULL(X_SV_NBR2.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_2, X_SV_DATE_2,
                        X_SV_NBR2, "CLMDTL_DIAG_CD", "CLMDTL_OMA_CD", flePEDIATRIC_PED, "CLMHDR_CLAIM_ID", "CLMHDR_LOC");
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:FEE_OMA_CD)    'Parent:DOC_INITS

                        SubFile(ref m_trnTRANS_UPDATE, ref flePEDIATRIC_SVC3, QDesign.NULL(X_SV_NBR3.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_3, X_SV_DATE_3,
                        X_SV_NBR3, "CLMDTL_DIAG_CD", "CLMDTL_OMA_CD", flePEDIATRIC_PED, "CLMHDR_CLAIM_ID", "CLMHDR_LOC");
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:FEE_OMA_CD)    'Parent:DOC_INITS

                        SubFile(ref m_trnTRANS_UPDATE, ref flePEDIATRIC_SVC4, QDesign.NULL(X_SV_NBR4.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_4, X_SV_DATE_4,
                        X_SV_NBR4, "CLMDTL_DIAG_CD", "CLMDTL_OMA_CD", flePEDIATRIC_PED, "CLMHDR_CLAIM_ID", "CLMHDR_LOC");
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:FEE_OMA_CD)    'Parent:DOC_INITS


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



public class DETAIL_PEDS_BILLINGS_PED_THREE_3 : DETAIL_PEDS_BILLINGS_PED
{

    public DETAIL_PEDS_BILLINGS_PED_THREE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePEDIATRIC1_PED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDIATRIC1_PED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF091_DIAG_CODES_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F091_DIAG_CODES_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePEDIATRIC2_PED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDIATRIC2_PED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_CLINIC.GetValue += X_CLINIC_GetValue;
        X_DOC.GetValue += X_DOC_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        DOC_INITS.GetValue += DOC_INITS_GetValue;
        DETAIL_LINE.GetValue += DETAIL_LINE_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(DETAIL_PEDS_BILLINGS_PED_THREE_3)"

    private SqlFileObject flePEDIATRIC1_PED;
    private SqlFileObject fleF040_OMA_FEE_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF091_DIAG_CODES_MSTR;
    private DCharacter X_CLINIC = new DCharacter("X_CLINIC", 2);
    private void X_CLINIC_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(flePEDIATRIC1_PED.GetStringValue("CLMDTL_ID"), 1, 2);


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
            Value= QDesign.Substring(flePEDIATRIC1_PED.GetStringValue("CLMDTL_ID"), 3, 3);


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

    private DCharacter DETAIL_LINE = new DCharacter("DETAIL_LINE", 120);
    private void DETAIL_LINE_GetValue(ref string Value)
    {
        try
        {
            Value = X_CLINIC.Value + COMMA.Value + X_DOC.Value + COMMA.Value + fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME") + COMMA.Value + DOC_INITS.Value + COMMA.Value + QDesign.ASCII(flePEDIATRIC1_PED.GetDecimalValue("X_SV_DATE_1")) + COMMA.Value +  string.Format("{0:+000000#;-0000000#;+0000000}", QDesign.NConvert(flePEDIATRIC1_PED.GetStringValue("X_CLMDTL_FEE_OHIP_1"))) + COMMA.Value + string.Format("{0:+0#;-0#;+00}", QDesign.NConvert(flePEDIATRIC1_PED.GetStringValue("X_SV_NBR1"))) + COMMA.Value + flePEDIATRIC1_PED.GetStringValue("CLMDTL_OMA_CD") + COMMA.Value + fleF040_OMA_FEE_MSTR.GetStringValue("FEE_DESC").PadRight(48, ' ') + COMMA.Value + flePEDIATRIC1_PED.GetStringValue("CLMHDR_LOC");
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

    private SqlFileObject flePEDIATRIC2_PED;


    #endregion


    #region "Standard Generated Procedures(DETAIL_PEDS_BILLINGS_PED_THREE_3)"


    #region "Automatic Item Initialization(DETAIL_PEDS_BILLINGS_PED_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DETAIL_PEDS_BILLINGS_PED_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:05 PM

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
        flePEDIATRIC1_PED.Transaction = m_trnTRANS_UPDATE;
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF091_DIAG_CODES_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePEDIATRIC2_PED.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DETAIL_PEDS_BILLINGS_PED_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:05 PM

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
            flePEDIATRIC1_PED.Dispose();
            fleF040_OMA_FEE_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF091_DIAG_CODES_MSTR.Dispose();
            flePEDIATRIC2_PED.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DETAIL_PEDS_BILLINGS_PED_THREE_3)"


    public void Run()
    {

        try
        {
            Request("THREE_3");

            while (flePEDIATRIC1_PED.QTPForMissing())
            {
                // --> GET PEDIATRIC1_PED <--

                flePEDIATRIC1_PED.GetData();
                // --> End GET PEDIATRIC1_PED <--

                while (fleF040_OMA_FEE_MSTR.QTPForMissing("1"))
                {
                    // --> GET F040_OMA_FEE_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((flePEDIATRIC1_PED.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(0, 1)));
                    //Parent:FEE_OMA_CD
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((flePEDIATRIC1_PED.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(1, 3)));
                    //Parent:FEE_OMA_CD

                    fleF040_OMA_FEE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F040_OMA_FEE_MSTR <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(flePEDIATRIC1_PED.GetStringValue("CLMDTL_ID"), 3, 3)));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF091_DIAG_CODES_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F091_DIAG_CODES_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF091_DIAG_CODES_MSTR.ElementOwner("DIAG_CD")).Append(" = ");
                            m_strWhere.Append(Common.StringToField((QDesign.ASCII(flePEDIATRIC1_PED.GetDecimalValue("CLMDTL_DIAG_CD"), 3))));

                            fleF091_DIAG_CODES_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F091_DIAG_CODES_MSTR <--

                            if (Transaction())
                            {
                                Sort(flePEDIATRIC1_PED.GetSortValue("CLMDTL_ID"));
                            }
                        }
                    }
                }
            }

            while (Sort(flePEDIATRIC1_PED, fleF040_OMA_FEE_MSTR, fleF020_DOCTOR_MSTR, fleF091_DIAG_CODES_MSTR))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref flePEDIATRIC2_PED, SubFileType.Portable, DETAIL_LINE);
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




