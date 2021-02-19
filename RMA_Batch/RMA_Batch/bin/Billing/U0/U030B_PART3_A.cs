
#region "Screen Comments"

// #> PROGRAM-ID.     U030B_PART3_A.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : THIRD PASS OF U030B
// NOTE: YOU MAY HAVE TO MODIFY THIS PROGRAM IF YOU RECEIVE DATA CONVERSION ON X-BATCH-AMOUNT IN REQUEST CALCULATE_BATCH_NBR.
// Find out the highest premium amount from r031c.txt, whatever the amount is, round up of 5K, 10K, 15K, 20K, 25K etc.
// For example, if the highest premium amount is  4500, then change change-batch-flag to ` <= 9500000`
// if the highest premium amount is  9500, then change change-batch-flag to ` <= 9000000`
// if the highest premium amount is 13500, then change change-batch-flag to ` <= 8500000`
// if the highest premium amount is 18500, then change change-batch-flag to ` <= 8000000`
// if the highest premium amount is 22500, then change change-batch-flag to ` <= 7500000`
// if the highest premium amount is 26000, then change change-batch-flag to ` <= 7000000`
// if the highest premium amount is 32500, then change change-batch-flag to ` <= 6500000`  etc.
// Now since we automate the solution as Brad suggested, I have defined all possible check up to > 90K.
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 06/Nov/03 M.C.         - ORIGINAL 
// - create miscellaneous premium payment records from record 8
// 07/Feb/15 M.C.      - Since Mary put the the postdate `termination date` in the
// doctor master, we still have to consider active doctor if the
// termination date > sysdate
// 07/apr/16 M.C.      - change the definition of x-paid-amt for negative amount as well
// 07/jun/13 M.C.      - add a new request at the end of the program to create records in the
// `tmp-counters-alpha` file from subfile
// 09/mar/09 M.C.      - add clinic 37 payment to apply to clinic 22  
// 09/mar/23 M.C.      - use clmhdr-adj-cd instead of hardcode `AGEP` because AGEP & MOHR can use
// this program
// 09/apr/01 M.C.      - use x-adj-cd instead of clmhdr-adj-cd
// 09/apr/20 M.C.      - u030b_part3.qts split into u030b_part3_a/b.qts
// 09/jul/20 M.C.      - add clinic 78, 79 & 88 payment to apply to clinic 22  
// 09/nov/05 BE/MC        - modify the last request to set each batch is <= 99 claims and the batch amount <= $95,000.00
// 12/Apr/19 MC1          - modify the last request `calculate_batch_nbr`  to set batch amount <= $90,000.00, 
// encounter the next record is over $9000
// 13/Mar/06 MC2      - exclude records if payment is zero
// 13/Mar/27 MC3      - apply payments to the doctors with dept 76 in clinic 22 for multiple doctors
// - add 4 new passes split_mult_doc, filter_22_docs_part1/2/3
// - create records in tmp-doctor-alpha if doctors have dept 76 in clinic 22
// 13/Aug/26 MC4          - write records in tmp-doctor-alpha at control break if doctors have dept 76 in clinic 22
// 15/Mar/16 MC5          - modify the last request `calculate_batch_nbr` to set batch amount <= $70,000.00, 
// according to r031c.txt, the highest premium amount is 28,548.41
// - add a new request to determine highest premium amount before the last request
// - Brad suggested to automate the w-check-amt,have defined all possible highest premium amount 
// for a doctor is >  $90,000.00
// 15/Jun/08 MC6      - use absolute to determine the highest premium amount
// 16/Jun/06 MC7      - add pay-this-doctor-ohip-premium in the sort so that for the doctors have set to `Y`
// will be selected if active for multiple active doctors 
// - add f020-doctor-extra in the access
// 16/Jul/11 MC8      - no need to check for highest amount 
// 16/Jul/14 MC9      - change amount field from zoned*7 to zoned*9
// 16/Jul/28 MC10      - transfer the last request from u030b_part3_b.qts to here as Yasemin requested
// to generate ru030n.txt as part of AGEP/MOHD_part1
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U030B_PART3_A : BaseClassControl
{

    private U030B_PART3_A m_U030B_PART3_A;

    public U030B_PART3_A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U030B_PART3_A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U030B_PART3_A != null))
        {
            m_U030B_PART3_A.CloseTransactionObjects();
            m_U030B_PART3_A = null;
        }
    }

    public U030B_PART3_A GetU030B_PART3_A(int Level)
    {
        if (m_U030B_PART3_A == null)
        {
            m_U030B_PART3_A = new U030B_PART3_A("U030B_PART3_A", Level);
        }
        else
        {
            m_U030B_PART3_A.ResetValues();
        }
        return m_U030B_PART3_A;
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

            U030B_PART3_A_EVALUATE_CLINIC_AMT_1 EVALUATE_CLINIC_AMT_1 = new U030B_PART3_A_EVALUATE_CLINIC_AMT_1(Name, Level);
            EVALUATE_CLINIC_AMT_1.Run();
            EVALUATE_CLINIC_AMT_1.Dispose();
            EVALUATE_CLINIC_AMT_1 = null;

            U030B_PART3_A_SEL_DOCTOR_2 SEL_DOCTOR_2 = new U030B_PART3_A_SEL_DOCTOR_2(Name, Level);
            SEL_DOCTOR_2.Run();
            SEL_DOCTOR_2.Dispose();
            SEL_DOCTOR_2 = null;

            U030B_PART3_A_SEL_UNIQUE_DOCTORS_3 SEL_UNIQUE_DOCTORS_3 = new U030B_PART3_A_SEL_UNIQUE_DOCTORS_3(Name, Level);
            SEL_UNIQUE_DOCTORS_3.Run();
            SEL_UNIQUE_DOCTORS_3.Dispose();
            SEL_UNIQUE_DOCTORS_3 = null;

            U030B_PART3_A_SEL_MULTIPLE_DOCTORS_4 SEL_MULTIPLE_DOCTORS_4 = new U030B_PART3_A_SEL_MULTIPLE_DOCTORS_4(Name, Level);
            SEL_MULTIPLE_DOCTORS_4.Run();
            SEL_MULTIPLE_DOCTORS_4.Dispose();
            SEL_MULTIPLE_DOCTORS_4 = null;

            U030B_PART3_A_SPLIT_MULT_DOCS_5 SPLIT_MULT_DOCS_5 = new U030B_PART3_A_SPLIT_MULT_DOCS_5(Name, Level);
            SPLIT_MULT_DOCS_5.Run();
            SPLIT_MULT_DOCS_5.Dispose();
            SPLIT_MULT_DOCS_5 = null;

            U030B_PART3_A_FILTER_22_DOCS_PART1_6 FILTER_22_DOCS_PART1_6 = new U030B_PART3_A_FILTER_22_DOCS_PART1_6(Name, Level);
            FILTER_22_DOCS_PART1_6.Run();
            FILTER_22_DOCS_PART1_6.Dispose();
            FILTER_22_DOCS_PART1_6 = null;

            U030B_PART3_A_FILTER_22_DOCS_PART2_7 FILTER_22_DOCS_PART2_7 = new U030B_PART3_A_FILTER_22_DOCS_PART2_7(Name, Level);
            FILTER_22_DOCS_PART2_7.Run();
            FILTER_22_DOCS_PART2_7.Dispose();
            FILTER_22_DOCS_PART2_7 = null;

            U030B_PART3_A_FILTER_22_DOCS_PART3_8 FILTER_22_DOCS_PART3_8 = new U030B_PART3_A_FILTER_22_DOCS_PART3_8(Name, Level);
            FILTER_22_DOCS_PART3_8.Run();
            FILTER_22_DOCS_PART3_8.Dispose();
            FILTER_22_DOCS_PART3_8 = null;

            U030B_PART3_A_SEL_FILTER_MULT_DOCS_9 SEL_FILTER_MULT_DOCS_9 = new U030B_PART3_A_SEL_FILTER_MULT_DOCS_9(Name, Level);
            SEL_FILTER_MULT_DOCS_9.Run();
            SEL_FILTER_MULT_DOCS_9.Dispose();
            SEL_FILTER_MULT_DOCS_9 = null;

            U030B_PART3_A_CONVERT_CLINIC_10 CONVERT_CLINIC_10 = new U030B_PART3_A_CONVERT_CLINIC_10(Name, Level);
            CONVERT_CLINIC_10.Run();
            CONVERT_CLINIC_10.Dispose();
            CONVERT_CLINIC_10 = null;

            U030B_PART3_A_SEL_ACTIVE_DOCTOR_11 SEL_ACTIVE_DOCTOR_11 = new U030B_PART3_A_SEL_ACTIVE_DOCTOR_11(Name, Level);
            SEL_ACTIVE_DOCTOR_11.Run();
            SEL_ACTIVE_DOCTOR_11.Dispose();
            SEL_ACTIVE_DOCTOR_11 = null;

            U030B_PART3_A_CALCULATE_RUNNING_AMT_12 CALCULATE_RUNNING_AMT_12 = new U030B_PART3_A_CALCULATE_RUNNING_AMT_12(Name, Level);
            CALCULATE_RUNNING_AMT_12.Run();
            CALCULATE_RUNNING_AMT_12.Dispose();
            CALCULATE_RUNNING_AMT_12 = null;

            U030B_PART3_A_DETERMINE_HIGHEST_AMT_13 DETERMINE_HIGHEST_AMT_13 = new U030B_PART3_A_DETERMINE_HIGHEST_AMT_13(Name, Level);
            DETERMINE_HIGHEST_AMT_13.Run();
            DETERMINE_HIGHEST_AMT_13.Dispose();
            DETERMINE_HIGHEST_AMT_13 = null;

            U030B_PART3_A_CALCULATE_BATCH_NBR_14 CALCULATE_BATCH_NBR_14 = new U030B_PART3_A_CALCULATE_BATCH_NBR_14(Name, Level);
            CALCULATE_BATCH_NBR_14.Run();
            CALCULATE_BATCH_NBR_14.Dispose();
            CALCULATE_BATCH_NBR_14 = null;

            U030B_PART3_A_TRANSFER_TO_TMP_FILE_15 TRANSFER_TO_TMP_FILE_15 = new U030B_PART3_A_TRANSFER_TO_TMP_FILE_15(Name, Level);
            TRANSFER_TO_TMP_FILE_15.Run();
            TRANSFER_TO_TMP_FILE_15.Dispose();
            TRANSFER_TO_TMP_FILE_15 = null;

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



public class U030B_PART3_A_EVALUATE_CLINIC_AMT_1 : U030B_PART3_A
{

    public U030B_PART3_A_EVALUATE_CLINIC_AMT_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_OHIP_PREMIUMS = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "R031A_OHIP_PREMIUMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_PAYMENT = new CoreDecimal("X_PAYMENT", 8, this);
        fleR031A_EXTRACT_DATA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_EXTRACT_DATA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_PAID_AMT.GetValue += X_PAID_AMT_GetValue;
        X_ADJ_CD.GetValue += X_ADJ_CD_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_EVALUATE_CLINIC_AMT_1)"

    private SqlFileObject fleR031A_OHIP_PREMIUMS;
    private DDecimal X_PAID_AMT = new DDecimal("X_PAID_AMT", 8);
    private void X_PAID_AMT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(QDesign.Substring(fleR031A_OHIP_PREMIUMS.GetStringValue("DOLLARS_PAID"), 1, 1)) == "-")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(fleR031A_OHIP_PREMIUMS.GetStringValue("DOLLARS_PAID"), 2, 2) + QDesign.Substring(fleR031A_OHIP_PREMIUMS.GetStringValue("DOLLARS_PAID"), 5, 3) + QDesign.Substring(fleR031A_OHIP_PREMIUMS.GetStringValue("DOLLARS_PAID"), 9, 2)) * -1;
            }
            else
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(fleR031A_OHIP_PREMIUMS.GetStringValue("DOLLARS_PAID"), 1, 3) + QDesign.Substring(fleR031A_OHIP_PREMIUMS.GetStringValue("DOLLARS_PAID"), 5, 3) + QDesign.Substring(fleR031A_OHIP_PREMIUMS.GetStringValue("DOLLARS_PAID"), 9, 2));
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
    private DCharacter X_ADJ_CD = new DCharacter("X_ADJ_CD", 5);
    private void X_ADJ_CD_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleR031A_OHIP_PREMIUMS.GetStringValue("CLMHDR_ADJ_CD")) == "AGE3")
            {
                CurrentValue = "AGEP";
            }
            else
            {
                CurrentValue = fleR031A_OHIP_PREMIUMS.GetStringValue("CLMHDR_ADJ_CD");
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

    private CoreDecimal X_PAYMENT;



    private SqlFileObject fleR031A_EXTRACT_DATA;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_EVALUATE_CLINIC_AMT_1)"


    #region "Automatic Item Initialization(U030B_PART3_A_EVALUATE_CLINIC_AMT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_EVALUATE_CLINIC_AMT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:53 PM

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
        fleR031A_OHIP_PREMIUMS.Transaction = m_trnTRANS_UPDATE;
        fleR031A_EXTRACT_DATA.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_EVALUATE_CLINIC_AMT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:53 PM

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
            fleR031A_OHIP_PREMIUMS.Dispose();
            fleR031A_EXTRACT_DATA.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_EVALUATE_CLINIC_AMT_1)"


    public void Run()
    {

        try
        {
            Request("EVALUATE_CLINIC_AMT_1");

            while (fleR031A_OHIP_PREMIUMS.QTPForMissing())
            {
                // --> GET R031A_OHIP_PREMIUMS <--

                fleR031A_OHIP_PREMIUMS.GetData();
                // --> End GET R031A_OHIP_PREMIUMS <--


                if (Transaction())
                {

                    Sort(fleR031A_OHIP_PREMIUMS.GetSortValue("ICONST_CLINIC_NBR_1_2"), X_ADJ_CD.Value, fleR031A_OHIP_PREMIUMS.GetSortValue("DOC_OHIP_NBR"));



                }

            }

            while (Sort(fleR031A_OHIP_PREMIUMS))
            {
                X_PAYMENT.Value = X_PAYMENT.Value + X_PAID_AMT.Value;





                SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_EXTRACT_DATA, fleR031A_OHIP_PREMIUMS.At("ICONST_CLINIC_NBR_1_2") || At(X_ADJ_CD) || fleR031A_OHIP_PREMIUMS.At("DOC_OHIP_NBR"), SubFileType.Keep, fleR031A_OHIP_PREMIUMS, "DOC_OHIP_NBR", "ICONST_CLINIC_NBR_1_2", X_PAYMENT, X_ADJ_CD);



                Reset(ref X_PAYMENT, fleR031A_OHIP_PREMIUMS.At("ICONST_CLINIC_NBR_1_2") || At(X_ADJ_CD) || fleR031A_OHIP_PREMIUMS.At("DOC_OHIP_NBR"));

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
            EndRequest("EVALUATE_CLINIC_AMT_1");

        }

    }




    #endregion


}
//EVALUATE_CLINIC_AMT_1



