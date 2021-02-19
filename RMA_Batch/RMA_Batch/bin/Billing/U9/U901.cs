
#region "Screen Comments"

// UPDATE F050, F051, AND F060 FILES
// 95/05/26 M. CHAN - F060 DOES NOT EXIST ANY MORE, COMMENT
// 99/10/20 M. CHAN - add set lock file update statement   
// 2000/03/02    M. CHAN - update f050 history and claims mstr as well
// 2000/10/30    M. CHAN - update f050 history for the current fiscal periods
// 2003/dec/24   A.A. - alpha doctor nbr
// 2004/04/07    M. CHAN - change x-doc-nbr to base on clmhdr-claim-id instead
// of key-clm-batch-nbr
// 2006/06/19    M. CHAN - change x-doc-nbr to base on clmhdr-claim-id with the
// correct offset/alignment
// REQUEST UPDATE_F060
// ACCESS F060-CHEQUE-REG-MSTR
// CHOOSE CHQ-REG-KEY PARM PROMPT `ENTER THE OLD CHQ REG KEY: `
// DEFINE NEW-CHQ-KEY CHAR*7 = PARM PROMPT `ENTER THE NEW CHQ REG KEY: `
// OUTPUT F060-CHEQUE-REG-MSTR UPDATE
// ITEM CHQ-REG-KEY FINAL NEW-CHQ-KEY
// !global temporary doc-nbr zoned*3 unsigned  parm prompt `ENTER THE DOCTOR NO:   `


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U901 : BaseClassControl
{

    private U901 m_U901;

    public U901(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        DOC_NBR = new CoreCharacter("DOC_NBR", 3, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());
        NEW_DEPT_NO = new CoreDecimal("NEW_DEPT_NO", 2, this, ResetTypes.ResetAtStartup, (Prompt(2)));
        X_PED = new CoreDate("X_PED", this, ResetTypes.ResetAtStartup, (Prompt(3)));


    }

    public U901(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        DOC_NBR = new CoreCharacter("DOC_NBR", 3, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());
        NEW_DEPT_NO = new CoreDecimal("NEW_DEPT_NO", 2, this, ResetTypes.ResetAtStartup, (Prompt(2)));
        X_PED = new CoreDate("X_PED", this, ResetTypes.ResetAtStartup, (Prompt(3)));


    }

    public override void Dispose()
    {
        if ((m_U901 != null))
        {
            m_U901.CloseTransactionObjects();
            m_U901 = null;
        }
    }

    public U901 GetU901(int Level)
    {
        if (m_U901 == null)
        {
            m_U901 = new U901("U901", Level);
        }
        else
        {
            m_U901.ResetValues();
        }
        return m_U901;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreCharacter DOC_NBR;
    protected CoreDecimal NEW_DEPT_NO;

    protected CoreDate X_PED;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U901_UPDATE_F050_1 UPDATE_F050_1 = new U901_UPDATE_F050_1(Name, Level);
            UPDATE_F050_1.Run();
            UPDATE_F050_1.Dispose();
            UPDATE_F050_1 = null;

            U901_UPDATE_F051_2 UPDATE_F051_2 = new U901_UPDATE_F051_2(Name, Level);
            UPDATE_F051_2.Run();
            UPDATE_F051_2.Dispose();
            UPDATE_F051_2 = null;

            U901_UPDATE_F050_HISTORY_3 UPDATE_F050_HISTORY_3 = new U901_UPDATE_F050_HISTORY_3(Name, Level);
            UPDATE_F050_HISTORY_3.Run();
            UPDATE_F050_HISTORY_3.Dispose();
            UPDATE_F050_HISTORY_3 = null;

            U901_UPDATE_F002_4 UPDATE_F002_4 = new U901_UPDATE_F002_4(Name, Level);
            UPDATE_F002_4.Run();
            UPDATE_F002_4.Dispose();
            UPDATE_F002_4 = null;

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



public class U901_UPDATE_F050_1 : U901
{

    public U901_UPDATE_F050_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF050_DOC_REVENUE_MSTR.SetItemFinals += fleF050_DOC_REVENUE_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U901_UPDATE_F050_1)"

    private SqlFileObject fleF050_DOC_REVENUE_MSTR;

    private void fleF050_DOC_REVENUE_MSTR_SetItemFinals()
    {

        try
        {
            fleF050_DOC_REVENUE_MSTR.set_SetValue("DOCREV_DEPT", NEW_DEPT_NO.Value);


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
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == QDesign.NULL(QDesign.NULL(DOC_NBR.Value)))
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


    #region "Standard Generated Procedures(U901_UPDATE_F050_1)"


    #region "Automatic Item Initialization(U901_UPDATE_F050_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U901_UPDATE_F050_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:31 PM

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
        fleF050_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U901_UPDATE_F050_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:31 PM

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
            fleF050_DOC_REVENUE_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U901_UPDATE_F050_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F050_1");

            while (fleF050_DOC_REVENUE_MSTR.QTPForMissing())
            {
                // --> GET F050_DOC_REVENUE_MSTR <--

                fleF050_DOC_REVENUE_MSTR.GetData();
                // --> End GET F050_DOC_REVENUE_MSTR <--

                if (Transaction())
                {

                     if (Select_If())
                    {

                        fleF050_DOC_REVENUE_MSTR.OutPut(OutPutType.Update);
                        //Parent:CLMHDR_CLAIM_ID

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
            EndRequest("UPDATE_F050_1");

        }

    }




    #endregion


}
//UPDATE_F050_1



public class U901_UPDATE_F051_2 : U901
{

    public U901_UPDATE_F051_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF051_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF051_DOC_CASH_MSTR.SetItemFinals += fleF051_DOC_CASH_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U901_UPDATE_F051_2)"

    private SqlFileObject fleF051_DOC_CASH_MSTR;

    private void fleF051_DOC_CASH_MSTR_SetItemFinals()
    {

        try
        {
            fleF051_DOC_CASH_MSTR.set_SetValue("DOCASH_DEPT", NEW_DEPT_NO.Value);


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
            if (QDesign.NULL(fleF051_DOC_CASH_MSTR.GetStringValue("DOCASH_DOC_NBR")) == QDesign.NULL(QDesign.NULL(DOC_NBR.Value)))
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


    #region "Standard Generated Procedures(U901_UPDATE_F051_2)"


    #region "Automatic Item Initialization(U901_UPDATE_F051_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U901_UPDATE_F051_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:31 PM

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
        fleF051_DOC_CASH_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U901_UPDATE_F051_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:31 PM

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
            fleF051_DOC_CASH_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U901_UPDATE_F051_2)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F051_2");

            while (fleF051_DOC_CASH_MSTR.QTPForMissing())
            {
                // --> GET F051_DOC_CASH_MSTR <--

                fleF051_DOC_CASH_MSTR.GetData();
                // --> End GET F051_DOC_CASH_MSTR <--

                if (Transaction())
                {

                     if (Select_If())
                    {

                        fleF051_DOC_CASH_MSTR.OutPut(OutPutType.Update);
                        //Parent:CLMHDR_CLAIM_ID

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
            EndRequest("UPDATE_F051_2");

        }

    }




    #endregion


}
//UPDATE_F051_2



public class U901_UPDATE_F050_HISTORY_3 : U901
{

    public U901_UPDATE_F050_HISTORY_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF050_DOC_REVENUE_MSTR_HISTORY.SetItemFinals += fleF050_DOC_REVENUE_MSTR_HISTORY_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U901_UPDATE_F050_HISTORY_3)"

    private SqlFileObject fleF050_DOC_REVENUE_MSTR_HISTORY;

    private void fleF050_DOC_REVENUE_MSTR_HISTORY_SetItemFinals()
    {

        try
        {
            fleF050_DOC_REVENUE_MSTR_HISTORY.set_SetValue("DOCREV_DEPT", NEW_DEPT_NO.Value);


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
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR")) == QDesign.NULL(QDesign.NULL(DOC_NBR.Value)) & fleF050_DOC_REVENUE_MSTR_HISTORY.GetNumericDateValue("ICONST_DATE_PERIOD_END") >= X_PED.Value)
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


    #region "Standard Generated Procedures(U901_UPDATE_F050_HISTORY_3)"


    #region "Automatic Item Initialization(U901_UPDATE_F050_HISTORY_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U901_UPDATE_F050_HISTORY_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:31 PM

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
        fleF050_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U901_UPDATE_F050_HISTORY_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:31 PM

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
            fleF050_DOC_REVENUE_MSTR_HISTORY.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U901_UPDATE_F050_HISTORY_3)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F050_HISTORY_3");

            while (fleF050_DOC_REVENUE_MSTR_HISTORY.QTPForMissing())
            {
                // --> GET F050_DOC_REVENUE_MSTR_HISTORY <--

                fleF050_DOC_REVENUE_MSTR_HISTORY.GetData();
                // --> End GET F050_DOC_REVENUE_MSTR_HISTORY <--

                if (Transaction())
                {

                     if (Select_If())
                    {

                        fleF050_DOC_REVENUE_MSTR_HISTORY.OutPut(OutPutType.Update);
                        //Parent:CLMHDR_CLAIM_ID

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
            EndRequest("UPDATE_F050_HISTORY_3");

        }

    }




    #endregion


}
//UPDATE_F050_HISTORY_3



public class U901_UPDATE_F002_4 : U901
{

    public U901_UPDATE_F002_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;
        X_DOC_NBR.GetValue += X_DOC_NBR_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(U901_UPDATE_F002_4)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (   ").Append(Common.StringToField(DOC_NBR.Value)).Append("  =  ").Append(Common.StringToField(X_DOC_NBR.Value)).Append("  AND ");
            strSQL.Append("  ").Append(GetWhereClauseString(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DATE_PERIOD_END"), ">=", X_PED.Value)).Append(")");


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



    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_DOC_DEPT", NEW_DEPT_NO.Value);


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

    private DCharacter X_DOC_NBR = new DCharacter("X_DOC_NBR", 3);
    private void X_DOC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 3, 3);
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



    #endregion


    #region "Standard Generated Procedures(U901_UPDATE_F002_4)"


    #region "Automatic Item Initialization(U901_UPDATE_F002_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U901_UPDATE_F002_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:31 PM

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


    }



    #endregion


    #region "FILE Management Procedures(U901_UPDATE_F002_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:31 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U901_UPDATE_F002_4)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F002_4");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--

                fleF002_CLAIMS_MSTR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--


                if (Transaction())
                {

                    fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update);
                    //Parent:CLMHDR_CLAIM_ID

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
            EndRequest("UPDATE_F002_4");

        }

    }




    #endregion


}
//UPDATE_F002_4




