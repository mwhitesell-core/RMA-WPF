
#region "Screen Comments"

// PROGRAM-ID.   UTL0020A_1.qts
// ((C)) Dyad Technologies
// R.M.A. VERSION
// PROGRAM PURPOSE :
// - extract data from the payroll system and download to 
// PC for upload into spreadsheet
// - in this program individual requests gather different
// information for the doctor and place it into a 
// unique record for the doctor within 
// file tmp-pc-download-file 
// MODIFICATION HISTORY
// DATE   WHO   DESCRIPTION
// 2003/SEP/25 b.e - re-write logic so that information is gathered into a unique
// record within file tmp-pc-download-file for each doctor
// - that file is then downloaded to the PC and places 
// into spreadsheet
// 2003/sep/28 b.e.- incorporate new fields after RMA requested changes
// use mtd paypot + ytdear instead of ytd paypot
// 2003/oct/05 b.e. - new selection criteria - added doc start date to extract
// 2003/oct/07 b.e. - added depchr
// 2003/oct/14 b.e. - added doctor classification (full/partime ind)
// - added PED of clinic 22
// - added subfile to save costing ped and pass to further proc`s
// 2003/dec/24 A.A. - alpha doctor nbr
// 2004/jul/21 b.e. - numerous data conversion errors and then final core dump
// so increased stacksize from 10000 to 15000 core dump
// error disappeared
// - added choose statement to select only rec 6
// 2004/sep/29 b.e.  added doc-nbr, ep-nbr to subfile debug_utl0020a
// 2006/sep/15 b.e. - split utl0020a.qts into _1 and _2 .. _1 contains the
// original logic while access of all revenue compensation
// codes was put into _2.qts
// 2006/oct/03 b.e. - added access to PAYEFT trans in f119 to add to tmp file
// 2006/nov/28 b.e. - added RMAEXR(rmaexr) and GST(gst) to file
// 2006/nov/30 b.e. - added BILL(bill) to file for selection of docs to download
// 2007/feb/19 b.e. - added RMAEXM(rmaexm)
// 2008/oct/28 brad1 - change select to pick only rec-type  A  records from f119 as the  C , D  hidden records were being 
// included in download and shouldn`t  have been


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0020A_1 : BaseClassControl
{

    private UTL0020A_1 m_UTL0020A_1;

    public UTL0020A_1(string Name, int Level) : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_FISCAL_START_YYMMDD = new CoreDate("W_CURRENT_FISCAL_START_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_FISCAL_END_YYMMDD = new CoreDate("W_CURRENT_FISCAL_END_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_CUTOFF_YYMMDD = new CoreDate("W_CURRENT_COSTING_CUTOFF_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED = new CoreDate("W_CURRENT_COSTING_PED", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED_YYMM = new CoreDecimal("W_CURRENT_COSTING_PED_YYMM", 6, this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_START_YYMMDD = new CoreDate("W_PREVIOUS_FISCAL_START_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_END_YYMMDD = new CoreDate("W_PREVIOUS_FISCAL_END_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_EP_YR = new CoreDecimal("W_EP_YR", 2, this, ResetTypes.ResetAtStartup);


    }

    public UTL0020A_1(string Name, int Level, bool Request) : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_FISCAL_START_YYMMDD = new CoreDate("W_CURRENT_FISCAL_START_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_FISCAL_END_YYMMDD = new CoreDate("W_CURRENT_FISCAL_END_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_CUTOFF_YYMMDD = new CoreDate("W_CURRENT_COSTING_CUTOFF_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED = new CoreDate("W_CURRENT_COSTING_PED", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED_YYMM = new CoreDecimal("W_CURRENT_COSTING_PED_YYMM", 6, this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_START_YYMMDD = new CoreDate("W_PREVIOUS_FISCAL_START_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_END_YYMMDD = new CoreDate("W_PREVIOUS_FISCAL_END_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_EP_YR = new CoreDecimal("W_EP_YR", 2, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_UTL0020A_1 != null))
        {
            m_UTL0020A_1.CloseTransactionObjects();
            m_UTL0020A_1 = null;
        }
    }

    public UTL0020A_1 GetUTL0020A_1(int Level)
    {
        if (m_UTL0020A_1 == null)
        {
            m_UTL0020A_1 = new UTL0020A_1("UTL0020A_1", Level);
        }
        else
        {
            m_UTL0020A_1.ResetValues();
        }
        return m_UTL0020A_1;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDate W_CURRENT_FISCAL_START_YYMMDD;
    protected CoreDate W_CURRENT_FISCAL_END_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_CUTOFF_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_PED;
    protected CoreDecimal W_CURRENT_COSTING_PED_YYMM;
    protected CoreDate W_PREVIOUS_FISCAL_START_YYMMDD;
    protected CoreDate W_PREVIOUS_FISCAL_END_YYMMDD;

    protected CoreDecimal W_EP_YR;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            UTL0020A_1_COSTING1_GET_REC_7_1 COSTING1_GET_REC_7_1 = new UTL0020A_1_COSTING1_GET_REC_7_1(Name, Level);
            COSTING1_GET_REC_7_1.Run();
            COSTING1_GET_REC_7_1.Dispose();
            COSTING1_GET_REC_7_1 = null;

            UTL0020A_1_DOWNLOAD_DOC_1_2 DOWNLOAD_DOC_1_2 = new UTL0020A_1_DOWNLOAD_DOC_1_2(Name, Level);
            DOWNLOAD_DOC_1_2.Run();
            DOWNLOAD_DOC_1_2.Dispose();
            DOWNLOAD_DOC_1_2 = null;

            UTL0020A_1_DOWNLOAD_DOC_2_3 DOWNLOAD_DOC_2_3 = new UTL0020A_1_DOWNLOAD_DOC_2_3(Name, Level);
            DOWNLOAD_DOC_2_3.Run();
            DOWNLOAD_DOC_2_3.Dispose();
            DOWNLOAD_DOC_2_3 = null;

            UTL0020A_1_DOWNLOAD_DOC_3_4 DOWNLOAD_DOC_3_4 = new UTL0020A_1_DOWNLOAD_DOC_3_4(Name, Level);
            DOWNLOAD_DOC_3_4.Run();
            DOWNLOAD_DOC_3_4.Dispose();
            DOWNLOAD_DOC_3_4 = null;

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



public class UTL0020A_1_COSTING1_GET_REC_7_1 : UTL0020A_1
{

    public UTL0020A_1_COSTING1_GET_REC_7_1(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_FISCAL_START_YYMMDD = new CoreDate("W_CURRENT_FISCAL_START_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_FISCAL_END_YYMMDD = new CoreDate("W_CURRENT_FISCAL_END_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_CUTOFF_YYMMDD = new CoreDate("W_CURRENT_COSTING_CUTOFF_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED = new CoreDate("W_CURRENT_COSTING_PED", this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED_YYMM = new CoreDecimal("W_CURRENT_COSTING_PED_YYMM", 6, this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_START_YYMMDD = new CoreDate("W_PREVIOUS_FISCAL_START_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_END_YYMMDD = new CoreDate("W_PREVIOUS_FISCAL_END_YYMMDD", this, ResetTypes.ResetAtStartup);
        W_EP_YR = new CoreDecimal("W_EP_YR", 2, this, ResetTypes.ResetAtStartup);
        fleCONSTANTS_MSTR_REC_7 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_7", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(UTL0020A_1_COSTING1_GET_REC_7_1)"

    protected CoreDate W_CURRENT_FISCAL_START_YYMMDD;
    protected CoreDate W_CURRENT_FISCAL_END_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_CUTOFF_YYMMDD;
    protected CoreDate W_CURRENT_COSTING_PED;
    protected CoreDecimal W_CURRENT_COSTING_PED_YYMM;
    protected CoreDate W_PREVIOUS_FISCAL_START_YYMMDD;
    protected CoreDate W_PREVIOUS_FISCAL_END_YYMMDD;
    protected CoreDecimal W_EP_YR;
    private SqlFileObject fleCONSTANTS_MSTR_REC_7;


    #endregion


    #region "Standard Generated Procedures(UTL0020A_1_COSTING1_GET_REC_7_1)"


    #region "Automatic Item Initialization(UTL0020A_1_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0020A_1_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 7/19/2017 8:20:28 AM

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
        fleCONSTANTS_MSTR_REC_7.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0020A_1_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 7/19/2017 8:20:28 AM

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
            fleCONSTANTS_MSTR_REC_7.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0020A_1_COSTING1_GET_REC_7_1)"


    public void Run()
    {

        try
        {
            Request("COSTING1_GET_REC_7_1");

            while (fleCONSTANTS_MSTR_REC_7.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_7 <--

                fleCONSTANTS_MSTR_REC_7.GetData();
                // --> End GET CONSTANTS_MSTR_REC_7 <--

                if (Transaction())
                {
                    W_CURRENT_FISCAL_START_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_FISCAL_START_YYMMDD");
                    W_CURRENT_FISCAL_END_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_FISCAL_END_YYMMDD");
                    W_CURRENT_COSTING_CUTOFF_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_COSTING_CUTOFF_YYMMDD");
                    W_CURRENT_COSTING_PED.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_COSTING_PED");
                    W_CURRENT_COSTING_PED_YYMM.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_COSTING_PED") / 100;
                    W_PREVIOUS_FISCAL_START_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("PREVIOUS_FISCAL_START_YYMMDD");
                    W_PREVIOUS_FISCAL_END_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("PREVIOUS_FISCAL_END_YYMMDD");
                    W_EP_YR.Value = fleCONSTANTS_MSTR_REC_7.GetDecimalValue("EP_YR");

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
            EndRequest("COSTING1_GET_REC_7_1");

        }

    }







    #endregion


}
//COSTING1_GET_REC_7_1



public class UTL0020A_1_DOWNLOAD_DOC_1_2 : UTL0020A_1
{

    public UTL0020A_1_DOWNLOAD_DOC_1_2(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_TOTINC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_TOTINC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_INCEXP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_INCEXP", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_PAYPOT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_PAYPOT", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_YTDEAR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_YTDEAR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_GTYPEA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_GTYPEA", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_DEPEXM = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_DEPEXM", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_DEPEXR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_DEPEXR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_DEPCHR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_DEPCHR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_PAYEFT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_PAYEFT", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_RMAEXR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_RMAEXR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_RMAEXM = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_RMAEXM", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_GST = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_GST", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleTMP_PC_DOWNLOAD_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_PC_DOWNLOAD_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0020A_PARMS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0020A_PARMS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        X_CURRENT_EP_NBR_MINUS_1.GetValue += X_CURRENT_EP_NBR_MINUS_1_GetValue;
        fleTMP_PC_DOWNLOAD_FILE.SetItemFinals += fleTMP_PC_DOWNLOAD_FILE_SetItemFinals;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;
        fleF119_TOTINC.InitializeItems += fleF119_TOTINC_AutomaticItemInitialization;
        fleF119_INCEXP.InitializeItems += fleF119_INCEXP_AutomaticItemInitialization;
        fleF119_PAYPOT.InitializeItems += fleF119_PAYPOT_AutomaticItemInitialization;
        fleF119_YTDEAR.InitializeItems += fleF119_YTDEAR_AutomaticItemInitialization;
        fleF119_GTYPEA.InitializeItems += fleF119_GTYPEA_AutomaticItemInitialization;
        fleF119_DEPEXM.InitializeItems += fleF119_DEPEXM_AutomaticItemInitialization;
        fleF119_DEPEXR.InitializeItems += fleF119_DEPEXR_AutomaticItemInitialization;
        fleF119_DEPCHR.InitializeItems += fleF119_DEPCHR_AutomaticItemInitialization;
        fleF119_PAYEFT.InitializeItems += fleF119_PAYEFT_AutomaticItemInitialization;
        fleF119_RMAEXR.InitializeItems += fleF119_RMAEXR_AutomaticItemInitialization;
        fleF119_RMAEXM.InitializeItems += fleF119_RMAEXM_AutomaticItemInitialization;
        fleF119_GST.InitializeItems += fleF119_GST_AutomaticItemInitialization;
        fleTMP_PC_DOWNLOAD_FILE.InitializeItems += fleTMP_PC_DOWNLOAD_FILE_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0020A_1_DOWNLOAD_DOC_1_2)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleICONST_MSTR_REC;
    private SqlFileObject fleF112_PYCDCEILINGS;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020_DOCTOR_EXTRA;
    private SqlFileObject fleF119_TOTINC;
    private SqlFileObject fleF119_INCEXP;
    private SqlFileObject fleF119_PAYPOT;
    private SqlFileObject fleF119_YTDEAR;
    private SqlFileObject fleF119_GTYPEA;
    private SqlFileObject fleF119_DEPEXM;
    private SqlFileObject fleF119_DEPEXR;
    private SqlFileObject fleF119_DEPCHR;
    private SqlFileObject fleF119_PAYEFT;
    private SqlFileObject fleF119_RMAEXR;
    private SqlFileObject fleF119_RMAEXM;
    private SqlFileObject fleF119_GST;

    private void fleCONSTANTS_MSTR_REC_6_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
            strSQL.Append(6);


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

    private DDecimal X_CURRENT_EP_NBR_MINUS_1 = new DDecimal("X_CURRENT_EP_NBR_MINUS_1", 6);
    private void X_CURRENT_EP_NBR_MINUS_1_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1;


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
    private SqlFileObject fleTMP_PC_DOWNLOAD_FILE;

    private void fleTMP_PC_DOWNLOAD_FILE_SetItemFinals()
    {

        try
        {
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("CURRENT_EP_NBR", X_CURRENT_EP_NBR_MINUS_1.Value);
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_NBR", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_NAME", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_INITS", fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));
            //Parent:DOC_INITS
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_DEPT", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_OHIP_NBR", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_SIN_NBR", fleF020_DOCTOR_MSTR.GetStringValue("DOC_SIN_123").Trim().PadLeft(3,'0') + fleF020_DOCTOR_MSTR.GetStringValue("DOC_SIN_456").PadLeft(3, '0').Trim() + fleF020_DOCTOR_MSTR.GetStringValue("DOC_SIN_789").PadLeft(3, '0').Trim());
            //fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_CLINIC_NBR", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_SPEC_CD", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_YRLY_CEILING_COMPUTED", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_DATE_FAC_START", Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD").ToString().PadLeft(2, '0')));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_DATE_FAC_TERM", Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0')));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_FULL_PART_IND", fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_PAY_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_PAY_SUB_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_YTD_TOTINC", fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_YTD_INCEXP", fleF119_INCEXP.GetDecimalValue("AMT_YTD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_MTD_PAYPOT", fleF119_PAYPOT.GetDecimalValue("AMT_MTD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_YTD_YTDEAR", fleF119_YTDEAR.GetDecimalValue("AMT_YTD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_YTD_DEPEXM", fleF119_DEPEXM.GetDecimalValue("AMT_YTD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_MTD_PAYEFT", fleF119_PAYEFT.GetDecimalValue("AMT_MTD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_MTD_GTYPEA", fleF119_GTYPEA.GetDecimalValue("AMT_MTD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_YTD_DEPEXR", fleF119_DEPEXR.GetDecimalValue("AMT_YTD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_YTD_DEPCHR", fleF119_DEPCHR.GetDecimalValue("AMT_YTD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_YTD_RMAEXR", fleF119_RMAEXR.GetDecimalValue("AMT_YTD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_YTD_GST", fleF119_GST.GetDecimalValue("AMT_YTD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMT_YTD_RMAEXM", fleF119_RMAEXM.GetDecimalValue("AMT_YTD"));


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




    private SqlFileObject fleUTL0020A_PARMS;


    #endregion


    #region "Standard Generated Procedures(UTL0020A_1_DOWNLOAD_DOC_1_2)"


    #region "Automatic Item Initialization(UTL0020A_1_DOWNLOAD_DOC_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 7/19/2017 8:20:30 AM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));

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
    //# fleF020_DOCTOR_EXTRA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF020_DOCTOR_EXTRA_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));

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
    //# fleF119_TOTINC_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF119_TOTINC_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_TOTINC.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_TOTINC.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_TOTINC.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_TOTINC.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_TOTINC.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_TOTINC.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));

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
    //# fleF119_INCEXP_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF119_INCEXP_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_INCEXP.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_INCEXP.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_INCEXP.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_INCEXP.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_INCEXP.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_INCEXP.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_INCEXP.set_SetValue("COMP_CODE", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE"));
            fleF119_INCEXP.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF119_INCEXP.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE_GROUP"));
            fleF119_INCEXP.set_SetValue("REC_TYPE", !Fixed, fleF119_TOTINC.GetStringValue("REC_TYPE"));
            fleF119_INCEXP.set_SetValue("REC_1", !Fixed, fleF119_TOTINC.GetStringValue("REC_1"));
            fleF119_INCEXP.set_SetValue("AMT_MTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_MTD"));
            fleF119_INCEXP.set_SetValue("AMT_YTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleF119_INCEXP.set_SetValue("TEXT", !Fixed, fleF119_TOTINC.GetStringValue("TEXT"));

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
    //# fleF119_PAYPOT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF119_PAYPOT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_PAYPOT.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_PAYPOT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_PAYPOT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_PAYPOT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_PAYPOT.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_PAYPOT.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_PAYPOT.set_SetValue("COMP_CODE", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE"));
            fleF119_PAYPOT.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF119_PAYPOT.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE_GROUP"));
            fleF119_PAYPOT.set_SetValue("REC_TYPE", !Fixed, fleF119_TOTINC.GetStringValue("REC_TYPE"));
            fleF119_PAYPOT.set_SetValue("REC_1", !Fixed, fleF119_TOTINC.GetStringValue("REC_1"));
            fleF119_PAYPOT.set_SetValue("AMT_MTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_MTD"));
            fleF119_PAYPOT.set_SetValue("AMT_YTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleF119_PAYPOT.set_SetValue("TEXT", !Fixed, fleF119_TOTINC.GetStringValue("TEXT"));

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
    //# fleF119_YTDEAR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF119_YTDEAR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_YTDEAR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_YTDEAR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_YTDEAR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_YTDEAR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_YTDEAR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_YTDEAR.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_YTDEAR.set_SetValue("COMP_CODE", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE"));
            fleF119_YTDEAR.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF119_YTDEAR.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE_GROUP"));
            fleF119_YTDEAR.set_SetValue("REC_TYPE", !Fixed, fleF119_TOTINC.GetStringValue("REC_TYPE"));
            fleF119_YTDEAR.set_SetValue("REC_1", !Fixed, fleF119_TOTINC.GetStringValue("REC_1"));
            fleF119_YTDEAR.set_SetValue("AMT_MTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_MTD"));
            fleF119_YTDEAR.set_SetValue("AMT_YTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleF119_YTDEAR.set_SetValue("TEXT", !Fixed, fleF119_TOTINC.GetStringValue("TEXT"));

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
    //# fleF119_GTYPEA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF119_GTYPEA_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_GTYPEA.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_GTYPEA.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_GTYPEA.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_GTYPEA.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_GTYPEA.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_GTYPEA.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_GTYPEA.set_SetValue("COMP_CODE", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE"));
            fleF119_GTYPEA.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF119_GTYPEA.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE_GROUP"));
            fleF119_GTYPEA.set_SetValue("REC_TYPE", !Fixed, fleF119_TOTINC.GetStringValue("REC_TYPE"));
            fleF119_GTYPEA.set_SetValue("REC_1", !Fixed, fleF119_TOTINC.GetStringValue("REC_1"));
            fleF119_GTYPEA.set_SetValue("AMT_MTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_MTD"));
            fleF119_GTYPEA.set_SetValue("AMT_YTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleF119_GTYPEA.set_SetValue("TEXT", !Fixed, fleF119_TOTINC.GetStringValue("TEXT"));

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
    //# fleF119_DEPEXM_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF119_DEPEXM_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_DEPEXM.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_DEPEXM.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_DEPEXM.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_DEPEXM.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_DEPEXM.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_DEPEXM.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_DEPEXM.set_SetValue("COMP_CODE", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE"));
            fleF119_DEPEXM.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF119_DEPEXM.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE_GROUP"));
            fleF119_DEPEXM.set_SetValue("REC_TYPE", !Fixed, fleF119_TOTINC.GetStringValue("REC_TYPE"));
            fleF119_DEPEXM.set_SetValue("REC_1", !Fixed, fleF119_TOTINC.GetStringValue("REC_1"));
            fleF119_DEPEXM.set_SetValue("AMT_MTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_MTD"));
            fleF119_DEPEXM.set_SetValue("AMT_YTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleF119_DEPEXM.set_SetValue("TEXT", !Fixed, fleF119_TOTINC.GetStringValue("TEXT"));

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
    //# fleF119_DEPEXR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF119_DEPEXR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_DEPEXR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_DEPEXR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_DEPEXR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_DEPEXR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_DEPEXR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_DEPEXR.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_DEPEXR.set_SetValue("COMP_CODE", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE"));
            fleF119_DEPEXR.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF119_DEPEXR.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE_GROUP"));
            fleF119_DEPEXR.set_SetValue("REC_TYPE", !Fixed, fleF119_TOTINC.GetStringValue("REC_TYPE"));
            fleF119_DEPEXR.set_SetValue("REC_1", !Fixed, fleF119_TOTINC.GetStringValue("REC_1"));
            fleF119_DEPEXR.set_SetValue("AMT_MTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_MTD"));
            fleF119_DEPEXR.set_SetValue("AMT_YTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleF119_DEPEXR.set_SetValue("TEXT", !Fixed, fleF119_TOTINC.GetStringValue("TEXT"));

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
    //# fleF119_DEPCHR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF119_DEPCHR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_DEPCHR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_DEPCHR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_DEPCHR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_DEPCHR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_DEPCHR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_DEPCHR.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_DEPCHR.set_SetValue("COMP_CODE", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE"));
            fleF119_DEPCHR.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF119_DEPCHR.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE_GROUP"));
            fleF119_DEPCHR.set_SetValue("REC_TYPE", !Fixed, fleF119_TOTINC.GetStringValue("REC_TYPE"));
            fleF119_DEPCHR.set_SetValue("REC_1", !Fixed, fleF119_TOTINC.GetStringValue("REC_1"));
            fleF119_DEPCHR.set_SetValue("AMT_MTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_MTD"));
            fleF119_DEPCHR.set_SetValue("AMT_YTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleF119_DEPCHR.set_SetValue("TEXT", !Fixed, fleF119_TOTINC.GetStringValue("TEXT"));

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
    //# fleF119_PAYEFT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF119_PAYEFT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_PAYEFT.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_PAYEFT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_PAYEFT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_PAYEFT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_PAYEFT.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_PAYEFT.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_PAYEFT.set_SetValue("COMP_CODE", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE"));
            fleF119_PAYEFT.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF119_PAYEFT.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE_GROUP"));
            fleF119_PAYEFT.set_SetValue("REC_TYPE", !Fixed, fleF119_TOTINC.GetStringValue("REC_TYPE"));
            fleF119_PAYEFT.set_SetValue("REC_1", !Fixed, fleF119_TOTINC.GetStringValue("REC_1"));
            fleF119_PAYEFT.set_SetValue("AMT_MTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_MTD"));
            fleF119_PAYEFT.set_SetValue("AMT_YTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleF119_PAYEFT.set_SetValue("TEXT", !Fixed, fleF119_TOTINC.GetStringValue("TEXT"));

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
    //# fleF119_RMAEXR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF119_RMAEXR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_RMAEXR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_RMAEXR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_RMAEXR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_RMAEXR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_RMAEXR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_RMAEXR.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_RMAEXR.set_SetValue("COMP_CODE", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE"));
            fleF119_RMAEXR.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF119_RMAEXR.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE_GROUP"));
            fleF119_RMAEXR.set_SetValue("REC_TYPE", !Fixed, fleF119_TOTINC.GetStringValue("REC_TYPE"));
            fleF119_RMAEXR.set_SetValue("REC_1", !Fixed, fleF119_TOTINC.GetStringValue("REC_1"));
            fleF119_RMAEXR.set_SetValue("AMT_MTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_MTD"));
            fleF119_RMAEXR.set_SetValue("AMT_YTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleF119_RMAEXR.set_SetValue("TEXT", !Fixed, fleF119_TOTINC.GetStringValue("TEXT"));

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
    //# fleF119_RMAEXM_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:29 AM
    //#-----------------------------------------
    private void fleF119_RMAEXM_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_RMAEXM.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_RMAEXM.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_RMAEXM.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_RMAEXM.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_RMAEXM.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_RMAEXM.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_RMAEXM.set_SetValue("COMP_CODE", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE"));
            fleF119_RMAEXM.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF119_RMAEXM.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE_GROUP"));
            fleF119_RMAEXM.set_SetValue("REC_TYPE", !Fixed, fleF119_TOTINC.GetStringValue("REC_TYPE"));
            fleF119_RMAEXM.set_SetValue("REC_1", !Fixed, fleF119_TOTINC.GetStringValue("REC_1"));
            fleF119_RMAEXM.set_SetValue("AMT_MTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_MTD"));
            fleF119_RMAEXM.set_SetValue("AMT_YTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleF119_RMAEXM.set_SetValue("TEXT", !Fixed, fleF119_TOTINC.GetStringValue("TEXT"));

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
    //# fleF119_GST_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:30 AM
    //#-----------------------------------------
    private void fleF119_GST_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_GST.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF119_GST.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_GST.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_GST.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF119_GST.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            //TODO: Manual steps may be required.
            fleF119_GST.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF119_GST.set_SetValue("COMP_CODE", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE"));
            fleF119_GST.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF119_GST.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_TOTINC.GetStringValue("COMP_CODE_GROUP"));
            fleF119_GST.set_SetValue("REC_TYPE", !Fixed, fleF119_TOTINC.GetStringValue("REC_TYPE"));
            fleF119_GST.set_SetValue("REC_1", !Fixed, fleF119_TOTINC.GetStringValue("REC_1"));
            fleF119_GST.set_SetValue("AMT_MTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_MTD"));
            fleF119_GST.set_SetValue("AMT_YTD", !Fixed, fleF119_TOTINC.GetDecimalValue("AMT_YTD"));
            fleF119_GST.set_SetValue("TEXT", !Fixed, fleF119_TOTINC.GetStringValue("TEXT"));

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
    //# fleTMP_PC_DOWNLOAD_FILE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:30 AM
    //#-----------------------------------------
    private void fleTMP_PC_DOWNLOAD_FILE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_PAY_CODE", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_PAY_SUB_CODE", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            //TODO: Manual steps may be required.
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            //TODO: Manual steps may be required.
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", !Fixed, fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE"));

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


    #region "Transaction Management Procedures(UTL0020A_1_DOWNLOAD_DOC_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 7/19/2017 8:20:28 AM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleF119_TOTINC.Transaction = m_trnTRANS_UPDATE;
        fleF119_INCEXP.Transaction = m_trnTRANS_UPDATE;
        fleF119_PAYPOT.Transaction = m_trnTRANS_UPDATE;
        fleF119_YTDEAR.Transaction = m_trnTRANS_UPDATE;
        fleF119_GTYPEA.Transaction = m_trnTRANS_UPDATE;
        fleF119_DEPEXM.Transaction = m_trnTRANS_UPDATE;
        fleF119_DEPEXR.Transaction = m_trnTRANS_UPDATE;
        fleF119_DEPCHR.Transaction = m_trnTRANS_UPDATE;
        fleF119_PAYEFT.Transaction = m_trnTRANS_UPDATE;
        fleF119_RMAEXR.Transaction = m_trnTRANS_UPDATE;
        fleF119_RMAEXM.Transaction = m_trnTRANS_UPDATE;
        fleF119_GST.Transaction = m_trnTRANS_UPDATE;
        fleTMP_PC_DOWNLOAD_FILE.Transaction = m_trnTRANS_UPDATE;
        fleUTL0020A_PARMS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0020A_1_DOWNLOAD_DOC_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 7/19/2017 8:20:28 AM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF112_PYCDCEILINGS.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF020_DOCTOR_EXTRA.Dispose();
            fleF119_TOTINC.Dispose();
            fleF119_INCEXP.Dispose();
            fleF119_PAYPOT.Dispose();
            fleF119_YTDEAR.Dispose();
            fleF119_GTYPEA.Dispose();
            fleF119_DEPEXM.Dispose();
            fleF119_DEPEXR.Dispose();
            fleF119_DEPCHR.Dispose();
            fleF119_PAYEFT.Dispose();
            fleF119_RMAEXR.Dispose();
            fleF119_RMAEXM.Dispose();
            fleF119_GST.Dispose();
            fleTMP_PC_DOWNLOAD_FILE.Dispose();
            fleUTL0020A_PARMS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0020A_1_DOWNLOAD_DOC_1_2)"


    public void Run()
    {

        try
        {
            Request("DOWNLOAD_DOC_1_2");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("CONST_CLINIC_NBR_1_21")).Append(" = ");
                    m_strWhere.Append((22));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--

                    while (fleF112_PYCDCEILINGS.QTPForMissing("2"))
                    {
                        // --> GET F112_PYCDCEILINGS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                        m_strWhere.Append(((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1)));

                        m_strOrderBy = new StringBuilder(" ORDER BY ");
                        m_strOrderBy.Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR"));
                        m_strOrderBy.Append(", ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR"));

                        fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                        // --> End GET F112_PYCDCEILINGS <--

                        while (fleF020_DOCTOR_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                            // --> End GET F020_DOCTOR_MSTR <--

                            while (fleF020_DOCTOR_EXTRA.QTPForMissing("4"))
                            {
                                // --> GET F020_DOCTOR_EXTRA <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                                fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F020_DOCTOR_EXTRA <--

                                while (fleF119_TOTINC.QTPForMissing("5"))
                                {
                                    // --> GET F119_TOTINC <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF119_TOTINC.ElementOwner("DOC_NBR")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                    m_strWhere.Append(" And ").Append(fleF119_TOTINC.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                    m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                    m_strWhere.Append(" And ").Append(fleF119_TOTINC.ElementOwner("COMP_CODE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField("TOTINC"));
                                    m_strWhere.Append(" And ").Append(fleF119_TOTINC.ElementOwner("REC_TYPE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField("A"));

                                    fleF119_TOTINC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F119_TOTINC <--

                                    while (fleF119_INCEXP.QTPForMissing("6"))
                                    {
                                        // --> GET F119_INCEXP <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleF119_INCEXP.ElementOwner("DOC_NBR")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                        m_strWhere.Append(" And ").Append(fleF119_INCEXP.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                        m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                        m_strWhere.Append(" And ").Append(fleF119_INCEXP.ElementOwner("COMP_CODE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField("INCEXP"));
                                        m_strWhere.Append(" And ").Append(fleF119_INCEXP.ElementOwner("REC_TYPE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField("A"));

                                        fleF119_INCEXP.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                        // --> End GET F119_INCEXP <--

                                        while (fleF119_PAYPOT.QTPForMissing("7"))
                                        {
                                            // --> GET F119_PAYPOT <--
                                            m_strWhere = new StringBuilder(" WHERE ");
                                            m_strWhere.Append(" ").Append(fleF119_PAYPOT.ElementOwner("DOC_NBR")).Append(" = ");
                                            m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                            m_strWhere.Append(" And ").Append(fleF119_PAYPOT.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                            m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                            m_strWhere.Append(" And ").Append(fleF119_PAYPOT.ElementOwner("COMP_CODE")).Append(" = ");
                                            m_strWhere.Append(Common.StringToField("PAYPOT"));
                                            m_strWhere.Append(" And ").Append(fleF119_PAYPOT.ElementOwner("REC_TYPE")).Append(" = ");
                                            m_strWhere.Append(Common.StringToField("A"));

                                            fleF119_PAYPOT.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                            // --> End GET F119_PAYPOT <--

                                            while (fleF119_YTDEAR.QTPForMissing("8"))
                                            {
                                                // --> GET F119_YTDEAR <--
                                                m_strWhere = new StringBuilder(" WHERE ");
                                                m_strWhere.Append(" ").Append(fleF119_YTDEAR.ElementOwner("DOC_NBR")).Append(" = ");
                                                m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                                m_strWhere.Append(" And ").Append(fleF119_YTDEAR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                                m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                                m_strWhere.Append(" And ").Append(fleF119_YTDEAR.ElementOwner("COMP_CODE")).Append(" = ");
                                                m_strWhere.Append(Common.StringToField("YTDEAR"));
                                                m_strWhere.Append(" And ").Append(fleF119_YTDEAR.ElementOwner("REC_TYPE")).Append(" = ");
                                                m_strWhere.Append(Common.StringToField("A"));

                                                fleF119_YTDEAR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                // --> End GET F119_YTDEAR <--

                                                while (fleF119_GTYPEA.QTPForMissing("9"))
                                                {
                                                    // --> GET F119_GTYPEA <--
                                                    m_strWhere = new StringBuilder(" WHERE ");
                                                    m_strWhere.Append(" ").Append(fleF119_GTYPEA.ElementOwner("DOC_NBR")).Append(" = ");
                                                    m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                                    m_strWhere.Append(" And ").Append(fleF119_GTYPEA.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                                    m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                                    m_strWhere.Append(" And ").Append(fleF119_GTYPEA.ElementOwner("COMP_CODE")).Append(" = ");
                                                    m_strWhere.Append(Common.StringToField("GTYPEA"));
                                                    m_strWhere.Append(" And ").Append(fleF119_GTYPEA.ElementOwner("REC_TYPE")).Append(" = ");
                                                    m_strWhere.Append(Common.StringToField("A"));

                                                    fleF119_GTYPEA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                    // --> End GET F119_GTYPEA <--

                                                    while (fleF119_DEPEXM.QTPForMissing("10"))
                                                    {
                                                        // --> GET F119_DEPEXM <--
                                                        m_strWhere = new StringBuilder(" WHERE ");
                                                        m_strWhere.Append(" ").Append(fleF119_DEPEXM.ElementOwner("DOC_NBR")).Append(" = ");
                                                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                                        m_strWhere.Append(" And ").Append(fleF119_DEPEXM.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                                        m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                                        m_strWhere.Append(" And ").Append(fleF119_DEPEXM.ElementOwner("COMP_CODE")).Append(" = ");
                                                        m_strWhere.Append(Common.StringToField("DEPEXM"));
                                                        m_strWhere.Append(" And ").Append(fleF119_DEPEXM.ElementOwner("REC_TYPE")).Append(" = ");
                                                        m_strWhere.Append(Common.StringToField("A"));

                                                        fleF119_DEPEXM.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                        // --> End GET F119_DEPEXM <--

                                                        while (fleF119_DEPEXR.QTPForMissing("11"))
                                                        {
                                                            // --> GET F119_DEPEXR <--
                                                            m_strWhere = new StringBuilder(" WHERE ");
                                                            m_strWhere.Append(" ").Append(fleF119_DEPEXR.ElementOwner("DOC_NBR")).Append(" = ");
                                                            m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                                            m_strWhere.Append(" And ").Append(fleF119_DEPEXR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                                            m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                                            m_strWhere.Append(" And ").Append(fleF119_DEPEXR.ElementOwner("COMP_CODE")).Append(" = ");
                                                            m_strWhere.Append(Common.StringToField("DEPEXR"));
                                                            m_strWhere.Append(" And ").Append(fleF119_DEPEXR.ElementOwner("REC_TYPE")).Append(" = ");
                                                            m_strWhere.Append(Common.StringToField("A"));

                                                            fleF119_DEPEXR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                            // --> End GET F119_DEPEXR <--

                                                            while (fleF119_DEPCHR.QTPForMissing("12"))
                                                            {
                                                                // --> GET F119_DEPCHR <--
                                                                m_strWhere = new StringBuilder(" WHERE ");
                                                                m_strWhere.Append(" ").Append(fleF119_DEPCHR.ElementOwner("DOC_NBR")).Append(" = ");
                                                                m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                                                m_strWhere.Append(" And ").Append(fleF119_DEPCHR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                                                m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                                                m_strWhere.Append(" And ").Append(fleF119_DEPCHR.ElementOwner("COMP_CODE")).Append(" = ");
                                                                m_strWhere.Append(Common.StringToField("DEPCHR"));
                                                                m_strWhere.Append(" And ").Append(fleF119_DEPCHR.ElementOwner("REC_TYPE")).Append(" = ");
                                                                m_strWhere.Append(Common.StringToField("A"));

                                                                fleF119_DEPCHR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                                // --> End GET F119_DEPCHR <--

                                                                while (fleF119_PAYEFT.QTPForMissing("13"))
                                                                {
                                                                    // --> GET F119_PAYEFT <--
                                                                    m_strWhere = new StringBuilder(" WHERE ");
                                                                    m_strWhere.Append(" ").Append(fleF119_PAYEFT.ElementOwner("DOC_NBR")).Append(" = ");
                                                                    m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                                                    m_strWhere.Append(" And ").Append(fleF119_PAYEFT.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                                                    m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                                                    m_strWhere.Append(" And ").Append(fleF119_PAYEFT.ElementOwner("COMP_CODE")).Append(" = ");
                                                                    m_strWhere.Append(Common.StringToField("PAYEFT"));
                                                                    m_strWhere.Append(" And ").Append(fleF119_PAYEFT.ElementOwner("REC_TYPE")).Append(" = ");
                                                                    m_strWhere.Append(Common.StringToField("A"));

                                                                    fleF119_PAYEFT.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                                    // --> End GET F119_PAYEFT <--

                                                                    while (fleF119_RMAEXR.QTPForMissing("14"))
                                                                    {
                                                                        // --> GET F119_RMAEXR <--
                                                                        m_strWhere = new StringBuilder(" WHERE ");
                                                                        m_strWhere.Append(" ").Append(fleF119_RMAEXR.ElementOwner("DOC_NBR")).Append(" = ");
                                                                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                                                        m_strWhere.Append(" And ").Append(fleF119_RMAEXR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                                                        m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                                                        m_strWhere.Append(" And ").Append(fleF119_RMAEXR.ElementOwner("COMP_CODE")).Append(" = ");
                                                                        m_strWhere.Append(Common.StringToField("RMAEXR"));
                                                                        m_strWhere.Append(" And ").Append(fleF119_RMAEXR.ElementOwner("REC_TYPE")).Append(" = ");
                                                                        m_strWhere.Append(Common.StringToField("A"));

                                                                        fleF119_RMAEXR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                                        // --> End GET F119_RMAEXR <--

                                                                        while (fleF119_RMAEXM.QTPForMissing("15"))
                                                                        {
                                                                            // --> GET F119_RMAEXM <--
                                                                            m_strWhere = new StringBuilder(" WHERE ");
                                                                            m_strWhere.Append(" ").Append(fleF119_RMAEXM.ElementOwner("DOC_NBR")).Append(" = ");
                                                                            m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                                                            m_strWhere.Append(" And ").Append(fleF119_RMAEXM.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                                                            m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                                                            m_strWhere.Append(" And ").Append(fleF119_RMAEXM.ElementOwner("COMP_CODE")).Append(" = ");
                                                                            m_strWhere.Append(Common.StringToField("RMAEXM"));
                                                                            m_strWhere.Append(" And ").Append(fleF119_RMAEXM.ElementOwner("REC_TYPE")).Append(" = ");
                                                                            m_strWhere.Append(Common.StringToField("A"));

                                                                            fleF119_RMAEXM.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                                            // --> End GET F119_RMAEXM <--

                                                                            while (fleF119_GST.QTPForMissing("16"))
                                                                            {
                                                                                // --> GET F119_GST <--
                                                                                m_strWhere = new StringBuilder(" WHERE ");
                                                                                m_strWhere.Append(" ").Append(fleF119_GST.ElementOwner("DOC_NBR")).Append(" = ");
                                                                                m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                                                                m_strWhere.Append(" And ").Append(fleF119_GST.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                                                                m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));
                                                                                m_strWhere.Append(" And ").Append(fleF119_GST.ElementOwner("COMP_CODE")).Append(" = ");
                                                                                m_strWhere.Append(Common.StringToField("GST"));
                                                                                m_strWhere.Append(" And ").Append(fleF119_GST.ElementOwner("REC_TYPE")).Append(" = ");
                                                                                m_strWhere.Append(Common.StringToField("A"));

                                                                                fleF119_GST.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                                                // --> End GET F119_GST <--


                                                                                if (Transaction())
                                                                                {

                                                                                    Sort(fleICONST_MSTR_REC.GetSortValue("CONST_CLINIC_NBR_1_21"));



                                                                                }

                                                                            }

                                                                        }

                                                                    }

                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }

            while (Sort(fleCONSTANTS_MSTR_REC_6, fleICONST_MSTR_REC, fleF112_PYCDCEILINGS, fleF020_DOCTOR_MSTR, fleF020_DOCTOR_EXTRA, fleF119_TOTINC, fleF119_INCEXP, fleF119_PAYPOT, fleF119_YTDEAR, fleF119_GTYPEA,

            fleF119_DEPEXM, fleF119_DEPEXR, fleF119_DEPCHR, fleF119_PAYEFT, fleF119_RMAEXR, fleF119_RMAEXM, fleF119_GST))
            {



                fleTMP_PC_DOWNLOAD_FILE.OutPut(OutPutType.Add_Update);
                //Parent:DOC_SIN_NBR)    'Parent:DOC_INITS)    'Parent:DOC_DATE_FAC_START)    'Parent:DOC_DATE_FAC_TERM






                SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0020A_PARMS, fleICONST_MSTR_REC.At("CONST_CLINIC_NBR_1_21"), SubFileType.Keep, X_CURRENT_EP_NBR_MINUS_1);
                //Parent:DOC_SIN_NBR)    'Parent:DOC_INITS)    'Parent:DOC_DATE_FAC_START)    'Parent:DOC_DATE_FAC_TERM


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
            EndRequest("DOWNLOAD_DOC_1_2");

        }

    }




    #endregion


}
//DOWNLOAD_DOC_1_2



public class UTL0020A_1_DOWNLOAD_DOC_2_3 : UTL0020A_1
{

    public UTL0020A_1_DOWNLOAD_DOC_2_3(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleTMP_CEIEXP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_PC_DOWNLOAD_FILE", "TMP_CEIEXP", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleTMP_YTDCEX = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_PC_DOWNLOAD_FILE", "TMP_YTDCEX", false, false, false, 0, "m_trnTRANS_UPDATE");

        X_CURRENT_EP_NBR_MINUS_1.GetValue += X_CURRENT_EP_NBR_MINUS_1_GetValue;
        fleTMP_CEIEXP.SetItemFinals += fleTMP_CEIEXP_SetItemFinals;
        fleTMP_YTDCEX.SetItemFinals += fleTMP_YTDCEX_SetItemFinals;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleTMP_CEIEXP.InitializeItems += fleTMP_CEIEXP_AutomaticItemInitialization;
        fleTMP_YTDCEX.InitializeItems += fleTMP_YTDCEX_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0020A_1_DOWNLOAD_DOC_2_3)"

    private SqlFileObject fleF110_COMPENSATION;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DDecimal X_CURRENT_EP_NBR_MINUS_1 = new DDecimal("X_CURRENT_EP_NBR_MINUS_1", 6);
    private void X_CURRENT_EP_NBR_MINUS_1_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1;


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

    private bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("EP_NBR")) == QDesign.NULL(X_CURRENT_EP_NBR_MINUS_1.Value) & (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "CEIEXP" | QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "YTDCEX"))
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

    private SqlFileObject fleTMP_CEIEXP;

    private void fleTMP_CEIEXP_SetItemFinals()
    {

        try
        {
            fleTMP_CEIEXP.set_SetValue("AMT_GROSS_CEIEXP", fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));


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

    private SqlFileObject fleTMP_YTDCEX;

    private void fleTMP_YTDCEX_SetItemFinals()
    {

        try
        {
            fleTMP_YTDCEX.set_SetValue("AMT_NET_YTDCEX", fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));


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


    #region "Standard Generated Procedures(UTL0020A_1_DOWNLOAD_DOC_2_3)"


    #region "Automatic Item Initialization(UTL0020A_1_DOWNLOAD_DOC_2_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 7/19/2017 8:20:30 AM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:30 AM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));

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
    //# fleTMP_CEIEXP_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:30 AM
    //#-----------------------------------------
    private void fleTMP_CEIEXP_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleTMP_CEIEXP.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleTMP_CEIEXP.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleTMP_CEIEXP.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleTMP_CEIEXP.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleTMP_CEIEXP.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleTMP_CEIEXP.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleTMP_CEIEXP.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));

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
    //# fleTMP_YTDCEX_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:30 AM
    //#-----------------------------------------
    private void fleTMP_YTDCEX_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleTMP_YTDCEX.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleTMP_YTDCEX.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleTMP_YTDCEX.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleTMP_YTDCEX.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleTMP_YTDCEX.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleTMP_YTDCEX.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleTMP_YTDCEX.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            //TODO: Manual steps may be required.
            fleTMP_YTDCEX.set_SetValue("CURRENT_EP_NBR", !Fixed, fleTMP_CEIEXP.GetDecimalValue("CURRENT_EP_NBR"));
            fleTMP_YTDCEX.set_SetValue("DOC_SIN_NBR", !Fixed, fleTMP_CEIEXP.GetDecimalValue("DOC_SIN_NBR"));
            fleTMP_YTDCEX.set_SetValue("DOC_CLINIC_NBR", !Fixed, fleTMP_CEIEXP.GetDecimalValue("DOC_CLINIC_NBR"));
            fleTMP_YTDCEX.set_SetValue("DOC_INITS", !Fixed, fleTMP_CEIEXP.GetStringValue("DOC_INITS"));
            fleTMP_YTDCEX.set_SetValue("DOC_DATE_FAC_START", !Fixed, fleTMP_CEIEXP.GetDecimalValue("DOC_DATE_FAC_START"));
            fleTMP_YTDCEX.set_SetValue("DOC_DATE_FAC_TERM", !Fixed, fleTMP_CEIEXP.GetDecimalValue("DOC_DATE_FAC_TERM"));
            fleTMP_YTDCEX.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", !Fixed, fleTMP_CEIEXP.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE"));
            fleTMP_YTDCEX.set_SetValue("DOC_GUARANTEE_PERCENTAGE", !Fixed, fleTMP_CEIEXP.GetDecimalValue("DOC_GUARANTEE_PERCENTAGE"));
            fleTMP_YTDCEX.set_SetValue("DOC_GUARANTEE_FLAG", !Fixed, fleTMP_CEIEXP.GetStringValue("DOC_GUARANTEE_FLAG"));
            fleTMP_YTDCEX.set_SetValue("AMT_GROSS_CEIEXP", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_GROSS_CEIEXP"));
            fleTMP_YTDCEX.set_SetValue("AMT_NET_YTDCEX", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_NET_YTDCEX"));
            fleTMP_YTDCEX.set_SetValue("DOC_PAY_CODE", !Fixed, fleTMP_CEIEXP.GetStringValue("DOC_PAY_CODE"));
            fleTMP_YTDCEX.set_SetValue("DOC_PAY_SUB_CODE", !Fixed, fleTMP_CEIEXP.GetStringValue("DOC_PAY_SUB_CODE"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_TOTINC", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_TOTINC"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_INCEXP", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_INCEXP"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_DEPEXM", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_DEPEXM"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_DEPEXR", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_DEPEXR"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_YTDEAR", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_YTDEAR"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_DEPCHR", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_DEPCHR"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_PAYEFT", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_PAYEFT"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_RMAEXR", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_RMAEXR"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_GST", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_GST"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_BILL", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_BILL"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_RMAEXM", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_RMAEXM"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_PAYPOT", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_PAYPOT"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_GTYPEA", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_GTYPEA"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_01", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_01"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_01", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_01"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_02", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_02"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_02", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_02"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_03", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_03"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_03", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_03"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_04", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_04"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_04", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_04"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_05", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_05"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_05", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_05"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_06", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_06"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_06", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_06"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_07", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_07"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_07", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_07"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_08", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_08"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_08", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_08"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_09", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_09"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_09", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_09"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_10", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_10"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_10", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_10"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_11", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_11"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_11", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_11"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_12", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_12"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_12", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_12"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_13", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_13"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_13", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_13"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_14", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_14"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_14", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_14"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_15", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_15"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_15", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_15"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_16", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_16"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_16", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_16"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_17", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_17"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_17", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_17"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_18", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_18"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_18", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_18"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_19", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_19"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_19", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_19"));
            fleTMP_YTDCEX.set_SetValue("AMT_MTD_REV_20", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_MTD_REV_20"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_20", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_20"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_21", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_21"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_22", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_22"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_23", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_23"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_24", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_24"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_25", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_25"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_26", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_26"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_27", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_27"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_28", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_28"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_29", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_29"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_30", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_30"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_31", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_31"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_32", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_32"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_33", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_33"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_34", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_34"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_REV_35", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_REV_35"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_EXP_01", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_EXP_01"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_EXP_02", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_EXP_02"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_EXP_03", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_EXP_03"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_EXP_04", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_EXP_04"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_EXP_05", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_EXP_05"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_EXP_06", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_EXP_06"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_EXP_07", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_EXP_07"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_EXP_08", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_EXP_08"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_EXP_09", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_EXP_09"));
            fleTMP_YTDCEX.set_SetValue("AMT_YTD_EXP_10", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMT_YTD_EXP_10"));
            fleTMP_YTDCEX.set_SetValue("AMTYTDTOTINCENDOFLASTFISCALYEAR", !Fixed, fleTMP_CEIEXP.GetDecimalValue("AMTYTDTOTINCENDOFLASTFISCALYEAR"));
            fleTMP_YTDCEX.set_SetValue("TEXT_MISC", !Fixed, fleTMP_CEIEXP.GetStringValue("TEXT_MISC"));

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


    #region "Transaction Management Procedures(UTL0020A_1_DOWNLOAD_DOC_2_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 7/19/2017 8:20:28 AM

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
        fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleTMP_CEIEXP.Transaction = m_trnTRANS_UPDATE;
        fleTMP_YTDCEX.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0020A_1_DOWNLOAD_DOC_2_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 7/19/2017 8:20:28 AM

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
            fleF110_COMPENSATION.Dispose();
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleTMP_CEIEXP.Dispose();
            fleTMP_YTDCEX.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0020A_1_DOWNLOAD_DOC_2_3)"


    public void Run()
    {

        try
        {
            Request("DOWNLOAD_DOC_2_3");

            while (fleF110_COMPENSATION.QTPForMissing())
            {
                // --> GET F110_COMPENSATION <--

                fleF110_COMPENSATION.GetData();
                // --> End GET F110_COMPENSATION <--

                while (fleCONSTANTS_MSTR_REC_6.QTPForMissing("1"))
                {
                    // --> GET CONSTANTS_MSTR_REC_6 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                    m_strWhere.Append((6));

                    fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString());
                    // --> End GET CONSTANTS_MSTR_REC_6 <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_MSTR <--


                        if (Transaction())
                        {

                            if (SelectIf())
                            {




                                fleTMP_CEIEXP.OutPut(OutPutType.Add_Update, null, QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "CEIEXP");
                                //Parent:DOC_SIN_NBR)    'Parent:DOC_INITS)    'Parent:DOC_DATE_FAC_START)    'Parent:DOC_DATE_FAC_TERM






                                fleTMP_YTDCEX.OutPut(OutPutType.Add_Update, null, QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "YTDCEX");
                                //Parent:DOC_SIN_NBR)    'Parent:DOC_INITS)    'Parent:DOC_DATE_FAC_START)    'Parent:DOC_DATE_FAC_TERM

                            }

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
            EndRequest("DOWNLOAD_DOC_2_3");

        }

    }




    #endregion


}
//DOWNLOAD_DOC_2_3



public class UTL0020A_1_DOWNLOAD_DOC_3_4 : UTL0020A_1
{

    public UTL0020A_1_DOWNLOAD_DOC_3_4(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEBUG_UTL0020A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUG_UTL0020A", "", false, false, false, 0,"m_trnTRANS_UPDATE", FileType.SubFile); 
        fleTMP_PC_DOWNLOAD_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_PC_DOWNLOAD_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        X_CURRENT_EP_NBR_MINUS_1.GetValue += X_CURRENT_EP_NBR_MINUS_1_GetValue;
        X_LAST_EP_OF_LAST_FISCAL_YEAR.GetValue += X_LAST_EP_OF_LAST_FISCAL_YEAR_GetValue;
        fleTMP_PC_DOWNLOAD_FILE.SetItemFinals += fleTMP_PC_DOWNLOAD_FILE_SetItemFinals;
        fleTMP_PC_DOWNLOAD_FILE.InitializeItems += fleTMP_PC_DOWNLOAD_FILE_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0020A_1_DOWNLOAD_DOC_3_4)"

    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DDecimal X_CURRENT_EP_NBR_MINUS_1 = new DDecimal("X_CURRENT_EP_NBR_MINUS_1", 6);
    private void X_CURRENT_EP_NBR_MINUS_1_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1;


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
    private DDecimal X_LAST_EP_OF_LAST_FISCAL_YEAR = new DDecimal("X_LAST_EP_OF_LAST_FISCAL_YEAR", 6);
    private void X_LAST_EP_OF_LAST_FISCAL_YEAR_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.ASCII(QDesign.NConvert(QDesign.Substring(QDesign.ASCII(X_CURRENT_EP_NBR_MINUS_1.Value), 1, 4)) - 1) + "13");


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

    private bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("EP_NBR")) == QDesign.NULL(X_LAST_EP_OF_LAST_FISCAL_YEAR.Value) & QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "TOTINC" & QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("REC_TYPE")) == "A")
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





    private SqlFileObject fleDEBUG_UTL0020A;
    private SqlFileObject fleTMP_PC_DOWNLOAD_FILE;

    private void fleTMP_PC_DOWNLOAD_FILE_SetItemFinals()
    {

        try
        {
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("AMTYTDTOTINCENDOFLASTFISCALYEAR", fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD"));


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


    #region "Standard Generated Procedures(UTL0020A_1_DOWNLOAD_DOC_3_4)"


    #region "Automatic Item Initialization(UTL0020A_1_DOWNLOAD_DOC_3_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 7/19/2017 8:20:31 AM

    //#-----------------------------------------
    //# fleTMP_PC_DOWNLOAD_FILE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 7/19/2017 8:20:31 AM
    //#-----------------------------------------
    private void fleTMP_PC_DOWNLOAD_FILE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleTMP_PC_DOWNLOAD_FILE.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));

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


    #region "Transaction Management Procedures(UTL0020A_1_DOWNLOAD_DOC_3_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 7/19/2017 8:20:28 AM

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
        fleF119_DOCTOR_YTD_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDEBUG_UTL0020A.Transaction = m_trnTRANS_UPDATE;
        fleTMP_PC_DOWNLOAD_FILE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0020A_1_DOWNLOAD_DOC_3_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 7/19/2017 8:20:28 AM

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
            fleF119_DOCTOR_YTD_HISTORY.Dispose();
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleDEBUG_UTL0020A.Dispose();
            fleTMP_PC_DOWNLOAD_FILE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0020A_1_DOWNLOAD_DOC_3_4)"


    public void Run()
    {

        try
        {
            Request("DOWNLOAD_DOC_3_4");

            while (fleF119_DOCTOR_YTD_HISTORY.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD_HISTORY <--

                fleF119_DOCTOR_YTD_HISTORY.GetData();
                // --> End GET F119_DOCTOR_YTD_HISTORY <--

                while (fleCONSTANTS_MSTR_REC_6.QTPForMissing("1"))
                {
                    // --> GET CONSTANTS_MSTR_REC_6 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                    m_strWhere.Append((6));

                    fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString());
                    // --> End GET CONSTANTS_MSTR_REC_6 <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_MSTR <--


                        if (Transaction())
                        {

                            if (SelectIf())
                            {




                                SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUG_UTL0020A, SubFileType.Keep, fleF119_DOCTOR_YTD_HISTORY, "DOC_NBR", "EP_NBR", "COMP_CODE", "AMT_YTD", "AMT_YTD");
                                //Parent:DOC_SIN_NBR)    'Parent:DOC_INITS)    'Parent:DOC_DATE_FAC_START)    'Parent:DOC_DATE_FAC_TERM





                                fleTMP_PC_DOWNLOAD_FILE.OutPut(OutPutType.Add_Update);
                                //Parent:DOC_SIN_NBR)    'Parent:DOC_INITS)    'Parent:DOC_DATE_FAC_START)    'Parent:DOC_DATE_FAC_TERM

                            }

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
            EndRequest("DOWNLOAD_DOC_3_4");

        }

    }




    #endregion


}
//DOWNLOAD_DOC_3_4




