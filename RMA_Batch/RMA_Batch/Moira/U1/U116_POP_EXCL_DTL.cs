
#region "Screen Comments"

// 2016/Feb/08 - u116_pop_excl_dtl.qts        
// - this program will be called from m116.qks when user activates the designer 
// procedure `excl` to populate f116-dtl  records
// select all doctors that are excluded tithe in selected dept and group


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U116_POP_EXCL_DTL : BaseClassControl
{

    private U116_POP_EXCL_DTL m_U116_POP_EXCL_DTL;

    public U116_POP_EXCL_DTL(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U116_POP_EXCL_DTL(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U116_POP_EXCL_DTL != null))
        {
            m_U116_POP_EXCL_DTL.CloseTransactionObjects();
            m_U116_POP_EXCL_DTL = null;
        }
    }

    public U116_POP_EXCL_DTL GetU116_POP_EXCL_DTL(int Level)
    {
        if (m_U116_POP_EXCL_DTL == null)
        {
            m_U116_POP_EXCL_DTL = new U116_POP_EXCL_DTL("U116_POP_EXCL_DTL", Level);
        }
        else
        {
            m_U116_POP_EXCL_DTL.ResetValues();
        }
        return m_U116_POP_EXCL_DTL;
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

            U116_POP_EXCL_DTL_ONE_1 ONE_1 = new U116_POP_EXCL_DTL_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            U116_POP_EXCL_DTL_TWO_2 TWO_2 = new U116_POP_EXCL_DTL_TWO_2(Name, Level);
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



public class U116_POP_EXCL_DTL_ONE_1 : U116_POP_EXCL_DTL
{

    public U116_POP_EXCL_DTL_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF116_DEPT_EXPENSE_RULES_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F116_DEPT_EXPENSE_RULES_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleTEMP1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "TEMP1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF116_DEPT_EXPENSE_RULES_HDR.Choose += fleF116_DEPT_EXPENSE_RULES_HDR_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_POP_EXCL_DTL_ONE_1)"

    private SqlFileObject fleF116_DEPT_EXPENSE_RULES_HDR;

    private void fleF116_DEPT_EXPENSE_RULES_HDR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("FLAT+3_TITHE_LEVELS"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DEPT_NBR"));
            strSQL.Append(" IN(");
            strSQL.Append(Prompt(1).ToString());
            strSQL.Append(")");

            strSQL.Append(" AND ");
            strSQL.Append(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DOC_AFP_PAYM_GROUP"));
            strSQL.Append(" IN(");
            strSQL.Append(Common.StringToField(Prompt(2).ToString()));
            strSQL.Append(")");

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
            if (QDesign.NULL(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("TITHE_IN_EX_CLUDE_FLAG")) == "E" & QDesign.NULL(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_NBR")) != "000")
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

    private SqlFileObject fleTEMP1;


    #endregion


    #region "Standard Generated Procedures(U116_POP_EXCL_DTL_ONE_1)"


    #region "Automatic Item Initialization(U116_POP_EXCL_DTL_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_POP_EXCL_DTL_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:49:00 PM

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
        fleF116_DEPT_EXPENSE_RULES_HDR.Transaction = m_trnTRANS_UPDATE;
        fleTEMP1.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U116_POP_EXCL_DTL_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:49:00 PM

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
            fleF116_DEPT_EXPENSE_RULES_HDR.Dispose();
            fleTEMP1.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_POP_EXCL_DTL_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF116_DEPT_EXPENSE_RULES_HDR.QTPForMissing())
            {
                // --> GET F116_DEPT_EXPENSE_RULES_HDR <--

                fleF116_DEPT_EXPENSE_RULES_HDR.GetData();
                // --> End GET F116_DEPT_EXPENSE_RULES_HDR <--

                if (Transaction())
                {

                     if (Select_If())
                    {
                        SubFile(ref m_trnTRANS_UPDATE, ref fleTEMP1, SubFileType.Keep, fleF116_DEPT_EXPENSE_RULES_HDR);


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



public class U116_POP_EXCL_DTL_TWO_2 : U116_POP_EXCL_DTL
{

    public U116_POP_EXCL_DTL_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleTEMP1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "TEMP1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF116_DEPT_EXPENSE_RULES_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F116_DEPT_EXPENSE_RULES_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF116_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F116_DEPT_EXPENSE_RULES_DTL", "F116_DOC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF116_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F116_DEPT_EXPENSE_RULES_DTL", "F116_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF116_ADD.SetItemFinals += fleF116_ADD_SetItemFinals;
        fleF116_DOC.InitializeItems += fleF116_DOC_AutomaticItemInitialization;
        fleF116_ADD.InitializeItems += fleF116_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_POP_EXCL_DTL_TWO_2)"

    private SqlFileObject fleTEMP1;
    private SqlFileObject fleF116_DEPT_EXPENSE_RULES_DTL;
    private SqlFileObject fleF116_DOC;
    private SqlFileObject fleF116_ADD;

    private void fleF116_ADD_SetItemFinals()
    {

        try
        {
            fleF116_ADD.set_SetValue("DOC_NBR", fleTEMP1.GetStringValue("DOC_NBR"));
            fleF116_ADD.set_SetValue("TITHE_IN_EX_CLUDE_FLAG", "E");


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


    #region "Standard Generated Procedures(U116_POP_EXCL_DTL_TWO_2)"


    #region "Automatic Item Initialization(U116_POP_EXCL_DTL_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:49:03 PM

    //#-----------------------------------------
    //# fleF116_DOC_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:49:02 PM
    //#-----------------------------------------
    private void fleF116_DOC_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF116_DOC.set_SetValue("DEPT_EXPENSE_CALC_CODE", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DEPT_EXPENSE_CALC_CODE"));
            fleF116_DOC.set_SetValue("DEPT_NBR", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetDecimalValue("DEPT_NBR"));
            fleF116_DOC.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF116_DOC.set_SetValue("DOC_NBR", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DOC_NBR"));
            fleF116_DOC.set_SetValue("COMP_CODE", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("COMP_CODE"));
            fleF116_DOC.set_SetValue("DESC_LONG", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DESC_LONG"));
            fleF116_DOC.set_SetValue("DESC_SHORT", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DESC_SHORT"));
            fleF116_DOC.set_SetValue("TITHE_IN_EX_CLUDE_FLAG", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("TITHE_IN_EX_CLUDE_FLAG"));
            fleF116_DOC.set_SetValue("FLAG_DISPLAY_HIDE", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("FLAG_DISPLAY_HIDE"));

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
    //# fleF116_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:49:03 PM
    //#-----------------------------------------
    private void fleF116_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF116_ADD.set_SetValue("DEPT_EXPENSE_CALC_CODE", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DEPT_EXPENSE_CALC_CODE"));
            fleF116_ADD.set_SetValue("DEPT_NBR", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetDecimalValue("DEPT_NBR"));
            fleF116_ADD.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF116_ADD.set_SetValue("DOC_NBR", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DOC_NBR"));
            fleF116_ADD.set_SetValue("COMP_CODE", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("COMP_CODE"));
            fleF116_ADD.set_SetValue("DESC_LONG", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DESC_LONG"));
            fleF116_ADD.set_SetValue("DESC_SHORT", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DESC_SHORT"));
            fleF116_ADD.set_SetValue("TITHE_IN_EX_CLUDE_FLAG", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("TITHE_IN_EX_CLUDE_FLAG"));
            fleF116_ADD.set_SetValue("FLAG_DISPLAY_HIDE", !Fixed, fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("FLAG_DISPLAY_HIDE"));

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


    #region "Transaction Management Procedures(U116_POP_EXCL_DTL_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:49:00 PM

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
        fleTEMP1.Transaction = m_trnTRANS_UPDATE;
        fleF116_DEPT_EXPENSE_RULES_DTL.Transaction = m_trnTRANS_UPDATE;
        fleF116_DOC.Transaction = m_trnTRANS_UPDATE;
        fleF116_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U116_POP_EXCL_DTL_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:49:00 PM

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
            fleTEMP1.Dispose();
            fleF116_DEPT_EXPENSE_RULES_DTL.Dispose();
            fleF116_DOC.Dispose();
            fleF116_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_POP_EXCL_DTL_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleTEMP1.QTPForMissing())
            {
                // --> GET TEMP1 <--

                fleTEMP1.GetData();
                // --> End GET TEMP1 <--

                while (fleF116_DEPT_EXPENSE_RULES_DTL.QTPForMissing("1"))
                {
                    // --> GET F116_DEPT_EXPENSE_RULES_DTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DEPT_EXPENSE_CALC_CODE")));
                    m_strWhere.Append(" And ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DEPT_NBR")).Append(" = ");
                    m_strWhere.Append((fleF116_DEPT_EXPENSE_RULES_DTL.GetDecimalValue("DEPT_NBR")));
                    m_strWhere.Append(" And ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DOC_AFP_PAYM_GROUP")));
                    m_strWhere.Append(" And ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("000"));

                    fleF116_DEPT_EXPENSE_RULES_DTL.GetData(m_strWhere.ToString());
                    // --> End GET F116_DEPT_EXPENSE_RULES_DTL <--

                    while (fleF116_DOC.QTPForMissing("2"))
                    {
                        // --> GET F116_DOC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF116_DOC.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DEPT_EXPENSE_CALC_CODE")));
                        m_strWhere.Append(" And ").Append(fleF116_DOC.ElementOwner("DEPT_NBR")).Append(" = ");
                        m_strWhere.Append((fleF116_DEPT_EXPENSE_RULES_DTL.GetDecimalValue("DEPT_NBR")));
                        m_strWhere.Append(" And ").Append(fleF116_DOC.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DOC_AFP_PAYM_GROUP")));
                        m_strWhere.Append(" And ").Append(fleF116_DOC.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleTEMP1.GetStringValue("DOC_NBR")));

                        fleF116_DOC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F116_DOC <--


                        if (Transaction())
                        {
                            fleF116_ADD.OutPut(OutPutType.Add, null, !fleF116_DOC.Exists());

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
            EndRequest("TWO_2");

        }

    }







    #endregion


}
//TWO_2




