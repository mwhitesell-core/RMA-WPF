
#region "Screen Comments"

// #> PROGRAM-ID.     U704A.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : UPDATE DATE-LAST-VISIT in f010 from F002-SUSPEND-HDR/DTL
// DESCRIP : THIS PROGRAM SHOULD BE RUN BEFORE PATIENT PURGE BECAUSE
// USER MAY NOT FINISH CREATE CLAIMS FROM SUSPENSE.  DO NOT
// WANT TO DELETE THE PATIENTS THAT ARE IN PROGRESS.
// MODIFICATION HISTORY
// DATE     SMS #   WHO       DESCRIPTION
// 2009/OCT/06           M.C.      - ORIGINAL
// 2016/Nov/30   MC1    - set pat-date-last-visit to be system date if clmdtl-sv-date = `????????`
// (data conversion error)


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U704A : BaseClassControl
{

    private U704A m_U704A;

    public U704A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U704A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U704A != null))
        {
            m_U704A.CloseTransactionObjects();
            m_U704A = null;
        }
    }

    public U704A GetU704A(int Level)
    {
        if (m_U704A == null)
        {
            m_U704A = new U704A("U704A", Level);
        }
        else
        {
            m_U704A.ResetValues();
        }
        return m_U704A;
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

            U704A_SELECT_CLAIMS_WITH_IKEY_1 SELECT_CLAIMS_WITH_IKEY_1 = new U704A_SELECT_CLAIMS_WITH_IKEY_1(Name, Level);
            SELECT_CLAIMS_WITH_IKEY_1.Run();
            SELECT_CLAIMS_WITH_IKEY_1.Dispose();
            SELECT_CLAIMS_WITH_IKEY_1 = null;

            U704A_SELECT_CLMDTL_2 SELECT_CLMDTL_2 = new U704A_SELECT_CLMDTL_2(Name, Level);
            SELECT_CLMDTL_2.Run();
            SELECT_CLMDTL_2.Dispose();
            SELECT_CLMDTL_2 = null;

            U704A_UPDATE_PATIENTS_3 UPDATE_PATIENTS_3 = new U704A_UPDATE_PATIENTS_3(Name, Level);
            UPDATE_PATIENTS_3.Run();
            UPDATE_PATIENTS_3.Dispose();
            UPDATE_PATIENTS_3 = null;

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



public class U704A_SELECT_CLAIMS_WITH_IKEY_1 : U704A
{

    public U704A_SELECT_CLAIMS_WITH_IKEY_1(string Name, int Level)
        : base(Name, Level, true)
	{
		this.ScreenType = ScreenTypes.QTP;
fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0,	"m_trnTRANS_UPDATE"); 
fleU704_CLMHDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U704_CLMHDR", "", false, false, false, 0,			"m_trnTRANS_UPDATE", FileType.SubFile); 


	}


    #region "Declarations (Variables, Files and Transactions)(U704A_SELECT_CLAIMS_WITH_IKEY_1)"

    private SqlFileObject fleF002_SUSPEND_HDR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE")) == "I")
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























    private SqlFileObject fleU704_CLMHDR;


    #endregion


    #region "Standard Generated Procedures(U704A_SELECT_CLAIMS_WITH_IKEY_1)"


    #region "Automatic Item Initialization(U704A_SELECT_CLAIMS_WITH_IKEY_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U704A_SELECT_CLAIMS_WITH_IKEY_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:50 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleU704_CLMHDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U704A_SELECT_CLAIMS_WITH_IKEY_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:50 PM

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
            fleF002_SUSPEND_HDR.Dispose();
            fleU704_CLMHDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U704A_SELECT_CLAIMS_WITH_IKEY_1)"


    public void Run()
    {

        try
        {
            Request("SELECT_CLAIMS_WITH_IKEY_1");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--

                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--

                if (Transaction())
                {

                     if (Select_If())
                    {

                        


                        SubFile(ref m_trnTRANS_UPDATE, ref fleU704_CLMHDR, SubFileType.Keep, fleF002_SUSPEND_HDR, "CLMHDR_PAT_KEY_TYPE", "CLMHDR_PAT_KEY_DATA", "CLMHDR_DOC_OHIP_NBR", "CLMHDR_ACCOUNTING_NBR");
                        


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
            EndRequest("SELECT_CLAIMS_WITH_IKEY_1");

        }

    }




    #endregion


}
//SELECT_CLAIMS_WITH_IKEY_1



public class U704A_SELECT_CLMDTL_2 : U704A
{

    public U704A_SELECT_CLMDTL_2(string Name, int Level)
        : base(Name, Level, true)
	{
		this.ScreenType = ScreenTypes.QTP;
fleU704_CLMHDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U704_CLMHDR", "", false, false, false, 0,			"m_trnTRANS_UPDATE", FileType.SubFile); 
fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0,	"m_trnTRANS_UPDATE"); 
fleU704_LAST_VISIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U704_LAST_VISIT", "", false, false, false, 0,			"m_trnTRANS_UPDATE", FileType.SubFile); 


	}


    #region "Declarations (Variables, Files and Transactions)(U704A_SELECT_CLMDTL_2)"

    private SqlFileObject fleU704_CLMHDR;
    private SqlFileObject fleF002_SUSPEND_DTL;





















    private SqlFileObject fleU704_LAST_VISIT;


    #endregion


    #region "Standard Generated Procedures(U704A_SELECT_CLMDTL_2)"


    #region "Automatic Item Initialization(U704A_SELECT_CLMDTL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U704A_SELECT_CLMDTL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:50 PM

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
        fleU704_CLMHDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU704_LAST_VISIT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U704A_SELECT_CLMDTL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:50 PM

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
            fleU704_CLMHDR.Dispose();
            fleF002_SUSPEND_DTL.Dispose();
            fleU704_LAST_VISIT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U704A_SELECT_CLMDTL_2)"


    public void Run()
    {

        try
        {
            Request("SELECT_CLMDTL_2");

            while (fleU704_CLMHDR.QTPForMissing())
            {
                // --> GET U704_CLMHDR <--

                fleU704_CLMHDR.GetData();
                // --> End GET U704_CLMHDR <--

                while (fleF002_SUSPEND_DTL.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_DTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleU704_CLMHDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU704_CLMHDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_DTL.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_DTL <--


                    if (Transaction())
                    {

                        Sort(fleU704_CLMHDR.GetSortValue("CLMHDR_PAT_OHIP_ID_OR_CHART"), fleF002_SUSPEND_DTL.GetSortValue("CLMDTL_SV_YY"), fleF002_SUSPEND_DTL.GetSortValue("CLMDTL_SV_YY_ALPHA"), fleF002_SUSPEND_DTL.GetSortValue("CLMDTL_SV_MM"), fleF002_SUSPEND_DTL.GetSortValue("CLMDTL_SV_MM_ALPHA"), fleF002_SUSPEND_DTL.GetSortValue("CLMDTL_SV_DD"), fleF002_SUSPEND_DTL.GetSortValue("CLMDTL_SV_DD_ALPHA"));



                    }

                }

            }


            while (Sort(fleU704_CLMHDR, fleF002_SUSPEND_DTL))
            {




















                SubFile(ref m_trnTRANS_UPDATE, ref fleU704_LAST_VISIT, fleU704_CLMHDR.At("CLMHDR_PAT_OHIP_ID_OR_CHART"), SubFileType.Keep, fleU704_CLMHDR, "CLMHDR_PAT_OHIP_ID_OR_CHART", fleF002_SUSPEND_DTL, "CLMDTL_SV_DATE");
                


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
            EndRequest("SELECT_CLMDTL_2");

        }

    }




    #endregion


}
//SELECT_CLMDTL_2