public class U030B_PART3_A_SEL_DOCTOR_2 : U030B_PART3_A
{

    public U030B_PART3_A_SEL_DOCTOR_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_EXTRACT_DATA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_EXTRACT_DATA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        XCOUNT = new CoreDecimal("XCOUNT", 6, this);
        fleR031A_SORT_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_SORT_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_SEL_DOCTOR_2)"

    private SqlFileObject fleR031A_EXTRACT_DATA;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleR031A_EXTRACT_DATA.GetDecimalValue("X_PAYMENT")) != 0)
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


    private CoreDecimal XCOUNT;



    private SqlFileObject fleR031A_SORT_DOCTOR;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_SEL_DOCTOR_2)"


    #region "Automatic Item Initialization(U030B_PART3_A_SEL_DOCTOR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_SEL_DOCTOR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:53 PM

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
        fleR031A_EXTRACT_DATA.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleR031A_SORT_DOCTOR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_SEL_DOCTOR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:53 PM

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
            fleR031A_EXTRACT_DATA.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleR031A_SORT_DOCTOR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_SEL_DOCTOR_2)"


    public void Run()
    {

        try
        {
            Request("SEL_DOCTOR_2");

            while (fleR031A_EXTRACT_DATA.QTPForMissing())
            {
                // --> GET R031A_EXTRACT_DATA <--

                fleR031A_EXTRACT_DATA.GetData();
                // --> End GET R031A_EXTRACT_DATA <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleR031A_EXTRACT_DATA.GetSortValue("ICONST_CLINIC_NBR_1_2"), fleR031A_EXTRACT_DATA.GetSortValue("X_ADJ_CD"), fleF020_DOCTOR_MSTR.GetSortValue("DOC_OHIP_NBR"));



                        }

                    }

                }

            }

            while (Sort(fleR031A_EXTRACT_DATA, fleF020_DOCTOR_MSTR))
            {
                XCOUNT.Value = XCOUNT.Value + 1;





                SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_SORT_DOCTOR, fleR031A_EXTRACT_DATA.At("ICONST_CLINIC_NBR_1_2") || fleR031A_EXTRACT_DATA.At("X_ADJ_CD") || fleF020_DOCTOR_MSTR.At("DOC_OHIP_NBR"), SubFileType.Keep, fleR031A_EXTRACT_DATA, "DOC_OHIP_NBR", fleF020_DOCTOR_MSTR, "DOC_NBR", "DOC_DATE_FAC_START", "DOC_DATE_FAC_TERM",
                fleR031A_EXTRACT_DATA, "ICONST_CLINIC_NBR_1_2", "X_PAYMENT", "X_ADJ_CD", fleF020_DOCTOR_MSTR, "DOC_DEPT", XCOUNT);



                Reset(ref XCOUNT, fleR031A_EXTRACT_DATA.At("ICONST_CLINIC_NBR_1_2") || fleR031A_EXTRACT_DATA.At("X_ADJ_CD") || fleF020_DOCTOR_MSTR.At("DOC_OHIP_NBR"));

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
            EndRequest("SEL_DOCTOR_2");

        }

    }




    #endregion


}
//SEL_DOCTOR_2



