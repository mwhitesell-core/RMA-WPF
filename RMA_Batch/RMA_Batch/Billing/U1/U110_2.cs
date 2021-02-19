
#region "Screen Comments"

// #> PROGRAM-ID.     U110_2.QTS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// Create EARNINGS transactions in F110-COMPENSATION for
// the current EP-NBR using MTD values taken from F050-REVENUE-MSTR
// STAGE 1 - create subfile of values from F050-REVENUE-MSTR
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 93/JUN/01  ____   B.E.     - original
// 93/AUG/02  ____   B.E.     - criteria for output of a transaction
// changed from > 0 to <> 0 to allow
// negative only transactions
// 93/OCT/07  ____   B.E.     - change summing from YTD to MTD amounts
// 93/OCT/11  ____   B.E.     - criteria for output of transactions changed
// to force creation if any record found in
// in F050
// 94/FEB/17  ____   M.C.     - MODIFY PGM TO INCLUDE HSC LOCATION
// 95/OCT/19  ----   M.C.     - PDR 631 - INCLUDE OMA CD `MICV`,
// `MICM`, `MISJ`, `MISP`, `MOHR`
// 99/feb/24  ----   B.E.     - add new miscellaneous payment codes of
// `MICB`, MIBR` and `MINH`
// 99/dec/20  ----   B.E.  - added MHSC (also allow DHSC which was
// mistakenly entered - s/b MHSC
// 06/jul/11  ----   B.E.  - added DHSC and then changed to DHSC
// 06/sep/07  ----   b.e.   - added AGEP 
// 07/jul/03  ----   b.e.     - added MICA - MICL
// 08/may/26  ----   M.C.     - original u110.qts has been splitted into u110_1 & U110_2
// as per Brad`s request, it only allows 30 subfiles
// 08/nov/20  ----   MC1      - set the value for factor, seq & type for MICF to MICL   
// from f190-comp-codes  
// 13/may/22  ----   MC2  - add MOHD and cleanup all redundants which are already defined in u110_1.qts
// 15/Dec/07  ----   MC3  - add MACC, MIBD, MPAP, MSLP, MMDU, MBRT 
// -------------------------------------------------------
// IF UPDATING THIS FILE ALSO UPDATE THE FOLLOWING FILES:
// costing_billing_codes_?.q?s 
// This program has an include:
// either - u110_rma.qts or u110_hsc.qts
// NOTE:  in the future, if new codes to be included, please add to U110_2.qts &
// and/or u110_rma.qts for RMA
// -------------------------------------------------------


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U110_2 : BaseClassControl
{

    private U110_2 m_U110_2;

    public U110_2(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        MICF_SEQ = new CoreDecimal("MICF_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICF_TYPE = new CoreCharacter("MICF_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICF_FACTOR = new CoreDecimal("MICF_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICG_SEQ = new CoreDecimal("MICG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICG_TYPE = new CoreCharacter("MICG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICG_FACTOR = new CoreDecimal("MICG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICH_SEQ = new CoreDecimal("MICH_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICH_TYPE = new CoreCharacter("MICH_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICH_FACTOR = new CoreDecimal("MICH_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICJ_SEQ = new CoreDecimal("MICJ_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICJ_TYPE = new CoreCharacter("MICJ_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICJ_FACTOR = new CoreDecimal("MICJ_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICK_SEQ = new CoreDecimal("MICK_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICK_TYPE = new CoreCharacter("MICK_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICK_FACTOR = new CoreDecimal("MICK_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICL_SEQ = new CoreDecimal("MICL_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICL_TYPE = new CoreCharacter("MICL_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICL_FACTOR = new CoreDecimal("MICL_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MOHD_SEQ = new CoreDecimal("MOHD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MOHD_TYPE = new CoreCharacter("MOHD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MOHD_FACTOR = new CoreDecimal("MOHD_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MACC_SEQ = new CoreDecimal("MACC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MACC_TYPE = new CoreCharacter("MACC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MACC_FACTOR = new CoreDecimal("MACC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MIBD_SEQ = new CoreDecimal("MIBD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MIBD_TYPE = new CoreCharacter("MIBD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MIBD_FACTOR = new CoreDecimal("MIBD_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MPAP_SEQ = new CoreDecimal("MPAP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MPAP_TYPE = new CoreCharacter("MPAP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MPAP_FACTOR = new CoreDecimal("MPAP_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MSLP_SEQ = new CoreDecimal("MSLP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MSLP_TYPE = new CoreCharacter("MSLP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MSLP_FACTOR = new CoreDecimal("MSLP_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MMDU_SEQ = new CoreDecimal("MMDU_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MMDU_TYPE = new CoreCharacter("MMDU_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MMDU_FACTOR = new CoreDecimal("MMDU_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MBRT_SEQ = new CoreDecimal("MBRT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MBRT_TYPE = new CoreCharacter("MBRT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MBRT_FACTOR = new CoreDecimal("MBRT_FACTOR", 6, this, ResetTypes.ResetAtStartup);



    }

    public U110_2(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        MICF_SEQ = new CoreDecimal("MICF_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICF_TYPE = new CoreCharacter("MICF_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICF_FACTOR = new CoreDecimal("MICF_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICG_SEQ = new CoreDecimal("MICG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICG_TYPE = new CoreCharacter("MICG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICG_FACTOR = new CoreDecimal("MICG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICH_SEQ = new CoreDecimal("MICH_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICH_TYPE = new CoreCharacter("MICH_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICH_FACTOR = new CoreDecimal("MICH_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICJ_SEQ = new CoreDecimal("MICJ_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICJ_TYPE = new CoreCharacter("MICJ_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICJ_FACTOR = new CoreDecimal("MICJ_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICK_SEQ = new CoreDecimal("MICK_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICK_TYPE = new CoreCharacter("MICK_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICK_FACTOR = new CoreDecimal("MICK_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICL_SEQ = new CoreDecimal("MICL_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICL_TYPE = new CoreCharacter("MICL_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICL_FACTOR = new CoreDecimal("MICL_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MOHD_SEQ = new CoreDecimal("MOHD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MOHD_TYPE = new CoreCharacter("MOHD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MOHD_FACTOR = new CoreDecimal("MOHD_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MACC_SEQ = new CoreDecimal("MACC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MACC_TYPE = new CoreCharacter("MACC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MACC_FACTOR = new CoreDecimal("MACC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MIBD_SEQ = new CoreDecimal("MIBD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MIBD_TYPE = new CoreCharacter("MIBD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MIBD_FACTOR = new CoreDecimal("MIBD_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MPAP_SEQ = new CoreDecimal("MPAP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MPAP_TYPE = new CoreCharacter("MPAP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MPAP_FACTOR = new CoreDecimal("MPAP_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MSLP_SEQ = new CoreDecimal("MSLP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MSLP_TYPE = new CoreCharacter("MSLP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MSLP_FACTOR = new CoreDecimal("MSLP_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MMDU_SEQ = new CoreDecimal("MMDU_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MMDU_TYPE = new CoreCharacter("MMDU_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MMDU_FACTOR = new CoreDecimal("MMDU_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MBRT_SEQ = new CoreDecimal("MBRT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MBRT_TYPE = new CoreCharacter("MBRT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MBRT_FACTOR = new CoreDecimal("MBRT_FACTOR", 6, this, ResetTypes.ResetAtStartup);



    }

    public override void Dispose()
    {
        if ((m_U110_2 != null))
        {
            m_U110_2.CloseTransactionObjects();
            m_U110_2 = null;
        }
    }

    public U110_2 GetU110_2(int Level)
    {
        if (m_U110_2 == null)
        {
            m_U110_2 = new U110_2("U110_2", Level);
        }
        else
        {
            m_U110_2.ResetValues();
        }
        return m_U110_2;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal MICF_SEQ;
    protected CoreCharacter MICF_TYPE;
    protected CoreDecimal MICF_FACTOR;
    protected CoreDecimal MICG_SEQ;
    protected CoreCharacter MICG_TYPE;
    protected CoreDecimal MICG_FACTOR;
    protected CoreDecimal MICH_SEQ;
    protected CoreCharacter MICH_TYPE;
    protected CoreDecimal MICH_FACTOR;
    protected CoreDecimal MICJ_SEQ;
    protected CoreCharacter MICJ_TYPE;
    protected CoreDecimal MICJ_FACTOR;
    protected CoreDecimal MICK_SEQ;
    protected CoreCharacter MICK_TYPE;
    protected CoreDecimal MICK_FACTOR;
    protected CoreDecimal MICL_SEQ;
    protected CoreCharacter MICL_TYPE;
    protected CoreDecimal MICL_FACTOR;
    protected CoreDecimal MOHD_SEQ;
    protected CoreCharacter MOHD_TYPE;
    protected CoreDecimal MOHD_FACTOR;
    protected CoreDecimal MACC_SEQ;
    protected CoreCharacter MACC_TYPE;
    protected CoreDecimal MACC_FACTOR;
    protected CoreDecimal MIBD_SEQ;
    protected CoreCharacter MIBD_TYPE;
    protected CoreDecimal MIBD_FACTOR;
    protected CoreDecimal MPAP_SEQ;
    protected CoreCharacter MPAP_TYPE;
    protected CoreDecimal MPAP_FACTOR;
    protected CoreDecimal MSLP_SEQ;
    protected CoreCharacter MSLP_TYPE;
    protected CoreDecimal MSLP_FACTOR;
    protected CoreDecimal MMDU_SEQ;
    protected CoreCharacter MMDU_TYPE;
    protected CoreDecimal MMDU_FACTOR;
    protected CoreDecimal MBRT_SEQ;
    protected CoreCharacter MBRT_TYPE;

    protected CoreDecimal MBRT_FACTOR;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U110_2_U111_A_GET_MICF_1 U111_A_GET_MICF_1 = new U110_2_U111_A_GET_MICF_1(Name, Level);
            U111_A_GET_MICF_1.Run();
            U111_A_GET_MICF_1.Dispose();
            U111_A_GET_MICF_1 = null;

            U110_2_U111_A_GET_MICG_2 U111_A_GET_MICG_2 = new U110_2_U111_A_GET_MICG_2(Name, Level);
            U111_A_GET_MICG_2.Run();
            U111_A_GET_MICG_2.Dispose();
            U111_A_GET_MICG_2 = null;

            U110_2_U111_A_GET_MICH_3 U111_A_GET_MICH_3 = new U110_2_U111_A_GET_MICH_3(Name, Level);
            U111_A_GET_MICH_3.Run();
            U111_A_GET_MICH_3.Dispose();
            U111_A_GET_MICH_3 = null;

            U110_2_U111_A_GET_MICJ_4 U111_A_GET_MICJ_4 = new U110_2_U111_A_GET_MICJ_4(Name, Level);
            U111_A_GET_MICJ_4.Run();
            U111_A_GET_MICJ_4.Dispose();
            U111_A_GET_MICJ_4 = null;

            U110_2_U111_A_GET_MICK_5 U111_A_GET_MICK_5 = new U110_2_U111_A_GET_MICK_5(Name, Level);
            U111_A_GET_MICK_5.Run();
            U111_A_GET_MICK_5.Dispose();
            U111_A_GET_MICK_5 = null;

            U110_2_U111_A_GET_MICL_6 U111_A_GET_MICL_6 = new U110_2_U111_A_GET_MICL_6(Name, Level);
            U111_A_GET_MICL_6.Run();
            U111_A_GET_MICL_6.Dispose();
            U111_A_GET_MICL_6 = null;

            U110_2_U111_A_GET_MOHD_7 U111_A_GET_MOHD_7 = new U110_2_U111_A_GET_MOHD_7(Name, Level);
            U111_A_GET_MOHD_7.Run();
            U111_A_GET_MOHD_7.Dispose();
            U111_A_GET_MOHD_7 = null;

            U110_2_U111_A_GET_MACC_8 U111_A_GET_MACC_8 = new U110_2_U111_A_GET_MACC_8(Name, Level);
            U111_A_GET_MACC_8.Run();
            U111_A_GET_MACC_8.Dispose();
            U111_A_GET_MACC_8 = null;

            U110_2_U111_A_GET_MIBD_9 U111_A_GET_MIBD_9 = new U110_2_U111_A_GET_MIBD_9(Name, Level);
            U111_A_GET_MIBD_9.Run();
            U111_A_GET_MIBD_9.Dispose();
            U111_A_GET_MIBD_9 = null;

            U110_2_U111_A_GET_MPAP_10 U111_A_GET_MPAP_10 = new U110_2_U111_A_GET_MPAP_10(Name, Level);
            U111_A_GET_MPAP_10.Run();
            U111_A_GET_MPAP_10.Dispose();
            U111_A_GET_MPAP_10 = null;

            U110_2_U111_A_GET_MSLP_11 U111_A_GET_MSLP_11 = new U110_2_U111_A_GET_MSLP_11(Name, Level);
            U111_A_GET_MSLP_11.Run();
            U111_A_GET_MSLP_11.Dispose();
            U111_A_GET_MSLP_11 = null;

            U110_2_U111_A_GET_MMDU_12 U111_A_GET_MMDU_12 = new U110_2_U111_A_GET_MMDU_12(Name, Level);
            U111_A_GET_MMDU_12.Run();
            U111_A_GET_MMDU_12.Dispose();
            U111_A_GET_MMDU_12 = null;

            U110_2_U111_A_GET_MBRT_13 U111_A_GET_MBRT_13 = new U110_2_U111_A_GET_MBRT_13(Name, Level);
            U111_A_GET_MBRT_13.Run();
            U111_A_GET_MBRT_13.Dispose();
            U111_A_GET_MBRT_13 = null;

            U110_2_U110_PROCESS_14 U110_PROCESS_14 = new U110_2_U110_PROCESS_14(Name, Level);
            U110_PROCESS_14.Run();
            U110_PROCESS_14.Dispose();
            U110_PROCESS_14 = null;

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



public class U110_2_U111_A_GET_MICF_1 : U110_2
{

    public U110_2_U111_A_GET_MICF_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MICF_1)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MICF"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MICF_1)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MICF_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MICF_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:36 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MICF_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:37 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MICF_1)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MICF_1");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MICF_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MICF_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MICF_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MICF_1");

        }

    }







    #endregion


}
//U111_A_GET_MICF_1



public class U110_2_U111_A_GET_MICG_2 : U110_2
{

    public U110_2_U111_A_GET_MICG_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MICG_2)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MICG"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MICG_2)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MICG_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MICG_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:37 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MICG_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:37 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MICG_2)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MICG_2");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MICG_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MICG_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MICG_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MICG_2");

        }

    }







    #endregion


}
//U111_A_GET_MICG_2



public class U110_2_U111_A_GET_MICH_3 : U110_2
{

    public U110_2_U111_A_GET_MICH_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MICH_3)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MICH"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MICH_3)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MICH_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MICH_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:37 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MICH_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:37 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MICH_3)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MICH_3");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MICH_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MICH_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MICH_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MICH_3");

        }

    }







    #endregion


}
//U111_A_GET_MICH_3



public class U110_2_U111_A_GET_MICJ_4 : U110_2
{

    public U110_2_U111_A_GET_MICJ_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MICJ_4)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MICJ"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MICJ_4)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MICJ_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MICJ_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:38 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MICJ_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:38 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MICJ_4)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MICJ_4");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MICJ_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MICJ_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MICJ_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MICJ_4");

        }

    }







    #endregion


}
//U111_A_GET_MICJ_4



public class U110_2_U111_A_GET_MICK_5 : U110_2
{

    public U110_2_U111_A_GET_MICK_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MICK_5)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MICK"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MICK_5)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MICK_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MICK_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:38 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MICK_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:38 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MICK_5)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MICK_5");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MICK_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MICK_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MICK_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MICK_5");

        }

    }







    #endregion


}
//U111_A_GET_MICK_5



public class U110_2_U111_A_GET_MICL_6 : U110_2
{

    public U110_2_U111_A_GET_MICL_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MICL_6)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MICL"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MICL_6)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MICL_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MICL_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:38 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MICL_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:38 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MICL_6)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MICL_6");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MICL_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MICL_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MICL_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MICL_6");

        }

    }







    #endregion


}
//U111_A_GET_MICL_6



public class U110_2_U111_A_GET_MOHD_7 : U110_2
{

    public U110_2_U111_A_GET_MOHD_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MOHD_7)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MOHD"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MOHD_7)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MOHD_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MOHD_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:38 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MOHD_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:39 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MOHD_7)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MOHD_7");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MOHD_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MOHD_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MOHD_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MOHD_7");

        }

    }







    #endregion


}
//U111_A_GET_MOHD_7



public class U110_2_U111_A_GET_MACC_8 : U110_2
{

    public U110_2_U111_A_GET_MACC_8(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MACC_8)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MACC"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MACC_8)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MACC_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MACC_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:39 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MACC_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:39 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MACC_8)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MACC_8");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MACC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MACC_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MACC_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MACC_8");

        }

    }







    #endregion


}
//U111_A_GET_MACC_8



public class U110_2_U111_A_GET_MIBD_9 : U110_2
{

    public U110_2_U111_A_GET_MIBD_9(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MIBD_9)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MIBD"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MIBD_9)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MIBD_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MIBD_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:39 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MIBD_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:39 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MIBD_9)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MIBD_9");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MIBD_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MIBD_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MIBD_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MIBD_9");

        }

    }







    #endregion


}
//U111_A_GET_MIBD_9



public class U110_2_U111_A_GET_MPAP_10 : U110_2
{

    public U110_2_U111_A_GET_MPAP_10(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MPAP_10)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MPAP"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MPAP_10)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MPAP_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MPAP_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:39 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MPAP_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:40 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MPAP_10)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MPAP_10");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MPAP_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MPAP_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MPAP_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MPAP_10");

        }

    }







    #endregion


}
//U111_A_GET_MPAP_10



public class U110_2_U111_A_GET_MSLP_11 : U110_2
{

    public U110_2_U111_A_GET_MSLP_11(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MSLP_11)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MSLP"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MSLP_11)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MSLP_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MSLP_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:40 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MSLP_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:40 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MSLP_11)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MSLP_11");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MSLP_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MSLP_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MSLP_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MSLP_11");

        }

    }







    #endregion


}
//U111_A_GET_MSLP_11



