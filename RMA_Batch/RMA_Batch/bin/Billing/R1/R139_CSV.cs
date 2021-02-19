
#region "Screen Comments"

// DOC: R139_CSV.QTS
// DOC: INCEXP minus TOTDED <> PAYEFT for pay code 2 only
// DOC: SORT BY COMPANY/DEPT
// DOC: RUN FOR: Ross  
// PROGRAM PURPOSE : The difference between ( (Total Revenue - Total Expense ) - Total Deduction)
// and PAYEFT Amount  for pay code 2 doctors 
// DATE           WHO       DESCRIPTION
// 2015/Aug/12 MC   ORIGINAL - this program will be run in $cmd/teb3; thus ep nbr has changed (+1)  
// this is the first pass of the program, second pass is r139_csv.qzs
// 2016/Mar/14 MC1   Brad suggested to include pay code 0 as well, show terminated date


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class R139_CSV : BaseClassControl
{

    private R139_CSV m_R139_CSV;

    public R139_CSV(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        AMT_ADVOUT = new CoreDecimal("AMT_ADVOUT", 8, this);
        AMT_INCEXP = new CoreDecimal("AMT_INCEXP", 8, this);
        AMT_TOTDED = new CoreDecimal("AMT_TOTDED", 8, this);
        AMT_PAYEFT = new CoreDecimal("AMT_PAYEFT", 8, this);
        AMT_PAYPOT = new CoreDecimal("AMT_PAYPOT", 8, this);
        fleR139_CSV = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R139_CSV", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD.Choose += fleF119_DOCTOR_YTD_Choose;

    }

    public R139_CSV(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        AMT_ADVOUT = new CoreDecimal("AMT_ADVOUT", 8, this);
        AMT_INCEXP = new CoreDecimal("AMT_INCEXP", 8, this);
        AMT_TOTDED = new CoreDecimal("AMT_TOTDED", 8, this);
        AMT_PAYEFT = new CoreDecimal("AMT_PAYEFT", 8, this);
        AMT_PAYPOT = new CoreDecimal("AMT_PAYPOT", 8, this);
        fleR139_CSV = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R139_CSV", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD.Choose += fleF119_DOCTOR_YTD_Choose;

    }

    public override void Dispose()
    {
        if ((m_R139_CSV != null))
        {
            m_R139_CSV.CloseTransactionObjects();
            m_R139_CSV = null;
        }
    }

    public R139_CSV GetR139_CSV(int Level)
    {
        if (m_R139_CSV == null)
        {
            m_R139_CSV = new R139_CSV("R139_CSV", Level);
        }
        else
        {
            m_R139_CSV.ResetValues();
        }
        return m_R139_CSV;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleF119_DOCTOR_YTD;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF112_PYCDCEILINGS;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF070_DEPT_MSTR;

    private void fleF119_DOCTOR_YTD_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF119_DOCTOR_YTD.ElementOwner("COMP_CODE")).Append(" IN ");
            strSQL.Append("(").Append(Common.StringToField("ADVOUT")).Append(",");
            strSQL.Append(Common.StringToField("INCEXP")).Append(",");
            strSQL.Append(Common.StringToField("TOTDED")).Append(",");
            strSQL.Append(Common.StringToField("PAYEFT")).Append(",");
            strSQL.Append(Common.StringToField("PAYPOT")).Append(")");


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
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE")) == "2" | QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE")) == "0")
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

    private CoreDecimal AMT_ADVOUT;
    private CoreDecimal AMT_INCEXP;
    private CoreDecimal AMT_TOTDED;
    private CoreDecimal AMT_PAYEFT;

    private CoreDecimal AMT_PAYPOT;
    private SqlFileObject fleR139_CSV;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("R139_CSV");

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

                    while (fleF112_PYCDCEILINGS.QTPForMissing("2"))
                    {
                        // --> GET F112_PYCDCEILINGS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                        m_strWhere.Append(((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1)));
                        m_strWhere.Append(" And ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")));

                        fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F112_PYCDCEILINGS <--

                        while (fleF020_DOCTOR_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F020_DOCTOR_MSTR <--

                            while (fleF070_DEPT_MSTR.QTPForMissing("4"))
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

                                        Sort(fleF119_DOCTOR_YTD.GetSortValue("DOC_NBR"));



                                    }

                                }

                            }

                        }

                    }

                }

            }

            while (Sort(fleF119_DOCTOR_YTD, fleCONSTANTS_MSTR_REC_6, fleF112_PYCDCEILINGS, fleF020_DOCTOR_MSTR, fleF070_DEPT_MSTR))
            {
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "ADVOUT")
                {
                    AMT_ADVOUT.Value = AMT_ADVOUT.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "INCEXP")
                {
                    AMT_INCEXP.Value = AMT_INCEXP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TOTDED")
                {
                    AMT_TOTDED.Value = AMT_TOTDED.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PAYEFT")
                {
                    AMT_PAYEFT.Value = AMT_PAYEFT.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PAYPOT")
                {
                    AMT_PAYPOT.Value = AMT_PAYPOT.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                }


                SubFile(ref m_trnTRANS_UPDATE, ref fleR139_CSV, fleF119_DOCTOR_YTD.At("DOC_NBR"), SubFileType.Keep, fleF070_DEPT_MSTR, "DEPT_COMPANY", fleF020_DOCTOR_MSTR, "DOC_DEPT", fleF119_DOCTOR_YTD, "DOC_NBR",
                fleF020_DOCTOR_MSTR, "DOC_NAME", "DOC_EP_PAY_CODE", "DOC_DATE_FAC_TERM", fleF112_PYCDCEILINGS, "EP_NBR", AMT_INCEXP, AMT_TOTDED, AMT_PAYPOT, AMT_PAYEFT,
                AMT_ADVOUT);



                Reset(ref AMT_ADVOUT, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref AMT_INCEXP, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref AMT_TOTDED, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref AMT_PAYEFT, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref AMT_PAYPOT, fleF119_DOCTOR_YTD.At("DOC_NBR"));

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
            EndRequest("R139_CSV");

        }

    }


    #region "Standard Generated Procedures(R139_CSV_R139_CSV)"

    #region "Transaction Management Procedures(R139_CSV_R139_CSV)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:39 PM

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
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF070_DEPT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleR139_CSV.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R139_CSV_R139_CSV)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:39 PM

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
            fleF112_PYCDCEILINGS.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF070_DEPT_MSTR.Dispose();
            fleR139_CSV.Dispose();


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


    public override bool RunQTP()
    {


        try
        {

            Run();

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

