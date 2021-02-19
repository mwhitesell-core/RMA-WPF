
#region "Screen Comments"

// 2014/JUL/24 MC - update the next monthend date for the clinics that have run
// - reset the cycle to 1  
// 2015/JAN/05   MC1     - pass/prompt PED as the second parameter, set the ped to the correct ped slot
// based on the iconst-ped-number-within-fiscal-year


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U016 : BaseClassControl
{

    private U016 m_U016;

    public U016(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U016(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U016 != null))
        {
            m_U016.CloseTransactionObjects();
            m_U016 = null;
        }
    }

    public U016 GetU016(int Level)
    {
        if (m_U016 == null)
        {
            m_U016 = new U016("U016", Level);
        }
        else
        {
            m_U016.ResetValues();
        }
        return m_U016;
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

            U016_UPD_CLINICS_1 UPD_CLINICS_1 = new U016_UPD_CLINICS_1(Name, Level);
            UPD_CLINICS_1.Run();
            UPD_CLINICS_1.Dispose();
            UPD_CLINICS_1 = null;

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



public class U016_UPD_CLINICS_1 : U016
{

    public U016_UPD_CLINICS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleICONST_MSTR_REC.SetItemFinals += fleICONST_MSTR_REC_SetItemFinals;
        fleICONST_MSTR_REC.Choose += fleICONST_MSTR_REC_Choose;
        X_MONTHEND.GetValue += X_MONTHEND_GetValue;
        X_PED.GetValue += X_PED_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U016_UPD_CLINICS_1)"

    private SqlFileObject fleICONST_MSTR_REC;

    private void fleICONST_MSTR_REC_SetItemFinals()
    {

        try
        {
            fleICONST_MSTR_REC.set_SetValue("ICONST_CLINIC_CYCLE_NBR", 1);
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) < 13)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR") + 1);
            }
            else if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 13)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONSTPEDNUMBERWITHINFISCALYEAR", 1);
            }
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_YY", (X_PED.Value).ToString().PadRight(8).Substring(0, 4));
            
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_MM", (X_PED.Value).ToString().PadRight(8).Substring(4, 2));
            
            fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_DD", (X_PED.Value).ToString().PadRight(8).Substring(6, 2));
            
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 1)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_1", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 2)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_2", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 3)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_3", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 4)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_4", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 5)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_5", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 6)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_6", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 7)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_7", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 8)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_8", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 9)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_9", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 10)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_10", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 11)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_11", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 12)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_12", X_PED.Value);
            }
            if (QDesign.NULL(fleICONST_MSTR_REC.GetDecimalValue("ICONSTPEDNUMBERWITHINFISCALYEAR")) == 13)
            {
                fleICONST_MSTR_REC.set_SetValue("ICONST_DATE_PERIOD_END_13", X_PED.Value);
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

    }


    private void fleICONST_MSTR_REC_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" BETWEEN ");
            strSQL.Append(22).Append(" AND ").Append(99);


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

    private DCharacter X_MONTHEND = new DCharacter("X_MONTHEND", 1);
    private void X_MONTHEND_GetValue(ref string Value)
    {

        try
        {
            Value = Prompt(1).ToString();


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
    private DDecimal X_PED = new DDecimal("X_PED");
    private void X_PED_GetValue(ref decimal Value)
    {

        try
        {
            Value = (Convert.ToDecimal(Prompt(2)));


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
            if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_MONTHEND")) == QDesign.NULL(X_MONTHEND.Value))
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


    #region "Standard Generated Procedures(U016_UPD_CLINICS_1)"


    #region "Automatic Item Initialization(U016_UPD_CLINICS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U016_UPD_CLINICS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:03 PM

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


    }



    #endregion


    #region "FILE Management Procedures(U016_UPD_CLINICS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:03 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U016_UPD_CLINICS_1)"


    public void Run()
    {

        try
        {
            Request("UPD_CLINICS_1");

            while (fleICONST_MSTR_REC.QTPForMissing())
            {
                // --> GET ICONST_MSTR_REC <--

                fleICONST_MSTR_REC.GetData();
                // --> End GET ICONST_MSTR_REC <--


                if (Transaction())
                {

                     if (Select_If())
                    {

                        fleICONST_MSTR_REC.OutPut(OutPutType.Update);
                        

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
            EndRequest("UPD_CLINICS_1");

        }

    }




    #endregion


}
//UPD_CLINICS_1




