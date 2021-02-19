
#region "Screen Comments"

// 91/11/14 M.C. - ORIGINAL
// - THIS PROGRAM SHOULD BE RUN AFTER CLAIMS
// PURGE (U072.CB), THIS PROGRAM WILL UPDATE
// THE OUTSTANDING CLAIMS TO PATIENT MSTR
// 1999/May/20 S.B. - Y2K checked.
// 2000/Jul/28 M.C.     - change access statement
// 2013/Apr/08 MC1      - add `set lock record update`
// 2013/Apr/22 MC2 - ran 4 times and received `*W* qtpscr.dat`, assuming the record complex is big and
// it may complain about the file size being too big for the intermediated scratch file
// - modify to split into 2 requests where first request extract the necessary item into 
// the subfile, second request update f010 based on subfile, to see if it will eliminate
// the problem.  Ran the program twice and it seemed work okay.
// 2015/Feb/19 MC3 - save the f010 subfile before updating f010 file


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U920 : BaseClassControl
{

    private U920 m_U920;

    public U920(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U920(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U920 != null))
        {
            m_U920.CloseTransactionObjects();
            m_U920 = null;
        }
    }

    public U920 GetU920(int Level)
    {
        if (m_U920 == null)
        {
            m_U920 = new U920("U920", Level);
        }
        else
        {
            m_U920.ResetValues();
        }
        return m_U920;
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

            U920_ACCESS_CLMHDR_1 ACCESS_CLMHDR_1 = new U920_ACCESS_CLMHDR_1(Name, Level);
            ACCESS_CLMHDR_1.Run();
            ACCESS_CLMHDR_1.Dispose();
            ACCESS_CLMHDR_1 = null;

            U920_UPDATE_PAT_CLM_NBR_2 UPDATE_PAT_CLM_NBR_2 = new U920_UPDATE_PAT_CLM_NBR_2(Name, Level);
            UPDATE_PAT_CLM_NBR_2.Run();
            UPDATE_PAT_CLM_NBR_2.Dispose();
            UPDATE_PAT_CLM_NBR_2 = null;

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



public class U920_ACCESS_CLMHDR_1 : U920
{

    public U920_ACCESS_CLMHDR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CLAIM_COUNT = new CoreDecimal("X_CLAIM_COUNT", 6, this);
        fleSAVECLMHDR_COUNT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVECLMHDR_COUNT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U920_ACCESS_CLMHDR_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_P_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("P"));


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


    private CoreDecimal X_CLAIM_COUNT;
    private SqlFileObject fleSAVECLMHDR_COUNT;


    #endregion


    #region "Standard Generated Procedures(U920_ACCESS_CLMHDR_1)"


    #region "Automatic Item Initialization(U920_ACCESS_CLMHDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U920_ACCESS_CLMHDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:28 PM

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
        fleSAVECLMHDR_COUNT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U920_ACCESS_CLMHDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:28 PM

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
            fleSAVECLMHDR_COUNT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U920_ACCESS_CLMHDR_1)"


    public void Run()
    {

        try
        {
            Request("ACCESS_CLMHDR_1");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--

                fleF002_CLAIMS_MSTR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--


                if (Transaction())
                {

                    Sort(fleF002_CLAIMS_MSTR.GetSortValue("KEY_P_CLM_DATA"));



                }

            }

            while (Sort(fleF002_CLAIMS_MSTR))
            {
                X_CLAIM_COUNT.Value = X_CLAIM_COUNT.Value + 1;


                SubFile(ref m_trnTRANS_UPDATE, ref fleSAVECLMHDR_COUNT, fleF002_CLAIMS_MSTR.At("KEY_P_CLM_DATA"), SubFileType.Keep, fleF002_CLAIMS_MSTR, "KEY_P_CLM_DATA", X_CLAIM_COUNT);



                Reset(ref X_CLAIM_COUNT, fleF002_CLAIMS_MSTR.At("KEY_P_CLM_DATA"));

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
            EndRequest("ACCESS_CLMHDR_1");

        }

    }




    #endregion


}
//ACCESS_CLMHDR_1



