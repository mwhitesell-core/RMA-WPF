
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Application.Utilities
{

    public class Factory
    {
        public COPY_F113 CreateCOPY_F113(int Level)
        {
            return new COPY_F113("COPY_F113", Level);
        }

        public COPY_F114 CreateCOPY_F114(int Level)
        {
            return new COPY_F114("COPY_F114", Level);
        }

        public LOAD_U132DAT CreateLOAD_U132DAT(int Level)
        {
            return new LOAD_U132DAT("LOAD_U132DAT", Level);
        }

        public F002SQL CreateF002SQL(int Level)
        {
            return new F002SQL("F002SQL", Level);
        }

        public LOAD_F086 CreateLOAD_F086(int Level)
        {
            return new LOAD_F086("LOAD_F086", Level);
        }

        public LOAD_F002_SUSPEND_FILES CreateLOAD_F002_SUSPEND_FILES(int Level)
        {
            return new LOAD_F002_SUSPEND_FILES("LOAD_F002_SUSPEND_FILES", Level);
        }

        public SQL_BACKUP CreateSQL_BACKUP(int Level)
        {
            return new SQL_BACKUP("SQL_BACKUP", Level);
        }
        public SQL_RELOAD CreateSQL_RELOAD(int Level)
        {
            return new SQL_RELOAD("SQL_RELOAD", Level);
        }

        public UTL0013 CreateUTL0013(int Level)
        {
            return new UTL0013("UTL0013", Level);
        }     

        public BACKUP_EARNINGS_DAILY CreateBACKUP_EARNINGS_DAILY(int Level)
        {
            return new BACKUP_EARNINGS_DAILY("BACKUP_EARNINGS_DAILY", Level);
        }

        public RELOAD_EARNINGS_DAILY CreateRELOAD_EARNINGS_DAILY(int Level)
        {
            return new RELOAD_EARNINGS_DAILY("RELOAD_EARNINGS_DAILY", Level);
        }
        public CHECKF002TECH_SERV_DATE CreateCHECKF002TECH_SERV_DATE(int Level)
        {
            return new CHECKF002TECH_SERV_DATE("CHECKF002TECH_SERV_DATE", Level);
        }

        public COSTING1 CreateCOSTING1(int Level)
        {
            return new COSTING1("COSTING1", Level);
        }

        public COSTING1_NOWEB CreateCOSTING1_NOWEB(int Level)
        {
            return new COSTING1_NOWEB("COSTING1_NOWEB", Level);
        }

        public COSTING2 CreateCOSTING2(int Level)
        {
            return new COSTING2("COSTING2", Level);
        }

        public COSTING2_NOWEB CreateCOSTING2_NOWEB(int Level)
        {
            return new COSTING2_NOWEB("COSTING2_NOWEB", Level);
        }

        public COSTING3 CreateCOSTING3(int Level)
        {
            return new COSTING3("COSTING3", Level);
        }

        public COSTING4 CreateCOSTING4(int Level)
        {
            return new COSTING4("COSTING4", Level);
        }

        public COSTING5 CreateCOSTING5(int Level)
        {
            return new COSTING5("COSTING5", Level);
        }

        public COSTING5_NOWEB CreateCOSTING5_NOWEB(int Level)
        {
            return new COSTING5_NOWEB("COSTING5_NOWEB", Level);
        }

        public COSTING6 CreateCOSTING6(int Level)
        {
            return new COSTING6("COSTING6", Level);
        }

        public COSTING6_NOWEB CreateCOSTING6_NOWEB(int Level)
        {
            return new COSTING6_NOWEB("COSTING6_NOWEB", Level);
        }

        public COSTING7 CreateCOSTING7(int Level)
        {
            return new COSTING7("COSTING7", Level);
        }

        public CREATE_DUMMY_RECORDS CreateCREATE_DUMMY_RECORDS(int Level)
        {
            return new CREATE_DUMMY_RECORDS("CREATE_DUMMY_RECORDS", Level);
        }

        public DOCREVALL CreateDOCREVALL(int Level)
        {
            return new DOCREVALL("DOCREVALL", Level);
        }

        public F020_INFO_IMPORT CreateF020_INFO_IMPORT(int Level)
        {
            return new F020_INFO_IMPORT("F020_INFO_IMPORT", Level);
        }

        public F050MA1 CreateF050MA1(int Level)
        {
            return new F050MA1("F050MA1", Level);
        }

        public F050_BI CreateF050_BI(int Level)
        {
            return new F050_BI("F050_BI", Level);
        }

        public F050_CSV CreateF050_CSV(int Level)
        {
            return new F050_CSV("F050_CSV", Level);
        }

        public FIX_ADJ_CLAIM_FILE_1 CreateFIX_ADJ_CLAIM_FILE_1(int Level)
        {
            return new FIX_ADJ_CLAIM_FILE_1("FIX_ADJ_CLAIM_FILE_1", Level);
        }

        public FIX_ADJ_CLAIM_FILE_2 CreateFIX_ADJ_CLAIM_FILE_2(int Level)
        {
            return new FIX_ADJ_CLAIM_FILE_2("FIX_ADJ_CLAIM_FILE_2", Level);
        }

        public FIX_DUMP_TECH CreateFIX_DUMP_TECH(int Level)
        {
            return new FIX_DUMP_TECH("FIX_DUMP_TECH", Level);
        }

        public FIX_F001_F002_ALL CreateFIX_F001_F002_ALL(int Level)
        {
            return new FIX_F001_F002_ALL("FIX_F001_F002_ALL", Level);
        }

        public FIX_SEQ_NBRS CreateFIX_SEQ_NBRS(int Level)
        {
            return new FIX_SEQ_NBRS("FIX_SEQ_NBRS", Level);
        }

        public MARIA_REJECTS1 CreateMARIA_REJECTS1(int Level)
        {
            return new MARIA_REJECTS1("MARIA_REJECTS1", Level);
        }

        public MARIA_REJECTS2 CreateMARIA_REJECTS2(int Level)
        {
            return new MARIA_REJECTS2("MARIA_REJECTS2", Level);
        }

        public NEWU701 CreateNEWU701(int Level)
        {
            return new NEWU701("NEWU701", Level);
        }

        public PRODTITHE CreatePRODTITHE(int Level)
        {
            return new PRODTITHE("PRODTITHE", Level);
        }

        public PURGE_F050_F051 CreatePURGE_F050_F051(int Level)
        {
            return new PURGE_F050_F051("PURGE_F050_F051", Level);
        }

        public R005_CSV CreateR005_CSV(int Level)
        {
            return new R005_CSV("R005_CSV", Level);
        }

        public R120 CreateR120(int Level)
        {
            return new R120("R120", Level);
        }

        public R121_SUMM CreateR121_SUMM(int Level)
        {
            return new R121_SUMM("R121_SUMM", Level);
        }

        public R128A CreateR128A(int Level)
        {
            return new R128A("R128A", Level);
        }

        public R136 CreateR136(int Level)
        {
            return new R136("R136", Level);
        }

        public R138_CSV CreateR138_CSV(int Level)
        {
            return new R138_CSV("R138_CSV", Level);
        }

        public R139_CSV CreateR139_CSV(int Level)
        {
            return new R139_CSV("R139_CSV", Level);
        }

        public R140W1 CreateR140W1(int Level)
        {
            return new R140W1("R140W1", Level);
        }

        public R140W2 CreateR140W2(int Level)
        {
            return new R140W2("R140W2", Level);
        }

        public R140_A1 CreateR140_A1(int Level)
        {
            return new R140_A1("R140_A1", Level);
        }

        public R150A_DETAIL CreateR150A_DETAIL(int Level)
        {
            return new R150A_DETAIL("R150A_DETAIL", Level);
        }

        public SOLOTITHE CreateSOLOTITHE(int Level)
        {
            return new SOLOTITHE("SOLOTITHE", Level);
        }

        public SOLO_EARNINGS CreateSOLO_EARNINGS(int Level)
        {
            return new SOLO_EARNINGS("SOLO_EARNINGS", Level);
        }

        public SOLO_INCOME_SUMMARY CreateSOLO_INCOME_SUMMARY(int Level)
        {
            return new SOLO_INCOME_SUMMARY("SOLO_INCOME_SUMMARY", Level);
        }

        public SUSPDTL CreateSUSPDTL(int Level)
        {
            return new SUSPDTL("SUSPDTL", Level);
        }

        public SUSPDTL_2 CreateSUSPDTL_2(int Level)
        {
            return new SUSPDTL_2("SUSPDTL_2", Level);
        }

        public SUSPEND_AGENT_DETAIL CreateSUSPEND_AGENT_DETAIL(int Level)
        {
            return new SUSPEND_AGENT_DETAIL("SUSPEND_AGENT_DETAIL", Level);
        }

        public TEMP_IGNORE_AGENT6_SUSP_HDR CreateTEMP_IGNORE_AGENT6_SUSP_HDR(int Level)
        {
            return new TEMP_IGNORE_AGENT6_SUSP_HDR("TEMP_IGNORE_AGENT6_SUSP_HDR", Level);
        }

        public U010DAILY CreateU010DAILY(int Level)
        {
            return new U010DAILY("U010DAILY", Level);
        }      

        public U014_F050 CreateU014_F050(int Level)
        {
            return new U014_F050("U014_F050", Level);
        }

        public U014_F050TP CreateU014_F050TP(int Level)
        {
            return new U014_F050TP("U014_F050TP", Level);
        }

        public U015 CreateU015(int Level)
        {
            return new U015("U015", Level);
        }

        public U015TP CreateU015TP(int Level)
        {
            return new U015TP("U015TP", Level);
        }

        public U016 CreateU016(int Level)
        {
            return new U016("U016", Level);
        }

        public U020A CreateU020A(int Level)
        {
            return new U020A("U020A", Level);
        }

        public U020B CreateU020B(int Level)
        {
            return new U020B("U020B", Level);
        }

        public U020C CreateU020C(int Level)
        {
            return new U020C("U020C", Level);
        }

        public U020D CreateU020D(int Level)
        {
            return new U020D("U020D", Level);
        }

        public U020_SHDW CreateU020_SHDW(int Level)
        {
            return new U020_SHDW("U020_SHDW", Level);
        }

        public U021A CreateU021A(int Level)
        {
            return new U021A("U021A", Level);
        }

        public U021F CreateU021F(int Level)
        {
            return new U021F("U021F", Level);
        }

        public U022A1 CreateU022A1(int Level)
        {
            return new U022A1("U022A1", Level);
        }

        public U022B CreateU022B(int Level)
        {
            return new U022B("U022B", Level);
        }

        public U022C CreateU022C(int Level)
        {
            return new U022C("U022C", Level);
        }

        public U030BB CreateU030BB(int Level)
        {
            return new U030BB("U030BB", Level);
        }

        public U030BB_1 CreateU030BB_1(int Level)
        {
            return new U030BB_1("U030BB_1", Level);
        }

        public U030B_1 CreateU030B_1(int Level)
        {
            return new U030B_1("U030B_1", Level);
        }

        public U030B_60 CreateU030B_60(int Level)
        {
            return new U030B_60("U030B_60", Level);
        }

        public U030B_AUTOADJ_CLINIC_DTL CreateU030B_AUTOADJ_CLINIC_DTL(int Level)
        {
            return new U030B_AUTOADJ_CLINIC_DTL("U030B_AUTOADJ_CLINIC_DTL", Level);
        }

        public U030B_PART1 CreateU030B_PART1(int Level)
        {
            return new U030B_PART1("U030B_PART1", Level);
        }

        public U030B_PART3_A CreateU030B_PART3_A(int Level)
        {
            return new U030B_PART3_A("U030B_PART3_A", Level);
        }

        public U030B_PART3_B CreateU030B_PART3_B(int Level)
        {
            return new U030B_PART3_B("U030B_PART3_B", Level);
        }

        public U030_DTL_TECH_PROF CreateU030_DTL_TECH_PROF(int Level)
        {
            return new U030_DTL_TECH_PROF("U030_DTL_TECH_PROF", Level);
        }

        public U031 CreateU031(int Level)
        {
            return new U031("U031", Level);
        }

        public U035A CreateU035A(int Level)
        {
            return new U035A("U035A", Level);
        }

        public U041_UPDATE_MIN_MAX CreateU041_UPDATE_MIN_MAX(int Level)
        {
            return new U041_UPDATE_MIN_MAX("U041_UPDATE_MIN_MAX", Level);
        }

        public U072 CreateU072(int Level)
        {
            return new U072("U072", Level);
        }

        public U072_DELETE_1 CreateU072_DELETE_1(int Level)
        {
            return new U072_DELETE_1("U072_DELETE_1", Level);
        }

        public U072_DELETE_2 CreateU072_DELETE_2(int Level)
        {
            return new U072_DELETE_2("U072_DELETE_2", Level);
        }

        public U072_RETAIN_1 CreateU072_RETAIN_1(int Level)
        {
            return new U072_RETAIN_1("U072_RETAIN_1", Level);
        }

        public U072_RETAIN_2 CreateU072_RETAIN_2(int Level)
        {
            return new U072_RETAIN_2("U072_RETAIN_2", Level);
        }

        public U080 CreateU080(int Level)
        {
            return new U080("U080", Level);
        }

        public U085 CreateU085(int Level)
        {
            return new U085("U085", Level);
        }

        public U085B CreateU085B(int Level)
        {
            return new U085B("U085B", Level);
        }

        public U085C CreateU085C(int Level)
        {
            return new U085C("U085C", Level);
        }

        public U085D CreateU085D(int Level)
        {
            return new U085D("U085D", Level);
        }

        public U085E CreateU085E(int Level)
        {
            return new U085E("U085E", Level);
        }

        public U086 CreateU086(int Level)
        {
            return new U086("U086", Level);
        }

        public U086A CreateU086A(int Level)
        {
            return new U086A("U086A", Level);
        }

        public U090 CreateU090(int Level)
        {
            return new U090("U090", Level);
        }

        public U090F CreateU090F(int Level)
        {
            return new U090F("U090F", Level);
        }

        public U093 CreateU093(int Level)
        {
            return new U093("U093", Level);
        }

        public U095 CreateU095(int Level)
        {
            return new U095("U095", Level);
        }

        public U099 CreateU099(int Level)
        {
            return new U099("U099", Level);
        }

        public U100 CreateU100(int Level)
        {
            return new U100("U100", Level);
        }

        public U105 CreateU105(int Level)
        {
            return new U105("U105", Level);
        }

        public Mp_U105 CreateMp_U105(int Level)
        {
            return new Mp_U105("Mp_U105", Level);
        }

        public U110B_RMA CreateU110B_RMA(int Level)
        {
            return new U110B_RMA("U110B_RMA", Level);
        }

        public U110_1 CreateU110_1(int Level)
        {
            return new U110_1("U110_1", Level);
        }

        public U110_2 CreateU110_2(int Level)
        {
            return new U110_2("U110_2", Level);
        }

        public U111C CreateU111C(int Level)
        {
            return new U111C("U111C", Level);
        }

        public U112 CreateU112(int Level)
        {
            return new U112("U112", Level);
        }

        public U113 CreateU113(int Level)
        {
            return new U113("U113", Level);
        }

        public U114A CreateU114A(int Level)
        {
            return new U114A("U114A", Level);
        }

        public U114B CreateU114B(int Level)
        {
            return new U114B("U114B", Level);
        }

        public U115A CreateU115A(int Level)
        {
            return new U115A("U115A", Level);
        }

        public U115B CreateU115B(int Level)
        {
            return new U115B("U115B", Level);
        }

        public U115C CreateU115C(int Level)
        {
            return new U115C("U115C", Level);
        }

        public U116 CreateU116(int Level)
        {
            return new U116("U116", Level);
        }

        public U117 CreateU117(int Level)
        {
            return new U117("U117", Level);
        }

        public U118 CreateU118(int Level)
        {
            return new U118("U118", Level);
        }

        public U119B CreateU119B(int Level)
        {
            return new U119B("U119B", Level);
        }

        public U119 CreateU119(int Level)
        {
            return new U119("U119", Level);
        }

        public U121 CreateU121(int Level)
        {
            return new U121("U121", Level);
        }

        public U122 CreateU122(int Level)
        {
            return new U122("U122", Level);
        }

        public U122_PAYCODE7 CreateU122_PAYCODE7(int Level)
        {
            return new U122_PAYCODE7("U122_PAYCODE7", Level);
        }

        public U122B CreateU122B(int Level)
        {
            return new U122B("U122B", Level);
        }

        public U125 CreateU125(int Level)
        {
            return new U125("U125", Level);
        }

        public U126 CreateU126(int Level)
        {
            return new U126("U126", Level);
        }

        public U127 CreateU127(int Level)
        {
            return new U127("U127", Level);
        }

        public U130 CreateU130(int Level)
        {
            return new U130("U130", Level);
        }

        public U131A CreateU131A(int Level)
        {
            return new U131A("U131A", Level);
        }

        public U132_DC CreateU132_DC(int Level)
        {
            return new U132_DC("U132_DC", Level);
        }

        public U132_SP CreateU132_SP(int Level)
        {
            return new U132_SP("U132_SP", Level);
        }

        public U140_A CreateU140_A(int Level)
        {
            return new U140_A("U140_A", Level);
        }

        public U140_B CreateU140_B(int Level)
        {
            return new U140_B("U140_B", Level);
        }

        public U140_C CreateU140_C(int Level)
        {
            return new U140_C("U140_C", Level);
        }

        public U140_D CreateU140_D(int Level)
        {
            return new U140_D("U140_D", Level);
        }

        public U140_D1_REMOVE_DUPS CreateU140_D1_REMOVE_DUPS(int Level)
        {
            return new U140_D1_REMOVE_DUPS("U140_D1_REMOVE_DUPS", Level);
        }

        public U140_E CreateU140_E(int Level)
        {
            return new U140_E("U140_E", Level);
        }

        public U140_F CreateU140_F(int Level)
        {
            return new U140_F("U140_F", Level);
        }

        public U141A CreateU141A(int Level)
        {
            return new U141A("U141A", Level);
        }

        public U141C CreateU141C(int Level)
        {
            return new U141C("U141C", Level);
        }

        public U704 CreateU704(int Level)
        {
            return new U704("U704", Level);
        }

        public U704A CreateU704A(int Level)
        {
            return new U704A("U704A", Level);
        }

        public U705 CreateU705(int Level)
        {
            return new U705("U705", Level);
        }

        public U708 CreateU708(int Level)
        {
            return new U708("U708", Level);
        }

        public U714 CreateU714(int Level)
        {
            return new U714("U714", Level);
        }

        public U716A CreateU716A(int Level)
        {
            return new U716A("U716A", Level);
        }

        public U716C CreateU716C(int Level)
        {
            return new U716C("U716C", Level);
        }

        public U802 CreateU802(int Level)
        {
            return new U802("U802", Level);
        }

        public U901 CreateU901(int Level)
        {
            return new U901("U901", Level);
        }

        public U920 CreateU920(int Level)
        {
            return new U920("U920", Level);
        }

        public U921A CreateU921A(int Level)
        {
            return new U921A("U921A", Level);
        }

        public U921C CreateU921C(int Level)
        {
            return new U921C("U921C", Level);
        }

        public U997 CreateU997(int Level)
        {
            return new U997("U997", Level);
        }

        public UNLOF002_ME_CLAIM CreateUNLOF002_ME_CLAIM(int Level)
        {
            return new UNLOF002_ME_CLAIM("UNLOF002_ME_CLAIM", Level);
        }

        public UNLOF002_RAT_PAYMENT CreateUNLOF002_RAT_PAYMENT(int Level)
        {
            return new UNLOF002_RAT_PAYMENT("UNLOF002_RAT_PAYMENT", Level);
        }

        public UTL0020A_1 CreateUTL0020A_1(int Level)
        {
            return new UTL0020A_1("UTL0020A_1", Level);
        }

        public UTL0012B CreateUTL0012B(int Level)
        {
            return new UTL0012B("UTL0012B", Level);
        }

        public UTL0012D CreateUTL0012D(int Level)
        {
            return new UTL0012D("UTL0012D", Level);
        }

        public UTL0017 CreateUTL0017(int Level)
        {
            return new UTL0017("UTL0017", Level);
        }

        public UTL0018 CreateUTL0018(int Level)
        {
            return new UTL0018("UTL0018", Level);
        }

        public UTL0018A CreateUTL0018A(int Level)
        {
            return new UTL0018A("UTL0018A", Level);
        }

        public UTL0018B CreateUTL0018B(int Level)
        {
            return new UTL0018B("UTL0018B", Level);
        }

        public UTL0021 CreateUTL0021(int Level)
        {
            return new UTL0021("UTL0021", Level);
        }

        public UTL0030 CreateUTL0030(int Level)
        {
            return new UTL0030("UTL0030", Level);
        }

        public UTL0100 CreateUTL0100(int Level)
        {
            return new UTL0100("UTL0100", Level);
        }

        public UTL0119 CreateUTL0119(int Level)
        {
            return new UTL0119("UTL0119", Level);
        }

        public UTL0200 CreateUTL0200(int Level)
        {
            return new UTL0200("UTL0200", Level);
        }

        public UTL0201 CreateUTL0201(int Level)
        {
            return new UTL0201("UTL0201", Level);
        }

        public UTL0201_F119 CreateUTL0201_F119(int Level)
        {
            return new UTL0201_F119("UTL0201_F119", Level);
        }

        public UTL0F020_OHIP_SIN CreateUTL0F020_OHIP_SIN(int Level)
        {
            return new UTL0F020_OHIP_SIN("UTL0F020_OHIP_SIN", Level);
        }

        public WEBPATIENTS_DOC CreateWEBPATIENTS_DOC(int Level)
        {
            return new WEBPATIENTS_DOC("WEBPATIENTS_DOC", Level);
        }

        public WEB_BEFORE_AFTER CreateWEB_BEFORE_AFTER(int Level)
        {
            return new WEB_BEFORE_AFTER("WEB_BEFORE_AFTER", Level);
        }

        public YEAREND_1 CreateYEAREND_1(int Level)
        {
            return new YEAREND_1("YEAREND_1", Level);
        }

        public YEAREND_2 CreateYEAREND_2(int Level)
        {
            return new YEAREND_2("YEAREND_2", Level);
        }

        public CREATEF073_COSTING CreateCREATEF073_COSTING(int Level)
        {
            return new CREATEF073_COSTING("CREATEF073_COSTING", Level);
        }

        public DEL_DOCTOR CreateDEL_DOCTOR(int Level)
        {
            return new DEL_DOCTOR("DEL_DOCTOR", Level);
        }

        public PURGE_F071 CreatePURGE_F071(int Level)
        {
            return new PURGE_F071("PURGE_F071", Level);
        }

        public UPDATEF087 CreateUPDATEF087(int Level)
        {
            return new UPDATEF087("UPDATEF087", Level);
        }

        public UPDATE_CLAIMS CreateUPDATE_CLAIMS(int Level)
        {
            return new UPDATE_CLAIMS("UPDATE_CLAIMS", Level);
        }

        public UPDATE_CLAIMS_REASON CreateUPDATE_CLAIMS_REASON(int Level)
        {
            return new UPDATE_CLAIMS_REASON("UPDATE_CLAIMS_REASON", Level);
        }

        public UPDATE_F001_F002_SUB_TYPE CreateUPDATE_F001_F002_SUB_TYPE(int Level)
        {
            return new UPDATE_F001_F002_SUB_TYPE("UPDATE_F001_F002_SUB_TYPE", Level);
        }

        public UPDATE_F087_VH8 CreateUPDATE_F087_VH8(int Level)
        {
            return new UPDATE_F087_VH8("UPDATE_F087_VH8", Level);
        }

        public UPDATE_SUSPEND_ALL_DTL CreateUPDATE_SUSPEND_ALL_DTL(int Level)
        {
            return new UPDATE_SUSPEND_ALL_DTL("UPDATE_SUSPEND_ALL_DTL", Level);
        }

        public UPDATE_SUSPEND_HDR CreateUPDATE_SUSPEND_HDR(int Level)
        {
            return new UPDATE_SUSPEND_HDR("UPDATE_SUSPEND_HDR", Level);
        }

        public UPDATE_SUSPEND_HDR_DTL CreateUPDATE_SUSPEND_HDR_DTL(int Level)
        {
            return new UPDATE_SUSPEND_HDR_DTL("UPDATE_SUSPEND_HDR_DTL", Level);
        }

        public UPDATE_SUSPEND_HDR_FROM_ALL_DTL CreateUPDATE_SUSPEND_HDR_FROM_ALL_DTL(int Level)
        {
            return new UPDATE_SUSPEND_HDR_FROM_ALL_DTL("UPDATE_SUSPEND_HDR_FROM_ALL_DTL", Level);
        }

        public UPDATE_SUSP_HDR_DTL_ADD_DESC CreateUPDATE_SUSP_HDR_DTL_ADD_DESC(int Level)
        {
            return new UPDATE_SUSP_HDR_DTL_ADD_DESC("UPDATE_SUSP_HDR_DTL_ADD_DESC", Level);
        }

        public NEWU706A CreateNEWU706A(int Level)
        {
            return new NEWU706A("NEWU706A", Level);
        }

        public U014_U015 CreateU014_U015(int Level)
        {
            return new U014_U015("U014_U015", Level);
        }

        public U030B_PART2 CreateU030B_PART2(int Level)
        {
            return new U030B_PART2("U030B_PART2", Level);
        }

        public U035C CreateU035C(int Level)
        {
            return new U035C("U035C", Level);
        }

        public U115A_0 CreateU115A_0(int Level)
        {
            return new U115A_0("U115A_0", Level);
        }

        public U115A_1 CreateU115A_1(int Level)
        {
            return new U115A_1("U115A_1", Level);
        }

        public U116_POP_EXCL_DTL CreateU116_POP_EXCL_DTL(int Level)
        {
            return new U116_POP_EXCL_DTL("U116_POP_EXCL_DTL", Level);
        }

        public U210 CreateU210(int Level)
        {
            return new U210("U210", Level);
        }

        public EARNINGS_MP CreateEARNINGS_MP(int Level)
        {
            return new EARNINGS_MP("EARNINGS_MP", Level);
        }

        public EARNINGS_MP_HISTORY CreateEARNINGS_MP_HISTORY(int Level)
        {
            return new EARNINGS_MP_HISTORY("EARNINGS_MP_HISTORY", Level);
        }

        public Mp_F020_INFO_EXPORT CreateMp_F020_INFO_EXPORT(int Level)
        {
            return new Mp_F020_INFO_EXPORT("Mp_F020_INFO_EXPORT", Level);
        }

        public Mp_U115A CreateMp_U115A(int Level)
        {
            return new Mp_U115A("Mp_U115A", Level);
        }

        public Mp_U115B CreateMp_U115B(int Level)
        {
            return new Mp_U115B("Mp_U115B", Level);
        }

        public Mp_U115C CreateMp_U115C(int Level)
        {
            return new Mp_U115C("Mp_U115C", Level);
        }

        public Mp_U116 CreateMp_U116(int Level)
        {
            return new Mp_U116("Mp_U116", Level);
        }

        public Mp_U122 CreateMp_U122(int Level)
        {
            return new Mp_U122("Mp_U122", Level);
        }

        public Mp_U130 CreateMp_U130(int Level)
        {
            return new Mp_U130("Mp_U130", Level);
        }

        public Mp_U132_SP_MP CreateMp_U132_SP_MP(int Level)
        {
            return new Mp_U132_SP_MP("Mp_U132_SP_MP", Level);
        }

        public Mp_YEAREND_1 CreateMp_YEAREND_1(int Level)
        {
            return new Mp_YEAREND_1("Mp_YEAREND_1", Level);
        }

        public CLINIC26 CreateCLINIC26(int Level)
        {
            return new CLINIC26("CLINIC26", Level);
        }

        public COSTING_F119HIST CreateCOSTING_F119HIST(int Level)
        {
            return new COSTING_F119HIST("COSTING_F119HIST", Level);
        }

        public DEPT4142_DOC_LOC_CTAS CreateDEPT4142_DOC_LOC_CTAS(int Level)
        {
            return new DEPT4142_DOC_LOC_CTAS("DEPT4142_DOC_LOC_CTAS", Level);
        }

        public DEPT44 CreateDEPT44(int Level)
        {
            return new DEPT44("DEPT44", Level);
        }

        public DEPT4_AVERAGE CreateDEPT4_AVERAGE(int Level)
        {
            return new DEPT4_AVERAGE("DEPT4_AVERAGE", Level);
        }

        public DEPT54_BILLINGS CreateDEPT54_BILLINGS(int Level)
        {
            return new DEPT54_BILLINGS("DEPT54_BILLINGS", Level);
        }

        public DEPT_AVERAGE_DOCOHIP CreateDEPT_AVERAGE_DOCOHIP(int Level)
        {
            return new DEPT_AVERAGE_DOCOHIP("DEPT_AVERAGE_DOCOHIP", Level);
        }

        public DETAIL_PEDS_BILLINGS_PED CreateDETAIL_PEDS_BILLINGS_PED(int Level)
        {
            return new DETAIL_PEDS_BILLINGS_PED("DETAIL_PEDS_BILLINGS_PED", Level);
        }

        public DOC_RAT_REJECTS CreateDOC_RAT_REJECTS(int Level)
        {
            return new DOC_RAT_REJECTS("DOC_RAT_REJECTS", Level);
        }

        public DRKOLESAR CreateDRKOLESAR(int Level)
        {
            return new DRKOLESAR("DRKOLESAR", Level);
        }

        public DRKOLESAR_DOC CreateDRKOLESAR_DOC(int Level)
        {
            return new DRKOLESAR_DOC("DRKOLESAR_DOC", Level);
        }

        public DRKOLESAR_YR CreateDRKOLESAR_YR(int Level)
        {
            return new DRKOLESAR_YR("DRKOLESAR_YR", Level);
        }

        public Mp_EARNINGS_MP CreateMp_EARNINGS_MP(int Level)
        {
            return new Mp_EARNINGS_MP("Mp_EARNINGS_MP", Level);
        }

        public Mp_EARNINGS_MP_HISTORY CreateMp_EARNINGS_MP_HISTORY(int Level)
        {
            return new Mp_EARNINGS_MP_HISTORY("Mp_EARNINGS_MP_HISTORY", Level);
        }

        public EMERGENCY_PAYROLL_CLMHDRID CreateEMERGENCY_PAYROLL_CLMHDRID(int Level)
        {
            return new EMERGENCY_PAYROLL_CLMHDRID("EMERGENCY_PAYROLL_CLMHDRID", Level);
        }

        public EMERGENCY_URGENT_CLMHDRID_44 CreateEMERGENCY_URGENT_CLMHDRID_44(int Level)
        {
            return new EMERGENCY_URGENT_CLMHDRID_44("EMERGENCY_URGENT_CLMHDRID_44", Level);
        }

        public EMERG_CODES_4142 CreateEMERG_CODES_4142(int Level)
        {
            return new EMERG_CODES_4142("EMERG_CODES_4142", Level);
        }

        public EMERG_DEPT_41_42_44_BYMONTH CreateEMERG_DEPT_41_42_44_BYMONTH(int Level)
        {
            return new EMERG_DEPT_41_42_44_BYMONTH("EMERG_DEPT_41_42_44_BYMONTH", Level);
        }

        public F020_INFO_EXPORT CreateF020_INFO_EXPORT(int Level)
        {
            return new F020_INFO_EXPORT("F020_INFO_EXPORT", Level);
        }

        public F050HIST_LOCATION_DEPT4 CreateF050HIST_LOCATION_DEPT4(int Level)
        {
            return new F050HIST_LOCATION_DEPT4("F050HIST_LOCATION_DEPT4", Level);
        }

        public F088_PEDS_REJECTS CreateF088_PEDS_REJECTS(int Level)
        {
            return new F088_PEDS_REJECTS("F088_PEDS_REJECTS", Level);
        }

        public F119HISTTITHE CreateF119HISTTITHE(int Level)
        {
            return new F119HISTTITHE("F119HISTTITHE", Level);
        }

        public F119TITHE CreateF119TITHE(int Level)
        {
            return new F119TITHE("F119TITHE", Level);
        }

        public G040_CODE CreateG040_CODE(int Level)
        {
            return new G040_CODE("G040_CODE", Level);
        }

        public GERIATRIC CreateGERIATRIC(int Level)
        {
            return new GERIATRIC("GERIATRIC", Level);
        }

        public K037_CODE CreateK037_CODE(int Level)
        {
            return new K037_CODE("K037_CODE", Level);
        }

        public LEENACLAIMS CreateLEENACLAIMS(int Level)
        {
            return new LEENACLAIMS("LEENACLAIMS", Level);
        }

        public LEENA_PREMIUM CreateLEENA_PREMIUM(int Level)
        {
            return new LEENA_PREMIUM("LEENA_PREMIUM", Level);
        }

        public PEDSURGERY CreatePEDSURGERY(int Level)
        {
            return new PEDSURGERY("PEDSURGERY", Level);
        }

        public PEDS_DIAG_CODES CreatePEDS_DIAG_CODES(int Level)
        {
            return new PEDS_DIAG_CODES("PEDS_DIAG_CODES", Level);
        }

        public UCC_PATIENT_COUNT_DTL CreateUCC_PATIENT_COUNT_DTL(int Level)
        {
            return new UCC_PATIENT_COUNT_DTL("UCC_PATIENT_COUNT_DTL", Level);
        }

        public UCC_PATIENT_COUNT_HDR CreateUCC_PATIENT_COUNT_HDR(int Level)
        {
            return new UCC_PATIENT_COUNT_HDR("UCC_PATIENT_COUNT_HDR", Level);
        }

        public R123A CreateR123A(int Level)
        {
            return new R123A("R123A", Level);
        }

        public R123A CreateMp_R123A(int Level)
        {
            return new R123A("R123A", Level);
        }
        public R123B CreateR123B(int Level)
        {
            return new R123B("R123B", Level);
        }

        public R123BMP CreateR123BMP(int Level)
        {
            return new R123BMP("R123BMP", Level);
        }

        public R153A CreateR153A(int Level)
        {
            return new R153A("R153A", Level);
        }

        public R153B CreateR153B(int Level)
        {
            return new R153B("R153B", Level);
        }

        public G271_CODE CreateG271_CODE(int Level)
        {
            return new G271_CODE("G271_CODE", Level);
        }

        public CREATEF086 CreateCREATEF086(int Level)
        {
            return new CREATEF086("CREATEF086", Level);
        }

        public  YASCLARE CreateYASCLARE(int Level)
        {
            return new YASCLARE("YASCLARE", Level);
        }

        public CREATE_PS CreateCREATE_PS(int Level)
        {
            return new CREATE_PS("CREATE_PS", Level);
        }

        public PURGE_RELOF011 CreatePURGE_RELOF011(int Level)
        {
            return new PURGE_RELOF011("PURGE_RELOF011", Level);
        }

        public PURGE_RELOF020_HISTORY CreatePURGE_RELOF020_HISTORY(int Level)
        {
            return new PURGE_RELOF020_HISTORY("PURGE_RELOF020_HISTORY", Level);
        }

        public PURGE_RELOF050_HISTORY CreatePURGE_RELOF050_HISTORY(int Level)
        {
            return new PURGE_RELOF050_HISTORY("PURGE_RELOF050_HISTORY", Level);
        }

        public PURGE_RELOF084 CreatePURGE_RELOF084(int Level)
        {
            return new PURGE_RELOF084("PURGE_RELOF084", Level);
        }

        public PURGE_RELOF087 CreatePURGE_RELOF087(int Level)
        {
            return new PURGE_RELOF087("PURGE_RELOF087", Level);
        }

        public PURGE_RELOF088 CreatePURGE_RELOF088(int Level)
        {
            return new PURGE_RELOF088("PURGE_RELOF088", Level);
        }

        public PURGE_RELOF110_HISTORY CreatePURGE_RELOF110_HISTORY(int Level)
        {
            return new PURGE_RELOF110_HISTORY("PURGE_RELOF110_HISTORY", Level);
        }

        public PURGE_RELOF112_HISTORY CreatePURGE_RELOF112_HISTORY(int Level)
        {
            return new PURGE_RELOF112_HISTORY("PURGE_RELOF112_HISTORY", Level);
        }

        public PURGE_RELOF113_HISTORY CreatePURGE_RELOF113_HISTORY(int Level)
        {
            return new PURGE_RELOF113_HISTORY("PURGE_RELOF113_HISTORY", Level);
        }

        public PURGE_RELOF119_HISTORY CreatePURGE_RELOF119_HISTORY(int Level)
        {
            return new PURGE_RELOF119_HISTORY("PURGE_RELOF119_HISTORY", Level);
        }

        public PURGE_UNLOF011 CreatePURGE_UNLOF011(int Level)
        {
            return new PURGE_UNLOF011("PURGE_UNLOF011", Level);
        }

        public PURGE_UNLOF020_HISTORY CreatePURGE_UNLOF020_HISTORY(int Level)
        {
            return new PURGE_UNLOF020_HISTORY("PURGE_UNLOF020_HISTORY", Level);
        }

        public PURGE_UNLOF050_HISTORY CreatePURGE_UNLOF050_HISTORY(int Level)
        {
            return new PURGE_UNLOF050_HISTORY("PURGE_UNLOF050_HISTORY", Level);
        }

        public PURGE_UNLOF084 CreatePURGE_UNLOF084(int Level)
        {
            return new PURGE_UNLOF084("PURGE_UNLOF084", Level);
        }

        public PURGE_UNLOF087 CreatePURGE_UNLOF087(int Level)
        {
            return new PURGE_UNLOF087("PURGE_UNLOF087", Level);
        }

        public PURGE_UNLOF088 CreatePURGE_UNLOF088(int Level)
        {
            return new PURGE_UNLOF088("PURGE_UNLOF088", Level);
        }

        public PURGE_UNLOF110_HISTORY CreatePURGE_UNLOF110_HISTORY(int Level)
        {
            return new PURGE_UNLOF110_HISTORY("PURGE_UNLOF110_HISTORY", Level);
        }

        public PURGE_UNLOF112_HISTORY CreatePURGE_UNLOF112_HISTORY(int Level)
        {
            return new PURGE_UNLOF112_HISTORY("PURGE_UNLOF112_HISTORY", Level);
        }

        public PURGE_UNLOF113_HISTORY CreatePURGE_UNLOF113_HISTORY(int Level)
        {
            return new PURGE_UNLOF113_HISTORY("PURGE_UNLOF113_HISTORY", Level);
        }

        public PURGE_UNLOF119_HISTORY CreatePURGE_UNLOF119_HISTORY(int Level)
        {
            return new PURGE_UNLOF119_HISTORY("PURGE_UNLOF119_HISTORY", Level);
        }

        public PURGE_F113 CreatePURGE_F113(int Level)
        {
            return new PURGE_F113("PURGE_F113", Level);
        }
    }
}

