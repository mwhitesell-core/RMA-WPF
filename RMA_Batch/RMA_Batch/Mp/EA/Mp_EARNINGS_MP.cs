
#region "Screen Comments"

// doc     : earnings_revenue_mp.qts
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
// 2009/06/14     Yas             add RETCLI SERREC EDUCON
// 2009/02/02     Yas             add LABMED                  
// 2009/10/05     Yas             add PREBON SPEPRE
// 2009/10/21     Yas             add SHADOW
// 2010/01/14     Yas             add ABCSTA
// 2010/05/03     Yas             add AFTHOU
// 2010/08/16     Yas             add HAHSO 
// 2011/01/10     Yas             add DIABET, HGHCON, GUARAN
// 2011/02/08     Yas  run it for all company one departments as per Mary Brownridge
// 2011/06/15     Yas  add WSIB UCAF                                                    
// 2011/11/15     Yas  add PDA MRP 
// 2012/01/02     Yas  add NEWPAT NEPHRO COVARL 
// 2012/04/24     Yas  add consul eftpay pedcal 
// 2012/06/04     Yas  add plasti and ortho    
// 2013/12/19 Yas  add BASE and OUTPRO
// 2014/04/16 Yas  add BRIDGE and TOPOFF
// 2014/04/12 Yas  add AGEP EARN MALPRA MICA MISC0 MOHD BLEPRE TRAVEL
// 2015/01/22 Yas  take out payeft as per Helena                         
// 2016/01/04 Yas  As per Helena add MICA and re-run - informed her that MICA is a 101c code and should not be
// used in MP


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Mp_EARNINGS_MP : BaseClassControl
{

    private Mp_EARNINGS_MP m_Mp_EARNINGS_MP;

    public Mp_EARNINGS_MP(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public Mp_EARNINGS_MP(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_Mp_EARNINGS_MP != null))
        {
            m_Mp_EARNINGS_MP.CloseTransactionObjects();
            m_Mp_EARNINGS_MP = null;
        }
    }

    public Mp_EARNINGS_MP GetMp_EARNINGS_MP(int Level)
    {
        if (m_Mp_EARNINGS_MP == null)
        {
            m_Mp_EARNINGS_MP = new Mp_EARNINGS_MP("Mp_EARNINGS_MP", Level);
        }
        else
        {
            m_Mp_EARNINGS_MP.ResetValues();
        }
        return m_Mp_EARNINGS_MP;
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

            Mp_EARNINGS_MP_ONE_1 ONE_1 = new Mp_EARNINGS_MP_ONE_1(Name, Level);
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



public class Mp_EARNINGS_MP_ONE_1 : Mp_EARNINGS_MP
{

    public Mp_EARNINGS_MP_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_PENPAY = new CoreDecimal("X_PENPAY", 10, this);
        X_PCR = new CoreDecimal("X_PCR", 10, this);
        X_OUTCLI = new CoreDecimal("X_OUTCLI", 10, this);
        X_SURPLU = new CoreDecimal("X_SURPLU", 10, this);
        X_CME = new CoreDecimal("X_CME", 10, this);
        X_REBATE = new CoreDecimal("X_REBATE", 10, this);
        X_AFPCON = new CoreDecimal("X_AFPCON", 10, this);
        X_GSTREB = new CoreDecimal("X_GSTREB", 10, this);
        X_REFUND = new CoreDecimal("X_REFUND", 10, this);
        X_ONCALL = new CoreDecimal("X_ONCALL", 10, this);
        X_AFP = new CoreDecimal("X_AFP", 10, this);
        X_DIRECT = new CoreDecimal("X_DIRECT", 10, this);
        X_PGPCP = new CoreDecimal("X_PGPCP", 10, this);
        X_EARADV = new CoreDecimal("X_EARADV", 10, this);
        X_COVERA = new CoreDecimal("X_COVERA", 10, this);
        X_FAMAFP = new CoreDecimal("X_FAMAFP", 10, this);
        X_PSYPAY = new CoreDecimal("X_PSYPAY", 10, this);
        X_OMARET = new CoreDecimal("X_OMARET", 10, this);
        X_RETRO = new CoreDecimal("X_RETRO", 10, this);
        X_SAMMP = new CoreDecimal("X_SAMMP", 10, this);
        X_SABBIT = new CoreDecimal("X_SABBIT", 10, this);
        X_OFN = new CoreDecimal("X_OFN", 10, this);
        X_SURONC = new CoreDecimal("X_SURONC", 10, this);
        X_AFPFUN = new CoreDecimal("X_AFPFUN", 10, this);
        X_TRANSP = new CoreDecimal("X_TRANSP", 10, this);
        X_AFPRET = new CoreDecimal("X_AFPRET", 10, this);
        X_MOHRET = new CoreDecimal("X_MOHRET", 10, this);
        X_PCN = new CoreDecimal("X_PCN", 10, this);
        X_UNINSU = new CoreDecimal("X_UNINSU", 10, this);
        X_SPEPAY = new CoreDecimal("X_SPEPAY", 10, this);
        X_ACAINC = new CoreDecimal("X_ACAINC", 10, this);
        X_COMPCA = new CoreDecimal("X_COMPCA", 10, this);
        X_STIPEN = new CoreDecimal("X_STIPEN", 10, this);
        X_COVCHU = new CoreDecimal("X_COVCHU", 10, this);
        X_PSYCAP = new CoreDecimal("X_PSYCAP", 10, this);
        X_PACE = new CoreDecimal("X_PACE", 10, this);
        X_LEACON = new CoreDecimal("X_LEACON", 10, this);
        X_AHSC = new CoreDecimal("X_AHSC", 10, this);
        X_WEEKEN = new CoreDecimal("X_WEEKEN", 10, this);
        X_ADVANC = new CoreDecimal("X_ADVANC", 10, this);
        X_DEPT = new CoreDecimal("X_DEPT", 10, this);
        X_EQUPAY = new CoreDecimal("X_EQUPAY", 10, this);
        X_MAROVE = new CoreDecimal("X_MAROVE", 10, this);
        X_HOCC = new CoreDecimal("X_HOCC", 10, this);
        X_FLOTHR = new CoreDecimal("X_FLOTHR", 10, this);
        X_CLIREP = new CoreDecimal("X_CLIREP", 10, this);
        X_RECRUI = new CoreDecimal("X_RECRUI", 10, this);
        X_RESSUP = new CoreDecimal("X_RESSUP", 10, this);
        X_AFPBON = new CoreDecimal("X_AFPBON", 10, this);
        X_LABPAY = new CoreDecimal("X_LABPAY", 10, this);
        X_NEUSRF = new CoreDecimal("X_NEUSRF", 10, this);
        X_RETCLI = new CoreDecimal("X_RETCLI", 10, this);
        X_SERREC = new CoreDecimal("X_SERREC", 10, this);
        X_EDUCON = new CoreDecimal("X_EDUCON", 10, this);
        X_LABMED = new CoreDecimal("X_LABMED", 10, this);
        X_PREBON = new CoreDecimal("X_PREBON", 10, this);
        X_SPEPRE = new CoreDecimal("X_SPEPRE", 10, this);
        X_SHADOW = new CoreDecimal("X_SHADOW", 10, this);
        X_ABCSTA = new CoreDecimal("X_ABCSTA", 10, this);
        X_AFTHOU = new CoreDecimal("X_AFTHOU", 10, this);
        X_HAHSO = new CoreDecimal("X_HAHSO", 10, this);
        X_DIABET = new CoreDecimal("X_DIABET", 10, this);
        X_HGHCON = new CoreDecimal("X_HGHCON", 10, this);
        X_GUARAN = new CoreDecimal("X_GUARAN", 10, this);
        X_WSIB = new CoreDecimal("X_WSIB", 10, this);
        X_UCAF = new CoreDecimal("X_UCAF", 10, this);
        X_PDA = new CoreDecimal("X_PDA", 10, this);
        X_MRP = new CoreDecimal("X_MRP", 10, this);
        X_NEWPAT = new CoreDecimal("X_NEWPAT", 10, this);
        X_NEPHRO = new CoreDecimal("X_NEPHRO", 10, this);
        X_COVARL = new CoreDecimal("X_COVARL", 10, this);
        X_PEDCAL = new CoreDecimal("X_PEDCAL", 10, this);
        X_CONSUL = new CoreDecimal("X_CONSUL", 10, this);
        X_EFTPAY = new CoreDecimal("X_EFTPAY", 10, this);
        X_PLASTI = new CoreDecimal("X_PLASTI", 10, this);
        X_ORTHO = new CoreDecimal("X_ORTHO", 10, this);
        X_BASE = new CoreDecimal("X_BASE", 10, this);
        X_OUTPRO = new CoreDecimal("X_OUTPRO", 10, this);
        X_TOPOFF = new CoreDecimal("X_TOPOFF", 10, this);
        X_BRIDGE = new CoreDecimal("X_BRIDGE", 10, this);
        X_AGEP = new CoreDecimal("X_AGEP", 10, this);
        X_EARN = new CoreDecimal("X_EARN", 10, this);
        X_MALPRA = new CoreDecimal("X_MALPRA", 10, this);
        X_MICA = new CoreDecimal("X_MICA", 10, this);
        X_MISC0 = new CoreDecimal("X_MISC0", 10, this);
        X_MOHD = new CoreDecimal("X_MOHD", 10, this);
        X_BLEPRE = new CoreDecimal("X_BLEPRE", 10, this);
        X_TRAVEL = new CoreDecimal("X_TRAVEL", 10, this);
        fleEARNINGSMP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EARNINGSMP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NAME.GetValue += X_NAME_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_EARNINGS_MP_ONE_1)"

    private SqlFileObject fleF119_DOCTOR_YTD;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if ((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT") >= 1 & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) < 11) | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 16 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 17 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 18 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 23 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 33 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 51 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 70 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 71 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 72 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 73 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 74 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 75)
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
            //Parent:DOC_INITS


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
    private CoreDecimal X_RECRUI;
    private CoreDecimal X_RESSUP;
    private CoreDecimal X_AFPBON;
    private CoreDecimal X_LABPAY;
    private CoreDecimal X_NEUSRF;
    private CoreDecimal X_RETCLI;
    private CoreDecimal X_SERREC;
    private CoreDecimal X_EDUCON;
    private CoreDecimal X_LABMED;
    private CoreDecimal X_PREBON;
    private CoreDecimal X_SPEPRE;
    private CoreDecimal X_SHADOW;
    private CoreDecimal X_ABCSTA;
    private CoreDecimal X_AFTHOU;
    private CoreDecimal X_HAHSO;
    private CoreDecimal X_DIABET;
    private CoreDecimal X_HGHCON;
    private CoreDecimal X_GUARAN;
    private CoreDecimal X_WSIB;
    private CoreDecimal X_UCAF;
    private CoreDecimal X_PDA;
    private CoreDecimal X_MRP;
    private CoreDecimal X_NEWPAT;
    private CoreDecimal X_NEPHRO;
    private CoreDecimal X_COVARL;
    private CoreDecimal X_PEDCAL;
    private CoreDecimal X_CONSUL;
    private CoreDecimal X_EFTPAY;
    private CoreDecimal X_PLASTI;
    private CoreDecimal X_ORTHO;
    private CoreDecimal X_BASE;
    private CoreDecimal X_OUTPRO;
    private CoreDecimal X_TOPOFF;
    private CoreDecimal X_BRIDGE;
    private CoreDecimal X_AGEP;
    private CoreDecimal X_EARN;
    private CoreDecimal X_MALPRA;
    private CoreDecimal X_MICA;
    private CoreDecimal X_MISC0;
    private CoreDecimal X_MOHD;
    private CoreDecimal X_BLEPRE;
    private CoreDecimal X_TRAVEL;

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

    private SqlFileObject fleEARNINGSMP;


    #endregion


    #region "Standard Generated Procedures(Mp_EARNINGS_MP_ONE_1)"


    #region "Automatic Item Initialization(Mp_EARNINGS_MP_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:39:29 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:39:28 PM
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


    #region "Transaction Management Procedures(Mp_EARNINGS_MP_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:39:28 PM

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
        fleEARNINGSMP.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Mp_EARNINGS_MP_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:39:28 PM

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
            fleEARNINGSMP.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_EARNINGS_MP_ONE_1)"


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
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "RECRUI")
                {
                    X_RECRUI.Value = X_RECRUI.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "RESSUP")
                {
                    X_RESSUP.Value = X_RESSUP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "AFPBON")
                {
                    X_AFPBON.Value = X_AFPBON.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "LABPAY")
                {
                    X_LABPAY.Value = X_LABPAY.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "NEUSRF")
                {
                    X_NEUSRF.Value = X_NEUSRF.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "RETCLI")
                {
                    X_RETCLI.Value = X_RETCLI.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "SERREC")
                {
                    X_SERREC.Value = X_SERREC.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "EDUCON")
                {
                    X_EDUCON.Value = X_EDUCON.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "LABMED")
                {
                    X_LABMED.Value = X_LABMED.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PREBON")
                {
                    X_PREBON.Value = X_PREBON.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "SPEPRE")
                {
                    X_SPEPRE.Value = X_SPEPRE.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "SHADOW")
                {
                    X_SHADOW.Value = X_SHADOW.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "ABCSTA")
                {
                    X_ABCSTA.Value = X_ABCSTA.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "AFTHOU")
                {
                    X_AFTHOU.Value = X_AFTHOU.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "HAHSO")
                {
                    X_HAHSO.Value = X_HAHSO.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "DIABET")
                {
                    X_DIABET.Value = X_DIABET.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "HGHCON")
                {
                    X_HGHCON.Value = X_HGHCON.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "GUARAN")
                {
                    X_GUARAN.Value = X_GUARAN.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "WSIB")
                {
                    X_WSIB.Value = X_WSIB.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "UCAF")
                {
                    X_UCAF.Value = X_UCAF.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PDA")
                {
                    X_PDA.Value = X_PDA.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "MRP")
                {
                    X_MRP.Value = X_MRP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "NEWPAT")
                {
                    X_NEWPAT.Value = X_NEWPAT.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "NEPHRO")
                {
                    X_NEPHRO.Value = X_NEPHRO.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "COVARL")
                {
                    X_COVARL.Value = X_COVARL.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PEDCAL")
                {
                    X_PEDCAL.Value = X_PEDCAL.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "CONSUL")
                {
                    X_CONSUL.Value = X_CONSUL.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "EFTPAY")
                {
                    X_EFTPAY.Value = X_EFTPAY.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PLASTI")
                {
                    X_PLASTI.Value = X_PLASTI.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "ORTHO")
                {
                    X_ORTHO.Value = X_ORTHO.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "BASE")
                {
                    X_BASE.Value = X_BASE.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "OUTPRO")
                {
                    X_OUTPRO.Value = X_OUTPRO.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TOPOFF")
                {
                    X_TOPOFF.Value = X_TOPOFF.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "BRIDGE")
                {
                    X_BRIDGE.Value = X_BRIDGE.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "AGEP")
                {
                    X_AGEP.Value = X_AGEP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "EARN")
                {
                    X_EARN.Value = X_EARN.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "MALPRA")
                {
                    X_MALPRA.Value = X_MALPRA.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "MICA")
                {
                    X_MICA.Value = X_MICA.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "MISC0")
                {
                    X_MISC0.Value = X_MISC0.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "MOHD")
                {
                    X_MOHD.Value = X_MOHD.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "BLEPRE")
                {
                    X_BLEPRE.Value = X_BLEPRE.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TRAVEL")
                {
                    X_TRAVEL.Value = X_TRAVEL.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }


                SubFile(ref m_trnTRANS_UPDATE, ref fleEARNINGSMP, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"), SubFileType.Portable, fleF020_DOCTOR_MSTR, "DOC_DEPT", COMMA, "DOC_NBR", COMMA, X_NAME, COMMA, X_PENPAY, COMMA,
                X_PCR, COMMA, X_OUTCLI, COMMA, X_SURPLU, COMMA, X_CME, COMMA, X_REBATE, COMMA, X_AFPCON, COMMA, X_GSTREB, COMMA, X_REFUND, COMMA, X_ONCALL, COMMA, X_AFP, COMMA, X_DIRECT, COMMA, X_PGPCP, COMMA, X_EARADV, COMMA, X_COVERA, COMMA, X_FAMAFP, COMMA, 
                X_PSYPAY, COMMA, X_OMARET, COMMA, X_RETRO, COMMA, X_SAMMP, COMMA, X_SABBIT, COMMA, X_OFN, COMMA, X_SURONC, COMMA, X_AFPFUN, COMMA, X_TRANSP, COMMA, X_AFPRET, COMMA, X_MOHRET, COMMA, X_PCN, COMMA, X_UNINSU, COMMA, X_SPEPAY, COMMA, X_ACAINC, COMMA,
                X_COMPCA, COMMA, X_STIPEN, COMMA, X_COVCHU, COMMA, X_PSYCAP, COMMA, X_PACE, COMMA, X_LEACON, COMMA, X_AHSC, COMMA, X_WEEKEN, COMMA, X_ADVANC, COMMA, X_DEPT, COMMA, X_EQUPAY, COMMA, X_MAROVE, COMMA, X_HOCC, COMMA, X_FLOTHR, COMMA, X_CLIREP, COMMA, 
                X_RECRUI, COMMA, X_RESSUP, COMMA, X_AFPBON, COMMA, X_LABPAY, COMMA, X_NEUSRF, COMMA, X_RETCLI, COMMA, X_SERREC, COMMA, X_EDUCON, COMMA, X_LABMED, COMMA, X_PREBON, COMMA, X_SPEPRE, COMMA, X_SHADOW, COMMA, X_ABCSTA, COMMA, X_AFTHOU, COMMA, 
                X_HAHSO, COMMA, X_DIABET, COMMA, X_HGHCON, COMMA, X_GUARAN, COMMA, X_WSIB, COMMA, X_UCAF, COMMA, X_PDA, COMMA, X_MRP, COMMA, X_NEWPAT, COMMA, X_NEPHRO, COMMA, X_COVARL, COMMA, X_PEDCAL, COMMA, X_CONSUL, COMMA, X_EFTPAY, COMMA, X_PLASTI, COMMA, 
                X_ORTHO, COMMA, X_BASE, COMMA, X_OUTPRO, COMMA, X_TOPOFF, COMMA, X_BRIDGE, COMMA, X_MICA, COMMA);
                //Parent:DOC_INITS


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
                Reset(ref X_RECRUI, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_RESSUP, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_AFPBON, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_LABPAY, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_NEUSRF, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_RETCLI, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_SERREC, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_EDUCON, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_LABMED, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_PREBON, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_SPEPRE, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_SHADOW, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_ABCSTA, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_AFTHOU, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_HAHSO, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_DIABET, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_HGHCON, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_GUARAN, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_WSIB, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_UCAF, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_PDA, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_MRP, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_NEWPAT, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_NEPHRO, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_COVARL, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_PEDCAL, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_CONSUL, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_EFTPAY, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_PLASTI, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_ORTHO, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_BASE, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_OUTPRO, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_TOPOFF, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_BRIDGE, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_AGEP, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_EARN, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_MALPRA, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_MICA, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_MISC0, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_MOHD, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_BLEPRE, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_TRAVEL, fleF020_DOCTOR_MSTR.At("DOC_DEPT") || fleF119_DOCTOR_YTD.At("DOC_NBR"));

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