public class U030B_PART3_A_SEL_UNIQUE_DOCTORS_3 : U030B_PART3_A
{

    public U030B_PART3_A_SEL_UNIQUE_DOCTORS_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_SORT_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_SORT_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleR031A_SELECT_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_SELECT_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_SEL_UNIQUE_DOCTORS_3)"

    private SqlFileObject fleR031A_SORT_DOCTOR;

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleR031A_SORT_DOCTOR.GetDecimalValue("XCOUNT")) == 1)
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





    private SqlFileObject fleR031A_SELECT_DOCTOR;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_SEL_UNIQUE_DOCTORS_3)"


    #region "Automatic Item Initialization(U030B_PART3_A_SEL_UNIQUE_DOCTORS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_SEL_UNIQUE_DOCTORS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:53 PM

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
        fleR031A_SORT_DOCTOR.Transaction = m_trnTRANS_UPDATE;
        fleR031A_SELECT_DOCTOR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_SEL_UNIQUE_DOCTORS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:53 PM

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
            fleR031A_SORT_DOCTOR.Dispose();
            fleR031A_SELECT_DOCTOR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_SEL_UNIQUE_DOCTORS_3)"


    public void Run()
    {

        try
        {
            Request("SEL_UNIQUE_DOCTORS_3");

            while (fleR031A_SORT_DOCTOR.QTPForMissing())
            {
                // --> GET R031A_SORT_DOCTOR <--

                fleR031A_SORT_DOCTOR.GetData();
                // --> End GET R031A_SORT_DOCTOR <--

                if (Transaction())
                {

                     if (Select_If())
                    {




                        SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_SELECT_DOCTOR, SubFileType.Keep, fleR031A_SORT_DOCTOR);



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
            EndRequest("SEL_UNIQUE_DOCTORS_3");

        }

    }




    #endregion


}
//SEL_UNIQUE_DOCTORS_3



public class U030B_PART3_A_SEL_MULTIPLE_DOCTORS_4 : U030B_PART3_A
{

    public U030B_PART3_A_SEL_MULTIPLE_DOCTORS_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_SORT_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_SORT_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR031A_MULTIPLE_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_MULTIPLE_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        DOC_DATE_FAC_START.GetValue += DOC_DATE_FAC_START_GetValue;
        DOC_DATE_FAC_TERM.GetValue += DOC_DATE_FAC_TERM_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_SEL_MULTIPLE_DOCTORS_4)"

    private SqlFileObject fleR031A_SORT_DOCTOR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020C_DOC_CLINIC_NEXT_BATCH_NBR;
    public override bool SelectIf()
    {
        try
        {
            //if (QDesign.NULL(fleR031A_SORT_DOCTOR.GetDecimalValue("XCOUNT")) > 1 & (QDesign.NULL(DOC_DATE_FAC_TERM.Value) == 0 | QDesign.NULL(DOC_DATE_FAC_TERM.Value) > QDesign.NULL(QDesign.SysDate(ref m_cnnQUERY))) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) != 31 & ((QDesign.NULL(fleR031A_SORT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR")) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH")) != 0) | (QDesign.NULL(fleR031A_SORT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_2")) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2")) != 0) | (QDesign.NULL(fleR031A_SORT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_3")) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3")) != 0) | (QDesign.NULL(fleR031A_SORT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_4")) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4")) != 0) | (QDesign.NULL(fleR031A_SORT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_5")) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5")) != 0) | (QDesign.NULL(fleR031A_SORT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_6")) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6")) != 0)))
            if (QDesign.NULL(fleR031A_SORT_DOCTOR.GetDecimalValue("XCOUNT")) > 1 & (QDesign.NULL(DOC_DATE_FAC_TERM.Value) == 0 | QDesign.NULL(DOC_DATE_FAC_TERM.Value) > QDesign.NULL(QDesign.SysDate(ref m_cnnQUERY))) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) != 31 & ((QDesign.NULL(fleR031A_SORT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == QDesign.NULL(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_CLINIC_NBR")) & QDesign.NULL(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_NX_AVAIL_BATCH")) != 0)))
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

    private SqlFileObject fleR031A_MULTIPLE_DOCTOR;

    private DDecimal DOC_DATE_FAC_START = new DDecimal("DOC_DATE_FAC_START", 8);
    private void DOC_DATE_FAC_START_GetValue(ref decimal Value)
    {
        try
        {
            Value = QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY")) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM")) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD")));
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

    private DDecimal DOC_DATE_FAC_TERM = new DDecimal("DOC_DATE_FAC_TERM", 8);
    private void DOC_DATE_FAC_TERM_GetValue(ref decimal Value)
    {
        try
        {
            Value = QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY")) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM")) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD")));
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


    #region "Standard Generated Procedures(U030B_PART3_A_SEL_MULTIPLE_DOCTORS_4)"


    #region "Automatic Item Initialization(U030B_PART3_A_SEL_MULTIPLE_DOCTORS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_SEL_MULTIPLE_DOCTORS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:53 PM

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
        fleR031A_SORT_DOCTOR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleR031A_MULTIPLE_DOCTOR.Transaction = m_trnTRANS_UPDATE;
        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;

    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_SEL_MULTIPLE_DOCTORS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:54 PM

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
            fleR031A_SORT_DOCTOR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleR031A_MULTIPLE_DOCTOR.Dispose();
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Dispose();

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_SEL_MULTIPLE_DOCTORS_4)"


    public void Run()
    {

        try
        {
            Request("SEL_MULTIPLE_DOCTORS_4");

            while (fleR031A_SORT_DOCTOR.QTPForMissing())
            {
                // --> GET R031A_SORT_DOCTOR <--

                fleR031A_SORT_DOCTOR.GetData();
                // --> End GET R031A_SORT_DOCTOR <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleR031A_SORT_DOCTOR.GetDecimalValue("DOC_OHIP_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.QTPForMissing("2"))
                    {
                        // --> GET F020C_DOCT_CLINIC_NEXT_BATCH_NBR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020C_DOCT_CLINIC_NEXT_BATCH_NBR <--

                        if (Transaction())
                        {
                            if (Select_If())
                            {
                                SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_MULTIPLE_DOCTOR, SubFileType.Keep, fleR031A_SORT_DOCTOR, "DOC_OHIP_NBR", fleF020_DOCTOR_MSTR, "DOC_NBR", DOC_DATE_FAC_START, DOC_DATE_FAC_TERM, fleR031A_SORT_DOCTOR,
                                    "ICONST_CLINIC_NBR_1_2", "X_PAYMENT", "X_ADJ_CD", "XCOUNT", fleF020_DOCTOR_MSTR, "DOC_DEPT");
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
            EndRequest("SEL_MULTIPLE_DOCTORS_4");
        }
    }

    #endregion


}
//SEL_MULTIPLE_DOCTORS_4



public class U030B_PART3_A_SPLIT_MULT_DOCS_5 : U030B_PART3_A
{

    public U030B_PART3_A_SPLIT_MULT_DOCS_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_MULTIPLE_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_MULTIPLE_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleR031A_MULT_22_CLINIC_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_MULT_22_CLINIC_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleR031A_MULT_OTHER_CLINIC_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_MULT_OTHER_CLINIC_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_SPLIT_MULT_DOCS_5)"

    private SqlFileObject fleR031A_MULTIPLE_DOCTOR;




    private SqlFileObject fleR031A_MULT_22_CLINIC_DOCTORS;




    private SqlFileObject fleR031A_MULT_OTHER_CLINIC_DOCTORS;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_SPLIT_MULT_DOCS_5)"


    #region "Automatic Item Initialization(U030B_PART3_A_SPLIT_MULT_DOCS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_SPLIT_MULT_DOCS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:54 PM

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
        fleR031A_MULTIPLE_DOCTOR.Transaction = m_trnTRANS_UPDATE;
        fleR031A_MULT_22_CLINIC_DOCTORS.Transaction = m_trnTRANS_UPDATE;
        fleR031A_MULT_OTHER_CLINIC_DOCTORS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_SPLIT_MULT_DOCS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:54 PM

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
            fleR031A_MULTIPLE_DOCTOR.Dispose();
            fleR031A_MULT_22_CLINIC_DOCTORS.Dispose();
            fleR031A_MULT_OTHER_CLINIC_DOCTORS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_SPLIT_MULT_DOCS_5)"


    public void Run()
    {

        try
        {
            Request("SPLIT_MULT_DOCS_5");

            while (fleR031A_MULTIPLE_DOCTOR.QTPForMissing())
            {
                // --> GET R031A_MULTIPLE_DOCTOR <--

                fleR031A_MULTIPLE_DOCTOR.GetData();
                // --> End GET R031A_MULTIPLE_DOCTOR <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_MULT_22_CLINIC_DOCTORS, QDesign.NULL(fleR031A_MULTIPLE_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == 22, SubFileType.Keep, fleR031A_MULTIPLE_DOCTOR);
                    SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_MULT_OTHER_CLINIC_DOCTORS, QDesign.NULL(fleR031A_MULTIPLE_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) != 22, SubFileType.Keep, fleR031A_MULTIPLE_DOCTOR);
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
            EndRequest("SPLIT_MULT_DOCS_5");

        }

    }




    #endregion


}
//SPLIT_MULT_DOCS_5