public class U110_2_U111_A_GET_MMDU_12 : U110_2
{

    public U110_2_U111_A_GET_MMDU_12(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MMDU_12)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MMDU"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MMDU_12)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MMDU_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MMDU_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:40 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MMDU_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:41 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MMDU_12)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MMDU_12");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MMDU_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MMDU_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MMDU_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MMDU_12");

        }

    }







    #endregion


}
//U111_A_GET_MMDU_12



public class U110_2_U111_A_GET_MBRT_13 : U110_2
{

    public U110_2_U111_A_GET_MBRT_13(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U111_A_GET_MBRT_13)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MBRT"));


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


    #region "Standard Generated Procedures(U110_2_U111_A_GET_MBRT_13)"


    #region "Automatic Item Initialization(U110_2_U111_A_GET_MBRT_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U111_A_GET_MBRT_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:41 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U111_A_GET_MBRT_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:41 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U111_A_GET_MBRT_13)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MBRT_13");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MBRT_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MBRT_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MBRT_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MBRT_13");

        }

    }







    #endregion


}
//U111_A_GET_MBRT_13



public class U110_2_U110_PROCESS_14 : U110_2
{

    public U110_2_U110_PROCESS_14(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        MTD_MICF = new CoreDecimal("MTD_MICF", 8, this);
        MTD_MICG = new CoreDecimal("MTD_MICG", 8, this);
        MTD_MICH = new CoreDecimal("MTD_MICH", 8, this);
        MTD_MICJ = new CoreDecimal("MTD_MICJ", 8, this);
        MTD_MICK = new CoreDecimal("MTD_MICK", 8, this);
        MTD_MICL = new CoreDecimal("MTD_MICL", 8, this);
        MTD_MOHD = new CoreDecimal("MTD_MOHD", 8, this);
        MTD_MACC = new CoreDecimal("MTD_MACC", 8, this);
        MTD_MIBD = new CoreDecimal("MTD_MIBD", 8, this);
        MTD_MPAP = new CoreDecimal("MTD_MPAP", 8, this);
        MTD_MSLP = new CoreDecimal("MTD_MSLP", 8, this);
        MTD_MMDU = new CoreDecimal("MTD_MMDU", 8, this);
        MTD_MBRT = new CoreDecimal("MTD_MBRT", 8, this);
        X_COMP_CODE_MICF = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICF = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICF", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICG = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICG = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICG", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICH = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICH", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICJ = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICJ", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICK = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICK = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICK", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICL = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICL", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MOHD = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MOHD = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MOHD", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MACC = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MACC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MACC", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MIBD = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MIBD = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MIBD", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MPAP = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MPAP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MPAP", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MSLP = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MSLP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MSLP", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MMDU = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MMDU = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MMDU", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MBRT = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MBRT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MBRT", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U110_2_U110_PROCESS_14)"

    private SqlFileObject fleF050_DOC_REVENUE_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    private CoreDecimal MTD_MICF;
    private CoreDecimal MTD_MICG;
    private CoreDecimal MTD_MICH;
    private CoreDecimal MTD_MICJ;
    private CoreDecimal MTD_MICK;
    private CoreDecimal MTD_MICL;
    private CoreDecimal MTD_MOHD;
    private CoreDecimal MTD_MACC;
    private CoreDecimal MTD_MIBD;
    private CoreDecimal MTD_MPAP;
    private CoreDecimal MTD_MSLP;
    private CoreDecimal MTD_MMDU;
    private CoreDecimal MTD_MBRT;
    private CoreCharacter X_COMP_CODE_MICF;
    private SqlFileObject fleU110_MICF;
    private CoreCharacter X_COMP_CODE_MICG;
    private SqlFileObject fleU110_MICG;
    private CoreCharacter X_COMP_CODE_MICH;
    private SqlFileObject fleU110_MICH;
    private CoreCharacter X_COMP_CODE_MICJ;
    private SqlFileObject fleU110_MICJ;
    private CoreCharacter X_COMP_CODE_MICK;
    private SqlFileObject fleU110_MICK;
    private CoreCharacter X_COMP_CODE_MICL;
    private SqlFileObject fleU110_MICL;
    private CoreCharacter X_COMP_CODE_MOHD;
    private SqlFileObject fleU110_MOHD;
    private CoreCharacter X_COMP_CODE_MACC;
    private SqlFileObject fleU110_MACC;
    private CoreCharacter X_COMP_CODE_MIBD;
    private SqlFileObject fleU110_MIBD;
    private CoreCharacter X_COMP_CODE_MPAP;
    private SqlFileObject fleU110_MPAP;
    private CoreCharacter X_COMP_CODE_MSLP;
    private SqlFileObject fleU110_MSLP;
    private CoreCharacter X_COMP_CODE_MMDU;
    private SqlFileObject fleU110_MMDU;
    private CoreCharacter X_COMP_CODE_MBRT;
    private SqlFileObject fleU110_MBRT;

    public override bool SelectIf()
    {
        try
        {
            if ((QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "22"
                | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "23"
                | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "24"
                | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "25"
                | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "26")
                | (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y"
                & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != " "
                & (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")).CompareTo("71") < 0
                | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")).CompareTo("75") > 0)))
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

    #endregion


    #region "Standard Generated Procedures(U110_2_U110_PROCESS_14)"


    #region "Automatic Item Initialization(U110_2_U110_PROCESS_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_2_U110_PROCESS_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:41 PM

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
        fleF050_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICF.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICG.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICH.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICJ.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICK.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICL.Transaction = m_trnTRANS_UPDATE;
        fleU110_MOHD.Transaction = m_trnTRANS_UPDATE;
        fleU110_MACC.Transaction = m_trnTRANS_UPDATE;
        fleU110_MIBD.Transaction = m_trnTRANS_UPDATE;
        fleU110_MPAP.Transaction = m_trnTRANS_UPDATE;
        fleU110_MSLP.Transaction = m_trnTRANS_UPDATE;
        fleU110_MMDU.Transaction = m_trnTRANS_UPDATE;
        fleU110_MBRT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_2_U110_PROCESS_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:41 PM

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
            fleF050_DOC_REVENUE_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleU110_MICF.Dispose();
            fleU110_MICG.Dispose();
            fleU110_MICH.Dispose();
            fleU110_MICJ.Dispose();
            fleU110_MICK.Dispose();
            fleU110_MICL.Dispose();
            fleU110_MOHD.Dispose();
            fleU110_MACC.Dispose();
            fleU110_MIBD.Dispose();
            fleU110_MPAP.Dispose();
            fleU110_MSLP.Dispose();
            fleU110_MMDU.Dispose();
            fleU110_MBRT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_2_U110_PROCESS_14)"


    public void Run()
    {

        try
        {
            Request("U110_PROCESS_14");

            while (fleF050_DOC_REVENUE_MSTR.QTPForMissing())
            {
                // --> GET F050_DOC_REVENUE_MSTR <--

                fleF050_DOC_REVENUE_MSTR.GetData();
                // --> End GET F050_DOC_REVENUE_MSTR <--

                // GW2018. Added for debug
                //if (!fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR").Equals("00T"))
                //    continue;

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleICONST_MSTR_REC.QTPForMissing("2"))
                    {
                        // --> GET ICONST_MSTR_REC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2"))));

                        fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                        // --> End GET ICONST_MSTR_REC <--


                        if (Transaction())
                        {

                             if (Select_If())
                            {

                                Sort(fleF050_DOC_REVENUE_MSTR.GetSortValue("DOCREV_CLINIC_1_2"), fleF050_DOC_REVENUE_MSTR.GetSortValue("DOCREV_DEPT"), fleF050_DOC_REVENUE_MSTR.GetSortValue("DOCREV_DOC_NBR"), fleF050_DOC_REVENUE_MSTR.GetSortValue("DOCREV_LOCATION"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleF050_DOC_REVENUE_MSTR, fleF020_DOCTOR_MSTR, fleICONST_MSTR_REC))
            {
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICF")
                {
                    MTD_MICF.Value = MTD_MICF.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICF.Value = MTD_MICF.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICG")
                {
                    MTD_MICG.Value = MTD_MICG.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICG.Value = MTD_MICG.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICH")
                {
                    MTD_MICH.Value = MTD_MICH.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICH.Value = MTD_MICH.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICJ")
                {
                    MTD_MICJ.Value = MTD_MICJ.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICJ.Value = MTD_MICJ.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICK")
                {
                    MTD_MICK.Value = MTD_MICK.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICK.Value = MTD_MICK.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICL")
                {
                    MTD_MICL.Value = MTD_MICL.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICL.Value = MTD_MICL.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MOHD")
                {
                    MTD_MOHD.Value = MTD_MOHD.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MOHD.Value = MTD_MOHD.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MACC")
                {
                    MTD_MACC.Value = MTD_MACC.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MACC.Value = MTD_MACC.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MIBD")
                {
                    MTD_MIBD.Value = MTD_MIBD.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MIBD.Value = MTD_MIBD.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MPAP")
                {
                    MTD_MPAP.Value = MTD_MPAP.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MPAP.Value = MTD_MPAP.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MSLP")
                {
                    MTD_MSLP.Value = MTD_MSLP.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MSLP.Value = MTD_MSLP.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MMDU")
                {
                    MTD_MMDU.Value = MTD_MMDU.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MMDU.Value = MTD_MMDU.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MBRT")
                {
                    MTD_MBRT.Value = MTD_MBRT.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MBRT.Value = MTD_MBRT.Value;
                }
                X_COMP_CODE_MICF.Value = "MICF";

                if (fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"))
                {

                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICF, (1==1), QDesign.NULL(MTD_MICF.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MICF, MICF_TYPE, MICF_SEQ,
                    MICF_FACTOR, MTD_MICF);

                    X_COMP_CODE_MICG.Value = "MICG";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICG, (1 == 1), QDesign.NULL(MTD_MICG.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MICG, MICG_TYPE, MICG_SEQ,
                    MICG_FACTOR, MTD_MICG);

                    X_COMP_CODE_MICH.Value = "MICH";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICH, (1 == 1), QDesign.NULL(MTD_MICH.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MICH, MICH_TYPE, MICH_SEQ,
                    MICH_FACTOR, MTD_MICH);

                    X_COMP_CODE_MICJ.Value = "MICJ";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICJ, (1 == 1), QDesign.NULL(MTD_MICJ.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MICJ, MICJ_TYPE, MICJ_SEQ,
                    MICJ_FACTOR, MTD_MICJ);

                    X_COMP_CODE_MICK.Value = "MICK";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICK, (1 == 1), QDesign.NULL(MTD_MICK.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MICK, MICK_TYPE, MICK_SEQ,
                    MICK_FACTOR, MTD_MICK);

                    X_COMP_CODE_MICL.Value = "MICL";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICL, (1 == 1), QDesign.NULL(MTD_MICL.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MICL, MICL_TYPE, MICL_SEQ,
                    MICL_FACTOR, MTD_MICL);

                    // GW2018. Added for debug
                    //string buf1, buf2, buf3 = "";
                    //buf1 = Convert.ToString(MOHD_SEQ.Value);
                    //buf2 = Convert.ToString(MOHD_FACTOR.Value);
                    //buf3 = Convert.ToString(MTD_MOHD.Value);

                    X_COMP_CODE_MOHD.Value = "MOHD";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MOHD, (1 == 1), QDesign.NULL(MTD_MOHD.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MOHD, MOHD_TYPE, MOHD_SEQ,
                    MOHD_FACTOR, MTD_MOHD);

                    X_COMP_CODE_MACC.Value = "MACC";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MACC, (1 == 1), QDesign.NULL(MTD_MACC.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MACC, MACC_TYPE, MACC_SEQ,
                    MACC_FACTOR, MTD_MACC);

                    X_COMP_CODE_MIBD.Value = "MIBD";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MIBD, (1 == 1), QDesign.NULL(MTD_MIBD.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MIBD, MIBD_TYPE, MIBD_SEQ,
                    MIBD_FACTOR, MTD_MIBD);

                    X_COMP_CODE_MPAP.Value = "MPAP";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MPAP, (1 == 1), QDesign.NULL(MTD_MPAP.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MPAP, MPAP_TYPE, MPAP_SEQ,
                    MPAP_FACTOR, MTD_MPAP);

                    X_COMP_CODE_MSLP.Value = "MSLP";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MSLP, (1 == 1), QDesign.NULL(MTD_MSLP.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MSLP, MSLP_TYPE, MSLP_SEQ,
                    MSLP_FACTOR, MTD_MSLP);

                    X_COMP_CODE_MMDU.Value = "MMDU";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MMDU, (1 == 1), QDesign.NULL(MTD_MMDU.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MMDU, MMDU_TYPE, MMDU_SEQ,
                    MMDU_FACTOR, MTD_MMDU);

                    X_COMP_CODE_MBRT.Value = "MBRT";
                    SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MBRT, (1 == 1), QDesign.NULL(MTD_MBRT.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", X_COMP_CODE_MBRT, MBRT_TYPE, MBRT_SEQ,
                    MBRT_FACTOR, MTD_MBRT);

                }

                Reset(ref MTD_MICF, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICG, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICH, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICJ, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICK, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICL, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MOHD, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MACC, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MIBD, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MPAP, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MSLP, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MMDU, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MBRT, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));

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
            EndRequest("U110_PROCESS_14");

        }

    }







    #endregion


}
//U110_PROCESS_14




