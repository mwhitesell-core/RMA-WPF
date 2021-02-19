
#region "Screen Comments"

// doc     : drkolesar_yr.qts
// purpose : report minimum/maximum/average amount for weekday-day, weekday-after-hour, weekend-day, weekend-after-hours
// weekday-day   = claims with NO E400C or E401C  
// weekday-after-hours  = claims with E400C or E401C  
// weekend-day   = claims with E400C  
// weekend-after-hours  = claims with E401C  
// who     : Dr. Kolesar  - Chief of Anesthesia at HHS
// 2013/Jun/25  MC - original
// - choose clinic 22, 23, 25, 32, 42, 98
// - select location M461 and department 2/13/21/26 and department 14 with specialty 01 only
// and serv date >= 20110701
// - exclude adjustment (clmdtl-adj-nbr = 1) when calculating min/max/avg - separate pass
// 2013/Jul/08   MC - they only want ohip billings no bill direct; hence exclude clinic 98 
// since this clinic should only contain agent 6
// - add selection in first request for agent <> 6 for other clinics
// *************************************************************
// 2013/Jul/23   MC - instead of using clmdtl-sv-date to determine weekday or weekend, use clmhdr-serv-date
// for the claim, do not require to explode the consecutive date
// write record at claim nbr level
// NOTE: Extend the year if needed - now work for 5 years, modify serv-yr define statement in request two below
// 2013/Jul/30   MC     - Yasemin requested to exclude selected doctors because they can`t get a consent from them
// Dr. Forero    ohip# 24614  doc#V63
// Dr. Hakim     ohip# 28527  doc# 37B and 72C
// Dr. Thomas    ohip# 26538  doc# 622, 52A and 318
// - modify two select statements for doctor exclusion in request summarize_claims_yr & create_records


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class DRKOLESAR_YR : BaseClassControl
{

    private DRKOLESAR_YR m_DRKOLESAR_YR;

    public DRKOLESAR_YR(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public DRKOLESAR_YR(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_DRKOLESAR_YR != null))
        {
            m_DRKOLESAR_YR.CloseTransactionObjects();
            m_DRKOLESAR_YR = null;
        }
    }

    public DRKOLESAR_YR GetDRKOLESAR_YR(int Level)
    {
        if (m_DRKOLESAR_YR == null)
        {
            m_DRKOLESAR_YR = new DRKOLESAR_YR("DRKOLESAR_YR", Level);
        }
        else
        {
            m_DRKOLESAR_YR.ResetValues();
        }
        return m_DRKOLESAR_YR;
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

            DRKOLESAR_YR_SUMMARIZE_CLAIMS_YR_1 SUMMARIZE_CLAIMS_YR_1 = new DRKOLESAR_YR_SUMMARIZE_CLAIMS_YR_1(Name, Level);
            SUMMARIZE_CLAIMS_YR_1.Run();
            SUMMARIZE_CLAIMS_YR_1.Dispose();
            SUMMARIZE_CLAIMS_YR_1 = null;

            DRKOLESAR_YR_CREATE_RECORDS_2 CREATE_RECORDS_2 = new DRKOLESAR_YR_CREATE_RECORDS_2(Name, Level);
            CREATE_RECORDS_2.Run();
            CREATE_RECORDS_2.Dispose();
            CREATE_RECORDS_2 = null;

            DRKOLESAR_YR_UPDATE_COUNT_3 UPDATE_COUNT_3 = new DRKOLESAR_YR_UPDATE_COUNT_3(Name, Level);
            UPDATE_COUNT_3.Run();
            UPDATE_COUNT_3.Dispose();
            UPDATE_COUNT_3 = null;

            DRKOLESAR_YR_SORT_AMT_4 SORT_AMT_4 = new DRKOLESAR_YR_SORT_AMT_4(Name, Level);
            SORT_AMT_4.Run();
            SORT_AMT_4.Dispose();
            SORT_AMT_4 = null;

            DRKOLESAR_YR_CALC_MEDIAN_5 CALC_MEDIAN_5 = new DRKOLESAR_YR_CALC_MEDIAN_5(Name, Level);
            CALC_MEDIAN_5.Run();
            CALC_MEDIAN_5.Dispose();
            CALC_MEDIAN_5 = null;

            DRKOLESAR_YR_FIND_MEDIAN1_6 FIND_MEDIAN1_6 = new DRKOLESAR_YR_FIND_MEDIAN1_6(Name, Level);
            FIND_MEDIAN1_6.Run();
            FIND_MEDIAN1_6.Dispose();
            FIND_MEDIAN1_6 = null;

            DRKOLESAR_YR_SUM_AVG_MEDIAN_7 SUM_AVG_MEDIAN_7 = new DRKOLESAR_YR_SUM_AVG_MEDIAN_7(Name, Level);
            SUM_AVG_MEDIAN_7.Run();
            SUM_AVG_MEDIAN_7.Dispose();
            SUM_AVG_MEDIAN_7 = null;

            DRKOLESAR_YR_YEAR_ALL_8 YEAR_ALL_8 = new DRKOLESAR_YR_YEAR_ALL_8(Name, Level);
            YEAR_ALL_8.Run();
            YEAR_ALL_8.Dispose();
            YEAR_ALL_8 = null;

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



public class DRKOLESAR_YR_SUMMARIZE_CLAIMS_YR_1 : DRKOLESAR_YR
{

    public DRKOLESAR_YR_SUMMARIZE_CLAIMS_YR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleKOLESAR_CLM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "KOLESAR_CLM", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        WEEKDAY_DAY = new CoreDecimal("WEEKDAY_DAY", 10, this);
        WEEKDAY_DAY_MIN = new CoreDecimal("WEEKDAY_DAY_MIN", 7, this);
        WEEKDAY_DAY_MAX = new CoreDecimal("WEEKDAY_DAY_MAX", 7, this);
        WEEKDAY_DAY_AVERAGE = new CoreDecimal("WEEKDAY_DAY_AVERAGE", 7, this);
        WEEKDAY_AFTER_HOUR = new CoreDecimal("WEEKDAY_AFTER_HOUR", 10, this);
        WEEKDAY_AFTER_HOUR_MIN = new CoreDecimal("WEEKDAY_AFTER_HOUR_MIN", 7, this);
        WEEKDAY_AFTER_HOUR_MAX = new CoreDecimal("WEEKDAY_AFTER_HOUR_MAX", 7, this);
        WEEKDAY_AFTER_HOUR_AVERAGE = new CoreDecimal("WEEKDAY_AFTER_HOUR_AVERAGE", 7, this);
        WEEKEND_DAY = new CoreDecimal("WEEKEND_DAY", 10, this);
        WEEKEND_DAY_MIN = new CoreDecimal("WEEKEND_DAY_MIN", 7, this);
        WEEKEND_DAY_MAX = new CoreDecimal("WEEKEND_DAY_MAX", 7, this);
        WEEKEND_DAY_AVERAGE = new CoreDecimal("WEEKEND_DAY_AVERAGE", 7, this);
        WEEKEND_AFTER_HOUR = new CoreDecimal("WEEKEND_AFTER_HOUR", 10, this);
        WEEKEND_AFTER_HOUR_MIN = new CoreDecimal("WEEKEND_AFTER_HOUR_MIN", 7, this);
        WEEKEND_AFTER_HOUR_MAX = new CoreDecimal("WEEKEND_AFTER_HOUR_MAX", 7, this);
        WEEKEND_AFTER_HOUR_AVERAGE = new CoreDecimal("WEEKEND_AFTER_HOUR_AVERAGE", 7, this);
        fleKOLESAR_YR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "KOLESAR_YR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_DOC_NBR.GetValue += X_DOC_NBR_GetValue;
        WEEKDAY_DAY_MINIMUM.GetValue += WEEKDAY_DAY_MINIMUM_GetValue;
        WEEKDAY_DAY_MAXIMUM.GetValue += WEEKDAY_DAY_MAXIMUM_GetValue;
        WEEKDAY_AFTER_HOUR_MINIMUM.GetValue += WEEKDAY_AFTER_HOUR_MINIMUM_GetValue;
        WEEKDAY_AFTER_HOUR_MAXIMUM.GetValue += WEEKDAY_AFTER_HOUR_MAXIMUM_GetValue;
        WEEKEND_DAY_MINIMUM.GetValue += WEEKEND_DAY_MINIMUM_GetValue;
        WEEKEND_DAY_MAXIMUM.GetValue += WEEKEND_DAY_MAXIMUM_GetValue;
        WEEKEND_AFTER_HOUR_MINIMUM.GetValue += WEEKEND_AFTER_HOUR_MINIMUM_GetValue;
        WEEKEND_AFTER_HOUR_MAXIMUM.GetValue += WEEKEND_AFTER_HOUR_MAXIMUM_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(DRKOLESAR_YR_SUMMARIZE_CLAIMS_YR_1)"

    private SqlFileObject fleKOLESAR_CLM;
    private DCharacter X_DOC_NBR = new DCharacter("X_DOC_NBR", 3);
    private void X_DOC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleKOLESAR_CLM.GetStringValue("KEY_CLM_BATCH_NBR"), 3, 3);


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
            if (QDesign.NULL(X_DOC_NBR.Value) != "V63" & QDesign.NULL(X_DOC_NBR.Value) != "026" & QDesign.NULL(X_DOC_NBR.Value) != "T66" & QDesign.NULL(X_DOC_NBR.Value) != "V56" & QDesign.NULL(X_DOC_NBR.Value) != "37B" & QDesign.NULL(X_DOC_NBR.Value) != "72C" & QDesign.NULL(X_DOC_NBR.Value) != "F56" & QDesign.NULL(X_DOC_NBR.Value) != "F55" & QDesign.NULL(X_DOC_NBR.Value) != "622" & QDesign.NULL(X_DOC_NBR.Value) != "52A" & QDesign.NULL(X_DOC_NBR.Value) != "318")
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

    private CoreDecimal WEEKDAY_DAY;
    private CoreDecimal WEEKDAY_DAY_MIN;
    private CoreDecimal WEEKDAY_DAY_MAX;
    private CoreDecimal WEEKDAY_DAY_AVERAGE;
    private CoreDecimal WEEKDAY_AFTER_HOUR;
    private CoreDecimal WEEKDAY_AFTER_HOUR_MIN;
    private CoreDecimal WEEKDAY_AFTER_HOUR_MAX;
    private CoreDecimal WEEKDAY_AFTER_HOUR_AVERAGE;
    private CoreDecimal WEEKEND_DAY;
    private CoreDecimal WEEKEND_DAY_MIN;
    private CoreDecimal WEEKEND_DAY_MAX;
    private CoreDecimal WEEKEND_DAY_AVERAGE;
    private CoreDecimal WEEKEND_AFTER_HOUR;
    private CoreDecimal WEEKEND_AFTER_HOUR_MIN;
    private CoreDecimal WEEKEND_AFTER_HOUR_MAX;
    private CoreDecimal WEEKEND_AFTER_HOUR_AVERAGE;
    private DDecimal WEEKDAY_DAY_MINIMUM = new DDecimal("WEEKDAY_DAY_MINIMUM", 7);
    private void WEEKDAY_DAY_MINIMUM_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(WEEKDAY_DAY.Value) != 0)
            {
                CurrentValue = WEEKDAY_DAY_MIN.Value;
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
    private DDecimal WEEKDAY_DAY_MAXIMUM = new DDecimal("WEEKDAY_DAY_MAXIMUM", 7);
    private void WEEKDAY_DAY_MAXIMUM_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(WEEKDAY_DAY.Value) != 0)
            {
                CurrentValue = WEEKDAY_DAY_MAX.Value;
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
    private DDecimal WEEKDAY_AFTER_HOUR_MINIMUM = new DDecimal("WEEKDAY_AFTER_HOUR_MINIMUM", 7);
    private void WEEKDAY_AFTER_HOUR_MINIMUM_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(WEEKDAY_AFTER_HOUR.Value) != 0)
            {
                CurrentValue = WEEKDAY_AFTER_HOUR_MIN.Value;
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
    private DDecimal WEEKDAY_AFTER_HOUR_MAXIMUM = new DDecimal("WEEKDAY_AFTER_HOUR_MAXIMUM", 7);
    private void WEEKDAY_AFTER_HOUR_MAXIMUM_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(WEEKDAY_AFTER_HOUR.Value) != 0)
            {
                CurrentValue = WEEKDAY_AFTER_HOUR_MAX.Value;
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
    private DDecimal WEEKEND_DAY_MINIMUM = new DDecimal("WEEKEND_DAY_MINIMUM", 7);
    private void WEEKEND_DAY_MINIMUM_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(WEEKEND_DAY.Value) != 0)
            {
                CurrentValue = WEEKEND_DAY_MIN.Value;
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
    private DDecimal WEEKEND_DAY_MAXIMUM = new DDecimal("WEEKEND_DAY_MAXIMUM", 7);
    private void WEEKEND_DAY_MAXIMUM_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(WEEKEND_DAY.Value) != 0)
            {
                CurrentValue = WEEKEND_DAY_MAX.Value;
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
    private DDecimal WEEKEND_AFTER_HOUR_MINIMUM = new DDecimal("WEEKEND_AFTER_HOUR_MINIMUM", 7);
    private void WEEKEND_AFTER_HOUR_MINIMUM_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(WEEKEND_AFTER_HOUR.Value) != 0)
            {
                CurrentValue = WEEKEND_AFTER_HOUR_MIN.Value;
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
    private DDecimal WEEKEND_AFTER_HOUR_MAXIMUM = new DDecimal("WEEKEND_AFTER_HOUR_MAXIMUM", 7);
    private void WEEKEND_AFTER_HOUR_MAXIMUM_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(WEEKEND_AFTER_HOUR.Value) != 0)
            {
                CurrentValue = WEEKEND_AFTER_HOUR_MAX.Value;
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
    private SqlFileObject fleKOLESAR_YR;


    #endregion


    #region "Standard Generated Procedures(DRKOLESAR_YR_SUMMARIZE_CLAIMS_YR_1)"


    #region "Automatic Item Initialization(DRKOLESAR_YR_SUMMARIZE_CLAIMS_YR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DRKOLESAR_YR_SUMMARIZE_CLAIMS_YR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:39 PM

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
        fleKOLESAR_CLM.Transaction = m_trnTRANS_UPDATE;
        fleKOLESAR_YR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DRKOLESAR_YR_SUMMARIZE_CLAIMS_YR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:39 PM

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
            fleKOLESAR_CLM.Dispose();
            fleKOLESAR_YR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DRKOLESAR_YR_SUMMARIZE_CLAIMS_YR_1)"


    public void Run()
    {

        try
        {
            Request("SUMMARIZE_CLAIMS_YR_1");

            while (fleKOLESAR_CLM.QTPForMissing())
            {
                // --> GET KOLESAR_CLM <--

                fleKOLESAR_CLM.GetData();
                // --> End GET KOLESAR_CLM <--


                if (Transaction())
                {

                     if (Select_If())
                    {

                        Sort(fleKOLESAR_CLM.GetSortValue("SERV_YR"));



                    }

                }

            }

            while (Sort(fleKOLESAR_CLM))
            {
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKDAY")) == 1 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) == 0 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) == 0)
                {
                    WEEKDAY_DAY.Value = WEEKDAY_DAY.Value + fleKOLESAR_CLM.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKDAY")) == 1 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) == 0 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) == 0)
                {
                    Minimum(ref WEEKDAY_DAY_MIN);
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKDAY")) == 1 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) == 0 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) == 0)
                {
                    Maximum(ref WEEKDAY_DAY_MAX);
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKDAY")) == 1 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) == 0 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) == 0)
                {
                    Average(ref WEEKDAY_DAY_AVERAGE);
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKDAY")) == 1 & (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) > 0 | QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) > 0))
                {
                    WEEKDAY_AFTER_HOUR.Value = WEEKDAY_AFTER_HOUR.Value + fleKOLESAR_CLM.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKDAY")) == 1 & (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) > 0 | QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) > 0))
                {
                    Minimum(ref WEEKDAY_AFTER_HOUR_MIN);
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKDAY")) == 1 & (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) > 0 | QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) > 0))
                {
                    Maximum(ref WEEKDAY_AFTER_HOUR_MAX);
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKDAY")) == 1 & (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) > 0 | QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) > 0))
                {
                    Average(ref WEEKDAY_AFTER_HOUR_AVERAGE);
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKEND")) == 1 & (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) > 0 | (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) == 0 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) == 0)))
                {
                    WEEKEND_DAY.Value = WEEKEND_DAY.Value + fleKOLESAR_CLM.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKEND")) == 1 & (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) > 0 | (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) == 0 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) == 0)))
                {
                    Minimum(ref WEEKEND_DAY_MIN);
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKEND")) == 1 & (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) > 0 | (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) == 0 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) == 0)))
                {
                    Maximum(ref WEEKEND_DAY_MAX);
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKEND")) == 1 & (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) > 0 | (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) == 0 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) == 0)))
                {
                    Average(ref WEEKEND_DAY_AVERAGE);
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKEND")) == 1 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) > 0)
                {
                    WEEKEND_AFTER_HOUR.Value = WEEKEND_AFTER_HOUR.Value + fleKOLESAR_CLM.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKEND")) == 1 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) > 0)
                {
                    Minimum(ref WEEKEND_AFTER_HOUR_MIN);
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKEND")) == 1 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) > 0)
                {
                    Maximum(ref WEEKEND_AFTER_HOUR_MAX);
                }
                if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKEND")) == 1 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) > 0)
                {
                    Average(ref WEEKEND_AFTER_HOUR_AVERAGE);
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleKOLESAR_YR, fleKOLESAR_CLM.At("SERV_YR"), SubFileType.Portable, WEEKDAY_DAY, WEEKDAY_DAY_MINIMUM, WEEKDAY_DAY_MAXIMUM, WEEKDAY_DAY_AVERAGE, WEEKDAY_AFTER_HOUR, WEEKDAY_AFTER_HOUR_MINIMUM,
                WEEKDAY_AFTER_HOUR_MAXIMUM, WEEKDAY_AFTER_HOUR_AVERAGE, WEEKEND_DAY, WEEKEND_DAY_MINIMUM, WEEKEND_DAY_MAXIMUM, WEEKEND_DAY_AVERAGE, WEEKEND_AFTER_HOUR, WEEKEND_AFTER_HOUR_MINIMUM, WEEKEND_AFTER_HOUR_MAXIMUM, WEEKEND_AFTER_HOUR_AVERAGE);


                Reset(ref WEEKDAY_DAY, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKDAY_DAY_MIN, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKDAY_DAY_MAX, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKDAY_DAY_AVERAGE, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKDAY_AFTER_HOUR, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKDAY_AFTER_HOUR_MIN, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKDAY_AFTER_HOUR_MAX, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKDAY_AFTER_HOUR_AVERAGE, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKEND_DAY, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKEND_DAY_MIN, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKEND_DAY_MAX, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKEND_DAY_AVERAGE, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKEND_AFTER_HOUR, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKEND_AFTER_HOUR_MIN, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKEND_AFTER_HOUR_MAX, fleKOLESAR_CLM.At("SERV_YR"));
                Reset(ref WEEKEND_AFTER_HOUR_AVERAGE, fleKOLESAR_CLM.At("SERV_YR"));

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
            EndRequest("SUMMARIZE_CLAIMS_YR_1");

        }

    }







    #endregion


}
//SUMMARIZE_CLAIMS_YR_1



public class DRKOLESAR_YR_CREATE_RECORDS_2 : DRKOLESAR_YR
{

    public DRKOLESAR_YR_CREATE_RECORDS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleKOLESAR_CLM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "KOLESAR_CLM", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_COUNTERS_DUP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_DUP", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        X_DOC_NBR.GetValue += X_DOC_NBR_GetValue;
        DAY_TYPE.GetValue += DAY_TYPE_GetValue;
        BILL_AMT.GetValue += BILL_AMT_GetValue;
        fleTMP_COUNTERS_DUP.SetItemFinals += fleTMP_COUNTERS_DUP_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(DRKOLESAR_YR_CREATE_RECORDS_2)"

    private SqlFileObject fleKOLESAR_CLM;
    private DCharacter X_DOC_NBR = new DCharacter("X_DOC_NBR", 3);
    private void X_DOC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleKOLESAR_CLM.GetStringValue("CLMHDR_CLAIM_ID"), 3, 3);


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
            if (QDesign.NULL(X_DOC_NBR.Value) != "V63" & QDesign.NULL(X_DOC_NBR.Value) != "026" & QDesign.NULL(X_DOC_NBR.Value) != "T66" & QDesign.NULL(X_DOC_NBR.Value) != "V56" & QDesign.NULL(X_DOC_NBR.Value) != "37B" & QDesign.NULL(X_DOC_NBR.Value) != "72C" & QDesign.NULL(X_DOC_NBR.Value) != "F56" & QDesign.NULL(X_DOC_NBR.Value) != "F55" & QDesign.NULL(X_DOC_NBR.Value) != "622" & QDesign.NULL(X_DOC_NBR.Value) != "52A" & QDesign.NULL(X_DOC_NBR.Value) != "318")
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

    private DCharacter DAY_TYPE = new DCharacter("DAY_TYPE", 1);
    private void DAY_TYPE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKDAY")) == 1 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) == 0 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) == 0)
            {
                CurrentValue = "1";
            }
            else if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKDAY")) == 1 & (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) > 0 | QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) > 0))
            {
                CurrentValue = "2";
            }
            else if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKEND")) == 1 & (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) > 0 | (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E400_COUNT")) == 0 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) == 0)))
            {
                CurrentValue = "3";
            }
            else if (QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("WEEKEND")) == 1 & QDesign.NULL(fleKOLESAR_CLM.GetDecimalValue("E401_COUNT")) > 0)
            {
                CurrentValue = "4";
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
    private DCharacter BILL_AMT = new DCharacter("BILL_AMT", 10);
    private void BILL_AMT_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(fleKOLESAR_CLM.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") * 100, 10);


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
    private SqlFileObject fleTMP_COUNTERS_DUP;

    private void fleTMP_COUNTERS_DUP_SetItemFinals()
    {

        try
        {
            fleTMP_COUNTERS_DUP.set_SetValue("EP_YR", fleKOLESAR_CLM.GetDecimalValue("SERV_YR"));
            fleTMP_COUNTERS_DUP.set_SetValue("DOC_NBR", " ");
            fleTMP_COUNTERS_DUP.set_SetValue("REC_TYPE", DAY_TYPE.Value);
            fleTMP_COUNTERS_DUP.set_SetValue("TMP_ALPHA_FIELD_1", BILL_AMT.Value);
            fleTMP_COUNTERS_DUP.set_SetValue("TMP_COUNTER_1", fleKOLESAR_CLM.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));


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


    #region "Standard Generated Procedures(DRKOLESAR_YR_CREATE_RECORDS_2)"


    #region "Automatic Item Initialization(DRKOLESAR_YR_CREATE_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DRKOLESAR_YR_CREATE_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:39 PM

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
        fleKOLESAR_CLM.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS_DUP.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DRKOLESAR_YR_CREATE_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:39 PM

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
            fleKOLESAR_CLM.Dispose();
            fleTMP_COUNTERS_DUP.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DRKOLESAR_YR_CREATE_RECORDS_2)"


    public void Run()
    {

        try
        {
            Request("CREATE_RECORDS_2");

            while (fleKOLESAR_CLM.QTPForMissing())
            {
                // --> GET KOLESAR_CLM <--

                fleKOLESAR_CLM.GetData();
                // --> End GET KOLESAR_CLM <--


                if (Transaction())
                {

                     if (Select_If())
                    {
                        fleTMP_COUNTERS_DUP.OutPut(OutPutType.Add);

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
            EndRequest("CREATE_RECORDS_2");

        }

    }







    #endregion


}
//CREATE_RECORDS_2



public class DRKOLESAR_YR_UPDATE_COUNT_3 : DRKOLESAR_YR
{

    public DRKOLESAR_YR_UPDATE_COUNT_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleTMP_COUNTERS_DUP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_DUP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_COUNT = new CoreDecimal("X_COUNT", 7, this);

        fleTMP_COUNTERS_DUP.SetItemFinals += fleTMP_COUNTERS_DUP_SetItemFinals;
        fleTMP_COUNTERS_DUP.Choose += fleTMP_COUNTERS_DUP_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(DRKOLESAR_YR_UPDATE_COUNT_3)"

    private SqlFileObject fleTMP_COUNTERS_DUP;

    private void fleTMP_COUNTERS_DUP_SetItemFinals()
    {

        try
        {
            fleTMP_COUNTERS_DUP.set_SetValue("TMP_COUNTER_2", X_COUNT.Value);


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


    private void fleTMP_COUNTERS_DUP_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleTMP_COUNTERS_DUP.ElementOwner("DOC_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField(" "));


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


    private CoreDecimal X_COUNT;


    #endregion


    #region "Standard Generated Procedures(DRKOLESAR_YR_UPDATE_COUNT_3)"


    #region "Automatic Item Initialization(DRKOLESAR_YR_UPDATE_COUNT_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DRKOLESAR_YR_UPDATE_COUNT_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:39 PM

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
        fleTMP_COUNTERS_DUP.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DRKOLESAR_YR_UPDATE_COUNT_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:39 PM

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
            fleTMP_COUNTERS_DUP.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DRKOLESAR_YR_UPDATE_COUNT_3)"


    public void Run()
    {

        try
        {
            Request("UPDATE_COUNT_3");

            while (fleTMP_COUNTERS_DUP.QTPForMissing())
            {
                // --> GET TMP_COUNTERS_DUP <--

                fleTMP_COUNTERS_DUP.GetData();
                // --> End GET TMP_COUNTERS_DUP <--


                if (Transaction())
                {

                    Sort(fleTMP_COUNTERS_DUP.GetSortValue("EP_YR"), fleTMP_COUNTERS_DUP.GetSortValue("REC_TYPE"));



                }

            }

            while (Sort(fleTMP_COUNTERS_DUP))
            {
                X_COUNT.Value = X_COUNT.Value + 1;

                fleTMP_COUNTERS_DUP.OutPut(OutPutType.Update);

                Reset(ref X_COUNT, fleTMP_COUNTERS_DUP.At("EP_YR") || fleTMP_COUNTERS_DUP.At("REC_TYPE"));

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
            EndRequest("UPDATE_COUNT_3");

        }

    }







    #endregion


}
//UPDATE_COUNT_3



public class DRKOLESAR_YR_SORT_AMT_4 : DRKOLESAR_YR
{

    public DRKOLESAR_YR_SORT_AMT_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleTMP_COUNTERS_DUP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_DUP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEYR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEYR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleTMP_COUNTERS_DUP.Choose += fleTMP_COUNTERS_DUP_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(DRKOLESAR_YR_SORT_AMT_4)"

    private SqlFileObject fleTMP_COUNTERS_DUP;

    private void fleTMP_COUNTERS_DUP_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleTMP_COUNTERS_DUP.ElementOwner("DOC_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField(" "));


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

    private SqlFileObject fleSAVEYR;


    #endregion


    #region "Standard Generated Procedures(DRKOLESAR_YR_SORT_AMT_4)"


    #region "Automatic Item Initialization(DRKOLESAR_YR_SORT_AMT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DRKOLESAR_YR_SORT_AMT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:39 PM

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
        fleTMP_COUNTERS_DUP.Transaction = m_trnTRANS_UPDATE;
        fleSAVEYR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DRKOLESAR_YR_SORT_AMT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:40 PM

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
            fleTMP_COUNTERS_DUP.Dispose();
            fleSAVEYR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DRKOLESAR_YR_SORT_AMT_4)"


    public void Run()
    {

        try
        {
            Request("SORT_AMT_4");

            while (fleTMP_COUNTERS_DUP.QTPForMissing())
            {
                // --> GET TMP_COUNTERS_DUP <--

                fleTMP_COUNTERS_DUP.GetData();
                // --> End GET TMP_COUNTERS_DUP <--


                if (Transaction())
                {

                    Sort(fleTMP_COUNTERS_DUP.GetSortValue("EP_YR"), fleTMP_COUNTERS_DUP.GetSortValue("REC_TYPE"));


                }

            }

            while (Sort(fleTMP_COUNTERS_DUP))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEYR, fleTMP_COUNTERS_DUP.At("EP_YR") || fleTMP_COUNTERS_DUP.At("REC_TYPE"), SubFileType.Keep, fleTMP_COUNTERS_DUP);


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
            EndRequest("SORT_AMT_4");

        }

    }







    #endregion


}
//SORT_AMT_4



public class DRKOLESAR_YR_CALC_MEDIAN_5 : DRKOLESAR_YR
{

    public DRKOLESAR_YR_CALC_MEDIAN_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSAVEYR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEYR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleSAVEMED1_YR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEMED1_YR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleSAVEMED2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEMED1_YR", "SAVEMED2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_MOD.GetValue += X_MOD_GetValue;
        X_MED1.GetValue += X_MED1_GetValue;
        X_MED2.GetValue += X_MED2_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(DRKOLESAR_YR_CALC_MEDIAN_5)"

    private SqlFileObject fleSAVEYR;
    private DDecimal X_MOD = new DDecimal("X_MOD", 6);
    private void X_MOD_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleSAVEYR.GetDecimalValue("TMP_COUNTER_2"), 2);


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
    private DDecimal X_MED1 = new DDecimal("X_MED1", 6);
    private void X_MED1_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.Ceiling(fleSAVEYR.GetDecimalValue("TMP_COUNTER_2") / 2);


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
    private DDecimal X_MED2 = new DDecimal("X_MED2", 6);
    private void X_MED2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_MOD.Value) == 0)
            {
                CurrentValue = X_MED1.Value + 1;
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
    private SqlFileObject fleSAVEMED1_YR;
    private SqlFileObject fleSAVEMED2;


    #endregion


    #region "Standard Generated Procedures(DRKOLESAR_YR_CALC_MEDIAN_5)"


    #region "Automatic Item Initialization(DRKOLESAR_YR_CALC_MEDIAN_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DRKOLESAR_YR_CALC_MEDIAN_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:40 PM

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
        fleSAVEYR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEMED1_YR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEMED2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DRKOLESAR_YR_CALC_MEDIAN_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:40 PM

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
            fleSAVEYR.Dispose();
            fleSAVEMED1_YR.Dispose();
            fleSAVEMED2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DRKOLESAR_YR_CALC_MEDIAN_5)"


    public void Run()
    {

        try
        {
            Request("CALC_MEDIAN_5");

            while (fleSAVEYR.QTPForMissing())
            {
                // --> GET SAVEYR <--

                fleSAVEYR.GetData();
                // --> End GET SAVEYR <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEMED1_YR, SubFileType.Keep, fleSAVEYR, X_MED1);

                    SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEMED2, QDesign.NULL(X_MOD.Value) == 0, SubFileType.Keep, fleSAVEYR, X_MED2);


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
            EndRequest("CALC_MEDIAN_5");

        }

    }







    #endregion


}
//CALC_MEDIAN_5



public class DRKOLESAR_YR_FIND_MEDIAN1_6 : DRKOLESAR_YR
{

    public DRKOLESAR_YR_FIND_MEDIAN1_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSAVEMED1_YR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEMED1_YR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_COUNTERS_DUP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_DUP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEMED2_YR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEMED2_YR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(DRKOLESAR_YR_FIND_MEDIAN1_6)"

    private SqlFileObject fleSAVEMED1_YR;
    private SqlFileObject fleTMP_COUNTERS_DUP;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleSAVEMED1_YR.GetDecimalValue("X_MED1")) == QDesign.NULL(fleTMP_COUNTERS_DUP.GetDecimalValue("TMP_COUNTER_2")))
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

    private SqlFileObject fleSAVEMED2_YR;


    #endregion


    #region "Standard Generated Procedures(DRKOLESAR_YR_FIND_MEDIAN1_6)"


    #region "Automatic Item Initialization(DRKOLESAR_YR_FIND_MEDIAN1_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DRKOLESAR_YR_FIND_MEDIAN1_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:40 PM

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
        fleSAVEMED1_YR.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS_DUP.Transaction = m_trnTRANS_UPDATE;
        fleSAVEMED2_YR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DRKOLESAR_YR_FIND_MEDIAN1_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:40 PM

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
            fleSAVEMED1_YR.Dispose();
            fleTMP_COUNTERS_DUP.Dispose();
            fleSAVEMED2_YR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DRKOLESAR_YR_FIND_MEDIAN1_6)"


    public void Run()
    {

        try
        {
            Request("FIND_MEDIAN1_6");

            while (fleSAVEMED1_YR.QTPForMissing())
            {
                // --> GET SAVEMED1_YR <--

                fleSAVEMED1_YR.GetData();
                // --> End GET SAVEMED1_YR <--

                while (fleTMP_COUNTERS_DUP.QTPForMissing("1"))
                {
                    // --> GET TMP_COUNTERS_DUP <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleTMP_COUNTERS_DUP.ElementOwner("EP_YR")).Append(" = ");
                    m_strWhere.Append((fleSAVEMED1_YR.GetDecimalValue("EP_YR")));

                    fleTMP_COUNTERS_DUP.GetData(m_strWhere.ToString());
                    // --> End GET TMP_COUNTERS_DUP <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {
                            SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEMED2_YR, SubFileType.Keep, fleTMP_COUNTERS_DUP, "TMP_COUNTER_1", fleSAVEMED1_YR);


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
            EndRequest("FIND_MEDIAN1_6");

        }

    }







    #endregion


}
//FIND_MEDIAN1_6



public class DRKOLESAR_YR_SUM_AVG_MEDIAN_7 : DRKOLESAR_YR
{

    public DRKOLESAR_YR_SUM_AVG_MEDIAN_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSAVEMED2_YR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEMED2_YR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        AVG_MED = new CoreDecimal("AVG_MED", 7, this);
        fleSAVEMED_YR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEMED_YR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_COUNTERS_DUP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_DUP", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_COUNTERS_DUP.InitializeItems += fleTMP_COUNTERS_DUP_InitializeItems;
        fleTMP_COUNTERS_DUP.SetItemFinals += fleTMP_COUNTERS_DUP_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(DRKOLESAR_YR_SUM_AVG_MEDIAN_7)"

    private SqlFileObject fleSAVEMED2_YR;
    private CoreDecimal AVG_MED;
    private SqlFileObject fleSAVEMED_YR;
    private SqlFileObject fleTMP_COUNTERS_DUP;

    private void fleTMP_COUNTERS_DUP_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleTMP_COUNTERS_DUP.set_SetValue("EP_YR", true, fleSAVEMED2_YR.GetDecimalValue("EP_YR"));
            if (!Fixed)
                fleTMP_COUNTERS_DUP.set_SetValue("DOC_NBR", true, fleSAVEMED2_YR.GetStringValue("DOC_NBR"));
            if (!Fixed)
                fleTMP_COUNTERS_DUP.set_SetValue("REC_TYPE", true, fleSAVEMED2_YR.GetStringValue("REC_TYPE"));


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



    private void fleTMP_COUNTERS_DUP_SetItemFinals()
    {

        try
        {
            fleTMP_COUNTERS_DUP.set_SetValue("TMP_COUNTER_1", AVG_MED.Value);


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


    #region "Standard Generated Procedures(DRKOLESAR_YR_SUM_AVG_MEDIAN_7)"


    #region "Automatic Item Initialization(DRKOLESAR_YR_SUM_AVG_MEDIAN_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DRKOLESAR_YR_SUM_AVG_MEDIAN_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:40 PM

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
        fleSAVEMED2_YR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEMED_YR.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS_DUP.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DRKOLESAR_YR_SUM_AVG_MEDIAN_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:40 PM

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
            fleSAVEMED2_YR.Dispose();
            fleSAVEMED_YR.Dispose();
            fleTMP_COUNTERS_DUP.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DRKOLESAR_YR_SUM_AVG_MEDIAN_7)"


    public void Run()
    {

        try
        {
            Request("SUM_AVG_MEDIAN_7");

            while (fleSAVEMED2_YR.QTPForMissing())
            {
                // --> GET SAVEMED2_YR <--

                fleSAVEMED2_YR.GetData();
                // --> End GET SAVEMED2_YR <--


                if (Transaction())
                {

                    Sort(fleSAVEMED2_YR.GetSortValue("EP_YR"), fleSAVEMED2_YR.GetSortValue("REC_TYPE"));



                }

            }

            while (Sort(fleSAVEMED2_YR))
            {
                Average(ref AVG_MED);

                SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEMED_YR, fleSAVEMED2_YR.At("EP_YR") || fleSAVEMED2_YR.At("REC_TYPE"), SubFileType.Keep, fleSAVEMED2_YR, "EP_YR", "DOC_NBR", "DOC_NBR", "REC_TYPE", AVG_MED);

                fleTMP_COUNTERS_DUP.OutPut(OutPutType.Add, fleSAVEMED2_YR.At("EP_YR") || fleSAVEMED2_YR.At("REC_TYPE"), null);

                Reset(ref AVG_MED, fleSAVEMED2_YR.At("EP_YR") || fleSAVEMED2_YR.At("REC_TYPE"));

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
            EndRequest("SUM_AVG_MEDIAN_7");

        }

    }







    #endregion


}
//SUM_AVG_MEDIAN_7



public class DRKOLESAR_YR_YEAR_ALL_8 : DRKOLESAR_YR
{

    public DRKOLESAR_YR_YEAR_ALL_8(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleKOLESAR_YR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "KOLESAR_YR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_COUNTERS_DUP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_DUP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        WEEKDAY_DAY_MEDIUM = new CoreDecimal("WEEKDAY_DAY_MEDIUM", 7, this);
        WEEKDAY_AFTER_HOUR_MEDIUM = new CoreDecimal("WEEKDAY_AFTER_HOUR_MEDIUM", 7, this);
        WEEKEND_DAY_MEDIUM = new CoreDecimal("WEEKEND_DAY_MEDIUM", 7, this);
        WEEKEND_AFTER_HOUR_MEDIUM = new CoreDecimal("WEEKEND_AFTER_HOUR_MEDIUM", 7, this);
        fleKOLESAR_YR_ALL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "KOLESAR_YR_ALL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        COMMA.GetValue += COMMA_GetValue;
        X_ZONED_CR.GetValue += X_ZONED_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(DRKOLESAR_YR_YEAR_ALL_8)"

    private SqlFileObject fleKOLESAR_YR;
    private SqlFileObject fleTMP_COUNTERS_DUP;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleTMP_COUNTERS_DUP.GetStringValue("TMP_ALPHA_FIELD_1")) == QDesign.NULL(" "))
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

    private CoreDecimal WEEKDAY_DAY_MEDIUM;
    private CoreDecimal WEEKDAY_AFTER_HOUR_MEDIUM;
    private CoreDecimal WEEKEND_DAY_MEDIUM;
    private CoreDecimal WEEKEND_AFTER_HOUR_MEDIUM;
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
    private DInteger X_ZONED_CR = new DInteger("X_ZONED_CR", 4);
    private void X_ZONED_CR_GetValue(ref decimal Value)
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
            Value = QDesign.Characters(X_ZONED_CR.Value);


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
    private SqlFileObject fleKOLESAR_YR_ALL;


    #endregion


    #region "Standard Generated Procedures(DRKOLESAR_YR_YEAR_ALL_8)"


    #region "Automatic Item Initialization(DRKOLESAR_YR_YEAR_ALL_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DRKOLESAR_YR_YEAR_ALL_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:40 PM

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
        fleKOLESAR_YR.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS_DUP.Transaction = m_trnTRANS_UPDATE;
        fleKOLESAR_YR_ALL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DRKOLESAR_YR_YEAR_ALL_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:34:40 PM

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
            fleKOLESAR_YR.Dispose();
            fleTMP_COUNTERS_DUP.Dispose();
            fleKOLESAR_YR_ALL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DRKOLESAR_YR_YEAR_ALL_8)"


    public void Run()
    {

        try
        {
            Request("YEAR_ALL_8");

            while (fleKOLESAR_YR.QTPForMissing())
            {
                // --> GET KOLESAR_YR <--

                fleKOLESAR_YR.GetData();
                // --> End GET KOLESAR_YR <--

                while (fleTMP_COUNTERS_DUP.QTPForMissing("1"))
                {
                    // --> GET TMP_COUNTERS_DUP <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleTMP_COUNTERS_DUP.ElementOwner("EP_YR")).Append(" = ");
                    m_strWhere.Append((fleKOLESAR_YR.GetDecimalValue("SERV_YR")));
                    m_strWhere.Append(" And ").Append(fleTMP_COUNTERS_DUP.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(" "));

                    fleTMP_COUNTERS_DUP.GetData(m_strWhere.ToString());
                    // --> End GET TMP_COUNTERS_DUP <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleTMP_COUNTERS_DUP.GetSortValue("EP_YR"));



                        }

                    }

                }

            }

            while (Sort(fleKOLESAR_YR, fleTMP_COUNTERS_DUP))
            {
                if (QDesign.NULL(fleTMP_COUNTERS_DUP.GetStringValue("REC_TYPE")) == "1")
                {
                    WEEKDAY_DAY_MEDIUM.Value = fleTMP_COUNTERS_DUP.GetDecimalValue("TMP_COUNTER_1");
                }
                if (QDesign.NULL(fleTMP_COUNTERS_DUP.GetStringValue("REC_TYPE")) == "2")
                {
                    WEEKDAY_AFTER_HOUR_MEDIUM.Value = fleTMP_COUNTERS_DUP.GetDecimalValue("TMP_COUNTER_1");
                }
                if (QDesign.NULL(fleTMP_COUNTERS_DUP.GetStringValue("REC_TYPE")) == "3")
                {
                    WEEKEND_DAY_MEDIUM.Value = fleTMP_COUNTERS_DUP.GetDecimalValue("TMP_COUNTER_1");
                }
                if (QDesign.NULL(fleTMP_COUNTERS_DUP.GetStringValue("REC_TYPE")) == "4")
                {
                    WEEKEND_AFTER_HOUR_MEDIUM.Value = fleTMP_COUNTERS_DUP.GetDecimalValue("TMP_COUNTER_1");
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleKOLESAR_YR_ALL, fleTMP_COUNTERS_DUP.At("EP_YR"), SubFileType.Keep, COMMA, fleKOLESAR_YR, "WEEKDAY_DAY", "WEEKDAY_DAY_MINIMUM", "WEEKDAY_DAY_MAXIMUM", "WEEKDAY_DAY_AVERAGE",
                WEEKDAY_DAY_MEDIUM, "WEEKDAY_AFTER_HOUR", "WEEKDAY_AFTER_HOUR_MINIMUM", "WEEKDAY_AFTER_HOUR_MAXIMUM", "WEEKDAY_AFTER_HOUR_AVERAGE", WEEKDAY_AFTER_HOUR_MEDIUM, "WEEKEND_DAY", "WEEKEND_DAY_MINIMUM", "WEEKEND_DAY_MAXIMUM", "WEEKEND_DAY_AVERAGE",
                WEEKEND_DAY_MEDIUM, "WEEKEND_AFTER_HOUR", "WEEKEND_AFTER_HOUR_MINIMUM", "WEEKEND_AFTER_HOUR_MAXIMUM", "WEEKEND_AFTER_HOUR_AVERAGE", WEEKEND_AFTER_HOUR_MEDIUM, X_CR);


                Reset(ref WEEKDAY_DAY_MEDIUM, fleTMP_COUNTERS_DUP.At("EP_YR"));
                Reset(ref WEEKDAY_AFTER_HOUR_MEDIUM, fleTMP_COUNTERS_DUP.At("EP_YR"));
                Reset(ref WEEKEND_DAY_MEDIUM, fleTMP_COUNTERS_DUP.At("EP_YR"));
                Reset(ref WEEKEND_AFTER_HOUR_MEDIUM, fleTMP_COUNTERS_DUP.At("EP_YR"));

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
            EndRequest("YEAR_ALL_8");

        }

    }







    #endregion


}
//YEAR_ALL_8




