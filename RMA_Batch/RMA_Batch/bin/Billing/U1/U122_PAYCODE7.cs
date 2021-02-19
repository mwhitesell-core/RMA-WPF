
#region "Screen Comments"

//#> PROGRAM-ID.     U122_PAYCODE7_paycode7.qts 
//
//       ((C)) Dyad Infosys LTD  
//
//    PURPOSE: sub-process within "earnings generation" process.
//             calculate 'CHGEFT' transactions for pay codes 7 only 
//	      CHGEFT = FINCHG - TOTDED
//	      This program now is primary for MP 
//	
//
// MODIFICATION HISTORY
// DATE SAF #  WHO      DESCRIPTION
//   2017/JAN/17         M.C.     - original
//                                - clone from u119.qts and transfer the last part of $use/u116_paycode7.use to here
//			  

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class U122_PAYCODE7 : BaseClassControl
{
    private U122_PAYCODE7 m_U122_PAYCODE7;

    public U122_PAYCODE7(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        CHGEFT_SEQ = new CoreDecimal("CHGEFT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CHGEFT_GROUP = new CoreCharacter("CHGEFT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
    }

    public U122_PAYCODE7(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        CHGEFT_SEQ = new CoreDecimal("CHGEFT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CHGEFT_GROUP = new CoreCharacter("CHGEFT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
    }

    public override void Dispose()
    {
        if ((m_U122_PAYCODE7 != null))
        {
            m_U122_PAYCODE7.CloseTransactionObjects();
            m_U122_PAYCODE7 = null;
        }
    }

    public U122_PAYCODE7 GetU122_PAYCODE7(int Level)
    {
        if (m_U122_PAYCODE7 == null)
        {
            m_U122_PAYCODE7 = new U122_PAYCODE7("U122_PAYCODE7", Level);
        }
        else
        {
            m_U122_PAYCODE7.ResetValues();
        }
        return m_U122_PAYCODE7;
    }

    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal CHGEFT_SEQ;
    protected CoreCharacter CHGEFT_GROUP;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;

    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {
        try
        {
            U122_PAYCODE7_U122_A_GET_CHGEFT_1 U122_A_GET_CHGEFT_1 = new U122_PAYCODE7_U122_A_GET_CHGEFT_1(Name, Level);
            U122_A_GET_CHGEFT_1.Run();
            U122_A_GET_CHGEFT_1.Dispose();
            U122_A_GET_CHGEFT_1 = null;

            U122_PAYCODE7_U122_B_2 U122_B_2 = new U122_PAYCODE7_U122_B_2(Name, Level);
            U122_B_2.Run();
            U122_B_2.Dispose();
            U122_B_2 = null;

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

public class U122_PAYCODE7_U122_A_GET_CHGEFT_1 : U122_PAYCODE7
{

    public U122_PAYCODE7_U122_A_GET_CHGEFT_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;
    }

    #region "Declarations (Variables, Files and Transactions)(U122_PAYCODE7_U122_A_GET_CHGEFT_1)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("CHGEFT"));

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

    #endregion

    #region "Standard Generated Procedures(U122_PAYCODE7_U122_A_GET_CHGEFT_1)"

    #region "Automatic Item Initialization(U122_PAYCODE7_U122_A_GET_CHGEFT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:16 PM

    #endregion

    #region "Transaction Management Procedures(U122_PAYCODE7_U122_A_GET_CHGEFT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:14 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(U122_PAYCODE7_U122_A_GET_CHGEFT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:14 PM

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
            fleF190_COMP_CODES.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U122_PAYCODE7_U122_A_GET_CHGEFT_1)"

    public void Run()
    {
        try
        {
            Request("U122_PAYCODE7_U122_A_GET_CHGEFT_1");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET fleF190_COMP_CODES <--
                fleF190_COMP_CODES.GetData();
                // --> End GET fleF190_COMP_CODES <--

                if (Transaction())
                {
                    CHGEFT_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    CHGEFT_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
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
            EndRequest("U122_PAYCODE7_U122_A_GET_CHGEFT_1");
        }
    }
    #endregion
}
//U122_PAYCODE7_U122_A_GET_CHGEFT_1

public class U122_PAYCODE7_U122_B_2 : U122_PAYCODE7
{

    public U122_PAYCODE7_U122_B_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_FINCHG = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_FINCHG", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_TOTDED = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_TOTDED", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_CHGEFT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_CHGEFT", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU122_PAYCODE7_CHGEFT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U122_PAYCODE7_CHGEFT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU119_CHGEFT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U119_CHGEFT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        W_CHGEFT_AMT_1.GetValue += W_CHGEFT_AMT_1_GetValue;
        W_CHGEFT_AMT_N.GetValue += W_CHGEFT_AMT_N_GetValue;
        W_AMT_MTD_FINCHG.GetValue += W_AMT_MTD_FINCHG_GetValue;
        W_AMT_MTD_TOTDED.GetValue += W_AMT_MTD_TOTDED_GetValue;
        W_AMT_YTD_CHGEFT.GetValue += W_AMT_YTD_CHGEFT_GetValue;
        fleF020_DOCTOR_MSTR.SetItemFinals += fleF020_DOCTOR_MSTR_SetItemFinals;
        fleF119_CHGEFT.SetItemFinals += fleF119_CHGEFT_SetItemFinals;
        fleF119_ADD.SetItemFinals += fleF119_ADD_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(U122_PAYCODE7_U122_B_2)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;

    private void fleCONSTANTS_MSTR_REC_6_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = 6");

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

    private SqlFileObject fleF112_PYCDCEILINGS;
    private SqlFileObject fleF119_FINCHG;
    private SqlFileObject fleF119_TOTDED;
    private SqlFileObject fleF119_CHGEFT;

    private void fleF119_CHGEFT_SetItemFinals()
    {
        try
        {
            fleF119_CHGEFT.set_SetValue("AMT_MTD", W_CHGEFT_AMT_N.Value);
            fleF119_CHGEFT.set_SetValue("AMT_YTD", W_AMT_YTD_CHGEFT.Value);
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

    private void fleF020_DOCTOR_MSTR_SetItemFinals()
    {
        try
        {
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_PAYEFT", W_CHGEFT_AMT_N.Value);
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
            if (fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE") == "7")
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

    private DInteger W_CHGEFT_AMT_1 = new DInteger("W_CHGEFT_AMT_1", 10);
    private void W_CHGEFT_AMT_1_GetValue(ref decimal Value)
    {
        try
        {
            Value = fleF119_FINCHG.GetDecimalValue("AMT_MTD") - fleF119_TOTDED.GetDecimalValue("AMT_MTD");
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

    private DInteger W_CHGEFT_AMT_N = new DInteger("W_CHGEFT_AMT_N", 10);
    private void W_CHGEFT_AMT_N_GetValue(ref decimal Value)
    {
        try
        {
            if (W_CHGEFT_AMT_1.Value >= 0)
            {
                Value = W_CHGEFT_AMT_1.Value;
            }
            else
            {
                Value = 0;
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

    private DInteger W_AMT_MTD_FINCHG = new DInteger("W_AMT_MTD_FINCHG", 10);
    private void W_AMT_MTD_FINCHG_GetValue(ref decimal Value)
    {
        try
        {
            Value = fleF119_FINCHG.GetDecimalValue("AMT_MTD");
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

    private DInteger W_AMT_MTD_TOTDED = new DInteger("W_AMT_MTD_TOTDED", 10);
    private void W_AMT_MTD_TOTDED_GetValue(ref decimal Value)
    {
        try
        {
            Value = fleF119_TOTDED.GetDecimalValue("AMT_MTD");
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

    private DInteger W_AMT_YTD_CHGEFT = new DInteger("W_AMT_YTD_CHGEFT", 10);
    private void W_AMT_YTD_CHGEFT_GetValue(ref decimal Value)
    {
        try
        {
            Value = fleF119_CHGEFT.GetDecimalValue("AMT_YTD") + W_CHGEFT_AMT_N.Value;
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

    private SqlFileObject fleU122_PAYCODE7_CHGEFT;
    private SqlFileObject fleU119_CHGEFT;
    private SqlFileObject fleF119_ADD;

    private void fleF119_ADD_SetItemFinals()
    {
        try
        {
            fleF119_ADD.set_SetValue("DOC_NBR", fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_ADD.set_SetValue("COMP_CODE", "CHGEFT");
            fleF119_ADD.set_SetValue("REC_TYPE", "A");
            fleF119_ADD.set_SetValue("PROCESS_SEQ", CHGEFT_SEQ.Value);
            fleF119_ADD.set_SetValue("COMP_CODE_GROUP", CHGEFT_GROUP.Value);
            fleF119_ADD.set_SetValue("AMT_MTD", W_CHGEFT_AMT_N.Value);
            fleF119_ADD.set_SetValue("AMT_YTD", W_AMT_YTD_CHGEFT.Value);
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

    #region "Standard Generated Procedures(U122_PAYCODE7_U122_B_2)"

    #region "Automatic Item Initialization(U122_PAYCODE7_U122_B_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:16 PM

    #endregion

    #region "Transaction Management Procedures(U122_PAYCODE7_U122_B_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:14 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF119_FINCHG.Transaction = m_trnTRANS_UPDATE;
        fleF119_TOTDED.Transaction = m_trnTRANS_UPDATE;
        fleF119_CHGEFT.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU122_PAYCODE7_CHGEFT.Transaction = m_trnTRANS_UPDATE;
        fleU119_CHGEFT.Transaction = m_trnTRANS_UPDATE;
        fleF119_ADD.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(U122_PAYCODE7_U122_B_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:14 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF112_PYCDCEILINGS.Dispose();
            fleF119_FINCHG.Dispose();
            fleF119_TOTDED.Dispose();
            fleF119_CHGEFT.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleU122_PAYCODE7_CHGEFT.Dispose();
            fleU119_CHGEFT.Dispose();
            fleF119_ADD.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U122_PAYCODE7_U122_B_2)"

    public void Run()
    {
        try
        {
            Request("U122_PAYCODE7_U122_B_2");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--
                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF112_PYCDCEILINGS.QTPForMissing("1"))
                {
                    // --> GET F112_PYCDCEILINGS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString());
                    // --> End GET F112_PYCDCEILINGS <--

                    while (fleF119_FINCHG.QTPForMissing("2"))
                    {
                        // --> GET F119_FINCHG <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(fleF119_FINCHG.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                        m_strWhere.Append(" AND ").Append(fleF119_FINCHG.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("FINCHG"));
                        //m_strWhere.Append(" AND ").Append(fleF119_FINCHG.ElementOwner("REC_TYPE")).Append(" = ");
                        //m_strWhere.Append(Common.StringToField("A"));

                        fleF119_FINCHG.GetData(m_strWhere.ToString());
                        // --> End GET F119_FINCHG <--

                        while (fleF119_TOTDED.QTPForMissing("3"))
                        {
                            // --> GET F119_FINCHG <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(fleF119_TOTDED.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" AND ").Append(fleF119_TOTDED.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("TOTDED"));
                            //m_strWhere.Append(" AND ").Append(fleF119_TOTDED.ElementOwner("REC_TYPE")).Append(" = ");
                            //m_strWhere.Append(Common.StringToField("A"));

                            fleF119_TOTDED.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F119_FINCHG <--

                            while (fleF119_CHGEFT.QTPForMissing("4"))
                            {
                                // --> GET F119_FINCHG <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(fleF119_CHGEFT.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                m_strWhere.Append(" AND ").Append(fleF119_CHGEFT.ElementOwner("COMP_CODE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField("CHGEFT"));
                                //m_strWhere.Append(" AND ").Append(fleF119_CHGEFT.ElementOwner("REC_TYPE")).Append(" = ");
                                //m_strWhere.Append(Common.StringToField("A"));

                                fleF119_CHGEFT.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F119_FINCHG <--

                                while (fleF020_DOCTOR_MSTR.QTPForMissing("5"))
                                {
                                    // --> GET F119_FINCHG <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F119_FINCHG <--

                                    if (Transaction())
                                    {
                                        if (Select_If())
                                        {
                                            SubFile(ref m_trnTRANS_UPDATE, ref fleU122_PAYCODE7_CHGEFT, SubFileType.KeepText, fleF112_PYCDCEILINGS, "DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_DEPT", W_AMT_MTD_FINCHG,
                                                    W_AMT_MTD_TOTDED, W_CHGEFT_AMT_1, W_CHGEFT_AMT_N, W_AMT_YTD_CHGEFT);

                                            SubFile(ref m_trnTRANS_UPDATE, ref fleU119_CHGEFT, SubFileType.Portable, fleF112_PYCDCEILINGS, "DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_DEPT", W_CHGEFT_AMT_N);

                                            fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update);


                                            fleF119_CHGEFT.OutPut(OutPutType.Update, null, fleF119_CHGEFT.Exists());


                                            fleF119_ADD.OutPut(OutPutType.Add, null, !fleF119_CHGEFT.Exists());

                                        }
                                    }
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
            EndRequest("U122_PAYCODE7_U122_B_2");
        }
    }
    #endregion
}
//U122_PAYCODE7_U122_A_GET_CHGEFT_1



