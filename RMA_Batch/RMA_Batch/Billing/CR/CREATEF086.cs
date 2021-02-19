
#region "Screen Comments"

//  2004/03/02 M.C. - createf086.qts
//  - create f086-pat-id for the patient have mess code
//  2004/03/10    M.C.    - update f010
//  - add the second request to delete records from 
//  rejected-claims, all records in rejected-claims
//  should contain `H` status with non-zero balance (>0)
//  2004/03/10    M.C. - alpha doc nbr

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class CREATEF086 : BaseClassControl
{
    private CREATEF086 m_CREATEF086;

    public CREATEF086(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public CREATEF086(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_CREATEF086 == null))
        {
            m_CREATEF086.CloseTransactionObjects();
            m_CREATEF086 = null;
        }
    }

    public CREATEF086 GetCREATEF086(int Level)
    {
        if ((m_CREATEF086 == null))
        {
            m_CREATEF086 = new CREATEF086("CREATEF086", Level);
        }
        else
        {
            m_CREATEF086.ResetValues();
        }

        return m_CREATEF086;
    }

    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.
    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
    protected SqlTransaction m_trnTRANS_UPDATE;

    #endregion

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {
        try
        {
            CREATEF086_ONE_1 ONE_1 = new CREATEF086_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            CREATEF086_TWO_2 TWO_2 = new CREATEF086_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

            CREATEF086_THREE_3 THREE_3 = new CREATEF086_THREE_3(Name, Level);
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
public class CREATEF086_ONE_1 : CREATEF086
{
    public CREATEF086_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF087_SUBMITTED_REJECTED_CLAIMS_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleEXTF010MESS = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "EXTF010MESS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF010_PAT_MSTR.SelectIf += fleF010_PAT_MSTR_SelectIf;
        KEY_PAT_MSTR.GetValue += KEY_PAT_MSTR_GetValue;

        PAT_SURNAME.GetValue += PAT_SURNAME_GetValue;
        PAT_GIVEN_NAME.GetValue += PAT_GIVEN_NAME_GetValue;
        PAT_BIRTH_DATE.GetValue += PAT_BIRTH_DATE_GetValue;
    }

    private DCharacter PAT_SURNAME = new DCharacter("PAT_SURNAME", 25);
    private void PAT_SURNAME_GetValue(ref string Value)
    {
        try
        {
            Value = fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22");
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

    private DCharacter PAT_GIVEN_NAME = new DCharacter("PAT_GIVEN_NAME", 17);
    private void PAT_GIVEN_NAME_GetValue(ref string Value)
    {
        try
        {
            Value = fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST1") + fleF010_PAT_MSTR.GetStringValue("FILLER3");
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

    private DCharacter PAT_BIRTH_DATE = new DCharacter("PAT_BIRTH_DATE", 8);
    private void PAT_BIRTH_DATE_GetValue(ref string Value)
    {
        try
        {
            //Value = fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22");
            // GW2019. Added for parent/child
            Value = QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_BIRTH_DATE_YY")).ToString().PadLeft(4, '0') +
                QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_BIRTH_DATE_MM")).ToString().PadLeft(2, '0') +
                QDesign.NULL(fleF010_PAT_MSTR.GetNumericDateValue("PAT_BIRTH_DATE_DD")).ToString().PadLeft(2, '0');
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

    #region "Declarations (Variables, Files and Transactions)(CREATEF086_1)"

    private SqlFileObject fleF010_PAT_MSTR;

    private void fleF010_PAT_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_MESS_CODE")).Append(" <>  ' ')");

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

    private SqlFileObject fleF087_SUBMITTED_REJECTED_CLAIMS_HDR;
    private SqlFileObject fleEXTF010MESS;

    private DCharacter KEY_PAT_MSTR = new DCharacter("KEY_PAT_MSTR", 16);
    private void KEY_PAT_MSTR_GetValue(ref string Value)
    {
        try
        {
            Value = fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4");
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

    #region "Standard Generated Procedures(CREATEF086_1)"

    #region "Automatic Item Initialization(CREATEF086_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(CREATEF086_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:18 AM
    // #-----------------------------------------
    // # InitializeTransactionObjects Procedure.
    // #-----------------------------------------
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

    // #-----------------------------------------
    // # CloseTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void CloseTransactionObjects()
    {
        try
        {
            this.CloseFiles();
            if (!(m_trnTRANS_UPDATE == null))
            {
                m_trnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Close();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Close();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Dispose();
            }
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
        if ((Method == TransactionMethods.Rollback))
        {
            m_trnTRANS_UPDATE.Rollback();
        }
        else
        {
            m_trnTRANS_UPDATE.Commit();
        }

        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        this.Initialize_TRANS_UPDATE();
    }

    private void Initialize_TRANS_UPDATE()
    {
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.Transaction = m_trnTRANS_UPDATE;
        fleEXTF010MESS.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(CREATEF086_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:18 AM
    // #-----------------------------------------
    // # InitializeFiles Procedure.
    // #-----------------------------------------

    protected override void InitializeFiles()
    {
        try
        {
            this.Initialize_TRANS_UPDATE();
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

    // #-----------------------------------------
    // # CloseFiles Procedure.
    // #-----------------------------------------
    protected override void CloseFiles()
    {
        try
        {
            fleF010_PAT_MSTR.Dispose();
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.Dispose();
            fleEXTF010MESS.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CREATEF086_1)"

    public void Run()
    {
        try
        {
            Request("ONE_1");
            while (fleF010_PAT_MSTR.QTPForMissing())
            {
                //  --> GET F010_PAT_MSTR <--
                fleF010_PAT_MSTR.GetData();
                //  --> End GET F010_PAT_MSTR <--

                while (fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.QTPForMissing("1"))
                {
                    //  --> GET F087_SUBMITTED_REJECTED_CLAIMS_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.ElementOwner("EDT_HEALTH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR"), 10)));

                    fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetData(m_strWhere.ToString());
                    //  --> End GET F087_SUBMITTED_REJECTED_CLAIMS_HDR <--

                    if (Transaction())
                    {
                        Sort(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetSortValue("EDT_HEALTH_NBR"), fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetSortValue("EDT_PROCESS_DATE"));
                    }
                }
            }

            while (Sort(fleF010_PAT_MSTR, fleF087_SUBMITTED_REJECTED_CLAIMS_HDR))
            {
                SubFile(ref m_trnTRANS_UPDATE, "EXTF010MESS", fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.At("EDT_HEALTH_NBR"), SubFileType.Keep, fleF087_SUBMITTED_REJECTED_CLAIMS_HDR, "EDT_HEALTH_NBR", "EDT_PROCESS_DATE",
                                                              fleF010_PAT_MSTR, "PAT_DATE_LAST_ELIG_MAINT", KEY_PAT_MSTR, "PAT_HEALTH_NBR", "PAT_CHART_NBR", "PAT_CHART_NBR_2", "PAT_CHART_NBR_3", "PAT_CHART_NBR_4",
                                                              "PAT_CHART_NBR_5", PAT_SURNAME, PAT_GIVEN_NAME, PAT_BIRTH_DATE, "PAT_LAST_BIRTH_DATE", "PAT_VERSION_CD", "PAT_LAST_VERSION_CD", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3");

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
// ONE_1
public class CREATEF086_TWO_2 : CREATEF086
{
    public CREATEF086_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleEXTF010MESS = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "EXTF010MESS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF086_PAT_ID = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "F086_PAT_ID", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF010MESS = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF010MESS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF010_PAT_MSTR.SetItemFinals += fleF010_PAT_MSTR_SetItemFinals;
        RUN_DATE.GetValue += RUN_DATE_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(CREATEF086_2)"

    private SqlFileObject fleEXTF010MESS;
    private SqlFileObject fleF010_PAT_MSTR;

    private void fleF010_PAT_MSTR_SetItemFinals()
    {
        try
        {
            fleF010_PAT_MSTR.set_SetValue("PAT_MESS_CODE", " ");
            fleF010_PAT_MSTR.set_SetValue("PAT_MESS_CODE", " ");
            fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_ELIG_MAINT", QDesign.SysDate(ref m_cnnQUERY));
            fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_ELIG_MAINT", QDesign.SysDate(ref m_cnnQUERY));
            fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_MAINT", QDesign.SysDate(ref m_cnnQUERY));
            fleF010_PAT_MSTR.set_SetValue("PAT_DATE_LAST_MAINT", QDesign.SysDate(ref m_cnnQUERY));
            fleF010_PAT_MSTR.set_SetValue("PAT_NO_OF_LETTER_SENT", 0);
            fleF010_PAT_MSTR.set_SetValue("PAT_NO_OF_LETTER_SENT", 0);
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
            if (QDesign.NULL(fleEXTF010MESS.GetDecimalValue("EDT_PROCESS_DATE")) < QDesign.NULL(fleEXTF010MESS.GetDecimalValue("PAT_DATE_LAST_ELIG_MAINT")))
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

    private DDecimal RUN_DATE = new DDecimal("RUN_DATE");
    private void RUN_DATE_GetValue(ref Decimal Value)
    {
        try
        {
            Value = QDesign.SysDate(ref m_cnnQUERY);
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

    private SqlFileObject fleF086_PAT_ID;
    private SqlFileObject fleSAVEF010MESS;

    #endregion

    #region "Standard Generated Procedures(CREATEF086_2)"

    #region "Automatic Item Initialization(CREATEF086_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(CREATEF086_2)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:18 AM

    // #-----------------------------------------
    // # InitializeTransactionObjects Procedure.
    // #-----------------------------------------
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

    // #-----------------------------------------
    // # CloseTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void CloseTransactionObjects()
    {
        try
        {
            this.CloseFiles();
            if (!(m_trnTRANS_UPDATE == null))
            {
                m_trnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Close();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Close();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Dispose();
            }
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
        if ((Method == TransactionMethods.Rollback))
        {
            m_trnTRANS_UPDATE.Rollback();
        }
        else
        {
            m_trnTRANS_UPDATE.Commit();
        }

        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        this.Initialize_TRANS_UPDATE();
    }

    private void Initialize_TRANS_UPDATE()
    {
        fleEXTF010MESS.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF086_PAT_ID.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF010MESS.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(CREATEF086_2)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:18 AM
    // #-----------------------------------------
    // # InitializeFiles Procedure.
    // #-----------------------------------------
    protected override void InitializeFiles()
    {
        try
        {
            this.Initialize_TRANS_UPDATE();
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

    // #-----------------------------------------
    // # CloseFiles Procedure.
    // #-----------------------------------------
    protected override void CloseFiles()
    {
        try
        {
            fleEXTF010MESS.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleF086_PAT_ID.Dispose();
            fleSAVEF010MESS.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CREATEF086_2)"

    public void Run()
    {
        try
        {
            Request("TWO_2");
            while (fleEXTF010MESS.QTPForMissing())
            {
                //  --> GET EXTF010MESS <--
                fleEXTF010MESS.GetData();
                //  --> End GET EXTF010MESS <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    //  --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF010MESS.GetStringValue("KEY_PAT_MSTR").PadRight(16).Substring(0, 1)));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert(fleEXTF010MESS.GetStringValue("KEY_PAT_MSTR").PadRight(16).Substring(1, 2)));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert(fleEXTF010MESS.GetStringValue("KEY_PAT_MSTR").PadRight(16).Substring(3, 12)));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF010MESS.GetStringValue("KEY_PAT_MSTR").PadRight(16).Substring(15, 1)));

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString());
                    //  --> End GET F010_PAT_MSTR <--

                    if (Transaction())
                    {
                        if (Select_If())
                        {
                            fleF086_PAT_ID.OutPut(OutPutType.Add);
                            SubFile(ref m_trnTRANS_UPDATE, "SAVEF010MESS", SubFileType.Keep, fleF010_PAT_MSTR, RUN_DATE);
                            fleF010_PAT_MSTR.OutPut(OutPutType.Update);
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
// TWO_2
public class CREATEF086_THREE_3 : CREATEF086
{
    public CREATEF086_THREE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleREJECTED_CLAIMS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "REJECTED_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF085 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "SAVEF085", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        BAL_DUE.GetValue += BAL_DUE_GetValue;
        RUN_DATE.GetValue += RUN_DATE_GetValue;
    }



    #region "Declarations (Variables, Files and Transactions)(CREATEF086_3)"

    private SqlFileObject fleREJECTED_CLAIMS;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ").Append(QDesign.NConvert(QDesign.Substring(fleREJECTED_CLAIMS.GetStringValue("CLAIM_NBR"), 9, 2)));
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ").Append("'00000'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ").Append("'0'");

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

    private DDecimal BAL_DUE = new DDecimal("BAL_DUE", 6);
    private void BAL_DUE_GetValue(ref Decimal Value)
    {
        try
        {
            Value = (fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS"));
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

    private DDecimal RUN_DATE = new DDecimal("RUN_DATE");
    private void RUN_DATE_GetValue(ref Decimal Value)
    {
        try
        {
            Value = QDesign.SysDate(ref m_cnnQUERY);
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
            if ((QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_TAPE_SUBMIT_IND")) != "H") || (BAL_DUE.Value <= 0))
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

    private SqlFileObject fleSAVEF085;

    #endregion

    #region "Standard Generated Procedures(CREATEF086_3)"

    #region "Automatic Item Initialization(CREATEF086_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(CREATEF086_3)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:18 AM
    // #-----------------------------------------
    // # InitializeTransactionObjects Procedure.
    // #-----------------------------------------
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

    // #-----------------------------------------
    // # CloseTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void CloseTransactionObjects()
    {
        try
        {
            this.CloseFiles();
            if (!(m_trnTRANS_UPDATE == null))
            {
                m_trnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Close();
            }

            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Dispose();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Close();
            }

            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Dispose();
            }
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
        if ((Method == TransactionMethods.Rollback))
        {
            m_trnTRANS_UPDATE.Rollback();
        }
        else
        {
            m_trnTRANS_UPDATE.Commit();
        }

        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        this.Initialize_TRANS_UPDATE();
    }

    private void Initialize_TRANS_UPDATE()
    {
        fleREJECTED_CLAIMS.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF085.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(CREATEF086_3)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:18 AM
    // #-----------------------------------------
    // # InitializeFiles Procedure.
    // #-----------------------------------------
    protected override void InitializeFiles()
    {
        try
        {
            this.Initialize_TRANS_UPDATE();
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

    // #-----------------------------------------
    // # CloseFiles Procedure.
    // #-----------------------------------------
    protected override void CloseFiles()
    {
        try
        {
            fleREJECTED_CLAIMS.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleSAVEF085.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CREATEF086_3)"

    public void Run()
    {
        try
        {
            Request("THREE_3");

            while (fleREJECTED_CLAIMS.QTPForMissing())
            {
                //  --> GET REJECTED_CLAIMS <--
                fleREJECTED_CLAIMS.GetData();
                //  --> End GET REJECTED_CLAIMS <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    //  --> GET F002_CLAIMS_MSTR <--                  
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleREJECTED_CLAIMS.GetStringValue("CLAIM_NBR", 0, 8)));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.VAL2(fleREJECTED_CLAIMS.GetStringValue("CLAIM_NBR", 8, 2)));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));


                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    //  --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {
                        if (Select_If())
                        {
                            SubFile(ref m_trnTRANS_UPDATE, "SAVEF085", SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMHDR_TAPE_SUBMIT_IND", BAL_DUE, RUN_DATE, fleREJECTED_CLAIMS);

                            fleREJECTED_CLAIMS.OutPut(OutPutType.Delete);

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
// THREE_3