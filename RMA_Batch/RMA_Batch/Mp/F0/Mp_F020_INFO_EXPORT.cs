
#region "Screen Comments"



#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Mp_F020_INFO_EXPORT : BaseClassControl
{

    private Mp_F020_INFO_EXPORT m_Mp_F020_INFO_EXPORT;

    public Mp_F020_INFO_EXPORT(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public Mp_F020_INFO_EXPORT(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_Mp_F020_INFO_EXPORT != null))
        {
            m_Mp_F020_INFO_EXPORT.CloseTransactionObjects();
            m_Mp_F020_INFO_EXPORT = null;
        }
    }

    public Mp_F020_INFO_EXPORT GetMp_F020_INFO_EXPORT(int Level)
    {
        if (m_Mp_F020_INFO_EXPORT == null)
        {
            m_Mp_F020_INFO_EXPORT = new Mp_F020_INFO_EXPORT("Mp_F020_INFO_EXPORT", Level);
        }
        else
        {
            m_Mp_F020_INFO_EXPORT.ResetValues();
        }
        return m_Mp_F020_INFO_EXPORT;
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

            Mp_F020_INFO_EXPORT_ONE_1 ONE_1 = new Mp_F020_INFO_EXPORT_ONE_1(Name, Level);
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



public class Mp_F020_INFO_EXPORT_ONE_1 : Mp_F020_INFO_EXPORT
{

    public Mp_F020_INFO_EXPORT_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleMp_F020_INFO_EXPORT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F020_INFO_EXPORT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020C_DOC_CLINIC_EXPORT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F020C_DOC_CLINIC_EXPORT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(Mp_F020_INFO_EXPORT_ONE_1)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 31 &
                QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "677" &
                QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "683" &
                QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "F86" &
                QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "E73" &
                QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "E28" &
                QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "D12" &
                QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")) != "686")
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




    private SqlFileObject fleF020C_DOC_CLINIC_EXPORT;
    private SqlFileObject fleF020C_DOC_CLINIC_NEXT_BATCH_NBR;
    private SqlFileObject fleMp_F020_INFO_EXPORT;



    #endregion


    #region "Standard Generated Procedures(Mp_F020_INFO_EXPORT_ONE_1)"


    #region "Automatic Item Initialization(Mp_F020_INFO_EXPORT_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_F020_INFO_EXPORT_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:39:34 PM

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
        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
        fleMp_F020_INFO_EXPORT.Transaction = m_trnTRANS_UPDATE;
        fleF020C_DOC_CLINIC_EXPORT.Transaction = m_trnTRANS_UPDATE;

    }



    #endregion


    #region "FILE Management Procedures(Mp_F020_INFO_EXPORT_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:39:34 PM

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
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Dispose();
            fleMp_F020_INFO_EXPORT.Dispose();
            fleF020C_DOC_CLINIC_EXPORT.Dispose();

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_F020_INFO_EXPORT_ONE_1)"


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


                while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.QTPForMissing("1"))
                {

                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                    fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);




                    if (Transaction())
                    {
                        if (Select_If())
                        {

                            Sort(fleF020_DOCTOR_MSTR.GetSortValue("DOC_NBR"));                         

                        }

                    }                   

                }                

            }


            while (Sort(fleF020_DOCTOR_MSTR, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleMp_F020_INFO_EXPORT, fleF020_DOCTOR_MSTR.At("DOC_NBR"), SubFileType.Keep, fleF020_DOCTOR_MSTR,
                    "DOC_NBR",
                    "DOC_DEPT",
                    "DOC_OHIP_NBR",
                    "DOC_NAME",
                    "DOC_INIT1",
                    "DOC_INIT2",
                    "DOC_INIT3",
                    "DOC_ADDR_HOME_1",
                    "DOC_ADDR_HOME_2",
                    "DOC_ADDR_HOME_3",
                    "DOC_ADDR_HOME_PC1",
                    "DOC_ADDR_HOME_PC2",
                    "DOC_ADDR_HOME_PC3",
                    "DOC_ADDR_HOME_PC4",
                    "DOC_ADDR_HOME_PC5",
                    "DOC_ADDR_HOME_PC6",
                    "DOC_ADDR_OFFICE_1",
                    "DOC_ADDR_OFFICE_2",
                    "DOC_ADDR_OFFICE_3",
                    "DOC_ADDR_OFFICE_PC1",
                    "DOC_ADDR_OFFICE_PC2",
                    "DOC_ADDR_OFFICE_PC3",
                    "DOC_ADDR_OFFICE_PC4",
                    "DOC_ADDR_OFFICE_PC5",
                    "DOC_ADDR_OFFICE_PC6",
                    "DOC_FULL_PART_IND",
                    "DOC_DATE_FAC_START_YY",
                    "DOC_DATE_FAC_START_MM",
                    "DOC_DATE_FAC_START_DD",
                    "DOC_DATE_FAC_TERM_YY",
                    "DOC_DATE_FAC_TERM_MM",
                    "DOC_DATE_FAC_TERM_DD");


                SubFile(ref m_trnTRANS_UPDATE, ref fleF020C_DOC_CLINIC_EXPORT, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Exists(), SubFileType.Keep, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR);

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




