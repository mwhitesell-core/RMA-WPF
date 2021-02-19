
#region "Screen Comments"

// doc     : ucc_patient_count_hdr.qts                
// purpose : report patient count and amount by doctor for dept 44  with agent 0,2,4,6,9                                        
// for the period from July 1 - Dec 31, 2012 for clinic 22, 23 & 98 only
// who     : Ross/John Crossley/Rob Kerr
// *************************************************************
// Date           Who            Description
// 2013/02/07     MC             original  


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UCC_PATIENT_COUNT_HDR : BaseClassControl
{

    private UCC_PATIENT_COUNT_HDR m_UCC_PATIENT_COUNT_HDR;

    public UCC_PATIENT_COUNT_HDR(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UCC_PATIENT_COUNT_HDR(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UCC_PATIENT_COUNT_HDR != null))
        {
            m_UCC_PATIENT_COUNT_HDR.CloseTransactionObjects();
            m_UCC_PATIENT_COUNT_HDR = null;
        }
    }

    public UCC_PATIENT_COUNT_HDR GetUCC_PATIENT_COUNT_HDR(int Level)
    {
        if (m_UCC_PATIENT_COUNT_HDR == null)
        {
            m_UCC_PATIENT_COUNT_HDR = new UCC_PATIENT_COUNT_HDR("UCC_PATIENT_COUNT_HDR", Level);
        }
        else
        {
            m_UCC_PATIENT_COUNT_HDR.ResetValues();
        }
        return m_UCC_PATIENT_COUNT_HDR;
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

            UCC_PATIENT_COUNT_HDR_ONE_1 ONE_1 = new UCC_PATIENT_COUNT_HDR_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

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



public class UCC_PATIENT_COUNT_HDR_ONE_1 : UCC_PATIENT_COUNT_HDR
{

    public UCC_PATIENT_COUNT_HDR_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        AGENT_0_PAT_COUNT = new CoreDecimal("AGENT_0_PAT_COUNT", 5, this);
        AGENT_0_AMOUNT = new CoreDecimal("AGENT_0_AMOUNT", 7, this);
        AGENT_2_PAT_COUNT = new CoreDecimal("AGENT_2_PAT_COUNT", 5, this);
        AGENT_2_AMOUNT = new CoreDecimal("AGENT_2_AMOUNT", 7, this);
        AGENT_6_PAT_COUNT = new CoreDecimal("AGENT_6_PAT_COUNT", 5, this);
        AGENT_6_AMOUNT = new CoreDecimal("AGENT_6_AMOUNT", 7, this);
        AGENT_9_PAT_COUNT = new CoreDecimal("AGENT_9_PAT_COUNT", 5, this);
        AGENT_9_AMOUNT = new CoreDecimal("AGENT_9_AMOUNT", 7, this);
        AGENT_TOT_PAT_COUNT = new CoreDecimal("AGENT_TOT_PAT_COUNT", 5, this);
        AGENT_TOT_AMOUNT = new CoreDecimal("AGENT_TOT_AMOUNT", 7, this);
        fleUCC_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UCC_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(UCC_PATIENT_COUNT_HDR_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" =  'C' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  44 AND ");
            strSQL.Append(" (  ").Append(GetWhereClauseString(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_SERV_DATE"), ">=", 20120701)).Append(" AND ");
            strSQL.Append("  ").Append(GetWhereClauseString(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_SERV_DATE"), "<=", 20121231)).Append(" ) AND ");
            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_AGENT_CD")).Append(" =  0 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_AGENT_CD")).Append(" =  2 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_AGENT_CD")).Append(" =  4 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_AGENT_CD")).Append(" =  6 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_AGENT_CD")).Append(" =  9 ))");


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

    private void fleF002_CLAIMS_MSTR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("B"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField("22@"));


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

    private CoreDecimal AGENT_0_PAT_COUNT;
    private CoreDecimal AGENT_0_AMOUNT;
    private CoreDecimal AGENT_2_PAT_COUNT;
    private CoreDecimal AGENT_2_AMOUNT;
    private CoreDecimal AGENT_6_PAT_COUNT;
    private CoreDecimal AGENT_6_AMOUNT;
    private CoreDecimal AGENT_9_PAT_COUNT;
    private CoreDecimal AGENT_9_AMOUNT;
    private CoreDecimal AGENT_TOT_PAT_COUNT;
    private CoreDecimal AGENT_TOT_AMOUNT;
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

    private SqlFileObject fleUCC_HDR;


    #endregion


    #region "Standard Generated Procedures(UCC_PATIENT_COUNT_HDR_ONE_1)"


    #region "Automatic Item Initialization(UCC_PATIENT_COUNT_HDR_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UCC_PATIENT_COUNT_HDR_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:20 PM

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
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleUCC_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UCC_PATIENT_COUNT_HDR_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:20 PM

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
            fleF020_DOCTOR_MSTR.Dispose();
            fleUCC_HDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UCC_PATIENT_COUNT_HDR_ONE_1)"


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

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 3, 3))));
                    //Parent:CLMHDR_CLAIM_ID

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                        Sort(fleF020_DOCTOR_MSTR.GetSortValue("DOC_NBR"));



                    }

                }

            }

            while (Sort(fleF002_CLAIMS_MSTR, fleF020_DOCTOR_MSTR))
            {
                if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)
                {
                    AGENT_0_PAT_COUNT.Value = AGENT_0_PAT_COUNT.Value + 1;
                }
                if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)
                {
                    AGENT_0_AMOUNT.Value = AGENT_0_AMOUNT.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
                }
                if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2)
                {
                    AGENT_2_PAT_COUNT.Value = AGENT_2_PAT_COUNT.Value + 1;
                }
                if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2)
                {
                    AGENT_2_AMOUNT.Value = AGENT_2_AMOUNT.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
                }
                if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6)
                {
                    AGENT_6_PAT_COUNT.Value = AGENT_6_PAT_COUNT.Value + 1;
                }
                if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6)
                {
                    AGENT_6_AMOUNT.Value = AGENT_6_AMOUNT.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
                }
                if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9)
                {
                    AGENT_9_PAT_COUNT.Value = AGENT_9_PAT_COUNT.Value + 1;
                }
                if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9)
                {
                    AGENT_9_AMOUNT.Value = AGENT_9_AMOUNT.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
                }
                AGENT_TOT_PAT_COUNT.Value = AGENT_TOT_PAT_COUNT.Value + 1;
                AGENT_TOT_AMOUNT.Value = AGENT_TOT_AMOUNT.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");


                SubFile(ref m_trnTRANS_UPDATE, ref fleUCC_HDR, fleF020_DOCTOR_MSTR.At("DOC_NBR"), SubFileType.Portable, fleF020_DOCTOR_MSTR, "DOC_NBR", COMMA, "DOC_NAME", AGENT_0_PAT_COUNT, AGENT_0_AMOUNT,
                AGENT_2_PAT_COUNT, AGENT_2_AMOUNT, AGENT_6_PAT_COUNT, AGENT_6_AMOUNT, AGENT_9_PAT_COUNT, AGENT_9_AMOUNT, AGENT_TOT_PAT_COUNT, AGENT_TOT_AMOUNT, X_CR);
                //Parent:CLMHDR_CLAIM_ID


                Reset(ref AGENT_0_PAT_COUNT, fleF020_DOCTOR_MSTR.At("DOC_NBR"));
                Reset(ref AGENT_0_AMOUNT, fleF020_DOCTOR_MSTR.At("DOC_NBR"));
                Reset(ref AGENT_2_PAT_COUNT, fleF020_DOCTOR_MSTR.At("DOC_NBR"));
                Reset(ref AGENT_2_AMOUNT, fleF020_DOCTOR_MSTR.At("DOC_NBR"));
                Reset(ref AGENT_6_PAT_COUNT, fleF020_DOCTOR_MSTR.At("DOC_NBR"));
                Reset(ref AGENT_6_AMOUNT, fleF020_DOCTOR_MSTR.At("DOC_NBR"));
                Reset(ref AGENT_9_PAT_COUNT, fleF020_DOCTOR_MSTR.At("DOC_NBR"));
                Reset(ref AGENT_9_AMOUNT, fleF020_DOCTOR_MSTR.At("DOC_NBR"));
                Reset(ref AGENT_TOT_PAT_COUNT, fleF020_DOCTOR_MSTR.At("DOC_NBR"));
                Reset(ref AGENT_TOT_AMOUNT, fleF020_DOCTOR_MSTR.At("DOC_NBR"));

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




