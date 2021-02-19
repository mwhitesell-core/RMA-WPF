
#region "Screen Comments"

// #> PROGRAM         U100.QTS  
// ((C)) Dyad Technologies
// PURPOSE: Verify there is a primary doctor assigned either for a single or multliple doctor
// that belong to the same doc ohip nbr  
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 2008/jun/18 M.C.      - original  
// 2009/may/19 MC1 - set doc-count to include the doctor is active in criteria
// 2009/oct/05 MC2     - add the second request to check for blank doc-paym-group
// 2011/nov/29 MC3     - add the third  request to check for blank record in f112-pycdceilings
// - modify select in second request
// 2012/Feb/13 MC4       - add the `optional` to the access statement in the first request, so that
// if f020-doctor-extra record does not exist will be included
// 2012/Dec/20 MC5 - pass the payroll flag as part of the selection, payroll A = 101c, payroll + = solo
// 2013/Dec/11 MC6 - include clinic 23, 24 & 25 in the selection - same as in u110_rma_1.qts
// 2014/Feb/11 MC7       - include dept and term date in the subfile
// 2014/Oct/14 MC8 - comment out the first request for checking primary flag because it has transferred to u100_b.qzs
// 2013/Dec/11 MC9 - include clinic 26 in the selection - same as in u110_rma_1.qts
// -------------------------------------------------------------------------------
// MC8
// ;request u100_search_primary_doctor      &
// ;  on edit        errors report &
// ;                on calculation errors report
// ;access f020-doctor-mstr    &
// ; link doc-nbr     &
// 2012/02/13 - MC4
// to  doc-nbr of f020-doctor-extra 
// ;   to  doc-nbr of f020-doctor-extra  optional
// 2012/02/13 -end
// ;choose doc-ohip-nbr
// 2012/12/20 - MC5
// ;def payroll-flag char*1 = parm prompt `Enter Payroll (A = 101c, + = solo): `
// 2012/12/20 - end
// ;sorted on doc-ohip-nbr
// select active doctors only
// sel if   doc-date-fac-term = 0  &
// 2012/12/20 - MC5 - add the payroll-flag check with selection condition
// ;sel if                           &
// ;      (    (   (doc-dept = 4)   &
// ;     or (    (    doc-dept = 14          &
// ;        or doc-dept = 15  &
// ;      )    &
// ;          and doc-afp-paym-group = `H111` &
// ;        )    &
// ;           )     &
// ;       and payroll-flag = `A`   &
// ;      )      &
// ;   or (    (    doc-dept = 31   &
// ;     and doc-afp-paym-group = `H132`  &
// ;           )      &
// ;       and payroll-flag = `C`   &
// ;      ) 
// 2012/12/20 - end
// ;temp doc-count 
// 2009/may/19 - MC1
// item doc-count = doc-count + 1 if doc-flag-primary = `Y`  reset at doc-ohip-nbr
// ;item doc-count = doc-count + 1 if doc-flag-primary = `Y` &
// ;               and  doc-date-fac-term = 0  &
// ;   reset at doc-ohip-nbr
// 2009/may/19 - end
// ;subfile u100_prim_doc keep at doc-ohip-nbr include &
// 2012/12/20 - MC5 - include payroll-flag
// doc-ohip-nbr, doc-count
// ; doc-ohip-nbr, doc-count, payroll-flag          
// 2012/12/20 - end
// -------------------------------------------------------------------------------
// 2009/10/05 - MC2 - add new request


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;



public class U100 : BaseClassControl
{

    private U100 m_U100;

