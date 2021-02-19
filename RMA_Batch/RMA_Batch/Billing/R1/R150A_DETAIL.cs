//  r150a_detail.qts 
//  2001/jan/18    Yasemin - clone from r150a.qts
//  2004/jan/20    Yasemin - add hahso, moh, rmapen, afpsti, inter, penpay,feecor
//  2005/jan/24    Yasemin - add new comp codes 36 codes after feecor            
//  2006/feb/01    yasemin - added new comp codes 12
//  2007/jan/18    yasemin - added new comp codes 8
//  2007/jun/20    yasemin - added spepay leacon uninsu covchu pace 
//  2008/jan/16    yasemin - added advanc ahsc weekend shn equpay 
//  2009/jan/14    yasemin - added 21 new comp-codes from RETCLI to DEPMED
//  2010/jan/15    yasemin - added titdef cppded prebon spepre shadow abcsta mansur
//  2011/jan/10    yasemin - added  exetax afthou diabet hghcon gstrej pathol guaran
//  2011/nov/15    yasemin - added  pda mrp ucaf wsib admin nucchr                    
//  2013/Jan/11    yasemin - added  perc pedcal cansul eftpay plasti ortho
//  2013/Jan/14    yasemin - added  BLEFEE take out PERC as per Mary
//  2014/Jan/21    yasemin - added  AGEP BASE MICA MISC0 MOHD OUTPRO
//  2014/May/16    yasemin - added  pyrfee pyrhst webhst bridge topoff blepre travel
//  2014/Jan/09    yasemin - added  perc                                                
//  2015/Feb/13    yasemin - added  MALPRA                                              
//  2016/Jan/08    yasemin - added  MICC GARNIS MANPAY
//  2016/Jan/20   MC1 - change to set lock record update
//  MC1 
//  set lock file update
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class R150A_DETAIL : BaseClassControl
{

    private R150A_DETAIL m_R150A_DETAIL;

    public R150A_DETAIL(string Name, int Level) :
            base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public R150A_DETAIL(string Name, int Level, bool Request) :
            base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if (!(m_R150A_DETAIL == null))
        {
            m_R150A_DETAIL.CloseTransactionObjects();
            m_R150A_DETAIL = null;
        }

    }

    public R150A_DETAIL GetR150A_DETAIL(int Level)
    {
        if (m_R150A_DETAIL == null)
        {
            m_R150A_DETAIL = new R150A_DETAIL("R150A_DETAIL", Level);
        }
        else
        {
            m_R150A_DETAIL.ResetValues();
        }

        return m_R150A_DETAIL;
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
            R150A_DETAIL_EXTRACT_F110_1 EXTRACT_F110_1 = new R150A_DETAIL_EXTRACT_F110_1(Name, Level);
            EXTRACT_F110_1.Run();
            EXTRACT_F110_1.Dispose();
            EXTRACT_F110_1 = null;

            R150A_DETAIL_EXTRACT_F110_HISTORY_2 EXTRACT_F110_HISTORY_2 = new R150A_DETAIL_EXTRACT_F110_HISTORY_2(Name, Level);
            EXTRACT_F110_HISTORY_2.Run();
            EXTRACT_F110_HISTORY_2.Dispose();
            EXTRACT_F110_HISTORY_2 = null;

            R150A_DETAIL_SUMMARIZE_DOC_TOTAL_3 SUMMARIZE_DOC_TOTAL_3 = new R150A_DETAIL_SUMMARIZE_DOC_TOTAL_3(Name, Level);
            SUMMARIZE_DOC_TOTAL_3.Run();
            SUMMARIZE_DOC_TOTAL_3.Dispose();
            SUMMARIZE_DOC_TOTAL_3 = null;
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
public class R150A_DETAIL_EXTRACT_F110_1 : R150A_DETAIL
{

    public R150A_DETAIL_EXTRACT_F110_1(string Name, int Level) :
            base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        W_NET_PAY = new CoreInteger("W_NET_PAY", 18, this);
        W_NET_DEDUC = new CoreInteger("W_NET_DEDUC", 18, this);
        W_NET_TAX = new CoreInteger("W_NET_TAX", 18, this);
        W_NET_PAGER = new CoreInteger("W_NET_PAGER", 18, this);
        W_NET_MEMBER = new CoreInteger("W_NET_MEMBER", 18, this);
        W_NET_OMASPC = new CoreInteger("W_NET_OMASPC", 18, this);
        W_NET_OMA = new CoreInteger("W_NET_OMA", 18, this);
        W_NET_CMPA = new CoreInteger("W_NET_CMPA", 18, this);
        W_NET_TAXREM = new CoreInteger("W_NET_TAXREM", 18, this);
        W_NET_DIRADV = new CoreInteger("W_NET_DIRADV", 18, this);
        W_NET_MOHRED = new CoreInteger("W_NET_MOHRED", 18, this);
        W_NET_OVPAY = new CoreInteger("W_NET_OVPAY", 18, this);
        W_NET_REFDOC = new CoreInteger("W_NET_REFDOC", 18, this);
        W_NET_FAMSUP = new CoreInteger("W_NET_FAMSUP", 18, this);
        W_NET_RMACHR = new CoreInteger("W_NET_RMACHR", 18, this);
        W_NET_GSTTAX = new CoreInteger("W_NET_GSTTAX", 18, this);
        W_NET_WEB = new CoreInteger("W_NET_WEB", 18, this);
        W_NET_RMAEXR = new CoreInteger("W_NET_RMAEXR", 18, this);
        W_NET_RMAEXM = new CoreInteger("W_NET_RMAEXM", 18, this);
        W_NET_GST = new CoreInteger("W_NET_GST", 18, this);
        W_NET_DEPEXR = new CoreInteger("W_NET_DEPEXR", 18, this);
        W_NET_DEPEXM = new CoreInteger("W_NET_DEPEXM", 18, this);
        W_NET_SURPLU = new CoreInteger("W_NET_SURPLU", 18, this);
        W_NET_REBATE = new CoreInteger("W_NET_REBATE", 18, this);
        W_NET_GSTREB = new CoreInteger("W_NET_GSTREB", 18, this);
        W_NET_DEPT = new CoreInteger("W_NET_DEPT", 18, this);
        W_NET_CORREC = new CoreInteger("W_NET_CORREC", 18, this);
        W_NET_LIPID = new CoreInteger("W_NET_LIPID", 18, this);
        W_NET_ICUCHR = new CoreInteger("W_NET_ICUCHR", 18, this);
        W_NET_ICUGST = new CoreInteger("W_NET_ICUGST", 18, this);
        W_NET_RCCP = new CoreInteger("W_NET_RCCP", 18, this);
        W_NET_CME = new CoreInteger("W_NET_CME", 18, this);
        W_NET_PCR = new CoreInteger("W_NET_PCR", 18, this);
        W_NET_ONCALL = new CoreInteger("W_NET_ONCALL", 18, this);
        W_NET_NEPHRO = new CoreInteger("W_NET_NEPHRO", 18, this);
        W_NET_OUTCLI = new CoreInteger("W_NET_OUTCLI", 18, this);
        W_NET_CASHED = new CoreInteger("W_NET_CASHED", 18, this);
        W_NET_SUPP = new CoreInteger("W_NET_SUPP", 18, this);
        W_NET_TAXDED = new CoreInteger("W_NET_TAXDED", 18, this);
        W_NET_DEPCHR = new CoreInteger("W_NET_DEPCHR", 18, this);
        W_NET_HAHSO = new CoreInteger("W_NET_HAHSO", 18, this);
        W_NET_MOH = new CoreInteger("W_NET_MOH", 18, this);
        W_NET_RMAPEN = new CoreInteger("W_NET_RMAPEN", 18, this);
        W_NET_AFPSTI = new CoreInteger("W_NET_AFPSTI", 18, this);
        W_NET_INTER = new CoreInteger("W_NET_INTER", 18, this);
        W_NET_PENPAY = new CoreInteger("W_NET_PENPAY", 18, this);
        W_NET_FEECOR = new CoreInteger("W_NET_FEECOR", 18, this);
        W_NET_AFP = new CoreInteger("W_NET_AFP", 18, this);
        W_NET_AFPCON = new CoreInteger("W_NET_AFPCON", 18, this);
        W_NET_DIRECT = new CoreInteger("W_NET_DIRECT", 18, this);
        W_NET_EARREF = new CoreInteger("W_NET_EARREF", 18, this);
        W_NET_EFTCAN = new CoreInteger("W_NET_EFTCAN", 18, this);
        W_NET_FAMAFP = new CoreInteger("W_NET_FAMAFP", 18, this);
        W_NET_INT = new CoreInteger("W_NET_INT", 18, this);
        W_NET_LABMED = new CoreInteger("W_NET_LABMED", 18, this);
        W_NET_LTD = new CoreInteger("W_NET_LTD", 18, this);
        W_NET_LTDINS = new CoreInteger("W_NET_LTDINS", 18, this);
        W_NET_MACPEN = new CoreInteger("W_NET_MACPEN", 18, this);
        W_NET_MANCHG = new CoreInteger("W_NET_MANCHG", 18, this);
        W_NET_MANEFT = new CoreInteger("W_NET_MANEFT", 18, this);
        W_NET_MANGST = new CoreInteger("W_NET_MANGST", 18, this);
        W_NET_MANPY = new CoreInteger("W_NET_MANPY", 18, this);
        W_NET_MANPYN = new CoreInteger("W_NET_MANPYN", 18, this);
        W_NET_MANTAX = new CoreInteger("W_NET_MANTAX", 18, this);
        W_NET_PARK = new CoreInteger("W_NET_PARK", 18, this);
        W_NET_PAYEFT = new CoreInteger("W_NET_PAYEFT", 18, this);
        W_NET_PAYRED = new CoreInteger("W_NET_PAYRED", 18, this);
        W_NET_PGPCP = new CoreInteger("W_NET_PGPCP", 18, this);
        W_NET_PSYCAP = new CoreInteger("W_NET_PSYCAP", 18, this);
        W_NET_PSYPAY = new CoreInteger("W_NET_PSYPAY", 18, this);
        W_NET_REDEFT = new CoreInteger("W_NET_REDEFT", 18, this);
        W_NET_SABBIT = new CoreInteger("W_NET_SABBIT", 18, this);
        W_NET_SAMMP = new CoreInteger("W_NET_SAMMP", 18, this);
        W_NET_SECEXP = new CoreInteger("W_NET_SECEXP", 18, this);
        W_NET_SERCHR = new CoreInteger("W_NET_SERCHR", 18, this);
        W_NET_SPETAX = new CoreInteger("W_NET_SPETAX", 18, this);
        W_NET_SURGBO = new CoreInteger("W_NET_SURGBO", 18, this);
        W_NET_TAXMAN = new CoreInteger("W_NET_TAXMAN", 18, this);
        W_NET_TAXREF = new CoreInteger("W_NET_TAXREF", 18, this);
        W_NET_MOHRET = new CoreInteger("W_NET_MOHRET", 18, this);
        W_NET_AFPRET = new CoreInteger("W_NET_AFPRET", 18, this);
        W_NET_COVARL = new CoreInteger("W_NET_COVARL", 18, this);
        W_NET_OMARET = new CoreInteger("W_NET_OMARET", 18, this);
        W_NET_TAXADJ = new CoreInteger("W_NET_TAXADJ", 18, this);
        W_NET_PRESHO = new CoreInteger("W_NET_PRESHO", 18, this);
        W_NET_TRANSP = new CoreInteger("W_NET_TRANSP", 18, this);
        W_NET_SURONC = new CoreInteger("W_NET_SURONC", 18, this);
        W_NET_OFN = new CoreInteger("W_NET_OFN", 18, this);
        W_NET_COVERA = new CoreInteger("W_NET_COVERA", 18, this);
        W_NET_PCN = new CoreInteger("W_NET_PCN", 18, this);
        W_NET_AFPFUN = new CoreInteger("W_NET_AFPFUN", 18, this);
        W_NET_BOAHON = new CoreInteger("W_NET_BOAHON", 18, this);
        W_NET_CANCEL = new CoreInteger("W_NET_CANCEL", 18, this);
        W_NET_CEIADV = new CoreInteger("W_NET_CEIADV", 18, this);
        W_NET_COMPCA = new CoreInteger("W_NET_COMPCA", 18, this);
        W_NET_EXEHON = new CoreInteger("W_NET_EXEHON", 18, this);
        W_NET_LTDDED = new CoreInteger("W_NET_LTDDED", 18, this);
        W_NET_ACAINC = new CoreInteger("W_NET_ACAINC", 18, this);
        W_NET_STIPEN = new CoreInteger("W_NET_STIPEN", 18, this);
        W_NET_RETRO = new CoreInteger("W_NET_RETRO", 18, this);
        W_NET_PACE = new CoreInteger("W_NET_PACE", 18, this);
        W_NET_UNINSU = new CoreInteger("W_NET_UNINSU", 18, this);
        W_NET_COVCHU = new CoreInteger("W_NET_COVCHU", 18, this);
        W_NET_LEACON = new CoreInteger("W_NET_LEACON", 18, this);
        W_NET_SPEPAY = new CoreInteger("W_NET_SPEPAY", 18, this);
        W_NET_ADVANC = new CoreInteger("W_NET_ADVANC", 18, this);
        W_NET_AHSC = new CoreInteger("W_NET_AHSC", 18, this);
        W_NET_WEEKEN = new CoreInteger("W_NET_WEEKEN", 18, this);
        W_NET_SHN = new CoreInteger("W_NET_SHN", 18, this);
        W_NET_EQUPAY = new CoreInteger("W_NET_EQUPAY", 18, this);
        W_NET_RETCLI = new CoreInteger("W_NET_RETCLI", 18, this);
        W_NET_SERREC = new CoreInteger("W_NET_SERREC", 18, this);
        W_NET_EDUCON = new CoreInteger("W_NET_EDUCON", 18, this);
        W_NET_NEUSRF = new CoreInteger("W_NET_NEUSRF", 18, this);
        W_NET_LABPAY = new CoreInteger("W_NET_LABPAY", 18, this);
        W_NET_REJECT = new CoreInteger("W_NET_REJECT", 18, this);
        W_NET_AFPBON = new CoreInteger("W_NET_AFPBON", 18, this);
        W_NET_RESSUP = new CoreInteger("W_NET_RESSUP", 18, this);
        W_NET_RECRUI = new CoreInteger("W_NET_RECRUI", 18, this);
        W_NET_CLIREP = new CoreInteger("W_NET_CLIREP", 18, this);
        W_NET_HOCC = new CoreInteger("W_NET_HOCC", 18, this);
        W_NET_FLOTHR = new CoreInteger("W_NET_FLOTHR", 18, this);
        W_NET_MOROVE = new CoreInteger("W_NET_MOROVE", 18, this);
        W_NET_TITHE1 = new CoreInteger("W_NET_TITHE1", 18, this);
        W_NET_TITHE2 = new CoreInteger("W_NET_TITHE2", 18, this);
        W_NET_TITHE3 = new CoreInteger("W_NET_TITHE3", 18, this);
        W_NET_DEPMEM = new CoreInteger("W_NET_DEPMEM", 18, this);
        W_NET_TITHD1 = new CoreInteger("W_NET_TITHD1", 18, this);
        W_NET_TITHD2 = new CoreInteger("W_NET_TITHD2", 18, this);
        W_NET_TITHD3 = new CoreInteger("W_NET_TITHD3", 18, this);
        W_NET_DEPMED = new CoreInteger("W_NET_DEPMED", 18, this);
        W_NET_TITDEF = new CoreInteger("W_NET_TITDEF", 18, this);
        W_NET_CPPDED = new CoreInteger("W_NET_CPPDED", 18, this);
        W_NET_PREBON = new CoreInteger("W_NET_PREBON", 18, this);
        W_NET_SPEPRE = new CoreInteger("W_NET_SPEPRE", 18, this);
        W_NET_SHADOW = new CoreInteger("W_NET_SHADOW", 18, this);
        W_NET_ABCSTA = new CoreInteger("W_NET_ABCSTA", 18, this);
        W_NET_MANSUR = new CoreInteger("W_NET_MANSUR", 18, this);
        W_NET_EXETAX = new CoreInteger("W_NET_EXETAX", 18, this);
        W_NET_AFTHOU = new CoreInteger("W_NET_AFTHOU", 18, this);
        W_NET_DIABET = new CoreInteger("W_NET_DIABET", 18, this);
        W_NET_HGHCON = new CoreInteger("W_NET_HGHCON", 18, this);
        W_NET_GSTREJ = new CoreInteger("W_NET_GSTREJ", 18, this);
        W_NET_PATHOL = new CoreInteger("W_NET_PATHOL", 18, this);
        W_NET_GUARAN = new CoreInteger("W_NET_GUARAN", 18, this);
        W_NET_PDA = new CoreInteger("W_NET_PDA", 18, this);
        W_NET_MRP = new CoreInteger("W_NET_MRP", 18, this);
        W_NET_UCAF = new CoreInteger("W_NET_UCAF", 18, this);
        W_NET_WSIB = new CoreInteger("W_NET_WSIB", 18, this);
        W_NET_ADMIN = new CoreInteger("W_NET_ADMIN", 18, this);
        W_NET_NUCCHR = new CoreInteger("W_NET_NUCCHR", 18, this);
        W_NET_NEWPAT = new CoreInteger("W_NET_NEWPAT", 18, this);
        W_NET_PEDCAL = new CoreInteger("W_NET_PEDCAL", 18, this);
        W_NET_CONSUL = new CoreInteger("W_NET_CONSUL", 18, this);
        W_NET_EFTPAY = new CoreInteger("W_NET_EFTPAY", 18, this);
        W_NET_PLASTI = new CoreInteger("W_NET_PLASTI", 18, this);
        W_NET_ORTHO = new CoreInteger("W_NET_ORTHO", 18, this);
        W_NET_BLEFEE = new CoreInteger("W_NET_BLEFEE", 18, this);
        W_NET_AGEP = new CoreInteger("W_NET_AGEP", 18, this);
        W_NET_BASE = new CoreInteger("W_NET_BASE", 18, this);
        W_NET_MICA = new CoreInteger("W_NET_MICA", 18, this);
        W_NET_MISC0 = new CoreInteger("W_NET_MISC0", 18, this);
        W_NET_MOHD = new CoreInteger("W_NET_MOHD", 18, this);
        W_NET_OUTPRO = new CoreInteger("W_NET_OUTPRO", 18, this);
        W_NET_PYRFEE = new CoreInteger("W_NET_PYRFEE", 18, this);
        W_NET_PYRHST = new CoreInteger("W_NET_PYRHST", 18, this);
        W_NET_WEBHST = new CoreInteger("W_NET_WEBHST", 18, this);
        W_NET_BRIDGE = new CoreInteger("W_NET_BRIDGE", 18, this);
        W_NET_TOPOFF = new CoreInteger("W_NET_TOPOFF", 18, this);
        W_NET_BLEPRE = new CoreInteger("W_NET_BLEPRE", 18, this);
        W_NET_TRAVEL = new CoreInteger("W_NET_TRAVEL", 18, this);
        W_NET_PERC = new CoreInteger("W_NET_PERC", 18, this);
        W_NET_MALPRA = new CoreInteger("W_NET_MALPRA", 18, this);
        W_NET_MICC = new CoreInteger("W_NET_MICC", 18, this);
        W_NET_GARNIS = new CoreInteger("W_NET_GARNIS", 18, this);
        W_NET_MANPAY = new CoreInteger("W_NET_MANPAY", 18, this);

        fleR150TEMP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R150TEMP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF110_COMPENSATION.Choose += fleF110_COMPENSATION_Choose;
    }

    private SqlFileObject fleF110_COMPENSATION;
    private SqlFileObject fleF190_COMP_CODES;

    private void fleF110_COMPENSATION_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");
            if ((!(Prompt(2).ToString() == null)
                        && (Prompt(2).ToString().Length > 0)))
            {
                strSQL.Append(fleF110_COMPENSATION.ElementOwner("EP_NBR"));
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

    private CoreInteger W_NET_PAY;
    private CoreInteger W_NET_DEDUC;
    private CoreInteger W_NET_TAX;
    private CoreInteger W_NET_PAGER;
    private CoreInteger W_NET_MEMBER;
    private CoreInteger W_NET_OMASPC;
    private CoreInteger W_NET_OMA;
    private CoreInteger W_NET_CMPA;                                    
    private CoreInteger W_NET_TAXREM;                                    
    private CoreInteger W_NET_DIRADV;                                    
    private CoreInteger W_NET_MOHRED;                                    
    private CoreInteger W_NET_OVPAY;                                    
    private CoreInteger W_NET_REFDOC;                                    
    private CoreInteger W_NET_FAMSUP;                                    
    private CoreInteger W_NET_RMACHR;                                    
    private CoreInteger W_NET_GSTTAX;
    private CoreInteger W_NET_WEB;
    private CoreInteger W_NET_RMAEXR;
    private CoreInteger W_NET_RMAEXM;
    private CoreInteger W_NET_GST;
    private CoreInteger W_NET_DEPEXR;
    private CoreInteger W_NET_DEPEXM;
    private CoreInteger W_NET_SURPLU;
    private CoreInteger W_NET_REBATE;
    private CoreInteger W_NET_GSTREB;
    private CoreInteger W_NET_DEPT;
    private CoreInteger W_NET_CORREC;
    private CoreInteger W_NET_LIPID;
    private CoreInteger W_NET_ICUCHR;
    private CoreInteger W_NET_ICUGST;
    private CoreInteger W_NET_RCCP;
    private CoreInteger W_NET_CME;
    private CoreInteger W_NET_PCR;
    private CoreInteger W_NET_ONCALL;
    private CoreInteger W_NET_NEPHRO;
    private CoreInteger W_NET_OUTCLI;
    private CoreInteger W_NET_CASHED;
    private CoreInteger W_NET_SUPP;
    private CoreInteger W_NET_TAXDED;
    private CoreInteger W_NET_DEPCHR;
    private CoreInteger W_NET_HAHSO;
    private CoreInteger W_NET_MOH;
    private CoreInteger W_NET_RMAPEN;
    private CoreInteger W_NET_AFPSTI;                                    
    private CoreInteger W_NET_INTER;                                    
    private CoreInteger W_NET_PENPAY;                                    
    private CoreInteger W_NET_FEECOR;                                    
    private CoreInteger W_NET_AFP;                                    
    private CoreInteger W_NET_AFPCON;                                    
    private CoreInteger W_NET_DIRECT;                                    
    private CoreInteger W_NET_EARREF;                                    
    private CoreInteger W_NET_EFTCAN;                                    
    private CoreInteger W_NET_FAMAFP;                                    
    private CoreInteger W_NET_INT;                                    
    private CoreInteger W_NET_LABMED;                                    
    private CoreInteger W_NET_LTD;                                    
    private CoreInteger W_NET_LTDINS;                                    
    private CoreInteger W_NET_MACPEN;                                    
    private CoreInteger W_NET_MANCHG;
    private CoreInteger W_NET_MANEFT;
    private CoreInteger W_NET_MANGST;                                    
    private CoreInteger W_NET_MANPY;                                    
    private CoreInteger W_NET_MANPYN;                                    
    private CoreInteger W_NET_MANTAX;                                    
    private CoreInteger W_NET_PARK;                                    
    private CoreInteger W_NET_PAYEFT;                                    
    private CoreInteger W_NET_PAYRED;                                    
    private CoreInteger W_NET_PGPCP;                                    
    private CoreInteger W_NET_PSYCAP;                                    
    private CoreInteger W_NET_PSYPAY;                                    
    private CoreInteger W_NET_REDEFT;                                    
    private CoreInteger W_NET_SABBIT;                                    
    private CoreInteger W_NET_SAMMP;                                    
    private CoreInteger W_NET_SECEXP;                                    
    private CoreInteger W_NET_SERCHR;                                    
    private CoreInteger W_NET_SPETAX;                                    
    private CoreInteger W_NET_SURGBO;                                    
    private CoreInteger W_NET_TAXMAN;                                    
    private CoreInteger W_NET_TAXREF;                                    
    private CoreInteger W_NET_MOHRET;                                    
    private CoreInteger W_NET_AFPRET;                                    
    private CoreInteger W_NET_COVARL;                                    
    private CoreInteger W_NET_OMARET;                                    
    private CoreInteger W_NET_TAXADJ;                                    
    private CoreInteger W_NET_PRESHO;                                    
    private CoreInteger W_NET_TRANSP;                                    
    private CoreInteger W_NET_SURONC;                                    
    private CoreInteger W_NET_OFN;                                    
    private CoreInteger W_NET_COVERA;                                    
    private CoreInteger W_NET_PCN;                                    
    private CoreInteger W_NET_AFPFUN;                                    
    private CoreInteger W_NET_BOAHON;                                    
    private CoreInteger W_NET_CANCEL;                                    
    private CoreInteger W_NET_CEIADV;                                    
    private CoreInteger W_NET_COMPCA;                                    
    private CoreInteger W_NET_EXEHON;                                    
    private CoreInteger W_NET_LTDDED;                                    
    private CoreInteger W_NET_ACAINC;                                    
    private CoreInteger W_NET_STIPEN;                                    
    private CoreInteger W_NET_RETRO;                                    
    private CoreInteger W_NET_PACE;                                    
    private CoreInteger W_NET_UNINSU;                                    
    private CoreInteger W_NET_COVCHU;                                    
    private CoreInteger W_NET_LEACON;                                    
    private CoreInteger W_NET_SPEPAY;                                    
    private CoreInteger W_NET_ADVANC;                                    
    private CoreInteger W_NET_AHSC;                                    
    private CoreInteger W_NET_WEEKEN;                                    
    private CoreInteger W_NET_SHN;                                    
    private CoreInteger W_NET_EQUPAY;                                    
    private CoreInteger W_NET_RETCLI;                                    
    private CoreInteger W_NET_SERREC;                                    
    private CoreInteger W_NET_EDUCON;                                    
    private CoreInteger W_NET_NEUSRF;                                    
    private CoreInteger W_NET_LABPAY;                                    
    private CoreInteger W_NET_REJECT;                                    
    private CoreInteger W_NET_AFPBON;                                    
    private CoreInteger W_NET_RESSUP;                                    
    private CoreInteger W_NET_RECRUI;                                    
    private CoreInteger W_NET_CLIREP;                                    
    private CoreInteger W_NET_HOCC;                                    
    private CoreInteger W_NET_FLOTHR;                                    
    private CoreInteger W_NET_MOROVE;                                    
    private CoreInteger W_NET_TITHE1;                                    
    private CoreInteger W_NET_TITHE2;                                    
    private CoreInteger W_NET_TITHE3;                                    
    private CoreInteger W_NET_DEPMEM;                                    
    private CoreInteger W_NET_TITHD1;                                    
    private CoreInteger W_NET_TITHD2;                                    
    private CoreInteger W_NET_TITHD3;                                    
    private CoreInteger W_NET_DEPMED;                                    
    private CoreInteger W_NET_TITDEF;                                    
    private CoreInteger W_NET_CPPDED;                                    
    private CoreInteger W_NET_PREBON;                                    
    private CoreInteger W_NET_SPEPRE;                                    
    private CoreInteger W_NET_SHADOW;                                    
    private CoreInteger W_NET_ABCSTA;                                    
    private CoreInteger W_NET_MANSUR;                                    
    private CoreInteger W_NET_EXETAX;                                    
    private CoreInteger W_NET_AFTHOU;                                    
    private CoreInteger W_NET_DIABET;                                    
    private CoreInteger W_NET_HGHCON;                                    
    private CoreInteger W_NET_GSTREJ;                                    
    private CoreInteger W_NET_PATHOL;                                    
    private CoreInteger W_NET_GUARAN;
    private CoreInteger W_NET_PDA;                                    
    private CoreInteger W_NET_MRP;                                    
    private CoreInteger W_NET_UCAF;                                    
    private CoreInteger W_NET_WSIB;                                    
    private CoreInteger W_NET_ADMIN;                                    
    private CoreInteger W_NET_NUCCHR;                                    
    private CoreInteger W_NET_NEWPAT;                                    
    private CoreInteger W_NET_PEDCAL;                                    
    private CoreInteger W_NET_CONSUL;                                    
    private CoreInteger W_NET_EFTPAY;                                    
    private CoreInteger W_NET_PLASTI;                                    
    private CoreInteger W_NET_ORTHO;                                    
    private CoreInteger W_NET_BLEFEE;                                    
    private CoreInteger W_NET_AGEP;                                    
    private CoreInteger W_NET_BASE;                                    
    private CoreInteger W_NET_MICA;
    private CoreInteger W_NET_MISC0;                                    
    private CoreInteger W_NET_MOHD;                                    
    private CoreInteger W_NET_OUTPRO;                                    
    private CoreInteger W_NET_PYRFEE;                                    
    private CoreInteger W_NET_PYRHST;                                    
    private CoreInteger W_NET_WEBHST;                                    
    private CoreInteger W_NET_BRIDGE;                                    
    private CoreInteger W_NET_TOPOFF;                                    
    private CoreInteger W_NET_BLEPRE;                                    
    private CoreInteger W_NET_TRAVEL;
    private CoreInteger W_NET_PERC;
    private CoreInteger W_NET_MALPRA;
    private CoreInteger W_NET_MICC;
    private CoreInteger W_NET_GARNIS;
    private CoreInteger W_NET_MANPAY;

    private SqlFileObject fleR150TEMP;

    public override bool SelectIf()
    {
        try
        {
            if (fleF190_COMP_CODES.GetStringValue("T4_NET_TAX_FLAG") == "Y" | fleF190_COMP_CODES.GetStringValue("T4_NET_PAY_FLAG") == "Y" | fleF190_COMP_CODES.GetStringValue("T4_NET_DEDUC_FLAG") == "Y")
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

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:40 AM
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
        if (Method == TransactionMethods.Rollback)
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
        fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleR150TEMP.Transaction = m_trnTRANS_UPDATE;
    }

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:40 AM
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
            fleF110_COMPENSATION.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleR150TEMP.Dispose();
        }
        catch (CustomApplicationException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;
        }

    }

    public void Run()
    {
        try
        {
            Request("EXTRACT_F110_1");
            while (fleF110_COMPENSATION.QTPForMissing())
            {
                //  --> GET F110_COMPENSATION <--
                fleF110_COMPENSATION.GetData();
                //  --> End GET F110_COMPENSATION <--
                while (fleF190_COMP_CODES.QTPForMissing("1"))
                {
                    //  --> GET F190_COMP_CODES <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));
                    fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    //  --> End GET F190_COMP_CODES <--
                    if (Transaction())
                    {    
                        if (Select_If())
                        {
                            Sort(fleF110_COMPENSATION.GetSortValue("DOC_NBR"));
                        }
                    }
                }
            }

            while (Sort(fleF110_COMPENSATION, fleF190_COMP_CODES))
            {
                if ((QDesign.NULL(fleF190_COMP_CODES.GetStringValue("T4_NET_PAY_FLAG")) == QDesign.NULL("Y")))
                {
                    W_NET_PAY.Value = (W_NET_PAY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF190_COMP_CODES.GetStringValue("T4_NET_DEDUC_FLAG")) == QDesign.NULL("Y")))
                {
                    W_NET_DEDUC.Value = (W_NET_DEDUC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF190_COMP_CODES.GetStringValue("T4_NET_TAX_FLAG")) == QDesign.NULL("Y")))
                {
                    W_NET_TAX.Value = (W_NET_TAX.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PAGER")))
                {
                    W_NET_PAGER.Value = (W_NET_PAGER.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MEMBER")))
                {
                    W_NET_MEMBER.Value = (W_NET_MEMBER.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("OMASPC")))
                {
                    W_NET_OMASPC.Value = (W_NET_OMASPC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("OMA")))
                {
                    W_NET_OMA.Value = (W_NET_OMA.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("CMPA")))
                {
                    W_NET_CMPA.Value = (W_NET_CMPA.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TAXREM")))
                {
                    W_NET_TAXREM.Value = (W_NET_TAXREM.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("DIRADV")))
                {
                    W_NET_DIRADV.Value = (W_NET_DIRADV.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MOHRED")))
                {
                    W_NET_MOHRED.Value = (W_NET_MOHRED.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("OVPAY")))
                {
                    W_NET_OVPAY.Value = (W_NET_OVPAY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("REFDOC")))
                {
                    W_NET_REFDOC.Value = (W_NET_REFDOC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("FAMSUP")))
                {
                    W_NET_FAMSUP.Value = (W_NET_FAMSUP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("RMACHR")))
                {
                    W_NET_RMACHR.Value = (W_NET_RMACHR.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("GSTTAX")))
                {
                    W_NET_GSTTAX.Value = (W_NET_GSTTAX.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("WEB")))
                {
                    W_NET_WEB.Value = (W_NET_WEB.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("RMAEXR")))
                {
                    W_NET_RMAEXR.Value = (W_NET_RMAEXR.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("RMAEXM")))
                {
                    W_NET_RMAEXM.Value = (W_NET_RMAEXM.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("GST")))
                {
                    W_NET_GST.Value = (W_NET_GST.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPEXR")))
                {
                    W_NET_DEPEXR.Value = (W_NET_DEPEXR.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPEXM")))
                {
                    W_NET_DEPEXM.Value = (W_NET_DEPEXM.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SURPLU")))
                {
                    W_NET_SURPLU.Value = (W_NET_SURPLU.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("REBATE")))
                {
                    W_NET_REBATE.Value = (W_NET_REBATE.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("GSTREB")))
                {
                    W_NET_GSTREB.Value = (W_NET_GSTREB.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPT")))
                {
                    W_NET_DEPT.Value = (W_NET_DEPT.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("CORREC")))
                {
                    W_NET_CORREC.Value = (W_NET_CORREC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("LIPID")))
                {
                    W_NET_LIPID.Value = (W_NET_LIPID.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("ICUCHR")))
                {
                    W_NET_ICUCHR.Value = (W_NET_ICUCHR.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("ICUGST")))
                {
                    W_NET_ICUGST.Value = (W_NET_ICUGST.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("RCCP")))
                {
                    W_NET_RCCP.Value = (W_NET_RCCP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("CME")))
                {
                    W_NET_CME.Value = (W_NET_CME.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PCR")))
                {
                    W_NET_PCR.Value = (W_NET_PCR.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("ONCALL")))
                {
                    W_NET_ONCALL.Value = (W_NET_ONCALL.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("NEPHRO")))
                {
                    W_NET_NEPHRO.Value = (W_NET_NEPHRO.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("OUTCLI")))
                {
                    W_NET_OUTCLI.Value = (W_NET_OUTCLI.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("CASHED")))
                {
                    W_NET_CASHED.Value = (W_NET_CASHED.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SUPP")))
                {
                    W_NET_SUPP.Value = (W_NET_SUPP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TAXDED")))
                {
                    W_NET_TAXDED.Value = (W_NET_TAXDED.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPCHR")))
                {
                    W_NET_DEPCHR.Value = (W_NET_DEPCHR.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("HAHSO")))
                {
                    W_NET_HAHSO.Value = (W_NET_HAHSO.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MOH")))
                {
                    W_NET_MOH.Value = (W_NET_MOH.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("RMAPEN")))
                {
                    W_NET_RMAPEN.Value = (W_NET_RMAPEN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("AFPSTI")))
                {
                    W_NET_AFPSTI.Value = (W_NET_AFPSTI.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("INTER")))
                {
                    W_NET_INTER.Value = (W_NET_INTER.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PENPAY")))
                {
                    W_NET_PENPAY.Value = (W_NET_PENPAY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("FEECOR")))
                {
                    W_NET_FEECOR.Value = (W_NET_FEECOR.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("AFP")))
                {
                    W_NET_AFP.Value = (W_NET_AFP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("AFPCON")))
                {
                    W_NET_AFPCON.Value = (W_NET_AFPCON.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("DIRECT")))
                {
                    W_NET_DIRECT.Value = (W_NET_DIRECT.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("EARREF")))
                {
                    W_NET_EARREF.Value = (W_NET_EARREF.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("EFTCAN")))
                {
                    W_NET_EFTCAN.Value = (W_NET_EFTCAN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("FAMAFP")))
                {
                    W_NET_FAMAFP.Value = (W_NET_FAMAFP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("INT")))
                {
                    W_NET_INT.Value = (W_NET_INT.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("LABMED")))
                {
                    W_NET_LABMED.Value = (W_NET_LABMED.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("LTD")))
                {
                    W_NET_LTD.Value = (W_NET_LTD.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("LTDINS")))
                {
                    W_NET_LTDINS.Value = (W_NET_LTDINS.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MACPEN")))
                {
                    W_NET_MACPEN.Value = (W_NET_MACPEN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MANCHG")))
                {
                    W_NET_MANCHG.Value = (W_NET_MANCHG.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MANEFT")))
                {
                    W_NET_MANEFT.Value = (W_NET_MANEFT.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MANGST")))
                {
                    W_NET_MANGST.Value = (W_NET_MANGST.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MANPY")))
                {
                    W_NET_MANPY.Value = (W_NET_MANPY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MANPYN")))
                {
                    W_NET_MANPYN.Value = (W_NET_MANPYN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MANTAX")))
                {
                    W_NET_MANTAX.Value = (W_NET_MANTAX.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PARK")))
                {
                    W_NET_PARK.Value = (W_NET_PARK.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PAYEFT")))
                {
                    W_NET_PAYEFT.Value = (W_NET_PAYEFT.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PAYRED")))
                {
                    W_NET_PAYRED.Value = (W_NET_PAYRED.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PGPCP")))
                {
                    W_NET_PGPCP.Value = (W_NET_PGPCP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PSYCAP")))
                {
                    W_NET_PSYCAP.Value = (W_NET_PSYCAP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PSYPAY")))
                {
                    W_NET_PSYPAY.Value = (W_NET_PSYPAY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("REDEFT")))
                {
                    W_NET_REDEFT.Value = (W_NET_REDEFT.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SABBIT")))
                {
                    W_NET_SABBIT.Value = (W_NET_SABBIT.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SAMMP")))
                {
                    W_NET_SAMMP.Value = (W_NET_SAMMP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SECEXP")))
                {
                    W_NET_SECEXP.Value = (W_NET_SECEXP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SERCHR")))
                {
                    W_NET_SERCHR.Value = (W_NET_SERCHR.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SPETAX")))
                {
                    W_NET_SPETAX.Value = (W_NET_SPETAX.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SURGBO")))
                {
                    W_NET_SURGBO.Value = (W_NET_SURGBO.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TAXMAN")))
                {
                    W_NET_TAXMAN.Value = (W_NET_TAXMAN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TAXREF")))
                {
                    W_NET_TAXREF.Value = (W_NET_TAXREF.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MOHRET")))
                {
                    W_NET_MOHRET.Value = (W_NET_MOHRET.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("AFPRET")))
                {
                    W_NET_AFPRET.Value = (W_NET_AFPRET.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("COVARL")))
                {
                    W_NET_COVARL.Value = (W_NET_COVARL.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("OMARET")))
                {
                    W_NET_OMARET.Value = (W_NET_OMARET.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TAXADJ")))
                {
                    W_NET_TAXADJ.Value = (W_NET_TAXADJ.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PRESHO")))
                {
                    W_NET_PRESHO.Value = (W_NET_PRESHO.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TRANSP")))
                {
                    W_NET_TRANSP.Value = (W_NET_TRANSP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SURONC")))
                {
                    W_NET_SURONC.Value = (W_NET_SURONC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("OFN")))
                {
                    W_NET_OFN.Value = (W_NET_OFN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("COVERA")))
                {
                    W_NET_COVERA.Value = (W_NET_COVERA.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PCN")))
                {
                    W_NET_PCN.Value = (W_NET_PCN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("AFPFUN")))
                {
                    W_NET_AFPFUN.Value = (W_NET_AFPFUN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("BOAHON")))
                {
                    W_NET_BOAHON.Value = (W_NET_BOAHON.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("CANCEL")))
                {
                    W_NET_CANCEL.Value = (W_NET_CANCEL.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("CEIADV")))
                {
                    W_NET_CEIADV.Value = (W_NET_CEIADV.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("COMPCA")))
                {
                    W_NET_COMPCA.Value = (W_NET_COMPCA.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("EXEHON")))
                {
                    W_NET_EXEHON.Value = (W_NET_EXEHON.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("LTDDED")))
                {
                    W_NET_LTDDED.Value = (W_NET_LTDDED.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("ACAINC")))
                {
                    W_NET_ACAINC.Value = (W_NET_ACAINC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("STIPEN")))
                {
                    W_NET_STIPEN.Value = (W_NET_STIPEN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("RETRO")))
                {
                    W_NET_RETRO.Value = (W_NET_RETRO.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PACE")))
                {
                    W_NET_PACE.Value = (W_NET_PACE.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("UNINSU")))
                {
                    W_NET_UNINSU.Value = (W_NET_UNINSU.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("COVCHU")))
                {
                    W_NET_COVCHU.Value = (W_NET_COVCHU.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("LEACON")))
                {
                    W_NET_LEACON.Value = (W_NET_LEACON.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SPEPAY")))
                {
                    W_NET_SPEPAY.Value = (W_NET_SPEPAY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("ADVANC")))
                {
                    W_NET_ADVANC.Value = (W_NET_ADVANC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("AHSC")))
                {
                    W_NET_AHSC.Value = (W_NET_AHSC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("WEEKEN")))
                {
                    W_NET_WEEKEN.Value = (W_NET_WEEKEN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SHN")))
                {
                    W_NET_SHN.Value = (W_NET_SHN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("EQUPAY")))
                {
                    W_NET_EQUPAY.Value = (W_NET_EQUPAY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("RETCLI")))
                {
                    W_NET_RETCLI.Value = (W_NET_RETCLI.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SERREC")))
                {
                    W_NET_SERREC.Value = (W_NET_SERREC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("EDUCON")))
                {
                    W_NET_EDUCON.Value = (W_NET_EDUCON.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("NEUSRF")))
                {
                    W_NET_NEUSRF.Value = (W_NET_NEUSRF.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("LABPAY")))
                {
                    W_NET_LABPAY.Value = (W_NET_LABPAY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("REJECT")))
                {
                    W_NET_REJECT.Value = (W_NET_REJECT.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("AFPBON")))
                {
                    W_NET_AFPBON.Value = (W_NET_AFPBON.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("RESSUP")))
                {
                    W_NET_RESSUP.Value = (W_NET_RESSUP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("RECRUI")))
                {
                    W_NET_RECRUI.Value = (W_NET_RECRUI.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("CLIREP")))
                {
                    W_NET_CLIREP.Value = (W_NET_CLIREP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("HOCC")))
                {
                    W_NET_HOCC.Value = (W_NET_HOCC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("FLOTHR")))
                {
                    W_NET_FLOTHR.Value = (W_NET_FLOTHR.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MOROVE")))
                {
                    W_NET_MOROVE.Value = (W_NET_MOROVE.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHE1")))
                {
                    W_NET_TITHE1.Value = (W_NET_TITHE1.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHE2")))
                {
                    W_NET_TITHE2.Value = (W_NET_TITHE2.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHE3")))
                {
                    W_NET_TITHE3.Value = (W_NET_TITHE3.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPMEM")))
                {
                    W_NET_DEPMEM.Value = (W_NET_DEPMEM.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHD1")))
                {
                    W_NET_TITHD1.Value = (W_NET_TITHD1.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHD2")))
                {
                    W_NET_TITHD2.Value = (W_NET_TITHD2.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHD3")))
                {
                    W_NET_TITHD3.Value = (W_NET_TITHD3.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPMED")))
                {
                    W_NET_DEPMED.Value = (W_NET_DEPMED.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TITDEF")))
                {
                    W_NET_TITDEF.Value = (W_NET_TITDEF.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("CPPDED")))
                {
                    W_NET_CPPDED.Value = (W_NET_CPPDED.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PREBON")))
                {
                    W_NET_PREBON.Value = (W_NET_PREBON.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SPEPRE")))
                {
                    W_NET_SPEPRE.Value = (W_NET_SPEPRE.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("SHADOW")))
                {
                    W_NET_SHADOW.Value = (W_NET_SHADOW.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("ABCSTA")))
                {
                    W_NET_ABCSTA.Value = (W_NET_ABCSTA.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MANSUR")))
                {
                    W_NET_MANSUR.Value = (W_NET_MANSUR.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("EXETAX")))
                {
                    W_NET_EXETAX.Value = (W_NET_EXETAX.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("AFTHOU")))
                {
                    W_NET_AFTHOU.Value = (W_NET_AFTHOU.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("DIABET")))
                {
                    W_NET_DIABET.Value = (W_NET_DIABET.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("HGHCON")))
                {
                    W_NET_HGHCON.Value = (W_NET_HGHCON.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("GSTREJ")))
                {
                    W_NET_GSTREJ.Value = (W_NET_GSTREJ.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PATHOL")))
                {
                    W_NET_PATHOL.Value = (W_NET_PATHOL.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("GUARAN")))
                {
                    W_NET_GUARAN.Value = (W_NET_GUARAN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PDA")))
                {
                    W_NET_PDA.Value = (W_NET_PDA.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MRP")))
                {
                    W_NET_MRP.Value = (W_NET_MRP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("UCAF")))
                {
                    W_NET_UCAF.Value = (W_NET_UCAF.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("WSIB")))
                {
                    W_NET_WSIB.Value = (W_NET_WSIB.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("ADMIN")))
                {
                    W_NET_ADMIN.Value = (W_NET_ADMIN.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("NUCCHR")))
                {
                    W_NET_NUCCHR.Value = (W_NET_NUCCHR.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("NEWPAT")))
                {
                    W_NET_NEWPAT.Value = (W_NET_NEWPAT.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PEDCAL")))
                {
                    W_NET_PEDCAL.Value = (W_NET_PEDCAL.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("CONSUL")))
                {
                    W_NET_CONSUL.Value = (W_NET_CONSUL.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("EFTPAY")))
                {
                    W_NET_EFTPAY.Value = (W_NET_EFTPAY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PLASTI")))
                {
                    W_NET_PLASTI.Value = (W_NET_PLASTI.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("ORTHO")))
                {
                    W_NET_ORTHO.Value = (W_NET_ORTHO.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("BLEFEE")))
                {
                    W_NET_BLEFEE.Value = (W_NET_BLEFEE.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("AGEP")))
                {
                    W_NET_AGEP.Value = (W_NET_AGEP.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("BASE")))
                {
                    W_NET_BASE.Value = (W_NET_BASE.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MICA")))
                {
                    W_NET_MICA.Value = (W_NET_MICA.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MISC0")))
                {
                    W_NET_MISC0.Value = (W_NET_MISC0.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MOHD")))
                {
                    W_NET_MOHD.Value = (W_NET_MOHD.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("OUTPRO")))
                {
                    W_NET_OUTPRO.Value = (W_NET_OUTPRO.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PYRFEE")))
                {
                    W_NET_PYRFEE.Value = (W_NET_PYRFEE.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PYRHST")))
                {
                    W_NET_PYRHST.Value = (W_NET_PYRHST.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("WEBHST")))
                {
                    W_NET_WEBHST.Value = (W_NET_WEBHST.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("BRIDGE")))
                {
                    W_NET_BRIDGE.Value = (W_NET_BRIDGE.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TOPOFF")))
                {
                    W_NET_TOPOFF.Value = (W_NET_TOPOFF.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("BLEPRE")))
                {
                    W_NET_BLEPRE.Value = (W_NET_BLEPRE.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("TRAVEL")))
                {
                    W_NET_TRAVEL.Value = (W_NET_TRAVEL.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("PERC")))
                {
                    W_NET_PERC.Value = (W_NET_PERC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MALPRA")))
                {
                    W_NET_MALPRA.Value = (W_NET_MALPRA.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MICC")))
                {
                    W_NET_MICC.Value = (W_NET_MICC.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("GARNIS")))
                {
                    W_NET_GARNIS.Value = (W_NET_GARNIS.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == QDesign.NULL("MANPAY")))
                {
                    W_NET_MANPAY.Value = (W_NET_MANPAY.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                }

                SubFile(ref m_trnTRANS_UPDATE, "R150TEMP", fleF110_COMPENSATION.At("DOC_NBR"), SubFileType.Keep, fleF110_COMPENSATION, "DOC_NBR", W_NET_PAY, W_NET_DEDUC, W_NET_TAX, W_NET_PAGER, W_NET_MEMBER, W_NET_OMASPC, W_NET_OMA, W_NET_CMPA, W_NET_TAXREM, W_NET_DIRADV, W_NET_MOHRED, W_NET_OVPAY, W_NET_REFDOC, W_NET_FAMSUP, W_NET_GSTTAX, W_NET_RMACHR, W_NET_WEB, W_NET_RMAEXR, W_NET_RMAEXM, W_NET_GST, W_NET_DEPEXR, W_NET_SURPLU, W_NET_REBATE, W_NET_GSTREB, W_NET_DEPT, W_NET_ICUCHR, W_NET_ICUGST, W_NET_CORREC, W_NET_LIPID, W_NET_DEPEXM, W_NET_RCCP, W_NET_CME, W_NET_PCR, W_NET_ONCALL, W_NET_NEPHRO, W_NET_OUTCLI, W_NET_CASHED, W_NET_SUPP, W_NET_TAXDED, W_NET_DEPCHR, W_NET_HAHSO, W_NET_MOH, W_NET_RMAPEN, W_NET_AFPSTI, W_NET_INTER, W_NET_PENPAY, W_NET_FEECOR, W_NET_AFP, W_NET_AFPCON, W_NET_DIRECT, W_NET_EARREF, W_NET_EFTCAN, W_NET_FAMAFP, W_NET_INT, W_NET_LABMED, W_NET_LTD, W_NET_LTDINS, W_NET_MACPEN, W_NET_MANCHG, W_NET_MANEFT, W_NET_MANGST, W_NET_MANPY, W_NET_MANPYN, W_NET_MANTAX, W_NET_PARK, W_NET_PAYEFT, W_NET_PAYRED, W_NET_PGPCP, W_NET_PSYCAP, W_NET_PSYPAY, W_NET_REDEFT, W_NET_SABBIT, W_NET_SAMMP, W_NET_SECEXP, W_NET_SERCHR, W_NET_SPETAX, W_NET_SURGBO, W_NET_TAXMAN, W_NET_TAXREF, W_NET_MOHRET, W_NET_AFPRET, W_NET_COVARL, W_NET_OMARET, W_NET_TAXADJ, W_NET_PRESHO, W_NET_TRANSP, W_NET_SURONC, W_NET_OFN, W_NET_COVERA, W_NET_PCN, W_NET_AFPFUN, W_NET_BOAHON, W_NET_CANCEL, W_NET_CEIADV, W_NET_COMPCA, W_NET_EXEHON, W_NET_LTDDED, W_NET_ACAINC, W_NET_STIPEN, W_NET_RETRO, W_NET_PACE, W_NET_UNINSU, W_NET_COVCHU, W_NET_LEACON, W_NET_SPEPAY, W_NET_ADVANC, W_NET_AHSC, W_NET_WEEKEN, W_NET_SHN, W_NET_EQUPAY, W_NET_RETCLI, W_NET_SERREC, W_NET_EDUCON, W_NET_NEUSRF, W_NET_LABPAY, W_NET_REJECT, W_NET_AFPBON, W_NET_RESSUP, W_NET_RECRUI, W_NET_CLIREP, W_NET_HOCC, W_NET_FLOTHR, W_NET_MOROVE, W_NET_TITHE1, W_NET_TITHE2, W_NET_TITHE3, W_NET_DEPMEM, W_NET_TITHD1, W_NET_TITHD2, W_NET_TITHD3, W_NET_DEPMED, W_NET_TITDEF, W_NET_CPPDED, W_NET_PREBON, W_NET_SPEPRE, W_NET_SHADOW, W_NET_ABCSTA, W_NET_MANSUR, W_NET_EXETAX, W_NET_AFTHOU, W_NET_DIABET, W_NET_HGHCON, W_NET_GSTREJ, W_NET_PATHOL, W_NET_GUARAN, W_NET_PDA, W_NET_MRP, W_NET_UCAF, W_NET_WSIB, W_NET_ADMIN, W_NET_NUCCHR, W_NET_NEWPAT, W_NET_PEDCAL, W_NET_CONSUL, W_NET_EFTPAY, W_NET_PLASTI, W_NET_ORTHO, W_NET_BLEFEE, W_NET_AGEP, W_NET_BASE, W_NET_MICA, W_NET_MISC0, W_NET_MOHD, W_NET_OUTPRO, W_NET_PYRFEE, W_NET_PYRHST, W_NET_WEBHST, W_NET_BRIDGE, W_NET_TOPOFF, W_NET_BLEPRE, W_NET_TRAVEL, W_NET_PERC, W_NET_MALPRA, W_NET_MICC, W_NET_GARNIS, W_NET_MANPAY);
                Reset(ref W_NET_PAY, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_DEDUC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TAX, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PAGER, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MEMBER, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_OMASPC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_OMA, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_CMPA, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TAXREM, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_DIRADV, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MOHRED, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_OVPAY, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_REFDOC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_FAMSUP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_RMACHR, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_GSTTAX, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_WEB, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_RMAEXR, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_RMAEXM, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_GST, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_DEPEXR, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_DEPEXM, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SURPLU, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_REBATE, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_GSTREB, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_DEPT, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_CORREC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_LIPID, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_ICUCHR, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_ICUGST, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_RCCP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_CME, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PCR, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_ONCALL, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_NEPHRO, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_OUTCLI, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_CASHED, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SUPP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TAXDED, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_DEPCHR, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_HAHSO, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MOH, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_RMAPEN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_AFPSTI, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_INTER, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PENPAY, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_FEECOR, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_AFP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_AFPCON, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_DIRECT, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_EARREF, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_EFTCAN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_FAMAFP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_INT, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_LABMED, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_LTD, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_LTDINS, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MACPEN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MANCHG, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MANEFT, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MANGST, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MANPY, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MANPYN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MANTAX, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PARK, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PAYEFT, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PAYRED, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PGPCP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PSYCAP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PSYPAY, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_REDEFT, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SABBIT, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SAMMP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SECEXP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SERCHR, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SPETAX, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SURGBO, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TAXMAN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TAXREF, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MOHRET, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_AFPRET, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_COVARL, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_OMARET, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TAXADJ, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PRESHO, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TRANSP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SURONC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_OFN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_COVERA, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PCN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_AFPFUN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_BOAHON, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_CANCEL, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_CEIADV, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_COMPCA, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_EXEHON, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_LTDDED, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_ACAINC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_STIPEN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_RETRO, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PACE, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_UNINSU, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_COVCHU, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_LEACON, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SPEPAY, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_ADVANC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_AHSC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_WEEKEN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SHN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_EQUPAY, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_RETCLI, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SERREC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_EDUCON, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_NEUSRF, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_LABPAY, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_REJECT, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_AFPBON, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_RESSUP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_RECRUI, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_CLIREP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_HOCC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_FLOTHR, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MOROVE, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TITHE1, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TITHE2, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TITHE3, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_DEPMEM, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TITHD1, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TITHD2, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TITHD3, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_DEPMED, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TITDEF, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_CPPDED, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PREBON, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SPEPRE, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_SHADOW, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_ABCSTA, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MANSUR, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_EXETAX, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_AFTHOU, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_DIABET, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_HGHCON, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_GSTREJ, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PATHOL, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_GUARAN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PDA, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MRP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_UCAF, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_WSIB, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_ADMIN, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_NUCCHR, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_NEWPAT, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PEDCAL, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_CONSUL, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_EFTPAY, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PLASTI, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_ORTHO, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_BLEFEE, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_AGEP, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_BASE, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MICA, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MISC0, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MOHD, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_OUTPRO, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PYRFEE, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PYRHST, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_WEBHST, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_BRIDGE, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TOPOFF, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_BLEPRE, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_TRAVEL, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_PERC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MALPRA, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MICC, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_GARNIS, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref W_NET_MANPAY, fleF110_COMPENSATION.At("DOC_NBR"));
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
            EndRequest("EXTRACT_F110_1");
        }

    }
}
// EXTRACT_F110_1
public class R150A_DETAIL_EXTRACT_F110_HISTORY_2 : R150A_DETAIL
{

    public R150A_DETAIL_EXTRACT_F110_HISTORY_2(string Name, int Level) :
            base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF110_COMPENSATION_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        W_NET_PAY = new CoreInteger("W_NET_PAY", 18, this);
        W_NET_DEDUC = new CoreInteger("W_NET_DEDUC", 18, this);
        W_NET_TAX = new CoreInteger("W_NET_TAX", 18, this);
        W_NET_PAGER = new CoreInteger("W_NET_PAGER", 18, this);
        W_NET_MEMBER = new CoreInteger("W_NET_MEMBER", 18, this);
        W_NET_OMASPC = new CoreInteger("W_NET_OMASPC", 18, this);
        W_NET_OMA = new CoreInteger("W_NET_OMA", 18, this);
        W_NET_CMPA = new CoreInteger("W_NET_CMPA", 18, this);
        W_NET_TAXREM = new CoreInteger("W_NET_TAXREM", 18, this);
        W_NET_DIRADV = new CoreInteger("W_NET_DIRADV", 18, this);
        W_NET_MOHRED = new CoreInteger("W_NET_MOHRED", 18, this);
        W_NET_OVPAY = new CoreInteger("W_NET_OVPAY", 18, this);
        W_NET_REFDOC = new CoreInteger("W_NET_REFDOC", 18, this);
        W_NET_FAMSUP = new CoreInteger("W_NET_FAMSUP", 18, this);
        W_NET_RMACHR = new CoreInteger("W_NET_RMACHR", 18, this);
        W_NET_GSTTAX = new CoreInteger("W_NET_GSTTAX", 18, this);
        W_NET_WEB = new CoreInteger("W_NET_WEB", 18, this);
        W_NET_RMAEXR = new CoreInteger("W_NET_RMAEXR", 18, this);
        W_NET_RMAEXM = new CoreInteger("W_NET_RMAEXM", 18, this);
        W_NET_GST = new CoreInteger("W_NET_GST", 18, this);
        W_NET_DEPEXR = new CoreInteger("W_NET_DEPEXR", 18, this);
        W_NET_DEPEXM = new CoreInteger("W_NET_DEPEXM", 18, this);
        W_NET_SURPLU = new CoreInteger("W_NET_SURPLU", 18, this);
        W_NET_REBATE = new CoreInteger("W_NET_REBATE", 18, this);
        W_NET_GSTREB = new CoreInteger("W_NET_GSTREB", 18, this);
        W_NET_DEPT = new CoreInteger("W_NET_DEPT", 18, this);
        W_NET_CORREC = new CoreInteger("W_NET_CORREC", 18, this);
        W_NET_LIPID = new CoreInteger("W_NET_LIPID", 18, this);
        W_NET_ICUCHR = new CoreInteger("W_NET_ICUCHR", 18, this);
        W_NET_ICUGST = new CoreInteger("W_NET_ICUGST", 18, this);
        W_NET_RCCP = new CoreInteger("W_NET_RCCP", 18, this);
        W_NET_CME = new CoreInteger("W_NET_CME", 18, this);
        W_NET_PCR = new CoreInteger("W_NET_PCR", 18, this);
        W_NET_ONCALL = new CoreInteger("W_NET_ONCALL", 18, this);
        W_NET_NEPHRO = new CoreInteger("W_NET_NEPHRO", 18, this);
        W_NET_OUTCLI = new CoreInteger("W_NET_OUTCLI", 18, this);
        W_NET_CASHED = new CoreInteger("W_NET_CASHED", 18, this);
        W_NET_SUPP = new CoreInteger("W_NET_SUPP", 18, this);
        W_NET_TAXDED = new CoreInteger("W_NET_TAXDED", 18, this);
        W_NET_DEPCHR = new CoreInteger("W_NET_DEPCHR", 18, this);
        W_NET_HAHSO = new CoreInteger("W_NET_HAHSO", 18, this);
        W_NET_MOH = new CoreInteger("W_NET_MOH", 18, this);
        W_NET_RMAPEN = new CoreInteger("W_NET_RMAPEN", 18, this);
        W_NET_AFPSTI = new CoreInteger("W_NET_AFPSTI", 18, this);
        W_NET_INTER = new CoreInteger("W_NET_INTER", 18, this);
        W_NET_PENPAY = new CoreInteger("W_NET_PENPAY", 18, this);
        W_NET_FEECOR = new CoreInteger("W_NET_FEECOR", 18, this);
        W_NET_AFP = new CoreInteger("W_NET_AFP", 18, this);
        W_NET_AFPCON = new CoreInteger("W_NET_AFPCON", 18, this);
        W_NET_DIRECT = new CoreInteger("W_NET_DIRECT", 18, this);
        W_NET_EARREF = new CoreInteger("W_NET_EARREF", 18, this);
        W_NET_EFTCAN = new CoreInteger("W_NET_EFTCAN", 18, this);
        W_NET_FAMAFP = new CoreInteger("W_NET_FAMAFP", 18, this);
        W_NET_INT = new CoreInteger("W_NET_INT", 18, this);
        W_NET_LABMED = new CoreInteger("W_NET_LABMED", 18, this);
        W_NET_LTD = new CoreInteger("W_NET_LTD", 18, this);
        W_NET_LTDINS = new CoreInteger("W_NET_LTDINS", 18, this);
        W_NET_MACPEN = new CoreInteger("W_NET_MACPEN", 18, this);
        W_NET_MANCHG = new CoreInteger("W_NET_MANCHG", 18, this);
        W_NET_MANEFT = new CoreInteger("W_NET_MANEFT", 18, this);
        W_NET_MANGST = new CoreInteger("W_NET_MANGST", 18, this);
        W_NET_MANPY = new CoreInteger("W_NET_MANPY", 18, this);
        W_NET_MANPYN = new CoreInteger("W_NET_MANPYN", 18, this);
        W_NET_MANTAX = new CoreInteger("W_NET_MANTAX", 18, this);
        W_NET_PARK = new CoreInteger("W_NET_PARK", 18, this);
        W_NET_PAYEFT = new CoreInteger("W_NET_PAYEFT", 18, this);
        W_NET_PAYRED = new CoreInteger("W_NET_PAYRED", 18, this);
        W_NET_PGPCP = new CoreInteger("W_NET_PGPCP", 18, this);
        W_NET_PSYCAP = new CoreInteger("W_NET_PSYCAP", 18, this);
        W_NET_PSYPAY = new CoreInteger("W_NET_PSYPAY", 18, this);
        W_NET_REDEFT = new CoreInteger("W_NET_REDEFT", 18, this);
        W_NET_SABBIT = new CoreInteger("W_NET_SABBIT", 18, this);
        W_NET_SAMMP = new CoreInteger("W_NET_SAMMP", 18, this);
        W_NET_SECEXP = new CoreInteger("W_NET_SECEXP", 18, this);
        W_NET_SERCHR = new CoreInteger("W_NET_SERCHR", 18, this);
        W_NET_SPETAX = new CoreInteger("W_NET_SPETAX", 18, this);
        W_NET_SURGBO = new CoreInteger("W_NET_SURGBO", 18, this);
        W_NET_TAXMAN = new CoreInteger("W_NET_TAXMAN", 18, this);
        W_NET_TAXREF = new CoreInteger("W_NET_TAXREF", 18, this);
        W_NET_MOHRET = new CoreInteger("W_NET_MOHRET", 18, this);
        W_NET_AFPRET = new CoreInteger("W_NET_AFPRET", 18, this);
        W_NET_COVARL = new CoreInteger("W_NET_COVARL", 18, this);
        W_NET_OMARET = new CoreInteger("W_NET_OMARET", 18, this);
        W_NET_TAXADJ = new CoreInteger("W_NET_TAXADJ", 18, this);
        W_NET_PRESHO = new CoreInteger("W_NET_PRESHO", 18, this);
        W_NET_TRANSP = new CoreInteger("W_NET_TRANSP", 18, this);
        W_NET_SURONC = new CoreInteger("W_NET_SURONC", 18, this);
        W_NET_OFN = new CoreInteger("W_NET_OFN", 18, this);
        W_NET_COVERA = new CoreInteger("W_NET_COVERA", 18, this);
        W_NET_PCN = new CoreInteger("W_NET_PCN", 18, this);
        W_NET_AFPFUN = new CoreInteger("W_NET_AFPFUN", 18, this);
        W_NET_BOAHON = new CoreInteger("W_NET_BOAHON", 18, this);
        W_NET_CANCEL = new CoreInteger("W_NET_CANCEL", 18, this);
        W_NET_CEIADV = new CoreInteger("W_NET_CEIADV", 18, this);
        W_NET_COMPCA = new CoreInteger("W_NET_COMPCA", 18, this);
        W_NET_EXEHON = new CoreInteger("W_NET_EXEHON", 18, this);
        W_NET_LTDDED = new CoreInteger("W_NET_LTDDED", 18, this);
        W_NET_ACAINC = new CoreInteger("W_NET_ACAINC", 18, this);
        W_NET_STIPEN = new CoreInteger("W_NET_STIPEN", 18, this);
        W_NET_RETRO = new CoreInteger("W_NET_RETRO", 18, this);
        W_NET_PACE = new CoreInteger("W_NET_PACE", 18, this);
        W_NET_UNINSU = new CoreInteger("W_NET_UNINSU", 18, this);
        W_NET_COVCHU = new CoreInteger("W_NET_COVCHU", 18, this);
        W_NET_LEACON = new CoreInteger("W_NET_LEACON", 18, this);
        W_NET_SPEPAY = new CoreInteger("W_NET_SPEPAY", 18, this);
        W_NET_ADVANC = new CoreInteger("W_NET_ADVANC", 18, this);
        W_NET_AHSC = new CoreInteger("W_NET_AHSC", 18, this);
        W_NET_WEEKEN = new CoreInteger("W_NET_WEEKEN", 18, this);
        W_NET_SHN = new CoreInteger("W_NET_SHN", 18, this);
        W_NET_EQUPAY = new CoreInteger("W_NET_EQUPAY", 18, this);
        W_NET_RETCLI = new CoreInteger("W_NET_RETCLI", 18, this);
        W_NET_SERREC = new CoreInteger("W_NET_SERREC", 18, this);
        W_NET_EDUCON = new CoreInteger("W_NET_EDUCON", 18, this);
        W_NET_NEUSRF = new CoreInteger("W_NET_NEUSRF", 18, this);
        W_NET_LABPAY = new CoreInteger("W_NET_LABPAY", 18, this);
        W_NET_REJECT = new CoreInteger("W_NET_REJECT", 18, this);
        W_NET_AFPBON = new CoreInteger("W_NET_AFPBON", 18, this);
        W_NET_RESSUP = new CoreInteger("W_NET_RESSUP", 18, this);
        W_NET_RECRUI = new CoreInteger("W_NET_RECRUI", 18, this);
        W_NET_CLIREP = new CoreInteger("W_NET_CLIREP", 18, this);
        W_NET_HOCC = new CoreInteger("W_NET_HOCC", 18, this);
        W_NET_FLOTHR = new CoreInteger("W_NET_FLOTHR", 18, this);
        W_NET_MOROVE = new CoreInteger("W_NET_MOROVE", 18, this);
        W_NET_TITHE1 = new CoreInteger("W_NET_TITHE1", 18, this);
        W_NET_TITHE2 = new CoreInteger("W_NET_TITHE2", 18, this);
        W_NET_TITHE3 = new CoreInteger("W_NET_TITHE3", 18, this);
        W_NET_DEPMEM = new CoreInteger("W_NET_DEPMEM", 18, this);
        W_NET_TITHD1 = new CoreInteger("W_NET_TITHD1", 18, this);
        W_NET_TITHD2 = new CoreInteger("W_NET_TITHD2", 18, this);
        W_NET_TITHD3 = new CoreInteger("W_NET_TITHD3", 18, this);
        W_NET_DEPMED = new CoreInteger("W_NET_DEPMED", 18, this);
        W_NET_TITDEF = new CoreInteger("W_NET_TITDEF", 18, this);
        W_NET_CPPDED = new CoreInteger("W_NET_CPPDED", 18, this);
        W_NET_PREBON = new CoreInteger("W_NET_PREBON", 18, this);
        W_NET_SPEPRE = new CoreInteger("W_NET_SPEPRE", 18, this);
        W_NET_SHADOW = new CoreInteger("W_NET_SHADOW", 18, this);
        W_NET_ABCSTA = new CoreInteger("W_NET_ABCSTA", 18, this);
        W_NET_MANSUR = new CoreInteger("W_NET_MANSUR", 18, this);
        W_NET_EXETAX = new CoreInteger("W_NET_EXETAX", 18, this);
        W_NET_AFTHOU = new CoreInteger("W_NET_AFTHOU", 18, this);
        W_NET_DIABET = new CoreInteger("W_NET_DIABET", 18, this);
        W_NET_HGHCON = new CoreInteger("W_NET_HGHCON", 18, this);
        W_NET_GSTREJ = new CoreInteger("W_NET_GSTREJ", 18, this);
        W_NET_PATHOL = new CoreInteger("W_NET_PATHOL", 18, this);
        W_NET_GUARAN = new CoreInteger("W_NET_GUARAN", 18, this);
        W_NET_PDA = new CoreInteger("W_NET_PDA", 18, this);
        W_NET_MRP = new CoreInteger("W_NET_MRP", 18, this);
        W_NET_UCAF = new CoreInteger("W_NET_UCAF", 18, this);
        W_NET_WSIB = new CoreInteger("W_NET_WSIB", 18, this);
        W_NET_ADMIN = new CoreInteger("W_NET_ADMIN", 18, this);
        W_NET_NUCCHR = new CoreInteger("W_NET_NUCCHR", 18, this);
        W_NET_NEWPAT = new CoreInteger("W_NET_NEWPAT", 18, this);
        W_NET_PEDCAL = new CoreInteger("W_NET_PEDCAL", 18, this);
        W_NET_CONSUL = new CoreInteger("W_NET_CONSUL", 18, this);
        W_NET_EFTPAY = new CoreInteger("W_NET_EFTPAY", 18, this);
        W_NET_PLASTI = new CoreInteger("W_NET_PLASTI", 18, this);
        W_NET_ORTHO = new CoreInteger("W_NET_ORTHO", 18, this);
        W_NET_BLEFEE = new CoreInteger("W_NET_BLEFEE", 18, this);
        W_NET_AGEP = new CoreInteger("W_NET_AGEP", 18, this);
        W_NET_BASE = new CoreInteger("W_NET_BASE", 18, this);
        W_NET_MICA = new CoreInteger("W_NET_MICA", 18, this);
        W_NET_MISC0 = new CoreInteger("W_NET_MISC0", 18, this);
        W_NET_MOHD = new CoreInteger("W_NET_MOHD", 18, this);
        W_NET_OUTPRO = new CoreInteger("W_NET_OUTPRO", 18, this);
        W_NET_PYRFEE = new CoreInteger("W_NET_PYRFEE", 18, this);
        W_NET_PYRHST = new CoreInteger("W_NET_PYRHST", 18, this);
        W_NET_WEBHST = new CoreInteger("W_NET_WEBHST", 18, this);
        W_NET_BRIDGE = new CoreInteger("W_NET_BRIDGE", 18, this);
        W_NET_TOPOFF = new CoreInteger("W_NET_TOPOFF", 18, this);
        W_NET_BLEPRE = new CoreInteger("W_NET_BLEPRE", 18, this);
        W_NET_TRAVEL = new CoreInteger("W_NET_TRAVEL", 18, this);
        W_NET_PERC = new CoreInteger("W_NET_PERC", 18, this);
        W_NET_MALPRA = new CoreInteger("W_NET_MALPRA", 18, this);
        W_NET_MICC = new CoreInteger("W_NET_MICC", 18, this);
        W_NET_GARNIS = new CoreInteger("W_NET_GARNIS", 18, this);
        W_NET_MANPAY = new CoreInteger("W_NET_MANPAY", 18, this);

        fleR150TEMP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R150TEMP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF110_COMPENSATION_HISTORY.Choose += fleF110_COMPENSATION_HISTORY_Choose;
    }
    

    private SqlFileObject fleF110_COMPENSATION_HISTORY;
    private SqlFileObject fleF190_COMP_CODES;

    private void fleF110_COMPENSATION_HISTORY_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");
            if ((!(Prompt(4) == null)
                        && (Prompt(4).ToString().Length > 0)))
            {
                strSQL.Append(fleF110_COMPENSATION_HISTORY.ElementOwner("EP_NBR"));
                strSQL.Append(" BETWEEN ");
                strSQL.Append(Prompt(3).ToString()).Append(" AND ").Append(Prompt(4));
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

    private CoreInteger W_NET_PAY;
    private CoreInteger W_NET_DEDUC;
    private CoreInteger W_NET_TAX;
    private CoreInteger W_NET_PAGER;
    private CoreInteger W_NET_MEMBER;
    private CoreInteger W_NET_OMASPC;
    private CoreInteger W_NET_OMA;
    private CoreInteger W_NET_CMPA;
    private CoreInteger W_NET_TAXREM;
    private CoreInteger W_NET_DIRADV;
    private CoreInteger W_NET_MOHRED;
    private CoreInteger W_NET_OVPAY;
    private CoreInteger W_NET_REFDOC;
    private CoreInteger W_NET_FAMSUP;
    private CoreInteger W_NET_RMACHR;
    private CoreInteger W_NET_GSTTAX;
    private CoreInteger W_NET_WEB;
    private CoreInteger W_NET_RMAEXR;
    private CoreInteger W_NET_RMAEXM;
    private CoreInteger W_NET_GST;
    private CoreInteger W_NET_DEPEXR;
    private CoreInteger W_NET_DEPEXM;
    private CoreInteger W_NET_SURPLU;                                    
    private CoreInteger W_NET_REBATE;                                    
    private CoreInteger W_NET_GSTREB;                                    
    private CoreInteger W_NET_DEPT;                                    
    private CoreInteger W_NET_CORREC;                                    
    private CoreInteger W_NET_LIPID;                                    
    private CoreInteger W_NET_ICUCHR;                                    
    private CoreInteger W_NET_ICUGST;                                    
    private CoreInteger W_NET_RCCP;                                    
    private CoreInteger W_NET_CME;                                    
    private CoreInteger W_NET_PCR;                                    
    private CoreInteger W_NET_ONCALL;                                    
    private CoreInteger W_NET_NEPHRO;                                    
    private CoreInteger W_NET_OUTCLI;                                    
    private CoreInteger W_NET_CASHED;
    private CoreInteger W_NET_SUPP;                                    
    private CoreInteger W_NET_TAXDED;                                    
    private CoreInteger W_NET_DEPCHR;                                    
    private CoreInteger W_NET_HAHSO;                                    
    private CoreInteger W_NET_MOH;                                    
    private CoreInteger W_NET_RMAPEN;                                    
    private CoreInteger W_NET_AFPSTI;                                    
    private CoreInteger W_NET_INTER;                                    
    private CoreInteger W_NET_PENPAY;                                    
    private CoreInteger W_NET_FEECOR;                                    
    private CoreInteger W_NET_AFP;                                    
    private CoreInteger W_NET_AFPCON;                                    
    private CoreInteger W_NET_DIRECT;                                    
    private CoreInteger W_NET_EARREF;                                    
    private CoreInteger W_NET_EFTCAN;                                    
    private CoreInteger W_NET_FAMAFP;                                    
    private CoreInteger W_NET_INT;                                    
    private CoreInteger W_NET_LABMED;                                    
    private CoreInteger W_NET_LTD;                                    
    private CoreInteger W_NET_LTDINS;                                    
    private CoreInteger W_NET_MACPEN;                                    
    private CoreInteger W_NET_MANCHG;                                    
    private CoreInteger W_NET_MANEFT;                                    
    private CoreInteger W_NET_MANGST;                                    
    private CoreInteger W_NET_MANPY;                                    
    private CoreInteger W_NET_MANPYN;                                    
    private CoreInteger W_NET_MANTAX;
    private CoreInteger W_NET_PARK;                                    
    private CoreInteger W_NET_PAYEFT;                                    
    private CoreInteger W_NET_PAYRED;
    private CoreInteger W_NET_PGPCP;                                     
    private CoreInteger W_NET_PSYCAP;                                    
    private CoreInteger W_NET_PSYPAY;                                    
    private CoreInteger W_NET_REDEFT;                                    
    private CoreInteger W_NET_SABBIT;                                    
    private CoreInteger W_NET_SAMMP;                                    
    private CoreInteger W_NET_SECEXP;                                    
    private CoreInteger W_NET_SERCHR;                                    
    private CoreInteger W_NET_SPETAX;                                    
    private CoreInteger W_NET_SURGBO;                                    
    private CoreInteger W_NET_TAXMAN;
    private CoreInteger W_NET_TAXREF;                                    
    private CoreInteger W_NET_MOHRET;                                    
    private CoreInteger W_NET_AFPRET;                                    
    private CoreInteger W_NET_COVARL;                                    
    private CoreInteger W_NET_OMARET;                                    
    private CoreInteger W_NET_TAXADJ;                                    
    private CoreInteger W_NET_PRESHO;                                    
    private CoreInteger W_NET_TRANSP;                                    
    private CoreInteger W_NET_SURONC;                                    
    private CoreInteger W_NET_OFN;                                    
    private CoreInteger W_NET_COVERA;                                    
    private CoreInteger W_NET_PCN;                                    
    private CoreInteger W_NET_AFPFUN;                                    
    private CoreInteger W_NET_BOAHON;                                    
    private CoreInteger W_NET_CANCEL;                                    
    private CoreInteger W_NET_CEIADV;                                    
    private CoreInteger W_NET_COMPCA;                                    
    private CoreInteger W_NET_EXEHON;                                    
    private CoreInteger W_NET_LTDDED;                                    
    private CoreInteger W_NET_ACAINC;                                    
    private CoreInteger W_NET_STIPEN;                                    
    private CoreInteger W_NET_RETRO ;                                    
    private CoreInteger W_NET_PACE;                                    
    private CoreInteger W_NET_UNINSU;                                    
    private CoreInteger W_NET_COVCHU;                                    
    private CoreInteger W_NET_LEACON;                                    
    private CoreInteger W_NET_SPEPAY;                                    
    private CoreInteger W_NET_ADVANC;                                    
    private CoreInteger W_NET_AHSC;                                    
    private CoreInteger W_NET_WEEKEN;                                    
    private CoreInteger W_NET_SHN;                                    
    private CoreInteger W_NET_EQUPAY;                                    
    private CoreInteger W_NET_RETCLI;                                    
    private CoreInteger W_NET_SERREC;                                    
    private CoreInteger W_NET_EDUCON;                                    
    private CoreInteger W_NET_NEUSRF;                                    
    private CoreInteger W_NET_LABPAY;                                    
    private CoreInteger W_NET_REJECT;                                   
    private CoreInteger W_NET_AFPBON;
    private CoreInteger W_NET_RESSUP;
    private CoreInteger W_NET_RECRUI;                                    
    private CoreInteger W_NET_CLIREP;                                    
    private CoreInteger W_NET_HOCC;                                    
    private CoreInteger W_NET_FLOTHR;                                    
    private CoreInteger W_NET_MOROVE;                                    
    private CoreInteger W_NET_TITHE1;                                    
    private CoreInteger W_NET_TITHE2;                                    
    private CoreInteger W_NET_TITHE3;
    private CoreInteger W_NET_DEPMEM;                                    
    private CoreInteger W_NET_TITHD1;                                    
    private CoreInteger W_NET_TITHD2;                                    
    private CoreInteger W_NET_TITHD3;                                    
    private CoreInteger W_NET_DEPMED;                                    
    private CoreInteger W_NET_TITDEF;                                    
    private CoreInteger W_NET_CPPDED;                                    
    private CoreInteger W_NET_PREBON;                                    
    private CoreInteger W_NET_SPEPRE;                                    
    private CoreInteger W_NET_SHADOW;                                    
    private CoreInteger W_NET_ABCSTA;                                    
    private CoreInteger W_NET_MANSUR;                                    
    private CoreInteger W_NET_EXETAX;                                    
    private CoreInteger W_NET_AFTHOU;
    private CoreInteger W_NET_DIABET;                                    
    private CoreInteger W_NET_HGHCON;                                    
    private CoreInteger W_NET_GSTREJ;                                    
    private CoreInteger W_NET_PATHOL;                                    
    private CoreInteger W_NET_GUARAN;                                    
    private CoreInteger W_NET_PDA;                                    
    private CoreInteger W_NET_MRP;                                    
    private CoreInteger W_NET_UCAF;                                    
    private CoreInteger W_NET_WSIB;                                    
    private CoreInteger W_NET_ADMIN;                                    
    private CoreInteger W_NET_NUCCHR;                                    
    private CoreInteger W_NET_NEWPAT;                                    
    private CoreInteger W_NET_PEDCAL;                                    
    private CoreInteger W_NET_CONSUL;                                    
    private CoreInteger W_NET_EFTPAY;                                    
    private CoreInteger W_NET_PLASTI;                                    
    private CoreInteger W_NET_ORTHO;                                    
    private CoreInteger W_NET_BLEFEE;                                    
    private CoreInteger W_NET_AGEP;                                    
    private CoreInteger W_NET_BASE;                                    
    private CoreInteger W_NET_MICA;                                    
    private CoreInteger W_NET_MISC0;                                    
    private CoreInteger W_NET_MOHD;                                    
    private CoreInteger W_NET_OUTPRO;                                    
    private CoreInteger W_NET_PYRFEE;                                    
    private CoreInteger W_NET_PYRHST;                                    
    private CoreInteger W_NET_WEBHST;                                    
    private CoreInteger W_NET_BRIDGE;                                    
    private CoreInteger W_NET_TOPOFF;                                    
    private CoreInteger W_NET_BLEPRE;                                    
    private CoreInteger W_NET_TRAVEL;                                    
    private CoreInteger W_NET_PERC;                                    
    private CoreInteger W_NET_MALPRA;                                    
    private CoreInteger W_NET_MICC;                                    
    private CoreInteger W_NET_GARNIS;                                    
    private CoreInteger W_NET_MANPAY;

    private SqlFileObject fleR150TEMP;

    public override bool SelectIf()
    {
        try
        {
            if (fleF190_COMP_CODES.GetStringValue("T4_NET_TAX_FLAG") == "Y" | fleF190_COMP_CODES.GetStringValue("T4_NET_PAY_FLAG") == "Y" | fleF190_COMP_CODES.GetStringValue("T4_NET_DEDUC_FLAG") == "Y")
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

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:40 AM
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
        fleF110_COMPENSATION_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleR150TEMP.Transaction = m_trnTRANS_UPDATE;
    }

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:40 AM
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
            fleF110_COMPENSATION_HISTORY.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleR150TEMP.Dispose();
        }
        catch (CustomApplicationException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;
        }

    }

    public void Run()
    {
        try
        {
            Request("EXTRACT_F110_HISTORY_2");
            while (fleF110_COMPENSATION_HISTORY.QTPForMissing())
            {
                //  --> GET F110_COMPENSATION_HISTORY <--
                fleF110_COMPENSATION_HISTORY.GetData();
                //  --> End GET F110_COMPENSATION_HISTORY <--
                while (fleF190_COMP_CODES.QTPForMissing("1"))
                {
                    //  --> GET F190_COMP_CODES <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")));
                    fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    //  --> End GET F190_COMP_CODES <--
                    if (Transaction())
                    {
                        if (Select_If())
                        {
                            Sort(fleF110_COMPENSATION_HISTORY.GetSortValue("DOC_NBR"));
                        }
                    }
                }
            }

            while (Sort(fleF110_COMPENSATION_HISTORY, fleF190_COMP_CODES))
            {
                if ((QDesign.NULL(fleF190_COMP_CODES.GetStringValue("T4_NET_PAY_FLAG")) == QDesign.NULL("Y")))
                {
                    W_NET_PAY.Value = (W_NET_PAY.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF190_COMP_CODES.GetStringValue("T4_NET_DEDUC_FLAG")) == QDesign.NULL("Y")))
                {
                    W_NET_DEDUC.Value = (W_NET_DEDUC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF190_COMP_CODES.GetStringValue("T4_NET_TAX_FLAG")) == QDesign.NULL("Y")))
                {
                    W_NET_TAX.Value = (W_NET_TAX.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PAGER")))
                {
                    W_NET_PAGER.Value = (W_NET_PAGER.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MEMBER")))
                {
                    W_NET_MEMBER.Value = (W_NET_MEMBER.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("OMASPC")))
                {
                    W_NET_OMASPC.Value = (W_NET_OMASPC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("OMA")))
                {
                    W_NET_OMA.Value = (W_NET_OMA.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("CMPA")))
                {
                    W_NET_CMPA.Value = (W_NET_CMPA.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TAXREM")))
                {
                    W_NET_TAXREM.Value = (W_NET_TAXREM.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("DIRADV")))
                {
                    W_NET_DIRADV.Value = (W_NET_DIRADV.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MOHRED")))
                {
                    W_NET_MOHRED.Value = (W_NET_MOHRED.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("OVPAY")))
                {
                    W_NET_OVPAY.Value = (W_NET_OVPAY.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("REFDOC")))
                {
                    W_NET_REFDOC.Value = (W_NET_REFDOC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("FAMSUP")))
                {
                    W_NET_FAMSUP.Value = (W_NET_FAMSUP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("RMACHR")))
                {
                    W_NET_RMACHR.Value = (W_NET_RMACHR.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("GSTTAX")))
                {
                    W_NET_GSTTAX.Value = (W_NET_GSTTAX.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("WEB")))
                {
                    W_NET_WEB.Value = (W_NET_WEB.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("RMAEXR")))
                {
                    W_NET_RMAEXR.Value = (W_NET_RMAEXR.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("RMAEXM")))
                {
                    W_NET_RMAEXM.Value = (W_NET_RMAEXM.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("GST")))
                {
                    W_NET_GST.Value = (W_NET_GST.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPEXR")))
                {
                    W_NET_DEPEXR.Value = (W_NET_DEPEXR.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPEXM")))
                {
                    W_NET_DEPEXM.Value = (W_NET_DEPEXM.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SURPLU")))
                {
                    W_NET_SURPLU.Value = (W_NET_SURPLU.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("REBATE")))
                {
                    W_NET_REBATE.Value = (W_NET_REBATE.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("GSTREB")))
                {
                    W_NET_GSTREB.Value = (W_NET_GSTREB.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPT")))
                {
                    W_NET_DEPT.Value = (W_NET_DEPT.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("CORREC")))
                {
                    W_NET_CORREC.Value = (W_NET_CORREC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("LIPID")))
                {
                    W_NET_LIPID.Value = (W_NET_LIPID.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("ICUCHR")))
                {
                    W_NET_ICUCHR.Value = (W_NET_ICUCHR.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("ICUGST")))
                {
                    W_NET_ICUGST.Value = (W_NET_ICUGST.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("RCCP")))
                {
                    W_NET_RCCP.Value = (W_NET_RCCP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("CME")))
                {
                    W_NET_CME.Value = (W_NET_CME.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PCR")))
                {
                    W_NET_PCR.Value = (W_NET_PCR.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("ONCALL")))
                {
                    W_NET_ONCALL.Value = (W_NET_ONCALL.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("NEPHRO")))
                {
                    W_NET_NEPHRO.Value = (W_NET_NEPHRO.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("OUTCLI")))
                {
                    W_NET_OUTCLI.Value = (W_NET_OUTCLI.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("CASHED")))
                {
                    W_NET_CASHED.Value = (W_NET_CASHED.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SUPP")))
                {
                    W_NET_SUPP.Value = (W_NET_SUPP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TAXDED")))
                {
                    W_NET_TAXDED.Value = (W_NET_TAXDED.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPCHR")))
                {
                    W_NET_DEPCHR.Value = (W_NET_DEPCHR.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("HAHSO")))
                {
                    W_NET_HAHSO.Value = (W_NET_HAHSO.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MOH")))
                {
                    W_NET_MOH.Value = (W_NET_MOH.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("RMAPEN")))
                {
                    W_NET_RMAPEN.Value = (W_NET_RMAPEN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("AFPSTI")))
                {
                    W_NET_AFPSTI.Value = (W_NET_AFPSTI.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("INTER")))
                {
                    W_NET_INTER.Value = (W_NET_INTER.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PENPAY")))
                {
                    W_NET_PENPAY.Value = (W_NET_PENPAY.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("FEECOR")))
                {
                    W_NET_FEECOR.Value = (W_NET_FEECOR.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("AFP")))
                {
                    W_NET_AFP.Value = (W_NET_AFP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("AFPCON")))
                {
                    W_NET_AFPCON.Value = (W_NET_AFPCON.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("DIRECT")))
                {
                    W_NET_DIRECT.Value = (W_NET_DIRECT.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("EARREF")))
                {
                    W_NET_EARREF.Value = (W_NET_EARREF.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("EFTCAN")))
                {
                    W_NET_EFTCAN.Value = (W_NET_EFTCAN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("FAMAFP")))
                {
                    W_NET_FAMAFP.Value = (W_NET_FAMAFP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("INT")))
                {
                    W_NET_INT.Value = (W_NET_INT.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("LABMED")))
                {
                    W_NET_LABMED.Value = (W_NET_LABMED.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("LTD")))
                {
                    W_NET_LTD.Value = (W_NET_LTD.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("LTDINS")))
                {
                    W_NET_LTDINS.Value = (W_NET_LTDINS.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MACPEN")))
                {
                    W_NET_MACPEN.Value = (W_NET_MACPEN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MANCHG")))
                {
                    W_NET_MANCHG.Value = (W_NET_MANCHG.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MANEFT")))
                {
                    W_NET_MANEFT.Value = (W_NET_MANEFT.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MANGST")))
                {
                    W_NET_MANGST.Value = (W_NET_MANGST.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MANPY")))
                {
                    W_NET_MANPY.Value = (W_NET_MANPY.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MANPYN")))
                {
                    W_NET_MANPYN.Value = (W_NET_MANPYN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MANTAX")))
                {
                    W_NET_MANTAX.Value = (W_NET_MANTAX.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PARK")))
                {
                    W_NET_PARK.Value = (W_NET_PARK.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PAYEFT")))
                {
                    W_NET_PAYEFT.Value = (W_NET_PAYEFT.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PAYRED")))
                {
                    W_NET_PAYRED.Value = (W_NET_PAYRED.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PGPCP")))
                {
                    W_NET_PGPCP.Value = (W_NET_PGPCP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PSYCAP")))
                {
                    W_NET_PSYCAP.Value = (W_NET_PSYCAP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PSYPAY")))
                {
                    W_NET_PSYPAY.Value = (W_NET_PSYPAY.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("REDEFT")))
                {
                    W_NET_REDEFT.Value = (W_NET_REDEFT.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SABBIT")))
                {
                    W_NET_SABBIT.Value = (W_NET_SABBIT.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SAMMP")))
                {
                    W_NET_SAMMP.Value = (W_NET_SAMMP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SECEXP")))
                {
                    W_NET_SECEXP.Value = (W_NET_SECEXP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SERCHR")))
                {
                    W_NET_SERCHR.Value = (W_NET_SERCHR.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SPETAX")))
                {
                    W_NET_SPETAX.Value = (W_NET_SPETAX.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SURGBO")))
                {
                    W_NET_SURGBO.Value = (W_NET_SURGBO.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TAXMAN")))
                {
                    W_NET_TAXMAN.Value = (W_NET_TAXMAN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TAXREF")))
                {
                    W_NET_TAXREF.Value = (W_NET_TAXREF.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MOHRET")))
                {
                    W_NET_MOHRET.Value = (W_NET_MOHRET.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("AFPRET")))
                {
                    W_NET_AFPRET.Value = (W_NET_AFPRET.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("COVARL")))
                {
                    W_NET_COVARL.Value = (W_NET_COVARL.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("OMARET")))
                {
                    W_NET_OMARET.Value = (W_NET_OMARET.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TAXADJ")))
                {
                    W_NET_TAXADJ.Value = (W_NET_TAXADJ.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PRESHO")))
                {
                    W_NET_PRESHO.Value = (W_NET_PRESHO.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TRANSP")))
                {
                    W_NET_TRANSP.Value = (W_NET_TRANSP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SURONC")))
                {
                    W_NET_SURONC.Value = (W_NET_SURONC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("OFN")))
                {
                    W_NET_OFN.Value = (W_NET_OFN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("COVERA")))
                {
                    W_NET_COVERA.Value = (W_NET_COVERA.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PCN")))
                {
                    W_NET_PCN.Value = (W_NET_PCN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("AFPFUN")))
                {
                    W_NET_AFPFUN.Value = (W_NET_AFPFUN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("BOAHON")))
                {
                    W_NET_BOAHON.Value = (W_NET_BOAHON.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("CANCEL")))
                {
                    W_NET_CANCEL.Value = (W_NET_CANCEL.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("CEIADV")))
                {
                    W_NET_CEIADV.Value = (W_NET_CEIADV.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("COMPCA")))
                {
                    W_NET_COMPCA.Value = (W_NET_COMPCA.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("EXEHON")))
                {
                    W_NET_EXEHON.Value = (W_NET_EXEHON.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("LTDDED")))
                {
                    W_NET_LTDDED.Value = (W_NET_LTDDED.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("ACAINC")))
                {
                    W_NET_ACAINC.Value = (W_NET_ACAINC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("STIPEN")))
                {
                    W_NET_STIPEN.Value = (W_NET_STIPEN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("RETRO")))
                {
                    W_NET_RETRO.Value = (W_NET_RETRO.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PACE")))
                {
                    W_NET_PACE.Value = (W_NET_PACE.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("UNINSU")))
                {
                    W_NET_UNINSU.Value = (W_NET_UNINSU.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("COVCHU")))
                {
                    W_NET_COVCHU.Value = (W_NET_COVCHU.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("LEACON")))
                {
                    W_NET_LEACON.Value = (W_NET_LEACON.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SPEPAY")))
                {
                    W_NET_SPEPAY.Value = (W_NET_SPEPAY.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("ADVANC")))
                {
                    W_NET_ADVANC.Value = (W_NET_ADVANC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("AHSC")))
                {
                    W_NET_AHSC.Value = (W_NET_AHSC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("WEEKEN")))
                {
                    W_NET_WEEKEN.Value = (W_NET_WEEKEN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SHN")))
                {
                    W_NET_SHN.Value = (W_NET_SHN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("EQUPAY")))
                {
                    W_NET_EQUPAY.Value = (W_NET_EQUPAY.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("RETCLI")))
                {
                    W_NET_RETCLI.Value = (W_NET_RETCLI.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SERREC")))
                {
                    W_NET_SERREC.Value = (W_NET_SERREC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("EDUCON")))
                {
                    W_NET_EDUCON.Value = (W_NET_EDUCON.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("NEUSRF")))
                {
                    W_NET_NEUSRF.Value = (W_NET_NEUSRF.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("LABPAY")))
                {
                    W_NET_LABPAY.Value = (W_NET_LABPAY.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("REJECT")))
                {
                    W_NET_REJECT.Value = (W_NET_REJECT.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("AFPBON")))
                {
                    W_NET_AFPBON.Value = (W_NET_AFPBON.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("RESSUP")))
                {
                    W_NET_RESSUP.Value = (W_NET_RESSUP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("RECRUI")))
                {
                    W_NET_RECRUI.Value = (W_NET_RECRUI.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("CLIREP")))
                {
                    W_NET_CLIREP.Value = (W_NET_CLIREP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("HOCC")))
                {
                    W_NET_HOCC.Value = (W_NET_HOCC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("FLOTHR")))
                {
                    W_NET_FLOTHR.Value = (W_NET_FLOTHR.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MOROVE")))
                {
                    W_NET_MOROVE.Value = (W_NET_MOROVE.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHE1")))
                {
                    W_NET_TITHE1.Value = (W_NET_TITHE1.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHE2")))
                {
                    W_NET_TITHE2.Value = (W_NET_TITHE2.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHE3")))
                {
                    W_NET_TITHE3.Value = (W_NET_TITHE3.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPMEM")))
                {
                    W_NET_DEPMEM.Value = (W_NET_DEPMEM.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHD1")))
                {
                    W_NET_TITHD1.Value = (W_NET_TITHD1.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHD2")))
                {
                    W_NET_TITHD2.Value = (W_NET_TITHD2.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TITHD3")))
                {
                    W_NET_TITHD3.Value = (W_NET_TITHD3.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("DEPMED")))
                {
                    W_NET_DEPMED.Value = (W_NET_DEPMED.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TITDEF")))
                {
                    W_NET_TITDEF.Value = (W_NET_TITDEF.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("CPPDED")))
                {
                    W_NET_CPPDED.Value = (W_NET_CPPDED.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PREBON")))
                {
                    W_NET_PREBON.Value = (W_NET_PREBON.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SPEPRE")))
                {
                    W_NET_SPEPRE.Value = (W_NET_SPEPRE.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("SHADOW")))
                {
                    W_NET_SHADOW.Value = (W_NET_SHADOW.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("ABCSTA")))
                {
                    W_NET_ABCSTA.Value = (W_NET_ABCSTA.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MANSUR")))
                {
                    W_NET_MANSUR.Value = (W_NET_MANSUR.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("EXETAX")))
                {
                    W_NET_EXETAX.Value = (W_NET_EXETAX.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("AFTHOU")))
                {
                    W_NET_AFTHOU.Value = (W_NET_AFTHOU.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("DIABET")))
                {
                    W_NET_DIABET.Value = (W_NET_DIABET.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("HGHCON")))
                {
                    W_NET_HGHCON.Value = (W_NET_HGHCON.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("GSTREJ")))
                {
                    W_NET_GSTREJ.Value = (W_NET_GSTREJ.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PATHOL")))
                {
                    W_NET_PATHOL.Value = (W_NET_PATHOL.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("GUARAN")))
                {
                    W_NET_GUARAN.Value = (W_NET_GUARAN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PDA")))
                {
                    W_NET_PDA.Value = (W_NET_PDA.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MRP")))
                {
                    W_NET_MRP.Value = (W_NET_MRP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("UCAF")))
                {
                    W_NET_UCAF.Value = (W_NET_UCAF.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("WSIB")))
                {
                    W_NET_WSIB.Value = (W_NET_WSIB.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("ADMIN")))
                {
                    W_NET_ADMIN.Value = (W_NET_ADMIN.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("NUCCHR")))
                {
                    W_NET_NUCCHR.Value = (W_NET_NUCCHR.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("NEWPAT")))
                {
                    W_NET_NEWPAT.Value = (W_NET_NEWPAT.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PEDCAL")))
                {
                    W_NET_PEDCAL.Value = (W_NET_PEDCAL.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("CONSUL")))
                {
                    W_NET_CONSUL.Value = (W_NET_CONSUL.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("EFTPAY")))
                {
                    W_NET_EFTPAY.Value = (W_NET_EFTPAY.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PLASTI")))
                {
                    W_NET_PLASTI.Value = (W_NET_PLASTI.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("ORTHO")))
                {
                    W_NET_ORTHO.Value = (W_NET_ORTHO.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("BLEFEE")))
                {
                    W_NET_BLEFEE.Value = (W_NET_BLEFEE.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("AGEP")))
                {
                    W_NET_AGEP.Value = (W_NET_AGEP.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("BASE")))
                {
                    W_NET_BASE.Value = (W_NET_BASE.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MICA")))
                {
                    W_NET_MICA.Value = (W_NET_MICA.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MISC0")))
                {
                    W_NET_MISC0.Value = (W_NET_MISC0.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MOHD")))
                {
                    W_NET_MOHD.Value = (W_NET_MOHD.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("OUTPRO")))
                {
                    W_NET_OUTPRO.Value = (W_NET_OUTPRO.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PYRFEE")))
                {
                    W_NET_PYRFEE.Value = (W_NET_PYRFEE.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PYRHST")))
                {
                    W_NET_PYRHST.Value = (W_NET_PYRHST.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("WEBHST")))
                {
                    W_NET_WEBHST.Value = (W_NET_WEBHST.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("BRIDGE")))
                {
                    W_NET_BRIDGE.Value = (W_NET_BRIDGE.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TOPOFF")))
                {
                    W_NET_TOPOFF.Value = (W_NET_TOPOFF.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("BLEPRE")))
                {
                    W_NET_BLEPRE.Value = (W_NET_BLEPRE.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("TRAVEL")))
                {
                    W_NET_TRAVEL.Value = (W_NET_TRAVEL.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("PERC")))
                {
                    W_NET_PERC.Value = (W_NET_PERC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MALPRA")))
                {
                    W_NET_MALPRA.Value = (W_NET_MALPRA.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MICC")))
                {
                    W_NET_MICC.Value = (W_NET_MICC.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("GARNIS")))
                {
                    W_NET_GARNIS.Value = (W_NET_GARNIS.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                if ((QDesign.NULL(fleF110_COMPENSATION_HISTORY.GetStringValue("COMP_CODE")) == QDesign.NULL("MANPAY")))
                {
                    W_NET_MANPAY.Value = (W_NET_MANPAY.Value + fleF110_COMPENSATION_HISTORY.GetDecimalValue("AMT_NET"));
                }

                SubFile(ref m_trnTRANS_UPDATE, "R150TEMP", fleF110_COMPENSATION_HISTORY.At("DOC_NBR"), SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION_HISTORY, "DOC_NBR", W_NET_PAY, W_NET_DEDUC, W_NET_TAX, W_NET_PAGER, W_NET_MEMBER, W_NET_OMASPC, W_NET_OMA, W_NET_CMPA, W_NET_TAXREM, W_NET_DIRADV, W_NET_MOHRED, W_NET_OVPAY, W_NET_REFDOC, W_NET_FAMSUP, W_NET_GSTTAX, W_NET_RMACHR, W_NET_WEB, W_NET_RMAEXR, W_NET_RMAEXM, W_NET_GST, W_NET_DEPEXR, W_NET_SURPLU, W_NET_REBATE, W_NET_GSTREB, W_NET_DEPT, W_NET_ICUCHR, W_NET_ICUGST, W_NET_CORREC, W_NET_LIPID, W_NET_DEPEXM, W_NET_RCCP, W_NET_CME, W_NET_PCR, W_NET_ONCALL, W_NET_NEPHRO, W_NET_OUTCLI, W_NET_CASHED, W_NET_SUPP, W_NET_TAXDED, W_NET_DEPCHR, W_NET_HAHSO, W_NET_MOH, W_NET_RMAPEN, W_NET_AFPSTI, W_NET_INTER, W_NET_PENPAY, W_NET_FEECOR, W_NET_AFP, W_NET_AFPCON, W_NET_DIRECT, W_NET_EARREF, W_NET_EFTCAN, W_NET_FAMAFP, W_NET_INT, W_NET_LABMED, W_NET_LTD, W_NET_LTDINS, W_NET_MACPEN, W_NET_MANCHG, W_NET_MANEFT, W_NET_MANGST, W_NET_MANPY, W_NET_MANPYN, W_NET_MANTAX, W_NET_PARK, W_NET_PAYEFT, W_NET_PAYRED, W_NET_PGPCP, W_NET_PSYCAP, W_NET_PSYPAY, W_NET_REDEFT, W_NET_SABBIT, W_NET_SAMMP, W_NET_SECEXP, W_NET_SERCHR, W_NET_SPETAX, W_NET_SURGBO, W_NET_TAXMAN, W_NET_TAXREF, W_NET_MOHRET, W_NET_AFPRET, W_NET_COVARL, W_NET_OMARET, W_NET_TAXADJ, W_NET_PRESHO, W_NET_TRANSP, W_NET_SURONC, W_NET_OFN, W_NET_COVERA, W_NET_PCN, W_NET_AFPFUN, W_NET_BOAHON, W_NET_CANCEL, W_NET_CEIADV, W_NET_COMPCA, W_NET_EXEHON, W_NET_LTDDED, W_NET_ACAINC, W_NET_STIPEN, W_NET_RETRO, W_NET_PACE, W_NET_UNINSU, W_NET_COVCHU, W_NET_LEACON, W_NET_SPEPAY, W_NET_ADVANC, W_NET_AHSC, W_NET_WEEKEN, W_NET_SHN, W_NET_EQUPAY, W_NET_RETCLI, W_NET_SERREC, W_NET_EDUCON, W_NET_NEUSRF, W_NET_LABPAY, W_NET_REJECT, W_NET_AFPBON, W_NET_RESSUP, W_NET_RECRUI, W_NET_CLIREP, W_NET_HOCC, W_NET_FLOTHR, W_NET_MOROVE, W_NET_TITHE1, W_NET_TITHE2, W_NET_TITHE3, W_NET_DEPMEM, W_NET_TITHD1, W_NET_TITHD2, W_NET_TITHD3, W_NET_DEPMED, W_NET_TITDEF, W_NET_CPPDED, W_NET_PREBON, W_NET_SPEPRE, W_NET_SHADOW, W_NET_ABCSTA, W_NET_MANSUR, W_NET_EXETAX, W_NET_AFTHOU, W_NET_DIABET, W_NET_HGHCON, W_NET_GSTREJ, W_NET_PATHOL, W_NET_GUARAN, W_NET_PDA, W_NET_MRP, W_NET_UCAF, W_NET_WSIB, W_NET_ADMIN, W_NET_NUCCHR, W_NET_NEWPAT, W_NET_PEDCAL, W_NET_CONSUL, W_NET_EFTPAY, W_NET_PLASTI, W_NET_ORTHO, W_NET_BLEFEE, W_NET_AGEP, W_NET_BASE, W_NET_MICA, W_NET_MISC0, W_NET_MOHD, W_NET_OUTPRO, W_NET_PYRFEE, W_NET_PYRHST, W_NET_WEBHST, W_NET_BRIDGE, W_NET_TOPOFF, W_NET_BLEPRE, W_NET_TRAVEL, W_NET_PERC, W_NET_MALPRA, W_NET_MICC, W_NET_GARNIS, W_NET_MANPAY);
                Reset(ref W_NET_PAY, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_DEDUC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TAX, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PAGER, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MEMBER, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_OMASPC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_OMA, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_CMPA, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TAXREM, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_DIRADV, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MOHRED, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_OVPAY, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_REFDOC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_FAMSUP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_RMACHR, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_GSTTAX, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_WEB, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_RMAEXR, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_RMAEXM, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_GST, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_DEPEXR, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_DEPEXM, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SURPLU, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_REBATE, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_GSTREB, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_DEPT, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_CORREC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_LIPID, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_ICUCHR, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_ICUGST, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_RCCP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_CME, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PCR, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_ONCALL, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_NEPHRO, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_OUTCLI, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_CASHED, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SUPP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TAXDED, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_DEPCHR, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_HAHSO, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MOH, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_RMAPEN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_AFPSTI, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_INTER, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PENPAY, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_FEECOR, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_AFP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_AFPCON, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_DIRECT, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_EARREF, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_EFTCAN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_FAMAFP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_INT, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_LABMED, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_LTD, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_LTDINS, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MACPEN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MANCHG, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MANEFT, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MANGST, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MANPY, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MANPYN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MANTAX, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PARK, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PAYEFT, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PAYRED, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PGPCP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PSYCAP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PSYPAY, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_REDEFT, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SABBIT, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SAMMP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SECEXP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SERCHR, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SPETAX, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SURGBO, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TAXMAN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TAXREF, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MOHRET, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_AFPRET, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_COVARL, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_OMARET, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TAXADJ, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PRESHO, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TRANSP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SURONC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_OFN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_COVERA, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PCN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_AFPFUN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_BOAHON, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_CANCEL, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_CEIADV, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_COMPCA, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_EXEHON, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_LTDDED, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_ACAINC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_STIPEN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_RETRO, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PACE, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_UNINSU, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_COVCHU, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_LEACON, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SPEPAY, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_ADVANC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_AHSC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_WEEKEN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SHN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_EQUPAY, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_RETCLI, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SERREC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_EDUCON, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_NEUSRF, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_LABPAY, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_REJECT, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_AFPBON, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_RESSUP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_RECRUI, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_CLIREP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_HOCC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_FLOTHR, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MOROVE, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TITHE1, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TITHE2, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TITHE3, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_DEPMEM, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TITHD1, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TITHD2, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TITHD3, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_DEPMED, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TITDEF, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_CPPDED, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PREBON, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SPEPRE, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_SHADOW, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_ABCSTA, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MANSUR, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_EXETAX, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_AFTHOU, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_DIABET, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_HGHCON, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_GSTREJ, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PATHOL, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_GUARAN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PDA, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MRP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_UCAF, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_WSIB, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_ADMIN, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_NUCCHR, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_NEWPAT, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PEDCAL, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_CONSUL, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_EFTPAY, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PLASTI, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_ORTHO, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_BLEFEE, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_AGEP, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_BASE, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MICA, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MISC0, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MOHD, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_OUTPRO, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PYRFEE, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PYRHST, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_WEBHST, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_BRIDGE, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TOPOFF, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_BLEPRE, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_TRAVEL, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_PERC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MALPRA, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MICC, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_GARNIS, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
                Reset(ref W_NET_MANPAY, fleF110_COMPENSATION_HISTORY.At("DOC_NBR"));
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
            EndRequest("EXTRACT_F110_HISTORY_2");
        }

    }
}
// EXTRACT_F110_HISTORY_2
public class R150A_DETAIL_SUMMARIZE_DOC_TOTAL_3 : R150A_DETAIL
{

    public R150A_DETAIL_SUMMARIZE_DOC_TOTAL_3(string Name, int Level) :
            base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleR150TEMP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R150TEMP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        T_NET_PAY = new CoreInteger("T_NET_PAY", 18, this);
        T_NET_DEDUC = new CoreInteger("T_NET_DEDUC", 18, this);
        T_NET_TAX = new CoreInteger("T_NET_TAX", 18, this);
        T_NET_PAGER = new CoreInteger("T_NET_PAGER", 18, this);
        T_NET_MEMBER = new CoreInteger("T_NET_MEMBER", 18, this);
        T_NET_OMASPC = new CoreInteger("T_NET_OMASPC", 18, this);
        T_NET_OMA = new CoreInteger("T_NET_OMA", 18, this);
        T_NET_CMPA = new CoreInteger("T_NET_CMPA", 18, this);
        T_NET_TAXREM = new CoreInteger("T_NET_TAXREM", 18, this);
        T_NET_DIRADV = new CoreInteger("T_NET_DIRADV", 18, this);
        T_NET_MOHRED = new CoreInteger("T_NET_MOHRED", 18, this);
        T_NET_OVPAY = new CoreInteger("T_NET_OVPAY", 18, this);
        T_NET_REFDOC = new CoreInteger("T_NET_REFDOC", 18, this);
        T_NET_FAMSUP = new CoreInteger("T_NET_FAMSUP", 18, this);
        T_NET_RMACHR = new CoreInteger("T_NET_RMACHR", 18, this);
        T_NET_GSTTAX = new CoreInteger("T_NET_GSTTAX", 18, this);
        T_NET_WEB = new CoreInteger("T_NET_WEB", 18, this);
        T_NET_RMAEXR = new CoreInteger("T_NET_RMAEXR", 18, this);
        T_NET_RMAEXM = new CoreInteger("T_NET_RMAEXM", 18, this);
        T_NET_GST = new CoreInteger("T_NET_GST", 18, this);
        T_NET_DEPEXR = new CoreInteger("T_NET_DEPEXR", 18, this);
        T_NET_DEPEXM = new CoreInteger("T_NET_DEPEXM", 18, this);
        T_NET_SURPLU = new CoreInteger("T_NET_SURPLU", 18, this);
        T_NET_REBATE = new CoreInteger("T_NET_REBATE", 18, this);
        T_NET_GSTREB = new CoreInteger("T_NET_GSTREB", 18, this);
        T_NET_DEPT = new CoreInteger("T_NET_DEPT", 18, this);
        T_NET_ICUCHR = new CoreInteger("T_NET_ICUCHR", 18, this);
        T_NET_ICUGST = new CoreInteger("T_NET_ICUGST", 18, this);
        T_NET_CORREC = new CoreInteger("T_NET_CORREC", 18, this);
        T_NET_LIPID = new CoreInteger("T_NET_LIPID", 18, this);
        T_NET_RCCP = new CoreInteger("T_NET_RCCP", 18, this);
        T_NET_CME = new CoreInteger("T_NET_CME", 18, this);
        T_NET_PCR = new CoreInteger("T_NET_PCR", 18, this);
        T_NET_ONCALL = new CoreInteger("T_NET_ONCALL", 18, this);
        T_NET_NEPHRO = new CoreInteger("T_NET_NEPHRO", 18, this);
        T_NET_OUTCLI = new CoreInteger("T_NET_OUTCLI", 18, this);
        T_NET_CASHED = new CoreInteger("T_NET_CASHED", 18, this);
        T_NET_SUPP = new CoreInteger("T_NET_SUPP", 18, this);
        T_NET_TAXDED = new CoreInteger("T_NET_TAXDED", 18, this);
        T_NET_DEPCHR = new CoreInteger("T_NET_DEPCHR", 18, this);
        T_NET_HAHSO = new CoreInteger("T_NET_HAHSO", 18, this);
        T_NET_MOH = new CoreInteger("T_NET_MOH", 18, this);
        T_NET_RMAPEN = new CoreInteger("T_NET_RMAPEN", 18, this);
        T_NET_AFPSTI = new CoreInteger("T_NET_AFPSTI", 18, this);
        T_NET_INTER = new CoreInteger("T_NET_INTER", 18, this);
        T_NET_PENPAY = new CoreInteger("T_NET_PENPAY", 18, this);
        T_NET_FEECOR = new CoreInteger("T_NET_FEECOR", 18, this);
        T_NET_AFP = new CoreInteger("T_NET_AFP", 18, this);
        T_NET_AFPCON = new CoreInteger("T_NET_AFPCON", 18, this);
        T_NET_DIRECT = new CoreInteger("T_NET_DIRECT", 18, this);
        T_NET_EARREF = new CoreInteger("T_NET_EARREF", 18, this);
        T_NET_EFTCAN = new CoreInteger("T_NET_EFTCAN", 18, this);
        T_NET_FAMAFP = new CoreInteger("T_NET_FAMAFP", 18, this);
        T_NET_INT = new CoreInteger("T_NET_INT", 18, this);
        T_NET_LABMED = new CoreInteger("T_NET_LABMED", 18, this);
        T_NET_LTD = new CoreInteger("T_NET_LTD", 18, this);
        T_NET_LTDINS = new CoreInteger("T_NET_LTDINS", 18, this);
        T_NET_MACPEN = new CoreInteger("T_NET_MACPEN", 18, this);
        T_NET_MANCHG = new CoreInteger("T_NET_MANCHG", 18, this);
        T_NET_MANEFT = new CoreInteger("T_NET_MANEFT", 18, this);
        T_NET_MANGST = new CoreInteger("T_NET_MANGST", 18, this);
        T_NET_MANPY = new CoreInteger("T_NET_MANPY", 18, this);
        T_NET_MANPYN = new CoreInteger("T_NET_MANPYN", 18, this);
        T_NET_MANTAX = new CoreInteger("T_NET_MANTAX", 18, this);
        T_NET_PARK = new CoreInteger("T_NET_PARK", 18, this);
        T_NET_PAYEFT = new CoreInteger("T_NET_PAYEFT", 18, this);
        T_NET_PAYRED = new CoreInteger("T_NET_PAYRED", 18, this);
        T_NET_PGPCP = new CoreInteger("T_NET_PGPCP", 18, this);
        T_NET_PSYCAP = new CoreInteger("T_NET_PSYCAP", 18, this);
        T_NET_PSYPAY = new CoreInteger("T_NET_PSYPAY", 18, this);
        T_NET_REDEFT = new CoreInteger("T_NET_REDEFT", 18, this);
        T_NET_SABBIT = new CoreInteger("T_NET_SABBIT", 18, this);
        T_NET_SAMMP = new CoreInteger("T_NET_SAMMP", 18, this);
        T_NET_SECEXP = new CoreInteger("T_NET_SECEXP", 18, this);
        T_NET_SERCHR = new CoreInteger("T_NET_SERCHR", 18, this);
        T_NET_SPETAX = new CoreInteger("T_NET_SPETAX", 18, this);
        T_NET_SURGBO = new CoreInteger("T_NET_SURGBO", 18, this);
        T_NET_TAXMAN = new CoreInteger("T_NET_TAXMAN", 18, this);
        T_NET_TAXREF = new CoreInteger("T_NET_TAXREF", 18, this);
        T_NET_MOHRET = new CoreInteger("T_NET_MOHRET", 18, this);
        T_NET_AFPRET = new CoreInteger("T_NET_AFPRET", 18, this);
        T_NET_COVARL = new CoreInteger("T_NET_COVARL", 18, this);
        T_NET_OMARET = new CoreInteger("T_NET_OMARET", 18, this);
        T_NET_TAXADJ = new CoreInteger("T_NET_TAXADJ", 18, this);
        T_NET_PRESHO = new CoreInteger("T_NET_PRESHO", 18, this);
        T_NET_TRANSP = new CoreInteger("T_NET_TRANSP", 18, this);
        T_NET_SURONC = new CoreInteger("T_NET_SURONC", 18, this);
        T_NET_OFN = new CoreInteger("T_NET_OFN", 18, this);
        T_NET_COVERA = new CoreInteger("T_NET_COVERA", 18, this);
        T_NET_PCN = new CoreInteger("T_NET_PCN", 18, this);
        T_NET_AFPFUN = new CoreInteger("T_NET_AFPFUN", 18, this);
        T_NET_BOAHON = new CoreInteger("T_NET_BOAHON", 18, this);
        T_NET_CANCEL = new CoreInteger("T_NET_CANCEL", 18, this);
        T_NET_CEIADV = new CoreInteger("T_NET_CEIADV", 18, this);
        T_NET_COMPCA = new CoreInteger("T_NET_COMPCA", 18, this);
        T_NET_EXEHON = new CoreInteger("T_NET_EXEHON", 18, this);
        T_NET_LTDDED = new CoreInteger("T_NET_LTDDED", 18, this);
        T_NET_ACAINC = new CoreInteger("T_NET_ACAINC", 18, this);
        T_NET_STIPEN = new CoreInteger("T_NET_STIPEN", 18, this);
        T_NET_RETRO = new CoreInteger("T_NET_RETRO", 18, this);
        T_NET_PACE = new CoreInteger("T_NET_PACE", 18, this);
        T_NET_UNINSU = new CoreInteger("T_NET_UNINSU", 18, this);
        T_NET_COVCHU = new CoreInteger("T_NET_COVCHU", 18, this);
        T_NET_LEACON = new CoreInteger("T_NET_LEACON", 18, this);
        T_NET_SPEPAY = new CoreInteger("T_NET_SPEPAY", 18, this);
        T_NET_ADVANC = new CoreInteger("T_NET_ADVANC", 18, this);
        T_NET_AHSC = new CoreInteger("T_NET_AHSC", 18, this);
        T_NET_WEEKEN = new CoreInteger("T_NET_WEEKEN", 18, this);
        T_NET_SHN = new CoreInteger("T_NET_SHN", 18, this);
        T_NET_EQUPAY = new CoreInteger("T_NET_EQUPAY", 18, this);
        T_NET_RETCLI = new CoreInteger("T_NET_RETCLI", 18, this);
        T_NET_SERREC = new CoreInteger("T_NET_SERREC", 18, this);
        T_NET_EDUCON = new CoreInteger("T_NET_EDUCON", 18, this);
        T_NET_NEUSRF = new CoreInteger("T_NET_NEUSRF", 18, this);
        T_NET_LABPAY = new CoreInteger("T_NET_LABPAY", 18, this);
        T_NET_REJECT = new CoreInteger("T_NET_REJECT", 18, this);
        T_NET_AFPBON = new CoreInteger("T_NET_AFPBON", 18, this);
        T_NET_RESSUP = new CoreInteger("T_NET_RESSUP", 18, this);
        T_NET_RECRUI = new CoreInteger("T_NET_RECRUI", 18, this);
        T_NET_CLIREP = new CoreInteger("T_NET_CLIREP", 18, this);
        T_NET_HOCC = new CoreInteger("T_NET_HOCC", 18, this);
        T_NET_FLOTHR = new CoreInteger("T_NET_FLOTHR", 18, this);
        T_NET_MOROVE = new CoreInteger("T_NET_MOROVE", 18, this);
        T_NET_TITHE1 = new CoreInteger("T_NET_TITHE1", 18, this);
        T_NET_TITHE2 = new CoreInteger("T_NET_TITHE2", 18, this);
        T_NET_TITHE3 = new CoreInteger("T_NET_TITHE3", 18, this);
        T_NET_DEPMEM = new CoreInteger("T_NET_DEPMEM", 18, this);
        T_NET_TITHD1 = new CoreInteger("T_NET_TITHD1", 18, this);
        T_NET_TITHD2 = new CoreInteger("T_NET_TITHD2", 18, this);
        T_NET_TITHD3 = new CoreInteger("T_NET_TITHD3", 18, this);
        T_NET_DEPMED = new CoreInteger("T_NET_DEPMED", 18, this);
        T_NET_TITDEF = new CoreInteger("T_NET_TITDEF", 18, this);
        T_NET_CPPDED = new CoreInteger("T_NET_CPPDED", 18, this);
        T_NET_PREBON = new CoreInteger("T_NET_PREBON", 18, this);
        T_NET_SPEPRE = new CoreInteger("T_NET_SPEPRE", 18, this);
        T_NET_SHADOW = new CoreInteger("T_NET_SHADOW", 18, this);
        T_NET_ABCSTA = new CoreInteger("T_NET_ABCSTA", 18, this);
        T_NET_MANSUR = new CoreInteger("T_NET_MANSUR", 18, this);
        T_NET_EXETAX = new CoreInteger("T_NET_EXETAX", 18, this);
        T_NET_AFTHOU = new CoreInteger("T_NET_AFTHOU", 18, this);
        T_NET_DIABET = new CoreInteger("T_NET_DIABET", 18, this);
        T_NET_HGHCON = new CoreInteger("T_NET_HGHCON", 18, this);
        T_NET_GSTREJ = new CoreInteger("T_NET_GSTREJ", 18, this);
        T_NET_PATHOL = new CoreInteger("T_NET_PATHOL", 18, this);
        T_NET_GUARAN = new CoreInteger("T_NET_GUARAN", 18, this);
        T_NET_PDA = new CoreInteger("T_NET_PDA", 18, this);
        T_NET_MRP = new CoreInteger("T_NET_MRP", 18, this);
        T_NET_UCAF = new CoreInteger("T_NET_UCAF", 18, this);
        T_NET_WSIB = new CoreInteger("T_NET_WSIB", 18, this);
        T_NET_ADMIN = new CoreInteger("T_NET_ADMIN", 18, this);
        T_NET_NUCCHR = new CoreInteger("T_NET_NUCCHR", 18, this);
        T_NET_NEWPAT = new CoreInteger("T_NET_NEWPAT", 18, this);
        T_NET_PEDCAL = new CoreInteger("T_NET_PEDCAL", 18, this);
        T_NET_CONSUL = new CoreInteger("T_NET_CONSUL", 18, this);
        T_NET_EFTPAY = new CoreInteger("T_NET_EFTPAY", 18, this);
        T_NET_PLASTI = new CoreInteger("T_NET_PLASTI", 18, this);
        T_NET_ORTHO = new CoreInteger("T_NET_ORTHO", 18, this);
        T_NET_BLEFEE = new CoreInteger("T_NET_BLEFEE", 18, this);
        T_NET_AGEP = new CoreInteger("T_NET_AGEP", 18, this);
        T_NET_BASE = new CoreInteger("T_NET_BASE", 18, this);
        T_NET_MICA = new CoreInteger("T_NET_MICA", 18, this);
        T_NET_MISC0 = new CoreInteger("T_NET_MISC0", 18, this);
        T_NET_MOHD = new CoreInteger("T_NET_MOHD", 18, this);
        T_NET_OUTPRO = new CoreInteger("T_NET_OUTPRO", 18, this);
        T_NET_PYRFEE = new CoreInteger("T_NET_PYRFEE", 18, this);
        T_NET_PYRHST = new CoreInteger("T_NET_PYRHST", 18, this);
        T_NET_WEBHST = new CoreInteger("T_NET_WEBHST", 18, this);
        T_NET_BRIDGE = new CoreInteger("T_NET_BRIDGE", 18, this);
        T_NET_TOPOFF = new CoreInteger("T_NET_TOPOFF", 18, this);
        T_NET_BLEPRE = new CoreInteger("T_NET_BLEPRE", 18, this);
        T_NET_TRAVEL = new CoreInteger("T_NET_TRAVEL", 18, this);
        T_NET_PERC = new CoreInteger("T_NET_PERC", 18, this);
        T_NET_MALPRA = new CoreInteger("T_NET_MALPRA", 18, this);
        T_NET_MICC = new CoreInteger("T_NET_MICC", 18, this);
        T_NET_GARNIS = new CoreInteger("T_NET_GARNIS", 18, this);
        T_NET_MANPAY = new CoreInteger("T_NET_MANPAY", 18, this);

        fleR150A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R150A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
    }

    private SqlFileObject fleR150TEMP;

    private CoreInteger T_NET_PAY;
    private CoreInteger T_NET_DEDUC;
    private CoreInteger T_NET_TAX;                                    
    private CoreInteger T_NET_PAGER ;                                    
    private CoreInteger T_NET_MEMBER;
    private CoreInteger T_NET_OMASPC;                                    
    private CoreInteger T_NET_OMA;                                    
    private CoreInteger T_NET_CMPA;                                    
    private CoreInteger T_NET_TAXREM;                                    
    private CoreInteger T_NET_DIRADV;                                    
    private CoreInteger T_NET_MOHRED;                                    
    private CoreInteger T_NET_OVPAY;                                    
    private CoreInteger T_NET_REFDOC;                                    
    private CoreInteger T_NET_FAMSUP;                                    
    private CoreInteger T_NET_RMACHR;                                    
    private CoreInteger T_NET_GSTTAX;                                    
    private CoreInteger T_NET_WEB;                                    
    private CoreInteger T_NET_RMAEXR;                                    
    private CoreInteger T_NET_RMAEXM;                                    
    private CoreInteger T_NET_GST;                                    
    private CoreInteger T_NET_DEPEXR;                                    
    private CoreInteger T_NET_DEPEXM;                                    
    private CoreInteger T_NET_SURPLU;                                    
    private CoreInteger T_NET_REBATE;                                    
    private CoreInteger T_NET_GSTREB;
    private CoreInteger T_NET_DEPT;                                    
    private CoreInteger T_NET_ICUCHR;                                    
    private CoreInteger T_NET_ICUGST;                                    
    private CoreInteger T_NET_CORREC;                                    
    private CoreInteger T_NET_LIPID;                                    
    private CoreInteger T_NET_RCCP;                                    
    private CoreInteger T_NET_CME;                                    
    private CoreInteger T_NET_PCR;                                    
    private CoreInteger T_NET_ONCALL;                                    
    private CoreInteger T_NET_NEPHRO;                                    
    private CoreInteger T_NET_OUTCLI;                                    
    private CoreInteger T_NET_CASHED;                                    
    private CoreInteger T_NET_SUPP;                                    
    private CoreInteger T_NET_TAXDED;                                    
    private CoreInteger T_NET_DEPCHR;                                    
    private CoreInteger T_NET_HAHSO;                                    
    private CoreInteger T_NET_MOH;                                    
    private CoreInteger T_NET_RMAPEN;                                    
    private CoreInteger T_NET_AFPSTI;                                    
    private CoreInteger T_NET_INTER;                                    
    private CoreInteger T_NET_PENPAY;                                   
    private CoreInteger T_NET_FEECOR;                                    
    private CoreInteger T_NET_AFP;                                    
    private CoreInteger T_NET_AFPCON;                                    
    private CoreInteger T_NET_DIRECT;                                    
    private CoreInteger T_NET_EARREF;                                    
    private CoreInteger T_NET_EFTCAN;                                    
    private CoreInteger T_NET_FAMAFP;                                    
    private CoreInteger T_NET_INT;                                    
    private CoreInteger T_NET_LABMED;                                    
    private CoreInteger T_NET_LTD;                                    
    private CoreInteger T_NET_LTDINS;
    private CoreInteger T_NET_MACPEN;                                   
    private CoreInteger T_NET_MANCHG;                                    
    private CoreInteger T_NET_MANEFT;                                    
    private CoreInteger T_NET_MANGST;                                    
    private CoreInteger T_NET_MANPY;                                    
    private CoreInteger T_NET_MANPYN;                                    
    private CoreInteger T_NET_MANTAX;                                    
    private CoreInteger T_NET_PARK;                                    
    private CoreInteger T_NET_PAYEFT;                                    
    private CoreInteger T_NET_PAYRED;                                    
    private CoreInteger T_NET_PGPCP;                                    
    private CoreInteger T_NET_PSYCAP;                                    
    private CoreInteger T_NET_PSYPAY;                                    
    private CoreInteger T_NET_REDEFT;                                    
    private CoreInteger T_NET_SABBIT;                                    
    private CoreInteger T_NET_SAMMP ;                                    
    private CoreInteger T_NET_SECEXP;                                    
    private CoreInteger T_NET_SERCHR;                                    
    private CoreInteger T_NET_SPETAX;                                    
    private CoreInteger T_NET_SURGBO;                                    
    private CoreInteger T_NET_TAXMAN;                                    
    private CoreInteger T_NET_TAXREF;                                    
    private CoreInteger T_NET_MOHRET;                                    
    private CoreInteger T_NET_AFPRET;                                    
    private CoreInteger T_NET_COVARL;                                    
    private CoreInteger T_NET_OMARET;                                    
    private CoreInteger T_NET_TAXADJ;                                    
    private CoreInteger T_NET_PRESHO;                                    
    private CoreInteger T_NET_TRANSP;                                    
    private CoreInteger T_NET_SURONC;                                    
    private CoreInteger T_NET_OFN;                                    
    private CoreInteger T_NET_COVERA;                                    
    private CoreInteger T_NET_PCN;                                    
    private CoreInteger T_NET_AFPFUN;                                    
    private CoreInteger T_NET_BOAHON;                                    
    private CoreInteger T_NET_CANCEL;                                    
    private CoreInteger T_NET_CEIADV;                                    
    private CoreInteger T_NET_COMPCA;                                    
    private CoreInteger T_NET_EXEHON;                                    
    private CoreInteger T_NET_LTDDED;                                    
    private CoreInteger T_NET_ACAINC;                                    
    private CoreInteger T_NET_STIPEN;                                    
    private CoreInteger T_NET_RETRO;                                    
    private CoreInteger T_NET_PACE;                                    
    private CoreInteger T_NET_UNINSU;                                    
    private CoreInteger T_NET_COVCHU;                                    
    private CoreInteger T_NET_LEACON;                                    
    private CoreInteger T_NET_SPEPAY;                                    
    private CoreInteger T_NET_ADVANC;                                    
    private CoreInteger T_NET_AHSC;                                    
    private CoreInteger T_NET_WEEKEN;                                    
    private CoreInteger T_NET_SHN;                                    
    private CoreInteger T_NET_EQUPAY;                                    
    private CoreInteger T_NET_RETCLI;                                    
    private CoreInteger T_NET_SERREC;                                    
    private CoreInteger T_NET_EDUCON;                                    
    private CoreInteger T_NET_NEUSRF;                                    
    private CoreInteger T_NET_LABPAY;                                    
    private CoreInteger T_NET_REJECT;                                    
    private CoreInteger T_NET_AFPBON;                                    
    private CoreInteger T_NET_RESSUP;                                    
    private CoreInteger T_NET_RECRUI;                                    
    private CoreInteger T_NET_CLIREP;                                    
    private CoreInteger T_NET_HOCC;                                    
    private CoreInteger T_NET_FLOTHR;                                    
    private CoreInteger T_NET_MOROVE;                                    
    private CoreInteger T_NET_TITHE1;                                    
    private CoreInteger T_NET_TITHE2;                                    
    private CoreInteger T_NET_TITHE3;                                    
    private CoreInteger T_NET_DEPMEM;                                    
    private CoreInteger T_NET_TITHD1;                                    
    private CoreInteger T_NET_TITHD2;                                    
    private CoreInteger T_NET_TITHD3;                                    
    private CoreInteger T_NET_DEPMED;                                    
    private CoreInteger T_NET_TITDEF;                                    
    private CoreInteger T_NET_CPPDED;                                    
    private CoreInteger T_NET_PREBON;                                    
    private CoreInteger T_NET_SPEPRE;                                    
    private CoreInteger T_NET_SHADOW;                                    
    private CoreInteger T_NET_ABCSTA;                                    
    private CoreInteger T_NET_MANSUR;                                    
    private CoreInteger T_NET_EXETAX;                                    
    private CoreInteger T_NET_AFTHOU;                                    
    private CoreInteger T_NET_DIABET;                                    
    private CoreInteger T_NET_HGHCON;                                    
    private CoreInteger T_NET_GSTREJ;                                    
    private CoreInteger T_NET_PATHOL;                                    
    private CoreInteger T_NET_GUARAN;                                    
    private CoreInteger T_NET_PDA;                                    
    private CoreInteger T_NET_MRP;                                    
    private CoreInteger T_NET_UCAF;                                    
    private CoreInteger T_NET_WSIB;                                    
    private CoreInteger T_NET_ADMIN;                                    
    private CoreInteger T_NET_NUCCHR;                                    
    private CoreInteger T_NET_NEWPAT;                                    
    private CoreInteger T_NET_PEDCAL;                                    
    private CoreInteger T_NET_CONSUL;                                    
    private CoreInteger T_NET_EFTPAY;                                   
    private CoreInteger T_NET_PLASTI;                                    
    private CoreInteger T_NET_ORTHO;                                    
    private CoreInteger T_NET_BLEFEE;                                    
    private CoreInteger T_NET_AGEP;                                    
    private CoreInteger T_NET_BASE;                                    
    private CoreInteger T_NET_MICA;                                    
    private CoreInteger T_NET_MISC0;
    private CoreInteger T_NET_MOHD;                                    
    private CoreInteger T_NET_OUTPRO;                                    
    private CoreInteger T_NET_PYRFEE;                                    
    private CoreInteger T_NET_PYRHST;                                    
    private CoreInteger T_NET_WEBHST;                                    
    private CoreInteger T_NET_BRIDGE;                                    
    private CoreInteger T_NET_TOPOFF;                                   
    private CoreInteger T_NET_BLEPRE;                                    
    private CoreInteger T_NET_TRAVEL;                                    
    private CoreInteger T_NET_PERC;                                    
    private CoreInteger T_NET_MALPRA;                                    
    private CoreInteger T_NET_MICC;                                    
    private CoreInteger T_NET_GARNIS;                                    
    private CoreInteger T_NET_MANPAY;

    private SqlFileObject fleR150A;

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:40 AM
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
        fleR150TEMP.Transaction = m_trnTRANS_UPDATE;
        fleR150A.Transaction = m_trnTRANS_UPDATE;
    }

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-08-13 8:04:40 AM
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
            fleR150TEMP.Dispose();
            fleR150A.Dispose();
        }
        catch (CustomApplicationException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            ExceptionManager.Publish(ex);
            throw ex;
        }

    }

    public void Run()
    {
        try
        {
            Request("SUMMARIZE_DOC_TOTAL_3");
            while (fleR150TEMP.QTPForMissing())
            {
                //  --> GET R150TEMP <--
                fleR150TEMP.GetData();
                //  --> End GET R150TEMP <--
                if (Transaction())
                {
                    Sort(fleR150TEMP.GetSortValue("DOC_NBR"));
                }

            }

            while (Sort(fleR150TEMP))
            {
                T_NET_PAY.Value = (T_NET_PAY.Value + fleR150TEMP.GetDecimalValue("W_NET_PAY"));
                T_NET_DEDUC.Value = (T_NET_DEDUC.Value + fleR150TEMP.GetDecimalValue("W_NET_DEDUC"));
                T_NET_TAX.Value = (T_NET_TAX.Value + fleR150TEMP.GetDecimalValue("W_NET_TAX"));
                T_NET_PAGER.Value = (T_NET_PAGER.Value + fleR150TEMP.GetDecimalValue("W_NET_PAGER"));
                T_NET_MEMBER.Value = (T_NET_MEMBER.Value + fleR150TEMP.GetDecimalValue("W_NET_MEMBER"));
                T_NET_OMASPC.Value = (T_NET_OMASPC.Value + fleR150TEMP.GetDecimalValue("W_NET_OMASPC"));
                T_NET_OMA.Value = (T_NET_OMA.Value + fleR150TEMP.GetDecimalValue("W_NET_OMA"));
                T_NET_CMPA.Value = (T_NET_CMPA.Value + fleR150TEMP.GetDecimalValue("W_NET_CMPA"));
                T_NET_TAXREM.Value = (T_NET_TAXREM.Value + fleR150TEMP.GetDecimalValue("W_NET_TAXREM"));
                T_NET_DIRADV.Value = (T_NET_DIRADV.Value + fleR150TEMP.GetDecimalValue("W_NET_DIRADV"));
                T_NET_MOHRED.Value = (T_NET_MOHRED.Value + fleR150TEMP.GetDecimalValue("W_NET_MOHRED"));
                T_NET_OVPAY.Value = (T_NET_OVPAY.Value + fleR150TEMP.GetDecimalValue("W_NET_OVPAY"));
                T_NET_REFDOC.Value = (T_NET_REFDOC.Value + fleR150TEMP.GetDecimalValue("W_NET_REFDOC"));
                T_NET_FAMSUP.Value = (T_NET_FAMSUP.Value + fleR150TEMP.GetDecimalValue("W_NET_FAMSUP"));
                T_NET_RMACHR.Value = (T_NET_RMACHR.Value + fleR150TEMP.GetDecimalValue("W_NET_RMACHR"));
                T_NET_GSTTAX.Value = (T_NET_GSTTAX.Value + fleR150TEMP.GetDecimalValue("W_NET_GSTTAX"));
                T_NET_WEB.Value = (T_NET_WEB.Value + fleR150TEMP.GetDecimalValue("W_NET_WEB"));
                T_NET_RMAEXR.Value = (T_NET_RMAEXR.Value + fleR150TEMP.GetDecimalValue("W_NET_RMAEXR"));
                T_NET_RMAEXM.Value = (T_NET_RMAEXM.Value + fleR150TEMP.GetDecimalValue("W_NET_RMAEXM"));
                T_NET_GST.Value = (T_NET_GST.Value + fleR150TEMP.GetDecimalValue("W_NET_GST"));
                T_NET_DEPEXR.Value = (T_NET_DEPEXR.Value + fleR150TEMP.GetDecimalValue("W_NET_DEPEXR"));
                T_NET_DEPEXM.Value = (T_NET_DEPEXM.Value + fleR150TEMP.GetDecimalValue("W_NET_DEPEXM"));
                T_NET_SURPLU.Value = (T_NET_SURPLU.Value + fleR150TEMP.GetDecimalValue("W_NET_SURPLU"));
                T_NET_REBATE.Value = (T_NET_REBATE.Value + fleR150TEMP.GetDecimalValue("W_NET_REBATE"));
                T_NET_GSTREB.Value = (T_NET_GSTREB.Value + fleR150TEMP.GetDecimalValue("W_NET_GSTREB"));
                T_NET_DEPT.Value = (T_NET_DEPT.Value + fleR150TEMP.GetDecimalValue("W_NET_DEPT"));
                T_NET_ICUCHR.Value = (T_NET_ICUCHR.Value + fleR150TEMP.GetDecimalValue("W_NET_ICUCHR"));
                T_NET_ICUGST.Value = (T_NET_ICUGST.Value + fleR150TEMP.GetDecimalValue("W_NET_ICUGST"));
                T_NET_CORREC.Value = (T_NET_CORREC.Value + fleR150TEMP.GetDecimalValue("W_NET_CORREC"));
                T_NET_LIPID.Value = (T_NET_LIPID.Value + fleR150TEMP.GetDecimalValue("W_NET_LIPID"));
                T_NET_RCCP.Value = (T_NET_RCCP.Value + fleR150TEMP.GetDecimalValue("W_NET_RCCP"));
                T_NET_CME.Value = (T_NET_CME.Value + fleR150TEMP.GetDecimalValue("W_NET_CME"));
                T_NET_PCR.Value = (T_NET_PCR.Value + fleR150TEMP.GetDecimalValue("W_NET_PCR"));
                T_NET_ONCALL.Value = (T_NET_ONCALL.Value + fleR150TEMP.GetDecimalValue("W_NET_ONCALL"));
                T_NET_NEPHRO.Value = (T_NET_NEPHRO.Value + fleR150TEMP.GetDecimalValue("W_NET_NEPHRO"));
                T_NET_OUTCLI.Value = (T_NET_OUTCLI.Value + fleR150TEMP.GetDecimalValue("W_NET_OUTCLI"));
                T_NET_CASHED.Value = (T_NET_CASHED.Value + fleR150TEMP.GetDecimalValue("W_NET_CASHED"));
                T_NET_SUPP.Value = (T_NET_SUPP.Value + fleR150TEMP.GetDecimalValue("W_NET_SUPP"));
                T_NET_TAXDED.Value = (T_NET_TAXDED.Value + fleR150TEMP.GetDecimalValue("W_NET_TAXDED"));
                T_NET_DEPCHR.Value = (T_NET_DEPCHR.Value + fleR150TEMP.GetDecimalValue("W_NET_DEPCHR"));
                T_NET_HAHSO.Value = (T_NET_HAHSO.Value + fleR150TEMP.GetDecimalValue("W_NET_HAHSO"));
                T_NET_MOH.Value = (T_NET_MOH.Value + fleR150TEMP.GetDecimalValue("W_NET_MOH"));
                T_NET_RMAPEN.Value = (T_NET_RMAPEN.Value + fleR150TEMP.GetDecimalValue("W_NET_RMAPEN"));
                T_NET_AFPSTI.Value = (T_NET_AFPSTI.Value + fleR150TEMP.GetDecimalValue("W_NET_AFPSTI"));
                T_NET_INTER.Value = (T_NET_INTER.Value + fleR150TEMP.GetDecimalValue("W_NET_INTER"));
                T_NET_PENPAY.Value = (T_NET_PENPAY.Value + fleR150TEMP.GetDecimalValue("W_NET_PENPAY"));
                T_NET_FEECOR.Value = (T_NET_FEECOR.Value + fleR150TEMP.GetDecimalValue("W_NET_FEECOR"));
                T_NET_AFP.Value = (T_NET_AFP.Value + fleR150TEMP.GetDecimalValue("W_NET_AFP"));
                T_NET_AFPCON.Value = (T_NET_AFPCON.Value + fleR150TEMP.GetDecimalValue("W_NET_AFPCON"));
                T_NET_DIRECT.Value = (T_NET_DIRECT.Value + fleR150TEMP.GetDecimalValue("W_NET_DIRECT"));
                T_NET_EARREF.Value = (T_NET_EARREF.Value + fleR150TEMP.GetDecimalValue("W_NET_EARREF"));
                T_NET_EFTCAN.Value = (T_NET_EFTCAN.Value + fleR150TEMP.GetDecimalValue("W_NET_EFTCAN"));
                T_NET_FAMAFP.Value = (T_NET_FAMAFP.Value + fleR150TEMP.GetDecimalValue("W_NET_FAMAFP"));
                T_NET_INT.Value = (T_NET_INT.Value + fleR150TEMP.GetDecimalValue("W_NET_INT"));
                T_NET_LABMED.Value = (T_NET_LABMED.Value + fleR150TEMP.GetDecimalValue("W_NET_LABMED"));
                T_NET_LTD.Value = (T_NET_LTD.Value + fleR150TEMP.GetDecimalValue("W_NET_LTD"));
                T_NET_LTDINS.Value = (T_NET_LTDINS.Value + fleR150TEMP.GetDecimalValue("W_NET_LTDINS"));
                T_NET_MACPEN.Value = (T_NET_MACPEN.Value + fleR150TEMP.GetDecimalValue("W_NET_MACPEN"));
                T_NET_MANCHG.Value = (T_NET_MANCHG.Value + fleR150TEMP.GetDecimalValue("W_NET_MANCHG"));
                T_NET_MANEFT.Value = (T_NET_MANEFT.Value + fleR150TEMP.GetDecimalValue("W_NET_MANEFT"));
                T_NET_MANGST.Value = (T_NET_MANGST.Value + fleR150TEMP.GetDecimalValue("W_NET_MANGST"));
                T_NET_MANPY.Value = (T_NET_MANPY.Value + fleR150TEMP.GetDecimalValue("W_NET_MANPY"));
                T_NET_MANPYN.Value = (T_NET_MANPYN.Value + fleR150TEMP.GetDecimalValue("W_NET_MANPYN"));
                T_NET_MANTAX.Value = (T_NET_MANTAX.Value + fleR150TEMP.GetDecimalValue("W_NET_MANTAX"));
                T_NET_PARK.Value = (T_NET_PARK.Value + fleR150TEMP.GetDecimalValue("W_NET_PARK"));
                T_NET_PAYEFT.Value = (T_NET_PAYEFT.Value + fleR150TEMP.GetDecimalValue("W_NET_PAYEFT"));
                T_NET_PAYRED.Value = (T_NET_PAYRED.Value + fleR150TEMP.GetDecimalValue("W_NET_PAYRED"));
                T_NET_PGPCP.Value = (T_NET_PGPCP.Value + fleR150TEMP.GetDecimalValue("W_NET_PGPCP"));
                T_NET_PSYCAP.Value = (T_NET_PSYCAP.Value + fleR150TEMP.GetDecimalValue("W_NET_PSYCAP"));
                T_NET_PSYPAY.Value = (T_NET_PSYPAY.Value + fleR150TEMP.GetDecimalValue("W_NET_PSYPAY"));
                T_NET_REDEFT.Value = (T_NET_REDEFT.Value + fleR150TEMP.GetDecimalValue("W_NET_REDEFT"));
                T_NET_SABBIT.Value = (T_NET_SABBIT.Value + fleR150TEMP.GetDecimalValue("W_NET_SABBIT"));
                T_NET_SAMMP.Value = (T_NET_SAMMP.Value + fleR150TEMP.GetDecimalValue("W_NET_SAMMP"));
                T_NET_SECEXP.Value = (T_NET_SECEXP.Value + fleR150TEMP.GetDecimalValue("W_NET_SECEXP"));
                T_NET_SERCHR.Value = (T_NET_SERCHR.Value + fleR150TEMP.GetDecimalValue("W_NET_SERCHR"));
                T_NET_SPETAX.Value = (T_NET_SPETAX.Value + fleR150TEMP.GetDecimalValue("W_NET_SPETAX"));
                T_NET_SURGBO.Value = (T_NET_SURGBO.Value + fleR150TEMP.GetDecimalValue("W_NET_SURGBO"));
                T_NET_TAXMAN.Value = (T_NET_TAXMAN.Value + fleR150TEMP.GetDecimalValue("W_NET_TAXMAN"));
                T_NET_TAXREF.Value = (T_NET_TAXREF.Value + fleR150TEMP.GetDecimalValue("W_NET_TAXREF"));
                T_NET_MOHRET.Value = (T_NET_MOHRET.Value + fleR150TEMP.GetDecimalValue("W_NET_MOHRET"));
                T_NET_AFPRET.Value = (T_NET_AFPRET.Value + fleR150TEMP.GetDecimalValue("W_NET_AFPRET"));
                T_NET_COVARL.Value = (T_NET_COVARL.Value + fleR150TEMP.GetDecimalValue("W_NET_COVARL"));
                T_NET_OMARET.Value = (T_NET_OMARET.Value + fleR150TEMP.GetDecimalValue("W_NET_OMARET"));
                T_NET_TAXADJ.Value = (T_NET_TAXADJ.Value + fleR150TEMP.GetDecimalValue("W_NET_TAXADJ"));
                T_NET_PRESHO.Value = (T_NET_PRESHO.Value + fleR150TEMP.GetDecimalValue("W_NET_PRESHO"));
                T_NET_TRANSP.Value = (T_NET_TRANSP.Value + fleR150TEMP.GetDecimalValue("W_NET_TRANSP"));
                T_NET_SURONC.Value = (T_NET_SURONC.Value + fleR150TEMP.GetDecimalValue("W_NET_SURONC"));
                T_NET_OFN.Value = (T_NET_OFN.Value + fleR150TEMP.GetDecimalValue("W_NET_OFN"));
                T_NET_COVERA.Value = (T_NET_COVERA.Value + fleR150TEMP.GetDecimalValue("W_NET_COVERA"));
                T_NET_PCN.Value = (T_NET_PCN.Value + fleR150TEMP.GetDecimalValue("W_NET_PCN"));
                T_NET_AFPFUN.Value = (T_NET_AFPFUN.Value + fleR150TEMP.GetDecimalValue("W_NET_AFPFUN"));
                T_NET_BOAHON.Value = (T_NET_BOAHON.Value + fleR150TEMP.GetDecimalValue("W_NET_BOAHON"));
                T_NET_CANCEL.Value = (T_NET_CANCEL.Value + fleR150TEMP.GetDecimalValue("W_NET_CANCEL"));
                T_NET_CEIADV.Value = (T_NET_CEIADV.Value + fleR150TEMP.GetDecimalValue("W_NET_CEIADV"));
                T_NET_COMPCA.Value = (T_NET_COMPCA.Value + fleR150TEMP.GetDecimalValue("W_NET_COMPCA"));
                T_NET_EXEHON.Value = (T_NET_EXEHON.Value + fleR150TEMP.GetDecimalValue("W_NET_EXEHON"));
                T_NET_LTDDED.Value = (T_NET_LTDDED.Value + fleR150TEMP.GetDecimalValue("W_NET_LTDDED"));
                T_NET_ACAINC.Value = (T_NET_ACAINC.Value + fleR150TEMP.GetDecimalValue("W_NET_ACAINC"));
                T_NET_STIPEN.Value = (T_NET_STIPEN.Value + fleR150TEMP.GetDecimalValue("W_NET_STIPEN"));
                T_NET_RETRO.Value = (T_NET_RETRO.Value + fleR150TEMP.GetDecimalValue("W_NET_RETRO"));
                T_NET_PACE.Value = (T_NET_PACE.Value + fleR150TEMP.GetDecimalValue("W_NET_PACE"));
                T_NET_UNINSU.Value = (T_NET_UNINSU.Value + fleR150TEMP.GetDecimalValue("W_NET_UNINSU"));
                T_NET_COVCHU.Value = (T_NET_COVCHU.Value + fleR150TEMP.GetDecimalValue("W_NET_COVCHU"));
                T_NET_LEACON.Value = (T_NET_LEACON.Value + fleR150TEMP.GetDecimalValue("W_NET_LEACON"));
                T_NET_SPEPAY.Value = (T_NET_SPEPAY.Value + fleR150TEMP.GetDecimalValue("W_NET_SPEPAY"));
                T_NET_ADVANC.Value = (T_NET_ADVANC.Value + fleR150TEMP.GetDecimalValue("W_NET_ADVANC"));
                T_NET_AHSC.Value = (T_NET_AHSC.Value + fleR150TEMP.GetDecimalValue("W_NET_AHSC"));
                T_NET_WEEKEN.Value = (T_NET_WEEKEN.Value + fleR150TEMP.GetDecimalValue("W_NET_WEEKEN"));
                T_NET_SHN.Value = (T_NET_SHN.Value + fleR150TEMP.GetDecimalValue("W_NET_SHN"));
                T_NET_EQUPAY.Value = (T_NET_EQUPAY.Value + fleR150TEMP.GetDecimalValue("W_NET_EQUPAY"));
                T_NET_RETCLI.Value = (T_NET_RETCLI.Value + fleR150TEMP.GetDecimalValue("W_NET_RETCLI"));
                T_NET_SERREC.Value = (T_NET_SERREC.Value + fleR150TEMP.GetDecimalValue("W_NET_SERREC"));
                T_NET_EDUCON.Value = (T_NET_EDUCON.Value + fleR150TEMP.GetDecimalValue("W_NET_EDUCON"));
                T_NET_NEUSRF.Value = (T_NET_NEUSRF.Value + fleR150TEMP.GetDecimalValue("W_NET_NEUSRF"));
                T_NET_LABPAY.Value = (T_NET_LABPAY.Value + fleR150TEMP.GetDecimalValue("W_NET_LABPAY"));
                T_NET_REJECT.Value = (T_NET_REJECT.Value + fleR150TEMP.GetDecimalValue("W_NET_REJECT"));
                T_NET_AFPBON.Value = (T_NET_AFPBON.Value + fleR150TEMP.GetDecimalValue("W_NET_AFPBON"));
                T_NET_RESSUP.Value = (T_NET_RESSUP.Value + fleR150TEMP.GetDecimalValue("W_NET_RESSUP"));
                T_NET_RECRUI.Value = (T_NET_RECRUI.Value + fleR150TEMP.GetDecimalValue("W_NET_RECRUI"));
                T_NET_CLIREP.Value = (T_NET_CLIREP.Value + fleR150TEMP.GetDecimalValue("W_NET_CLIREP"));
                T_NET_HOCC.Value = (T_NET_HOCC.Value + fleR150TEMP.GetDecimalValue("W_NET_HOCC"));
                T_NET_FLOTHR.Value = (T_NET_FLOTHR.Value + fleR150TEMP.GetDecimalValue("W_NET_FLOTHR"));
                T_NET_MOROVE.Value = (T_NET_MOROVE.Value + fleR150TEMP.GetDecimalValue("W_NET_MOROVE"));
                T_NET_TITHE1.Value = (T_NET_TITHE1.Value + fleR150TEMP.GetDecimalValue("W_NET_TITHE1"));
                T_NET_TITHE2.Value = (T_NET_TITHE2.Value + fleR150TEMP.GetDecimalValue("W_NET_TITHE2"));
                T_NET_TITHE3.Value = (T_NET_TITHE3.Value + fleR150TEMP.GetDecimalValue("W_NET_TITHE3"));
                T_NET_DEPMEM.Value = (T_NET_DEPMEM.Value + fleR150TEMP.GetDecimalValue("W_NET_DEPMEM"));
                T_NET_TITHD1.Value = (T_NET_TITHD1.Value + fleR150TEMP.GetDecimalValue("W_NET_TITHD1"));
                T_NET_TITHD2.Value = (T_NET_TITHD2.Value + fleR150TEMP.GetDecimalValue("W_NET_TITHD2"));
                T_NET_TITHD3.Value = (T_NET_TITHD3.Value + fleR150TEMP.GetDecimalValue("W_NET_TITHD3"));
                T_NET_DEPMED.Value = (T_NET_DEPMED.Value + fleR150TEMP.GetDecimalValue("W_NET_DEPMED"));
                T_NET_TITDEF.Value = (T_NET_TITDEF.Value + fleR150TEMP.GetDecimalValue("W_NET_TITDEF"));
                T_NET_CPPDED.Value = (T_NET_CPPDED.Value + fleR150TEMP.GetDecimalValue("W_NET_CPPDED"));
                T_NET_PREBON.Value = (T_NET_PREBON.Value + fleR150TEMP.GetDecimalValue("W_NET_PREBON"));
                T_NET_SPEPRE.Value = (T_NET_SPEPRE.Value + fleR150TEMP.GetDecimalValue("W_NET_SPEPRE"));
                T_NET_SHADOW.Value = (T_NET_SHADOW.Value + fleR150TEMP.GetDecimalValue("W_NET_SHADOW"));
                T_NET_ABCSTA.Value = (T_NET_ABCSTA.Value + fleR150TEMP.GetDecimalValue("W_NET_ABCSTA"));
                T_NET_MANSUR.Value = (T_NET_MANSUR.Value + fleR150TEMP.GetDecimalValue("W_NET_MANSUR"));
                T_NET_EXETAX.Value = (T_NET_EXETAX.Value + fleR150TEMP.GetDecimalValue("W_NET_EXETAX"));
                T_NET_AFTHOU.Value = (T_NET_AFTHOU.Value + fleR150TEMP.GetDecimalValue("W_NET_AFTHOU"));
                T_NET_DIABET.Value = (T_NET_DIABET.Value + fleR150TEMP.GetDecimalValue("W_NET_DIABET"));
                T_NET_HGHCON.Value = (T_NET_HGHCON.Value + fleR150TEMP.GetDecimalValue("W_NET_HGHCON"));
                T_NET_GSTREJ.Value = (T_NET_GSTREJ.Value + fleR150TEMP.GetDecimalValue("W_NET_GSTREJ"));
                T_NET_PATHOL.Value = (T_NET_PATHOL.Value + fleR150TEMP.GetDecimalValue("W_NET_PATHOL"));
                T_NET_GUARAN.Value = (T_NET_GUARAN.Value + fleR150TEMP.GetDecimalValue("W_NET_GUARAN"));
                T_NET_PDA.Value = (T_NET_PDA.Value + fleR150TEMP.GetDecimalValue("W_NET_PDA"));
                T_NET_MRP.Value = (T_NET_MRP.Value + fleR150TEMP.GetDecimalValue("W_NET_MRP"));
                T_NET_UCAF.Value = (T_NET_UCAF.Value + fleR150TEMP.GetDecimalValue("W_NET_UCAF"));
                T_NET_WSIB.Value = (T_NET_WSIB.Value + fleR150TEMP.GetDecimalValue("W_NET_WSIB"));
                T_NET_ADMIN.Value = (T_NET_ADMIN.Value + fleR150TEMP.GetDecimalValue("W_NET_ADMIN"));
                T_NET_NUCCHR.Value = (T_NET_NUCCHR.Value + fleR150TEMP.GetDecimalValue("W_NET_NUCCHR"));
                T_NET_NEWPAT.Value = (T_NET_NEWPAT.Value + fleR150TEMP.GetDecimalValue("W_NET_NEWPAT"));
                T_NET_PEDCAL.Value = (T_NET_PEDCAL.Value + fleR150TEMP.GetDecimalValue("W_NET_PEDCAL"));
                T_NET_CONSUL.Value = (T_NET_CONSUL.Value + fleR150TEMP.GetDecimalValue("W_NET_CONSUL"));
                T_NET_EFTPAY.Value = (T_NET_EFTPAY.Value + fleR150TEMP.GetDecimalValue("W_NET_EFTPAY"));
                T_NET_PLASTI.Value = (T_NET_PLASTI.Value + fleR150TEMP.GetDecimalValue("W_NET_PLASTI"));
                T_NET_ORTHO.Value = (T_NET_ORTHO.Value + fleR150TEMP.GetDecimalValue("W_NET_ORTHO"));
                T_NET_BLEFEE.Value = (T_NET_BLEFEE.Value + fleR150TEMP.GetDecimalValue("W_NET_BLEFEE"));
                T_NET_AGEP.Value = (T_NET_AGEP.Value + fleR150TEMP.GetDecimalValue("W_NET_AGEP"));
                T_NET_BASE.Value = (T_NET_BASE.Value + fleR150TEMP.GetDecimalValue("W_NET_BASE"));
                T_NET_MICA.Value = (T_NET_MICA.Value + fleR150TEMP.GetDecimalValue("W_NET_MICA"));
                T_NET_MISC0.Value = (T_NET_MISC0.Value + fleR150TEMP.GetDecimalValue("W_NET_MISC0"));
                T_NET_MOHD.Value = (T_NET_MOHD.Value + fleR150TEMP.GetDecimalValue("W_NET_MOHD"));
                T_NET_OUTPRO.Value = (T_NET_OUTPRO.Value + fleR150TEMP.GetDecimalValue("W_NET_OUTPRO"));
                T_NET_PYRFEE.Value = (T_NET_PYRFEE.Value + fleR150TEMP.GetDecimalValue("W_NET_PYRFEE"));
                T_NET_PYRHST.Value = (T_NET_PYRHST.Value + fleR150TEMP.GetDecimalValue("W_NET_PYRHST"));
                T_NET_WEBHST.Value = (T_NET_WEBHST.Value + fleR150TEMP.GetDecimalValue("W_NET_WEBHST"));
                T_NET_BRIDGE.Value = (T_NET_BRIDGE.Value + fleR150TEMP.GetDecimalValue("W_NET_BRIDGE"));
                T_NET_TOPOFF.Value = (T_NET_TOPOFF.Value + fleR150TEMP.GetDecimalValue("W_NET_TOPOFF"));
                T_NET_BLEPRE.Value = (T_NET_BLEPRE.Value + fleR150TEMP.GetDecimalValue("W_NET_BLEPRE"));
                T_NET_TRAVEL.Value = (T_NET_TRAVEL.Value + fleR150TEMP.GetDecimalValue("W_NET_TRAVEL"));
                T_NET_PERC.Value = (T_NET_PERC.Value + fleR150TEMP.GetDecimalValue("W_NET_PERC"));
                T_NET_MALPRA.Value = (T_NET_MALPRA.Value + fleR150TEMP.GetDecimalValue("W_NET_MALPRA"));
                T_NET_MICC.Value = (T_NET_MICC.Value + fleR150TEMP.GetDecimalValue("W_NET_MICC"));
                T_NET_GARNIS.Value = (T_NET_GARNIS.Value + fleR150TEMP.GetDecimalValue("W_NET_GARNIS"));
                T_NET_MANPAY.Value = (T_NET_MANPAY.Value + fleR150TEMP.GetDecimalValue("W_NET_MANPAY"));
                SubFile(ref m_trnTRANS_UPDATE, "R150A", fleR150TEMP.At("DOC_NBR"), SubFileType.Keep, fleR150TEMP, "DOC_NBR", T_NET_PAY, T_NET_DEDUC, T_NET_TAX, T_NET_PAGER, T_NET_MEMBER, T_NET_OMASPC, T_NET_OMA, T_NET_CMPA, T_NET_TAXREM, T_NET_DIRADV, T_NET_MOHRED, T_NET_OVPAY, T_NET_REFDOC, T_NET_FAMSUP, T_NET_GSTTAX, T_NET_RMACHR, T_NET_WEB, T_NET_RMAEXR, T_NET_RMAEXM, T_NET_GST, T_NET_DEPEXR, T_NET_SURPLU, T_NET_REBATE, T_NET_GSTREB, T_NET_DEPT, T_NET_ICUCHR, T_NET_ICUGST, T_NET_CORREC, T_NET_LIPID, T_NET_DEPEXM, T_NET_RCCP, T_NET_CME, T_NET_PCR, T_NET_ONCALL, T_NET_NEPHRO, T_NET_OUTCLI, T_NET_CASHED, T_NET_SUPP, T_NET_TAXDED, T_NET_DEPCHR, T_NET_HAHSO, T_NET_MOH, T_NET_RMAPEN, T_NET_AFPSTI, T_NET_INTER, T_NET_PENPAY, T_NET_FEECOR, T_NET_AFP, T_NET_AFPCON, T_NET_DIRECT, T_NET_EARREF, T_NET_EFTCAN, T_NET_FAMAFP, T_NET_INT, T_NET_LABMED, T_NET_LTD, T_NET_LTDINS, T_NET_MACPEN, T_NET_MANCHG, T_NET_MANEFT, T_NET_MANGST, T_NET_MANPY, T_NET_MANPYN, T_NET_MANTAX, T_NET_PARK, T_NET_PAYEFT, T_NET_PAYRED, T_NET_PGPCP, T_NET_PSYCAP, T_NET_PSYPAY, T_NET_REDEFT, T_NET_SABBIT, T_NET_SAMMP, T_NET_SECEXP, T_NET_SERCHR, T_NET_SPETAX, T_NET_SURGBO, T_NET_TAXMAN, T_NET_TAXREF, T_NET_MOHRET, T_NET_AFPRET, T_NET_COVARL, T_NET_OMARET, T_NET_TAXADJ, T_NET_PRESHO, T_NET_TRANSP, T_NET_SURONC, T_NET_OFN, T_NET_COVERA, T_NET_PCN, T_NET_AFPFUN, T_NET_BOAHON, T_NET_CANCEL, T_NET_CEIADV, T_NET_COMPCA, T_NET_EXEHON, T_NET_LTDDED, T_NET_ACAINC, T_NET_STIPEN, T_NET_RETRO, T_NET_PACE, T_NET_UNINSU, T_NET_COVCHU, T_NET_LEACON, T_NET_SPEPAY, T_NET_ADVANC, T_NET_AHSC, T_NET_WEEKEN, T_NET_SHN, T_NET_EQUPAY, T_NET_RETCLI, T_NET_SERREC, T_NET_EDUCON, T_NET_NEUSRF, T_NET_LABPAY, T_NET_REJECT, T_NET_AFPBON, T_NET_RESSUP, T_NET_RECRUI, T_NET_CLIREP, T_NET_HOCC, T_NET_FLOTHR, T_NET_MOROVE, T_NET_TITHE1, T_NET_TITHE2, T_NET_TITHE3, T_NET_DEPMEM, T_NET_TITHD1, T_NET_TITHD2, T_NET_TITHD3, T_NET_DEPMED, T_NET_TITDEF, T_NET_CPPDED, T_NET_PREBON, T_NET_SPEPRE, T_NET_SHADOW, T_NET_ABCSTA, T_NET_MANSUR, T_NET_EXETAX, T_NET_AFTHOU, T_NET_DIABET, T_NET_HGHCON, T_NET_GSTREJ, T_NET_PATHOL, T_NET_GUARAN, T_NET_PDA, T_NET_MRP, T_NET_UCAF, T_NET_WSIB, T_NET_ADMIN, T_NET_NUCCHR, T_NET_NEWPAT, T_NET_PEDCAL, T_NET_CONSUL, T_NET_EFTPAY, T_NET_PLASTI, T_NET_ORTHO, T_NET_BLEFEE, T_NET_AGEP, T_NET_BASE, T_NET_MICA, T_NET_MISC0, T_NET_MOHD, T_NET_OUTPRO, T_NET_PYRFEE, T_NET_PYRHST, T_NET_WEBHST, T_NET_BRIDGE, T_NET_TOPOFF, T_NET_BLEPRE, T_NET_TRAVEL, T_NET_PERC, T_NET_MALPRA, T_NET_MICC, T_NET_GARNIS, T_NET_MANPAY);
                Reset(ref T_NET_PAY, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_DEDUC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TAX, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PAGER, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MEMBER, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_OMASPC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_OMA, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_CMPA, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TAXREM, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_DIRADV, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MOHRED, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_OVPAY, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_REFDOC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_FAMSUP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_RMACHR, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_GSTTAX, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_WEB, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_RMAEXR, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_RMAEXM, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_GST, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_DEPEXR, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_DEPEXM, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SURPLU, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_REBATE, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_GSTREB, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_DEPT, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_ICUCHR, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_ICUGST, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_CORREC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_LIPID, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_RCCP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_CME, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PCR, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_ONCALL, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_NEPHRO, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_OUTCLI, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_CASHED, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SUPP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TAXDED, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_DEPCHR, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_HAHSO, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MOH, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_RMAPEN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_AFPSTI, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_INTER, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PENPAY, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_FEECOR, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_AFP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_AFPCON, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_DIRECT, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_EARREF, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_EFTCAN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_FAMAFP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_INT, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_LABMED, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_LTD, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_LTDINS, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MACPEN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MANCHG, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MANEFT, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MANGST, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MANPY, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MANPYN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MANTAX, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PARK, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PAYEFT, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PAYRED, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PGPCP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PSYCAP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PSYPAY, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_REDEFT, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SABBIT, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SAMMP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SECEXP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SERCHR, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SPETAX, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SURGBO, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TAXMAN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TAXREF, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MOHRET, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_AFPRET, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_COVARL, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_OMARET, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TAXADJ, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PRESHO, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TRANSP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SURONC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_OFN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_COVERA, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PCN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_AFPFUN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_BOAHON, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_CANCEL, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_CEIADV, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_COMPCA, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_EXEHON, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_LTDDED, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_ACAINC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_STIPEN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_RETRO, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PACE, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_UNINSU, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_COVCHU, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_LEACON, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SPEPAY, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_ADVANC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_AHSC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_WEEKEN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SHN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_EQUPAY, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_RETCLI, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SERREC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_EDUCON, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_NEUSRF, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_LABPAY, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_REJECT, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_AFPBON, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_RESSUP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_RECRUI, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_CLIREP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_HOCC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_FLOTHR, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MOROVE, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TITHE1, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TITHE2, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TITHE3, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_DEPMEM, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TITHD1, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TITHD2, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TITHD3, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_DEPMED, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TITDEF, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_CPPDED, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PREBON, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SPEPRE, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_SHADOW, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_ABCSTA, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MANSUR, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_EXETAX, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_AFTHOU, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_DIABET, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_HGHCON, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_GSTREJ, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PATHOL, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_GUARAN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PDA, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MRP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_UCAF, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_WSIB, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_ADMIN, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_NUCCHR, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_NEWPAT, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PEDCAL, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_CONSUL, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_EFTPAY, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PLASTI, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_ORTHO, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_BLEFEE, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_AGEP, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_BASE, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MICA, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MISC0, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MOHD, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_OUTPRO, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PYRFEE, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PYRHST, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_WEBHST, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_BRIDGE, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TOPOFF, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_BLEPRE, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_TRAVEL, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_PERC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MALPRA, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MICC, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_GARNIS, fleR150TEMP.At("DOC_NBR"));
                Reset(ref T_NET_MANPAY, fleR150TEMP.At("DOC_NBR"));
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
            EndRequest("SUMMARIZE_DOC_TOTAL_3");
        }

    }
}
// SUMMARIZE_DOC_TOTAL_3