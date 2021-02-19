
#region "Screen Comments"

// #> PROGRAM-ID.    newu701.qts
// ((C)) Dyad Technologies
// program purpose : transfer the manual review text records from the incoming
// flat file (transferred from the web) into the f002
// suspend description file
// MODIFICATION HISTORY
// DATE      WHO   DESCRIPTION
// 00/sep/15  B.E.  - original
// 00/sep/20  B.E.  - set manual review flag to  Y`es if any desc recs found
// 00/oct/02  B.E.  - ensured that accounting-nbr is a left justified, zero 
// filled field
// 01/mar/01  M.C.  - add a new request to select if clmhdr-status = `I`, then
// set clmdtl-status in description record to be the same
// 07/Jun/20  M.C.  - change the definition with file qualifier and output with 
// the proper alias name for desc 2 to 5
// 11/Feb/14  MC1   - Yasemin requests not to set manual review flag to  Y`es if any desc recs found
// 12/Sep/26  MC2   - add `on errors report  ` on output statement in first request
// ------------------------------------------------


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class NEWU701 : BaseClassControl
{

    private NEWU701 m_NEWU701;

    public NEWU701(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public NEWU701(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_NEWU701 != null))
        {
            m_NEWU701.CloseTransactionObjects();
            m_NEWU701 = null;
        }
    }

    public NEWU701 GetNEWU701(int Level)
    {
        if (m_NEWU701 == null)
        {
            m_NEWU701 = new NEWU701("NEWU701", Level);
        }
        else
        {
            m_NEWU701.ResetValues();
        }
        return m_NEWU701;
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

            NEWU701_1_1 N1_1 = new NEWU701_1_1(Name, Level);
            N1_1.Run();
            N1_1.Dispose();
            N1_1 = null;

            NEWU701_2_2 N2_2 = new NEWU701_2_2(Name, Level);
            N2_2.Run();
            N2_2.Dispose();
            N2_2 = null;

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



public class NEWU701_1_1 : NEWU701
{

    public NEWU701_1_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSUBMIT_DISK_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "SUBMIT_DISK_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_DESC_2 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DESC", "F002_DESC_2", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_DESC_3 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DESC", "F002_DESC_3", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_DESC_4 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DESC", "F002_DESC_4", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        X_REC_1.GetValue += X_REC_1_GetValue;
        X_REC_2.GetValue += X_REC_2_GetValue;
        X_REC_3.GetValue += X_REC_3_GetValue;
        X_REC_4.GetValue += X_REC_4_GetValue;
        X_NBR_DESC_RECS.GetValue += X_NBR_DESC_RECS_GetValue;
        X_ZERO_FILL_ACCOUNTING_NBR.GetValue += X_ZERO_FILL_ACCOUNTING_NBR_GetValue;
        fleF002_SUSPEND_DESC.SetItemFinals += fleF002_SUSPEND_DESC_SetItemFinals;
        fleF002_DESC_2.SetItemFinals += fleF002_DESC_2_SetItemFinals;
        fleF002_DESC_3.SetItemFinals += fleF002_DESC_3_SetItemFinals;
        fleF002_DESC_4.SetItemFinals += fleF002_DESC_4_SetItemFinals;
        fleF002_SUSPEND_HDR.SetItemFinals += fleF002_SUSPEND_HDR_SetItemFinals;
        fleF002_DESC_2.InitializeItems += fleF002_DESC_2_AutomaticItemInitialization;
        fleF002_DESC_3.InitializeItems += fleF002_DESC_3_AutomaticItemInitialization;
        fleF002_DESC_4.InitializeItems += fleF002_DESC_4_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU701_1_1)"

    private SqlFileObject fleSUBMIT_DISK_DESC;
    private DCharacter X_REC_1 = new DCharacter("X_REC_1", 70);
    private void X_REC_1_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleSUBMIT_DISK_DESC.GetStringValue("CLMDTL_SUSPEND_DESC_255"), 1, 70);


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
    private DCharacter X_REC_2 = new DCharacter("X_REC_2", 70);
    private void X_REC_2_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleSUBMIT_DISK_DESC.GetStringValue("CLMDTL_SUSPEND_DESC_255"), 71, 140);


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
    private DCharacter X_REC_3 = new DCharacter("X_REC_3", 70);
    private void X_REC_3_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleSUBMIT_DISK_DESC.GetStringValue("CLMDTL_SUSPEND_DESC_255"), 141, 210);


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
    private DCharacter X_REC_4 = new DCharacter("X_REC_4", 70);
    private void X_REC_4_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleSUBMIT_DISK_DESC.GetStringValue("CLMDTL_SUSPEND_DESC_255"), 211, 255);


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
    private DDecimal X_NBR_DESC_RECS = new DDecimal("X_NBR_DESC_RECS", 2);
    private void X_NBR_DESC_RECS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_REC_4.Value) != QDesign.NULL(" "))
            {
                CurrentValue = 4;
            }
            else if (QDesign.NULL(X_REC_3.Value) != QDesign.NULL(" "))
            {
                CurrentValue = 3;
            }
            else if (QDesign.NULL(X_REC_2.Value) != QDesign.NULL(" "))
            {
                CurrentValue = 2;
            }
            else if (QDesign.NULL(X_REC_1.Value) != QDesign.NULL(" "))
            {
                CurrentValue = 1;
            }
            else
            {
                CurrentValue = 0;
            }

            Value = CurrentValue;

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
    private DCharacter X_ZERO_FILL_ACCOUNTING_NBR = new DCharacter("X_ZERO_FILL_ACCOUNTING_NBR", 10);
    private void X_ZERO_FILL_ACCOUNTING_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ZeroFill(QDesign.RightJustify(fleSUBMIT_DISK_DESC.GetStringValue("CLMDTL_ACCOUNTING_NBR")));


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
    private SqlFileObject fleF002_SUSPEND_DESC;

    private void fleF002_SUSPEND_DESC_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_DOC_OHIP_NBR", fleSUBMIT_DISK_DESC.GetDecimalValue("CLMDTL_DOC_OHIP_NBR"));
            fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_ACCOUNTING_NBR", X_ZERO_FILL_ACCOUNTING_NBR.Value);
            fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_LINE_NO", 1);
            fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_SUSPEND_DESC", X_REC_1.Value);


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

    private SqlFileObject fleF002_DESC_2;

    private void fleF002_DESC_2_SetItemFinals()
    {

        try
        {
            fleF002_DESC_2.set_SetValue("CLMDTL_DOC_OHIP_NBR", fleSUBMIT_DISK_DESC.GetDecimalValue("CLMDTL_DOC_OHIP_NBR"));
            fleF002_DESC_2.set_SetValue("CLMDTL_ACCOUNTING_NBR", X_ZERO_FILL_ACCOUNTING_NBR.Value);
            fleF002_DESC_2.set_SetValue("CLMDTL_LINE_NO", 2);
            fleF002_DESC_2.set_SetValue("CLMDTL_SUSPEND_DESC", X_REC_2.Value);


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

    private SqlFileObject fleF002_DESC_3;

    private void fleF002_DESC_3_SetItemFinals()
    {

        try
        {
            fleF002_DESC_3.set_SetValue("CLMDTL_DOC_OHIP_NBR", fleSUBMIT_DISK_DESC.GetDecimalValue("CLMDTL_DOC_OHIP_NBR"));
            fleF002_DESC_3.set_SetValue("CLMDTL_ACCOUNTING_NBR", X_ZERO_FILL_ACCOUNTING_NBR.Value);
            fleF002_DESC_3.set_SetValue("CLMDTL_LINE_NO", 3);
            fleF002_DESC_3.set_SetValue("CLMDTL_SUSPEND_DESC", X_REC_3.Value);


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

    private SqlFileObject fleF002_DESC_4;

    private void fleF002_DESC_4_SetItemFinals()
    {

        try
        {
            fleF002_DESC_4.set_SetValue("CLMDTL_DOC_OHIP_NBR", fleSUBMIT_DISK_DESC.GetDecimalValue("CLMDTL_DOC_OHIP_NBR"));
            fleF002_DESC_4.set_SetValue("CLMDTL_ACCOUNTING_NBR", X_ZERO_FILL_ACCOUNTING_NBR.Value);
            fleF002_DESC_4.set_SetValue("CLMDTL_LINE_NO", 4);
            fleF002_DESC_4.set_SetValue("CLMDTL_SUSPEND_DESC", X_REC_4.Value);


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

    private SqlFileObject fleF002_SUSPEND_HDR;

    private void fleF002_SUSPEND_HDR_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_NBR_SUSPEND_DESC_RECS", X_NBR_DESC_RECS.Value);


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


    #region "Standard Generated Procedures(NEWU701_1_1)"


    #region "Automatic Item Initialization(NEWU701_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:12 PM

    //#-----------------------------------------
    //# fleF002_DESC_2_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:04:11 PM
    //#-----------------------------------------
    private void fleF002_DESC_2_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF002_DESC_2.set_SetValue("CLMDTL_SUSPEND_DESC", !Fixed, fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_SUSPEND_DESC"));
            fleF002_DESC_2.set_SetValue("CLMDTL_STATUS", !Fixed, fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_STATUS"));
            fleF002_DESC_2.set_SetValue("CLMDTL_DOC_OHIP_NBR", !Fixed, fleF002_SUSPEND_DESC.GetDecimalValue("CLMDTL_DOC_OHIP_NBR"));
            fleF002_DESC_2.set_SetValue("CLMDTL_ACCOUNTING_NBR", !Fixed, fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_ACCOUNTING_NBR"));
            fleF002_DESC_2.set_SetValue("CLMDTL_LINE_NO", !Fixed, fleF002_SUSPEND_DESC.GetDecimalValue("CLMDTL_LINE_NO"));

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
    //# fleF002_DESC_3_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:04:11 PM
    //#-----------------------------------------
    private void fleF002_DESC_3_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF002_DESC_3.set_SetValue("CLMDTL_SUSPEND_DESC", !Fixed, fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_SUSPEND_DESC"));
            fleF002_DESC_3.set_SetValue("CLMDTL_STATUS", !Fixed, fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_STATUS"));
            fleF002_DESC_3.set_SetValue("CLMDTL_DOC_OHIP_NBR", !Fixed, fleF002_SUSPEND_DESC.GetDecimalValue("CLMDTL_DOC_OHIP_NBR"));
            fleF002_DESC_3.set_SetValue("CLMDTL_ACCOUNTING_NBR", !Fixed, fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_ACCOUNTING_NBR"));
            fleF002_DESC_3.set_SetValue("CLMDTL_LINE_NO", !Fixed, fleF002_SUSPEND_DESC.GetDecimalValue("CLMDTL_LINE_NO"));

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
    //# fleF002_DESC_4_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:04:12 PM
    //#-----------------------------------------
    private void fleF002_DESC_4_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF002_DESC_4.set_SetValue("CLMDTL_SUSPEND_DESC", !Fixed, fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_SUSPEND_DESC"));
            fleF002_DESC_4.set_SetValue("CLMDTL_STATUS", !Fixed, fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_STATUS"));
            fleF002_DESC_4.set_SetValue("CLMDTL_DOC_OHIP_NBR", !Fixed, fleF002_SUSPEND_DESC.GetDecimalValue("CLMDTL_DOC_OHIP_NBR"));
            fleF002_DESC_4.set_SetValue("CLMDTL_ACCOUNTING_NBR", !Fixed, fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_ACCOUNTING_NBR"));
            fleF002_DESC_4.set_SetValue("CLMDTL_LINE_NO", !Fixed, fleF002_SUSPEND_DESC.GetDecimalValue("CLMDTL_LINE_NO"));

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


    #region "Transaction Management Procedures(NEWU701_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:09 PM

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
        fleSUBMIT_DISK_DESC.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DESC.Transaction = m_trnTRANS_UPDATE;
        fleF002_DESC_2.Transaction = m_trnTRANS_UPDATE;
        fleF002_DESC_3.Transaction = m_trnTRANS_UPDATE;
        fleF002_DESC_4.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU701_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:09 PM

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
            fleSUBMIT_DISK_DESC.Dispose();
            fleF002_SUSPEND_DESC.Dispose();
            fleF002_DESC_2.Dispose();
            fleF002_DESC_3.Dispose();
            fleF002_DESC_4.Dispose();
            fleF002_SUSPEND_HDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU701_1_1)"


    public void Run()
    {

        try
        {
            Request("1_1");

            while (fleSUBMIT_DISK_DESC.QTPForMissing())
            {
                // --> GET SUBMIT_DISK_DESC <--

                fleSUBMIT_DISK_DESC.GetData();
                // --> End GET SUBMIT_DISK_DESC <--


                if (Transaction())
                {
                    fleF002_SUSPEND_DESC.OutPut(OutPutType.Add, null, QDesign.NULL(X_NBR_DESC_RECS.Value) > 0);


                    fleF002_DESC_2.OutPut(OutPutType.Add, null, QDesign.NULL(X_NBR_DESC_RECS.Value) > 1);


                    fleF002_DESC_3.OutPut(OutPutType.Add, null, QDesign.NULL(X_NBR_DESC_RECS.Value) > 2);


                    fleF002_DESC_4.OutPut(OutPutType.Add, null, QDesign.NULL(X_NBR_DESC_RECS.Value) > 3);


                    while (fleF002_SUSPEND_HDR.QTPForMissing())
                    {
                        // --> GET F002_SUSPEND_HDR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR")).Append(" = ");
                        m_strWhere.Append((fleSUBMIT_DISK_DESC.GetDecimalValue("CLMDTL_DOC_OHIP_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(X_ZERO_FILL_ACCOUNTING_NBR.Value));

                        m_strOrderBy = new StringBuilder(" ORDER BY ");
                        m_strOrderBy.Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR"));
                        m_strOrderBy.Append(", ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR"));

                        fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                        // --> End GET F002_SUSPEND_HDR <--


                        fleF002_SUSPEND_HDR.OutPut(OutPutType.Update);

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
            EndRequest("1_1");

        }

    }







    #endregion


}
//1_1



public class NEWU701_2_2 : NEWU701
{

    public NEWU701_2_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_SUSPEND_DESC.SetItemFinals += fleF002_SUSPEND_DESC_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(NEWU701_2_2)"

    private SqlFileObject fleF002_SUSPEND_DESC;

    private void fleF002_SUSPEND_DESC_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_STATUS", "I");


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

    private SqlFileObject fleF002_SUSPEND_HDR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == "I")
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


    #region "Standard Generated Procedures(NEWU701_2_2)"


    #region "Automatic Item Initialization(NEWU701_2_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(NEWU701_2_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:09 PM

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
        fleF002_SUSPEND_DESC.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(NEWU701_2_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:09 PM

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
            fleF002_SUSPEND_DESC.Dispose();
            fleF002_SUSPEND_HDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(NEWU701_2_2)"


    public void Run()
    {

        try
        {
            Request("2_2");

            while (fleF002_SUSPEND_DESC.QTPForMissing())
            {
                // --> GET F002_SUSPEND_DESC <--

                fleF002_SUSPEND_DESC.GetData();
                // --> End GET F002_SUSPEND_DESC <--

                while (fleF002_SUSPEND_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_SUSPEND_DESC.GetDecimalValue("CLMDTL_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_HDR <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {
                            fleF002_SUSPEND_DESC.OutPut(OutPutType.Update);

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
            EndRequest("2_2");

        }

    }







    #endregion


}
//2_2




