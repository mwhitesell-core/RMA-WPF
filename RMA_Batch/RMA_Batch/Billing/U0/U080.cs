#region "Screen Comments"

//  #> PROGRAM-ID.    u080.qts
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : TO RELOAD F010-pat-mstr
//  MODIFICATION HISTORY
//  DATE   WHO     DESCRIPTION
//  2007/04/18 M.C.    make correction for PE, it should be 8 digits instead of 9
//  2011/03/09    MC1   make correction for PE, MB, NL and add NU 
//  2013/04/08    MC2   change `set lock file update` to `set lock record update`
//  refine the edit check on all chart nbrs (5)
//  add subfiles for error E6 to E9
//  2014/02/19    MC3     chart-nbr    -  `M` , `W`
//  chart-nbr-2  -  `K`, `ZB`
//  chart-nbr-3  -  `H002`, `H003`
//  chart-nbr-4  -  `0001`, `0005`, `D`, `E`, `F`
//  chart-nbr-5  -  `J`+10, `J`+8
//  D = Haldimand War Memorial Hospital, Dunnville
//  E = West Haldimand Hospital, Hagersville
//  F = St. Peter`s Hospital, Hamilton
//  W = West Lincoln Memorial Hospital - Grimsby
//  ZB = Bay Area Genetics Lab
//  2016/Nov/28   MC4 - since we set `?`+ikey for chartnbr 4 if blank;
//  then exclude this as error
//  MC2
//  set lock file update
//  ------------------------------------------------

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class U080 : BaseClassControl
{
    private U080 m_U080;
    
    public U080(string Name, int Level) 
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public U080(string Name, int Level, bool Request) 
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose()
    {
        if (!(m_U080 == null))
        {
            m_U080.CloseTransactionObjects();
            m_U080 = null;
        }
    }
    
    public U080 GetU080(int Level)
    {
        if ((m_U080 == null))
        {
            m_U080 = new U080("U080", Level);
        }
        else
        {
            m_U080.ResetValues();
        }
        
        return m_U080;
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.
    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
    protected SqlTransaction m_trnTRANS_UPDATE;

    public override bool RunQTP()
    {
        try
        {
            U080_LOAD_U099_RETAIN_PATIENTS_1 U080_1 = new U080_LOAD_U099_RETAIN_PATIENTS_1(Name, Level);
            U080_1.Run();
            U080_1.Dispose();
            U080_1 = null;

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
}

public class U080_LOAD_U099_RETAIN_PATIENTS_1 : U080
{
    public U080_LOAD_U099_RETAIN_PATIENTS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleU099_RETAIN_PATIENTS = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U099_RETAIN_PATIENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU080_INVALID_RECORDS = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U080_INVALID_RECORDS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleINVALID_PAT_DIRECT = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "INVALID_PAT_DIRECT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleINVALID_BLANKS = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "INVALID_BLANKS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleINVALID_PAT_ACRONYM = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "INVALID_PAT_ACRONYM", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleINVALID_PAT_CHART = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "INVALID_PAT_CHART", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleINVALID_PAT_CHART_2 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "INVALID_PAT_CHART_2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleINVALID_PAT_CHART_3 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "INVALID_PAT_CHART_3", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleINVALID_PAT_CHART_4 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "INVALID_PAT_CHART_4", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleINVALID_PAT_CHART_5 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "INVALID_PAT_CHART_5", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        D_NAME.GetValue += D_NAME_GetValue;
        IKEY.GetValue += IKEY_GetValue;
        D_INVALID_ON_OHIP.GetValue += D_INVALID_ON_OHIP_GetValue;
        T_BIRTH_DATE.GetValue += T_BIRTH_DATE_GetValue;
        D_INVALID_PAT_DIRECT.GetValue += D_INVALID_PAT_DIRECT_GetValue;
        D_INVALID_BLANKS.GetValue += D_INVALID_BLANKS_GetValue;
        D_PAT_ACRONYM.GetValue += D_PAT_ACRONYM_GetValue;
        D_INVALID_PAT_ACRONYM.GetValue += D_INVALID_PAT_ACRONYM_GetValue;
        D_INVALID_PAT_CHART.GetValue += D_INVALID_PAT_CHART_GetValue;
        D_INVALID_PAT_CHART_2.GetValue += D_INVALID_PAT_CHART_2_GetValue;
        D_INVALID_PAT_CHART_3.GetValue += D_INVALID_PAT_CHART_3_GetValue;
        D_INVALID_PAT_CHART_4.GetValue += D_INVALID_PAT_CHART_4_GetValue;
        D_INVALID_PAT_CHART_5.GetValue += D_INVALID_PAT_CHART_5_GetValue;
        D_FILLER.GetValue += D_FILLER_GetValue;

        T_COUNT = new CoreDecimal("T_COUNT", 6, this);
}

#region "Declarations (Variables, Files and Transactions)(U080_LOAD_U099_RETAIN_PATIENTS_1)"

private SqlFileObject fleU099_RETAIN_PATIENTS;

    private DCharacter D_NAME = new DCharacter("D_NAME", 4);
    private void D_NAME_GetValue(ref string Value)
    {
        try
        {
            Value = (QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_SURNAME"), 1, 3) + QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_GIVEN_NAME"), 1, 1));
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

    private DCharacter IKEY = new DCharacter("IKEY", 12);
    private void IKEY_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("KEY_PAT_MSTR"), 4, 12);
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

    private DCharacter D_INVALID_ON_OHIP = new DCharacter("D_INVALID_ON_OHIP", 2);
    private void D_INVALID_ON_OHIP_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY")) != QDesign.NULL(" ")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY")) != QDesign.NULL(IKEY.Value)
                        && (!MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 3), "^^^")
                        && ((QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "AB") && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 10), "######### "))
                        || (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "BC" && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 11), "########## "))
                        || (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "MB" && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 10), "######### "))
                        || (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "NL" && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 13), "############ "))
                        || (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "NB" && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 10), "######### "))
                        || (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "NT" && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 9), "^####### "))
                        || (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "NS" && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 11), "########## "))
                        || (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "PE" && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 9), "######## "))
                        || (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "PQ" && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 4), D_NAME.Value))
                        || (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "SK" && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 10), "######### "))
                        || (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "NU" && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 10), "######### "))
                        || (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_PROV_CD")) == "YT") && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY"), 1, 10), "######### ")))
            {
                CurrentValue = "E1";
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

    private DCharacter T_BIRTH_DATE = new DCharacter("T_BIRTH_DATE", 6);
    private void T_BIRTH_DATE_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(QDesign.ASCII(fleU099_RETAIN_PATIENTS.GetNumericDateValue("PAT_BIRTH_DATE"), 8), 3, 6);
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

    private DCharacter D_INVALID_PAT_DIRECT = new DCharacter("D_INVALID_PAT_DIRECT", 2);
    private void D_INVALID_PAT_DIRECT_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if ((MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_DIRECT_ID"), 1, 3), "^^^")
                        && (QDesign.NULL(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_DIRECT_ID"), 1, 3)) != QDesign.NULL(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_ACRONYM"), 1, 3)))
                        || QDesign.NULL(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_DIRECT_ID"), 4, 6)) != QDesign.NULL(T_BIRTH_DATE.Value))
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_DIRECT_ID")) != QDesign.NULL(" ")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_DIRECT_ID")) != QDesign.NULL(IKEY.Value))
            {
                CurrentValue = "E2";
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

    private DCharacter D_INVALID_BLANKS = new DCharacter("D_INVALID_BLANKS", 2);
    private void D_INVALID_BLANKS_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_OHIP_MMYY")) == QDesign.NULL(" ")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR")) == QDesign.NULL(" ")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_2")) == QDesign.NULL(" ")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_3")) == QDesign.NULL(" ")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_4")) == QDesign.NULL(" ")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_5")) == QDesign.NULL(" ")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetDecimalValue("PAT_HEALTH_NBR")) == QDesign.NULL(0d))
            {
                CurrentValue = "E3";
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

    private DCharacter D_PAT_ACRONYM = new DCharacter("D_PAT_ACRONYM", 9);
    private void D_PAT_ACRONYM_GetValue(ref string Value)
    {
        try
        {
            Value = (QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_SURNAME"), 1, 6) + QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_GIVEN_NAME"), 1, 3));
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

    private DCharacter D_INVALID_PAT_ACRONYM = new DCharacter("D_INVALID_PAT_ACRONYM", 2);
    private void D_INVALID_PAT_ACRONYM_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_ACRONYM")) != QDesign.NULL(D_PAT_ACRONYM.Value) && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_ACRONYM")) != QDesign.NULL(" "))
            {
                CurrentValue = "E4";
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

    private DCharacter D_INVALID_PAT_CHART = new DCharacter("D_INVALID_PAT_CHART", 2);
    private void D_INVALID_PAT_CHART_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (!MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR"), 1, 1), "M")
                        && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR"), 1, 1), "W")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR")) != QDesign.NULL(QDesign.Substring(IKEY.Value, 3, 10))
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR")) != QDesign.NULL(" "))
            {
                CurrentValue = "E5";
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

    private DCharacter D_INVALID_PAT_CHART_2 = new DCharacter("D_INVALID_PAT_CHART_2", 2);
    private void D_INVALID_PAT_CHART_2_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (!MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_2"), 1, 1), "K")
                        && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_2"), 1, 2), "ZB")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_2")) != QDesign.NULL(QDesign.Substring(IKEY.Value, 3, 10))
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_2")) != QDesign.NULL(" "))
            {
                CurrentValue = "E6";
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

    private DCharacter D_INVALID_PAT_CHART_3 = new DCharacter("D_INVALID_PAT_CHART_3", 2);
    private void D_INVALID_PAT_CHART_3_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (!MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_3"), 1, 4), "H002")
                        && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_3"), 1, 4), "H003")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_3")) != QDesign.NULL(QDesign.Substring(IKEY.Value, 3, 10))
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_3")) != QDesign.NULL(" "))
            {
                CurrentValue = "E7";
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

    private DCharacter D_INVALID_PAT_CHART_4 = new DCharacter("D_INVALID_PAT_CHART_4", 2);
    private void D_INVALID_PAT_CHART_4_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;
            if (!MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_4"), 1, 4), "0001")
                        && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_4"), 1, 4), "0005")
                        && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_4"), 1, 1), "D")
                        && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_4"), 1, 1), "E")
                        && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_4"), 1, 1), "F")
                        && !MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_4"), 1, 1), "?")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_4")) != QDesign.NULL(QDesign.Substring(IKEY.Value, 3, 10))
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_4")) != QDesign.NULL(" "))
            {
                CurrentValue = "E8";
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

    private DCharacter D_INVALID_PAT_CHART_5 = new DCharacter("D_INVALID_PAT_CHART_5", 2);
    private void D_INVALID_PAT_CHART_5_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (!MatchPattern(QDesign.Substring(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_5"), 1, 1), "J")
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_5")) != QDesign.NULL(QDesign.Substring(IKEY.Value, 2, 11))
                        && QDesign.NULL(fleU099_RETAIN_PATIENTS.GetStringValue("PAT_CHART_NBR_5")) != QDesign.NULL(" "))
            {
                CurrentValue = "E9";
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

    private DInteger D_FILLER = new DInteger("D_FILLER", 4);
    private void D_FILLER_GetValue(ref Decimal Value)
    {
        try
        {
            Value = 0;
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

    private CoreDecimal T_COUNT;

    private SqlFileObject fleU080_INVALID_RECORDS;
    private SqlFileObject fleINVALID_PAT_DIRECT;
    private SqlFileObject fleINVALID_BLANKS;
    private SqlFileObject fleINVALID_PAT_ACRONYM;
    private SqlFileObject fleINVALID_PAT_CHART;
    private SqlFileObject fleINVALID_PAT_CHART_2;
    private SqlFileObject fleINVALID_PAT_CHART_3;
    private SqlFileObject fleINVALID_PAT_CHART_4;
    private SqlFileObject fleINVALID_PAT_CHART_5;
    private SqlFileObject fleF010_PAT_MSTR;

    #endregion

    #region "Standard Generated Procedures(U080_LOAD_U099_RETAIN_PATIENTS_1)"

    #region "Automatic Item Initialization(U080_LOAD_U099_RETAIN_PATIENTS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(U080_LOAD_U099_RETAIN_PATIENTS_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 8/30/2019 9:57:26 AM

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
        fleU099_RETAIN_PATIENTS.Transaction = m_trnTRANS_UPDATE;
        fleU080_INVALID_RECORDS.Transaction = m_trnTRANS_UPDATE;
        fleINVALID_PAT_DIRECT.Transaction = m_trnTRANS_UPDATE;
        fleINVALID_BLANKS.Transaction = m_trnTRANS_UPDATE;
        fleINVALID_PAT_ACRONYM.Transaction = m_trnTRANS_UPDATE;
        fleINVALID_PAT_CHART.Transaction = m_trnTRANS_UPDATE;
        fleINVALID_PAT_CHART_2.Transaction = m_trnTRANS_UPDATE;
        fleINVALID_PAT_CHART_3.Transaction = m_trnTRANS_UPDATE;
        fleINVALID_PAT_CHART_4.Transaction = m_trnTRANS_UPDATE;
        fleINVALID_PAT_CHART_5.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(U080_LOAD_U099_RETAIN_PATIENTS_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 8/30/2019 9:57:26 AM

    // #-----------------------------------------
    // # InitializeFiles Procedure.
    // #-----------------------------------------
    protected override void InitializeFiles()
    {
        try {
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
            fleU099_RETAIN_PATIENTS.Dispose();
            fleU080_INVALID_RECORDS.Dispose();
            fleINVALID_PAT_DIRECT.Dispose();
            fleINVALID_BLANKS.Dispose();
            fleINVALID_PAT_ACRONYM.Dispose();
            fleINVALID_PAT_CHART.Dispose();
            fleINVALID_PAT_CHART_2.Dispose();
            fleINVALID_PAT_CHART_3.Dispose();
            fleINVALID_PAT_CHART_4.Dispose();
            fleINVALID_PAT_CHART_5.Dispose();
            fleF010_PAT_MSTR.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U080_LOAD_U099_RETAIN_PATIENTS_1)"

    public void Run()
    {
        try
        {
            Request("LOAD_U099_RETAIN_PATIENTS_1");

            while (fleU099_RETAIN_PATIENTS.QTPForMissing())
            {
                //  --> GET U099_RETAIN_PATIENTS <--
                fleU099_RETAIN_PATIENTS.GetData();
                //  --> End GET U099_RETAIN_PATIENTS <--

                if (Transaction())
                {
                    T_COUNT.Value = (T_COUNT.Value + 1);

                    SubFile(ref m_trnTRANS_UPDATE, "U080_INVALID_RECORDS", QDesign.NULL(D_INVALID_ON_OHIP.Value) == "E1", SubFileType.Keep, T_COUNT, D_INVALID_ON_OHIP, fleU099_RETAIN_PATIENTS, "PAT_ACRONYM", "PAT_OHIP_MMYY", "PAT_CHART_NBR", "PAT_CHART_NBR_2", "PAT_CHART_NBR_3", "PAT_CHART_NBR_4", "PAT_CHART_NBR_5", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_INIT", "PAT_LOCATION_FIELD", D_FILLER, "PAT_LAST_DOC_NBR_SEEN", "PAT_BIRTH_DATE", "PAT_DATE_LAST_MAINT", "PAT_DATE_LAST_VISIT", "PAT_DATE_LAST_ADMIT", "PAT_PHONE_NBR", "PAT_PROV_CD");
                    SubFile(ref m_trnTRANS_UPDATE, "INVALID_PAT_DIRECT", QDesign.NULL(D_INVALID_PAT_DIRECT.Value) == "E2", SubFileType.Temp, T_COUNT, D_INVALID_PAT_DIRECT, fleU099_RETAIN_PATIENTS, "PAT_ACRONYM", "PAT_OHIP_MMYY", "PAT_CHART_NBR", "PAT_CHART_NBR_2", "PAT_CHART_NBR_3", "PAT_CHART_NBR_4", "PAT_CHART_NBR_5", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_INIT", "PAT_LOCATION_FIELD", D_FILLER, "PAT_LAST_DOC_NBR_SEEN", "PAT_BIRTH_DATE", "PAT_DATE_LAST_MAINT", "PAT_DATE_LAST_VISIT", "PAT_DATE_LAST_ADMIT", "PAT_PHONE_NBR", "PAT_PROV_CD");
                    SubFile(ref m_trnTRANS_UPDATE, "INVALID_BLANKS", QDesign.NULL(D_INVALID_BLANKS.Value) == "E3", SubFileType.Temp, T_COUNT, D_INVALID_BLANKS, fleU099_RETAIN_PATIENTS, "PAT_ACRONYM", "PAT_OHIP_MMYY", "PAT_CHART_NBR", "PAT_CHART_NBR_2", "PAT_CHART_NBR_3", "PAT_CHART_NBR_4", "PAT_CHART_NBR_5", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_INIT", "PAT_LOCATION_FIELD", D_FILLER, "PAT_LAST_DOC_NBR_SEEN", "PAT_BIRTH_DATE", "PAT_DATE_LAST_MAINT", "PAT_DATE_LAST_VISIT", "PAT_DATE_LAST_ADMIT", "PAT_PHONE_NBR", "PAT_PROV_CD");
                    SubFile(ref m_trnTRANS_UPDATE, "INVALID_PAT_ACRONYM", QDesign.NULL(D_INVALID_PAT_ACRONYM.Value) == "E4", SubFileType.Temp, T_COUNT, D_INVALID_PAT_ACRONYM, fleU099_RETAIN_PATIENTS, "PAT_ACRONYM", "PAT_OHIP_MMYY", "PAT_CHART_NBR", "PAT_CHART_NBR_2", "PAT_CHART_NBR_3", "PAT_CHART_NBR_4", "PAT_CHART_NBR_5", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_INIT", "PAT_LOCATION_FIELD", D_FILLER, "PAT_LAST_DOC_NBR_SEEN", "PAT_BIRTH_DATE", "PAT_DATE_LAST_MAINT", "PAT_DATE_LAST_VISIT", "PAT_DATE_LAST_ADMIT", "PAT_PHONE_NBR", "PAT_PROV_CD");
                    SubFile(ref m_trnTRANS_UPDATE, "INVALID_PAT_CHART", QDesign.NULL(D_INVALID_PAT_CHART.Value) == "E5", SubFileType.Temp, T_COUNT, D_INVALID_PAT_CHART, fleU099_RETAIN_PATIENTS, "PAT_ACRONYM", "PAT_OHIP_MMYY", "PAT_CHART_NBR", "PAT_CHART_NBR_2", "PAT_CHART_NBR_3", "PAT_CHART_NBR_4", "PAT_CHART_NBR_5", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_INIT", "PAT_LOCATION_FIELD", D_FILLER, "PAT_LAST_DOC_NBR_SEEN", "PAT_BIRTH_DATE", "PAT_DATE_LAST_MAINT", "PAT_DATE_LAST_VISIT", "PAT_DATE_LAST_ADMIT", "PAT_PHONE_NBR", "PAT_PROV_CD");
                    SubFile(ref m_trnTRANS_UPDATE, "INVALID_PAT_CHART_2", QDesign.NULL(D_INVALID_PAT_CHART_2.Value) == "E6", SubFileType.Temp, T_COUNT, D_INVALID_PAT_CHART_2, fleU099_RETAIN_PATIENTS, "PAT_ACRONYM", "PAT_OHIP_MMYY", "PAT_CHART_NBR", "PAT_CHART_NBR_2", "PAT_CHART_NBR_3", "PAT_CHART_NBR_4", "PAT_CHART_NBR_5", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_INIT", "PAT_LOCATION_FIELD", D_FILLER, "PAT_LAST_DOC_NBR_SEEN", "PAT_BIRTH_DATE", "PAT_DATE_LAST_MAINT", "PAT_DATE_LAST_VISIT", "PAT_DATE_LAST_ADMIT", "PAT_PHONE_NBR", "PAT_PROV_CD");
                    SubFile(ref m_trnTRANS_UPDATE, "INVALID_PAT_CHART_3", QDesign.NULL(D_INVALID_PAT_CHART_3.Value) == "E7", SubFileType.Temp, T_COUNT, D_INVALID_PAT_CHART_3, fleU099_RETAIN_PATIENTS, "PAT_ACRONYM", "PAT_OHIP_MMYY", "PAT_CHART_NBR", "PAT_CHART_NBR_2", "PAT_CHART_NBR_3", "PAT_CHART_NBR_4", "PAT_CHART_NBR_5", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_INIT", "PAT_LOCATION_FIELD", D_FILLER, "PAT_LAST_DOC_NBR_SEEN", "PAT_BIRTH_DATE", "PAT_DATE_LAST_MAINT", "PAT_DATE_LAST_VISIT", "PAT_DATE_LAST_ADMIT", "PAT_PHONE_NBR", "PAT_PROV_CD");
                    SubFile(ref m_trnTRANS_UPDATE, "INVALID_PAT_CHART_4", QDesign.NULL(D_INVALID_PAT_CHART_4.Value) == "E8", SubFileType.Temp, T_COUNT, D_INVALID_PAT_CHART_4, fleU099_RETAIN_PATIENTS, "PAT_ACRONYM", "PAT_OHIP_MMYY", "PAT_CHART_NBR", "PAT_CHART_NBR_2", "PAT_CHART_NBR_3", "PAT_CHART_NBR_4", "PAT_CHART_NBR_5", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_INIT", "PAT_LOCATION_FIELD", D_FILLER, "PAT_LAST_DOC_NBR_SEEN", "PAT_BIRTH_DATE", "PAT_DATE_LAST_MAINT", "PAT_DATE_LAST_VISIT", "PAT_DATE_LAST_ADMIT", "PAT_PHONE_NBR", "PAT_PROV_CD");
                    SubFile(ref m_trnTRANS_UPDATE, "INVALID_PAT_CHART_5", QDesign.NULL(D_INVALID_PAT_CHART_5.Value) == "E9", SubFileType.Temp, T_COUNT, D_INVALID_PAT_CHART_5, fleU099_RETAIN_PATIENTS, "PAT_ACRONYM", "PAT_OHIP_MMYY", "PAT_CHART_NBR", "PAT_CHART_NBR_2", "PAT_CHART_NBR_3", "PAT_CHART_NBR_4", "PAT_CHART_NBR_5", "PAT_SURNAME", "PAT_GIVEN_NAME", "PAT_INIT", "PAT_LOCATION_FIELD", D_FILLER, "PAT_LAST_DOC_NBR_SEEN", "PAT_BIRTH_DATE", "PAT_DATE_LAST_MAINT", "PAT_DATE_LAST_VISIT", "PAT_DATE_LAST_ADMIT", "PAT_PHONE_NBR", "PAT_PROV_CD");

                    fleF010_PAT_MSTR.OutPut(OutPutType.Add);
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
            EndRequest("LOAD_U099_RETAIN_PATIENTS_1");
        }
    }

    #endregion
}
// LOAD_U099_RETAIN_PATIENTS_1