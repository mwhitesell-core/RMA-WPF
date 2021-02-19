
#region "Screen Comments"

// doc     : emerg_codes_4142.qts
// purpose : for department 41/42 and 44 report total amount/ total number of claims/ 6 columns                      
// column 1= total number of claims for codes G521, G522  and G523                               
// column 2= total number of claims for G391 and G395                                                       
// column 3= total number of claims for H102     
// column 4= total number of claims for H132     
// column 5= total number of claims for H152     
// column 6= total number of claims for H122     
// who     : Dr. Crossley and Dr. Jowett
// *************************************************************
// 2015/09/01      : They want to change the columns
// column 1= total number of claims for codes G521, G522  and G523
// column 2= total number of claims for G391 and G395
// column 3= total number of claims for H102
// column 4= total number of claims for H132
// column 5= total number of claims for H152
// column 6= total number of claims for H122
// column 7= total number of claims for H104
// column 8= total number of claims for H134
// column 9= total number of claims for H154
// column10= total number of claims for H124
// column11= total number of claims for column 1 to 10             
// column12= total fee for columns 1 to 10             
// column13= total number of claims all codes         
// column14= total fee all codes                         
// column15= total AGEP from f119 history for January to December 2014 (ep nbr 201307 to 201406)
// modify for new year every year 
// 20160526          Jan 1, 2015 to Dec 31, 2015


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class EMERG_CODES_4142 : BaseClassControl
{

    private EMERG_CODES_4142 m_EMERG_CODES_4142;

    public EMERG_CODES_4142(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public EMERG_CODES_4142(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_EMERG_CODES_4142 != null))
        {
            m_EMERG_CODES_4142.CloseTransactionObjects();
            m_EMERG_CODES_4142 = null;
        }
    }

    public EMERG_CODES_4142 GetEMERG_CODES_4142(int Level)
    {
        if (m_EMERG_CODES_4142 == null)
        {
            m_EMERG_CODES_4142 = new EMERG_CODES_4142("EMERG_CODES_4142", Level);
        }
        else
        {
            m_EMERG_CODES_4142.ResetValues();
        }
        return m_EMERG_CODES_4142;
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

            EMERG_CODES_4142_ONE_1 ONE_1 = new EMERG_CODES_4142_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            EMERG_CODES_4142_TWO_2 TWO_2 = new EMERG_CODES_4142_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

            EMERG_CODES_4142_THREE_3 THREE_3 = new EMERG_CODES_4142_THREE_3(Name, Level);
            THREE_3.Run();
            THREE_3.Dispose();
            THREE_3 = null;

            EMERG_CODES_4142_FOUR_4 FOUR_4 = new EMERG_CODES_4142_FOUR_4(Name, Level);
            FOUR_4.Run();
            FOUR_4.Dispose();
            FOUR_4 = null;

            EMERG_CODES_4142_FIVE_5 FIVE_5 = new EMERG_CODES_4142_FIVE_5(Name, Level);
            FIVE_5.Run();
            FIVE_5.Dispose();
            FIVE_5 = null;

            EMERG_CODES_4142_SIX_6 SIX_6 = new EMERG_CODES_4142_SIX_6(Name, Level);
            SIX_6.Run();
            SIX_6.Dispose();
            SIX_6 = null;

            EMERG_CODES_4142_SEVEN_7 SEVEN_7 = new EMERG_CODES_4142_SEVEN_7(Name, Level);
            SEVEN_7.Run();
            SEVEN_7.Dispose();
            SEVEN_7 = null;

            EMERG_CODES_4142_EIGHT_8 EIGHT_8 = new EMERG_CODES_4142_EIGHT_8(Name, Level);
            EIGHT_8.Run();
            EIGHT_8.Dispose();
            EIGHT_8 = null;

            EMERG_CODES_4142_NINE_9 NINE_9 = new EMERG_CODES_4142_NINE_9(Name, Level);
            NINE_9.Run();
            NINE_9.Dispose();
            NINE_9 = null;

            EMERG_CODES_4142_TEN_10 TEN_10 = new EMERG_CODES_4142_TEN_10(Name, Level);
            TEN_10.Run();
            TEN_10.Dispose();
            TEN_10 = null;

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



public class EMERG_CODES_4142_ONE_1 : EMERG_CODES_4142
{

    public EMERG_CODES_4142_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCODES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERG_CODES_4142_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" =  'C' AND ");
            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  41 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  42 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  44 ) AND ");
            strSQL.Append("  ").Append(GetWhereClauseString(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_SERV_DATE"), ">=", 20150101)).Append(" AND ");
            strSQL.Append("  ").Append(GetWhereClauseString(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_SERV_DATE"), "<=", 20151231)).Append(")");


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






    private SqlFileObject fleCODES;


    #endregion


    #region "Standard Generated Procedures(EMERG_CODES_4142_ONE_1)"


    #region "Automatic Item Initialization(EMERG_CODES_4142_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERG_CODES_4142_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:18 PM

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
        fleCODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERG_CODES_4142_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:18 PM

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
            fleCODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERG_CODES_4142_ONE_1)"


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





                    SubFile(ref m_trnTRANS_UPDATE, ref fleCODES, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMHDR_CLAIM_ID", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_SERV_DATE", "CLMHDR_AGENT_CD", "CLMHDR_DOC_DEPT",
                    "CLMHDR_TOT_CLAIM_AR_OHIP");
                    //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R


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



public class EMERG_CODES_4142_TWO_2 : EMERG_CODES_4142
{

    public EMERG_CODES_4142_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCODES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCODES1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleCODES_SVC2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES1", "CODES_SVC2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleCODES_SVC3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES1", "CODES_SVC3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleCODES_SVC4 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES1", "CODES_SVC4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

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

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERG_CODES_4142_TWO_2)"

    private SqlFileObject fleCODES;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_SV_YY")).Append(" >=  '2015' AND ");
            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_SV_MM")).Append(" >=  '01' AND ");
            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_SV_DD")).Append(" >=  ('01' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_SV_DATE")).Append(" <=  '20151231' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  '0000' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'ZZZZ' AND ");
            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'G521' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'G522' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'G523' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'G391' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'G395' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'H102' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'H132' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'H152' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'H122' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'H104' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'H134' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'H154' OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" =  'H124' ) AND ");
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

    private DCharacter CONSEC_FLAG = new DCharacter("CONSEC_FLAG", 1);
    private void CONSEC_FLAG_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 1, 3)) != "0OP" & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 1, 3)) != "0MR" & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 1, 3)) != "0BI" & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 1, 3)) != "0" & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 1, 3)) != " 00" & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 1, 3)) != "000" & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 1, 3)) != QDesign.NULL("   "))
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
                CurrentValue = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_CONSEC_DATES"), 9), 1, 1));
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
                CurrentValue = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_CONSEC_DATES"), 9), 4, 1));
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
                CurrentValue = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_CONSEC_DATES"), 9), 7, 1));
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
            decimal CurrentValue = 0m;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / X_NBR_SVCS.Value;
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
                CurrentValue = X_FEE.Value;
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
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2);
                //Parent:CLMDTL_SV_DATE    'Parent:CLMDTL_CONSEC_DATES_R
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
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 5, 2);
                //Parent:CLMDTL_SV_DATE    'Parent:CLMDTL_CONSEC_DATES_R
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
                CurrentValue= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 8, 2);
                //Parent:CLMDTL_SV_DATE    'Parent:CLMDTL_CONSEC_DATES_R
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



    private SqlFileObject fleCODES1;



    private SqlFileObject fleCODES_SVC2;



    private SqlFileObject fleCODES_SVC3;



    private SqlFileObject fleCODES_SVC4;


    #endregion


    #region "Standard Generated Procedures(EMERG_CODES_4142_TWO_2)"


    #region "Automatic Item Initialization(EMERG_CODES_4142_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERG_CODES_4142_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:19 PM

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
        fleCODES.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleCODES1.Transaction = m_trnTRANS_UPDATE;
        fleCODES_SVC2.Transaction = m_trnTRANS_UPDATE;
        fleCODES_SVC3.Transaction = m_trnTRANS_UPDATE;
        fleCODES_SVC4.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERG_CODES_4142_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:19 PM

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
            fleCODES.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleCODES1.Dispose();
            fleCODES_SVC2.Dispose();
            fleCODES_SVC3.Dispose();
            fleCODES_SVC4.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERG_CODES_4142_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleCODES.QTPForMissing())
            {
                // --> GET CODES <--

                fleCODES.GetData();
                // --> End GET CODES <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_CLAIMS_MSTR.GetDecimalValue("KEY_CLM_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {





                        SubFile(ref m_trnTRANS_UPDATE, ref fleCODES1, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMDTL_ID", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", fleCODES, X_CLMDTL_FEE_OHIP_1, X_SV_DATE_1,
                        fleF002_CLAIMS_MSTR, "CLMDTL_OMA_CD");
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R






                        SubFile(ref m_trnTRANS_UPDATE, ref fleCODES_SVC2, QDesign.NULL(X_SV_NBR2.Value) != 0, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMDTL_ID", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", fleCODES, X_CLMDTL_FEE_OHIP_2,
                        X_SV_DATE_2, fleF002_CLAIMS_MSTR, "CLMDTL_OMA_CD");
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R






                        SubFile(ref m_trnTRANS_UPDATE, ref fleCODES_SVC3, QDesign.NULL(X_SV_NBR3.Value) != 0, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMDTL_ID", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", fleCODES, X_CLMDTL_FEE_OHIP_3,
                        X_SV_DATE_3, fleF002_CLAIMS_MSTR, "CLMDTL_OMA_CD");
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R






                        SubFile(ref m_trnTRANS_UPDATE, ref fleCODES_SVC4, QDesign.NULL(X_SV_NBR4.Value) != 0, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMDTL_ID", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", fleCODES, X_CLMDTL_FEE_OHIP_4,
                        X_SV_DATE_4, fleF002_CLAIMS_MSTR, "CLMDTL_OMA_CD");
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R


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



public class EMERG_CODES_4142_THREE_3 : EMERG_CODES_4142
{

    public EMERG_CODES_4142_THREE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCODES1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CODE1 = new CoreDecimal("X_CODE1", 7, this);
        X_CODE2 = new CoreDecimal("X_CODE2", 7, this);
        X_CODE3 = new CoreDecimal("X_CODE3", 7, this);
        X_CODE4 = new CoreDecimal("X_CODE4", 7, this);
        X_CODE5 = new CoreDecimal("X_CODE5", 7, this);
        X_CODE6 = new CoreDecimal("X_CODE6", 7, this);
        X_CODE7 = new CoreDecimal("X_CODE7", 7, this);
        X_CODE8 = new CoreDecimal("X_CODE8", 7, this);
        X_CODE9 = new CoreDecimal("X_CODE9", 7, this);
        X_CODE10 = new CoreDecimal("X_CODE10", 7, this);
        X_FEE_SELECTED = new CoreDecimal("X_FEE_SELECTED", 9, this);
        fleCODES2_4142 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES2_4142", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_DOC.GetValue += X_DOC_GetValue;
        X_CODE11.GetValue += X_CODE11_GetValue;
        X_CLM_COUNT.GetValue += X_CLM_COUNT_GetValue;
        X_FEE.GetValue += X_FEE_GetValue;
        X_AGEP.GetValue += X_AGEP_GetValue;

        fleCODES1.SelectIf += fleCODES1_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERG_CODES_4142_THREE_3)"

    private SqlFileObject fleCODES1;


    private void fleCODES1_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" ( (    ").Append(fleCODES1.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  41 OR ");
            strSQL.Append("    ").Append(fleCODES1.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  42 ))");


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
    private DCharacter X_DOC = new DCharacter("X_DOC", 3);
    private void X_DOC_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleCODES1.GetStringValue("CLMDTL_ID"), 3, 3);


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
    private CoreDecimal X_CODE1;
    private CoreDecimal X_CODE2;
    private CoreDecimal X_CODE3;
    private CoreDecimal X_CODE4;
    private CoreDecimal X_CODE5;
    private CoreDecimal X_CODE6;
    private CoreDecimal X_CODE7;
    private CoreDecimal X_CODE8;
    private CoreDecimal X_CODE9;
    private CoreDecimal X_CODE10;
    private DDecimal X_CODE11 = new DDecimal("X_CODE11", 7);
    private void X_CODE11_GetValue(ref decimal Value)
    {

        try
        {
            Value = X_CODE1.Value + X_CODE2.Value + X_CODE3.Value + X_CODE4.Value + X_CODE5.Value + X_CODE6.Value + X_CODE7.Value + X_CODE8.Value + X_CODE9.Value + X_CODE10.Value;


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
    private CoreDecimal X_FEE_SELECTED;
    private DDecimal X_CLM_COUNT = new DDecimal("X_CLM_COUNT", 7);
    private void X_CLM_COUNT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_FEE = new DDecimal("X_FEE", 9);
    private void X_FEE_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_AGEP = new DDecimal("X_AGEP", 9);
    private void X_AGEP_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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





    private SqlFileObject fleCODES2_4142;


    #endregion


    #region "Standard Generated Procedures(EMERG_CODES_4142_THREE_3)"


    #region "Automatic Item Initialization(EMERG_CODES_4142_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERG_CODES_4142_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:19 PM

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
        fleCODES1.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleCODES2_4142.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERG_CODES_4142_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:19 PM

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
            fleCODES1.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleCODES2_4142.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERG_CODES_4142_THREE_3)"


    public void Run()
    {

        try
        {
            Request("THREE_3");

            while (fleCODES1.QTPForMissing())
            {
                // --> GET CODES1 <--

                fleCODES1.GetData();
                // --> End GET CODES1 <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleCODES1.GetStringValue("CLMDTL_ID"), 3, 3)));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                        Sort(X_DOC.Value, fleCODES1.GetSortValue("KEY_CLM_BATCH_NBR"), fleCODES1.GetSortValue("KEY_CLM_CLAIM_NBR"));



                    }

                }

            }

            while (Sort(fleCODES1, fleF020_DOCTOR_MSTR))
            {
                if ((QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G521" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G522" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G523"))
                {
                    X_CODE1.Value = X_CODE1.Value + 1;
                }
                if ((QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G391" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G395"))
                {
                    X_CODE2.Value = X_CODE2.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H102")
                {
                    X_CODE3.Value = X_CODE3.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H132")
                {
                    X_CODE4.Value = X_CODE4.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H152")
                {
                    X_CODE5.Value = X_CODE5.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H122")
                {
                    X_CODE6.Value = X_CODE6.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H104")
                {
                    X_CODE7.Value = X_CODE7.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H134")
                {
                    X_CODE8.Value = X_CODE8.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H154")
                {
                    X_CODE9.Value = X_CODE9.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H124")
                {
                    X_CODE10.Value = X_CODE10.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G521" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G522" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G523" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G391" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G395" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H102" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H132" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H152" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H122" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H104" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H134" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H154" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H124")
                {
                    X_FEE_SELECTED.Value = X_FEE_SELECTED.Value + fleCODES1.GetDecimalValue("X_CLMDTL_FEE_OHIP_1");
                }






                SubFile(ref m_trnTRANS_UPDATE, ref fleCODES2_4142, At(X_DOC), SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_DEPT", X_DOC, "DOC_NAME", X_CODE1, X_CODE2,
                X_CODE3, X_CODE4, X_CODE5, X_CODE6, X_CODE7, X_CODE8, X_CODE9, X_CODE10, X_CODE11, X_FEE_SELECTED,
                X_CLM_COUNT, X_FEE, X_AGEP);
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R


                Reset(ref X_CODE1, At(X_DOC));
                Reset(ref X_CODE2, At(X_DOC));
                Reset(ref X_CODE3, At(X_DOC));
                Reset(ref X_CODE4, At(X_DOC));
                Reset(ref X_CODE5, At(X_DOC));
                Reset(ref X_CODE6, At(X_DOC));
                Reset(ref X_CODE7, At(X_DOC));
                Reset(ref X_CODE8, At(X_DOC));
                Reset(ref X_CODE9, At(X_DOC));
                Reset(ref X_CODE10, At(X_DOC));
                Reset(ref X_FEE_SELECTED, At(X_DOC));

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



public class EMERG_CODES_4142_FOUR_4 : EMERG_CODES_4142
{

    public EMERG_CODES_4142_FOUR_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCODES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CLM_COUNT = new CoreDecimal("X_CLM_COUNT", 7, this);
        X_FEE = new CoreDecimal("X_FEE", 9, this);
        fleCODES2_4142 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES2_4142", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_DOC.GetValue += X_DOC_GetValue;
        X_CODE1.GetValue += X_CODE1_GetValue;
        X_CODE2.GetValue += X_CODE2_GetValue;
        X_CODE3.GetValue += X_CODE3_GetValue;
        X_CODE4.GetValue += X_CODE4_GetValue;
        X_CODE5.GetValue += X_CODE5_GetValue;
        X_CODE6.GetValue += X_CODE6_GetValue;
        X_CODE7.GetValue += X_CODE7_GetValue;
        X_CODE8.GetValue += X_CODE8_GetValue;
        X_CODE9.GetValue += X_CODE9_GetValue;
        X_CODE10.GetValue += X_CODE10_GetValue;
        X_CODE11.GetValue += X_CODE11_GetValue;
        X_FEE_SELECTED.GetValue += X_FEE_SELECTED_GetValue;
        X_AGEP.GetValue += X_AGEP_GetValue;

        fleCODES.SelectIf += fleCODES_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERG_CODES_4142_FOUR_4)"

    private SqlFileObject fleCODES;


    private void fleCODES_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" ( (    ").Append(fleCODES.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  41 OR ");
            strSQL.Append("    ").Append(fleCODES.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  42 ))");


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
    private DCharacter X_DOC = new DCharacter("X_DOC", 3);
    private void X_DOC_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleCODES.GetStringValue("KEY_CLM_BATCH_NBR"), 3, 3);


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
    private DDecimal X_CODE1 = new DDecimal("X_CODE1", 7);
    private void X_CODE1_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE2 = new DDecimal("X_CODE2", 7);
    private void X_CODE2_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE3 = new DDecimal("X_CODE3", 7);
    private void X_CODE3_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE4 = new DDecimal("X_CODE4", 7);
    private void X_CODE4_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE5 = new DDecimal("X_CODE5", 7);
    private void X_CODE5_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE6 = new DDecimal("X_CODE6", 7);
    private void X_CODE6_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE7 = new DDecimal("X_CODE7", 7);
    private void X_CODE7_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE8 = new DDecimal("X_CODE8", 7);
    private void X_CODE8_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE9 = new DDecimal("X_CODE9", 7);
    private void X_CODE9_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE10 = new DDecimal("X_CODE10", 7);
    private void X_CODE10_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE11 = new DDecimal("X_CODE11", 7);
    private void X_CODE11_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_FEE_SELECTED = new DDecimal("X_FEE_SELECTED", 9);
    private void X_FEE_SELECTED_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private CoreDecimal X_CLM_COUNT;
    private CoreDecimal X_FEE;
    private DDecimal X_AGEP = new DDecimal("X_AGEP", 9);
    private void X_AGEP_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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





    private SqlFileObject fleCODES2_4142;


    #endregion


    #region "Standard Generated Procedures(EMERG_CODES_4142_FOUR_4)"


    #region "Automatic Item Initialization(EMERG_CODES_4142_FOUR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERG_CODES_4142_FOUR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:19 PM

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
        fleCODES.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleCODES2_4142.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERG_CODES_4142_FOUR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:19 PM

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
            fleCODES.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleCODES2_4142.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERG_CODES_4142_FOUR_4)"


    public void Run()
    {

        try
        {
            Request("FOUR_4");

            while (fleCODES.QTPForMissing())
            {
                // --> GET CODES <--

                fleCODES.GetData();
                // --> End GET CODES <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleCODES.GetStringValue("KEY_CLM_BATCH_NBR"), 3, 3)));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                        Sort(X_DOC.Value, fleCODES.GetSortValue("KEY_CLM_BATCH_NBR"), fleCODES.GetSortValue("KEY_CLM_CLAIM_NBR"));



                    }

                }

            }

            while (Sort(fleCODES, fleF020_DOCTOR_MSTR))
            {
                if (At(X_DOC) || fleCODES.At("KEY_CLM_BATCH_NBR") || fleCODES.At("KEY_CLM_CLAIM_NBR"))
                {
                    X_CLM_COUNT.Value = X_CLM_COUNT.Value + 1;
                }
                if (At(X_DOC) || fleCODES.At("KEY_CLM_BATCH_NBR") || fleCODES.At("KEY_CLM_CLAIM_NBR"))
                {
                    X_FEE.Value = X_FEE.Value + fleCODES.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
                }






                SubFile(ref m_trnTRANS_UPDATE, ref fleCODES2_4142, At(X_DOC), SubFileType.Keep, fleF020_DOCTOR_MSTR, X_CODE1, X_CODE2, X_CODE3, X_CODE4, X_CODE5,
                X_CODE6, X_CODE7, X_CODE8, X_CODE9, X_CODE10, X_CODE11, X_FEE_SELECTED, X_CLM_COUNT, X_FEE, X_AGEP);
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R


                Reset(ref X_CLM_COUNT, At(X_DOC));
                Reset(ref X_FEE, At(X_DOC));

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
            EndRequest("FOUR_4");

        }

    }




    #endregion


}
//FOUR_4



public class EMERG_CODES_4142_FIVE_5 : EMERG_CODES_4142
{

    public EMERG_CODES_4142_FIVE_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_AGEP = new CoreDecimal("X_AGEP", 9, this);
        fleCODES2_4142 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES2_4142", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD_HISTORY.Choose += fleF119_DOCTOR_YTD_HISTORY_Choose;
        X_CODE1.GetValue += X_CODE1_GetValue;
        X_CODE2.GetValue += X_CODE2_GetValue;
        X_CODE3.GetValue += X_CODE3_GetValue;
        X_CODE4.GetValue += X_CODE4_GetValue;
        X_CODE5.GetValue += X_CODE5_GetValue;
        X_CODE6.GetValue += X_CODE6_GetValue;
        X_CODE7.GetValue += X_CODE7_GetValue;
        X_CODE8.GetValue += X_CODE8_GetValue;
        X_CODE9.GetValue += X_CODE9_GetValue;
        X_CODE10.GetValue += X_CODE10_GetValue;
        X_CODE11.GetValue += X_CODE11_GetValue;
        X_FEE_SELECTED.GetValue += X_FEE_SELECTED_GetValue;
        X_CLM_COUNT.GetValue += X_CLM_COUNT_GetValue;
        X_FEE.GetValue += X_FEE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERG_CODES_4142_FIVE_5)"

    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;
    private SqlFileObject fleF020_DOCTOR_MSTR;

    private void fleF119_DOCTOR_YTD_HISTORY_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("EP_NBR")).Append(" = ");
            strSQL.Append(201407);


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


    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "AGEP" & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 41 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 42))
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

    private DDecimal X_CODE1 = new DDecimal("X_CODE1", 7);
    private void X_CODE1_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE2 = new DDecimal("X_CODE2", 7);
    private void X_CODE2_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE3 = new DDecimal("X_CODE3", 7);
    private void X_CODE3_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE4 = new DDecimal("X_CODE4", 7);
    private void X_CODE4_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE5 = new DDecimal("X_CODE5", 7);
    private void X_CODE5_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE6 = new DDecimal("X_CODE6", 7);
    private void X_CODE6_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE7 = new DDecimal("X_CODE7", 7);
    private void X_CODE7_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE8 = new DDecimal("X_CODE8", 7);
    private void X_CODE8_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE9 = new DDecimal("X_CODE9", 7);
    private void X_CODE9_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE10 = new DDecimal("X_CODE10", 7);
    private void X_CODE10_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE11 = new DDecimal("X_CODE11", 7);
    private void X_CODE11_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_FEE_SELECTED = new DDecimal("X_FEE_SELECTED", 9);
    private void X_FEE_SELECTED_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CLM_COUNT = new DDecimal("X_CLM_COUNT", 7);
    private void X_CLM_COUNT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_FEE = new DDecimal("X_FEE", 9);
    private void X_FEE_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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

    private CoreDecimal X_AGEP;




    private SqlFileObject fleCODES2_4142;


    #endregion


    #region "Standard Generated Procedures(EMERG_CODES_4142_FIVE_5)"


    #region "Automatic Item Initialization(EMERG_CODES_4142_FIVE_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERG_CODES_4142_FIVE_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:20 PM

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
        fleCODES2_4142.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERG_CODES_4142_FIVE_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:20 PM

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
            fleCODES2_4142.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERG_CODES_4142_FIVE_5)"


    public void Run()
    {

        try
        {
            Request("FIVE_5");

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

                         if (Select_If())
                        {

                            Sort(fleF119_DOCTOR_YTD_HISTORY.GetSortValue("DOC_NBR"));



                        }

                    }

                }

            }

            while (Sort(fleF119_DOCTOR_YTD_HISTORY, fleF020_DOCTOR_MSTR))
            {
                X_AGEP.Value = X_AGEP.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_MTD");






                SubFile(ref m_trnTRANS_UPDATE, ref fleCODES2_4142, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"), SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_DEPT", fleF119_DOCTOR_YTD_HISTORY, "DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_NAME",
                X_CODE1, X_CODE2, X_CODE3, X_CODE4, X_CODE5, X_CODE6, X_CODE7, X_CODE8, X_CODE9, X_CODE10,
                X_CODE11, X_FEE_SELECTED, X_CLM_COUNT, X_FEE, X_AGEP);
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R


                Reset(ref X_AGEP, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));

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
            EndRequest("FIVE_5");

        }

    }




    #endregion


}
//FIVE_5



