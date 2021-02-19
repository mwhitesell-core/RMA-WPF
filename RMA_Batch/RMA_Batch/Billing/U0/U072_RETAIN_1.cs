#region "Screen Comments"

//  Each program only allows 31 files/subfiles from all requests - clinic 22 to 79  (29 files)
//  2012/Jun/25 - MC1 - include clinic 24 & 25  and now has reached the max 31 files, no more addition
//  if more clinics in the future, modify u072_retain_2.qts

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class U072_RETAIN_1 : BaseClassControl
{
    private U072_RETAIN_1 m_U072_RETAIN_1;
    
    public U072_RETAIN_1(string Name, int Level) 
        : base(Name, Level) {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public U072_RETAIN_1(string Name, int Level, bool Request) 
        : base(Name, Level, Request) {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose()
    {
        if (!(m_U072_RETAIN_1 == null))
        {
            m_U072_RETAIN_1.CloseTransactionObjects();
            m_U072_RETAIN_1 = null;
        }
    }
    
    public U072_RETAIN_1 GetU072_RETAIN_1(int Level)
    {
        if ((m_U072_RETAIN_1 == null))
        {
            m_U072_RETAIN_1 = new U072_RETAIN_1("U072_RETAIN_1", Level);
        }
        else
        {
            m_U072_RETAIN_1.ResetValues();
        }
        
        return m_U072_RETAIN_1;
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
            U072_RETAIN_1_1 RETAIN_1_1 = new U072_RETAIN_1_1(Name, Level);
            RETAIN_1_1.Run();
            RETAIN_1_1.Dispose();
            RETAIN_1_1 = null;

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

public class U072_RETAIN_1_1 : U072_RETAIN_1
{
    public U072_RETAIN_1_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleU072_RETAIN_CLAIM_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_22 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_22", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_23 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_23", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_24 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_24", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_25 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_25", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_31 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_31", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_32 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_32", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_33 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_33", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_34 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_34", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_35 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_35", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_36 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_36", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_37 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_37", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_41 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_41", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_42 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_42", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_43 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_43", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_44 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_44", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_45 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_45", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_46 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_46", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_61 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_61", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_62 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_62", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_63 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_63", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_64 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_64", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_65 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_65", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_66 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_66", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_71 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_71", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_72 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_72", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_73 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_73", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_74 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_74", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_75 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_75", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_78 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_78", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_HDR_79 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR_79", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
    }

    #region "Declarations (Variables, Files and Transactions)(U072_RETAIN_1)"

    private SqlFileObject fleU072_RETAIN_CLAIM_HDR;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_22;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_23;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_24;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_25;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_31;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_32;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_33;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_34;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_35;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_36;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_37;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_41;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_42;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_43;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_44;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_45;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_46;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_61;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_62;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_63;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_64;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_65;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_66;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_71;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_72;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_73;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_74;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_75;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_78;
    private SqlFileObject fleU072_RETAIN_CLAIM_HDR_79;

    #endregion

    #region "Standard Generated Procedures(U072_RETAIN_1)"

    #region "Automatic Item Initialization(U072_RETAIN_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(U072_RETAIN_1)"

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
        fleU072_RETAIN_CLAIM_HDR.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_22.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_23.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_24.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_25.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_31.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_32.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_33.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_34.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_35.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_36.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_37.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_41.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_42.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_43.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_44.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_45.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_46.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_61.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_62.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_63.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_64.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_65.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_66.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_71.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_72.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_73.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_74.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_75.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_78.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR_79.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion


    #region "FILE Management Procedures(U072_RETAIN_1)"

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
            fleU072_RETAIN_CLAIM_HDR.Dispose();
            fleU072_RETAIN_CLAIM_HDR_22.Dispose();
            fleU072_RETAIN_CLAIM_HDR_23.Dispose();
            fleU072_RETAIN_CLAIM_HDR_24.Dispose();
            fleU072_RETAIN_CLAIM_HDR_25.Dispose();
            fleU072_RETAIN_CLAIM_HDR_31.Dispose();
            fleU072_RETAIN_CLAIM_HDR_32.Dispose();
            fleU072_RETAIN_CLAIM_HDR_33.Dispose();
            fleU072_RETAIN_CLAIM_HDR_34.Dispose();
            fleU072_RETAIN_CLAIM_HDR_35.Dispose();
            fleU072_RETAIN_CLAIM_HDR_36.Dispose();
            fleU072_RETAIN_CLAIM_HDR_37.Dispose();
            fleU072_RETAIN_CLAIM_HDR_41.Dispose();
            fleU072_RETAIN_CLAIM_HDR_42.Dispose();
            fleU072_RETAIN_CLAIM_HDR_43.Dispose();
            fleU072_RETAIN_CLAIM_HDR_44.Dispose();
            fleU072_RETAIN_CLAIM_HDR_45.Dispose();
            fleU072_RETAIN_CLAIM_HDR_46.Dispose();
            fleU072_RETAIN_CLAIM_HDR_61.Dispose();
            fleU072_RETAIN_CLAIM_HDR_62.Dispose();
            fleU072_RETAIN_CLAIM_HDR_63.Dispose();
            fleU072_RETAIN_CLAIM_HDR_64.Dispose();
            fleU072_RETAIN_CLAIM_HDR_65.Dispose();
            fleU072_RETAIN_CLAIM_HDR_66.Dispose();
            fleU072_RETAIN_CLAIM_HDR_71.Dispose();
            fleU072_RETAIN_CLAIM_HDR_72.Dispose();
            fleU072_RETAIN_CLAIM_HDR_73.Dispose();
            fleU072_RETAIN_CLAIM_HDR_74.Dispose();
            fleU072_RETAIN_CLAIM_HDR_75.Dispose();
            fleU072_RETAIN_CLAIM_HDR_78.Dispose();
            fleU072_RETAIN_CLAIM_HDR_79.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U072_RETAIN_1)"


    public void Run()
    {
        try
        {
            Request("U072_RETAIN_1");

            while (fleU072_RETAIN_CLAIM_HDR.QTPForMissing())
            {
                //  --> GET U072_RETAIN_CLAIM_HDR <--
                fleU072_RETAIN_CLAIM_HDR.GetData();
                //  --> End GET U072_RETAIN_CLAIM_HDR <--

                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_22", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 22, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_23", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 23, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_24", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 24, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_25", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 25, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_31", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 31, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_32", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 32, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_33", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 33, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_34", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 34, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_35", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 35, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_36", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 36, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_37", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 37, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_41", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 41, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_42", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 42, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_43", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 43, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_44", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 44, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_45", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 45, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_46", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 46, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_61", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 61, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_62", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 62, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_63", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 63, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_64", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 64, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_65", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 65, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_66", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 66, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_71", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 71, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_72", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 72, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_73", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 73, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_74", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 74, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_75", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 75, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_78", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 78, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
                    SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR_79", QDesign.NConvert(QDesign.Substring(fleU072_RETAIN_CLAIM_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)) == 79, SubFileType.Keep, fleU072_RETAIN_CLAIM_HDR);
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
            EndRequest("U072_RETAIN_1");
        }
    }

    #endregion
}