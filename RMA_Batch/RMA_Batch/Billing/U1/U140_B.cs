
#region "Screen Comments"

// Program: u140_b
// Purpose: After the RA is run and f075 updated with RA payments this program
// will determine the percentage by RMA doctor number of the RA
// payments at the doctor`s OHIP number level.
// Later programs will use this percentage to split the AFP payment
// mod history
// 2004/jul/01 b.e. - originla
// 2004/aug/12 b.e. - changed `count` of doctors with same ohip number
// to count with same ohip nbr within doc-afp-paym-group 
// 2005/mar/08 M.C. - substitute afp-payment-percentage with afp-multi-doc-ra-percentage
// divide by 100000 instead of 100 because we carry 5 decimal places
// 2005/apr/08 b.e. - set lock update statement
// 2005/jun/09 M.C. - change from sorted to sort
// - change temp amount field from default to zoned*11 numeric
// 2007/feb/22 b.e. - access group flag and skip any records for groups whose
// afp group flag says `R`eport only as these doctors won`t
// won`t have any rma number and no split between those nbrs
// to calculate
// 2012/feb/22 MC1  - modify last request to link fo f020-doctor-mstr, change sort so that active doctor
// will be selected
// set lock file update


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U140_B : BaseClassControl
{

    private U140_B m_U140_B;

    public U140_B(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U140_B(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U140_B != null))
        {
            m_U140_B.CloseTransactionObjects();
            m_U140_B = null;
        }
    }

    public U140_B GetU140_B(int Level)
    {
        if (m_U140_B == null)
        {
            m_U140_B = new U140_B("U140_B", Level);
        }
        else
        {
            m_U140_B.ResetValues();
        }
        return m_U140_B;
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

            U140_B_F075_CALC_RA_TOTAL_1 F075_CALC_RA_TOTAL_1 = new U140_B_F075_CALC_RA_TOTAL_1(Name, Level);
            F075_CALC_RA_TOTAL_1.Run();
            F075_CALC_RA_TOTAL_1.Dispose();
            F075_CALC_RA_TOTAL_1 = null;

            U140_B_F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2 F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2 = new U140_B_F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2(Name, Level);
            F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2.Run();
            F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2.Dispose();
            F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2 = null;

            U140_B_F075_ENSURE_PERCENTAGE_IS_100_3 F075_ENSURE_PERCENTAGE_IS_100_3 = new U140_B_F075_ENSURE_PERCENTAGE_IS_100_3(Name, Level);
            F075_ENSURE_PERCENTAGE_IS_100_3.Run();
            F075_ENSURE_PERCENTAGE_IS_100_3.Dispose();
            F075_ENSURE_PERCENTAGE_IS_100_3 = null;

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



public class U140_B_F075_CALC_RA_TOTAL_1 : U140_B
{

    public U140_B_F075_CALC_RA_TOTAL_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
          fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_RA_TOTAL = new CoreDecimal("X_RA_TOTAL", 11, this);
        fleU140_B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF074_AFP_GROUP_MSTR.InitializeItems += fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_B_F075_CALC_RA_TOTAL_1)"

    private SqlFileObject fleF075_AFP_DOC_MSTR;
    private SqlFileObject fleF074_AFP_GROUP_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_GROUP_PROCESS_FLAG")) == "E")
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


    private CoreDecimal X_RA_TOTAL;
    private SqlFileObject fleU140_B;


    #endregion


    #region "Standard Generated Procedures(U140_B_F075_CALC_RA_TOTAL_1)"


    #region "Automatic Item Initialization(U140_B_F075_CALC_RA_TOTAL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:36 PM

    //#-----------------------------------------
    //# fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:35 PM
    //#-----------------------------------------
    private void fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF074_AFP_GROUP_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_REPORTING_MTH", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("AFP_REPORTING_MTH"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_MULTI_DOC_RA_PERCENTAGE", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT_TOTAL", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT_TOTAL"));

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


    #region "Transaction Management Procedures(U140_B_F075_CALC_RA_TOTAL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:34 PM

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
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU140_B.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_B_F075_CALC_RA_TOTAL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:35 PM

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
            fleF075_AFP_DOC_MSTR.Dispose();
            fleF074_AFP_GROUP_MSTR.Dispose();
            fleU140_B.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_B_F075_CALC_RA_TOTAL_1)"


    public void Run()
    {

        try
        {
            Request("F075_CALC_RA_TOTAL_1");

            while (fleF075_AFP_DOC_MSTR.QTPForMissing())
            {
                // --> GET F075_AFP_DOC_MSTR <--

                fleF075_AFP_DOC_MSTR.GetData();
                // --> End GET F075_AFP_DOC_MSTR <--

                while (fleF074_AFP_GROUP_MSTR.QTPForMissing("1"))
                {
                    // --> GET F074_AFP_GROUP_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));

                    fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F074_AFP_GROUP_MSTR <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleF075_AFP_DOC_MSTR.GetSortValue("DOC_OHIP_NBR"), fleF075_AFP_DOC_MSTR.GetSortValue("DOC_AFP_PAYM_GROUP"));



                        }

                    }

                }

            }

            while (Sort(fleF075_AFP_DOC_MSTR, fleF074_AFP_GROUP_MSTR))
            {
                X_RA_TOTAL.Value = X_RA_TOTAL.Value + fleF075_AFP_DOC_MSTR.GetDecimalValue("RA_PAYMENT_AMT");


                SubFile(ref m_trnTRANS_UPDATE, ref fleU140_B, fleF075_AFP_DOC_MSTR.At("DOC_OHIP_NBR") || fleF075_AFP_DOC_MSTR.At("DOC_AFP_PAYM_GROUP"), SubFileType.Keep, fleF075_AFP_DOC_MSTR, "DOC_OHIP_NBR", "DOC_AFP_PAYM_GROUP", X_RA_TOTAL);



                Reset(ref X_RA_TOTAL, fleF075_AFP_DOC_MSTR.At("DOC_OHIP_NBR") || fleF075_AFP_DOC_MSTR.At("DOC_AFP_PAYM_GROUP"));

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
            EndRequest("F075_CALC_RA_TOTAL_1");

        }

    }




    #endregion


}
//F075_CALC_RA_TOTAL_1