public class EMERG_CODES_4142_SIX_6 : EMERG_CODES_4142
{

    public EMERG_CODES_4142_SIX_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCODES2_4142 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES2_4142", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COL1 = new CoreDecimal("X_COL1", 7, this);
        X_COL2 = new CoreDecimal("X_COL2", 7, this);
        X_COL3 = new CoreDecimal("X_COL3", 7, this);
        X_COL4 = new CoreDecimal("X_COL4", 7, this);
        X_COL5 = new CoreDecimal("X_COL5", 7, this);
        X_COL6 = new CoreDecimal("X_COL6", 7, this);
        X_COL7 = new CoreDecimal("X_COL7", 7, this);
        X_COL8 = new CoreDecimal("X_COL8", 7, this);
        X_COL9 = new CoreDecimal("X_COL9", 7, this);
        X_COL10 = new CoreDecimal("X_COL10", 7, this);
        X_COL11 = new CoreDecimal("X_COL11", 7, this);
        X_COL12 = new CoreDecimal("X_COL12", 9, this);
        X_COL13 = new CoreDecimal("X_COL13", 7, this);
        X_COL14 = new CoreDecimal("X_COL14", 9, this);
        X_COL15 = new CoreDecimal("X_COL15", 9, this);
        fleCODES2_4142_ALL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES2_4142_ALL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERG_CODES_4142_SIX_6)"

    private SqlFileObject fleCODES2_4142;
    private CoreDecimal X_COL1;
    private CoreDecimal X_COL2;
    private CoreDecimal X_COL3;
    private CoreDecimal X_COL4;
    private CoreDecimal X_COL5;
    private CoreDecimal X_COL6;
    private CoreDecimal X_COL7;
    private CoreDecimal X_COL8;
    private CoreDecimal X_COL9;
    private CoreDecimal X_COL10;
    private CoreDecimal X_COL11;
    private CoreDecimal X_COL12;
    private CoreDecimal X_COL13;
    private CoreDecimal X_COL14;
    private CoreDecimal X_COL15;
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





    private SqlFileObject fleCODES2_4142_ALL;


    #endregion


    #region "Standard Generated Procedures(EMERG_CODES_4142_SIX_6)"


    #region "Automatic Item Initialization(EMERG_CODES_4142_SIX_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERG_CODES_4142_SIX_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:20 PM

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
        fleCODES2_4142.Transaction = m_trnTRANS_UPDATE;
        fleCODES2_4142_ALL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERG_CODES_4142_SIX_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:20 PM

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
            fleCODES2_4142.Dispose();
            fleCODES2_4142_ALL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERG_CODES_4142_SIX_6)"


    public void Run()
    {

        try
        {
            Request("SIX_6");

            while (fleCODES2_4142.QTPForMissing())
            {
                // --> GET CODES2_4142 <--

                fleCODES2_4142.GetData();
                // --> End GET CODES2_4142 <--


                if (Transaction())
                {

                    Sort(fleCODES2_4142.GetSortValue("X_DOC"));



                }

            }

            while (Sort(fleCODES2_4142))
            {
                X_COL1.Value = X_COL1.Value + fleCODES2_4142.GetDecimalValue("X_CODE1");
                X_COL2.Value = X_COL2.Value + fleCODES2_4142.GetDecimalValue("X_CODE2");
                X_COL3.Value = X_COL3.Value + fleCODES2_4142.GetDecimalValue("X_CODE3");
                X_COL4.Value = X_COL4.Value + fleCODES2_4142.GetDecimalValue("X_CODE4");
                X_COL5.Value = X_COL5.Value + fleCODES2_4142.GetDecimalValue("X_CODE5");
                X_COL6.Value = X_COL6.Value + fleCODES2_4142.GetDecimalValue("X_CODE6");
                X_COL7.Value = X_COL7.Value + fleCODES2_4142.GetDecimalValue("X_CODE7");
                X_COL8.Value = X_COL8.Value + fleCODES2_4142.GetDecimalValue("X_CODE8");
                X_COL9.Value = X_COL9.Value + fleCODES2_4142.GetDecimalValue("X_CODE9");
                X_COL10.Value = X_COL10.Value + fleCODES2_4142.GetDecimalValue("X_CODE10");
                X_COL11.Value = X_COL11.Value + fleCODES2_4142.GetDecimalValue("X_CODE11");
                X_COL12.Value = X_COL12.Value + fleCODES2_4142.GetDecimalValue("X_FEE_SELECTED");
                X_COL13.Value = X_COL13.Value + fleCODES2_4142.GetDecimalValue("X_CLM_COUNT");
                X_COL14.Value = X_COL14.Value + fleCODES2_4142.GetDecimalValue("X_FEE");
                X_COL15.Value = X_COL15.Value + fleCODES2_4142.GetDecimalValue("X_AGEP");






                SubFile(ref m_trnTRANS_UPDATE, ref fleCODES2_4142_ALL, fleCODES2_4142.At("X_DOC"), SubFileType.Portable, fleCODES2_4142, "DOC_DEPT", COMMA, "X_DOC", "DOC_NAME", X_COL1,
                X_COL2, X_COL3, X_COL4, X_COL5, X_COL6, X_COL7, X_COL8, X_COL9, X_COL10, X_COL11,
                X_COL12, X_COL13, X_COL14, X_COL15, X_CR);
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R


                Reset(ref X_COL1, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL2, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL3, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL4, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL5, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL6, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL7, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL8, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL9, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL10, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL11, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL12, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL13, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL14, fleCODES2_4142.At("X_DOC"));
                Reset(ref X_COL15, fleCODES2_4142.At("X_DOC"));

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
            EndRequest("SIX_6");

        }

    }




    #endregion


}
//SIX_6



