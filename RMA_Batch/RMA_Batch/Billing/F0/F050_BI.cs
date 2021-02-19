
#region "Screen Comments"

// 2015/Jul/13 BE original
// convert f050ma1.ps  with delimiter `~` for bi so that Dave can access
// 2015/Jul/28   MC - include the build statement
// 2015/Oct/08   MC1 - change the subfile to bi_f050 instead of f050_bi 
// 2015/Nov/12   MC2 - add PED as the first column as requested by Brad 
// 2015/Nov/26   MC3 - take out cr at the end to see if the extra blank line not created at the end
// 2015/dec/13   be1 - undo MC2 change for now .. don`t want dave to have to adjapt to PED column until it`s in SQL


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class F050_BI : BaseClassControl
{

    private F050_BI m_F050_BI;

    public F050_BI(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050MA1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F050MA1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleBI_F050 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "BI_F050", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_CR_LF.GetValue += X_CR_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;
        PED.GetValue += PED_GetValue;

    }

    public F050_BI(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050MA1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F050MA1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleBI_F050 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "BI_F050", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_CR_LF.GetValue += X_CR_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;
        PED.GetValue += PED_GetValue;

    }

    public override void Dispose()
    {
        if ((m_F050_BI != null))
        {
            m_F050_BI.CloseTransactionObjects();
            m_F050_BI = null;
        }
    }

    public F050_BI GetF050_BI(int Level)
    {
        if (m_F050_BI == null)
        {
            m_F050_BI = new F050_BI("F050_BI", Level);
        }
        else
        {
            m_F050_BI.ResetValues();
        }
        return m_F050_BI;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleF050MA1;
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
    private DCharacter X_CR = new DCharacter("X_CR", 1);
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
    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_CR_LF = new DCharacter("X_CR_LF", 2);
    private void X_CR_LF_GetValue(ref string Value)
    {

        try
        {
            Value = X_CR.Value + X_LF.Value;


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
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
    private DCharacter PED = new DCharacter("PED", 10);
    private void PED_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY)), 1, 4) + "-" + QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY)), 5, 2) + "-01";


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
    private SqlFileObject fleBI_F050;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("F050_BI");

            while (fleF050MA1.QTPForMissing())
            {
                // --> GET F050MA1 <--

                fleF050MA1.GetData();
                // --> End GET F050MA1 <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleBI_F050, SubFileType.Portable, fleF050MA1, "DOCREV_CLINIC_1_2", X_DELIMITER, "DOCREV_DEPT", "DOC_NBR", "DOCREV_LOCATION", "DOCREV_MTD_IN_REC",
                    "DOCREV_MTD_IN_SVC", "DOCREV_MTD_OUT_REC", "DOCREV_MTD_OUT_SVC", "DOCREV_YTD_IN_REC", "DOCREV_YTD_IN_SVC", "DOCREV_YTD_OUT_REC", "DOCREV_YTD_OUT_SVC", "NAME", X_LF);


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
            EndRequest("F050_BI");

        }

    }


    #region "Standard Generated Procedures(F050_BI_F050_BI)"

    #region "Transaction Management Procedures(F050_BI_F050_BI)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:26 PM

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
        fleF050MA1.Transaction = m_trnTRANS_UPDATE;
        fleBI_F050.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(F050_BI_F050_BI)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:26 PM

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
            fleF050MA1.Dispose();
            fleBI_F050.Dispose();


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

