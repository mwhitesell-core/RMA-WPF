#region "Screen Comments"

// #> Program-id.     u030bb_1.qts
// ((C)) Dyad Technologies
// Program Purpose:  - separate module called by u030bb.qts to extract
// current RAT create f088-dtl recs and update
// f088-hdr records with appropriate charge status
// and OHIP error code.
// - Placed into separate module so that if the charge
// rules change, this module can be re-run for any
// number of RATs by simplying running the u033b_1
// module and passing the RAT`s PAYMENT DATE
// MODIFICATION HISTORY
// DATE    WHO    DESCRIPTION
// 2000/jul/13 B.E.   - original
// 2000/jul/25 M.C.   - include ped in the u030bb_chargeable_detail subfile,
// - include ped in the access statement in the request
// u030bb_update_f088_dtl
// 2003/dec/23 A.A.   - alpha doctor nbr
// 2009/jan/15 M.C.   - there is a flaw in the last request, ohip-err-code did not set properly from subfile
// ohip err code in f088 is blank, change to set lock record update
// no charge for I4 for clinic 88 is added in $use/costing_charge_select.use
// 2013/Nov/05 MC1    - whatever defined in selection criteria in u030b_autoadj_clinic_dtl.qts should have no charge
// add/modify in $use/costing_charge_select.use
// 2016/Jan/28 MC2    - modify/add selection criteria in $use/costing_charge_select.use
// 2009/01/15 - MC