public class EMERG_CODES_4142_SEVEN_7 : EMERG_CODES_4142
{

    public EMERG_CODES_4142_SEVEN_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCODES1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CODE1 = new CoreDecimal("X_CODE1", 7, this);
        X_CODE2 = new CoreDecimal("X_CODE2", 7, this);
        X_CODE3 = new CoreDecimal("X_CODE3", 7, this);
        X_CODE4 = new CoreDecimal("X_CODE4", 7, this);
        X_CODE5 = new CoreDecimal("X_CODE5", 7, this);
        X_CODE6 = new CoreDecimal("X_CODE6", 7, this);
        X_CODE7 = new CoreDecimal("X_CODE7", 7, this);
        X_CODE8 = new CoreDecimal("X_CODE8", 7, this);
        X_CODE9 = new CoreDecimal("X_CODE9", 7, this);
        X_CODE10 = new CoreDecimal("X_CODE10", 7, this);
        X_FEE_SELECTED = new CoreDecimal("X_FEE_SELECTED", 9, this);
        fleCODES2_44 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES2_44", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_DOC.GetValue += X_DOC_GetValue;
        X_CODE11.GetValue += X_CODE11_GetValue;
        X_CLM_COUNT.GetValue += X_CLM_COUNT_GetValue;
        X_FEE.GetValue += X_FEE_GetValue;
        X_AGEP.GetValue += X_AGEP_GetValue;

