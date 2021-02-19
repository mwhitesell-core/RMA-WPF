
#region "Screen Comments"

// program: utl0100.qts
// purpose: search f119-doctor-ytd for duplicate entries.
// This is the 1st pass of process. If  duplicates are found, then
// the doctor number and code are placed into subfile which is
// is used to create report in 2nd pass.
// 2004/jun/10 b.e. -alpha doctor number conversion
// 2004/jul/21 b.e. -added deletion of duplicate record


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class UTL0100 : BaseClassControl
{
    private UTL0100 m_UTL0100;

    public UTL0100(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public UTL0100(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if ((m_UTL0100 != null))
        {
            m_UTL0100.CloseTransactionObjects();
            m_UTL0100 = null;
        }
    }

    public UTL0100 GetUTL0100(int Level)
    {
        if (m_UTL0100 == null)
        {
            m_UTL0100 = new UTL0100("UTL0100", Level);
        }
        else
        {
            m_UTL0100.ResetValues();
        }
        return m_UTL0100;
    }

    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;

    #endregion

    public override bool RunQTP()
    {
        try
        {
            UTL0100_F119_DUPLICATE_CHECKING F119_DUPLICATE_CHECKING = new UTL0100_F119_DUPLICATE_CHECKING(Name, Level);
            F119_DUPLICATE_CHECKING.Run();
            F119_DUPLICATE_CHECKING.Dispose();
            F119_DUPLICATE_CHECKING = null;

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
}

public class UTL0100_F119_DUPLICATE_CHECKING : UTL0100
{

    public UTL0100_F119_DUPLICATE_CHECKING(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_DUPLICATES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119_DUPLICATES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        LAST_COMP_CODE = new CoreCharacter("LAST_COMP_CODE", 6, this);
        LAST_DOC_NBR = new CoreCharacter("LAST_DOC_NBR", 3, this);
        LAST_AMT_MTD = new CoreDecimal("LAST_AMT_MTD", 10, this);
        LAST_AMT_YTD = new CoreDecimal("LAST_AMT_YTD", 10, this);

        DUP_FOUND_FLAG.GetValue += DUP_FOUND_FLAG_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(U121_RUN_0_2)"

    private SqlFileObject fleF119_DOCTOR_YTD;
    private SqlFileObject fleF119_DUPLICATES;

    public override bool SelectIf()
    {
        try
        {
            if (fleF119_DOCTOR_YTD.GetStringValue("REC_TYPE") == "A")
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

    CoreCharacter LAST_COMP_CODE;
    CoreCharacter LAST_DOC_NBR;
    CoreDecimal LAST_AMT_MTD;
    CoreDecimal LAST_AMT_YTD;

    private DCharacter DUP_FOUND_FLAG = new DCharacter("DUP_FOUND_FLAG", 1);
    private void DUP_FOUND_FLAG_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (LAST_COMP_CODE.Value == fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE") && LAST_DOC_NBR.Value == fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR"))
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

    #endregion

    #region "Standard Generated Procedures(UTL0100_UTL0100)"

    #region "Transaction Management Procedures(UTL0100_UTL0100)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:36 PM

    //#-----------------------------------------
    //# InitializeTransactionObjects Procedure.
    //#-----------------------------------------

    protected override void InitializeTransactionObjects()
    {
        try
        {
            m_cnnTRANS_UPDATE = new SqlConnection(Common.GetConnectionString());
            m_cnnTRANS_UPDATE.Open();
            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_cnnQUERY = new SqlConnection(Common.GetConnectionString());
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
        fleF119_DUPLICATES.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(UTL0100_UTL0100)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:36 PM

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
            fleF119_DUPLICATES.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public void Run()
    {
        try
        {
            Request("UTL0100_F119_CHECK_FOR_DUPLICATES");

            while (fleF119_DOCTOR_YTD.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD <--
                fleF119_DOCTOR_YTD.GetData();
                // --> End GET F119_DOCTOR_YTD <--

                if (Transaction())
                {
                    if (Select_If())
                    {
                        SubFile(ref m_trnTRANS_UPDATE, ref fleF119_DUPLICATES, DUP_FOUND_FLAG.Value == "Y", SubFileType.Keep, DUP_FOUND_FLAG, LAST_DOC_NBR, fleF119_DOCTOR_YTD, "DOC_NBR", LAST_COMP_CODE,
                                "COMP_CODE", LAST_AMT_MTD,  "AMT_MTD", LAST_AMT_YTD, "AMT_YTD");

                        if (DUP_FOUND_FLAG.Value == "Y")
                        {
                            fleF119_DOCTOR_YTD.OutPut(OutPutType.Delete);
                        }

                        LAST_COMP_CODE.Value = fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE");
                        LAST_DOC_NBR.Value = fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR");
                        LAST_AMT_MTD.Value = fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                        LAST_AMT_YTD.Value = fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD");
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
            EndRequest("UTL0100_F119_CHECK_FOR_DUPLICATES");
        }
    }

    #endregion
}

