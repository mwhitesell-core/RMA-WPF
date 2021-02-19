
#region "Screen Comments"

// program: fix_adj_claim_file_1.qts
// (1 of 2 programs in a series)
// Purpose: This program can be used to correct records in the adj-claim-file
// that is used to create automatic adjustment. 
// The program can be used to either DELETE a record or to MODIFY
// the contents of a record.
// The program works by reading the input file and modifying the data
// before it`s written to the output file. 
// 2013/08/20 -  now $cmd/fix_adj_file will run the below
// AFTER RUNNING THIS PROGRAM and BEFORE RUNNING THE 2ND PROGRAM 
// you must manually rename the original adjustment file to some 
//  backup name . 
// THEN you MUST RUN qutil to create  a new empty adj-claim-file
// Then when you run the 2nd program - fix_adj_claim_file2.qts
// it will recreate the original adjustment file. To confirm that
// all is well rerun by hand r990.qzs and the report should be empty.
// Procedures:
// modify this file as needed and run it
// then delete adj_claim_file.dat
// then qutil to re-create file adj-claim-file
// then run fix_adj_claim_file_2.qtc to update adj-claim file with subfile
// created by this program
// 2004/jan/05 b.e. - alpha doctor number
// 2013/aug/20 MC1  - allow up to 6 claims 
// 2014/sep/10 MC2  - correct to delete record/modify record accordingly


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class FIX_ADJ_CLAIM_FILE_1 : BaseClassControl
{

    private FIX_ADJ_CLAIM_FILE_1 m_FIX_ADJ_CLAIM_FILE_1;

    public FIX_ADJ_CLAIM_FILE_1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleADJ_CLAIM_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "ADJ_CLAIM_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleADJ_CLAIM_FILE_FIXED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "ADJ_CLAIM_FILE_FIXED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        FIX_FLAG.GetValue += FIX_FLAG_GetValue;
        FIXED_ADJ_OMA_CD_SUFF.GetValue += FIXED_ADJ_OMA_CD_SUFF_GetValue;
        FIXED_ADJ_SERV_DATE.GetValue += FIXED_ADJ_SERV_DATE_GetValue;
        DELETE_FLAG.GetValue += DELETE_FLAG_GetValue;

    }

    public FIX_ADJ_CLAIM_FILE_1(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleADJ_CLAIM_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "ADJ_CLAIM_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleADJ_CLAIM_FILE_FIXED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "ADJ_CLAIM_FILE_FIXED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        FIX_FLAG.GetValue += FIX_FLAG_GetValue;
        FIXED_ADJ_OMA_CD_SUFF.GetValue += FIXED_ADJ_OMA_CD_SUFF_GetValue;
        FIXED_ADJ_SERV_DATE.GetValue += FIXED_ADJ_SERV_DATE_GetValue;
        DELETE_FLAG.GetValue += DELETE_FLAG_GetValue;

    }

    public override void Dispose()
    {
        if ((m_FIX_ADJ_CLAIM_FILE_1 != null))
        {
            m_FIX_ADJ_CLAIM_FILE_1.CloseTransactionObjects();
            m_FIX_ADJ_CLAIM_FILE_1 = null;
        }
    }

    public FIX_ADJ_CLAIM_FILE_1 GetFIX_ADJ_CLAIM_FILE_1(int Level)
    {
        if (m_FIX_ADJ_CLAIM_FILE_1 == null)
        {
            m_FIX_ADJ_CLAIM_FILE_1 = new FIX_ADJ_CLAIM_FILE_1("FIX_ADJ_CLAIM_FILE_1", Level);
        }
        else
        {
            m_FIX_ADJ_CLAIM_FILE_1.ResetValues();
        }
        return m_FIX_ADJ_CLAIM_FILE_1;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleADJ_CLAIM_FILE;
    private DCharacter FIX_FLAG = new DCharacter("FIX_FLAG", 1);
    private void FIX_FLAG_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "3546J037" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 2)
            {
                CurrentValue = "1";
            }
            else if (QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "3546J037" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 3)
            {
                CurrentValue = "2";
            }
            else if (QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "batch-3" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 99)
            {
                CurrentValue = "3";
            }
            else if (QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "batch-4" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 99)
            {
                CurrentValue = "4";
            }
            else if (QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "batch-5" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 99)
            {
                CurrentValue = "5";
            }
            else if (QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "batch-6" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 99)
            {
                CurrentValue = "6";
            }
            else
            {
                CurrentValue = "0";
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
    private DCharacter FIXED_ADJ_OMA_CD_SUFF = new DCharacter("FIXED_ADJ_OMA_CD_SUFF", 5);
    private void FIXED_ADJ_OMA_CD_SUFF_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(FIX_FLAG.Value) == "0")
            {
                CurrentValue = fleADJ_CLAIM_FILE.GetStringValue("ADJ_OMA_CD_SUFF");
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "1")
            {
                CurrentValue = "W195A";
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "2")
            {
                CurrentValue = "W195A";
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "3")
            {
                CurrentValue = "code3";
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "4")
            {
                CurrentValue = "code4";
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "5")
            {
                CurrentValue = "code5";
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "6")
            {
                CurrentValue = "code6";
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
    private DDecimal FIXED_ADJ_SERV_DATE = new DDecimal("FIXED_ADJ_SERV_DATE");
    private void FIXED_ADJ_SERV_DATE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(FIX_FLAG.Value) == "0")
            {
                CurrentValue = fleADJ_CLAIM_FILE.GetNumericDateValue("ADJ_SERV_DATE");
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "1")
            {
                CurrentValue = 20161014;
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "2")
            {
                CurrentValue = 20161014;
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "3")
            {
                CurrentValue = 99990131;
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "4")
            {
                CurrentValue = 99990131;
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "5")
            {
                CurrentValue = 99990131;
            }
            else if (QDesign.NULL(FIX_FLAG.Value) == "6")
            {
                CurrentValue = 99990131;
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
    private DCharacter DELETE_FLAG = new DCharacter("DELETE_FLAG", 1);
    private void DELETE_FLAG_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if ((QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "xxxxxxxx" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 1) | (QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "xxxxxxxx" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 2) | (QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "xxxxxxx3" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 99) | (QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "xxxxxxx4" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 99) | (QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "xxxxxxx5" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 99) | (QDesign.NULL(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR")) == "xxxxxxx6" & QDesign.NULL(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR")) == 99))
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "N";
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
    private SqlFileObject fleADJ_CLAIM_FILE_FIXED;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("FIX_ADJ_CLAIM_FILE_1");

            while (fleADJ_CLAIM_FILE.QTPForMissing())
            {
                // --> GET ADJ_CLAIM_FILE <--

                fleADJ_CLAIM_FILE.GetData();
                // --> End GET ADJ_CLAIM_FILE <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleADJ_CLAIM_FILE_FIXED, QDesign.NULL(DELETE_FLAG.Value) == "N", SubFileType.Keep, fleADJ_CLAIM_FILE, "ADJ_BATCH_NBR", "ADJ_CLAIM_NBR", FIXED_ADJ_OMA_CD_SUFF, FIXED_ADJ_SERV_DATE, "ADJ_AGENT_CD",
                    "ADJ_PAT_ACRONYM", "ADJ_AMT_BAL", "ADJ_DIAG_CD", "ADJ_LINE_NO");


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
            EndRequest("FIX_ADJ_CLAIM_FILE_1");

        }

    }


    #region "Standard Generated Procedures(FIX_ADJ_CLAIM_FILE_1_FIX_ADJ_CLAIM_FILE_1)"

    #region "Transaction Management Procedures(FIX_ADJ_CLAIM_FILE_1_FIX_ADJ_CLAIM_FILE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:57 PM

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
        fleADJ_CLAIM_FILE.Transaction = m_trnTRANS_UPDATE;
        fleADJ_CLAIM_FILE_FIXED.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(FIX_ADJ_CLAIM_FILE_1_FIX_ADJ_CLAIM_FILE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:57 PM

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
            fleADJ_CLAIM_FILE.Dispose();
            fleADJ_CLAIM_FILE_FIXED.Dispose();


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

