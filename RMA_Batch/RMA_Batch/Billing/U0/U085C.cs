
#region "Screen Comments"

// Program: u085c 
// Purpose: create letters to patients requesting update of health card 
// eligibility information. All claims  of the patient are
// listed in the body of the letter along with doctor`s
// name
// - NOTE: only claims that have NOT be flagged as confidential
// ( Y  for ministry,  R  for rma flagged) will be 
// printed.
// - If ALL claims are confidential NO letter is genereated
// 00/sep/14    B.E.    - reduce to a max of 5 the number of doctors reported 
// on any individual letter to a patient. This is 
// accomplished by outputing a doc-nbr-count field
// that is reset at the start of each patient.
// 03/dec/15 A.A. - alpha doctor nbr
// 2013/11/07 - MC
// set lock file update
// 2013/11/07 - end
// !        (nconvert(ascii(claim-nbr,10)[1:2] +  0  + ascii(claim-nbr,10)[3:6])), &
// !        (nconvert(ascii(claim-nbr,10)[9:2])),                   &


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U085C : BaseClassControl
{

    private U085C m_U085C;

    public U085C(string Name, int Level) : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU085B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U085B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_OLD_DOC_NBR = new CoreCharacter("X_OLD_DOC_NBR", 3, this, Common.cEmptyString);
        X_OLD_PAT_ID = new CoreCharacter("X_OLD_PAT_ID", 16, this, Common.cEmptyString);
        X_DOC_CHANGED = new CoreCharacter("X_DOC_CHANGED", 1, this, Common.cEmptyString);
        X_DOC_NBR_COUNT = new CoreDecimal("X_DOC_NBR_COUNT", 7, this);
        fleU085C = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U085C", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }

    public U085C(string Name, int Level, bool Request) : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU085B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U085B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_OLD_DOC_NBR = new CoreCharacter("X_OLD_DOC_NBR", 3, this, Common.cEmptyString);
        X_OLD_PAT_ID = new CoreCharacter("X_OLD_PAT_ID", 16, this, Common.cEmptyString);
        X_DOC_CHANGED = new CoreCharacter("X_DOC_CHANGED", 1, this, Common.cEmptyString);
        X_DOC_NBR_COUNT = new CoreDecimal("X_DOC_NBR_COUNT", 7, this);
        fleU085C = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U085C", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }

    public override void Dispose()
    {
        if ((m_U085C != null))
        {
            m_U085C.CloseTransactionObjects();
            m_U085C = null;
        }
    }

    public U085C GetU085C(int Level)
    {
        if (m_U085C == null)
        {
            m_U085C = new U085C("U085C", Level);
        }
        else
        {
            m_U085C.ResetValues();
        }
        return m_U085C;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleU085B;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_CONFIDENTIAL_FLAG")) != "R" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_CONFIDENTIAL_FLAG")) != "Y")
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

    private CoreCharacter X_OLD_DOC_NBR;
    private CoreCharacter X_OLD_PAT_ID;
    private CoreCharacter X_DOC_CHANGED;

    private CoreDecimal X_DOC_NBR_COUNT;
    private SqlFileObject fleU085C;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("U085C");

            while (fleU085B.QTPForMissing())
            {
                // --> GET U085B <--

                fleU085B.GetData();
                // --> End GET U085B <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleU085B.GetStringValue("CLAIM_NBR"), 1, 8))));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(((QDesign.NConvert(QDesign.Substring(fleU085B.GetStringValue("CLAIM_NBR"), 9, 2)))));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {

                        if (Select_If())
                        {

                            Sort(fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_PAT_KEY_TYPE"), fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_PAT_KEY_DATA"), fleU085B.GetSortValue("DOC_NBR"));
                        



                        }

                    }

                }

            }

            while (Sort(fleU085B, fleF002_CLAIMS_MSTR))
            {
                if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")) != QDesign.NULL(X_OLD_PAT_ID.Value) | QDesign.NULL(fleU085B.GetStringValue("DOC_NBR")) != QDesign.NULL(X_OLD_DOC_NBR.Value))
                {
                    X_DOC_CHANGED.Value = "Y";
                }
                else
                {
                    X_DOC_CHANGED.Value = "N";
                }
                if (QDesign.NULL(X_DOC_CHANGED.Value) == "Y")
                {
                    X_DOC_NBR_COUNT.Value = X_DOC_NBR_COUNT.Value + 1;
                }
                else
                {
                    X_DOC_NBR_COUNT.Value = X_DOC_NBR_COUNT.Value;
                }
                X_OLD_DOC_NBR.Value = fleU085B.GetStringValue("DOC_NBR");
                X_OLD_PAT_ID.Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA");
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART


                SubFile(ref m_trnTRANS_UPDATE, ref fleU085C, SubFileType.Keep, fleU085B, X_OLD_DOC_NBR, X_DOC_CHANGED, X_DOC_NBR_COUNT);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART


                Reset(ref X_DOC_NBR_COUNT, fleF002_CLAIMS_MSTR.At("CLMHDR_PAT_KEY_TYPE") | fleF002_CLAIMS_MSTR.At("CLMHDR_PAT_KEY_DATA") );

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
            EndRequest("U085C");

        }

    }


    #region "Standard Generated Procedures(U085C_U085C)"

    #region "Transaction Management Procedures(U085C_U085C)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:02 PM

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
        fleU085B.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU085C.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U085C_U085C)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:02 PM

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
            fleU085B.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleU085C.Dispose();


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


    public override bool RunQTP()
    {


        try
        {

            Run();

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

