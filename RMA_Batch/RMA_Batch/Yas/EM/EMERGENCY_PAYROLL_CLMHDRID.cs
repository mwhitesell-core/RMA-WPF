
#region "Screen Comments"

// doc     : emergency_payroll_clmhdrid.qts         
// purpose : report by doc Value in payroll field in f002 for dept 41, 42, 43 or 75
// ; THIS report is by clmhdrid - there are two other programs one by doc by dept and one by month by location
// who     : department head
// *************************************************************
// Date           Who            Description
// 2010/10/28     Yasemin
// 2016/08/29     Yasemin        modify dates for 20160701 - 20170630


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class EMERGENCY_PAYROLL_CLMHDRID : BaseClassControl
{

    private EMERGENCY_PAYROLL_CLMHDRID m_EMERGENCY_PAYROLL_CLMHDRID;

    public EMERGENCY_PAYROLL_CLMHDRID(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public EMERGENCY_PAYROLL_CLMHDRID(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_EMERGENCY_PAYROLL_CLMHDRID != null))
        {
            m_EMERGENCY_PAYROLL_CLMHDRID.CloseTransactionObjects();
            m_EMERGENCY_PAYROLL_CLMHDRID = null;
        }
    }

    public EMERGENCY_PAYROLL_CLMHDRID GetEMERGENCY_PAYROLL_CLMHDRID(int Level)
    {
        if (m_EMERGENCY_PAYROLL_CLMHDRID == null)
        {
            m_EMERGENCY_PAYROLL_CLMHDRID = new EMERGENCY_PAYROLL_CLMHDRID("EMERGENCY_PAYROLL_CLMHDRID", Level);
        }
        else
        {
            m_EMERGENCY_PAYROLL_CLMHDRID.ResetValues();
        }
        return m_EMERGENCY_PAYROLL_CLMHDRID;
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

            EMERGENCY_PAYROLL_CLMHDRID_ONE_1 ONE_1 = new EMERGENCY_PAYROLL_CLMHDRID_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            EMERGENCY_PAYROLL_CLMHDRID_TWO_2 TWO_2 = new EMERGENCY_PAYROLL_CLMHDRID_TWO_2(Name, Level);
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



public class EMERGENCY_PAYROLL_CLMHDRID_ONE_1 : EMERGENCY_PAYROLL_CLMHDRID
{

    public EMERGENCY_PAYROLL_CLMHDRID_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePAYROLL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PAYROLL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR_HDR.Choose += fleF002_CLAIMS_MSTR_Choose;
        X_CLAIM.GetValue += X_CLAIM_GetValue;
        X_CLINIC.GetValue += X_CLINIC_GetValue;
        CLMHDR_PAYROLL.GetValue += CLMHDR_PAYROLL_GetValue;
        CLMHDR_CLAIM_ID.GetValue += CLMHDR_CLAIM_ID_GetValue;

        fleF002_CLAIMS_MSTR_HDR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;
    }

    #region "Declarations (Variables, Files and Transactions)(EMERGENCY_PAYROLL_CLMHDRID_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR_HDR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" =  'C' AND ");
            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  41 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  42 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  43 OR ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  75 ))");


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

            strSQL.Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("B"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("00000"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
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
            Value= QDesign.Substring(fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 10);
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
            Value= QDesign.Substring(fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 2);
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


    private SqlFileObject flePAYROLL;

    private DCharacter CLMHDR_PAYROLL = new DCharacter("CLMHDR_PAYROLL", 1);
    private void CLMHDR_PAYROLL_GetValue(ref string Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_HOSP");
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
            Value = fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_ADJ_NBR");
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


    #region "Standard Generated Procedures(EMERGENCY_PAYROLL_CLMHDRID_ONE_1)"


    #region "Automatic Item Initialization(EMERGENCY_PAYROLL_CLMHDRID_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERGENCY_PAYROLL_CLMHDRID_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:49 PM

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
        fleF002_CLAIMS_MSTR_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePAYROLL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERGENCY_PAYROLL_CLMHDRID_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:49 PM

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
            fleF002_CLAIMS_MSTR_HDR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            flePAYROLL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERGENCY_PAYROLL_CLMHDRID_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF002_CLAIMS_MSTR_HDR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--

                fleF002_CLAIMS_MSTR_HDR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 3, 3))));
                    //Parent:CLMHDR_CLAIM_ID

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {


                        SubFile(ref m_trnTRANS_UPDATE, ref flePAYROLL, SubFileType.Keep, CLMHDR_CLAIM_ID, fleF002_CLAIMS_MSTR_HDR,  "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLAIM, X_CLINIC, CLMHDR_PAYROLL,
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



public class EMERGENCY_PAYROLL_CLMHDRID_TWO_2 : EMERGENCY_PAYROLL_CLMHDRID
{

    public EMERGENCY_PAYROLL_CLMHDRID_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePAYROLL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PAYROLL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePAYROLL2_CLMID = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PAYROLL2_CLMID", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERGENCY_PAYROLL_CLMHDRID_TWO_2)"

    private SqlFileObject flePAYROLL;

    public override bool SelectIf()
    {


        try
        {
            if (flePAYROLL.GetNumericDateValue("CLMHDR_SERV_DATE") >= 20160701 & flePAYROLL.GetNumericDateValue("CLMHDR_SERV_DATE") <= 20170630)
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


    private SqlFileObject flePAYROLL2_CLMID;


    #endregion


    #region "Standard Generated Procedures(EMERGENCY_PAYROLL_CLMHDRID_TWO_2)"


    #region "Automatic Item Initialization(EMERGENCY_PAYROLL_CLMHDRID_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERGENCY_PAYROLL_CLMHDRID_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:49 PM

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
        flePAYROLL.Transaction = m_trnTRANS_UPDATE;
        flePAYROLL2_CLMID.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERGENCY_PAYROLL_CLMHDRID_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:49 PM

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
            flePAYROLL.Dispose();
            flePAYROLL2_CLMID.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERGENCY_PAYROLL_CLMHDRID_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (flePAYROLL.QTPForMissing())
            {
                // --> GET PAYROLL <--

                flePAYROLL.GetData();
                // --> End GET PAYROLL <--

                if (Transaction())
                {

                     if (Select_If())
                    {

                        Sort(flePAYROLL.GetSortValue("DOC_NAME"), flePAYROLL.GetSortValue("CLMHDR_PAYROLL"));



                    }

                }

            }


            while (Sort(flePAYROLL))
            {

                SubFile(ref m_trnTRANS_UPDATE, ref flePAYROLL2_CLMID, SubFileType.Portable, flePAYROLL, "X_CLAIM", COMMA, "X_CLINIC", "CLMHDR_DOC_DEPT", "DOC_NBR", "DOC_NAME",
                "CLMHDR_SERV_DATE", "CLMHDR_LOC", "CLMHDR_PAYROLL");
                //Parent:CLMHDR_CLAIM_ID)    'Parent:DOC_INITS


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




