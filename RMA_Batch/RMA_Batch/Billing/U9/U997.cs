
#region "Screen Comments"

// program-id. u997.qts
// purpose: To check data from u030-tape-145-file
// and create subfiles with  wrong  and  ok  data
// MODIFICATION HISTORY
// DATE    SMS # WHO DESCRIPTION
// 90.11.16   131          D.B.    ORIGINAL
// 91.03.08   138  D.B. NEW MRO LAYOUT
// 92.10.14         Y.B. INCLUDE W-RAT-145-AMT-PAID IN
// U997_TOTAL
// 1999/May/16  S.B. Y2K checked.
// 2003/dec/16  A.A. alpha doctor nbr
// 2004/sep/20  M.C. change the definition for w-wrong-flag
// 2004/nov/25        M.C. change the definition for w-wrong-flag
// by adding criteria
// create a new request for rmb 


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U997 : BaseClassControl
{

    private U997 m_U997;

    public U997(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U997(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U997 != null))
        {
            m_U997.CloseTransactionObjects();
            m_U997 = null;
        }
    }

    public U997 GetU997(int Level)
    {
        if (m_U997 == null)
        {
            m_U997 = new U997("U997", Level);
        }
        else
        {
            m_U997.ResetValues();
        }
        return m_U997;
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

            U997_EXTRACT_RECORDS_1 EXTRACT_RECORDS_1 = new U997_EXTRACT_RECORDS_1(Name, Level);
            EXTRACT_RECORDS_1.Run();
            EXTRACT_RECORDS_1.Dispose();
            EXTRACT_RECORDS_1 = null;

            U997_EXTRACT_RECORDS_2 EXTRACT_RECORDS_2 = new U997_EXTRACT_RECORDS_2(Name, Level);
            EXTRACT_RECORDS_2.Run();
            EXTRACT_RECORDS_2.Dispose();
            EXTRACT_RECORDS_2 = null;

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



public class U997_EXTRACT_RECORDS_1 : U997
{

    public U997_EXTRACT_RECORDS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_TAPE_145_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "U030_TAPE_145_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        W_COUNT = new CoreDecimal("W_COUNT", 6, this);
        W_RAT_145_AMOUNT_SUB = new CoreDecimal("W_RAT_145_AMOUNT_SUB", 11, this);
        W_RAT_145_AMT_PAID = new CoreDecimal("W_RAT_145_AMT_PAID", 11, this);
        fleU997_BAD = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U997_BAD", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU997_GOOD = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U997_GOOD", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU997_TOTAL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U997_TOTAL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        W_WRONG_FLAG.GetValue += W_WRONG_FLAG_GetValue;
        W_LAST_REC_FLAG.GetValue += W_LAST_REC_FLAG_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U997_EXTRACT_RECORDS_1)"

    private SqlFileObject fleU030_TAPE_145_FILE;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DCharacter W_WRONG_FLAG = new DCharacter("W_WRONG_FLAG", 1);
    private void W_WRONG_FLAG_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if ((!fleF020_DOCTOR_MSTR.Exists() | 8 > (QDesign.Length((fleU030_TAPE_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR")).TrimEnd())) | String.Compare(QDesign.NULL(QDesign.Substring(fleU030_TAPE_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR"), 4, 5)), "00000") < 0 | string.Compare(QDesign.NULL(QDesign.Substring(fleU030_TAPE_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR"), 4, 5)), "99999") > 0) | (QDesign.NULL(fleU030_TAPE_145_FILE.GetDecimalValue("RAT_145_DOC_NBR")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"))))
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
    private DCharacter W_LAST_REC_FLAG = new DCharacter("W_LAST_REC_FLAG", 1);
    private void W_LAST_REC_FLAG_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private CoreDecimal W_COUNT;
    private CoreDecimal W_RAT_145_AMOUNT_SUB;

    private CoreDecimal W_RAT_145_AMT_PAID;

    private SqlFileObject fleU997_BAD;


    private SqlFileObject fleU997_GOOD;


    private SqlFileObject fleU997_TOTAL;


    #endregion


    #region "Standard Generated Procedures(U997_EXTRACT_RECORDS_1)"


    #region "Automatic Item Initialization(U997_EXTRACT_RECORDS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U997_EXTRACT_RECORDS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:17 PM

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
        fleU030_TAPE_145_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU997_BAD.Transaction = m_trnTRANS_UPDATE;
        fleU997_GOOD.Transaction = m_trnTRANS_UPDATE;
        fleU997_TOTAL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U997_EXTRACT_RECORDS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:17 PM

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
            fleU030_TAPE_145_FILE.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleU997_BAD.Dispose();
            fleU997_GOOD.Dispose();
            fleU997_TOTAL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U997_EXTRACT_RECORDS_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_RECORDS_1");

            while (fleU030_TAPE_145_FILE.QTPForMissing())
            {
                // --> GET U030_TAPE_145_FILE <--

                fleU030_TAPE_145_FILE.GetData();
                // --> End GET U030_TAPE_145_FILE <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleU030_TAPE_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR"), 1, 3))));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                        Sort(W_LAST_REC_FLAG.Value, fleU030_TAPE_145_FILE.GetSortValue("RAT_145_ACCOUNT_NBR"));



                    }

                }

            }

            while (Sort(fleU030_TAPE_145_FILE, fleF020_DOCTOR_MSTR))
            {
                Count(ref W_COUNT, At(W_LAST_REC_FLAG) || fleU030_TAPE_145_FILE.At("RAT_145_ACCOUNT_NBR"));
                SubTotal(ref W_RAT_145_AMOUNT_SUB, fleU030_TAPE_145_FILE.GetDecimalValue("RAT_145_AMOUNT_SUB"));
                SubTotal(ref W_RAT_145_AMT_PAID, fleU030_TAPE_145_FILE.GetDecimalValue("RAT_145_AMT_PAID"));



                SubFile(ref m_trnTRANS_UPDATE, ref fleU997_BAD, QDesign.NULL(W_WRONG_FLAG.Value) == "Y", SubFileType.KeepSQL, fleU030_TAPE_145_FILE);




                SubFile(ref m_trnTRANS_UPDATE, ref fleU997_GOOD, QDesign.NULL(W_WRONG_FLAG.Value) == "N", SubFileType.KeepSQL, fleU030_TAPE_145_FILE);




                SubFile(ref m_trnTRANS_UPDATE, ref fleU997_TOTAL, At(W_LAST_REC_FLAG), SubFileType.KeepSQL, W_COUNT, W_RAT_145_AMOUNT_SUB, W_RAT_145_AMT_PAID);



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
            EndRequest("EXTRACT_RECORDS_1");

        }

    }




    #endregion


}
//EXTRACT_RECORDS_1



