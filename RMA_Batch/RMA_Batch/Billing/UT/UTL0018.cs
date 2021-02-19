
#region "Screen Comments"

// 2014/Jul/24   M.C.    utl0018.qts
// - this program should only be run once a year after yearend 
// - change PED 1 to 13 for all clinics for the new fiscal year, Yasemin must define 3 sets of monthend date
// for clinic 22, 60 & 37 as they are run in monthend 1, 2 & 3 respectively


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0018 : BaseClassControl
{

    private UTL0018 m_UTL0018;

    public UTL0018(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UTL0018(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UTL0018 != null))
        {
            m_UTL0018.CloseTransactionObjects();
            m_UTL0018 = null;
        }
    }

    public UTL0018 GetUTL0018(int Level)
    {
        if (m_UTL0018 == null)
        {
            m_UTL0018 = new UTL0018("UTL0018", Level);
        }
        else
        {
            m_UTL0018.ResetValues();
        }
        return m_UTL0018;
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

            UTL0018_EXTRACT_CLINIC_22_60_37_1 EXTRACT_CLINIC_22_60_37_1 = new UTL0018_EXTRACT_CLINIC_22_60_37_1(Name, Level);
            EXTRACT_CLINIC_22_60_37_1.Run();
            EXTRACT_CLINIC_22_60_37_1.Dispose();
            EXTRACT_CLINIC_22_60_37_1 = null;

            UTL0018_UPDATE_MONTHEND_3_CLINICS_2 UPDATE_MONTHEND_3_CLINICS_2 = new UTL0018_UPDATE_MONTHEND_3_CLINICS_2(Name, Level);
            UPDATE_MONTHEND_3_CLINICS_2.Run();
            UPDATE_MONTHEND_3_CLINICS_2.Dispose();
            UPDATE_MONTHEND_3_CLINICS_2 = null;

            UTL0018_UPDATE_MONTHEND_2_CLINICS_3 UPDATE_MONTHEND_2_CLINICS_3 = new UTL0018_UPDATE_MONTHEND_2_CLINICS_3(Name, Level);
            UPDATE_MONTHEND_2_CLINICS_3.Run();
            UPDATE_MONTHEND_2_CLINICS_3.Dispose();
            UPDATE_MONTHEND_2_CLINICS_3 = null;

            UTL0018_UPDATE_MONTHEND_1_CLINICS_4 UPDATE_MONTHEND_1_CLINICS_4 = new UTL0018_UPDATE_MONTHEND_1_CLINICS_4(Name, Level);
            UPDATE_MONTHEND_1_CLINICS_4.Run();
            UPDATE_MONTHEND_1_CLINICS_4.Dispose();
            UPDATE_MONTHEND_1_CLINICS_4 = null;

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



public class UTL0018_EXTRACT_CLINIC_22_60_37_1 : UTL0018
{

    public UTL0018_EXTRACT_CLINIC_22_60_37_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleEXT_CLINIC22 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXT_CLINIC22", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleEXT_CLINIC60 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXT_CLINIC60", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleEXT_CLINIC37 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXT_CLINIC37", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleICONST_MSTR_REC.Choose += fleICONST_MSTR_REC_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0018_EXTRACT_CLINIC_22_60_37_1)"

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





    private SqlFileObject fleEXT_CLINIC22;




    private SqlFileObject fleEXT_CLINIC60;




    private SqlFileObject fleEXT_CLINIC37;


    #endregion


    #region "Standard Generated Procedures(UTL0018_EXTRACT_CLINIC_22_60_37_1)"


    #region "Automatic Item Initialization(UTL0018_EXTRACT_CLINIC_22_60_37_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0018_EXTRACT_CLINIC_22_60_37_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:53 PM

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
        fleEXT_CLINIC22.Transaction = m_trnTRANS_UPDATE;
        fleEXT_CLINIC60.Transaction = m_trnTRANS_UPDATE;
        fleEXT_CLINIC37.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0018_EXTRACT_CLINIC_22_60_37_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:53 PM

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
            fleEXT_CLINIC22.Dispose();
            fleEXT_CLINIC60.Dispose();
            fleEXT_CLINIC37.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0018_EXTRACT_CLINIC_22_60_37_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_CLINIC_22_60_37_1");

            while (fleICONST_MSTR_REC.QTPForMissing())
            {
                // --> GET ICONST_MSTR_REC <--

                fleICONST_MSTR_REC.GetData();
                // --> End GET ICONST_MSTR_REC <--


                if (Transaction())
                {




                    SubFile(ref m_trnTRANS_UPDATE, ref fleEXT_CLINIC22, QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == 22, SubFileType.Keep, fleICONST_MSTR_REC, "ICONST_DATE_PERIOD_END_1", "ICONST_DATE_PERIOD_END_2", "ICONST_DATE_PERIOD_END_3", "ICONST_DATE_PERIOD_END_4", "ICONST_DATE_PERIOD_END_5",
                    "ICONST_DATE_PERIOD_END_6", "ICONST_DATE_PERIOD_END_7", "ICONST_DATE_PERIOD_END_8", "ICONST_DATE_PERIOD_END_9", "ICONST_DATE_PERIOD_END_10", "ICONST_DATE_PERIOD_END_11", "ICONST_DATE_PERIOD_END_12", "ICONST_DATE_PERIOD_END_13", "ICONST_MONTHEND", "ICONST_DATE_PERIOD_END",
                    "ICONST_PED_NUMBER_WITHIN_FISCAL_YEAR");






                    SubFile(ref m_trnTRANS_UPDATE, ref fleEXT_CLINIC60, QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == 60, SubFileType.Keep, fleICONST_MSTR_REC, "ICONST_DATE_PERIOD_END_1", "ICONST_DATE_PERIOD_END_2", "ICONST_DATE_PERIOD_END_3", "ICONST_DATE_PERIOD_END_4", "ICONST_DATE_PERIOD_END_5",
                    "ICONST_DATE_PERIOD_END_6", "ICONST_DATE_PERIOD_END_7", "ICONST_DATE_PERIOD_END_8", "ICONST_DATE_PERIOD_END_9", "ICONST_DATE_PERIOD_END_10", "ICONST_DATE_PERIOD_END_11", "ICONST_DATE_PERIOD_END_12", "ICONST_DATE_PERIOD_END_13", "ICONST_MONTHEND", "ICONST_DATE_PERIOD_END",
                    "ICONST_PED_NUMBER_WITHIN_FISCAL_YEAR");






                    SubFile(ref m_trnTRANS_UPDATE, ref fleEXT_CLINIC37, QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_NBR_1_2")) == 37, SubFileType.Keep, fleICONST_MSTR_REC, "ICONST_DATE_PERIOD_END_1", "ICONST_DATE_PERIOD_END_2", "ICONST_DATE_PERIOD_END_3", "ICONST_DATE_PERIOD_END_4", "ICONST_DATE_PERIOD_END_5",
                    "ICONST_DATE_PERIOD_END_6", "ICONST_DATE_PERIOD_END_7", "ICONST_DATE_PERIOD_END_8", "ICONST_DATE_PERIOD_END_9", "ICONST_DATE_PERIOD_END_10", "ICONST_DATE_PERIOD_END_11", "ICONST_DATE_PERIOD_END_12", "ICONST_DATE_PERIOD_END_13", "ICONST_MONTHEND", "ICONST_DATE_PERIOD_END",
                    "ICONST_PED_NUMBER_WITHIN_FISCAL_YEAR");



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
            EndRequest("EXTRACT_CLINIC_22_60_37_1");

        }

    }




    #endregion


}
//EXTRACT_CLINIC_22_60_37_1



public class UTL0018_UPDATE_MONTHEND_3_CLINICS_2 : UTL0018
{

    public UTL0018_UPDATE_MONTHEND_3_CLINICS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleEXT_CLINIC22 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXT_CLINIC22", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleICONST_MSTR_REC.Choose += fleICONST_MSTR_REC_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0018_UPDATE_MONTHEND_3_CLINICS_2)"

    private SqlFileObject fleICONST_MSTR_REC;



    private SqlFileObject fleEXT_CLINIC22;

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


    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_MONTHEND")) == QDesign.NULL(fleEXT_CLINIC22.GetStringValue("ICONST_MONTHEND")))
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


    #endregion


    #region "Standard Generated Procedures(UTL0018_UPDATE_MONTHEND_3_CLINICS_2)"


    #region "Automatic Item Initialization(UTL0018_UPDATE_MONTHEND_3_CLINICS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0018_UPDATE_MONTHEND_3_CLINICS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:53 PM

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
        fleEXT_CLINIC22.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0018_UPDATE_MONTHEND_3_CLINICS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:53 PM

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
            fleEXT_CLINIC22.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0018_UPDATE_MONTHEND_3_CLINICS_2)"


    public void Run()
    {

        try
        {
            Request("UPDATE_MONTHEND_3_CLINICS_2");

            while (fleICONST_MSTR_REC.QTPForMissing())
            {
                // --> GET ICONST_MSTR_REC <--

                fleICONST_MSTR_REC.GetData();
                // --> End GET ICONST_MSTR_REC <--

                while (fleEXT_CLINIC22.QTPForMissing("1"))
                {
                    // --> GET EXT_CLINIC22 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleEXT_CLINIC22.ElementOwner("CORE_RECORD_NUMBER")).Append(" = ");
                    m_strWhere.Append((0));

                    fleEXT_CLINIC22.GetData(m_strWhere.ToString());
                    // --> End GET EXT_CLINIC22 <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_YY", (fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END")).ToString().PadRight(8).Substring(0, 4));
                            
                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_MM", (fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END")).ToString().PadRight(8).Substring(4, 2));
                            
                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_DD", (fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END")).ToString().PadRight(8).Substring(6, 2));
                            


                            fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", fleEXT_CLINIC22.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_1", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_1"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_2", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_2"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_3", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_3"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_4", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_4"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_5", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_5"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_6", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_6"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_7", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_7"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_8", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_8"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_9", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_9"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_10", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_10"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_11", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_11"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_12", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_12"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_13", fleEXT_CLINIC22.GetNumericDateValue("ICONST_DATE_PERIOD_END_13"));





                            fleICONST_MSTR_REC.OutPut(OutPutType.Update);


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
            EndRequest("UPDATE_MONTHEND_3_CLINICS_2");

        }

    }




    #endregion


}
//UPDATE_MONTHEND_3_CLINICS_2



