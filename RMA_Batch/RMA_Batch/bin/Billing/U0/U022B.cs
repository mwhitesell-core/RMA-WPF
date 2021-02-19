
#region "Screen Comments"

// #> PROGRAM-ID.     U022B.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : TO SELECT DETAIL CLAIMS FOR RE-SUBMITION
// AND CREATE TAPE FILE
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 91/MAR/04 D.B.         - ORIGINAL (SMS 138)
// 91/OCT/09 M.C.           - PDR 527 - OPTIMIZATION SIMILIAR TO U020
// 97/AUG/18 M.C.           - ADD U020_USE FILE IN THE PROGRAM
// 1999/jan/31 B.E.  - y2k


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U022B : BaseClassControl
{

    private U022B m_U022B;

    public U022B(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U022B(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U022B != null))
        {
            m_U022B.CloseTransactionObjects();
            m_U022B = null;
        }
    }

    public U022B GetU022B(int Level)
    {
        if (m_U022B == null)
        {
            m_U022B = new U022B("U022B", Level);
        }
        else
        {
            m_U022B.ResetValues();
        }
        return m_U022B;
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

            U022B_SELECT_CLMDTL_1 SELECT_CLMDTL_1 = new U022B_SELECT_CLMDTL_1(Name, Level);
            SELECT_CLMDTL_1.Run();
            SELECT_CLMDTL_1.Dispose();
            SELECT_CLMDTL_1 = null;

            U022B_CHECK_SLI_2 CHECK_SLI_2 = new U022B_CHECK_SLI_2(Name, Level);
            CHECK_SLI_2.Run();
            CHECK_SLI_2.Dispose();
            CHECK_SLI_2 = null;

            U022B_CREATE_TAPE_3 CREATE_TAPE_3 = new U022B_CREATE_TAPE_3(Name, Level);
            CREATE_TAPE_3.Run();
            CREATE_TAPE_3.Dispose();
            CREATE_TAPE_3 = null;

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



public class U022B_SELECT_CLMDTL_1 : U022B
{

    public U022B_SELECT_CLMDTL_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU020A1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020A1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU020B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU020B1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020B", "U020B1", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU020B2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020B", "U020B2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU020B3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020B", "U020B3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        W_CLMDTL_NBR_SERV_1.GetValue += W_CLMDTL_NBR_SERV_1_GetValue;
        W_CLMDTL_NBR_SERV_2.GetValue += W_CLMDTL_NBR_SERV_2_GetValue;
        W_CLMDTL_NBR_SERV_3.GetValue += W_CLMDTL_NBR_SERV_3_GetValue;
        W_CLMDTL_NBR_SERV.GetValue += W_CLMDTL_NBR_SERV_GetValue;
        W_FEE.GetValue += W_FEE_GetValue;
        W_CLMDTL_FEE_OHIP.GetValue += W_CLMDTL_FEE_OHIP_GetValue;
        W_CLMDTL_FEE_OHIP_1.GetValue += W_CLMDTL_FEE_OHIP_1_GetValue;
        W_CLMDTL_FEE_OHIP_2.GetValue += W_CLMDTL_FEE_OHIP_2_GetValue;
        W_CLMDTL_FEE_OHIP_3.GetValue += W_CLMDTL_FEE_OHIP_3_GetValue;
        W_CLMDTL_SV_DATE_1.GetValue += W_CLMDTL_SV_DATE_1_GetValue;
        W_CLMDTL_SV_DATE_2.GetValue += W_CLMDTL_SV_DATE_2_GetValue;
        W_CLMDTL_SV_DATE_3.GetValue += W_CLMDTL_SV_DATE_3_GetValue;
        W_SUBSCR_ADDR2.GetValue += W_SUBSCR_ADDR2_GetValue;
        W_SUBSCR_ADDR3.GetValue += W_SUBSCR_ADDR3_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(U022B_SELECT_CLMDTL_1)"

    private SqlFileObject fleU020A1;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_ADJ_OMA_CD")).Append(" <>  '0000' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_ADJ_OMA_CD")).Append(" <>  'ZZZZ')");


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

    private DDecimal W_CLMDTL_NBR_SERV_1 = new DDecimal("W_CLMDTL_NBR_SERV_1", 2);
    private void W_CLMDTL_NBR_SERV_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if ((QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) != "MR" & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) != "OP") & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 1, 1)) != "0")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 1, 1));
                //Parent:CLMDTL_CONSEC_DATES_R
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
    private DDecimal W_CLMDTL_NBR_SERV_2 = new DDecimal("W_CLMDTL_NBR_SERV_2", 2);
    private void W_CLMDTL_NBR_SERV_2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if ((QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) != "MR" & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) != "OP") & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 4, 1)) != "0")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 4, 1));
                //Parent:CLMDTL_CONSEC_DATES_R
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
    private DDecimal W_CLMDTL_NBR_SERV_3 = new DDecimal("W_CLMDTL_NBR_SERV_3", 2);
    private void W_CLMDTL_NBR_SERV_3_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if ((QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) != "MR" & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) != "OP") & QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 7, 1)) != "0")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 7, 1));
                //Parent:CLMDTL_CONSEC_DATES_R
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
    private DDecimal W_CLMDTL_NBR_SERV = new DDecimal("W_CLMDTL_NBR_SERV", 6);
    private void W_CLMDTL_NBR_SERV_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + W_CLMDTL_NBR_SERV_1.Value + W_CLMDTL_NBR_SERV_2.Value + W_CLMDTL_NBR_SERV_3.Value;


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
    private DDecimal W_FEE = new DDecimal("W_FEE", 6);
    private void W_FEE_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / W_CLMDTL_NBR_SERV.Value;


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
    private DDecimal W_CLMDTL_FEE_OHIP = new DDecimal("W_CLMDTL_FEE_OHIP", 7);
    private void W_CLMDTL_FEE_OHIP_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU020A1.GetStringValue("DOLLAR_FLAG")) == "Y")
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") * W_FEE.Value;
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
    private DDecimal W_CLMDTL_FEE_OHIP_1 = new DDecimal("W_CLMDTL_FEE_OHIP_1", 7);
    private void W_CLMDTL_FEE_OHIP_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU020A1.GetStringValue("DOLLAR_FLAG")) == "Y")
            {
                CurrentValue = W_CLMDTL_NBR_SERV_1.Value * W_FEE.Value;
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
    private DDecimal W_CLMDTL_FEE_OHIP_2 = new DDecimal("W_CLMDTL_FEE_OHIP_2", 7);
    private void W_CLMDTL_FEE_OHIP_2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU020A1.GetStringValue("DOLLAR_FLAG")) == "Y")
            {
                CurrentValue = W_CLMDTL_NBR_SERV_2.Value * W_FEE.Value;
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
    private DDecimal W_CLMDTL_FEE_OHIP_3 = new DDecimal("W_CLMDTL_FEE_OHIP_3", 7);
    private void W_CLMDTL_FEE_OHIP_3_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU020A1.GetStringValue("DOLLAR_FLAG")) == "Y")
            {
                CurrentValue = W_CLMDTL_NBR_SERV_3.Value * W_FEE.Value;
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
    private DCharacter W_CLMDTL_SV_DATE_1 = new DCharacter("W_CLMDTL_SV_DATE_1", 8);
    private void W_CLMDTL_SV_DATE_1_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2);



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
    private DCharacter W_CLMDTL_SV_DATE_2 = new DCharacter("W_CLMDTL_SV_DATE_2", 8);
    private void W_CLMDTL_SV_DATE_2_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 5, 2);



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
    private DCharacter W_CLMDTL_SV_DATE_3 = new DCharacter("W_CLMDTL_SV_DATE_3", 8);
    private void W_CLMDTL_SV_DATE_3_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 8, 2);



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
    private DCharacter W_SUBSCR_ADDR2 = new DCharacter("W_SUBSCR_ADDR2", 21);
    private void W_SUBSCR_ADDR2_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleU020A1.GetStringValue("SUBSCR_ADDR2")) != QDesign.NULL(" "))
            {
                CurrentValue = fleU020A1.GetStringValue("SUBSCR_ADDR2");
            }
            else
            {
                CurrentValue = fleU020A1.GetStringValue("SUBSCR_ADDR3");
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
    private DCharacter W_SUBSCR_ADDR3 = new DCharacter("W_SUBSCR_ADDR3", 21);
    private void W_SUBSCR_ADDR3_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleU020A1.GetStringValue("SUBSCR_ADDR2")) != QDesign.NULL(" "))
            {
                CurrentValue = fleU020A1.GetStringValue("SUBSCR_ADDR3");
            }
            else
            {
                CurrentValue = " ";
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


    private SqlFileObject fleU020B;


    private SqlFileObject fleU020B1;


    private SqlFileObject fleU020B2;


    private SqlFileObject fleU020B3;


    #endregion


    #region "Standard Generated Procedures(U022B_SELECT_CLMDTL_1)"


    #region "Automatic Item Initialization(U022B_SELECT_CLMDTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U022B_SELECT_CLMDTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:53 PM

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
        fleU020A1.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU020B.Transaction = m_trnTRANS_UPDATE;
        fleU020B1.Transaction = m_trnTRANS_UPDATE;
        fleU020B2.Transaction = m_trnTRANS_UPDATE;
        fleU020B3.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U022B_SELECT_CLMDTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:53 PM

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
            fleU020A1.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleU020B.Dispose();
            fleU020B1.Dispose();
            fleU020B2.Dispose();
            fleU020B3.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U022B_SELECT_CLMDTL_1)"


    public void Run()
    {

        try
        {
            Request("SELECT_CLMDTL_1");

            while (fleU020A1.QTPForMissing())
            {
                // --> GET U020A1 <--

                fleU020A1.GetData();
                // --> End GET U020A1 <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU020A1.GetStringValue("BATCTRL_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {


                        SubFile(ref m_trnTRANS_UPDATE, ref fleU020B, SubFileType.Keep, fleU020A1, "BATCTRL_BATCH_NBR", "BATCTRL_BATCH_TYPE", "BATCTRL_CLINIC_NBR", "BATCTRL_DOC_NBR_OHIP", "BATCTRL_LOC", "BATCTRL_AGENT_CD",
                        "BATCTRL_DATE_BATCH_ENTERED", "ICONST_CLINIC_NBR_1_2", "ICONST_CLINIC_CYCLE_NBR", "ICONST_DATE_PERIOD_END", "CLMHDR_DOC_SPEC_CD", "PAT_HEALTH_NBR", "PAT_VERSION_CD", "CLMHDR_CLAIM_ID", "W_CLMHDR_HOSP", "CLMHDR_REFER_DOC_NBR",
                        "CLMHDR_DATE_ADMIT", "W_PAT_OHIP_MMYY", "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLMHDR_SUB_NBR", "PAT_CHART_NBR", "CLMHDR_MANUAL_REVIEW", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_BIRTH_DATE", "W_PAT_SEX",
                        "PAT_PROV_CD", "SUBSCR_ADDR1", W_SUBSCR_ADDR2, W_SUBSCR_ADDR3, "SUBSCR_POSTAL_CD", fleF002_CLAIMS_MSTR, "CLMDTL_OMA_CD", "CLMDTL_OMA_SUFF", W_CLMDTL_FEE_OHIP, "CLMDTL_NBR_SERV",
                        "CLMDTL_SV_DATE", "CLMDTL_DIAG_CD", "CLMDTL_LINE_NO", fleU020A1, "TRANSLATED_GROUP_NBR", "W_MOH_LOCATION_CODE", "CONTRACT_CODE");




                        SubFile(ref m_trnTRANS_UPDATE, ref fleU020B1, QDesign.NULL(W_CLMDTL_NBR_SERV_1.Value) != 0, SubFileType.Keep, fleU020A1, "BATCTRL_BATCH_NBR", "BATCTRL_BATCH_TYPE", "BATCTRL_CLINIC_NBR", "BATCTRL_DOC_NBR_OHIP", "BATCTRL_LOC",
                        "BATCTRL_AGENT_CD", "BATCTRL_DATE_BATCH_ENTERED", "ICONST_CLINIC_NBR_1_2", "ICONST_CLINIC_CYCLE_NBR", "ICONST_DATE_PERIOD_END", "CLMHDR_DOC_SPEC_CD", "PAT_HEALTH_NBR", "PAT_VERSION_CD", "CLMHDR_CLAIM_ID", "W_CLMHDR_HOSP",
                        "CLMHDR_REFER_DOC_NBR", "CLMHDR_DATE_ADMIT", "W_PAT_OHIP_MMYY", "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLMHDR_SUB_NBR", "PAT_CHART_NBR", "CLMHDR_MANUAL_REVIEW", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_BIRTH_DATE",
                        "W_PAT_SEX", "PAT_PROV_CD", "SUBSCR_ADDR1", W_SUBSCR_ADDR2, W_SUBSCR_ADDR3, "SUBSCR_POSTAL_CD", fleF002_CLAIMS_MSTR, "CLMDTL_OMA_CD", "CLMDTL_OMA_SUFF", W_CLMDTL_FEE_OHIP_1,
                        W_CLMDTL_NBR_SERV_1, W_CLMDTL_SV_DATE_1, "CLMDTL_DIAG_CD", "CLMDTL_LINE_NO", fleU020A1, "TRANSLATED_GROUP_NBR", "W_MOH_LOCATION_CODE", "CONTRACT_CODE");




                        SubFile(ref m_trnTRANS_UPDATE, ref fleU020B2, QDesign.NULL(W_CLMDTL_NBR_SERV_2.Value) != 0, SubFileType.Keep, fleU020A1, "BATCTRL_BATCH_NBR", "BATCTRL_BATCH_TYPE", "BATCTRL_CLINIC_NBR", "BATCTRL_DOC_NBR_OHIP", "BATCTRL_LOC",
                        "BATCTRL_AGENT_CD", "BATCTRL_DATE_BATCH_ENTERED", "ICONST_CLINIC_NBR_1_2", "ICONST_CLINIC_CYCLE_NBR", "ICONST_DATE_PERIOD_END", "CLMHDR_DOC_SPEC_CD", "PAT_HEALTH_NBR", "PAT_VERSION_CD", "CLMHDR_CLAIM_ID", "W_CLMHDR_HOSP",
                        "CLMHDR_REFER_DOC_NBR", "CLMHDR_DATE_ADMIT", "W_PAT_OHIP_MMYY", "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLMHDR_SUB_NBR", "PAT_CHART_NBR", "CLMHDR_MANUAL_REVIEW", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_BIRTH_DATE",
                        "W_PAT_SEX", "PAT_PROV_CD", "SUBSCR_ADDR1", W_SUBSCR_ADDR2, W_SUBSCR_ADDR3, "SUBSCR_POSTAL_CD", fleF002_CLAIMS_MSTR, "CLMDTL_OMA_CD", "CLMDTL_OMA_SUFF", W_CLMDTL_FEE_OHIP_2,
                        W_CLMDTL_NBR_SERV_2, W_CLMDTL_SV_DATE_2, "CLMDTL_DIAG_CD", "CLMDTL_LINE_NO", fleU020A1, "TRANSLATED_GROUP_NBR", "W_MOH_LOCATION_CODE", "CONTRACT_CODE");




                        SubFile(ref m_trnTRANS_UPDATE, ref fleU020B3, QDesign.NULL(W_CLMDTL_NBR_SERV_3.Value) != 0, SubFileType.Keep, fleU020A1, "BATCTRL_BATCH_NBR", "BATCTRL_BATCH_TYPE", "BATCTRL_CLINIC_NBR", "BATCTRL_DOC_NBR_OHIP", "BATCTRL_LOC",
                        "BATCTRL_AGENT_CD", "BATCTRL_DATE_BATCH_ENTERED", "ICONST_CLINIC_NBR_1_2", "ICONST_CLINIC_CYCLE_NBR", "ICONST_DATE_PERIOD_END", "CLMHDR_DOC_SPEC_CD", "PAT_HEALTH_NBR", "PAT_VERSION_CD", "CLMHDR_CLAIM_ID", "W_CLMHDR_HOSP",
                        "CLMHDR_REFER_DOC_NBR", "CLMHDR_DATE_ADMIT", "W_PAT_OHIP_MMYY", "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLMHDR_SUB_NBR", "PAT_CHART_NBR", "CLMHDR_MANUAL_REVIEW", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_BIRTH_DATE",
                        "W_PAT_SEX", "PAT_PROV_CD", "SUBSCR_ADDR1", W_SUBSCR_ADDR2, W_SUBSCR_ADDR3, "SUBSCR_POSTAL_CD", fleF002_CLAIMS_MSTR, "CLMDTL_OMA_CD", "CLMDTL_OMA_SUFF", W_CLMDTL_FEE_OHIP_3,
                        W_CLMDTL_NBR_SERV_3, W_CLMDTL_SV_DATE_3, "CLMDTL_DIAG_CD", "CLMDTL_LINE_NO", fleU020A1, "TRANSLATED_GROUP_NBR", "W_MOH_LOCATION_CODE", "CONTRACT_CODE");



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
            EndRequest("SELECT_CLMDTL_1");

        }

    }




    #endregion


}
//SELECT_CLMDTL_1



