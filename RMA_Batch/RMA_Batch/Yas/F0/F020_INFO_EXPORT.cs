
#region "Screen Comments"



#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class F020_INFO_EXPORT : BaseClassControl
{

    private F020_INFO_EXPORT m_F020_INFO_EXPORT;

    public F020_INFO_EXPORT(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public F020_INFO_EXPORT(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_F020_INFO_EXPORT != null))
        {
            m_F020_INFO_EXPORT.CloseTransactionObjects();
            m_F020_INFO_EXPORT = null;
        }
    }

    public F020_INFO_EXPORT GetF020_INFO_EXPORT(int Level)
    {
        if (m_F020_INFO_EXPORT == null)
        {
            m_F020_INFO_EXPORT = new F020_INFO_EXPORT("F020_INFO_EXPORT", Level);
        }
        else
        {
            m_F020_INFO_EXPORT.ResetValues();
        }
        return m_F020_INFO_EXPORT;
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

            F020_INFO_EXPORT_ONE_1 ONE_1 = new F020_INFO_EXPORT_ONE_1(Name, Level);
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



public class F020_INFO_EXPORT_ONE_1 : F020_INFO_EXPORT
{

    public F020_INFO_EXPORT_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_INFO_EXPORT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F020_INFO_EXPORT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(F020_INFO_EXPORT_ONE_1)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 31 & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "677" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "683" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "F86" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "E73" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "E28" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "D12" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "686")
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






    private SqlFileObject fleF020_INFO_EXPORT;


    #endregion


    #region "Standard Generated Procedures(F020_INFO_EXPORT_ONE_1)"


    #region "Automatic Item Initialization(F020_INFO_EXPORT_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(F020_INFO_EXPORT_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:55 PM

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
        fleF020_INFO_EXPORT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(F020_INFO_EXPORT_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:55 PM

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
            fleF020_INFO_EXPORT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(F020_INFO_EXPORT_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--

                if (Transaction())
                {

                     if (Select_If())
                    {





                        SubFile(ref m_trnTRANS_UPDATE, ref fleF020_INFO_EXPORT, SubFileType.Keep, fleF020_DOCTOR_MSTR);
                        //Parent:DOC_INITS)    'Parent:DOC_ADDR_OFFICE_PC)    'Parent:DOC_ADDR_HOME_PC)    'Parent:DOC_DATE_FAC_START)    'Parent:DOC_DATE_FAC_TERM


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
            EndRequest("ONE_1");

        }

    }




    #endregion


}
//ONE_1




