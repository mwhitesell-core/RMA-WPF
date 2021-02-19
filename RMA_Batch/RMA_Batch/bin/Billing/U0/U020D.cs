
#region "Screen Comments"

// #> PROGRAM-ID.     U020D.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : 
// 1. add a new record to ohip-run-dates
// 2. UPDATE clmhdr-submit-date from rejected-claims file to be
// the last ohip-run-date, assuming all the outstanding records
// with zero clmhdr-submit-date might have created from u021f
// Note:  This program is to be executed once after running u020 for all contracts (A to E)
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 2011/Jan/20 M.C.         - ORIGINAL 
// 2011/Feb/14 MC1      - transfer request update_const_mstr from u020c.qts to this program
// 2011/02/14 - transfer this request from u020c.qts 


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U020D : BaseClassControl
{

    private U020D m_U020D;

    public U020D(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U020D(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U020D != null))
        {
            m_U020D.CloseTransactionObjects();
            m_U020D = null;
        }
    }

    public U020D GetU020D(int Level)
    {
        if (m_U020D == null)
        {
            m_U020D = new U020D("U020D", Level);
        }
        else
        {
            m_U020D.ResetValues();
        }
        return m_U020D;
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

            U020D_UPDATE_ICONST_MSTR_1 UPDATE_ICONST_MSTR_1 = new U020D_UPDATE_ICONST_MSTR_1(Name, Level);
            UPDATE_ICONST_MSTR_1.Run();
            UPDATE_ICONST_MSTR_1.Dispose();
            UPDATE_ICONST_MSTR_1 = null;

            U020D_UPDATE_OHIP_RUN_DATES_2 UPDATE_OHIP_RUN_DATES_2 = new U020D_UPDATE_OHIP_RUN_DATES_2(Name, Level);
            UPDATE_OHIP_RUN_DATES_2.Run();
            UPDATE_OHIP_RUN_DATES_2.Dispose();
            UPDATE_OHIP_RUN_DATES_2 = null;

            U020D_UPDATE_F085_DATE_3 UPDATE_F085_DATE_3 = new U020D_UPDATE_F085_DATE_3(Name, Level);
            UPDATE_F085_DATE_3.Run();
            UPDATE_F085_DATE_3.Dispose();
            UPDATE_F085_DATE_3 = null;

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



public class U020D_UPDATE_ICONST_MSTR_1 : U020D
{

    public U020D_UPDATE_ICONST_MSTR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleICONST_MSTR_REC.SetItemFinals += fleICONST_MSTR_REC_SetItemFinals;
        fleICONST_MSTR_REC.Choose += fleICONST_MSTR_REC_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U020D_UPDATE_ICONST_MSTR_1)"

    private SqlFileObject fleICONST_MSTR_REC;

    private void fleICONST_MSTR_REC_SetItemFinals()
    {

        try
        {
            fleICONST_MSTR_REC.set_SetValue("ICONST_CLINIC_CYCLE_NBR", fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_CYCLE_NBR") + 1);


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


    private void fleICONST_MSTR_REC_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
            strSQL.Append(22);


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


    #region "Standard Generated Procedures(U020D_UPDATE_ICONST_MSTR_1)"


    #region "Automatic Item Initialization(U020D_UPDATE_ICONST_MSTR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U020D_UPDATE_ICONST_MSTR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:10 PM

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
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U020D_UPDATE_ICONST_MSTR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:10 PM

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
            fleICONST_MSTR_REC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U020D_UPDATE_ICONST_MSTR_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_ICONST_MSTR_1");

            while (fleICONST_MSTR_REC.QTPForMissing())
            {
                // --> GET ICONST_MSTR_REC <--

                fleICONST_MSTR_REC.GetData();
                // --> End GET ICONST_MSTR_REC <--


                if (Transaction())
                {

                    Sort(fleICONST_MSTR_REC.GetSortValue("ICONST_CLINIC_NBR_1_2"));


                }

            }

            while (Sort(fleICONST_MSTR_REC))
            {
                fleICONST_MSTR_REC.OutPut(OutPutType.Update, fleICONST_MSTR_REC.At("ICONST_CLINIC_NBR_1_2"), null);

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
            EndRequest("UPDATE_ICONST_MSTR_1");

        }

    }







    #endregion


}
//UPDATE_ICONST_MSTR_1



public class U020D_UPDATE_OHIP_RUN_DATES_2 : U020D
{

    public U020D_UPDATE_OHIP_RUN_DATES_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleOHIP_RUN_DATES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "OHIP_RUN_DATES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleRUN_DATE_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "OHIP_RUN_DATES", "RUN_DATE_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU020C_OHIP_RUN_DATE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020C_OHIP_RUN_DATE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleRUN_DATE_ADD.SetItemFinals += fleRUN_DATE_ADD_SetItemFinals;
        fleRUN_DATE_ADD.InitializeItems += fleRUN_DATE_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U020D_UPDATE_OHIP_RUN_DATES_2)"

    private SqlFileObject fleOHIP_RUN_DATES;
    private SqlFileObject fleRUN_DATE_ADD;

    private void fleRUN_DATE_ADD_SetItemFinals()
    {

        try
        {
            fleRUN_DATE_ADD.set_SetValue("SEQ_NBR", fleOHIP_RUN_DATES.GetDecimalValue("SEQ_NBR") + 1);
            fleRUN_DATE_ADD.set_SetValue("OHIP_RUN_DATE", QDesign.SysDate(ref m_cnnQUERY));


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

    private SqlFileObject fleU020C_OHIP_RUN_DATE;


    #endregion


    #region "Standard Generated Procedures(U020D_UPDATE_OHIP_RUN_DATES_2)"


    #region "Automatic Item Initialization(U020D_UPDATE_OHIP_RUN_DATES_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:10 PM

    //#-----------------------------------------
    //# fleRUN_DATE_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.20448  Generated on: 6/27/2017 12:28:10 PM
    //#-----------------------------------------
    private void fleRUN_DATE_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleRUN_DATE_ADD.set_SetValue("SEQ_NBR", !Fixed, fleOHIP_RUN_DATES.GetDecimalValue("SEQ_NBR"));
            fleRUN_DATE_ADD.set_SetValue("OHIP_RUN_DATE", !Fixed, fleOHIP_RUN_DATES.GetDecimalValue("OHIP_RUN_DATE"));

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


    #region "Transaction Management Procedures(U020D_UPDATE_OHIP_RUN_DATES_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:10 PM

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
        fleOHIP_RUN_DATES.Transaction = m_trnTRANS_UPDATE;
        fleRUN_DATE_ADD.Transaction = m_trnTRANS_UPDATE;
        fleU020C_OHIP_RUN_DATE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U020D_UPDATE_OHIP_RUN_DATES_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:10 PM

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
            fleOHIP_RUN_DATES.Dispose();
            fleRUN_DATE_ADD.Dispose();
            fleU020C_OHIP_RUN_DATE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U020D_UPDATE_OHIP_RUN_DATES_2)"


    public void Run()
    {

        try
        {
            Request("UPDATE_OHIP_RUN_DATES_2");

            while (fleOHIP_RUN_DATES.QTPForMissing())
            {
                // --> GET OHIP_RUN_DATES <--

                fleOHIP_RUN_DATES.GetData();
                // --> End GET OHIP_RUN_DATES <--


                if (Transaction())
                {
                    fleRUN_DATE_ADD.OutPut(OutPutType.Add, AtFinal(), null);


                    SubFile(ref m_trnTRANS_UPDATE, ref fleU020C_OHIP_RUN_DATE, AtFinal(), SubFileType.Keep, fleRUN_DATE_ADD, "OHIP_RUN_DATE");


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
            EndRequest("UPDATE_OHIP_RUN_DATES_2");

        }

    }







    #endregion


}
//UPDATE_OHIP_RUN_DATES_2



public class U020D_UPDATE_F085_DATE_3 : U020D
{

    public U020D_UPDATE_F085_DATE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleREJECTED_CLAIMS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F085_REJECTED_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU020C_OHIP_RUN_DATE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020C_OHIP_RUN_DATE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleREJECTED_CLAIMS.SetItemFinals += fleREJECTED_CLAIMS_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U020D_UPDATE_F085_DATE_3)"

    private SqlFileObject fleREJECTED_CLAIMS;

    private void fleREJECTED_CLAIMS_SetItemFinals()
    {

        try
        {
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_SUBMIT_DATE", fleU020C_OHIP_RUN_DATE.GetNumericDateValue("OHIP_RUN_DATE"));


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

    private SqlFileObject fleU020C_OHIP_RUN_DATE;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleREJECTED_CLAIMS.GetNumericDateValue("CLMHDR_SUBMIT_DATE")) == 0)
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


    #region "Standard Generated Procedures(U020D_UPDATE_F085_DATE_3)"


    #region "Automatic Item Initialization(U020D_UPDATE_F085_DATE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U020D_UPDATE_F085_DATE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:10 PM

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
        fleREJECTED_CLAIMS.Transaction = m_trnTRANS_UPDATE;
        fleU020C_OHIP_RUN_DATE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U020D_UPDATE_F085_DATE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:10 PM

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
            fleREJECTED_CLAIMS.Dispose();
            fleU020C_OHIP_RUN_DATE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U020D_UPDATE_F085_DATE_3)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F085_DATE_3");

            while (fleREJECTED_CLAIMS.QTPForMissing())
            {
                // --> GET REJECTED_CLAIMS <--

                fleREJECTED_CLAIMS.GetData();
                // --> End GET REJECTED_CLAIMS <--

                while (fleU020C_OHIP_RUN_DATE.QTPForMissing("1"))
                {
                    // --> GET U020C_OHIP_RUN_DATE <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleU020C_OHIP_RUN_DATE.ElementOwner("CORE_RECORD_NUMBER")).Append(" = ");
                    m_strWhere.Append((0));

                    fleU020C_OHIP_RUN_DATE.GetData(m_strWhere.ToString());
                    // --> End GET U020C_OHIP_RUN_DATE <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {
                            fleREJECTED_CLAIMS.OutPut(OutPutType.Update);

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
            EndRequest("UPDATE_F085_DATE_3");

        }

    }







    #endregion


}
//UPDATE_F085_DATE_3




