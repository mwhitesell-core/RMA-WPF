
#region "Screen Comments"

// program utl0012b.qts
// purpose: place missing patient`s IKEY into tmp-pat-mstr
// link clmhdr-pat-ohip-id-or-chart              &


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0012B : BaseClassControl
{

    private UTL0012B m_UTL0012B;

    public UTL0012B(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleNOPAT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "NOPAT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleTMP_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_PAT_MSTR.SetItemFinals += fleTMP_PAT_MSTR_SetItemFinals;

    }

    public UTL0012B(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleNOPAT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "NOPAT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleTMP_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_PAT_MSTR.SetItemFinals += fleTMP_PAT_MSTR_SetItemFinals;

    }

    public override void Dispose()
    {
        if ((m_UTL0012B != null))
        {
            m_UTL0012B.CloseTransactionObjects();
            m_UTL0012B = null;
        }
    }

    public UTL0012B GetUTL0012B(int Level)
    {
        if (m_UTL0012B == null)
        {
            m_UTL0012B = new UTL0012B("UTL0012B", Level);
        }
        else
        {
            m_UTL0012B.ResetValues();
        }
        return m_UTL0012B;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleNOPAT;
    private SqlFileObject fleF010_PAT_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (!fleF010_PAT_MSTR.Exists())
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

    private SqlFileObject fleTMP_PAT_MSTR;

    private void fleTMP_PAT_MSTR_SetItemFinals()
    {

        try
        {
            fleTMP_PAT_MSTR.set_SetValue("PAT_ACRONYM_FIRST6", (fleNOPAT.GetStringValue("CLMHDR_PAT_ACRONYM")).PadRight(9).Substring(0, 6));
            //Parent:PAT_ACRONYM
            fleTMP_PAT_MSTR.set_SetValue("PAT_ACRONYM_LAST3", (fleNOPAT.GetStringValue("CLMHDR_PAT_ACRONYM")).PadRight(9).Substring(6, 3));
            //Parent:PAT_ACRONYM
            fleTMP_PAT_MSTR.set_SetValue("PAT_I_KEY", (fleNOPAT.GetStringValue("KEY_P_CLM_DATA")).PadRight(16).Substring(0, 1));
            
            fleTMP_PAT_MSTR.set_SetValue("PAT_CON_NBR", (fleNOPAT.GetStringValue("KEY_P_CLM_DATA")).PadRight(16).Substring(1, 2));
            
            fleTMP_PAT_MSTR.set_SetValue("PAT_I_NBR", (fleNOPAT.GetStringValue("KEY_P_CLM_DATA")).PadRight(16).Substring(3, 12));
            
            fleTMP_PAT_MSTR.set_SetValue("FILLER4", (fleNOPAT.GetStringValue("KEY_P_CLM_DATA")).PadRight(16).Substring(15, 1));
            


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

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("UTL0012B");

            while (fleNOPAT.QTPForMissing())
            {
                // --> GET NOPAT <--

                fleNOPAT.GetData();
                // --> End GET NOPAT <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleNOPAT.GetStringValue("KEY_P_CLM_DATA")).PadRight(16).Substring(0, 1)));
                    
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleNOPAT.GetStringValue("KEY_P_CLM_DATA")).PadRight(16).Substring(1, 2)));
                    
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleNOPAT.GetStringValue("KEY_P_CLM_DATA")).PadRight(16).Substring(3, 12)));
                    
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleNOPAT.GetStringValue("KEY_P_CLM_DATA")).PadRight(16).Substring(15, 1)));
                    

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F010_PAT_MSTR <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleNOPAT.GetSortValue("KEY_P_CLM_DATA"));


                        }

                    }

                }

            }


            while (Sort(fleNOPAT, fleF010_PAT_MSTR))
            {


                fleTMP_PAT_MSTR.OutPut(OutPutType.Add, fleNOPAT.At("KEY_P_CLM_DATA"), null);
                

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
            EndRequest("UTL0012B");

        }

    }


    #region "Standard Generated Procedures(UTL0012B_UTL0012B)"

    #region "Transaction Management Procedures(UTL0012B_UTL0012B)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:00 PM

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
        fleNOPAT.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleTMP_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0012B_UTL0012B)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:00 PM

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
            fleNOPAT.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleTMP_PAT_MSTR.Dispose();


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