    public U100(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U100(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U100 != null))
        {
            m_U100.CloseTransactionObjects();
            m_U100 = null;
        }
    }

    public U100 GetU100(int Level)
    {
        if (m_U100 == null)
        {
            m_U100 = new U100("U100", Level);
        }
        else
        {
            m_U100.ResetValues();
        }
        return m_U100;
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

            U100_SEARCH_BLANK_PAYM_GROUP_1 SEARCH_BLANK_PAYM_GROUP_1 = new U100_SEARCH_BLANK_PAYM_GROUP_1(Name, Level);
            SEARCH_BLANK_PAYM_GROUP_1.Run();
            SEARCH_BLANK_PAYM_GROUP_1.Dispose();
            SEARCH_BLANK_PAYM_GROUP_1 = null;

            U100_SEARCH_BLANK_F112_RECORD_2 SEARCH_BLANK_F112_RECORD_2 = new U100_SEARCH_BLANK_F112_RECORD_2(Name, Level);
            SEARCH_BLANK_F112_RECORD_2.Run();
            SEARCH_BLANK_F112_RECORD_2.Dispose();
            SEARCH_BLANK_F112_RECORD_2 = null;

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



public class U100_SEARCH_BLANK_PAYM_GROUP_1 : U100
{

    public U100_SEARCH_BLANK_PAYM_GROUP_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU100_BLANK_PAYM_GRP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U100_BLANK_PAYM_GRP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        DOC_DATE_FAC_TERM.GetValue += DOC_DATE_FAC_TERM_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(U100_SEARCH_BLANK_PAYM_GROUP_1)"

    private SqlFileObject fleF050_DOC_REVENUE_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) == QDesign.NULL(" ") & (string.Compare(QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")), "71") < 0 | string.Compare(QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")), "75") > 0) & (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC")) != 0 | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC")) != 0))
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




    private SqlFileObject fleU100_BLANK_PAYM_GRP;

    private DDecimal DOC_DATE_FAC_TERM = new DDecimal("DOC_DATE_FAC_TERM", 8);
    private void DOC_DATE_FAC_TERM_GetValue(ref decimal Value)
    {
        try
        {
            Value = QDesign.NConvert(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString() + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString() + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString());
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


    #region "Standard Generated Procedures(U100_SEARCH_BLANK_PAYM_GROUP_1)"


    #region "Automatic Item Initialization(U100_SEARCH_BLANK_PAYM_GROUP_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U100_SEARCH_BLANK_PAYM_GROUP_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:27:56 PM

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
        fleF050_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleU100_BLANK_PAYM_GRP.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U100_SEARCH_BLANK_PAYM_GROUP_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:27:56 PM

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
            fleF050_DOC_REVENUE_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleU100_BLANK_PAYM_GRP.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U100_SEARCH_BLANK_PAYM_GROUP_1)"


    public void Run()
    {

        try
        {
            Request("SEARCH_BLANK_PAYM_GROUP_1");

            while (fleF050_DOC_REVENUE_MSTR.QTPForMissing())
            {
                // --> GET F050_DOC_REVENUE_MSTR <--

                fleF050_DOC_REVENUE_MSTR.GetData();
                // --> End GET F050_DOC_REVENUE_MSTR <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleICONST_MSTR_REC.QTPForMissing("2"))
                    {
                        // --> GET ICONST_MSTR_REC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2"))));

                        fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                        // --> End GET ICONST_MSTR_REC <--

                        if (Transaction())
                        {
                             if (Select_If())
                            {
                                SubFile(ref m_trnTRANS_UPDATE, ref fleU100_BLANK_PAYM_GRP, SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_NBR", "DOC_OHIP_NBR", "DOC_DEPT", "DOC_NAME", DOC_DATE_FAC_TERM, fleF050_DOC_REVENUE_MSTR,
                                "DOCREV_CLINIC_1_2", "DOCREV_DEPT", "DOCREV_DOC_NBR", "DOCREV_LOCATION", "DOCREV_OMA_CODE", "DOCREV_OMA_SUFF",  "DOCREV_MTD_IN_REC", "DOCREV_MTD_OUT_REC");
                            }
                        }
                    }
                }
            }

            string subfilePath = Directory.GetCurrentDirectory();

            if (!subfilePath.EndsWith("\\"))
                subfilePath = subfilePath + "\\";

            if (!File.Exists(subfilePath + "U100_BLANK_PAYM_GRP.sf"))
            {
                //Create an empty subfile
                SubFile("U100_BLANK_PAYM_GRP", SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_NBR", "DOC_OHIP_NBR", "DOC_DEPT", "DOC_NAME", DOC_DATE_FAC_TERM, fleF050_DOC_REVENUE_MSTR,
                "DOCREV_CLINIC_1_2", "DOCREV_DEPT", "DOCREV_DOC_NBR", "DOCREV_LOCATION", "DOCREV_OMA_CODE", "DOCREV_OMA_SUFF", "DOCREV_MTD_IN_REC", "DOCREV_MTD_OUT_REC");
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
            EndRequest("SEARCH_BLANK_PAYM_GROUP_1");

        }

    }




    #endregion


}
//SEARCH_BLANK_PAYM_GROUP_1



