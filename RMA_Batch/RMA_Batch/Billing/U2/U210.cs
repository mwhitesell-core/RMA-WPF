
#region "Screen Comments"

// DOC: U210.QTS
// DOC: UPDATE BATCH STATUS FROM 3 TO 4(BLANK)
// DOC: RUN INSTEAD OF HISTORY TAPE RUN FOR CLINICS 22/60/80/81/82/83
// PROGRAM PURPOSE : THIS PROGRAM WAS DESIGNED TO REPLACE U210.CB TO
// ONLY UPDATE THE BATCH STATUS FROM   3 TO   4.
// MODIFICATION HISTORY
// DATE       WHO         DESCRIPTION
// 95/NOV/13  YAS         - ORIGINAL
// 97/MAR/13  YAS         - ADD NEW CLINIC 82
// 97/AUG/05  YAS         - ADD NEW CLINIC 83
// 1999/May/10  S.B.      - Checked for Y2K.
// 1999/May/21 S.B.        - Added the use file
// def_batctrl_batch_status.def to 
// prevent hardcoding of batctrl-batch-status.
// 2003/dec/23 A.A.      - alpha doctor nbr
// 2015/Jun/29 MC1         - update clinics based on selected monthend (1, 2 or 3) instead of choose clinic
// - save batches into the subfile so that it can be used as a driver file in
// unlof002_me_claims.qts


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U210 : BaseClassControl
{

    private U210 m_U210;

    public U210(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U210(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U210 != null))
        {
            m_U210.CloseTransactionObjects();
            m_U210 = null;
        }
    }

    public U210 GetU210(int Level)
    {
        if (m_U210 == null)
        {
            m_U210 = new U210("U210", Level);
        }
        else
        {
            m_U210.ResetValues();
        }
        return m_U210;
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

            U210_UPDATE_BATCH_CONTROL_1 UPDATE_BATCH_CONTROL_1 = new U210_UPDATE_BATCH_CONTROL_1(Name, Level);
            UPDATE_BATCH_CONTROL_1.Run();
            UPDATE_BATCH_CONTROL_1.Dispose();
            UPDATE_BATCH_CONTROL_1 = null;

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



public class U210_UPDATE_BATCH_CONTROL_1 : U210
{

    public U210_UPDATE_BATCH_CONTROL_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU210_BATCHES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U210_BATCHES", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF001_BATCH_CONTROL_FILE.SetItemFinals += fleF001_BATCH_CONTROL_FILE_SetItemFinals;      
        BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
        BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
        BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
        BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
        BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;

        fleF001_BATCH_CONTROL_FILE.SelectIf += fleF001_BATCH_CONTROL_FILE_SelectIf;
        ICONST_DATE_PERIOD_END.GetValue += ICONST_DATE_PERIOD_END_GetValue;
        fleF001_BATCH_CONTROL_FILE.Choose += fleF001_BATCH_CONTROL_FILE_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U210_UPDATE_BATCH_CONTROL_1)"

    private DDecimal ICONST_DATE_PERIOD_END = new DDecimal("ICONST_DATE_PERIOD_END", 8);
    private void ICONST_DATE_PERIOD_END_GetValue(ref decimal Value)
    {

        try
        {
            Value = Convert.ToInt64(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY").ToString().PadLeft(4, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM").ToString().PadLeft(2, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD").ToString().PadLeft(2, '0'));


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

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;
    private void fleF001_BATCH_CONTROL_FILE_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            if ((Prompt(1).ToString() != null) && Prompt(2).ToString().Length > 0)
            {
                strSQL.Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR"));
                strSQL.Append(" BETWEEN ");
                strSQL.Append(Common.StringToField(Prompt(1).ToString())).Append(" AND ").Append(Common.StringToField(Prompt(2).ToString()));

            }

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

    private void fleF001_BATCH_CONTROL_FILE_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_STATUS")).Append(" =  ").Append(Common.StringToField(BATCTRL_BATCH_STATUS_OHIP_SENT.Value)).Append(" )");


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



    private void fleF001_BATCH_CONTROL_FILE_SetItemFinals()
    {

        try
        {
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_STATUS", BATCTRL_BATCH_STATUS_MONTHEND_DONE.Value);


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

    private SqlFileObject fleICONST_MSTR_REC;

 

   
    private DCharacter BATCTRL_BATCH_STATUS_UNBALANCED = new DCharacter("BATCTRL_BATCH_STATUS_UNBALANCED", 1);
    private void BATCTRL_BATCH_STATUS_UNBALANCED_GetValue(ref string Value)
    {

        try
        {
            Value = "0";


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
    private DCharacter BATCTRL_BATCH_STATUS_BALANCED = new DCharacter("BATCTRL_BATCH_STATUS_BALANCED", 1);
    private void BATCTRL_BATCH_STATUS_BALANCED_GetValue(ref string Value)
    {

        try
        {
            Value = "1";


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
    private DCharacter BATCTRL_BATCH_STATUS_REV_UPDATED = new DCharacter("BATCTRL_BATCH_STATUS_REV_UPDATED", 1);
    private void BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "2";


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
    private DCharacter BATCTRL_BATCH_STATUS_OHIP_SENT = new DCharacter("BATCTRL_BATCH_STATUS_OHIP_SENT", 1);
    private void BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue(ref string Value)
    {

        try
        {
            Value = "3";


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
    private DCharacter BATCTRL_BATCH_STATUS_MONTHEND_DONE = new DCharacter("BATCTRL_BATCH_STATUS_MONTHEND_DONE", 1);
    private void BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue(ref string Value)
    {

        try
        {
            Value = "4";


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
            if (QDesign.NULL(ICONST_DATE_PERIOD_END.Value) == QDesign.NULL(QDesign.NConvert(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_DATE_PERIOD_END"))))
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


    private SqlFileObject fleU210_BATCHES;


    #endregion


    #region "Standard Generated Procedures(U210_UPDATE_BATCH_CONTROL_1)"


    #region "Automatic Item Initialization(U210_UPDATE_BATCH_CONTROL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U210_UPDATE_BATCH_CONTROL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:49:04 PM

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
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleU210_BATCHES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U210_UPDATE_BATCH_CONTROL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:49:04 PM

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
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleU210_BATCHES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U210_UPDATE_BATCH_CONTROL_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_BATCH_CONTROL_1");

            while (fleF001_BATCH_CONTROL_FILE.QTPForMissing())
            {
                // --> GET F001_BATCH_CONTROL_FILE <--

                fleF001_BATCH_CONTROL_FILE.GetData();
                // --> End GET F001_BATCH_CONTROL_FILE <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR", 0, 2)));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--


                    if (Transaction())
                    {

                        if (Select_If())
                        {

                            SubFile(ref m_trnTRANS_UPDATE, ref fleU210_BATCHES, SubFileType.Keep, fleF001_BATCH_CONTROL_FILE);

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
            EndRequest("UPDATE_BATCH_CONTROL_1");

        }

    }




    #endregion


}
//UPDATE_BATCH_CONTROL_1




