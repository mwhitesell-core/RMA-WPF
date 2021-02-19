
#region "Screen Comments"

// 2013/05/15  MC - determine the tech/prof amt paid for each doctor witin clinic
// - using the final breakdown to calculate MOHD payments for miscellaneous payment in claim


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U030_DTL_TECH_PROF : BaseClassControl
{

    private U030_DTL_TECH_PROF m_U030_DTL_TECH_PROF;

    public U030_DTL_TECH_PROF(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U030_DTL_TECH_PROF(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U030_DTL_TECH_PROF != null))
        {
            m_U030_DTL_TECH_PROF.CloseTransactionObjects();
            m_U030_DTL_TECH_PROF = null;
        }
    }

    public U030_DTL_TECH_PROF GetU030_DTL_TECH_PROF(int Level)
    {
        if (m_U030_DTL_TECH_PROF == null)
        {
            m_U030_DTL_TECH_PROF = new U030_DTL_TECH_PROF("U030_DTL_TECH_PROF", Level);
        }
        else
        {
            m_U030_DTL_TECH_PROF.ResetValues();
        }
        return m_U030_DTL_TECH_PROF;
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

            U030_DTL_TECH_PROF_EXTRACT_DTL_1 EXTRACT_DTL_1 = new U030_DTL_TECH_PROF_EXTRACT_DTL_1(Name, Level);
            EXTRACT_DTL_1.Run();
            EXTRACT_DTL_1.Dispose();
            EXTRACT_DTL_1 = null;

            U030_DTL_TECH_PROF_CREATE_TMP_RECORDS_2 CREATE_TMP_RECORDS_2 = new U030_DTL_TECH_PROF_CREATE_TMP_RECORDS_2(Name, Level);
            CREATE_TMP_RECORDS_2.Run();
            CREATE_TMP_RECORDS_2.Dispose();
            CREATE_TMP_RECORDS_2 = null;

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



public class U030_DTL_TECH_PROF_EXTRACT_DTL_1 : U030_DTL_TECH_PROF
{

    public U030_DTL_TECH_PROF_EXTRACT_DTL_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleMC_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "MC_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030_DTL_TECH_PROF_EXTRACT_DTL_1)"

    private SqlFileObject fleU030_DTL;
    private SqlFileObject fleF040_OMA_FEE_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (fleU030_DTL.GetNumericDateValue("RAT_145_SERVICE_DATE") >= 20130401)
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


    private SqlFileObject fleMC_DTL;


    #endregion


    #region "Standard Generated Procedures(U030_DTL_TECH_PROF_EXTRACT_DTL_1)"


    #region "Automatic Item Initialization(U030_DTL_TECH_PROF_EXTRACT_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030_DTL_TECH_PROF_EXTRACT_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:49 PM

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
        fleU030_DTL.Transaction = m_trnTRANS_UPDATE;
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleMC_DTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030_DTL_TECH_PROF_EXTRACT_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:49 PM

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
            fleU030_DTL.Dispose();
            fleF040_OMA_FEE_MSTR.Dispose();
            fleMC_DTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030_DTL_TECH_PROF_EXTRACT_DTL_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_DTL_1");

            while (fleU030_DTL.QTPForMissing())
            {
                // --> GET U030_DTL <--

                fleU030_DTL.GetData();
                // --> End GET U030_DTL <--

                while (fleF040_OMA_FEE_MSTR.QTPForMissing("1"))
                {
                    // --> GET F040_OMA_FEE_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleU030_DTL.GetStringValue("RAT_145_SERVICE_CD")).PadRight(4).Substring(0, 1)));

                    m_strWhere.Append(" AND ").Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleU030_DTL.GetStringValue("RAT_145_SERVICE_CD")).PadRight(4).Substring(1, 1)));


                    fleF040_OMA_FEE_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F040_OMA_FEE_MSTR <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            SubFile(ref m_trnTRANS_UPDATE, ref fleMC_DTL, SubFileType.Keep, fleU030_DTL, "RAT_145_GROUP_NBR", "RAT_145_DOC_NBR", "RAT_145_SERVICE_CD", "RAT_145_AMT_PAID", fleF040_OMA_FEE_MSTR, "FEE_TECH_IND");



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
            EndRequest("EXTRACT_DTL_1");

        }

    }




    #endregion


}
//EXTRACT_DTL_1



public class U030_DTL_TECH_PROF_CREATE_TMP_RECORDS_2 : U030_DTL_TECH_PROF
{

