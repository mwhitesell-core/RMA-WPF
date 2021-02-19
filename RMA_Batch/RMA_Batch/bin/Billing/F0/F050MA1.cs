
#region "Screen Comments"

// 2002/jan/23 yas add doctors 078 and 279 change doctor 662 to 55
// 2003/jul/23 yas take out doc 448 and add treleaven 967            
// 2003/dec/24    A.A. alpha doctor nbr
// 2008/Jun/24    yas     Add doc L76  
// 2008/Jul/7     yas     add doc 733
// 2009/May/27    yas     add doc P18
// 2011/Oct/12    yas     add doc Karen Chia-Ying and DR. Michael Walsh
// 2012/Oct/12    yas     add doc 05C new number for 279                  
// 2014/Sep/08    yas     add new number for Dr. To 761                   
// 2014/Sep/24    yas     add new number for Dr. Miller 38H and 53K       
// 2015/Jan/06    yas     add new number for Dr. Ribic 03E                
// 2016/Apr/15    yas     take out 459 anfor 455 and D80 and ADD 80M (Dr. Molnar) as per Dr Brimble
// 2016/Jul/26    yas     add corporation numbers for Yang 58N and Molnar 79P                      


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class F050MA1 : BaseClassControl
{

    private F050MA1 m_F050MA1;

    public F050MA1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF050MA1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F050MA1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        NAME.GetValue += NAME_GetValue;
        DOC_NBR.GetValue += DOC_NBR_GetValue;
        FIXED_DOCREV_OMA_CD.GetValue += FIXED_DOCREV_OMA_CD_GetValue;
        OMA_CD_DESC.GetValue += OMA_CD_DESC_GetValue;
        OMA_CODE_ONLY.GetValue += OMA_CODE_ONLY_GetValue;
        RPT_SORT_SEQ.GetValue += RPT_SORT_SEQ_GetValue;
        PRESORT_CODE.GetValue += PRESORT_CODE_GetValue;
        GROUPING.GetValue += GROUPING_GetValue;

    }

    public F050MA1(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF050MA1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F050MA1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        NAME.GetValue += NAME_GetValue;
        DOC_NBR.GetValue += DOC_NBR_GetValue;
        FIXED_DOCREV_OMA_CD.GetValue += FIXED_DOCREV_OMA_CD_GetValue;
        OMA_CD_DESC.GetValue += OMA_CD_DESC_GetValue;
        OMA_CODE_ONLY.GetValue += OMA_CODE_ONLY_GetValue;
        RPT_SORT_SEQ.GetValue += RPT_SORT_SEQ_GetValue;
        PRESORT_CODE.GetValue += PRESORT_CODE_GetValue;
        GROUPING.GetValue += GROUPING_GetValue;

    }

    public override void Dispose()
    {
        if ((m_F050MA1 != null))
        {
            m_F050MA1.CloseTransactionObjects();
            m_F050MA1 = null;
        }
    }

    public F050MA1 GetF050MA1(int Level)
    {
        if (m_F050MA1 == null)
        {
            m_F050MA1 = new F050MA1("F050MA1", Level);
        }
        else
        {
            m_F050MA1.ResetValues();
        }
        return m_F050MA1;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleF050_DOC_REVENUE_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF040_OMA_FEE_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if ((QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "J26" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "J89" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "D69" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "05C" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "K16" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "733" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "K17" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "L76" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "38H" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "53K" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "P18" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "761" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "J85" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "965" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "03E" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "M08" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "58N" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "80M" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) == "79P"))
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

    private DCharacter NAME = new DCharacter("NAME", 30);
    private void NAME_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) != "301")
            {
                CurrentValue = QDesign.Pack(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME") + "," + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3") + "(" + fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR") + ")");
                
            }
            else
            {
                CurrentValue = "BARNES,CC (481)";
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
    private DCharacter DOC_NBR = new DCharacter("DOC_NBR", 3);
    private void DOC_NBR_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR")) != "301")
            {
                CurrentValue = fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_DOC_NBR");
            }
            else
            {
                CurrentValue = "481";
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
    private DCharacter FIXED_DOCREV_OMA_CD = new DCharacter("FIXED_DOCREV_OMA_CD", 5);
    private void FIXED_DOCREV_OMA_CD_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE"), 5, 1)) == "M")
            {
                CurrentValue = QDesign.Substring(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE"), 1, 4) + "A";
                
            }
            else
            {
                CurrentValue = fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE");
                
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
    private DCharacter OMA_CD_DESC = new DCharacter("OMA_CD_DESC", 55);
    private void OMA_CD_DESC_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (fleF040_OMA_FEE_MSTR.Exists())
            {
                CurrentValue = QDesign.Pack(FIXED_DOCREV_OMA_CD.Value + " - " + fleF040_OMA_FEE_MSTR.GetStringValue("FEE_DESC"));
            }
            else
            {
                CurrentValue = QDesign.Pack(FIXED_DOCREV_OMA_CD.Value + " - UNKNOWN FEE CODE");
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
    private DCharacter OMA_CODE_ONLY = new DCharacter("OMA_CODE_ONLY", 4);
    private void OMA_CODE_ONLY_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE"), 1, 4);
            


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
    private DCharacter RPT_SORT_SEQ = new DCharacter("RPT_SORT_SEQ", 4);
    private void RPT_SORT_SEQ_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A135")
            {
                CurrentValue = "E001";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A435")
            {
                CurrentValue = "E002";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A136")
            {
                CurrentValue = "E003";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A133")
            {
                CurrentValue = "E004";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A134")
            {
                CurrentValue = "E005";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "A138")
            {
                CurrentValue = "E006";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K990")
            {
                CurrentValue = "E007";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K991")
            {
                CurrentValue = "E008";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K992")
            {
                CurrentValue = "E009";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K993")
            {
                CurrentValue = "E010";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K994")
            {
                CurrentValue = "E011";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K995")
            {
                CurrentValue = "E012";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K996")
            {
                CurrentValue = "E013";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "K997")
            {
                CurrentValue = "E014";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C135")
            {
                CurrentValue = "D001";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C435")
            {
                CurrentValue = "D002";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C136")
            {
                CurrentValue = "D003";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C133")
            {
                CurrentValue = "D004";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C134")
            {
                CurrentValue = "D005";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C132")
            {
                CurrentValue = "D006";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C137")
            {
                CurrentValue = "D007";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C139")
            {
                CurrentValue = "D008";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C138")
            {
                CurrentValue = "D009";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C121")
            {
                CurrentValue = "D010";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C101")
            {
                CurrentValue = "D011";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C990")
            {
                CurrentValue = "D012";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C991")
            {
                CurrentValue = "D013";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C992")
            {
                CurrentValue = "D014";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C993")
            {
                CurrentValue = "D015";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C994")
            {
                CurrentValue = "D016";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C995")
            {
                CurrentValue = "D017";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C996")
            {
                CurrentValue = "D018";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "C997")
            {
                CurrentValue = "D019";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "R849")
            {
                CurrentValue = "A001";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G325")
            {
                CurrentValue = "A002";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G323")
            {
                CurrentValue = "A003";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G330")
            {
                CurrentValue = "A004";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G331")
            {
                CurrentValue = "A005";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G860")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G862")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G863")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G864")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G865")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G866")
            {
                CurrentValue = "B000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G408")
            {
                CurrentValue = "C000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G409")
            {
                CurrentValue = "C000";
            }
            else if (QDesign.NULL(OMA_CODE_ONLY.Value) == "G412")
            {
                CurrentValue = "C000";
            }
            else if (QDesign.NULL(QDesign.Substring(OMA_CODE_ONLY.Value, 1, 3)) == "MIS")
            {
                CurrentValue = "G000";
            }
            else
            {
                CurrentValue = "F000";
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
    private DCharacter PRESORT_CODE = new DCharacter("PRESORT_CODE", 8);
    private void PRESORT_CODE_GetValue(ref string Value)
    {

        try
        {
            Value = RPT_SORT_SEQ.Value + OMA_CODE_ONLY.Value;


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
    private DCharacter GROUPING = new DCharacter("GROUPING", 1);
    private void GROUPING_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(RPT_SORT_SEQ.Value, 1, 1);


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



    private SqlFileObject fleF050MA1;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("F050MA1");

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

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF040_OMA_FEE_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F040_OMA_FEE_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(4).Substring(0, 1)));
                            
                        m_strWhere.Append(" AND ").Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")).PadRight(4).Substring(1, 1)));
                            

                        fleF040_OMA_FEE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F040_OMA_FEE_MSTR <--


                        if (Transaction())
                        {

                             if (Select_If())
                            {

                                SubFile(ref m_trnTRANS_UPDATE, ref fleF050MA1, SubFileType.Portable, fleF050_DOC_REVENUE_MSTR, "DOCREV_CLINIC_1_2", "DOCREV_DEPT", DOC_NBR, "DOCREV_LOCATION", FIXED_DOCREV_OMA_CD, PRESORT_CODE,
                                GROUPING, OMA_CD_DESC, "DOCREV_MTD_IN_REC", "DOCREV_MTD_IN_SVC", "DOCREV_MTD_OUT_REC", "DOCREV_MTD_OUT_SVC", "DOCREV_YTD_IN_REC", "DOCREV_YTD_IN_SVC", "DOCREV_YTD_OUT_REC", "DOCREV_YTD_OUT_SVC",
                                NAME);



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
            EndRequest("F050MA1");

        }

    }


    #region "Standard Generated Procedures(F050MA1_F050MA1)"

    #region "Transaction Management Procedures(F050MA1_F050MA1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:19 PM

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
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF050MA1.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(F050MA1_F050MA1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:19 PM

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
            fleF040_OMA_FEE_MSTR.Dispose();
            fleF050MA1.Dispose();


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

