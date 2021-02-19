
#region "Screen Comments"

// doc     : f119histtithe.qts       
// purpose : create a excel file for doctors that match the selection criteria 
// Dwayne and Lisa report hi97 screen
// *************************************************************
// Date  Who  Description
// 2009/10/05 MC/yas          original
// 2015/07/07     yas             include MOHD


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class F119HISTTITHE : BaseClassControl
{

    private F119HISTTITHE m_F119HISTTITHE;

    public F119HISTTITHE(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public F119HISTTITHE(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_F119HISTTITHE != null))
        {
            m_F119HISTTITHE.CloseTransactionObjects();
            m_F119HISTTITHE = null;
        }
    }

    public F119HISTTITHE GetF119HISTTITHE(int Level)
    {
        if (m_F119HISTTITHE == null)
        {
            m_F119HISTTITHE = new F119HISTTITHE("F119HISTTITHE", Level);
        }
        else
        {
            m_F119HISTTITHE.ResetValues();
        }
        return m_F119HISTTITHE;
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

            F119HISTTITHE_ONE_1 ONE_1 = new F119HISTTITHE_ONE_1(Name, Level);
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



public class F119HISTTITHE_ONE_1 : F119HISTTITHE
{

    public F119HISTTITHE_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        NONRBP = new CoreDecimal("NONRBP", 9, this);
        AFPIN = new CoreDecimal("AFPIN", 9, this);
        AFPOUT = new CoreDecimal("AFPOUT", 9, this);
        AGEP = new CoreDecimal("AGEP", 9, this);
        BILL = new CoreDecimal("BILL", 9, this);
        DHSC = new CoreDecimal("DHSC", 9, this);
        MHSC = new CoreDecimal("MHSC", 9, this);
        MICA = new CoreDecimal("MICA", 9, this);
        MICB = new CoreDecimal("MICB", 9, this);
        MISC0 = new CoreDecimal("MISC0", 9, this);
        MISJ = new CoreDecimal("MISJ", 9, this);
        MISP = new CoreDecimal("MISP", 9, this);
        MOHR = new CoreDecimal("MOHR", 9, this);
        MICG = new CoreDecimal("MICG", 9, this);
        MICJ = new CoreDecimal("MICJ", 9, this);
        MOHD = new CoreDecimal("MOHD", 9, this);
        fleF119HIST_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119HIST_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD_HISTORY.Choose += fleF119_DOCTOR_YTD_HISTORY_Choose;
        COMMA.GetValue += COMMA_GetValue;
        NUM_CR.GetValue += NUM_CR_GetValue;
        CR.GetValue += CR_GetValue;
        DOC_INITS.GetValue += DOC_INITS_GetValue;

    }

    #region "Declarations (Variables, Files and Transactions)(F119HISTTITHE_ONE_1)"

    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;
    private SqlFileObject fleF020_DOCTOR_MSTR;

    private void fleF119_DOCTOR_YTD_HISTORY_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("EP_NBR")).Append(" = ");
            strSQL.Append(Prompt(1));


            strSQL.Append(" AND ");
            strSQL.Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("REC_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("D"));


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


    public override bool SelectIf()
    {


        try
        {
            if ((((QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 4 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 42 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 79) | (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) == "H111" & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 14 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 15)))))
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

    private CoreDecimal NONRBP;
    private CoreDecimal AFPIN;
    private CoreDecimal AFPOUT;
    private CoreDecimal AGEP;
    private CoreDecimal BILL;
    private CoreDecimal DHSC;
    private CoreDecimal MHSC;
    private CoreDecimal MICA;
    private CoreDecimal MICB;
    private CoreDecimal MISC0;
    private CoreDecimal MISJ;
    private CoreDecimal MISP;
    private CoreDecimal MOHR;
    private CoreDecimal MICG;
    private CoreDecimal MICJ;
    private CoreDecimal MOHD;
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
    private DInteger NUM_CR = new DInteger("NUM_CR", 4);
    private void NUM_CR_GetValue(ref decimal Value)
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
    private DCharacter CR = new DCharacter("CR", 2);
    private void CR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(NUM_CR.Value);


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

    private DCharacter DOC_INITS = new DCharacter("DOC_INITS", 3);
    private void DOC_INITS_GetValue(ref string Value)
    {
        try
        {
            Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3");
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

    private SqlFileObject fleF119HIST_DTL;


    #endregion


    #region "Standard Generated Procedures(F119HISTTITHE_ONE_1)"


    #region "Automatic Item Initialization(F119HISTTITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(F119HISTTITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:02 PM

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
        fleF119HIST_DTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(F119HISTTITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:02 PM

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
            fleF119HIST_DTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(F119HISTTITHE_ONE_1)"


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

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
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
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "NONRBP")
                {
                    NONRBP.Value = NONRBP.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "AFPIN")
                {
                    AFPIN.Value = AFPIN.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "AFPOUT")
                {
                    AFPOUT.Value = AFPOUT.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "AGEP")
                {
                    AGEP.Value = AGEP.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "BILL")
                {
                    BILL.Value = BILL.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "DHSC")
                {
                    DHSC.Value = DHSC.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "MHSC")
                {
                    MHSC.Value = MHSC.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "MICA")
                {
                    MICA.Value = MICA.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "MICB")
                {
                    MICB.Value = MICB.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "MISC0")
                {
                    MISC0.Value = MISC0.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "MISJ")
                {
                    MISJ.Value = MISJ.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "MISP")
                {
                    MISP.Value = MISP.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "MOHR")
                {
                    MOHR.Value = MOHR.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "MICG")
                {
                    MICG.Value = MICG.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "MICJ")
                {
                    MICJ.Value = MICJ.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")) == "MOHD")
                {
                    MOHD.Value = MOHD.Value + fleF119_DOCTOR_YTD_HISTORY.GetDecimalValue("AMT_YTD") / 100;
                }


                SubFile(ref m_trnTRANS_UPDATE, ref fleF119HIST_DTL, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"), SubFileType.Portable, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", COMMA, "DOC_AFP_PAYM_GROUP", fleF119_DOCTOR_YTD_HISTORY, "DOC_NBR",
                fleF020_DOCTOR_MSTR, "DOC_DEPT", "DOC_NAME", DOC_INITS, NONRBP, AFPIN, AFPOUT, AGEP, BILL, DHSC,
                MHSC, MICA, MICB, MISC0, MISJ, MISP, MOHR, MICG, MICJ, MOHD,
                CR);
                //Parent:DOC_INITS


                Reset(ref NONRBP, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref AFPIN, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref AFPOUT, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref AGEP, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref BILL, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref DHSC, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref MHSC, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref MICA, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref MICB, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref MISC0, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref MISJ, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref MISP, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref MOHR, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref MICG, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref MICJ, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));
                Reset(ref MOHD, fleF119_DOCTOR_YTD_HISTORY.At("DOC_NBR"));

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