    public U030_DTL_TECH_PROF_CREATE_TMP_RECORDS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleMC_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "MC_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        TECH_AMT = new CoreDecimal("TECH_AMT", 8, this);
        PROF_AMT = new CoreDecimal("PROF_AMT", 8, this);
        TOT_PAID_AMT = new CoreDecimal("TOT_PAID_AMT", 8, this);
        fleTMP_DOCTOR_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_DOCTOR_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        CLINIC_NBR.GetValue += CLINIC_NBR_GetValue;
        fleTMP_DOCTOR_ALPHA.SetItemFinals += fleTMP_DOCTOR_ALPHA_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U030_DTL_TECH_PROF_CREATE_TMP_RECORDS_2)"

    private SqlFileObject fleMC_DTL;
    private DCharacter CLINIC_NBR = new DCharacter("CLINIC_NBR", 2);
    private void CLINIC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleMC_DTL.GetStringValue("RAT_145_GROUP_NBR"), 1, 2);


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
    private CoreDecimal TECH_AMT;
    private CoreDecimal PROF_AMT;
    private CoreDecimal TOT_PAID_AMT;
    private SqlFileObject fleTMP_DOCTOR_ALPHA;

    private void fleTMP_DOCTOR_ALPHA_SetItemFinals()
    {

        try
        {
            fleTMP_DOCTOR_ALPHA.set_SetValue("DOC_OHIP_NBR", fleMC_DTL.GetDecimalValue("RAT_145_DOC_NBR"));
            fleTMP_DOCTOR_ALPHA.set_SetValue("DOC_NBR", " ");
            fleTMP_DOCTOR_ALPHA.set_SetValue("TMP_ALPHA_FIELD_1", CLINIC_NBR.Value);
            fleTMP_DOCTOR_ALPHA.set_SetValue("TMP_COUNTER_1", TECH_AMT.Value);
            fleTMP_DOCTOR_ALPHA.set_SetValue("TMP_COUNTER_2", PROF_AMT.Value);
            fleTMP_DOCTOR_ALPHA.set_SetValue("TMP_COUNTER_3", TOT_PAID_AMT.Value);


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


    #region "Standard Generated Procedures(U030_DTL_TECH_PROF_CREATE_TMP_RECORDS_2)"


    #region "Automatic Item Initialization(U030_DTL_TECH_PROF_CREATE_TMP_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030_DTL_TECH_PROF_CREATE_TMP_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:49 PM

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
        fleMC_DTL.Transaction = m_trnTRANS_UPDATE;
        fleTMP_DOCTOR_ALPHA.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030_DTL_TECH_PROF_CREATE_TMP_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:49 PM

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
            fleMC_DTL.Dispose();
            fleTMP_DOCTOR_ALPHA.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030_DTL_TECH_PROF_CREATE_TMP_RECORDS_2)"


    public void Run()
    {

        try
        {
            Request("CREATE_TMP_RECORDS_2");

            while (fleMC_DTL.QTPForMissing())
            {
                // --> GET MC_DTL <--

                fleMC_DTL.GetData();
                // --> End GET MC_DTL <--


                if (Transaction())
                {

                    Sort(CLINIC_NBR.Value, fleMC_DTL.GetSortValue("RAT_145_DOC_NBR"));



                }

            }

            while (Sort(fleMC_DTL))
            {
                if (QDesign.NULL(fleMC_DTL.GetStringValue("FEE_TECH_IND")) == "Y")
                {
                    TECH_AMT.Value = TECH_AMT.Value + fleMC_DTL.GetDecimalValue("RAT_145_AMT_PAID");
                }
                if (QDesign.NULL(fleMC_DTL.GetStringValue("FEE_TECH_IND")) != "Y")
                {
                    PROF_AMT.Value = PROF_AMT.Value + fleMC_DTL.GetDecimalValue("RAT_145_AMT_PAID");
                }
                TOT_PAID_AMT.Value = TOT_PAID_AMT.Value + fleMC_DTL.GetDecimalValue("RAT_145_AMT_PAID");


                fleTMP_DOCTOR_ALPHA.OutPut(OutPutType.Add, At(CLINIC_NBR) || fleMC_DTL.At("RAT_145_DOC_NBR"), null);


                Reset(ref TECH_AMT, At(CLINIC_NBR) || fleMC_DTL.At("RAT_145_DOC_NBR"));
                Reset(ref PROF_AMT, At(CLINIC_NBR) || fleMC_DTL.At("RAT_145_DOC_NBR"));
                Reset(ref TOT_PAID_AMT, At(CLINIC_NBR) || fleMC_DTL.At("RAT_145_DOC_NBR"));

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
            EndRequest("CREATE_TMP_RECORDS_2");

        }

    }




    #endregion


}
//CREATE_TMP_RECORDS_2




