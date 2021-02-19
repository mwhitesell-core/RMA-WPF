
#region "Screen Comments"

// #> PROGRAM-ID.     U119B.qts
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// CALCULATE `EFTXXX` TRANSACTIONS FOR ALL PAY CODES
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 2000/jan/24         B.E.     - original 
// 2001/may/23         B.E.  - all transaction found in incoming subfile
// now added to f110
// 2015/Aug/23  MC1  - modify to add `on errors report` when output f110 add because PAYEFT records
// might have created via u113.qts if user has defined the record via 98 screen


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U119B : BaseClassControl
{

    private U119B m_U119B;

    public U119B(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U119B(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U119B != null))
        {
            m_U119B.CloseTransactionObjects();
            m_U119B = null;
        }
    }

    public U119B GetU119B(int Level)
    {
        if (m_U119B == null)
        {
            m_U119B = new U119B("U119B", Level);
        }
        else
        {
            m_U119B.ResetValues();
        }
        return m_U119B;
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

            U119B_1 U1 = new U119B_1(Name, Level);
            U1.Run();
            U1.Dispose();
            U1 = null;

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



public class U119B_1 : U119B
{

    public U119B_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU119_F110 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U119_F110", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U119B_1)"

    private SqlFileObject fleU119_F110;
    private DCharacter COMPENSATION_STATUS_ACCEPTED = new DCharacter("COMPENSATION_STATUS_ACCEPTED", 1);
    private void COMPENSATION_STATUS_ACCEPTED_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private SqlFileObject fleF110_COMPENSATION;


    #endregion


    #region "Standard Generated Procedures(U119B_1)"


    #region "Automatic Item Initialization(U119B_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U119B_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:21 PM

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
        fleU119_F110.Transaction = m_trnTRANS_UPDATE;
        fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U119B_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:21 PM

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
            fleU119_F110.Dispose();
            fleF110_COMPENSATION.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U119B_1)"


    public void Run()
    {

        try
        {
            Request("1");

            while (fleU119_F110.QTPForMissing())
            {
                // --> GET U119_F110 <--

                fleU119_F110.GetData();
                // --> End GET U119_F110 <--


                if (Transaction())
                {
                    fleF110_COMPENSATION.set_SetValue("DOC_NBR", fleU119_F110.GetStringValue("DOC_NBR"));

                    fleF110_COMPENSATION.set_SetValue("EP_NBR", fleU119_F110.GetDecimalValue("W_EP_NBR"));


                    fleF110_COMPENSATION.set_SetValue("EP_NBR_ENTRY", fleU119_F110.GetDecimalValue("W_EP_NBR_ENTRY"));


                    fleF110_COMPENSATION.set_SetValue("COMP_CODE", fleU119_F110.GetStringValue("W_COMP_CODE_TRANSFER_OR_EFT"));


                    fleF110_COMPENSATION.set_SetValue("COMP_TYPE", fleU119_F110.GetStringValue("W_TYPE"));


                    fleF110_COMPENSATION.set_SetValue("PROCESS_SEQ", fleU119_F110.GetDecimalValue("W_SEQ"));


                    fleF110_COMPENSATION.set_SetValue("FACTOR", fleU119_F110.GetDecimalValue("W_FACTOR"));


                    fleF110_COMPENSATION.set_SetValue("FACTOR_OVERRIDE", fleU119_F110.GetStringValue("W_FACTOR_OVERRIDE"));


                    fleF110_COMPENSATION.set_SetValue("COMP_UNITS", fleU119_F110.GetDecimalValue("W_COMP_UNITS"));


                    fleF110_COMPENSATION.set_SetValue("AMT_GROSS", fleU119_F110.GetDecimalValue("W_AMT_GROSS"));


                    fleF110_COMPENSATION.set_SetValue("AMT_NET", fleU119_F110.GetDecimalValue("W_AMT_NET"));


                    fleF110_COMPENSATION.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                    fleF110_COMPENSATION.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                    fleF110_COMPENSATION.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                    fleF110_COMPENSATION.set_SetValue("LAST_MOD_USER_ID", "U119B gen`d");

                    fleF110_COMPENSATION.OutPut(OutPutType.Add);

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
            EndRequest("1");

        }

    }







    #endregion


}
//1




