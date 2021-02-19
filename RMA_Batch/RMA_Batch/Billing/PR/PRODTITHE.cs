
#region "Screen Comments"

// doc     : prodtithe.qts           
// purpose : create a excel file for dept 4 or group H111                      
// sort by doc-name  
// who     : For Dwayne Martins                                    
// *************************************************************
// Date  Who  Description
// 2008/10/07 Yasemin         original
// 2008/10/30 MC  - exclude terminated doctors, only pick the summarized TOTITE from rec-type `D`
// 2008/12/02 MC  - include terminated doctors
// 2009/05/28     MC  - modify the selection criteria in the second request
// 2016/Aug/04   MC1             - add a new column for term date as requested by Yasemin
// 2016/Sep/08     - Yasemin agreed to include new column primary-flag
// 2017/Mar/01  MC2  - replace INCEXP with totded as Yasemin requested


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class PRODTITHE : BaseClassControl
{

    private PRODTITHE m_PRODTITHE;

    public PRODTITHE(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public PRODTITHE(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_PRODTITHE != null))
        {
            m_PRODTITHE.CloseTransactionObjects();
            m_PRODTITHE = null;
        }
    }

    public PRODTITHE GetPRODTITHE(int Level)
    {
        if (m_PRODTITHE == null)
        {
            m_PRODTITHE = new PRODTITHE("PRODTITHE", Level);
        }
        else
        {
            m_PRODTITHE.ResetValues();
        }
        return m_PRODTITHE;
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

            PRODTITHE_ONE_1 ONE_1 = new PRODTITHE_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            PRODTITHE_TWO_2 TWO_2 = new PRODTITHE_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

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



public class PRODTITHE_ONE_1 : PRODTITHE
{

    public PRODTITHE_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        TITHE1 = new CoreDecimal("TITHE1", 9, this);
        TITHE2 = new CoreDecimal("TITHE2", 9, this);
        TITHE3 = new CoreDecimal("TITHE3", 9, this);
        TOTITE = new CoreDecimal("TOTITE", 9, this);
        DEPMEM = new CoreDecimal("DEPMEM", 9, this);
        PAYEFT = new CoreDecimal("PAYEFT", 9, this);
        INCEXP = new CoreDecimal("INCEXP", 9, this);
        flePRODTITHE_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PRODTITHE_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD.Choose += fleF119_DOCTOR_YTD_Choose;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(PRODTITHE_ONE_1)"

    private SqlFileObject fleF119_DOCTOR_YTD;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020_DOCTOR_EXTRA;

    private void fleF119_DOCTOR_YTD_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF119_DOCTOR_YTD.ElementOwner("REC_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("A"));


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

    private CoreDecimal TITHE1;
    private CoreDecimal TITHE2;
    private CoreDecimal TITHE3;
    private CoreDecimal TOTITE;
    private CoreDecimal DEPMEM;
    private CoreDecimal PAYEFT;

    private CoreDecimal INCEXP;

    private SqlFileObject flePRODTITHE_DTL;


    #endregion


    #region "Standard Generated Procedures(PRODTITHE_ONE_1)"


    #region "Automatic Item Initialization(PRODTITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:07 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:04:05 PM
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
    //# fleF020_DOCTOR_EXTRA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:04:06 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_EXTRA_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_NBR", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_EXTRA.set_SetValue("FILLER", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(PRODTITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        flePRODTITHE_DTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(PRODTITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
            fleF020_DOCTOR_EXTRA.Dispose();
            flePRODTITHE_DTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PRODTITHE_ONE_1)"


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

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF020_DOCTOR_EXTRA.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_EXTRA <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_EXTRA <--


                        if (Transaction())
                        {

                            if (Select_If())
                            {

                                Sort(fleF119_DOCTOR_YTD.GetSortValue("DOC_NBR"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleF119_DOCTOR_YTD, fleF020_DOCTOR_MSTR, fleF020_DOCTOR_EXTRA))
            {
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TITHE1")
                {
                    TITHE1.Value = Math.Floor(TITHE1.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100);
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TITHE2")
                {
                    TITHE2.Value = Math.Floor(TITHE2.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100);
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TITHE3")
                {
                    TITHE3.Value = Math.Floor(TITHE3.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100);
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TOTITE")
                {
                    TOTITE.Value = Math.Floor(TOTITE.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100);
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "DEPMEM")
                {
                    DEPMEM.Value = Math.Floor(DEPMEM.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100);
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "PAYEFT")
                {
                    PAYEFT.Value = Math.Floor(PAYEFT.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100);
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "INCEXP")
                {
                    INCEXP.Value = INCEXP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }



                SubFile(ref m_trnTRANS_UPDATE, ref flePRODTITHE_DTL, fleF119_DOCTOR_YTD.At("DOC_NBR"), SubFileType.Keep, fleF119_DOCTOR_YTD, "DOC_OHIP_NBR", fleF020_DOCTOR_MSTR, "DOC_AFP_PAYM_GROUP", "DOC_NBR", "DOC_DEPT",
                "DOC_NAME", "DOC_INIT1", "DOC_INIT2", "DOC_INIT3", fleF020_DOCTOR_EXTRA, "DOC_FLAG_PRIMARY", fleF020_DOCTOR_MSTR, "DOC_DATE_FAC_TERM_YY", "DOC_DATE_FAC_TERM_MM", "DOC_DATE_FAC_TERM_DD", TOTITE, TITHE1, TITHE2, TITHE3,
                DEPMEM, PAYEFT, INCEXP);



                Reset(ref TITHE1, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref TITHE2, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref TITHE3, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref TOTITE, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref DEPMEM, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref PAYEFT, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref INCEXP, fleF119_DOCTOR_YTD.At("DOC_NBR"));

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



public class PRODTITHE_TWO_2 : PRODTITHE
{

    public PRODTITHE_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePRODTITHE_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PRODTITHE_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePRODTITHE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PRODTITHE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePRODTITHE2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PRODTITHE2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        TERM_DATE.GetValue += TERM_DATE_GetValue;
        TOTITE.GetValue += TOTITE_GetValue;
        TOTDED.GetValue += TOTDED_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        NUM_CR.GetValue += NUM_CR_GetValue;
        CR.GetValue += CR_GetValue;
        DOC_DEPT.GetValue += DOC_DEPT_GetValue;
    }


    #region "Declarations (Variables, Files and Transactions)(PRODTITHE_TWO_2)"

    private SqlFileObject flePRODTITHE_DTL;
    private SqlFileObject fleF119_DOCTOR_YTD;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(flePRODTITHE_DTL.GetDecimalValue("DEPMEM")) != 0 | (QDesign.NULL(flePRODTITHE_DTL.GetDecimalValue("TITHE1")) != 0 | QDesign.NULL(flePRODTITHE_DTL.GetDecimalValue("TITHE2")) != 0 | QDesign.NULL(flePRODTITHE_DTL.GetDecimalValue("TITHE3")) != 0))
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

    private DCharacter TERM_DATE = new DCharacter("TERM_DATE", 8);
    private void TERM_DATE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(flePRODTITHE_DTL.GetDecimalValue("DOC_DATE_FAC_TERM_YY")) != 0)
            {
                CurrentValue = flePRODTITHE_DTL.GetStringValue("DOC_DATE_FAC_TERM_YY").PadLeft(4, '0') + flePRODTITHE_DTL.GetStringValue("DOC_DATE_FAC_TERM_MM").PadLeft(2, '0') + flePRODTITHE_DTL.GetStringValue("DOC_DATE_FAC_TERM_DD").PadLeft(2, '0');
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
    private DDecimal TOTITE = new DDecimal("TOTITE", 9);
    private void TOTITE_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = Math.Floor(fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100);


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
    private DDecimal TOTDED = new DDecimal("TOTDED", 9);
    private void TOTDED_GetValue(ref decimal Value)
    {

        try
        {
            Value = Math.Floor(flePRODTITHE_DTL.GetDecimalValue("TITHE1") + flePRODTITHE_DTL.GetDecimalValue("TITHE2") + flePRODTITHE_DTL.GetDecimalValue("TITHE3") + flePRODTITHE_DTL.GetDecimalValue("DEPMEM"));


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


    private DDecimal DOC_DEPT = new DDecimal("DOC_DEPT", 2);
    private void DOC_DEPT_GetValue(ref decimal Value)
    {

        try
        {
            Value = flePRODTITHE_DTL.GetDecimalValue("DOC_DEPT");


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


    private SqlFileObject flePRODTITHE;
    private SqlFileObject flePRODTITHE2;


    #endregion


    #region "Standard Generated Procedures(PRODTITHE_TWO_2)"


    #region "Automatic Item Initialization(PRODTITHE_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(PRODTITHE_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
        flePRODTITHE_DTL.Transaction = m_trnTRANS_UPDATE;
        fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;
        flePRODTITHE.Transaction = m_trnTRANS_UPDATE;
        flePRODTITHE2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(PRODTITHE_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
            flePRODTITHE_DTL.Dispose();
            fleF119_DOCTOR_YTD.Dispose();
            flePRODTITHE.Dispose();
            flePRODTITHE2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PRODTITHE_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (flePRODTITHE_DTL.QTPForMissing())
            {
                // --> GET PRODTITHE_DTL <--

                flePRODTITHE_DTL.GetData();
                // --> End GET PRODTITHE_DTL <--

                while (fleF119_DOCTOR_YTD.QTPForMissing("1"))
                {
                    // --> GET F119_DOCTOR_YTD <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF119_DOCTOR_YTD.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((flePRODTITHE_DTL.GetDecimalValue("DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF119_DOCTOR_YTD.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("000"));
                    m_strWhere.Append(" And ").Append(fleF119_DOCTOR_YTD.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("TOTITE"));
                    m_strWhere.Append(" And ").Append(fleF119_DOCTOR_YTD.ElementOwner("REC_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("D"));

                    fleF119_DOCTOR_YTD.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F119_DOCTOR_YTD <--

                  
                   
                    if (Transaction())
                    {

                       
                         if (Select_If())
                        {


                            SubFile(ref m_trnTRANS_UPDATE, ref flePRODTITHE, SubFileType.Portable, flePRODTITHE_DTL, 
                                "DOC_AFP_PAYM_GROUP", 
                                COMMA, "DOC_NBR",
                                COMMA, DOC_DEPT,
                                COMMA, "DOC_NAME",
                                COMMA, "DOC_INIT1", "DOC_INIT2", "DOC_INIT3",
                                COMMA, TOTITE,
                                COMMA, "TITHE1",
                                COMMA, "TITHE2",
                                COMMA, "TITHE3",
                                COMMA, "DEPMEM",
                                COMMA, TOTDED,
                                COMMA, TERM_DATE,
                                COMMA, "DOC_FLAG_PRIMARY");

                            // Added for debugging. No commas.
                            SubFile(ref m_trnTRANS_UPDATE, ref flePRODTITHE2, SubFileType.Keep, flePRODTITHE_DTL,
                                "DOC_AFP_PAYM_GROUP",
                                "DOC_NBR",
                                DOC_DEPT,
                                "DOC_NAME",
                                "DOC_INIT1", "DOC_INIT2", "DOC_INIT3",
                                TOTITE,
                                "TITHE1",
                                "TITHE2",
                                "TITHE3",
                                "DEPMEM",
                                TOTDED,
                                TERM_DATE,
                                "DOC_FLAG_PRIMARY");
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
            EndRequest("TWO_2");

        }

    }




    #endregion


}
//TWO_2