public class U030B_PART3_A_FILTER_22_DOCS_PART1_6 : U030B_PART3_A
{

    public U030B_PART3_A_FILTER_22_DOCS_PART1_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_MULT_22_CLINIC_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_MULT_22_CLINIC_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_DOCTOR_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_DOCTOR_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_FILTER_22_DOCS_PART1_6)"

    private SqlFileObject fleR031A_MULT_22_CLINIC_DOCTORS;

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleR031A_MULT_22_CLINIC_DOCTORS.GetDecimalValue("DOC_DEPT")) == 76)
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

    private SqlFileObject fleTMP_DOCTOR_ALPHA;

    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_FILTER_22_DOCS_PART1_6)"


    #region "Automatic Item Initialization(U030B_PART3_A_FILTER_22_DOCS_PART1_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_FILTER_22_DOCS_PART1_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:54 PM

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
        fleR031A_MULT_22_CLINIC_DOCTORS.Transaction = m_trnTRANS_UPDATE;
        fleTMP_DOCTOR_ALPHA.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_FILTER_22_DOCS_PART1_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:54 PM

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
            fleR031A_MULT_22_CLINIC_DOCTORS.Dispose();
            fleTMP_DOCTOR_ALPHA.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_FILTER_22_DOCS_PART1_6)"


    public void Run()
    {

        try
        {
            Request("FILTER_22_DOCS_PART1_6");

            while (fleR031A_MULT_22_CLINIC_DOCTORS.QTPForMissing())
            {
                // --> GET R031A_MULT_22_CLINIC_DOCTORS <--

                fleR031A_MULT_22_CLINIC_DOCTORS.GetData();
                // --> End GET R031A_MULT_22_CLINIC_DOCTORS <--


                if (Transaction())
                {

                     if (Select_If())
                    {

                        Sort(fleR031A_MULT_22_CLINIC_DOCTORS.GetSortValue("DOC_OHIP_NBR"), fleR031A_MULT_22_CLINIC_DOCTORS.GetSortValue("DOC_NBR"));



                    }

                }

            }


            while (Sort(fleR031A_MULT_22_CLINIC_DOCTORS))
            {



                fleTMP_DOCTOR_ALPHA.OutPut(OutPutType.Add, fleR031A_MULT_22_CLINIC_DOCTORS.At("DOC_OHIP_NBR") || fleR031A_MULT_22_CLINIC_DOCTORS.At("DOC_NBR"), null);


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
            EndRequest("FILTER_22_DOCS_PART1_6");

        }

    }




    #endregion


}
//FILTER_22_DOCS_PART1_6



public class U030B_PART3_A_FILTER_22_DOCS_PART2_7 : U030B_PART3_A
{

