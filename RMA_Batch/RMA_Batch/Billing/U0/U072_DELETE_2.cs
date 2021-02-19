#region "Screen Comments"

//  2014/Oct/04 MC1 include clinic 68 & 69
//  2014/Oct/16 MC2 include clinic 30 
//  2015/Mar/10 MC3 include clinic 26 
//  Each program only allows 31 files/subfiles from all requests - clinic 80 to 98  (15 files)

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class U072_DELETE_2 : BaseClassControl
{
    private U072_DELETE_2 m_U072_DELETE_2;
    
    public U072_DELETE_2(string Name, int Level) 
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public U072_DELETE_2(string Name, int Level, bool Request) 
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose()
    {
        if (!(m_U072_DELETE_2 == null))
        {
            m_U072_DELETE_2.CloseTransactionObjects();
            m_U072_DELETE_2 = null;
        }
    }
    
    public U072_DELETE_2 GetU072_DELETE_2(int Level)
    {
        if ((m_U072_DELETE_2 == null))
        {
            m_U072_DELETE_2 = new U072_DELETE_2("U072_DELETE_2", Level);
        }
        else
        {
            m_U072_DELETE_2.ResetValues();
        }
        
        return m_U072_DELETE_2;
    }

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.
    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
    protected SqlTransaction m_trnTRANS_UPDATE;

    public override bool RunQTP()
    {
        try
        {
            U072_DELETE_2_1 DELETE_2_1 = new U072_DELETE_2_1(Name, Level);
            DELETE_2_1.Run();
            DELETE_2_1.Dispose();
            DELETE_2_1 = null;

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
}

public class U072_DELETE_2_1 : U072_DELETE_2
{
    public U072_DELETE_2_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleU072_DELETE_CLAIM_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_26 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_26", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_30 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_30", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_68 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_68", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_69 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_69", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_80 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_80", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_82 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_82", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_84 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_84", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_86 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_86", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_87 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_87", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_88 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_88", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_89 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_89", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_91 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_91", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_92 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_92", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_93 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_93", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_94 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_94", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_95 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_95", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_96 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_96", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_DELETE_CLAIM_HDR_98 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_DELETE_CLAIM_HDR_98", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
    }

    #region "Declarations (Variables, Files and Transactions)(U072_DELETE_2)"

    private SqlFileObject fleU072_DELETE_CLAIM_HDR;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_26;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_30;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_68;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_69;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_80;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_82;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_84;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_86;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_87;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_88;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_89;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_91;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_92;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_93;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_94;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_95;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_96;
    private SqlFileObject fleU072_DELETE_CLAIM_HDR_98;

    #endregion

    #region "Standard Generated Procedures(U072_DELETE_2)"

    #region "Automatic Item Initialization(U072_DELETE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(U072_DELETE_2)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 8/30/2019 9:56:14 AM

    // #-----------------------------------------
    // # InitializeTransactionObjects Procedure.
    // #-----------------------------------------
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

    // #-----------------------------------------
    // # CloseTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void CloseTransactionObjects()
    {
        try
        {
            this.CloseFiles();

            if (!(m_trnTRANS_UPDATE == null))
            {
                m_trnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Close();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Close();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Dispose();
            }
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
        if ((Method == TransactionMethods.Rollback))
        {
            m_trnTRANS_UPDATE.Rollback();
        }
        else
        {
            m_trnTRANS_UPDATE.Commit();
        }

        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        this.Initialize_TRANS_UPDATE();
    }

    private void Initialize_TRANS_UPDATE()
    {
        fleU072_DELETE_CLAIM_HDR.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_26.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_30.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_68.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_69.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_80.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_82.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_84.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_86.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_87.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_88.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_89.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_91.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_92.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_93.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_94.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_95.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_96.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR_98.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion


    #region "FILE Management Procedures(U072_DELETE_2)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 8/30/2019 9:56:14 AM
    // #-----------------------------------------
    // # InitializeFiles Procedure.
    // #-----------------------------------------
    protected override void InitializeFiles()
    {
        try
        {
            this.Initialize_TRANS_UPDATE();
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

    // #-----------------------------------------
    // # CloseFiles Procedure.
    // #-----------------------------------------
    protected override void CloseFiles()
    {
        try
        {
            fleU072_DELETE_CLAIM_HDR.Dispose();
            fleU072_DELETE_CLAIM_HDR_26.Dispose();
            fleU072_DELETE_CLAIM_HDR_30.Dispose();
            fleU072_DELETE_CLAIM_HDR_68.Dispose();
            fleU072_DELETE_CLAIM_HDR_69.Dispose();
            fleU072_DELETE_CLAIM_HDR_80.Dispose();
            fleU072_DELETE_CLAIM_HDR_82.Dispose();
            fleU072_DELETE_CLAIM_HDR_84.Dispose();
            fleU072_DELETE_CLAIM_HDR_86.Dispose();
            fleU072_DELETE_CLAIM_HDR_87.Dispose();
            fleU072_DELETE_CLAIM_HDR_88.Dispose();
            fleU072_DELETE_CLAIM_HDR_89.Dispose();
            fleU072_DELETE_CLAIM_HDR_91.Dispose();
            fleU072_DELETE_CLAIM_HDR_92.Dispose();
            fleU072_DELETE_CLAIM_HDR_93.Dispose();
            fleU072_DELETE_CLAIM_HDR_94.Dispose();
            fleU072_DELETE_CLAIM_HDR_95.Dispose();
            fleU072_DELETE_CLAIM_HDR_96.Dispose();
            fleU072_DELETE_CLAIM_HDR_98.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U072_DELETE_2)"

    public void Run()
    {
        try
        {
            Request("U072_DELETE_2");

            while (fleU072_DELETE_CLAIM_HDR.QTPForMissing())
            {
                //  --> GET U072_DELETE_CLAIM_HDR <--
                fleU072_DELETE_CLAIM_HDR.GetData();
                //  --> End GET U072_DELETE_CLAIM_HDR <--

                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_26", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 26, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_30", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 30, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_68", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 68, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_69", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 69, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_80", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 80, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_82", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 82, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_84", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 84, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_86", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 86, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_87", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 87, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_88", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 88, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_89", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 89, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_91", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 91, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_92", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 92, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_93", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 93, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_94", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 94, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_95", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 95, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_96", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 96, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR_98", QDesign.NConvert(QDesign.Substring(fleU072_DELETE_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 98, SubFileType.Keep, fleU072_DELETE_CLAIM_HDR);
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
            EndRequest("U072_DELETE_2");
        }
    }

    #endregion    
}