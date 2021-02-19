
#region "Screen Comments"

// program utl0012d
// purpose: add missing patients back into f010


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0012D : BaseClassControl
{

    private UTL0012D m_UTL0012D;

    public UTL0012D(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU099_DELETE_PATIENTS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U099_DELETE_PATIENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }

    public UTL0012D(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU099_DELETE_PATIENTS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U099_DELETE_PATIENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }

    public override void Dispose()
    {
        if ((m_UTL0012D != null))
        {
            m_UTL0012D.CloseTransactionObjects();
            m_UTL0012D = null;
        }
    }

    public UTL0012D GetUTL0012D(int Level)
    {
        if (m_UTL0012D == null)
        {
            m_UTL0012D = new UTL0012D("UTL0012D", Level);
        }
        else
        {
            m_UTL0012D.ResetValues();
        }
        return m_UTL0012D;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleU099_DELETE_PATIENTS;
    private SqlFileObject fleTMP_PAT_MSTR;
    private SqlFileObject fleF010_PAT_MSTR;
    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("UTL0012D");

            while (fleU099_DELETE_PATIENTS.QTPForMissing())
            {
                // --> GET U099_DELETE_PATIENTS <--

                fleU099_DELETE_PATIENTS.GetData();
                // --> End GET U099_DELETE_PATIENTS <--

                while (fleTMP_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET TMP_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleTMP_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(((QDesign.Substring(fleTMP_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleTMP_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleTMP_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleTMP_PAT_MSTR.GetStringValue("FILLER4"), 2, 15))).PadRight(16).Substring(0, 1)));

                    m_strWhere.Append(" AND ").Append(" ").Append(fleTMP_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(((QDesign.Substring(fleTMP_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleTMP_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleTMP_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleTMP_PAT_MSTR.GetStringValue("FILLER4"), 2, 15))).PadRight(16).Substring(1, 2)));

                    m_strWhere.Append(" AND ").Append(" ").Append(fleTMP_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(((QDesign.Substring(fleTMP_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleTMP_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleTMP_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleTMP_PAT_MSTR.GetStringValue("FILLER4"), 2, 15))).PadRight(16).Substring(3, 12)));

                    m_strWhere.Append(" AND ").Append(" ").Append(fleTMP_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(((QDesign.Substring(fleTMP_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleTMP_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleTMP_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleTMP_PAT_MSTR.GetStringValue("FILLER4"), 2, 15))).PadRight(16).Substring(15, 1)));


                    fleTMP_PAT_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET TMP_PAT_MSTR <--


                    if (Transaction())
                    {

                        fleF010_PAT_MSTR.OutPut(OutPutType.Add);
                        

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
            EndRequest("UTL0012D");

        }

    }


    #region "Standard Generated Procedures(UTL0012D_UTL0012D)"

    #region "Transaction Management Procedures(UTL0012D_UTL0012D)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:59 PM

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
        fleU099_DELETE_PATIENTS.Transaction = m_trnTRANS_UPDATE;
        fleTMP_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0012D_UTL0012D)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:59 PM

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
            fleU099_DELETE_PATIENTS.Dispose();
            fleTMP_PAT_MSTR.Dispose();
            fleF010_PAT_MSTR.Dispose();


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

