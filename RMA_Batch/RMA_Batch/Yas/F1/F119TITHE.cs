
#region "Screen Comments"



#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class F119TITHE : BaseClassControl
{

    private F119TITHE m_F119TITHE;

    public F119TITHE(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public F119TITHE(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_F119TITHE != null))
        {
            m_F119TITHE.CloseTransactionObjects();
            m_F119TITHE = null;
        }
    }

    public F119TITHE GetF119TITHE(int Level)
    {
        if (m_F119TITHE == null)
        {
            m_F119TITHE = new F119TITHE("F119TITHE", Level);
        }
        else
        {
            m_F119TITHE.ResetValues();
        }
        return m_F119TITHE;
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

            F119TITHE_ONE_1 ONE_1 = new F119TITHE_ONE_1(Name, Level);
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



public class F119TITHE_ONE_1 : F119TITHE
{

    public F119TITHE_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_TITHE1 = new CoreDecimal("X_TITHE1", 9, this);
        X_TITHE2 = new CoreDecimal("X_TITHE2", 9, this);
        X_TITHE3 = new CoreDecimal("X_TITHE3", 9, this);
        X_DEPMEM = new CoreDecimal("X_DEPMEM", 9, this);
        X_INCEXP = new CoreDecimal("X_INCEXP", 9, this);
        fleF119TITHE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119TITHE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF119_DOCTOR_YTD.Choose += fleF119_DOCTOR_YTD_Choose;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(F119TITHE_ONE_1)"

    private SqlFileObject fleF119_DOCTOR_YTD;
    private SqlFileObject fleF020_DOCTOR_MSTR;

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
            if ((QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TITHE1" & QDesign.NULL(fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD")) != 0) & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 4 | (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) == "H111" & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 14 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 15)))
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

    private CoreDecimal X_TITHE1;
    private CoreDecimal X_TITHE2;
    private CoreDecimal X_TITHE3;
    private CoreDecimal X_DEPMEM;
    private CoreDecimal X_INCEXP;
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

    private SqlFileObject fleF119TITHE;


    #endregion


    #region "Standard Generated Procedures(F119TITHE_ONE_1)"


    #region "Automatic Item Initialization(F119TITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:05 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:36:04 PM
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


    #region "Transaction Management Procedures(F119TITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:04 PM

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
        fleF119TITHE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(F119TITHE_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:04 PM

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
            fleF119TITHE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(F119TITHE_ONE_1)"


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

                            Sort(fleF119_DOCTOR_YTD.GetSortValue("DOC_NBR"));



                        }

                    }

                }

            }

            while (Sort(fleF119_DOCTOR_YTD, fleF020_DOCTOR_MSTR))
            {
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TITHE1")
                {
                    X_TITHE1.Value = X_TITHE1.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TITHE2")
                {
                    X_TITHE2.Value = X_TITHE2.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "TITHE3")
                {
                    X_TITHE3.Value = X_TITHE3.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "DEPMEM")
                {
                    X_DEPMEM.Value = X_DEPMEM.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD") / 100;
                }
                if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")) == "INCEXP")
                {
                    X_INCEXP.Value = X_INCEXP.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD") / 100;
                }


                SubFile(ref m_trnTRANS_UPDATE, ref fleF119TITHE, fleF119_DOCTOR_YTD.At("DOC_NBR"), SubFileType.Portable, fleF020_DOCTOR_MSTR, "DOC_AFP_PAYM_GROUP", COMMA, "DOC_NBR", "DOC_DEPT", "DOC_NAME",
                "DOC_INITS", X_TITHE1, X_TITHE2, X_TITHE3, X_DEPMEM, X_INCEXP, X_CR);
                //Parent:DOC_INITS


                Reset(ref X_TITHE1, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_TITHE2, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_TITHE3, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_DEPMEM, fleF119_DOCTOR_YTD.At("DOC_NBR"));
                Reset(ref X_INCEXP, fleF119_DOCTOR_YTD.At("DOC_NBR"));

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




