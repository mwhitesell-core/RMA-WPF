
#region "Screen Comments"

// doc     : emergency_urgent_clmhdrid_44.qts         
// purpose : same as emergency_payroll_clmhdrid.qts   but for dept 44 urgent care - does not have CTAS                           
// ; THIS report is by clmhdrid - there are two other programs one by doc by dept and one by month by location
// who     : department head
// *************************************************************
// Date           Who            Description
// 2012/04/23     Yasemin        emergency_payroll_clmhdrid.qts
// 2012/10/26     Yasemin        change date to 20120701 to 20130630
// 2016/08/29     Yasemin        change date to 20160701 to 20170630


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class EMERGENCY_URGENT_CLMHDRID_44 : BaseClassControl
{

    private EMERGENCY_URGENT_CLMHDRID_44 m_EMERGENCY_URGENT_CLMHDRID_44;

    public EMERGENCY_URGENT_CLMHDRID_44(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public EMERGENCY_URGENT_CLMHDRID_44(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_EMERGENCY_URGENT_CLMHDRID_44 != null))
        {
            m_EMERGENCY_URGENT_CLMHDRID_44.CloseTransactionObjects();
            m_EMERGENCY_URGENT_CLMHDRID_44 = null;
        }
    }

    public EMERGENCY_URGENT_CLMHDRID_44 GetEMERGENCY_URGENT_CLMHDRID_44(int Level)
    {
        if (m_EMERGENCY_URGENT_CLMHDRID_44 == null)
        {
            m_EMERGENCY_URGENT_CLMHDRID_44 = new EMERGENCY_URGENT_CLMHDRID_44("EMERGENCY_URGENT_CLMHDRID_44", Level);
        }
        else
        {
            m_EMERGENCY_URGENT_CLMHDRID_44.ResetValues();
        }
        return m_EMERGENCY_URGENT_CLMHDRID_44;
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

            EMERGENCY_URGENT_CLMHDRID_44_ONE_1 ONE_1 = new EMERGENCY_URGENT_CLMHDRID_44_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            EMERGENCY_URGENT_CLMHDRID_44_TWO_2 TWO_2 = new EMERGENCY_URGENT_CLMHDRID_44_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

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



public class EMERGENCY_URGENT_CLMHDRID_44_ONE_1 : EMERGENCY_URGENT_CLMHDRID_44
{

    public EMERGENCY_URGENT_CLMHDRID_44_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleURGENT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "URGENT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;
        X_CLAIM.GetValue += X_CLAIM_GetValue;
        X_CLINIC.GetValue += X_CLINIC_GetValue;
        CLMHDR_CLAIM_ID.GetValue += CLMHDR_CLAIM_ID_GetValue;
        CLMHDR_PAT_OHIP_ID_OR_CHART.GetValue += CLMHDR_PAT_OHIP_ID_OR_CHART_GetValue;
        DOC_INITS.GetValue += DOC_INITS_GetValue;
        CLMHDR_PAYROLL.GetValue += CLMHDR_PAYROLL_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }

    #region "Declarations (Variables, Files and Transactions)(EMERGENCY_URGENT_CLMHDRID_44_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" =  'C' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  44)");


            SelectIfClause = strSQL.ToString();


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

    private SqlFileObject fleF020_DOCTOR_MSTR;

    private void fleF002_CLAIMS_MSTR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("B"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("00000"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField("0"));


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

    private DCharacter X_CLAIM = new DCharacter("X_CLAIM", 10);
    private void X_CLAIM_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 10);
            //Parent:CLMHDR_CLAIM_ID


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
    private DCharacter X_CLINIC = new DCharacter("X_CLINIC", 2);
    private void X_CLINIC_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 2);
            //Parent:CLMHDR_CLAIM_ID


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



    private SqlFileObject fleURGENT;

    private DCharacter CLMHDR_CLAIM_ID = new DCharacter("CLMHDR_CLAIM_ID", 16);
    private void CLMHDR_CLAIM_ID_GetValue(ref string Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR");
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

    private DCharacter CLMHDR_PAT_OHIP_ID_OR_CHART = new DCharacter("CLMHDR_PAT_OHIP_ID_OR_CHART", 16);
    private void CLMHDR_PAT_OHIP_ID_OR_CHART_GetValue(ref string Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA");
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

    private DCharacter DOC_INITS = new DCharacter("DOC_INITS", 3);
    private void DOC_INITS_GetValue(ref string Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3");
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

    private DCharacter CLMHDR_PAYROLL = new DCharacter("CLMHDR_PAYROLL", 1);
    private void CLMHDR_PAYROLL_GetValue(ref string Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_HOSP");
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


    #region "Standard Generated Procedures(EMERGENCY_URGENT_CLMHDRID_44_ONE_1)"


    #region "Automatic Item Initialization(EMERGENCY_URGENT_CLMHDRID_44_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERGENCY_URGENT_CLMHDRID_44_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:52 PM

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
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleURGENT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERGENCY_URGENT_CLMHDRID_44_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:52 PM

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
            fleF002_CLAIMS_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleURGENT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERGENCY_URGENT_CLMHDRID_44_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--

                fleF002_CLAIMS_MSTR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 3, 3))));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    if (Transaction())
                    {
                        SubFile(ref m_trnTRANS_UPDATE, ref fleURGENT, SubFileType.Keep, CLMHDR_CLAIM_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLAIM, X_CLINIC, CLMHDR_PAT_OHIP_ID_OR_CHART,
                        CLMHDR_PAYROLL, "CLMHDR_DOC_DEPT", "CLMHDR_LOC", "CLMHDR_SERV_DATE", fleF020_DOCTOR_MSTR, "DOC_NBR", "DOC_NAME", DOC_INITS);
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



public class EMERGENCY_URGENT_CLMHDRID_44_TWO_2 : EMERGENCY_URGENT_CLMHDRID_44
{

    public EMERGENCY_URGENT_CLMHDRID_44_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleURGENT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "URGENT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleURGENT2_CLMID = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "URGENT2_CLMID", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleURGENT2_CLMID2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "URGENT2_CLMID2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        DETAIL_LINE.GetValue += DETAIL_LINE_GetValue;
        DETAIL_LINE2.GetValue += DETAIL_LINE2_GetValue;

    }

    #region "Declarations (Variables, Files and Transactions)(EMERGENCY_URGENT_CLMHDRID_44_TWO_2)"

    private SqlFileObject fleURGENT;
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

    private DCharacter DETAIL_LINE = new DCharacter("DETAIL_LINE", 60);
    private void DETAIL_LINE_GetValue(ref string Value)
    {
        try
        {
            Value = fleURGENT.GetStringValue("X_CLINIC") + COMMA.Value + string.Format("{0:+0#;-0#;+00}", QDesign.NConvert(fleURGENT.GetStringValue("CLMHDR_DOC_DEPT"))) + COMMA.Value + fleURGENT.GetStringValue("DOC_NBR") + COMMA.Value + fleURGENT.GetStringValue("DOC_NAME") + COMMA.Value + string.Format("{0:+0000000#;-0000000#;+00000000}", fleURGENT.GetDecimalValue("CLMHDR_SERV_DATE")) + COMMA.Value + fleURGENT.GetStringValue("CLMHDR_LOC") + COMMA.Value;
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

    private DCharacter DETAIL_LINE2 = new DCharacter("DETAIL_LINE2", 60);
    private void DETAIL_LINE2_GetValue(ref string Value)
    {
        try
        {
            Value = fleURGENT.GetStringValue("X_CLINIC") + COMMA.Value + string.Format("{0:+0#;-0#;+00}", QDesign.NConvert(fleURGENT.GetStringValue("CLMHDR_DOC_DEPT"))) + COMMA.Value + fleURGENT.GetStringValue("DOC_NBR") + COMMA.Value + fleURGENT.GetStringValue("DOC_NAME") + COMMA.Value + string.Format("{0:+0000000#;-0000000#;+00000000}", fleURGENT.GetDecimalValue("CLMHDR_SERV_DATE")) + COMMA.Value + fleURGENT.GetStringValue("CLMHDR_LOC") + COMMA.Value;
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

    private SqlFileObject fleURGENT2_CLMID;
    private SqlFileObject fleURGENT2_CLMID2;


    #endregion


    #region "Standard Generated Procedures(EMERGENCY_URGENT_CLMHDRID_44_TWO_2)"


    #region "Automatic Item Initialization(EMERGENCY_URGENT_CLMHDRID_44_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(EMERGENCY_URGENT_CLMHDRID_44_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:52 PM

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
        fleURGENT.Transaction = m_trnTRANS_UPDATE;
        fleURGENT2_CLMID.Transaction = m_trnTRANS_UPDATE;
        fleURGENT2_CLMID2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(EMERGENCY_URGENT_CLMHDRID_44_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:35:52 PM

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
            fleURGENT.Dispose();
            fleURGENT2_CLMID.Dispose();
            fleURGENT2_CLMID2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(EMERGENCY_URGENT_CLMHDRID_44_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleURGENT.QTPForMissing())
            {
                // --> GET URGENT <--

                fleURGENT.GetData();
                // --> End GET URGENT <--


                if (Transaction())
                {
                    Sort(fleURGENT.GetSortValue("X_CLINIC"), fleURGENT.GetSortValue("DOC_NBR"));
                }
            }

            while (Sort(fleURGENT))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleURGENT2_CLMID, fleURGENT.GetDecimalValue("CLMHDR_SERV_DATE") >= 20160701 & fleURGENT.GetDecimalValue("CLMHDR_SERV_DATE") <= 20170630, SubFileType.Portable, DETAIL_LINE);
                SubFile(ref m_trnTRANS_UPDATE, ref fleURGENT2_CLMID2, fleURGENT.GetDecimalValue("CLMHDR_SERV_DATE") >= 20170101 & fleURGENT.GetDecimalValue("CLMHDR_SERV_DATE") <= 20171231, SubFileType.Portable, DETAIL_LINE2);
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




