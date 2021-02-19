
#region "Screen Comments"

// #> PROGRAM-ID.   utl0201_f119.qts
// ((C)) Dyad Technologies
// PROGRAM PURPOSE :
// - extract data from f119 to be run at the end of payroll run after ep nbr has changed to next month
// MODIFICATION HISTORY
// DATE   WHO   DESCRIPTION
// 2015/mar/24 MC  - original
// - copy the request for f191 from ut0030.qts as agreed by Brad


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0201_F119 : BaseClassControl
{

    private UTL0201_F119 m_UTL0201_F119;

    public UTL0201_F119(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        ENVIRONMENT = new CoreCharacter("ENVIRONMENT", 4, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());


    }

    public UTL0201_F119(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        ENVIRONMENT = new CoreCharacter("ENVIRONMENT", 4, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());


    }

    public override void Dispose()
    {
        if ((m_UTL0201_F119 != null))
        {
            m_UTL0201_F119.CloseTransactionObjects();
            m_UTL0201_F119 = null;
        }
    }

    public UTL0201_F119 GetUTL0201_F119(int Level)
    {
        if (m_UTL0201_F119 == null)
        {
            m_UTL0201_F119 = new UTL0201_F119("UTL0201_F119", Level);
        }
        else
        {
            m_UTL0201_F119.ResetValues();
        }
        return m_UTL0201_F119;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_EP_NBR;

    protected CoreCharacter ENVIRONMENT;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            UTL0201_F119_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1 UTL0201_A_CONSTANTS_VALUES_EP_NBR_1 = new UTL0201_F119_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1(Name, Level);
            UTL0201_A_CONSTANTS_VALUES_EP_NBR_1.Run();
            UTL0201_A_CONSTANTS_VALUES_EP_NBR_1.Dispose();
            UTL0201_A_CONSTANTS_VALUES_EP_NBR_1 = null;

            UTL0201_F119_2 u2 = new UTL0201_F119_2(Name, Level);
            u2.Run();
            u2.Dispose();
            u2 = null;

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



public class UTL0201_F119_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1 : UTL0201_F119
{

    public UTL0201_F119_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0201_F119_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;

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




    #endregion


    #region "Standard Generated Procedures(UTL0201_F119_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"


    #region "Automatic Item Initialization(UTL0201_F119_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0201_F119_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:17 PM

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


    }



    #endregion


    #region "FILE Management Procedures(UTL0201_F119_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:17 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0201_F119_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"


    public void Run()
    {

        try
        {
            Request("UTL0201_A_CONSTANTS_VALUES_EP_NBR_1");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                if (Transaction())
                {
                    W_CURRENT_EP_NBR.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR");

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
            EndRequest("UTL0201_A_CONSTANTS_VALUES_EP_NBR_1");

        }

    }







    #endregion


}
//UTL0201_A_CONSTANTS_VALUES_EP_NBR_1



public class UTL0201_F119_2 : UTL0201_F119
{

    public UTL0201_F119_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0201_F119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0201_F119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;
        X_PED.GetValue += X_PED_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0201_F119_2)"

    private SqlFileObject fleF119_DOCTOR_YTD;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("REC_TYPE")) == "A")
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

    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
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
    private DCharacter X_PED = new DCharacter("X_PED", 6);
    private void X_PED_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(QDesign.ASCII(W_CURRENT_EP_NBR.Value), 1, 6);


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
    private SqlFileObject fleUTL0201_F119;


    #endregion


    #region "Standard Generated Procedures(UTL0201_F119_2)"


    #region "Automatic Item Initialization(UTL0201_F119_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0201_F119_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:17 PM

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
        fleUTL0201_F119.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0201_F119_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:17 PM

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
            fleUTL0201_F119.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0201_F119_2)"


    public void Run()
    {

        try
        {
            Request("2");

            while (fleF119_DOCTOR_YTD.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD <--

                fleF119_DOCTOR_YTD.GetData();
                // --> End GET F119_DOCTOR_YTD <--


                if (Transaction())
                {

                     if (Select_If())
                    {
                        SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0201_F119, SubFileType.Portable, ENVIRONMENT, X_DELIMITER, fleF119_DOCTOR_YTD, "DOC_NBR", X_PED, "COMP_CODE", "PROCESS_SEQ",
                        "COMP_CODE_GROUP", "REC_TYPE", "AMT_MTD", "AMT_YTD", "LAST_MOD_DATE", "LAST_MOD_TIME", "LAST_MOD_USER_ID", X_LF);


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
            EndRequest("2");

        }

    }







    #endregion


}
//2




