
#region "Screen Comments"

// #> PROGRAM-ID.     U116.QTS
// ((C)) Dyad Systems
// PURPOSE: Sub-process within `EARNINGS GENERATION` process.
// Calculate `POTENTIAL PAYMENTS`( PAYPOT ) for all PAY CODES
// Create/update GTYPE-x GUARantee transactions for PAY CODE 1
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 92/JAN/01  ____   B.E.     - original
// 92/APR/30         B.E.     - incorporate GTYPE-x logic
// 92/MAY/11         B.E.     - allow for scaling of dollar values
// 92/MAY/20         B.E.     - CODE for  1D  pay-sub-CODE
// 92/SEP/20         B.E.     - CODE for YTD GUARantee Amt CODE 1A
// 92/SEP/22         B.E.     - added FACTOR from F112 to affect
// NET PAY calculation
// 92/SEP/28         B.E.     - changed `W-DOC-YRLY-CEILING`
// to `AMT-NET OF F110-YTDCEA`
// 92/OCT/13         B.E.     - changed `YTDGUC` to `YTDGUD` for 1D calc`s
// 92/OCT/13         B.E.     - added calculation for UNDERage Comp CODE
// for payCODE 1.
// - changed `YTDGUC` to `YTDGUD` for 1D calc`s
// - NOVE/10 CHANGED YTDGUD BACK TO YTDGUCB
// ??? HOW DOES GUARANTEE UNDER CODE 1/A/B/C
// GET MOVED OVER TO GUD TO DETERMINE  TRUE  INCOME
// 92/OCT/14         B.E.     - added Ceiling Guarantee % to 1B calc.
// 93/FEB/21         B.E.     - added update of Doctor Mstr logic in pay code 1
// into paycode 2/3/4 logic.
// 93/APR/20         B.E.     - removed access to F190 for YTDEXP since no   1
// longer needed after using F020 values.
// 93/MAY/18         B.E.     - removed access to F110 for TOTINC and CEIEAR
// 93/MAY/25         B.E.     - changed UNDER to STATUS
// 93/MAY/27         B.E.     - output F110 STATUS rec even if $ value is 0
// 93/JUN/01         B.E.     - STATUS rec output to F119 changed X-NOT-NEEDED
// to DOC-YTDEAR from F020
// 93/JUN/03         B.E.     - 1C PAYPOT changed to do pay calculation
// than add addition current EP Income (TOTINC)
// up to limits (ie. YTD Ceiling - YTDCEA)
// 93/JUN/08         B.E.     - YTDEAR updated with -AMT-NET-3 not -AMT-NET
// 93/JUL/13         B.E.     - include all  GTYPE  transactions in F119
// even if not a  I ncome TYPE transaction
// 94/FEB/14         M.C.     - FOR PAY CODE 1, REVERSE THE SIGN ON
// W-POTGUAR-AMT-NET
// 94/MAR/04         M.C.     - ADD THE CONDITIONAL COMPILE FOR PAY
// CODE 5 LOGIC
// SEE LINE BELOW  SHOULDN`T ABOVE LINE TAKE INTO CONSIDERATION ...  TO
// DETERMINE IF FURTHER EDIT REQUIRED ??????????????????
// 1999/Feb/18         S.B.     - Checked for Y2K.
// 1999/June/03 S.B.  - Changed the calls for the u116_paycode0,
// 1,2,34,5 from pb_src to use.
// 2014-feb-20  be1 - new paycode 7 logic
// - TODO - complete description of change here
// 2014-apr-20  be2 - add logic to calc HST on doc charges(HSTRTE, PY7HST, FINCHG)
// 2014/May/20   MC1     - include DOCFTE compcode for paycode 7


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

using System.IO;



public class U116 : BaseClassControl
{

    private U116 m_U116;

