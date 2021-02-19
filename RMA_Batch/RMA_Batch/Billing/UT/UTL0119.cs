
#region "Screen Comments"

// 2014/Nov/25 MC utl0119.qts    
// purpose: download all records from f119-doctor-ytd for rec-type = `A` only.
// This program is to be run monthly for all environments (101, SOLO, MP)
// Brad requested this via Ross.
// 2014/12/09 MC1 include more requests to download f020
// 2015/02/05 MC2        exclude if doc-name is blank and doc-dept is zero
// in second request download_f020 as per Brad`s request


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0119 : BaseClassControl
{

    private UTL0119 m_UTL0119;

    public UTL0119(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        ENVIRONMENT = new CoreCharacter("ENVIRONMENT", 4, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());


    }

    public UTL0119(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        ENVIRONMENT = new CoreCharacter("ENVIRONMENT", 4, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());


    }

    public override void Dispose()
    {
        if ((m_UTL0119 != null))
        {
            m_UTL0119.CloseTransactionObjects();
            m_UTL0119 = null;
        }
    }

    public UTL0119 GetUTL0119(int Level)
    {
        if (m_UTL0119 == null)
        {
            m_UTL0119 = new UTL0119("UTL0119", Level);
        }
        else
        {
            m_UTL0119.ResetValues();
        }
        return m_UTL0119;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

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

            UTL0119_DOWNLOAD_F119_1 DOWNLOAD_F119_1 = new UTL0119_DOWNLOAD_F119_1(Name, Level);
            DOWNLOAD_F119_1.Run();
            DOWNLOAD_F119_1.Dispose();
            DOWNLOAD_F119_1 = null;

            UTL0119_DOWNLOAD_F020_2 DOWNLOAD_F020_2 = new UTL0119_DOWNLOAD_F020_2(Name, Level);
            DOWNLOAD_F020_2.Run();
            DOWNLOAD_F020_2.Dispose();
            DOWNLOAD_F020_2 = null;

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



public class UTL0119_DOWNLOAD_F119_1 : UTL0119
{

    public UTL0119_DOWNLOAD_F119_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0F119_A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F119_A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0119_DOWNLOAD_F119_1)"

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




    private SqlFileObject fleUTL0F119_A;


    #endregion


    #region "Standard Generated Procedures(UTL0119_DOWNLOAD_F119_1)"


    #region "Automatic Item Initialization(UTL0119_DOWNLOAD_F119_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0119_DOWNLOAD_F119_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:33 PM

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
        fleUTL0F119_A.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0119_DOWNLOAD_F119_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:33 PM

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
            fleUTL0F119_A.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0119_DOWNLOAD_F119_1)"


    public void Run()
    {

        try
        {
            Request("DOWNLOAD_F119_1");

            while (fleF119_DOCTOR_YTD.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD <--

                fleF119_DOCTOR_YTD.GetData();
                // --> End GET F119_DOCTOR_YTD <--

                if (Transaction())
                {

                    if (Select_If())
                    {




                        SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F119_A, SubFileType.Portable, ENVIRONMENT, X_DELIMITER, fleF119_DOCTOR_YTD, "DOC_NBR", "COMP_CODE", "AMT_MTD", "AMT_YTD",
                        X_LF);



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
            EndRequest("DOWNLOAD_F119_1");

        }

    }




    #endregion


}
//DOWNLOAD_F119_1



public class UTL0119_DOWNLOAD_F020_2 : UTL0119
{

    public UTL0119_DOWNLOAD_F020_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0F020_A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F020_A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.PortableSubFile);
        fleUTL0F020_B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F020_B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.PortableSubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0119_DOWNLOAD_F020_2)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME")) != QDesign.NULL(" ") | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) != 0)
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




    private SqlFileObject fleUTL0F020_A;




    private SqlFileObject fleUTL0F020_B;


    #endregion


    #region "Standard Generated Procedures(UTL0119_DOWNLOAD_F020_2)"


    #region "Automatic Item Initialization(UTL0119_DOWNLOAD_F020_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0119_DOWNLOAD_F020_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:33 PM

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
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleUTL0F020_A.Transaction = m_trnTRANS_UPDATE;
        fleUTL0F020_B.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0119_DOWNLOAD_F020_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:33 PM

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
            fleF020_DOCTOR_MSTR.Dispose();
            fleUTL0F020_A.Dispose();
            fleUTL0F020_B.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0119_DOWNLOAD_F020_2)"


    public void Run()
    {

        try
        {
            Request("DOWNLOAD_F020_2");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--


                if (Transaction())
                {

                    if (Select_If())
                    {




                        SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F020_A, SubFileType.Portable, ENVIRONMENT, X_DELIMITER, fleF020_DOCTOR_MSTR, X_LF);






                        SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F020_B, QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"), 2)) == 0 | QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"), 2)) > 20131201, SubFileType.Portable, ENVIRONMENT, X_DELIMITER, fleF020_DOCTOR_MSTR, X_LF);



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
            EndRequest("DOWNLOAD_F020_2");

        }

    }




    #endregion


}
//DOWNLOAD_F020_2




