
#region "Screen Comments"

// 2015/Jan/06    M.C.    utl0018a.qts
// - this program should only be run once a year after yearend 
// - this program will reset ped 1 to 13 to zero, cycle nbr to 1 and ped nbr to 1 
// for all clinics 22 to 99  


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0018A : BaseClassControl
{

    private UTL0018A m_UTL0018A;

    public UTL0018A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UTL0018A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UTL0018A != null))
        {
            m_UTL0018A.CloseTransactionObjects();
            m_UTL0018A = null;
        }
    }

    public UTL0018A GetUTL0018A(int Level)
    {
        if (m_UTL0018A == null)
        {
            m_UTL0018A = new UTL0018A("UTL0018A", Level);
        }
        else
        {
            m_UTL0018A.ResetValues();
        }
        return m_UTL0018A;
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

            UTL0018A_SET_PED_1 SET_PED_1 = new UTL0018A_SET_PED_1(Name, Level);
            SET_PED_1.Run();
            SET_PED_1.Dispose();
            SET_PED_1 = null;

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



public class UTL0018A_SET_PED_1 : UTL0018A
{

    public UTL0018A_SET_PED_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleICONST_MSTR_REC.SetItemFinals += fleICONST_MSTR_REC_SetItemFinals;
        fleICONST_MSTR_REC.Choose += fleICONST_MSTR_REC_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0018A_SET_PED_1)"

    private SqlFileObject fleICONST_MSTR_REC;

    private void fleICONST_MSTR_REC_SetItemFinals()
    {

        try
        {
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_YY", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_MM", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_DD", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_1", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_2", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_3", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_4", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_5", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_6", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_7", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_8", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_9", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_10", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_11", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_12", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_13", 0);
            fleICONST_MSTR_REC.set_SetValue("ICONST_CLINIC_CYCLE_NBR", 1);
            fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 1);


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


    private void fleICONST_MSTR_REC_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
            strSQL.Append(22);


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


    #endregion


    #region "Standard Generated Procedures(UTL0018A_SET_PED_1)"


    #region "Automatic Item Initialization(UTL0018A_SET_PED_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0018A_SET_PED_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:52 PM

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
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0018A_SET_PED_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:52 PM

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
            fleICONST_MSTR_REC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0018A_SET_PED_1)"


    public void Run()
    {

        try
        {
            Request("SET_PED_1");

            while (fleICONST_MSTR_REC.QTPForMissing())
            {
                // --> GET ICONST_MSTR_REC <--

                fleICONST_MSTR_REC.GetData();
                // --> End GET ICONST_MSTR_REC <--


                if (Transaction())
                {

                    fleICONST_MSTR_REC.OutPut(OutPutType.Update);
                    

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
            EndRequest("SET_PED_1");

        }

    }




    #endregion


}
//SET_PED_1




