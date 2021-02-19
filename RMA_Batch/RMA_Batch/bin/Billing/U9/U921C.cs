
#region "Screen Comments"

// u921c.qts  formerly createf113_depmem.qts
// 2012/oct/11 MC1 - create records in f113 file
// - According to Yasemin, this program should be run after September monthend each year
// - this is the third pass of 3 passes (u921a.qts, r921b.qzs, u921c.qts)
// - ep-nbr-from should be yyyy04(oct) and ep-nbr-to should be yyyy06 (dec)


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U921C : BaseClassControl
{

    private U921C m_U921C;

    public U921C(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU921A_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U921A_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF113_DEFAULT_COMP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF113 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "F113", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF113_DEFAULT_COMP.SetItemFinals += fleF113_DEFAULT_COMP_SetItemFinals;
        fleF113.SetItemFinals += fleF113_SetItemFinals;

    }

    public U921C(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU921A_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U921A_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF113_DEFAULT_COMP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF113 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "F113", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF113_DEFAULT_COMP.SetItemFinals += fleF113_DEFAULT_COMP_SetItemFinals;
        fleF113.SetItemFinals += fleF113_SetItemFinals;

    }

    public override void Dispose()
    {
        if ((m_U921C != null))
        {
            m_U921C.CloseTransactionObjects();
            m_U921C = null;
        }
    }

    public U921C GetU921C(int Level)
    {
        if (m_U921C == null)
        {
            m_U921C = new U921C("U921C", Level);
        }
        else
        {
            m_U921C.ResetValues();
        }
        return m_U921C;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleU921A_DOCTORS;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF113_DEFAULT_COMP;

    private void fleF113_DEFAULT_COMP_SetItemFinals()
    {

        try
        {
            fleF113_DEFAULT_COMP.set_SetValue("DOC_NBR", fleU921A_DOCTORS.GetStringValue("DOC_NBR"));
            fleF113_DEFAULT_COMP.set_SetValue("EP_NBR_FROM", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));
            fleF113_DEFAULT_COMP.set_SetValue("EP_NBR_TO", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") + 1);
            if (QDesign.NULL(fleU921A_DOCTORS.GetDecimalValue("DOC_DEPT")) != 31)
            {
                fleF113_DEFAULT_COMP.set_SetValue("COMP_CODE", "DEPMEM");
            }
            else if (QDesign.NULL(fleU921A_DOCTORS.GetDecimalValue("DOC_DEPT")) == 31)
            {
                fleF113_DEFAULT_COMP.set_SetValue("COMP_CODE", "DEPMED");
            }
            fleF113_DEFAULT_COMP.set_SetValue("FACTOR", 10000);
            fleF113_DEFAULT_COMP.set_SetValue("AMT_GROSS", 233334);
            fleF113_DEFAULT_COMP.set_SetValue("AMT_NET", 233334);
            fleF113_DEFAULT_COMP.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));
            fleF113_DEFAULT_COMP.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF113_DEFAULT_COMP.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF113_DEFAULT_COMP.set_SetValue("LAST_MOD_USER_ID", "U921C");


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

    private SqlFileObject fleF113;

    private void fleF113_SetItemFinals()
    {

        try
        {
            fleF113.set_SetValue("DOC_NBR", fleU921A_DOCTORS.GetStringValue("DOC_NBR"));
            fleF113.set_SetValue("EP_NBR_FROM", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") + 2);
            fleF113.set_SetValue("EP_NBR_TO", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") + 2);
            if (QDesign.NULL(fleU921A_DOCTORS.GetDecimalValue("DOC_DEPT")) != 31)
            {
                fleF113.set_SetValue("COMP_CODE", "DEPMEM");
            }
            else if (QDesign.NULL(fleU921A_DOCTORS.GetDecimalValue("DOC_DEPT")) == 31)
            {
                fleF113.set_SetValue("COMP_CODE", "DEPMED");
            }
            fleF113.set_SetValue("FACTOR", 10000);
            fleF113.set_SetValue("AMT_GROSS", 233332);
            fleF113.set_SetValue("AMT_NET", 233332);
            fleF113.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") + 2);
            fleF113.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF113.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF113.set_SetValue("LAST_MOD_USER_ID", "U921C");


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
            Request("U921C");

            while (fleU921A_DOCTORS.QTPForMissing())
            {
                // --> GET U921A_DOCTORS <--

                fleU921A_DOCTORS.GetData();
                // --> End GET U921A_DOCTORS <--

                while (fleCONSTANTS_MSTR_REC_6.QTPForMissing("1"))
                {
                    // --> GET CONSTANTS_MSTR_REC_6 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                    m_strWhere.Append((6));

                    fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString());
                    // --> End GET CONSTANTS_MSTR_REC_6 <--


                    if (Transaction())
                    {
                        fleF113_DEFAULT_COMP.OutPut(OutPutType.Add);


                        fleF113.OutPut(OutPutType.Add);

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
            EndRequest("U921C");

        }

    }


    #region "Standard Generated Procedures(U921C_U921C)"

    #region "Transaction Management Procedures(U921C_U921C)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:26 PM

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
        fleU921A_DOCTORS.Transaction = m_trnTRANS_UPDATE;
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF113_DEFAULT_COMP.Transaction = m_trnTRANS_UPDATE;
        fleF113.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U921C_U921C)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:26 PM

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
            fleU921A_DOCTORS.Dispose();
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF113_DEFAULT_COMP.Dispose();
            fleF113.Dispose();


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

