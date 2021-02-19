
#region "Screen Comments"

// #> PROGRAM-ID.     U030B_1.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : This program update total amount paid for the doctor
// to f075-afp-doc-mstr                        
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 04/Jul/08 M.C.         - ORIGINAL
// 2007/feb/22 b.e. - access group`s process flag and handle the REPORT ONLY
// and the EARNINGS SUBSYTEM groups differently since
// REPORT ONLY doctors don`t have RMA nbrs and must
// be processed using their OHIP nbr
// 2007/07/19 - MC  - modify access statment 
// 2007/07/19 - MC
// set lock file update 
// 2007/07/19 - end
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U030B_1 : BaseClassControl
{

    private U030B_1 m_U030B_1;

    public U030B_1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U030B_1(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U030B_1 != null))
        {
            m_U030B_1.CloseTransactionObjects();
            m_U030B_1 = null;
        }
    }

    public U030B_1 GetU030B_1(int Level)
    {
        if (m_U030B_1 == null)
        {
            m_U030B_1 = new U030B_1("U030B_1", Level);
        }
        else
        {
            m_U030B_1.ResetValues();
        }
        return m_U030B_1;
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

            U030B_1_UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1 UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1 = new U030B_1_UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1(Name, Level);
            UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1.Run();
            UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1.Dispose();
            UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1 = null;

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



public class U030B_1_UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1 : U030B_1
{

    public U030B_1_UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_PAID_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_PAID_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        TOTAL_AMT_PAID = new CoreDecimal("TOTAL_AMT_PAID", 8, this);

        fleF075_AFP_DOC_MSTR.SetItemFinals += fleF075_AFP_DOC_MSTR_SetItemFinals;
        fleF074_AFP_GROUP_MSTR.InitializeItems += fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_1_UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1)"

    private SqlFileObject fleU030_PAID_AMT;
    private SqlFileObject fleICONST_MSTR_REC;
    private SqlFileObject fleF075_AFP_DOC_MSTR;

    private void fleF075_AFP_DOC_MSTR_SetItemFinals()
    {

        try
        {
            fleF075_AFP_DOC_MSTR.set_SetValue("RA_PAYMENT_AMT", fleF075_AFP_DOC_MSTR.GetDecimalValue("RA_PAYMENT_AMT") + TOTAL_AMT_PAID.Value);


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

    private SqlFileObject fleF074_AFP_GROUP_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_GROUP_PROCESS_FLAG")) == "E")
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


    private CoreDecimal TOTAL_AMT_PAID;


    #endregion


    #region "Standard Generated Procedures(U030B_1_UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1)"


    #region "Automatic Item Initialization(U030B_1_UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:48 PM

    //#-----------------------------------------
    //# fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:07:48 PM
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


    #region "Transaction Management Procedures(U030B_1_UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:46 PM

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
        fleU030_PAID_AMT.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_1_UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:46 PM

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
            fleU030_PAID_AMT.Dispose();
            fleICONST_MSTR_REC.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_1_UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1");

            while (fleU030_PAID_AMT.QTPForMissing())
            {
                // --> GET U030_PAID_AMT <--

                fleU030_PAID_AMT.GetData();
                // --> End GET U030_PAID_AMT <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR"))));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--

                    while (fleF075_AFP_DOC_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F075_AFP_DOC_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_PAID_AMT.GetStringValue("RAT_145_ACCOUNT_NBR"), 1, 3)));
                        m_strWhere.Append(" And ").Append(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_NBR")));

                        fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F075_AFP_DOC_MSTR <--

                        while (fleF074_AFP_GROUP_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F074_AFP_GROUP_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));

                            fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString());
                            // --> End GET F074_AFP_GROUP_MSTR <--


                            if (Transaction())
                            {

                                 if (Select_If())
                                {

                                    Sort(fleF075_AFP_DOC_MSTR.GetSortValue("DOC_NBR"), fleF075_AFP_DOC_MSTR.GetSortValue("DOC_AFP_PAYM_GROUP"));



                                }

                            }

                        }

                    }

                }

            }

            while (Sort(fleU030_PAID_AMT, fleICONST_MSTR_REC, fleF075_AFP_DOC_MSTR, fleF074_AFP_GROUP_MSTR))
            {
                TOTAL_AMT_PAID.Value = TOTAL_AMT_PAID.Value + fleU030_PAID_AMT.GetDecimalValue("X_TOT_AMT_PAID");

                fleF075_AFP_DOC_MSTR.OutPut(OutPutType.Update, fleF075_AFP_DOC_MSTR.At("DOC_NBR") || fleF075_AFP_DOC_MSTR.At("DOC_AFP_PAYM_GROUP"), null);

                Reset(ref TOTAL_AMT_PAID, fleF075_AFP_DOC_MSTR.At("DOC_NBR") || fleF075_AFP_DOC_MSTR.At("DOC_AFP_PAYM_GROUP"));

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
            EndRequest("UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1");

        }

    }







    #endregion


}
//UPDATE_AFT_DOC_MSTR_EARNINGS_GROUPS_1




