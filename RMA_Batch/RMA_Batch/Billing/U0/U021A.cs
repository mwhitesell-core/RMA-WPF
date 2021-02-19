
#region "Screen Comments"

// #> PROGRAM-ID.     u021a.qts
// ((C)) Dyad Technologies
// PROGRAM PURPOSE :  this is the prepass before generating r021b report
// MODIFICATION HISTORY
// DATE   WHO         DESCRIPTION
// 03/dec/02 M.C.        - original 
// 06/sep/07 M.C.  - add more defined item to determine the type of errors
// 10/mar/04 MC1  - define V09 as a referring doctor reject error (like ERF and AC4)
// 13/Jun/18 MC2  - define ARF as a referring doctor reject error (like ERF and AC4)


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U021A : BaseClassControl
{

    private U021A m_U021A;

    public U021A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U021A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U021A != null))
        {
            m_U021A.CloseTransactionObjects();
            m_U021A = null;
        }
    }

    public U021A GetU021A(int Level)
    {
        if (m_U021A == null)
        {
            m_U021A = new U021A("U021A", Level);
        }
        else
        {
            m_U021A.ResetValues();
        }
        return m_U021A;
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

            U021A_DETERMINE_TYPE_OF_ERRORS_1 DETERMINE_TYPE_OF_ERRORS_1 = new U021A_DETERMINE_TYPE_OF_ERRORS_1(Name, Level);
            DETERMINE_TYPE_OF_ERRORS_1.Run();
            DETERMINE_TYPE_OF_ERRORS_1.Dispose();
            DETERMINE_TYPE_OF_ERRORS_1 = null;

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



public class U021A_DETERMINE_TYPE_OF_ERRORS_1 : U021A
{

    public U021A_DETERMINE_TYPE_OF_ERRORS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU021A_EDT_1HT_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "U021A_EDT_1HT_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_1 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_1", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_2 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_2", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_3 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_3", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_4 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_4", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_HDR_5 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_HDR_5", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_1 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_1", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_2 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_2", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_3 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_3", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_4 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_4", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF093_DTL_5 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "F093_DTL_5", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_SERV_REF_CODE_THIS_REC = new CoreDecimal("X_SERV_REF_CODE_THIS_REC", 6, this);
        X_SERV_NON_REF_CODE_THIS_REC = new CoreDecimal("X_SERV_NON_REF_CODE_THIS_REC", 6, this);
        X_SERV_ERR_CODE_THIS_REC = new CoreDecimal("X_SERV_ERR_CODE_THIS_REC", 6, this);
        X_ELIG_ERR_CODE_THIS_REC = new CoreDecimal("X_ELIG_ERR_CODE_THIS_REC", 6, this);
        REC_COUNTER = new CoreDecimal("REC_COUNTER", 6, this);
        fleTMP_SERV_ERR_CLAIM = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_SERV_ERR_CLAIM", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        X_OHIP_ERR_REF_SERV_SS.GetValue += X_OHIP_ERR_REF_SERV_SS_GetValue;
        X_OHIP_ERR_NON_REF_SERV_SS.GetValue += X_OHIP_ERR_NON_REF_SERV_SS_GetValue;
        X_OHIP_ERR_HDR_SERV_SS.GetValue += X_OHIP_ERR_HDR_SERV_SS_GetValue;
        X_OHIP_ERR_DTL_SERV_SS.GetValue += X_OHIP_ERR_DTL_SERV_SS_GetValue;
        X_OHIP_ERR_HDR_ELIG_SS.GetValue += X_OHIP_ERR_HDR_ELIG_SS_GetValue;
        X_OHIP_ERR_DTL_ELIG_SS.GetValue += X_OHIP_ERR_DTL_ELIG_SS_GetValue;
        fleTMP_SERV_ERR_CLAIM.SetItemFinals += fleTMP_SERV_ERR_CLAIM_SetItemFinals;
        fleF093_HDR_2.InitializeItems += fleF093_HDR_2_AutomaticItemInitialization;
        fleF093_HDR_3.InitializeItems += fleF093_HDR_3_AutomaticItemInitialization;
        fleF093_HDR_4.InitializeItems += fleF093_HDR_4_AutomaticItemInitialization;
        fleF093_HDR_5.InitializeItems += fleF093_HDR_5_AutomaticItemInitialization;
        fleF093_DTL_1.InitializeItems += fleF093_DTL_1_AutomaticItemInitialization;
        fleF093_DTL_2.InitializeItems += fleF093_DTL_2_AutomaticItemInitialization;
        fleF093_DTL_3.InitializeItems += fleF093_DTL_3_AutomaticItemInitialization;
        fleF093_DTL_4.InitializeItems += fleF093_DTL_4_AutomaticItemInitialization;
        fleF093_DTL_5.InitializeItems += fleF093_DTL_5_AutomaticItemInitialization;
        fleTMP_SERV_ERR_CLAIM.InitializeItems += fleTMP_SERV_ERR_CLAIM_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U021A_DETERMINE_TYPE_OF_ERRORS_1)"

    private SqlFileObject fleU021A_EDT_1HT_FILE;
    private SqlFileObject fleF093_HDR_1;
    private SqlFileObject fleF093_HDR_2;
    private SqlFileObject fleF093_HDR_3;
    private SqlFileObject fleF093_HDR_4;
    private SqlFileObject fleF093_HDR_5;
    private SqlFileObject fleF093_DTL_1;
    private SqlFileObject fleF093_DTL_2;
    private SqlFileObject fleF093_DTL_3;
    private SqlFileObject fleF093_DTL_4;
    private SqlFileObject fleF093_DTL_5;
    private DDecimal X_OHIP_ERR_REF_SERV_SS = new DDecimal("X_OHIP_ERR_REF_SERV_SS", 6);
    private void X_OHIP_ERR_REF_SERV_SS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) == "EQ6" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) == "EQ6" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) == "EQ6" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) == "EQ6" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) == "EQ6" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) == "EQ6" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) == "EQ6" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) == "EQ6" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) == "EQ6" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) == "EQ6" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) == "AC4" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) == "AC4" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) == "AC4" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) == "AC4" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) == "AC4" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) == "AC4" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) == "AC4" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) == "AC4" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) == "AC4" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) == "AC4" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) == "ERF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) == "ERF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) == "ERF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) == "ERF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) == "ERF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) == "ERF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) == "ERF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) == "ERF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) == "ERF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) == "ERF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) == "V09" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) == "V09" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) == "V09" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) == "V09" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) == "V09" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) == "V09" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) == "V09" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) == "V09" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) == "V09" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) == "V09" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) == "ARF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) == "ARF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) == "ARF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) == "ARF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) == "ARF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) == "ARF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) == "ARF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) == "ARF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) == "ARF" | QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) == "ARF")
            {
                CurrentValue = 1;
            }
            else
            {
                CurrentValue = 0;
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
    private DDecimal X_OHIP_ERR_NON_REF_SERV_SS = new DDecimal("X_OHIP_ERR_NON_REF_SERV_SS", 6);
    private void X_OHIP_ERR_NON_REF_SERV_SS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != "EQ6" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != "EQ6" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != "EQ6" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != "EQ6" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != "EQ6" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != "EQ6" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != "EQ6" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != "EQ6" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != "EQ6" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != "EQ6" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != "AC4" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != "AC4" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != "AC4" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != "AC4" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != "AC4" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != "AC4" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != "AC4" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != "AC4" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != "AC4" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != "AC4" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != "ERF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != "ERF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != "ERF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != "ERF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != "ERF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != "ERF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != "ERF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != "ERF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != "ERF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != "ERF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != "V09" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != "V09" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != "V09" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != "V09" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != "V09" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != "V09" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != "V09" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != "V09" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != "V09" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != "V09" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != "ARF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != "ARF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != "ARF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != "ARF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != "ARF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != "ARF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != "ARF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != "ARF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != "ARF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != "ARF" & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != QDesign.NULL(" "))
            {
                CurrentValue = 1;
            }
            else
            {
                CurrentValue = 0;
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
    private DDecimal X_OHIP_ERR_HDR_SERV_SS = new DDecimal("X_OHIP_ERR_HDR_SERV_SS", 6);
    private void X_OHIP_ERR_HDR_SERV_SS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE")) == "S")
            {
                CurrentValue = 1;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_2.GetStringValue("OHIP_ERR_CAT_CODE")) == "S")
            {
                CurrentValue = 2;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_3.GetStringValue("OHIP_ERR_CAT_CODE")) == "S")
            {
                CurrentValue = 3;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_4.GetStringValue("OHIP_ERR_CAT_CODE")) == "S")
            {
                CurrentValue = 4;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_5.GetStringValue("OHIP_ERR_CAT_CODE")) == "S")
            {
                CurrentValue = 5;
            }
            else
            {
                CurrentValue = 0;
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
    private DDecimal X_OHIP_ERR_DTL_SERV_SS = new DDecimal("X_OHIP_ERR_DTL_SERV_SS", 6);
    private void X_OHIP_ERR_DTL_SERV_SS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_1.GetStringValue("OHIP_ERR_CAT_CODE")) == "S")
            {
                CurrentValue = 1;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_2.GetStringValue("OHIP_ERR_CAT_CODE")) == "S")
            {
                CurrentValue = 2;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_3.GetStringValue("OHIP_ERR_CAT_CODE")) == "S")
            {
                CurrentValue = 3;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_4.GetStringValue("OHIP_ERR_CAT_CODE")) == "S")
            {
                CurrentValue = 4;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_5.GetStringValue("OHIP_ERR_CAT_CODE")) == "S")
            {
                CurrentValue = 5;
            }
            else
            {
                CurrentValue = 0;
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
    private DDecimal X_OHIP_ERR_HDR_ELIG_SS = new DDecimal("X_OHIP_ERR_HDR_ELIG_SS", 6);
    private void X_OHIP_ERR_HDR_ELIG_SS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE")) == "E")
            {
                CurrentValue = 1;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_2.GetStringValue("OHIP_ERR_CAT_CODE")) == "E")
            {
                CurrentValue = 2;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_3.GetStringValue("OHIP_ERR_CAT_CODE")) == "E")
            {
                CurrentValue = 3;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_4.GetStringValue("OHIP_ERR_CAT_CODE")) == "E")
            {
                CurrentValue = 4;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_HDR_5.GetStringValue("OHIP_ERR_CAT_CODE")) == "E")
            {
                CurrentValue = 5;
            }
            else
            {
                CurrentValue = 0;
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
    private DDecimal X_OHIP_ERR_DTL_ELIG_SS = new DDecimal("X_OHIP_ERR_DTL_ELIG_SS", 6);
    private void X_OHIP_ERR_DTL_ELIG_SS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_1.GetStringValue("OHIP_ERR_CAT_CODE")) == "E")
            {
                CurrentValue = 1;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_2.GetStringValue("OHIP_ERR_CAT_CODE")) == "E")
            {
                CurrentValue = 2;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_3.GetStringValue("OHIP_ERR_CAT_CODE")) == "E")
            {
                CurrentValue = 3;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_4.GetStringValue("OHIP_ERR_CAT_CODE")) == "E")
            {
                CurrentValue = 4;
            }
            else if (QDesign.NULL(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(fleF093_DTL_5.GetStringValue("OHIP_ERR_CAT_CODE")) == "E")
            {
                CurrentValue = 5;
            }
            else
            {
                CurrentValue = 0;
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
    private CoreDecimal X_SERV_REF_CODE_THIS_REC;
    private CoreDecimal X_SERV_NON_REF_CODE_THIS_REC;
    private CoreDecimal X_SERV_ERR_CODE_THIS_REC;
    private CoreDecimal X_ELIG_ERR_CODE_THIS_REC;
    private CoreDecimal REC_COUNTER;
    private SqlFileObject fleTMP_SERV_ERR_CLAIM;

    private void fleTMP_SERV_ERR_CLAIM_SetItemFinals()
    {

        try
        {
            fleTMP_SERV_ERR_CLAIM.set_SetValue("RAT_RMB_ACCOUNT_NBR", fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ACCOUNT_NBR"));
            fleTMP_SERV_ERR_CLAIM.set_SetValue("TRAILER_T_COUNT", REC_COUNTER.Value);
            if (QDesign.NULL(X_ELIG_ERR_CODE_THIS_REC.Value) > 0)
            {
                fleTMP_SERV_ERR_CLAIM.set_SetValue("CLMHDR_ELIG_ERROR", "Y");
            }
            if (QDesign.NULL(X_SERV_ERR_CODE_THIS_REC.Value) > 0)
            {
                fleTMP_SERV_ERR_CLAIM.set_SetValue("CLMHDR_SERV_ERROR", "Y");
            }
            if (QDesign.NULL(X_SERV_REF_CODE_THIS_REC.Value) > 0 & QDesign.NULL(X_SERV_NON_REF_CODE_THIS_REC.Value) == 0)
            {
                fleTMP_SERV_ERR_CLAIM.set_SetValue("CLMHDR_STATUS_OHIP", "R ");
            }
            else if (QDesign.NULL(X_SERV_REF_CODE_THIS_REC.Value) > 0 & QDesign.NULL(X_SERV_NON_REF_CODE_THIS_REC.Value) > 0)
            {
                fleTMP_SERV_ERR_CLAIM.set_SetValue("CLMHDR_STATUS_OHIP", "RN");
            }
            else if (QDesign.NULL(X_SERV_REF_CODE_THIS_REC.Value) == 0 & QDesign.NULL(X_SERV_NON_REF_CODE_THIS_REC.Value) > 0)
            {
                fleTMP_SERV_ERR_CLAIM.set_SetValue("CLMHDR_STATUS_OHIP", " N");
            }
            fleTMP_SERV_ERR_CLAIM.set_SetValue("ENTRY_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleTMP_SERV_ERR_CLAIM.set_SetValue("ENTRY_TIME_LONG", QDesign.SysTime(ref m_cnnQUERY));
            fleTMP_SERV_ERR_CLAIM.set_SetValue("ENTRY_USER_ID", "system");


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


    #region "Standard Generated Procedures(U021A_DETERMINE_TYPE_OF_ERRORS_1)"


    #region "Automatic Item Initialization(U021A_DETERMINE_TYPE_OF_ERRORS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:11 PM

    //#-----------------------------------------
    //# fleF093_HDR_2_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.20448  Generated on: 6/27/2017 12:28:11 PM
    //#-----------------------------------------
    private void fleF093_HDR_2_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF093_HDR_2.set_SetValue("OHIP_ERR_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CODE"));
            fleF093_HDR_2.set_SetValue("OHIP_ERR_DESCRIPTION", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_DESCRIPTION"));
            fleF093_HDR_2.set_SetValue("OHIP_ERR_CAT_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE"));
            fleF093_HDR_2.set_SetValue("ENTRY_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_DATE"));
            fleF093_HDR_2.set_SetValue("ENTRY_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_TIME"));
            fleF093_HDR_2.set_SetValue("ENTRY_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("ENTRY_USER_ID"));
            fleF093_HDR_2.set_SetValue("LAST_MOD_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_DATE"));
            fleF093_HDR_2.set_SetValue("LAST_MOD_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_TIME"));
            fleF093_HDR_2.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF093_HDR_3_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.20448  Generated on: 6/27/2017 12:28:11 PM
    //#-----------------------------------------
    private void fleF093_HDR_3_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF093_HDR_3.set_SetValue("OHIP_ERR_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CODE"));
            fleF093_HDR_3.set_SetValue("OHIP_ERR_DESCRIPTION", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_DESCRIPTION"));
            fleF093_HDR_3.set_SetValue("OHIP_ERR_CAT_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE"));
            fleF093_HDR_3.set_SetValue("ENTRY_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_DATE"));
            fleF093_HDR_3.set_SetValue("ENTRY_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_TIME"));
            fleF093_HDR_3.set_SetValue("ENTRY_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("ENTRY_USER_ID"));
            fleF093_HDR_3.set_SetValue("LAST_MOD_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_DATE"));
            fleF093_HDR_3.set_SetValue("LAST_MOD_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_TIME"));
            fleF093_HDR_3.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF093_HDR_4_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.20448  Generated on: 6/27/2017 12:28:11 PM
    //#-----------------------------------------
    private void fleF093_HDR_4_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF093_HDR_4.set_SetValue("OHIP_ERR_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CODE"));
            fleF093_HDR_4.set_SetValue("OHIP_ERR_DESCRIPTION", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_DESCRIPTION"));
            fleF093_HDR_4.set_SetValue("OHIP_ERR_CAT_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE"));
            fleF093_HDR_4.set_SetValue("ENTRY_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_DATE"));
            fleF093_HDR_4.set_SetValue("ENTRY_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_TIME"));
            fleF093_HDR_4.set_SetValue("ENTRY_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("ENTRY_USER_ID"));
            fleF093_HDR_4.set_SetValue("LAST_MOD_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_DATE"));
            fleF093_HDR_4.set_SetValue("LAST_MOD_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_TIME"));
            fleF093_HDR_4.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF093_HDR_5_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.20448  Generated on: 6/27/2017 12:28:11 PM
    //#-----------------------------------------
    private void fleF093_HDR_5_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF093_HDR_5.set_SetValue("OHIP_ERR_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CODE"));
            fleF093_HDR_5.set_SetValue("OHIP_ERR_DESCRIPTION", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_DESCRIPTION"));
            fleF093_HDR_5.set_SetValue("OHIP_ERR_CAT_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE"));
            fleF093_HDR_5.set_SetValue("ENTRY_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_DATE"));
            fleF093_HDR_5.set_SetValue("ENTRY_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_TIME"));
            fleF093_HDR_5.set_SetValue("ENTRY_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("ENTRY_USER_ID"));
            fleF093_HDR_5.set_SetValue("LAST_MOD_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_DATE"));
            fleF093_HDR_5.set_SetValue("LAST_MOD_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_TIME"));
            fleF093_HDR_5.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF093_DTL_1_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.20448  Generated on: 6/27/2017 12:28:11 PM
    //#-----------------------------------------
    private void fleF093_DTL_1_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF093_DTL_1.set_SetValue("OHIP_ERR_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CODE"));
            fleF093_DTL_1.set_SetValue("OHIP_ERR_DESCRIPTION", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_DESCRIPTION"));
            fleF093_DTL_1.set_SetValue("OHIP_ERR_CAT_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE"));
            fleF093_DTL_1.set_SetValue("ENTRY_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_DATE"));
            fleF093_DTL_1.set_SetValue("ENTRY_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_TIME"));
            fleF093_DTL_1.set_SetValue("ENTRY_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("ENTRY_USER_ID"));
            fleF093_DTL_1.set_SetValue("LAST_MOD_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_DATE"));
            fleF093_DTL_1.set_SetValue("LAST_MOD_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_TIME"));
            fleF093_DTL_1.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF093_DTL_2_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.20448  Generated on: 6/27/2017 12:28:11 PM
    //#-----------------------------------------
    private void fleF093_DTL_2_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF093_DTL_2.set_SetValue("OHIP_ERR_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CODE"));
            fleF093_DTL_2.set_SetValue("OHIP_ERR_DESCRIPTION", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_DESCRIPTION"));
            fleF093_DTL_2.set_SetValue("OHIP_ERR_CAT_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE"));
            fleF093_DTL_2.set_SetValue("ENTRY_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_DATE"));
            fleF093_DTL_2.set_SetValue("ENTRY_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_TIME"));
            fleF093_DTL_2.set_SetValue("ENTRY_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("ENTRY_USER_ID"));
            fleF093_DTL_2.set_SetValue("LAST_MOD_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_DATE"));
            fleF093_DTL_2.set_SetValue("LAST_MOD_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_TIME"));
            fleF093_DTL_2.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF093_DTL_3_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.20448  Generated on: 6/27/2017 12:28:11 PM
    //#-----------------------------------------
    private void fleF093_DTL_3_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF093_DTL_3.set_SetValue("OHIP_ERR_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CODE"));
            fleF093_DTL_3.set_SetValue("OHIP_ERR_DESCRIPTION", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_DESCRIPTION"));
            fleF093_DTL_3.set_SetValue("OHIP_ERR_CAT_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE"));
            fleF093_DTL_3.set_SetValue("ENTRY_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_DATE"));
            fleF093_DTL_3.set_SetValue("ENTRY_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_TIME"));
            fleF093_DTL_3.set_SetValue("ENTRY_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("ENTRY_USER_ID"));
            fleF093_DTL_3.set_SetValue("LAST_MOD_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_DATE"));
            fleF093_DTL_3.set_SetValue("LAST_MOD_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_TIME"));
            fleF093_DTL_3.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF093_DTL_4_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.20448  Generated on: 6/27/2017 12:28:11 PM
    //#-----------------------------------------
    private void fleF093_DTL_4_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF093_DTL_4.set_SetValue("OHIP_ERR_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CODE"));
            fleF093_DTL_4.set_SetValue("OHIP_ERR_DESCRIPTION", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_DESCRIPTION"));
            fleF093_DTL_4.set_SetValue("OHIP_ERR_CAT_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE"));
            fleF093_DTL_4.set_SetValue("ENTRY_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_DATE"));
            fleF093_DTL_4.set_SetValue("ENTRY_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_TIME"));
            fleF093_DTL_4.set_SetValue("ENTRY_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("ENTRY_USER_ID"));
            fleF093_DTL_4.set_SetValue("LAST_MOD_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_DATE"));
            fleF093_DTL_4.set_SetValue("LAST_MOD_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_TIME"));
            fleF093_DTL_4.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF093_DTL_5_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.20448  Generated on: 6/27/2017 12:28:11 PM
    //#-----------------------------------------
    private void fleF093_DTL_5_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF093_DTL_5.set_SetValue("OHIP_ERR_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CODE"));
            fleF093_DTL_5.set_SetValue("OHIP_ERR_DESCRIPTION", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_DESCRIPTION"));
            fleF093_DTL_5.set_SetValue("OHIP_ERR_CAT_CODE", !Fixed, fleF093_HDR_1.GetStringValue("OHIP_ERR_CAT_CODE"));
            fleF093_DTL_5.set_SetValue("ENTRY_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_DATE"));
            fleF093_DTL_5.set_SetValue("ENTRY_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_TIME"));
            fleF093_DTL_5.set_SetValue("ENTRY_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("ENTRY_USER_ID"));
            fleF093_DTL_5.set_SetValue("LAST_MOD_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_DATE"));
            fleF093_DTL_5.set_SetValue("LAST_MOD_TIME", !Fixed, fleF093_HDR_1.GetDecimalValue("LAST_MOD_TIME"));
            fleF093_DTL_5.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleTMP_SERV_ERR_CLAIM_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.20448  Generated on: 6/27/2017 12:28:11 PM
    //#-----------------------------------------
    private void fleTMP_SERV_ERR_CLAIM_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleTMP_SERV_ERR_CLAIM.set_SetValue("ENTRY_DATE", !Fixed, fleF093_HDR_1.GetDecimalValue("ENTRY_DATE"));
            fleTMP_SERV_ERR_CLAIM.set_SetValue("ENTRY_USER_ID", !Fixed, fleF093_HDR_1.GetStringValue("ENTRY_USER_ID"));

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


    #region "Transaction Management Procedures(U021A_DETERMINE_TYPE_OF_ERRORS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:11 PM

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
        fleU021A_EDT_1HT_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_1.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_2.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_3.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_4.Transaction = m_trnTRANS_UPDATE;
        fleF093_HDR_5.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_1.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_2.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_3.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_4.Transaction = m_trnTRANS_UPDATE;
        fleF093_DTL_5.Transaction = m_trnTRANS_UPDATE;
        fleTMP_SERV_ERR_CLAIM.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U021A_DETERMINE_TYPE_OF_ERRORS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:11 PM

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
            fleU021A_EDT_1HT_FILE.Dispose();
            fleF093_HDR_1.Dispose();
            fleF093_HDR_2.Dispose();
            fleF093_HDR_3.Dispose();
            fleF093_HDR_4.Dispose();
            fleF093_HDR_5.Dispose();
            fleF093_DTL_1.Dispose();
            fleF093_DTL_2.Dispose();
            fleF093_DTL_3.Dispose();
            fleF093_DTL_4.Dispose();
            fleF093_DTL_5.Dispose();
            fleTMP_SERV_ERR_CLAIM.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U021A_DETERMINE_TYPE_OF_ERRORS_1)"


    public void Run()
    {

        try
        {
            Request("DETERMINE_TYPE_OF_ERRORS_1");

            while (fleU021A_EDT_1HT_FILE.QTPForMissing())
            {
                // --> GET U021A_EDT_1HT_FILE <--

                fleU021A_EDT_1HT_FILE.GetData();
                // --> End GET U021A_EDT_1HT_FILE <--

                while (fleF093_HDR_1.QTPForMissing("1"))
                {
                    // --> GET F093_HDR_1 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF093_HDR_1.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_1")));

                    fleF093_HDR_1.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F093_HDR_1 <--

                    while (fleF093_HDR_2.QTPForMissing("2"))
                    {
                        // --> GET F093_HDR_2 <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF093_HDR_2.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_2")));

                        fleF093_HDR_2.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F093_HDR_2 <--

                        while (fleF093_HDR_3.QTPForMissing("3"))
                        {
                            // --> GET F093_HDR_3 <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF093_HDR_3.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_3")));

                            fleF093_HDR_3.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F093_HDR_3 <--

                            while (fleF093_HDR_4.QTPForMissing("4"))
                            {
                                // --> GET F093_HDR_4 <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF093_HDR_4.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_4")));

                                fleF093_HDR_4.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F093_HDR_4 <--

                                while (fleF093_HDR_5.QTPForMissing("5"))
                                {
                                    // --> GET F093_HDR_5 <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF093_HDR_5.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_H_CD_5")));

                                    fleF093_HDR_5.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F093_HDR_5 <--

                                    while (fleF093_DTL_1.QTPForMissing("6"))
                                    {
                                        // --> GET F093_DTL_1 <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleF093_DTL_1.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_1")));

                                        fleF093_DTL_1.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                        // --> End GET F093_DTL_1 <--

                                        while (fleF093_DTL_2.QTPForMissing("7"))
                                        {
                                            // --> GET F093_DTL_2 <--
                                            m_strWhere = new StringBuilder(" WHERE ");
                                            m_strWhere.Append(" ").Append(fleF093_DTL_2.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                            m_strWhere.Append(Common.StringToField(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_2")));

                                            fleF093_DTL_2.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                            // --> End GET F093_DTL_2 <--

                                            while (fleF093_DTL_3.QTPForMissing("8"))
                                            {
                                                // --> GET F093_DTL_3 <--
                                                m_strWhere = new StringBuilder(" WHERE ");
                                                m_strWhere.Append(" ").Append(fleF093_DTL_3.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                m_strWhere.Append(Common.StringToField(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_3")));

                                                fleF093_DTL_3.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                // --> End GET F093_DTL_3 <--

                                                while (fleF093_DTL_4.QTPForMissing("9"))
                                                {
                                                    // --> GET F093_DTL_4 <--
                                                    m_strWhere = new StringBuilder(" WHERE ");
                                                    m_strWhere.Append(" ").Append(fleF093_DTL_4.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                    m_strWhere.Append(Common.StringToField(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_4")));

                                                    fleF093_DTL_4.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                    // --> End GET F093_DTL_4 <--

                                                    while (fleF093_DTL_5.QTPForMissing("10"))
                                                    {
                                                        // --> GET F093_DTL_5 <--
                                                        m_strWhere = new StringBuilder(" WHERE ");
                                                        m_strWhere.Append(" ").Append(fleF093_DTL_5.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
                                                        m_strWhere.Append(Common.StringToField(fleU021A_EDT_1HT_FILE.GetStringValue("RAT_RMB_ERROR_T_CD_5")));

                                                        fleF093_DTL_5.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                        // --> End GET F093_DTL_5 <--


                                                        if (Transaction())
                                                        {

                                                            Sort(fleU021A_EDT_1HT_FILE.GetSortValue("RAT_RMB_ACCOUNT_NBR"));



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

            while (Sort(fleU021A_EDT_1HT_FILE, fleF093_HDR_1, fleF093_HDR_2, fleF093_HDR_3, fleF093_HDR_4, fleF093_HDR_5, fleF093_DTL_1, fleF093_DTL_2, fleF093_DTL_3, fleF093_DTL_4,
            fleF093_DTL_5))
            {
                if (QDesign.NULL(X_OHIP_ERR_REF_SERV_SS.Value) > 0)
                {
                    X_SERV_REF_CODE_THIS_REC.Value = X_SERV_REF_CODE_THIS_REC.Value + 1;
                }
                if (QDesign.NULL(X_OHIP_ERR_NON_REF_SERV_SS.Value) > 0)
                {
                    X_SERV_NON_REF_CODE_THIS_REC.Value = X_SERV_NON_REF_CODE_THIS_REC.Value + 1;
                }
                if (QDesign.NULL(X_OHIP_ERR_HDR_SERV_SS.Value) > 0 | QDesign.NULL(X_OHIP_ERR_DTL_SERV_SS.Value) > 0)
                {
                    X_SERV_ERR_CODE_THIS_REC.Value = X_SERV_ERR_CODE_THIS_REC.Value + 1;
                }
                if (QDesign.NULL(X_OHIP_ERR_HDR_ELIG_SS.Value) > 0 | QDesign.NULL(X_OHIP_ERR_DTL_ELIG_SS.Value) > 0)
                {
                    X_ELIG_ERR_CODE_THIS_REC.Value = X_ELIG_ERR_CODE_THIS_REC.Value + 1;
                }
                REC_COUNTER.Value = REC_COUNTER.Value + 1;

                fleTMP_SERV_ERR_CLAIM.OutPut(OutPutType.Add, fleU021A_EDT_1HT_FILE.At("RAT_RMB_ACCOUNT_NBR"), null);

                Reset(ref X_SERV_REF_CODE_THIS_REC, fleU021A_EDT_1HT_FILE.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_SERV_NON_REF_CODE_THIS_REC, fleU021A_EDT_1HT_FILE.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_SERV_ERR_CODE_THIS_REC, fleU021A_EDT_1HT_FILE.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref X_ELIG_ERR_CODE_THIS_REC, fleU021A_EDT_1HT_FILE.At("RAT_RMB_ACCOUNT_NBR"));
                Reset(ref REC_COUNTER, fleU021A_EDT_1HT_FILE.At("RAT_RMB_ACCOUNT_NBR"));

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
            EndRequest("DETERMINE_TYPE_OF_ERRORS_1");

        }

    }







    #endregion


}
//DETERMINE_TYPE_OF_ERRORS_1




