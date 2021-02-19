
#region "Screen Comments"

// Program: u140_c
// Purpose: Before the RA is run this program must to be to put all doctors      
// into the f075 file with an indication of the number of doctors
// that share the same MOH OHIP Number
// This f075 file is then updated with the RA payments and based upon
// the split between a doctors RMA doctors of their RA Payments the
// same ratio is used to divy up the single AFP payment identified 
// only with the doctor`s OHIP number
// 2005/apr/08 b.e. - set lock update statement
// 2005/jun/09 M.C. - define amount item with zoned*numeric


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U140_C : BaseClassControl
{

    private U140_C m_U140_C;

    public U140_C(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U140_C(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U140_C != null))
        {
            m_U140_C.CloseTransactionObjects();
            m_U140_C = null;
        }
    }

    public U140_C GetU140_C(int Level)
    {
        if (m_U140_C == null)
        {
            m_U140_C = new U140_C("U140_C", Level);
        }
        else
        {
            m_U140_C.ResetValues();
        }
        return m_U140_C;
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

            U140_C_F074_UPDATE_REPORT_MTH_1 F074_UPDATE_REPORT_MTH_1 = new U140_C_F074_UPDATE_REPORT_MTH_1(Name, Level);
            F074_UPDATE_REPORT_MTH_1.Run();
            F074_UPDATE_REPORT_MTH_1.Dispose();
            F074_UPDATE_REPORT_MTH_1 = null;

            U140_C_F074_UPDATE_PAYMENT_AMT_2 F074_UPDATE_PAYMENT_AMT_2 = new U140_C_F074_UPDATE_PAYMENT_AMT_2(Name, Level);
            F074_UPDATE_PAYMENT_AMT_2.Run();
            F074_UPDATE_PAYMENT_AMT_2.Dispose();
            F074_UPDATE_PAYMENT_AMT_2 = null;

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



public class U140_C_F074_UPDATE_REPORT_MTH_1 : U140_C
{

    public U140_C_F074_UPDATE_REPORT_MTH_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleAFP_A1F_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "AFP_A1F_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
          fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF074_AFP_GROUP_MSTR.SetItemFinals += fleF074_AFP_GROUP_MSTR_SetItemFinals;
        X_PAYMENT_AMT_TOTAL.GetValue += X_PAYMENT_AMT_TOTAL_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_C_F074_UPDATE_REPORT_MTH_1)"

    private SqlFileObject fleAFP_A1F_FILE;
    private SqlFileObject fleF074_AFP_GROUP_MSTR;

    private void fleF074_AFP_GROUP_MSTR_SetItemFinals()
    {

        try
        {
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_REPORTING_MTH", fleAFP_A1F_FILE.GetStringValue("AFP_REPORTING_MTH"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT_TOTAL", X_PAYMENT_AMT_TOTAL.Value);


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

    private DDecimal X_PAYMENT_AMT_TOTAL = new DDecimal("X_PAYMENT_AMT_TOTAL", 11);
    private void X_PAYMENT_AMT_TOTAL_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleAFP_A1F_FILE.GetStringValue("AFP_PAYMENT_SIGN")) == QDesign.NULL(" "))
            {
                CurrentValue = fleAFP_A1F_FILE.GetDecimalValue("AFP_PAYMENT_AMT");
            }
            else
            {
                CurrentValue = 0 - fleAFP_A1F_FILE.GetDecimalValue("AFP_PAYMENT_AMT");
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



    #endregion


    #region "Standard Generated Procedures(U140_C_F074_UPDATE_REPORT_MTH_1)"


    #region "Automatic Item Initialization(U140_C_F074_UPDATE_REPORT_MTH_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_C_F074_UPDATE_REPORT_MTH_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:33 PM

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
        fleAFP_A1F_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_C_F074_UPDATE_REPORT_MTH_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:33 PM

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
            fleAFP_A1F_FILE.Dispose();
            fleF074_AFP_GROUP_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_C_F074_UPDATE_REPORT_MTH_1)"


    public void Run()
    {

        try
        {
            Request("F074_UPDATE_REPORT_MTH_1");

            while (fleAFP_A1F_FILE.QTPForMissing())
            {
                // --> GET AFP_A1F_FILE <--

                fleAFP_A1F_FILE.GetData();
                // --> End GET AFP_A1F_FILE <--

                while (fleF074_AFP_GROUP_MSTR.QTPForMissing("1"))
                {
                    // --> GET F074_AFP_GROUP_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("AFP_GOVERNANCE_GROUP")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleAFP_A1F_FILE.GetStringValue("AFP_GOVERNANCE_GROUP")));

                    fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F074_AFP_GROUP_MSTR <--


                    if (Transaction())
                    {
                        fleF074_AFP_GROUP_MSTR.OutPut(OutPutType.Update);

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
            EndRequest("F074_UPDATE_REPORT_MTH_1");

        }

    }







    #endregion


}
//F074_UPDATE_REPORT_MTH_1



public class U140_C_F074_UPDATE_PAYMENT_AMT_2 : U140_C
{

    public U140_C_F074_UPDATE_PAYMENT_AMT_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleAFP_A2G_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "AFP_A2G_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
          fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF074_AFP_GROUP_MSTR.SetItemFinals += fleF074_AFP_GROUP_MSTR_SetItemFinals;
        X_PAYMENT_AMT.GetValue += X_PAYMENT_AMT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_C_F074_UPDATE_PAYMENT_AMT_2)"

    private SqlFileObject fleAFP_A2G_FILE;
    private SqlFileObject fleF074_AFP_GROUP_MSTR;

    private void fleF074_AFP_GROUP_MSTR_SetItemFinals()
    {

        try
        {
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_GROUP_NAME", fleAFP_A2G_FILE.GetStringValue("AFP_GROUP_NAME"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT", X_PAYMENT_AMT.Value);


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

    private DDecimal X_PAYMENT_AMT = new DDecimal("X_PAYMENT_AMT", 6);
    private void X_PAYMENT_AMT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleAFP_A2G_FILE.GetStringValue("AFP_PAYMENT_SIGN")) == QDesign.NULL(" "))
            {
                CurrentValue = fleAFP_A2G_FILE.GetDecimalValue("AFP_PAYMENT_AMT");
            }
            else
            {
                CurrentValue = 0 - fleAFP_A2G_FILE.GetDecimalValue("AFP_PAYMENT_AMT");
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



    #endregion


    #region "Standard Generated Procedures(U140_C_F074_UPDATE_PAYMENT_AMT_2)"


    #region "Automatic Item Initialization(U140_C_F074_UPDATE_PAYMENT_AMT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_C_F074_UPDATE_PAYMENT_AMT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:33 PM

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
        fleAFP_A2G_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_C_F074_UPDATE_PAYMENT_AMT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:33 PM

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
            fleAFP_A2G_FILE.Dispose();
            fleF074_AFP_GROUP_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_C_F074_UPDATE_PAYMENT_AMT_2)"


    public void Run()
    {

        try
        {
            Request("F074_UPDATE_PAYMENT_AMT_2");

            while (fleAFP_A2G_FILE.QTPForMissing())
            {
                // --> GET AFP_A2G_FILE <--

                fleAFP_A2G_FILE.GetData();
                // --> End GET AFP_A2G_FILE <--

                while (fleF074_AFP_GROUP_MSTR.QTPForMissing("1"))
                {
                    // --> GET F074_AFP_GROUP_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleAFP_A2G_FILE.GetStringValue("DOC_AFP_PAYM_GROUP")));

                    fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F074_AFP_GROUP_MSTR <--


                    if (Transaction())
                    {
                        fleF074_AFP_GROUP_MSTR.OutPut(OutPutType.Update);

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
            EndRequest("F074_UPDATE_PAYMENT_AMT_2");

        }

    }







    #endregion


}
//F074_UPDATE_PAYMENT_AMT_2