    public U030B_PART3_A_FILTER_22_DOCS_PART2_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_MULT_22_CLINIC_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_MULT_22_CLINIC_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_DOCTOR_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_DOCTOR_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR031A_MULT_OTHER_CLINIC_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_MULT_OTHER_CLINIC_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_FILTER_22_DOCS_PART2_7)"

    private SqlFileObject fleR031A_MULT_22_CLINIC_DOCTORS;
    private SqlFileObject fleTMP_DOCTOR_ALPHA;
    public override bool SelectIf()
    {


        try
        {
            if (!fleTMP_DOCTOR_ALPHA.Exists())
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





    private SqlFileObject fleR031A_MULT_OTHER_CLINIC_DOCTORS;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_FILTER_22_DOCS_PART2_7)"


    #region "Automatic Item Initialization(U030B_PART3_A_FILTER_22_DOCS_PART2_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_FILTER_22_DOCS_PART2_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:54 PM

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
        fleR031A_MULT_22_CLINIC_DOCTORS.Transaction = m_trnTRANS_UPDATE;
        fleTMP_DOCTOR_ALPHA.Transaction = m_trnTRANS_UPDATE;
        fleR031A_MULT_OTHER_CLINIC_DOCTORS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_FILTER_22_DOCS_PART2_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:54 PM

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
            fleR031A_MULT_22_CLINIC_DOCTORS.Dispose();
            fleTMP_DOCTOR_ALPHA.Dispose();
            fleR031A_MULT_OTHER_CLINIC_DOCTORS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_FILTER_22_DOCS_PART2_7)"


    public void Run()
    {

        try
        {
            Request("FILTER_22_DOCS_PART2_7");

            while (fleR031A_MULT_22_CLINIC_DOCTORS.QTPForMissing())
            {
                // --> GET R031A_MULT_22_CLINIC_DOCTORS <--

                fleR031A_MULT_22_CLINIC_DOCTORS.GetData();
                // --> End GET R031A_MULT_22_CLINIC_DOCTORS <--

                while (fleTMP_DOCTOR_ALPHA.QTPForMissing("1"))
                {
                    // --> GET TMP_DOCTOR_ALPHA <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleTMP_DOCTOR_ALPHA.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleR031A_MULT_22_CLINIC_DOCTORS.GetDecimalValue("DOC_OHIP_NBR")));

                    fleTMP_DOCTOR_ALPHA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET TMP_DOCTOR_ALPHA <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {




                            SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_MULT_OTHER_CLINIC_DOCTORS, SubFileType.Keep, fleR031A_MULT_22_CLINIC_DOCTORS);



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
            EndRequest("FILTER_22_DOCS_PART2_7");

        }

    }




    #endregion


}
//FILTER_22_DOCS_PART2_7



public class U030B_PART3_A_FILTER_22_DOCS_PART3_8 : U030B_PART3_A
{

    public U030B_PART3_A_FILTER_22_DOCS_PART3_8(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_MULT_22_CLINIC_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_MULT_22_CLINIC_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_DOCTOR_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_DOCTOR_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR031A_MULT_OTHER_CLINIC_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_MULT_OTHER_CLINIC_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_FILTER_22_DOCS_PART3_8)"

    private SqlFileObject fleR031A_MULT_22_CLINIC_DOCTORS;
    private SqlFileObject fleTMP_DOCTOR_ALPHA;



    private SqlFileObject fleR031A_MULT_OTHER_CLINIC_DOCTORS;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_FILTER_22_DOCS_PART3_8)"


    #region "Automatic Item Initialization(U030B_PART3_A_FILTER_22_DOCS_PART3_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_FILTER_22_DOCS_PART3_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:54 PM

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
        fleR031A_MULT_22_CLINIC_DOCTORS.Transaction = m_trnTRANS_UPDATE;
        fleTMP_DOCTOR_ALPHA.Transaction = m_trnTRANS_UPDATE;
        fleR031A_MULT_OTHER_CLINIC_DOCTORS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_FILTER_22_DOCS_PART3_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:54 PM

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
            fleR031A_MULT_22_CLINIC_DOCTORS.Dispose();
            fleTMP_DOCTOR_ALPHA.Dispose();
            fleR031A_MULT_OTHER_CLINIC_DOCTORS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_FILTER_22_DOCS_PART3_8)"


    public void Run()
    {

        try
        {
            Request("FILTER_22_DOCS_PART3_8");

            while (fleR031A_MULT_22_CLINIC_DOCTORS.QTPForMissing())
            {
                // --> GET R031A_MULT_22_CLINIC_DOCTORS <--

                fleR031A_MULT_22_CLINIC_DOCTORS.GetData();
                // --> End GET R031A_MULT_22_CLINIC_DOCTORS <--

                while (fleTMP_DOCTOR_ALPHA.QTPForMissing("1"))
                {
                    // --> GET TMP_DOCTOR_ALPHA <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleTMP_DOCTOR_ALPHA.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleR031A_MULT_22_CLINIC_DOCTORS.GetDecimalValue("DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleTMP_DOCTOR_ALPHA.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleR031A_MULT_22_CLINIC_DOCTORS.GetStringValue("DOC_NBR")));

                    fleTMP_DOCTOR_ALPHA.GetData(m_strWhere.ToString());
                    // --> End GET TMP_DOCTOR_ALPHA <--


                    if (Transaction())
                    {



                        SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_MULT_OTHER_CLINIC_DOCTORS, SubFileType.Keep, fleR031A_MULT_22_CLINIC_DOCTORS);



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
            EndRequest("FILTER_22_DOCS_PART3_8");

        }

    }




    #endregion


}
//FILTER_22_DOCS_PART3_8



public class U030B_PART3_A_SEL_FILTER_MULT_DOCS_9 : U030B_PART3_A
{

    public U030B_PART3_A_SEL_FILTER_MULT_DOCS_9(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_MULT_OTHER_CLINIC_DOCTORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_MULT_OTHER_CLINIC_DOCTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR031A_SELECT_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_SELECT_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_SEL_FILTER_MULT_DOCS_9)"

    private SqlFileObject fleR031A_MULT_OTHER_CLINIC_DOCTORS;
    private SqlFileObject fleF020_DOCTOR_EXTRA;



    private SqlFileObject fleR031A_SELECT_DOCTOR;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_SEL_FILTER_MULT_DOCS_9)"


    #region "Automatic Item Initialization(U030B_PART3_A_SEL_FILTER_MULT_DOCS_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_SEL_FILTER_MULT_DOCS_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:55 PM

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
        fleR031A_MULT_OTHER_CLINIC_DOCTORS.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleR031A_SELECT_DOCTOR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_SEL_FILTER_MULT_DOCS_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:55 PM

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
            fleR031A_MULT_OTHER_CLINIC_DOCTORS.Dispose();
            fleF020_DOCTOR_EXTRA.Dispose();
            fleR031A_SELECT_DOCTOR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_SEL_FILTER_MULT_DOCS_9)"


    public void Run()
    {

        try
        {
            Request("SEL_FILTER_MULT_DOCS_9");

            while (fleR031A_MULT_OTHER_CLINIC_DOCTORS.QTPForMissing())
            {
                // --> GET R031A_MULT_OTHER_CLINIC_DOCTORS <--

                fleR031A_MULT_OTHER_CLINIC_DOCTORS.GetData();
                // --> End GET R031A_MULT_OTHER_CLINIC_DOCTORS <--

                while (fleF020_DOCTOR_EXTRA.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_EXTRA <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleR031A_MULT_OTHER_CLINIC_DOCTORS.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_EXTRA <--


                    if (Transaction())
                    {

                        Sort(fleR031A_MULT_OTHER_CLINIC_DOCTORS.GetSortValue("ICONST_CLINIC_NBR_1_2"), fleR031A_MULT_OTHER_CLINIC_DOCTORS.GetSortValue("X_ADJ_CD"), fleR031A_MULT_OTHER_CLINIC_DOCTORS.GetSortValue("DOC_OHIP_NBR"), fleF020_DOCTOR_EXTRA.GetSortValue("PAY_THIS_DOCTOR_OHIP_PREMIUM"), fleR031A_MULT_OTHER_CLINIC_DOCTORS.GetSortValue("DOC_DEPT", SortType.Descending), fleR031A_MULT_OTHER_CLINIC_DOCTORS.GetSortValue("DOC_DATE_FAC_START"));



                    }

                }

            }


            while (Sort(fleR031A_MULT_OTHER_CLINIC_DOCTORS, fleF020_DOCTOR_EXTRA))
            {



                SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_SELECT_DOCTOR, fleR031A_MULT_OTHER_CLINIC_DOCTORS.At("ICONST_CLINIC_NBR_1_2") || fleR031A_MULT_OTHER_CLINIC_DOCTORS.At("X_ADJ_CD") || fleR031A_MULT_OTHER_CLINIC_DOCTORS.At("DOC_OHIP_NBR"), SubFileType.Keep, fleR031A_MULT_OTHER_CLINIC_DOCTORS);



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
            EndRequest("SEL_FILTER_MULT_DOCS_9");

        }

    }




    #endregion


}
//SEL_FILTER_MULT_DOCS_9



