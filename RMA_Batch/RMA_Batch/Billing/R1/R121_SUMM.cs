
#region "Screen Comments"

// PROGRAM:  R121_SUMM.QTS
// EXTRACT FROM F119 AND F119HIST FOR THE SELECTED CALENDAR YEAR
// DATE      WHO       MODIFICATION
// 2015/Jan/15   MC1   original (clone from r121a.qzs)


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class R121_SUMM : BaseClassControl
{

    private R121_SUMM m_R121_SUMM;

    public R121_SUMM(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public R121_SUMM(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_R121_SUMM != null))
        {
            m_R121_SUMM.CloseTransactionObjects();
            m_R121_SUMM = null;
        }
    }

    public R121_SUMM GetR121_SUMM(int Level)
    {
        if (m_R121_SUMM == null)
        {
            m_R121_SUMM = new R121_SUMM("R121_SUMM", Level);
        }
        else
        {
            m_R121_SUMM.ResetValues();
        }
        return m_R121_SUMM;
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

            R121_SUMM_EXTRACT_F119_HIST_1 EXTRACT_F119_HIST_1 = new R121_SUMM_EXTRACT_F119_HIST_1(Name, Level);
            EXTRACT_F119_HIST_1.Run();
            EXTRACT_F119_HIST_1.Dispose();
            EXTRACT_F119_HIST_1 = null;

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



public class R121_SUMM_EXTRACT_F119_HIST_1 : R121_SUMM
{

    public R121_SUMM_EXTRACT_F119_HIST_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
         fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR121_SUMM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R121_SUMM", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD_HISTORY.Choose += fleF119_DOCTOR_YTD_HISTORY_Choose;
        CALENDAR_YEAR.GetValue += CALENDAR_YEAR_GetValue;
        PREV_DEC_EP_NBR.GetValue += PREV_DEC_EP_NBR_GetValue;
        YTD_AMT.GetValue += YTD_AMT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(R121_SUMM_EXTRACT_F119_HIST_1)"

    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF070_DEPT_MSTR;

    private void fleF119_DOCTOR_YTD_HISTORY_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");
            
            strSQL.Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("EP_NBR"));
            strSQL.Append(" IN(");
            strSQL.Append(Prompt(1).ToString() + ",");
            strSQL.Append(Prompt(2).ToString() + ",");
            strSQL.Append(Prompt(3).ToString());
            strSQL.Append(")");
            

            strSQL.Append(" AND ");
            strSQL.Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("REC_TYPE")).Append(" = ");
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

    private DDecimal CALENDAR_YEAR = new DDecimal("CALENDAR_YEAR", 4);
    private void CALENDAR_YEAR_GetValue(ref decimal Value)
    {

        try
        {
            Value = (Convert.ToDecimal(Prompt(4)));


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
    private DDecimal PREV_DEC_EP_NBR = new DDecimal("PREV_DEC_EP_NBR", 6);
    private void PREV_DEC_EP_NBR_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.ASCII(CALENDAR_YEAR.Value - 1) + "06");


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
    private DDecimal YTD_AMT = new DDecimal("YTD_AMT", 10);
    private void YTD_AMT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("EP_NBR")) == QDesign.NULL(PREV_DEC_EP_NBR.Value))
            {
                CurrentValue = fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") * -1;
            }
            else
            {
                CurrentValue = fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD");
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
    private SqlFileObject fleR121_SUMM;


    #endregion


    #region "Standard Generated Procedures(R121_SUMM_EXTRACT_F119_HIST_1)"


    #region "Automatic Item Initialization(R121_SUMM_EXTRACT_F119_HIST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R121_SUMM_EXTRACT_F119_HIST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:55 PM

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
        fleF119_DOCTOR_YTD_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF070_DEPT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleR121_SUMM.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R121_SUMM_EXTRACT_F119_HIST_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:55 PM

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
            fleF119_DOCTOR_YTD_HISTORY.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF070_DEPT_MSTR.Dispose();
            fleR121_SUMM.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R121_SUMM_EXTRACT_F119_HIST_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_F119_HIST_1");

            while (fleF119_DOCTOR_YTD_HISTORY.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD_HISTORY <--

                fleF119_DOCTOR_YTD_HISTORY.GetData();
                // --> End GET F119_DOCTOR_YTD_HISTORY <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF190_COMP_CODES.QTPForMissing("2"))
                    {
                        // --> GET F190_COMP_CODES <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")));

                        fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F190_COMP_CODES <--

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
                                SubFile(ref m_trnTRANS_UPDATE, ref fleR121_SUMM, SubFileType.Keep, fleF119_DOCTOR_YTD_HISTORY, "EP_NBR", "DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_DEPT", "DOC_NAME", "DOC_FULL_PART_IND",
                                fleF070_DEPT_MSTR, "DEPT_COMPANY", "DEPT_NAME", fleF190_COMP_CODES, "COMP_TYPE", fleF119_DOCTOR_YTD_HISTORY, "COMP_CODE", "COMP_CODE_GROUP", fleF190_COMP_CODES, "REPORTING_SEQ",
                                "DESC_SHORT", YTD_AMT, CALENDAR_YEAR);


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
            EndRequest("EXTRACT_F119_HIST_1");

        }

    }







    #endregion


}
//EXTRACT_F119_HIST_1




