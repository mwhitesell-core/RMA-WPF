
#region "Screen Comments"

// doc     : costing_f119hist
// purpose : report yearend TOTINC  (report name on share staff Total Revenue payroll yearend 2012.xls)
// :  put it in \\Rmaham-dc\share staff\Ross Reports\Yearend yyyy
// : (report name on share staff Total Revenue payroll yearend 2012.xls)
// who     : Leena     Ross   
// *************************************************************
// Date  Who  Description
// 2006/08/08 Yasemin         original
// 2010/07/22     Yasemin         take items afpin afpadj afpcon leave totinc
// 2013/07/11     Yasemin         add RMAEXR (percent charge) and RMAEXM     
// 2014/12/15     Yasemin         add start date  and change date to 2015 yearend
// 2016/04/13     Yasemin         add start date  and change date to 2015 yearend (ross wanted one run in March monthend)


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class COSTING_F119HIST : BaseClassControl
{

    private COSTING_F119HIST m_COSTING_F119HIST;

    public COSTING_F119HIST(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public COSTING_F119HIST(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_COSTING_F119HIST != null))
        {
            m_COSTING_F119HIST.CloseTransactionObjects();
            m_COSTING_F119HIST = null;
        }
    }

    public COSTING_F119HIST GetCOSTING_F119HIST(int Level)
    {
        if (m_COSTING_F119HIST == null)
        {
            m_COSTING_F119HIST = new COSTING_F119HIST("COSTING_F119HIST", Level);
        }
        else
        {
            m_COSTING_F119HIST.ResetValues();
        }
        return m_COSTING_F119HIST;
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

            COSTING_F119HIST_ONE_1 ONE_1 = new COSTING_F119HIST_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

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



public class COSTING_F119HIST_ONE_1 : COSTING_F119HIST
{

    public COSTING_F119HIST_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_TOTINC = new CoreDecimal("X_TOTINC", 9, this);
        X_RMACHR = new CoreDecimal("X_RMACHR", 9, this);
        X_RMAEXR = new CoreDecimal("X_RMAEXR", 9, this);
        X_RMAEXM = new CoreDecimal("X_RMAEXM", 9, this);
        fleCOSTINGF119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTINGF119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD_HISTORY.Choose += fleF119_DOCTOR_YTD_HISTORY_Choose;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        DOC_INITS.GetValue += DOC_INITS_GetValue;
        DOC_DATE_FAC_START.GetValue += DOC_DATE_FAC_START_GetValue;
        DOC_DATE_FAC_TERM.GetValue += DOC_DATE_FAC_TERM_GetValue;
    }


    #region "Declarations (Variables, Files and Transactions)(COSTING_F119HIST_ONE_1)"

    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020C_DOC_CLINIC_NEXT_BATCH_NBR;

    private void fleF119_DOCTOR_YTD_HISTORY_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("EP_NBR")).Append(" = ");
            strSQL.Append(Prompt(1).ToString());


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


    public override bool SelectIf()
    {


        try
        {
            if ((QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "TOTINC" | QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "RMACHR" | QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "RMAEXR" | QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "RMAEXM") & QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("EP_NBR")) == Decimal.Parse(Prompt(1).ToString()))
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

    private CoreDecimal X_TOTINC;
    private CoreDecimal X_RMACHR;
    private CoreDecimal X_RMAEXR;
    private CoreDecimal X_RMAEXM;
    private DCharacter COMMA = new DCharacter("COMMA", 1);
    private void COMMA_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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
    private DInteger X_NUM_CR = new DInteger("X_NUM_CR", 4);
    private void X_NUM_CR_GetValue(ref decimal Value)
    {

        try
        {
            Value = 13;


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
    private DCharacter X_CR = new DCharacter("X_CR", 2);
    private void X_CR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_CR.Value);


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

    private DCharacter DOC_INITS = new DCharacter("DOC_INITS", 3);
    private void DOC_INITS_GetValue(ref string Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3");


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


    private DDecimal DOC_DATE_FAC_START = new DDecimal("DOC_DATE_FAC_START", 8);
    private void DOC_DATE_FAC_START_GetValue(ref decimal Value)
    {
        try
        {
            Value = QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY")) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM")).PadLeft(2, '0') + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD")).PadLeft(2, '0'));
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

    private DDecimal DOC_DATE_FAC_TERM = new DDecimal("DOC_DATE_FAC_TERM", 8);
    private void DOC_DATE_FAC_TERM_GetValue(ref decimal Value)
    {
        try
        {
            Value = QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY")) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM")).PadLeft(2, '0') + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD")).PadLeft(2, '0'));
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

    private SqlFileObject fleCOSTINGF119;

    #endregion


    #region "Standard Generated Procedures(COSTING_F119HIST_ONE_1)"


    #region "Automatic Item Initialization(COSTING_F119HIST_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(COSTING_F119HIST_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:32:59 PM

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
        fleCOSTINGF119.Transaction = m_trnTRANS_UPDATE;
        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;

    }



    #endregion


    #region "FILE Management Procedures(COSTING_F119HIST_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:32:59 PM

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
            fleCOSTINGF119.Dispose();
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Dispose();

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING_F119HIST_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

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

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.QTPForMissing("2"))
                    {
                        // --> GET F020C_DOCT_CLINIC_NEXT_BATCH_NBR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                        m_strWhere.Append(" AND ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("SEQ_NO")).Append(" = ");
                        m_strWhere.Append(1);

                        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetData(m_strWhere.ToString());
                        // --> End GET F020C_DOCT_CLINIC_NEXT_BATCH_NBR <--

                        if (Transaction())
                        {

                            if (Select_If())
                            {

                                Sort(fleF119_DOCTOR_YTD_HISTORY.GetSortValue("DOC_NBR"));



                            }

                        }

                    }
                }
            }

            while (Sort(fleF119_DOCTOR_YTD_HISTORY, fleF020_DOCTOR_MSTR, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR))
            {

                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "TOTINC")
                {
                    X_TOTINC.Value = X_TOTINC.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD");
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "RMACHR")
                {
                    X_RMACHR.Value = X_RMACHR.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD");
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "RMAEXR")
                {
                    X_RMAEXR.Value = X_RMAEXR.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD");
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "RMAEXM")
                {
                    X_RMAEXM.Value = X_RMAEXM.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD");
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTINGF119, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"), SubFileType.Portable, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR, "DOC_CLINIC_NBR", COMMA, fleF020_DOCTOR_MSTR, "DOC_DEPT", fleF119_DOCTOR_YTD_HISTORY, "DOC_NBR",
                fleF020_DOCTOR_MSTR, "DOC_NAME", DOC_INITS, X_TOTINC, X_RMACHR, X_RMAEXR, X_RMAEXM, DOC_DATE_FAC_START, DOC_DATE_FAC_TERM);

                Reset(ref X_TOTINC, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref X_RMACHR, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref X_RMAEXR, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref X_RMAEXM, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));

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
            EndRequest("ONE_1");

        }

    }




    #endregion


}
//ONE_1




