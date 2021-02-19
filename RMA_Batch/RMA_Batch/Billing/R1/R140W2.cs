
#region "Screen Comments"

// 2008/nov/05 M.C. - modify first request to add choose & sorted & output statement 
// - modify second request for access and sorted statements
// - add 2 new requests


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class R140W2 : BaseClassControl
{

    private R140W2 m_R140W2;

    public R140W2(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public R140W2(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_R140W2 != null))
        {
            m_R140W2.CloseTransactionObjects();
            m_R140W2 = null;
        }
    }

    public R140W2 GetR140W2(int Level)
    {
        if (m_R140W2 == null)
        {
            m_R140W2 = new R140W2("R140W2", Level);
        }
        else
        {
            m_R140W2.ResetValues();
        }
        return m_R140W2;
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

            R140W2_R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1 R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1 = new R140W2_R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1(Name, Level);
            R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1.Run();
            R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1.Dispose();
            R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1 = null;

            R140W2_R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2 R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2 = new R140W2_R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2(Name, Level);
            R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2.Run();
            R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2.Dispose();
            R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2 = null;

            R140W2_R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3 R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3 = new R140W2_R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3(Name, Level);
            R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3.Run();
            R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3.Dispose();
            R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3 = null;

            R140W2_R140W_SET_TERMINATED_DOCTORS_FROM_F075_4 R140W_SET_TERMINATED_DOCTORS_FROM_F075_4 = new R140W2_R140W_SET_TERMINATED_DOCTORS_FROM_F075_4(Name, Level);
            R140W_SET_TERMINATED_DOCTORS_FROM_F075_4.Run();
            R140W_SET_TERMINATED_DOCTORS_FROM_F075_4.Dispose();
            R140W_SET_TERMINATED_DOCTORS_FROM_F075_4 = null;

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



public class R140W2_R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1 : R140W2
{

    public R140W2_R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleTMP_GOVERNANCE_PAYMENTS_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "TMP_GOVERNANCE_PAYMENTS_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_GOVERNANCE_PAYMENTS_FILE.SetItemFinals += fleTMP_GOVERNANCE_PAYMENTS_FILE_SetItemFinals;
        fleF075_AFP_DOC_MSTR.InitializeItems += fleF075_AFP_DOC_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(R140W2_R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1)"

    private SqlFileObject fleTMP_GOVERNANCE_PAYMENTS_FILE;

    private void fleTMP_GOVERNANCE_PAYMENTS_FILE_SetItemFinals()
    {

        try
        {
            fleTMP_GOVERNANCE_PAYMENTS_FILE.set_SetValue("REPORTED_IN_R140B_REPORT", "Y");


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
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleTMP_GOVERNANCE_PAYMENTS_FILE.GetStringValue("DOC_AFP_PAYM_GROUP")) == QDesign.NULL(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")))
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


    #region "Standard Generated Procedures(R140W2_R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1)"


    #region "Automatic Item Initialization(R140W2_R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:35 PM

    //#-----------------------------------------
    //# fleF075_AFP_DOC_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:03:35 PM
    //#-----------------------------------------
    private void fleF075_AFP_DOC_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleTMP_GOVERNANCE_PAYMENTS_FILE.GetDecimalValue("DOC_OHIP_NBR"));
            fleF075_AFP_DOC_MSTR.set_SetValue("AFP_PAYMENT_AMT", !Fixed, fleTMP_GOVERNANCE_PAYMENTS_FILE.GetDecimalValue("AFP_PAYMENT_AMT"));
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleTMP_GOVERNANCE_PAYMENTS_FILE.GetStringValue("DOC_AFP_PAYM_GROUP"));

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


    #region "Transaction Management Procedures(R140W2_R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:35 PM

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
        fleTMP_GOVERNANCE_PAYMENTS_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R140W2_R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:35 PM

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
            fleTMP_GOVERNANCE_PAYMENTS_FILE.Dispose();
            fleF075_AFP_DOC_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R140W2_R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1)"


    public void Run()
    {

        try
        {
            Request("R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1");

            while (fleTMP_GOVERNANCE_PAYMENTS_FILE.QTPForMissing())
            {
                // --> GET TMP_GOVERNANCE_PAYMENTS_FILE <--

                fleTMP_GOVERNANCE_PAYMENTS_FILE.GetData();
                // --> End GET TMP_GOVERNANCE_PAYMENTS_FILE <--

                while (fleF075_AFP_DOC_MSTR.QTPForMissing("1"))
                {
                    // --> GET F075_AFP_DOC_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleTMP_GOVERNANCE_PAYMENTS_FILE.GetDecimalValue("DOC_OHIP_NBR")));

                    fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F075_AFP_DOC_MSTR <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleTMP_GOVERNANCE_PAYMENTS_FILE.GetSortValue("DOC_AFP_PAYM_GROUP"), fleTMP_GOVERNANCE_PAYMENTS_FILE.GetSortValue("DOC_OHIP_NBR"));



                        }

                    }

                }

            }


            while (Sort(fleTMP_GOVERNANCE_PAYMENTS_FILE, fleF075_AFP_DOC_MSTR))
            {
                fleTMP_GOVERNANCE_PAYMENTS_FILE.OutPut(OutPutType.Update, fleTMP_GOVERNANCE_PAYMENTS_FILE.At("DOC_AFP_PAYM_GROUP") || fleTMP_GOVERNANCE_PAYMENTS_FILE.At("DOC_OHIP_NBR"), null);


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
            EndRequest("R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1");

        }

    }




    #endregion


}
//R140W_CHECK_IF_INCOMING_RECORDS_EXISTS_IN_F075_1



