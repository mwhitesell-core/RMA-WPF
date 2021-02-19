
#region "Screen Comments"

// 2014/Jul/21 M.C. utl0017.qts 
// - this program should only be run once a year after yearend before July payroll
// - change new fee for comp code RMACHR & GSTTAX
// - user should change the ep-nbr-from and the new and old fee


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0017 : BaseClassControl
{

    private UTL0017 m_UTL0017;

    public UTL0017(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF113_DEFAULT_COMP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF113 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF113", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF113_DEFAULT_COMP.SetItemFinals += fleF113_DEFAULT_COMP_SetItemFinals;
        fleF113_DEFAULT_COMP.Choose += fleF113_DEFAULT_COMP_Choose;

    }

    public UTL0017(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF113_DEFAULT_COMP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF113 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF113", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF113_DEFAULT_COMP.SetItemFinals += fleF113_DEFAULT_COMP_SetItemFinals;
        fleF113_DEFAULT_COMP.Choose += fleF113_DEFAULT_COMP_Choose;

    }

    public override void Dispose()
    {
        if ((m_UTL0017 != null))
        {
            m_UTL0017.CloseTransactionObjects();
            m_UTL0017 = null;
        }
    }

    public UTL0017 GetUTL0017(int Level)
    {
        if (m_UTL0017 == null)
        {
            m_UTL0017 = new UTL0017("UTL0017", Level);
        }
        else
        {
            m_UTL0017.ResetValues();
        }
        return m_UTL0017;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleF113_DEFAULT_COMP;

    private void fleF113_DEFAULT_COMP_SetItemFinals()
    {

        try
        {
            if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS")) == QDesign.NConvert(Prompt(2).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_GROSS", QDesign.NConvert(Prompt(3).ToString()));
            }
            else if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS")) == QDesign.NConvert(Prompt(4).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_GROSS", QDesign.NConvert(Prompt(5).ToString()));
            }
            else if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS")) == QDesign.NConvert(Prompt(6).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_GROSS", QDesign.NConvert(Prompt(7).ToString()));
            }
            else if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS")) == QDesign.NConvert(Prompt(8).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_GROSS", QDesign.NConvert(Prompt(9).ToString()));
            }
            else if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS")) == QDesign.NConvert(Prompt(10).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_GROSS", QDesign.NConvert(Prompt(11).ToString()));
            }
            else if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS")) == QDesign.NConvert(Prompt(12).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_GROSS", QDesign.NConvert(Prompt(13).ToString()));
            }

            if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET")) == QDesign.NConvert(Prompt(2).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_NET", QDesign.NConvert(Prompt(3).ToString()));
            }
            else if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET")) == QDesign.NConvert(Prompt(4).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_NET", QDesign.NConvert(Prompt(5).ToString()));
            }
            else if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET")) == QDesign.NConvert(Prompt(6).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_NET", QDesign.NConvert(Prompt(7).ToString()));
            }
            else if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET")) == QDesign.NConvert(Prompt(8).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_NET", QDesign.NConvert(Prompt(9).ToString()));
            }
            else if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET")) == QDesign.NConvert(Prompt(10).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_NET", QDesign.NConvert(Prompt(11).ToString()));
            }
            else if (QDesign.NULL(fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET")) == QDesign.NConvert(Prompt(12).ToString()))
            {
                fleF113_DEFAULT_COMP.set_SetValue("AMT_NET", QDesign.NConvert(Prompt(13).ToString()));
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

    }

    private SqlFileObject fleF020_DOCTOR_MSTR;

    private void fleF113_DEFAULT_COMP_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF113_DEFAULT_COMP.ElementOwner("EP_NBR_FROM")).Append(" = ");
            strSQL.Append(Prompt(1));


            strSQL.Append(" AND ");
            strSQL.Append(fleF113_DEFAULT_COMP.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("RMACHR"));


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


    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 14 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 80)
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


    private SqlFileObject fleSAVEF113;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("UTL0017");

            while (fleF113_DEFAULT_COMP.QTPForMissing())
            {
                // --> GET F113_DEFAULT_COMP <--

                fleF113_DEFAULT_COMP.GetData();
                // --> End GET F113_DEFAULT_COMP <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF113, SubFileType.Keep, fleF113_DEFAULT_COMP);
                            //Parent:F113_DEFAULT_COMP_KEY


                            fleF113_DEFAULT_COMP.OutPut(OutPutType.Update);
                            //Parent:F113_DEFAULT_COMP_KEY

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
            EndRequest("UTL0017");

        }

    }


    #region "Standard Generated Procedures(UTL0017_UTL0017)"

    #region "Transaction Management Procedures(UTL0017_UTL0017)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:58 PM

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
        fleF113_DEFAULT_COMP.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF113.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0017_UTL0017)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:58 PM

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
            fleF113_DEFAULT_COMP.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleSAVEF113.Dispose();


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

