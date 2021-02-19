
#region "Screen Comments"

// 2016/Dec/01 MC utl0013.qts
// Helena made the below rule:
// If the doctor has a Dept 13 and Dept 14 RMA #, Dept 14 should be credited with the OHIP discounts (MOHD) 
// and the OHIP premiums (AGEP).
// This program should be run before running for MOHD and/or AGEP macros
// This program will set `Y` to pay-this-doctor-ohip-premium for dept 14 if doctor has both dept 13 and 14
// This is the first pass of utl0013


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0013 : BaseClassControl
{

    private UTL0013 m_UTL0013;

    public UTL0013(string Name, int Level) : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

    }

    public UTL0013(string Name, int Level, bool Request) : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if ((m_UTL0013 != null))
        {
            m_UTL0013.CloseTransactionObjects();
            m_UTL0013 = null;
        }
    }

    public UTL0013 GetUTL0013(int Level)
    {
        if (m_UTL0013 == null)
        {
            m_UTL0013 = new UTL0013("UTL0013", Level);
        }
        else
        {
            m_UTL0013.ResetValues();
        }
        return m_UTL0013;
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

            UTL0013_ONE_1 ONE_1 = new UTL0013_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            UTL0013_TWO_2 TWO_2 = new UTL0013_TWO_2(Name, Level);
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



public class UTL0013_ONE_1 : UTL0013
{

    public UTL0013_ONE_1(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        XCOUNT = new CoreDecimal("XCOUNT", 6, this);
        fleUTL0013_A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0013_A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);



    }


    #region "Declarations (Variables, Files and Transactions)(UTL0013_ONE_1)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (((QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 13 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 14) & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) == 0 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) > QDesign.NULL(QDesign.SysDate(ref m_cnnQUERY)))))
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


    private CoreDecimal XCOUNT;

    private SqlFileObject fleUTL0013_A;


    #endregion


    #region "Standard Generated Procedures(UTL0013_ONE_1)"


    #region "Automatic Item Initialization(UTL0013_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0013_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/4/2017 8:36:47 AM

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
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleUTL0013_A.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0013_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/4/2017 8:36:47 AM

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
            fleF020_DOCTOR_MSTR.Dispose();
            fleUTL0013_A.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0013_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--

                if (Transaction())
                {

                    if (Select_If())
                    {

                        Sort(fleF020_DOCTOR_MSTR.GetSortValue("DOC_OHIP_NBR"));



                    }

                }

            }

            while (Sort(fleF020_DOCTOR_MSTR))
            {
                XCOUNT.Value = XCOUNT.Value + 1;



                SubFile(ref m_trnTRANS_UPDATE, "UTL0013_A", fleF020_DOCTOR_MSTR.At("DOC_OHIP_NBR"), SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", XCOUNT);
                


                Reset(ref XCOUNT, fleF020_DOCTOR_MSTR.At("DOC_OHIP_NBR"));

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



public class UTL0013_TWO_2 : UTL0013
{

    public UTL0013_TWO_2(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleUTL0013_A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0013_A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        REC_IND = new CoreCharacter("REC_IND", 6, this, Common.cEmptyString);
        fleUTL0013_B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0013_B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleAFTER = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0013_B", "AFTER", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF020_DOCTOR_EXTRA.SetItemFinals += fleF020_DOCTOR_EXTRA_SetItemFinals;
        fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0013_TWO_2)"

    private SqlFileObject fleUTL0013_A;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020_DOCTOR_EXTRA;

    private void fleF020_DOCTOR_EXTRA_SetItemFinals()
    {

        try
        {
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 14)
            {
                fleF020_DOCTOR_EXTRA.set_SetValue("PAY_THIS_DOCTOR_OHIP_PREMIUM", "Y");
            }
            else
            {
                fleF020_DOCTOR_EXTRA.set_SetValue("PAY_THIS_DOCTOR_OHIP_PREMIUM", " ");
            }
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 14)
            {
                fleF020_DOCTOR_EXTRA.set_SetValue("PAY_THIS_DOCTOR_OHIP_PREMIUM", "Y");
            }
            else
            {
                fleF020_DOCTOR_EXTRA.set_SetValue("PAY_THIS_DOCTOR_OHIP_PREMIUM", " ");
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


    public override bool SelectIf()
    {


        try
        {
            if ((fleUTL0013_A.GetDecimalValue("XCOUNT") > 1 & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 13 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 14)))
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


    private CoreCharacter REC_IND;

    private SqlFileObject fleUTL0013_B;


    private SqlFileObject fleAFTER;


    #endregion


    #region "Standard Generated Procedures(UTL0013_TWO_2)"


    #region "Automatic Item Initialization(UTL0013_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/4/2017 8:36:47 AM

    //#-----------------------------------------
    //# fleF020_DOCTOR_EXTRA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 10/4/2017 8:36:47 AM
    //#-----------------------------------------
    private void fleF020_DOCTOR_EXTRA_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));

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


    #region "Transaction Management Procedures(UTL0013_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/4/2017 8:36:47 AM

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
        fleUTL0013_A.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleUTL0013_B.Transaction = m_trnTRANS_UPDATE;
        fleAFTER.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0013_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/4/2017 8:36:47 AM

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
            fleUTL0013_A.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF020_DOCTOR_EXTRA.Dispose();
            fleUTL0013_B.Dispose();
            fleAFTER.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0013_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleUTL0013_A.QTPForMissing())
            {
                // --> GET UTL0013_A <--

                fleUTL0013_A.GetData();
                // --> End GET UTL0013_A <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF020_DOCTOR_EXTRA.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_EXTRA <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_EXTRA <--

                        if (Transaction())
                        {

                            if (Select_If())
                            {
                                REC_IND.Value = "Before";


                                SubFile(ref m_trnTRANS_UPDATE, "UTL0013_B", SubFileType.Keep, REC_IND, fleF020_DOCTOR_MSTR, fleF020_DOCTOR_EXTRA, "PAY_THIS_DOCTOR_OHIP_PREMIUM", "PAY_THIS_DOCTOR_OHIP_PREMIUM");
                                



                                fleF020_DOCTOR_EXTRA.OutPut(OutPutType.Update);
                                


                                REC_IND.Value = "After";



                                SubFile(ref m_trnTRANS_UPDATE, "AFTER", SubFileType.Temp, REC_IND, fleF020_DOCTOR_MSTR, fleF020_DOCTOR_EXTRA, "PAY_THIS_DOCTOR_OHIP_PREMIUM", "PAY_THIS_DOCTOR_OHIP_PREMIUM");
                                


                            }

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




