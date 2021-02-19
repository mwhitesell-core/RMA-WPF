
#region "Screen Comments"

// 2013/Aug/28 - MC - original  
// fixed the records for difference that are generated from check_f001_f002_all.qzs
// 2014/Aug/18 - MC1 - add on calculation and edit on errors report in 3 requests
// - correct accordingly 
// MC1
// request one  


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class FIX_F001_F002_ALL : BaseClassControl
{

    private FIX_F001_F002_ALL m_FIX_F001_F002_ALL;

    public FIX_F001_F002_ALL(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public FIX_F001_F002_ALL(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_FIX_F001_F002_ALL != null))
        {
            m_FIX_F001_F002_ALL.CloseTransactionObjects();
            m_FIX_F001_F002_ALL = null;
        }
    }

    public FIX_F001_F002_ALL GetFIX_F001_F002_ALL(int Level)
    {
        if (m_FIX_F001_F002_ALL == null)
        {
            m_FIX_F001_F002_ALL = new FIX_F001_F002_ALL("FIX_F001_F002_ALL", Level);
        }
        else
        {
            m_FIX_F001_F002_ALL.ResetValues();
        }
        return m_FIX_F001_F002_ALL;
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

            FIX_F001_F002_ALL_ONE_1 ONE_1 = new FIX_F001_F002_ALL_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            FIX_F001_F002_ALL_TWO_2 TWO_2 = new FIX_F001_F002_ALL_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

            FIX_F001_F002_ALL_THREE_3 THREE_3 = new FIX_F001_F002_ALL_THREE_3(Name, Level);
            THREE_3.Run();
            THREE_3.Dispose();
            THREE_3 = null;

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



public class FIX_F001_F002_ALL_ONE_1 : FIX_F001_F002_ALL
{

    public FIX_F001_F002_ALL_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleEXTF002HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF002HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF001_BATCH_CONTROL_FILE.SetItemFinals += fleF001_BATCH_CONTROL_FILE_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(FIX_F001_F002_ALL_ONE_1)"

    private SqlFileObject fleEXTF002HDR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleEXTF002HDR.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("XCOUNT")) | QDesign.NULL(fleEXTF002HDR.GetDecimalValue("BATCTRL_LAST_CLAIM_NBR")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("KEY_CLM_CLAIM_NBR")) | (QDesign.NULL(fleEXTF002HDR.GetDecimalValue("BATCTRL_CALC_TOT_REV")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) & QDesign.NULL(fleEXTF002HDR.GetStringValue("BATCTRL_BATCH_TYPE")) == "C") | (QDesign.NULL(fleEXTF002HDR.GetDecimalValue("BATCTRL_CALC_TOT_REV")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) & (QDesign.NULL(fleEXTF002HDR.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleEXTF002HDR.GetStringValue("BATCTRL_ADJ_CD")) != "A")) | (QDesign.NULL(fleEXTF002HDR.GetDecimalValue("BATCTRL_CALC_AR_DUE")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) & QDesign.NULL(fleEXTF002HDR.GetStringValue("BATCTRL_BATCH_TYPE")) == "C") | (QDesign.NULL(fleEXTF002HDR.GetDecimalValue("BATCTRL_CALC_AR_DUE")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) & (QDesign.NULL(fleEXTF002HDR.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleEXTF002HDR.GetStringValue("BATCTRL_ADJ_CD")) == "A")) | (QDesign.NULL(fleEXTF002HDR.GetDecimalValue("BATCTRL_MANUAL_PAY_TOT")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS")) & QDesign.NULL(fleEXTF002HDR.GetStringValue("BATCTRL_BATCH_TYPE")) == "P") | QDesign.NULL(fleEXTF002HDR.GetDecimalValue("BATCTRL_AMT_ACT")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("BATCTRL_AMT_EST")))
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

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_SetItemFinals()
    {

        try
        {
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_LAST_CLAIM_NBR")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("KEY_CLM_CLAIM_NBR")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_LAST_CLAIM_NBR", fleEXTF002HDR.GetDecimalValue("KEY_CLM_CLAIM_NBR"));
            }
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("XCOUNT")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_NBR_CLAIMS_IN_BATCH", fleEXTF002HDR.GetDecimalValue("XCOUNT"));
            }
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT")) != QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_EST")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT"));
            }
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_EST")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_EST", fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));
            }
            if ((QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_TOT_REV")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "C") | (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_TOT_REV")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) & (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD")) != "A")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CALC_TOT_REV", fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));
            }
            if ((QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "C") | (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) & (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD")) == "A")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CALC_AR_DUE", fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));
            }
            if ((QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_MANUAL_PAY_TOT")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS")) & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "P"))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_MANUAL_PAY_TOT", fleEXTF002HDR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS"));
            }
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_ACT", fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));
            }
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT")) != QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_EST")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT"));
            }
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_EST")) != QDesign.NULL(fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_EST", fleEXTF002HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));
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




    #endregion


    #region "Standard Generated Procedures(FIX_F001_F002_ALL_ONE_1)"


    #region "Automatic Item Initialization(FIX_F001_F002_ALL_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(FIX_F001_F002_ALL_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:52 PM

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
        fleEXTF002HDR.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(FIX_F001_F002_ALL_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:52 PM

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
            fleEXTF002HDR.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(FIX_F001_F002_ALL_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleEXTF002HDR.QTPForMissing())
            {
                // --> GET EXTF002HDR <--

                fleEXTF002HDR.GetData();
                // --> End GET EXTF002HDR <--

                if (Transaction())
                {

                     if (Select_If())
                    {
                        while (fleF001_BATCH_CONTROL_FILE.QTPForMissing())
                        {
                            // --> GET F001_BATCH_CONTROL_FILE <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleEXTF002HDR.GetStringValue("BATCTRL_BATCH_NBR")));

                            fleF001_BATCH_CONTROL_FILE.GetData(m_strWhere.ToString());
                            // --> End GET F001_BATCH_CONTROL_FILE <--


                            fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Update);

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
            EndRequest("ONE_1");

        }

    }







    #endregion


}
//ONE_1



public class FIX_F001_F002_ALL_TWO_2 : FIX_F001_F002_ALL
{

    public FIX_F001_F002_ALL_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleEXTF002DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF002DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF001_BATCH_CONTROL_FILE.SetItemFinals += fleF001_BATCH_CONTROL_FILE_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(FIX_F001_F002_ALL_TWO_2)"

    private SqlFileObject fleEXTF002DTL;
    public override bool SelectIf()
    {


        try
        {
            if ((QDesign.NULL(fleEXTF002DTL.GetDecimalValue("BATCTRL_CALC_TOT_REV")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & QDesign.NULL(fleEXTF002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "C") | (QDesign.NULL(fleEXTF002DTL.GetDecimalValue("BATCTRL_CALC_TOT_REV")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & (QDesign.NULL(fleEXTF002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleEXTF002DTL.GetStringValue("BATCTRL_ADJ_CD")) != "A")) | (QDesign.NULL(fleEXTF002DTL.GetDecimalValue("BATCTRL_CALC_AR_DUE")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & QDesign.NULL(fleEXTF002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "C") | (QDesign.NULL(fleEXTF002DTL.GetDecimalValue("BATCTRL_CALC_AR_DUE")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & (QDesign.NULL(fleEXTF002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleEXTF002DTL.GetStringValue("BATCTRL_ADJ_CD")) == "A")) | (QDesign.NULL(fleEXTF002DTL.GetDecimalValue("BATCTRL_MANUAL_PAY_TOT")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & QDesign.NULL(fleEXTF002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P") | QDesign.NULL(fleEXTF002DTL.GetDecimalValue("BATCTRL_SVC_ACT")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("TOT_SVC")))
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

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_SetItemFinals()
    {

        try
        {
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_ACT")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("TOT_SVC")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_SVC_ACT", fleEXTF002DTL.GetDecimalValue("TOT_SVC"));
            }
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_EST")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("TOT_SVC")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_SVC_EST", fleEXTF002DTL.GetDecimalValue("TOT_SVC"));
            }
            if ((QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_TOT_REV")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "C") | (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_TOT_REV")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD")) != "A")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CALC_TOT_REV", fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
            }
            if ((QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "C") | (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD")) == "A")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CALC_AR_DUE", fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
            }
            if ((QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_MANUAL_PAY_TOT")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "P"))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_MANUAL_PAY_TOT", fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
            }
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_ACT", fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
            }
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_EST")) != QDesign.NULL(fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP")))
            {
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_EST", fleEXTF002DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
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




    #endregion


    #region "Standard Generated Procedures(FIX_F001_F002_ALL_TWO_2)"


    #region "Automatic Item Initialization(FIX_F001_F002_ALL_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(FIX_F001_F002_ALL_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:52 PM

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
        fleEXTF002DTL.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(FIX_F001_F002_ALL_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:52 PM

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
            fleEXTF002DTL.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(FIX_F001_F002_ALL_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleEXTF002DTL.QTPForMissing())
            {
                // --> GET EXTF002DTL <--

                fleEXTF002DTL.GetData();
                // --> End GET EXTF002DTL <--

                if (Transaction())
                {

                     if (Select_If())
                    {
                        while (fleF001_BATCH_CONTROL_FILE.QTPForMissing())
                        {
                            // --> GET F001_BATCH_CONTROL_FILE <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleEXTF002DTL.GetStringValue("BATCTRL_BATCH_NBR")));

                            fleF001_BATCH_CONTROL_FILE.GetData(m_strWhere.ToString());
                            // --> End GET F001_BATCH_CONTROL_FILE <--


                            fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Update);

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
            EndRequest("TWO_2");

        }

    }







    #endregion


}
//TWO_2



public class FIX_F001_F002_ALL_THREE_3 : FIX_F001_F002_ALL
{

    public FIX_F001_F002_ALL_THREE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleEXTF002HDRDTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF002HDRDTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(FIX_F001_F002_ALL_THREE_3)"

    private SqlFileObject fleEXTF002HDRDTL;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            if ((QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) != QDesign.NULL(fleEXTF002HDRDTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "C") | (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) != QDesign.NULL(fleEXTF002HDRDTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & (QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_ADJ_CD")) != "A")) | (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) != QDesign.NULL(fleEXTF002HDRDTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & (QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_ADJ_CD")) == "A")))
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", fleEXTF002HDRDTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
            }
            if ((QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS")) != QDesign.NULL(fleEXTF002HDRDTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P"))
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", fleEXTF002HDRDTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
            }
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));


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
            if ((QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) != QDesign.NULL(fleEXTF002HDRDTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "C") | (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) != QDesign.NULL(fleEXTF002HDRDTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & (QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_ADJ_CD")) != "A")) | (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) != QDesign.NULL(fleEXTF002HDRDTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & (QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_ADJ_CD")) == "A")) | (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS")) != QDesign.NULL(fleEXTF002HDRDTL.GetDecimalValue("CLMDTL_FEE_OHIP")) & QDesign.NULL(fleEXTF002HDRDTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P"))
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


    #region "Standard Generated Procedures(FIX_F001_F002_ALL_THREE_3)"


    #region "Automatic Item Initialization(FIX_F001_F002_ALL_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(FIX_F001_F002_ALL_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:52 PM

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
        fleEXTF002HDRDTL.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(FIX_F001_F002_ALL_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:52 PM

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
            fleEXTF002HDRDTL.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(FIX_F001_F002_ALL_THREE_3)"


    public void Run()
    {

        try
        {
            Request("THREE_3");

            while (fleEXTF002HDRDTL.QTPForMissing())
            {
                // --> GET EXTF002HDRDTL <--

                fleEXTF002HDRDTL.GetData();
                // --> End GET EXTF002HDRDTL <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_CLAIMS_MSTR.GetDecimalValue("KEY_CLM_CLAIM_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {
                            fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update);

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
            EndRequest("THREE_3");

        }

    }







    #endregion


}
//THREE_3