public class U030B_PART3_A_CONVERT_CLINIC_10 : U030B_PART3_A
{

    public U030B_PART3_A_CONVERT_CLINIC_10(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_SELECT_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_SELECT_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_TOTAL_PAID_AMT = new CoreDecimal("X_TOTAL_PAID_AMT", 8, this);
        fleR031A_CONVERT_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_CONVERT_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_CLINIC.GetValue += X_CLINIC_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_CONVERT_CLINIC_10)"

    private SqlFileObject fleR031A_SELECT_DOCTOR;
    private DDecimal X_CLINIC = new DDecimal("X_CLINIC", 2);
    private void X_CLINIC_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleR031A_SELECT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == 84 | QDesign.NULL(fleR031A_SELECT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == 96 | QDesign.NULL(fleR031A_SELECT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == 37 | QDesign.NULL(fleR031A_SELECT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == 78 | QDesign.NULL(fleR031A_SELECT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == 79 | QDesign.NULL(fleR031A_SELECT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == 88)
            {
                CurrentValue = 22;
            }
            else
            {
                CurrentValue = fleR031A_SELECT_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2");
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

    private CoreDecimal X_TOTAL_PAID_AMT;



    private SqlFileObject fleR031A_CONVERT_DOCTOR;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_CONVERT_CLINIC_10)"


    #region "Automatic Item Initialization(U030B_PART3_A_CONVERT_CLINIC_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_CONVERT_CLINIC_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:55 PM

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
        fleR031A_SELECT_DOCTOR.Transaction = m_trnTRANS_UPDATE;
        fleR031A_CONVERT_DOCTOR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_CONVERT_CLINIC_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:55 PM

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
            fleR031A_SELECT_DOCTOR.Dispose();
            fleR031A_CONVERT_DOCTOR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_CONVERT_CLINIC_10)"


    public void Run()
    {

        try
        {
            Request("CONVERT_CLINIC_10");

            while (fleR031A_SELECT_DOCTOR.QTPForMissing())
            {
                // --> GET R031A_SELECT_DOCTOR <--

                fleR031A_SELECT_DOCTOR.GetData();
                // --> End GET R031A_SELECT_DOCTOR <--


                if (Transaction())
                {

                    Sort(X_CLINIC.Value, fleR031A_SELECT_DOCTOR.GetSortValue("ICONST_CLINIC_NBR_1_2"), fleR031A_SELECT_DOCTOR.GetSortValue("X_ADJ_CD"), fleR031A_SELECT_DOCTOR.GetSortValue("DOC_OHIP_NBR"), fleR031A_SELECT_DOCTOR.GetSortValue("DOC_NBR"));



                }

            }

            while (Sort(fleR031A_SELECT_DOCTOR))
            {
                X_TOTAL_PAID_AMT.Value = X_TOTAL_PAID_AMT.Value + fleR031A_SELECT_DOCTOR.GetDecimalValue("X_PAYMENT");





                SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_CONVERT_DOCTOR, At(X_CLINIC) || fleR031A_SELECT_DOCTOR.At("ICONST_CLINIC_NBR_1_2") || fleR031A_SELECT_DOCTOR.At("X_ADJ_CD") || fleR031A_SELECT_DOCTOR.At("DOC_OHIP_NBR") || fleR031A_SELECT_DOCTOR.At("DOC_NBR"), SubFileType.Keep, X_CLINIC, X_TOTAL_PAID_AMT, fleR031A_SELECT_DOCTOR);



                Reset(ref X_TOTAL_PAID_AMT, At(X_CLINIC) || fleR031A_SELECT_DOCTOR.At("ICONST_CLINIC_NBR_1_2") || fleR031A_SELECT_DOCTOR.At("X_ADJ_CD") || fleR031A_SELECT_DOCTOR.At("DOC_OHIP_NBR") || fleR031A_SELECT_DOCTOR.At("DOC_NBR"));

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
            EndRequest("CONVERT_CLINIC_10");

        }

    }




    #endregion


}
//CONVERT_CLINIC_10



public class U030B_PART3_A_SEL_ACTIVE_DOCTOR_11 : U030B_PART3_A
{

    public U030B_PART3_A_SEL_ACTIVE_DOCTOR_11(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_CONVERT_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_CONVERT_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleR031A_ACTIVE_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_ACTIVE_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_SEL_ACTIVE_DOCTOR_11)"

    private SqlFileObject fleR031A_CONVERT_DOCTOR;

    public override bool SelectIf()
    {


        try
        {
            if ((QDesign.NULL(fleR031A_CONVERT_DOCTOR.GetNumericDateValue("DOC_DATE_FAC_TERM")) == 0 | QDesign.NULL(fleR031A_CONVERT_DOCTOR.GetNumericDateValue("DOC_DATE_FAC_TERM")) > QDesign.NULL(QDesign.SysDate(ref m_cnnQUERY))) & QDesign.NULL(fleR031A_CONVERT_DOCTOR.GetDecimalValue("X_TOTAL_PAID_AMT")) != 0)
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





    private SqlFileObject fleR031A_ACTIVE_DOCTOR;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_SEL_ACTIVE_DOCTOR_11)"


    #region "Automatic Item Initialization(U030B_PART3_A_SEL_ACTIVE_DOCTOR_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_SEL_ACTIVE_DOCTOR_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:55 PM

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
        fleR031A_CONVERT_DOCTOR.Transaction = m_trnTRANS_UPDATE;
        fleR031A_ACTIVE_DOCTOR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_SEL_ACTIVE_DOCTOR_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:56 PM

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
            fleR031A_CONVERT_DOCTOR.Dispose();
            fleR031A_ACTIVE_DOCTOR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_SEL_ACTIVE_DOCTOR_11)"


    public void Run()
    {

        try
        {
            Request("SEL_ACTIVE_DOCTOR_11");

            while (fleR031A_CONVERT_DOCTOR.QTPForMissing())
            {
                // --> GET R031A_CONVERT_DOCTOR <--

                fleR031A_CONVERT_DOCTOR.GetData();
                // --> End GET R031A_CONVERT_DOCTOR <--


                if (Transaction())
                {

                     if (Select_If())
                    {




                        SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_ACTIVE_DOCTOR, SubFileType.Keep, fleR031A_CONVERT_DOCTOR);



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
            EndRequest("SEL_ACTIVE_DOCTOR_11");

        }

    }




    #endregion


}
//SEL_ACTIVE_DOCTOR_11



public class U030B_PART3_A_CALCULATE_RUNNING_AMT_12 : U030B_PART3_A
{

    public U030B_PART3_A_CALCULATE_RUNNING_AMT_12(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_ACTIVE_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_ACTIVE_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_AMT = new CoreDecimal("X_AMT", 9, this);
        fleR031A_RUNNING_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_RUNNING_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_CALCULATE_RUNNING_AMT_12)"

    private SqlFileObject fleR031A_ACTIVE_DOCTOR;

    private CoreDecimal X_AMT;



    private SqlFileObject fleR031A_RUNNING_AMT;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_CALCULATE_RUNNING_AMT_12)"


    #region "Automatic Item Initialization(U030B_PART3_A_CALCULATE_RUNNING_AMT_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_CALCULATE_RUNNING_AMT_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:56 PM

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
        fleR031A_ACTIVE_DOCTOR.Transaction = m_trnTRANS_UPDATE;
        fleR031A_RUNNING_AMT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_CALCULATE_RUNNING_AMT_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:56 PM

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
            fleR031A_ACTIVE_DOCTOR.Dispose();
            fleR031A_RUNNING_AMT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_CALCULATE_RUNNING_AMT_12)"


    public void Run()
    {

        try
        {
            Request("CALCULATE_RUNNING_AMT_12");

            while (fleR031A_ACTIVE_DOCTOR.QTPForMissing())
            {
                // --> GET R031A_ACTIVE_DOCTOR <--

                fleR031A_ACTIVE_DOCTOR.GetData();
                // --> End GET R031A_ACTIVE_DOCTOR <--


                if (Transaction())
                {

                    Sort(fleR031A_ACTIVE_DOCTOR.GetSortValue("X_CLINIC"));



                }

            }

            while (Sort(fleR031A_ACTIVE_DOCTOR))
            {
                X_AMT.Value = X_AMT.Value + fleR031A_ACTIVE_DOCTOR.GetDecimalValue("X_TOTAL_PAID_AMT");





                SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_RUNNING_AMT, SubFileType.Keep, X_AMT, fleR031A_ACTIVE_DOCTOR);



                Reset(ref X_AMT, fleR031A_ACTIVE_DOCTOR.At("X_CLINIC"));

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
            EndRequest("CALCULATE_RUNNING_AMT_12");

        }

    }




    #endregion


}
//CALCULATE_RUNNING_AMT_12



public class U030B_PART3_A_DETERMINE_HIGHEST_AMT_13 : U030B_PART3_A
{

    public U030B_PART3_A_DETERMINE_HIGHEST_AMT_13(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_ACTIVE_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_ACTIVE_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleR031A_HIGHEST_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_HIGHEST_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_ABS_AMT.GetValue += X_ABS_AMT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_DETERMINE_HIGHEST_AMT_13)"

    private SqlFileObject fleR031A_ACTIVE_DOCTOR;
    private DDecimal X_ABS_AMT = new DDecimal("X_ABS_AMT", 6);
    private void X_ABS_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = Math.Abs(fleR031A_ACTIVE_DOCTOR.GetDecimalValue("X_TOTAL_PAID_AMT"));


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




    private SqlFileObject fleR031A_HIGHEST_AMT;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_DETERMINE_HIGHEST_AMT_13)"


    #region "Automatic Item Initialization(U030B_PART3_A_DETERMINE_HIGHEST_AMT_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_DETERMINE_HIGHEST_AMT_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:56 PM

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
        fleR031A_ACTIVE_DOCTOR.Transaction = m_trnTRANS_UPDATE;
        fleR031A_HIGHEST_AMT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_DETERMINE_HIGHEST_AMT_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:56 PM

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
            fleR031A_ACTIVE_DOCTOR.Dispose();
            fleR031A_HIGHEST_AMT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_DETERMINE_HIGHEST_AMT_13)"


    public void Run()
    {

        try
        {
            Request("DETERMINE_HIGHEST_AMT_13");

            while (fleR031A_ACTIVE_DOCTOR.QTPForMissing())
            {
                // --> GET R031A_ACTIVE_DOCTOR <--

                fleR031A_ACTIVE_DOCTOR.GetData();
                // --> End GET R031A_ACTIVE_DOCTOR <--


                if (Transaction())
                {

                    Sort(X_ABS_AMT.Value);



                }

            }


            while (Sort(fleR031A_ACTIVE_DOCTOR))
            {



                SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_HIGHEST_AMT, AtFinal(), SubFileType.Keep, X_ABS_AMT, fleR031A_ACTIVE_DOCTOR);



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
            EndRequest("DETERMINE_HIGHEST_AMT_13");

        }

    }




    #endregion


}
//DETERMINE_HIGHEST_AMT_13



public class U030B_PART3_A_CALCULATE_BATCH_NBR_14 : U030B_PART3_A
{