        fleCODES1.SelectIf += fleCODES1_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERG_CODES_4142_SEVEN_7)"

    private SqlFileObject fleCODES1;


    private void fleCODES1_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleCODES1.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  44)");


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
    private DCharacter X_DOC = new DCharacter("X_DOC", 3);
    private void X_DOC_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleCODES1.GetStringValue("CLMDTL_ID"), 3, 3);


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
    private CoreDecimal X_CODE1;
    private CoreDecimal X_CODE2;
    private CoreDecimal X_CODE3;
    private CoreDecimal X_CODE4;
    private CoreDecimal X_CODE5;
    private CoreDecimal X_CODE6;
    private CoreDecimal X_CODE7;
    private CoreDecimal X_CODE8;
    private CoreDecimal X_CODE9;
    private CoreDecimal X_CODE10;
    private DDecimal X_CODE11 = new DDecimal("X_CODE11", 7);
    private void X_CODE11_GetValue(ref decimal Value)
    {

        try
        {
            Value = X_CODE1.Value + X_CODE2.Value + X_CODE3.Value + X_CODE4.Value + X_CODE5.Value + X_CODE6.Value + X_CODE7.Value + X_CODE8.Value + X_CODE9.Value + X_CODE10.Value;


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
    private CoreDecimal X_FEE_SELECTED;
    private DDecimal X_CLM_COUNT = new DDecimal("X_CLM_COUNT", 7);
    private void X_CLM_COUNT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_FEE = new DDecimal("X_FEE", 9);
    private void X_FEE_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_AGEP = new DDecimal("X_AGEP", 9);
    private void X_AGEP_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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





    private SqlFileObject fleCODES2_44;


    #endregion


    #region "Standard Generated Procedures(EMERG_CODES_4142_SEVEN_7)"


    #region "Automatic Item Initialization(EMERG_CODES_4142_SEVEN_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERG_CODES_4142_SEVEN_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:20 PM

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
        fleCODES1.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleCODES2_44.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERG_CODES_4142_SEVEN_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:21 PM

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
            fleCODES1.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleCODES2_44.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERG_CODES_4142_SEVEN_7)"


    public void Run()
    {

        try
        {
            Request("SEVEN_7");

            while (fleCODES1.QTPForMissing())
            {
                // --> GET CODES1 <--

                fleCODES1.GetData();
                // --> End GET CODES1 <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleCODES1.GetStringValue("CLMDTL_ID"), 3, 3)));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                        Sort(X_DOC.Value, fleCODES1.GetSortValue("KEY_CLM_BATCH_NBR"), fleCODES1.GetSortValue("KEY_CLM_CLAIM_NBR"));



                    }

                }

            }

            while (Sort(fleCODES1, fleF020_DOCTOR_MSTR))
            {
                if ((QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G521" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G522" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G523"))
                {
                    X_CODE1.Value = X_CODE1.Value + 1;
                }
                if ((QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G391" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G395"))
                {
                    X_CODE2.Value = X_CODE2.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H102")
                {
                    X_CODE3.Value = X_CODE3.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H132")
                {
                    X_CODE4.Value = X_CODE4.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H152")
                {
                    X_CODE5.Value = X_CODE5.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H122")
                {
                    X_CODE6.Value = X_CODE6.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H104")
                {
                    X_CODE7.Value = X_CODE7.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H134")
                {
                    X_CODE8.Value = X_CODE8.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H154")
                {
                    X_CODE9.Value = X_CODE9.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H124")
                {
                    X_CODE10.Value = X_CODE10.Value + 1;
                }
                if (QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G521" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G522" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G523" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G391" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "G395" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H102" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H132" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H152" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H122" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H104" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H134" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H154" | QDesign.NULL(fleCODES1.GetStringValue("CLMDTL_OMA_CD")) == "H124")
                {
                    X_FEE_SELECTED.Value = X_FEE_SELECTED.Value + fleCODES1.GetDecimalValue("X_CLMDTL_FEE_OHIP_1");
                }






                SubFile(ref m_trnTRANS_UPDATE, ref fleCODES2_44, At(X_DOC), SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_DEPT", X_DOC, "DOC_NAME", X_CODE1, X_CODE2,
                X_CODE3, X_CODE4, X_CODE5, X_CODE6, X_CODE7, X_CODE8, X_CODE9, X_CODE10, X_CODE11, X_FEE_SELECTED,
                X_CLM_COUNT, X_FEE, X_AGEP);
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R


                Reset(ref X_CODE1, At(X_DOC));
                Reset(ref X_CODE2, At(X_DOC));
                Reset(ref X_CODE3, At(X_DOC));
                Reset(ref X_CODE4, At(X_DOC));
                Reset(ref X_CODE5, At(X_DOC));
                Reset(ref X_CODE6, At(X_DOC));
                Reset(ref X_CODE7, At(X_DOC));
                Reset(ref X_CODE8, At(X_DOC));
                Reset(ref X_CODE9, At(X_DOC));
                Reset(ref X_CODE10, At(X_DOC));
                Reset(ref X_FEE_SELECTED, At(X_DOC));

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
            EndRequest("SEVEN_7");

        }

    }




    #endregion


}
//SEVEN_7



public class EMERG_CODES_4142_EIGHT_8 : EMERG_CODES_4142
{

    public EMERG_CODES_4142_EIGHT_8(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCODES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CLM_COUNT = new CoreDecimal("X_CLM_COUNT", 7, this);
        X_FEE = new CoreDecimal("X_FEE", 9, this);
        fleCODES2_44 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES2_44", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_DOC.GetValue += X_DOC_GetValue;
        X_CODE1.GetValue += X_CODE1_GetValue;
        X_CODE2.GetValue += X_CODE2_GetValue;
        X_CODE3.GetValue += X_CODE3_GetValue;
        X_CODE4.GetValue += X_CODE4_GetValue;
        X_CODE5.GetValue += X_CODE5_GetValue;
        X_CODE6.GetValue += X_CODE6_GetValue;
        X_CODE7.GetValue += X_CODE7_GetValue;
        X_CODE8.GetValue += X_CODE8_GetValue;
        X_CODE9.GetValue += X_CODE9_GetValue;
        X_CODE10.GetValue += X_CODE10_GetValue;
        X_CODE11.GetValue += X_CODE11_GetValue;
        X_FEE_SELECTED.GetValue += X_FEE_SELECTED_GetValue;
        X_AGEP.GetValue += X_AGEP_GetValue;

        fleCODES.SelectIf += fleCODES_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERG_CODES_4142_EIGHT_8)"

    private SqlFileObject fleCODES;


    private void fleCODES_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleCODES.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  44)");


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
    private DCharacter X_DOC = new DCharacter("X_DOC", 3);
    private void X_DOC_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleCODES.GetStringValue("KEY_CLM_BATCH_NBR"), 3, 3);


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
    private DDecimal X_CODE1 = new DDecimal("X_CODE1", 7);
    private void X_CODE1_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE2 = new DDecimal("X_CODE2", 7);
    private void X_CODE2_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE3 = new DDecimal("X_CODE3", 7);
    private void X_CODE3_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE4 = new DDecimal("X_CODE4", 7);
    private void X_CODE4_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE5 = new DDecimal("X_CODE5", 7);
    private void X_CODE5_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE6 = new DDecimal("X_CODE6", 7);
    private void X_CODE6_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE7 = new DDecimal("X_CODE7", 7);
    private void X_CODE7_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE8 = new DDecimal("X_CODE8", 7);
    private void X_CODE8_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE9 = new DDecimal("X_CODE9", 7);
    private void X_CODE9_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE10 = new DDecimal("X_CODE10", 7);
    private void X_CODE10_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE11 = new DDecimal("X_CODE11", 7);
    private void X_CODE11_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_FEE_SELECTED = new DDecimal("X_FEE_SELECTED", 9);
    private void X_FEE_SELECTED_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private CoreDecimal X_CLM_COUNT;
    private CoreDecimal X_FEE;
    private DDecimal X_AGEP = new DDecimal("X_AGEP", 9);
    private void X_AGEP_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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





    private SqlFileObject fleCODES2_44;


    #endregion


    #region "Standard Generated Procedures(EMERG_CODES_4142_EIGHT_8)"


    #region "Automatic Item Initialization(EMERG_CODES_4142_EIGHT_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERG_CODES_4142_EIGHT_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:21 PM

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
        fleCODES.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleCODES2_44.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERG_CODES_4142_EIGHT_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:21 PM

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
            fleCODES.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleCODES2_44.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERG_CODES_4142_EIGHT_8)"


    public void Run()
    {

        try
        {
            Request("EIGHT_8");

            while (fleCODES.QTPForMissing())
            {
                // --> GET CODES <--

                fleCODES.GetData();
                // --> End GET CODES <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleCODES.GetStringValue("KEY_CLM_BATCH_NBR"), 3, 3)));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                        Sort(X_DOC.Value, fleCODES.GetSortValue("KEY_CLM_BATCH_NBR"), fleCODES.GetSortValue("KEY_CLM_CLAIM_NBR"));



                    }

                }

            }

            while (Sort(fleCODES, fleF020_DOCTOR_MSTR))
            {
                if (At(X_DOC) || fleCODES.At("KEY_CLM_BATCH_NBR") || fleCODES.At("KEY_CLM_CLAIM_NBR"))
                {
                    X_CLM_COUNT.Value = X_CLM_COUNT.Value + 1;
                }
                if (At(X_DOC) || fleCODES.At("KEY_CLM_BATCH_NBR") || fleCODES.At("KEY_CLM_CLAIM_NBR"))
                {
                    X_FEE.Value = X_FEE.Value + fleCODES.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
                }






                SubFile(ref m_trnTRANS_UPDATE, ref fleCODES2_44, At(X_DOC), SubFileType.Keep, fleF020_DOCTOR_MSTR, X_CODE1, X_CODE2, X_CODE3, X_CODE4, X_CODE5,
                X_CODE6, X_CODE7, X_CODE8, X_CODE9, X_CODE10, X_CODE11, X_FEE_SELECTED, X_CLM_COUNT, X_FEE, X_AGEP);
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R


                Reset(ref X_CLM_COUNT, At(X_DOC));
                Reset(ref X_FEE, At(X_DOC));

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
            EndRequest("EIGHT_8");

        }

    }




    #endregion


}
//EIGHT_8



public class EMERG_CODES_4142_NINE_9 : EMERG_CODES_4142
{

    public EMERG_CODES_4142_NINE_9(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_AGEP = new CoreDecimal("X_AGEP", 9, this);
        fleCODES2_44 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES2_44", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD_HISTORY.Choose += fleF119_DOCTOR_YTD_HISTORY_Choose;
        X_CODE1.GetValue += X_CODE1_GetValue;
        X_CODE2.GetValue += X_CODE2_GetValue;
        X_CODE3.GetValue += X_CODE3_GetValue;
        X_CODE4.GetValue += X_CODE4_GetValue;
        X_CODE5.GetValue += X_CODE5_GetValue;
        X_CODE6.GetValue += X_CODE6_GetValue;
        X_CODE7.GetValue += X_CODE7_GetValue;
        X_CODE8.GetValue += X_CODE8_GetValue;
        X_CODE9.GetValue += X_CODE9_GetValue;
        X_CODE10.GetValue += X_CODE10_GetValue;
        X_CODE11.GetValue += X_CODE11_GetValue;
        X_FEE_SELECTED.GetValue += X_FEE_SELECTED_GetValue;
        X_CLM_COUNT.GetValue += X_CLM_COUNT_GetValue;
        X_FEE.GetValue += X_FEE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERG_CODES_4142_NINE_9)"

    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;
    private SqlFileObject fleF020_DOCTOR_MSTR;

    private void fleF119_DOCTOR_YTD_HISTORY_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("EP_NBR")).Append(" = ");
            strSQL.Append(201407);


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


    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "AGEP" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 44)
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

    private DDecimal X_CODE1 = new DDecimal("X_CODE1", 7);
    private void X_CODE1_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE2 = new DDecimal("X_CODE2", 7);
    private void X_CODE2_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE3 = new DDecimal("X_CODE3", 7);
    private void X_CODE3_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE4 = new DDecimal("X_CODE4", 7);
    private void X_CODE4_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE5 = new DDecimal("X_CODE5", 7);
    private void X_CODE5_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE6 = new DDecimal("X_CODE6", 7);
    private void X_CODE6_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE7 = new DDecimal("X_CODE7", 7);
    private void X_CODE7_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE8 = new DDecimal("X_CODE8", 7);
    private void X_CODE8_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE9 = new DDecimal("X_CODE9", 7);
    private void X_CODE9_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE10 = new DDecimal("X_CODE10", 7);
    private void X_CODE10_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CODE11 = new DDecimal("X_CODE11", 7);
    private void X_CODE11_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_FEE_SELECTED = new DDecimal("X_FEE_SELECTED", 9);
    private void X_FEE_SELECTED_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_CLM_COUNT = new DDecimal("X_CLM_COUNT", 7);
    private void X_CLM_COUNT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_FEE = new DDecimal("X_FEE", 9);
    private void X_FEE_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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

    private CoreDecimal X_AGEP;




    private SqlFileObject fleCODES2_44;


    #endregion


    #region "Standard Generated Procedures(EMERG_CODES_4142_NINE_9)"


    #region "Automatic Item Initialization(EMERG_CODES_4142_NINE_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERG_CODES_4142_NINE_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:21 PM

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
        fleCODES2_44.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERG_CODES_4142_NINE_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:22 PM

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
            fleCODES2_44.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERG_CODES_4142_NINE_9)"


    public void Run()
    {

        try
        {
            Request("NINE_9");

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

                         if (Select_If())
                        {

                            Sort(fleF119_DOCTOR_YTD_HISTORY.GetSortValue("DOC_NBR"));



                        }

                    }

                }

            }

            while (Sort(fleF119_DOCTOR_YTD_HISTORY, fleF020_DOCTOR_MSTR))
            {
                X_AGEP.Value = X_AGEP.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_MTD");






                SubFile(ref m_trnTRANS_UPDATE, ref fleCODES2_44, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"), SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_DEPT", fleF119_DOCTOR_YTD_HISTORY, "DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_NAME",
                X_CODE1, X_CODE2, X_CODE3, X_CODE4, X_CODE5, X_CODE6, X_CODE7, X_CODE8, X_CODE9, X_CODE10,
                X_CODE11, X_FEE_SELECTED, X_CLM_COUNT, X_FEE, X_AGEP);
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R


                Reset(ref X_AGEP, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));

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
            EndRequest("NINE_9");

        }

    }




    #endregion


}
//NINE_9