public class UTL0018_UPDATE_MONTHEND_2_CLINICS_3 : UTL0018
{

    public UTL0018_UPDATE_MONTHEND_2_CLINICS_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleEXT_CLINIC60 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXT_CLINIC60", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleICONST_MSTR_REC.Choose += fleICONST_MSTR_REC_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0018_UPDATE_MONTHEND_2_CLINICS_3)"

    private SqlFileObject fleICONST_MSTR_REC;



    private SqlFileObject fleEXT_CLINIC60;

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


    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_MONTHEND")) == QDesign.NULL(fleEXT_CLINIC60.GetStringValue("ICONST_MONTHEND")))
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


    #endregion


    #region "Standard Generated Procedures(UTL0018_UPDATE_MONTHEND_2_CLINICS_3)"


    #region "Automatic Item Initialization(UTL0018_UPDATE_MONTHEND_2_CLINICS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0018_UPDATE_MONTHEND_2_CLINICS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:53 PM

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
        fleEXT_CLINIC60.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0018_UPDATE_MONTHEND_2_CLINICS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:53 PM

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
            fleEXT_CLINIC60.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0018_UPDATE_MONTHEND_2_CLINICS_3)"


    public void Run()
    {

        try
        {
            Request("UPDATE_MONTHEND_2_CLINICS_3");

            while (fleICONST_MSTR_REC.QTPForMissing())
            {
                // --> GET ICONST_MSTR_REC <--

                fleICONST_MSTR_REC.GetData();
                // --> End GET ICONST_MSTR_REC <--

                while (fleEXT_CLINIC60.QTPForMissing("1"))
                {
                    // --> GET EXT_CLINIC60 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleEXT_CLINIC60.ElementOwner("CORE_RECORD_NUMBER")).Append(" = ");
                    m_strWhere.Append((0));

                    fleEXT_CLINIC60.GetData(m_strWhere.ToString());
                    // --> End GET EXT_CLINIC60 <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_YY", (fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END")).ToString().PadRight(8).Substring(0, 4));
                            
                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_MM", (fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END")).ToString().PadRight(8).Substring(4, 2));
                            
                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_DD", (fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END")).ToString().PadRight(8).Substring(6, 2));
                            


                            fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", fleEXT_CLINIC60.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_1", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_1"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_2", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_2"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_3", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_3"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_4", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_4"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_5", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_5"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_6", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_6"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_7", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_7"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_8", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_8"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_9", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_9"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_10", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_10"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_11", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_11"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_12", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_12"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_13", fleEXT_CLINIC60.GetNumericDateValue("ICONST_DATE_PERIOD_END_13"));





                            fleICONST_MSTR_REC.OutPut(OutPutType.Update);


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
            EndRequest("UPDATE_MONTHEND_2_CLINICS_3");

        }

    }




    #endregion


}
//UPDATE_MONTHEND_2_CLINICS_3



