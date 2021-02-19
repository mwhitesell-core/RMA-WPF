
#region "Screen Comments"

// doc: patients.qts
// PROGRAM PURPOSE : extract patient information for a doctor to be uploaded into 
// web
// DATE       BY WHOM   DESCRIPTION
// 2011/03    YASEMIN   patients.qzs  too long for .txt file


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Billing_WEBPATIENTS_DOC : BaseClassControl
{

    private Billing_WEBPATIENTS_DOC m_Billing_WEBPATIENTS_DOC;

    public Billing_WEBPATIENTS_DOC(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public Billing_WEBPATIENTS_DOC(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_Billing_WEBPATIENTS_DOC != null))
        {
            m_Billing_WEBPATIENTS_DOC.CloseTransactionObjects();
            m_Billing_WEBPATIENTS_DOC = null;
        }
    }

    public Billing_WEBPATIENTS_DOC GetBilling_WEBPATIENTS_DOC(int Level)
    {
        if (m_Billing_WEBPATIENTS_DOC == null)
        {
            m_Billing_WEBPATIENTS_DOC = new Billing_WEBPATIENTS_DOC("Billing_WEBPATIENTS_DOC", Level);
        }
        else
        {
            m_Billing_WEBPATIENTS_DOC.ResetValues();
        }
        return m_Billing_WEBPATIENTS_DOC;
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

            Billing_WEBPATIENTS_DOC_ONE_1 ONE_1 = new Billing_WEBPATIENTS_DOC_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

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



public class Billing_WEBPATIENTS_DOC_ONE_1 : Billing_WEBPATIENTS_DOC
{

    public Billing_WEBPATIENTS_DOC_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePATIENTS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PATIENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;
        X_PROVINCE.GetValue += X_PROVINCE_GetValue;
        X_ADDRESS.GetValue += X_ADDRESS_GetValue;
        X_CHART_M.GetValue += X_CHART_M_GetValue;
        X_CHART_K.GetValue += X_CHART_K_GetValue;
        X_CHART_H.GetValue += X_CHART_H_GetValue;
        X_CHART_G.GetValue += X_CHART_G_GetValue;
        X_CHART_J.GetValue += X_CHART_J_GetValue;
        X_RMB_NBR.GetValue += X_RMB_NBR_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_WEBPATIENTS_DOC_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleF010_PAT_MSTR;

    private void fleF002_CLAIMS_MSTR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("B"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField("22E89@"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("00000"));


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

    private DCharacter X_PROVINCE = new DCharacter("X_PROVINCE", 21);
    private void X_PROVINCE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "ON")
            {
                CurrentValue = "Ontario";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "AB")
            {
                CurrentValue = "Alberta";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "BC")
            {
                CurrentValue = "British Columbia";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "MB")
            {
                CurrentValue = "Manitoba";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "NF")
            {
                CurrentValue = "Newfoundland";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "NB")
            {
                CurrentValue = "New Brunswick";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "NT")
            {
                CurrentValue = "Northwest Territories";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "NS")
            {
                CurrentValue = "Nova Scotia";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "PE")
            {
                CurrentValue = "Prince Edward Island";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "SK")
            {
                CurrentValue = "Saskatchewan";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "YT")
            {
                CurrentValue = "Yukon";
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "PQ")
            {
                CurrentValue = "Quebec";
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
    private DCharacter X_ADDRESS = new DCharacter("X_ADDRESS", 42);
    private void X_ADDRESS_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Pack(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR1") + " " + fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR2"));


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
    private DCharacter X_CHART_M = new DCharacter("X_CHART_M", 10);
    private void X_CHART_M_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR"), 1, 1)) == "M")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR");
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
    private DCharacter X_CHART_K = new DCharacter("X_CHART_K", 10);
    private void X_CHART_K_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_2"), 1, 1)) == "K")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_2");
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
    private DCharacter X_CHART_H = new DCharacter("X_CHART_H", 10);
    private void X_CHART_H_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_3"), 1, 1)) == "H")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_3");
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
    private DCharacter X_CHART_G = new DCharacter("X_CHART_G", 10);
    private void X_CHART_G_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_4")) != QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 6, 10)))
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_4");
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
    private DCharacter X_CHART_J = new DCharacter("X_CHART_J", 11);
    private void X_CHART_J_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_5"), 1, 1)) == "J")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_5");
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
    private DCharacter X_RMB_NBR = new DCharacter("X_RMB_NBR", 16);
    private void X_RMB_NBR_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR")) == 0)
            {
                CurrentValue = QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_OHIP_NBR"), 8) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_MM"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_YY"), 2) + fleF010_PAT_MSTR.GetStringValue("FILLER1");
                //Parent:PAT_OHIP_MMYY
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
    private DCharacter COMMA = new DCharacter("COMMA", 1);
    private void COMMA_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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
    private DInteger X_NUM_CR = new DInteger("X_NUM_CR", 4);
    private void X_NUM_CR_GetValue(ref decimal Value)
    {

        try
        {
            Value = 13;


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
    private DCharacter X_CR = new DCharacter("X_CR", 2);
    private void X_CR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_CR.Value);


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







    private SqlFileObject flePATIENTS;


    #endregion


    #region "Standard Generated Procedures(Billing_WEBPATIENTS_DOC_ONE_1)"


    #region "Automatic Item Initialization(Billing_WEBPATIENTS_DOC_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_WEBPATIENTS_DOC_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:11 PM

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
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePATIENTS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_WEBPATIENTS_DOC_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:11 PM

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
            fleF002_CLAIMS_MSTR.Dispose();
            fleF010_PAT_MSTR.Dispose();
            flePATIENTS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_WEBPATIENTS_DOC_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--

                fleF002_CLAIMS_MSTR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                    //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                    //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
                    //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));
                    //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F010_PAT_MSTR <--


                    if (Transaction())
                    {

                        Sort(fleF010_PAT_MSTR.GetSortValue("PAT_HEALTH_NBR"));



                    }

                }

            }


            while (Sort(fleF002_CLAIMS_MSTR, fleF010_PAT_MSTR))
            {

                SubFile(ref m_trnTRANS_UPDATE, ref flePATIENTS, fleF010_PAT_MSTR.At("PAT_HEALTH_NBR"), SubFileType.Keep, fleF010_PAT_MSTR, "PAT_SURNAME", COMMA, "PAT_GIVEN_NAME", "PAT_HEALTH_NBR", "PAT_VERSION_CD",
                "PAT_PROV_CD", X_RMB_NBR, X_CHART_M, X_CHART_K, X_CHART_H, X_CHART_G, X_CHART_J, "PAT_BIRTH_DATE", "PAT_PHONE_NBR", "PAT_SEX",
                X_ADDRESS, "SUBSCR_ADDR3", "PAT_COUNTRY", "SUBSCR_POSTAL_CD", X_CR);



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
            EndRequest("ONE_1");

        }

    }




    #endregion


}
//ONE_1