public class EMERG_CODES_4142_TEN_10 : EMERG_CODES_4142
{

    public EMERG_CODES_4142_TEN_10(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCODES2_44 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES2_44", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COL1 = new CoreDecimal("X_COL1", 7, this);
        X_COL2 = new CoreDecimal("X_COL2", 7, this);
        X_COL3 = new CoreDecimal("X_COL3", 7, this);
        X_COL4 = new CoreDecimal("X_COL4", 7, this);
        X_COL5 = new CoreDecimal("X_COL5", 7, this);
        X_COL6 = new CoreDecimal("X_COL6", 7, this);
        X_COL7 = new CoreDecimal("X_COL7", 7, this);
        X_COL8 = new CoreDecimal("X_COL8", 7, this);
        X_COL9 = new CoreDecimal("X_COL9", 7, this);
        X_COL10 = new CoreDecimal("X_COL10", 7, this);
        X_COL11 = new CoreDecimal("X_COL11", 7, this);
        X_COL12 = new CoreDecimal("X_COL12", 9, this);
        X_COL13 = new CoreDecimal("X_COL13", 7, this);
        X_COL14 = new CoreDecimal("X_COL14", 9, this);
        X_COL15 = new CoreDecimal("X_COL15", 9, this);
        fleCODES2_44_ALL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "CODES2_44_ALL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERG_CODES_4142_TEN_10)"

    private SqlFileObject fleCODES2_44;
    private CoreDecimal X_COL1;
    private CoreDecimal X_COL2;
    private CoreDecimal X_COL3;
    private CoreDecimal X_COL4;
    private CoreDecimal X_COL5;
    private CoreDecimal X_COL6;
    private CoreDecimal X_COL7;
    private CoreDecimal X_COL8;
    private CoreDecimal X_COL9;
    private CoreDecimal X_COL10;
    private CoreDecimal X_COL11;
    private CoreDecimal X_COL12;
    private CoreDecimal X_COL13;
    private CoreDecimal X_COL14;
    private CoreDecimal X_COL15;
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





    private SqlFileObject fleCODES2_44_ALL;


    #endregion


    #region "Standard Generated Procedures(EMERG_CODES_4142_TEN_10)"


    #region "Automatic Item Initialization(EMERG_CODES_4142_TEN_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERG_CODES_4142_TEN_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:22 PM

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
        fleCODES2_44.Transaction = m_trnTRANS_UPDATE;
        fleCODES2_44_ALL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERG_CODES_4142_TEN_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:22 PM

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
            fleCODES2_44.Dispose();
            fleCODES2_44_ALL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERG_CODES_4142_TEN_10)"