public class R140W2_R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2 : R140W2
{

    public R140W2_R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleTMP_GOVERNANCE_PAYMENTS_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "TMP_GOVERNANCE_PAYMENTS_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleTMP_GOV_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "TMP_GOVERNANCE_PAYMENTS_FILE", "TMP_GOV_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_GOV_ADD.SetItemFinals += fleTMP_GOV_ADD_SetItemFinals;
        fleTMP_GOVERNANCE_PAYMENTS_FILE.InitializeItems += fleTMP_GOVERNANCE_PAYMENTS_FILE_AutomaticItemInitialization;
        fleTMP_GOV_ADD.InitializeItems += fleTMP_GOV_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(R140W2_R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2)"

    private SqlFileObject fleF075_AFP_DOC_MSTR;
    private SqlFileObject fleTMP_GOVERNANCE_PAYMENTS_FILE;
    public override bool SelectIf()
    {


        try
        {
            if (!fleTMP_GOVERNANCE_PAYMENTS_FILE.Exists())
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

    private SqlFileObject fleTMP_GOV_ADD;

    private void fleTMP_GOV_ADD_SetItemFinals()
    {

        try
        {
            fleTMP_GOV_ADD.set_SetValue("DOC_OHIP_NBR", fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleTMP_GOV_ADD.set_SetValue("DOC_AFP_PAYM_GROUP", fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleTMP_GOV_ADD.set_SetValue("REPORTED_IN_R140B_REPORT", "M");


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


    #region "Standard Generated Procedures(R140W2_R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2)"


    #region "Automatic Item Initialization(R140W2_R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:35 PM

    //#-----------------------------------------
    //# fleTMP_GOVERNANCE_PAYMENTS_FILE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:03:35 PM
    //#-----------------------------------------
    private void fleTMP_GOVERNANCE_PAYMENTS_FILE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleTMP_GOVERNANCE_PAYMENTS_FILE.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleTMP_GOVERNANCE_PAYMENTS_FILE.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleTMP_GOVERNANCE_PAYMENTS_FILE.set_SetValue("AFP_PAYMENT_AMT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT"));

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
    //# fleTMP_GOV_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:03:35 PM
    //#-----------------------------------------
    private void fleTMP_GOV_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleTMP_GOV_ADD.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleTMP_GOV_ADD.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleTMP_GOV_ADD.set_SetValue("AFP_PAYMENT_AMT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT"));
            //TODO: Manual steps may be required.
            fleTMP_GOV_ADD.set_SetValue("AFP_SOLO_NAME", !Fixed, fleTMP_GOVERNANCE_PAYMENTS_FILE.GetStringValue("AFP_SOLO_NAME"));
            fleTMP_GOV_ADD.set_SetValue("AFP_PAYMENT_AMT_PAYROLL_A", !Fixed, fleTMP_GOVERNANCE_PAYMENTS_FILE.GetDecimalValue("AFP_PAYMENT_AMT_PAYROLL_A"));
            fleTMP_GOV_ADD.set_SetValue("AFP_PAYMENT_AMT_PAYROLL_B", !Fixed, fleTMP_GOVERNANCE_PAYMENTS_FILE.GetDecimalValue("AFP_PAYMENT_AMT_PAYROLL_B"));
            fleTMP_GOV_ADD.set_SetValue("REPORTED_IN_R140B_REPORT", !Fixed, fleTMP_GOVERNANCE_PAYMENTS_FILE.GetStringValue("REPORTED_IN_R140B_REPORT"));

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


    #region "Transaction Management Procedures(R140W2_R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:35 PM

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
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleTMP_GOVERNANCE_PAYMENTS_FILE.Transaction = m_trnTRANS_UPDATE;
        fleTMP_GOV_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R140W2_R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:35 PM

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
            fleF075_AFP_DOC_MSTR.Dispose();
            fleTMP_GOVERNANCE_PAYMENTS_FILE.Dispose();
            fleTMP_GOV_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R140W2_R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2)"


    public void Run()
    {

        try
        {
            Request("R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2");

            while (fleF075_AFP_DOC_MSTR.QTPForMissing())
            {
                // --> GET F075_AFP_DOC_MSTR <--

                fleF075_AFP_DOC_MSTR.GetData();
                // --> End GET F075_AFP_DOC_MSTR <--

                while (fleTMP_GOVERNANCE_PAYMENTS_FILE.QTPForMissing("1"))
                {
                    // --> GET TMP_GOVERNANCE_PAYMENTS_FILE <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleTMP_GOVERNANCE_PAYMENTS_FILE.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));
                    m_strWhere.Append(" And ").Append(fleTMP_GOVERNANCE_PAYMENTS_FILE.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR")));

                    fleTMP_GOVERNANCE_PAYMENTS_FILE.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET TMP_GOVERNANCE_PAYMENTS_FILE <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleF075_AFP_DOC_MSTR.GetSortValue("DOC_AFP_PAYM_GROUP"), fleF075_AFP_DOC_MSTR.GetSortValue("DOC_OHIP_NBR"));



                        }

                    }

                }

            }


            while (Sort(fleF075_AFP_DOC_MSTR, fleTMP_GOVERNANCE_PAYMENTS_FILE))
            {
                fleTMP_GOV_ADD.OutPut(OutPutType.Add, fleF075_AFP_DOC_MSTR.At("DOC_AFP_PAYM_GROUP") || fleF075_AFP_DOC_MSTR.At("DOC_OHIP_NBR"), null);


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
            EndRequest("R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2");

        }

    }




    #endregion


}
//R140W_CHECK_IF_DOC_EXISTS_IN_INCOMING_FILE_2



public class R140W2_R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3 : R140W2
{

    public R140W2_R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR140W_TERM_F075_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R140W_TERM_F075_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(R140W2_R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3)"

    private SqlFileObject fleF075_AFP_DOC_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0')) != 0)
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


    private SqlFileObject fleR140W_TERM_F075_DOCTORS;


    #endregion


    #region "Standard Generated Procedures(R140W2_R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3)"


    #region "Automatic Item Initialization(R140W2_R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:36 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:03:35 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));

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


    #region "Transaction Management Procedures(R140W2_R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:35 PM

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
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleR140W_TERM_F075_DOCTORS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R140W2_R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:35 PM

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
            fleF075_AFP_DOC_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleR140W_TERM_F075_DOCTORS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R140W2_R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3)"


    public void Run()
    {

        try
        {
            Request("R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3");

            while (fleF075_AFP_DOC_MSTR.QTPForMissing())
            {
                // --> GET F075_AFP_DOC_MSTR <--

                fleF075_AFP_DOC_MSTR.GetData();
                // --> End GET F075_AFP_DOC_MSTR <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            SubFile(ref m_trnTRANS_UPDATE, ref fleR140W_TERM_F075_DOCTORS, SubFileType.Keep, fleF075_AFP_DOC_MSTR);



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
            EndRequest("R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3");

        }

    }




    #endregion


}
//R140W_CHECK_IF_DOC_TERMINATED_IN_F020_3



public class R140W2_R140W_SET_TERMINATED_DOCTORS_FROM_F075_4 : R140W2
{

    public R140W2_R140W_SET_TERMINATED_DOCTORS_FROM_F075_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR140W_TERM_F075_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R140W_TERM_F075_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_GOVERNANCE_PAYMENTS_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "TMP_GOVERNANCE_PAYMENTS_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_GOVERNANCE_PAYMENTS_FILE.SetItemFinals += fleTMP_GOVERNANCE_PAYMENTS_FILE_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(R140W2_R140W_SET_TERMINATED_DOCTORS_FROM_F075_4)"

    private SqlFileObject fleR140W_TERM_F075_DOCTORS;
    private SqlFileObject fleTMP_GOVERNANCE_PAYMENTS_FILE;

    private void fleTMP_GOVERNANCE_PAYMENTS_FILE_SetItemFinals()
    {

        try
        {
            if (QDesign.NULL(fleTMP_GOVERNANCE_PAYMENTS_FILE.GetStringValue("REPORTED_IN_R140B_REPORT")) == "M")
            {
                fleTMP_GOVERNANCE_PAYMENTS_FILE.set_SetValue("REPORTED_IN_R140B_REPORT", "T");
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


    #endregion


    #region "Standard Generated Procedures(R140W2_R140W_SET_TERMINATED_DOCTORS_FROM_F075_4)"


    #region "Automatic Item Initialization(R140W2_R140W_SET_TERMINATED_DOCTORS_FROM_F075_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R140W2_R140W_SET_TERMINATED_DOCTORS_FROM_F075_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:35 PM

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
        fleR140W_TERM_F075_DOCTORS.Transaction = m_trnTRANS_UPDATE;
        fleTMP_GOVERNANCE_PAYMENTS_FILE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R140W2_R140W_SET_TERMINATED_DOCTORS_FROM_F075_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:35 PM

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
            fleR140W_TERM_F075_DOCTORS.Dispose();
            fleTMP_GOVERNANCE_PAYMENTS_FILE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R140W2_R140W_SET_TERMINATED_DOCTORS_FROM_F075_4)"


    public void Run()
    {

        try
        {
            Request("R140W_SET_TERMINATED_DOCTORS_FROM_F075_4");

            while (fleR140W_TERM_F075_DOCTORS.QTPForMissing())
            {
                // --> GET R140W_TERM_F075_DOCTORS <--

                fleR140W_TERM_F075_DOCTORS.GetData();
                // --> End GET R140W_TERM_F075_DOCTORS <--

                while (fleTMP_GOVERNANCE_PAYMENTS_FILE.QTPForMissing("1"))
                {
                    // --> GET TMP_GOVERNANCE_PAYMENTS_FILE <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleTMP_GOVERNANCE_PAYMENTS_FILE.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleTMP_GOVERNANCE_PAYMENTS_FILE.GetStringValue("DOC_AFP_PAYM_GROUP")));
                    m_strWhere.Append(" And ").Append(fleTMP_GOVERNANCE_PAYMENTS_FILE.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleTMP_GOVERNANCE_PAYMENTS_FILE.GetDecimalValue("DOC_OHIP_NBR")));

                    fleTMP_GOVERNANCE_PAYMENTS_FILE.GetData(m_strWhere.ToString());
                    // --> End GET TMP_GOVERNANCE_PAYMENTS_FILE <--


                    if (Transaction())
                    {

                        Sort(fleTMP_GOVERNANCE_PAYMENTS_FILE.GetSortValue("DOC_AFP_PAYM_GROUP"), fleTMP_GOVERNANCE_PAYMENTS_FILE.GetSortValue("DOC_OHIP_NBR"));



                    }

                }

            }


            while (Sort(fleR140W_TERM_F075_DOCTORS, fleTMP_GOVERNANCE_PAYMENTS_FILE))
            {
                fleTMP_GOVERNANCE_PAYMENTS_FILE.OutPut(OutPutType.Update, fleTMP_GOVERNANCE_PAYMENTS_FILE.At("DOC_AFP_PAYM_GROUP") || fleTMP_GOVERNANCE_PAYMENTS_FILE.At("DOC_OHIP_NBR"), null);


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
            EndRequest("R140W_SET_TERMINATED_DOCTORS_FROM_F075_4");

        }

    }




    #endregion


}
//R140W_SET_TERMINATED_DOCTORS_FROM_F075_4




