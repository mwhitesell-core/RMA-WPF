
#region "Screen Comments"

// purpose : report ep numbers 200708 to 200806     for surplu and spepay
// purpose : to balance the tax sammaries                                      
// who     : Mary 
// *************************************************************
// Date  Who  Description
// 2008/01/30     Yasemin         original
// 2014/01/14 Yas  Change dates for Jan to Dec 2013 - 201207 to 201212 and 201301 to 201306


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Billing_SOLO_INCOME_SUMMARY : BaseClassControl
{

    private Billing_SOLO_INCOME_SUMMARY m_Billing_SOLO_INCOME_SUMMARY;

    public Billing_SOLO_INCOME_SUMMARY(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public Billing_SOLO_INCOME_SUMMARY(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_Billing_SOLO_INCOME_SUMMARY != null))
        {
            m_Billing_SOLO_INCOME_SUMMARY.CloseTransactionObjects();
            m_Billing_SOLO_INCOME_SUMMARY = null;
        }
    }

    public Billing_SOLO_INCOME_SUMMARY GetBilling_SOLO_INCOME_SUMMARY(int Level)
    {
        if (m_Billing_SOLO_INCOME_SUMMARY == null)
        {
            m_Billing_SOLO_INCOME_SUMMARY = new Billing_SOLO_INCOME_SUMMARY("Billing_SOLO_INCOME_SUMMARY", Level);
        }
        else
        {
            m_Billing_SOLO_INCOME_SUMMARY.ResetValues();
        }
        return m_Billing_SOLO_INCOME_SUMMARY;
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

            Billing_SOLO_INCOME_SUMMARY_ONE_1 ONE_1 = new Billing_SOLO_INCOME_SUMMARY_ONE_1(Name, Level);
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



public class Billing_SOLO_INCOME_SUMMARY_ONE_1 : Billing_SOLO_INCOME_SUMMARY
{

    public Billing_SOLO_INCOME_SUMMARY_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_AFPCON = new CoreDecimal("X_AFPCON", 7, this);
        X_TITHD1 = new CoreDecimal("X_TITHD1", 7, this);
        X_TITHD2 = new CoreDecimal("X_TITHD2", 7, this);
        X_TITHD3 = new CoreDecimal("X_TITHD3", 7, this);
        X_DEPMED = new CoreDecimal("X_DEPMED", 7, this);
        X_PAYEFT = new CoreDecimal("X_PAYEFT", 7, this);
        fleSOLOINCOME = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SOLOINCOME", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_SOLO_INCOME_SUMMARY_ONE_1)"

    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if ((QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "AFPCON" | QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "TITHD1" | QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "TITHD2" | QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "TITHD3" | QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "DEPMED" | QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "PAYEFT") & ((fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("EP_NBR") >= 201507 & fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("EP_NBR") <= 201512) | (fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("EP_NBR") >= 201601 & fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("EP_NBR") <= 201606)) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 31)
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

    private CoreDecimal X_AFPCON;
    private CoreDecimal X_TITHD1;
    private CoreDecimal X_TITHD2;
    private CoreDecimal X_TITHD3;
    private CoreDecimal X_DEPMED;
    private CoreDecimal X_PAYEFT;
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

    private SqlFileObject fleSOLOINCOME;


    #endregion


    #region "Standard Generated Procedures(Billing_SOLO_INCOME_SUMMARY_ONE_1)"


    #region "Automatic Item Initialization(Billing_SOLO_INCOME_SUMMARY_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_SOLO_INCOME_SUMMARY_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:17 PM

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
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleSOLOINCOME.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_SOLO_INCOME_SUMMARY_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:17 PM

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
            fleF020_DOCTOR_MSTR.Dispose();
            fleSOLOINCOME.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_SOLO_INCOME_SUMMARY_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF119_DOCTOR_YTD_HISTORY.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD_HISTORY <--

                fleF119_DOCTOR_YTD_HISTORY.GetData();
                // --> End GET F119_DOCTOR_YTD_HISTORY <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleF119_DOCTOR_YTD_HISTORY.GetSortValue("DOC_NBR"));



                        }

                    }

                }

            }

            while (Sort(fleF119_DOCTOR_YTD_HISTORY, fleF020_DOCTOR_MSTR))
            {
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "AFPCON")
                {
                    X_AFPCON.Value = X_AFPCON.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_MTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "TITHD1")
                {
                    X_TITHD1.Value = X_TITHD1.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_MTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "TITHD2")
                {
                    X_TITHD2.Value = X_TITHD2.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_MTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "TITHD3")
                {
                    X_TITHD3.Value = X_TITHD3.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_MTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "DEPMED")
                {
                    X_DEPMED.Value = X_DEPMED.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_MTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "PAYEFT")
                {
                    X_PAYEFT.Value = X_PAYEFT.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_MTD") / 100;
                }


                SubFile(ref m_trnTRANS_UPDATE, ref fleSOLOINCOME, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"), SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_DEPT", COMMA, fleF119_DOCTOR_YTD_HISTORY, "DOC_NBR", fleF020_DOCTOR_MSTR,
                "DOC_NAME", "DOC_INITS", "DOC_OHIP_NBR", X_AFPCON, X_TITHD1, X_TITHD2, X_TITHD3, X_DEPMED, X_PAYEFT, X_CR);



                Reset(ref X_AFPCON, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref X_TITHD1, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref X_TITHD2, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref X_TITHD3, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref X_DEPMED, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref X_PAYEFT, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));

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




