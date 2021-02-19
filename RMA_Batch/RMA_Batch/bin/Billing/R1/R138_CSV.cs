
#region "Screen Comments"

// DOC: R138_CSV.QTS
// DOC: DEFICIT REPORT
// DOC: SORT BY COMPANY/DEPT
// DOC: RUN FOR: Ross  
// PROGRAM PURPOSE : DEFICIT REPORT FOR PAYROLL
// DATE           WHO       DESCRIPTION
// 2016/Mar/15 MC   ORIGINAL - this program will be run in $cmd/teb3; thus ep nbr has changed (+1)  
// clone from original r138_csv.qzs
// this will be the first pass program, second pass program is r138_csv.qzs
// Brad suggested to extract DEFIC from f110 file in one pass, 
// and then extract ADVOUT from f119 file in second pass;
// merge into one record per doctor in the third pass
// 2016/Jul/01    MC1       change amount fields from zoned*6  numeric to zoned*7 numeric


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class R138_CSV : BaseClassControl
{

    private R138_CSV m_R138_CSV;

    public R138_CSV(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public R138_CSV(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_R138_CSV != null))
        {
            m_R138_CSV.CloseTransactionObjects();
            m_R138_CSV = null;
        }
    }

    public R138_CSV GetR138_CSV(int Level)
    {
        if (m_R138_CSV == null)
        {
            m_R138_CSV = new R138_CSV("R138_CSV", Level);
        }
        else
        {
            m_R138_CSV.ResetValues();
        }
        return m_R138_CSV;
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

            R138_CSV_EXTRACT_F110_1 EXTRACT_F110_1 = new R138_CSV_EXTRACT_F110_1(Name, Level);
            EXTRACT_F110_1.Run();
            EXTRACT_F110_1.Dispose();
            EXTRACT_F110_1 = null;

            R138_CSV_EXTRACT_F119_2 EXTRACT_F119_2 = new R138_CSV_EXTRACT_F119_2(Name, Level);
            EXTRACT_F119_2.Run();
            EXTRACT_F119_2.Dispose();
            EXTRACT_F119_2 = null;

            R138_CSV_MERGE_BY_DOC_3 MERGE_BY_DOC_3 = new R138_CSV_MERGE_BY_DOC_3(Name, Level);
            MERGE_BY_DOC_3.Run();
            MERGE_BY_DOC_3.Dispose();
            MERGE_BY_DOC_3 = null;

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



public class R138_CSV_EXTRACT_F110_1 : R138_CSV
{

    public R138_CSV_EXTRACT_F110_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR138_CSV = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R138_CSV", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        X_DEFICIT_AMT.GetValue += X_DEFICIT_AMT_GetValue;
        X_ADVOUT_AMT.GetValue += X_ADVOUT_AMT_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF070_DEPT_MSTR.InitializeItems += fleF070_DEPT_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(R138_CSV_EXTRACT_F110_1)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF110_COMPENSATION;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF070_DEPT_MSTR;

    private void fleCONSTANTS_MSTR_REC_6_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
            strSQL.Append(6);


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
            if (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "DEFIC" & QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("AMT_NET")) != 0)
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

    private DDecimal X_DEFICIT_AMT = new DDecimal("X_DEFICIT_AMT", 7);
    private void X_DEFICIT_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF110_COMPENSATION.GetDecimalValue("AMT_NET");


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
    private DDecimal X_ADVOUT_AMT = new DDecimal("X_ADVOUT_AMT", 7);
    private void X_ADVOUT_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private SqlFileObject fleR138_CSV;


    #endregion


    #region "Standard Generated Procedures(R138_CSV_EXTRACT_F110_1)"


    #region "Automatic Item Initialization(R138_CSV_EXTRACT_F110_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:42 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:03:40 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));

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
    //# fleF070_DEPT_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:03:40 PM
    //#-----------------------------------------
    private void fleF070_DEPT_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF070_DEPT_MSTR.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(R138_CSV_EXTRACT_F110_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:40 PM

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
        fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF070_DEPT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleR138_CSV.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R138_CSV_EXTRACT_F110_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:40 PM

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
            fleF110_COMPENSATION.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF070_DEPT_MSTR.Dispose();
            fleR138_CSV.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R138_CSV_EXTRACT_F110_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_F110_1");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF110_COMPENSATION.QTPForMissing("1"))
                {
                    // --> GET F110_COMPENSATION <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF110_COMPENSATION.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    fleF110_COMPENSATION.GetData(m_strWhere.ToString());
                    // --> End GET F110_COMPENSATION <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF070_DEPT_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F070_DEPT_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ");
                            m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")));

                            fleF070_DEPT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F070_DEPT_MSTR <--

                            if (Transaction())
                            {

                                 if (Select_If())
                                {
                                    SubFile(ref m_trnTRANS_UPDATE, ref fleR138_CSV, SubFileType.Keep, fleF070_DEPT_MSTR, "DEPT_COMPANY", fleF020_DOCTOR_MSTR, "DOC_DEPT", fleF110_COMPENSATION, "DOC_NBR", fleF020_DOCTOR_MSTR,
                                    "DOC_NAME", fleF110_COMPENSATION, "EP_NBR", fleF020_DOCTOR_MSTR, "DOC_EP_PAY_CODE", "DOC_EP_PAY_SUB_CODE", X_DEFICIT_AMT, X_ADVOUT_AMT);


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
            EndRequest("EXTRACT_F110_1");

        }

    }







    #endregion


}
//EXTRACT_F110_1



public class R138_CSV_EXTRACT_F119_2 : R138_CSV
{

    public R138_CSV_EXTRACT_F119_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR138_CSV = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R138_CSV", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD.Choose += fleF119_DOCTOR_YTD_Choose;
        X_DEFICIT_AMT.GetValue += X_DEFICIT_AMT_GetValue;
        X_ADVOUT_AMT.GetValue += X_ADVOUT_AMT_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF070_DEPT_MSTR.InitializeItems += fleF070_DEPT_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(R138_CSV_EXTRACT_F119_2)"

    private SqlFileObject fleF119_DOCTOR_YTD;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF070_DEPT_MSTR;

    private void fleF119_DOCTOR_YTD_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF119_DOCTOR_YTD.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("ADVOUT"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF119_DOCTOR_YTD.ElementOwner("REC_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("A"));


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
            if (QDesign.NULL(fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD")) != 0)
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

    private DDecimal X_DEFICIT_AMT = new DDecimal("X_DEFICIT_AMT", 7);
    private void X_DEFICIT_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal X_ADVOUT_AMT = new DDecimal("X_ADVOUT_AMT", 7);
    private void X_ADVOUT_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");


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
    private SqlFileObject fleR138_CSV;


    #endregion


    #region "Standard Generated Procedures(R138_CSV_EXTRACT_F119_2)"


    #region "Automatic Item Initialization(R138_CSV_EXTRACT_F119_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:45 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:03:42 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("DOC_OHIP_NBR"));

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
    //# fleF070_DEPT_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:03:42 PM
    //#-----------------------------------------
    private void fleF070_DEPT_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF070_DEPT_MSTR.set_SetValue("FILLER", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(R138_CSV_EXTRACT_F119_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:40 PM

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
        fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF070_DEPT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleR138_CSV.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R138_CSV_EXTRACT_F119_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:40 PM

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
            fleF119_DOCTOR_YTD.Dispose();
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF070_DEPT_MSTR.Dispose();
            fleR138_CSV.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R138_CSV_EXTRACT_F119_2)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_F119_2");

            while (fleF119_DOCTOR_YTD.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD <--

                fleF119_DOCTOR_YTD.GetData();
                // --> End GET F119_DOCTOR_YTD <--

                while (fleCONSTANTS_MSTR_REC_6.QTPForMissing("1"))
                {
                    // --> GET CONSTANTS_MSTR_REC_6 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                    m_strWhere.Append((6));

                    fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString());
                    // --> End GET CONSTANTS_MSTR_REC_6 <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF070_DEPT_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F070_DEPT_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ");
                            m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")));

                            fleF070_DEPT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F070_DEPT_MSTR <--

                            if (Transaction())
                            {

                                 if (Select_If())
                                {
                                    SubFile(ref m_trnTRANS_UPDATE, ref fleR138_CSV, SubFileType.Keep, fleF070_DEPT_MSTR, "DEPT_COMPANY", fleF020_DOCTOR_MSTR, "DOC_DEPT", fleF119_DOCTOR_YTD, "DOC_NBR", fleF020_DOCTOR_MSTR,
                                    "DOC_NAME", fleCONSTANTS_MSTR_REC_6, "CURRENT_EP_NBR", fleF020_DOCTOR_MSTR, "DOC_EP_PAY_CODE", "DOC_EP_PAY_SUB_CODE", X_DEFICIT_AMT, X_ADVOUT_AMT);


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
            EndRequest("EXTRACT_F119_2");

        }

    }







    #endregion


}
//EXTRACT_F119_2



public class R138_CSV_MERGE_BY_DOC_3 : R138_CSV
{

    public R138_CSV_MERGE_BY_DOC_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR138_CSV = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R138_CSV", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        DEFICIT_AMT = new CoreDecimal("DEFICIT_AMT", 7, this);
        ADVOUT_AMT = new CoreDecimal("ADVOUT_AMT", 7, this);
        fleR138_CSV_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R138_CSV_DOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(R138_CSV_MERGE_BY_DOC_3)"

    private SqlFileObject fleR138_CSV;
    private CoreDecimal DEFICIT_AMT;
    private CoreDecimal ADVOUT_AMT;
    private SqlFileObject fleR138_CSV_DOC;


    #endregion


    #region "Standard Generated Procedures(R138_CSV_MERGE_BY_DOC_3)"


    #region "Automatic Item Initialization(R138_CSV_MERGE_BY_DOC_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R138_CSV_MERGE_BY_DOC_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:40 PM

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
        fleR138_CSV.Transaction = m_trnTRANS_UPDATE;
        fleR138_CSV_DOC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R138_CSV_MERGE_BY_DOC_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:40 PM

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
            fleR138_CSV.Dispose();
            fleR138_CSV_DOC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R138_CSV_MERGE_BY_DOC_3)"


    public void Run()
    {

        try
        {
            Request("MERGE_BY_DOC_3");

            while (fleR138_CSV.QTPForMissing())
            {
                // --> GET R138_CSV <--

                fleR138_CSV.GetData();
                // --> End GET R138_CSV <--


                if (Transaction())
                {

                    Sort(fleR138_CSV.GetSortValue("DOC_NBR"));



                }

            }

            while (Sort(fleR138_CSV))
            {
                DEFICIT_AMT.Value = DEFICIT_AMT.Value + fleR138_CSV.GetDecimalValue("X_DEFICIT_AMT");
                ADVOUT_AMT.Value = ADVOUT_AMT.Value + fleR138_CSV.GetDecimalValue("X_ADVOUT_AMT");

                SubFile(ref m_trnTRANS_UPDATE, ref fleR138_CSV_DOC, fleR138_CSV.At("DOC_NBR"), SubFileType.Keep, fleR138_CSV, "DEPT_COMPANY", "DOC_DEPT", "DOC_NBR", "DOC_NAME", "EP_NBR",
                "DOC_EP_PAY_CODE", "DOC_EP_PAY_SUB_CODE", DEFICIT_AMT, ADVOUT_AMT);


                Reset(ref DEFICIT_AMT, fleR138_CSV.At("DOC_NBR"));
                Reset(ref ADVOUT_AMT, fleR138_CSV.At("DOC_NBR"));

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
            EndRequest("MERGE_BY_DOC_3");

        }

    }







    #endregion


}
//MERGE_BY_DOC_3




