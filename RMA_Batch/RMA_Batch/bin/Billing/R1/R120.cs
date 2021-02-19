
#region "Screen Comments"

// -----------------------------------------------------------------
// #> PROGRAM-ID.     R120.QTS
// ((C)) Dyad Technologies
// PURPOSE: Print the Earnings Register
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 94/AUG/02  ____   B.M.L.   - original
// 03/nov/20  M.C.  - alpha doc nbr
// 03/dec/16  A.A.  - alpha doctor nbr
// 2010/aug/25         b.e.     - comment out the `set lock record update` command
// -----------------------------------------------------------------
// brad 2010/aug/25 turned off due to error 
// set lock record update


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class R120 : BaseClassControl
{

    private R120 m_R120;

    public R120(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public R120(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_R120 != null))
        {
            m_R120.CloseTransactionObjects();
            m_R120 = null;
        }
    }

    public R120 GetR120(int Level)
    {
        if (m_R120 == null)
        {
            m_R120 = new R120("R120", Level);
        }
        else
        {
            m_R120.ResetValues();
        }
        return m_R120;
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

            R120_EXTRACT_DETAILS_1 EXTRACT_DETAILS_1 = new R120_EXTRACT_DETAILS_1(Name, Level);
            EXTRACT_DETAILS_1.Run();
            EXTRACT_DETAILS_1.Dispose();
            EXTRACT_DETAILS_1 = null;

            R120_BUILD_DEPT_TOTALS_2 BUILD_DEPT_TOTALS_2 = new R120_BUILD_DEPT_TOTALS_2(Name, Level);
            BUILD_DEPT_TOTALS_2.Run();
            BUILD_DEPT_TOTALS_2.Dispose();
            BUILD_DEPT_TOTALS_2 = null;

            R120_BUILD_DEPT_FULL_PART_3 BUILD_DEPT_FULL_PART_3 = new R120_BUILD_DEPT_FULL_PART_3(Name, Level);
            BUILD_DEPT_FULL_PART_3.Run();
            BUILD_DEPT_FULL_PART_3.Dispose();
            BUILD_DEPT_FULL_PART_3 = null;

            R120_BUILD_GRAND_FULL_PART_4 BUILD_GRAND_FULL_PART_4 = new R120_BUILD_GRAND_FULL_PART_4(Name, Level);
            BUILD_GRAND_FULL_PART_4.Run();
            BUILD_GRAND_FULL_PART_4.Dispose();
            BUILD_GRAND_FULL_PART_4 = null;

            R120_BUILD_GRAND_TOTALS_5 BUILD_GRAND_TOTALS_5 = new R120_BUILD_GRAND_TOTALS_5(Name, Level);
            BUILD_GRAND_TOTALS_5.Run();
            BUILD_GRAND_TOTALS_5.Dispose();
            BUILD_GRAND_TOTALS_5 = null;

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



public class R120_EXTRACT_DETAILS_1 : R120
{

    public R120_EXTRACT_DETAILS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR120AA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R120AA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF190_COMP_CODES_TMP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "F190_COMP_CODES_TMP", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR_TMP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "F020_DOCTOR_MSTR_TMP", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF112_PYCDCEILINGS.Choose += fleF112_PYCDCEILINGS_Choose;
        D_CHAR_DOC.GetValue += D_CHAR_DOC_GetValue;
        DOC_NAME.GetValue += D_DOC_NAME_GetValue;
        D_CHAR_DEPT.GetValue += D_CHAR_DEPT_GetValue;
        D_CHAR_F_P_IND.GetValue += D_CHAR_F_P_IND_GetValue;
        fleR120AA.SetItemFinals += fleR120AA_SetItemFinals;
        fleF110_COMPENSATION.InitializeItems += fleF110_COMPENSATION_AutomaticItemInitialization;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        COMPENSATION_FACTOR.GetValue += COMPENSATION_FACTOR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(R120_EXTRACT_DETAILS_1)"

    private SqlFileObject fleF112_PYCDCEILINGS;
    private SqlFileObject fleF110_COMPENSATION;

    private void fleF112_PYCDCEILINGS_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            if ((Prompt(1).ToString() != null) && Prompt(2).ToString().Length > 0)
            {
                strSQL.Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR"));
                strSQL.Append(" BETWEEN ");
                strSQL.Append(Prompt(2).ToString()).Append(" AND ").Append(Prompt(2));
                //strSQL.Append("201611".ToString()).Append(" AND ").Append("201611");

            }

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

    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF190_COMP_CODES_TMP;
    private SqlFileObject fleF020_DOCTOR_MSTR_TMP;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private DCharacter D_CHAR_DOC = new DCharacter("D_CHAR_DOC", 3);
    private void D_CHAR_DOC_GetValue(ref string Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR");


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

    private DCharacter DOC_NAME = new DCharacter("DOC_NAME", 24);
    private void D_DOC_NAME_GetValue(ref string Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME");


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
    private DCharacter D_CHAR_DEPT = new DCharacter("D_CHAR_DEPT", 2);
    private void D_CHAR_DEPT_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"), 2);


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
    private DCharacter D_CHAR_F_P_IND = new DCharacter("D_CHAR_F_P_IND", 2);
    private void D_CHAR_F_P_IND_GetValue(ref string Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND") + "A";


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

    private SqlFileObject fleR120AA;


    private void fleR120AA_SetItemFinals()
    {

        try
        {
            if (fleF020_DOCTOR_MSTR.Exists())
            {
                fleR120AA.set_SetValue("DOC_NAME", ("DR." + QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1")) + QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2")) + QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3")) + QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"))).PadRight(24, ' ').Substring(0, 24));

            }
            else
            {
                fleR120AA.set_SetValue("DOC_NAME", "UNKNOWN");
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

    }

    private DDecimal COMPENSATION_FACTOR = new DDecimal("COMPENSATION_FACTOR", 6);
    private void COMPENSATION_FACTOR_GetValue(ref decimal Value)
    {
        try
        {
            Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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


    #region "Standard Generated Procedures(R120_EXTRACT_DETAILS_1)"


    #region "Automatic Item Initialization(R120_EXTRACT_DETAILS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:01 PM

    //#-----------------------------------------
    //# fleF110_COMPENSATION_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:03:58 PM
    //#-----------------------------------------
    private void fleF110_COMPENSATION_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_COMPENSATION.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_COMPENSATION.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_COMPENSATION.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:03:58 PM
    //#-----------------------------------------
    private void fleF190_COMP_CODES_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF190_COMP_CODES.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF190_COMP_CODES.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));

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
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:03:58 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));

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


    #region "Transaction Management Procedures(R120_EXTRACT_DETAILS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:58 PM

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
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleR120AA.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES_TMP.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR_TMP.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R120_EXTRACT_DETAILS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:58 PM

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
            fleF112_PYCDCEILINGS.Dispose();
            fleF110_COMPENSATION.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleR120AA.Dispose();
            fleF190_COMP_CODES_TMP.Dispose();
            fleF020_DOCTOR_MSTR_TMP.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R120_EXTRACT_DETAILS_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_DETAILS_1");

            while (fleF112_PYCDCEILINGS.QTPForMissing())
            {
                // --> GET F112_PYCDCEILINGS <--

                fleF112_PYCDCEILINGS.GetData();
                // --> End GET F112_PYCDCEILINGS <--

                while (fleF110_COMPENSATION.QTPForMissing("1"))
                {
                    // --> GET F110_COMPENSATION <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF110_COMPENSATION.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                    m_strWhere.Append(" And ").Append(fleF110_COMPENSATION.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append(fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF110_COMPENSATION.ElementOwner("EP_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF110_COMPENSATION.ElementOwner("DOC_NBR"));

                    fleF110_COMPENSATION.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F110_COMPENSATION <--


                    if (Transaction())
                    {
                        while (fleF190_COMP_CODES.QTPForMissing())
                        {
                            // --> GET F190_COMP_CODES <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));

                            m_strOrderBy = new StringBuilder(" ORDER BY ");
                            m_strOrderBy.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));

                            fleF190_COMP_CODES.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                            // --> End GET F190_COMP_CODES <--

                            fleF190_COMP_CODES.OutPut(OutPutType.Add_Update, null, 1 == 2);
                        }

                        while (fleF020_DOCTOR_MSTR.QTPForMissing())
                        {
                            // --> GET F020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));

                            m_strOrderBy = new StringBuilder(" ORDER BY ");
                            m_strOrderBy.Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR"));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                            // --> End GET F020_DOCTOR_MSTR <--

                            fleF020_DOCTOR_MSTR.OutPut(OutPutType.Add_Update, null, 1 == 2);

                        }

                        while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
                        {
                            // --> GET CONSTANTS_MSTR_REC_6 <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                            m_strWhere.Append(((6)));

                            m_strOrderBy = new StringBuilder(" ORDER BY ");
                            m_strOrderBy.Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR"));

                            fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                            // --> End GET CONSTANTS_MSTR_REC_6 <--

                            fleCONSTANTS_MSTR_REC_6.OutPut(OutPutType.Add_Update, 1 == 2 && AtFinal(), null);
                        }

                        SubFile(ref m_trnTRANS_UPDATE, ref fleR120AA, SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_DEPT", fleF112_PYCDCEILINGS, "DOC_NBR", "EP_NBR", "DOC_PAY_CODE", "DOC_PAY_SUB_CODE",
                                "FACTOR", "DOC_YRLY_CEILING", "DOC_YRLY_CEILING_GUAR_PERC", "DOC_YRLY_CEIL_GUAR", "DOC_YRLY_EXPENSE", "DOC_YRLY_EXPN_ALLOC_PERS", fleF190_COMP_CODES, "COMP_TYPE",
                                "COMP_CODE", "DESC_SHORT", COMPENSATION_FACTOR, fleF110_COMPENSATION, "AMT_GROSS", "AMT_NET", "COMPENSATION_STATUS", fleF020_DOCTOR_MSTR, "DOC_FULL_PART_IND",
                                fleF110_COMPENSATION, "PROCESS_SEQ", DOC_NAME, D_CHAR_DOC, D_CHAR_DEPT, D_CHAR_F_P_IND);
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
            EndRequest("EXTRACT_DETAILS_1");

        }

    }




    #endregion


}
//EXTRACT_DETAILS_1



