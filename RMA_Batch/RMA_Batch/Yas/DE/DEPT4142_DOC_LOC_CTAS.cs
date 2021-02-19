
#region "Screen Comments"

// doc     : dept4142_bydoc_byloc.qts            
// purpose : report by doc - patient count - separated by location -  H  vs  G 
// *************************************************************


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class DEPT4142_DOC_LOC_CTAS : BaseClassControl
{

    private DEPT4142_DOC_LOC_CTAS m_DEPT4142_DOC_LOC_CTAS;

    public DEPT4142_DOC_LOC_CTAS(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public DEPT4142_DOC_LOC_CTAS(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_DEPT4142_DOC_LOC_CTAS != null))
        {
            m_DEPT4142_DOC_LOC_CTAS.CloseTransactionObjects();
            m_DEPT4142_DOC_LOC_CTAS = null;
        }
    }

    public DEPT4142_DOC_LOC_CTAS GetDEPT4142_DOC_LOC_CTAS(int Level)
    {
        if (m_DEPT4142_DOC_LOC_CTAS == null)
        {
            m_DEPT4142_DOC_LOC_CTAS = new DEPT4142_DOC_LOC_CTAS("DEPT4142_DOC_LOC_CTAS", Level);
        }
        else
        {
            m_DEPT4142_DOC_LOC_CTAS.ResetValues();
        }
        return m_DEPT4142_DOC_LOC_CTAS;
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

            DEPT4142_DOC_LOC_CTAS_ONE_1 ONE_1 = new DEPT4142_DOC_LOC_CTAS_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            DEPT4142_DOC_LOC_CTAS_TWO_2 TWO_2 = new DEPT4142_DOC_LOC_CTAS_TWO_2(Name, Level);
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



public class DEPT4142_DOC_LOC_CTAS_ONE_1 : DEPT4142_DOC_LOC_CTAS
{

    public DEPT4142_DOC_LOC_CTAS_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePAYROLLCTAS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PAYROLLCTAS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;
        X_CLAIM.GetValue += X_CLAIM_GetValue;
        X_CLINIC.GetValue += X_CLINIC_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(DEPT4142_DOC_LOC_CTAS_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" =  'C' AND ");
            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  41 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  42 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  43 ))");


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
    private DCharacter X_CLINIC = new DCharacter("X_CLINIC", 2);
    private void X_CLINIC_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 2);
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


    private SqlFileObject flePAYROLLCTAS;


    #endregion


    #region "Standard Generated Procedures(DEPT4142_DOC_LOC_CTAS_ONE_1)"


    #region "Automatic Item Initialization(DEPT4142_DOC_LOC_CTAS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEPT4142_DOC_LOC_CTAS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:07 PM

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
        flePAYROLLCTAS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEPT4142_DOC_LOC_CTAS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:07 PM

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
            flePAYROLLCTAS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEPT4142_DOC_LOC_CTAS_ONE_1)"


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


                        SubFile(ref m_trnTRANS_UPDATE, ref flePAYROLLCTAS, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMHDR_CLAIM_ID", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLAIM, X_CLINIC, "CLMHDR_PAYROLL",
                        "CLMHDR_DOC_DEPT", "CLMHDR_LOC", "CLMHDR_SERV_DATE", fleF020_DOCTOR_MSTR);
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



public class DEPT4142_DOC_LOC_CTAS_TWO_2 : DEPT4142_DOC_LOC_CTAS
{

    public DEPT4142_DOC_LOC_CTAS_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePAYROLLCTAS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PAYROLLCTAS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        CTAS1_COUNT = new CoreDecimal("CTAS1_COUNT", 6, this);
        CTAS2_COUNT = new CoreDecimal("CTAS2_COUNT", 6, this);
        CTAS3_COUNT = new CoreDecimal("CTAS3_COUNT", 6, this);
        CTAS4_COUNT = new CoreDecimal("CTAS4_COUNT", 6, this);
        CTAS5_COUNT = new CoreDecimal("CTAS5_COUNT", 6, this);
        CTAS0_COUNT = new CoreDecimal("CTAS0_COUNT", 6, this);
        flePAYROLLCTAS1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PAYROLLCTAS1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_LOC.GetValue += X_LOC_GetValue;
        X_MONTH.GetValue += X_MONTH_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(DEPT4142_DOC_LOC_CTAS_TWO_2)"

    private SqlFileObject flePAYROLLCTAS;