#endregion "Screen Comments"

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class U030BB_1 : BaseClassControl
{
    private U030BB_1 m_U030BB_1;

    public U030BB_1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_PED = new CoreDecimal("W_PED", 8, this, ResetTypes.ResetAtStartup);
    }

    public U030BB_1(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_PED = new CoreDecimal("W_PED", 8, this, ResetTypes.ResetAtStartup);
    }

    public override void Dispose()
    {
        if ((m_U030BB_1 != null))
        {
            m_U030BB_1.CloseTransactionObjects();
            m_U030BB_1 = null;
        }
    }

    public U030BB_1 GetU030BB_1(int Level)
    {
        if (m_U030BB_1 == null)
        {
            m_U030BB_1 = new U030BB_1("U030BB_1", Level);
        }
        else
        {
            m_U030BB_1.ResetValues();
        }
        return m_U030BB_1;
    }

    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    protected CoreDecimal W_PED;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;

    #endregion "Declarations (Variables, Files and Transactions)"

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {
        try
        {
            U030BB_1_GET_ICONST_CLINIC_VALUES_1 GET_ICONST_CLINIC_VALUES_1 = new U030BB_1_GET_ICONST_CLINIC_VALUES_1(Name, Level);
            GET_ICONST_CLINIC_VALUES_1.Run();
            GET_ICONST_CLINIC_VALUES_1.Dispose();
            GET_ICONST_CLINIC_VALUES_1 = null;

            U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2 U030BB_EXTRACT_CHARGEABLE_DTLS_2 = new U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2(Name, Level);
            U030BB_EXTRACT_CHARGEABLE_DTLS_2.Run();
            U030BB_EXTRACT_CHARGEABLE_DTLS_2.Dispose();
            U030BB_EXTRACT_CHARGEABLE_DTLS_2 = null;

            U030BB_1_U030BB_UPDATE_F088_DTL_3 U030BB_UPDATE_F088_DTL_3 = new U030BB_1_U030BB_UPDATE_F088_DTL_3(Name, Level);
            U030BB_UPDATE_F088_DTL_3.Run();
            U030BB_UPDATE_F088_DTL_3.Dispose();
            U030BB_UPDATE_F088_DTL_3 = null;

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

    #endregion "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    #endregion "Renaissance Architect Migration Services Default Regions"
}

public class U030BB_1_GET_ICONST_CLINIC_VALUES_1 : U030BB_1
{
    public U030BB_1_GET_ICONST_CLINIC_VALUES_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_PED = new CoreDecimal("W_PED", 8, this, ResetTypes.ResetAtStartup);
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC.Choose += fleICONST_MSTR_REC_Choose;
    }

    #region "Declarations (Variables, Files and Transactions)(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"

    protected CoreDecimal W_PED;
    private SqlFileObject fleICONST_MSTR_REC;

    private void fleICONST_MSTR_REC_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
            strSQL.Append(Prompt(1).ToString());

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

    #endregion "Declarations (Variables, Files and Transactions)(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"

    #region "Standard Generated Procedures(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"

    #region "Automatic Item Initialization(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion "Automatic Item Initialization(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"

    #region "Transaction Management Procedures(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:38 PM

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
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion "Transaction Management Procedures(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"

    #region "FILE Management Procedures(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:38 PM

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
            fleICONST_MSTR_REC.Dispose();
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

    #endregion "FILE Management Procedures(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"

    #endregion "Standard Generated Procedures(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"

    public void Run()
    {
        try
        {
            Request("GET_ICONST_CLINIC_VALUES_1");

            while (fleICONST_MSTR_REC.QTPForMissing())
            {
                // --> GET ICONST_MSTR_REC <--

                fleICONST_MSTR_REC.GetData();
                // --> End GET ICONST_MSTR_REC <--

                if (Transaction())
                {
                    if (AtFinal())
                    {
                        W_PED.Value = Convert.ToInt64(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY").ToString().PadLeft(4, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM").ToString().PadLeft(2, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD").ToString().PadLeft(2, '0'));
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
            EndRequest("GET_ICONST_CLINIC_VALUES_1");
        }
    }

    #endregion "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030BB_1_GET_ICONST_CLINIC_VALUES_1)"
}

//GET_ICONST_CLINIC_VALUES_1

public class U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2 : U030BB_1
{
    public U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF088_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_DTL", "F088_DTL", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF096_OHIP_PAY_CODE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F096_OHIP_PAY_CODE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU030BB_CHARGEABLE_DETAILS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030BB_CHARGEABLE_DETAILS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_SELECTED_RAT_DATE.GetValue += X_SELECTED_RAT_DATE_GetValue;
        X_PGM_NAME.GetValue += X_PGM_NAME_GetValue;
        X_CLINIC_NBR.GetValue += X_CLINIC_NBR_GetValue;
        X_BAL_DUE.GetValue += X_BAL_DUE_GetValue;
        X_BAL.GetValue += X_BAL_GetValue;
        X_CLAIM_NBR.GetValue += X_CLAIM_NBR_GetValue;
        fleF088_DTL.SelectIf += FleF088_DTL_SelectIf;
    }

    #region "Declarations (Variables, Files and Transactions)(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"

    private void FleF088_DTL_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (('").Append(X_PGM_NAME.Value.Trim()).Append("' = 'u030bb_1' ");
            strSQL.Append(" And ").Append(fleF088_DTL.ElementOwner("PED")).Append(" = ");
            strSQL.Append(X_SELECTED_RAT_DATE.Value);
            strSQL.Append(" ) OR ('").Append(X_PGM_NAME.Value.Trim()).Append("' = 'fix_f088_b')) ");

            SelectIfClause = strSQL.ToString();
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
          

            if (((X_PGM_NAME.Value.Trim() == "u030bb_1"
             & fleF088_DTL.GetDecimalValue("PED") == X_SELECTED_RAT_DATE.Value
             )
         | (X_PGM_NAME.Value.Trim() == "fix_f088_b"
            )
        )
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != " "
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "00"
         & (QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "35"

              )
         & (QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "D7"
               | (QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) == "D7"
           & (QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "Z403"
                & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "Z408")

                  )
              )
         & (QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "D8"
               | (QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) == "D8"

                   & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_DOC_NBR")) != "309"
                  )
              )

         & (QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "D8"
               | (QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) == "D8"

                   & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_DOC_NBR")) != "309"
                  )
              )

         & (QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "M1"
               | (QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) == "M1"
                   & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "G277"

                   & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "K013"

                  )

               | ((QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) == "M1"
                        & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "G388"
                        & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "E423"
                        & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "P005"
               )
                    | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF")) != "A"
                    | X_BAL.Value > 4600
          )

              )
         & (QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "DA"

              )
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "48"
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "51"
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "55"
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "80"
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "C7"
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "D2"
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "EV"
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "I2"
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "I5"
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "V7"
         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "V1"


     & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "S3"

     & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "C1"

     & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "57"
     & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "H3"
     & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "H5"

     & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "F1"
     & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "V8"

     & (QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "36" | X_CLINIC_NBR.Value != "71")

     & ((QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "I4"
             & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "36"
           )
        | QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "G313"
        | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF")) != "A"
        | (X_CLINIC_NBR.Value != "88"
            & X_CLINIC_NBR.Value != "78"
            & X_CLINIC_NBR.Value != "79"
           )
          )

     & ((QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "36"
             & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "58"

             & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "D6"
             & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "O9"
             & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "O2"

           )
        | ((QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "E082"
                & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "E083"
                & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "G271"
                & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "P007"

                & QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "P025"

               )
             | QDesign.NULL(fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_SUFF")) != "A"
           )

            | X_BAL.Value > 5600

          )

     & ((QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "80"
           )

               | ((String.Compare(X_CLINIC_NBR.Value, "61") < 0
                          | String.Compare(X_CLINIC_NBR.Value, "66") > 0
            )
                    & (String.Compare(X_CLINIC_NBR.Value, "71") < 0
                          | String.Compare(X_CLINIC_NBR.Value, "75") > 0
            )

           )
              )

         & QDesign.NULL(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")) != "MC"
     & X_BAL_DUE.Value > 0

         & QDesign.NULL(fleF088_DTL.GetStringValue("LAST_MOD_USER_ID")) == " "

)
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

    private SqlFileObject fleF088_DTL;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF096_OHIP_PAY_CODE;
    private DDecimal X_SELECTED_RAT_DATE = new DDecimal("X_SELECTED_RAT_DATE");

    private void X_SELECTED_RAT_DATE_GetValue(ref decimal Value)
    {
        try
        {
            Value = W_PED.Value;
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

    private DCharacter X_PGM_NAME = new DCharacter("X_PGM_NAME", 10);

    private void X_PGM_NAME_GetValue(ref string Value)
    {
        try
        {
            Value = "u030bb_1";
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

    private DCharacter X_CLINIC_NBR = new DCharacter("X_CLINIC_NBR", 2);

    private void X_CLINIC_NBR_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2);
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

    private DDecimal X_BAL_DUE = new DDecimal("X_BAL_DUE", 6);

    private void X_BAL_DUE_GetValue(ref decimal Value)
    {
        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
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

    private DDecimal X_BAL = new DDecimal("X_BAL", 6);

    private void X_BAL_GetValue(ref decimal Value)
    {
        try
        {
            Value = fleF088_DTL.GetDecimalValue("PART_DTL_AMT_PAID") - fleF088_DTL.GetDecimalValue("PART_DTL_AMT_BILL");
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

    private DCharacter X_CLAIM_NBR = new DCharacter("X_CLAIM_NBR", 10);

    private void X_CLAIM_NBR_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF088_DTL.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF088_DTL.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF088_DTL.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 10);
            //Parent:RAT_REJECTED_CLAIM_DTL
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

    private SqlFileObject fleU030BB_CHARGEABLE_DETAILS;

    #endregion "Declarations (Variables, Files and Transactions)(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"

    #region "Standard Generated Procedures(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"

    #region "Automatic Item Initialization(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion "Automatic Item Initialization(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"

    #region "Transaction Management Procedures(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:38 PM

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
        fleF088_DTL.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF096_OHIP_PAY_CODE.Transaction = m_trnTRANS_UPDATE;
        fleU030BB_CHARGEABLE_DETAILS.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion "Transaction Management Procedures(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"

    #region "FILE Management Procedures(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:38 PM

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
            fleF088_DTL.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF096_OHIP_PAY_CODE.Dispose();
            fleU030BB_CHARGEABLE_DETAILS.Dispose();
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

    #endregion "FILE Management Procedures(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"

    #endregion "Standard Generated Procedures(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"

    public void Run()
    {
        try
        {
            Request("U030BB_EXTRACT_CHARGEABLE_DTLS_2");

            while (fleF088_DTL.QTPForMissing())
            {
                // --> GET F088_DTL <--

                fleF088_DTL.GetData();
                // --> End GET F088_DTL <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleF088_DTL.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF088_DTL.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF088_DTL.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 8))));
                    //Parent:RAT_REJECTED_CLAIM_DTL
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleF088_DTL.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF088_DTL.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF088_DTL.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF088_DTL.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 9, 2))));
                    //Parent:RAT_REJECTED_CLAIM_DTL
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF088_DTL.GetStringValue("CLMHDR_DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF096_OHIP_PAY_CODE.QTPForMissing("3"))
                        {
                            // --> GET F096_OHIP_PAY_CODE <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF096_OHIP_PAY_CODE.ElementOwner("RAT_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF088_DTL.GetStringValue("OHIP_ERR_CODE")));

                            fleF096_OHIP_PAY_CODE.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F096_OHIP_PAY_CODE <--

                            if (Transaction())
                            {
                                if (Select_If())
                                {
                                    Sort(X_CLAIM_NBR.Value, X_BAL.SortValue(SortType.Numeric));
                                }
                            }
                        }
                    }
                }
            }

            while (Sort(fleF088_DTL, fleF002_CLAIMS_MSTR, fleF020_DOCTOR_MSTR, fleF096_OHIP_PAY_CODE))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleU030BB_CHARGEABLE_DETAILS, At(X_CLAIM_NBR), SubFileType.Keep, X_CLAIM_NBR, fleF088_DTL, "PED", "OHIP_ERR_CODE");
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
            EndRequest("U030BB_EXTRACT_CHARGEABLE_DTLS_2");
        }
    }

    #endregion "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030BB_1_U030BB_EXTRACT_CHARGEABLE_DTLS_2)"
}

//U030BB_EXTRACT_CHARGEABLE_DTLS_2

public class U030BB_1_U030BB_UPDATE_F088_DTL_3 : U030BB_1
{
    public U030BB_1_U030BB_UPDATE_F088_DTL_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030BB_CHARGEABLE_DETAILS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030BB_CHARGEABLE_DETAILS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF088_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_HDR", "F088_HDR", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF088_HDR.SetItemFinals += fleF088_HDR_SetItemFinals;
        NOT_CHARGED.GetValue += NOT_CHARGED_GetValue;
        CHARGED.GetValue += CHARGED_GetValue;
        CANCELLED.GetValue += CANCELLED_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(U030BB_1_U030BB_UPDATE_F088_DTL_3)"

    private SqlFileObject fleU030BB_CHARGEABLE_DETAILS;
    private SqlFileObject fleF088_HDR;

    private void fleF088_HDR_SetItemFinals()
    {
        try
        {
            fleF088_HDR.set_SetValue("OHIP_ERR_CODE", fleU030BB_CHARGEABLE_DETAILS.GetStringValue("OHIP_ERR_CODE"));
            fleF088_HDR.set_SetValue("CHARGE_STATUS", CHARGED.Value);
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

    private DCharacter NOT_CHARGED = new DCharacter("NOT_CHARGED", 1);

    private void NOT_CHARGED_GetValue(ref string Value)
    {
        try
        {
            Value = " ";
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

    private DCharacter CHARGED = new DCharacter("CHARGED", 1);

    private void CHARGED_GetValue(ref string Value)
    {
        try
        {
            Value = "Y";
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

    private DCharacter CANCELLED = new DCharacter("CANCELLED", 1);

    private void CANCELLED_GetValue(ref string Value)
    {
        try
        {
            Value = "C";
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

    #endregion "Declarations (Variables, Files and Transactions)(U030BB_1_U030BB_UPDATE_F088_DTL_3)"

    #region "Standard Generated Procedures(U030BB_1_U030BB_UPDATE_F088_DTL_3)"

    #region "Automatic Item Initialization(U030BB_1_U030BB_UPDATE_F088_DTL_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion "Automatic Item Initialization(U030BB_1_U030BB_UPDATE_F088_DTL_3)"

    #region "Transaction Management Procedures(U030BB_1_U030BB_UPDATE_F088_DTL_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:39 PM

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
        fleU030BB_CHARGEABLE_DETAILS.Transaction = m_trnTRANS_UPDATE;
        fleF088_HDR.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion "Transaction Management Procedures(U030BB_1_U030BB_UPDATE_F088_DTL_3)"

    #region "FILE Management Procedures(U030BB_1_U030BB_UPDATE_F088_DTL_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:39 PM

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
            fleU030BB_CHARGEABLE_DETAILS.Dispose();
            fleF088_HDR.Dispose();
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

    #endregion "FILE Management Procedures(U030BB_1_U030BB_UPDATE_F088_DTL_3)"

    #endregion "Standard Generated Procedures(U030BB_1_U030BB_UPDATE_F088_DTL_3)"

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030BB_1_U030BB_UPDATE_F088_DTL_3)"

    public void Run()
    {
        try
        {
            Request("U030BB_UPDATE_F088_DTL_3");

            while (fleU030BB_CHARGEABLE_DETAILS.QTPForMissing())
            {
                // --> GET U030BB_CHARGEABLE_DETAILS <--

                fleU030BB_CHARGEABLE_DETAILS.GetData();
                // --> End GET U030BB_CHARGEABLE_DETAILS <--

                while (fleF088_HDR.QTPForMissing("1"))
                {
                    // --> GET F088_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF088_HDR.ElementOwner("CLMHDR_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleU030BB_CHARGEABLE_DETAILS.GetStringValue("X_CLAIM_NBR")).PadRight(10).Substring(0, 8)));
                    //Parent:RAT_REJECTED_CLAIM
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF088_HDR.ElementOwner("CLMHDR_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert((fleU030BB_CHARGEABLE_DETAILS.GetStringValue("X_CLAIM_NBR")).PadRight(10).Substring(8, 2)));
                    //Parent:RAT_REJECTED_CLAIM

                    m_strWhere.Append(" AND ").Append(" ").Append(fleF088_HDR.ElementOwner("PED")).Append(" = ");
                    m_strWhere.Append(fleU030BB_CHARGEABLE_DETAILS.GetDecimalValue("PED"));

                    fleF088_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F088_HDR <--

                    if (Transaction())
                    {
                        fleF088_HDR.OutPut(OutPutType.Update);
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
            EndRequest("U030BB_UPDATE_F088_DTL_3");
        }
    }

    #endregion "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030BB_1_U030BB_UPDATE_F088_DTL_3)"
}

//U030BB_UPDATE_F088_DTL_3