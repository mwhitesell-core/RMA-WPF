
#region "Screen Comments"

// Program: u140_f.qts
// Purpose: add `report only` docs to subfile so that they appear in r140_b
// modification history
// 2007/mar/08 b.e. - origina
// ------------------------------------------------


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U140_F : BaseClassControl
{

    private U140_F m_U140_F;

    public U140_F(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U140_F(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U140_F != null))
        {
            m_U140_F.CloseTransactionObjects();
            m_U140_F = null;
        }
    }

    public U140_F GetU140_F(int Level)
    {
        if (m_U140_F == null)
        {
            m_U140_F = new U140_F("U140_F", Level);
        }
        else
        {
            m_U140_F.ResetValues();
        }
        return m_U140_F;
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

            U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_1 U140_UPDATE_F075_WITH_REPORT_ONLY_1 = new U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_1(Name, Level);
            U140_UPDATE_F075_WITH_REPORT_ONLY_1.Run();
            U140_UPDATE_F075_WITH_REPORT_ONLY_1.Dispose();
            U140_UPDATE_F075_WITH_REPORT_ONLY_1 = null;

            U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_2 U140_UPDATE_F075_WITH_REPORT_ONLY_2 = new U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_2(Name, Level);
            U140_UPDATE_F075_WITH_REPORT_ONLY_2.Run();
            U140_UPDATE_F075_WITH_REPORT_ONLY_2.Dispose();
            U140_UPDATE_F075_WITH_REPORT_ONLY_2 = null;

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



public class U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_1 : U140_F
{

    public U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleTMP_DOCTOR_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_DOCTOR_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
          fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_DOCTOR_ALPHA.SetItemFinals += fleTMP_DOCTOR_ALPHA_SetItemFinals;
        X_DOC_SOLO.GetValue += X_DOC_SOLO_GetValue;
        X_SUBMISSION_AMT.GetValue += X_SUBMISSION_AMT_GetValue;
        X_CONVERSION_AMT.GetValue += X_CONVERSION_AMT_GetValue;
        fleF075_AFP_DOC_MSTR.InitializeItems += fleF075_AFP_DOC_MSTR_AutomaticItemInitialization;
        fleF074_AFP_GROUP_MSTR.InitializeItems += fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_1)"

    private SqlFileObject fleTMP_DOCTOR_ALPHA;

    private void fleTMP_DOCTOR_ALPHA_SetItemFinals()
    {

        try
        {
            fleTMP_DOCTOR_ALPHA.set_SetValue("TMP_ALPHA_FIELD_2", "on f075");


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

    private SqlFileObject fleF075_AFP_DOC_MSTR;
    private SqlFileObject fleF074_AFP_GROUP_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleTMP_DOCTOR_ALPHA.GetStringValue("TMP_ALPHA_FIELD_1")) == QDesign.NULL(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")))
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

    private DDecimal X_DOC_SOLO = new DDecimal("X_DOC_SOLO", 6);
    private void X_DOC_SOLO_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleTMP_DOCTOR_ALPHA.GetDecimalValue("DOC_OHIP_NBR");


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
    private DDecimal X_SUBMISSION_AMT = new DDecimal("X_SUBMISSION_AMT", 6);
    private void X_SUBMISSION_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleTMP_DOCTOR_ALPHA.GetDecimalValue("TMP_COUNTER_1");


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
    private DDecimal X_CONVERSION_AMT = new DDecimal("X_CONVERSION_AMT", 6);
    private void X_CONVERSION_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleTMP_DOCTOR_ALPHA.GetDecimalValue("TMP_COUNTER_2");


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


    #region "Standard Generated Procedures(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_1)"


    #region "Automatic Item Initialization(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:15 PM

    //#-----------------------------------------
    //# fleF075_AFP_DOC_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:15 PM
    //#-----------------------------------------
    private void fleF075_AFP_DOC_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleTMP_DOCTOR_ALPHA.GetDecimalValue("DOC_OHIP_NBR"));
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_NBR", !Fixed, fleTMP_DOCTOR_ALPHA.GetStringValue("DOC_NBR"));

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
    //# fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:15 PM
    //#-----------------------------------------
    private void fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF074_AFP_GROUP_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_REPORTING_MTH", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("AFP_REPORTING_MTH"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_MULTI_DOC_RA_PERCENTAGE", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT_TOTAL", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT_TOTAL"));

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


    #region "Transaction Management Procedures(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:14 PM

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
        fleTMP_DOCTOR_ALPHA.Transaction = m_trnTRANS_UPDATE;
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:14 PM

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
            fleTMP_DOCTOR_ALPHA.Dispose();
            fleF075_AFP_DOC_MSTR.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_1)"


    public void Run()
    {

        try
        {
            Request("U140_UPDATE_F075_WITH_REPORT_ONLY_1");

            while (fleTMP_DOCTOR_ALPHA.QTPForMissing())
            {
                // --> GET TMP_DOCTOR_ALPHA <--

                fleTMP_DOCTOR_ALPHA.GetData();
                // --> End GET TMP_DOCTOR_ALPHA <--

                while (fleF075_AFP_DOC_MSTR.QTPForMissing("1"))
                {
                    // --> GET F075_AFP_DOC_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleTMP_DOCTOR_ALPHA.GetStringValue("DOC_NBR")));

                    fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F075_AFP_DOC_MSTR <--

                    while (fleF074_AFP_GROUP_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F074_AFP_GROUP_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleTMP_DOCTOR_ALPHA.GetStringValue("TMP_ALPHA_FIELD_1")));

                        fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F074_AFP_GROUP_MSTR <--


                        if (Transaction())
                        {

                             if (Select_If())
                            {
                                fleTMP_DOCTOR_ALPHA.OutPut(OutPutType.Update);

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
            EndRequest("U140_UPDATE_F075_WITH_REPORT_ONLY_1");

        }

    }







    #endregion


}
//U140_UPDATE_F075_WITH_REPORT_ONLY_1



public class U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_2 : U140_F
{

    public U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleTMP_DOCTOR_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_DOCTOR_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
          fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF075_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "F075_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        X_SUBMISSION_AMT.GetValue += X_SUBMISSION_AMT_GetValue;
        X_CONVERSION_AMT.GetValue += X_CONVERSION_AMT_GetValue;
        fleF075_ADD.SetItemFinals += fleF075_ADD_SetItemFinals;
        fleF075_ADD.InitializeItems += fleF075_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_2)"

    private SqlFileObject fleTMP_DOCTOR_ALPHA;
    private SqlFileObject fleF074_AFP_GROUP_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleTMP_DOCTOR_ALPHA.GetStringValue("TMP_ALPHA_FIELD_2")) != "on f075" & QDesign.NULL(fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_GROUP_PROCESS_FLAG")) == "R")
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

    private DDecimal X_SUBMISSION_AMT = new DDecimal("X_SUBMISSION_AMT", 6);
    private void X_SUBMISSION_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleTMP_DOCTOR_ALPHA.GetDecimalValue("TMP_COUNTER_1");


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
    private DDecimal X_CONVERSION_AMT = new DDecimal("X_CONVERSION_AMT", 6);
    private void X_CONVERSION_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleTMP_DOCTOR_ALPHA.GetDecimalValue("TMP_COUNTER_2");


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
    private SqlFileObject fleF075_ADD;

    private void fleF075_ADD_SetItemFinals()
    {

        try
        {
            fleF075_ADD.set_SetValue("DOC_NBR", fleTMP_DOCTOR_ALPHA.GetStringValue("DOC_NBR"));
            fleF075_ADD.set_SetValue("DOC_OHIP_NBR", fleTMP_DOCTOR_ALPHA.GetDecimalValue("DOC_OHIP_NBR"));
            fleF075_ADD.set_SetValue("DOC_AFP_PAYM_GROUP", fleTMP_DOCTOR_ALPHA.GetStringValue("TMP_ALPHA_FIELD_1"));
            fleF075_ADD.set_SetValue("AFP_REPORTING_MTH", fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_REPORTING_MTH"));
            fleF075_ADD.set_SetValue("AFP_MULTI_DOC_RA_PERCENTAGE", 0);
            fleF075_ADD.set_SetValue("RA_PAYMENT_AMT", 0);
            fleF075_ADD.set_SetValue("RA_PAYMENT_AMT_TOTAL", 0);
            fleF075_ADD.set_SetValue("AFP_PAYMENT_AMT", X_CONVERSION_AMT.Value);
            fleF075_ADD.set_SetValue("AFP_PAYMENT_AMT_TOTAL", X_CONVERSION_AMT.Value);
            fleF075_ADD.set_SetValue("AFP_SUBMISSION_AMT", X_SUBMISSION_AMT.Value);
            fleF075_ADD.set_SetValue("AFP_DUPLICATE_DOC_COUNT", 1);


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


    #region "Standard Generated Procedures(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_2)"


    #region "Automatic Item Initialization(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:15 PM

    //#-----------------------------------------
    //# fleF075_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:15 PM
    //#-----------------------------------------
    private void fleF075_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF075_ADD.set_SetValue("DOC_OHIP_NBR", !Fixed, fleTMP_DOCTOR_ALPHA.GetDecimalValue("DOC_OHIP_NBR"));
            fleF075_ADD.set_SetValue("DOC_NBR", !Fixed, fleTMP_DOCTOR_ALPHA.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF075_ADD.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF074_AFP_GROUP_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF075_ADD.set_SetValue("AFP_REPORTING_MTH", !Fixed, fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_REPORTING_MTH"));
            fleF075_ADD.set_SetValue("AFP_MULTI_DOC_RA_PERCENTAGE", !Fixed, fleF074_AFP_GROUP_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE"));
            fleF075_ADD.set_SetValue("AFP_PAYMENT_AMT", !Fixed, fleF074_AFP_GROUP_MSTR.GetDecimalValue("AFP_PAYMENT_AMT"));
            fleF075_ADD.set_SetValue("AFP_PAYMENT_AMT_TOTAL", !Fixed, fleF074_AFP_GROUP_MSTR.GetDecimalValue("AFP_PAYMENT_AMT_TOTAL"));

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


    #region "Transaction Management Procedures(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:14 PM

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
        fleTMP_DOCTOR_ALPHA.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF075_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:15 PM

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
            fleTMP_DOCTOR_ALPHA.Dispose();
            fleF074_AFP_GROUP_MSTR.Dispose();
            fleF075_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_F_U140_UPDATE_F075_WITH_REPORT_ONLY_2)"


    public void Run()
    {

        try
        {
            Request("U140_UPDATE_F075_WITH_REPORT_ONLY_2");

            while (fleTMP_DOCTOR_ALPHA.QTPForMissing())
            {
                // --> GET TMP_DOCTOR_ALPHA <--

                fleTMP_DOCTOR_ALPHA.GetData();
                // --> End GET TMP_DOCTOR_ALPHA <--

                while (fleF074_AFP_GROUP_MSTR.QTPForMissing("1"))
                {
                    // --> GET F074_AFP_GROUP_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleTMP_DOCTOR_ALPHA.GetStringValue("TMP_ALPHA_FIELD_1")));

                    fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F074_AFP_GROUP_MSTR <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {
                            fleF075_ADD.OutPut(OutPutType.Add);

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
            EndRequest("U140_UPDATE_F075_WITH_REPORT_ONLY_2");

        }

    }







    #endregion


}
//U140_UPDATE_F075_WITH_REPORT_ONLY_2




