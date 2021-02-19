
#region "Screen Comments"

// doc     : earnings_revenue_solo.qts
// purpose : create a excel file for all docs certain comp-code = s YTD amount 
// sort by department by doc-name  
// who     : For Leena to be sent to the department mangaers      
// *************************************************************
// Date  Who  Description
// 2006/03/16 Yasemin         original
// 2007/03/27     Yas         Delete MANSUR AND MANAFP 
// ***** Add UNINSU and SPEPAY at the same spot as above
// excel file replace the column heading with the 
// explanation for UNINSU and SPEPAY
// 2007/06/04     Yas             add PACE
// 2008/03/17     Yas             add HOCC FLOTHR
// 2008/06/17     Yas             add CLIREP            


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Billing_SOLO_EARNINGS : BaseClassControl
{

    private Billing_SOLO_EARNINGS m_Billing_SOLO_EARNINGS;

    public Billing_SOLO_EARNINGS(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public Billing_SOLO_EARNINGS(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_Billing_SOLO_EARNINGS != null))
        {
            m_Billing_SOLO_EARNINGS.CloseTransactionObjects();
            m_Billing_SOLO_EARNINGS = null;
        }
    }

    public Billing_SOLO_EARNINGS GetBilling_SOLO_EARNINGS(int Level)
    {
        if (m_Billing_SOLO_EARNINGS == null)
        {
            m_Billing_SOLO_EARNINGS = new Billing_SOLO_EARNINGS("Billing_SOLO_EARNINGS", Level);
        }
        else
        {
            m_Billing_SOLO_EARNINGS.ResetValues();
        }
        return m_Billing_SOLO_EARNINGS;
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

            Billing_SOLO_EARNINGS_ONE_1 ONE_1 = new Billing_SOLO_EARNINGS_ONE_1(Name, Level);
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



public class Billing_SOLO_EARNINGS_ONE_1 : Billing_SOLO_EARNINGS
{

    public Billing_SOLO_EARNINGS_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_PENPAY = new CoreDecimal("X_PENPAY", 7, this);
        X_PCR = new CoreDecimal("X_PCR", 7, this);
        X_OUTCLI = new CoreDecimal("X_OUTCLI", 7, this);
        X_SURPLU = new CoreDecimal("X_SURPLU", 7, this);
        X_CME = new CoreDecimal("X_CME", 7, this);
        X_REBATE = new CoreDecimal("X_REBATE", 7, this);
        X_AFPCON = new CoreDecimal("X_AFPCON", 7, this);
        X_GSTREB = new CoreDecimal("X_GSTREB", 7, this);
        X_REFUND = new CoreDecimal("X_REFUND", 7, this);
        X_ONCALL = new CoreDecimal("X_ONCALL", 7, this);
        X_AFP = new CoreDecimal("X_AFP", 7, this);
        X_DIRECT = new CoreDecimal("X_DIRECT", 7, this);
        X_PGPCP = new CoreDecimal("X_PGPCP", 7, this);
        X_EARADV = new CoreDecimal("X_EARADV", 7, this);
        X_COVERA = new CoreDecimal("X_COVERA", 7, this);
        X_FAMAFP = new CoreDecimal("X_FAMAFP", 7, this);
        X_PSYPAY = new CoreDecimal("X_PSYPAY", 7, this);
        X_OMARET = new CoreDecimal("X_OMARET", 7, this);
        X_RETRO = new CoreDecimal("X_RETRO", 7, this);
        X_SAMMP = new CoreDecimal("X_SAMMP", 7, this);
        X_SABBIT = new CoreDecimal("X_SABBIT", 7, this);
        X_OFN = new CoreDecimal("X_OFN", 7, this);
        X_SURONC = new CoreDecimal("X_SURONC", 7, this);
        X_AFPFUN = new CoreDecimal("X_AFPFUN", 7, this);
        X_TRANSP = new CoreDecimal("X_TRANSP", 7, this);
        X_AFPRET = new CoreDecimal("X_AFPRET", 7, this);
        X_MOHRET = new CoreDecimal("X_MOHRET", 7, this);
        X_PCN = new CoreDecimal("X_PCN", 7, this);
        X_UNINSU = new CoreDecimal("X_UNINSU", 7, this);
        X_SPEPAY = new CoreDecimal("X_SPEPAY", 7, this);
        X_ACAINC = new CoreDecimal("X_ACAINC", 7, this);
        X_COMPCA = new CoreDecimal("X_COMPCA", 7, this);
        X_STIPEN = new CoreDecimal("X_STIPEN", 7, this);
        X_COVCHU = new CoreDecimal("X_COVCHU", 7, this);
        X_PSYCAP = new CoreDecimal("X_PSYCAP", 7, this);
        X_PACE = new CoreDecimal("X_PACE", 7, this);
        X_LEACON = new CoreDecimal("X_LEACON", 7, this);
        X_AHSC = new CoreDecimal("X_AHSC", 7, this);
        X_WEEKEN = new CoreDecimal("X_WEEKEN", 7, this);
        X_ADVANC = new CoreDecimal("X_ADVANC", 7, this);
        X_DEPT = new CoreDecimal("X_DEPT", 7, this);
        X_EQUPAY = new CoreDecimal("X_EQUPAY", 7, this);
        X_MAROVE = new CoreDecimal("X_MAROVE", 7, this);
        X_HOCC = new CoreDecimal("X_HOCC", 7, this);
        X_FLOTHR = new CoreDecimal("X_FLOTHR", 7, this);
        X_CLIREP = new CoreDecimal("X_CLIREP", 7, this);
        fleEARNINGSSOLO = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EARNINGSSOLO", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NAME.GetValue += X_NAME_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_SOLO_EARNINGS_ONE_1)"

    private SqlFileObject fleF119_DOCTOR_YTD;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if ((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT") >= 1 & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) < 9) | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 73 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 74)
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

    private DCharacter X_NAME = new DCharacter("X_NAME", 30);
    private void X_NAME_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Pack(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME") + ", " + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));



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
    private CoreDecimal X_PENPAY;
    private CoreDecimal X_PCR;
    private CoreDecimal X_OUTCLI;
    private CoreDecimal X_SURPLU;
    private CoreDecimal X_CME;
    private CoreDecimal X_REBATE;
    private CoreDecimal X_AFPCON;
    private CoreDecimal X_GSTREB;
    private CoreDecimal X_REFUND;
    private CoreDecimal X_ONCALL;
    private CoreDecimal X_AFP;
    private CoreDecimal X_DIRECT;
    private CoreDecimal X_PGPCP;
    private CoreDecimal X_EARADV;
    private CoreDecimal X_COVERA;
    private CoreDecimal X_FAMAFP;
    private CoreDecimal X_PSYPAY;
    private CoreDecimal X_OMARET;
    private CoreDecimal X_RETRO;
    private CoreDecimal X_SAMMP;
    private CoreDecimal X_SABBIT;
    private CoreDecimal X_OFN;
    private CoreDecimal X_SURONC;
    private CoreDecimal X_AFPFUN;
    private CoreDecimal X_TRANSP;
    private CoreDecimal X_AFPRET;
    private CoreDecimal X_MOHRET;
    private CoreDecimal X_PCN;
    private CoreDecimal X_UNINSU;
    private CoreDecimal X_SPEPAY;
    private CoreDecimal X_ACAINC;
    private CoreDecimal X_COMPCA;
    private CoreDecimal X_STIPEN;
    private CoreDecimal X_COVCHU;
    private CoreDecimal X_PSYCAP;
    private CoreDecimal X_PACE;
    private CoreDecimal X_LEACON;
    private CoreDecimal X_AHSC;
    private CoreDecimal X_WEEKEN;
    private CoreDecimal X_ADVANC;
    private CoreDecimal X_DEPT;
    private CoreDecimal X_EQUPAY;
    private CoreDecimal X_MAROVE;
    private CoreDecimal X_HOCC;
    private CoreDecimal X_FLOTHR;
    private CoreDecimal X_CLIREP;
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

    private SqlFileObject fleEARNINGSSOLO;


    #endregion


    #region "Standard Generated Procedures(Billing_SOLO_EARNINGS_ONE_1)"


    #region "Automatic Item Initialization(Billing_SOLO_EARNINGS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:19 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:05:18 PM
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



    #endregion


    #region "Transaction Management Procedures(Billing_SOLO_EARNINGS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:18 PM

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
        fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleEARNINGSSOLO.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_SOLO_EARNINGS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:18 PM

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
            fleF119_DOCTOR_YTD.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleEARNINGSSOLO.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_SOLO_EARNINGS_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF119_DOCTOR_YTD.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD <--

                fleF119_DOCTOR_YTD.GetData();
                // --> End GET F119_DOCTOR_YTD <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleF020_DOCTOR_MSTR.GetSortValue("DOC_DEPT"), fleF119_DOCTOR_YTD.GetSortValue("DOC_NBR"));



                        }

                    }

                }

            }

            while (Sort(fleF119_DOCTOR_YTD, fleF020_DOCTOR_MSTR))
            {
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PENPAY")
                {
                    X_PENPAY.Value = X_PENPAY.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PCR")
                {
                    X_PCR.Value = X_PCR.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "OUTCLI")
                {
                    X_OUTCLI.Value = X_OUTCLI.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "SURPLU")
                {
                    X_SURPLU.Value = X_SURPLU.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "CME")
                {
                    X_CME.Value = X_CME.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "REBATE")
                {
                    X_REBATE.Value = X_REBATE.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "AFPCON")
                {
                    X_AFPCON.Value = X_AFPCON.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "GSTREB")
                {
                    X_GSTREB.Value = X_GSTREB.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "REFUND")
                {
                    X_REFUND.Value = X_REFUND.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "ONCALL")
                {
                    X_ONCALL.Value = X_ONCALL.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "AFP")
                {
                    X_AFP.Value = X_AFP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "DIRECT")
                {
                    X_DIRECT.Value = X_DIRECT.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PGPCP")
                {
                    X_PGPCP.Value = X_PGPCP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "EARADV")
                {
                    X_EARADV.Value = X_EARADV.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "COVERA")
                {
                    X_COVERA.Value = X_COVERA.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "FAMAFP")
                {
                    X_FAMAFP.Value = X_FAMAFP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PSYPAY")
                {
                    X_PSYPAY.Value = X_PSYPAY.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "OMARET")
                {
                    X_OMARET.Value = X_OMARET.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "RETRO")
                {
                    X_RETRO.Value = X_RETRO.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "SAMMP")
                {
                    X_SAMMP.Value = X_SAMMP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "SABBIT")
                {
                    X_SABBIT.Value = X_SABBIT.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "OFN")
                {
                    X_OFN.Value = X_OFN.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "SURONC")
                {
                    X_SURONC.Value = X_SURONC.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "AFPFUN")
                {
                    X_AFPFUN.Value = X_AFPFUN.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TRANSP")
                {
                    X_TRANSP.Value = X_TRANSP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "AFPRET")
                {
                    X_AFPRET.Value = X_AFPRET.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "MOHRET")
                {
                    X_MOHRET.Value = X_MOHRET.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PCN")
                {
                    X_PCN.Value = X_PCN.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "UNINSU")
                {
                    X_UNINSU.Value = X_UNINSU.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "SPEPAY")
                {
                    X_SPEPAY.Value = X_SPEPAY.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "ACAINC")
                {
                    X_ACAINC.Value = X_ACAINC.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "COMPCA")
                {
                    X_COMPCA.Value = X_COMPCA.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "STIPEN")
                {
                    X_STIPEN.Value = X_STIPEN.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "COVCHU")
                {
                    X_COVCHU.Value = X_COVCHU.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PSYCAP")
                {
                    X_PSYCAP.Value = X_PSYCAP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PACE")
                {
                    X_PACE.Value = X_PACE.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "LEACON")
                {
                    X_LEACON.Value = X_LEACON.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "AHSC")
                {
                    X_AHSC.Value = X_AHSC.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "WEEKEN")
                {
                    X_WEEKEN.Value = X_WEEKEN.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "ADVANC")
                {
                    X_ADVANC.Value = X_ADVANC.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "DEPT")
                {
                    X_DEPT.Value = X_DEPT.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "EQUPAY")
                {
                    X_EQUPAY.Value = X_EQUPAY.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "MAROVE")
                {
                    X_MAROVE.Value = X_MAROVE.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "HOCC")
                {
                    X_HOCC.Value = X_HOCC.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "FLOTHR")
                {
                    X_FLOTHR.Value = X_FLOTHR.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "CLIREP")
                {
                    X_CLIREP.Value = X_CLIREP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }


                SubFile(ref m_trnTRANS_UPDATE, ref fleEARNINGSSOLO, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"), SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_DEPT", COMMA, "DOC_NBR", X_NAME, X_PENPAY,
                X_PCR, X_OUTCLI, X_SURPLU, X_CME, X_REBATE, X_AFPCON, X_GSTREB, X_REFUND, X_ONCALL, X_AFP,
                X_DIRECT, X_PGPCP, X_EARADV, X_COVERA, X_FAMAFP, X_PSYPAY, X_OMARET, X_RETRO, X_SAMMP, X_SABBIT,
                X_OFN, X_SURONC, X_AFPFUN, X_TRANSP, X_AFPRET, X_MOHRET, X_PCN, X_UNINSU, X_SPEPAY, X_ACAINC,
                X_COMPCA, X_STIPEN, X_COVCHU, X_PSYCAP, X_PACE, X_LEACON, X_AHSC, X_WEEKEN, X_ADVANC, X_DEPT,
                X_EQUPAY, X_MAROVE, X_HOCC, X_FLOTHR, X_CLIREP, X_CR);



                Reset(ref X_PENPAY, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_PCR, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_OUTCLI, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_SURPLU, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_CME, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_REBATE, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_AFPCON, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_GSTREB, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_REFUND, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_ONCALL, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_AFP, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_DIRECT, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_PGPCP, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_EARADV, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_COVERA, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_FAMAFP, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_PSYPAY, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_OMARET, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_RETRO, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_SAMMP, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_SABBIT, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_OFN, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_SURONC, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_AFPFUN, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_TRANSP, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_AFPRET, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_MOHRET, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_PCN, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_UNINSU, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_SPEPAY, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_ACAINC, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_COMPCA, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_STIPEN, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_COVCHU, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_PSYCAP, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_PACE, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_LEACON, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_AHSC, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_WEEKEN, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_ADVANC, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_DEPT, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_EQUPAY, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_MAROVE, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_HOCC, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_FLOTHR, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_CLIREP, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));

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