    public U030B_PART3_A_CALCULATE_BATCH_NBR_14(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_RUNNING_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_RUNNING_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleR031A_HIGHEST_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_HIGHEST_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_BATCH_COUNT_BEFORE = new CoreDecimal("X_BATCH_COUNT_BEFORE", 6, this);
        X_BATCH_COUNT_AFTER = new CoreDecimal("X_BATCH_COUNT_AFTER", 6, this);
        X_COUNT = new CoreDecimal("X_COUNT", 6, this);
        X_CLAIM_COUNT = new CoreDecimal("X_CLAIM_COUNT", 6, this);
        X_BATCH_COUNT = new CoreDecimal("X_BATCH_COUNT", 6, this);
        X_BATCH_AMOUNT = new CoreDecimal("X_BATCH_AMOUNT", 9, this);
        CHANGE_BATCH_FLAG = new CoreCharacter("CHANGE_BATCH_FLAG", 1, this, Common.cEmptyString);
        fleR031A_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleR031A_DEBUG_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_DEBUG_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_CHECK_AMT.GetValue += X_CHECK_AMT_GetValue;
        X_ABS_BATCH_AMT.GetValue += X_ABS_BATCH_AMT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_CALCULATE_BATCH_NBR_14)"

    private SqlFileObject fleR031A_RUNNING_AMT;




    private SqlFileObject fleR031A_HIGHEST_AMT;
    private DDecimal X_CHECK_AMT = new DDecimal("X_CHECK_AMT", 7);
    private void X_CHECK_AMT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 9000000)
            {
                CurrentValue = 500000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 8500000)
            {
                CurrentValue = 1000000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 8000000)
            {
                CurrentValue = 1500000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 7500000)
            {
                CurrentValue = 2000000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 7000000)
            {
                CurrentValue = 2500000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 6500000)
            {
                CurrentValue = 3000000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 6000000)
            {
                CurrentValue = 3500000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 5500000)
            {
                CurrentValue = 4000000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 5000000)
            {
                CurrentValue = 4500000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 4500000)
            {
                CurrentValue = 5000000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 4000000)
            {
                CurrentValue = 5500000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 3500000)
            {
                CurrentValue = 6000000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 3000000)
            {
                CurrentValue = 6500000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 2500000)
            {
                CurrentValue = 7000000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 2000000)
            {
                CurrentValue = 7500000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 1500000)
            {
                CurrentValue = 8000000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 1000000)
            {
                CurrentValue = 8500000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 500000)
            {
                CurrentValue = 9000000;
            }
            else if (QDesign.NULL(fleR031A_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 0)
            {
                CurrentValue = 9500000;
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
    private CoreDecimal X_BATCH_COUNT_BEFORE;
    private CoreDecimal X_BATCH_COUNT_AFTER;
    private CoreDecimal X_COUNT;
    private CoreDecimal X_CLAIM_COUNT;
    private CoreDecimal X_BATCH_COUNT;
    private CoreDecimal X_BATCH_AMOUNT;
    private CoreCharacter CHANGE_BATCH_FLAG;
    private DDecimal X_ABS_BATCH_AMT = new DDecimal("X_ABS_BATCH_AMT", 6);
    private void X_ABS_BATCH_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = Math.Abs(X_BATCH_AMOUNT.Value);


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




    private SqlFileObject fleR031A_BATCH_NBR;




    private SqlFileObject fleR031A_DEBUG_BATCH_NBR;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_A_CALCULATE_BATCH_NBR_14)"


    #region "Automatic Item Initialization(U030B_PART3_A_CALCULATE_BATCH_NBR_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_CALCULATE_BATCH_NBR_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:56 PM

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
        fleR031A_RUNNING_AMT.Transaction = m_trnTRANS_UPDATE;
        fleR031A_HIGHEST_AMT.Transaction = m_trnTRANS_UPDATE;
        fleR031A_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
        fleR031A_DEBUG_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_CALCULATE_BATCH_NBR_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:57 PM

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
            fleR031A_RUNNING_AMT.Dispose();
            fleR031A_HIGHEST_AMT.Dispose();
            fleR031A_BATCH_NBR.Dispose();
            fleR031A_DEBUG_BATCH_NBR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_CALCULATE_BATCH_NBR_14)"