public class R120_BUILD_DEPT_TOTALS_2 : R120
{

    public R120_BUILD_DEPT_TOTALS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR120AA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R120AA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        T_AMT_GROSS = new CoreInteger("T_AMT_GROSS", 18, this);
        T_AMT_NET = new CoreInteger("T_AMT_NET", 18, this);
        fleDEPT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R120AA", "DEPT", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
       
        fleDEPT.SetItemFinals += fleDEPT_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(R120_BUILD_DEPT_TOTALS_2)"

    private SqlFileObject fleR120AA;
    private CoreInteger T_AMT_GROSS;

    private CoreInteger T_AMT_NET;
    private SqlFileObject fleDEPT;


    private void fleDEPT_SetItemFinals()
    {

        try
        {
            fleDEPT.set_SetValue("AMT_GROSS", T_AMT_GROSS.Value);
            fleDEPT.set_SetValue("AMT_NET", T_AMT_NET.Value);
            fleDEPT.set_SetValue("DOC_NBR", "   ");
            fleDEPT.set_SetValue("DOC_NAME", "*** DEPT. TOTALS ***");
            fleDEPT.set_SetValue("DOC_PAY_CODE", " ");
            fleDEPT.set_SetValue("DOC_PAY_SUB_CODE", " ");
            fleDEPT.set_SetValue("D_CHAR_DOC", "ZZZ");
            fleDEPT.set_SetValue("D_CHAR_F_P_IND", "ZZ");
            fleDEPT.set_SetValue("DOC_YRLY_CEILING", 0);
            fleDEPT.set_SetValue("DOC_YRLY_CEILING_GUAR_PERC", 0);
            fleDEPT.set_SetValue("DOC_YRLY_CEIL_GUAR", 0);
            fleDEPT.set_SetValue("DOC_YRLY_EXPENSE", 0);
            fleDEPT.set_SetValue("DOC_YRLY_EXPN_ALLOC_PERS", 0);
            fleDEPT.set_SetValue("DOC_FULL_PART_IND", " ");


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


    #region "Standard Generated Procedures(R120_BUILD_DEPT_TOTALS_2)"


    #region "Automatic Item Initialization(R120_BUILD_DEPT_TOTALS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R120_BUILD_DEPT_TOTALS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:58 PM

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
        fleR120AA.Transaction = m_trnTRANS_UPDATE;
        fleDEPT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R120_BUILD_DEPT_TOTALS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:58 PM

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
            fleR120AA.Dispose();
            fleDEPT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R120_BUILD_DEPT_TOTALS_2)"


    public void Run()
    {

        try
        {
            Request("BUILD_DEPT_TOTALS_2");

            while (fleR120AA.QTPForMissing())
            {
                // --> GET R120AA <--

                fleR120AA.GetData();
                // --> End GET R120AA <--


                if (Transaction())
                {

                    Sort(fleR120AA.GetSortValue("DOC_DEPT"), fleR120AA.GetSortValue("COMP_CODE"));



                }

            }

            while (Sort(fleR120AA))
            {
                SubTotal(ref T_AMT_GROSS, fleR120AA.GetDecimalValue("AMT_GROSS"));
                SubTotal(ref T_AMT_NET, fleR120AA.GetDecimalValue("AMT_NET"));


                SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT, fleR120AA.At("DOC_DEPT") || fleR120AA.At("COMP_CODE"), SubFileType.Keep, fleR120AA);

              

                Reset(ref T_AMT_GROSS, fleR120AA.At("DOC_DEPT") || fleR120AA.At("COMP_CODE"));
                Reset(ref T_AMT_NET, fleR120AA.At("DOC_DEPT") || fleR120AA.At("COMP_CODE"));

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
            EndRequest("BUILD_DEPT_TOTALS_2");

        }

    }




    #endregion


}
//BUILD_DEPT_TOTALS_2



public class R120_BUILD_DEPT_FULL_PART_3 : R120
{