public class UTL0018_UPDATE_MONTHEND_1_CLINICS_4 : UTL0018
{

    public UTL0018_UPDATE_MONTHEND_1_CLINICS_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleEXT_CLINIC37 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXT_CLINIC37", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleICONST_MSTR_REC.Choose += fleICONST_MSTR_REC_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0018_UPDATE_MONTHEND_1_CLINICS_4)"

    private SqlFileObject fleICONST_MSTR_REC;



    private SqlFileObject fleEXT_CLINIC37;

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


    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_MONTHEND")) == QDesign.NULL(fleEXT_CLINIC37.GetStringValue("ICONST_MONTHEND")))
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


    #endregion


    #region "Standard Generated Procedures(UTL0018_UPDATE_MONTHEND_1_CLINICS_4)"


    #region "Automatic Item Initialization(UTL0018_UPDATE_MONTHEND_1_CLINICS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0018_UPDATE_MONTHEND_1_CLINICS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:53 PM

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
        fleEXT_CLINIC37.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0018_UPDATE_MONTHEND_1_CLINICS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:53 PM

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
            fleEXT_CLINIC37.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0018_UPDATE_MONTHEND_1_CLINICS_4)"


    public void Run()
    {

        try
        {
            Request("UPDATE_MONTHEND_1_CLINICS_4");

            while (fleICONST_MSTR_REC.QTPForMissing())
            {
                // --> GET ICONST_MSTR_REC <--

                fleICONST_MSTR_REC.GetData();
                // --> End GET ICONST_MSTR_REC <--

                while (fleEXT_CLINIC37.QTPForMissing("1"))
                {
                    // --> GET EXT_CLINIC37 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleEXT_CLINIC37.ElementOwner("CORE_RECORD_NUMBER")).Append(" = ");
                    m_strWhere.Append((0));

                    fleEXT_CLINIC37.GetData(m_strWhere.ToString());
                    // --> End GET EXT_CLINIC37 <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_YY", (fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END")).ToString().PadRight(8).Substring(0, 4));
                            
                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_MM", (fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END")).ToString().PadRight(8).Substring(4, 2));
                            
                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_DD", (fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END")).ToString().PadRight(8).Substring(6, 2));
                            


                            fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", fleEXT_CLINIC37.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_1", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_1"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_2", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_2"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_3", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_3"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_4", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_4"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_5", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_5"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_6", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_6"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_7", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_7"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_8", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_8"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_9", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_9"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_10", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_10"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_11", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_11"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_12", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_12"));


                            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_13", fleEXT_CLINIC37.GetNumericDateValue("ICONST_DATE_PERIOD_END_13"));





                            fleICONST_MSTR_REC.OutPut(OutPutType.Update);


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
            EndRequest("UPDATE_MONTHEND_1_CLINICS_4");

        }

    }




    #endregion


}
//UPDATE_MONTHEND_1_CLINICS_4




