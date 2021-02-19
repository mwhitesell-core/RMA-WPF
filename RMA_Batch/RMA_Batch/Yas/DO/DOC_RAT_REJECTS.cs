
#region "Screen Comments"

// doc     : f088_peds_rejects.qts
// purpose : Report pediatric rat rejects 
// who     : doc rejects change doc number as requested
// Date           Who             Description
// 2012/06/14      Yasemin


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class DOC_RAT_REJECTS : BaseClassControl
{

    private DOC_RAT_REJECTS m_DOC_RAT_REJECTS;

    public DOC_RAT_REJECTS(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public DOC_RAT_REJECTS(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_DOC_RAT_REJECTS != null))
        {
            m_DOC_RAT_REJECTS.CloseTransactionObjects();
            m_DOC_RAT_REJECTS = null;
        }
    }

    public DOC_RAT_REJECTS GetDOC_RAT_REJECTS(int Level)
    {
        if (m_DOC_RAT_REJECTS == null)
        {
            m_DOC_RAT_REJECTS = new DOC_RAT_REJECTS("DOC_RAT_REJECTS", Level);
        }
        else
        {
            m_DOC_RAT_REJECTS.ResetValues();
        }
        return m_DOC_RAT_REJECTS;
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

            DOC_RAT_REJECTS_ONE_1 ONE_1 = new DOC_RAT_REJECTS_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            DOC_RAT_REJECTS_TWO_2 TWO_2 = new DOC_RAT_REJECTS_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

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



public class DOC_RAT_REJECTS_ONE_1 : DOC_RAT_REJECTS
{

    public DOC_RAT_REJECTS_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF088RATREJECTEDCLAIMSHISTDTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF088RATREJECTEDCLAIMSHISTHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDOCF088 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DOCF088", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF088RATREJECTEDCLAIMSHISTDTL.Choose += fleF088RATREJECTEDCLAIMSHISTDTL_Choose;
        X_CODE.GetValue += X_CODE_GetValue;
        fleF088RATREJECTEDCLAIMSHISTHDR.InitializeItems += fleF088RATREJECTEDCLAIMSHISTHDR_AutomaticItemInitialization;

        fleF088RATREJECTEDCLAIMSHISTDTL.SelectIf += fleF088RATREJECTEDCLAIMSHISTDTL_SelectIf;
        fleF088RATREJECTEDCLAIMSHISTHDR.SelectIf += fleF088RATREJECTEDCLAIMSHISTHDR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(DOC_RAT_REJECTS_ONE_1)"

    private SqlFileObject fleF088RATREJECTEDCLAIMSHISTDTL;

    private void fleF088RATREJECTEDCLAIMSHISTDTL_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (  ").Append(GetWhereClauseString(fleF088RATREJECTEDCLAIMSHISTDTL.ElementOwner("PED"), ">=", 20130701)).Append(" AND ");
            strSQL.Append("  ").Append(GetWhereClauseString(fleF088RATREJECTEDCLAIMSHISTDTL.ElementOwner("PED"), "<=", 20140630)).Append(")");


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

    private SqlFileObject fleF088RATREJECTEDCLAIMSHISTHDR;

    private void fleF088RATREJECTEDCLAIMSHISTHDR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF088RATREJECTEDCLAIMSHISTHDR.ElementOwner("CHARGE_STATUS")).Append(" =  'Y')");


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
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleF010_PAT_MSTR;

    private void fleF088RATREJECTEDCLAIMSHISTDTL_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF088RATREJECTEDCLAIMSHISTDTL.ElementOwner("CLMHDR_BATCH_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField("23E74@"));


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

    private DCharacter X_CODE = new DCharacter("X_CODE", 5);
    private void X_CODE_GetValue(ref string Value)
    {

        try
        {
            Value = fleF088RATREJECTEDCLAIMSHISTDTL.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF088RATREJECTEDCLAIMSHISTDTL.GetStringValue("CLMHDR_ADJ_OMA_SUFF");


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }







    private SqlFileObject fleDOCF088;


    #endregion


    #region "Standard Generated Procedures(DOC_RAT_REJECTS_ONE_1)"


    #region "Automatic Item Initialization(DOC_RAT_REJECTS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:22 PM

    //#-----------------------------------------
    //# fleF088RATREJECTEDCLAIMSHISTHDR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:34:19 PM
    //#-----------------------------------------
    private void fleF088RATREJECTEDCLAIMSHISTHDR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF088RATREJECTEDCLAIMSHISTHDR.set_SetValue("CLMHDR_BATCH_NBR", !Fixed, fleF088RATREJECTEDCLAIMSHISTDTL.GetStringValue("CLMHDR_BATCH_NBR"));
            fleF088RATREJECTEDCLAIMSHISTHDR.set_SetValue("CLMHDR_CLAIM_NBR", !Fixed, fleF088RATREJECTEDCLAIMSHISTDTL.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            fleF088RATREJECTEDCLAIMSHISTHDR.set_SetValue("PED", !Fixed, fleF088RATREJECTEDCLAIMSHISTDTL.GetDecimalValue("PED"));
            fleF088RATREJECTEDCLAIMSHISTHDR.set_SetValue("OHIP_ERR_CODE", !Fixed, fleF088RATREJECTEDCLAIMSHISTDTL.GetStringValue("OHIP_ERR_CODE"));
            fleF088RATREJECTEDCLAIMSHISTHDR.set_SetValue("CLMHDR_DOC_NBR", !Fixed, fleF088RATREJECTEDCLAIMSHISTDTL.GetStringValue("CLMHDR_DOC_NBR"));
            fleF088RATREJECTEDCLAIMSHISTHDR.set_SetValue("ENTRY_DATE", !Fixed, fleF088RATREJECTEDCLAIMSHISTDTL.GetDecimalValue("ENTRY_DATE"));
            fleF088RATREJECTEDCLAIMSHISTHDR.set_SetValue("ENTRY_TIME_LONG", !Fixed, fleF088RATREJECTEDCLAIMSHISTDTL.GetDecimalValue("ENTRY_TIME_LONG"));
            fleF088RATREJECTEDCLAIMSHISTHDR.set_SetValue("ENTRY_USER_ID", !Fixed, fleF088RATREJECTEDCLAIMSHISTDTL.GetStringValue("ENTRY_USER_ID"));
            fleF088RATREJECTEDCLAIMSHISTHDR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF088RATREJECTEDCLAIMSHISTDTL.GetDecimalValue("LAST_MOD_DATE"));
            fleF088RATREJECTEDCLAIMSHISTHDR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF088RATREJECTEDCLAIMSHISTDTL.GetDecimalValue("LAST_MOD_TIME"));
            fleF088RATREJECTEDCLAIMSHISTHDR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF088RATREJECTEDCLAIMSHISTDTL.GetStringValue("LAST_MOD_USER_ID"));

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


    #region "Transaction Management Procedures(DOC_RAT_REJECTS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:19 PM

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
        fleF088RATREJECTEDCLAIMSHISTDTL.Transaction = m_trnTRANS_UPDATE;
        fleF088RATREJECTEDCLAIMSHISTHDR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDOCF088.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DOC_RAT_REJECTS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:19 PM

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
            fleF088RATREJECTEDCLAIMSHISTDTL.Dispose();
            fleF088RATREJECTEDCLAIMSHISTHDR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleDOCF088.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DOC_RAT_REJECTS_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF088RATREJECTEDCLAIMSHISTDTL.QTPForMissing())
            {
                // --> GET F088RATREJECTEDCLAIMSHISTDTL <--

                fleF088RATREJECTEDCLAIMSHISTDTL.GetData();
                // --> End GET F088RATREJECTEDCLAIMSHISTDTL <--

                while (fleF088RATREJECTEDCLAIMSHISTHDR.QTPForMissing("1"))
                {
                    // --> GET F088RATREJECTEDCLAIMSHISTHDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF088RATREJECTEDCLAIMSHISTHDR.ElementOwner("CLMHDR_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(((fleF088RATREJECTEDCLAIMSHISTDTL.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF088RATREJECTEDCLAIMSHISTDTL.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2))).PadRight(10).Substring(0, 8)));
                    //Parent:RAT_REJECTED_CLAIM
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF088RATREJECTEDCLAIMSHISTHDR.ElementOwner("CLMHDR_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(((fleF088RATREJECTEDCLAIMSHISTDTL.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF088RATREJECTEDCLAIMSHISTDTL.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2))).PadRight(10).Substring(8, 2)));
                    //Parent:RAT_REJECTED_CLAIM
                    m_strWhere.Append(GetWhereClauseString(fleF088RATREJECTEDCLAIMSHISTHDR.ElementOwner("PED"), "=", fleF088RATREJECTEDCLAIMSHISTDTL.GetNumericDateValue("PED")));

                    fleF088RATREJECTEDCLAIMSHISTHDR.GetData(m_strWhere.ToString());
                    // --> End GET F088RATREJECTEDCLAIMSHISTHDR <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF088RATREJECTEDCLAIMSHISTDTL.GetStringValue("CLMHDR_DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF002_CLAIMS_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F002_CLAIMS_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("B"));
                            m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF088RATREJECTEDCLAIMSHISTDTL.GetStringValue("CLMHDR_BATCH_NBR")));
                            m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                            m_strWhere.Append((fleF088RATREJECTEDCLAIMSHISTDTL.GetDecimalValue("CLMHDR_CLAIM_NBR")));
                            m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("00000"));
                            m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("0"));

                            fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F002_CLAIMS_MSTR <--

                            while (fleF010_PAT_MSTR.QTPForMissing("4"))
                            {
                                // --> GET F010_PAT_MSTR <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                                m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                                m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
                                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                                m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                                m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));
                                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR

                                fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F010_PAT_MSTR <--


                                if (Transaction())
                                {


                                    SubFile(ref m_trnTRANS_UPDATE, ref fleDOCF088, SubFileType.Keep, fleF020_DOCTOR_MSTR, fleF010_PAT_MSTR, "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_HEALTH_NBR", "PAT_VERSION_CD", fleF002_CLAIMS_MSTR,
                                    "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", X_CODE, fleF088RATREJECTEDCLAIMSHISTDTL, "CLMDTL_SV_DATE", "PART_DTL_AMT_BILL", "PART_DTL_AMT_PAID", "OHIP_ERR_CODE", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED");
                                    //Parent:RAT_REJECTED_CLAIM)    'Parent:DOC_INITS)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_SURNAME)    'Parent:PAT_GIVEN_NAME)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD


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
            EndRequest("ONE_1");

        }

    }




    #endregion


}
//ONE_1