    public R120_BUILD_DEPT_FULL_PART_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR120AA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R120AA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        T_AMT_GROSS = new CoreInteger("T_AMT_GROSS", 18, this);
        T_AMT_NET = new CoreInteger("T_AMT_NET", 18, this);
        fleFULL_PART = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R120AA", "FULL_PART", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleFULL_PART.SetItemFinals += fleFULL_PART_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(R120_BUILD_DEPT_FULL_PART_3)"

    private SqlFileObject fleR120AA;

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleR120AA.GetStringValue("D_CHAR_DOC")) != "ZZZ")
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

    private CoreInteger T_AMT_GROSS;

    private CoreInteger T_AMT_NET;
    private SqlFileObject fleFULL_PART;


    private void fleFULL_PART_SetItemFinals()
    {

        try
        {
            fleFULL_PART.set_SetValue("AMT_GROSS", T_AMT_GROSS.Value);
            fleFULL_PART.set_SetValue("AMT_NET", T_AMT_NET.Value);
            fleFULL_PART.set_SetValue("DOC_NBR", "   ");
            fleFULL_PART.set_SetValue("DOC_NAME", "*** F/P TOTAL ***");
            fleFULL_PART.set_SetValue("DOC_PAY_CODE", " ");
            fleFULL_PART.set_SetValue("DOC_PAY_SUB_CODE", " ");
            fleFULL_PART.set_SetValue("D_CHAR_DOC", "ZZ" + fleR120AA.GetStringValue("DOC_FULL_PART_IND"));
            fleFULL_PART.set_SetValue("D_CHAR_F_P_IND", fleR120AA.GetStringValue("DOC_FULL_PART_IND") + "Z");
            fleFULL_PART.set_SetValue("DOC_YRLY_CEILING", 0);
            fleFULL_PART.set_SetValue("DOC_YRLY_CEILING_GUAR_PERC", 0);
            fleFULL_PART.set_SetValue("DOC_YRLY_CEIL_GUAR", 0);
            fleFULL_PART.set_SetValue("DOC_YRLY_EXPENSE", 0);
            fleFULL_PART.set_SetValue("DOC_YRLY_EXPN_ALLOC_PERS", 0);


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


    #region "Standard Generated Procedures(R120_BUILD_DEPT_FULL_PART_3)"


    #region "Automatic Item Initialization(R120_BUILD_DEPT_FULL_PART_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R120_BUILD_DEPT_FULL_PART_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:58 PM

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
        fleR120AA.Transaction = m_trnTRANS_UPDATE;
        fleFULL_PART.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R120_BUILD_DEPT_FULL_PART_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:58 PM

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
            fleR120AA.Dispose();
            fleFULL_PART.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R120_BUILD_DEPT_FULL_PART_3)"


    public void Run()
    {

        try
        {
            Request("BUILD_DEPT_FULL_PART_3");

            while (fleR120AA.QTPForMissing())
            {
                // --> GET R120AA <--

                fleR120AA.GetData();
                // --> End GET R120AA <--

                if (Transaction())
                {

                    if (Select_If())
                    {

                        Sort(fleR120AA.GetSortValue("DOC_DEPT"), fleR120AA.GetSortValue("DOC_FULL_PART_IND"), fleR120AA.GetSortValue("COMP_CODE"));



                    }

                }

            }

            while (Sort(fleR120AA))
            {
                SubTotal(ref T_AMT_GROSS, fleR120AA.GetDecimalValue("AMT_GROSS"));
                SubTotal(ref T_AMT_NET, fleR120AA.GetDecimalValue("AMT_NET"));


                SubFile(ref m_trnTRANS_UPDATE, ref fleFULL_PART, fleR120AA.At("DOC_DEPT") || fleR120AA.At("DOC_FULL_PART_IND") || fleR120AA.At("COMP_CODE"), SubFileType.Keep, fleR120AA);



                Reset(ref T_AMT_GROSS, fleR120AA.At("DOC_DEPT") || fleR120AA.At("DOC_FULL_PART_IND") || fleR120AA.At("COMP_CODE"));
                Reset(ref T_AMT_NET, fleR120AA.At("DOC_DEPT") || fleR120AA.At("DOC_FULL_PART_IND") || fleR120AA.At("COMP_CODE"));

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
            EndRequest("BUILD_DEPT_FULL_PART_3");

        }

    }




    #endregion


}
//BUILD_DEPT_FULL_PART_3



public class R120_BUILD_GRAND_FULL_PART_4 : R120
{

    public R120_BUILD_GRAND_FULL_PART_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR120AA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R120AA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        T_AMT_GROSS = new CoreInteger("T_AMT_GROSS", 18, this);
        T_AMT_NET = new CoreInteger("T_AMT_NET", 18, this);
        fleGRAND_F_P = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R120AA", "GRAND_F_P", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleGRAND_F_P.SetItemFinals += fleGRAND_F_P_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(R120_BUILD_GRAND_FULL_PART_4)"

    private SqlFileObject fleR120AA;

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(QDesign.Substring(fleR120AA.GetStringValue("D_CHAR_DOC"), 1, 2)) == "ZZ" & QDesign.NULL(QDesign.Substring(fleR120AA.GetStringValue("D_CHAR_DOC"), 3, 1)) != "Z")
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

    private CoreInteger T_AMT_GROSS;

    private CoreInteger T_AMT_NET;
    private SqlFileObject fleGRAND_F_P;


    private void fleGRAND_F_P_SetItemFinals()
    {

        try
        {
            fleGRAND_F_P.set_SetValue("AMT_GROSS", T_AMT_GROSS.Value);
            fleGRAND_F_P.set_SetValue("AMT_NET", T_AMT_NET.Value);
            fleGRAND_F_P.set_SetValue("DOC_DEPT", 0);
            fleGRAND_F_P.set_SetValue("D_CHAR_DEPT", "Z" + fleR120AA.GetStringValue("DOC_FULL_PART_IND"));
            fleGRAND_F_P.set_SetValue("DOC_PAY_CODE", " ");
            fleGRAND_F_P.set_SetValue("DOC_PAY_SUB_CODE", " ");
            fleGRAND_F_P.set_SetValue("EP_NBR", 0);
            fleGRAND_F_P.set_SetValue("DOC_NAME", "* F/P GRAND TOTALS *");


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


    #region "Standard Generated Procedures(R120_BUILD_GRAND_FULL_PART_4)"


    #region "Automatic Item Initialization(R120_BUILD_GRAND_FULL_PART_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R120_BUILD_GRAND_FULL_PART_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:58 PM

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
        fleR120AA.Transaction = m_trnTRANS_UPDATE;
        fleGRAND_F_P.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R120_BUILD_GRAND_FULL_PART_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:58 PM

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
            fleR120AA.Dispose();
            fleGRAND_F_P.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R120_BUILD_GRAND_FULL_PART_4)"


    public void Run()
    {

        try
        {
            Request("BUILD_GRAND_FULL_PART_4");

            while (fleR120AA.QTPForMissing())
            {
                // --> GET R120AA <--

                fleR120AA.GetData();
                // --> End GET R120AA <--

                if (Transaction())
                {

                    if (Select_If())
                    {

                        Sort(fleR120AA.GetSortValue("DOC_FULL_PART_IND"), fleR120AA.GetSortValue("COMP_CODE"));



                    }

                }

            }

            while (Sort(fleR120AA))
            {
                SubTotal(ref T_AMT_GROSS, fleR120AA.GetDecimalValue("AMT_GROSS"));
                SubTotal(ref T_AMT_NET, fleR120AA.GetDecimalValue("AMT_NET"));


                SubFile(ref m_trnTRANS_UPDATE, ref fleGRAND_F_P, fleR120AA.At("DOC_FULL_PART_IND") || fleR120AA.At("COMP_CODE"), SubFileType.Keep, fleR120AA);



                Reset(ref T_AMT_GROSS, fleR120AA.At("DOC_FULL_PART_IND") || fleR120AA.At("COMP_CODE"));
                Reset(ref T_AMT_NET, fleR120AA.At("DOC_FULL_PART_IND") || fleR120AA.At("COMP_CODE"));

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
            EndRequest("BUILD_GRAND_FULL_PART_4");

        }

    }




    #endregion


}
//BUILD_GRAND_FULL_PART_4



public class R120_BUILD_GRAND_TOTALS_5 : R120
{

    public R120_BUILD_GRAND_TOTALS_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR120AA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R120AA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        T_AMT_GROSS = new CoreInteger("T_AMT_GROSS", 18, this);
        T_AMT_NET = new CoreInteger("T_AMT_NET", 18, this);
        fleGRAND = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R120AA", "GRAND", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleGRAND.SetItemFinals += fleGRAND_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(R120_BUILD_GRAND_TOTALS_5)"

    private SqlFileObject fleR120AA;

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleR120AA.GetStringValue("D_CHAR_DOC")) == "ZZZ")
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

    private CoreInteger T_AMT_GROSS;

    private CoreInteger T_AMT_NET;
    private SqlFileObject fleGRAND;


    private void fleGRAND_SetItemFinals()
    {

        try
        {
            fleGRAND.set_SetValue("AMT_GROSS", T_AMT_GROSS.Value);
            fleGRAND.set_SetValue("AMT_NET", T_AMT_NET.Value);
            fleGRAND.set_SetValue("DOC_DEPT", 0);
            fleGRAND.set_SetValue("D_CHAR_DEPT", "ZZ");
            fleGRAND.set_SetValue("D_CHAR_F_P_IND", "ZZ");
            fleGRAND.set_SetValue("DOC_FULL_PART_IND", " ");
            fleGRAND.set_SetValue("DOC_PAY_CODE", " ");
            fleGRAND.set_SetValue("DOC_PAY_SUB_CODE", " ");
            fleGRAND.set_SetValue("EP_NBR", 0);
            fleGRAND.set_SetValue("DOC_NAME", "*** GRAND TOTALS ***");


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


    #region "Standard Generated Procedures(R120_BUILD_GRAND_TOTALS_5)"


    #region "Automatic Item Initialization(R120_BUILD_GRAND_TOTALS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R120_BUILD_GRAND_TOTALS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:58 PM

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
        fleR120AA.Transaction = m_trnTRANS_UPDATE;
        fleGRAND.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R120_BUILD_GRAND_TOTALS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:58 PM

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
            fleR120AA.Dispose();
            fleGRAND.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R120_BUILD_GRAND_TOTALS_5)"


    public void Run()
    {

        try
        {
            Request("BUILD_GRAND_TOTALS_5");

            while (fleR120AA.QTPForMissing())
            {
                // --> GET R120AA <--

                fleR120AA.GetData();
                // --> End GET R120AA <--

                if (Transaction())
                {

                    if (Select_If())
                    {

                        // GW2017. Not sure why this was here. To be reviewed. Replaced with AT COMP_CODE below.
                        //Sort(fleR120AA.GetSortValue("DOC_DEPT"),
                        //    fleR120AA.GetSortValue("DOC_NBR"),
                        //    fleR120AA.GetSortValue("EP_NBR"),
                        //    fleR120AA.GetSortValue("DOC_PAY_CODE"),
                        //    fleR120AA.GetSortValue("DOC_PAY_SUB_CODE"),
                        //    fleR120AA.GetSortValue("FACTOR"),
                        //    fleR120AA.GetSortValue("DOC_YRLY_CEILING"),
                        //    fleR120AA.GetSortValue("DOC_YRLY_CEILING_GUAR_PERC"),
                        //    fleR120AA.GetSortValue("DOC_YRLY_CEIL_GUAR"),
                        //    fleR120AA.GetSortValue("DOC_YRLY_EXPENSE"),
                        //    fleR120AA.GetSortValue("DOC_YRLY_EXPN_ALLOC_PERS"),
                        //    fleR120AA.GetSortValue("COMP_TYPE"),
                        //    fleR120AA.GetSortValue("COMP_CODE"));

                        Sort(fleR120AA.GetSortValue("COMP_CODE"));

                    }

                }

            }

            while (Sort(fleR120AA))
            {
                SubTotal(ref T_AMT_GROSS, fleR120AA.GetDecimalValue("AMT_GROSS"));
                SubTotal(ref T_AMT_NET, fleR120AA.GetDecimalValue("AMT_NET"));

                // GW2017. Not sure why this was here. To be reviewed. Replaced with AT COMP_CODE below.
                //SubFile(ref m_trnTRANS_UPDATE, ref fleGRAND, 
                //    fleR120AA.At("DOC_DEPT") || fleR120AA.At("DOC_NBR") || fleR120AA.At("EP_NBR") || fleR120AA.At("DOC_PAY_CODE") || fleR120AA.At("DOC_PAY_SUB_CODE") || fleR120AA.At("FACTOR") ||
                //     fleR120AA.At("DOC_YRLY_CEILING") || fleR120AA.At("DOC_YRLY_CEILING_GUAR_PERC") || fleR120AA.At("DOC_YRLY_CEIL_GUAR") || fleR120AA.At("DOC_YRLY_EXPENSE") || fleR120AA.At("DOC_YRLY_EXPN_ALLOC_PERS") ||
                //      fleR120AA.At("COMP_TYPE") || fleR120AA.At("COMP_CODE")
                //    , SubFileType.Keep, fleR120AA);

                SubFile(ref m_trnTRANS_UPDATE, ref fleGRAND, fleR120AA.At("COMP_CODE"), SubFileType.Keep, fleR120AA);



                Reset(ref T_AMT_GROSS, fleR120AA.At("COMP_CODE"));
                Reset(ref T_AMT_NET, fleR120AA.At("COMP_CODE"));

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
            EndRequest("BUILD_GRAND_TOTALS_5");

        }

    }




    #endregion


}
//BUILD_GRAND_TOTALS_5