public class U997_EXTRACT_RECORDS_2 : U997
{

    public U997_EXTRACT_RECORDS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_TAPE_RMB_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "U030_TAPE_RMB_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU997_BAD = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U997_BAD", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU997_RMB_GOOD = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U997_RMB_GOOD", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        W_WRONG_FLAG.GetValue += W_WRONG_FLAG_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U997_EXTRACT_RECORDS_2)"

    private SqlFileObject fleU030_TAPE_RMB_FILE;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DCharacter W_WRONG_FLAG = new DCharacter("W_WRONG_FLAG", 1);
    private void W_WRONG_FLAG_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if ((!fleF020_DOCTOR_MSTR.Exists() | 8 > (QDesign.Length((fleU030_TAPE_RMB_FILE.GetStringValue("RAT_RMB_ACCOUNT_NBR")).TrimEnd())) | String.Compare(QDesign.NULL(QDesign.Substring(fleU030_TAPE_RMB_FILE.GetStringValue("RAT_RMB_ACCOUNT_NBR"), 4, 5)), "00000") < 0 | string.Compare(QDesign.NULL(QDesign.Substring(fleU030_TAPE_RMB_FILE.GetStringValue("RAT_RMB_ACCOUNT_NBR"), 4, 5)), "99999") > 0) | (QDesign.NULL(fleU030_TAPE_RMB_FILE.GetDecimalValue("RAT_RMB_DOC_NBR")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"))))
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


    private SqlFileObject fleU997_BAD;


    private SqlFileObject fleU997_RMB_GOOD;


    #endregion


    #region "Standard Generated Procedures(U997_EXTRACT_RECORDS_2)"


    #region "Automatic Item Initialization(U997_EXTRACT_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U997_EXTRACT_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:17 PM

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
        fleU030_TAPE_RMB_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU997_BAD.Transaction = m_trnTRANS_UPDATE;
        fleU997_RMB_GOOD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U997_EXTRACT_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:17 PM

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
            fleU030_TAPE_RMB_FILE.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleU997_BAD.Dispose();
            fleU997_RMB_GOOD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U997_EXTRACT_RECORDS_2)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_RECORDS_2");

            while (fleU030_TAPE_RMB_FILE.QTPForMissing())
            {
                // --> GET U030_TAPE_RMB_FILE <--

                fleU030_TAPE_RMB_FILE.GetData();
                // --> End GET U030_TAPE_RMB_FILE <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleU030_TAPE_RMB_FILE.GetStringValue("RAT_RMB_ACCOUNT_NBR"), 1, 3))));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {


                        SubFile(ref m_trnTRANS_UPDATE, ref fleU997_BAD, QDesign.NULL(W_WRONG_FLAG.Value) == "Y", SubFileType.KeepSQL, fleU030_TAPE_RMB_FILE);




                        SubFile(ref m_trnTRANS_UPDATE, ref fleU997_RMB_GOOD, QDesign.NULL(W_WRONG_FLAG.Value) == "N", SubFileType.KeepSQL, fleU030_TAPE_RMB_FILE);



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
            EndRequest("EXTRACT_RECORDS_2");

        }

    }




    #endregion


}
//EXTRACT_RECORDS_2




