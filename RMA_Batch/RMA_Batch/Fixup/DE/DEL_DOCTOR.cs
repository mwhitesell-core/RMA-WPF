
#region "Screen Comments"

// 2010/sep/13 MC - Yasemin requests to delete f020-extra, f027 & f028 records as well
// - allow users to delete more than one doctor at a time by choose parm
// 2010/sep/14 MC - Yasemin requests to delete doctor with termination date only
// 2010/09/13 - comment out and rewrite
// request delete_doctor
// access f020-doctor-mstr
// choose doc-nbr  ### ,  ### 
// choose doc-nbr  ### 
// subfile savef020 keep include f020-doctor-mstr
// output  f020-doctor-mstr delete


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class DEL_DOCTOR : BaseClassControl
{

    private DEL_DOCTOR m_DEL_DOCTOR;

    public DEL_DOCTOR(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public DEL_DOCTOR(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_DEL_DOCTOR != null))
        {
            m_DEL_DOCTOR.CloseTransactionObjects();
            m_DEL_DOCTOR = null;
        }
    }

    public DEL_DOCTOR GetDEL_DOCTOR(int Level)
    {
        if (m_DEL_DOCTOR == null)
        {
            m_DEL_DOCTOR = new DEL_DOCTOR("DEL_DOCTOR", Level);
        }
        else
        {
            m_DEL_DOCTOR.ResetValues();
        }
        return m_DEL_DOCTOR;
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

            DEL_DOCTOR_DELETE_DOCTOR_1 DELETE_DOCTOR_1 = new DEL_DOCTOR_DELETE_DOCTOR_1(Name, Level);
            DELETE_DOCTOR_1.Run();
            DELETE_DOCTOR_1.Dispose();
            DELETE_DOCTOR_1 = null;

            DEL_DOCTOR_DELETE_DOCTOR_EXTRA_2 DELETE_DOCTOR_EXTRA_2 = new DEL_DOCTOR_DELETE_DOCTOR_EXTRA_2(Name, Level);
            DELETE_DOCTOR_EXTRA_2.Run();
            DELETE_DOCTOR_EXTRA_2.Dispose();
            DELETE_DOCTOR_EXTRA_2 = null;

            DEL_DOCTOR_DELETE_F027_3 DELETE_F027_3 = new DEL_DOCTOR_DELETE_F027_3(Name, Level);
            DELETE_F027_3.Run();
            DELETE_F027_3.Dispose();
            DELETE_F027_3 = null;

            DEL_DOCTOR_DELETE_F028_4 DELETE_F028_4 = new DEL_DOCTOR_DELETE_F028_4(Name, Level);
            DELETE_F028_4.Run();
            DELETE_F028_4.Dispose();
            DELETE_F028_4 = null;

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



public class DEL_DOCTOR_DELETE_DOCTOR_1 : DEL_DOCTOR
{

    public DEL_DOCTOR_DELETE_DOCTOR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF020 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF020", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDELF020_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DELF020_DOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF020_DOCTOR_MSTR.Choose += fleF020_DOCTOR_MSTR_Choose;
        TERM_DATE.GetValue += TERM_DATE_GetValue;
        RUN_DATE.GetValue += RUN_DATE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(DEL_DOCTOR_DELETE_DOCTOR_1)"

    private SqlFileObject fleF020_DOCTOR_MSTR;

    private void fleF020_DOCTOR_MSTR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            if ((Prompt(1).ToString() != null) && Prompt(1).ToString().Length > 0)
            {
                strSQL.Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR"));
                strSQL.Append(" IN(");
                strSQL.Append(Common.StringToField(Prompt(2).ToString()));
                strSQL.Append(")");
            }

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

    private DDecimal TERM_DATE = new DDecimal("TERM_DATE");
    private void TERM_DATE_GetValue(ref decimal Value)
    {

        try
        {
            Value = (Convert.ToDecimal(Prompt(3)));


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
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) != 0 & fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM") <= TERM_DATE.Value)
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

    private DDecimal RUN_DATE = new DDecimal("RUN_DATE");
    private void RUN_DATE_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.SysDate(ref m_cnnQUERY);


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


    private SqlFileObject fleSAVEF020;


    private SqlFileObject fleDELF020_DOC;


    #endregion


    #region "Standard Generated Procedures(DEL_DOCTOR_DELETE_DOCTOR_1)"


    #region "Automatic Item Initialization(DEL_DOCTOR_DELETE_DOCTOR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEL_DOCTOR_DELETE_DOCTOR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:04 PM

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
        fleSAVEF020.Transaction = m_trnTRANS_UPDATE;
        fleDELF020_DOC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEL_DOCTOR_DELETE_DOCTOR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:04 PM

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
            fleSAVEF020.Dispose();
            fleDELF020_DOC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEL_DOCTOR_DELETE_DOCTOR_1)"


    public void Run()
    {

        try
        {
            Request("DELETE_DOCTOR_1");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--


                if (Transaction())
                {

                     if (Select_If())
                    {


                        SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF020, SubFileType.Keep, RUN_DATE);
                        //Parent:DOC_DATE_FAC_TERM)    'Parent:CONTACTS_INITS



                        SubFile(ref m_trnTRANS_UPDATE, ref fleDELF020_DOC, SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_NBR");
                        //Parent:DOC_DATE_FAC_TERM)    'Parent:CONTACTS_INITS



                        fleF020_DOCTOR_MSTR.OutPut(OutPutType.Delete);
                        //Parent:DOC_DATE_FAC_TERM)    'Parent:CONTACTS_INITS

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
            EndRequest("DELETE_DOCTOR_1");

        }

    }




    #endregion


}
//DELETE_DOCTOR_1



public class DEL_DOCTOR_DELETE_DOCTOR_EXTRA_2 : DEL_DOCTOR
{

    public DEL_DOCTOR_DELETE_DOCTOR_EXTRA_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleDELF020_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DELF020_DOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF020EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF020EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(DEL_DOCTOR_DELETE_DOCTOR_EXTRA_2)"

    private SqlFileObject fleDELF020_DOC;
    private SqlFileObject fleF020_DOCTOR_EXTRA;

    private SqlFileObject fleSAVEF020EXTRA;


    #endregion


    #region "Standard Generated Procedures(DEL_DOCTOR_DELETE_DOCTOR_EXTRA_2)"


    #region "Automatic Item Initialization(DEL_DOCTOR_DELETE_DOCTOR_EXTRA_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEL_DOCTOR_DELETE_DOCTOR_EXTRA_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:04 PM

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
        fleDELF020_DOC.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF020EXTRA.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEL_DOCTOR_DELETE_DOCTOR_EXTRA_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:04 PM

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
            fleDELF020_DOC.Dispose();
            fleF020_DOCTOR_EXTRA.Dispose();
            fleSAVEF020EXTRA.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEL_DOCTOR_DELETE_DOCTOR_EXTRA_2)"


    public void Run()
    {

        try
        {
            Request("DELETE_DOCTOR_EXTRA_2");

            while (fleDELF020_DOC.QTPForMissing())
            {
                // --> GET DELF020_DOC <--

                fleDELF020_DOC.GetData();
                // --> End GET DELF020_DOC <--

                while (fleF020_DOCTOR_EXTRA.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_EXTRA <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleDELF020_DOC.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_EXTRA <--


                    if (Transaction())
                    {

                        SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF020EXTRA, SubFileType.Keep, fleF020_DOCTOR_EXTRA);
                        //Parent:DOC_DATE_FAC_TERM)    'Parent:CONTACTS_INITS



                        fleF020_DOCTOR_EXTRA.OutPut(OutPutType.Delete);
                        //Parent:DOC_DATE_FAC_TERM)    'Parent:CONTACTS_INITS

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
            EndRequest("DELETE_DOCTOR_EXTRA_2");

        }

    }




    #endregion


}
//DELETE_DOCTOR_EXTRA_2



public class DEL_DOCTOR_DELETE_F027_3 : DEL_DOCTOR
{

    public DEL_DOCTOR_DELETE_F027_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleDELF020_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DELF020_DOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF027_CONTACTS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F027_CONTACTS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF027 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF027", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(DEL_DOCTOR_DELETE_F027_3)"

    private SqlFileObject fleDELF020_DOC;
    private SqlFileObject fleF027_CONTACTS_MSTR;

    private SqlFileObject fleSAVEF027;


    #endregion


    #region "Standard Generated Procedures(DEL_DOCTOR_DELETE_F027_3)"


    #region "Automatic Item Initialization(DEL_DOCTOR_DELETE_F027_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEL_DOCTOR_DELETE_F027_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:04 PM

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
        fleDELF020_DOC.Transaction = m_trnTRANS_UPDATE;
        fleF027_CONTACTS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF027.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEL_DOCTOR_DELETE_F027_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:05 PM

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
            fleDELF020_DOC.Dispose();
            fleF027_CONTACTS_MSTR.Dispose();
            fleSAVEF027.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEL_DOCTOR_DELETE_F027_3)"


    public void Run()
    {

        try
        {
            Request("DELETE_F027_3");

            while (fleDELF020_DOC.QTPForMissing())
            {
                // --> GET DELF020_DOC <--

                fleDELF020_DOC.GetData();
                // --> End GET DELF020_DOC <--

                while (fleF027_CONTACTS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F027_CONTACTS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF027_CONTACTS_MSTR.ElementOwner("FILLER")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((" ")));
                    m_strWhere.Append(" And ").Append(fleF027_CONTACTS_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF027_CONTACTS_MSTR.GetStringValue("DOC_NBR")));

                    fleF027_CONTACTS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F027_CONTACTS_MSTR <--


                    if (Transaction())
                    {

                        SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF027, SubFileType.Keep, fleF027_CONTACTS_MSTR);
                        //Parent:DOC_DATE_FAC_TERM)    'Parent:CONTACTS_INITS



                        fleF027_CONTACTS_MSTR.OutPut(OutPutType.Delete);
                        //Parent:DOC_DATE_FAC_TERM)    'Parent:CONTACTS_INITS

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
            EndRequest("DELETE_F027_3");

        }

    }




    #endregion


}
//DELETE_F027_3



public class DEL_DOCTOR_DELETE_F028_4 : DEL_DOCTOR
{

    public DEL_DOCTOR_DELETE_F028_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleDELF020_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DELF020_DOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF028_CONTACTS_INFO_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_CONTACTS_INFO_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF028 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF028", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(DEL_DOCTOR_DELETE_F028_4)"

    private SqlFileObject fleDELF020_DOC;
    private SqlFileObject fleF028_CONTACTS_INFO_MSTR;

    private SqlFileObject fleSAVEF028;


    #endregion


    #region "Standard Generated Procedures(DEL_DOCTOR_DELETE_F028_4)"


    #region "Automatic Item Initialization(DEL_DOCTOR_DELETE_F028_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(DEL_DOCTOR_DELETE_F028_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:05 PM

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
        fleDELF020_DOC.Transaction = m_trnTRANS_UPDATE;
        fleF028_CONTACTS_INFO_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF028.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(DEL_DOCTOR_DELETE_F028_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:05 PM

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
            fleDELF020_DOC.Dispose();
            fleF028_CONTACTS_INFO_MSTR.Dispose();
            fleSAVEF028.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(DEL_DOCTOR_DELETE_F028_4)"


    public void Run()
    {

        try
        {
            Request("DELETE_F028_4");

            while (fleDELF020_DOC.QTPForMissing())
            {
                // --> GET DELF020_DOC <--

                fleDELF020_DOC.GetData();
                // --> End GET DELF020_DOC <--

                while (fleF028_CONTACTS_INFO_MSTR.QTPForMissing("1"))
                {
                    // --> GET F028_CONTACTS_INFO_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF028_CONTACTS_INFO_MSTR.ElementOwner("FILLER")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((" ")));
                    m_strWhere.Append(" And ").Append(fleF028_CONTACTS_INFO_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF028_CONTACTS_INFO_MSTR.GetStringValue("DOC_NBR")));

                    fleF028_CONTACTS_INFO_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F028_CONTACTS_INFO_MSTR <--


                    if (Transaction())
                    {

                        SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF028, SubFileType.Keep, fleF028_CONTACTS_INFO_MSTR);
                        //Parent:DOC_DATE_FAC_TERM)    'Parent:CONTACTS_INITS



                        fleF028_CONTACTS_INFO_MSTR.OutPut(OutPutType.Delete);
                        //Parent:DOC_DATE_FAC_TERM)    'Parent:CONTACTS_INITS

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
            EndRequest("DELETE_F028_4");

        }

    }




    #endregion


}
//DELETE_F028_4




