
#region "Screen Comments"

// #> PROGRAM-ID.     U110_1.QTS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// Create EARNINGS transactions in F110-COMPENSATION for
// the current EP-NBR using MTD values taken from F050-REVENUE-MSTR
// STAGE 1 - create subfile of values from F050-REVENUE-MSTR
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 93/JUN/01  ____   B.E.     - original
// 93/AUG/02  ____   B.E.     - criteria for output of a transaction
// changed from > 0 to <> 0 to allow
// negative only transactions
// 93/OCT/07  ____   B.E.     - change summing from YTD to MTD amounts
// 93/OCT/11  ____   B.E.     - criteria for output of transactions changed
// to force creation if any record found in
// in F050
// 94/FEB/17  ____   M.C.     - MODIFY PGM TO INCLUDE HSC LOCATION
// 95/OCT/19  ----   M.C.     - PDR 631 - INCLUDE OMA CD `MICV`,
// `MICM`, `MISJ`, `MISP`, `MOHR`
// 99/feb/24  ----   B.E.     - add new miscellaneous payment codes of
// `MICB`, MIBR` and `MINH`
// 99/dec/20  ----   B.E.  - added MHSC (also allow DHSC which was
// mistakenly entered - s/b MHSC
// 06/jul/11  ----   B.E.  - added DHSC and then changed to DHSC
// 06/sep/07  ----   b.e.   - added AGEP 
// 07/jul/03  ----   b.e.     - added MICA - MICL
// 08/may/26  ----   M.C.     - original u110.qts has been splitted into U110_1 & u110_2
// as per Brad`s request, it only allows 30 subfiles
// 14/May/01  ----   MC1      - remove global temp MICF - MICL as they have transferred to u110_2.qts
// -------------------------------------------------------
// IF UPDATING THIS FILE ALSO UPDATE THE FOLLOWING FILES:
// costing_billing_codes_?.q?s 
// This program has an include:
// either - u110_rma_1.qts or u110_hsc.qts
// NOTE:  in the future, if new codes to be included, please add to U110_2.qts &
// and/or u110_rma_2.qts for RMA
// -------------------------------------------------------
// MC1
// MC1 - end


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U110_1 : BaseClassControl
{

    private U110_1 m_U110_1;

    public U110_1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        BILL_SEQ = new CoreDecimal("BILL_SEQ", 2, this, ResetTypes.ResetAtStartup);
        BILL_TYPE = new CoreCharacter("BILL_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        BILL_FACTOR = new CoreDecimal("BILL_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        AFPIN_SEQ = new CoreDecimal("AFPIN_SEQ", 2, this, ResetTypes.ResetAtStartup);
        AFPIN_TYPE = new CoreCharacter("AFPIN_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        AFPIN_FACTOR = new CoreDecimal("AFPIN_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        AFPOUT_SEQ = new CoreDecimal("AFPOUT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        AFPOUT_TYPE = new CoreCharacter("AFPOUT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        AFPOUT_FACTOR = new CoreDecimal("AFPOUT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC0_SEQ = new CoreDecimal("MISC0_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC0_TYPE = new CoreCharacter("MISC0_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC0_FACTOR = new CoreDecimal("MISC0_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC1_SEQ = new CoreDecimal("MISC1_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC1_TYPE = new CoreCharacter("MISC1_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC1_FACTOR = new CoreDecimal("MISC1_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC2_SEQ = new CoreDecimal("MISC2_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC2_TYPE = new CoreCharacter("MISC2_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC2_FACTOR = new CoreDecimal("MISC2_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC3_SEQ = new CoreDecimal("MISC3_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC3_TYPE = new CoreCharacter("MISC3_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC3_FACTOR = new CoreDecimal("MISC3_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC4_SEQ = new CoreDecimal("MISC4_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC4_TYPE = new CoreCharacter("MISC4_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC4_FACTOR = new CoreDecimal("MISC4_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC5_SEQ = new CoreDecimal("MISC5_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC5_TYPE = new CoreCharacter("MISC5_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC5_FACTOR = new CoreDecimal("MISC5_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC6_SEQ = new CoreDecimal("MISC6_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC6_TYPE = new CoreCharacter("MISC6_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC6_FACTOR = new CoreDecimal("MISC6_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC7_SEQ = new CoreDecimal("MISC7_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC7_TYPE = new CoreCharacter("MISC7_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC7_FACTOR = new CoreDecimal("MISC7_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC8_SEQ = new CoreDecimal("MISC8_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC8_TYPE = new CoreCharacter("MISC8_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC8_FACTOR = new CoreDecimal("MISC8_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC9_SEQ = new CoreDecimal("MISC9_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC9_TYPE = new CoreCharacter("MISC9_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC9_FACTOR = new CoreDecimal("MISC9_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICV_SEQ = new CoreDecimal("MICV_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICV_TYPE = new CoreCharacter("MICV_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICV_FACTOR = new CoreDecimal("MICV_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICM_SEQ = new CoreDecimal("MICM_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICM_TYPE = new CoreCharacter("MICM_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICM_FACTOR = new CoreDecimal("MICM_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISJ_SEQ = new CoreDecimal("MISJ_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISJ_TYPE = new CoreCharacter("MISJ_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISJ_FACTOR = new CoreDecimal("MISJ_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISP_SEQ = new CoreDecimal("MISP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISP_TYPE = new CoreCharacter("MISP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISP_FACTOR = new CoreDecimal("MISP_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MOHR_SEQ = new CoreDecimal("MOHR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MOHR_TYPE = new CoreCharacter("MOHR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MOHR_FACTOR = new CoreDecimal("MOHR_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICB_SEQ = new CoreDecimal("MICB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICB_TYPE = new CoreCharacter("MICB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICB_FACTOR = new CoreDecimal("MICB_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MIBR_SEQ = new CoreDecimal("MIBR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MIBR_TYPE = new CoreCharacter("MIBR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MIBR_FACTOR = new CoreDecimal("MIBR_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MINH_SEQ = new CoreDecimal("MINH_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MINH_TYPE = new CoreCharacter("MINH_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MINH_FACTOR = new CoreDecimal("MINH_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MHSC_SEQ = new CoreDecimal("MHSC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MHSC_TYPE = new CoreCharacter("MHSC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MHSC_FACTOR = new CoreDecimal("MHSC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DHSC_SEQ = new CoreDecimal("DHSC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DHSC_TYPE = new CoreCharacter("DHSC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DHSC_FACTOR = new CoreDecimal("DHSC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        AGEP_SEQ = new CoreDecimal("AGEP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        AGEP_TYPE = new CoreCharacter("AGEP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        AGEP_FACTOR = new CoreDecimal("AGEP_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICA_SEQ = new CoreDecimal("MICA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICA_TYPE = new CoreCharacter("MICA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICA_FACTOR = new CoreDecimal("MICA_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICC_SEQ = new CoreDecimal("MICC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICC_TYPE = new CoreCharacter("MICC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICC_FACTOR = new CoreDecimal("MICC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICD_SEQ = new CoreDecimal("MICD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICD_TYPE = new CoreCharacter("MICD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICD_FACTOR = new CoreDecimal("MICD_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICE_SEQ = new CoreDecimal("MICE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICE_TYPE = new CoreCharacter("MICE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICE_FACTOR = new CoreDecimal("MICE_FACTOR", 6, this, ResetTypes.ResetAtStartup);


    }

    public U110_1(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        BILL_SEQ = new CoreDecimal("BILL_SEQ", 2, this, ResetTypes.ResetAtStartup);
        BILL_TYPE = new CoreCharacter("BILL_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        BILL_FACTOR = new CoreDecimal("BILL_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        AFPIN_SEQ = new CoreDecimal("AFPIN_SEQ", 2, this, ResetTypes.ResetAtStartup);
        AFPIN_TYPE = new CoreCharacter("AFPIN_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        AFPIN_FACTOR = new CoreDecimal("AFPIN_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        AFPOUT_SEQ = new CoreDecimal("AFPOUT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        AFPOUT_TYPE = new CoreCharacter("AFPOUT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        AFPOUT_FACTOR = new CoreDecimal("AFPOUT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC0_SEQ = new CoreDecimal("MISC0_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC0_TYPE = new CoreCharacter("MISC0_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC0_FACTOR = new CoreDecimal("MISC0_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC1_SEQ = new CoreDecimal("MISC1_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC1_TYPE = new CoreCharacter("MISC1_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC1_FACTOR = new CoreDecimal("MISC1_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC2_SEQ = new CoreDecimal("MISC2_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC2_TYPE = new CoreCharacter("MISC2_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC2_FACTOR = new CoreDecimal("MISC2_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC3_SEQ = new CoreDecimal("MISC3_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC3_TYPE = new CoreCharacter("MISC3_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC3_FACTOR = new CoreDecimal("MISC3_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC4_SEQ = new CoreDecimal("MISC4_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC4_TYPE = new CoreCharacter("MISC4_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC4_FACTOR = new CoreDecimal("MISC4_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC5_SEQ = new CoreDecimal("MISC5_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC5_TYPE = new CoreCharacter("MISC5_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC5_FACTOR = new CoreDecimal("MISC5_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC6_SEQ = new CoreDecimal("MISC6_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC6_TYPE = new CoreCharacter("MISC6_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC6_FACTOR = new CoreDecimal("MISC6_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC7_SEQ = new CoreDecimal("MISC7_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC7_TYPE = new CoreCharacter("MISC7_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC7_FACTOR = new CoreDecimal("MISC7_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC8_SEQ = new CoreDecimal("MISC8_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC8_TYPE = new CoreCharacter("MISC8_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC8_FACTOR = new CoreDecimal("MISC8_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISC9_SEQ = new CoreDecimal("MISC9_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISC9_TYPE = new CoreCharacter("MISC9_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISC9_FACTOR = new CoreDecimal("MISC9_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICV_SEQ = new CoreDecimal("MICV_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICV_TYPE = new CoreCharacter("MICV_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICV_FACTOR = new CoreDecimal("MICV_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICM_SEQ = new CoreDecimal("MICM_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICM_TYPE = new CoreCharacter("MICM_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICM_FACTOR = new CoreDecimal("MICM_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISJ_SEQ = new CoreDecimal("MISJ_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISJ_TYPE = new CoreCharacter("MISJ_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISJ_FACTOR = new CoreDecimal("MISJ_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MISP_SEQ = new CoreDecimal("MISP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MISP_TYPE = new CoreCharacter("MISP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MISP_FACTOR = new CoreDecimal("MISP_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MOHR_SEQ = new CoreDecimal("MOHR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MOHR_TYPE = new CoreCharacter("MOHR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MOHR_FACTOR = new CoreDecimal("MOHR_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICB_SEQ = new CoreDecimal("MICB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICB_TYPE = new CoreCharacter("MICB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICB_FACTOR = new CoreDecimal("MICB_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MIBR_SEQ = new CoreDecimal("MIBR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MIBR_TYPE = new CoreCharacter("MIBR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MIBR_FACTOR = new CoreDecimal("MIBR_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MINH_SEQ = new CoreDecimal("MINH_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MINH_TYPE = new CoreCharacter("MINH_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MINH_FACTOR = new CoreDecimal("MINH_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MHSC_SEQ = new CoreDecimal("MHSC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MHSC_TYPE = new CoreCharacter("MHSC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MHSC_FACTOR = new CoreDecimal("MHSC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DHSC_SEQ = new CoreDecimal("DHSC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DHSC_TYPE = new CoreCharacter("DHSC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DHSC_FACTOR = new CoreDecimal("DHSC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        AGEP_SEQ = new CoreDecimal("AGEP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        AGEP_TYPE = new CoreCharacter("AGEP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        AGEP_FACTOR = new CoreDecimal("AGEP_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICA_SEQ = new CoreDecimal("MICA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICA_TYPE = new CoreCharacter("MICA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICA_FACTOR = new CoreDecimal("MICA_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICC_SEQ = new CoreDecimal("MICC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICC_TYPE = new CoreCharacter("MICC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICC_FACTOR = new CoreDecimal("MICC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICD_SEQ = new CoreDecimal("MICD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICD_TYPE = new CoreCharacter("MICD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICD_FACTOR = new CoreDecimal("MICD_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        MICE_SEQ = new CoreDecimal("MICE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        MICE_TYPE = new CoreCharacter("MICE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        MICE_FACTOR = new CoreDecimal("MICE_FACTOR", 6, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_U110_1 != null))
        {
            m_U110_1.CloseTransactionObjects();
            m_U110_1 = null;
        }
    }

    public U110_1 GetU110_1(int Level)
    {
        if (m_U110_1 == null)
        {
            m_U110_1 = new U110_1("U110_1", Level);
        }
        else
        {
            m_U110_1.ResetValues();
        }
        return m_U110_1;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal BILL_SEQ;
    protected CoreCharacter BILL_TYPE;
    protected CoreDecimal BILL_FACTOR;
    protected CoreDecimal AFPIN_SEQ;
    protected CoreCharacter AFPIN_TYPE;
    protected CoreDecimal AFPIN_FACTOR;
    protected CoreDecimal AFPOUT_SEQ;
    protected CoreCharacter AFPOUT_TYPE;
    protected CoreDecimal AFPOUT_FACTOR;
    protected CoreDecimal MISC0_SEQ;
    protected CoreCharacter MISC0_TYPE;
    protected CoreDecimal MISC0_FACTOR;
    protected CoreDecimal MISC1_SEQ;
    protected CoreCharacter MISC1_TYPE;
    protected CoreDecimal MISC1_FACTOR;
    protected CoreDecimal MISC2_SEQ;
    protected CoreCharacter MISC2_TYPE;
    protected CoreDecimal MISC2_FACTOR;
    protected CoreDecimal MISC3_SEQ;
    protected CoreCharacter MISC3_TYPE;
    protected CoreDecimal MISC3_FACTOR;
    protected CoreDecimal MISC4_SEQ;
    protected CoreCharacter MISC4_TYPE;
    protected CoreDecimal MISC4_FACTOR;
    protected CoreDecimal MISC5_SEQ;
    protected CoreCharacter MISC5_TYPE;
    protected CoreDecimal MISC5_FACTOR;
    protected CoreDecimal MISC6_SEQ;
    protected CoreCharacter MISC6_TYPE;
    protected CoreDecimal MISC6_FACTOR;
    protected CoreDecimal MISC7_SEQ;
    protected CoreCharacter MISC7_TYPE;
    protected CoreDecimal MISC7_FACTOR;
    protected CoreDecimal MISC8_SEQ;
    protected CoreCharacter MISC8_TYPE;
    protected CoreDecimal MISC8_FACTOR;
    protected CoreDecimal MISC9_SEQ;
    protected CoreCharacter MISC9_TYPE;
    protected CoreDecimal MISC9_FACTOR;
    protected CoreDecimal MICV_SEQ;
    protected CoreCharacter MICV_TYPE;
    protected CoreDecimal MICV_FACTOR;
    protected CoreDecimal MICM_SEQ;
    protected CoreCharacter MICM_TYPE;
    protected CoreDecimal MICM_FACTOR;
    protected CoreDecimal MISJ_SEQ;
    protected CoreCharacter MISJ_TYPE;
    protected CoreDecimal MISJ_FACTOR;
    protected CoreDecimal MISP_SEQ;
    protected CoreCharacter MISP_TYPE;
    protected CoreDecimal MISP_FACTOR;
    protected CoreDecimal MOHR_SEQ;
    protected CoreCharacter MOHR_TYPE;
    protected CoreDecimal MOHR_FACTOR;
    protected CoreDecimal MICB_SEQ;
    protected CoreCharacter MICB_TYPE;
    protected CoreDecimal MICB_FACTOR;
    protected CoreDecimal MIBR_SEQ;
    protected CoreCharacter MIBR_TYPE;
    protected CoreDecimal MIBR_FACTOR;
    protected CoreDecimal MINH_SEQ;
    protected CoreCharacter MINH_TYPE;
    protected CoreDecimal MINH_FACTOR;
    protected CoreDecimal MHSC_SEQ;
    protected CoreCharacter MHSC_TYPE;
    protected CoreDecimal MHSC_FACTOR;
    protected CoreDecimal DHSC_SEQ;
    protected CoreCharacter DHSC_TYPE;
    protected CoreDecimal DHSC_FACTOR;
    protected CoreDecimal AGEP_SEQ;
    protected CoreCharacter AGEP_TYPE;
    protected CoreDecimal AGEP_FACTOR;
    protected CoreDecimal MICA_SEQ;
    protected CoreCharacter MICA_TYPE;
    protected CoreDecimal MICA_FACTOR;
    protected CoreDecimal MICC_SEQ;
    protected CoreCharacter MICC_TYPE;
    protected CoreDecimal MICC_FACTOR;
    protected CoreDecimal MICD_SEQ;
    protected CoreCharacter MICD_TYPE;
    protected CoreDecimal MICD_FACTOR;
    protected CoreDecimal MICE_SEQ;
    protected CoreCharacter MICE_TYPE;

    protected CoreDecimal MICE_FACTOR;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U110_1_U111_A_GET_BILL_1 U111_A_GET_BILL_1 = new U110_1_U111_A_GET_BILL_1(Name, Level);
            U111_A_GET_BILL_1.Run();
            U111_A_GET_BILL_1.Dispose();
            U111_A_GET_BILL_1 = null;

            U110_1_U111_A_GET_AFPIN_2 U111_A_GET_AFPIN_2 = new U110_1_U111_A_GET_AFPIN_2(Name, Level);
            U111_A_GET_AFPIN_2.Run();
            U111_A_GET_AFPIN_2.Dispose();
            U111_A_GET_AFPIN_2 = null;

            U110_1_U111_A_GET_AFPOUT_3 U111_A_GET_AFPOUT_3 = new U110_1_U111_A_GET_AFPOUT_3(Name, Level);
            U111_A_GET_AFPOUT_3.Run();
            U111_A_GET_AFPOUT_3.Dispose();
            U111_A_GET_AFPOUT_3 = null;

            U110_1_U111_A_GET_MISC0_4 U111_A_GET_MISC0_4 = new U110_1_U111_A_GET_MISC0_4(Name, Level);
            U111_A_GET_MISC0_4.Run();
            U111_A_GET_MISC0_4.Dispose();
            U111_A_GET_MISC0_4 = null;

            U110_1_U111_A_GET_MISC1_5 U111_A_GET_MISC1_5 = new U110_1_U111_A_GET_MISC1_5(Name, Level);
            U111_A_GET_MISC1_5.Run();
            U111_A_GET_MISC1_5.Dispose();
            U111_A_GET_MISC1_5 = null;

            U110_1_U111_A_GET_MISC2_6 U111_A_GET_MISC2_6 = new U110_1_U111_A_GET_MISC2_6(Name, Level);
            U111_A_GET_MISC2_6.Run();
            U111_A_GET_MISC2_6.Dispose();
            U111_A_GET_MISC2_6 = null;

            U110_1_U111_A_GET_MISC3_7 U111_A_GET_MISC3_7 = new U110_1_U111_A_GET_MISC3_7(Name, Level);
            U111_A_GET_MISC3_7.Run();
            U111_A_GET_MISC3_7.Dispose();
            U111_A_GET_MISC3_7 = null;

            U110_1_U111_A_GET_MISC4_8 U111_A_GET_MISC4_8 = new U110_1_U111_A_GET_MISC4_8(Name, Level);
            U111_A_GET_MISC4_8.Run();
            U111_A_GET_MISC4_8.Dispose();
            U111_A_GET_MISC4_8 = null;

            U110_1_U111_A_GET_MISC5_9 U111_A_GET_MISC5_9 = new U110_1_U111_A_GET_MISC5_9(Name, Level);
            U111_A_GET_MISC5_9.Run();
            U111_A_GET_MISC5_9.Dispose();
            U111_A_GET_MISC5_9 = null;

            U110_1_U111_A_GET_MISC6_10 U111_A_GET_MISC6_10 = new U110_1_U111_A_GET_MISC6_10(Name, Level);
            U111_A_GET_MISC6_10.Run();
            U111_A_GET_MISC6_10.Dispose();
            U111_A_GET_MISC6_10 = null;

            U110_1_U111_A_GET_MISC7_11 U111_A_GET_MISC7_11 = new U110_1_U111_A_GET_MISC7_11(Name, Level);
            U111_A_GET_MISC7_11.Run();
            U111_A_GET_MISC7_11.Dispose();
            U111_A_GET_MISC7_11 = null;

            U110_1_U111_A_GET_MISC8_12 U111_A_GET_MISC8_12 = new U110_1_U111_A_GET_MISC8_12(Name, Level);
            U111_A_GET_MISC8_12.Run();
            U111_A_GET_MISC8_12.Dispose();
            U111_A_GET_MISC8_12 = null;

            U110_1_U111_A_GET_MISC9_13 U111_A_GET_MISC9_13 = new U110_1_U111_A_GET_MISC9_13(Name, Level);
            U111_A_GET_MISC9_13.Run();
            U111_A_GET_MISC9_13.Dispose();
            U111_A_GET_MISC9_13 = null;

            U110_1_U111_A_GET_MICV_14 U111_A_GET_MICV_14 = new U110_1_U111_A_GET_MICV_14(Name, Level);
            U111_A_GET_MICV_14.Run();
            U111_A_GET_MICV_14.Dispose();
            U111_A_GET_MICV_14 = null;

            U110_1_U111_A_GET_MICM_15 U111_A_GET_MICM_15 = new U110_1_U111_A_GET_MICM_15(Name, Level);
            U111_A_GET_MICM_15.Run();
            U111_A_GET_MICM_15.Dispose();
            U111_A_GET_MICM_15 = null;

            U110_1_U111_A_GET_MISJ_16 U111_A_GET_MISJ_16 = new U110_1_U111_A_GET_MISJ_16(Name, Level);
            U111_A_GET_MISJ_16.Run();
            U111_A_GET_MISJ_16.Dispose();
            U111_A_GET_MISJ_16 = null;

            U110_1_U111_A_GET_MICB_17 U111_A_GET_MICB_17 = new U110_1_U111_A_GET_MICB_17(Name, Level);
            U111_A_GET_MICB_17.Run();
            U111_A_GET_MICB_17.Dispose();
            U111_A_GET_MICB_17 = null;

            U110_1_U111_A_GET_MIBR_18 U111_A_GET_MIBR_18 = new U110_1_U111_A_GET_MIBR_18(Name, Level);
            U111_A_GET_MIBR_18.Run();
            U111_A_GET_MIBR_18.Dispose();
            U111_A_GET_MIBR_18 = null;

            U110_1_U111_A_GET_MINH_19 U111_A_GET_MINH_19 = new U110_1_U111_A_GET_MINH_19(Name, Level);
            U111_A_GET_MINH_19.Run();
            U111_A_GET_MINH_19.Dispose();
            U111_A_GET_MINH_19 = null;

            U110_1_U111_A_GET_MISP_20 U111_A_GET_MISP_20 = new U110_1_U111_A_GET_MISP_20(Name, Level);
            U111_A_GET_MISP_20.Run();
            U111_A_GET_MISP_20.Dispose();
            U111_A_GET_MISP_20 = null;

            U110_1_U111_A_GET_MOHR_21 U111_A_GET_MOHR_21 = new U110_1_U111_A_GET_MOHR_21(Name, Level);
            U111_A_GET_MOHR_21.Run();
            U111_A_GET_MOHR_21.Dispose();
            U111_A_GET_MOHR_21 = null;

            U110_1_U111_A_GET_MHSC_22 U111_A_GET_MHSC_22 = new U110_1_U111_A_GET_MHSC_22(Name, Level);
            U111_A_GET_MHSC_22.Run();
            U111_A_GET_MHSC_22.Dispose();
            U111_A_GET_MHSC_22 = null;

            U110_1_U111_A_GET_DHSC_23 U111_A_GET_DHSC_23 = new U110_1_U111_A_GET_DHSC_23(Name, Level);
            U111_A_GET_DHSC_23.Run();
            U111_A_GET_DHSC_23.Dispose();
            U111_A_GET_DHSC_23 = null;

            U110_1_U111_A_GET_AGEP_24 U111_A_GET_AGEP_24 = new U110_1_U111_A_GET_AGEP_24(Name, Level);
            U111_A_GET_AGEP_24.Run();
            U111_A_GET_AGEP_24.Dispose();
            U111_A_GET_AGEP_24 = null;

            U110_1_U110_PROCESS_25 U110_PROCESS_25 = new U110_1_U110_PROCESS_25(Name, Level);
            U110_PROCESS_25.Run();
            U110_PROCESS_25.Dispose();
            U110_PROCESS_25 = null;

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



public class U110_1_U111_A_GET_BILL_1 : U110_1
{

    public U110_1_U111_A_GET_BILL_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_BILL_1)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("BILL"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_BILL_1)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_BILL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_BILL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:44 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_BILL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:44 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_BILL_1)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_BILL_1");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    BILL_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    BILL_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    BILL_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_BILL_1");

        }

    }







    #endregion


}
//U111_A_GET_BILL_1



public class U110_1_U111_A_GET_AFPIN_2 : U110_1
{

    public U110_1_U111_A_GET_AFPIN_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_AFPIN_2)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("AFPIN"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_AFPIN_2)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_AFPIN_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_AFPIN_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:44 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_AFPIN_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:44 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_AFPIN_2)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_AFPIN_2");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    AFPIN_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    AFPIN_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    AFPIN_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_AFPIN_2");

        }

    }







    #endregion


}
//U111_A_GET_AFPIN_2



public class U110_1_U111_A_GET_AFPOUT_3 : U110_1
{

    public U110_1_U111_A_GET_AFPOUT_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_AFPOUT_3)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("AFPOUT"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_AFPOUT_3)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_AFPOUT_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_AFPOUT_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:44 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_AFPOUT_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:44 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_AFPOUT_3)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_AFPOUT_3");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    AFPOUT_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    AFPOUT_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    AFPOUT_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_AFPOUT_3");

        }

    }







    #endregion


}
//U111_A_GET_AFPOUT_3



public class U110_1_U111_A_GET_MISC0_4 : U110_1
{

    public U110_1_U111_A_GET_MISC0_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISC0_4)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISC0"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISC0_4)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISC0_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISC0_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:45 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISC0_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:45 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISC0_4)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISC0_4");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISC0_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISC0_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISC0_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISC0_4");

        }

    }







    #endregion


}
//U111_A_GET_MISC0_4



public class U110_1_U111_A_GET_MISC1_5 : U110_1
{

    public U110_1_U111_A_GET_MISC1_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISC1_5)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISC1"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISC1_5)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISC1_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISC1_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:45 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISC1_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:45 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISC1_5)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISC1_5");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISC1_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISC1_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISC1_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISC1_5");

        }

    }







    #endregion


}
//U111_A_GET_MISC1_5



public class U110_1_U111_A_GET_MISC2_6 : U110_1
{

    public U110_1_U111_A_GET_MISC2_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISC2_6)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISC2"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISC2_6)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISC2_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISC2_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:45 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISC2_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:46 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISC2_6)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISC2_6");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISC2_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISC2_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISC2_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISC2_6");

        }

    }







    #endregion


}
//U111_A_GET_MISC2_6



public class U110_1_U111_A_GET_MISC3_7 : U110_1
{

    public U110_1_U111_A_GET_MISC3_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISC3_7)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISC3"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISC3_7)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISC3_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISC3_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:46 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISC3_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:46 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISC3_7)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISC3_7");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISC3_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISC3_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISC3_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISC3_7");

        }

    }







    #endregion


}
//U111_A_GET_MISC3_7



public class U110_1_U111_A_GET_MISC4_8 : U110_1
{

    public U110_1_U111_A_GET_MISC4_8(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISC4_8)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISC4"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISC4_8)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISC4_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISC4_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:46 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISC4_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:47 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISC4_8)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISC4_8");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISC4_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISC4_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISC4_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISC4_8");

        }

    }







    #endregion


}
//U111_A_GET_MISC4_8



public class U110_1_U111_A_GET_MISC5_9 : U110_1
{

    public U110_1_U111_A_GET_MISC5_9(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISC5_9)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISC5"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISC5_9)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISC5_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISC5_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:47 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISC5_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:47 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISC5_9)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISC5_9");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISC5_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISC5_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISC5_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISC5_9");

        }

    }







    #endregion


}
//U111_A_GET_MISC5_9



public class U110_1_U111_A_GET_MISC6_10 : U110_1
{

    public U110_1_U111_A_GET_MISC6_10(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISC6_10)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISC6"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISC6_10)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISC6_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISC6_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:48 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISC6_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:48 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISC6_10)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISC6_10");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISC6_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISC6_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISC6_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISC6_10");

        }

    }







    #endregion


}
//U111_A_GET_MISC6_10



public class U110_1_U111_A_GET_MISC7_11 : U110_1
{

    public U110_1_U111_A_GET_MISC7_11(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISC7_11)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISC7"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISC7_11)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISC7_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISC7_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:48 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISC7_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:48 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISC7_11)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISC7_11");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISC7_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISC7_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISC7_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISC7_11");

        }

    }







    #endregion


}
//U111_A_GET_MISC7_11



public class U110_1_U111_A_GET_MISC8_12 : U110_1
{

    public U110_1_U111_A_GET_MISC8_12(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISC8_12)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISC8"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISC8_12)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISC8_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISC8_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:49 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISC8_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:49 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISC8_12)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISC8_12");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISC8_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISC8_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISC8_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISC8_12");

        }

    }







    #endregion


}
//U111_A_GET_MISC8_12



public class U110_1_U111_A_GET_MISC9_13 : U110_1
{

    public U110_1_U111_A_GET_MISC9_13(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISC9_13)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISC9"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISC9_13)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISC9_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISC9_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:50 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISC9_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:50 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISC9_13)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISC9_13");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISC9_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISC9_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISC9_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISC9_13");

        }

    }







    #endregion


}
//U111_A_GET_MISC9_13



public class U110_1_U111_A_GET_MICV_14 : U110_1
{

    public U110_1_U111_A_GET_MICV_14(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MICV_14)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MICV"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MICV_14)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MICV_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MICV_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:50 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MICV_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:50 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MICV_14)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MICV_14");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MICV_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MICV_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MICV_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MICV_14");

        }

    }







    #endregion


}
//U111_A_GET_MICV_14



public class U110_1_U111_A_GET_MICM_15 : U110_1
{

    public U110_1_U111_A_GET_MICM_15(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MICM_15)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MICM"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MICM_15)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MICM_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MICM_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:51 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MICM_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:51 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MICM_15)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MICM_15");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MICM_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MICM_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MICM_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MICM_15");

        }

    }







    #endregion


}
//U111_A_GET_MICM_15



public class U110_1_U111_A_GET_MISJ_16 : U110_1
{

    public U110_1_U111_A_GET_MISJ_16(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISJ_16)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISJ"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISJ_16)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISJ_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISJ_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:51 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISJ_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:52 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISJ_16)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISJ_16");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISJ_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISJ_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISJ_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISJ_16");

        }

    }







    #endregion


}
//U111_A_GET_MISJ_16



public class U110_1_U111_A_GET_MICB_17 : U110_1
{

    public U110_1_U111_A_GET_MICB_17(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MICB_17)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MICB"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MICB_17)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MICB_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MICB_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:52 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MICB_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:52 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MICB_17)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MICB_17");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MICB_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MICB_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MICB_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MICB_17");

        }

    }







    #endregion


}
//U111_A_GET_MICB_17



public class U110_1_U111_A_GET_MIBR_18 : U110_1
{

    public U110_1_U111_A_GET_MIBR_18(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MIBR_18)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MIBR"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MIBR_18)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MIBR_18)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MIBR_18)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:52 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MIBR_18)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:53 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MIBR_18)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MIBR_18");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MIBR_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MIBR_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MIBR_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MIBR_18");

        }

    }







    #endregion


}
//U111_A_GET_MIBR_18



public class U110_1_U111_A_GET_MINH_19 : U110_1
{

    public U110_1_U111_A_GET_MINH_19(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MINH_19)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MINH"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MINH_19)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MINH_19)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MINH_19)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:53 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MINH_19)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:53 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MINH_19)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MINH_19");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MINH_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MINH_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MINH_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MINH_19");

        }

    }







    #endregion


}
//U111_A_GET_MINH_19



public class U110_1_U111_A_GET_MISP_20 : U110_1
{

    public U110_1_U111_A_GET_MISP_20(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MISP_20)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MISP"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MISP_20)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MISP_20)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MISP_20)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:53 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MISP_20)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:54 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MISP_20)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MISP_20");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MISP_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MISP_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MISP_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MISP_20");

        }

    }







    #endregion


}
//U111_A_GET_MISP_20



public class U110_1_U111_A_GET_MOHR_21 : U110_1
{

    public U110_1_U111_A_GET_MOHR_21(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MOHR_21)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MOHR"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MOHR_21)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MOHR_21)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MOHR_21)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:54 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MOHR_21)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:54 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MOHR_21)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MOHR_21");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MOHR_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MOHR_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MOHR_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MOHR_21");

        }

    }







    #endregion


}
//U111_A_GET_MOHR_21



public class U110_1_U111_A_GET_MHSC_22 : U110_1
{

    public U110_1_U111_A_GET_MHSC_22(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_MHSC_22)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("MHSC"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_MHSC_22)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_MHSC_22)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_MHSC_22)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:54 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_MHSC_22)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:55 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_MHSC_22)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_MHSC_22");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    MHSC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    MHSC_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    MHSC_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_MHSC_22");

        }

    }







    #endregion


}
//U111_A_GET_MHSC_22



public class U110_1_U111_A_GET_DHSC_23 : U110_1
{

    public U110_1_U111_A_GET_DHSC_23(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_DHSC_23)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("DHSC"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_DHSC_23)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_DHSC_23)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_DHSC_23)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:55 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_DHSC_23)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:55 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_DHSC_23)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_DHSC_23");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    DHSC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    DHSC_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    DHSC_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_DHSC_23");

        }

    }







    #endregion


}
//U111_A_GET_DHSC_23