    public void Run()
    {

        try
        {
            Request("CALCULATE_BATCH_NBR_14");

            while (fleR031A_RUNNING_AMT.QTPForMissing())
            {
                // --> GET R031A_RUNNING_AMT <--

                fleR031A_RUNNING_AMT.GetData();
                // --> End GET R031A_RUNNING_AMT <--

                while (fleR031A_HIGHEST_AMT.QTPForMissing("1"))
                {
                    // --> GET R031A_HIGHEST_AMT <--
                    //m_strWhere = new StringBuilder(" WHERE ");
                    //m_strWhere.Append(" ").Append(fleR031A_HIGHEST_AMT.ElementOwner("CORE_RECORD_NUMBER")).Append(" = ");
                    //m_strWhere.Append((0));

                    //fleR031A_HIGHEST_AMT.GetData(m_strWhere.ToString());
                    fleR031A_HIGHEST_AMT.GetData();
                    // --> End GET R031A_HIGHEST_AMT <--


                    if (Transaction())
                    {

                        Sort(fleR031A_RUNNING_AMT.GetSortValue("X_CLINIC"));



                    }

                }

            }

            while (Sort(fleR031A_RUNNING_AMT, fleR031A_HIGHEST_AMT))
            {
                X_BATCH_COUNT_BEFORE.Value = X_BATCH_COUNT.Value;
                if (QDesign.NULL(X_CLAIM_COUNT.Value) < 99 & QDesign.NULL(X_BATCH_COUNT.Value) != 0)
                {
                    CHANGE_BATCH_FLAG.Value = "N";
                }
                else
                {
                    CHANGE_BATCH_FLAG.Value = "Y";
                }
                if (QDesign.NULL(CHANGE_BATCH_FLAG.Value) == "N")
                {
                    X_BATCH_AMOUNT.Value = X_BATCH_AMOUNT.Value + fleR031A_RUNNING_AMT.GetDecimalValue("X_TOTAL_PAID_AMT");
                }
                else
                {
                    X_BATCH_AMOUNT.Value = fleR031A_RUNNING_AMT.GetDecimalValue("X_TOTAL_PAID_AMT");
                }
                if (QDesign.NULL(CHANGE_BATCH_FLAG.Value) == "N")
                {
                    X_CLAIM_COUNT.Value = X_CLAIM_COUNT.Value + 1;
                }
                else
                {
                    X_CLAIM_COUNT.Value = 1;
                }
                if (QDesign.NULL(CHANGE_BATCH_FLAG.Value) == "Y")
                {
                    X_BATCH_COUNT.Value = X_BATCH_COUNT.Value + 1;
                }
                else
                {
                    X_BATCH_COUNT.Value = X_BATCH_COUNT_BEFORE.Value;
                }
                Count(ref X_COUNT);
                X_BATCH_COUNT_AFTER.Value = X_BATCH_COUNT.Value;





                SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_BATCH_NBR, SubFileType.Keep, X_COUNT, X_BATCH_COUNT, X_CLAIM_COUNT, fleR031A_RUNNING_AMT);






                SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_DEBUG_BATCH_NBR, SubFileType.Keep, X_COUNT, X_BATCH_COUNT_BEFORE, X_BATCH_COUNT, X_CLAIM_COUNT, X_BATCH_AMOUNT, X_BATCH_COUNT_AFTER, fleR031A_RUNNING_AMT);



                Reset(ref X_BATCH_AMOUNT, fleR031A_RUNNING_AMT.At("X_CLINIC"));
                Reset(ref X_BATCH_COUNT, fleR031A_RUNNING_AMT.At("X_CLINIC"));
                Reset(ref X_COUNT, fleR031A_RUNNING_AMT.At("X_CLINIC"));

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
            EndRequest("CALCULATE_BATCH_NBR_14");

        }

    }




    #endregion


}
//CALCULATE_BATCH_NBR_14



public class U030B_PART3_A_TRANSFER_TO_TMP_FILE_15 : U030B_PART3_A
{

    public U030B_PART3_A_TRANSFER_TO_TMP_FILE_15(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_ACTIVE_DOCTOR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_ACTIVE_DOCTOR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_COUNTERS_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_COUNTERS_ALPHA.SetItemFinals += fleTMP_COUNTERS_ALPHA_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_A_TRANSFER_TO_TMP_FILE_15)"

    private SqlFileObject fleR031A_ACTIVE_DOCTOR;
    private SqlFileObject fleTMP_COUNTERS_ALPHA;

    private void fleTMP_COUNTERS_ALPHA_SetItemFinals()
    {

        try
        {
            fleTMP_COUNTERS_ALPHA.set_SetValue("TMP_COUNTER_KEY_ALPHA", QDesign.ASCII(fleR031A_ACTIVE_DOCTOR.GetDecimalValue("ICONST_CLINIC_NBR_1_2"), 2) + fleR031A_ACTIVE_DOCTOR.GetStringValue("X_ADJ_CD") + QDesign.ASCII(fleR031A_ACTIVE_DOCTOR.GetDecimalValue("DOC_OHIP_NBR"), 6));


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


    #region "Standard Generated Procedures(U030B_PART3_A_TRANSFER_TO_TMP_FILE_15)"


    #region "Automatic Item Initialization(U030B_PART3_A_TRANSFER_TO_TMP_FILE_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_A_TRANSFER_TO_TMP_FILE_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:57 PM

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
        fleR031A_ACTIVE_DOCTOR.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS_ALPHA.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_A_TRANSFER_TO_TMP_FILE_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:57 PM

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
            fleR031A_ACTIVE_DOCTOR.Dispose();
            fleTMP_COUNTERS_ALPHA.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_A_TRANSFER_TO_TMP_FILE_15)"


    public void Run()
    {

        try
        {
            Request("TRANSFER_TO_TMP_FILE_15");

            while (fleR031A_ACTIVE_DOCTOR.QTPForMissing())
            {
                // --> GET R031A_ACTIVE_DOCTOR <--

                fleR031A_ACTIVE_DOCTOR.GetData();
                // --> End GET R031A_ACTIVE_DOCTOR <--


                if (Transaction())
                {




                    fleTMP_COUNTERS_ALPHA.OutPut(OutPutType.Add);


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
            EndRequest("TRANSFER_TO_TMP_FILE_15");

        }

    }




    #endregion


}
//TRANSFER_TO_TMP_FILE_15




