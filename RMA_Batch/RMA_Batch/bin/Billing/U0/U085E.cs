
#region "Screen Comments"

// #> program-id.     u085e.qts
// ((C)) Dyad Technologies
// program purpose : update pat-date-last-elig-mailing to sysdate
// add 1 to pat-no-letter-sent in f010-pat-mstr
// MODIFICATION HISTORY
// 93/04/28   AGK         - ORIGINAL SMS141
// 93/05/21 M. CHAN  - ADD MESS CODE CHECK IN THE
// SELECTION CRITERIA SAME AS
// R085.QZS
// - UPDATE PAT RECORD BY PATIENT
// - ONLY NOT BY EACH CLAIM
// 93/06/04        YASEMIN  - ADD = <> FOR ELIG-MAILING
// 160100
// 94/03/02 M. CHAN  - CHECK IF LAST MAILING IS 21
// DAYS OLD INSTEAD OF 10 DAYS
// 95/06/13 B.M.L.  - COMMENT OUT BRIANU085 SUBFILE
// 98/12/10        B.E.      - changed to access *r085 subfile rather than
// selecting records directly from the
// rejected-claims file.
// 1999/jan/13 B.E.  - y2k
// 00/jun/29 B.E. - changed to access *u085b rather than *r085. This ensures
// the claims processed are the same ones printed in the
// letters and have been filtered so that no `confidential`
// claims are processed
// 03/dec/15 A.A. - alpha doc nbr
// 04/jan/15 M.C. - change sorted to sort
// 07/jul/04 M.C. - add `set lock record update`
// 10/jul/15 MC1  -  do the same as r085e.qzs
// add rejected-claims in the access statement and add the section criteria for records 
// that are NOT `logically` deleted  and the clmhdr-submit-date = sel-date 
// 11/jan/20 MC2  -  use u085d subfile instead of u085b, should  be same as r085e.qzs, also include     
// ohip_run_dates in the access
// -  add a new request to delete the earliest ohip run date record
// 11/Feb/03 MC3  -  change the same for d-test-date as r085e.qzs
// 11/Mar/02 MC4  -  change the same for selection criterias as r085e.qzs with the resubmit criteria section
// use < if there are more than one records in ohip-run-dates file;
// otherwise, use <= if there is only one record in ohip-run-dates file
// -  add the subfile for before patient update
// 11/Mar/08 MC5  - this program has been renamed from u085.qts
// - include tmp-counters in the access statement
// - change the selection criteria to use either `<` or `<=` based on the tmp-counter-1 of tmp-counters files
// 11/Apr/04 MC6   - change to use r085e subfile from r085e.qzs to update the f010 file, delete all unnecessary codes  
// 2007/07/04 - MC
// 2007/07/04 - end


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U085E : BaseClassControl
{

    private U085E m_U085E;

    public U085E(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U085E(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U085E != null))
        {
            m_U085E.CloseTransactionObjects();
            m_U085E = null;
        }
    }

    public U085E GetU085E(int Level)
    {
        if (m_U085E == null)
        {
            m_U085E = new U085E("U085E", Level);
        }
        else
        {
            m_U085E.ResetValues();
        }
        return m_U085E;
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

            U085E_PAT_DATE_UPDATE_1 PAT_DATE_UPDATE_1 = new U085E_PAT_DATE_UPDATE_1(Name, Level);
            PAT_DATE_UPDATE_1.Run();
            PAT_DATE_UPDATE_1.Dispose();
            PAT_DATE_UPDATE_1 = null;

            U085E_DELETE_OHIP_RUN_DATE_2 DELETE_OHIP_RUN_DATE_2 = new U085E_DELETE_OHIP_RUN_DATE_2(Name, Level);
            DELETE_OHIP_RUN_DATE_2.Run();
            DELETE_OHIP_RUN_DATE_2.Dispose();
            DELETE_OHIP_RUN_DATE_2 = null;

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



public class U085E_PAT_DATE_UPDATE_1 : U085E
{

    public U085E_PAT_DATE_UPDATE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR085E = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R085E", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF010_PAT_MSTR.SetItemFinals += fleF010_PAT_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U085E_PAT_DATE_UPDATE_1)"

    private SqlFileObject fleR085E;
    private SqlFileObject fleF010_PAT_MSTR;

    private void fleF010_PAT_MSTR_SetItemFinals()
    {

        try
        {
            fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_ELIG_MAILING", QDesign.SysDate(ref m_cnnQUERY));
            fleF010_PAT_MSTR.set_SetValue("PAT_NO_OF_LETTER_SENT", (fleF010_PAT_MSTR.GetDecimalValue("PAT_NO_OF_LETTER_SENT") + 1));


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


    #region "Standard Generated Procedures(U085E_PAT_DATE_UPDATE_1)"


    #region "Automatic Item Initialization(U085E_PAT_DATE_UPDATE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U085E_PAT_DATE_UPDATE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:59 PM

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
        fleR085E.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U085E_PAT_DATE_UPDATE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:59 PM

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
            fleR085E.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U085E_PAT_DATE_UPDATE_1)"


    public void Run()
    {

        try
        {
            Request("PAT_DATE_UPDATE_1");

            while (fleR085E.QTPForMissing())
            {
                // --> GET R085E <--

                fleR085E.GetData();
                // --> End GET R085E <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("KEY_PAT_MSTR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleR085E.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF010_PAT_MSTR.ElementOwner("KEY_PAT_MSTR"));

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F010_PAT_MSTR <--


                    if (Transaction())
                    {
                        fleF010_PAT_MSTR.OutPut(OutPutType.Update);

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
            EndRequest("PAT_DATE_UPDATE_1");

        }

    }







    #endregion


}
//PAT_DATE_UPDATE_1



public class U085E_DELETE_OHIP_RUN_DATE_2 : U085E
{

    public U085E_DELETE_OHIP_RUN_DATE_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR085E_RUN_DATE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R085E_RUN_DATE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleOHIP_RUN_DATES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "OHIP_RUN_DATES", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(U085E_DELETE_OHIP_RUN_DATE_2)"

    private SqlFileObject fleR085E_RUN_DATE;
    private SqlFileObject fleOHIP_RUN_DATES;


    #endregion


    #region "Standard Generated Procedures(U085E_DELETE_OHIP_RUN_DATE_2)"


    #region "Automatic Item Initialization(U085E_DELETE_OHIP_RUN_DATE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U085E_DELETE_OHIP_RUN_DATE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:59 PM

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
        fleR085E_RUN_DATE.Transaction = m_trnTRANS_UPDATE;
        fleOHIP_RUN_DATES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U085E_DELETE_OHIP_RUN_DATE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:59 PM

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
            fleR085E_RUN_DATE.Dispose();
            fleOHIP_RUN_DATES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U085E_DELETE_OHIP_RUN_DATE_2)"


    public void Run()
    {

        try
        {
            Request("DELETE_OHIP_RUN_DATE_2");

            while (fleR085E_RUN_DATE.QTPForMissing())
            {
                // --> GET R085E_RUN_DATE <--

                fleR085E_RUN_DATE.GetData();
                // --> End GET R085E_RUN_DATE <--

                while (fleOHIP_RUN_DATES.QTPForMissing("1"))
                {
                    // --> GET OHIP_RUN_DATES <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleOHIP_RUN_DATES.ElementOwner("SEQ_NBR")).Append(" = ");
                    m_strWhere.Append((fleR085E_RUN_DATE.GetDecimalValue("SEQ_NBR")));

                    fleOHIP_RUN_DATES.GetData(m_strWhere.ToString());
                    // --> End GET OHIP_RUN_DATES <--


                    if (Transaction())
                    {
                        fleOHIP_RUN_DATES.OutPut(OutPutType.Delete);

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
            EndRequest("DELETE_OHIP_RUN_DATE_2");

        }

    }







    #endregion


}
//DELETE_OHIP_RUN_DATE_2