public class DOC_RAT_REJECTS_TWO_2 : DOC_RAT_REJECTS
{

    public DOC_RAT_REJECTS_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleDOCF088 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DOCF088", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDOCF088_1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DOCF088_1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        X_CLAIM.GetValue += X_CLAIM_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(DOC_RAT_REJECTS_TWO_2)"

    private SqlFileObject fleDOCF088;
    private SqlFileObject fleF040_OMA_FEE_MSTR;
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
    private DCharacter X_CLAIM = new DCharacter("X_CLAIM", 10);
    private void X_CLAIM_GetValue(ref string Value)
    {

        try
        {
            Value = (fleDOCF088.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleDOCF088.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2));


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }







    private SqlFileObject fleDOCF088_1;


    #endregion


    #region "Standard Generated Procedures(DOC_RAT_REJECTS_TWO_2)"


    #region "Automatic Item Initialization(DOC_RAT_REJECTS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DOC_RAT_REJECTS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:19 PM

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
        fleDOCF088.Transaction = m_trnTRANS_UPDATE;
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDOCF088_1.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DOC_RAT_REJECTS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:19 PM

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
            fleDOCF088.Dispose();
            fleF040_OMA_FEE_MSTR.Dispose();
            fleDOCF088_1.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DOC_RAT_REJECTS_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleDOCF088.QTPForMissing())
            {
                // --> GET DOCF088 <--

                fleDOCF088.GetData();
                // --> End GET DOCF088 <--

                while (fleF040_OMA_FEE_MSTR.QTPForMissing("1"))
                {
                    // --> GET F040_OMA_FEE_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleDOCF088.GetStringValue("X_CODE")).PadRight(4).Substring(0, 1)));
                    //Parent:FEE_OMA_CD
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleDOCF088.GetStringValue("X_CODE")).PadRight(4).Substring(1, 1)));
                    //Parent:FEE_OMA_CD

                    fleF040_OMA_FEE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F040_OMA_FEE_MSTR <--


                    if (Transaction())
                    {

                        SubFile(ref m_trnTRANS_UPDATE, ref fleDOCF088_1, SubFileType.Portable, X_CLAIM, COMMA, fleDOCF088, "X_CODE", "PART_DTL_AMT_BILL", "CLMDTL_SV_DATE", "PED",
                        "OHIP_ERR_CODE", X_CR);
                        //Parent:RAT_REJECTED_CLAIM)    'Parent:DOC_INITS)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:PAT_SURNAME)    'Parent:PAT_GIVEN_NAME)    'Parent:KEY_PAT_MSTR)    'Parent:FEE_OMA_CD


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




