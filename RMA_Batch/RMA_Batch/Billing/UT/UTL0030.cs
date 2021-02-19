
#region "Screen Comments"

// PROGRAM: utl0030.qts
// PURPOSE: download files for storage in SQL for analysis
// - note:  this program should only extract the master files that are shared the same for all
// environments.  If need to run for 3 environment, must do it in utl0201.qts
// 2014/Dec/09  MC - utl0030.qts
// - download f030, f070 & f190 files
// 2015/mar/18   MC1 - include f191 and f090 for just current-ep-nbr        
// 2015/mar/22 be1 - changed all date fields in f191 download to be text field with - included in data (yyyy-mm-dd)
// 2015/mar/24   MC2     - transfer the request for f191 to utl0201.qts as agreed by Brad
// 2015/jun/17   MC3     - include f090 for each clinic & f123-company-file
// -------------------------------------------------------------------------------
// OBTAIN CONSTANTS VALUES FOR PASSING TO SUBSEQUENT REQUESTS


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0030 : BaseClassControl
{

    private UTL0030 m_UTL0030;

    public UTL0030(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UTL0030(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UTL0030 != null))
        {
            m_UTL0030.CloseTransactionObjects();
            m_UTL0030 = null;
        }
    }

    public UTL0030 GetUTL0030(int Level)
    {
        if (m_UTL0030 == null)
        {
            m_UTL0030 = new UTL0030("UTL0030", Level);
        }
        else
        {
            m_UTL0030.ResetValues();
        }
        return m_UTL0030;
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

            UTL0030_CONST_REC6_1 CONST_REC6_1 = new UTL0030_CONST_REC6_1(Name, Level);
            CONST_REC6_1.Run();
            CONST_REC6_1.Dispose();
            CONST_REC6_1 = null;

            UTL0030_F030_2 F030_2 = new UTL0030_F030_2(Name, Level);
            F030_2.Run();
            F030_2.Dispose();
            F030_2 = null;

            UTL0030_F070_3 F070_3 = new UTL0030_F070_3(Name, Level);
            F070_3.Run();
            F070_3.Dispose();
            F070_3 = null;

            UTL0030_F190_4 F190_4 = new UTL0030_F190_4(Name, Level);
            F190_4.Run();
            F190_4.Dispose();
            F190_4 = null;

            UTL0030_F090_CLINIC_5 F090_CLINIC_5 = new UTL0030_F090_CLINIC_5(Name, Level);
            F090_CLINIC_5.Run();
            F090_CLINIC_5.Dispose();
            F090_CLINIC_5 = null;

            UTL0030_F123_6 F123_6 = new UTL0030_F123_6(Name, Level);
            F123_6.Run();
            F123_6.Dispose();
            F123_6 = null;

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



public class UTL0030_CONST_REC6_1 : UTL0030
{

    public UTL0030_CONST_REC6_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0F090_REC6 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F090_REC6", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0030_CONST_REC6_1)"

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
    private SqlFileObject fleUTL0F090_REC6;


    #endregion


    #region "Standard Generated Procedures(UTL0030_CONST_REC6_1)"


    #region "Automatic Item Initialization(UTL0030_CONST_REC6_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0030_CONST_REC6_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
        fleUTL0F090_REC6.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0030_CONST_REC6_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
            fleUTL0F090_REC6.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0030_CONST_REC6_1)"


    public void Run()
    {

        try
        {
            Request("CONST_REC6_1");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F090_REC6, SubFileType.Portable, fleCONSTANTS_MSTR_REC_6, "CURRENT_EP_NBR", X_LF);


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
            EndRequest("CONST_REC6_1");

        }

    }







    #endregion


}
//CONST_REC6_1



public class UTL0030_F030_2 : UTL0030
{

    public UTL0030_F030_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF030_LOCATIONS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F030_LOCATIONS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0F030 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F030", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0030_F030_2)"

    private SqlFileObject fleF030_LOCATIONS_MSTR;
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
    private SqlFileObject fleUTL0F030;


    #endregion


    #region "Standard Generated Procedures(UTL0030_F030_2)"


    #region "Automatic Item Initialization(UTL0030_F030_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0030_F030_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
        fleF030_LOCATIONS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleUTL0F030.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0030_F030_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
            fleF030_LOCATIONS_MSTR.Dispose();
            fleUTL0F030.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0030_F030_2)"


    public void Run()
    {

        try
        {
            Request("F030_2");

            while (fleF030_LOCATIONS_MSTR.QTPForMissing())
            {
                // --> GET F030_LOCATIONS_MSTR <--

                fleF030_LOCATIONS_MSTR.GetData();
                // --> End GET F030_LOCATIONS_MSTR <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F030, SubFileType.Portable, fleF030_LOCATIONS_MSTR, "LOC_NBR", X_DELIMITER, "LOC_NAME", "LOC_CLINIC_NBR", "LOC_HOSPITAL_NBR", "LOC_HOSPITAL_CODE",
                    "LOC_CARD_COLOUR", "LOC_MINISTRY_LOC_CODE", "LOC_PAYROLL_FLAG", "LOC_ACTIVE_FOR_ENTRY", "LOC_SERVICE_LOCATION_INDICATOR", X_LF);


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
            EndRequest("F030_2");

        }

    }







    #endregion


}
//F030_2



