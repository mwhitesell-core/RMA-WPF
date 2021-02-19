
#region "Screen Comments"



#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class EMERG_DEPT_41_42_44_BYMONTH : BaseClassControl
{

    private EMERG_DEPT_41_42_44_BYMONTH m_EMERG_DEPT_41_42_44_BYMONTH;

    public EMERG_DEPT_41_42_44_BYMONTH(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public EMERG_DEPT_41_42_44_BYMONTH(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_EMERG_DEPT_41_42_44_BYMONTH != null))
        {
            m_EMERG_DEPT_41_42_44_BYMONTH.CloseTransactionObjects();
            m_EMERG_DEPT_41_42_44_BYMONTH = null;
        }
    }

    public EMERG_DEPT_41_42_44_BYMONTH GetEMERG_DEPT_41_42_44_BYMONTH(int Level)
    {
        if (m_EMERG_DEPT_41_42_44_BYMONTH == null)
        {
            m_EMERG_DEPT_41_42_44_BYMONTH = new EMERG_DEPT_41_42_44_BYMONTH("EMERG_DEPT_41_42_44_BYMONTH", Level);
        }
        else
        {
            m_EMERG_DEPT_41_42_44_BYMONTH.ResetValues();
        }
        return m_EMERG_DEPT_41_42_44_BYMONTH;
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

            EMERG_DEPT_41_42_44_BYMONTH_ONE_1 ONE_1 = new EMERG_DEPT_41_42_44_BYMONTH_ONE_1(Name, Level);
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



public class EMERG_DEPT_41_42_44_BYMONTH_ONE_1 : EMERG_DEPT_41_42_44_BYMONTH
{

    public EMERG_DEPT_41_42_44_BYMONTH_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleEMR441 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EMR441", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_JUL_10 = new CoreDecimal("X_JUL_10", 7, this);
        X_AUG_10 = new CoreDecimal("X_AUG_10", 7, this);
        X_SEP_10 = new CoreDecimal("X_SEP_10", 7, this);
        X_OCT_10 = new CoreDecimal("X_OCT_10", 7, this);
        X_NOV_10 = new CoreDecimal("X_NOV_10", 7, this);
        X_DEC_10 = new CoreDecimal("X_DEC_10", 7, this);
        X_JAN_11 = new CoreDecimal("X_JAN_11", 7, this);
        X_FEB_11 = new CoreDecimal("X_FEB_11", 7, this);
        X_MAR_11 = new CoreDecimal("X_MAR_11", 7, this);
        X_APR_11 = new CoreDecimal("X_APR_11", 7, this);
        X_MAY_11 = new CoreDecimal("X_MAY_11", 7, this);
        X_JUN_11 = new CoreDecimal("X_JUN_11", 7, this);
        X_JUL_11 = new CoreDecimal("X_JUL_11", 7, this);
        X_AUG_11 = new CoreDecimal("X_AUG_11", 7, this);
        X_SEP_11 = new CoreDecimal("X_SEP_11", 7, this);
        X_OCT_11 = new CoreDecimal("X_OCT_11", 7, this);
        X_NOV_11 = new CoreDecimal("X_NOV_11", 7, this);
        X_DEC_11 = new CoreDecimal("X_DEC_11", 7, this);
        fleEMR442MONTH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EMR442MONTH", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_CLINIC.GetValue += X_CLINIC_GetValue;
        X_DOC.GetValue += X_DOC_GetValue;
        X_YYYYMM.GetValue += X_YYYYMM_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(EMERG_DEPT_41_42_44_BYMONTH_ONE_1)"

    private SqlFileObject fleEMR441;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DCharacter X_CLINIC = new DCharacter("X_CLINIC", 2);
    private void X_CLINIC_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleEMR441.GetStringValue("CLMDTL_ID"), 1, 2);


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
    private DCharacter X_DOC = new DCharacter("X_DOC", 3);
    private void X_DOC_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleEMR441.GetStringValue("CLMDTL_ID"), 3, 3);


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
    private DCharacter X_YYYYMM = new DCharacter("X_YYYYMM", 6);
    private void X_YYYYMM_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleEMR441.GetStringValue("X_SV_DATE_1"), 1, 6);


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
    private CoreDecimal X_JUL_10;
    private CoreDecimal X_AUG_10;
    private CoreDecimal X_SEP_10;
    private CoreDecimal X_OCT_10;
    private CoreDecimal X_NOV_10;
    private CoreDecimal X_DEC_10;
    private CoreDecimal X_JAN_11;
    private CoreDecimal X_FEB_11;
    private CoreDecimal X_MAR_11;
    private CoreDecimal X_APR_11;
    private CoreDecimal X_MAY_11;
    private CoreDecimal X_JUN_11;
    private CoreDecimal X_JUL_11;
    private CoreDecimal X_AUG_11;
    private CoreDecimal X_SEP_11;
    private CoreDecimal X_OCT_11;
    private CoreDecimal X_NOV_11;
    private CoreDecimal X_DEC_11;
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
    private SqlFileObject fleEMR442MONTH;


    #endregion


    #region "Standard Generated Procedures(EMERG_DEPT_41_42_44_BYMONTH_ONE_1)"


    #region "Automatic Item Initialization(EMERG_DEPT_41_42_44_BYMONTH_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERG_DEPT_41_42_44_BYMONTH_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:47 PM

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
        fleEMR441.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleEMR442MONTH.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERG_DEPT_41_42_44_BYMONTH_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:47 PM

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
            fleEMR441.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleEMR442MONTH.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERG_DEPT_41_42_44_BYMONTH_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleEMR441.QTPForMissing())
            {
                // --> GET EMR441 <--

                fleEMR441.GetData();
                // --> End GET EMR441 <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleEMR441.GetStringValue("CLMDTL_ID"), 3, 3)));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                        Sort(fleF020_DOCTOR_MSTR.GetSortValue("DOC_DEPT"));



                    }

                }

            }

            while (Sort(fleEMR441, fleF020_DOCTOR_MSTR))
            {
                if (QDesign.NULL(X_YYYYMM.Value) == "201007")
                {
                    X_JUL_10.Value = X_JUL_10.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201008")
                {
                    X_AUG_10.Value = X_AUG_10.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201009")
                {
                    X_SEP_10.Value = X_SEP_10.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201010")
                {
                    X_OCT_10.Value = X_OCT_10.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201011")
                {
                    X_NOV_10.Value = X_NOV_10.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201012")
                {
                    X_DEC_10.Value = X_DEC_10.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201101")
                {
                    X_JAN_11.Value = X_JAN_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201102")
                {
                    X_FEB_11.Value = X_FEB_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201103")
                {
                    X_MAR_11.Value = X_MAR_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201104")
                {
                    X_APR_11.Value = X_APR_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201105")
                {
                    X_MAY_11.Value = X_MAY_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201106")
                {
                    X_JUN_11.Value = X_JUN_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201107")
                {
                    X_JUL_11.Value = X_JUL_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201108")
                {
                    X_AUG_11.Value = X_AUG_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201109")
                {
                    X_SEP_11.Value = X_SEP_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201110")
                {
                    X_OCT_11.Value = X_OCT_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201111")
                {
                    X_NOV_11.Value = X_NOV_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }
                if (QDesign.NULL(X_YYYYMM.Value) == "201112")
                {
                    X_DEC_11.Value = X_DEC_11.Value + fleEMR441.GetDecimalValue("X_CLMDTL_FEE_OHIP_1") / 100;
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleEMR442MONTH, fleF020_DOCTOR_MSTR.At("DOC_DEPT"), SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_DEPT", COMMA, X_JUL_10, X_AUG_10, X_SEP_10,
                X_OCT_10, X_NOV_10, X_DEC_10, X_JAN_11, X_FEB_11, X_MAR_11, X_APR_11, X_MAY_11, X_JUN_11, X_JUL_11,
                X_AUG_11, X_SEP_11, X_OCT_11, X_NOV_11, X_DEC_11, X_CR);


                Reset(ref X_JUL_10, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_AUG_10, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_SEP_10, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_OCT_10, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_NOV_10, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_DEC_10, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_JAN_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_FEB_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_MAR_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_APR_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_MAY_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_JUN_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_JUL_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_AUG_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_SEP_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_OCT_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_NOV_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));
                Reset(ref X_DEC_11, fleF020_DOCTOR_MSTR.At("DOC_DEPT"));

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




