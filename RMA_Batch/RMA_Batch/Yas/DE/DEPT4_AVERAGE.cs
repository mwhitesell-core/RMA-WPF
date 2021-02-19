
#region "Screen Comments"

// doc     : dept4_average.qts
// purpose : create report by doctor and report doc# name and average amount date-entered vs service-date
// for department 4  select service date from July 1, 2010 to June 30, 2011
// who     : Lisa Greer Annette Rosati
// *************************************************************
// Date           Who             Description
// 2011/06/07     Yasemin       


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class DEPT4_AVERAGE : BaseClassControl
{

    private DEPT4_AVERAGE m_DEPT4_AVERAGE;

    public DEPT4_AVERAGE(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public DEPT4_AVERAGE(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_DEPT4_AVERAGE != null))
        {
            m_DEPT4_AVERAGE.CloseTransactionObjects();
            m_DEPT4_AVERAGE = null;
        }
    }

    public DEPT4_AVERAGE GetDEPT4_Average(ref int Level)
    {
        if (m_DEPT4_AVERAGE == null)
        {
            m_DEPT4_AVERAGE = new DEPT4_AVERAGE("DEPT4_AVERAGE", Level);
        }
        else
        {
            m_DEPT4_AVERAGE.ResetValues();
        }
        return m_DEPT4_AVERAGE;
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

            DEPT4_AVERAGE_ONE_1 ONE_1 = new DEPT4_AVERAGE_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            DEPT4_AVERAGE_TWO_2 TWO_2 = new DEPT4_AVERAGE_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

            DEPT4_AVERAGE_THREE_3 THREE_3 = new DEPT4_AVERAGE_THREE_3(Name, Level);
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



public class DEPT4_AVERAGE_ONE_1 : DEPT4_AVERAGE
{

    public DEPT4_AVERAGE_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleAVERAGE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "AVERAGE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;
        X_CLAIM.GetValue += X_CLAIM_GetValue;
        X_DAYS.GetValue += X_DAYS_GetValue;
        CLMHDR_CLAIM_ID.GetValue += CLMHDR_CLAIM_ID_GetValue;
        DOC_INITS.GetValue += DOC_INITS_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(DEPT4_AVERAGE_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" =  'C' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  4 AND ");
            strSQL.Append("  ").Append(GetWhereClauseString(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_SERV_DATE"), ">=", 20160701)).Append(" AND ");
            strSQL.Append("  ").Append(GetWhereClauseString(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_SERV_DATE"), "<=", 20170630)).Append(")");


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

    private DCharacter X_CLAIM = new DCharacter("X_CLAIM", 10);
    private void X_CLAIM_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 10);
            //Parent:CLMHDR_CLAIM_ID


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
    private DDecimal X_DAYS = new DDecimal("X_DAYS", 4);
    private void X_DAYS_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.Days(QDesign.NConvert(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_DATE_SYS"))) - QDesign.Days(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SERV_DATE"));


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

    private SqlFileObject fleAVERAGE;


    #endregion


    #region "Standard Generated Procedures(DEPT4_AVERAGE_ONE_1)"


    #region "Automatic Item Initialization(DEPT4_AVERAGE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEPT4_AVERAGE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:04 PM

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
        fleAVERAGE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEPT4_AVERAGE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:04 PM

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
            fleAVERAGE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEPT4_AVERAGE_ONE_1)"


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
                        SubFile(ref m_trnTRANS_UPDATE, ref fleAVERAGE, SubFileType.Keep, CLMHDR_CLAIM_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", X_CLAIM,
                        fleF002_CLAIMS_MSTR, "CLMHDR_DOC_DEPT", "CLMHDR_SERV_DATE", "CLMHDR_DATE_SYS", X_DAYS, fleF020_DOCTOR_MSTR, "DOC_NBR", "DOC_NAME", DOC_INITS);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:DOC_INITS
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



public class DEPT4_AVERAGE_TWO_2 : DEPT4_AVERAGE
{

    public DEPT4_AVERAGE_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleAVERAGE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "AVERAGE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_TOT_DAYS = new CoreDecimal("X_TOT_DAYS", 8, this);
        CLAIM_COUNT = new CoreDecimal("CLAIM_COUNT", 6, this);
        fleAVERAGE1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "AVERAGE1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(DEPT4_AVERAGE_TWO_2)"

    private SqlFileObject fleAVERAGE;
    private CoreDecimal X_TOT_DAYS;

    private CoreDecimal CLAIM_COUNT;

    private SqlFileObject fleAVERAGE1;


    #endregion


    #region "Standard Generated Procedures(DEPT4_AVERAGE_TWO_2)"


    #region "Automatic Item Initialization(DEPT4_AVERAGE_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEPT4_AVERAGE_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:04 PM

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
        fleAVERAGE.Transaction = m_trnTRANS_UPDATE;
        fleAVERAGE1.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEPT4_AVERAGE_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:04 PM

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
            fleAVERAGE.Dispose();
            fleAVERAGE1.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEPT4_AVERAGE_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleAVERAGE.QTPForMissing())
            {
                // --> GET AVERAGE <--

                fleAVERAGE.GetData();
                // --> End GET AVERAGE <--


                if (Transaction())
                {

                    Sort(fleAVERAGE.GetSortValue("DOC_OHIP_NBR"), fleAVERAGE.GetSortValue("CLMHDR_SERV_DATE"));



                }

            }

            while (Sort(fleAVERAGE))
            {
                X_TOT_DAYS.Value = X_TOT_DAYS.Value + fleAVERAGE.GetDecimalValue("X_DAYS");
                CLAIM_COUNT.Value = CLAIM_COUNT.Value + 1;



                SubFile(ref m_trnTRANS_UPDATE, ref fleAVERAGE1, fleAVERAGE.At("DOC_OHIP_NBR"), SubFileType.Keep, fleAVERAGE, "CLMHDR_DOC_DEPT", "DOC_NBR", "DOC_NAME", "DOC_INITS", X_TOT_DAYS,
                CLAIM_COUNT, "CLMHDR_SERV_DATE");
                //Parent:CLMHDR_CLAIM_ID)    'Parent:DOC_INITS


                Reset(ref X_TOT_DAYS, fleAVERAGE.At("DOC_OHIP_NBR"));
                Reset(ref CLAIM_COUNT, fleAVERAGE.At("DOC_OHIP_NBR"));

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



public class DEPT4_AVERAGE_THREE_3 : DEPT4_AVERAGE
{

    public DEPT4_AVERAGE_THREE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleAVERAGE1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "AVERAGE1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_AVERAGE = new CoreDecimal("X_AVERAGE", 6, this);
        fleAVERAGE2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "AVERAGE2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(DEPT4_AVERAGE_THREE_3)"

    private SqlFileObject fleAVERAGE1;
    private CoreDecimal X_AVERAGE;
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


    private SqlFileObject fleAVERAGE2;


    #endregion


    #region "Standard Generated Procedures(DEPT4_AVERAGE_THREE_3)"


    #region "Automatic Item Initialization(DEPT4_AVERAGE_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEPT4_AVERAGE_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:04 PM

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
        fleAVERAGE1.Transaction = m_trnTRANS_UPDATE;
        fleAVERAGE2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEPT4_AVERAGE_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:04 PM

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
            fleAVERAGE1.Dispose();
            fleAVERAGE2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEPT4_AVERAGE_THREE_3)"


    public void Run()
    {

        try
        {
            Request("THREE_3");

            while (fleAVERAGE1.QTPForMissing())
            {
                // --> GET AVERAGE1 <--

                fleAVERAGE1.GetData();
                // --> End GET AVERAGE1 <--


                if (Transaction())
                {
                    X_AVERAGE.Value = fleAVERAGE1.GetDecimalValue("X_TOT_DAYS") / fleAVERAGE1.GetDecimalValue("CLAIM_COUNT") * 100;


                    SubFile(ref m_trnTRANS_UPDATE, ref fleAVERAGE2, SubFileType.Portable, fleAVERAGE1, "CLMHDR_DOC_DEPT", COMMA, "DOC_NBR", "DOC_NAME", "DOC_INITS", "CLAIM_COUNT",
                    X_AVERAGE, "CLMHDR_SERV_DATE", X_CR);
                    //Parent:CLMHDR_CLAIM_ID)    'Parent:DOC_INITS


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
            EndRequest("THREE_3");

        }

    }




    #endregion


}
//THREE_3