public class U022B_CHECK_SLI_2 : U022B
{

    public U022B_CHECK_SLI_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU020B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF201_SLI_OMA_CODE_SUFF = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F201_SLI_OMA_CODE_SUFF", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        SLI_COUNT = new CoreDecimal("SLI_COUNT", 2, this);
        fleTMP_COUNTERS_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        CLAIM_KEY.GetValue += CLAIM_KEY_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U022B_CHECK_SLI_2)"

    private SqlFileObject fleU020B;
    private SqlFileObject fleF201_SLI_OMA_CODE_SUFF;
    private DCharacter CLAIM_KEY = new DCharacter("CLAIM_KEY", 10);
    private void CLAIM_KEY_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleU020B.GetStringValue("CLMHDR_CLAIM_ID"), 1, 10);


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
    private CoreDecimal SLI_COUNT;
    private SqlFileObject fleTMP_COUNTERS_ALPHA;

    #endregion


    #region "Standard Generated Procedures(U022B_CHECK_SLI_2)"


    #region "Automatic Item Initialization(U022B_CHECK_SLI_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U022B_CHECK_SLI_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:53 PM

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
        fleU020B.Transaction = m_trnTRANS_UPDATE;
        fleF201_SLI_OMA_CODE_SUFF.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS_ALPHA.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U022B_CHECK_SLI_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:53 PM

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
            fleU020B.Dispose();
            fleF201_SLI_OMA_CODE_SUFF.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U022B_CHECK_SLI_2)"


    public void Run()
    {

        try
        {
            Request("CHECK_SLI_2");

            while (fleU020B.QTPForMissing())
            {
                // --> GET U020B <--

                fleU020B.GetData();
                // --> End GET U020B <--

                while (fleF201_SLI_OMA_CODE_SUFF.QTPForMissing("1"))
                {
                    // --> GET F201_SLI_OMA_CODE_SUFF <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("CLMDTL_OMA_CD")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_CD")));
                    m_strWhere.Append(" And ").Append(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("CLMDTL_OMA_SUFF")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_SUFF")));
                    m_strWhere.Append(" And ").Append(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("LOC_SERVICE_LOCATION_INDICATOR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU020B.GetStringValue("W_MOH_LOCATION_CODE")));

                    fleF201_SLI_OMA_CODE_SUFF.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F201_SLI_OMA_CODE_SUFF <--


                    if (Transaction())
                    {

                        Sort(CLAIM_KEY.Value);



                    }

                }

            }

            while (Sort(fleU020B, fleF201_SLI_OMA_CODE_SUFF))
            {
                if (fleF201_SLI_OMA_CODE_SUFF.Exists())
                {
                    SLI_COUNT.Value = SLI_COUNT.Value + 1;
                }



                fleTMP_COUNTERS_ALPHA.OutPut(OutPutType.Add, At(CLAIM_KEY), null);

                Reset(ref SLI_COUNT, At(CLAIM_KEY));

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
            EndRequest("CHECK_SLI_2");

        }

    }




    #endregion


}
//CHECK_SLI_2



public class U022B_CREATE_TAPE_3 : U022B
{

    public U022B_CREATE_TAPE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU020B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_COUNTERS_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        W_BATCH_COUNT = new CoreDecimal("W_BATCH_COUNT", 4, this, 1m);
        W_B_COUNT = new CoreDecimal("W_B_COUNT", 4, this);
        W_B_COUNT_R = new CoreDecimal("W_B_COUNT_R", 4, this);
        W_H_COUNT = new CoreDecimal("W_H_COUNT", 4, this);
        W_R_COUNT = new CoreDecimal("W_R_COUNT", 4, this);
        W_T_COUNT = new CoreDecimal("W_T_COUNT", 4, this);
        W_A_COUNT = new CoreDecimal("W_A_COUNT", 4, this);
        W_COUNT = new CoreDecimal("W_COUNT", 6, this);
        fleU020_TP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020_TP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU020_TAPE_H1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020_TP", "U020_TAPE_H1", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU020_TAPE_H2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020_TP", "U020_TAPE_H2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU020_TAPE_I = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020_TP", "U020_TAPE_I", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU020_TAPE_T = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020_TP", "U020_TAPE_T", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        W_CLMHDR_CLAIM_ID.GetValue += W_CLMHDR_CLAIM_ID_GetValue;
        W_DTL.GetValue += W_DTL_GetValue;
        W_BATCH_IND.GetValue += W_BATCH_IND_GetValue;
        W_OPER_NBR.GetValue += W_OPER_NBR_GetValue;
        W_CLMDTL_OMA_SUFF.GetValue += W_CLMDTL_OMA_SUFF_GetValue;
        W_BATCH_IDENT.GetValue += W_BATCH_IDENT_GetValue;
        W_MOH_OFFICE_CODE.GetValue += W_MOH_OFFICE_CODE_GetValue;
        W_RELEASE_ID.GetValue += W_RELEASE_ID_GetValue;
        W_MOH_SLI_CODE.GetValue += W_MOH_SLI_CODE_GetValue;
        W_RESERVED_OCC_HDR1.GetValue += W_RESERVED_OCC_HDR1_GetValue;
        W_RESERVED_OCC_DTL1.GetValue += W_RESERVED_OCC_DTL1_GetValue;
        W_CLAIM_1_IDENT.GetValue += W_CLAIM_1_IDENT_GetValue;
        W_CLAIM_2_IDENT.GetValue += W_CLAIM_2_IDENT_GetValue;
        W_ITEM_IDENT.GetValue += W_ITEM_IDENT_GetValue;
        W_ADDR_IDENT.GetValue += W_ADDR_IDENT_GetValue;
        W_TRAIL_IDENT.GetValue += W_TRAIL_IDENT_GetValue;
        W_PAY_PROGRAM.GetValue += W_PAY_PROGRAM_GetValue;
        W_PAYEE.GetValue += W_PAYEE_GetValue;
        W_PAT_OHIP_NBR.GetValue += W_PAT_OHIP_NBR_GetValue;
        W_SUBSCR_ADDR_1.GetValue += W_SUBSCR_ADDR_1_GetValue;
        W_SUBSCR_ADDR_2.GetValue += W_SUBSCR_ADDR_2_GetValue;
        W_SUBSCR_ADDR_3.GetValue += W_SUBSCR_ADDR_3_GetValue;
        W_PAT_HEALTH_NBR.GetValue += W_PAT_HEALTH_NBR_GetValue;
        W_CLMHDR_REFER_DOC_NBR.GetValue += W_CLMHDR_REFER_DOC_NBR_GetValue;
        W_CLMHDR_DATE_ADMIT.GetValue += W_CLMHDR_DATE_ADMIT_GetValue;
        W_CLMHDR_MANUAL_REVIEW.GetValue += W_CLMHDR_MANUAL_REVIEW_GetValue;
        W_DEFAULT_POSTAL_CODE.GetValue += W_DEFAULT_POSTAL_CODE_GetValue;
        W_SUBSCR_POSTAL_CD.GetValue += W_SUBSCR_POSTAL_CD_GetValue;
        W_PAT_INFO.GetValue += W_PAT_INFO_GetValue;
        W_BATCH_HEADER_REC.GetValue += W_BATCH_HEADER_REC_GetValue;
        W_CLAIM_HEADER_REC_1.GetValue += W_CLAIM_HEADER_REC_1_GetValue;
        W_CLAIM_HEADER_REC_2.GetValue += W_CLAIM_HEADER_REC_2_GetValue;
        W_ITEM_REC.GetValue += W_ITEM_REC_GetValue;
        W_TRAILER_REC.GetValue += W_TRAILER_REC_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U022B_CREATE_TAPE_3)"

    private SqlFileObject fleU020B;
    private SqlFileObject fleTMP_COUNTERS_ALPHA;
    private DCharacter W_CLMHDR_CLAIM_ID = new DCharacter("W_CLMHDR_CLAIM_ID", 19);
    private void W_CLMHDR_CLAIM_ID_GetValue(ref string Value)
    {

        try
        {
            Value = fleU020B.GetStringValue("CLMHDR_CLAIM_ID") + fleU020B.GetStringValue("PAT_VERSION_CD");


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
    private DCharacter W_DTL = new DCharacter("W_DTL", 29);
    private void W_DTL_GetValue(ref string Value)
    {

        try
        {
            Value = W_CLMHDR_CLAIM_ID.Value + QDesign.ASCII(fleU020B.GetDecimalValue("CLMDTL_LINE_NO"), 2) + fleU020B.GetStringValue("CLMDTL_SV_DATE");


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
    private CoreDecimal W_BATCH_COUNT;
    private CoreDecimal W_B_COUNT;
    private CoreDecimal W_B_COUNT_R;
    private CoreDecimal W_H_COUNT;
    private CoreDecimal W_R_COUNT;
    private CoreDecimal W_T_COUNT;
    private CoreDecimal W_A_COUNT;
    private CoreDecimal W_COUNT;
    private DCharacter W_BATCH_IND = new DCharacter("W_BATCH_IND", 12);
    private void W_BATCH_IND_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(((QDesign.SysDate(ref m_cnnQUERY) * 10000) + W_BATCH_COUNT.Value), 12);


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
    private DCharacter W_OPER_NBR = new DCharacter("W_OPER_NBR", 6);
    private void W_OPER_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = "000805";


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
    private DCharacter W_CLMDTL_OMA_SUFF = new DCharacter("W_CLMDTL_OMA_SUFF", 1);
    private void W_CLMDTL_OMA_SUFF_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleU020B.GetStringValue("CLMDTL_OMA_SUFF")) != "M")
            {
                CurrentValue = fleU020B.GetStringValue("CLMDTL_OMA_SUFF");
            }
            else
            {
                CurrentValue = "A";
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
    private DCharacter W_BATCH_IDENT = new DCharacter("W_BATCH_IDENT", 3);
    private void W_BATCH_IDENT_GetValue(ref string Value)
    {

        try
        {
            Value = "HEB";


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
    private DCharacter W_MOH_OFFICE_CODE = new DCharacter("W_MOH_OFFICE_CODE", 1);
    private void W_MOH_OFFICE_CODE_GetValue(ref string Value)
    {

        try
        {
            Value = "G";


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
    private DCharacter W_RELEASE_ID = new DCharacter("W_RELEASE_ID", 3);
    private void W_RELEASE_ID_GetValue(ref string Value)
    {

        try
        {
            Value = "V03";


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
    private DCharacter W_MOH_SLI_CODE = new DCharacter("W_MOH_SLI_CODE", 4);
    private void W_MOH_SLI_CODE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleTMP_COUNTERS_ALPHA.GetDecimalValue("TMP_COUNTER_1")) == 0)
            {
                CurrentValue = "    ";
            }
            else
            {
                CurrentValue = fleU020B.GetStringValue("W_MOH_LOCATION_CODE");
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
    private DCharacter W_RESERVED_OCC_HDR1 = new DCharacter("W_RESERVED_OCC_HDR1", 4);
    private void W_RESERVED_OCC_HDR1_GetValue(ref string Value)
    {

        try
        {
            Value = "    ";


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
    private DCharacter W_RESERVED_OCC_DTL1 = new DCharacter("W_RESERVED_OCC_DTL1", 10);
    private void W_RESERVED_OCC_DTL1_GetValue(ref string Value)
    {

        try
        {
            Value = "          ";


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
    private DCharacter W_CLAIM_1_IDENT = new DCharacter("W_CLAIM_1_IDENT", 3);
    private void W_CLAIM_1_IDENT_GetValue(ref string Value)
    {

        try
        {
            Value = "HEH";


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
    private DCharacter W_CLAIM_2_IDENT = new DCharacter("W_CLAIM_2_IDENT", 3);
    private void W_CLAIM_2_IDENT_GetValue(ref string Value)
    {

        try
        {
            Value = "HER";


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
    private DCharacter W_ITEM_IDENT = new DCharacter("W_ITEM_IDENT", 3);
    private void W_ITEM_IDENT_GetValue(ref string Value)
    {

        try
        {
            Value = "HET";


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
    private DCharacter W_ADDR_IDENT = new DCharacter("W_ADDR_IDENT", 3);
    private void W_ADDR_IDENT_GetValue(ref string Value)
    {

        try
        {
            Value = "HEA";


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
    private DCharacter W_TRAIL_IDENT = new DCharacter("W_TRAIL_IDENT", 3);
    private void W_TRAIL_IDENT_GetValue(ref string Value)
    {

        try
        {
            Value = "HEE";


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
    private DCharacter W_PAY_PROGRAM = new DCharacter("W_PAY_PROGRAM", 3);
    private void W_PAY_PROGRAM_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleU020B.GetStringValue("PAT_PROV_CD")) != "ON")
            {
                CurrentValue = "RMB";
            }
            else if (QDesign.NULL(fleU020B.GetDecimalValue("BATCTRL_AGENT_CD")) == 2)
            {
                CurrentValue = "WCB";
            }
            else
            {
                CurrentValue = "HCP";
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
    private DCharacter W_PAYEE = new DCharacter("W_PAYEE", 1);
    private void W_PAYEE_GetValue(ref string Value)
    {

        try
        {
            Value = "P";


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
    private DCharacter W_PAT_OHIP_NBR = new DCharacter("W_PAT_OHIP_NBR", 12);
    private void W_PAT_OHIP_NBR_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleU020B.GetStringValue("PAT_PROV_CD")) == "ON")
            {
                CurrentValue= QDesign.Substring(fleU020B.GetStringValue("W_PAT_OHIP_MMYY"), 1, 8);
            }
            else
            {
                CurrentValue= QDesign.Substring(fleU020B.GetStringValue("W_PAT_OHIP_MMYY"), 1, 12);
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
    private DCharacter W_SUBSCR_ADDR_1 = new DCharacter("W_SUBSCR_ADDR_1", 25);
    private void W_SUBSCR_ADDR_1_GetValue(ref string Value)
    {

        try
        {
            Value = fleU020B.GetStringValue("SUBSCR_ADDR1");


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
    private DCharacter W_SUBSCR_ADDR_2 = new DCharacter("W_SUBSCR_ADDR_2", 25);
    private void W_SUBSCR_ADDR_2_GetValue(ref string Value)
    {

        try
        {
            Value = fleU020B.GetStringValue("W_SUBSCR_ADDR2");


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
    private DCharacter W_SUBSCR_ADDR_3 = new DCharacter("W_SUBSCR_ADDR_3", 18);
    private void W_SUBSCR_ADDR_3_GetValue(ref string Value)
    {

        try
        {
            Value = fleU020B.GetStringValue("W_SUBSCR_ADDR3");


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
    private DCharacter W_PAT_HEALTH_NBR = new DCharacter("W_PAT_HEALTH_NBR", 10);
    private void W_PAT_HEALTH_NBR_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (fleU020B.GetDecimalValue("PAT_HEALTH_NBR") != 0 & fleU020B.GetDecimalValue("PAT_HEALTH_NBR") != 1111111116)
            {
                CurrentValue = QDesign.ASCII(fleU020B.GetDecimalValue("PAT_HEALTH_NBR"), 10);
            }
            else
            {
                CurrentValue = " ";
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
    private DCharacter W_CLMHDR_REFER_DOC_NBR = new DCharacter("W_CLMHDR_REFER_DOC_NBR", 6);
    private void W_CLMHDR_REFER_DOC_NBR_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleU020B.GetDecimalValue("CLMHDR_REFER_DOC_NBR")) != 0)
            {
                CurrentValue = QDesign.ASCII(fleU020B.GetDecimalValue("CLMHDR_REFER_DOC_NBR"), 6);
            }
            else
            {
                CurrentValue = " ";
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
    private DCharacter W_CLMHDR_DATE_ADMIT = new DCharacter("W_CLMHDR_DATE_ADMIT", 8);
    private void W_CLMHDR_DATE_ADMIT_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleU020B.GetStringValue("CLMHDR_DATE_ADMIT")) != "00000000")
            {
                CurrentValue = fleU020B.GetStringValue("CLMHDR_DATE_ADMIT");
            }
            else
            {
                CurrentValue = " ";
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
    private DCharacter W_CLMHDR_MANUAL_REVIEW = new DCharacter("W_CLMHDR_MANUAL_REVIEW", 1);
    private void W_CLMHDR_MANUAL_REVIEW_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleU020B.GetStringValue("CLMHDR_MANUAL_REVIEW")) == "Y")
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = " ";
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
    private DCharacter W_DEFAULT_POSTAL_CODE = new DCharacter("W_DEFAULT_POSTAL_CODE", 6);
    private void W_DEFAULT_POSTAL_CODE_GetValue(ref string Value)
    {

        try
        {
            Value = "L8S4K1";


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
    private DCharacter W_SUBSCR_POSTAL_CD = new DCharacter("W_SUBSCR_POSTAL_CD", 6);
    private void W_SUBSCR_POSTAL_CD_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleU020B.GetStringValue("SUBSCR_POSTAL_CD")) != " 0 0 0")
            {
                CurrentValue = fleU020B.GetStringValue("SUBSCR_POSTAL_CD");
            }
            else
            {
                CurrentValue = W_DEFAULT_POSTAL_CODE.Value;
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
    private DCharacter W_PAT_INFO = new DCharacter("W_PAT_INFO", 20);
    private void W_PAT_INFO_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleU020B.GetDecimalValue("PAT_HEALTH_NBR")) != 1111111116)
            {
                CurrentValue = W_PAT_HEALTH_NBR.Value + fleU020B.GetStringValue("PAT_VERSION_CD") + QDesign.ASCII(fleU020B.GetNumericDateValue("PAT_BIRTH_DATE"), 8);
            }
            else
            {
                CurrentValue = " ";
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
    private DCharacter W_BATCH_HEADER_REC = new DCharacter("W_BATCH_HEADER_REC", 79);
    private void W_BATCH_HEADER_REC_GetValue(ref string Value)
    {

        try
        {
            Value = W_BATCH_IDENT.Value + W_RELEASE_ID.Value + W_MOH_OFFICE_CODE.Value + W_BATCH_IND.Value + W_OPER_NBR.Value + fleU020B.GetStringValue("TRANSLATED_GROUP_NBR") + QDesign.ASCII(fleU020B.GetDecimalValue("BATCTRL_DOC_NBR_OHIP"), 6) + QDesign.ASCII(fleU020B.GetDecimalValue("CLMHDR_DOC_SPEC_CD"), 2);


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
    private DCharacter W_CLAIM_HEADER_REC_1 = new DCharacter("W_CLAIM_HEADER_REC_1", 79);
    private void W_CLAIM_HEADER_REC_1_GetValue(ref string Value)
    {

        try
        {
            Value = W_CLAIM_1_IDENT.Value + W_PAT_INFO.Value + QDesign.Substring(fleU020B.GetStringValue("CLMHDR_CLAIM_ID"), 3, 8) + W_PAY_PROGRAM.Value + W_PAYEE.Value + W_CLMHDR_REFER_DOC_NBR.Value + fleU020B.GetStringValue("W_CLMHDR_HOSP") + W_CLMHDR_DATE_ADMIT.Value + "    " + W_CLMHDR_MANUAL_REVIEW.Value + W_MOH_SLI_CODE.Value + W_RESERVED_OCC_HDR1.Value;


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
    private DCharacter W_CLAIM_HEADER_REC_2 = new DCharacter("W_CLAIM_HEADER_REC_2", 79);
    private void W_CLAIM_HEADER_REC_2_GetValue(ref string Value)
    {

        try
        {
            Value = W_CLAIM_2_IDENT.Value + W_PAT_OHIP_NBR.Value + QDesign.Substring(fleU020B.GetStringValue("PAT_SURNAME"), 1, 9) + QDesign.Substring(fleU020B.GetStringValue("PAT_GIVEN_NAME"), 1, 5) + fleU020B.GetStringValue("W_PAT_SEX") + fleU020B.GetStringValue("PAT_PROV_CD");


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
    private DCharacter W_ITEM_REC = new DCharacter("W_ITEM_REC", 79);
    private void W_ITEM_REC_GetValue(ref string Value)
    {

        try
        {
            Value = W_ITEM_IDENT.Value + fleU020B.GetStringValue("CLMDTL_OMA_CD") + W_CLMDTL_OMA_SUFF.Value + "  " + QDesign.ASCII(fleU020B.GetDecimalValue("W_CLMDTL_FEE_OHIP"), 6) + QDesign.ASCII(fleU020B.GetDecimalValue("CLMDTL_NBR_SERV"), 2) + fleU020B.GetStringValue("CLMDTL_SV_DATE") + QDesign.ASCII(fleU020B.GetDecimalValue("CLMDTL_DIAG_CD"), 3) + W_RESERVED_OCC_DTL1.Value;


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
    private DCharacter W_TRAILER_REC = new DCharacter("W_TRAILER_REC", 79);
    private void W_TRAILER_REC_GetValue(ref string Value)
    {

        try
        {
            Value = W_TRAIL_IDENT.Value + QDesign.ASCII(W_H_COUNT.Value, 4) + QDesign.ASCII(W_R_COUNT.Value, 4) + QDesign.ASCII(W_T_COUNT.Value, 5);


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


    private SqlFileObject fleU020_TP;


    private SqlFileObject fleU020_TAPE_H1;


    private SqlFileObject fleU020_TAPE_H2;


    private SqlFileObject fleU020_TAPE_I;


    private SqlFileObject fleU020_TAPE_T;


    #endregion


    #region "Standard Generated Procedures(U022B_CREATE_TAPE_3)"


    #region "Automatic Item Initialization(U022B_CREATE_TAPE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U022B_CREATE_TAPE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:53 PM

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
        fleU020B.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS_ALPHA.Transaction = m_trnTRANS_UPDATE;
        fleU020_TP.Transaction = m_trnTRANS_UPDATE;
        fleU020_TAPE_H1.Transaction = m_trnTRANS_UPDATE;
        fleU020_TAPE_H2.Transaction = m_trnTRANS_UPDATE;
        fleU020_TAPE_I.Transaction = m_trnTRANS_UPDATE;
        fleU020_TAPE_T.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U022B_CREATE_TAPE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:53 PM

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
            fleU020B.Dispose();
            fleTMP_COUNTERS_ALPHA.Dispose();
            fleU020_TP.Dispose();
            fleU020_TAPE_H1.Dispose();
            fleU020_TAPE_H2.Dispose();
            fleU020_TAPE_I.Dispose();
            fleU020_TAPE_T.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U022B_CREATE_TAPE_3)"


    public void Run()
    {

        try
        {
            Request("CREATE_TAPE_3");

            while (fleU020B.QTPForMissing())
            {
                // --> GET U020B <--

                fleU020B.GetData();
                // --> End GET U020B <--

                while (fleTMP_COUNTERS_ALPHA.QTPForMissing("1"))
                {
                    // --> GET TMP_COUNTERS_ALPHA <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleTMP_COUNTERS_ALPHA.ElementOwner("TMP_COUNTER_KEY_ALPHA")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU020B.GetStringValue("CLMHDR_CLAIM_ID"), 1, 10)));

                    fleTMP_COUNTERS_ALPHA.GetData(m_strWhere.ToString());
                    // --> End GET TMP_COUNTERS_ALPHA <--


                    if (Transaction())
                    {

                        Sort(fleU020B.GetSortValue("CONTRACT_CODE"), fleU020B.GetSortValue("TRANSLATED_GROUP_NBR"), fleU020B.GetSortValue("BATCTRL_BATCH_NBR"), W_CLMHDR_CLAIM_ID.Value, W_DTL.Value);



                    }

                }

            }

            while (Sort(fleU020B, fleTMP_COUNTERS_ALPHA))
            {
                Count(ref W_BATCH_COUNT);
                Count(ref W_B_COUNT);
                Count(ref W_B_COUNT_R);
                Count(ref W_H_COUNT, fleU020B.At("CONTRACT_CODE") || fleU020B.At("TRANSLATED_GROUP_NBR") || fleU020B.At("BATCTRL_BATCH_NBR") || At(W_CLMHDR_CLAIM_ID));
                if (QDesign.NULL(fleU020B.GetStringValue("W_PAT_OHIP_MMYY")) != QDesign.NULL(" "))
                {
                    Count(ref W_R_COUNT);
                }
                Count(ref W_T_COUNT, fleU020B.At("CONTRACT_CODE") || fleU020B.At("TRANSLATED_GROUP_NBR") || fleU020B.At("BATCTRL_BATCH_NBR") || At(W_CLMHDR_CLAIM_ID) || At(W_DTL));
                if (QDesign.NULL(fleU020B.GetStringValue("W_PAT_OHIP_MMYY")) != QDesign.NULL(" ") & QDesign.NULL(fleU020B.GetStringValue("PAT_PROV_CD")) == "ON")
                {
                    Count(ref W_A_COUNT);
                }
                Count(ref W_COUNT);



                SubFile(ref m_trnTRANS_UPDATE, ref fleU020_TP, QDesign.NULL(W_B_COUNT.Value) == 1, SubFileType.Keep, W_BATCH_HEADER_REC);




                SubFile(ref m_trnTRANS_UPDATE, ref fleU020_TAPE_H1, QDesign.NULL(W_COUNT.Value) == 1, SubFileType.Keep, W_CLAIM_HEADER_REC_1);




                SubFile(ref m_trnTRANS_UPDATE, ref fleU020_TAPE_H2, QDesign.NULL(W_COUNT.Value) == 1 & QDesign.NULL(fleU020B.GetStringValue("W_PAT_OHIP_MMYY")) != QDesign.NULL(" "), SubFileType.Keep, W_CLAIM_HEADER_REC_2);




                SubFile(ref m_trnTRANS_UPDATE, ref fleU020_TAPE_I, fleU020B.At("CONTRACT_CODE") || fleU020B.At("TRANSLATED_GROUP_NBR") || fleU020B.At("BATCTRL_BATCH_NBR") || At(W_CLMHDR_CLAIM_ID) || At(W_DTL), SubFileType.Keep, W_ITEM_REC);




                SubFile(ref m_trnTRANS_UPDATE, ref fleU020_TAPE_T, fleU020B.At("CONTRACT_CODE") || fleU020B.At("TRANSLATED_GROUP_NBR") || fleU020B.At("BATCTRL_BATCH_NBR"), SubFileType.Keep, W_TRAILER_REC);



                Reset(ref W_B_COUNT, fleU020B.At("CONTRACT_CODE") || fleU020B.At("TRANSLATED_GROUP_NBR") || fleU020B.At("BATCTRL_BATCH_NBR"));
                Reset(ref W_B_COUNT_R, fleU020B.At("CONTRACT_CODE") || fleU020B.At("TRANSLATED_GROUP_NBR") || fleU020B.At("BATCTRL_BATCH_NBR"));
                Reset(ref W_H_COUNT, fleU020B.At("CONTRACT_CODE") || fleU020B.At("TRANSLATED_GROUP_NBR") || fleU020B.At("BATCTRL_BATCH_NBR") || At(W_CLMHDR_CLAIM_ID));
                Reset(ref W_R_COUNT, fleU020B.At("CONTRACT_CODE") || fleU020B.At("TRANSLATED_GROUP_NBR") || fleU020B.At("BATCTRL_BATCH_NBR") || At(W_CLMHDR_CLAIM_ID));
                Reset(ref W_T_COUNT, fleU020B.At("CONTRACT_CODE") || fleU020B.At("TRANSLATED_GROUP_NBR") || fleU020B.At("BATCTRL_BATCH_NBR") || At(W_CLMHDR_CLAIM_ID) || At(W_DTL));
                Reset(ref W_A_COUNT, fleU020B.At("CONTRACT_CODE") || fleU020B.At("TRANSLATED_GROUP_NBR") || fleU020B.At("BATCTRL_BATCH_NBR") || At(W_CLMHDR_CLAIM_ID));
                Reset(ref W_COUNT, fleU020B.At("CONTRACT_CODE") || fleU020B.At("TRANSLATED_GROUP_NBR") || fleU020B.At("BATCTRL_BATCH_NBR") || At(W_CLMHDR_CLAIM_ID));

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
            EndRequest("CREATE_TAPE_3");

        }

    }




    #endregion


}
//CREATE_TAPE_3