public class U920_UPDATE_PAT_CLM_NBR_2 : U920
{

    public U920_UPDATE_PAT_CLM_NBR_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSAVECLMHDR_COUNT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVECLMHDR_COUNT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF010 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF010", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF010_PAT_MSTR.SetItemFinals += fleF010_PAT_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U920_UPDATE_PAT_CLM_NBR_2)"

    private SqlFileObject fleSAVECLMHDR_COUNT;
    private SqlFileObject fleF010_PAT_MSTR;

    private void fleF010_PAT_MSTR_SetItemFinals()
    {

        try
        {
            fleF010_PAT_MSTR.set_SetValue("PAT_NBR_OUTSTANDING_CLAIMS", fleSAVECLMHDR_COUNT.GetDecimalValue("X_CLAIM_COUNT"));
            fleF010_PAT_MSTR.set_SetValue("PAT_NBR_OUTSTANDING_CLAIMS", fleSAVECLMHDR_COUNT.GetDecimalValue("X_CLAIM_COUNT"));
            fleF010_PAT_MSTR.set_SetValue("PAT_TOTAL_NBR_CLAIMS", fleSAVECLMHDR_COUNT.GetDecimalValue("X_CLAIM_COUNT"));
            fleF010_PAT_MSTR.set_SetValue("PAT_TOTAL_NBR_CLAIMS", fleSAVECLMHDR_COUNT.GetDecimalValue("X_CLAIM_COUNT"));


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


    private SqlFileObject fleSAVEF010;


    #endregion


    #region "Standard Generated Procedures(U920_UPDATE_PAT_CLM_NBR_2)"


    #region "Automatic Item Initialization(U920_UPDATE_PAT_CLM_NBR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U920_UPDATE_PAT_CLM_NBR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:28 PM

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
        fleSAVECLMHDR_COUNT.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF010.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U920_UPDATE_PAT_CLM_NBR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:28 PM

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
            fleSAVECLMHDR_COUNT.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleSAVEF010.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U920_UPDATE_PAT_CLM_NBR_2)"


    public void Run()
    {

        try
        {
            Request("UPDATE_PAT_CLM_NBR_2");

            while (fleSAVECLMHDR_COUNT.QTPForMissing())
            {
                // --> GET SAVECLMHDR_COUNT <--

                fleSAVECLMHDR_COUNT.GetData();
                // --> End GET SAVECLMHDR_COUNT <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((("I" + fleSAVECLMHDR_COUNT.GetStringValue("KEY_P_CLM_DATA"))).PadRight(16).Substring(0, 1)));

                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((("I" + fleSAVECLMHDR_COUNT.GetStringValue("KEY_P_CLM_DATA"))).PadRight(16).Substring(1, 2)));

                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((("I" + fleSAVECLMHDR_COUNT.GetStringValue("KEY_P_CLM_DATA"))).PadRight(16).Substring(3, 12)));

                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((("I" + fleSAVECLMHDR_COUNT.GetStringValue("KEY_P_CLM_DATA"))).PadRight(16).Substring(15, 1)));


                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F010_PAT_MSTR <--


                    if (Transaction())
                    {

                        Sort(fleF010_PAT_MSTR.GetSortValue("PAT_I_KEY"), fleF010_PAT_MSTR.GetSortValue("PAT_CON_NBR"), fleF010_PAT_MSTR.GetSortValue("PAT_I_NBR"), fleF010_PAT_MSTR.GetSortValue("FILLER4"));




                    }

                }

            }


            while (Sort(fleSAVECLMHDR_COUNT, fleF010_PAT_MSTR))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF010, fleF010_PAT_MSTR.At("KEY_PAT_MSTR"), SubFileType.Keep, fleF010_PAT_MSTR);



                fleF010_PAT_MSTR.OutPut(OutPutType.Update, fleF010_PAT_MSTR.At("KEY_PAT_MSTR"), null);


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
            EndRequest("UPDATE_PAT_CLM_NBR_2");

        }

    }




    #endregion


}
//UPDATE_PAT_CLM_NBR_2




