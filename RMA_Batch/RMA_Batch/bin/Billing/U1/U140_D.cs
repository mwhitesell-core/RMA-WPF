
#region "Screen Comments"

// Program: u140_d.qts
// Purpose: Calculate individual doctor AFP conversion payment /submission amounts 
// factoring values sent from MOH by the RA payments
// For doctors whose group is  R eport only, there is no existing
// doctor record in f075 so add with zero RMA doctor number and
// payment to 100% for that transaction
// modification history
// 2004/jul/01 b.e. - original
// 2004/aug/12 b.e. - add record to f075 if payment comes in for doctor not on file .. 
// 2004/oct/16 b.e. - store afp-submission-amt in tmp-counter-2
// 2005/mar/08 M.C. - substitute afp-payment-percentage with afp-multi-doc-ra-percentage
// 2005/apr/08 b.e. - set lock update statement
// 2005/jun/09 M.C. - change def factored with zoned*11 numeric
// 2007/feb/26 b.e. - add logic to process doctors not already in f075 whose
// afp group`s process flag is not  R eport only
// 2007/may/01 b.e. - changed select to include if afp file has <> 0 payment
// 2007/may/01 b.e. - undo above change - hard code doctor
// 2007/jul/25 M.C. - reference doc-afp-paym-group of f075-afp-doc-mstr instead of f020-doctor-mstr
// - include file qualifier on sort and output statements
// 2007/aug/19 b.e. - undo moira`s change in select stmnt - check afp group in f020 not f075
// 2007/sep/10 M.C. - uncomment the afp-conversion-amt <> 0   in the selection criteria
// Brad mentioned: Try uncommenting the commented out line - ie if non-zero 
// afp-conversion-payment then include ..  if the doctor isn`t terminated we want 
// to see payment but if he`s terminated and there is either an RA payment or conversion payment then include .. 
// - when storing afp-reporting-mth in u140_d1, use from f074 instead of f075
// 2008/jun/26 M.C. - comment out the last part of the select statement, Yasemin would like to display what is coming
// from the incoming file regardless the status of the doctors or the amount.
// 2008/sep/04 M.C. - comment out the check of afp-group-process-flag of f074-afp-group-mstr =  E 
// 2008/oct/14 M.C. - undo comment the check of afp-group-process-flag of f074-afp-group-mstr =  E  above
// 2008/oct/20 M.C. - comment out the check of afp-group-process-flag of f074-afp-group-mstr =  E 
// 2008/nov/03 M.C. - undo comment the check of afp-group-process-flag of f074-afp-group-mstr =  E  above
// we should only pick up `E`arnings type groups, `R`eporting type groups have been extracted
// from u140_k.qzs which will add to u140_d1 subfile.  Without the change, it will print double
// the amount for `R`eporting type groups.
// 2008/nov/04 M.C. - reinstate back to 2008/Oct/20, we should pick up all groups; otherwise, NONRBP will not be 
// generated for `R`eporting Only groups, eliminate the execution of u140_k.qzs will not print
// double the amount on r140_b.txt for `R`eporting Only groups
// 2012/Feb/23 MC1  - change the access, select and sort statement and add define item
// set lock file update 
// -------------------------------------------------------


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U140_D : BaseClassControl
{

    private U140_D m_U140_D;

    public U140_D(string Name, int Level) : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U140_D(string Name, int Level, bool Request) : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U140_D != null))
        {
            m_U140_D.CloseTransactionObjects();
            m_U140_D = null;
        }
    }

    public U140_D GetU140_D(int Level)
    {
        if (m_U140_D == null)
        {
            m_U140_D = new U140_D("U140_D", Level);
        }
        else
        {
            m_U140_D.ResetValues();
        }
        return m_U140_D;
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

            U140_D_U140_D1_GET_TRANS_IN_A2S_1 U140_D1_GET_TRANS_IN_A2S_1 = new U140_D_U140_D1_GET_TRANS_IN_A2S_1(Name, Level);
            U140_D1_GET_TRANS_IN_A2S_1.Run();
            U140_D1_GET_TRANS_IN_A2S_1.Dispose();
            U140_D1_GET_TRANS_IN_A2S_1 = null;

            U140_D_U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2 U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2 = new U140_D_U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2(Name, Level);
            U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2.Run();
            U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2.Dispose();
            U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2 = null;

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



public class U140_D_U140_D1_GET_TRANS_IN_A2S_1 : U140_D
{

    public U140_D_U140_D1_GET_TRANS_IN_A2S_1(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleAFP_A2S_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "AFP_A2S_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU140_D1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_D1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_DOC_GROUP_EARNINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_DOCTOR_ALPHA", "TMP_DOC_GROUP_EARNINGS", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF075_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "F075_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF075_AFP_DOC_MSTR.SetItemFinals += fleF075_AFP_DOC_MSTR_SetItemFinals;
        X_DOC_NAME.GetValue += X_DOC_NAME_GetValue;
        X_CONVERSION_AMT_UNFACTORED.GetValue += X_CONVERSION_AMT_UNFACTORED_GetValue;
        X_CONVERSION_AMT.GetValue += X_CONVERSION_AMT_GetValue;
        X_SUBMISSION_AMT_UNFACTORED.GetValue += X_SUBMISSION_AMT_UNFACTORED_GetValue;
        X_SUBMISSION_AMT.GetValue += X_SUBMISSION_AMT_GetValue;
        X_TERM_DATE.GetValue += X_TERM_DATE_GetValue;
        fleTMP_DOC_GROUP_EARNINGS.SetItemFinals += fleTMP_DOC_GROUP_EARNINGS_SetItemFinals;
        fleF075_ADD.SetItemFinals += fleF075_ADD_SetItemFinals;
        fleF075_AFP_DOC_MSTR.InitializeItems += fleF075_AFP_DOC_MSTR_AutomaticItemInitialization;
        fleF074_AFP_GROUP_MSTR.InitializeItems += fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization;
        fleTMP_DOC_GROUP_EARNINGS.InitializeItems += fleTMP_DOC_GROUP_EARNINGS_AutomaticItemInitialization;
        fleF075_ADD.InitializeItems += fleF075_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_D_U140_D1_GET_TRANS_IN_A2S_1)"

    private SqlFileObject fleAFP_A2S_FILE;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF075_AFP_DOC_MSTR;

    private void fleF075_AFP_DOC_MSTR_SetItemFinals()
    {

        try
        {
            fleF075_AFP_DOC_MSTR.set_SetValue("AFP_REPORTING_MTH", fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_REPORTING_MTH"));
            fleF075_AFP_DOC_MSTR.set_SetValue("AFP_PAYMENT_AMT_TOTAL", X_CONVERSION_AMT_UNFACTORED.Value);
            fleF075_AFP_DOC_MSTR.set_SetValue("AFP_PAYMENT_AMT", X_CONVERSION_AMT.Value);
            fleF075_AFP_DOC_MSTR.set_SetValue("AFP_PAYMENT_AMT", X_CONVERSION_AMT.Value);
            fleF075_AFP_DOC_MSTR.set_SetValue("AFP_SUBMISSION_AMT", X_SUBMISSION_AMT.Value);
            fleF075_AFP_DOC_MSTR.set_SetValue("AFP_SUBMISSION_AMT", X_SUBMISSION_AMT.Value);


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

    private SqlFileObject fleF074_AFP_GROUP_MSTR;
    private SqlFileObject fleF070_DEPT_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if ((QDesign.NULL(fleAFP_A2S_FILE.GetStringValue("DOC_AFP_PAYM_GROUP")) == QDesign.NULL(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"))))
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

    private DCharacter X_DOC_NAME = new DCharacter("X_DOC_NAME", 35);
    private void X_DOC_NAME_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Pack(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME") + ", " + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3") + " (" + fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR") + ")");



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
    private DDecimal X_CONVERSION_AMT_UNFACTORED = new DDecimal("X_CONVERSION_AMT_UNFACTORED", 11);
    private void X_CONVERSION_AMT_UNFACTORED_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleAFP_A2S_FILE.GetStringValue("AFP_CONVERSION_SIGN")) == QDesign.NULL(" "))
            {
                CurrentValue = fleAFP_A2S_FILE.GetDecimalValue("AFP_CONVERSION_AMT");
            }
            else
            {
                CurrentValue = 0 - fleAFP_A2S_FILE.GetDecimalValue("AFP_CONVERSION_AMT");
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
    private DDecimal X_CONVERSION_AMT = new DDecimal("X_CONVERSION_AMT", 11);
    private void X_CONVERSION_AMT_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.Round(X_CONVERSION_AMT_UNFACTORED.Value * (fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE") / 100000), 0, RoundOptionTypes.Near);


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
    private DDecimal X_SUBMISSION_AMT_UNFACTORED = new DDecimal("X_SUBMISSION_AMT_UNFACTORED", 11);
    private void X_SUBMISSION_AMT_UNFACTORED_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleAFP_A2S_FILE.GetStringValue("AFP_SUBMISSION_SIGN")) == QDesign.NULL(" "))
            {
                CurrentValue = fleAFP_A2S_FILE.GetDecimalValue("AFP_SUBMISSION_AMT");
            }
            else
            {
                CurrentValue = 0 - fleAFP_A2S_FILE.GetDecimalValue("AFP_SUBMISSION_AMT");
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
    private DDecimal X_SUBMISSION_AMT = new DDecimal("X_SUBMISSION_AMT", 11);
    private void X_SUBMISSION_AMT_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.Round(X_SUBMISSION_AMT_UNFACTORED.Value * (fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE") / 100000), 0, RoundOptionTypes.Near);


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
    private DDecimal X_TERM_DATE = new DDecimal("X_TERM_DATE");
    private void X_TERM_DATE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) == 0)
            {
                CurrentValue = 20991231;
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM");
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



    private SqlFileObject fleU140_D1;
    private SqlFileObject fleTMP_DOC_GROUP_EARNINGS;

    private void fleTMP_DOC_GROUP_EARNINGS_SetItemFinals()
    {

        try
        {
            fleTMP_DOC_GROUP_EARNINGS.set_SetValue("DOC_OHIP_NBR", QDesign.NConvert(fleAFP_A2S_FILE.GetStringValue("DOC_AFP_PAYM_SOLO")));
            fleTMP_DOC_GROUP_EARNINGS.set_SetValue("DOC_NBR", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleTMP_DOC_GROUP_EARNINGS.set_SetValue("TMP_ALPHA_FIELD_1", fleAFP_A2S_FILE.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleTMP_DOC_GROUP_EARNINGS.set_SetValue("TMP_COUNTER_1", X_CONVERSION_AMT.Value);
            fleTMP_DOC_GROUP_EARNINGS.set_SetValue("TMP_COUNTER_2", X_SUBMISSION_AMT.Value);


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

    private SqlFileObject fleF075_ADD;

    private void fleF075_ADD_SetItemFinals()
    {

        try
        {
            fleF075_ADD.set_SetValue("DOC_NBR", fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF075_ADD.set_SetValue("DOC_OHIP_NBR", QDesign.NConvert(fleAFP_A2S_FILE.GetStringValue("DOC_AFP_PAYM_SOLO")));
            fleF075_ADD.set_SetValue("DOC_AFP_PAYM_GROUP", fleAFP_A2S_FILE.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF075_ADD.set_SetValue("AFP_REPORTING_MTH", fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_REPORTING_MTH"));
            fleF075_ADD.set_SetValue("AFP_PAYMENT_AMT_TOTAL", X_CONVERSION_AMT_UNFACTORED.Value);
            fleF075_ADD.set_SetValue("AFP_PAYMENT_AMT", X_CONVERSION_AMT.Value);
            fleF075_ADD.set_SetValue("AFP_SUBMISSION_AMT", X_SUBMISSION_AMT.Value);


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


    #region "Standard Generated Procedures(U140_D_U140_D1_GET_TRANS_IN_A2S_1)"


    #region "Automatic Item Initialization(U140_D_U140_D1_GET_TRANS_IN_A2S_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:32 PM

    //#-----------------------------------------
    //# fleF075_AFP_DOC_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:26 PM
    //#-----------------------------------------
    private void fleF075_AFP_DOC_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));

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
    //# fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:26 PM
    //#-----------------------------------------
    private void fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF074_AFP_GROUP_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            //TODO: Manual steps may be required.
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_REPORTING_MTH", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("AFP_REPORTING_MTH"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_MULTI_DOC_RA_PERCENTAGE", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT_TOTAL", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT_TOTAL"));

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
    //# fleTMP_DOC_GROUP_EARNINGS_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:31 PM
    //#-----------------------------------------
    private void fleTMP_DOC_GROUP_EARNINGS_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleTMP_DOC_GROUP_EARNINGS.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleTMP_DOC_GROUP_EARNINGS.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));

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
    //# fleF075_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:32 PM
    //#-----------------------------------------
    private void fleF075_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF075_ADD.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF075_ADD.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF075_ADD.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            //TODO: Manual steps may be required.
            fleF075_ADD.set_SetValue("AFP_REPORTING_MTH", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("AFP_REPORTING_MTH"));
            fleF075_ADD.set_SetValue("AFP_MULTI_DOC_RA_PERCENTAGE", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE"));
            fleF075_ADD.set_SetValue("RA_PAYMENT_AMT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("RA_PAYMENT_AMT"));
            fleF075_ADD.set_SetValue("RA_PAYMENT_AMT_TOTAL", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("RA_PAYMENT_AMT_TOTAL"));
            fleF075_ADD.set_SetValue("AFP_PAYMENT_AMT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT"));
            fleF075_ADD.set_SetValue("AFP_PAYMENT_AMT_TOTAL", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT_TOTAL"));
            fleF075_ADD.set_SetValue("AFP_SUBMISSION_AMT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_SUBMISSION_AMT"));
            fleF075_ADD.set_SetValue("AFP_DUPLICATE_DOC_COUNT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_DUPLICATE_DOC_COUNT"));

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


    #region "Transaction Management Procedures(U140_D_U140_D1_GET_TRANS_IN_A2S_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:25 PM

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
        fleAFP_A2S_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF070_DEPT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU140_D1.Transaction = m_trnTRANS_UPDATE;
        fleTMP_DOC_GROUP_EARNINGS.Transaction = m_trnTRANS_UPDATE;
        fleF075_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_D_U140_D1_GET_TRANS_IN_A2S_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:25 PM

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
            fleAFP_A2S_FILE.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF075_AFP_DOC_MSTR.Dispose();
            fleF074_AFP_GROUP_MSTR.Dispose();
            fleF070_DEPT_MSTR.Dispose();
            fleU140_D1.Dispose();
            fleTMP_DOC_GROUP_EARNINGS.Dispose();
            fleF075_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_D_U140_D1_GET_TRANS_IN_A2S_1)"


    public void Run()
    {

        try
        {
            Request("U140_D1_GET_TRANS_IN_A2S_1");

            while (fleAFP_A2S_FILE.QTPForMissing())
            {
                // --> GET AFP_A2S_FILE <--

                fleAFP_A2S_FILE.GetData();
                // --> End GET AFP_A2S_FILE <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append(((QDesign.NConvert(fleAFP_A2S_FILE.GetStringValue("DOC_AFP_PAYM_SOLO")))));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF075_AFP_DOC_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F075_AFP_DOC_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                        fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F075_AFP_DOC_MSTR <--

                        while (fleF074_AFP_GROUP_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F074_AFP_GROUP_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleAFP_A2S_FILE.GetStringValue("DOC_AFP_PAYM_GROUP")));

                            fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F074_AFP_GROUP_MSTR <--

                            while (fleF070_DEPT_MSTR.QTPForMissing("4"))
                            {
                                // --> GET F070_DEPT_MSTR <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ");
                                m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")));

                                fleF070_DEPT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F070_DEPT_MSTR <--


                                if (Transaction())
                                {

                                    if (Select_If())
                                    {

                                        Sort(fleAFP_A2S_FILE.GetSortValue("DOC_AFP_PAYM_SOLO"), fleAFP_A2S_FILE.GetSortValue("DOC_AFP_PAYM_GROUP"), X_TERM_DATE.Value, fleF020_DOCTOR_MSTR.GetSortValue("DOC_NBR"));



                                    }

                                }

                            }

                        }

                    }

                }

            }


            while (Sort(fleAFP_A2S_FILE, fleF020_DOCTOR_MSTR, fleF075_AFP_DOC_MSTR, fleF074_AFP_GROUP_MSTR, fleF070_DEPT_MSTR))
            {


                SubFile(ref m_trnTRANS_UPDATE, ref fleU140_D1, fleAFP_A2S_FILE.At("DOC_AFP_PAYM_SOLO") || fleAFP_A2S_FILE.At("DOC_AFP_PAYM_GROUP") || At(X_TERM_DATE) || fleF020_DOCTOR_MSTR.At("DOC_NBR"), SubFileType.Keep, fleAFP_A2S_FILE, "AFP_TRANSACTION_ID", "AFP_RECORD_ID", "DOC_AFP_PAYM_GROUP", fleF074_AFP_GROUP_MSTR, "AFP_GROUP_NAME",
                fleAFP_A2S_FILE, "DOC_AFP_PAYM_SOLO", fleF020_DOCTOR_MSTR, "DOC_NBR", fleAFP_A2S_FILE, "AFP_SOLO_NAME", X_DOC_NAME, fleF070_DEPT_MSTR, fleAFP_A2S_FILE, "AFP_PAYMENT_PERCENTAGE",
                fleF075_AFP_DOC_MSTR, "AFP_MULTI_DOC_RA_PERCENTAGE", "AFP_PAYMENT_AMT", "AFP_PAYMENT_AMT", "AFP_SUBMISSION_AMT", "AFP_SUBMISSION_AMT", X_CONVERSION_AMT, X_SUBMISSION_AMT, fleF074_AFP_GROUP_MSTR, "AFP_GROUP_PROCESS_FLAG",
                fleF020_DOCTOR_MSTR, "DOC_DATE_FAC_TERM", fleF074_AFP_GROUP_MSTR, "AFP_REPORTING_MTH", "AFP_REPORTING_MTH");





                fleTMP_DOC_GROUP_EARNINGS.OutPut(OutPutType.Add);





                fleF075_AFP_DOC_MSTR.OutPut(OutPutType.Update, null, fleF075_AFP_DOC_MSTR.Exists());






                fleF075_ADD.OutPut(OutPutType.Add, null, !fleF075_AFP_DOC_MSTR.Exists());


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
            EndRequest("U140_D1_GET_TRANS_IN_A2S_1");

        }

    }




    #endregion


}
//U140_D1_GET_TRANS_IN_A2S_1



public class U140_D_U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2 : U140_D
{

    public U140_D_U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF075_AFP_DOC_MSTR.SetItemFinals += fleF075_AFP_DOC_MSTR_SetItemFinals;
        fleF075_AFP_DOC_MSTR.InitializeItems += fleF075_AFP_DOC_MSTR_AutomaticItemInitialization;
        fleF074_AFP_GROUP_MSTR.InitializeItems += fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_D_U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF075_AFP_DOC_MSTR;

    private void fleF075_AFP_DOC_MSTR_SetItemFinals()
    {

        try
        {
            fleF075_AFP_DOC_MSTR.set_SetValue("AFP_REPORTING_MTH", fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_REPORTING_MTH"));


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

    private SqlFileObject fleF074_AFP_GROUP_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0')) == 0 | QDesign.NULL(fleF075_AFP_DOC_MSTR.GetDecimalValue("RA_PAYMENT_AMT")) != 0)
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


    #region "Standard Generated Procedures(U140_D_U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2)"


    #region "Automatic Item Initialization(U140_D_U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:32 PM

    //#-----------------------------------------
    //# fleF075_AFP_DOC_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:32 PM
    //#-----------------------------------------
    private void fleF075_AFP_DOC_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));

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
    //# fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:32 PM
    //#-----------------------------------------
    private void fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF074_AFP_GROUP_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            //TODO: Manual steps may be required.
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_REPORTING_MTH", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("AFP_REPORTING_MTH"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_MULTI_DOC_RA_PERCENTAGE", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT_TOTAL", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT_TOTAL"));

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


    #region "Transaction Management Procedures(U140_D_U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:25 PM

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
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_D_U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:25 PM

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
            fleF020_DOCTOR_MSTR.Dispose();
            fleF075_AFP_DOC_MSTR.Dispose();
            fleF074_AFP_GROUP_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_D_U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2)"


    public void Run()
    {

        try
        {
            Request("U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--

                while (fleF075_AFP_DOC_MSTR.QTPForMissing("1"))
                {
                    // --> GET F075_AFP_DOC_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                    fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F075_AFP_DOC_MSTR <--

                    while (fleF074_AFP_GROUP_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F074_AFP_GROUP_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));

                        fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F074_AFP_GROUP_MSTR <--


                        if (Transaction())
                        {

                            if (Select_If())
                            {



                                fleF075_AFP_DOC_MSTR.OutPut(OutPutType.Update);


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
            EndRequest("U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2");

        }

    }




    #endregion


}
//U140_D5_UPDATE_F075_INCLUDE_TERMED_DOC_WITH_RA_AMT_2




