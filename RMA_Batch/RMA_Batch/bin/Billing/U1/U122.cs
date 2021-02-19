
#region "Screen Comments"

// #V PROGRAM-ID.     U122.QTS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// - Update F119-DOCTOR-YTD with values from current EP
// run (that were placed into *F119)
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 93/Apr/19  ____   B.E.     - original
// 93/SEP/15  ____   B.E.     - added access to F190 so that GROSS amts
// are updated into F119-YTD for INCOME based
// based transactions and NET for NON-INCOME
// 93/NOV/26  ____   B.E.     - STATUS updated into YTD only, MTD zeroed
// 93/DEC/24  ____   B.E.     - YTDEAR updated into YTD only, MTD zeroed
// 93/DEC/28  ____   B.E.     - variables renamed to reflect change in
// in *F119 from AMT-GROSS to X-AMT-GROSS
// 93/DEC/31  ____   B.E.     - changed f119_tithe to unique keys
// 96/JAN/19  ____   M.C.     - INCREQ & INCTAR updated into YTD
// only, MTD zeroed. (SMS 147)
// 96/APR/18  ____   Y.B.     - ADD  REVCLA  TO TMP-AMT-MTD AND
// TO TMP-AMT-YTD (to pick up net-amt)
// REVCLA ONE TIME ONLY. MAKE TMPMTD
// AND TMPYTD THE SAME YTD DOES NOT
// UPDATE OTHERWISE.
// 98/oct/22         B.E.   - f119_tithe database fields defined as `numeric
// size 8` as part of unix conversion.
// tmp-amt fields changed to match.
// 1999/Feb/18  S.B.  - Checked for Y2K.
// 2003/dec/24          A.A.  - alpha doctor nbr
// 2004/mar/01          b.e.  - BILADJ coded to use net amount instead of gross
// 2005/mar/21  b.e. - change x-amt-gross and x-amt-net to 
// to w- variable names to match u119
// - and change x-rec-type to w-rec-type
// - and change reporting-seq to payeft-seq and
// comp-code-group to payeft-group to match u122 
// 2005/apr/21  b.e  - reverse above change ??
// 2008/may/27  M.C.    - add rec-type to indexes and change the access
// linkage to include rec-type
// - include f020-doctor-mstr to the access 
// statement
// 2008/jun/10   M.C.    - add a new request to add/update 
// f119-doctor-ytd from f119_tithe subfile which
// is created from u115a.qts
// - also add `on errors report` on output 
// statement in the first request
// 2008/jul/02 brad1  - calculations were using gross amount from f119. This
// doesn`t take into consideration the factor which could
// have reduced the net amount. changing it for `I`ncome
// type comp codes to use net not gross amount.
// 2008/oct/25 brad2  - undo above change
// 2008/oct/25 brad3  - putback change - write all INCOME records to f119 as unfactored amounts
// 2008/nov/18 M.C.   - for comp-code `TITTHE1/2/3` or `TITHD1/2/3`, use tmp-amt-ytd = amt-ytd + x-amt-net 
// and tmp-amt-mtd = x-amt-net of f119
// - delete the new request u122_run_1_update_f119_tithe that was created on 2008/jun/10
// is not needed
// 2012/May/02 MC1    - set ytd-amt = 0 for `DEFIC` & `ADVOUT`
// 2015/Oct/01 MC2    - change to use x-amt-gross for comp-code `TITHD1/2/3` because x-amt-net = 0 was 
// set in u117.qts for `D` comp-type
// - Solo Sep payroll did not update properly for TITHD for rec-type `A` only, `D` rec-type were okay


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U122 : BaseClassControl
{

    private U122 m_U122;

    public U122(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U122(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U122 != null))
        {
            m_U122.CloseTransactionObjects();
            m_U122 = null;
        }
    }

    public U122 GetU122(int Level)
    {
        if (m_U122 == null)
        {
            m_U122 = new U122("U122", Level);
        }
        else
        {
            m_U122.ResetValues();
        }
        return m_U122;
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

            U122_RUN_0_UPDATE_F119_TITHE_1 RUN_0_UPDATE_F119_TITHE_1 = new U122_RUN_0_UPDATE_F119_TITHE_1(Name, Level);
            RUN_0_UPDATE_F119_TITHE_1.Run();
            RUN_0_UPDATE_F119_TITHE_1.Dispose();
            RUN_0_UPDATE_F119_TITHE_1 = null;

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



public class U122_RUN_0_UPDATE_F119_TITHE_1 : U122
{

    public U122_RUN_0_UPDATE_F119_TITHE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "F119_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF119_DOCTOR_YTD.SetItemFinals += fleF119_DOCTOR_YTD_SetItemFinals;
        TMP_AMT_YTD.GetValue += TMP_AMT_YTD_GetValue;
        TMP_AMT_MTD.GetValue += TMP_AMT_MTD_GetValue;
        fleF119_ADD.SetItemFinals += fleF119_ADD_SetItemFinals;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF119_ADD.InitializeItems += fleF119_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U122_RUN_0_UPDATE_F119_TITHE_1)"

    private SqlFileObject fleF119;
    private SqlFileObject fleF119_DOCTOR_YTD;

    private void fleF119_DOCTOR_YTD_SetItemFinals()
    {

        try
        {
            fleF119_DOCTOR_YTD.set_SetValue("AMT_MTD", TMP_AMT_MTD.Value);
            fleF119_DOCTOR_YTD.set_SetValue("AMT_YTD", TMP_AMT_YTD.Value);


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
    private SqlFileObject fleF190_COMP_CODES;
    private DDecimal TMP_AMT_YTD = new DDecimal("TMP_AMT_YTD", 10);
    private void TMP_AMT_YTD_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "BILADJ" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "TITHE1" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "TITHE2" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "TITHE3")
            {
                CurrentValue = fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") + fleF119.GetDecimalValue("X_AMT_NET");
            }
            else if (QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "STATUS" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "YTDEAR" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "INCREQ" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "INCTAR")
            {
                CurrentValue = fleF119.GetDecimalValue("X_AMT_GROSS");
            }
            else if (QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "REVCLA" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "DEFIC" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "ADVOUT")
            {
                CurrentValue = fleF119.GetDecimalValue("X_AMT_NET");
            }
            else if (QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "TOTDED")
            {
                CurrentValue = fleF119.GetDecimalValue("X_AMT_NET") + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD");
            }
            else
            {
                CurrentValue = fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") + fleF119.GetDecimalValue("X_AMT_GROSS");
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
    private DDecimal TMP_AMT_MTD = new DDecimal("TMP_AMT_MTD", 10);
    private void TMP_AMT_MTD_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "STATUS" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "YTDEAR" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "INCREQ" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "INCTAR")
            {
                CurrentValue = 0;
            }
            else if (QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "REVCLA" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "BILADJ" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "TITHE1" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "TITHE2" | QDesign.NULL(fleF119.GetStringValue("COMP_CODE")) == "TITHE3")
            {
                CurrentValue = fleF119.GetDecimalValue("X_AMT_NET");
            }
            else
            {
                CurrentValue = fleF119.GetDecimalValue("X_AMT_GROSS");
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
    private SqlFileObject fleF119_ADD;

    private void fleF119_ADD_SetItemFinals()
    {

        try
        {
            fleF119_ADD.set_SetValue("DOC_NBR", fleF119.GetStringValue("DOC_NBR"));
            fleF119_ADD.set_SetValue("COMP_CODE", fleF119.GetStringValue("COMP_CODE"));
            fleF119_ADD.set_SetValue("PROCESS_SEQ", fleF119.GetDecimalValue("REPORTING_SEQ"));
            fleF119_ADD.set_SetValue("COMP_CODE_GROUP", fleF119.GetStringValue("COMP_CODE_GROUP"));
            fleF119_ADD.set_SetValue("REC_TYPE", fleF119.GetStringValue("REC_TYPE"));
            fleF119_ADD.set_SetValue("AMT_MTD", TMP_AMT_MTD.Value);
            fleF119_ADD.set_SetValue("AMT_YTD", TMP_AMT_YTD.Value);
            fleF119_ADD.set_SetValue("DOC_OHIP_NBR", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));


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


    #region "Standard Generated Procedures(U122_RUN_0_UPDATE_F119_TITHE_1)"


    #region "Automatic Item Initialization(U122_RUN_0_UPDATE_F119_TITHE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:16 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:15 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("DOC_OHIP_NBR"));

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
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:16 PM
    //#-----------------------------------------
    private void fleF190_COMP_CODES_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("COMP_CODE", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE"));
            fleF190_COMP_CODES.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("PROCESS_SEQ"));
            fleF190_COMP_CODES.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE_GROUP"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_DATE", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("LAST_MOD_DATE"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_TIME", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("LAST_MOD_TIME"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF119_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:16 PM
    //#-----------------------------------------
    private void fleF119_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF119_ADD.set_SetValue("DOC_NBR", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR"));
            fleF119_ADD.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("DOC_OHIP_NBR"));
            fleF119_ADD.set_SetValue("COMP_CODE", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE"));
            fleF119_ADD.set_SetValue("PROCESS_SEQ", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("PROCESS_SEQ"));
            fleF119_ADD.set_SetValue("COMP_CODE_GROUP", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE_GROUP"));
            fleF119_ADD.set_SetValue("REC_TYPE", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("REC_TYPE"));
            fleF119_ADD.set_SetValue("REC_1", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("REC_1"));
            fleF119_ADD.set_SetValue("AMT_MTD", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD"));
            fleF119_ADD.set_SetValue("AMT_YTD", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD"));
            fleF119_ADD.set_SetValue("FILLER", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("FILLER"));
            fleF119_ADD.set_SetValue("TEXT", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("TEXT"));
            fleF119_ADD.set_SetValue("LAST_MOD_DATE", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("LAST_MOD_DATE"));
            fleF119_ADD.set_SetValue("LAST_MOD_TIME", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("LAST_MOD_TIME"));
            fleF119_ADD.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("LAST_MOD_USER_ID"));

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


    #region "Transaction Management Procedures(U122_RUN_0_UPDATE_F119_TITHE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:14 PM

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
        fleF119.Transaction = m_trnTRANS_UPDATE;
        fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF119_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U122_RUN_0_UPDATE_F119_TITHE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:14 PM

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
            fleF119.Dispose();
            fleF119_DOCTOR_YTD.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF119_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U122_RUN_0_UPDATE_F119_TITHE_1)"


    public void Run()
    {

        try
        {
            Request("RUN_0_UPDATE_F119_TITHE_1");

            while (fleF119.QTPForMissing())
            {
                // --> GET F119 <--

                fleF119.GetData();
                // --> End GET F119 <--

                while (fleF119_DOCTOR_YTD.QTPForMissing("1"))
                {
                    // --> GET F119_DOCTOR_YTD <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF119_DOCTOR_YTD.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF119.GetStringValue("DOC_NBR")));
                    m_strWhere.Append(" And ").Append(fleF119_DOCTOR_YTD.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF119.GetStringValue("COMP_CODE")));
                    m_strWhere.Append(" And ").Append(fleF119_DOCTOR_YTD.ElementOwner("REC_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF119.GetStringValue("REC_TYPE")));

                    fleF119_DOCTOR_YTD.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F119_DOCTOR_YTD <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF119.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF190_COMP_CODES.QTPForMissing("3"))
                        {
                            // --> GET F190_COMP_CODES <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF119.GetStringValue("COMP_CODE")));

                            fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F190_COMP_CODES <--


                            if (Transaction())
                            {
                                fleF119_DOCTOR_YTD.OutPut(OutPutType.Update, null, fleF119_DOCTOR_YTD.Exists());


                                fleF119_ADD.OutPut(OutPutType.Add, null, !fleF119_DOCTOR_YTD.Exists());

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
            EndRequest("RUN_0_UPDATE_F119_TITHE_1");

        }

    }







    #endregion


}
//RUN_0_UPDATE_F119_TITHE_1




