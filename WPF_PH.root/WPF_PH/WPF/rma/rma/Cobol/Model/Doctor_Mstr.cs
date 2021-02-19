﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rma.Cobol.Model
{
    public class Doctor_Mstr
    {
        public Guid ROWID { get; set; }
        public string DOC_NBR { get; set; }
        public int DOC_DEPT { get; set; }
        public long DOC_OHIP_NBR { get; set; }
        public long DOC_SIN_123 { get; set; }
        public int DOC_SIN_456 { get; set; }
        public int DOC_SIN_789 { get; set; }
        public int DOC_SPEC_CD { get; set; }
        public string DOC_HOSP_NBR { get; set; }
        public string DOC_NAME { get; set; }
        public string DOC_NAME_SOUNDEX { get; set; }
        public string DOC_INIT1 { get; set; }
        public string DOC_INIT2 { get; set; }
        public string DOC_INIT3 { get; set; }
        public string DOC_ADDR_OFFICE_1 { get; set; }
        public string DOC_ADDR_OFFICE_2 { get; set; }
        public string DOC_ADDR_OFFICE_3 { get; set; }
        public string DOC_ADDR_OFFICE_PC1 { get; set; }
        public int DOC_ADDR_OFFICE_PC2 { get; set; }
        public string DOC_ADDR_OFFICE_PC3 { get; set; }
        public int DOC_ADDR_OFFICE_PC4 { get; set; }
        public string DOC_ADDR_OFFICE_PC5 { get; set; }
        public int DOC_ADDR_OFFICE_PC6 { get; set; }
        public string DOC_ADDR_HOME_1 { get; set; }
        public string DOC_ADDR_HOME_2 { get; set; }
        public string DOC_ADDR_HOME_3 { get; set; }
        public string DOC_ADDR_HOME_PC1 { get; set; }
        public int DOC_ADDR_HOME_PC2 { get; set; }
        public string DOC_ADDR_HOME_PC3 { get; set; }
        public int DOC_ADDR_HOME_PC4 { get; set; }
        public string DOC_ADDR_HOME_PC5 { get; set; }
        public int DOC_ADDR_HOME_PC6 { get; set; }
        public string DOC_FULL_PART_IND { get; set; }
        public int DOC_BANK_NBR { get; set; }
        public long DOC_BANK_BRANCH { get; set; }
        public string DOC_BANK_ACCT { get; set; }
        public long DOC_DATE_FAC_START_YY { get; set; }
        public int DOC_DATE_FAC_START_MM { get; set; }
        public int DOC_DATE_FAC_START_DD { get; set; }
        public long DOC_DATE_FAC_TERM_YY { get; set; }
        public int DOC_DATE_FAC_TERM_MM { get; set; }
        public int DOC_DATE_FAC_TERM_DD { get; set; }
        public long DOC_YTDGUA { get; set; }
        public long DOC_YTDGUB { get; set; }
        public long DOC_YTDGUC { get; set; }
        public long DOC_YTDGUD { get; set; }
        public long DOC_YTDCEA { get; set; }
        public long DOC_YTDCEX { get; set; }
        public long DOC_YTDEAR { get; set; }
        public long DOC_YTDINC { get; set; }
        public long DOC_YTDEFT { get; set; }
        public long DOC_TOTINC_G { get; set; }
        public long DOC_EP_DATE_DEPOSIT { get; set; }
        public long DOC_TOTINC { get; set; }
        public long DOC_EP_CEIEXP { get; set; }
        public long DOC_ADJCEA { get; set; }
        public long DOC_ADJCEX { get; set; }
        public long DOC_CEICEA { get; set; }
        public long DOC_CEICEX { get; set; }
        public string CEICEA_PRT_FORMAT { get; set; }
        public string CEICEX_PRT_FORMAT { get; set; }
        public string YTDCEA_PRT_FORMAT { get; set; }
        public string YTDCEX_PRT_FORMAT { get; set; }
        public int DOC_SPEC_CD_2 { get; set; }
        public int DOC_SPEC_CD_3 { get; set; }
        public long DOC_YTDINC_G { get; set; }
        public long DOC_RMA_EXPENSE_PERCENT_MISC { get; set; }
        public string DOC_AFP_PAYM_GROUP { get; set; }
        public int DOC_DEPT_2 { get; set; }
        public string DOC_IND_PAYS_GST { get; set; }
        public int DOC_NX_AVAIL_BATCH { get; set; }
        public int DOC_NX_AVAIL_BATCH_2 { get; set; }
        public int DOC_NX_AVAIL_BATCH_3 { get; set; }
        public int DOC_NX_AVAIL_BATCH_4 { get; set; }
        public int DOC_NX_AVAIL_BATCH_5 { get; set; }
        public int DOC_NX_AVAIL_BATCH_6 { get; set; }
        public long DOC_YRLY_CEILING_COMPUTED { get; set; }
        public long DOC_YRLY_EXPENSE_COMPUTED { get; set; }
        public long DOC_RMA_EXPENSE_PERCENT_REG { get; set; }
        public string DOC_SUB_SPECIALTY { get; set; }
        public long DOC_PAYEFT { get; set; }
        public long DOC_YTDDED { get; set; }
        public long DOC_DEPT_EXPENSE_PERCENT_MISC { get; set; }
        public long DOC_DEPT_EXPENSE_PERCENT_REG { get; set; }
        public long DOC_EP_PED { get; set; }
        public string DOC_EP_PAY_CODE { get; set; }
        public string DOC_EP_PAY_SUB_CODE { get; set; }
        public string DOC_PARTNERSHIP { get; set; }
        public string DOC_IND_HOLDBACK_ACTIVE { get; set; }
        public string GROUP_REGULAR_SERVICE { get; set; }
        public string GROUP_OVER_SERVICED { get; set; }
        public string DOC_LOC_1_S1 { get; set; }
        public string DOC_LOC_1_S2 { get; set; }
        public string DOC_LOC_1_S3 { get; set; }
        public string DOC_LOC_2_S1 { get; set; }
        public string DOC_LOC_2_S2 { get; set; }
        public string DOC_LOC_2_S3 { get; set; }
        public string DOC_LOC_3_S1 { get; set; }
        public string DOC_LOC_3_S2 { get; set; }
        public string DOC_LOC_3_S3 { get; set; }
        public string DOC_LOC_4_S1 { get; set; }
        public string DOC_LOC_4_S2 { get; set; }
        public string DOC_LOC_4_S3 { get; set; }
        public string DOC_LOC_5_S1 { get; set; }
        public string DOC_LOC_5_S2 { get; set; }
        public string DOC_LOC_5_S3 { get; set; }
        public string DOC_LOC_6_S1 { get; set; }
        public string DOC_LOC_6_S2 { get; set; }
        public string DOC_LOC_6_S3 { get; set; }
        public string DOC_LOC_7_S1 { get; set; }
        public string DOC_LOC_7_S2 { get; set; }
        public string DOC_LOC_7_S3 { get; set; }
        public string DOC_LOC_8_S1 { get; set; }
        public string DOC_LOC_8_S2 { get; set; }
        public string DOC_LOC_8_S3 { get; set; }
        public string DOC_LOC_9_S1 { get; set; }
        public string DOC_LOC_9_S2 { get; set; }
        public string DOC_LOC_9_S3 { get; set; }
        public string DOC_LOC_10_S1 { get; set; }
        public string DOC_LOC_10_S2 { get; set; }
        public string DOC_LOC_10_S3 { get; set; }
        public string DOC_LOC_11_S1 { get; set; }
        public string DOC_LOC_11_S2 { get; set; }
        public string DOC_LOC_11_S3 { get; set; }
        public string DOC_LOC_12_S1 { get; set; }
        public string DOC_LOC_12_S2 { get; set; }
        public string DOC_LOC_12_S3 { get; set; }
        public string DOC_LOC_13_S1 { get; set; }
        public string DOC_LOC_13_S2 { get; set; }
        public string DOC_LOC_13_S3 { get; set; }
        public string DOC_LOC_14_S1 { get; set; }
        public string DOC_LOC_14_S2 { get; set; }
        public string DOC_LOC_14_S3 { get; set; }
        public string DOC_LOC_15_S1 { get; set; }
        public string DOC_LOC_15_S2 { get; set; }
        public string DOC_LOC_15_S3 { get; set; }
        public string DOC_LOC_16_S1 { get; set; }
        public string DOC_LOC_16_S2 { get; set; }
        public string DOC_LOC_16_S3 { get; set; }
        public string DOC_LOC_17_S1 { get; set; }
        public string DOC_LOC_17_S2 { get; set; }
        public string DOC_LOC_17_S3 { get; set; }
        public string DOC_LOC_18_S1 { get; set; }
        public string DOC_LOC_18_S2 { get; set; }
        public string DOC_LOC_18_S3 { get; set; }
        public string DOC_LOC_19_S1 { get; set; }
        public string DOC_LOC_19_S2 { get; set; }
        public string DOC_LOC_19_S3 { get; set; }
        public string DOC_LOC_20_S1 { get; set; }
        public string DOC_LOC_20_S2 { get; set; }
        public string DOC_LOC_20_S3 { get; set; }
        public string DOC_LOC_21_S1 { get; set; }
        public string DOC_LOC_21_S2 { get; set; }
        public string DOC_LOC_21_S3 { get; set; }
        public string DOC_LOC_22_S1 { get; set; }
        public string DOC_LOC_22_S2 { get; set; }
        public string DOC_LOC_22_S3 { get; set; }
        public string DOC_LOC_23_S1 { get; set; }
        public string DOC_LOC_23_S2 { get; set; }
        public string DOC_LOC_23_S3 { get; set; }
        public string DOC_LOC_24_S1 { get; set; }
        public string DOC_LOC_24_S2 { get; set; }
        public string DOC_LOC_24_S3 { get; set; }
        public string DOC_LOC_25_S1 { get; set; }
        public string DOC_LOC_25_S2 { get; set; }
        public string DOC_LOC_25_S3 { get; set; }
        public string DOC_LOC_26_S1 { get; set; }
        public string DOC_LOC_26_S2 { get; set; }
        public string DOC_LOC_26_S3 { get; set; }
        public string DOC_LOC_27_S1 { get; set; }
        public string DOC_LOC_27_S2 { get; set; }
        public string DOC_LOC_27_S3 { get; set; }
        public string DOC_LOC_28_S1 { get; set; }
        public string DOC_LOC_28_S2 { get; set; }
        public string DOC_LOC_28_S3 { get; set; }
        public string DOC_LOC_29_S1 { get; set; }
        public string DOC_LOC_29_S2 { get; set; }
        public string DOC_LOC_29_S3 { get; set; }
        public string DOC_LOC_30_S1 { get; set; }
        public string DOC_LOC_30_S2 { get; set; }
        public string DOC_LOC_30_S3 { get; set; }
    }
}
