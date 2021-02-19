
#region "Screen Comments"

// report revenue by doc by location billings only no Misc rev  - doc dept, doc#, Name, total revenue by location
// To: Lisa Greer and Annette 


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class F050HIST_LOCATION_DEPT4 : BaseClassControl
{

    private F050HIST_LOCATION_DEPT4 m_F050HIST_LOCATION_DEPT4;

    public F050HIST_LOCATION_DEPT4(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF030_LOCATIONS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F030_LOCATIONS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_AMT = new CoreDecimal("X_AMT", 9, this);
        fleDEPT4LOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT4LOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF050_DOC_REVENUE_MSTR_HISTORY.Choose += fleF050_DOC_REVENUE_MSTR_HISTORY_Choose;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }

    public F050HIST_LOCATION_DEPT4(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF030_LOCATIONS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F030_LOCATIONS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_AMT = new CoreDecimal("X_AMT", 9, this);
        fleDEPT4LOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEPT4LOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF050_DOC_REVENUE_MSTR_HISTORY.Choose += fleF050_DOC_REVENUE_MSTR_HISTORY_Choose;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }

    public override void Dispose()
    {
        if ((m_F050HIST_LOCATION_DEPT4 != null))
        {
            m_F050HIST_LOCATION_DEPT4.CloseTransactionObjects();
            m_F050HIST_LOCATION_DEPT4 = null;
        }
    }

    public F050HIST_LOCATION_DEPT4 GetF050HIST_LOCATION_DEPT4(int Level)
    {
        if (m_F050HIST_LOCATION_DEPT4 == null)
        {
            m_F050HIST_LOCATION_DEPT4 = new F050HIST_LOCATION_DEPT4("F050HIST_LOCATION_DEPT4", Level);
        }
        else
        {
            m_F050HIST_LOCATION_DEPT4.ResetValues();
        }
        return m_F050HIST_LOCATION_DEPT4;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleF050_DOC_REVENUE_MSTR_HISTORY;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF030_LOCATIONS_MSTR;

    private void fleF050_DOC_REVENUE_MSTR_HISTORY_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF050_DOC_REVENUE_MSTR_HISTORY.ElementOwner("EP_YR")).Append(" = ");
            strSQL.Append(2015);


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
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")) == "34" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_DEPT")) == 4 & (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MOHD" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "AGEP" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MICM" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MISJ" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MISP" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MICB" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MIBR" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MHSC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "DHSC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MICA" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MICC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MICE" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MICH"))
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

    private CoreDecimal X_AMT;
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
    private SqlFileObject fleDEPT4LOC;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("F050HIST_LOCATION_DEPT4");

            while (fleF050_DOC_REVENUE_MSTR_HISTORY.QTPForMissing())
            {
                // --> GET F050_DOC_REVENUE_MSTR_HISTORY <--

                fleF050_DOC_REVENUE_MSTR_HISTORY.GetData();
                // --> End GET F050_DOC_REVENUE_MSTR_HISTORY <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF030_LOCATIONS_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F030_LOCATIONS_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF030_LOCATIONS_MSTR.ElementOwner("LOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION")));

                        fleF030_LOCATIONS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F030_LOCATIONS_MSTR <--

                        if (Transaction())
                        {

                             if (Select_If())
                            {

                                Sort(fleF050_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREV_DOC_NBR"), fleF050_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREV_LOCATION"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleF050_DOC_REVENUE_MSTR_HISTORY, fleF020_DOCTOR_MSTR, fleF030_LOCATIONS_MSTR))
            {
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetNumericDateValue("ICONST_DATE_PERIOD_END")) == 20160630)
                {
                    X_AMT.Value = X_AMT.Value + (fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_IN_REC") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_OUT_REC"));
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleDEPT4LOC, fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_DOC_NBR") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_LOCATION"), SubFileType.Portable, fleF050_DOC_REVENUE_MSTR_HISTORY, "DOCREV_CLINIC_1_2", COMMA, fleF020_DOCTOR_MSTR, "DOC_DEPT", fleF050_DOC_REVENUE_MSTR_HISTORY,
                "DOCREV_DOC_NBR", fleF030_LOCATIONS_MSTR, "LOC_NBR", fleF020_DOCTOR_MSTR, "DOC_NAME", fleF050_DOC_REVENUE_MSTR_HISTORY, "DOCREV_LOCATION", fleF030_LOCATIONS_MSTR, "LOC_NAME", X_AMT,
                X_CR);


                Reset(ref X_AMT, fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_DOC_NBR") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_LOCATION"));

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
            EndRequest("F050HIST_LOCATION_DEPT4");

        }

    }


    #region "Standard Generated Procedures(F050HIST_LOCATION_DEPT4_F050HIST_LOCATION_DEPT4)"

    #region "Transaction Management Procedures(F050HIST_LOCATION_DEPT4_F050HIST_LOCATION_DEPT4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:56 PM

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
        fleF050_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF030_LOCATIONS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDEPT4LOC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(F050HIST_LOCATION_DEPT4_F050HIST_LOCATION_DEPT4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:56 PM

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
            fleF050_DOC_REVENUE_MSTR_HISTORY.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF030_LOCATIONS_MSTR.Dispose();
            fleDEPT4LOC.Dispose();


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

