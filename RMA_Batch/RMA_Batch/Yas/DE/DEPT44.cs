
#region "Screen Comments"

// doc     : emerg_dept44.qts
// purpose : report department 44 claims                                    
// who     : Leena               
// *************************************************************
// Date  Who  Description
// 2011/04/19 Yasemin         geriatrics


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class DEPT44 : BaseClassControl
{

    private DEPT44 m_DEPT44;

    public DEPT44(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public DEPT44(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_DEPT44 != null))
        {
            m_DEPT44.CloseTransactionObjects();
            m_DEPT44 = null;
        }
    }

    public DEPT44 GetDEPT44(int Level)
    {
        if (m_DEPT44 == null)
        {
            m_DEPT44 = new DEPT44("DEPT44", Level);
        }
        else
        {
            m_DEPT44.ResetValues();
        }
        return m_DEPT44;
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

            DEPT44_ONE_1 ONE_1 = new DEPT44_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            DEPT44_TWO_2 TWO_2 = new DEPT44_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

            DEPT44_THREE_3 THREE_3 = new DEPT44_THREE_3(Name, Level);
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



public class DEPT44_ONE_1 : DEPT44
{

    public DEPT44_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEPT44 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT44", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(DEPT44_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" =  'C' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  44)");


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









    private SqlFileObject fleDEPT44;


    #endregion


    #region "Standard Generated Procedures(DEPT44_ONE_1)"


    #region "Automatic Item Initialization(DEPT44_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEPT44_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:10 PM

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
        fleDEPT44.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEPT44_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:10 PM

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
            fleDEPT44.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEPT44_ONE_1)"


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








                    SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT44, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMHDR_CLAIM_ID", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_LOC", "CLMHDR_HOSP", "CLMHDR_PAYROLL",
                    "CLMHDR_PAT_OHIP_ID_OR_CHART");
                    //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD


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



public class DEPT44_TWO_2 : DEPT44
{

    public DEPT44_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleDEPT44 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT44", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEPT441 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT441", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDEPT44_SVC2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT441", "DEPT44_SVC2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDEPT44_SVC3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT441", "DEPT44_SVC3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDEPT44_SVC4 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT441", "DEPT44_SVC4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

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


    #region "Declarations (Variables, Files and Transactions)(DEPT44_TWO_2)"

    private SqlFileObject fleDEPT44;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_SV_YY")).Append(" >=  ('20140701' AND ");
            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_SV_MM")).Append(" >=  ('20140701' AND ");
            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_SV_DD")).Append(" >=  ('20140701' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_SV_DATE")).Append(" <=  '20150630' AND ");
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
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <>  'AGEP' AND ");
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
    private DDecimal X_FEE = new DDecimal("X_FEE", 7);
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
                //Parent:CLMDTL_CONSEC_DATES_R    'Parent:CLMDTL_SV_DATE
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
                //Parent:CLMDTL_CONSEC_DATES_R    'Parent:CLMDTL_SV_DATE
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
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 8, 2);
                //Parent:CLMDTL_CONSEC_DATES_R    'Parent:CLMDTL_SV_DATE
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



    private SqlFileObject fleDEPT441;



    private SqlFileObject fleDEPT44_SVC2;



    private SqlFileObject fleDEPT44_SVC3;



    private SqlFileObject fleDEPT44_SVC4;


    #endregion


    #region "Standard Generated Procedures(DEPT44_TWO_2)"


    #region "Automatic Item Initialization(DEPT44_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEPT44_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:10 PM

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
        fleDEPT44.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDEPT441.Transaction = m_trnTRANS_UPDATE;
        fleDEPT44_SVC2.Transaction = m_trnTRANS_UPDATE;
        fleDEPT44_SVC3.Transaction = m_trnTRANS_UPDATE;
        fleDEPT44_SVC4.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEPT44_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:10 PM

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
            fleDEPT44.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleDEPT441.Dispose();
            fleDEPT44_SVC2.Dispose();
            fleDEPT44_SVC3.Dispose();
            fleDEPT44_SVC4.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEPT44_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleDEPT44.QTPForMissing())
            {
                // --> GET DEPT44 <--

                fleDEPT44.GetData();
                // --> End GET DEPT44 <--

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








                        SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT441, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMDTL_ID", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_1, X_SV_DATE_1, "CLMDTL_DIAG_CD",
                        "CLMDTL_OMA_CD", fleDEPT44);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD









                        SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT44_SVC2, QDesign.NULL(X_SV_NBR2.Value) != 0, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMDTL_ID", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_2, X_SV_DATE_2,
                        "CLMDTL_DIAG_CD", "CLMDTL_OMA_CD", fleDEPT44);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD









                        SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT44_SVC3, QDesign.NULL(X_SV_NBR3.Value) != 0, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMDTL_ID", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_3, X_SV_DATE_3,
                        "CLMDTL_DIAG_CD", "CLMDTL_OMA_CD", fleDEPT44);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD









                        SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT44_SVC4, QDesign.NULL(X_SV_NBR4.Value) != 0, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMDTL_ID", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_4, X_SV_DATE_4,
                        "CLMDTL_DIAG_CD", "CLMDTL_OMA_CD", fleDEPT44);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD


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



public class DEPT44_THREE_3 : DEPT44
{

    public DEPT44_THREE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleDEPT441 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT441", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF030_LOCATIONS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F030_LOCATIONS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF091_DIAG_CODES_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F091_DIAG_CODES_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEPT442 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT442", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_CLINIC.GetValue += X_CLINIC_GetValue;
        X_DOC.GetValue += X_DOC_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        fleF040_OMA_FEE_MSTR.InitializeItems += fleF040_OMA_FEE_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(DEPT44_THREE_3)"

    private SqlFileObject fleDEPT441;
    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleF030_LOCATIONS_MSTR;
    private SqlFileObject fleF040_OMA_FEE_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF091_DIAG_CODES_MSTR;
    private DCharacter X_CLINIC = new DCharacter("X_CLINIC", 2);
    private void X_CLINIC_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleDEPT441.GetStringValue("CLMDTL_ID"), 1, 2);


        }
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
            Value = QDesign.Substring(fleDEPT441.GetStringValue("CLMDTL_ID"), 3, 3);


        }
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








    private SqlFileObject fleDEPT442;


    #endregion


    #region "Standard Generated Procedures(DEPT44_THREE_3)"


    #region "Automatic Item Initialization(DEPT44_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:25 PM

    //#-----------------------------------------
    //# fleF040_OMA_FEE_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:33:20 PM
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


    #region "Transaction Management Procedures(DEPT44_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:10 PM

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
        fleDEPT441.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF030_LOCATIONS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF091_DIAG_CODES_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDEPT442.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEPT44_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:10 PM

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
            fleDEPT441.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleF030_LOCATIONS_MSTR.Dispose();
            fleF040_OMA_FEE_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF091_DIAG_CODES_MSTR.Dispose();
            fleDEPT442.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEPT44_THREE_3)"


    public void Run()
    {

        try
        {
            Request("THREE_3");

            while (fleDEPT441.QTPForMissing())
            {
                // --> GET DEPT441 <--

                fleDEPT441.GetData();
                // --> End GET DEPT441 <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleDEPT441.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(0, 1)));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleDEPT441.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(1, 2)));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleDEPT441.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(3, 12)));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleDEPT441.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(15, 1)));
                    //Parent:KEY_PAT_MSTR

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F010_PAT_MSTR <--

                    while (fleF030_LOCATIONS_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F030_LOCATIONS_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF030_LOCATIONS_MSTR.ElementOwner("LOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleDEPT441.GetStringValue("CLMHDR_LOC")));

                        fleF030_LOCATIONS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F030_LOCATIONS_MSTR <--

                        while (fleF040_OMA_FEE_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F040_OMA_FEE_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                            m_strWhere.Append(Common.StringToField((fleDEPT441.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(0, 1)));
                            //Parent:FEE_OMA_CD
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                            m_strWhere.Append(Common.StringToField((fleDEPT441.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(1, 1)));
                            //Parent:FEE_OMA_CD

                            fleF040_OMA_FEE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F040_OMA_FEE_MSTR <--

                            while (fleF020_DOCTOR_MSTR.QTPForMissing("4"))
                            {
                                // --> GET F020_DOCTOR_MSTR <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(QDesign.Substring(fleDEPT441.GetStringValue("CLMDTL_ID"), 3, 3)));

                                fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F020_DOCTOR_MSTR <--

                                while (fleF091_DIAG_CODES_MSTR.QTPForMissing("5"))
                                {
                                    // --> GET F091_DIAG_CODES_MSTR <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF091_DIAG_CODES_MSTR.ElementOwner("DIAG_CD")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleDEPT441.GetDecimalValue("CLMDTL_DIAG_CD"), 3))));

                                    fleF091_DIAG_CODES_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F091_DIAG_CODES_MSTR <--


                                    if (Transaction())
                                    {

                                        Sort(fleDEPT441.GetSortValue("X_SV_DATE_1"));



                                    }

                                }

                            }

                        }

                    }

                }

            }


            while (Sort(fleDEPT441, fleF010_PAT_MSTR, fleF030_LOCATIONS_MSTR, fleF040_OMA_FEE_MSTR, fleF020_DOCTOR_MSTR, fleF091_DIAG_CODES_MSTR))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT442, SubFileType.Keep, X_CLINIC, COMMA, X_DOC, fleF020_DOCTOR_MSTR, "DOC_NAME", fleDEPT441, "CLMDTL_OMA_CD",
                X_CR);
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD


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