public class U100_SEARCH_BLANK_F112_RECORD_2 : U100
{

    public U100_SEARCH_BLANK_F112_RECORD_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU100_BLANK_F112_REC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U100_BLANK_F112_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF112_PYCDCEILINGS.InitializeItems += fleF112_PYCDCEILINGS_AutomaticItemInitialization;
        DOC_DATE_FAC_TERM.GetValue += DOC_DATE_FAC_TERM_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U100_SEARCH_BLANK_F112_RECORD_2)"

    private SqlFileObject fleF050_DOC_REVENUE_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    private SqlFileObject fleF112_PYCDCEILINGS;
    public override bool SelectIf()
    {


        try
        {
            if ((QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "22" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "23" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "24" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "25" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "26" | (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" ") & (string.Compare(QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")), "71") < 0 | string.Compare(QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")), "75") > 0))) & (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC")) != 0 | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC")) != 0) & !fleF112_PYCDCEILINGS.Exists())
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




    private SqlFileObject fleU100_BLANK_F112_REC;

    private DDecimal DOC_DATE_FAC_TERM = new DDecimal("DOC_DATE_FAC_TERM", 8);
    private void DOC_DATE_FAC_TERM_GetValue(ref decimal Value)
    {
        try
        {
            Value = QDesign.NConvert(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY").ToString() + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM").ToString() + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD").ToString());
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


    #region "Standard Generated Procedures(U100_SEARCH_BLANK_F112_RECORD_2)"


    #region "Automatic Item Initialization(U100_SEARCH_BLANK_F112_RECORD_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:28:00 PM

    //#-----------------------------------------
    //# fleF112_PYCDCEILINGS_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:27:58 PM
    //#-----------------------------------------
    private void fleF112_PYCDCEILINGS_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF112_PYCDCEILINGS.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF112_PYCDCEILINGS.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));

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


    #region "Transaction Management Procedures(U100_SEARCH_BLANK_F112_RECORD_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:27:56 PM

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
        fleF050_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleU100_BLANK_F112_REC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U100_SEARCH_BLANK_F112_RECORD_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:27:56 PM

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
            fleF050_DOC_REVENUE_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF112_PYCDCEILINGS.Dispose();
            fleU100_BLANK_F112_REC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U100_SEARCH_BLANK_F112_RECORD_2)"


    public void Run()
    {

        try
        {
            Request("SEARCH_BLANK_F112_RECORD_2");

            while (fleF050_DOC_REVENUE_MSTR.QTPForMissing())
            {
                // --> GET F050_DOC_REVENUE_MSTR <--

                fleF050_DOC_REVENUE_MSTR.GetData();
                // --> End GET F050_DOC_REVENUE_MSTR <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleICONST_MSTR_REC.QTPForMissing("2"))
                    {
                        // --> GET ICONST_MSTR_REC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2"))));

                        fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                        // --> End GET ICONST_MSTR_REC <--

                        while (fleF112_PYCDCEILINGS.QTPForMissing("3"))
                        {
                            // --> GET F112_PYCDCEILINGS <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")));

                            fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F112_PYCDCEILINGS <--


                            if (Transaction())
                            {

                                 if (Select_If())
                                {

                                    Sort(fleF050_DOC_REVENUE_MSTR.GetSortValue("DOCREV_DOC_NBR"));



                                }

                            }

                        }

                    }

                }

            }


            while (Sort(fleF050_DOC_REVENUE_MSTR, fleF020_DOCTOR_MSTR, fleICONST_MSTR_REC, fleF112_PYCDCEILINGS))
            {


                SubFile(ref m_trnTRANS_UPDATE, ref fleU100_BLANK_F112_REC, fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), SubFileType.Keep, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", "DOC_DEPT", "DOC_NAME",
                DOC_DATE_FAC_TERM);



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
            EndRequest("SEARCH_BLANK_F112_RECORD_2");

        }

    }




    #endregion


}
//SEARCH_BLANK_F112_RECORD_2