public class U140_B_F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2 : U140_B
{

    public U140_B_F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU140_B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU140_B_AUDIT_1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_B_AUDIT_1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
     
        X_RA_PERCENTAGE.GetValue += X_RA_PERCENTAGE_GetValue;
        fleF075_AFP_DOC_MSTR.SetItemFinals += fleF075_AFP_DOC_MSTR_SetItemFinals;
      
    }


    #region "Declarations (Variables, Files and Transactions)(U140_B_F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2)"

    private SqlFileObject fleU140_B;
    private SqlFileObject fleF075_AFP_DOC_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleU140_B.GetStringValue("DOC_AFP_PAYM_GROUP")) == QDesign.NULL(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")))
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

    private DDecimal X_RA_PERCENTAGE = new DDecimal("X_RA_PERCENTAGE", 6);
    private void X_RA_PERCENTAGE_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.Round(QDesign.Divide(fleF075_AFP_DOC_MSTR.GetDecimalValue("RA_PAYMENT_AMT") , fleU140_B.GetDecimalValue("X_RA_TOTAL")) * 100000, 0, RoundOptionTypes.Near);
                      

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

    private SqlFileObject fleU140_B_AUDIT_1;

    private void fleF075_AFP_DOC_MSTR_SetItemFinals()
    {

        try
        {
            fleF075_AFP_DOC_MSTR.set_SetValue("RA_PAYMENT_AMT_TOTAL", fleU140_B.GetDecimalValue("X_RA_TOTAL"));
            fleF075_AFP_DOC_MSTR.set_SetValue("AFP_MULTI_DOC_RA_PERCENTAGE", X_RA_PERCENTAGE.Value);


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


    #region "Standard Generated Procedures(U140_B_F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2)"


    #region "Automatic Item Initialization(U140_B_F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2)"

   



    #endregion


    #region "Transaction Management Procedures(U140_B_F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:35 PM

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
        fleU140_B.Transaction = m_trnTRANS_UPDATE;
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU140_B_AUDIT_1.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_B_F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:35 PM

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
            fleU140_B.Dispose();
            fleF075_AFP_DOC_MSTR.Dispose();
            fleU140_B_AUDIT_1.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_B_F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2)"


    public void Run()
    {

        try
        {
            Request("F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2");

            while (fleU140_B.QTPForMissing())
            {
                // --> GET U140_B <--

                fleU140_B.GetData();
                // --> End GET U140_B <--

                while (fleF075_AFP_DOC_MSTR.QTPForMissing("1"))
                {
                    // --> GET F075_AFP_DOC_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleU140_B.GetDecimalValue("DOC_OHIP_NBR")));

                    fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F075_AFP_DOC_MSTR <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            SubFile(ref m_trnTRANS_UPDATE, ref fleU140_B_AUDIT_1, SubFileType.Keep, fleU140_B, "DOC_OHIP_NBR", fleF075_AFP_DOC_MSTR, "DOC_NBR", "RA_PAYMENT_AMT", fleU140_B, "X_RA_TOTAL",
                            X_RA_PERCENTAGE);



                            fleF075_AFP_DOC_MSTR.OutPut(OutPutType.Update);


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
            EndRequest("F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2");

        }

    }




    #endregion


}
//F075_UPDATE_DOC_RECS_WITH_RA_TOTAL_2



public class U140_B_F075_ENSURE_PERCENTAGE_IS_100_3 : U140_B
{

    public U140_B_F075_ENSURE_PERCENTAGE_IS_100_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_REC_COUNT = new CoreDecimal("X_REC_COUNT", 6, this);
        X_RA_PERCENTAGE = new CoreDecimal("X_RA_PERCENTAGE", 6, this);
        fleU140_B_AUDIT_2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_B_AUDIT_2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
       
        X_TERM_DATE.GetValue += X_TERM_DATE_GetValue;
        X_FINAL_PERCENTAGE.GetValue += X_FINAL_PERCENTAGE_GetValue;
        fleF075_AFP_DOC_MSTR.SetItemFinals += fleF075_AFP_DOC_MSTR_SetItemFinals;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        

    }


    #region "Declarations (Variables, Files and Transactions)(U140_B_F075_ENSURE_PERCENTAGE_IS_100_3)"

    private SqlFileObject fleF075_AFP_DOC_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DDecimal X_TERM_DATE = new DDecimal("X_TERM_DATE");
    private void X_TERM_DATE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0')) == 0)
            {
                CurrentValue = 20991231;
            }
            else
            {
                CurrentValue = Convert.ToDecimal(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString().PadLeft(4, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString().PadLeft(2, '0') + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString().PadLeft(2, '0'));
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
    private CoreDecimal X_REC_COUNT;
    private CoreDecimal X_RA_PERCENTAGE;
    private DDecimal X_FINAL_PERCENTAGE = new DDecimal("X_FINAL_PERCENTAGE", 6);
    private void X_FINAL_PERCENTAGE_GetValue(ref decimal Value)
    {

        try
        {
            Value = 100000 - X_RA_PERCENTAGE.Value;


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

    private SqlFileObject fleU140_B_AUDIT_2;

    private void fleF075_AFP_DOC_MSTR_SetItemFinals()
    {

        try
        {
            fleF075_AFP_DOC_MSTR.set_SetValue("AFP_MULTI_DOC_RA_PERCENTAGE", X_FINAL_PERCENTAGE.Value);


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


    #region "Standard Generated Procedures(U140_B_F075_ENSURE_PERCENTAGE_IS_100_3)"


    #region "Automatic Item Initialization(U140_B_F075_ENSURE_PERCENTAGE_IS_100_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:40 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:39 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));

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


    #region "Transaction Management Procedures(U140_B_F075_ENSURE_PERCENTAGE_IS_100_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:35 PM

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
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU140_B_AUDIT_2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_B_F075_ENSURE_PERCENTAGE_IS_100_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:35 PM

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
            fleF075_AFP_DOC_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleU140_B_AUDIT_2.Dispose();

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_B_F075_ENSURE_PERCENTAGE_IS_100_3)"


    public void Run()
    {

        try
        {
            Request("F075_ENSURE_PERCENTAGE_IS_100_3");

            while (fleF075_AFP_DOC_MSTR.QTPForMissing())
            {
                // --> GET F075_AFP_DOC_MSTR <--

                fleF075_AFP_DOC_MSTR.GetData();
                // --> End GET F075_AFP_DOC_MSTR <--
             

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--


                    if (Transaction())
                    {

                        Sort(fleF075_AFP_DOC_MSTR.GetSortValue("DOC_OHIP_NBR"), fleF075_AFP_DOC_MSTR.GetSortValue("DOC_AFP_PAYM_GROUP"), X_TERM_DATE.Value, fleF075_AFP_DOC_MSTR.GetSortValue("DOC_NBR"));



                    }

                }

            }

            while (Sort(fleF075_AFP_DOC_MSTR, fleF020_DOCTOR_MSTR))
            {
              
                X_REC_COUNT.Value = X_REC_COUNT.Value + 1;
                if (QDesign.NULL(X_REC_COUNT.Value) != QDesign.NULL(fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_DUPLICATE_DOC_COUNT")))
                {
                    X_RA_PERCENTAGE.Value = X_RA_PERCENTAGE.Value + fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE");
                }
                else
                {
                    X_RA_PERCENTAGE.Value = X_RA_PERCENTAGE.Value;
                }


                SubFile(ref m_trnTRANS_UPDATE, ref fleU140_B_AUDIT_2, SubFileType.Keep, fleF075_AFP_DOC_MSTR, "DOC_OHIP_NBR", "DOC_NBR", "DOC_AFP_PAYM_GROUP", X_RA_PERCENTAGE, "AFP_MULTI_DOC_RA_PERCENTAGE", X_FINAL_PERCENTAGE,
                X_REC_COUNT, "AFP_DUPLICATE_DOC_COUNT");


             

                fleF075_AFP_DOC_MSTR.OutPut(OutPutType.Update, null, QDesign.NULL(X_REC_COUNT.Value) == QDesign.NULL(fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_DUPLICATE_DOC_COUNT")));


                Reset(ref X_REC_COUNT, fleF075_AFP_DOC_MSTR.At("DOC_OHIP_NBR") ||  fleF075_AFP_DOC_MSTR.At("DOC_AFP_PAYM_GROUP"));
                Reset(ref X_RA_PERCENTAGE, fleF075_AFP_DOC_MSTR.At("DOC_OHIP_NBR")  || fleF075_AFP_DOC_MSTR.At("DOC_AFP_PAYM_GROUP"));

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
            EndRequest("F075_ENSURE_PERCENTAGE_IS_100_3");

        }

    }




    #endregion


}
//F075_ENSURE_PERCENTAGE_IS_100_3




