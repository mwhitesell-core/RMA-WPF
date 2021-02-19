
#region "Screen Comments"

// #> PROGRAM-ID.     U704.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : UPDATE SUSPENDED CLAIM HEADER RECS WITH PATIENT I-KEYS
// DESCRIP : USING THE SUBFILE GENERATED FROM THE PATIENT/SUBSCRIBER
// UPDATE PROGRAM, ACCESS THE ORIGINAL CLAIM HEADER RECS
// IN THE  SUSPEND CLAIM HEADER  FILE AND IDENTIFY
// THE PATIENTS WITH THE  I-KEY  GIVEN TO THE PATIENTS
// BY THE UPDATE PROCESS
// MODIFICATION HISTORY
// DATE     SMS #   WHO       DESCRIPTION
// 90/JUN/05          D.B.      - ORIGINAL
// 90/AUG/01          B.E.      - WHEN UPDATING SUSPEND-HDR PUT  I  IN FRONT OF  I-KEY 
// 98/MAR/20          B.E.      - ADDED UPDATE OF PATIENT S ACRONYM AND PROVINCE
// 1999/jan/28          B.E.    - y2k


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U704 : BaseClassControl
{

    private U704 m_U704;

    public U704(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U704(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U704 != null))
        {
            m_U704.CloseTransactionObjects();
            m_U704 = null;
        }
    }

    public U704 GetU704(int Level)
    {
        if (m_U704 == null)
        {
            m_U704 = new U704("U704", Level);
        }
        else
        {
            m_U704.ResetValues();
        }
        return m_U704;
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

            U704_UPDATE_SUSPEND_1 UPDATE_SUSPEND_1 = new U704_UPDATE_SUSPEND_1(Name, Level);
            UPDATE_SUSPEND_1.Run();
            UPDATE_SUSPEND_1.Dispose();
            UPDATE_SUSPEND_1 = null;

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



public class U704_UPDATE_SUSPEND_1 : U704
{

    public U704_UPDATE_SUSPEND_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSUBMIT_DISK_PAT_OUT = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "SUBMIT_DISK_PAT_OUT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_SUSPEND_HDR.SetItemFinals += fleF002_SUSPEND_HDR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U704_UPDATE_SUSPEND_1)"

    private SqlFileObject fleSUBMIT_DISK_PAT_OUT;
    private SqlFileObject fleF002_SUSPEND_HDR;

    private void fleF002_SUSPEND_HDR_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_PAT_KEY_TYPE", "I");
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_PAT_KEY_DATA", fleSUBMIT_DISK_PAT_OUT.GetStringValue("SEQ_PAT_I_KEY"));
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_PAT_ACRONYM6", (fleSUBMIT_DISK_PAT_OUT.GetStringValue("SEQ_PAT_ACRONYM")).PadRight(9).Substring(0, 6));
            //Parent:CLMHDR_PAT_ACRONYM
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_PAT_ACRONYM3", (fleSUBMIT_DISK_PAT_OUT.GetStringValue("SEQ_PAT_ACRONYM")).PadRight(9).Substring(6, 3));
            //Parent:CLMHDR_PAT_ACRONYM
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_HEALTH_CARE_PROV", fleSUBMIT_DISK_PAT_OUT.GetStringValue("SEQ_PAT_PROVINCE"));


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


    #region "Standard Generated Procedures(U704_UPDATE_SUSPEND_1)"


    #region "Automatic Item Initialization(U704_UPDATE_SUSPEND_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U704_UPDATE_SUSPEND_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:55 PM

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
        fleSUBMIT_DISK_PAT_OUT.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U704_UPDATE_SUSPEND_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:55 PM

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
            fleSUBMIT_DISK_PAT_OUT.Dispose();
            fleF002_SUSPEND_HDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U704_UPDATE_SUSPEND_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_SUSPEND_1");

            while (fleSUBMIT_DISK_PAT_OUT.QTPForMissing())
            {
                // --> GET SUBMIT_DISK_PAT_OUT <--

                fleSUBMIT_DISK_PAT_OUT.GetData();
                // --> End GET SUBMIT_DISK_PAT_OUT <--

                while (fleF002_SUSPEND_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleSUBMIT_DISK_PAT_OUT.GetDecimalValue("SEQ_PAT_DOCTOR_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleSUBMIT_DISK_PAT_OUT.GetStringValue("SEQ_PAT_ACCOUNT_NBR")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR"));

                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F002_SUSPEND_HDR <--



                    fleF002_SUSPEND_HDR.OutPut(OutPutType.Update);
                    //Parent:CLMHDR_PAT_ACRONYM

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
            EndRequest("UPDATE_SUSPEND_1");

        }

    }




    #endregion


}
//UPDATE_SUSPEND_1