public class U110_1_U111_A_GET_AGEP_24 : U110_1
{

    public U110_1_U111_A_GET_AGEP_24(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U111_A_GET_AGEP_24)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("AGEP"));


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




    #endregion


    #region "Standard Generated Procedures(U110_1_U111_A_GET_AGEP_24)"


    #region "Automatic Item Initialization(U110_1_U111_A_GET_AGEP_24)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U111_A_GET_AGEP_24)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:56 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U111_A_GET_AGEP_24)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:56 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U111_A_GET_AGEP_24)"


    public void Run()
    {

        try
        {
            Request("U111_A_GET_AGEP_24");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    AGEP_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    AGEP_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    AGEP_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
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
            EndRequest("U111_A_GET_AGEP_24");

        }

    }







    #endregion


}
//U111_A_GET_AGEP_24



public class U110_1_U110_PROCESS_25 : U110_1
{

    public U110_1_U110_PROCESS_25(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        MTD_BILL = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISC0 = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISC1 = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISC2 = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISC3 = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISC4 = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISC5 = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISC6 = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISC7 = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISC8 = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISC9 = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MICV = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MICM = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISJ = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MISP = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MOHR = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MICB = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MIBR = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MINH = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MHSC = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_DHSC = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_AGEP = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MICA = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MICC = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MICD = new CoreDecimal("MTD_BILLING", 8, this);
        MTD_MICE = new CoreDecimal("MTD_BILLING", 8, this);
        COMP_CODE = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        COMP_TYPE = new CoreCharacter("COMP_TYPE", 1, this, Common.cEmptyString);
        PROCESS_SEQ = new CoreDecimal("PROCESS_SEQ", 2, this);
        FACTOR = new CoreDecimal("FACTOR", 6, this);
        MTD_BILLING = new CoreDecimal("MTD_BILLING", 8, this);
        fleU110_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU110_AUDIT_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110_AUDIT_DOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU110 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISC0 = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISC0 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISC0", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISC1 = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISC1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISC1", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISC2 = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISC2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISC2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISC3 = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISC3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISC3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISC4 = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISC4 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISC4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISC5 = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISC5 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISC5", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISC6 = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISC6 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISC6", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISC7 = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISC7 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISC7", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISC8 = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISC8 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISC8", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISC9 = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISC9 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISC9", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICV = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICV = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICV", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICM = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICM", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISJ = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISJ", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MISP = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MISP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MISP", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MOHR = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MOHR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MOHR", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICB = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICB = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICB", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MIBR = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MIBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MIBR", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MINH = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MINH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MINH", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MHSC = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MHSC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MHSC", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_DHSC = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_DHSC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_DHSC", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_AGEP = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_AGEP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_AGEP", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICA = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICA", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICC = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICC", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICD = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICD = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICD", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_MICE = new CoreCharacter("COMP_CODE", 6, this, Common.cEmptyString);
        fleU110_MICE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U110", "U110_MICE", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U110_1_U110_PROCESS_25)"

    private SqlFileObject fleF050_DOC_REVENUE_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;
    private CoreDecimal MTD_BILL;
    private CoreDecimal MTD_MISC0;
    private CoreDecimal MTD_MISC1;
    private CoreDecimal MTD_MISC2;
    private CoreDecimal MTD_MISC3;
    private CoreDecimal MTD_MISC4;
    private CoreDecimal MTD_MISC5;
    private CoreDecimal MTD_MISC6;
    private CoreDecimal MTD_MISC7;
    private CoreDecimal MTD_MISC8;
    private CoreDecimal MTD_MISC9;
    private CoreDecimal MTD_MICV;
    private CoreDecimal MTD_MICM;
    private CoreDecimal MTD_MISJ;
    private CoreDecimal MTD_MISP;
    private CoreDecimal MTD_MOHR;
    private CoreDecimal MTD_MICB;
    private CoreDecimal MTD_MIBR;
    private CoreDecimal MTD_MINH;
    private CoreDecimal MTD_MHSC;
    private CoreDecimal MTD_DHSC;
    private CoreDecimal MTD_AGEP;
    private CoreDecimal MTD_MICA;
    private CoreDecimal MTD_MICC;
    private CoreDecimal MTD_MICD;
    private CoreDecimal MTD_MICE;
    private CoreCharacter COMP_CODE;
    private CoreCharacter COMP_TYPE;
    private CoreDecimal PROCESS_SEQ;
    private CoreDecimal FACTOR;

    private CoreDecimal MTD_BILLING;
    private SqlFileObject fleU110_AUDIT;

    private SqlFileObject fleU110_AUDIT_DOC;

    private SqlFileObject fleU110;

    private CoreCharacter X_COMP_CODE_MISC0;
    private SqlFileObject fleU110_MISC0;

    private CoreCharacter X_COMP_CODE_MISC1;
    private SqlFileObject fleU110_MISC1;

    private CoreCharacter X_COMP_CODE_MISC2;
    private SqlFileObject fleU110_MISC2;

    private CoreCharacter X_COMP_CODE_MISC3;
    private SqlFileObject fleU110_MISC3;

    private CoreCharacter X_COMP_CODE_MISC4;
    private SqlFileObject fleU110_MISC4;

    private CoreCharacter X_COMP_CODE_MISC5;
    private SqlFileObject fleU110_MISC5;

    private CoreCharacter X_COMP_CODE_MISC6;
    private SqlFileObject fleU110_MISC6;

    private CoreCharacter X_COMP_CODE_MISC7;
    private SqlFileObject fleU110_MISC7;

    private CoreCharacter X_COMP_CODE_MISC8;
    private SqlFileObject fleU110_MISC8;

    private CoreCharacter X_COMP_CODE_MISC9;
    private SqlFileObject fleU110_MISC9;

    private CoreCharacter X_COMP_CODE_MICV;
    private SqlFileObject fleU110_MICV;

    private CoreCharacter X_COMP_CODE_MICM;
    private SqlFileObject fleU110_MICM;

    private CoreCharacter X_COMP_CODE_MISJ;
    private SqlFileObject fleU110_MISJ;

    private CoreCharacter X_COMP_CODE_MISP;
    private SqlFileObject fleU110_MISP;

    private CoreCharacter X_COMP_CODE_MOHR;
    private SqlFileObject fleU110_MOHR;

    private CoreCharacter X_COMP_CODE_MICB;
    private SqlFileObject fleU110_MICB;

    private CoreCharacter X_COMP_CODE_MIBR;
    private SqlFileObject fleU110_MIBR;

    private CoreCharacter X_COMP_CODE_MINH;
    private SqlFileObject fleU110_MINH;

    private CoreCharacter X_COMP_CODE_MHSC;
    private SqlFileObject fleU110_MHSC;

    private CoreCharacter X_COMP_CODE_DHSC;
    private SqlFileObject fleU110_DHSC;

    private CoreCharacter X_COMP_CODE_AGEP;
    private SqlFileObject fleU110_AGEP;

    private CoreCharacter X_COMP_CODE_MICA;
    private SqlFileObject fleU110_MICA;

    private CoreCharacter X_COMP_CODE_MICC;
    private SqlFileObject fleU110_MICC;

    private CoreCharacter X_COMP_CODE_MICD;
    private SqlFileObject fleU110_MICD;

    private CoreCharacter X_COMP_CODE_MICE;
    private SqlFileObject fleU110_MICE;

    public override bool SelectIf()
    {
        try
        {
            if ((QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "22"
                | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "23"
                | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "24"
                | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "25"
                | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")) == "26")
                | (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y"
                & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != " "
                & (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")).CompareTo("71") < 0
                | QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_CLINIC_1_2")).CompareTo("75") > 0)))
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


    #region "Standard Generated Procedures(U110_1_U110_PROCESS_25)"


    #region "Automatic Item Initialization(U110_1_U110_PROCESS_25)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U110_1_U110_PROCESS_25)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:56 PM

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
        fleU110_AUDIT.Transaction = m_trnTRANS_UPDATE;
        fleU110_AUDIT_DOC.Transaction = m_trnTRANS_UPDATE;
        fleU110.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISC0.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISC1.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISC2.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISC3.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISC4.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISC5.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISC6.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISC7.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISC8.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISC9.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICV.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICM.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISJ.Transaction = m_trnTRANS_UPDATE;
        fleU110_MISP.Transaction = m_trnTRANS_UPDATE;
        fleU110_MOHR.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICB.Transaction = m_trnTRANS_UPDATE;
        fleU110_MIBR.Transaction = m_trnTRANS_UPDATE;
        fleU110_MINH.Transaction = m_trnTRANS_UPDATE;
        fleU110_MHSC.Transaction = m_trnTRANS_UPDATE;
        fleU110_DHSC.Transaction = m_trnTRANS_UPDATE;
        fleU110_AGEP.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICA.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICC.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICD.Transaction = m_trnTRANS_UPDATE;
        fleU110_MICE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U110_1_U110_PROCESS_25)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:23:56 PM

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
            fleU110_AUDIT.Dispose();
            fleU110_AUDIT_DOC.Dispose();
            fleU110.Dispose();
            fleU110_MISC0.Dispose();
            fleU110_MISC1.Dispose();
            fleU110_MISC2.Dispose();
            fleU110_MISC3.Dispose();
            fleU110_MISC4.Dispose();
            fleU110_MISC5.Dispose();
            fleU110_MISC6.Dispose();
            fleU110_MISC7.Dispose();
            fleU110_MISC8.Dispose();
            fleU110_MISC9.Dispose();
            fleU110_MICV.Dispose();
            fleU110_MICM.Dispose();
            fleU110_MISJ.Dispose();
            fleU110_MISP.Dispose();
            fleU110_MOHR.Dispose();
            fleU110_MICB.Dispose();
            fleU110_MIBR.Dispose();
            fleU110_MINH.Dispose();
            fleU110_MHSC.Dispose();
            fleU110_DHSC.Dispose();
            fleU110_AGEP.Dispose();
            fleU110_MICA.Dispose();
            fleU110_MICC.Dispose();
            fleU110_MICD.Dispose();
            fleU110_MICE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U110_1_U110_PROCESS_25)"


    public void Run()
    {

        try
        {
            Request("U110_PROCESS_25");

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


                        if (Transaction())
                        {

                            if (Select_If())
                            {

                                Sort(fleF050_DOC_REVENUE_MSTR.GetSortValue("DOCREV_CLINIC_1_2"), fleF050_DOC_REVENUE_MSTR.GetSortValue("DOCREV_DEPT"), fleF050_DOC_REVENUE_MSTR.GetSortValue("DOCREV_DOC_NBR"), fleF050_DOC_REVENUE_MSTR.GetSortValue("DOCREV_LOCATION"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleF050_DOC_REVENUE_MSTR, fleF020_DOCTOR_MSTR, fleICONST_MSTR_REC))
            {
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) != "MISC")
                {
                    MTD_BILL.Value = MTD_BILL.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_BILL.Value = MTD_BILL.Value;
                }

                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")) == "MISC0")
                {
                    MTD_MISC0.Value = MTD_MISC0.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISC0.Value = MTD_MISC0.Value;
                }

                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")) == "MISC1")
                {
                    MTD_MISC1.Value = MTD_MISC1.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISC1.Value = MTD_MISC1.Value;
                }

                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")) == "MISC2")
                {
                    MTD_MISC2.Value = MTD_MISC2.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISC2.Value = MTD_MISC2.Value;
                }

                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")) == "MISC3")
                {
                    MTD_MISC3.Value = MTD_MISC3.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISC3.Value = MTD_MISC3.Value;
                }

                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")) == "MISC4")
                {
                    MTD_MISC4.Value = MTD_MISC4.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISC4.Value = MTD_MISC4.Value;
                }

                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")) == "MISC5")
                {
                    MTD_MISC5.Value = MTD_MISC5.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISC5.Value = MTD_MISC5.Value;
                }

                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")) == "MISC6")
                {
                    MTD_MISC6.Value = MTD_MISC6.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISC6.Value = MTD_MISC6.Value;
                }

                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")) == "MISC7")
                {
                    MTD_MISC7.Value = MTD_MISC7.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISC7.Value = MTD_MISC7.Value;
                }

                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")) == "MISC8")
                {
                    MTD_MISC8.Value = MTD_MISC8.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISC8.Value = MTD_MISC8.Value;
                }

                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_SUFF") + fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_ADJ_CD_SUB_TYPE")) == "MISC9")
                {
                    MTD_MISC9.Value = MTD_MISC9.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISC9.Value = MTD_MISC9.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICV")
                {
                    MTD_MICV.Value = MTD_MICV.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICV.Value = MTD_MICV.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICM")
                {
                    MTD_MICM.Value = MTD_MICM.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICM.Value = MTD_MICM.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MISJ")
                {
                    MTD_MISJ.Value = MTD_MISJ.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISJ.Value = MTD_MISJ.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MISP")
                {
                    MTD_MISP.Value = MTD_MISP.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MISP.Value = MTD_MISP.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MOHR")
                {
                    MTD_MOHR.Value = MTD_MOHR.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MOHR.Value = MTD_MOHR.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICB")
                {
                    MTD_MICB.Value = MTD_MICB.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICB.Value = MTD_MICB.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MIBR")
                {
                    MTD_MIBR.Value = MTD_MIBR.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MIBR.Value = MTD_MIBR.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MINH")
                {
                    MTD_MINH.Value = MTD_MINH.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MINH.Value = MTD_MINH.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MHSC")
                {
                    MTD_MHSC.Value = MTD_MHSC.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MHSC.Value = MTD_MHSC.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "DHSC")
                {
                    MTD_DHSC.Value = MTD_DHSC.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_DHSC.Value = MTD_DHSC.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "AGEP")
                {
                    MTD_AGEP.Value = MTD_AGEP.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_AGEP.Value = MTD_AGEP.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICA")
                {
                    MTD_MICA.Value = MTD_MICA.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICA.Value = MTD_MICA.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICC")
                {
                    MTD_MICC.Value = MTD_MICC.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICC.Value = MTD_MICC.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICD")
                {
                    MTD_MICD.Value = MTD_MICD.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICD.Value = MTD_MICD.Value;
                }
                if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR.GetStringValue("DOCREV_OMA_CODE")) == "MICE")
                {
                    MTD_MICE.Value = MTD_MICE.Value + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_IN_REC") + fleF050_DOC_REVENUE_MSTR.GetDecimalValue("DOCREV_MTD_OUT_REC");
                }
                else
                {
                    MTD_MICE.Value = MTD_MICE.Value;
                }
                if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" "))
                {
                    COMP_CODE.Value = "AFPIN";
                }
                else if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" "))
                {
                    COMP_CODE.Value = "AFPOUT";
                }
                else
                {
                    COMP_CODE.Value = "BILL";
                }
                if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" "))
                {
                    COMP_TYPE.Value = QDesign.NULL(AFPIN_TYPE.Value);
                }
                else if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" "))
                {
                    COMP_TYPE.Value = QDesign.NULL(AFPOUT_TYPE.Value);
                }
                else
                {
                    COMP_TYPE.Value = QDesign.NULL(BILL_TYPE.Value);
                }
                if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" "))
                {
                    PROCESS_SEQ.Value = AFPIN_SEQ.Value;
                }
                else if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" "))
                {
                    PROCESS_SEQ.Value = AFPOUT_SEQ.Value;
                }
                else
                {
                    PROCESS_SEQ.Value = BILL_SEQ.Value;
                }
                if (QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y" & QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" "))
                {
                    FACTOR.Value = AFPIN_FACTOR.Value;
                }
                else if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" "))
                {
                    FACTOR.Value = AFPOUT_FACTOR.Value;
                }
                else
                {
                    FACTOR.Value = BILL_FACTOR.Value;
                }
                MTD_BILLING.Value = MTD_BILL.Value;


                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_AUDIT, SubFileType.Keep, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_AFP_PAYM_GROUP", MTD_BILLING, COMP_CODE, FACTOR,
                PROCESS_SEQ, COMP_TYPE);



                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_AUDIT_DOC, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), SubFileType.Keep, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_AFP_PAYM_GROUP", MTD_BILLING, COMP_CODE,
                FACTOR, PROCESS_SEQ, COMP_TYPE);



                SubFile(ref m_trnTRANS_UPDATE, ref fleU110, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) == QDesign.NULL(" ") | (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(" ") & QDesign.NULL(MTD_BILL.Value) != 0), SubFileType.Keep, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR", COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MISC0.Value = "MISC0";

                
                PROCESS_SEQ.Value = MISC0_SEQ.Value;
                COMP_TYPE.Value = MISC0_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISC0.Value;
                FACTOR.Value = MISC0_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISC0.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISC0, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISC0.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                     COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MISC1.Value = "MISC1";

                PROCESS_SEQ.Value = MISC1_SEQ.Value;
                COMP_TYPE.Value = MISC1_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISC1.Value;
                FACTOR.Value = MISC1_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISC1.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISC1, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISC1.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                   COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MISC2.Value = "MISC2";

                PROCESS_SEQ.Value = MISC2_SEQ.Value;
                COMP_TYPE.Value = MISC2_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISC2.Value;
                FACTOR.Value = MISC2_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISC2.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISC2, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISC2.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                     COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MISC3.Value = "MISC3";

                PROCESS_SEQ.Value = MISC3_SEQ.Value;
                COMP_TYPE.Value = MISC3_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISC3.Value;
                FACTOR.Value = MISC3_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISC3.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISC3, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISC3.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MISC4.Value = "MISC4";

                PROCESS_SEQ.Value = MISC4_SEQ.Value;
                COMP_TYPE.Value = MISC4_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISC4.Value;
                FACTOR.Value = MISC4_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISC4.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISC4, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISC4.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MISC5.Value = "MISC5";

                PROCESS_SEQ.Value = MISC5_SEQ.Value;
                COMP_TYPE.Value = MISC5_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISC5.Value;
                FACTOR.Value = MISC5_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISC5.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISC5, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISC5.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
               FACTOR, MTD_BILLING);


                X_COMP_CODE_MISC6.Value = "MISC6";

                PROCESS_SEQ.Value = MISC6_SEQ.Value;
                COMP_TYPE.Value = MISC6_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISC6.Value;
                FACTOR.Value = MISC6_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISC6.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISC6, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISC6.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MISC7.Value = "MISC7";

                PROCESS_SEQ.Value = MISC7_SEQ.Value;
                COMP_TYPE.Value = MISC7_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISC7.Value;
                FACTOR.Value = MISC7_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISC7.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISC7, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISC7.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MISC8.Value = "MISC8";

                PROCESS_SEQ.Value = MISC8_SEQ.Value;
                COMP_TYPE.Value = MISC8_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISC8.Value;
                FACTOR.Value = MISC8_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISC8.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISC8, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISC8.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                   COMP_CODE, COMP_TYPE, PROCESS_SEQ,
               FACTOR, MTD_BILLING);


                X_COMP_CODE_MISC9.Value = "MISC9";

                PROCESS_SEQ.Value = MISC9_SEQ.Value;
                COMP_TYPE.Value = MISC9_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISC9.Value;
                FACTOR.Value = MISC9_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISC9.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISC9, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISC9.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
               FACTOR, MTD_BILLING);


                X_COMP_CODE_MICV.Value = "MICV";

                PROCESS_SEQ.Value = MICV_SEQ.Value;
                COMP_TYPE.Value = MICV_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MICV.Value;
                FACTOR.Value = MICV_FACTOR.Value;
                MTD_BILLING.Value = MTD_MICV.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICV, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MICV.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                   COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MICM.Value = "MICM";

                PROCESS_SEQ.Value = MICM_SEQ.Value;
                COMP_TYPE.Value = MICM_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MICM.Value;
                FACTOR.Value = MICM_FACTOR.Value;
                MTD_BILLING.Value = MTD_MICM.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICM, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MICM.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MISJ.Value = "MISJ";

                PROCESS_SEQ.Value = MISJ_SEQ.Value;
                COMP_TYPE.Value = MISJ_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISJ.Value;
                FACTOR.Value = MISJ_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISJ.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISJ, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISJ.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
               FACTOR, MTD_BILLING);


                X_COMP_CODE_MISP.Value = "MISP";

                PROCESS_SEQ.Value = MISP_SEQ.Value;
                COMP_TYPE.Value = MISP_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MISP.Value;
                FACTOR.Value = MISP_FACTOR.Value;
                MTD_BILLING.Value = MTD_MISP.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MISP, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MISP.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MOHR.Value = "MOHR";

                PROCESS_SEQ.Value = MOHR_SEQ.Value;
                COMP_TYPE.Value = MOHR_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MOHR.Value;
                FACTOR.Value = MOHR_FACTOR.Value;
                MTD_BILLING.Value = MTD_MOHR.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MOHR, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MOHR.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                     COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MICB.Value = "MICB";

                PROCESS_SEQ.Value = MICB_SEQ.Value;
                COMP_TYPE.Value = MICB_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MICB.Value;
                FACTOR.Value = MICB_FACTOR.Value;
                MTD_BILLING.Value = MTD_MICB.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICB, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MICB.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MIBR.Value = "MIBR";

                PROCESS_SEQ.Value = MIBR_SEQ.Value;
                COMP_TYPE.Value = MIBR_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MIBR.Value;
                FACTOR.Value = MIBR_FACTOR.Value;
                MTD_BILLING.Value = MTD_MIBR.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MIBR, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MIBR.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MINH.Value = "MINH";

                PROCESS_SEQ.Value = MINH_SEQ.Value;
                COMP_TYPE.Value = MINH_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MINH.Value;
                FACTOR.Value = MINH_FACTOR.Value;
                MTD_BILLING.Value = MTD_MINH.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MINH, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MINH.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
               FACTOR, MTD_BILLING);


                X_COMP_CODE_MHSC.Value = "MHSC";

                PROCESS_SEQ.Value = MHSC_SEQ.Value;
                COMP_TYPE.Value = MHSC_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MHSC.Value;
                FACTOR.Value = MHSC_FACTOR.Value;
                MTD_BILLING.Value = MTD_MHSC.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MHSC, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MHSC.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_DHSC.Value = "DHSC";

                PROCESS_SEQ.Value = DHSC_SEQ.Value;
                COMP_TYPE.Value = DHSC_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_DHSC.Value;
                FACTOR.Value = DHSC_FACTOR.Value;
                MTD_BILLING.Value = MTD_DHSC.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_DHSC, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_DHSC.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                     COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_AGEP.Value = "AGEP";

                PROCESS_SEQ.Value = AGEP_SEQ.Value;
                COMP_TYPE.Value = AGEP_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_AGEP.Value;
                FACTOR.Value = AGEP_FACTOR.Value;
                MTD_BILLING.Value = MTD_AGEP.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_AGEP, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_AGEP.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                     COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MICA.Value = "MICA";

                PROCESS_SEQ.Value = MICA_SEQ.Value;
                COMP_TYPE.Value = MICA_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MICA.Value;
                FACTOR.Value = MICA_FACTOR.Value;
                MTD_BILLING.Value = MTD_MICA.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICA, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MICA.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                     COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                 FACTOR, MTD_BILLING);


                X_COMP_CODE_MICC.Value = "MICC";

                PROCESS_SEQ.Value = MICC_SEQ.Value;
                COMP_TYPE.Value = MICC_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MICC.Value;
                FACTOR.Value = MICC_FACTOR.Value;
                MTD_BILLING.Value = MTD_MICC.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICC, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MICC.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MICD.Value = "MICD";

                PROCESS_SEQ.Value = MICD_SEQ.Value;
                COMP_TYPE.Value = MICD_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MICD.Value;
                FACTOR.Value = MICD_FACTOR.Value;
                MTD_BILLING.Value = MTD_MICD.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICD, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MICD.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                FACTOR, MTD_BILLING);


                X_COMP_CODE_MICE.Value = "MICE";

                PROCESS_SEQ.Value = MICE_SEQ.Value;
                COMP_TYPE.Value = MICE_TYPE.Value;
                COMP_CODE.Value = X_COMP_CODE_MICE.Value;
                FACTOR.Value = MICE_FACTOR.Value;
                MTD_BILLING.Value = MTD_MICE.Value;
                SubFile(ref m_trnTRANS_UPDATE, ref fleU110_MICE, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"), QDesign.NULL(MTD_MICE.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF050_DOC_REVENUE_MSTR, "DOCREV_DOC_NBR",
                    COMP_CODE, COMP_TYPE, PROCESS_SEQ,
                 FACTOR, MTD_BILLING);



                Reset(ref MTD_BILL, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISC0, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISC1, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISC2, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISC3, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISC4, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISC5, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISC6, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISC7, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISC8, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISC9, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICV, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICM, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISJ, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MISP, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MOHR, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICB, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MIBR, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MINH, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MHSC, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_DHSC, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_AGEP, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICA, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICC, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICD, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));
                Reset(ref MTD_MICE, fleF050_DOC_REVENUE_MSTR.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR.At("DOCREV_DOC_NBR"));

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
            EndRequest("U110_PROCESS_25");

        }

    }




    #endregion


}
//U110_PROCESS_25