    public void Run()
    {

        try
        {
            Request("TEN_10");

            while (fleCODES2_44.QTPForMissing())
            {
                // --> GET CODES2_44 <--

                fleCODES2_44.GetData();
                // --> End GET CODES2_44 <--


                if (Transaction())
                {

                    Sort(fleCODES2_44.GetSortValue("X_DOC"));



                }

            }

            while (Sort(fleCODES2_44))
            {
                X_COL1.Value = X_COL1.Value + fleCODES2_44.GetDecimalValue("X_CODE1");
                X_COL2.Value = X_COL2.Value + fleCODES2_44.GetDecimalValue("X_CODE2");
                X_COL3.Value = X_COL3.Value + fleCODES2_44.GetDecimalValue("X_CODE3");
                X_COL4.Value = X_COL4.Value + fleCODES2_44.GetDecimalValue("X_CODE4");
                X_COL5.Value = X_COL5.Value + fleCODES2_44.GetDecimalValue("X_CODE5");
                X_COL6.Value = X_COL6.Value + fleCODES2_44.GetDecimalValue("X_CODE6");
                X_COL7.Value = X_COL7.Value + fleCODES2_44.GetDecimalValue("X_CODE7");
                X_COL8.Value = X_COL8.Value + fleCODES2_44.GetDecimalValue("X_CODE8");
                X_COL9.Value = X_COL9.Value + fleCODES2_44.GetDecimalValue("X_CODE9");
                X_COL10.Value = X_COL10.Value + fleCODES2_44.GetDecimalValue("X_CODE10");
                X_COL11.Value = X_COL11.Value + fleCODES2_44.GetDecimalValue("X_CODE11");
                X_COL12.Value = X_COL12.Value + fleCODES2_44.GetDecimalValue("X_FEE_SELECTED");
                X_COL13.Value = X_COL13.Value + fleCODES2_44.GetDecimalValue("X_CLM_COUNT");
                X_COL14.Value = X_COL14.Value + fleCODES2_44.GetDecimalValue("X_FEE");
                X_COL15.Value = X_COL15.Value + fleCODES2_44.GetDecimalValue("X_AGEP");






                SubFile(ref m_trnTRANS_UPDATE, ref fleCODES2_44_ALL, fleCODES2_44.At("X_DOC"), SubFileType.Portable, fleCODES2_44, "DOC_DEPT", COMMA, "X_DOC", "DOC_NAME", X_COL1,
                X_COL2, X_COL3, X_COL4, X_COL5, X_COL6, X_COL7, X_COL8, X_COL9, X_COL10, X_COL11,
                X_COL12, X_COL13, X_COL14, X_COL15, X_CR);
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R


                Reset(ref X_COL1, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL2, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL3, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL4, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL5, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL6, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL7, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL8, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL9, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL10, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL11, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL12, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL13, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL14, fleCODES2_44.At("X_DOC"));
                Reset(ref X_COL15, fleCODES2_44.At("X_DOC"));

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
            EndRequest("TEN_10");

        }

    }




    #endregion


}
//TEN_10




