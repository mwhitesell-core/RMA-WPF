
#region "Screen Comments"

// PROGRAM: utl0021
// PURPOSE: report on descrepances between f020 TOT screen fields and associated f119 mtd/ytd values
// 2015/Apr/02 - link to constants-mstr-rec-6 & f112 to get the doc-pay-code
// f020
// doc-ytdear   YTDEAR ytd f119
// doc-ytdinc   TOTINC ytd f119
// doc-ceicex   CEIEXP mtd f119    
// doc-ytdcex   CEIEXP ytd f119


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0021 : BaseClassControl
{

    private UTL0021 m_UTL0021;

    public UTL0021(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UTL0021(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UTL0021 != null))
        {
            m_UTL0021.CloseTransactionObjects();
            m_UTL0021 = null;
        }
    }

    public UTL0021 GetUTL0021(int Level)
    {
        if (m_UTL0021 == null)
        {
            m_UTL0021 = new UTL0021("UTL0021", Level);
        }
        else
        {
            m_UTL0021.ResetValues();
        }
        return m_UTL0021;
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

            UTL0021_ONE_1 ONE_1 = new UTL0021_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            UTL0021_TWO_2 TWO_2 = new UTL0021_TWO_2(Name, Level);
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



public class UTL0021_ONE_1 : UTL0021
{

    public UTL0021_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_YTDEAR = new CoreDecimal("X_YTDEAR", 9, this);
        X_TOTINC_YTD = new CoreDecimal("X_TOTINC_YTD", 9, this);
        X_TOTINC_MTD = new CoreDecimal("X_TOTINC_MTD", 9, this);
        X_CEIEXP_MTD = new CoreDecimal("X_CEIEXP_MTD", 9, this);
        X_CEIEXP_YTD = new CoreDecimal("X_CEIEXP_YTD", 9, this);
        fleUTL0021 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0021", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD.Choose += fleF119_DOCTOR_YTD_Choose;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF112_PYCDCEILINGS.InitializeItems += fleF112_PYCDCEILINGS_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0021_ONE_1)"

    private SqlFileObject fleF119_DOCTOR_YTD;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF112_PYCDCEILINGS;

    private void fleF119_DOCTOR_YTD_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF119_DOCTOR_YTD.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDEAR"));


            strSQL.Append(" AND ");
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

    private CoreDecimal X_YTDEAR;
    private CoreDecimal X_TOTINC_YTD;
    private CoreDecimal X_TOTINC_MTD;
    private CoreDecimal X_CEIEXP_MTD;
    private CoreDecimal X_CEIEXP_YTD;
    private SqlFileObject fleUTL0021;


    #endregion


    #region "Standard Generated Procedures(UTL0021_ONE_1)"


    #region "Automatic Item Initialization(UTL0021_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:44 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:52:41 PM
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
    //# fleF112_PYCDCEILINGS_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:52:42 PM
    //#-----------------------------------------
    private void fleF112_PYCDCEILINGS_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF112_PYCDCEILINGS.set_SetValue("DOC_NBR", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR"));
            fleF112_PYCDCEILINGS.set_SetValue("LAST_MOD_DATE", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("LAST_MOD_DATE"));
            fleF112_PYCDCEILINGS.set_SetValue("LAST_MOD_TIME", !Fixed, fleF119_DOCTOR_YTD.GetDecimalValue("LAST_MOD_TIME"));
            fleF112_PYCDCEILINGS.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF119_DOCTOR_YTD.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF112_PYCDCEILINGS.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));

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


    #region "Transaction Management Procedures(UTL0021_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:41 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleUTL0021.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0021_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:41 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF112_PYCDCEILINGS.Dispose();
            fleUTL0021.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0021_ONE_1)"


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

                    while (fleCONSTANTS_MSTR_REC_6.QTPForMissing("2"))
                    {
                        // --> GET CONSTANTS_MSTR_REC_6 <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                        m_strWhere.Append((6));

                        fleCONSTANTS_MSTR_REC_6.GetData(m_strWhere.ToString());
                        // --> End GET CONSTANTS_MSTR_REC_6 <--

                        while (fleF112_PYCDCEILINGS.QTPForMissing("3"))
                        {
                            // --> GET F112_PYCDCEILINGS <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" And ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                            m_strWhere.Append(((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1)));

                            fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F112_PYCDCEILINGS <--


                            if (Transaction())
                            {

                                Sort(fleF119_DOCTOR_YTD.GetSortValue("DOC_NBR"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleF119_DOCTOR_YTD, fleF020_DOCTOR_MSTR, fleCONSTANTS_MSTR_REC_6, fleF112_PYCDCEILINGS))
            {
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "YTDEAR")
                {
                    X_YTDEAR.Value = X_YTDEAR.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD");
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TOTINC")
                {
                    X_TOTINC_YTD.Value = X_TOTINC_YTD.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD");
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TOTINC")
                {
                    X_TOTINC_MTD.Value = X_TOTINC_MTD.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "CEIEXP")
                {
                    X_CEIEXP_MTD.Value = X_CEIEXP_MTD.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD");
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "CEIEXP")
                {
                    X_CEIEXP_YTD.Value = X_CEIEXP_YTD.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD");
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0021, fleF119_DOCTOR_YTD.At("DOC_NBR"), SubFileType.Keep, fleF119_DOCTOR_YTD, "DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_DEPT", fleF112_PYCDCEILINGS, "DOC_PAY_CODE",
                fleF020_DOCTOR_MSTR, "DOC_TOTINC_G", X_TOTINC_MTD, X_TOTINC_YTD, "DOC_TOTINC", "DOC_YTDINC", "DOC_YTDINC_G", X_CEIEXP_MTD, X_CEIEXP_YTD, X_YTDEAR,
                "DOC_YTDEAR", "DOC_YTDCEX", "DOC_CEICEX");


                Reset(ref X_YTDEAR, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_TOTINC_YTD, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_TOTINC_MTD, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_CEIEXP_MTD, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_CEIEXP_YTD, fleF119_DOCTOR_YTD.At("DOC_NBR"));

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



public class UTL0021_TWO_2 : UTL0021
{

    public UTL0021_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CEICEA_NET = new CoreDecimal("X_CEICEA_NET", 9, this);
        X_YTDCEA_NET = new CoreDecimal("X_YTDCEA_NET", 9, this);
        fleUTL0021_F110 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0021_F110", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;

        fleF110_COMPENSATION.SelectIf += fleF110_COMPENSATION_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0021_TWO_2)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF110_COMPENSATION;

    private void fleF110_COMPENSATION_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF110_COMPENSATION.ElementOwner("COMP_CODE")).Append(" =  'CEIEAR' OR ");
            strSQL.Append("    ").Append(fleF110_COMPENSATION.ElementOwner("COMP_CODE")).Append(" =  'YTDCEA')");


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

    private SqlFileObject fleF020_DOCTOR_MSTR;

    private void fleCONSTANTS_MSTR_REC_6_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
            strSQL.Append(6);


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

    private CoreDecimal X_CEICEA_NET;
    private CoreDecimal X_YTDCEA_NET;
    private SqlFileObject fleUTL0021_F110;


    #endregion


    #region "Standard Generated Procedures(UTL0021_TWO_2)"


    #region "Automatic Item Initialization(UTL0021_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:46 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:52:44 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));

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


    #region "Transaction Management Procedures(UTL0021_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:41 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleUTL0021_F110.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0021_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:41 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF110_COMPENSATION.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleUTL0021_F110.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0021_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF110_COMPENSATION.QTPForMissing("1"))
                {
                    // --> GET F110_COMPENSATION <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF110_COMPENSATION.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append(((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1)));

                    fleF110_COMPENSATION.GetData(m_strWhere.ToString());
                    // --> End GET F110_COMPENSATION <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_MSTR <--


                        if (Transaction())
                        {

                            Sort(fleF110_COMPENSATION.GetSortValue("DOC_NBR"));



                        }

                    }

                }

            }

            while (Sort(fleCONSTANTS_MSTR_REC_6, fleF110_COMPENSATION, fleF020_DOCTOR_MSTR))
            {
                if (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "CEIEAR")
                {
                    X_CEICEA_NET.Value = X_CEICEA_NET.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                if (QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "YTDCEA")
                {
                    X_YTDCEA_NET.Value = X_YTDCEA_NET.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0021_F110, fleF110_COMPENSATION.At("DOC_NBR"), SubFileType.Keep, fleF110_COMPENSATION, "DOC_NBR", X_CEICEA_NET, X_YTDCEA_NET, fleF020_DOCTOR_MSTR, "DOC_CEICEA",
                "DOC_YTDCEA");


                Reset(ref X_CEICEA_NET, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref X_YTDCEA_NET, fleF110_COMPENSATION.At("DOC_NBR"));

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