    public override bool SelectIf()
    {


        try
        {
            if (flePAYROLLCTAS.GetNumericDateValue("CLMHDR_SERV_DATE") >= 20150401 & flePAYROLLCTAS.GetNumericDateValue("CLMHDR_SERV_DATE") <= 20160331)
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

    private DCharacter X_LOC = new DCharacter("X_LOC", 1);
    private void X_LOC_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(flePAYROLLCTAS.GetStringValue("CLMHDR_LOC"), 1, 4);


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DCharacter X_MONTH = new DCharacter("X_MONTH", 6);
    private void X_MONTH_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(QDesign.ASCII(flePAYROLLCTAS.GetNumericDateValue("CLMHDR_SERV_DATE")), 1, 6);


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private CoreDecimal CTAS1_COUNT;
    private CoreDecimal CTAS2_COUNT;
    private CoreDecimal CTAS3_COUNT;
    private CoreDecimal CTAS4_COUNT;
    private CoreDecimal CTAS5_COUNT;
    private CoreDecimal CTAS0_COUNT;
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


    private SqlFileObject flePAYROLLCTAS1;


    #endregion


    #region "Standard Generated Procedures(DEPT4142_DOC_LOC_CTAS_TWO_2)"


    #region "Automatic Item Initialization(DEPT4142_DOC_LOC_CTAS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEPT4142_DOC_LOC_CTAS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:07 PM

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
        flePAYROLLCTAS.Transaction = m_trnTRANS_UPDATE;
        flePAYROLLCTAS1.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEPT4142_DOC_LOC_CTAS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:33:07 PM

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
            flePAYROLLCTAS.Dispose();
            flePAYROLLCTAS1.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEPT4142_DOC_LOC_CTAS_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (flePAYROLLCTAS.QTPForMissing())
            {
                // --> GET PAYROLLCTAS <--

                flePAYROLLCTAS.GetData();
                // --> End GET PAYROLLCTAS <--

                if (Transaction())
                {

                     if (Select_If())
                    {

                        Sort(flePAYROLLCTAS.GetSortValue("DOC_NBR"));



                    }

                }

            }

            while (Sort(flePAYROLLCTAS))
            {
                if (QDesign.NULL(flePAYROLLCTAS.GetStringValue("CLMHDR_PAYROLL")) == "1")
                {
                    CTAS1_COUNT.Value = CTAS1_COUNT.Value + 1;
                }
                if (QDesign.NULL(flePAYROLLCTAS.GetStringValue("CLMHDR_PAYROLL")) == "2")
                {
                    CTAS2_COUNT.Value = CTAS2_COUNT.Value + 1;
                }
                if (QDesign.NULL(flePAYROLLCTAS.GetStringValue("CLMHDR_PAYROLL")) == "3")
                {
                    CTAS3_COUNT.Value = CTAS3_COUNT.Value + 1;
                }
                if (QDesign.NULL(flePAYROLLCTAS.GetStringValue("CLMHDR_PAYROLL")) == "4")
                {
                    CTAS4_COUNT.Value = CTAS4_COUNT.Value + 1;
                }
                if (QDesign.NULL(flePAYROLLCTAS.GetStringValue("CLMHDR_PAYROLL")) == "5")
                {
                    CTAS5_COUNT.Value = CTAS5_COUNT.Value + 1;
                }
                if (QDesign.NULL(flePAYROLLCTAS.GetStringValue("CLMHDR_PAYROLL")) == QDesign.NULL(" ") | QDesign.NULL(flePAYROLLCTAS.GetStringValue("CLMHDR_PAYROLL")) == "0" | string.Compare(QDesign.NULL(flePAYROLLCTAS.GetStringValue("CLMHDR_PAYROLL")), "5") > 0)
                {
                    CTAS0_COUNT.Value = CTAS0_COUNT.Value + 1;
                }



                SubFile(ref m_trnTRANS_UPDATE, ref flePAYROLLCTAS1, flePAYROLLCTAS.At("DOC_NBR"), SubFileType.Portable, flePAYROLLCTAS, "DOC_DEPT", COMMA, "DOC_NBR", "DOC_NAME", "CLMHDR_LOC",
                CTAS1_COUNT, CTAS2_COUNT, CTAS3_COUNT, CTAS4_COUNT, CTAS5_COUNT, CTAS0_COUNT, X_CR);
                //Parent:CLMHDR_CLAIM_ID)    'Parent:DOC_INITS


                Reset(ref CTAS1_COUNT, flePAYROLLCTAS.At("DOC_NBR"));
                Reset(ref CTAS2_COUNT, flePAYROLLCTAS.At("DOC_NBR"));
                Reset(ref CTAS3_COUNT, flePAYROLLCTAS.At("DOC_NBR"));
                Reset(ref CTAS4_COUNT, flePAYROLLCTAS.At("DOC_NBR"));
                Reset(ref CTAS5_COUNT, flePAYROLLCTAS.At("DOC_NBR"));
                Reset(ref CTAS0_COUNT, flePAYROLLCTAS.At("DOC_NBR"));

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