    public U116(string Name, int Level) : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ = new CoreDecimal("PAYPOT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ_RPT = new CoreDecimal("PAYPOT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_TYPE = new CoreCharacter("PAYPOT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYPOT_GROUP = new CoreCharacter("PAYPOT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEAR_SEQ = new CoreDecimal("CEIEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEAR_TYPE = new CoreCharacter("CEIEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEXP_SEQ = new CoreDecimal("CEIEXP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEXP_TYPE = new CoreCharacter("CEIEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTINC_SEQ = new CoreDecimal("TOTINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTINC_TYPE = new CoreCharacter("TOTINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEA_SEQ = new CoreDecimal("YTDCEA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEA_TYPE = new CoreCharacter("YTDCEA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEX_SEQ = new CoreDecimal("YTDCEX_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEX_TYPE = new CoreCharacter("YTDCEX_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDEAR_SEQ = new CoreDecimal("YTDEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDEAR_TYPE = new CoreCharacter("YTDEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDINC_SEQ = new CoreDecimal("YTDINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDINC_TYPE = new CoreCharacter("YTDINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUB_SEQ = new CoreDecimal("YTDGUB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUB_TYPE = new CoreCharacter("YTDGUB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUC_SEQ = new CoreDecimal("YTDGUC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUC_TYPE = new CoreCharacter("YTDGUC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUD_SEQ = new CoreDecimal("YTDGUD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUD_TYPE = new CoreCharacter("YTDGUD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_SEQ = new CoreDecimal("STATUS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        STATUS_SEQ_RPT = new CoreDecimal("STATUS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        STATUS_TYPE = new CoreCharacter("STATUS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_GROUP = new CoreCharacter("STATUS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_SEQ = new CoreDecimal("ADVOUT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_SEQ_RPT = new CoreDecimal("ADVOUT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_TYPE = new CoreCharacter("ADVOUT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_GROUP = new CoreCharacter("ADVOUT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_FACTOR = new CoreDecimal("ADVOUT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ = new CoreDecimal("TOTADV_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ_RPT = new CoreDecimal("TOTADV_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_TYPE = new CoreCharacter("TOTADV_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_GROUP = new CoreCharacter("TOTADV_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_FACTOR = new CoreDecimal("TOTADV_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ = new CoreDecimal("DEPINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ_RPT = new CoreDecimal("DEPINC_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_TYPE = new CoreCharacter("DEPINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_GROUP = new CoreCharacter("DEPINC_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_FACTOR = new CoreDecimal("DEPINC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ = new CoreDecimal("SVCRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ_RPT = new CoreDecimal("SVCRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_TYPE = new CoreCharacter("SVCRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_GROUP = new CoreCharacter("SVCRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_FACTOR = new CoreDecimal("SVCRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ = new CoreDecimal("SVCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ_RPT = new CoreDecimal("SVCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_TYPE = new CoreCharacter("SVCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_GROUP = new CoreCharacter("SVCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_FACTOR = new CoreDecimal("SVCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ = new CoreDecimal("KEYHRS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ_RPT = new CoreDecimal("KEYHRS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_TYPE = new CoreCharacter("KEYHRS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_GROUP = new CoreCharacter("KEYHRS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_FACTOR = new CoreDecimal("KEYHRS_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ = new CoreDecimal("KEYRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ_RPT = new CoreDecimal("KEYRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_TYPE = new CoreCharacter("KEYRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_GROUP = new CoreCharacter("KEYRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_FACTOR = new CoreDecimal("KEYRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ = new CoreDecimal("KEYCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ_RPT = new CoreDecimal("KEYCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_TYPE = new CoreCharacter("KEYCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_GROUP = new CoreCharacter("KEYCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_FACTOR = new CoreDecimal("KEYCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ = new CoreDecimal("DEPCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ_RPT = new CoreDecimal("DEPCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_TYPE = new CoreCharacter("DEPCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_GROUP = new CoreCharacter("DEPCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_FACTOR = new CoreDecimal("DEPCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ = new CoreDecimal("DEPFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ_RPT = new CoreDecimal("DEPFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_TYPE = new CoreCharacter("DEPFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_GROUP = new CoreCharacter("DEPFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_FACTOR = new CoreDecimal("DEPFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ = new CoreDecimal("DOCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ_RPT = new CoreDecimal("DOCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_TYPE = new CoreCharacter("DOCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_GROUP = new CoreCharacter("DOCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_FACTOR = new CoreDecimal("DOCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ = new CoreDecimal("HSTRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ_RPT = new CoreDecimal("HSTRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_TYPE = new CoreCharacter("HSTRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_GROUP = new CoreCharacter("HSTRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_FACTOR = new CoreDecimal("HSTRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ = new CoreDecimal("PY7HST_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ_RPT = new CoreDecimal("PY7HST_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_TYPE = new CoreCharacter("PY7HST_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_GROUP = new CoreCharacter("PY7HST_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_FACTOR = new CoreDecimal("PY7HST_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ = new CoreDecimal("FINCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ_RPT = new CoreDecimal("FINCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_TYPE = new CoreCharacter("FINCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_GROUP = new CoreCharacter("FINCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_FACTOR = new CoreDecimal("FINCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ = new CoreDecimal("DOCFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ_RPT = new CoreDecimal("DOCFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_TYPE = new CoreCharacter("DOCFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_GROUP = new CoreCharacter("DOCFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_FACTOR = new CoreDecimal("DOCFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);


    }

    public U116(string Name, int Level, bool Request) : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ = new CoreDecimal("PAYPOT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ_RPT = new CoreDecimal("PAYPOT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_TYPE = new CoreCharacter("PAYPOT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYPOT_GROUP = new CoreCharacter("PAYPOT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEAR_SEQ = new CoreDecimal("CEIEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEAR_TYPE = new CoreCharacter("CEIEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEXP_SEQ = new CoreDecimal("CEIEXP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEXP_TYPE = new CoreCharacter("CEIEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTINC_SEQ = new CoreDecimal("TOTINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTINC_TYPE = new CoreCharacter("TOTINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEA_SEQ = new CoreDecimal("YTDCEA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEA_TYPE = new CoreCharacter("YTDCEA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEX_SEQ = new CoreDecimal("YTDCEX_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEX_TYPE = new CoreCharacter("YTDCEX_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDEAR_SEQ = new CoreDecimal("YTDEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDEAR_TYPE = new CoreCharacter("YTDEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDINC_SEQ = new CoreDecimal("YTDINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDINC_TYPE = new CoreCharacter("YTDINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUB_SEQ = new CoreDecimal("YTDGUB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUB_TYPE = new CoreCharacter("YTDGUB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUC_SEQ = new CoreDecimal("YTDGUC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUC_TYPE = new CoreCharacter("YTDGUC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUD_SEQ = new CoreDecimal("YTDGUD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUD_TYPE = new CoreCharacter("YTDGUD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_SEQ = new CoreDecimal("STATUS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        STATUS_SEQ_RPT = new CoreDecimal("STATUS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        STATUS_TYPE = new CoreCharacter("STATUS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_GROUP = new CoreCharacter("STATUS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_SEQ = new CoreDecimal("ADVOUT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_SEQ_RPT = new CoreDecimal("ADVOUT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_TYPE = new CoreCharacter("ADVOUT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_GROUP = new CoreCharacter("ADVOUT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_FACTOR = new CoreDecimal("ADVOUT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ = new CoreDecimal("TOTADV_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ_RPT = new CoreDecimal("TOTADV_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_TYPE = new CoreCharacter("TOTADV_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_GROUP = new CoreCharacter("TOTADV_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_FACTOR = new CoreDecimal("TOTADV_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ = new CoreDecimal("DEPINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ_RPT = new CoreDecimal("DEPINC_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_TYPE = new CoreCharacter("DEPINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_GROUP = new CoreCharacter("DEPINC_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_FACTOR = new CoreDecimal("DEPINC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ = new CoreDecimal("SVCRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ_RPT = new CoreDecimal("SVCRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_TYPE = new CoreCharacter("SVCRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_GROUP = new CoreCharacter("SVCRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_FACTOR = new CoreDecimal("SVCRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ = new CoreDecimal("SVCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ_RPT = new CoreDecimal("SVCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_TYPE = new CoreCharacter("SVCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_GROUP = new CoreCharacter("SVCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_FACTOR = new CoreDecimal("SVCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ = new CoreDecimal("KEYHRS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ_RPT = new CoreDecimal("KEYHRS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_TYPE = new CoreCharacter("KEYHRS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_GROUP = new CoreCharacter("KEYHRS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_FACTOR = new CoreDecimal("KEYHRS_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ = new CoreDecimal("KEYRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ_RPT = new CoreDecimal("KEYRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_TYPE = new CoreCharacter("KEYRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_GROUP = new CoreCharacter("KEYRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_FACTOR = new CoreDecimal("KEYRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ = new CoreDecimal("KEYCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ_RPT = new CoreDecimal("KEYCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_TYPE = new CoreCharacter("KEYCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_GROUP = new CoreCharacter("KEYCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_FACTOR = new CoreDecimal("KEYCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ = new CoreDecimal("DEPCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ_RPT = new CoreDecimal("DEPCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_TYPE = new CoreCharacter("DEPCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_GROUP = new CoreCharacter("DEPCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_FACTOR = new CoreDecimal("DEPCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ = new CoreDecimal("DEPFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ_RPT = new CoreDecimal("DEPFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_TYPE = new CoreCharacter("DEPFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_GROUP = new CoreCharacter("DEPFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_FACTOR = new CoreDecimal("DEPFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ = new CoreDecimal("DOCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ_RPT = new CoreDecimal("DOCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_TYPE = new CoreCharacter("DOCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_GROUP = new CoreCharacter("DOCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_FACTOR = new CoreDecimal("DOCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ = new CoreDecimal("HSTRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ_RPT = new CoreDecimal("HSTRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_TYPE = new CoreCharacter("HSTRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_GROUP = new CoreCharacter("HSTRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_FACTOR = new CoreDecimal("HSTRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ = new CoreDecimal("PY7HST_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ_RPT = new CoreDecimal("PY7HST_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_TYPE = new CoreCharacter("PY7HST_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_GROUP = new CoreCharacter("PY7HST_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_FACTOR = new CoreDecimal("PY7HST_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ = new CoreDecimal("FINCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ_RPT = new CoreDecimal("FINCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_TYPE = new CoreCharacter("FINCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_GROUP = new CoreCharacter("FINCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_FACTOR = new CoreDecimal("FINCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ = new CoreDecimal("DOCFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ_RPT = new CoreDecimal("DOCFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_TYPE = new CoreCharacter("DOCFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_GROUP = new CoreCharacter("DOCFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_FACTOR = new CoreDecimal("DOCFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_U116 != null))
        {
            m_U116.CloseTransactionObjects();
            m_U116 = null;
        }
    }

    public U116 GetU116(int Level)
    {
        if (m_U116 == null)
        {
            m_U116 = new U116("U116", Level);
        }
        else
        {
            m_U116.ResetValues();
        }
        return m_U116;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_EP_NBR;
    protected CoreDecimal W_CURRENT_EP_NBR_MINUS1;
    protected CoreDecimal PAYPOT_SEQ;
    protected CoreDecimal PAYPOT_SEQ_RPT;
    protected CoreCharacter PAYPOT_TYPE;
    protected CoreCharacter PAYPOT_GROUP;
    protected CoreDecimal CEIEAR_SEQ;
    protected CoreCharacter CEIEAR_TYPE;
    protected CoreDecimal CEIEXP_SEQ;
    protected CoreCharacter CEIEXP_TYPE;
    protected CoreDecimal TOTINC_SEQ;
    protected CoreCharacter TOTINC_TYPE;
    protected CoreDecimal YTDCEA_SEQ;
    protected CoreCharacter YTDCEA_TYPE;
    protected CoreDecimal YTDCEX_SEQ;
    protected CoreCharacter YTDCEX_TYPE;
    protected CoreDecimal YTDEAR_SEQ;
    protected CoreCharacter YTDEAR_TYPE;
    protected CoreDecimal YTDINC_SEQ;
    protected CoreCharacter YTDINC_TYPE;
    protected CoreDecimal YTDGUB_SEQ;
    protected CoreCharacter YTDGUB_TYPE;
    protected CoreDecimal YTDGUC_SEQ;
    protected CoreCharacter YTDGUC_TYPE;
    protected CoreDecimal YTDGUD_SEQ;
    protected CoreCharacter YTDGUD_TYPE;
    protected CoreDecimal STATUS_SEQ;
    protected CoreDecimal STATUS_SEQ_RPT;
    protected CoreCharacter STATUS_TYPE;
    protected CoreCharacter STATUS_GROUP;
    protected CoreDecimal ADVOUT_SEQ;
    protected CoreDecimal ADVOUT_SEQ_RPT;
    protected CoreCharacter ADVOUT_TYPE;
    protected CoreCharacter ADVOUT_GROUP;
    protected CoreDecimal ADVOUT_FACTOR;
    protected CoreDecimal TOTADV_SEQ;
    protected CoreDecimal TOTADV_SEQ_RPT;
    protected CoreCharacter TOTADV_TYPE;
    protected CoreCharacter TOTADV_GROUP;
    protected CoreDecimal TOTADV_FACTOR;
    protected CoreDecimal DEPINC_SEQ;
    protected CoreDecimal DEPINC_SEQ_RPT;
    protected CoreCharacter DEPINC_TYPE;
    protected CoreCharacter DEPINC_GROUP;
    protected CoreDecimal DEPINC_FACTOR;
    protected CoreDecimal SVCRTE_SEQ;
    protected CoreDecimal SVCRTE_SEQ_RPT;
    protected CoreCharacter SVCRTE_TYPE;
    protected CoreCharacter SVCRTE_GROUP;
    protected CoreDecimal SVCRTE_FACTOR;
    protected CoreDecimal SVCCHG_SEQ;
    protected CoreDecimal SVCCHG_SEQ_RPT;
    protected CoreCharacter SVCCHG_TYPE;
    protected CoreCharacter SVCCHG_GROUP;
    protected CoreDecimal SVCCHG_FACTOR;
    protected CoreDecimal KEYHRS_SEQ;
    protected CoreDecimal KEYHRS_SEQ_RPT;
    protected CoreCharacter KEYHRS_TYPE;
    protected CoreCharacter KEYHRS_GROUP;
    protected CoreDecimal KEYHRS_FACTOR;
    protected CoreDecimal KEYRTE_SEQ;
    protected CoreDecimal KEYRTE_SEQ_RPT;
    protected CoreCharacter KEYRTE_TYPE;
    protected CoreCharacter KEYRTE_GROUP;
    protected CoreDecimal KEYRTE_FACTOR;
    protected CoreDecimal KEYCHG_SEQ;
    protected CoreDecimal KEYCHG_SEQ_RPT;
    protected CoreCharacter KEYCHG_TYPE;
    protected CoreCharacter KEYCHG_GROUP;
    protected CoreDecimal KEYCHG_FACTOR;
    protected CoreDecimal DEPCHG_SEQ;
    protected CoreDecimal DEPCHG_SEQ_RPT;
    protected CoreCharacter DEPCHG_TYPE;
    protected CoreCharacter DEPCHG_GROUP;
    protected CoreDecimal DEPCHG_FACTOR;
    protected CoreDecimal DEPFTE_SEQ;
    protected CoreDecimal DEPFTE_SEQ_RPT;
    protected CoreCharacter DEPFTE_TYPE;
    protected CoreCharacter DEPFTE_GROUP;
    protected CoreDecimal DEPFTE_FACTOR;
    protected CoreDecimal DOCCHG_SEQ;
    protected CoreDecimal DOCCHG_SEQ_RPT;
    protected CoreCharacter DOCCHG_TYPE;
    protected CoreCharacter DOCCHG_GROUP;
    protected CoreDecimal DOCCHG_FACTOR;
    protected CoreDecimal HSTRTE_SEQ;
    protected CoreDecimal HSTRTE_SEQ_RPT;
    protected CoreCharacter HSTRTE_TYPE;
    protected CoreCharacter HSTRTE_GROUP;
    protected CoreDecimal HSTRTE_FACTOR;
    protected CoreDecimal PY7HST_SEQ;
    protected CoreDecimal PY7HST_SEQ_RPT;
    protected CoreCharacter PY7HST_TYPE;
    protected CoreCharacter PY7HST_GROUP;
    protected CoreDecimal PY7HST_FACTOR;
    protected CoreDecimal FINCHG_SEQ;
    protected CoreDecimal FINCHG_SEQ_RPT;
    protected CoreCharacter FINCHG_TYPE;
    protected CoreCharacter FINCHG_GROUP;
    protected CoreDecimal FINCHG_FACTOR;
    protected CoreDecimal DOCFTE_SEQ;
    protected CoreDecimal DOCFTE_SEQ_RPT;
    protected CoreCharacter DOCFTE_TYPE;
    protected CoreCharacter DOCFTE_GROUP;

    protected CoreDecimal DOCFTE_FACTOR;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U116_CONST_MSTR_GET_EP_NBR_1 CONST_MSTR_GET_EP_NBR_1 = new U116_CONST_MSTR_GET_EP_NBR_1(Name, Level);
            CONST_MSTR_GET_EP_NBR_1.Run();
            CONST_MSTR_GET_EP_NBR_1.Dispose();
            CONST_MSTR_GET_EP_NBR_1 = null;

            U116_A_GET_PAYPOT_2 A_GET_PAYPOT_2 = new U116_A_GET_PAYPOT_2(Name, Level);
            A_GET_PAYPOT_2.Run();
            A_GET_PAYPOT_2.Dispose();
            A_GET_PAYPOT_2 = null;

            U116_GET_CEIEAR_3 GET_CEIEAR_3 = new U116_GET_CEIEAR_3(Name, Level);
            GET_CEIEAR_3.Run();
            GET_CEIEAR_3.Dispose();
            GET_CEIEAR_3 = null;

            U116_GET_YTDEAR_4 GET_YTDEAR_4 = new U116_GET_YTDEAR_4(Name, Level);
            GET_YTDEAR_4.Run();
            GET_YTDEAR_4.Dispose();
            GET_YTDEAR_4 = null;

            U116_GET_YTDCEA_5 GET_YTDCEA_5 = new U116_GET_YTDCEA_5(Name, Level);
            GET_YTDCEA_5.Run();
            GET_YTDCEA_5.Dispose();
            GET_YTDCEA_5 = null;

            U116_GET_YTDCEX_6 GET_YTDCEX_6 = new U116_GET_YTDCEX_6(Name, Level);
            GET_YTDCEX_6.Run();
            GET_YTDCEX_6.Dispose();
            GET_YTDCEX_6 = null;

            U116_GET_TOTINC_7 GET_TOTINC_7 = new U116_GET_TOTINC_7(Name, Level);
            GET_TOTINC_7.Run();
            GET_TOTINC_7.Dispose();
            GET_TOTINC_7 = null;

            U116_GET_YTDINC_8 GET_YTDINC_8 = new U116_GET_YTDINC_8(Name, Level);
            GET_YTDINC_8.Run();
            GET_YTDINC_8.Dispose();
            GET_YTDINC_8 = null;

            U116_GET_YTDGUB_9 GET_YTDGUB_9 = new U116_GET_YTDGUB_9(Name, Level);
            GET_YTDGUB_9.Run();
            GET_YTDGUB_9.Dispose();
            GET_YTDGUB_9 = null;

            U116_GET_YTDGUC_10 GET_YTDGUC_10 = new U116_GET_YTDGUC_10(Name, Level);
            GET_YTDGUC_10.Run();
            GET_YTDGUC_10.Dispose();
            GET_YTDGUC_10 = null;

            U116_GET_UNDER_11 GET_UNDER_11 = new U116_GET_UNDER_11(Name, Level);
            GET_UNDER_11.Run();
            GET_UNDER_11.Dispose();
            GET_UNDER_11 = null;

            U116_A_GET_ADVOUT_12 A_GET_ADVOUT_12 = new U116_A_GET_ADVOUT_12(Name, Level);
            A_GET_ADVOUT_12.Run();
            A_GET_ADVOUT_12.Dispose();
            A_GET_ADVOUT_12 = null;

            U116_A_GET_TOTADV_13 A_GET_TOTADV_13 = new U116_A_GET_TOTADV_13(Name, Level);
            A_GET_TOTADV_13.Run();
            A_GET_TOTADV_13.Dispose();
            A_GET_TOTADV_13 = null;

            U116_A_GET_DEPINC_14 A_GET_DEPINC_14 = new U116_A_GET_DEPINC_14(Name, Level);
            A_GET_DEPINC_14.Run();
            A_GET_DEPINC_14.Dispose();
            A_GET_DEPINC_14 = null;

            U116_A_GET_SVCRTE_15 A_GET_SVCRTE_15 = new U116_A_GET_SVCRTE_15(Name, Level);
            A_GET_SVCRTE_15.Run();
            A_GET_SVCRTE_15.Dispose();
            A_GET_SVCRTE_15 = null;

            U116_A_GET_SVCCHG_16 A_GET_SVCCHG_16 = new U116_A_GET_SVCCHG_16(Name, Level);
            A_GET_SVCCHG_16.Run();
            A_GET_SVCCHG_16.Dispose();
            A_GET_SVCCHG_16 = null;

            U116_A_GET_KEYHRS_17 A_GET_KEYHRS_17 = new U116_A_GET_KEYHRS_17(Name, Level);
            A_GET_KEYHRS_17.Run();
            A_GET_KEYHRS_17.Dispose();
            A_GET_KEYHRS_17 = null;

            U116_A_GET_KEYRTE_18 A_GET_KEYRTE_18 = new U116_A_GET_KEYRTE_18(Name, Level);
            A_GET_KEYRTE_18.Run();
            A_GET_KEYRTE_18.Dispose();
            A_GET_KEYRTE_18 = null;

            U116_A_GET_KEYCHG_19 A_GET_KEYCHG_19 = new U116_A_GET_KEYCHG_19(Name, Level);
            A_GET_KEYCHG_19.Run();
            A_GET_KEYCHG_19.Dispose();
            A_GET_KEYCHG_19 = null;

            U116_A_GET_DEPCHG_20 A_GET_DEPCHG_20 = new U116_A_GET_DEPCHG_20(Name, Level);
            A_GET_DEPCHG_20.Run();
            A_GET_DEPCHG_20.Dispose();
            A_GET_DEPCHG_20 = null;

            U116_A_GET_DEPFTE_21 A_GET_DEPFTE_21 = new U116_A_GET_DEPFTE_21(Name, Level);
            A_GET_DEPFTE_21.Run();
            A_GET_DEPFTE_21.Dispose();
            A_GET_DEPFTE_21 = null;

            U116_A_GET_DOCCHG_22 A_GET_DOCCHG_22 = new U116_A_GET_DOCCHG_22(Name, Level);
            A_GET_DOCCHG_22.Run();
            A_GET_DOCCHG_22.Dispose();
            A_GET_DOCCHG_22 = null;

            U116_A_GET_PY7HST_23 A_GET_PY7HST_23 = new U116_A_GET_PY7HST_23(Name, Level);
            A_GET_PY7HST_23.Run();
            A_GET_PY7HST_23.Dispose();
            A_GET_PY7HST_23 = null;

            U116_A_GET_FINCHG_24 A_GET_FINCHG_24 = new U116_A_GET_FINCHG_24(Name, Level);
            A_GET_FINCHG_24.Run();
            A_GET_FINCHG_24.Dispose();
            A_GET_FINCHG_24 = null;

            U116_A_GET_DOCFTE_25 A_GET_DOCFTE_25 = new U116_A_GET_DOCFTE_25(Name, Level);
            A_GET_DOCFTE_25.Run();
            A_GET_DOCFTE_25.Dispose();
            A_GET_DOCFTE_25 = null;

            U116_RUN_0_CALC_PAYCD_0_26 RUN_0_CALC_PAYCD_0_26 = new U116_RUN_0_CALC_PAYCD_0_26(Name, Level);
            RUN_0_CALC_PAYCD_0_26.Run();
            RUN_0_CALC_PAYCD_0_26.Dispose();
            RUN_0_CALC_PAYCD_0_26 = null;

            U116_RUN_1_CALC_PAYCD_1X_27 RUN_1_CALC_PAYCD_1X_27 = new U116_RUN_1_CALC_PAYCD_1X_27(Name, Level);
            RUN_1_CALC_PAYCD_1X_27.Run();
            RUN_1_CALC_PAYCD_1X_27.Dispose();
            RUN_1_CALC_PAYCD_1X_27 = null;

            U116_RUN_2_CALC_PAYCD_2_28 RUN_2_CALC_PAYCD_2_28 = new U116_RUN_2_CALC_PAYCD_2_28(Name, Level);
            RUN_2_CALC_PAYCD_2_28.Run();
            RUN_2_CALC_PAYCD_2_28.Dispose();
            RUN_2_CALC_PAYCD_2_28 = null;

            U116_RUN_3_PAYCODES_346_29 RUN_3_PAYCODES_346_29 = new U116_RUN_3_PAYCODES_346_29(Name, Level);
            RUN_3_PAYCODES_346_29.Run();
            RUN_3_PAYCODES_346_29.Dispose();
            RUN_3_PAYCODES_346_29 = null;

            //U116_RUN_2_CALC_PAYCD_5_30 RUN_2_CALC_PAYCD_5_30 = new U116_RUN_2_CALC_PAYCD_5_30(Name, Level);
            //RUN_2_CALC_PAYCD_5_30.Run();
            //RUN_2_CALC_PAYCD_5_30.Dispose();
            //RUN_2_CALC_PAYCD_5_30 = null;

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



public class U116_CONST_MSTR_GET_EP_NBR_1 : U116
{

    public U116_CONST_MSTR_GET_EP_NBR_1(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_CONST_MSTR_GET_EP_NBR_1)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;

    private void fleCONSTANTS_MSTR_REC_6_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
            strSQL.Append(6);


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


    #region "Standard Generated Procedures(U116_CONST_MSTR_GET_EP_NBR_1)"


    #region "Automatic Item Initialization(U116_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:41 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U116_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:41 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_CONST_MSTR_GET_EP_NBR_1)"


    public void Run()
    {

        try
        {
            Request("CONST_MSTR_GET_EP_NBR_1");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                if (Transaction())
                {
                    W_CURRENT_EP_NBR.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR");
                    W_CURRENT_EP_NBR_MINUS1.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1;

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
            EndRequest("CONST_MSTR_GET_EP_NBR_1");

        }

    }







    #endregion


}
//CONST_MSTR_GET_EP_NBR_1



public class U116_A_GET_PAYPOT_2 : U116
{

    public U116_A_GET_PAYPOT_2(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_PAYPOT_2)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("PAYPOT"));


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


    #region "Standard Generated Procedures(U116_A_GET_PAYPOT_2)"


    #region "Automatic Item Initialization(U116_A_GET_PAYPOT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_PAYPOT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:41 PM

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


    #region "FILE Management Procedures(U116_A_GET_PAYPOT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:41 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_PAYPOT_2)"


    public void Run()
    {

        try
        {
            Request("A_GET_PAYPOT_2");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    PAYPOT_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    PAYPOT_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    PAYPOT_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    PAYPOT_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");

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
            EndRequest("A_GET_PAYPOT_2");

        }

    }







    #endregion


}
//A_GET_PAYPOT_2



public class U116_GET_CEIEAR_3 : U116
{

    public U116_GET_CEIEAR_3(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_GET_CEIEAR_3)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("CEIEAR"));


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


    #region "Standard Generated Procedures(U116_GET_CEIEAR_3)"


    #region "Automatic Item Initialization(U116_GET_CEIEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_GET_CEIEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:41 PM

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


    #region "FILE Management Procedures(U116_GET_CEIEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:41 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_GET_CEIEAR_3)"


    public void Run()
    {

        try
        {
            Request("GET_CEIEAR_3");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    CEIEAR_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    CEIEAR_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("GET_CEIEAR_3");

        }

    }







    #endregion


}
//GET_CEIEAR_3



public class U116_GET_YTDEAR_4 : U116
{

    public U116_GET_YTDEAR_4(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_GET_YTDEAR_4)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDEAR"));


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


    #region "Standard Generated Procedures(U116_GET_YTDEAR_4)"


    #region "Automatic Item Initialization(U116_GET_YTDEAR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_GET_YTDEAR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:41 PM

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


    #region "FILE Management Procedures(U116_GET_YTDEAR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:42 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_GET_YTDEAR_4)"


    public void Run()
    {

        try
        {
            Request("GET_YTDEAR_4");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDEAR_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDEAR_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("GET_YTDEAR_4");

        }

    }







    #endregion


}
//GET_YTDEAR_4



public class U116_GET_YTDCEA_5 : U116
{

    public U116_GET_YTDCEA_5(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_GET_YTDCEA_5)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDCEA"));


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


    #region "Standard Generated Procedures(U116_GET_YTDCEA_5)"


    #region "Automatic Item Initialization(U116_GET_YTDCEA_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_GET_YTDCEA_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:42 PM

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


    #region "FILE Management Procedures(U116_GET_YTDCEA_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:42 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_GET_YTDCEA_5)"


    public void Run()
    {

        try
        {
            Request("GET_YTDCEA_5");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDCEA_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDCEA_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("GET_YTDCEA_5");

        }

    }







    #endregion


}
//GET_YTDCEA_5



public class U116_GET_YTDCEX_6 : U116
{

    public U116_GET_YTDCEX_6(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_GET_YTDCEX_6)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDCEX"));


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


    #region "Standard Generated Procedures(U116_GET_YTDCEX_6)"


    #region "Automatic Item Initialization(U116_GET_YTDCEX_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_GET_YTDCEX_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:42 PM

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


    #region "FILE Management Procedures(U116_GET_YTDCEX_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:42 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_GET_YTDCEX_6)"


    public void Run()
    {

        try
        {
            Request("GET_YTDCEX_6");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDCEX_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDCEX_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("GET_YTDCEX_6");

        }

    }







    #endregion


}
//GET_YTDCEX_6



public class U116_GET_TOTINC_7 : U116
{

    public U116_GET_TOTINC_7(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_GET_TOTINC_7)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("TOTINC"));


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


    #region "Standard Generated Procedures(U116_GET_TOTINC_7)"


    #region "Automatic Item Initialization(U116_GET_TOTINC_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_GET_TOTINC_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:42 PM

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


    #region "FILE Management Procedures(U116_GET_TOTINC_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:42 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_GET_TOTINC_7)"


    public void Run()
    {

        try
        {
            Request("GET_TOTINC_7");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    TOTINC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    TOTINC_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("GET_TOTINC_7");

        }

    }







    #endregion


}
//GET_TOTINC_7



public class U116_GET_YTDINC_8 : U116
{

    public U116_GET_YTDINC_8(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_GET_YTDINC_8)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDINC"));


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


    #region "Standard Generated Procedures(U116_GET_YTDINC_8)"


    #region "Automatic Item Initialization(U116_GET_YTDINC_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_GET_YTDINC_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:42 PM

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


    #region "FILE Management Procedures(U116_GET_YTDINC_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:42 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_GET_YTDINC_8)"


    public void Run()
    {

        try
        {
            Request("GET_YTDINC_8");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDINC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDINC_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("GET_YTDINC_8");

        }

    }







    #endregion


}
//GET_YTDINC_8



public class U116_GET_YTDGUB_9 : U116
{

    public U116_GET_YTDGUB_9(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_GET_YTDGUB_9)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDGUB"));


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


    #region "Standard Generated Procedures(U116_GET_YTDGUB_9)"


    #region "Automatic Item Initialization(U116_GET_YTDGUB_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_GET_YTDGUB_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:43 PM

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


    #region "FILE Management Procedures(U116_GET_YTDGUB_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:43 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_GET_YTDGUB_9)"


    public void Run()
    {

        try
        {
            Request("GET_YTDGUB_9");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDGUB_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDGUB_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("GET_YTDGUB_9");

        }

    }







    #endregion


}
//GET_YTDGUB_9



public class U116_GET_YTDGUC_10 : U116
{

    public U116_GET_YTDGUC_10(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_GET_YTDGUC_10)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDGUC"));


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


    #region "Standard Generated Procedures(U116_GET_YTDGUC_10)"


    #region "Automatic Item Initialization(U116_GET_YTDGUC_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_GET_YTDGUC_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:43 PM

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


    #region "FILE Management Procedures(U116_GET_YTDGUC_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:43 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_GET_YTDGUC_10)"


    public void Run()
    {

        try
        {
            Request("GET_YTDGUC_10");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDGUC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    YTDGUC_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("GET_YTDGUC_10");

        }

    }







    #endregion


}
//GET_YTDGUC_10



public class U116_GET_UNDER_11 : U116
{

    public U116_GET_UNDER_11(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_GET_UNDER_11)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("STATUS"));


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


    #region "Standard Generated Procedures(U116_GET_UNDER_11)"


    #region "Automatic Item Initialization(U116_GET_UNDER_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_GET_UNDER_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:43 PM

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


    #region "FILE Management Procedures(U116_GET_UNDER_11)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:43 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_GET_UNDER_11)"


    public void Run()
    {

        try
        {
            Request("GET_UNDER_11");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    STATUS_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    STATUS_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    STATUS_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    STATUS_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");

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
            EndRequest("GET_UNDER_11");

        }

    }







    #endregion


}
//GET_UNDER_11



public class U116_A_GET_ADVOUT_12 : U116
{

    public U116_A_GET_ADVOUT_12(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_ADVOUT_12)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("ADVOUT"));


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


    #region "Standard Generated Procedures(U116_A_GET_ADVOUT_12)"


    #region "Automatic Item Initialization(U116_A_GET_ADVOUT_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_ADVOUT_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:43 PM

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


    #region "FILE Management Procedures(U116_A_GET_ADVOUT_12)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:43 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_ADVOUT_12)"


    public void Run()
    {

        try
        {
            Request("A_GET_ADVOUT_12");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    ADVOUT_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    ADVOUT_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    ADVOUT_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    ADVOUT_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    ADVOUT_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_ADVOUT_12");

        }

    }







    #endregion


}
//A_GET_ADVOUT_12



public class U116_A_GET_TOTADV_13 : U116
{

    public U116_A_GET_TOTADV_13(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_TOTADV_13)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("ADVOUT"));


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


    #region "Standard Generated Procedures(U116_A_GET_TOTADV_13)"


    #region "Automatic Item Initialization(U116_A_GET_TOTADV_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_TOTADV_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:44 PM

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


    #region "FILE Management Procedures(U116_A_GET_TOTADV_13)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:44 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_TOTADV_13)"


    public void Run()
    {

        try
        {
            Request("A_GET_TOTADV_13");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--


                if (Transaction())
                {
                    TOTADV_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    TOTADV_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    TOTADV_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    TOTADV_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    TOTADV_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_TOTADV_13");

        }

    }







    #endregion


}
//A_GET_TOTADV_13



public class U116_A_GET_DEPINC_14 : U116
{

    public U116_A_GET_DEPINC_14(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_DEPINC_14)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("DEPINC"));


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


    #region "Standard Generated Procedures(U116_A_GET_DEPINC_14)"


    #region "Automatic Item Initialization(U116_A_GET_DEPINC_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_DEPINC_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:44 PM

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


    #region "FILE Management Procedures(U116_A_GET_DEPINC_14)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:44 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_DEPINC_14)"


    public void Run()
    {

        try
        {
            Request("A_GET_DEPINC_14");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    DEPINC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    DEPINC_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    DEPINC_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    DEPINC_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    DEPINC_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_DEPINC_14");

        }

    }







    #endregion


}
//A_GET_DEPINC_14



public class U116_A_GET_SVCRTE_15 : U116
{

    public U116_A_GET_SVCRTE_15(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_SVCRTE_15)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("SVCRTE"));


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


    #region "Standard Generated Procedures(U116_A_GET_SVCRTE_15)"


    #region "Automatic Item Initialization(U116_A_GET_SVCRTE_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_SVCRTE_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:44 PM

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


    #region "FILE Management Procedures(U116_A_GET_SVCRTE_15)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:44 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_SVCRTE_15)"


    public void Run()
    {

        try
        {
            Request("A_GET_SVCRTE_15");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    SVCRTE_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    SVCRTE_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    SVCRTE_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    SVCRTE_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    SVCRTE_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_SVCRTE_15");

        }

    }







    #endregion


}
//A_GET_SVCRTE_15



public class U116_A_GET_SVCCHG_16 : U116
{

    public U116_A_GET_SVCCHG_16(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_SVCCHG_16)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("SVCCHG"));


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


    #region "Standard Generated Procedures(U116_A_GET_SVCCHG_16)"


    #region "Automatic Item Initialization(U116_A_GET_SVCCHG_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_SVCCHG_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:44 PM

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


    #region "FILE Management Procedures(U116_A_GET_SVCCHG_16)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:45 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_SVCCHG_16)"


    public void Run()
    {

        try
        {
            Request("A_GET_SVCCHG_16");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    SVCCHG_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    SVCCHG_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    SVCCHG_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    SVCCHG_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    SVCCHG_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_SVCCHG_16");

        }

    }







    #endregion


}
//A_GET_SVCCHG_16



public class U116_A_GET_KEYHRS_17 : U116
{

    public U116_A_GET_KEYHRS_17(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_KEYHRS_17)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("KEYHRS"));


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


    #region "Standard Generated Procedures(U116_A_GET_KEYHRS_17)"


    #region "Automatic Item Initialization(U116_A_GET_KEYHRS_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_KEYHRS_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:45 PM

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


    #region "FILE Management Procedures(U116_A_GET_KEYHRS_17)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:45 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_KEYHRS_17)"


    public void Run()
    {

        try
        {
            Request("A_GET_KEYHRS_17");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    KEYHRS_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    KEYHRS_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    KEYHRS_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    KEYHRS_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    KEYHRS_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_KEYHRS_17");

        }

    }







    #endregion


}
//A_GET_KEYHRS_17



public class U116_A_GET_KEYRTE_18 : U116
{

    public U116_A_GET_KEYRTE_18(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_KEYRTE_18)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("KEYRTE"));


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


    #region "Standard Generated Procedures(U116_A_GET_KEYRTE_18)"


    #region "Automatic Item Initialization(U116_A_GET_KEYRTE_18)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_KEYRTE_18)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:45 PM

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


    #region "FILE Management Procedures(U116_A_GET_KEYRTE_18)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:45 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_KEYRTE_18)"


    public void Run()
    {

        try
        {
            Request("A_GET_KEYRTE_18");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    KEYRTE_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    KEYRTE_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    KEYRTE_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    KEYRTE_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    KEYRTE_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_KEYRTE_18");

        }

    }







    #endregion


}
//A_GET_KEYRTE_18



public class U116_A_GET_KEYCHG_19 : U116
{

    public U116_A_GET_KEYCHG_19(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_KEYCHG_19)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("KEYCHG"));


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


    #region "Standard Generated Procedures(U116_A_GET_KEYCHG_19)"


    #region "Automatic Item Initialization(U116_A_GET_KEYCHG_19)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_KEYCHG_19)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:45 PM

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


    #region "FILE Management Procedures(U116_A_GET_KEYCHG_19)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:45 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_KEYCHG_19)"


    public void Run()
    {

        try
        {
            Request("A_GET_KEYCHG_19");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    KEYCHG_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    KEYCHG_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    KEYCHG_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    KEYCHG_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    KEYCHG_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_KEYCHG_19");

        }

    }







    #endregion


}
//A_GET_KEYCHG_19



public class U116_A_GET_DEPCHG_20 : U116
{

    public U116_A_GET_DEPCHG_20(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_DEPCHG_20)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("DEPCHG"));


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


    #region "Standard Generated Procedures(U116_A_GET_DEPCHG_20)"


    #region "Automatic Item Initialization(U116_A_GET_DEPCHG_20)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_DEPCHG_20)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:46 PM

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


    #region "FILE Management Procedures(U116_A_GET_DEPCHG_20)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:46 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_DEPCHG_20)"


    public void Run()
    {

        try
        {
            Request("A_GET_DEPCHG_20");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    DEPCHG_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    DEPCHG_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    DEPCHG_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    DEPCHG_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    DEPCHG_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_DEPCHG_20");

        }

    }







    #endregion


}
//A_GET_DEPCHG_20



public class U116_A_GET_DEPFTE_21 : U116
{

    public U116_A_GET_DEPFTE_21(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_DEPFTE_21)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("DEPFTE"));


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


    #region "Standard Generated Procedures(U116_A_GET_DEPFTE_21)"


    #region "Automatic Item Initialization(U116_A_GET_DEPFTE_21)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_DEPFTE_21)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:46 PM

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


    #region "FILE Management Procedures(U116_A_GET_DEPFTE_21)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:46 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_DEPFTE_21)"


    public void Run()
    {

        try
        {
            Request("A_GET_DEPFTE_21");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    DEPFTE_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    DEPFTE_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    DEPFTE_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    DEPFTE_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    DEPFTE_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_DEPFTE_21");

        }

    }







    #endregion


}
//A_GET_DEPFTE_21



public class U116_A_GET_DOCCHG_22 : U116
{

    public U116_A_GET_DOCCHG_22(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_DOCCHG_22)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("DOCCHG"));


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


    #region "Standard Generated Procedures(U116_A_GET_DOCCHG_22)"


    #region "Automatic Item Initialization(U116_A_GET_DOCCHG_22)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_DOCCHG_22)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:46 PM

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


    #region "FILE Management Procedures(U116_A_GET_DOCCHG_22)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:46 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_DOCCHG_22)"


    public void Run()
    {

        try
        {
            Request("A_GET_DOCCHG_22");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    DOCCHG_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    DOCCHG_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    DOCCHG_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    DOCCHG_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    DOCCHG_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_DOCCHG_22");

        }

    }







    #endregion


}
//A_GET_DOCCHG_22



public class U116_A_GET_PY7HST_23 : U116
{

    public U116_A_GET_PY7HST_23(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_PY7HST_23)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("PY7HST"));


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


    #region "Standard Generated Procedures(U116_A_GET_PY7HST_23)"


    #region "Automatic Item Initialization(U116_A_GET_PY7HST_23)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_PY7HST_23)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:46 PM

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


    #region "FILE Management Procedures(U116_A_GET_PY7HST_23)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:47 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_PY7HST_23)"


    public void Run()
    {

        try
        {
            Request("A_GET_PY7HST_23");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    PY7HST_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    PY7HST_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    PY7HST_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    PY7HST_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    PY7HST_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_PY7HST_23");

        }

    }







    #endregion


}
//A_GET_PY7HST_23



public class U116_A_GET_FINCHG_24 : U116
{

    public U116_A_GET_FINCHG_24(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_FINCHG_24)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("FINCHG"));


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


    #region "Standard Generated Procedures(U116_A_GET_FINCHG_24)"


    #region "Automatic Item Initialization(U116_A_GET_FINCHG_24)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_FINCHG_24)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:47 PM

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


    #region "FILE Management Procedures(U116_A_GET_FINCHG_24)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:47 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_FINCHG_24)"


    public void Run()
    {

        try
        {
            Request("A_GET_FINCHG_24");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    FINCHG_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    FINCHG_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    FINCHG_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    FINCHG_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    FINCHG_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_FINCHG_24");

        }

    }







    #endregion


}
//A_GET_FINCHG_24



public class U116_A_GET_DOCFTE_25 : U116
{

    public U116_A_GET_DOCFTE_25(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U116_A_GET_DOCFTE_25)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("DOCFTE"));


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


    #region "Standard Generated Procedures(U116_A_GET_DOCFTE_25)"


    #region "Automatic Item Initialization(U116_A_GET_DOCFTE_25)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U116_A_GET_DOCFTE_25)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:47 PM

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


    #region "FILE Management Procedures(U116_A_GET_DOCFTE_25)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:47 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_A_GET_DOCFTE_25)"


    public void Run()
    {

        try
        {
            Request("A_GET_DOCFTE_25");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    DOCFTE_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    DOCFTE_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    DOCFTE_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    DOCFTE_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    DOCFTE_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("A_GET_DOCFTE_25");

        }

    }







    #endregion


}
//A_GET_DOCFTE_25



public class U116_RUN_0_CALC_PAYCD_0_26 : U116
{

    public U116_RUN_0_CALC_PAYCD_0_26(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ = new CoreDecimal("PAYPOT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ_RPT = new CoreDecimal("PAYPOT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_TYPE = new CoreCharacter("PAYPOT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYPOT_GROUP = new CoreCharacter("PAYPOT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEAR_SEQ = new CoreDecimal("CEIEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEAR_TYPE = new CoreCharacter("CEIEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEXP_SEQ = new CoreDecimal("CEIEXP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEXP_TYPE = new CoreCharacter("CEIEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTINC_SEQ = new CoreDecimal("TOTINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTINC_TYPE = new CoreCharacter("TOTINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEA_SEQ = new CoreDecimal("YTDCEA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEA_TYPE = new CoreCharacter("YTDCEA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEX_SEQ = new CoreDecimal("YTDCEX_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEX_TYPE = new CoreCharacter("YTDCEX_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDEAR_SEQ = new CoreDecimal("YTDEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDEAR_TYPE = new CoreCharacter("YTDEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDINC_SEQ = new CoreDecimal("YTDINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDINC_TYPE = new CoreCharacter("YTDINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUB_SEQ = new CoreDecimal("YTDGUB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUB_TYPE = new CoreCharacter("YTDGUB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUC_SEQ = new CoreDecimal("YTDGUC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUC_TYPE = new CoreCharacter("YTDGUC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUD_SEQ = new CoreDecimal("YTDGUD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUD_TYPE = new CoreCharacter("YTDGUD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_SEQ = new CoreDecimal("STATUS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        STATUS_SEQ_RPT = new CoreDecimal("STATUS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        STATUS_TYPE = new CoreCharacter("STATUS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_GROUP = new CoreCharacter("STATUS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_SEQ = new CoreDecimal("ADVOUT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_SEQ_RPT = new CoreDecimal("ADVOUT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_TYPE = new CoreCharacter("ADVOUT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_GROUP = new CoreCharacter("ADVOUT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_FACTOR = new CoreDecimal("ADVOUT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ = new CoreDecimal("TOTADV_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ_RPT = new CoreDecimal("TOTADV_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_TYPE = new CoreCharacter("TOTADV_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_GROUP = new CoreCharacter("TOTADV_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_FACTOR = new CoreDecimal("TOTADV_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ = new CoreDecimal("DEPINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ_RPT = new CoreDecimal("DEPINC_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_TYPE = new CoreCharacter("DEPINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_GROUP = new CoreCharacter("DEPINC_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_FACTOR = new CoreDecimal("DEPINC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ = new CoreDecimal("SVCRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ_RPT = new CoreDecimal("SVCRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_TYPE = new CoreCharacter("SVCRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_GROUP = new CoreCharacter("SVCRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_FACTOR = new CoreDecimal("SVCRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ = new CoreDecimal("SVCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ_RPT = new CoreDecimal("SVCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_TYPE = new CoreCharacter("SVCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_GROUP = new CoreCharacter("SVCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_FACTOR = new CoreDecimal("SVCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ = new CoreDecimal("KEYHRS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ_RPT = new CoreDecimal("KEYHRS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_TYPE = new CoreCharacter("KEYHRS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_GROUP = new CoreCharacter("KEYHRS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_FACTOR = new CoreDecimal("KEYHRS_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ = new CoreDecimal("KEYRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ_RPT = new CoreDecimal("KEYRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_TYPE = new CoreCharacter("KEYRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_GROUP = new CoreCharacter("KEYRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_FACTOR = new CoreDecimal("KEYRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ = new CoreDecimal("KEYCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ_RPT = new CoreDecimal("KEYCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_TYPE = new CoreCharacter("KEYCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_GROUP = new CoreCharacter("KEYCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_FACTOR = new CoreDecimal("KEYCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ = new CoreDecimal("DEPCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ_RPT = new CoreDecimal("DEPCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_TYPE = new CoreCharacter("DEPCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_GROUP = new CoreCharacter("DEPCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_FACTOR = new CoreDecimal("DEPCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ = new CoreDecimal("DEPFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ_RPT = new CoreDecimal("DEPFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_TYPE = new CoreCharacter("DEPFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_GROUP = new CoreCharacter("DEPFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_FACTOR = new CoreDecimal("DEPFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ = new CoreDecimal("DOCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ_RPT = new CoreDecimal("DOCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_TYPE = new CoreCharacter("DOCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_GROUP = new CoreCharacter("DOCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_FACTOR = new CoreDecimal("DOCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ = new CoreDecimal("HSTRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ_RPT = new CoreDecimal("HSTRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_TYPE = new CoreCharacter("HSTRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_GROUP = new CoreCharacter("HSTRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_FACTOR = new CoreDecimal("HSTRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ = new CoreDecimal("PY7HST_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ_RPT = new CoreDecimal("PY7HST_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_TYPE = new CoreCharacter("PY7HST_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_GROUP = new CoreCharacter("PY7HST_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_FACTOR = new CoreDecimal("PY7HST_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ = new CoreDecimal("FINCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ_RPT = new CoreDecimal("FINCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_TYPE = new CoreCharacter("FINCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_GROUP = new CoreCharacter("FINCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_FACTOR = new CoreDecimal("FINCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ = new CoreDecimal("DOCFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ_RPT = new CoreDecimal("DOCFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_TYPE = new CoreCharacter("DOCFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_GROUP = new CoreCharacter("DOCFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_FACTOR = new CoreDecimal("DOCFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_OUTPUT_PAYPOT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_OUTPUT_PAYPOT", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_COMP_CODE = new CoreCharacter("X_COMP_CODE", 6, this, Common.cEmptyString);
        fleF119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        W_PAYPOT_AMT_NET.GetValue += W_PAYPOT_AMT_NET_GetValue;
        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        X_NOT_NEEDED.GetValue += X_NOT_NEEDED_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF110_OUTPUT_PAYPOT.InitializeItems += fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization;
        fleF112_PYCDCEILINGS.SelectIf += FleF112_PYCDCEILINGS_SelectIf;
    }


    #region "Declarations (Variables, Files and Transactions)(U116_RUN_0_CALC_PAYCD_0_26)"

    protected CoreDecimal W_CURRENT_EP_NBR;
    protected CoreDecimal W_CURRENT_EP_NBR_MINUS1;
    protected CoreDecimal PAYPOT_SEQ;
    protected CoreDecimal PAYPOT_SEQ_RPT;
    protected CoreCharacter PAYPOT_TYPE;
    protected CoreCharacter PAYPOT_GROUP;
    protected CoreDecimal CEIEAR_SEQ;
    protected CoreCharacter CEIEAR_TYPE;
    protected CoreDecimal CEIEXP_SEQ;
    protected CoreCharacter CEIEXP_TYPE;
    protected CoreDecimal TOTINC_SEQ;
    protected CoreCharacter TOTINC_TYPE;
    protected CoreDecimal YTDCEA_SEQ;
    protected CoreCharacter YTDCEA_TYPE;
    protected CoreDecimal YTDCEX_SEQ;
    protected CoreCharacter YTDCEX_TYPE;
    protected CoreDecimal YTDEAR_SEQ;
    protected CoreCharacter YTDEAR_TYPE;
    protected CoreDecimal YTDINC_SEQ;
    protected CoreCharacter YTDINC_TYPE;
    protected CoreDecimal YTDGUB_SEQ;
    protected CoreCharacter YTDGUB_TYPE;
    protected CoreDecimal YTDGUC_SEQ;
    protected CoreCharacter YTDGUC_TYPE;
    protected CoreDecimal YTDGUD_SEQ;
    protected CoreCharacter YTDGUD_TYPE;
    protected CoreDecimal STATUS_SEQ;
    protected CoreDecimal STATUS_SEQ_RPT;
    protected CoreCharacter STATUS_TYPE;
    protected CoreCharacter STATUS_GROUP;
    protected CoreDecimal ADVOUT_SEQ;
    protected CoreDecimal ADVOUT_SEQ_RPT;
    protected CoreCharacter ADVOUT_TYPE;
    protected CoreCharacter ADVOUT_GROUP;
    protected CoreDecimal ADVOUT_FACTOR;
    protected CoreDecimal TOTADV_SEQ;
    protected CoreDecimal TOTADV_SEQ_RPT;
    protected CoreCharacter TOTADV_TYPE;
    protected CoreCharacter TOTADV_GROUP;
    protected CoreDecimal TOTADV_FACTOR;
    protected CoreDecimal DEPINC_SEQ;
    protected CoreDecimal DEPINC_SEQ_RPT;
    protected CoreCharacter DEPINC_TYPE;
    protected CoreCharacter DEPINC_GROUP;
    protected CoreDecimal DEPINC_FACTOR;
    protected CoreDecimal SVCRTE_SEQ;
    protected CoreDecimal SVCRTE_SEQ_RPT;
    protected CoreCharacter SVCRTE_TYPE;
    protected CoreCharacter SVCRTE_GROUP;
    protected CoreDecimal SVCRTE_FACTOR;
    protected CoreDecimal SVCCHG_SEQ;
    protected CoreDecimal SVCCHG_SEQ_RPT;
    protected CoreCharacter SVCCHG_TYPE;
    protected CoreCharacter SVCCHG_GROUP;
    protected CoreDecimal SVCCHG_FACTOR;
    protected CoreDecimal KEYHRS_SEQ;
    protected CoreDecimal KEYHRS_SEQ_RPT;
    protected CoreCharacter KEYHRS_TYPE;
    protected CoreCharacter KEYHRS_GROUP;
    protected CoreDecimal KEYHRS_FACTOR;
    protected CoreDecimal KEYRTE_SEQ;
    protected CoreDecimal KEYRTE_SEQ_RPT;
    protected CoreCharacter KEYRTE_TYPE;
    protected CoreCharacter KEYRTE_GROUP;
    protected CoreDecimal KEYRTE_FACTOR;
    protected CoreDecimal KEYCHG_SEQ;
    protected CoreDecimal KEYCHG_SEQ_RPT;
    protected CoreCharacter KEYCHG_TYPE;
    protected CoreCharacter KEYCHG_GROUP;
    protected CoreDecimal KEYCHG_FACTOR;
    protected CoreDecimal DEPCHG_SEQ;
    protected CoreDecimal DEPCHG_SEQ_RPT;
    protected CoreCharacter DEPCHG_TYPE;
    protected CoreCharacter DEPCHG_GROUP;
    protected CoreDecimal DEPCHG_FACTOR;
    protected CoreDecimal DEPFTE_SEQ;
    protected CoreDecimal DEPFTE_SEQ_RPT;
    protected CoreCharacter DEPFTE_TYPE;
    protected CoreCharacter DEPFTE_GROUP;
    protected CoreDecimal DEPFTE_FACTOR;
    protected CoreDecimal DOCCHG_SEQ;
    protected CoreDecimal DOCCHG_SEQ_RPT;
    protected CoreCharacter DOCCHG_TYPE;
    protected CoreCharacter DOCCHG_GROUP;
    protected CoreDecimal DOCCHG_FACTOR;
    protected CoreDecimal HSTRTE_SEQ;
    protected CoreDecimal HSTRTE_SEQ_RPT;
    protected CoreCharacter HSTRTE_TYPE;
    protected CoreCharacter HSTRTE_GROUP;
    protected CoreDecimal HSTRTE_FACTOR;
    protected CoreDecimal PY7HST_SEQ;
    protected CoreDecimal PY7HST_SEQ_RPT;
    protected CoreCharacter PY7HST_TYPE;
    protected CoreCharacter PY7HST_GROUP;
    protected CoreDecimal PY7HST_FACTOR;
    protected CoreDecimal FINCHG_SEQ;
    protected CoreDecimal FINCHG_SEQ_RPT;
    protected CoreCharacter FINCHG_TYPE;
    protected CoreCharacter FINCHG_GROUP;
    protected CoreDecimal FINCHG_FACTOR;
    protected CoreDecimal DOCFTE_SEQ;
    protected CoreDecimal DOCFTE_SEQ_RPT;
    protected CoreCharacter DOCFTE_TYPE;
    protected CoreCharacter DOCFTE_GROUP;
    protected CoreDecimal DOCFTE_FACTOR;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF112_PYCDCEILINGS;
    private void FleF112_PYCDCEILINGS_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append("    ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_PAY_CODE")).Append(" =  '0'  ");


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
    private DInteger W_PAYPOT_AMT_NET = new DInteger("W_PAYPOT_AMT_NET", 10);
    private void W_PAYPOT_AMT_NET_GetValue(ref decimal Value)
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
    private SqlFileObject fleF110_OUTPUT_PAYPOT;
    private DCharacter X_REC_TYPE = new DCharacter("X_REC_TYPE", 1);
    private void X_REC_TYPE_GetValue(ref string Value)
    {

        try
        {
            Value = "A";


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
    private DInteger X_NOT_NEEDED = new DInteger("X_NOT_NEEDED", 10);
    private void X_NOT_NEEDED_GetValue(ref decimal Value)
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
    private CoreCharacter X_COMP_CODE;
    private SqlFileObject fleF119;


    #endregion


    #region "Standard Generated Procedures(U116_RUN_0_CALC_PAYCD_0_26)"


    #region "Automatic Item Initialization(U116_RUN_0_CALC_PAYCD_0_26)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:38:02 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:01 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));

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
    //# fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:02 PM
    //#-----------------------------------------
    private void fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_PAYPOT.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));

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


    #region "Transaction Management Procedures(U116_RUN_0_CALC_PAYCD_0_26)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:47 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF110_OUTPUT_PAYPOT.Transaction = m_trnTRANS_UPDATE;
        fleF119.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U116_RUN_0_CALC_PAYCD_0_26)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:48 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF112_PYCDCEILINGS.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF110_OUTPUT_PAYPOT.Dispose();
            fleF119.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_RUN_0_CALC_PAYCD_0_26)"


    public void Run()
    {

        try
        {
            Request("RUN_0_CALC_PAYCD_0_26");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF112_PYCDCEILINGS.QTPForMissing("1"))
                {
                    // --> GET F112_PYCDCEILINGS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR"));

                    fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F112_PYCDCEILINGS <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--


                        if (Transaction())
                        {
                            fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update);



                            fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                            fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_CODE", "PAYPOT");


                            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_TYPE", QDesign.NULL(PAYPOT_TYPE.Value));


                            fleF110_OUTPUT_PAYPOT.set_SetValue("PROCESS_SEQ", PAYPOT_SEQ.Value);


                            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR", 0);


                            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR_OVERRIDE", " ");


                            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_UNITS", 0);


                            fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_GROSS", 0);


                            fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_NET", W_PAYPOT_AMT_NET.Value);


                            fleF110_OUTPUT_PAYPOT.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_USER_ID", "U116 gen`d");

                            fleF110_OUTPUT_PAYPOT.OutPut(OutPutType.Add);


                            X_COMP_CODE.Value = "PAYPOT";

                            SubFile(ref m_trnTRANS_UPDATE, ref fleF119, SubFileType.Keep, SubFileMode.Append,  fleF112_PYCDCEILINGS, "DOC_NBR", X_COMP_CODE, PAYPOT_SEQ, PAYPOT_GROUP, X_REC_TYPE, X_NOT_NEEDED,
                            W_PAYPOT_AMT_NET);


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
            EndRequest("RUN_0_CALC_PAYCD_0_26");

        }

    }







    #endregion


}
//RUN_0_CALC_PAYCD_0_26



public class U116_RUN_1_CALC_PAYCD_1X_27 : U116
{

    public U116_RUN_1_CALC_PAYCD_1X_27(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ = new CoreDecimal("PAYPOT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ_RPT = new CoreDecimal("PAYPOT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_TYPE = new CoreCharacter("PAYPOT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYPOT_GROUP = new CoreCharacter("PAYPOT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEAR_SEQ = new CoreDecimal("CEIEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEAR_TYPE = new CoreCharacter("CEIEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEXP_SEQ = new CoreDecimal("CEIEXP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEXP_TYPE = new CoreCharacter("CEIEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTINC_SEQ = new CoreDecimal("TOTINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTINC_TYPE = new CoreCharacter("TOTINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEA_SEQ = new CoreDecimal("YTDCEA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEA_TYPE = new CoreCharacter("YTDCEA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEX_SEQ = new CoreDecimal("YTDCEX_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEX_TYPE = new CoreCharacter("YTDCEX_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDEAR_SEQ = new CoreDecimal("YTDEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDEAR_TYPE = new CoreCharacter("YTDEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDINC_SEQ = new CoreDecimal("YTDINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDINC_TYPE = new CoreCharacter("YTDINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUB_SEQ = new CoreDecimal("YTDGUB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUB_TYPE = new CoreCharacter("YTDGUB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUC_SEQ = new CoreDecimal("YTDGUC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUC_TYPE = new CoreCharacter("YTDGUC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUD_SEQ = new CoreDecimal("YTDGUD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUD_TYPE = new CoreCharacter("YTDGUD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_SEQ = new CoreDecimal("STATUS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        STATUS_SEQ_RPT = new CoreDecimal("STATUS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        STATUS_TYPE = new CoreCharacter("STATUS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_GROUP = new CoreCharacter("STATUS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_SEQ = new CoreDecimal("ADVOUT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_SEQ_RPT = new CoreDecimal("ADVOUT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_TYPE = new CoreCharacter("ADVOUT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_GROUP = new CoreCharacter("ADVOUT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_FACTOR = new CoreDecimal("ADVOUT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ = new CoreDecimal("TOTADV_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ_RPT = new CoreDecimal("TOTADV_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_TYPE = new CoreCharacter("TOTADV_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_GROUP = new CoreCharacter("TOTADV_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_FACTOR = new CoreDecimal("TOTADV_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ = new CoreDecimal("DEPINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ_RPT = new CoreDecimal("DEPINC_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_TYPE = new CoreCharacter("DEPINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_GROUP = new CoreCharacter("DEPINC_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_FACTOR = new CoreDecimal("DEPINC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ = new CoreDecimal("SVCRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ_RPT = new CoreDecimal("SVCRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_TYPE = new CoreCharacter("SVCRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_GROUP = new CoreCharacter("SVCRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_FACTOR = new CoreDecimal("SVCRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ = new CoreDecimal("SVCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ_RPT = new CoreDecimal("SVCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_TYPE = new CoreCharacter("SVCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_GROUP = new CoreCharacter("SVCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_FACTOR = new CoreDecimal("SVCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ = new CoreDecimal("KEYHRS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ_RPT = new CoreDecimal("KEYHRS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_TYPE = new CoreCharacter("KEYHRS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_GROUP = new CoreCharacter("KEYHRS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_FACTOR = new CoreDecimal("KEYHRS_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ = new CoreDecimal("KEYRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ_RPT = new CoreDecimal("KEYRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_TYPE = new CoreCharacter("KEYRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_GROUP = new CoreCharacter("KEYRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_FACTOR = new CoreDecimal("KEYRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ = new CoreDecimal("KEYCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ_RPT = new CoreDecimal("KEYCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_TYPE = new CoreCharacter("KEYCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_GROUP = new CoreCharacter("KEYCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_FACTOR = new CoreDecimal("KEYCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ = new CoreDecimal("DEPCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ_RPT = new CoreDecimal("DEPCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_TYPE = new CoreCharacter("DEPCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_GROUP = new CoreCharacter("DEPCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_FACTOR = new CoreDecimal("DEPCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ = new CoreDecimal("DEPFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ_RPT = new CoreDecimal("DEPFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_TYPE = new CoreCharacter("DEPFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_GROUP = new CoreCharacter("DEPFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_FACTOR = new CoreDecimal("DEPFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ = new CoreDecimal("DOCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ_RPT = new CoreDecimal("DOCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_TYPE = new CoreCharacter("DOCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_GROUP = new CoreCharacter("DOCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_FACTOR = new CoreDecimal("DOCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ = new CoreDecimal("HSTRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ_RPT = new CoreDecimal("HSTRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_TYPE = new CoreCharacter("HSTRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_GROUP = new CoreCharacter("HSTRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_FACTOR = new CoreDecimal("HSTRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ = new CoreDecimal("PY7HST_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ_RPT = new CoreDecimal("PY7HST_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_TYPE = new CoreCharacter("PY7HST_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_GROUP = new CoreCharacter("PY7HST_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_FACTOR = new CoreDecimal("PY7HST_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ = new CoreDecimal("FINCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ_RPT = new CoreDecimal("FINCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_TYPE = new CoreCharacter("FINCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_GROUP = new CoreCharacter("FINCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_FACTOR = new CoreDecimal("FINCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ = new CoreDecimal("DOCFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ_RPT = new CoreDecimal("DOCFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_TYPE = new CoreCharacter("DOCFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_GROUP = new CoreCharacter("DOCFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_FACTOR = new CoreDecimal("DOCFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_GTYPE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_GTYPE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_TOTADV = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_TOTADV", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEBUGU116CD1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU116CD1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF110_ADD_GTYPE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_ADD_GTYPE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_PAYPOT_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_PAYPOT_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_OUTPUT_UNDERAGE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_OUTPUT_UNDERAGE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "F020_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_COMP_CODE = new CoreCharacter("X_COMP_CODE", 6, this, Common.cEmptyString);
        fleF119_GTYPE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_GTYPE", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_PAYPOT = new CoreCharacter("X_COMP_CODE_PAYPOT", 6, this, Common.cEmptyString);
        fleF119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_STATUS = new CoreCharacter("X_COMP_CODE_STATUS", 6, this, Common.cEmptyString);
        fleF119_UNDER = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_UNDER", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        W_DOC_YRLY_CEIL_GUAR.GetValue += W_DOC_YRLY_CEIL_GUAR_GetValue;
        W_DOC_YRLY_CEILING.GetValue += W_DOC_YRLY_CEILING_GetValue;
        W_DOC_YRLY_CEILING_GUAR_FACTOR.GetValue += W_DOC_YRLY_CEILING_GUAR_FACTOR_GetValue;
        W_TRUE_YTDINC.GetValue += W_TRUE_YTDINC_GetValue;
        W_TRUE_YTDINC_PLUS_CEIEAR.GetValue += W_TRUE_YTDINC_PLUS_CEIEAR_GetValue;
        W_EXCESS_INCOME.GetValue += W_EXCESS_INCOME_GetValue;
        W_POT_D_YTD_PAYMENTS.GetValue += W_POT_D_YTD_PAYMENTS_GetValue;
        W_POT_D_PAYMENT.GetValue += W_POT_D_PAYMENT_GetValue;
        W_ACTUAL_D_PAYMENT.GetValue += W_ACTUAL_D_PAYMENT_GetValue;
        W_YTDCEA_MINUS_YTDEAR.GetValue += W_YTDCEA_MINUS_YTDEAR_GetValue;
        W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER.GetValue += W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER_GetValue;
        W_POT_YTDGUB.GetValue += W_POT_YTDGUB_GetValue;
        W_PAYPOT_B_2.GetValue += W_PAYPOT_B_2_GetValue;
        W_PAYPOT_AMT_GROSS.GetValue += W_PAYPOT_AMT_GROSS_GetValue;
        W_PAYPOT_AMT_NET_1.GetValue += W_PAYPOT_AMT_NET_1_GetValue;
        W_YTD_COMPUTED_CEIEAR.GetValue += W_YTD_COMPUTED_CEIEAR_GetValue;
        W_PAYPOT_YTD.GetValue += W_PAYPOT_YTD_GetValue;
        W_PAYPOT_AMT_NET_2.GetValue += W_PAYPOT_AMT_NET_2_GetValue;
        W_PAYPOT_AMT_NET_3.GetValue += W_PAYPOT_AMT_NET_3_GetValue;
        W_PAYPOT_AMT_NET_4.GetValue += W_PAYPOT_AMT_NET_4_GetValue;
        W_AMT_ADVOUT.GetValue += W_AMT_ADVOUT_GetValue;
        W_PAYPOT_AMT_NET_FINAL.GetValue += W_PAYPOT_AMT_NET_FINAL_GetValue;
        W_POTGUAR_AMT_NET.GetValue += W_POTGUAR_AMT_NET_GetValue;
        W_UNDERAGE_ACT.GetValue += W_UNDERAGE_ACT_GetValue;
        NEW_DOC_YTDEAR.GetValue += NEW_DOC_YTDEAR_GetValue;
        NEW_DOC_YTDGUA.GetValue += NEW_DOC_YTDGUA_GetValue;
        NEW_DOC_YTDGUB.GetValue += NEW_DOC_YTDGUB_GetValue;
        NEW_DOC_YTDGUC.GetValue += NEW_DOC_YTDGUC_GetValue;
        NEW_DOC_YTDGUD.GetValue += NEW_DOC_YTDGUD_GetValue;
        NEW_DOC_YTDINC.GetValue += NEW_DOC_YTDINC_GetValue;
        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        X_NOT_NEEDED.GetValue += X_NOT_NEEDED_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        W_POTGUAR_AMT_NET_REVERSE_SIGN.GetValue += W_POTGUAR_AMT_NET_REVERSE_SIGN_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF110_GTYPE.InitializeItems += fleF110_GTYPE_AutomaticItemInitialization;
        fleF110_TOTADV.InitializeItems += fleF110_TOTADV_AutomaticItemInitialization;
        fleF110_ADD_GTYPE.InitializeItems += fleF110_ADD_GTYPE_AutomaticItemInitialization;
        fleF110_PAYPOT_ADD.InitializeItems += fleF110_PAYPOT_ADD_AutomaticItemInitialization;
        fleF110_OUTPUT_UNDERAGE.InitializeItems += fleF110_OUTPUT_UNDERAGE_AutomaticItemInitialization;
        fleF020_UPDATE.InitializeItems += fleF020_UPDATE_AutomaticItemInitialization;
        fleF112_PYCDCEILINGS.SelectIf += FleF112_PYCDCEILINGS_SelectIf;
        fleF020_DOCTOR_MSTR.SetItemFinals += FleF020_DOCTOR_MSTR_SetItemFinals;
    }




    #region "Declarations (Variables, Files and Transactions)(U116_RUN_1_CALC_PAYCD_1X_27)"

    protected CoreDecimal W_CURRENT_EP_NBR;
    protected CoreDecimal W_CURRENT_EP_NBR_MINUS1;
    protected CoreDecimal PAYPOT_SEQ;
    protected CoreDecimal PAYPOT_SEQ_RPT;
    protected CoreCharacter PAYPOT_TYPE;
    protected CoreCharacter PAYPOT_GROUP;
    protected CoreDecimal CEIEAR_SEQ;
    protected CoreCharacter CEIEAR_TYPE;
    protected CoreDecimal CEIEXP_SEQ;
    protected CoreCharacter CEIEXP_TYPE;
    protected CoreDecimal TOTINC_SEQ;
    protected CoreCharacter TOTINC_TYPE;
    protected CoreDecimal YTDCEA_SEQ;
    protected CoreCharacter YTDCEA_TYPE;
    protected CoreDecimal YTDCEX_SEQ;
    protected CoreCharacter YTDCEX_TYPE;
    protected CoreDecimal YTDEAR_SEQ;
    protected CoreCharacter YTDEAR_TYPE;
    protected CoreDecimal YTDINC_SEQ;
    protected CoreCharacter YTDINC_TYPE;
    protected CoreDecimal YTDGUB_SEQ;
    protected CoreCharacter YTDGUB_TYPE;
    protected CoreDecimal YTDGUC_SEQ;
    protected CoreCharacter YTDGUC_TYPE;
    protected CoreDecimal YTDGUD_SEQ;
    protected CoreCharacter YTDGUD_TYPE;
    protected CoreDecimal STATUS_SEQ;
    protected CoreDecimal STATUS_SEQ_RPT;
    protected CoreCharacter STATUS_TYPE;
    protected CoreCharacter STATUS_GROUP;
    protected CoreDecimal ADVOUT_SEQ;
    protected CoreDecimal ADVOUT_SEQ_RPT;
    protected CoreCharacter ADVOUT_TYPE;
    protected CoreCharacter ADVOUT_GROUP;
    protected CoreDecimal ADVOUT_FACTOR;
    protected CoreDecimal TOTADV_SEQ;
    protected CoreDecimal TOTADV_SEQ_RPT;
    protected CoreCharacter TOTADV_TYPE;
    protected CoreCharacter TOTADV_GROUP;
    protected CoreDecimal TOTADV_FACTOR;
    protected CoreDecimal DEPINC_SEQ;
    protected CoreDecimal DEPINC_SEQ_RPT;
    protected CoreCharacter DEPINC_TYPE;
    protected CoreCharacter DEPINC_GROUP;
    protected CoreDecimal DEPINC_FACTOR;
    protected CoreDecimal SVCRTE_SEQ;
    protected CoreDecimal SVCRTE_SEQ_RPT;
    protected CoreCharacter SVCRTE_TYPE;
    protected CoreCharacter SVCRTE_GROUP;
    protected CoreDecimal SVCRTE_FACTOR;
    protected CoreDecimal SVCCHG_SEQ;
    protected CoreDecimal SVCCHG_SEQ_RPT;
    protected CoreCharacter SVCCHG_TYPE;
    protected CoreCharacter SVCCHG_GROUP;
    protected CoreDecimal SVCCHG_FACTOR;
    protected CoreDecimal KEYHRS_SEQ;
    protected CoreDecimal KEYHRS_SEQ_RPT;
    protected CoreCharacter KEYHRS_TYPE;
    protected CoreCharacter KEYHRS_GROUP;
    protected CoreDecimal KEYHRS_FACTOR;
    protected CoreDecimal KEYRTE_SEQ;
    protected CoreDecimal KEYRTE_SEQ_RPT;
    protected CoreCharacter KEYRTE_TYPE;
    protected CoreCharacter KEYRTE_GROUP;
    protected CoreDecimal KEYRTE_FACTOR;
    protected CoreDecimal KEYCHG_SEQ;
    protected CoreDecimal KEYCHG_SEQ_RPT;
    protected CoreCharacter KEYCHG_TYPE;
    protected CoreCharacter KEYCHG_GROUP;
    protected CoreDecimal KEYCHG_FACTOR;
    protected CoreDecimal DEPCHG_SEQ;
    protected CoreDecimal DEPCHG_SEQ_RPT;
    protected CoreCharacter DEPCHG_TYPE;
    protected CoreCharacter DEPCHG_GROUP;
    protected CoreDecimal DEPCHG_FACTOR;
    protected CoreDecimal DEPFTE_SEQ;
    protected CoreDecimal DEPFTE_SEQ_RPT;
    protected CoreCharacter DEPFTE_TYPE;
    protected CoreCharacter DEPFTE_GROUP;
    protected CoreDecimal DEPFTE_FACTOR;
    protected CoreDecimal DOCCHG_SEQ;
    protected CoreDecimal DOCCHG_SEQ_RPT;
    protected CoreCharacter DOCCHG_TYPE;
    protected CoreCharacter DOCCHG_GROUP;
    protected CoreDecimal DOCCHG_FACTOR;
    protected CoreDecimal HSTRTE_SEQ;
    protected CoreDecimal HSTRTE_SEQ_RPT;
    protected CoreCharacter HSTRTE_TYPE;
    protected CoreCharacter HSTRTE_GROUP;
    protected CoreDecimal HSTRTE_FACTOR;
    protected CoreDecimal PY7HST_SEQ;
    protected CoreDecimal PY7HST_SEQ_RPT;
    protected CoreCharacter PY7HST_TYPE;
    protected CoreCharacter PY7HST_GROUP;
    protected CoreDecimal PY7HST_FACTOR;
    protected CoreDecimal FINCHG_SEQ;
    protected CoreDecimal FINCHG_SEQ_RPT;
    protected CoreCharacter FINCHG_TYPE;
    protected CoreCharacter FINCHG_GROUP;
    protected CoreDecimal FINCHG_FACTOR;
    protected CoreDecimal DOCFTE_SEQ;
    protected CoreDecimal DOCFTE_SEQ_RPT;
    protected CoreCharacter DOCFTE_TYPE;
    protected CoreCharacter DOCFTE_GROUP;
    protected CoreDecimal DOCFTE_FACTOR;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF112_PYCDCEILINGS;
    private void FleF112_PYCDCEILINGS_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append("    ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_PAY_CODE")).Append(" =  '1'  ");


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

   

    private void FleF020_DOCTOR_MSTR_SetItemFinals()
    {
        try
        {
          
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDEAR", NEW_DOC_YTDEAR.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDGUA", NEW_DOC_YTDGUA.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDGUB", NEW_DOC_YTDGUB.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDGUC", NEW_DOC_YTDGUC.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDGUD", NEW_DOC_YTDGUD.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDINC", NEW_DOC_YTDINC.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_EP_PAY_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_EP_PAY_SUB_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));





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


    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF110_GTYPE;
    private SqlFileObject fleF110_TOTADV;
    private DInteger W_DOC_YRLY_CEIL_GUAR = new DInteger("W_DOC_YRLY_CEIL_GUAR", 10);
    private void W_DOC_YRLY_CEIL_GUAR_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEIL_GUAR") * 100;


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
    private DInteger W_DOC_YRLY_CEILING = new DInteger("W_DOC_YRLY_CEILING", 10);
    private void W_DOC_YRLY_CEILING_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING") * 100;


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
    private DDecimal W_DOC_YRLY_CEILING_GUAR_FACTOR = new DDecimal("W_DOC_YRLY_CEILING_GUAR_FACTOR", 6);
    private void W_DOC_YRLY_CEILING_GUAR_FACTOR_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_GUAR_PERC")) != 0)
            {
                CurrentValue = (fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_GUAR_PERC") / 100);
            }
            else
            {
                CurrentValue = 1;
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
    private DInteger W_TRUE_YTDINC = new DInteger("W_TRUE_YTDINC", 10);
    private void W_TRUE_YTDINC_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB")) > 0)
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC") - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB");
            }
            else if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC")) > 0)
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC") - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC");
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC") - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD");
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
    private DInteger W_TRUE_YTDINC_PLUS_CEIEAR = new DInteger("W_TRUE_YTDINC_PLUS_CEIEAR", 10);
    private void W_TRUE_YTDINC_PLUS_CEIEAR_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_TRUE_YTDINC.Value + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA");


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
    private DInteger W_EXCESS_INCOME = new DInteger("W_EXCESS_INCOME", 10);
    private void W_EXCESS_INCOME_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(W_TRUE_YTDINC.Value) > QDesign.NULL(W_DOC_YRLY_CEIL_GUAR.Value))
            {
                CurrentValue = W_TRUE_YTDINC.Value - W_DOC_YRLY_CEIL_GUAR.Value;
            }
            else
            {
                CurrentValue = 0;
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
    private DInteger W_POT_D_YTD_PAYMENTS = new DInteger("W_POT_D_YTD_PAYMENTS", 10);
    private void W_POT_D_YTD_PAYMENTS_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA") + W_EXCESS_INCOME.Value;


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
    private DInteger W_POT_D_PAYMENT = new DInteger("W_POT_D_PAYMENT", 10);
    private void W_POT_D_PAYMENT_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA") + W_EXCESS_INCOME.Value;


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
    private DInteger W_ACTUAL_D_PAYMENT = new DInteger("W_ACTUAL_D_PAYMENT", 10);
    private void W_ACTUAL_D_PAYMENT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(W_POT_D_YTD_PAYMENTS.Value) < QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA")))
            {
                CurrentValue = W_POT_D_PAYMENT.Value;
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA") - (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
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
    private DInteger W_YTDCEA_MINUS_YTDEAR = new DInteger("W_YTDCEA_MINUS_YTDEAR", 10);
    private void W_YTDCEA_MINUS_YTDEAR_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA") - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR");


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
    private DInteger W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER = new DInteger("W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER", 10);
    private void W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_YTDCEA_MINUS_YTDEAR.Value * W_DOC_YRLY_CEILING_GUAR_FACTOR.Value;


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
    private DInteger W_POT_YTDGUB = new DInteger("W_POT_YTDGUB", 10);
    private void W_POT_YTDGUB_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB") + (W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER.Value - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));


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
    private DInteger W_PAYPOT_B_2 = new DInteger("W_PAYPOT_B_2", 10);
    private void W_PAYPOT_B_2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if ((W_POT_YTDGUB.Value <= W_DOC_YRLY_CEIL_GUAR.Value) | QDesign.NULL(W_DOC_YRLY_CEIL_GUAR.Value) == 0)
            {
                CurrentValue = W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER.Value;
            }
            else
            {
                CurrentValue = W_DOC_YRLY_CEIL_GUAR.Value - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB") + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC");
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
    private DInteger W_PAYPOT_AMT_GROSS = new DInteger("W_PAYPOT_AMT_GROSS", 10);
    private void W_PAYPOT_AMT_GROSS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "C")
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA") + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC");
            }
            else if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "A")
            {
                CurrentValue = W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER.Value;
            }
            else if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "B")
            {
                CurrentValue = W_PAYPOT_B_2.Value;
            }
            else if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "D" & (W_TRUE_YTDINC_PLUS_CEIEAR.Value <= W_DOC_YRLY_CEIL_GUAR.Value))
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA");
            }
            else if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "D" & (QDesign.NULL(W_TRUE_YTDINC_PLUS_CEIEAR.Value) > QDesign.NULL(W_DOC_YRLY_CEIL_GUAR.Value)))
            {
                CurrentValue = W_ACTUAL_D_PAYMENT.Value;
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
    private DInteger W_PAYPOT_AMT_NET_1 = new DInteger("W_PAYPOT_AMT_NET_1", 10);
    private void W_PAYPOT_AMT_NET_1_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = (W_PAYPOT_AMT_GROSS.Value * fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR")) / 10000;


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
    private DInteger W_YTD_COMPUTED_CEIEAR = new DInteger("W_YTD_COMPUTED_CEIEAR", 10);
    private void W_YTD_COMPUTED_CEIEAR_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA");


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
    private DInteger W_PAYPOT_YTD = new DInteger("W_PAYPOT_YTD", 10);
    private void W_PAYPOT_YTD_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + W_PAYPOT_AMT_NET_1.Value;


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
    private DInteger W_PAYPOT_AMT_NET_2 = new DInteger("W_PAYPOT_AMT_NET_2", 10);
    private void W_PAYPOT_AMT_NET_2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(W_PAYPOT_YTD.Value) < QDesign.NULL(W_YTD_COMPUTED_CEIEAR.Value))
            {
                CurrentValue = W_PAYPOT_AMT_NET_1.Value;
            }
            else
            {
                CurrentValue = W_YTD_COMPUTED_CEIEAR.Value - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR");
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
    private DInteger W_PAYPOT_AMT_NET_3 = new DInteger("W_PAYPOT_AMT_NET_3", 10);
    private void W_PAYPOT_AMT_NET_3_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_PAYPOT_AMT_NET_2.Value;


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
    private DInteger W_PAYPOT_AMT_NET_4 = new DInteger("W_PAYPOT_AMT_NET_4", 10);
    private void W_PAYPOT_AMT_NET_4_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (fleF110_TOTADV.Exists())
            {
                CurrentValue = W_PAYPOT_AMT_NET_3.Value - fleF110_TOTADV.GetDecimalValue("AMT_NET");
            }
            else
            {
                CurrentValue = W_PAYPOT_AMT_NET_3.Value;
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
    private DInteger W_AMT_ADVOUT = new DInteger("W_AMT_ADVOUT", 10);
    private void W_AMT_ADVOUT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (W_PAYPOT_AMT_NET_4.Value >= 0)
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = Math.Abs(W_PAYPOT_AMT_NET_4.Value);
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
    private DInteger W_PAYPOT_AMT_NET_FINAL = new DInteger("W_PAYPOT_AMT_NET_FINAL", 10);
    private void W_PAYPOT_AMT_NET_FINAL_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_PAYPOT_AMT_NET_4.Value;


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
    private DInteger W_POTGUAR_AMT_NET = new DInteger("W_POTGUAR_AMT_NET", 10);
    private void W_POTGUAR_AMT_NET_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "A" | QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "B")
            {
                CurrentValue = (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + W_PAYPOT_AMT_NET_FINAL.Value) - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC");
            }
            else if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "C")
            {
                CurrentValue = W_PAYPOT_AMT_NET_FINAL.Value;
            }
            else if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "D")
            {
                CurrentValue = W_PAYPOT_AMT_GROSS.Value;
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
    private DInteger W_UNDERAGE_ACT = new DInteger("W_UNDERAGE_ACT", 10);
    private void W_UNDERAGE_ACT_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA") - (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + W_PAYPOT_AMT_NET_FINAL.Value);


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
    private DInteger NEW_DOC_YTDEAR = new DInteger("NEW_DOC_YTDEAR", 10);
    private void NEW_DOC_YTDEAR_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + W_PAYPOT_AMT_NET_FINAL.Value;


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
    private DInteger NEW_DOC_YTDGUA = new DInteger("NEW_DOC_YTDGUA", 10);
    private void NEW_DOC_YTDGUA_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "A")
            {
                CurrentValue = W_POTGUAR_AMT_NET.Value;
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA");
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
    private DInteger NEW_DOC_YTDGUB = new DInteger("NEW_DOC_YTDGUB", 10);
    private void NEW_DOC_YTDGUB_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "B")
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB") + W_POTGUAR_AMT_NET.Value;
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB");
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
    private DInteger NEW_DOC_YTDGUC = new DInteger("NEW_DOC_YTDGUC", 10);
    private void NEW_DOC_YTDGUC_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "C")
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC") + W_POTGUAR_AMT_NET.Value;
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC");
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
    private DInteger NEW_DOC_YTDGUD = new DInteger("NEW_DOC_YTDGUD", 10);
    private void NEW_DOC_YTDGUD_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "D")
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD") + W_POTGUAR_AMT_NET.Value;
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD");
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
    private DInteger NEW_DOC_YTDINC = new DInteger("NEW_DOC_YTDINC", 10);
    private void NEW_DOC_YTDINC_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "B" | QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")) == "C")
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC") + W_POTGUAR_AMT_NET.Value;
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC");
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
    private SqlFileObject fleDEBUGU116CD1;
    private SqlFileObject fleF110_ADD_GTYPE;
    private SqlFileObject fleF110_PAYPOT_ADD;
    private SqlFileObject fleF110_OUTPUT_UNDERAGE;
    private SqlFileObject fleF020_UPDATE;
    private DInteger X_NOT_NEEDED = new DInteger("X_NOT_NEEDED", 10);
    private void X_NOT_NEEDED_GetValue(ref decimal Value)
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
    private DCharacter X_REC_TYPE = new DCharacter("X_REC_TYPE", 1);
    private void X_REC_TYPE_GetValue(ref string Value)
    {

        try
        {
            Value = "A";


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
    private DInteger W_POTGUAR_AMT_NET_REVERSE_SIGN = new DInteger("W_POTGUAR_AMT_NET_REVERSE_SIGN", 10);
    private void W_POTGUAR_AMT_NET_REVERSE_SIGN_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0 - W_POTGUAR_AMT_NET.Value;


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
    private CoreCharacter X_COMP_CODE;
    private SqlFileObject fleF119_GTYPE;
    private CoreCharacter X_COMP_CODE_PAYPOT;
    private SqlFileObject fleF119;
    private CoreCharacter X_COMP_CODE_STATUS;
    private SqlFileObject fleF119_UNDER;


    #endregion


    #region "Standard Generated Procedures(U116_RUN_1_CALC_PAYCD_1X_27)"


    #region "Automatic Item Initialization(U116_RUN_1_CALC_PAYCD_1X_27)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:38:04 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:02 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));

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
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:02 PM
    //#-----------------------------------------
    private void fleF190_COMP_CODES_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF110_GTYPE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:02 PM
    //#-----------------------------------------
    private void fleF110_GTYPE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_GTYPE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_GTYPE.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_GTYPE.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_GTYPE.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_GTYPE.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_GTYPE.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_GTYPE.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF110_GTYPE.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_GTYPE.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));

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
    //# fleF110_TOTADV_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:02 PM
    //#-----------------------------------------
    private void fleF110_TOTADV_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_TOTADV.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_TOTADV.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_TOTADV.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_TOTADV.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF110_TOTADV.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_TOTADV.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            //TODO: Manual steps may be required.
            fleF110_TOTADV.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_GTYPE.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_TOTADV.set_SetValue("COMP_UNITS", !Fixed, fleF110_GTYPE.GetDecimalValue("COMP_UNITS"));
            fleF110_TOTADV.set_SetValue("AMT_GROSS", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_GROSS"));
            fleF110_TOTADV.set_SetValue("AMT_NET", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_NET"));
            fleF110_TOTADV.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_GTYPE.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_TOTADV.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_GTYPE.GetStringValue("COMPENSATION_STATUS"));
            fleF110_TOTADV.set_SetValue("FILLER", !Fixed, fleF110_GTYPE.GetStringValue("FILLER"));

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
    //# fleF110_ADD_GTYPE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:02 PM
    //#-----------------------------------------
    private void fleF110_ADD_GTYPE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_ADD_GTYPE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_ADD_GTYPE.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_ADD_GTYPE.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_ADD_GTYPE.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF110_ADD_GTYPE.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_ADD_GTYPE.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            //TODO: Manual steps may be required.
            fleF110_ADD_GTYPE.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_GTYPE.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_ADD_GTYPE.set_SetValue("COMP_UNITS", !Fixed, fleF110_GTYPE.GetDecimalValue("COMP_UNITS"));
            fleF110_ADD_GTYPE.set_SetValue("AMT_GROSS", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_GROSS"));
            fleF110_ADD_GTYPE.set_SetValue("AMT_NET", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_NET"));
            fleF110_ADD_GTYPE.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_GTYPE.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_ADD_GTYPE.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_GTYPE.GetStringValue("COMPENSATION_STATUS"));
            fleF110_ADD_GTYPE.set_SetValue("FILLER", !Fixed, fleF110_GTYPE.GetStringValue("FILLER"));

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
    //# fleF110_PAYPOT_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:02 PM
    //#-----------------------------------------
    private void fleF110_PAYPOT_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_PAYPOT_ADD.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_PAYPOT_ADD.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_PAYPOT_ADD.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_PAYPOT_ADD.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_PAYPOT_ADD.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_PAYPOT_ADD.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_PAYPOT_ADD.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF110_PAYPOT_ADD.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_PAYPOT_ADD.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            //TODO: Manual steps may be required.
            fleF110_PAYPOT_ADD.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_GTYPE.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_PAYPOT_ADD.set_SetValue("COMP_UNITS", !Fixed, fleF110_GTYPE.GetDecimalValue("COMP_UNITS"));
            fleF110_PAYPOT_ADD.set_SetValue("AMT_GROSS", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_GROSS"));
            fleF110_PAYPOT_ADD.set_SetValue("AMT_NET", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_NET"));
            fleF110_PAYPOT_ADD.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_GTYPE.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_PAYPOT_ADD.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_GTYPE.GetStringValue("COMPENSATION_STATUS"));
            fleF110_PAYPOT_ADD.set_SetValue("FILLER", !Fixed, fleF110_GTYPE.GetStringValue("FILLER"));

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
    //# fleF110_OUTPUT_UNDERAGE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:02 PM
    //#-----------------------------------------
    private void fleF110_OUTPUT_UNDERAGE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_UNDERAGE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_UNDERAGE.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_GTYPE.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_UNITS", !Fixed, fleF110_GTYPE.GetDecimalValue("COMP_UNITS"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("AMT_GROSS", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_GROSS"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("AMT_NET", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_NET"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_GTYPE.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_GTYPE.GetStringValue("COMPENSATION_STATUS"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("FILLER", !Fixed, fleF110_GTYPE.GetStringValue("FILLER"));

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
    //# fleF020_UPDATE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:04 PM
    //#-----------------------------------------
    private void fleF020_UPDATE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleF020_UPDATE.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_123", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_456", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_789", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleF020_UPDATE.set_SetValue("DOC_HOSP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_HOSP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleF020_UPDATE.set_SetValue("DOC_NAME_SOUNDEX", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME_SOUNDEX"));
            fleF020_UPDATE.set_SetValue("DOC_INIT1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1"));
            fleF020_UPDATE.set_SetValue("DOC_INIT2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2"));
            fleF020_UPDATE.set_SetValue("DOC_INIT3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_BRANCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_ACCT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUB", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEAR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_EP_DATE_DEPOSIT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
            fleF020_UPDATE.set_SetValue("DOC_EP_CEIEXP", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
            fleF020_UPDATE.set_SetValue("CEICEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("CEICEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_2"));
            fleF020_UPDATE.set_SetValue("DOC_IND_PAYS_GST", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_5", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6"));
            fleF020_UPDATE.set_SetValue("DOC_SUB_SPECIALTY", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY"));
            fleF020_UPDATE.set_SetValue("DOC_PAYEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
            fleF020_UPDATE.set_SetValue("DOC_YTDDED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_SUB_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_PARTNERSHIP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_PARTNERSHIP"));
            fleF020_UPDATE.set_SetValue("DOC_IND_HOLDBACK_ACTIVE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE"));
            fleF020_UPDATE.set_SetValue("GROUP_REGULAR_SERVICE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE"));
            fleF020_UPDATE.set_SetValue("GROUP_OVER_SERVICED", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3"));

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


    #region "Transaction Management Procedures(U116_RUN_1_CALC_PAYCD_1X_27)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:53 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF110_GTYPE.Transaction = m_trnTRANS_UPDATE;
        fleF110_TOTADV.Transaction = m_trnTRANS_UPDATE;
        fleDEBUGU116CD1.Transaction = m_trnTRANS_UPDATE;
        fleF110_ADD_GTYPE.Transaction = m_trnTRANS_UPDATE;
        fleF110_PAYPOT_ADD.Transaction = m_trnTRANS_UPDATE;
        fleF110_OUTPUT_UNDERAGE.Transaction = m_trnTRANS_UPDATE;
        fleF020_UPDATE.Transaction = m_trnTRANS_UPDATE;
        fleF119_GTYPE.Transaction = m_trnTRANS_UPDATE;
        fleF119.Transaction = m_trnTRANS_UPDATE;
        fleF119_UNDER.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U116_RUN_1_CALC_PAYCD_1X_27)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:53 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF112_PYCDCEILINGS.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF110_GTYPE.Dispose();
            fleF110_TOTADV.Dispose();
            fleDEBUGU116CD1.Dispose();
            fleF110_ADD_GTYPE.Dispose();
            fleF110_PAYPOT_ADD.Dispose();
            fleF110_OUTPUT_UNDERAGE.Dispose();
            fleF020_UPDATE.Dispose();
            fleF119_GTYPE.Dispose();
            fleF119.Dispose();
            fleF119_UNDER.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_RUN_1_CALC_PAYCD_1X_27)"


    public void Run()
    {

        try
        {
            Request("RUN_1_CALC_PAYCD_1X_27");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF112_PYCDCEILINGS.QTPForMissing("1"))
                {
                    // --> GET F112_PYCDCEILINGS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR"));

                    fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F112_PYCDCEILINGS <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF190_COMP_CODES.QTPForMissing("3"))
                        {
                            // --> GET F190_COMP_CODES <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("GTYPE" + fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")));

                            fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F190_COMP_CODES <--

                            while (fleF110_GTYPE.QTPForMissing("4"))
                            {
                                // --> GET F110_GTYPE <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF110_GTYPE.ElementOwner("EP_NBR")).Append(" = ");
                                m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                                m_strWhere.Append(" And ").Append(fleF110_GTYPE.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                m_strWhere.Append(" And ").Append(fleF110_GTYPE.ElementOwner("COMP_CODE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField("GTYPE" + fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")));
                                m_strWhere.Append(" And ").Append(fleF110_GTYPE.ElementOwner("PROCESS_SEQ")).Append(" = ");
                                m_strWhere.Append((fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ")));

                                fleF110_GTYPE.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F110_GTYPE <--

                                while (fleF110_TOTADV.QTPForMissing("5"))
                                {
                                    // --> GET F110_TOTADV <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF110_TOTADV.ElementOwner("EP_NBR")).Append(" = ");
                                    m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                                    m_strWhere.Append(" And ").Append(fleF110_TOTADV.ElementOwner("DOC_NBR")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                    m_strWhere.Append(" And ").Append(fleF110_TOTADV.ElementOwner("COMP_CODE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField("ADVOUT"));
                                    m_strWhere.Append(" And ").Append(fleF110_TOTADV.ElementOwner("PROCESS_SEQ")).Append(" = ");
                                    m_strWhere.Append((TOTADV_SEQ.Value));

                                    fleF110_TOTADV.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F110_TOTADV <--


                                    if (Transaction())
                                    {

                                        Sort(fleF112_PYCDCEILINGS.GetSortValue("DOC_NBR"));



                                    }

                                }

                            }

                        }

                    }

                }

            }

            while (Sort(fleCONSTANTS_MSTR_REC_6, fleF112_PYCDCEILINGS, fleF020_DOCTOR_MSTR, fleF190_COMP_CODES, fleF110_GTYPE, fleF110_TOTADV))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU116CD1, SubFileType.Keep, fleF112_PYCDCEILINGS, "EP_NBR", "DOC_NBR", "DOC_PAY_CODE", "DOC_PAY_SUB_CODE", "FACTOR", fleF020_DOCTOR_MSTR,
                "DOC_YTDEAR", "DOC_YTDINC", "DOC_YTDCEA", "DOC_YTDGUA", "DOC_YTDGUB", "DOC_YTDGUC", "DOC_YTDGUD", NEW_DOC_YTDEAR, NEW_DOC_YTDGUA, NEW_DOC_YTDGUB,
                NEW_DOC_YTDGUC, NEW_DOC_YTDGUD, NEW_DOC_YTDINC, fleF110_TOTADV, "AMT_NET", W_ACTUAL_D_PAYMENT, W_DOC_YRLY_CEIL_GUAR, W_DOC_YRLY_CEILING, W_DOC_YRLY_CEILING_GUAR_FACTOR, W_EXCESS_INCOME,
                W_PAYPOT_AMT_GROSS, W_PAYPOT_AMT_NET_1, W_PAYPOT_AMT_NET_2, W_PAYPOT_AMT_NET_3, W_PAYPOT_AMT_NET_4, W_PAYPOT_AMT_NET_FINAL, W_AMT_ADVOUT, W_PAYPOT_B_2, W_POTGUAR_AMT_NET, W_POT_D_PAYMENT,
                W_POT_D_YTD_PAYMENTS, W_POT_YTDGUB, W_TRUE_YTDINC, W_TRUE_YTDINC_PLUS_CEIEAR, W_YTDCEA_MINUS_YTDEAR, W_YTDCEA_MINUS_YTDEAR_X_GUAR_PER, W_YTD_COMPUTED_CEIEAR, W_PAYPOT_YTD, W_UNDERAGE_ACT);


                fleF110_GTYPE.set_SetValue("COMP_UNITS", 0);


                fleF110_GTYPE.set_SetValue("AMT_GROSS", 0);


                fleF110_GTYPE.set_SetValue("AMT_NET", W_POTGUAR_AMT_NET.Value);


                fleF110_GTYPE.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                fleF110_GTYPE.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_GTYPE.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_GTYPE.set_SetValue("LAST_MOD_USER_ID", "U116 gen`d");

                fleF110_GTYPE.OutPut(OutPutType.Update, null, fleF110_GTYPE.Exists());



                fleF110_ADD_GTYPE.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                fleF110_ADD_GTYPE.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                fleF110_ADD_GTYPE.set_SetValue("COMP_CODE", fleF190_COMP_CODES.GetStringValue("COMP_CODE"));


                fleF110_ADD_GTYPE.set_SetValue("COMP_TYPE", fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));


                fleF110_ADD_GTYPE.set_SetValue("PROCESS_SEQ", fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));


                fleF110_ADD_GTYPE.set_SetValue("FACTOR", fleF110_GTYPE.GetDecimalValue("FACTOR"));


                fleF110_ADD_GTYPE.set_SetValue("FACTOR_OVERRIDE", fleF110_GTYPE.GetStringValue("FACTOR_OVERRIDE"));


                fleF110_ADD_GTYPE.set_SetValue("COMP_UNITS", 0);


                fleF110_ADD_GTYPE.set_SetValue("AMT_GROSS", 0);


                fleF110_ADD_GTYPE.set_SetValue("AMT_NET", W_POTGUAR_AMT_NET.Value);


                fleF110_ADD_GTYPE.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_USER_ID", "U116 gen`d");

                fleF110_ADD_GTYPE.OutPut(OutPutType.Add, null, !fleF110_GTYPE.Exists());



                fleF110_PAYPOT_ADD.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                fleF110_PAYPOT_ADD.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                fleF110_PAYPOT_ADD.set_SetValue("COMP_CODE", "PAYPOT");


                fleF110_PAYPOT_ADD.set_SetValue("COMP_TYPE", QDesign.NULL(PAYPOT_TYPE.Value));


                fleF110_PAYPOT_ADD.set_SetValue("PROCESS_SEQ", PAYPOT_SEQ.Value);


                fleF110_PAYPOT_ADD.set_SetValue("FACTOR", fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));

                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR")) != 10000)
                {
                    fleF110_PAYPOT_ADD.set_SetValue("FACTOR_OVERRIDE", "*");

                }
                else
                {
                    fleF110_PAYPOT_ADD.set_SetValue("FACTOR_OVERRIDE", " ");

                }


                fleF110_PAYPOT_ADD.set_SetValue("COMP_UNITS", 0);


                fleF110_PAYPOT_ADD.set_SetValue("AMT_GROSS", W_DOC_YRLY_CEILING.Value);


                fleF110_PAYPOT_ADD.set_SetValue("AMT_NET", W_PAYPOT_AMT_NET_FINAL.Value);


                fleF110_PAYPOT_ADD.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                fleF110_PAYPOT_ADD.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_PAYPOT_ADD.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_PAYPOT_ADD.set_SetValue("LAST_MOD_USER_ID", "U116 gen`d");

                fleF110_PAYPOT_ADD.OutPut(OutPutType.Add);



                fleF110_OUTPUT_UNDERAGE.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                fleF110_OUTPUT_UNDERAGE.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_CODE", "STATUS");


                fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_TYPE", QDesign.NULL(STATUS_TYPE.Value));


                fleF110_OUTPUT_UNDERAGE.set_SetValue("PROCESS_SEQ", STATUS_SEQ.Value);


                fleF110_OUTPUT_UNDERAGE.set_SetValue("FACTOR", 0);


                fleF110_OUTPUT_UNDERAGE.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_UNITS", 0);


                fleF110_OUTPUT_UNDERAGE.set_SetValue("AMT_GROSS", 0);


                fleF110_OUTPUT_UNDERAGE.set_SetValue("AMT_NET", W_UNDERAGE_ACT.Value);


                fleF110_OUTPUT_UNDERAGE.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_USER_ID", "U116 gen`d");

                fleF110_OUTPUT_UNDERAGE.OutPut(OutPutType.Add);


                fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update, fleF112_PYCDCEILINGS.At("DOC_NBR"), null);


                X_COMP_CODE.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE");

                SubFile(ref m_trnTRANS_UPDATE,ref fleF119_GTYPE, fleF112_PYCDCEILINGS.At("DOC_NBR"), QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "I" | QDesign.NULL(QDesign.Substring(fleF190_COMP_CODES.GetStringValue("COMP_CODE"), 1, 5)) == "GTYPE", SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS, "DOC_NBR", X_COMP_CODE, fleF190_COMP_CODES, "REPORTING_SEQ",
                "COMP_CODE_GROUP", X_REC_TYPE, X_NOT_NEEDED, W_POTGUAR_AMT_NET_REVERSE_SIGN);

                X_COMP_CODE_PAYPOT.Value = "PAYPOT";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119, fleF112_PYCDCEILINGS.At("DOC_NBR"), SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS, "DOC_NBR", X_COMP_CODE_PAYPOT, PAYPOT_SEQ_RPT, PAYPOT_GROUP, X_REC_TYPE,
                NEW_DOC_YTDEAR, W_PAYPOT_AMT_NET_FINAL);

                X_COMP_CODE_STATUS.Value = "STATUS";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_UNDER, fleF112_PYCDCEILINGS.At("DOC_NBR"), SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS, "DOC_NBR", X_COMP_CODE_STATUS, STATUS_SEQ_RPT, STATUS_GROUP, X_REC_TYPE,
                X_NOT_NEEDED, W_UNDERAGE_ACT);


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
            EndRequest("RUN_1_CALC_PAYCD_1X_27");

        }

    }







    #endregion


}
//RUN_1_CALC_PAYCD_1X_27



public class U116_RUN_2_CALC_PAYCD_2_28 : U116
{

    public U116_RUN_2_CALC_PAYCD_2_28(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ = new CoreDecimal("PAYPOT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ_RPT = new CoreDecimal("PAYPOT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_TYPE = new CoreCharacter("PAYPOT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYPOT_GROUP = new CoreCharacter("PAYPOT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEAR_SEQ = new CoreDecimal("CEIEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEAR_TYPE = new CoreCharacter("CEIEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEXP_SEQ = new CoreDecimal("CEIEXP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEXP_TYPE = new CoreCharacter("CEIEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTINC_SEQ = new CoreDecimal("TOTINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTINC_TYPE = new CoreCharacter("TOTINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEA_SEQ = new CoreDecimal("YTDCEA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEA_TYPE = new CoreCharacter("YTDCEA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEX_SEQ = new CoreDecimal("YTDCEX_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEX_TYPE = new CoreCharacter("YTDCEX_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDEAR_SEQ = new CoreDecimal("YTDEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDEAR_TYPE = new CoreCharacter("YTDEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDINC_SEQ = new CoreDecimal("YTDINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDINC_TYPE = new CoreCharacter("YTDINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUB_SEQ = new CoreDecimal("YTDGUB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUB_TYPE = new CoreCharacter("YTDGUB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUC_SEQ = new CoreDecimal("YTDGUC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUC_TYPE = new CoreCharacter("YTDGUC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUD_SEQ = new CoreDecimal("YTDGUD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUD_TYPE = new CoreCharacter("YTDGUD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_SEQ = new CoreDecimal("STATUS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        STATUS_SEQ_RPT = new CoreDecimal("STATUS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        STATUS_TYPE = new CoreCharacter("STATUS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_GROUP = new CoreCharacter("STATUS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_SEQ = new CoreDecimal("ADVOUT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_SEQ_RPT = new CoreDecimal("ADVOUT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_TYPE = new CoreCharacter("ADVOUT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_GROUP = new CoreCharacter("ADVOUT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_FACTOR = new CoreDecimal("ADVOUT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ = new CoreDecimal("TOTADV_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ_RPT = new CoreDecimal("TOTADV_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_TYPE = new CoreCharacter("TOTADV_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_GROUP = new CoreCharacter("TOTADV_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_FACTOR = new CoreDecimal("TOTADV_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ = new CoreDecimal("DEPINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ_RPT = new CoreDecimal("DEPINC_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_TYPE = new CoreCharacter("DEPINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_GROUP = new CoreCharacter("DEPINC_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_FACTOR = new CoreDecimal("DEPINC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ = new CoreDecimal("SVCRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ_RPT = new CoreDecimal("SVCRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_TYPE = new CoreCharacter("SVCRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_GROUP = new CoreCharacter("SVCRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_FACTOR = new CoreDecimal("SVCRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ = new CoreDecimal("SVCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ_RPT = new CoreDecimal("SVCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_TYPE = new CoreCharacter("SVCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_GROUP = new CoreCharacter("SVCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_FACTOR = new CoreDecimal("SVCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ = new CoreDecimal("KEYHRS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ_RPT = new CoreDecimal("KEYHRS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_TYPE = new CoreCharacter("KEYHRS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_GROUP = new CoreCharacter("KEYHRS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_FACTOR = new CoreDecimal("KEYHRS_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ = new CoreDecimal("KEYRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ_RPT = new CoreDecimal("KEYRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_TYPE = new CoreCharacter("KEYRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_GROUP = new CoreCharacter("KEYRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_FACTOR = new CoreDecimal("KEYRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ = new CoreDecimal("KEYCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ_RPT = new CoreDecimal("KEYCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_TYPE = new CoreCharacter("KEYCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_GROUP = new CoreCharacter("KEYCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_FACTOR = new CoreDecimal("KEYCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ = new CoreDecimal("DEPCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ_RPT = new CoreDecimal("DEPCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_TYPE = new CoreCharacter("DEPCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_GROUP = new CoreCharacter("DEPCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_FACTOR = new CoreDecimal("DEPCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ = new CoreDecimal("DEPFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ_RPT = new CoreDecimal("DEPFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_TYPE = new CoreCharacter("DEPFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_GROUP = new CoreCharacter("DEPFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_FACTOR = new CoreDecimal("DEPFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ = new CoreDecimal("DOCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ_RPT = new CoreDecimal("DOCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_TYPE = new CoreCharacter("DOCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_GROUP = new CoreCharacter("DOCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_FACTOR = new CoreDecimal("DOCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ = new CoreDecimal("HSTRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ_RPT = new CoreDecimal("HSTRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_TYPE = new CoreCharacter("HSTRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_GROUP = new CoreCharacter("HSTRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_FACTOR = new CoreDecimal("HSTRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ = new CoreDecimal("PY7HST_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ_RPT = new CoreDecimal("PY7HST_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_TYPE = new CoreCharacter("PY7HST_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_GROUP = new CoreCharacter("PY7HST_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_FACTOR = new CoreDecimal("PY7HST_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ = new CoreDecimal("FINCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ_RPT = new CoreDecimal("FINCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_TYPE = new CoreCharacter("FINCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_GROUP = new CoreCharacter("FINCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_FACTOR = new CoreDecimal("FINCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ = new CoreDecimal("DOCFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ_RPT = new CoreDecimal("DOCFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_TYPE = new CoreCharacter("DOCFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_GROUP = new CoreCharacter("DOCFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_FACTOR = new CoreDecimal("DOCFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_YTDINC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_YTDINC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_YTDEAR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_YTDEAR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_TOTADV = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_TOTADV", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEBUGU116CD2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU116CD2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF110_OUTPUT_PAYPOT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_OUTPUT_PAYPOT", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "F020_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        W_AMT_NET_F110_YTDINC.GetValue += W_AMT_NET_F110_YTDINC_GetValue;
        W_AMT_NET_F110_YTDEAR.GetValue += W_AMT_NET_F110_YTDEAR_GetValue;
        W_AMT_NET_F110_TOTADV.GetValue += W_AMT_NET_F110_TOTADV_GetValue;
        W_PAYPOT_AMT_NET_2.GetValue += W_PAYPOT_AMT_NET_2_GetValue;
        W_PAYPOT_AMT_NET_3.GetValue += W_PAYPOT_AMT_NET_3_GetValue;
        TOTADV_FLAG.GetValue += TOTADV_FLAG_GetValue;
        W_PAYPOT_AMT_NET_4.GetValue += W_PAYPOT_AMT_NET_4_GetValue;
        W_AMT_ADVOUT.GetValue += W_AMT_ADVOUT_GetValue;
        W_PAYPOT_AMT_NET.GetValue += W_PAYPOT_AMT_NET_GetValue;
        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        NEW_DOC_YTDEAR.GetValue += NEW_DOC_YTDEAR_GetValue;
        X_NOT_NEEDED.GetValue += X_NOT_NEEDED_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        X_COMP_CODE.GetValue += X_COMP_CODE_GetValue;
        fleF110_YTDINC.InitializeItems += fleF110_YTDINC_AutomaticItemInitialization;
        fleF110_YTDEAR.InitializeItems += fleF110_YTDEAR_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF110_TOTADV.InitializeItems += fleF110_TOTADV_AutomaticItemInitialization;
        fleF110_OUTPUT_PAYPOT.InitializeItems += fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization;
        fleF020_UPDATE.InitializeItems += fleF020_UPDATE_AutomaticItemInitialization;
        fleF112_PYCDCEILINGS.SelectIf += FleF112_PYCDCEILINGS_SelectIf;
        fleF020_DOCTOR_MSTR.SetItemFinals += FleF020_DOCTOR_MSTR_SetItemFinals;
    }







    #region "Declarations (Variables, Files and Transactions)(U116_RUN_2_CALC_PAYCD_2_28)"

    protected CoreDecimal W_CURRENT_EP_NBR;
    protected CoreDecimal W_CURRENT_EP_NBR_MINUS1;
    protected CoreDecimal PAYPOT_SEQ;
    protected CoreDecimal PAYPOT_SEQ_RPT;
    protected CoreCharacter PAYPOT_TYPE;
    protected CoreCharacter PAYPOT_GROUP;
    protected CoreDecimal CEIEAR_SEQ;
    protected CoreCharacter CEIEAR_TYPE;
    protected CoreDecimal CEIEXP_SEQ;
    protected CoreCharacter CEIEXP_TYPE;
    protected CoreDecimal TOTINC_SEQ;
    protected CoreCharacter TOTINC_TYPE;
    protected CoreDecimal YTDCEA_SEQ;
    protected CoreCharacter YTDCEA_TYPE;
    protected CoreDecimal YTDCEX_SEQ;
    protected CoreCharacter YTDCEX_TYPE;
    protected CoreDecimal YTDEAR_SEQ;
    protected CoreCharacter YTDEAR_TYPE;
    protected CoreDecimal YTDINC_SEQ;
    protected CoreCharacter YTDINC_TYPE;
    protected CoreDecimal YTDGUB_SEQ;
    protected CoreCharacter YTDGUB_TYPE;
    protected CoreDecimal YTDGUC_SEQ;
    protected CoreCharacter YTDGUC_TYPE;
    protected CoreDecimal YTDGUD_SEQ;
    protected CoreCharacter YTDGUD_TYPE;
    protected CoreDecimal STATUS_SEQ;
    protected CoreDecimal STATUS_SEQ_RPT;
    protected CoreCharacter STATUS_TYPE;
    protected CoreCharacter STATUS_GROUP;
    protected CoreDecimal ADVOUT_SEQ;
    protected CoreDecimal ADVOUT_SEQ_RPT;
    protected CoreCharacter ADVOUT_TYPE;
    protected CoreCharacter ADVOUT_GROUP;
    protected CoreDecimal ADVOUT_FACTOR;
    protected CoreDecimal TOTADV_SEQ;
    protected CoreDecimal TOTADV_SEQ_RPT;
    protected CoreCharacter TOTADV_TYPE;
    protected CoreCharacter TOTADV_GROUP;
    protected CoreDecimal TOTADV_FACTOR;
    protected CoreDecimal DEPINC_SEQ;
    protected CoreDecimal DEPINC_SEQ_RPT;
    protected CoreCharacter DEPINC_TYPE;
    protected CoreCharacter DEPINC_GROUP;
    protected CoreDecimal DEPINC_FACTOR;
    protected CoreDecimal SVCRTE_SEQ;
    protected CoreDecimal SVCRTE_SEQ_RPT;
    protected CoreCharacter SVCRTE_TYPE;
    protected CoreCharacter SVCRTE_GROUP;
    protected CoreDecimal SVCRTE_FACTOR;
    protected CoreDecimal SVCCHG_SEQ;
    protected CoreDecimal SVCCHG_SEQ_RPT;
    protected CoreCharacter SVCCHG_TYPE;
    protected CoreCharacter SVCCHG_GROUP;
    protected CoreDecimal SVCCHG_FACTOR;
    protected CoreDecimal KEYHRS_SEQ;
    protected CoreDecimal KEYHRS_SEQ_RPT;
    protected CoreCharacter KEYHRS_TYPE;
    protected CoreCharacter KEYHRS_GROUP;
    protected CoreDecimal KEYHRS_FACTOR;
    protected CoreDecimal KEYRTE_SEQ;
    protected CoreDecimal KEYRTE_SEQ_RPT;
    protected CoreCharacter KEYRTE_TYPE;
    protected CoreCharacter KEYRTE_GROUP;
    protected CoreDecimal KEYRTE_FACTOR;
    protected CoreDecimal KEYCHG_SEQ;
    protected CoreDecimal KEYCHG_SEQ_RPT;
    protected CoreCharacter KEYCHG_TYPE;
    protected CoreCharacter KEYCHG_GROUP;
    protected CoreDecimal KEYCHG_FACTOR;
    protected CoreDecimal DEPCHG_SEQ;
    protected CoreDecimal DEPCHG_SEQ_RPT;
    protected CoreCharacter DEPCHG_TYPE;
    protected CoreCharacter DEPCHG_GROUP;
    protected CoreDecimal DEPCHG_FACTOR;
    protected CoreDecimal DEPFTE_SEQ;
    protected CoreDecimal DEPFTE_SEQ_RPT;
    protected CoreCharacter DEPFTE_TYPE;
    protected CoreCharacter DEPFTE_GROUP;
    protected CoreDecimal DEPFTE_FACTOR;
    protected CoreDecimal DOCCHG_SEQ;
    protected CoreDecimal DOCCHG_SEQ_RPT;
    protected CoreCharacter DOCCHG_TYPE;
    protected CoreCharacter DOCCHG_GROUP;
    protected CoreDecimal DOCCHG_FACTOR;
    protected CoreDecimal HSTRTE_SEQ;
    protected CoreDecimal HSTRTE_SEQ_RPT;
    protected CoreCharacter HSTRTE_TYPE;
    protected CoreCharacter HSTRTE_GROUP;
    protected CoreDecimal HSTRTE_FACTOR;
    protected CoreDecimal PY7HST_SEQ;
    protected CoreDecimal PY7HST_SEQ_RPT;
    protected CoreCharacter PY7HST_TYPE;
    protected CoreCharacter PY7HST_GROUP;
    protected CoreDecimal PY7HST_FACTOR;
    protected CoreDecimal FINCHG_SEQ;
    protected CoreDecimal FINCHG_SEQ_RPT;
    protected CoreCharacter FINCHG_TYPE;
    protected CoreCharacter FINCHG_GROUP;
    protected CoreDecimal FINCHG_FACTOR;
    protected CoreDecimal DOCFTE_SEQ;
    protected CoreDecimal DOCFTE_SEQ_RPT;
    protected CoreCharacter DOCFTE_TYPE;
    protected CoreCharacter DOCFTE_GROUP;
    protected CoreDecimal DOCFTE_FACTOR;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF112_PYCDCEILINGS;
    private void FleF112_PYCDCEILINGS_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append("    ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_PAY_CODE")).Append(" =  '2'  ");


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
    private SqlFileObject fleF110_YTDINC;
    private SqlFileObject fleF110_YTDEAR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private void FleF020_DOCTOR_MSTR_SetItemFinals()
    {
        try
        {
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDEAR", NEW_DOC_YTDEAR.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_EP_PAY_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_EP_PAY_SUB_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));
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

    private SqlFileObject fleF110_TOTADV;
    private DDecimal W_AMT_NET_F110_YTDINC = new DDecimal("W_AMT_NET_F110_YTDINC", 10);
    private void W_AMT_NET_F110_YTDINC_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (fleF110_YTDINC.Exists())
            {
                CurrentValue = fleF110_YTDINC.GetDecimalValue("AMT_NET");
            }
            else
            {
                CurrentValue = 0;
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
    private DDecimal W_AMT_NET_F110_YTDEAR = new DDecimal("W_AMT_NET_F110_YTDEAR", 10);
    private void W_AMT_NET_F110_YTDEAR_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (fleF110_YTDEAR.Exists())
            {
                CurrentValue = fleF110_YTDEAR.GetDecimalValue("AMT_NET");
            }
            else
            {
                CurrentValue = 0;
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
    private DDecimal W_AMT_NET_F110_TOTADV = new DDecimal("W_AMT_NET_F110_TOTADV", 10);
    private void W_AMT_NET_F110_TOTADV_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (fleF110_TOTADV.Exists())
            {
                CurrentValue = fleF110_TOTADV.GetDecimalValue("AMT_NET");
            }
            else
            {
                CurrentValue = 0;
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
    private DInteger W_PAYPOT_AMT_NET_2 = new DInteger("W_PAYPOT_AMT_NET_2", 10);
    private void W_PAYPOT_AMT_NET_2_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = ((W_AMT_NET_F110_YTDINC.Value - W_AMT_NET_F110_YTDEAR.Value) * fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR")) / 10000;


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
    private DInteger W_PAYPOT_AMT_NET_3 = new DInteger("W_PAYPOT_AMT_NET_3", 10);
    private void W_PAYPOT_AMT_NET_3_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_PAYPOT_AMT_NET_2.Value;


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
    private DCharacter TOTADV_FLAG = new DCharacter("TOTADV_FLAG", 1);
    private void TOTADV_FLAG_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (fleF110_TOTADV.Exists())
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "N";
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
    private DInteger W_PAYPOT_AMT_NET_4 = new DInteger("W_PAYPOT_AMT_NET_4", 10);
    private void W_PAYPOT_AMT_NET_4_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (fleF110_TOTADV.Exists())
            {
                CurrentValue = W_PAYPOT_AMT_NET_3.Value - W_AMT_NET_F110_TOTADV.Value;
            }
            else
            {
                CurrentValue = W_PAYPOT_AMT_NET_3.Value;
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
    private DInteger W_AMT_ADVOUT = new DInteger("W_AMT_ADVOUT", 10);
    private void W_AMT_ADVOUT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (W_PAYPOT_AMT_NET_4.Value >= 0)
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = Math.Abs(W_PAYPOT_AMT_NET_4.Value);
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
    private DInteger W_PAYPOT_AMT_NET = new DInteger("W_PAYPOT_AMT_NET", 10);
    private void W_PAYPOT_AMT_NET_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_PAYPOT_AMT_NET_4.Value;


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
    private SqlFileObject fleDEBUGU116CD2;
    private SqlFileObject fleF110_OUTPUT_PAYPOT;
    private DInteger NEW_DOC_YTDEAR = new DInteger("NEW_DOC_YTDEAR", 10);
    private void NEW_DOC_YTDEAR_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + W_PAYPOT_AMT_NET.Value;


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
    private SqlFileObject fleF020_UPDATE;
    private DInteger X_NOT_NEEDED = new DInteger("X_NOT_NEEDED", 10);
    private void X_NOT_NEEDED_GetValue(ref decimal Value)
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
    private DCharacter X_REC_TYPE = new DCharacter("X_REC_TYPE", 1);
    private void X_REC_TYPE_GetValue(ref string Value)
    {

        try
        {
            Value = "A";


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
    private DCharacter X_COMP_CODE = new DCharacter("X_COMP_CODE", 6);
    private void X_COMP_CODE_GetValue(ref string Value)
    {

        try
        {
            Value = "PAYPOT";


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
    private SqlFileObject fleF119;


    #endregion


    #region "Standard Generated Procedures(U116_RUN_2_CALC_PAYCD_2_28)"


    #region "Automatic Item Initialization(U116_RUN_2_CALC_PAYCD_2_28)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:38:04 PM

    //#-----------------------------------------
    //# fleF110_YTDINC_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:04 PM
    //#-----------------------------------------
    private void fleF110_YTDINC_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_YTDINC.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_YTDINC.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_YTDINC.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_YTDINC.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_YTDINC.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_YTDINC.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF110_YTDEAR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:04 PM
    //#-----------------------------------------
    private void fleF110_YTDEAR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_YTDEAR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_YTDEAR.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_YTDEAR.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_YTDEAR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_YTDEAR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_YTDEAR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_YTDEAR.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_YTDINC.GetDecimalValue("PROCESS_SEQ"));
            fleF110_YTDEAR.set_SetValue("COMP_CODE", !Fixed, fleF110_YTDINC.GetStringValue("COMP_CODE"));
            fleF110_YTDEAR.set_SetValue("COMP_TYPE", !Fixed, fleF110_YTDINC.GetStringValue("COMP_TYPE"));
            fleF110_YTDEAR.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_YTDINC.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_YTDEAR.set_SetValue("COMP_UNITS", !Fixed, fleF110_YTDINC.GetDecimalValue("COMP_UNITS"));
            fleF110_YTDEAR.set_SetValue("AMT_GROSS", !Fixed, fleF110_YTDINC.GetDecimalValue("AMT_GROSS"));
            fleF110_YTDEAR.set_SetValue("AMT_NET", !Fixed, fleF110_YTDINC.GetDecimalValue("AMT_NET"));
            fleF110_YTDEAR.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_YTDINC.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_YTDEAR.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_YTDINC.GetStringValue("COMPENSATION_STATUS"));
            fleF110_YTDEAR.set_SetValue("FILLER", !Fixed, fleF110_YTDINC.GetStringValue("FILLER"));

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
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:04 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));

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
    //# fleF110_TOTADV_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:04 PM
    //#-----------------------------------------
    private void fleF110_TOTADV_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_TOTADV.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_TOTADV.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_TOTADV.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_TOTADV.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_YTDINC.GetDecimalValue("PROCESS_SEQ"));
            fleF110_TOTADV.set_SetValue("COMP_CODE", !Fixed, fleF110_YTDINC.GetStringValue("COMP_CODE"));
            fleF110_TOTADV.set_SetValue("COMP_TYPE", !Fixed, fleF110_YTDINC.GetStringValue("COMP_TYPE"));
            fleF110_TOTADV.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_YTDINC.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_TOTADV.set_SetValue("COMP_UNITS", !Fixed, fleF110_YTDINC.GetDecimalValue("COMP_UNITS"));
            fleF110_TOTADV.set_SetValue("AMT_GROSS", !Fixed, fleF110_YTDINC.GetDecimalValue("AMT_GROSS"));

            // CORE. Commented out. Not sure why automatic item initialization is happening here. This is wrong
            //fleF110_TOTADV.set_SetValue("AMT_NET", !Fixed, fleF110_YTDINC.GetDecimalValue("AMT_NET"));

            fleF110_TOTADV.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_YTDINC.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_TOTADV.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_YTDINC.GetStringValue("COMPENSATION_STATUS"));
            fleF110_TOTADV.set_SetValue("FILLER", !Fixed, fleF110_YTDINC.GetStringValue("FILLER"));

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
    //# fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:04 PM
    //#-----------------------------------------
    private void fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_PAYPOT.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_PAYPOT.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_YTDINC.GetDecimalValue("PROCESS_SEQ"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_CODE", !Fixed, fleF110_YTDINC.GetStringValue("COMP_CODE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_TYPE", !Fixed, fleF110_YTDINC.GetStringValue("COMP_TYPE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_YTDINC.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_UNITS", !Fixed, fleF110_YTDINC.GetDecimalValue("COMP_UNITS"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_GROSS", !Fixed, fleF110_YTDINC.GetDecimalValue("AMT_GROSS"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_NET", !Fixed, fleF110_YTDINC.GetDecimalValue("AMT_NET"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_YTDINC.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_YTDINC.GetStringValue("COMPENSATION_STATUS"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("FILLER", !Fixed, fleF110_YTDINC.GetStringValue("FILLER"));

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
    //# fleF020_UPDATE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:04 PM
    //#-----------------------------------------
    private void fleF020_UPDATE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleF020_UPDATE.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_123", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_456", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_789", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleF020_UPDATE.set_SetValue("DOC_HOSP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_HOSP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleF020_UPDATE.set_SetValue("DOC_NAME_SOUNDEX", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME_SOUNDEX"));
            fleF020_UPDATE.set_SetValue("DOC_INIT1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1"));
            fleF020_UPDATE.set_SetValue("DOC_INIT2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2"));
            fleF020_UPDATE.set_SetValue("DOC_INIT3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_BRANCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_ACCT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUB", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEAR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_EP_DATE_DEPOSIT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
            fleF020_UPDATE.set_SetValue("DOC_EP_CEIEXP", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
            fleF020_UPDATE.set_SetValue("CEICEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("CEICEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_2"));
            fleF020_UPDATE.set_SetValue("DOC_IND_PAYS_GST", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_5", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6"));
            fleF020_UPDATE.set_SetValue("DOC_SUB_SPECIALTY", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY"));
            fleF020_UPDATE.set_SetValue("DOC_PAYEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
            fleF020_UPDATE.set_SetValue("DOC_YTDDED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_SUB_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_PARTNERSHIP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_PARTNERSHIP"));
            fleF020_UPDATE.set_SetValue("DOC_IND_HOLDBACK_ACTIVE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE"));
            fleF020_UPDATE.set_SetValue("GROUP_REGULAR_SERVICE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE"));
            fleF020_UPDATE.set_SetValue("GROUP_OVER_SERVICED", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3"));

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


    #region "Transaction Management Procedures(U116_RUN_2_CALC_PAYCD_2_28)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:53 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF110_YTDINC.Transaction = m_trnTRANS_UPDATE;
        fleF110_YTDEAR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF110_TOTADV.Transaction = m_trnTRANS_UPDATE;
        fleDEBUGU116CD2.Transaction = m_trnTRANS_UPDATE;
        fleF110_OUTPUT_PAYPOT.Transaction = m_trnTRANS_UPDATE;
        fleF020_UPDATE.Transaction = m_trnTRANS_UPDATE;
        fleF119.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U116_RUN_2_CALC_PAYCD_2_28)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:54 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF112_PYCDCEILINGS.Dispose();
            fleF110_YTDINC.Dispose();
            fleF110_YTDEAR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF110_TOTADV.Dispose();
            fleDEBUGU116CD2.Dispose();
            fleF110_OUTPUT_PAYPOT.Dispose();
            fleF020_UPDATE.Dispose();
            fleF119.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_RUN_2_CALC_PAYCD_2_28)"


    public void Run()
    {

        try
        {
            Request("RUN_2_CALC_PAYCD_2_28");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF112_PYCDCEILINGS.QTPForMissing("1"))
                {
                    // --> GET F112_PYCDCEILINGS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR"));

                    fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F112_PYCDCEILINGS <--

                    while (fleF110_YTDINC.QTPForMissing("2"))
                    {
                        // --> GET F110_YTDINC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF110_YTDINC.ElementOwner("EP_NBR")).Append(" = ");
                        m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                        m_strWhere.Append(" And ").Append(fleF110_YTDINC.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                        m_strWhere.Append(" And ").Append(fleF110_YTDINC.ElementOwner("PROCESS_SEQ")).Append(" = ");
                        m_strWhere.Append((YTDINC_SEQ.Value));
                        m_strWhere.Append(" And ").Append(fleF110_YTDINC.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("YTDINC"));

                        fleF110_YTDINC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F110_YTDINC <--

                        while (fleF110_YTDEAR.QTPForMissing("3"))
                        {
                            // --> GET F110_YTDEAR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF110_YTDEAR.ElementOwner("EP_NBR")).Append(" = ");
                            m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                            m_strWhere.Append(" And ").Append(fleF110_YTDEAR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" And ").Append(fleF110_YTDEAR.ElementOwner("PROCESS_SEQ")).Append(" = ");
                            m_strWhere.Append((YTDEAR_SEQ.Value));
                            m_strWhere.Append(" And ").Append(fleF110_YTDEAR.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("YTDEAR"));

                            fleF110_YTDEAR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F110_YTDEAR <--

                            while (fleF020_DOCTOR_MSTR.QTPForMissing("4"))
                            {
                                // --> GET F020_DOCTOR_MSTR <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                                fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F020_DOCTOR_MSTR <--

                                while (fleF110_TOTADV.QTPForMissing("5"))
                                {
                                    // --> GET F110_TOTADV <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF110_TOTADV.ElementOwner("EP_NBR")).Append(" = ");
                                    m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                                    m_strWhere.Append(" And ").Append(fleF110_TOTADV.ElementOwner("DOC_NBR")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                    m_strWhere.Append(" And ").Append(fleF110_TOTADV.ElementOwner("PROCESS_SEQ")).Append(" = ");
                                    m_strWhere.Append((ADVOUT_SEQ.Value));
                                    m_strWhere.Append(" And ").Append(fleF110_TOTADV.ElementOwner("COMP_CODE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField("ADVOUT"));

                                    fleF110_TOTADV.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F110_TOTADV <--


                                    if (Transaction())
                                    {
                                        SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU116CD2, SubFileType.Keep, fleF112_PYCDCEILINGS, "EP_NBR", "DOC_NBR", "DOC_PAY_CODE", "DOC_PAY_SUB_CODE", "DOC_PAY_SUB_CODE", W_PAYPOT_AMT_NET_2,
                                        W_AMT_NET_F110_YTDINC, W_AMT_NET_F110_YTDEAR, "FACTOR", W_PAYPOT_AMT_NET_3, W_PAYPOT_AMT_NET_4, fleF110_TOTADV, "AMT_NET", W_AMT_ADVOUT, W_PAYPOT_AMT_NET, ADVOUT_SEQ,
                                        W_AMT_NET_F110_TOTADV, TOTADV_FLAG);


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_CODE", "PAYPOT");


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_TYPE", QDesign.NULL(PAYPOT_TYPE.Value));


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("PROCESS_SEQ", PAYPOT_SEQ.Value);


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR", fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));

                                        if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR")) != 10000)
                                        {
                                            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR_OVERRIDE", "*");

                                        }
                                        else
                                        {
                                            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR_OVERRIDE", " ");

                                        }


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_UNITS", fleF110_YTDINC.GetDecimalValue("COMP_UNITS"));


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_GROSS", fleF110_YTDINC.GetDecimalValue("AMT_GROSS"));


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_NET", W_PAYPOT_AMT_NET.Value);


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                                        fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_USER_ID", "U116 gen`d");

                                        fleF110_OUTPUT_PAYPOT.OutPut(OutPutType.Add);


                                        fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update);


                                        SubFile(ref m_trnTRANS_UPDATE, ref fleF119, SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS, "DOC_NBR", X_COMP_CODE, PAYPOT_SEQ_RPT, PAYPOT_GROUP, X_REC_TYPE, NEW_DOC_YTDEAR,
                                        W_PAYPOT_AMT_NET);


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
            EndRequest("RUN_2_CALC_PAYCD_2_28");

        }

    }







    #endregion


}
//RUN_2_CALC_PAYCD_2_28



public class U116_RUN_3_PAYCODES_346_29 : U116
{

    public U116_RUN_3_PAYCODES_346_29(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ = new CoreDecimal("PAYPOT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ_RPT = new CoreDecimal("PAYPOT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_TYPE = new CoreCharacter("PAYPOT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYPOT_GROUP = new CoreCharacter("PAYPOT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEAR_SEQ = new CoreDecimal("CEIEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEAR_TYPE = new CoreCharacter("CEIEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEXP_SEQ = new CoreDecimal("CEIEXP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEXP_TYPE = new CoreCharacter("CEIEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTINC_SEQ = new CoreDecimal("TOTINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTINC_TYPE = new CoreCharacter("TOTINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEA_SEQ = new CoreDecimal("YTDCEA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEA_TYPE = new CoreCharacter("YTDCEA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEX_SEQ = new CoreDecimal("YTDCEX_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEX_TYPE = new CoreCharacter("YTDCEX_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDEAR_SEQ = new CoreDecimal("YTDEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDEAR_TYPE = new CoreCharacter("YTDEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDINC_SEQ = new CoreDecimal("YTDINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDINC_TYPE = new CoreCharacter("YTDINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUB_SEQ = new CoreDecimal("YTDGUB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUB_TYPE = new CoreCharacter("YTDGUB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUC_SEQ = new CoreDecimal("YTDGUC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUC_TYPE = new CoreCharacter("YTDGUC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUD_SEQ = new CoreDecimal("YTDGUD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUD_TYPE = new CoreCharacter("YTDGUD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_SEQ = new CoreDecimal("STATUS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        STATUS_SEQ_RPT = new CoreDecimal("STATUS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        STATUS_TYPE = new CoreCharacter("STATUS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_GROUP = new CoreCharacter("STATUS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_SEQ = new CoreDecimal("ADVOUT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_SEQ_RPT = new CoreDecimal("ADVOUT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_TYPE = new CoreCharacter("ADVOUT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_GROUP = new CoreCharacter("ADVOUT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_FACTOR = new CoreDecimal("ADVOUT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ = new CoreDecimal("TOTADV_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ_RPT = new CoreDecimal("TOTADV_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_TYPE = new CoreCharacter("TOTADV_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_GROUP = new CoreCharacter("TOTADV_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_FACTOR = new CoreDecimal("TOTADV_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ = new CoreDecimal("DEPINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ_RPT = new CoreDecimal("DEPINC_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_TYPE = new CoreCharacter("DEPINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_GROUP = new CoreCharacter("DEPINC_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_FACTOR = new CoreDecimal("DEPINC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ = new CoreDecimal("SVCRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ_RPT = new CoreDecimal("SVCRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_TYPE = new CoreCharacter("SVCRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_GROUP = new CoreCharacter("SVCRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_FACTOR = new CoreDecimal("SVCRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ = new CoreDecimal("SVCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ_RPT = new CoreDecimal("SVCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_TYPE = new CoreCharacter("SVCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_GROUP = new CoreCharacter("SVCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_FACTOR = new CoreDecimal("SVCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ = new CoreDecimal("KEYHRS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ_RPT = new CoreDecimal("KEYHRS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_TYPE = new CoreCharacter("KEYHRS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_GROUP = new CoreCharacter("KEYHRS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_FACTOR = new CoreDecimal("KEYHRS_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ = new CoreDecimal("KEYRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ_RPT = new CoreDecimal("KEYRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_TYPE = new CoreCharacter("KEYRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_GROUP = new CoreCharacter("KEYRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_FACTOR = new CoreDecimal("KEYRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ = new CoreDecimal("KEYCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ_RPT = new CoreDecimal("KEYCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_TYPE = new CoreCharacter("KEYCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_GROUP = new CoreCharacter("KEYCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_FACTOR = new CoreDecimal("KEYCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ = new CoreDecimal("DEPCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ_RPT = new CoreDecimal("DEPCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_TYPE = new CoreCharacter("DEPCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_GROUP = new CoreCharacter("DEPCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_FACTOR = new CoreDecimal("DEPCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ = new CoreDecimal("DEPFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ_RPT = new CoreDecimal("DEPFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_TYPE = new CoreCharacter("DEPFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_GROUP = new CoreCharacter("DEPFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_FACTOR = new CoreDecimal("DEPFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ = new CoreDecimal("DOCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ_RPT = new CoreDecimal("DOCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_TYPE = new CoreCharacter("DOCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_GROUP = new CoreCharacter("DOCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_FACTOR = new CoreDecimal("DOCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ = new CoreDecimal("HSTRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ_RPT = new CoreDecimal("HSTRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_TYPE = new CoreCharacter("HSTRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_GROUP = new CoreCharacter("HSTRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_FACTOR = new CoreDecimal("HSTRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ = new CoreDecimal("PY7HST_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ_RPT = new CoreDecimal("PY7HST_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_TYPE = new CoreCharacter("PY7HST_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_GROUP = new CoreCharacter("PY7HST_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_FACTOR = new CoreDecimal("PY7HST_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ = new CoreDecimal("FINCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ_RPT = new CoreDecimal("FINCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_TYPE = new CoreCharacter("FINCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_GROUP = new CoreCharacter("FINCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_FACTOR = new CoreDecimal("FINCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ = new CoreDecimal("DOCFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ_RPT = new CoreDecimal("DOCFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_TYPE = new CoreCharacter("DOCFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_GROUP = new CoreCharacter("DOCFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_FACTOR = new CoreDecimal("DOCFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_GTYPE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_GTYPE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_CEIEAR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_CEIEAR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_TOTADV = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_TOTADV", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_OUTPUT_PAYPOT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_OUTPUT_PAYPOT", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_OUTPUT_UNDERAGE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_OUTPUT_UNDERAGE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_ADD_GTYPE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_ADD_GTYPE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEBUGU116CD346 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU116CD346", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "F020_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_COMP_CODE = new CoreCharacter("X_COMP_CODE", 6, this, Common.cEmptyString);
        fleF119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_STATUS = new CoreCharacter("X_COMP_CODE_STATUS", 6, this, Common.cEmptyString);
        fleF119_UNDER = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_UNDER", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_GTYPE = new CoreCharacter("X_COMP_CODE_GTYPE", 6, this, Common.cEmptyString);
        fleF119_GTYPE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_GTYPE", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        W_PAY_POT_G_1.GetValue += W_PAY_POT_G_1_GetValue;
        W_PAY_POT_G.GetValue += W_PAY_POT_G_GetValue;
        W_POT_YTD_PAYMENTS.GetValue += W_POT_YTD_PAYMENTS_GetValue;
        W_PAY_ACTUAL_G.GetValue += W_PAY_ACTUAL_G_GetValue;
        W_PAY_ACTUAL_N.GetValue += W_PAY_ACTUAL_N_GetValue;
        W_PAYPOT_AMT_NET_3.GetValue += W_PAYPOT_AMT_NET_3_GetValue;
        W_PAYPOT_AMT_NET_4.GetValue += W_PAYPOT_AMT_NET_4_GetValue;
        W_AMT_ADVOUT.GetValue += W_AMT_ADVOUT_GetValue;
        W_PAYPOT_AMT_NET.GetValue += W_PAYPOT_AMT_NET_GetValue;
        W_UNDERAGE_ACT.GetValue += W_UNDERAGE_ACT_GetValue;
        W_POTGUAR_AMT_NET.GetValue += W_POTGUAR_AMT_NET_GetValue;
        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        NEW_DOC_YTDEAR.GetValue += NEW_DOC_YTDEAR_GetValue;
        X_NOT_NEEDED.GetValue += X_NOT_NEEDED_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        W_POTGUAR_AMT_NET_REVERSE_SIGN.GetValue += W_POTGUAR_AMT_NET_REVERSE_SIGN_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF110_GTYPE.InitializeItems += fleF110_GTYPE_AutomaticItemInitialization;
        fleF110_CEIEAR.InitializeItems += fleF110_CEIEAR_AutomaticItemInitialization;
        fleF110_TOTADV.InitializeItems += fleF110_TOTADV_AutomaticItemInitialization;
        fleF110_OUTPUT_PAYPOT.InitializeItems += fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization;
        fleF110_OUTPUT_UNDERAGE.InitializeItems += fleF110_OUTPUT_UNDERAGE_AutomaticItemInitialization;
        fleF110_ADD_GTYPE.InitializeItems += fleF110_ADD_GTYPE_AutomaticItemInitialization;
        fleF020_UPDATE.InitializeItems += fleF020_UPDATE_AutomaticItemInitialization;
        fleF112_PYCDCEILINGS.SelectIf += FleF112_PYCDCEILINGS_SelectIf;
        fleF020_DOCTOR_MSTR.SetItemFinals += FleF020_DOCTOR_MSTR_SetItemFinals;
    }


    #region "Declarations (Variables, Files and Transactions)(U116_RUN_3_PAYCODES_346_29)"

    protected CoreDecimal W_CURRENT_EP_NBR;
    protected CoreDecimal W_CURRENT_EP_NBR_MINUS1;
    protected CoreDecimal PAYPOT_SEQ;
    protected CoreDecimal PAYPOT_SEQ_RPT;
    protected CoreCharacter PAYPOT_TYPE;
    protected CoreCharacter PAYPOT_GROUP;
    protected CoreDecimal CEIEAR_SEQ;
    protected CoreCharacter CEIEAR_TYPE;
    protected CoreDecimal CEIEXP_SEQ;
    protected CoreCharacter CEIEXP_TYPE;
    protected CoreDecimal TOTINC_SEQ;
    protected CoreCharacter TOTINC_TYPE;
    protected CoreDecimal YTDCEA_SEQ;
    protected CoreCharacter YTDCEA_TYPE;
    protected CoreDecimal YTDCEX_SEQ;
    protected CoreCharacter YTDCEX_TYPE;
    protected CoreDecimal YTDEAR_SEQ;
    protected CoreCharacter YTDEAR_TYPE;
    protected CoreDecimal YTDINC_SEQ;
    protected CoreCharacter YTDINC_TYPE;
    protected CoreDecimal YTDGUB_SEQ;
    protected CoreCharacter YTDGUB_TYPE;
    protected CoreDecimal YTDGUC_SEQ;
    protected CoreCharacter YTDGUC_TYPE;
    protected CoreDecimal YTDGUD_SEQ;
    protected CoreCharacter YTDGUD_TYPE;
    protected CoreDecimal STATUS_SEQ;
    protected CoreDecimal STATUS_SEQ_RPT;
    protected CoreCharacter STATUS_TYPE;
    protected CoreCharacter STATUS_GROUP;
    protected CoreDecimal ADVOUT_SEQ;
    protected CoreDecimal ADVOUT_SEQ_RPT;
    protected CoreCharacter ADVOUT_TYPE;
    protected CoreCharacter ADVOUT_GROUP;
    protected CoreDecimal ADVOUT_FACTOR;
    protected CoreDecimal TOTADV_SEQ;
    protected CoreDecimal TOTADV_SEQ_RPT;
    protected CoreCharacter TOTADV_TYPE;
    protected CoreCharacter TOTADV_GROUP;
    protected CoreDecimal TOTADV_FACTOR;
    protected CoreDecimal DEPINC_SEQ;
    protected CoreDecimal DEPINC_SEQ_RPT;
    protected CoreCharacter DEPINC_TYPE;
    protected CoreCharacter DEPINC_GROUP;
    protected CoreDecimal DEPINC_FACTOR;
    protected CoreDecimal SVCRTE_SEQ;
    protected CoreDecimal SVCRTE_SEQ_RPT;
    protected CoreCharacter SVCRTE_TYPE;
    protected CoreCharacter SVCRTE_GROUP;
    protected CoreDecimal SVCRTE_FACTOR;
    protected CoreDecimal SVCCHG_SEQ;
    protected CoreDecimal SVCCHG_SEQ_RPT;
    protected CoreCharacter SVCCHG_TYPE;
    protected CoreCharacter SVCCHG_GROUP;
    protected CoreDecimal SVCCHG_FACTOR;
    protected CoreDecimal KEYHRS_SEQ;
    protected CoreDecimal KEYHRS_SEQ_RPT;
    protected CoreCharacter KEYHRS_TYPE;
    protected CoreCharacter KEYHRS_GROUP;
    protected CoreDecimal KEYHRS_FACTOR;
    protected CoreDecimal KEYRTE_SEQ;
    protected CoreDecimal KEYRTE_SEQ_RPT;
    protected CoreCharacter KEYRTE_TYPE;
    protected CoreCharacter KEYRTE_GROUP;
    protected CoreDecimal KEYRTE_FACTOR;
    protected CoreDecimal KEYCHG_SEQ;
    protected CoreDecimal KEYCHG_SEQ_RPT;
    protected CoreCharacter KEYCHG_TYPE;
    protected CoreCharacter KEYCHG_GROUP;
    protected CoreDecimal KEYCHG_FACTOR;
    protected CoreDecimal DEPCHG_SEQ;
    protected CoreDecimal DEPCHG_SEQ_RPT;
    protected CoreCharacter DEPCHG_TYPE;
    protected CoreCharacter DEPCHG_GROUP;
    protected CoreDecimal DEPCHG_FACTOR;
    protected CoreDecimal DEPFTE_SEQ;
    protected CoreDecimal DEPFTE_SEQ_RPT;
    protected CoreCharacter DEPFTE_TYPE;
    protected CoreCharacter DEPFTE_GROUP;
    protected CoreDecimal DEPFTE_FACTOR;
    protected CoreDecimal DOCCHG_SEQ;
    protected CoreDecimal DOCCHG_SEQ_RPT;
    protected CoreCharacter DOCCHG_TYPE;
    protected CoreCharacter DOCCHG_GROUP;
    protected CoreDecimal DOCCHG_FACTOR;
    protected CoreDecimal HSTRTE_SEQ;
    protected CoreDecimal HSTRTE_SEQ_RPT;
    protected CoreCharacter HSTRTE_TYPE;
    protected CoreCharacter HSTRTE_GROUP;
    protected CoreDecimal HSTRTE_FACTOR;
    protected CoreDecimal PY7HST_SEQ;
    protected CoreDecimal PY7HST_SEQ_RPT;
    protected CoreCharacter PY7HST_TYPE;
    protected CoreCharacter PY7HST_GROUP;
    protected CoreDecimal PY7HST_FACTOR;
    protected CoreDecimal FINCHG_SEQ;
    protected CoreDecimal FINCHG_SEQ_RPT;
    protected CoreCharacter FINCHG_TYPE;
    protected CoreCharacter FINCHG_GROUP;
    protected CoreDecimal FINCHG_FACTOR;
    protected CoreDecimal DOCFTE_SEQ;
    protected CoreDecimal DOCFTE_SEQ_RPT;
    protected CoreCharacter DOCFTE_TYPE;
    protected CoreCharacter DOCFTE_GROUP;
    protected CoreDecimal DOCFTE_FACTOR;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF112_PYCDCEILINGS;
    private void FleF112_PYCDCEILINGS_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append("  (  ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_PAY_CODE")).Append(" =  '3'  ");
            strSQL.Append("  OR  ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_PAY_CODE")).Append(" =  '4'  ");
            strSQL.Append("  OR  ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_PAY_CODE")).Append(" =  '6' ) ");


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
    private void FleF020_DOCTOR_MSTR_SetItemFinals()
    {
        try
        {
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDEAR", NEW_DOC_YTDEAR.Value);
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_EP_PAY_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_EP_PAY_SUB_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));
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
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF110_GTYPE;
    private SqlFileObject fleF110_CEIEAR;
    private SqlFileObject fleF110_TOTADV;
    private DInteger W_PAY_POT_G_1 = new DInteger("W_PAY_POT_G_1", 10);
    private void W_PAY_POT_G_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "4")
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC") - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR");
            }
            else if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "6")
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G") - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED");
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC") - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR");
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
    private DInteger W_PAY_POT_G = new DInteger("W_PAY_POT_G", 10);
    private void W_PAY_POT_G_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_PAY_POT_G_1.Value;


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
    private DInteger W_POT_YTD_PAYMENTS = new DInteger("W_POT_YTD_PAYMENTS", 10);
    private void W_POT_YTD_PAYMENTS_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + W_PAY_POT_G.Value;


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
    private DInteger W_PAY_ACTUAL_G = new DInteger("W_PAY_ACTUAL_G", 10);
    private void W_PAY_ACTUAL_G_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (W_POT_YTD_PAYMENTS.Value <= fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA") | QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "6")
            {
                CurrentValue = W_PAY_POT_G.Value;
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA") - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR");
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
    private DInteger W_PAY_ACTUAL_N = new DInteger("W_PAY_ACTUAL_N", 10);
    private void W_PAY_ACTUAL_N_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = (W_PAY_ACTUAL_G.Value * fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR")) / 10000;


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
    private DInteger W_PAYPOT_AMT_NET_3 = new DInteger("W_PAYPOT_AMT_NET_3", 10);
    private void W_PAYPOT_AMT_NET_3_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_PAY_ACTUAL_N.Value;


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
    private DInteger W_PAYPOT_AMT_NET_4 = new DInteger("W_PAYPOT_AMT_NET_4", 10);
    private void W_PAYPOT_AMT_NET_4_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (fleF110_TOTADV.Exists())
            {
                CurrentValue = W_PAYPOT_AMT_NET_3.Value - fleF110_TOTADV.GetDecimalValue("AMT_NET");
            }
            else
            {
                CurrentValue = W_PAYPOT_AMT_NET_3.Value;
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
    private DInteger W_AMT_ADVOUT = new DInteger("W_AMT_ADVOUT", 10);
    private void W_AMT_ADVOUT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (W_PAYPOT_AMT_NET_4.Value >= 0)
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = Math.Abs(W_PAYPOT_AMT_NET_4.Value);
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
    private DInteger W_PAYPOT_AMT_NET = new DInteger("W_PAYPOT_AMT_NET", 10);
    private void W_PAYPOT_AMT_NET_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_PAYPOT_AMT_NET_4.Value;


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
    private DInteger W_UNDERAGE_ACT = new DInteger("W_UNDERAGE_ACT", 10);
    private void W_UNDERAGE_ACT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) != "6")
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA") - (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + W_PAYPOT_AMT_NET.Value);
            }
            else
            {
                CurrentValue = 0;
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
    private DInteger W_POTGUAR_AMT_NET = new DInteger("W_POTGUAR_AMT_NET", 10);
    private void W_POTGUAR_AMT_NET_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) != "6")
            {
                CurrentValue = (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + W_PAYPOT_AMT_NET.Value) - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC") + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX");
            }
            else
            {
                CurrentValue = 0;
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
    private SqlFileObject fleF110_OUTPUT_PAYPOT;
    private SqlFileObject fleF110_OUTPUT_UNDERAGE;
    private SqlFileObject fleF110_ADD_GTYPE;
    private SqlFileObject fleDEBUGU116CD346;
    private DInteger NEW_DOC_YTDEAR = new DInteger("NEW_DOC_YTDEAR", 10);
    private void NEW_DOC_YTDEAR_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + W_PAYPOT_AMT_NET.Value;


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
    private SqlFileObject fleF020_UPDATE;
    private DInteger X_NOT_NEEDED = new DInteger("X_NOT_NEEDED", 10);
    private void X_NOT_NEEDED_GetValue(ref decimal Value)
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
    private DCharacter X_REC_TYPE = new DCharacter("X_REC_TYPE", 1);
    private void X_REC_TYPE_GetValue(ref string Value)
    {

        try
        {
            Value = "A";


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
    private CoreCharacter X_COMP_CODE;
    private SqlFileObject fleF119;
    private CoreCharacter X_COMP_CODE_STATUS;
    private SqlFileObject fleF119_UNDER;
    private DInteger W_POTGUAR_AMT_NET_REVERSE_SIGN = new DInteger("W_POTGUAR_AMT_NET_REVERSE_SIGN", 10);
    private void W_POTGUAR_AMT_NET_REVERSE_SIGN_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0 - W_POTGUAR_AMT_NET.Value;


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
    private CoreCharacter X_COMP_CODE_GTYPE;
    private SqlFileObject fleF119_GTYPE;


    #endregion


    #region "Standard Generated Procedures(U116_RUN_3_PAYCODES_346_29)"


    #region "Automatic Item Initialization(U116_RUN_3_PAYCODES_346_29)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:38:05 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));

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
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF190_COMP_CODES_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF110_GTYPE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF110_GTYPE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_GTYPE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_GTYPE.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_GTYPE.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_GTYPE.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_GTYPE.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_GTYPE.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_GTYPE.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF110_GTYPE.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_GTYPE.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));

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
    //# fleF110_CEIEAR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF110_CEIEAR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_CEIEAR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_CEIEAR.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_CEIEAR.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_CEIEAR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_CEIEAR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_CEIEAR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_CEIEAR.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF110_CEIEAR.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_CEIEAR.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            //TODO: Manual steps may be required.
            fleF110_CEIEAR.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_GTYPE.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_CEIEAR.set_SetValue("COMP_UNITS", !Fixed, fleF110_GTYPE.GetDecimalValue("COMP_UNITS"));
            fleF110_CEIEAR.set_SetValue("AMT_GROSS", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_GROSS"));
            fleF110_CEIEAR.set_SetValue("AMT_NET", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_NET"));
            fleF110_CEIEAR.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_GTYPE.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_CEIEAR.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_GTYPE.GetStringValue("COMPENSATION_STATUS"));
            fleF110_CEIEAR.set_SetValue("FILLER", !Fixed, fleF110_GTYPE.GetStringValue("FILLER"));

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
    //# fleF110_TOTADV_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF110_TOTADV_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_TOTADV.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_TOTADV.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_TOTADV.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_TOTADV.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF110_TOTADV.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_TOTADV.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            //TODO: Manual steps may be required.
            fleF110_TOTADV.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_GTYPE.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_TOTADV.set_SetValue("COMP_UNITS", !Fixed, fleF110_GTYPE.GetDecimalValue("COMP_UNITS"));
            fleF110_TOTADV.set_SetValue("AMT_GROSS", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_GROSS"));
            fleF110_TOTADV.set_SetValue("AMT_NET", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_NET"));
            fleF110_TOTADV.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_GTYPE.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_TOTADV.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_GTYPE.GetStringValue("COMPENSATION_STATUS"));
            fleF110_TOTADV.set_SetValue("FILLER", !Fixed, fleF110_GTYPE.GetStringValue("FILLER"));

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
    //# fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_PAYPOT.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_GTYPE.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_UNITS", !Fixed, fleF110_GTYPE.GetDecimalValue("COMP_UNITS"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_GROSS", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_GROSS"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_NET", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_NET"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_GTYPE.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_GTYPE.GetStringValue("COMPENSATION_STATUS"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("FILLER", !Fixed, fleF110_GTYPE.GetStringValue("FILLER"));

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
    //# fleF110_OUTPUT_UNDERAGE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF110_OUTPUT_UNDERAGE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_UNDERAGE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_UNDERAGE.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_GTYPE.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_UNITS", !Fixed, fleF110_GTYPE.GetDecimalValue("COMP_UNITS"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("AMT_GROSS", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_GROSS"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("AMT_NET", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_NET"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_GTYPE.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_GTYPE.GetStringValue("COMPENSATION_STATUS"));
            fleF110_OUTPUT_UNDERAGE.set_SetValue("FILLER", !Fixed, fleF110_GTYPE.GetStringValue("FILLER"));

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
    //# fleF110_ADD_GTYPE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF110_ADD_GTYPE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_ADD_GTYPE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_ADD_GTYPE.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_ADD_GTYPE.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_ADD_GTYPE.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF110_ADD_GTYPE.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_ADD_GTYPE.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            //TODO: Manual steps may be required.
            fleF110_ADD_GTYPE.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_GTYPE.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_ADD_GTYPE.set_SetValue("COMP_UNITS", !Fixed, fleF110_GTYPE.GetDecimalValue("COMP_UNITS"));
            fleF110_ADD_GTYPE.set_SetValue("AMT_GROSS", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_GROSS"));
            fleF110_ADD_GTYPE.set_SetValue("AMT_NET", !Fixed, fleF110_GTYPE.GetDecimalValue("AMT_NET"));
            fleF110_ADD_GTYPE.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_GTYPE.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_ADD_GTYPE.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_GTYPE.GetStringValue("COMPENSATION_STATUS"));
            fleF110_ADD_GTYPE.set_SetValue("FILLER", !Fixed, fleF110_GTYPE.GetStringValue("FILLER"));

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
    //# fleF020_UPDATE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF020_UPDATE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleF020_UPDATE.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_123", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_456", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_789", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleF020_UPDATE.set_SetValue("DOC_HOSP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_HOSP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleF020_UPDATE.set_SetValue("DOC_NAME_SOUNDEX", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME_SOUNDEX"));
            fleF020_UPDATE.set_SetValue("DOC_INIT1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1"));
            fleF020_UPDATE.set_SetValue("DOC_INIT2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2"));
            fleF020_UPDATE.set_SetValue("DOC_INIT3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_BRANCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_ACCT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUB", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEAR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_EP_DATE_DEPOSIT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
            fleF020_UPDATE.set_SetValue("DOC_EP_CEIEXP", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
            fleF020_UPDATE.set_SetValue("CEICEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("CEICEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_2"));
            fleF020_UPDATE.set_SetValue("DOC_IND_PAYS_GST", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_5", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6"));
            fleF020_UPDATE.set_SetValue("DOC_SUB_SPECIALTY", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY"));
            fleF020_UPDATE.set_SetValue("DOC_PAYEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
            fleF020_UPDATE.set_SetValue("DOC_YTDDED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_SUB_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_PARTNERSHIP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_PARTNERSHIP"));
            fleF020_UPDATE.set_SetValue("DOC_IND_HOLDBACK_ACTIVE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE"));
            fleF020_UPDATE.set_SetValue("GROUP_REGULAR_SERVICE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE"));
            fleF020_UPDATE.set_SetValue("GROUP_OVER_SERVICED", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3"));

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


    #region "Transaction Management Procedures(U116_RUN_3_PAYCODES_346_29)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:55 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF110_GTYPE.Transaction = m_trnTRANS_UPDATE;
        fleF110_CEIEAR.Transaction = m_trnTRANS_UPDATE;
        fleF110_TOTADV.Transaction = m_trnTRANS_UPDATE;
        fleF110_OUTPUT_PAYPOT.Transaction = m_trnTRANS_UPDATE;
        fleF110_OUTPUT_UNDERAGE.Transaction = m_trnTRANS_UPDATE;
        fleF110_ADD_GTYPE.Transaction = m_trnTRANS_UPDATE;
        fleDEBUGU116CD346.Transaction = m_trnTRANS_UPDATE;
        fleF020_UPDATE.Transaction = m_trnTRANS_UPDATE;
        fleF119.Transaction = m_trnTRANS_UPDATE;
        fleF119_UNDER.Transaction = m_trnTRANS_UPDATE;
        fleF119_GTYPE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U116_RUN_3_PAYCODES_346_29)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:55 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF112_PYCDCEILINGS.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF110_GTYPE.Dispose();
            fleF110_CEIEAR.Dispose();
            fleF110_TOTADV.Dispose();
            fleF110_OUTPUT_PAYPOT.Dispose();
            fleF110_OUTPUT_UNDERAGE.Dispose();
            fleF110_ADD_GTYPE.Dispose();
            fleDEBUGU116CD346.Dispose();
            fleF020_UPDATE.Dispose();
            fleF119.Dispose();
            fleF119_UNDER.Dispose();
            fleF119_GTYPE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_RUN_3_PAYCODES_346_29)"


    public void Run()
    {

        try
        {
            Request("RUN_3_PAYCODES_346_29");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF112_PYCDCEILINGS.QTPForMissing("1"))
                {
                    // --> GET F112_PYCDCEILINGS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));
                    

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR"));

                    fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F112_PYCDCEILINGS <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF190_COMP_CODES.QTPForMissing("3"))
                        {
                            // --> GET F190_COMP_CODES <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("GTYPE" + fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")));

                            fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F190_COMP_CODES <--

                            while (fleF110_GTYPE.QTPForMissing("4"))
                            {
                                // --> GET F110_GTYPE <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF110_GTYPE.ElementOwner("EP_NBR")).Append(" = ");
                                m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                                m_strWhere.Append(" And ").Append(fleF110_GTYPE.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                m_strWhere.Append(" And ").Append(fleF110_GTYPE.ElementOwner("COMP_CODE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField("GTYPE" + fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE")));
                                m_strWhere.Append(" And ").Append(fleF110_GTYPE.ElementOwner("PROCESS_SEQ")).Append(" = ");
                                m_strWhere.Append((fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ")));

                                fleF110_GTYPE.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F110_GTYPE <--

                                while (fleF110_CEIEAR.QTPForMissing("5"))
                                {
                                    // --> GET F110_CEIEAR <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF110_CEIEAR.ElementOwner("EP_NBR")).Append(" = ");
                                    m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                                    m_strWhere.Append(" And ").Append(fleF110_CEIEAR.ElementOwner("DOC_NBR")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                    m_strWhere.Append(" And ").Append(fleF110_CEIEAR.ElementOwner("COMP_CODE")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField("CEIEAR"));
                                    m_strWhere.Append(" And ").Append(fleF110_CEIEAR.ElementOwner("PROCESS_SEQ")).Append(" = ");
                                    m_strWhere.Append((CEIEAR_SEQ.Value));

                                    fleF110_CEIEAR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F110_CEIEAR <--

                                    while (fleF110_TOTADV.QTPForMissing("6"))
                                    {
                                        // --> GET F110_TOTADV <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleF110_TOTADV.ElementOwner("EP_NBR")).Append(" = ");
                                        m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                                        m_strWhere.Append(" And ").Append(fleF110_TOTADV.ElementOwner("DOC_NBR")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                        m_strWhere.Append(" And ").Append(fleF110_TOTADV.ElementOwner("COMP_CODE")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField("TOTADV"));
                                        m_strWhere.Append(" And ").Append(fleF110_TOTADV.ElementOwner("PROCESS_SEQ")).Append(" = ");
                                        m_strWhere.Append((TOTADV_SEQ.Value));

                                        fleF110_TOTADV.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                        // --> End GET F110_TOTADV <--


                                        if (Transaction())
                                        {
                                            fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_CODE", "PAYPOT");


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_TYPE", QDesign.NULL(PAYPOT_TYPE.Value));


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("PROCESS_SEQ", PAYPOT_SEQ.Value);


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR", fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));

                                            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR")) != 10000)
                                            {
                                                fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR_OVERRIDE", "*");

                                            }
                                            else
                                            {
                                                fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR_OVERRIDE", " ");

                                            }


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_UNITS", 0);


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_GROSS", fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING") * 100);


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_NET", W_PAYPOT_AMT_NET.Value);


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                                            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_USER_ID", "U116 gen`d");


                                            fleF110_OUTPUT_PAYPOT.OutPut(OutPutType.Add);


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_CODE", "STATUS");


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_TYPE", QDesign.NULL(STATUS_TYPE.Value));


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("PROCESS_SEQ", STATUS_SEQ.Value);


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("FACTOR", 0);


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("FACTOR_OVERRIDE", " ");


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMP_UNITS", 0);


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("AMT_GROSS", 0);


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("AMT_NET", W_UNDERAGE_ACT.Value);


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                                            fleF110_OUTPUT_UNDERAGE.set_SetValue("LAST_MOD_USER_ID", "U116 gen`d");

                                            fleF110_OUTPUT_UNDERAGE.OutPut(OutPutType.Add, null, QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) != "6");



                                            fleF110_GTYPE.set_SetValue("COMP_UNITS", 0);


                                            fleF110_GTYPE.set_SetValue("AMT_GROSS", 0);


                                            fleF110_GTYPE.set_SetValue("AMT_NET", W_POTGUAR_AMT_NET.Value);


                                            fleF110_GTYPE.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                                            fleF110_GTYPE.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                                            fleF110_GTYPE.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                                            fleF110_GTYPE.set_SetValue("LAST_MOD_USER_ID", "U116 gen`d");

                                            fleF110_GTYPE.OutPut(OutPutType.Update, null, fleF110_GTYPE.Exists() & QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "4");



                                            fleF110_ADD_GTYPE.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                                            fleF110_ADD_GTYPE.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                                            fleF110_ADD_GTYPE.set_SetValue("COMP_CODE", fleF190_COMP_CODES.GetStringValue("COMP_CODE"));


                                            fleF110_ADD_GTYPE.set_SetValue("COMP_TYPE", fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));


                                            fleF110_ADD_GTYPE.set_SetValue("PROCESS_SEQ", fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));


                                            fleF110_ADD_GTYPE.set_SetValue("FACTOR", fleF110_GTYPE.GetDecimalValue("FACTOR"));


                                            fleF110_ADD_GTYPE.set_SetValue("FACTOR_OVERRIDE", fleF110_GTYPE.GetStringValue("FACTOR_OVERRIDE"));


                                            fleF110_ADD_GTYPE.set_SetValue("COMP_UNITS", 0);


                                            fleF110_ADD_GTYPE.set_SetValue("AMT_GROSS", 0);


                                            fleF110_ADD_GTYPE.set_SetValue("AMT_NET", W_POTGUAR_AMT_NET.Value);


                                            fleF110_ADD_GTYPE.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                                            fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                                            fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                                            fleF110_ADD_GTYPE.set_SetValue("LAST_MOD_USER_ID", "U116 gen`d");

                                            fleF110_ADD_GTYPE.OutPut(OutPutType.Add, null, !fleF110_GTYPE.Exists() & QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "4");


                                            SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU116CD346, SubFileType.Keep, fleF112_PYCDCEILINGS, "EP_NBR", "DOC_NBR", "DOC_PAY_CODE", "DOC_PAY_SUB_CODE", "FACTOR", fleF020_DOCTOR_MSTR,
                                            "DOC_YTDINC", "DOC_YTDEAR", "DOC_YTDCEA", "DOC_YTDCEX", "DOC_YRLY_EXPENSE_COMPUTED", "DOC_YTDINC_G", W_PAY_POT_G_1, W_PAY_POT_G, W_PAY_ACTUAL_G, W_PAY_ACTUAL_N,
                                            W_PAYPOT_AMT_NET, W_UNDERAGE_ACT);

                                            fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update);


                                            X_COMP_CODE.Value = "PAYPOT";

                                            SubFile(ref m_trnTRANS_UPDATE, ref fleF119, SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS, "DOC_NBR", X_COMP_CODE, PAYPOT_SEQ_RPT, PAYPOT_GROUP, X_REC_TYPE, NEW_DOC_YTDEAR,
                                            W_PAYPOT_AMT_NET);

                                            X_COMP_CODE_STATUS.Value = "STATUS";
                                            SubFile(ref m_trnTRANS_UPDATE, ref fleF119_UNDER, SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS, "DOC_NBR", X_COMP_CODE_STATUS, STATUS_SEQ_RPT, STATUS_GROUP, X_REC_TYPE, X_NOT_NEEDED,
                                            W_UNDERAGE_ACT);

                                            X_COMP_CODE_GTYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE");
                                            SubFile(ref m_trnTRANS_UPDATE, ref fleF119_GTYPE, QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "4", SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS, "DOC_NBR", X_COMP_CODE_GTYPE, fleF190_COMP_CODES, "REPORTING_SEQ", "COMP_CODE_GROUP",
                                            X_REC_TYPE, X_NOT_NEEDED, W_POTGUAR_AMT_NET_REVERSE_SIGN);


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
            EndRequest("RUN_3_PAYCODES_346_29");

        }

    }







    #endregion


}
//RUN_3_PAYCODES_346_29



public class U116_RUN_2_CALC_PAYCD_5_30 : U116
{

    public U116_RUN_2_CALC_PAYCD_5_30(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ = new CoreDecimal("PAYPOT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ_RPT = new CoreDecimal("PAYPOT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_TYPE = new CoreCharacter("PAYPOT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYPOT_GROUP = new CoreCharacter("PAYPOT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEAR_SEQ = new CoreDecimal("CEIEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEAR_TYPE = new CoreCharacter("CEIEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEXP_SEQ = new CoreDecimal("CEIEXP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        CEIEXP_TYPE = new CoreCharacter("CEIEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTINC_SEQ = new CoreDecimal("TOTINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTINC_TYPE = new CoreCharacter("TOTINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEA_SEQ = new CoreDecimal("YTDCEA_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEA_TYPE = new CoreCharacter("YTDCEA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDCEX_SEQ = new CoreDecimal("YTDCEX_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDCEX_TYPE = new CoreCharacter("YTDCEX_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDEAR_SEQ = new CoreDecimal("YTDEAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDEAR_TYPE = new CoreCharacter("YTDEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDINC_SEQ = new CoreDecimal("YTDINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDINC_TYPE = new CoreCharacter("YTDINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUB_SEQ = new CoreDecimal("YTDGUB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUB_TYPE = new CoreCharacter("YTDGUB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUC_SEQ = new CoreDecimal("YTDGUC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUC_TYPE = new CoreCharacter("YTDGUC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        YTDGUD_SEQ = new CoreDecimal("YTDGUD_SEQ", 2, this, ResetTypes.ResetAtStartup);
        YTDGUD_TYPE = new CoreCharacter("YTDGUD_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_SEQ = new CoreDecimal("STATUS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        STATUS_SEQ_RPT = new CoreDecimal("STATUS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        STATUS_TYPE = new CoreCharacter("STATUS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        STATUS_GROUP = new CoreCharacter("STATUS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_SEQ = new CoreDecimal("ADVOUT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_SEQ_RPT = new CoreDecimal("ADVOUT_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_TYPE = new CoreCharacter("ADVOUT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_GROUP = new CoreCharacter("ADVOUT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_FACTOR = new CoreDecimal("ADVOUT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ = new CoreDecimal("TOTADV_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ_RPT = new CoreDecimal("TOTADV_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_TYPE = new CoreCharacter("TOTADV_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_GROUP = new CoreCharacter("TOTADV_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_FACTOR = new CoreDecimal("TOTADV_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ = new CoreDecimal("DEPINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_SEQ_RPT = new CoreDecimal("DEPINC_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPINC_TYPE = new CoreCharacter("DEPINC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_GROUP = new CoreCharacter("DEPINC_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPINC_FACTOR = new CoreDecimal("DEPINC_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ = new CoreDecimal("SVCRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_SEQ_RPT = new CoreDecimal("SVCRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCRTE_TYPE = new CoreCharacter("SVCRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_GROUP = new CoreCharacter("SVCRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCRTE_FACTOR = new CoreDecimal("SVCRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ = new CoreDecimal("SVCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_SEQ_RPT = new CoreDecimal("SVCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        SVCCHG_TYPE = new CoreCharacter("SVCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_GROUP = new CoreCharacter("SVCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        SVCCHG_FACTOR = new CoreDecimal("SVCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ = new CoreDecimal("KEYHRS_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_SEQ_RPT = new CoreDecimal("KEYHRS_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYHRS_TYPE = new CoreCharacter("KEYHRS_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_GROUP = new CoreCharacter("KEYHRS_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYHRS_FACTOR = new CoreDecimal("KEYHRS_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ = new CoreDecimal("KEYRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_SEQ_RPT = new CoreDecimal("KEYRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYRTE_TYPE = new CoreCharacter("KEYRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_GROUP = new CoreCharacter("KEYRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYRTE_FACTOR = new CoreDecimal("KEYRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ = new CoreDecimal("KEYCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_SEQ_RPT = new CoreDecimal("KEYCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        KEYCHG_TYPE = new CoreCharacter("KEYCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_GROUP = new CoreCharacter("KEYCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        KEYCHG_FACTOR = new CoreDecimal("KEYCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ = new CoreDecimal("DEPCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_SEQ_RPT = new CoreDecimal("DEPCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPCHG_TYPE = new CoreCharacter("DEPCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_GROUP = new CoreCharacter("DEPCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPCHG_FACTOR = new CoreDecimal("DEPCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ = new CoreDecimal("DEPFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_SEQ_RPT = new CoreDecimal("DEPFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DEPFTE_TYPE = new CoreCharacter("DEPFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_GROUP = new CoreCharacter("DEPFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEPFTE_FACTOR = new CoreDecimal("DEPFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ = new CoreDecimal("DOCCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_SEQ_RPT = new CoreDecimal("DOCCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCCHG_TYPE = new CoreCharacter("DOCCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_GROUP = new CoreCharacter("DOCCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCCHG_FACTOR = new CoreDecimal("DOCCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ = new CoreDecimal("HSTRTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_SEQ_RPT = new CoreDecimal("HSTRTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        HSTRTE_TYPE = new CoreCharacter("HSTRTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_GROUP = new CoreCharacter("HSTRTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        HSTRTE_FACTOR = new CoreDecimal("HSTRTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ = new CoreDecimal("PY7HST_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_SEQ_RPT = new CoreDecimal("PY7HST_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        PY7HST_TYPE = new CoreCharacter("PY7HST_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_GROUP = new CoreCharacter("PY7HST_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PY7HST_FACTOR = new CoreDecimal("PY7HST_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ = new CoreDecimal("FINCHG_SEQ", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_SEQ_RPT = new CoreDecimal("FINCHG_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        FINCHG_TYPE = new CoreCharacter("FINCHG_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_GROUP = new CoreCharacter("FINCHG_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        FINCHG_FACTOR = new CoreDecimal("FINCHG_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ = new CoreDecimal("DOCFTE_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_SEQ_RPT = new CoreDecimal("DOCFTE_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        DOCFTE_TYPE = new CoreCharacter("DOCFTE_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_GROUP = new CoreCharacter("DOCFTE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DOCFTE_FACTOR = new CoreDecimal("DOCFTE_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_TOTINC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_TOTINC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEBUGU116CD5 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU116CD5", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF110_OUTPUT_PAYPOT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_OUTPUT_PAYPOT", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "F020_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        W_DOC_YRLY_CEILING.GetValue += W_DOC_YRLY_CEILING_GetValue;
        W_PAYPOT_AMT_GROSS.GetValue += W_PAYPOT_AMT_GROSS_GetValue;
        W_PAYPOT_AMT_NET.GetValue += W_PAYPOT_AMT_NET_GetValue;
        NEW_DOC_YTDEAR.GetValue += NEW_DOC_YTDEAR_GetValue;
        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        X_NOT_NEEDED.GetValue += X_NOT_NEEDED_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        X_COMP_CODE.GetValue += X_COMP_CODE_GetValue;
        fleF110_TOTINC.InitializeItems += fleF110_TOTINC_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF110_OUTPUT_PAYPOT.InitializeItems += fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization;
        fleF020_UPDATE.InitializeItems += fleF020_UPDATE_AutomaticItemInitialization;
        fleF112_PYCDCEILINGS.SelectIf += FleF112_PYCDCEILINGS_SelectIf;
    }


    #region "Declarations (Variables, Files and Transactions)(U116_RUN_2_CALC_PAYCD_5_30)"

    protected CoreDecimal W_CURRENT_EP_NBR;
    protected CoreDecimal W_CURRENT_EP_NBR_MINUS1;
    protected CoreDecimal PAYPOT_SEQ;
    protected CoreDecimal PAYPOT_SEQ_RPT;
    protected CoreCharacter PAYPOT_TYPE;
    protected CoreCharacter PAYPOT_GROUP;
    protected CoreDecimal CEIEAR_SEQ;
    protected CoreCharacter CEIEAR_TYPE;
    protected CoreDecimal CEIEXP_SEQ;
    protected CoreCharacter CEIEXP_TYPE;
    protected CoreDecimal TOTINC_SEQ;
    protected CoreCharacter TOTINC_TYPE;
    protected CoreDecimal YTDCEA_SEQ;
    protected CoreCharacter YTDCEA_TYPE;
    protected CoreDecimal YTDCEX_SEQ;
    protected CoreCharacter YTDCEX_TYPE;
    protected CoreDecimal YTDEAR_SEQ;
    protected CoreCharacter YTDEAR_TYPE;
    protected CoreDecimal YTDINC_SEQ;
    protected CoreCharacter YTDINC_TYPE;
    protected CoreDecimal YTDGUB_SEQ;
    protected CoreCharacter YTDGUB_TYPE;
    protected CoreDecimal YTDGUC_SEQ;
    protected CoreCharacter YTDGUC_TYPE;
    protected CoreDecimal YTDGUD_SEQ;
    protected CoreCharacter YTDGUD_TYPE;
    protected CoreDecimal STATUS_SEQ;
    protected CoreDecimal STATUS_SEQ_RPT;
    protected CoreCharacter STATUS_TYPE;
    protected CoreCharacter STATUS_GROUP;
    protected CoreDecimal ADVOUT_SEQ;
    protected CoreDecimal ADVOUT_SEQ_RPT;
    protected CoreCharacter ADVOUT_TYPE;
    protected CoreCharacter ADVOUT_GROUP;
    protected CoreDecimal ADVOUT_FACTOR;
    protected CoreDecimal TOTADV_SEQ;
    protected CoreDecimal TOTADV_SEQ_RPT;
    protected CoreCharacter TOTADV_TYPE;
    protected CoreCharacter TOTADV_GROUP;
    protected CoreDecimal TOTADV_FACTOR;
    protected CoreDecimal DEPINC_SEQ;
    protected CoreDecimal DEPINC_SEQ_RPT;
    protected CoreCharacter DEPINC_TYPE;
    protected CoreCharacter DEPINC_GROUP;
    protected CoreDecimal DEPINC_FACTOR;
    protected CoreDecimal SVCRTE_SEQ;
    protected CoreDecimal SVCRTE_SEQ_RPT;
    protected CoreCharacter SVCRTE_TYPE;
    protected CoreCharacter SVCRTE_GROUP;
    protected CoreDecimal SVCRTE_FACTOR;
    protected CoreDecimal SVCCHG_SEQ;
    protected CoreDecimal SVCCHG_SEQ_RPT;
    protected CoreCharacter SVCCHG_TYPE;
    protected CoreCharacter SVCCHG_GROUP;
    protected CoreDecimal SVCCHG_FACTOR;
    protected CoreDecimal KEYHRS_SEQ;
    protected CoreDecimal KEYHRS_SEQ_RPT;
    protected CoreCharacter KEYHRS_TYPE;
    protected CoreCharacter KEYHRS_GROUP;
    protected CoreDecimal KEYHRS_FACTOR;
    protected CoreDecimal KEYRTE_SEQ;
    protected CoreDecimal KEYRTE_SEQ_RPT;
    protected CoreCharacter KEYRTE_TYPE;
    protected CoreCharacter KEYRTE_GROUP;
    protected CoreDecimal KEYRTE_FACTOR;
    protected CoreDecimal KEYCHG_SEQ;
    protected CoreDecimal KEYCHG_SEQ_RPT;
    protected CoreCharacter KEYCHG_TYPE;
    protected CoreCharacter KEYCHG_GROUP;
    protected CoreDecimal KEYCHG_FACTOR;
    protected CoreDecimal DEPCHG_SEQ;
    protected CoreDecimal DEPCHG_SEQ_RPT;
    protected CoreCharacter DEPCHG_TYPE;
    protected CoreCharacter DEPCHG_GROUP;
    protected CoreDecimal DEPCHG_FACTOR;
    protected CoreDecimal DEPFTE_SEQ;
    protected CoreDecimal DEPFTE_SEQ_RPT;
    protected CoreCharacter DEPFTE_TYPE;
    protected CoreCharacter DEPFTE_GROUP;
    protected CoreDecimal DEPFTE_FACTOR;
    protected CoreDecimal DOCCHG_SEQ;
    protected CoreDecimal DOCCHG_SEQ_RPT;
    protected CoreCharacter DOCCHG_TYPE;
    protected CoreCharacter DOCCHG_GROUP;
    protected CoreDecimal DOCCHG_FACTOR;
    protected CoreDecimal HSTRTE_SEQ;
    protected CoreDecimal HSTRTE_SEQ_RPT;
    protected CoreCharacter HSTRTE_TYPE;
    protected CoreCharacter HSTRTE_GROUP;
    protected CoreDecimal HSTRTE_FACTOR;
    protected CoreDecimal PY7HST_SEQ;
    protected CoreDecimal PY7HST_SEQ_RPT;
    protected CoreCharacter PY7HST_TYPE;
    protected CoreCharacter PY7HST_GROUP;
    protected CoreDecimal PY7HST_FACTOR;
    protected CoreDecimal FINCHG_SEQ;
    protected CoreDecimal FINCHG_SEQ_RPT;
    protected CoreCharacter FINCHG_TYPE;
    protected CoreCharacter FINCHG_GROUP;
    protected CoreDecimal FINCHG_FACTOR;
    protected CoreDecimal DOCFTE_SEQ;
    protected CoreDecimal DOCFTE_SEQ_RPT;
    protected CoreCharacter DOCFTE_TYPE;
    protected CoreCharacter DOCFTE_GROUP;
    protected CoreDecimal DOCFTE_FACTOR;
    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF112_PYCDCEILINGS;

    private void FleF112_PYCDCEILINGS_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append("    ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_PAY_CODE")).Append(" =  '5'  ");


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
    private SqlFileObject fleF110_TOTINC;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DInteger W_DOC_YRLY_CEILING = new DInteger("W_DOC_YRLY_CEILING", 10);
    private void W_DOC_YRLY_CEILING_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING") * 100;


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
    private DInteger W_PAYPOT_AMT_GROSS = new DInteger("W_PAYPOT_AMT_GROSS", 10);
    private void W_PAYPOT_AMT_GROSS_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA") + fleF110_TOTINC.GetDecimalValue("AMT_NET");


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
    private DInteger W_PAYPOT_AMT_NET = new DInteger("W_PAYPOT_AMT_NET", 10);
    private void W_PAYPOT_AMT_NET_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = (W_PAYPOT_AMT_GROSS.Value * fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR")) / 10000;


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
    private DInteger NEW_DOC_YTDEAR = new DInteger("NEW_DOC_YTDEAR", 10);
    private void NEW_DOC_YTDEAR_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") + W_PAYPOT_AMT_NET.Value;


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
    private SqlFileObject fleDEBUGU116CD5;
    private SqlFileObject fleF110_OUTPUT_PAYPOT;
    private SqlFileObject fleF020_UPDATE;
    private DInteger X_NOT_NEEDED = new DInteger("X_NOT_NEEDED", 10);
    private void X_NOT_NEEDED_GetValue(ref decimal Value)
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
    private DCharacter X_REC_TYPE = new DCharacter("X_REC_TYPE", 1);
    private void X_REC_TYPE_GetValue(ref string Value)
    {

        try
        {
            Value = "A";


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
    private DCharacter X_COMP_CODE = new DCharacter("X_COMP_CODE", 6);
    private void X_COMP_CODE_GetValue(ref string Value)
    {

        try
        {
            Value = "PAYPOT";


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
    private SqlFileObject fleF119;


    #endregion


    #region "Standard Generated Procedures(U116_RUN_2_CALC_PAYCD_5_30)"


    #region "Automatic Item Initialization(U116_RUN_2_CALC_PAYCD_5_30)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:38:05 PM

    //#-----------------------------------------
    //# fleF110_TOTINC_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF110_TOTINC_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_TOTINC.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_TOTINC.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_TOTINC.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_TOTINC.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_TOTINC.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_TOTINC.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));

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
    //# fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF110_OUTPUT_PAYPOT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_PAYPOT.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_OUTPUT_PAYPOT.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_TOTINC.GetDecimalValue("PROCESS_SEQ"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_CODE", !Fixed, fleF110_TOTINC.GetStringValue("COMP_CODE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_TYPE", !Fixed, fleF110_TOTINC.GetStringValue("COMP_TYPE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_TOTINC.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_UNITS", !Fixed, fleF110_TOTINC.GetDecimalValue("COMP_UNITS"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_GROSS", !Fixed, fleF110_TOTINC.GetDecimalValue("AMT_GROSS"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_NET", !Fixed, fleF110_TOTINC.GetDecimalValue("AMT_NET"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_TOTINC.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_TOTINC.GetStringValue("COMPENSATION_STATUS"));
            fleF110_OUTPUT_PAYPOT.set_SetValue("FILLER", !Fixed, fleF110_TOTINC.GetStringValue("FILLER"));

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
    //# fleF020_UPDATE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6407.16120  Generated on: 9/12/2017 12:38:05 PM
    //#-----------------------------------------
    private void fleF020_UPDATE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            //TODO: Manual steps may be required.
            fleF020_UPDATE.set_SetValue("DOC_DEPT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            fleF020_UPDATE.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_123", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_123"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_456", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_456"));
            fleF020_UPDATE.set_SetValue("DOC_SIN_789", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_789"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD"));
            fleF020_UPDATE.set_SetValue("DOC_HOSP_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_HOSP_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_NAME", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME"));
            fleF020_UPDATE.set_SetValue("DOC_NAME_SOUNDEX", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME_SOUNDEX"));
            fleF020_UPDATE.set_SetValue("DOC_INIT1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1"));
            fleF020_UPDATE.set_SetValue("DOC_INIT2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2"));
            fleF020_UPDATE.set_SetValue("DOC_INIT3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_OFFICE_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_OFFICE_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_OFFICE_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC1"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC2"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC3"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC4"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC5", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_ADDR_HOME_PC5"));
            fleF020_UPDATE.set_SetValue("DOC_ADDR_HOME_PC6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADDR_HOME_PC6"));
            fleF020_UPDATE.set_SetValue("DOC_FULL_PART_IND", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_FULL_PART_IND"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_NBR"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_BRANCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_BANK_BRANCH"));
            fleF020_UPDATE.set_SetValue("DOC_BANK_ACCT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_BANK_ACCT"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_START_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_YY", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_MM", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"));
            fleF020_UPDATE.set_SetValue("DOC_DATE_FAC_TERM_DD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUB", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUB"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDGUD", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDGUD"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA"));
            fleF020_UPDATE.set_SetValue("DOC_YTDCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEAR", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC"));
            fleF020_UPDATE.set_SetValue("DOC_YTDEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEFT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_EP_DATE_DEPOSIT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_DATE_DEPOSIT"));
            fleF020_UPDATE.set_SetValue("DOC_TOTINC", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_TOTINC"));
            fleF020_UPDATE.set_SetValue("DOC_EP_CEIEXP", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_CEIEXP"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));
            fleF020_UPDATE.set_SetValue("DOC_ADJCEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEX"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEA", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEA"));
            fleF020_UPDATE.set_SetValue("DOC_CEICEX", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_CEICEX"));
            fleF020_UPDATE.set_SetValue("CEICEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("CEICEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("CEICEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEA_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEA_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("YTDCEX_PRT_FORMAT", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("YTDCEX_PRT_FORMAT"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2"));
            fleF020_UPDATE.set_SetValue("DOC_SPEC_CD_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3"));
            fleF020_UPDATE.set_SetValue("DOC_YTDINC_G", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDINC_G"));
            fleF020_UPDATE.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF020_UPDATE.set_SetValue("DOC_DEPT_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT_2"));
            fleF020_UPDATE.set_SetValue("DOC_IND_PAYS_GST", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_PAYS_GST"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_2", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_2"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_3", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_3"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_4", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_4"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_5", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_5"));
            fleF020_UPDATE.set_SetValue("DOC_NX_AVAIL_BATCH_6", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_NX_AVAIL_BATCH_6"));
            fleF020_UPDATE.set_SetValue("DOC_SUB_SPECIALTY", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_SUB_SPECIALTY"));
            fleF020_UPDATE.set_SetValue("DOC_PAYEFT", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_PAYEFT"));
            fleF020_UPDATE.set_SetValue("DOC_YTDDED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PED", !Fixed, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_EP_PED"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_EP_PAY_SUB_CODE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_EP_PAY_SUB_CODE"));
            fleF020_UPDATE.set_SetValue("DOC_PARTNERSHIP", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_PARTNERSHIP"));
            fleF020_UPDATE.set_SetValue("DOC_IND_HOLDBACK_ACTIVE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_IND_HOLDBACK_ACTIVE"));
            fleF020_UPDATE.set_SetValue("GROUP_REGULAR_SERVICE", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_REGULAR_SERVICE"));
            fleF020_UPDATE.set_SetValue("GROUP_OVER_SERVICED", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("GROUP_OVER_SERVICED"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_1_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_1_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_2_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_2_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_3_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_3_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_4_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_4_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_5_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_5_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_6_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_6_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_7_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_7_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_8_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_8_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_9_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_9_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_10_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_10_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_11_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_11_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_12_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_12_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_13_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_13_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_14_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_14_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_15_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_15_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_16_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_16_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_17_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_17_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_18_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_18_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_19_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_19_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_20_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_20_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_21_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_21_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_22_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_22_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_23_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_23_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_24_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_24_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_25_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_25_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_26_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_26_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_27_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_27_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_28_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_28_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_29_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_29_S3"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S1", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S1"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S2", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S2"));
            fleF020_UPDATE.set_SetValue("DOC_LOC_30_S3", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_LOC_30_S3"));

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


    #region "Transaction Management Procedures(U116_RUN_2_CALC_PAYCD_5_30)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:55 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF110_TOTINC.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDEBUGU116CD5.Transaction = m_trnTRANS_UPDATE;
        fleF110_OUTPUT_PAYPOT.Transaction = m_trnTRANS_UPDATE;
        fleF020_UPDATE.Transaction = m_trnTRANS_UPDATE;
        fleF119.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U116_RUN_2_CALC_PAYCD_5_30)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 9/12/2017 12:37:55 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();
            fleF112_PYCDCEILINGS.Dispose();
            fleF110_TOTINC.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleDEBUGU116CD5.Dispose();
            fleF110_OUTPUT_PAYPOT.Dispose();
            fleF020_UPDATE.Dispose();
            fleF119.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U116_RUN_2_CALC_PAYCD_5_30)"


    public void Run()
    {

        try
        {
            Request("RUN_2_CALC_PAYCD_5_30");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF112_PYCDCEILINGS.QTPForMissing("1"))
                {
                    // --> GET F112_PYCDCEILINGS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR"));

                    fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F112_PYCDCEILINGS <--

                    while (fleF110_TOTINC.QTPForMissing("2"))
                    {
                        // --> GET F110_TOTINC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF110_TOTINC.ElementOwner("EP_NBR")).Append(" = ");
                        m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                        m_strWhere.Append(" And ").Append(fleF110_TOTINC.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                        m_strWhere.Append(" And ").Append(fleF110_TOTINC.ElementOwner("PROCESS_SEQ")).Append(" = ");
                        m_strWhere.Append((TOTINC_SEQ.Value));
                        m_strWhere.Append(" And ").Append(fleF110_TOTINC.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("TOTINC"));

                        fleF110_TOTINC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F110_TOTINC <--

                        while (fleF020_DOCTOR_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F020_DOCTOR_MSTR <--


                            if (Transaction())
                            {
                                SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU116CD5, SubFileType.Keep, fleF112_PYCDCEILINGS, "EP_NBR", "DOC_NBR", "DOC_PAY_CODE", "DOC_PAY_SUB_CODE", "DOC_PAY_SUB_CODE", "FACTOR",
                                fleF020_DOCTOR_MSTR, "DOC_YTDEAR", NEW_DOC_YTDEAR, W_DOC_YRLY_CEILING, "DOC_CEICEA", fleF110_TOTINC, "AMT_NET", W_PAYPOT_AMT_GROSS, W_PAYPOT_AMT_NET);


                                fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                                fleF110_OUTPUT_PAYPOT.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                                fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_CODE", "PAYPOT");


                                fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_TYPE", QDesign.NULL(PAYPOT_TYPE.Value));


                                fleF110_OUTPUT_PAYPOT.set_SetValue("PROCESS_SEQ", PAYPOT_SEQ.Value);


                                fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR", fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));

                                if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR")) != 10000)
                                {
                                    fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR_OVERRIDE", "*");

                                }
                                else
                                {
                                    fleF110_OUTPUT_PAYPOT.set_SetValue("FACTOR_OVERRIDE", " ");

                                }


                                fleF110_OUTPUT_PAYPOT.set_SetValue("COMP_UNITS", 0);


                                fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_GROSS", W_DOC_YRLY_CEILING.Value);


                                fleF110_OUTPUT_PAYPOT.set_SetValue("AMT_NET", W_PAYPOT_AMT_NET.Value);


                                fleF110_OUTPUT_PAYPOT.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                                fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                                fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                                fleF110_OUTPUT_PAYPOT.set_SetValue("LAST_MOD_USER_ID", "U116 gen`d");

                                fleF110_OUTPUT_PAYPOT.OutPut(OutPutType.Add);


                                fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update);


                                SubFile(ref m_trnTRANS_UPDATE, ref fleF119, SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS, "DOC_NBR", X_COMP_CODE, PAYPOT_SEQ_RPT, PAYPOT_GROUP, X_REC_TYPE, NEW_DOC_YTDEAR,
                                W_PAYPOT_AMT_NET);


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
            EndRequest("RUN_2_CALC_PAYCD_5_30");

        }

    }







    #endregion


}
//RUN_2_CALC_PAYCD_5_30




