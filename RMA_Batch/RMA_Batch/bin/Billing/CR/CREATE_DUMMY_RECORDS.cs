
#region "Screen Comments"

// 2012/Jun/20 MC - As Brad Suggested, create dummy records in files as part of the backup macros


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class CREATE_DUMMY_RECORDS : BaseClassControl
{

    private CREATE_DUMMY_RECORDS m_CREATE_DUMMY_RECORDS;

    public CREATE_DUMMY_RECORDS(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public CREATE_DUMMY_RECORDS(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_CREATE_DUMMY_RECORDS != null))
        {
            m_CREATE_DUMMY_RECORDS.CloseTransactionObjects();
            m_CREATE_DUMMY_RECORDS = null;
        }
    }

    public CREATE_DUMMY_RECORDS GetCREATE_DUMMY_RECORDS(int Level)
    {
        if (m_CREATE_DUMMY_RECORDS == null)
        {
            m_CREATE_DUMMY_RECORDS = new CREATE_DUMMY_RECORDS("CREATE_DUMMY_RECORDS", Level);
        }
        else
        {
            m_CREATE_DUMMY_RECORDS.ResetValues();
        }
        return m_CREATE_DUMMY_RECORDS;
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

            CREATE_DUMMY_RECORDS_CREATE_F001_1 CREATE_F001_1 = new CREATE_DUMMY_RECORDS_CREATE_F001_1(Name, Level);
            CREATE_F001_1.Run();
            CREATE_F001_1.Dispose();
            CREATE_F001_1 = null;

            CREATE_DUMMY_RECORDS_CREATE_F002_2 CREATE_F002_2 = new CREATE_DUMMY_RECORDS_CREATE_F002_2(Name, Level);
            CREATE_F002_2.Run();
            CREATE_F002_2.Dispose();
            CREATE_F002_2 = null;

            CREATE_DUMMY_RECORDS_CREATE_F010_3 CREATE_F010_3 = new CREATE_DUMMY_RECORDS_CREATE_F010_3(Name, Level);
            CREATE_F010_3.Run();
            CREATE_F010_3.Dispose();
            CREATE_F010_3 = null;

            CREATE_DUMMY_RECORDS_CREATE_F020_4 CREATE_F020_4 = new CREATE_DUMMY_RECORDS_CREATE_F020_4(Name, Level);
            CREATE_F020_4.Run();
            CREATE_F020_4.Dispose();
            CREATE_F020_4 = null;

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



public class CREATE_DUMMY_RECORDS_CREATE_F001_1 : CREATE_DUMMY_RECORDS
{

    public CREATE_DUMMY_RECORDS_CREATE_F001_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF001_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "F001_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF001_ADD.InitializeItems += fleF001_ADD_InitializeItems;
        fleF001_ADD.InitializeItems += fleF001_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(CREATE_DUMMY_RECORDS_CREATE_F001_1)"

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;
    private SqlFileObject fleF001_ADD;

    private void fleF001_ADD_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF001_ADD.set_SetValue("BATCTRL_BATCH_NBR", true, "ZZZZZZZZ");
            if (!Fixed)
                fleF001_ADD.set_SetValue("BATCTRL_BATCH_STATUS", true, "4");
            if (!Fixed)
                fleF001_ADD.set_SetValue("BATCTRL_DATE_BATCH_ENTERED", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY)));


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


    #region "Standard Generated Procedures(CREATE_DUMMY_RECORDS_CREATE_F001_1)"


    #region "Automatic Item Initialization(CREATE_DUMMY_RECORDS_CREATE_F001_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------
    private void fleF001_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF001_ADD.set_SetValue("BATCTRL_BATCH_NBR", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"));
            fleF001_ADD.set_SetValue("BATCTRL_BATCH_TYPE", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE"));
            fleF001_ADD.set_SetValue("BATCTRL_ADJ_CD", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD"));
            fleF001_ADD.set_SetValue("BATCTRL_ADJ_CD_SUB_TYPE", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD_SUB_TYPE"));
            fleF001_ADD.set_SetValue("BATCTRL_LAST_CLAIM_NBR", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_LAST_CLAIM_NBR"));
            fleF001_ADD.set_SetValue("BATCTRL_CLINIC_NBR", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_CLINIC_NBR"));
            fleF001_ADD.set_SetValue("BATCTRL_DOC_NBR_OHIP", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_DOC_NBR_OHIP"));
            fleF001_ADD.set_SetValue("BATCTRL_HOSP", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_HOSP"));
            fleF001_ADD.set_SetValue("BATCTRL_LOC", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_LOC"));
            fleF001_ADD.set_SetValue("BATCTRL_AGENT_CD", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AGENT_CD"));
            fleF001_ADD.set_SetValue("BATCTRL_I_O_PAT_IND", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_I_O_PAT_IND"));
            fleF001_ADD.set_SetValue("BATCTRL_DATE_BATCH_ENTERED", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_DATE_BATCH_ENTERED"));
            fleF001_ADD.set_SetValue("BATCTRL_DATE_PERIOD_END", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_DATE_PERIOD_END"));
            fleF001_ADD.set_SetValue("BATCTRL_CYCLE_NBR", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CYCLE_NBR"));
            fleF001_ADD.set_SetValue("BATCTRL_AMT_EST", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_EST"));
            fleF001_ADD.set_SetValue("BATCTRL_AMT_ACT", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT"));
            fleF001_ADD.set_SetValue("BATCTRL_SVC_EST", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_EST"));
            fleF001_ADD.set_SetValue("BATCTRL_SVC_ACT", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_ACT"));
            fleF001_ADD.set_SetValue("BATCTRL_AR_YY_MM", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_AR_YY_MM"));
            fleF001_ADD.set_SetValue("BATCTRL_CALC_AR_DUE", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE"));
            fleF001_ADD.set_SetValue("BATCTRL_CALC_TOT_REV", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_TOT_REV"));
            fleF001_ADD.set_SetValue("BATCTRL_MANUAL_PAY_TOT", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_MANUAL_PAY_TOT"));
            fleF001_ADD.set_SetValue("BATCTRL_BATCH_STATUS", !Fixed, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_STATUS"));
            fleF001_ADD.set_SetValue("BATCTRL_NBR_CLAIMS_IN_BATCH", !Fixed, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH"));

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


    #region "Transaction Management Procedures(CREATE_DUMMY_RECORDS_CREATE_F001_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

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
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF001_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(CREATE_DUMMY_RECORDS_CREATE_F001_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

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
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleF001_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CREATE_DUMMY_RECORDS_CREATE_F001_1)"


    public void Run()
    {

        try
        {
            Request("CREATE_F001_1");

            while (fleF001_BATCH_CONTROL_FILE.QTPForMissing())
            {
                // --> GET F001_BATCH_CONTROL_FILE <--

                fleF001_BATCH_CONTROL_FILE.GetData();
                // --> End GET F001_BATCH_CONTROL_FILE <--


                if (Transaction())
                {


                    fleF001_ADD.OutPut(OutPutType.Add);
                   

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
            EndRequest("CREATE_F001_1");

        }

    }




    #endregion


}
//CREATE_F001_1



public class CREATE_DUMMY_RECORDS_CREATE_F002_2 : CREATE_DUMMY_RECORDS
{

    public CREATE_DUMMY_RECORDS_CREATE_F002_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "F002_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_ADD.InitializeItems += fleF002_ADD_InitializeItems;

    }


    #region "Declarations (Variables, Files and Transactions)(CREATE_DUMMY_RECORDS_CREATE_F002_2)"

    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleF002_ADD;

    private void fleF002_ADD_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF002_ADD.set_SetValue("KEY_CLM_TYPE", true, "B");
            if (!Fixed)
                fleF002_ADD.set_SetValue("KEY_CLM_BATCH_NBR", true, "ZZZZZZZZ");
            if (!Fixed)
                fleF002_ADD.set_SetValue("KEY_CLM_CLAIM_NBR", true, 99);
            if (!Fixed)
                fleF002_ADD.set_SetValue("KEY_CLM_SERV_CODE", true, "ZZZZZ");
            if (!Fixed)
                fleF002_ADD.set_SetValue("KEY_CLM_ADJ_NBR", true, "Z");
            if (!Fixed)
                fleF002_ADD.set_SetValue("KEY_P_CLM_TYPE", true, "P");
            if (!Fixed)
                fleF002_ADD.set_SetValue("KEY_P_CLM_DATA", true, "ZZZZZZZZZZZZZZZZ");
            if (!Fixed)
                fleF002_ADD.set_SetValue("CLMHDR_DATE_SYS", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY)));


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


    #region "Standard Generated Procedures(CREATE_DUMMY_RECORDS_CREATE_F002_2)"


    #region "Automatic Item Initialization(CREATE_DUMMY_RECORDS_CREATE_F002_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(CREATE_DUMMY_RECORDS_CREATE_F002_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

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
        fleF002_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(CREATE_DUMMY_RECORDS_CREATE_F002_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

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
            fleF002_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CREATE_DUMMY_RECORDS_CREATE_F002_2)"


    public void Run()
    {

        try
        {
            Request("CREATE_F002_2");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--

                fleF002_CLAIMS_MSTR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--


                if (Transaction())
                {


                    fleF002_ADD.OutPut(OutPutType.Add);
                   

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
            EndRequest("CREATE_F002_2");

        }

    }




    #endregion


}
//CREATE_F002_2



public class CREATE_DUMMY_RECORDS_CREATE_F010_3 : CREATE_DUMMY_RECORDS
{

    public CREATE_DUMMY_RECORDS_CREATE_F010_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "F010_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF010_ADD.InitializeItems += fleF010_ADD_InitializeItems;
        fleF010_ADD.InitializeItems += fleF010_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(CREATE_DUMMY_RECORDS_CREATE_F010_3)"

    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleF010_ADD;

    private void fleF010_ADD_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF010_ADD.set_SetValue("KEY_PAT_MSTR", true, "ZZZZZZZZZZZZZZZ");
            if (!Fixed)
                fleF010_ADD.set_SetValue("PAT_DATE_LAST_MAINT", true, QDesign.SysDate(ref m_cnnQUERY));


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


    #region "Standard Generated Procedures(CREATE_DUMMY_RECORDS_CREATE_F010_3)"


    #region "Automatic Item Initialization(CREATE_DUMMY_RECORDS_CREATE_F010_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF010_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------
    private void fleF010_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF010_ADD.set_SetValue("PAT_ACRONYM_FIRST6", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6"));
            fleF010_ADD.set_SetValue("PAT_ACRONYM_LAST3", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3"));
            fleF010_ADD.set_SetValue("PAT_DIRECT_ALPHA", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_ALPHA"));
            fleF010_ADD.set_SetValue("PAT_DIRECT_YY", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_YY"));
            fleF010_ADD.set_SetValue("PAT_DIRECT_MM", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_MM"));
            fleF010_ADD.set_SetValue("PAT_DIRECT_DD", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_DD"));
            fleF010_ADD.set_SetValue("PAT_DIRECT_LAST_6", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_LAST_6"));
            fleF010_ADD.set_SetValue("PAT_CHART_NBR", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR"));
            fleF010_ADD.set_SetValue("PAT_CHART_NBR_2", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_2"));
            fleF010_ADD.set_SetValue("PAT_CHART_NBR_3", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_3"));
            fleF010_ADD.set_SetValue("PAT_CHART_NBR_4", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_4"));
            fleF010_ADD.set_SetValue("PAT_CHART_NBR_5", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_5"));
            fleF010_ADD.set_SetValue("PAT_SURNAME_FIRST3", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3"));
            fleF010_ADD.set_SetValue("PAT_SURNAME_LAST22", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22"));
            fleF010_ADD.set_SetValue("PAT_GIVEN_NAME_FIRST1", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST1"));
            fleF010_ADD.set_SetValue("FILLER3", !Fixed, fleF010_PAT_MSTR.GetStringValue("FILLER3"));
            fleF010_ADD.set_SetValue("PAT_INIT1", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_INIT1"));
            fleF010_ADD.set_SetValue("PAT_INIT2", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_INIT2"));
            fleF010_ADD.set_SetValue("PAT_INIT3", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_INIT3"));
            fleF010_ADD.set_SetValue("PAT_LOCATION_FIELD", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_LOCATION_FIELD"));
            fleF010_ADD.set_SetValue("PAT_LAST_DOC_NBR_SEEN", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_LAST_DOC_NBR_SEEN"));
            fleF010_ADD.set_SetValue("PAT_BIRTH_DATE_YY", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_YY"));
            fleF010_ADD.set_SetValue("PAT_BIRTH_DATE_MM", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_MM"));
            fleF010_ADD.set_SetValue("PAT_BIRTH_DATE_DD", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_DD"));
            fleF010_ADD.set_SetValue("PAT_DATE_LAST_MAINT", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_DATE_LAST_MAINT"));
            fleF010_ADD.set_SetValue("PAT_DATE_LAST_VISIT", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_DATE_LAST_VISIT"));
            fleF010_ADD.set_SetValue("PAT_DATE_LAST_ADMIT", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_DATE_LAST_ADMIT"));
            fleF010_ADD.set_SetValue("PAT_PHONE_NBR", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_PHONE_NBR"));
            fleF010_ADD.set_SetValue("PAT_TOTAL_NBR_VISITS", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_TOTAL_NBR_VISITS"));
            fleF010_ADD.set_SetValue("PAT_TOTAL_NBR_CLAIMS", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_TOTAL_NBR_CLAIMS"));
            fleF010_ADD.set_SetValue("PAT_SEX", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_SEX"));
            fleF010_ADD.set_SetValue("PAT_IN_OUT", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_IN_OUT"));
            fleF010_ADD.set_SetValue("PAT_NBR_OUTSTANDING_CLAIMS", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_NBR_OUTSTANDING_CLAIMS"));
            fleF010_ADD.set_SetValue("PAT_I_KEY", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY"));
            fleF010_ADD.set_SetValue("PAT_CON_NBR", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"));
            fleF010_ADD.set_SetValue("PAT_I_NBR", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"));
            fleF010_ADD.set_SetValue("FILLER4", !Fixed, fleF010_PAT_MSTR.GetStringValue("FILLER4"));
            fleF010_ADD.set_SetValue("PAT_HEALTH_NBR", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR"));
            fleF010_ADD.set_SetValue("PAT_VERSION_CD", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD"));
            fleF010_ADD.set_SetValue("PAT_HEALTH_65_IND", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_HEALTH_65_IND"));
            fleF010_ADD.set_SetValue("PAT_EXPIRY_YY", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_EXPIRY_YY"));
            fleF010_ADD.set_SetValue("PAT_EXPIRY_MM", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_EXPIRY_MM"));
            fleF010_ADD.set_SetValue("PAT_PROV_CD", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD"));
            fleF010_ADD.set_SetValue("SUBSCR_ADDR1", !Fixed, fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR1"));
            fleF010_ADD.set_SetValue("SUBSCR_ADDR2", !Fixed, fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR2"));
            fleF010_ADD.set_SetValue("SUBSCR_ADDR3", !Fixed, fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3"));
            fleF010_ADD.set_SetValue("SUBSCR_PROV_CD", !Fixed, fleF010_PAT_MSTR.GetStringValue("SUBSCR_PROV_CD"));
            fleF010_ADD.set_SetValue("SUBSCR_POST_CD1", !Fixed, fleF010_PAT_MSTR.GetStringValue("SUBSCR_POST_CD1"));
            fleF010_ADD.set_SetValue("SUBSCR_POST_CD2", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_POST_CD2"));
            fleF010_ADD.set_SetValue("SUBSCR_POST_CD3", !Fixed, fleF010_PAT_MSTR.GetStringValue("SUBSCR_POST_CD3"));
            fleF010_ADD.set_SetValue("SUBSCR_POST_CD4", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_POST_CD4"));
            fleF010_ADD.set_SetValue("SUBSCR_POST_CD5", !Fixed, fleF010_PAT_MSTR.GetStringValue("SUBSCR_POST_CD5"));
            fleF010_ADD.set_SetValue("SUBSCR_POST_CD6", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_POST_CD6"));
            fleF010_ADD.set_SetValue("FILLER", !Fixed, fleF010_PAT_MSTR.GetStringValue("FILLER"));
            fleF010_ADD.set_SetValue("SUBSCR_MSG_NBR", !Fixed, fleF010_PAT_MSTR.GetStringValue("SUBSCR_MSG_NBR"));
            fleF010_ADD.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY"));
            fleF010_ADD.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM"));
            fleF010_ADD.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD"));
            fleF010_ADD.set_SetValue("SUBSCR_DATE_LAST_STATEMENT_YY", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_DATE_LAST_STATEMENT_YY"));
            fleF010_ADD.set_SetValue("SUBSCR_DATE_LAST_STATEMENT_MM", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_DATE_LAST_STATEMENT_MM"));
            fleF010_ADD.set_SetValue("SUBSCR_DATE_LAST_STATEMENT_DD", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("SUBSCR_DATE_LAST_STATEMENT_DD"));
            fleF010_ADD.set_SetValue("SUBSCR_AUTO_UPDATE", !Fixed, fleF010_PAT_MSTR.GetStringValue("SUBSCR_AUTO_UPDATE"));
            fleF010_ADD.set_SetValue("PAT_LAST_MOD_BY", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_LAST_MOD_BY"));
            fleF010_ADD.set_SetValue("PAT_DATE_LAST_ELIG_MAILING", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_DATE_LAST_ELIG_MAILING"));
            fleF010_ADD.set_SetValue("PAT_DATE_LAST_ELIG_MAINT", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_DATE_LAST_ELIG_MAINT"));
            fleF010_ADD.set_SetValue("PAT_LAST_BIRTH_DATE", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_LAST_BIRTH_DATE"));
            fleF010_ADD.set_SetValue("PAT_LAST_VERSION_CD", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_LAST_VERSION_CD"));
            fleF010_ADD.set_SetValue("PAT_MESS_CODE", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_MESS_CODE"));
            fleF010_ADD.set_SetValue("PAT_COUNTRY", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_COUNTRY"));
            fleF010_ADD.set_SetValue("PAT_NO_OF_LETTER_SENT", !Fixed, fleF010_PAT_MSTR.GetDecimalValue("PAT_NO_OF_LETTER_SENT"));
            fleF010_ADD.set_SetValue("PAT_DIALYSIS", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_DIALYSIS"));
            fleF010_ADD.set_SetValue("PAT_OHIP_VALIDATION_STATUS", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_OHIP_VALIDATION_STATUS"));
            fleF010_ADD.set_SetValue("PAT_OBEC_STATUS", !Fixed, fleF010_PAT_MSTR.GetStringValue("PAT_OBEC_STATUS"));

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


    #region "Transaction Management Procedures(CREATE_DUMMY_RECORDS_CREATE_F010_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

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
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(CREATE_DUMMY_RECORDS_CREATE_F010_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

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
            fleF010_PAT_MSTR.Dispose();
            fleF010_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CREATE_DUMMY_RECORDS_CREATE_F010_3)"


    public void Run()
    {

        try
        {
            Request("CREATE_F010_3");

            while (fleF010_PAT_MSTR.QTPForMissing())
            {
                // --> GET F010_PAT_MSTR <--

                fleF010_PAT_MSTR.GetData();
                // --> End GET F010_PAT_MSTR <--


                if (Transaction())
                {


                    fleF010_ADD.OutPut(OutPutType.Add);
                   

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
            EndRequest("CREATE_F010_3");

        }

    }




    #endregion


}
//CREATE_F010_3



public class CREATE_DUMMY_RECORDS_CREATE_F020_4 : CREATE_DUMMY_RECORDS
{

    public CREATE_DUMMY_RECORDS_CREATE_F020_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "F020_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF020_ADD.InitializeItems += fleF020_ADD_InitializeItems;
        fleF020_ADD.InitializeItems += fleF020_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(CREATE_DUMMY_RECORDS_CREATE_F020_4)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020_ADD;

    private void fleF020_ADD_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF020_ADD.set_SetValue("DOC_NBR", true, "ZZZ");
            if (!Fixed)
                fleF020_ADD.set_SetValue("DOC_DATE_FAC_START", true, QDesign.SysDate(ref m_cnnQUERY));


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


    #region "Standard Generated Procedures(CREATE_DUMMY_RECORDS_CREATE_F020_4)"


    #region "Automatic Item Initialization(CREATE_DUMMY_RECORDS_CREATE_F020_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:48 PM

    //#-----------------------------------------
    //# fleF020_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------
    private void fleF020_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_ADD.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF020_ADD.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleF020_ADD.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_ADD.set_SetValue("DOC_SIN_123", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123"));
            fleF020_ADD.set_SetValue("DOC_SIN_456", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456"));
            fleF020_ADD.set_SetValue("DOC_SIN_789", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789"));
            fleF020_ADD.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleF020_ADD.set_SetValue("DOC_HOSP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_HOSP_NBR"));
            fleF020_ADD.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleF020_ADD.set_SetValue("DOC_NAME_SOUNDEX", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME_SOUNDEX"));
            fleF020_ADD.set_SetValue("DOC_INIT1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1"));
            fleF020_ADD.set_SetValue("DOC_INIT2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2"));
            fleF020_ADD.set_SetValue("DOC_INIT3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));
            fleF020_ADD.set_SetValue("DOC_ADDR_OFFICE_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_1"));
            fleF020_ADD.set_SetValue("DOC_ADDR_OFFICE_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_2"));
            fleF020_ADD.set_SetValue("DOC_ADDR_OFFICE_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_3"));
            fleF020_ADD.set_SetValue("DOC_ADDR_OFFICE_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1"));
            fleF020_ADD.set_SetValue("DOC_ADDR_OFFICE_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC2"));
            fleF020_ADD.set_SetValue("DOC_ADDR_OFFICE_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3"));
            fleF020_ADD.set_SetValue("DOC_ADDR_OFFICE_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC4"));
            fleF020_ADD.set_SetValue("DOC_ADDR_OFFICE_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5"));
            fleF020_ADD.set_SetValue("DOC_ADDR_OFFICE_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC6"));
            fleF020_ADD.set_SetValue("DOC_ADDR_HOME_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_1"));
            fleF020_ADD.set_SetValue("DOC_ADDR_HOME_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_2"));
            fleF020_ADD.set_SetValue("DOC_ADDR_HOME_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_3"));
            fleF020_ADD.set_SetValue("DOC_ADDR_HOME_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1"));
            fleF020_ADD.set_SetValue("DOC_ADDR_HOME_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC2"));
            fleF020_ADD.set_SetValue("DOC_ADDR_HOME_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3"));
            fleF020_ADD.set_SetValue("DOC_ADDR_HOME_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC4"));
            fleF020_ADD.set_SetValue("DOC_ADDR_HOME_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5"));
            fleF020_ADD.set_SetValue("DOC_ADDR_HOME_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC6"));
            fleF020_ADD.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleF020_ADD.set_SetValue("DOC_BANK_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_ADD.set_SetValue("DOC_BANK_BRANCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_ADD.set_SetValue("DOC_BANK_ACCT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
            fleF020_ADD.set_SetValue("DOC_DATE_FAC_START_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY"));
            fleF020_ADD.set_SetValue("DOC_DATE_FAC_START_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM"));
            fleF020_ADD.set_SetValue("DOC_DATE_FAC_START_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD"));
            fleF020_ADD.set_SetValue("DOC_DATE_FAC_TERM_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"));
            fleF020_ADD.set_SetValue("DOC_DATE_FAC_TERM_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"));
            fleF020_ADD.set_SetValue("DOC_DATE_FAC_TERM_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"));
            fleF020_ADD.set_SetValue("DOC_YTDGUA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
            fleF020_ADD.set_SetValue("DOC_YTDGUB", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
            fleF020_ADD.set_SetValue("DOC_YTDGUC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
            fleF020_ADD.set_SetValue("DOC_YTDGUD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
            fleF020_ADD.set_SetValue("DOC_YTDCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
            fleF020_ADD.set_SetValue("DOC_YTDCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
            fleF020_ADD.set_SetValue("DOC_YTDEAR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
            fleF020_ADD.set_SetValue("DOC_YTDINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
            fleF020_ADD.set_SetValue("DOC_YTDEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
            fleF020_ADD.set_SetValue("DOC_TOTINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_ADD.set_SetValue("DOC_EP_DATE_DEPOSIT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_ADD.set_SetValue("DOC_TOTINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
            fleF020_ADD.set_SetValue("DOC_EP_CEIEXP", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_ADD.set_SetValue("DOC_ADJCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
            fleF020_ADD.set_SetValue("DOC_ADJCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
            fleF020_ADD.set_SetValue("DOC_CEICEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
            fleF020_ADD.set_SetValue("DOC_CEICEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
            fleF020_ADD.set_SetValue("CEICEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_ADD.set_SetValue("CEICEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_ADD.set_SetValue("YTDCEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_ADD.set_SetValue("YTDCEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_ADD.set_SetValue("DOC_SPEC_CD_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"));
            fleF020_ADD.set_SetValue("DOC_SPEC_CD_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"));
            fleF020_ADD.set_SetValue("DOC_YTDINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_ADD.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_ADD.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF020_ADD.set_SetValue("DOC_DEPT_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_2"));
            fleF020_ADD.set_SetValue("DOC_IND_PAYS_GST", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST"));
            fleF020_ADD.set_SetValue("DOC_NX_AVAIL_BATCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH"));
            fleF020_ADD.set_SetValue("DOC_NX_AVAIL_BATCH_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2"));
            fleF020_ADD.set_SetValue("DOC_NX_AVAIL_BATCH_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3"));
            fleF020_ADD.set_SetValue("DOC_NX_AVAIL_BATCH_4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4"));
            fleF020_ADD.set_SetValue("DOC_NX_AVAIL_BATCH_5", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5"));
            fleF020_ADD.set_SetValue("DOC_NX_AVAIL_BATCH_6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6"));
            fleF020_ADD.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_ADD.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_ADD.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_ADD.set_SetValue("DOC_SUB_SPECIALTY", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY"));
            fleF020_ADD.set_SetValue("DOC_PAYEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
            fleF020_ADD.set_SetValue("DOC_YTDDED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
            fleF020_ADD.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF020_ADD.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_ADD.set_SetValue("DOC_EP_PED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED"));
            fleF020_ADD.set_SetValue("DOC_EP_PAY_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_ADD.set_SetValue("DOC_EP_PAY_SUB_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            fleF020_ADD.set_SetValue("DOC_PARTNERSHIP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_PARTNERSHIP"));
            fleF020_ADD.set_SetValue("DOC_IND_HOLDBACK_ACTIVE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE"));
            fleF020_ADD.set_SetValue("GROUP_REGULAR_SERVICE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE"));
            fleF020_ADD.set_SetValue("GROUP_OVER_SERVICED", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED"));
            fleF020_ADD.set_SetValue("DOC_LOC_1_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_1_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_1_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_2_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_2_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_2_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_3_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_3_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_3_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_4_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_4_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_4_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_5_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_5_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_5_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_6_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_6_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_6_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_7_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_7_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_7_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_8_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_8_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_8_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_9_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_9_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_9_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_10_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_10_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_10_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_11_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_11_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_11_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_12_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_12_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_12_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_13_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_13_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_13_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_14_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_14_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_14_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_15_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_15_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_15_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_16_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_16_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_16_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_17_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_17_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_17_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_18_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_18_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_18_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_19_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_19_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_19_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_20_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_20_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_20_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_21_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_21_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_21_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_22_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_22_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_22_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_23_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_23_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_23_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_24_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_24_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_24_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_25_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_25_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_25_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_26_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_26_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_26_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_27_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_27_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_27_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_28_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_28_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_28_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_29_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_29_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_29_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3"));
            fleF020_ADD.set_SetValue("DOC_LOC_30_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1"));
            fleF020_ADD.set_SetValue("DOC_LOC_30_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2"));
            fleF020_ADD.set_SetValue("DOC_LOC_30_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3"));

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


    #region "Transaction Management Procedures(CREATE_DUMMY_RECORDS_CREATE_F020_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

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
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(CREATE_DUMMY_RECORDS_CREATE_F020_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

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
            fleF020_DOCTOR_MSTR.Dispose();
            fleF020_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CREATE_DUMMY_RECORDS_CREATE_F020_4)"


    public void Run()
    {

        try
        {
            Request("CREATE_F020_4");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--


                if (Transaction())
                {


                    fleF020_ADD.OutPut(OutPutType.Add);
                   

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
            EndRequest("CREATE_F020_4");

        }

    }




    #endregion


}
//CREATE_F020_4