public class UTL0030_F070_3 : UTL0030
{

    public UTL0030_F070_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
         fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0F070 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F070", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0030_F070_3)"

    private SqlFileObject fleF070_DEPT_MSTR;
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
    private SqlFileObject fleUTL0F070;


    #endregion


    #region "Standard Generated Procedures(UTL0030_F070_3)"


    #region "Automatic Item Initialization(UTL0030_F070_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0030_F070_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
        fleF070_DEPT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleUTL0F070.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0030_F070_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
            fleF070_DEPT_MSTR.Dispose();
            fleUTL0F070.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0030_F070_3)"


    public void Run()
    {

        try
        {
            Request("F070_3");

            while (fleF070_DEPT_MSTR.QTPForMissing())
            {
                // --> GET F070_DEPT_MSTR <--

                fleF070_DEPT_MSTR.GetData();
                // --> End GET F070_DEPT_MSTR <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F070, SubFileType.Portable, fleF070_DEPT_MSTR, "DEPT_NBR", X_DELIMITER, "DEPT_NAME", "DEPT_ADDR1", "DEPT_ADDR2", "DEPT_ADDR3",
                    "DEPT_CHAIRMAN", "DEPT_CO_ORDINATOR", "DEPT_COMPANY", X_LF);


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
            EndRequest("F070_3");

        }

    }







    #endregion


}
//F070_3



public class UTL0030_F190_4 : UTL0030
{

    public UTL0030_F190_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0F190 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F190", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0030_F190_4)"

    private SqlFileObject fleF190_COMP_CODES;
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
    private SqlFileObject fleUTL0F190;


    #endregion


    #region "Standard Generated Procedures(UTL0030_F190_4)"


    #region "Automatic Item Initialization(UTL0030_F190_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0030_F190_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleUTL0F190.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0030_F190_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
            fleF190_COMP_CODES.Dispose();
            fleUTL0F190.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0030_F190_4)"


    public void Run()
    {

        try
        {
            Request("F190_4");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F190, SubFileType.Portable, fleF190_COMP_CODES, "COMP_CODE", X_DELIMITER, "COMP_TYPE", "DESC_LONG", "DESC_SHORT", X_LF);


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
            EndRequest("F190_4");

        }

    }







    #endregion


}
//F190_4



public class UTL0030_F090_CLINIC_5 : UTL0030
{

    public UTL0030_F090_CLINIC_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0F090_CLINIC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F090_CLINIC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleICONST_MSTR_REC.Choose += fleICONST_MSTR_REC_Choose;
        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0030_F090_CLINIC_5)"

    private SqlFileObject fleICONST_MSTR_REC;

    private void fleICONST_MSTR_REC_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
            strSQL.Append(22);


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
    private SqlFileObject fleUTL0F090_CLINIC;


    #endregion


    #region "Standard Generated Procedures(UTL0030_F090_CLINIC_5)"


    #region "Automatic Item Initialization(UTL0030_F090_CLINIC_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0030_F090_CLINIC_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleUTL0F090_CLINIC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0030_F090_CLINIC_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
            fleICONST_MSTR_REC.Dispose();
            fleUTL0F090_CLINIC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0030_F090_CLINIC_5)"


    public void Run()
    {

        try
        {
            Request("F090_CLINIC_5");

            while (fleICONST_MSTR_REC.QTPForMissing())
            {
                // --> GET ICONST_MSTR_REC <--

                fleICONST_MSTR_REC.GetData();
                // --> End GET ICONST_MSTR_REC <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F090_CLINIC, SubFileType.Portable, fleICONST_MSTR_REC, "ICONST_CLINIC_NBR_1_2", X_DELIMITER, "ICONST_CLINIC_NBR", "ICONST_CLINIC_NAME", X_LF);


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
            EndRequest("F090_CLINIC_5");

        }

    }







    #endregion


}
//F090_CLINIC_5



public class UTL0030_F123_6 : UTL0030
{

    public UTL0030_F123_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF123_COMPANY_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F123_COMPANY_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0F123 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F123", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0030_F123_6)"

    private SqlFileObject fleF123_COMPANY_MSTR;
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
    private SqlFileObject fleUTL0F123;


    #endregion


    #region "Standard Generated Procedures(UTL0030_F123_6)"


    #region "Automatic Item Initialization(UTL0030_F123_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0030_F123_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
        fleF123_COMPANY_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleUTL0F123.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0030_F123_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:37 PM

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
            fleF123_COMPANY_MSTR.Dispose();
            fleUTL0F123.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0030_F123_6)"


    public void Run()
    {

        try
        {
            Request("F123_6");

            while (fleF123_COMPANY_MSTR.QTPForMissing())
            {
                // --> GET F123_COMPANY_MSTR <--

                fleF123_COMPANY_MSTR.GetData();
                // --> End GET F123_COMPANY_MSTR <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F123, SubFileType.Portable, fleF123_COMPANY_MSTR, "COMPANY_NBR", X_DELIMITER, "COMPANY_NAME", X_LF);


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
            EndRequest("F123_6");

        }

    }







    #endregion


}
//F123_6