public class U704A_UPDATE_PATIENTS_3 : U704A
{

    public U704A_UPDATE_PATIENTS_3(string Name, int Level)
        : base(Name, Level, true)
	{
		this.ScreenType = ScreenTypes.QTP;
fleU704_LAST_VISIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U704_LAST_VISIT", "", false, false, false, 0,			"m_trnTRANS_UPDATE", FileType.SubFile); 
fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0,	"m_trnTRANS_UPDATE"); 
XCOUNT = new CoreDecimal("XCOUNT", 6, this); 
fleU704A_F010_BEFORE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U704A_F010_BEFORE", "", false, false, false, 0,			"m_trnTRANS_UPDATE", FileType.SubFile); 

fleF010_PAT_MSTR.SetItemFinals += fleF010_PAT_MSTR_SetItemFinals;
VISIT_DATE.GetValue += VISIT_DATE_GetValue;

	}


    #region "Declarations (Variables, Files and Transactions)(U704A_UPDATE_PATIENTS_3)"

    private SqlFileObject fleU704_LAST_VISIT;
    private SqlFileObject fleF010_PAT_MSTR;

    private void fleF010_PAT_MSTR_SetItemFinals()
    {

        try
        {
            fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_VISIT", VISIT_DATE.Value);
            fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_VISIT", VISIT_DATE.Value);


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

    private CoreDecimal XCOUNT;
    private DDecimal VISIT_DATE = new DDecimal("VISIT_DATE");
    private void VISIT_DATE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU704_LAST_VISIT.GetStringValue("CLMDTL_SV_DATE")) != "????????")
            {
                CurrentValue = QDesign.NConvert(fleU704_LAST_VISIT.GetStringValue("CLMDTL_SV_DATE"));
            }
            else
            {
                CurrentValue = QDesign.SysDate(ref m_cnnQUERY);
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






















    private SqlFileObject fleU704A_F010_BEFORE;


    #endregion


    #region "Standard Generated Procedures(U704A_UPDATE_PATIENTS_3)"


    #region "Automatic Item Initialization(U704A_UPDATE_PATIENTS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U704A_UPDATE_PATIENTS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:50 PM

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
        fleU704_LAST_VISIT.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU704A_F010_BEFORE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U704A_UPDATE_PATIENTS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:50 PM

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
            fleU704_LAST_VISIT.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleU704A_F010_BEFORE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U704A_UPDATE_PATIENTS_3)"


    public void Run()
    {

        try
        {
            Request("UPDATE_PATIENTS_3");

            while (fleU704_LAST_VISIT.QTPForMissing())
            {
                // --> GET U704_LAST_VISIT <--

                fleU704_LAST_VISIT.GetData();
                // --> End GET U704_LAST_VISIT <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleU704_LAST_VISIT.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(0, 1)));
                    
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleU704_LAST_VISIT.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(1, 2)));
                    
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleU704_LAST_VISIT.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(3, 12)));
                    
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleU704_LAST_VISIT.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(15, 1)));
                    

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F010_PAT_MSTR <--


                    if (Transaction())
                    {
                        XCOUNT.Value = XCOUNT.Value + 1;

                        SubFile(ref m_trnTRANS_UPDATE, ref fleU704A_F010_BEFORE, SubFileType.Keep, XCOUNT, fleU704_LAST_VISIT, "CLMDTL_SV_DATE", VISIT_DATE, fleF010_PAT_MSTR);
                        


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
            EndRequest("UPDATE_PATIENTS_3");

        }

    }




    #endregion


}
//UPDATE_PATIENTS_3




