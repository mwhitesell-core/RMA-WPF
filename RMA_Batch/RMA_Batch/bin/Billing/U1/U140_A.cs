
#region "Screen Comments"

// Program: u140_a
// Purpose: Before the RA is run this program must to be to put all doctors
// into the f075 file with an indication of the number of doctors
// that share the same MOH OHIP Number
// This f075 file is then updated with the RA payments and based upon
// the split between a doctors RMA doctors of their RA Payments the
// same ratio is used to divy up the single AFP payment identified
// only with the doctor`s OHIP number
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
// NOTE:  BEWARE -  what you see in field doc-afp-paym-group in subfiles and /or files
// is not from f020-doctor-mstr, but it is translated from the clinic nbr
// that is assigned to the doctor
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
// 2005/apr/08 b.e. - set lock update statement
// 2005/apr/13 M.C. - count number of doctors within the group with MOH ohip number
// 2005/may/10 b.e. - removed all select statements on doctors so that both
// active and terminated doctors are selected
// 2007/jul/19 M.C. - create a new request `u140_extract_doc_afp_group` in the beginning
// and a new request`u140_update_doc_count` at the end of the program
// 2008/sep/09 M.C. - create a new request to extract doctor records  for the incoming group from A2S file 
// into f075-afp-doc-mstr  with an indication of the number of doctors
// 2008/oct/16 M.C. - include doc-nbr in the sort statement in request u140_doc_afp_group  
// and include doc-nbr in the access in the request u140_create_f075_records   
// 2008/nov/04 M.C. - Brad said that we should explode the group records only if doc-afp-paym-group
// of f020-doctor-mstr is non-blank                                             
// 2008/dec/02 MC1  - undo on 2008/nov/04  - because dr 888 - Tarnolopsky 187427 has blank afp group defined in f020
// and did not show on r140_b.txt report, he has 2 records from Dec governance which have
// non-zero amt under H522 & H523
// 2009/jul/08 MC2  - include f074-afp-group-sequence-mstr in the access of request u140_extract_reporting_grp
// - check on nonrbp-flag or solo-flag instead of hard coded group number
// 2011/nov/09 MC3  - change the sort in request u140_doc_afp_group so that the active doctor will be selected
// for the same group number
// 2012/Apr/03 MC4  - Brad suggested to filter out (ignore) doctor with blank doc-afp-paym-group of f020-doctor-mstr
// before creating records in f075 file in u140_create_f075_records request.  
// This is for the example 266049 with 3 different doctor records
// and has applied to the wrong doctor K79 and it should be 780.
// K79 Active with dept 31 and blank group
// 780 Active with dept 14 and H111  group
// L69 Terminate with dept 14 and H111 group
// 2007/07/19 - MC - add the new request to extract doctor afp group


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U140_A : BaseClassControl
{

    private U140_A m_U140_A;

    public U140_A(string Name, int Level) : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U140_A(string Name, int Level, bool Request) : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U140_A != null))
        {
            m_U140_A.CloseTransactionObjects();
            m_U140_A = null;
        }
    }

    public U140_A GetU140_A(int Level)
    {
        if (m_U140_A == null)
        {
            m_U140_A = new U140_A("U140_A", Level);
        }
        else
        {
            m_U140_A.ResetValues();
        }
        return m_U140_A;
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

            U140_A_U140_EXTRACT_DOC_AFP_GROUP_1 U140_EXTRACT_DOC_AFP_GROUP_1 = new U140_A_U140_EXTRACT_DOC_AFP_GROUP_1(Name, Level);
            U140_EXTRACT_DOC_AFP_GROUP_1.Run();
            U140_EXTRACT_DOC_AFP_GROUP_1.Dispose();
            U140_EXTRACT_DOC_AFP_GROUP_1 = null;

            U140_A_U140_EXTRACT_REPORTING_GRP_2 U140_EXTRACT_REPORTING_GRP_2 = new U140_A_U140_EXTRACT_REPORTING_GRP_2(Name, Level);
            U140_EXTRACT_REPORTING_GRP_2.Run();
            U140_EXTRACT_REPORTING_GRP_2.Dispose();
            U140_EXTRACT_REPORTING_GRP_2 = null;

            U140_A_U140_GET_UNIQUE_DOC_GROUP_3 U140_GET_UNIQUE_DOC_GROUP_3 = new U140_A_U140_GET_UNIQUE_DOC_GROUP_3(Name, Level);
            U140_GET_UNIQUE_DOC_GROUP_3.Run();
            U140_GET_UNIQUE_DOC_GROUP_3.Dispose();
            U140_GET_UNIQUE_DOC_GROUP_3 = null;

            U140_A_U140_DOC_AFP_GROUP_4 U140_DOC_AFP_GROUP_4 = new U140_A_U140_DOC_AFP_GROUP_4(Name, Level);
            U140_DOC_AFP_GROUP_4.Run();
            U140_DOC_AFP_GROUP_4.Dispose();
            U140_DOC_AFP_GROUP_4 = null;

            U140_A_U140_CREATE_F075_RECORDS_5 U140_CREATE_F075_RECORDS_5 = new U140_A_U140_CREATE_F075_RECORDS_5(Name, Level);
            U140_CREATE_F075_RECORDS_5.Run();
            U140_CREATE_F075_RECORDS_5.Dispose();
            U140_CREATE_F075_RECORDS_5 = null;

            U140_A_U140_COUNT_F075_NBR_OF_DOCTOR_6 U140_COUNT_F075_NBR_OF_DOCTOR_6 = new U140_A_U140_COUNT_F075_NBR_OF_DOCTOR_6(Name, Level);
            U140_COUNT_F075_NBR_OF_DOCTOR_6.Run();
            U140_COUNT_F075_NBR_OF_DOCTOR_6.Dispose();
            U140_COUNT_F075_NBR_OF_DOCTOR_6 = null;

            U140_A_U140_UPDATE_F075_NBR_OF_DOCTOR_7 U140_UPDATE_F075_NBR_OF_DOCTOR_7 = new U140_A_U140_UPDATE_F075_NBR_OF_DOCTOR_7(Name, Level);
            U140_UPDATE_F075_NBR_OF_DOCTOR_7.Run();
            U140_UPDATE_F075_NBR_OF_DOCTOR_7.Dispose();
            U140_UPDATE_F075_NBR_OF_DOCTOR_7 = null;

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



public class U140_A_U140_EXTRACT_DOC_AFP_GROUP_1 : U140_A
{

    public U140_A_U140_EXTRACT_DOC_AFP_GROUP_1(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCLINIC1 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_1", "CLINIC1", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCLINIC2 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_2", "CLINIC2", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCLINIC3 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_3", "CLINIC3", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCLINIC4 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_4", "CLINIC4", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCLINIC5 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_5", "CLINIC5", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCLINIC6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "CLINIC6", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU140_AFP_GROUP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_AFP_GROUP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleAFPCLINIC2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_AFP_GROUP", "AFPCLINIC2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleAFPCLINIC3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_AFP_GROUP", "AFPCLINIC3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleAFPCLINIC4 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_AFP_GROUP", "AFPCLINIC4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleAFPCLINIC5 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_AFP_GROUP", "AFPCLINIC5", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleAFPCLINIC6 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_AFP_GROUP", "AFPCLINIC6", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF020_DOCTOR_MSTR.Choose += fleF020_DOCTOR_MSTR_Choose;
        X_TERM_DATE.GetValue += X_TERM_DATE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_A_U140_EXTRACT_DOC_AFP_GROUP_1)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleCLINIC1;
    private SqlFileObject fleCLINIC2;
    private SqlFileObject fleCLINIC3;
    private SqlFileObject fleCLINIC4;
    private SqlFileObject fleCLINIC5;
    private SqlFileObject fleCLINIC6;

    private void fleF020_DOCTOR_MSTR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
            strSQL.Append(1);


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

    private DDecimal X_TERM_DATE = new DDecimal("X_TERM_DATE");
    private void X_TERM_DATE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) == 0)
            {
                CurrentValue = 20991231;
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM");
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


    private SqlFileObject fleU140_AFP_GROUP;


    private SqlFileObject fleAFPCLINIC2;


    private SqlFileObject fleAFPCLINIC3;


    private SqlFileObject fleAFPCLINIC4;


    private SqlFileObject fleAFPCLINIC5;


    private SqlFileObject fleAFPCLINIC6;


    #endregion


    #region "Standard Generated Procedures(U140_A_U140_EXTRACT_DOC_AFP_GROUP_1)"


    #region "Automatic Item Initialization(U140_A_U140_EXTRACT_DOC_AFP_GROUP_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_A_U140_EXTRACT_DOC_AFP_GROUP_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:41 PM

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
        fleCLINIC1.Transaction = m_trnTRANS_UPDATE;
        fleCLINIC2.Transaction = m_trnTRANS_UPDATE;
        fleCLINIC3.Transaction = m_trnTRANS_UPDATE;
        fleCLINIC4.Transaction = m_trnTRANS_UPDATE;
        fleCLINIC5.Transaction = m_trnTRANS_UPDATE;
        fleCLINIC6.Transaction = m_trnTRANS_UPDATE;
        fleU140_AFP_GROUP.Transaction = m_trnTRANS_UPDATE;
        fleAFPCLINIC2.Transaction = m_trnTRANS_UPDATE;
        fleAFPCLINIC3.Transaction = m_trnTRANS_UPDATE;
        fleAFPCLINIC4.Transaction = m_trnTRANS_UPDATE;
        fleAFPCLINIC5.Transaction = m_trnTRANS_UPDATE;
        fleAFPCLINIC6.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_A_U140_EXTRACT_DOC_AFP_GROUP_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:41 PM

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
            fleCLINIC1.Dispose();
            fleCLINIC2.Dispose();
            fleCLINIC3.Dispose();
            fleCLINIC4.Dispose();
            fleCLINIC5.Dispose();
            fleCLINIC6.Dispose();
            fleU140_AFP_GROUP.Dispose();
            fleAFPCLINIC2.Dispose();
            fleAFPCLINIC3.Dispose();
            fleAFPCLINIC4.Dispose();
            fleAFPCLINIC5.Dispose();
            fleAFPCLINIC6.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_A_U140_EXTRACT_DOC_AFP_GROUP_1)"


    public void Run()
    {

        try
        {
            Request("U140_EXTRACT_DOC_AFP_GROUP_1");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--

                while (fleCLINIC1.QTPForMissing("1"))
                {
                    // --> GET CLINIC1 <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleCLINIC1.ElementOwner("CONST_REC_NBR")).Append(" = ");
                    m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR")));

                    fleCLINIC1.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET CLINIC1 <--

                    while (fleCLINIC2.QTPForMissing("2"))
                    {
                        // --> GET CLINIC2 <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleCLINIC2.ElementOwner("CONST_REC_NBR")).Append(" = ");
                        m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_2")));

                        fleCLINIC2.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET CLINIC2 <--

                        while (fleCLINIC3.QTPForMissing("3"))
                        {
                            // --> GET CLINIC3 <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleCLINIC3.ElementOwner("CONST_REC_NBR")).Append(" = ");
                            m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_3")));

                            fleCLINIC3.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET CLINIC3 <--

                            while (fleCLINIC4.QTPForMissing("4"))
                            {
                                // --> GET CLINIC4 <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleCLINIC4.ElementOwner("CONST_REC_NBR")).Append(" = ");
                                m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_4")));

                                fleCLINIC4.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET CLINIC4 <--

                                while (fleCLINIC5.QTPForMissing("5"))
                                {
                                    // --> GET CLINIC5 <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleCLINIC5.ElementOwner("CONST_REC_NBR")).Append(" = ");
                                    m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_5")));

                                    fleCLINIC5.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET CLINIC5 <--

                                    while (fleCLINIC6.QTPForMissing("6"))
                                    {
                                        // --> GET CLINIC6 <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleCLINIC6.ElementOwner("CONST_REC_NBR")).Append(" = ");
                                        m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CLINIC_NBR_6")));

                                        fleCLINIC6.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                        // --> End GET CLINIC6 <--


                                        if (Transaction())
                                        {


                                            SubFile(ref m_trnTRANS_UPDATE, ref fleU140_AFP_GROUP, QDesign.NULL(fleCLINIC1.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y", SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", "DOC_NBR", X_TERM_DATE, fleCLINIC1, "ICONST_CLINIC_NBR");




                                            SubFile(ref m_trnTRANS_UPDATE, ref fleAFPCLINIC2, QDesign.NULL(fleCLINIC2.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y", SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", "DOC_NBR", X_TERM_DATE, fleCLINIC2, "ICONST_CLINIC_NBR");




                                            SubFile(ref m_trnTRANS_UPDATE, ref fleAFPCLINIC3, QDesign.NULL(fleCLINIC3.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y", SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", "DOC_NBR", X_TERM_DATE, fleCLINIC3, "ICONST_CLINIC_NBR");




                                            SubFile(ref m_trnTRANS_UPDATE, ref fleAFPCLINIC4, QDesign.NULL(fleCLINIC4.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y", SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", "DOC_NBR", X_TERM_DATE, fleCLINIC4, "ICONST_CLINIC_NBR");




                                            SubFile(ref m_trnTRANS_UPDATE, ref fleAFPCLINIC5, QDesign.NULL(fleCLINIC5.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y", SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", "DOC_NBR", X_TERM_DATE, fleCLINIC5, "ICONST_CLINIC_NBR");




                                            SubFile(ref m_trnTRANS_UPDATE, ref fleAFPCLINIC6, QDesign.NULL(fleCLINIC6.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y", SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", "DOC_NBR", X_TERM_DATE, fleCLINIC6, "ICONST_CLINIC_NBR");



                                        }

                                    }

                                }

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
            EndRequest("U140_EXTRACT_DOC_AFP_GROUP_1");

        }

    }




    #endregion


}
//U140_EXTRACT_DOC_AFP_GROUP_1



public class U140_A_U140_EXTRACT_REPORTING_GRP_2 : U140_A
{

    public U140_A_U140_EXTRACT_REPORTING_GRP_2(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleAFP_A2S_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "AFP_A2S_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF074_AFP_GROUP_SEQUENCE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F074_AFP_GROUP_SEQUENCE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleAFPA2S = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_AFP_GROUP", "AFPA2S", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_PAYROLL.GetValue += X_PAYROLL_GetValue;
        X_TERM_DATE.GetValue += X_TERM_DATE_GetValue;
        X_NONRBP_GROUP.GetValue += X_NONRBP_GROUP_GetValue;
        X_SOLO_NONRBP_GROUP.GetValue += X_SOLO_NONRBP_GROUP_GetValue;
        fleF074_AFP_GROUP_SEQUENCE_MSTR.InitializeItems += fleF074_AFP_GROUP_SEQUENCE_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_A_U140_EXTRACT_REPORTING_GRP_2)"

    private SqlFileObject fleAFP_A2S_FILE;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF074_AFP_GROUP_SEQUENCE_MSTR;
    private DCharacter X_PAYROLL = new DCharacter("X_PAYROLL", 1);
    private void X_PAYROLL_GetValue(ref string Value)
    {

        try
        {
            Value = Prompt(1).ToString();


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
    private DDecimal X_TERM_DATE = new DDecimal("X_TERM_DATE");
    private void X_TERM_DATE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) == 0)
            {
                CurrentValue = 20991231;
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM");
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
    private DCharacter X_NONRBP_GROUP = new DCharacter("X_NONRBP_GROUP", 1);
    private void X_NONRBP_GROUP_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF074_AFP_GROUP_SEQUENCE_MSTR.GetStringValue("NONRBP_FLAG")) == "Y" & QDesign.NULL(fleF074_AFP_GROUP_SEQUENCE_MSTR.GetStringValue("SOLO_FLAG")) == "N")
            {
                CurrentValue = "Y";
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
    private DCharacter X_SOLO_NONRBP_GROUP = new DCharacter("X_SOLO_NONRBP_GROUP", 1);
    private void X_SOLO_NONRBP_GROUP_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF074_AFP_GROUP_SEQUENCE_MSTR.GetStringValue("NONRBP_FLAG")) == "Y" & (QDesign.NULL(fleF074_AFP_GROUP_SEQUENCE_MSTR.GetStringValue("SOLO_FLAG")) == "Y" | QDesign.NULL(fleF074_AFP_GROUP_SEQUENCE_MSTR.GetStringValue("SOLO_FLAG")) == "N"))
            {
                CurrentValue = "Y";
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

    public override bool SelectIf()
    {


        try
        {
            if ((QDesign.NULL(X_SOLO_NONRBP_GROUP.Value) == "Y" & QDesign.NULL(X_PAYROLL.Value) == "C") | (QDesign.NULL(X_NONRBP_GROUP.Value) == "Y" & QDesign.NULL(X_PAYROLL.Value) == "A"))
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



    private SqlFileObject fleAFPA2S;


    #endregion


    #region "Standard Generated Procedures(U140_A_U140_EXTRACT_REPORTING_GRP_2)"


    #region "Automatic Item Initialization(U140_A_U140_EXTRACT_REPORTING_GRP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:15 PM

    //#-----------------------------------------
    //# fleF074_AFP_GROUP_SEQUENCE_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:13 PM
    //#-----------------------------------------
    private void fleF074_AFP_GROUP_SEQUENCE_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF074_AFP_GROUP_SEQUENCE_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));

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


    #region "Transaction Management Procedures(U140_A_U140_EXTRACT_REPORTING_GRP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:41 PM

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
        fleAFP_A2S_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_SEQUENCE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleAFPA2S.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_A_U140_EXTRACT_REPORTING_GRP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:41 PM

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
            fleAFP_A2S_FILE.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF074_AFP_GROUP_SEQUENCE_MSTR.Dispose();
            fleAFPA2S.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_A_U140_EXTRACT_REPORTING_GRP_2)"


    public void Run()
    {

        try
        {
            Request("U140_EXTRACT_REPORTING_GRP_2");

            while (fleAFP_A2S_FILE.QTPForMissing())
            {
                // --> GET AFP_A2S_FILE <--

                fleAFP_A2S_FILE.GetData();
                // --> End GET AFP_A2S_FILE <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append(((QDesign.NConvert(fleAFP_A2S_FILE.GetStringValue("DOC_AFP_PAYM_SOLO")))));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF074_AFP_GROUP_SEQUENCE_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F074_AFP_GROUP_SEQUENCE_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_SEQUENCE_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleAFP_A2S_FILE.GetStringValue("DOC_AFP_PAYM_GROUP")));

                        fleF074_AFP_GROUP_SEQUENCE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F074_AFP_GROUP_SEQUENCE_MSTR <--


                        if (Transaction())
                        {

                            if (Select_If())
                            {


                                SubFile(ref m_trnTRANS_UPDATE, ref fleAFPA2S, SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_OHIP_NBR", "DOC_NBR", X_TERM_DATE, fleAFP_A2S_FILE, "DOC_AFP_PAYM_GROUP");



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
            EndRequest("U140_EXTRACT_REPORTING_GRP_2");

        }

    }




    #endregion


}
//U140_EXTRACT_REPORTING_GRP_2



public class U140_A_U140_GET_UNIQUE_DOC_GROUP_3 : U140_A
{

    public U140_A_U140_GET_UNIQUE_DOC_GROUP_3(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU140_AFP_GROUP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_AFP_GROUP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU140_AFP_GROUP_SORT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_AFP_GROUP_SORT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        DOC_AFP_PAYM_GROUP.GetValue += DOC_AFP_PAYM_GROUP_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_A_U140_GET_UNIQUE_DOC_GROUP_3)"

    private SqlFileObject fleU140_AFP_GROUP;
    private DCharacter DOC_AFP_PAYM_GROUP = new DCharacter("DOC_AFP_PAYM_GROUP", 4);
    private void DOC_AFP_PAYM_GROUP_GetValue(ref string Value)
    {

        try
        {
            Value = fleU140_AFP_GROUP.GetStringValue("ICONST_CLINIC_NBR");


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


    private SqlFileObject fleU140_AFP_GROUP_SORT;


    #endregion


    #region "Standard Generated Procedures(U140_A_U140_GET_UNIQUE_DOC_GROUP_3)"


    #region "Automatic Item Initialization(U140_A_U140_GET_UNIQUE_DOC_GROUP_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_A_U140_GET_UNIQUE_DOC_GROUP_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:41 PM

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
        fleU140_AFP_GROUP.Transaction = m_trnTRANS_UPDATE;
        fleU140_AFP_GROUP_SORT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_A_U140_GET_UNIQUE_DOC_GROUP_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:41 PM

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
            fleU140_AFP_GROUP.Dispose();
            fleU140_AFP_GROUP_SORT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_A_U140_GET_UNIQUE_DOC_GROUP_3)"


    public void Run()
    {

        try
        {
            Request("U140_GET_UNIQUE_DOC_GROUP_3");

            while (fleU140_AFP_GROUP.QTPForMissing())
            {
                // --> GET U140_AFP_GROUP <--

                fleU140_AFP_GROUP.GetData();
                // --> End GET U140_AFP_GROUP <--


                if (Transaction())
                {

                    Sort(fleU140_AFP_GROUP.GetSortValue("DOC_OHIP_NBR"), fleU140_AFP_GROUP.GetSortValue("DOC_NBR"), DOC_AFP_PAYM_GROUP.Value);



                }

            }


            while (Sort(fleU140_AFP_GROUP))
            {

                SubFile(ref m_trnTRANS_UPDATE, ref fleU140_AFP_GROUP_SORT, fleU140_AFP_GROUP.At("DOC_OHIP_NBR") || fleU140_AFP_GROUP.At("DOC_NBR") || At(DOC_AFP_PAYM_GROUP), SubFileType.Keep, fleU140_AFP_GROUP, "DOC_OHIP_NBR", "DOC_NBR", "X_TERM_DATE", DOC_AFP_PAYM_GROUP);



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
            EndRequest("U140_GET_UNIQUE_DOC_GROUP_3");

        }

    }




    #endregion


}
//U140_GET_UNIQUE_DOC_GROUP_3



public class U140_A_U140_DOC_AFP_GROUP_4 : U140_A
{

    public U140_A_U140_DOC_AFP_GROUP_4(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU140_AFP_GROUP_SORT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_AFP_GROUP_SORT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_DOC_COUNT = new CoreDecimal("X_DOC_COUNT", 6, this);
        fleU140_A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_DOCTOR_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_DOCTOR_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_DOCTOR_ALPHA.SetItemFinals += fleTMP_DOCTOR_ALPHA_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_A_U140_DOC_AFP_GROUP_4)"

    private SqlFileObject fleU140_AFP_GROUP_SORT;

    private CoreDecimal X_DOC_COUNT;

    private SqlFileObject fleU140_A;
    private SqlFileObject fleTMP_DOCTOR_ALPHA;

    private void fleTMP_DOCTOR_ALPHA_SetItemFinals()
    {

        try
        {
            fleTMP_DOCTOR_ALPHA.set_SetValue("DOC_OHIP_NBR", fleU140_AFP_GROUP_SORT.GetDecimalValue("DOC_OHIP_NBR"));
            fleTMP_DOCTOR_ALPHA.set_SetValue("DOC_NBR", fleU140_AFP_GROUP_SORT.GetStringValue("DOC_NBR"));
            fleTMP_DOCTOR_ALPHA.set_SetValue("TMP_ALPHA_FIELD_1", fleU140_AFP_GROUP_SORT.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleTMP_DOCTOR_ALPHA.set_SetValue("TMP_ALPHA_FIELD_2", QDesign.ASCII(fleU140_AFP_GROUP_SORT.GetNumericDateValue("X_TERM_DATE")));
            fleTMP_DOCTOR_ALPHA.set_SetValue("TMP_COUNTER_1", X_DOC_COUNT.Value);


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


    #region "Standard Generated Procedures(U140_A_U140_DOC_AFP_GROUP_4)"


    #region "Automatic Item Initialization(U140_A_U140_DOC_AFP_GROUP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_A_U140_DOC_AFP_GROUP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:42 PM

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
        fleU140_AFP_GROUP_SORT.Transaction = m_trnTRANS_UPDATE;
        fleU140_A.Transaction = m_trnTRANS_UPDATE;
        fleTMP_DOCTOR_ALPHA.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_A_U140_DOC_AFP_GROUP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:42 PM

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
            fleU140_AFP_GROUP_SORT.Dispose();
            fleU140_A.Dispose();
            fleTMP_DOCTOR_ALPHA.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_A_U140_DOC_AFP_GROUP_4)"


    public void Run()
    {

        try
        {
            Request("U140_DOC_AFP_GROUP_4");

            while (fleU140_AFP_GROUP_SORT.QTPForMissing())
            {
                // --> GET U140_AFP_GROUP_SORT <--

                fleU140_AFP_GROUP_SORT.GetData();
                // --> End GET U140_AFP_GROUP_SORT <--


                if (Transaction())
                {

                    Sort(fleU140_AFP_GROUP_SORT.GetSortValue("DOC_OHIP_NBR"), fleU140_AFP_GROUP_SORT.GetSortValue("DOC_AFP_PAYM_GROUP"), fleU140_AFP_GROUP_SORT.GetSortValue("X_TERM_DATE"), fleU140_AFP_GROUP_SORT.GetSortValue("DOC_NBR"));



                }

            }

            while (Sort(fleU140_AFP_GROUP_SORT))
            {
                X_DOC_COUNT.Value = X_DOC_COUNT.Value + 1;



                SubFile(ref m_trnTRANS_UPDATE, ref fleU140_A, SubFileType.Keep, fleU140_AFP_GROUP_SORT, X_DOC_COUNT);




                fleTMP_DOCTOR_ALPHA.OutPut(OutPutType.Add, fleU140_AFP_GROUP_SORT.At("DOC_OHIP_NBR") || fleU140_AFP_GROUP_SORT.At("DOC_AFP_PAYM_GROUP") || fleU140_AFP_GROUP_SORT.At("X_TERM_DATE") || fleU140_AFP_GROUP_SORT.At("DOC_NBR"), null);


                Reset(ref X_DOC_COUNT, fleU140_AFP_GROUP_SORT.At("DOC_OHIP_NBR") || fleU140_AFP_GROUP_SORT.At("DOC_AFP_PAYM_GROUP"));

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
            EndRequest("U140_DOC_AFP_GROUP_4");

        }

    }




    #endregion


}
//U140_DOC_AFP_GROUP_4



public class U140_A_U140_CREATE_F075_RECORDS_5 : U140_A
{

    public U140_A_U140_CREATE_F075_RECORDS_5(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU140_A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_DOCTOR_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_DOCTOR_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_COUNT = new CoreDecimal("X_COUNT", 6, this);
        fleBRADDEBUG = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "BRADDEBUG", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF075_AFP_DOC_MSTR.SetItemFinals += fleF075_AFP_DOC_MSTR_SetItemFinals;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF075_AFP_DOC_MSTR.InitializeItems += fleF075_AFP_DOC_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_A_U140_CREATE_F075_RECORDS_5)"

    private SqlFileObject fleU140_A;
    private SqlFileObject fleTMP_DOCTOR_ALPHA;
    private SqlFileObject fleF020_DOCTOR_MSTR;

    private CoreDecimal X_COUNT;

    private SqlFileObject fleBRADDEBUG;
    private SqlFileObject fleF075_AFP_DOC_MSTR;

    private void fleF075_AFP_DOC_MSTR_SetItemFinals()
    {

        try
        {
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_OHIP_NBR", fleU140_A.GetDecimalValue("DOC_OHIP_NBR"));
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_NBR", fleU140_A.GetStringValue("DOC_NBR"));
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", fleU140_A.GetStringValue("DOC_AFP_PAYM_GROUP"));


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


    #region "Standard Generated Procedures(U140_A_U140_CREATE_F075_RECORDS_5)"


    #region "Automatic Item Initialization(U140_A_U140_CREATE_F075_RECORDS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:21 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:18 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleTMP_DOCTOR_ALPHA.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleTMP_DOCTOR_ALPHA.GetStringValue("DOC_NBR"));

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
    //# fleF075_AFP_DOC_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:21 PM
    //#-----------------------------------------
    private void fleF075_AFP_DOC_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleTMP_DOCTOR_ALPHA.GetDecimalValue("DOC_OHIP_NBR"));
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_NBR", !Fixed, fleTMP_DOCTOR_ALPHA.GetStringValue("DOC_NBR"));
            //TODO: Manual steps may be required.
            fleF075_AFP_DOC_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));

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


    #region "Transaction Management Procedures(U140_A_U140_CREATE_F075_RECORDS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:42 PM

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
        fleU140_A.Transaction = m_trnTRANS_UPDATE;
        fleTMP_DOCTOR_ALPHA.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleBRADDEBUG.Transaction = m_trnTRANS_UPDATE;
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_A_U140_CREATE_F075_RECORDS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:42 PM

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
            fleU140_A.Dispose();
            fleTMP_DOCTOR_ALPHA.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleBRADDEBUG.Dispose();
            fleF075_AFP_DOC_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_A_U140_CREATE_F075_RECORDS_5)"


    public void Run()
    {

        try
        {
            Request("U140_CREATE_F075_RECORDS_5");

            while (fleU140_A.QTPForMissing())
            {
                // --> GET U140_A <--

                fleU140_A.GetData();
                // --> End GET U140_A <--

                while (fleTMP_DOCTOR_ALPHA.QTPForMissing("1"))
                {
                    // --> GET TMP_DOCTOR_ALPHA <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleTMP_DOCTOR_ALPHA.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleTMP_DOCTOR_ALPHA.GetDecimalValue("DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleTMP_DOCTOR_ALPHA.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleTMP_DOCTOR_ALPHA.GetStringValue("DOC_NBR")));
                    m_strWhere.Append(" And ").Append(fleTMP_DOCTOR_ALPHA.ElementOwner("TMP_ALPHA_FIELD_1")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU140_A.GetStringValue("DOC_AFP_PAYM_GROUP")));

                    fleTMP_DOCTOR_ALPHA.GetData(m_strWhere.ToString());
                    // --> End GET TMP_DOCTOR_ALPHA <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleTMP_DOCTOR_ALPHA.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_MSTR <--


                        if (Transaction())
                        {

                            Sort(fleTMP_DOCTOR_ALPHA.GetSortValue("DOC_OHIP_NBR"), fleF020_DOCTOR_MSTR.GetSortValue("DOC_AFP_PAYM_GROUP", SortType.Descending));



                        }

                    }

                }

            }

            while (Sort(fleU140_A, fleTMP_DOCTOR_ALPHA, fleF020_DOCTOR_MSTR))
            {
                X_COUNT.Value = X_COUNT.Value + 1;



                SubFile(ref m_trnTRANS_UPDATE, ref fleBRADDEBUG, SubFileType.Keep, fleU140_A, "DOC_OHIP_NBR", "DOC_OHIP_NBR", "DOC_NBR", "DOC_NBR", "DOC_AFP_PAYM_GROUP", fleTMP_DOCTOR_ALPHA,
                "TMP_ALPHA_FIELD_1", fleU140_A, "X_DOC_COUNT", fleTMP_DOCTOR_ALPHA, "TMP_COUNTER_1");




                fleF075_AFP_DOC_MSTR.OutPut(OutPutType.Add, null, QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" ") | (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) == QDesign.NULL(" ") & QDesign.NULL(X_COUNT.Value) == 1));


                Reset(ref X_COUNT, fleTMP_DOCTOR_ALPHA.At("DOC_OHIP_NBR"));

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
            EndRequest("U140_CREATE_F075_RECORDS_5");

        }

    }




    #endregion


}
//U140_CREATE_F075_RECORDS_5



public class U140_A_U140_COUNT_F075_NBR_OF_DOCTOR_6 : U140_A
{

    public U140_A_U140_COUNT_F075_NBR_OF_DOCTOR_6(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_DOC_COUNT = new CoreDecimal("X_DOC_COUNT", 6, this);
        fleU140_A_DOC_COUNT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_A_DOC_COUNT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U140_A_U140_COUNT_F075_NBR_OF_DOCTOR_6)"

    private SqlFileObject fleF075_AFP_DOC_MSTR;

    private CoreDecimal X_DOC_COUNT;

    private SqlFileObject fleU140_A_DOC_COUNT;


    #endregion


    #region "Standard Generated Procedures(U140_A_U140_COUNT_F075_NBR_OF_DOCTOR_6)"


    #region "Automatic Item Initialization(U140_A_U140_COUNT_F075_NBR_OF_DOCTOR_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_A_U140_COUNT_F075_NBR_OF_DOCTOR_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:42 PM

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
        fleU140_A_DOC_COUNT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_A_U140_COUNT_F075_NBR_OF_DOCTOR_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:42 PM

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
            fleU140_A_DOC_COUNT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_A_U140_COUNT_F075_NBR_OF_DOCTOR_6)"


    public void Run()
    {

        try
        {
            Request("U140_COUNT_F075_NBR_OF_DOCTOR_6");

            while (fleF075_AFP_DOC_MSTR.QTPForMissing())
            {
                // --> GET F075_AFP_DOC_MSTR <--

                fleF075_AFP_DOC_MSTR.GetData();
                // --> End GET F075_AFP_DOC_MSTR <--


                if (Transaction())
                {

                    Sort(fleF075_AFP_DOC_MSTR.GetSortValue("DOC_OHIP_NBR"), fleF075_AFP_DOC_MSTR.GetSortValue("DOC_AFP_PAYM_GROUP"), fleF075_AFP_DOC_MSTR.GetSortValue("DOC_NBR"));



                }

            }

            while (Sort(fleF075_AFP_DOC_MSTR))
            {
                X_DOC_COUNT.Value = X_DOC_COUNT.Value + 1;



                SubFile(ref m_trnTRANS_UPDATE, ref fleU140_A_DOC_COUNT, fleF075_AFP_DOC_MSTR.At("DOC_OHIP_NBR") || fleF075_AFP_DOC_MSTR.At("DOC_AFP_PAYM_GROUP"), SubFileType.Keep, fleF075_AFP_DOC_MSTR, "DOC_OHIP_NBR", "DOC_AFP_PAYM_GROUP", X_DOC_COUNT);



                Reset(ref X_DOC_COUNT, fleF075_AFP_DOC_MSTR.At("DOC_OHIP_NBR") || fleF075_AFP_DOC_MSTR.At("DOC_AFP_PAYM_GROUP"));

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
            EndRequest("U140_COUNT_F075_NBR_OF_DOCTOR_6");

        }

    }




    #endregion


}
//U140_COUNT_F075_NBR_OF_DOCTOR_6



public class U140_A_U140_UPDATE_F075_NBR_OF_DOCTOR_7 : U140_A
{

    public U140_A_U140_UPDATE_F075_NBR_OF_DOCTOR_7(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU140_A_DOC_COUNT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_A_DOC_COUNT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF075_AFP_DOC_MSTR.SetItemFinals += fleF075_AFP_DOC_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_A_U140_UPDATE_F075_NBR_OF_DOCTOR_7)"

    private SqlFileObject fleU140_A_DOC_COUNT;
    private SqlFileObject fleF075_AFP_DOC_MSTR;

    private void fleF075_AFP_DOC_MSTR_SetItemFinals()
    {

        try
        {
            fleF075_AFP_DOC_MSTR.set_SetValue("AFP_DUPLICATE_DOC_COUNT", fleU140_A_DOC_COUNT.GetDecimalValue("X_DOC_COUNT"));


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
            if (QDesign.NULL(fleU140_A_DOC_COUNT.GetStringValue("DOC_AFP_PAYM_GROUP")) == QDesign.NULL(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")))
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


    #region "Standard Generated Procedures(U140_A_U140_UPDATE_F075_NBR_OF_DOCTOR_7)"


    #region "Automatic Item Initialization(U140_A_U140_UPDATE_F075_NBR_OF_DOCTOR_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_A_U140_UPDATE_F075_NBR_OF_DOCTOR_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:42 PM

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
        fleU140_A_DOC_COUNT.Transaction = m_trnTRANS_UPDATE;
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_A_U140_UPDATE_F075_NBR_OF_DOCTOR_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:42 PM

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
            fleU140_A_DOC_COUNT.Dispose();
            fleF075_AFP_DOC_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_A_U140_UPDATE_F075_NBR_OF_DOCTOR_7)"


    public void Run()
    {

        try
        {
            Request("U140_UPDATE_F075_NBR_OF_DOCTOR_7");

            while (fleU140_A_DOC_COUNT.QTPForMissing())
            {
                // --> GET U140_A_DOC_COUNT <--

                fleU140_A_DOC_COUNT.GetData();
                // --> End GET U140_A_DOC_COUNT <--

                while (fleF075_AFP_DOC_MSTR.QTPForMissing("1"))
                {
                    // --> GET F075_AFP_DOC_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF075_AFP_DOC_MSTR.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR")));

                    fleF075_AFP_DOC_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F075_AFP_DOC_MSTR <--

                    if (Transaction())
                    {

                        if (Select_If())
                        {


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
            EndRequest("U140_UPDATE_F075_NBR_OF_DOCTOR_7");

        }

    }




    #endregion


}
//U140_UPDATE_F075_NBR_OF_DOCTOR_7




