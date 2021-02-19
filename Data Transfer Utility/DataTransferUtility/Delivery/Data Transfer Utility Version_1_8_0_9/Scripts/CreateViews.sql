USE [%DatabaseName%]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[INDEXED].[EXTF002HDR]', 'V') IS NOT NULL
  DROP VIEW [INDEXED].[EXTF002HDR]
GO

CREATE VIEW [INDEXED].[EXTF002HDR] AS 
SELECT KEY_CLM_TYPE, KEY_CLM_BATCH_NBR, KEY_CLM_CLAIM_NBR, CLMHDR_SERV_DATE, CLMHDR_AMT_TECH_BILLED, CLMHDR_TOT_CLAIM_AR_OHIP, CLMHDR_TOT_CLAIM_AR_OMA, CLMHDR_AGENT_CD
FROM [INDEXED].[F002_CLAIMS_MSTR_HDR]
WHERE KEY_CLM_TYPE = 'B' 
AND KEY_CLM_SERV_CODE = '00000'
AND KEY_CLM_ADJ_NBR = '0'
AND CLMHDR_BATCH_TYPE = 'C'

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[INDEXED].[F002_ORIG_DTL]', 'V') IS NOT NULL
  DROP VIEW [INDEXED].[F002_ORIG_DTL]
GO

CREATE VIEW [INDEXED].[F002_ORIG_DTL] AS 
SELECT hdr.KEY_CLM_TYPE, hdr.KEY_CLM_BATCH_NBR, hdr.KEY_CLM_CLAIM_NBR, hdr.CLMHDR_SERV_DATE, hdr.CLMHDR_AMT_TECH_BILLED, hdr.CLMHDR_TOT_CLAIM_AR_OHIP, hdr.CLMHDR_TOT_CLAIM_AR_OMA, hdr.CLMHDR_AGENT_CD,
       SUM(dtl.CLMDTL_AMT_TECH_BILLED) x_amt_tech_billed,
       MIN(CAST(CAST(dtl.CLMDTL_SV_YY AS char(4)) + RIGHT('00' + LTRIM(dtl.CLMDTL_SV_MM),2) + RIGHT('00' + LTRIM(dtl.CLMDTL_SV_DD),2) AS int))  x_sv_date,
       SUM(dtl.CLMDTL_FEE_OHIP) x_amt_ohip,
       SUM(dtl.CLMDTL_FEE_OMA) x_amt_oma
FROM [INDEXED].[EXTF002HDR] hdr
INNER JOIN [INDEXED].[F002_CLAIMS_MSTR_DTL] dtl ON dtl.KEY_CLM_TYPE = hdr.KEY_CLM_TYPE AND dtl.KEY_CLM_BATCH_NBR = hdr.KEY_CLM_BATCH_NBR AND dtl.KEY_CLM_CLAIM_NBR = hdr.KEY_CLM_CLAIM_NBR
WHERE dtl.CLMDTL_OMA_CD <> '0000' 
AND dtl.CLMDTL_OMA_CD <> 'ZZZZ' 
AND dtl.CLMDTL_OMA_CD <> 'PAID'
-- Tenmporary fix to exclude bad data
AND (dtl.CLMDTL_BATCH_NBR <> '9879P003' AND dtl.CLMDTL_CLAIM_NBR <> '3')
GROUP BY hdr.KEY_CLM_BATCH_NBR, hdr.KEY_CLM_CLAIM_NBR, hdr.KEY_CLM_TYPE, hdr.CLMHDR_SERV_DATE, hdr.CLMHDR_AMT_TECH_BILLED, hdr.CLMHDR_TOT_CLAIM_AR_OHIP, hdr.CLMHDR_TOT_CLAIM_AR_OMA, hdr.CLMHDR_AGENT_CD

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[INDEXED].[DIFF_SV_DATE_SEL]', 'V') IS NOT NULL
  DROP VIEW [INDEXED].[DIFF_SV_DATE_SEL]
GO

CREATE VIEW [INDEXED].[DIFF_SV_DATE_SEL] AS 
SELECT details.KEY_CLM_TYPE, details.KEY_CLM_BATCH_NBR,details.KEY_CLM_CLAIM_NBR, details.CLMHDR_AMT_TECH_BILLED, details.CLMHDR_TOT_CLAIM_AR_OHIP, details.CLMHDR_TOT_CLAIM_AR_OMA, details.CLMHDR_AGENT_CD,
       details.X_AMT_TECH_BILLED, details.X_SV_DATE, details.X_AMT_OHIP, details.X_AMT_OMA 
FROM (
      SELECT DISTINCT hdr.KEY_CLM_TYPE, hdr.KEY_CLM_BATCH_NBR, hdr.KEY_CLM_CLAIM_NBR, hdr.CLMHDR_AMT_TECH_BILLED, hdr.CLMHDR_TOT_CLAIM_AR_OHIP, hdr.CLMHDR_TOT_CLAIM_AR_OMA, hdr.CLMHDR_AGENT_CD, hdr.X_AMT_TECH_BILLED,
                      hdr.X_SV_DATE, hdr.X_AMT_OHIP, hdr.X_AMT_OMA 
      FROM [INDEXED].[F002_ORIG_DTL] hdr
      INNER JOIN (
                  SELECT dtl.KEY_CLM_BATCH_NBR key_clm_batch_nbr1, dtl.KEY_CLM_CLAIM_NBR key_clm_claim_nbr1, dtl.KEY_CLM_TYPE 
                  FROM [INDEXED].[F002_ORIG_DTL] dtl
                  WHERE dtl.KEY_CLM_TYPE = key_clm_type 
                  AND dtl.KEY_CLM_BATCH_NBR = dtl.KEY_CLM_BATCH_NBR
                  AND dtl.KEY_CLM_CLAIM_NBR = dtl.KEY_CLM_CLAIM_NBR
                  GROUP BY dtl.KEY_CLM_CLAIM_NBR, dtl.KEY_CLM_BATCH_NBR, dtl.KEY_CLM_TYPE 
                 ) AS diff_sv_date_sel ON hdr.KEY_CLM_BATCH_NBR = diff_sv_date_sel.key_clm_batch_nbr1 AND hdr.KEY_CLM_CLAIM_NBR = diff_sv_date_sel.key_clm_claim_nbr1 AND diff_sv_date_sel.KEY_CLM_TYPE = hdr.KEY_CLM_TYPE
      WHERE (hdr.CLMHDR_SERV_DATE = 0)
      OR (hdr.CLMHDR_SERV_DATE <> hdr.X_SV_DATE)
     ) AS details

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[INDEXED].[DIFF_AMTS_SEL]', 'V') IS NOT NULL
  DROP VIEW [INDEXED].[DIFF_AMTS_SEL]
GO

CREATE VIEW [INDEXED].[DIFF_AMTS_SEL] AS 
SELECT details.KEY_CLM_TYPE, details.KEY_CLM_BATCH_NBR, details.KEY_CLM_CLAIM_NBR, details.CLMHDR_AMT_TECH_BILLED, details.CLMHDR_TOT_CLAIM_AR_OHIP, details.CLMHDR_TOT_CLAIM_AR_OMA, details.CLMHDR_AGENT_CD,
       details.X_AMT_TECH_BILLED, details.X_SV_DATE, details.X_AMT_OHIP, details.X_AMT_OMA 
FROM (
      SELECT DISTINCT hdr.KEY_CLM_TYPE, hdr.KEY_CLM_BATCH_NBR, hdr.KEY_CLM_CLAIM_NBR, hdr.CLMHDR_AMT_TECH_BILLED, hdr.CLMHDR_TOT_CLAIM_AR_OHIP, hdr.CLMHDR_TOT_CLAIM_AR_OMA, hdr.CLMHDR_AGENT_CD, hdr.X_AMT_TECH_BILLED,
                      hdr.X_SV_DATE, hdr.X_AMT_OHIP, hdr.X_AMT_OMA 
      FROM [INDEXED].[F002_ORIG_DTL] hdr
      INNER JOIN (
                  SELECT dtl.KEY_CLM_BATCH_NBR key_clm_batch_nbr1, dtl.KEY_CLM_CLAIM_NBR key_clm_claim_nbr1, dtl.KEY_CLM_TYPE 
                  FROM [INDEXED].[F002_ORIG_DTL] dtl
                  WHERE dtl.KEY_CLM_TYPE = dtl.KEY_CLM_TYPE AND dtl.KEY_CLM_BATCH_NBR = dtl.KEY_CLM_BATCH_NBR AND dtl.KEY_CLM_CLAIM_NBR = dtl.KEY_CLM_CLAIM_NBR
                  GROUP BY dtl.KEY_CLM_CLAIM_NBR, dtl.KEY_CLM_BATCH_NBR, dtl.KEY_CLM_TYPE 
                 ) AS diff_amts_sel ON diff_amts_sel.key_clm_batch_nbr1 = hdr.KEY_CLM_BATCH_NBR AND diff_amts_sel.key_clm_claim_nbr1 = hdr.key_clm_claim_nbr AND diff_amts_sel.KEY_CLM_TYPE = hdr.KEY_CLM_TYPE 
      WHERE (hdr.X_AMT_TECH_BILLED <> hdr.CLMHDR_AMT_TECH_BILLED)
      OR (hdr.X_AMT_OHIP <> hdr.CLMHDR_TOT_CLAIM_AR_OHIP)
      OR (hdr.X_AMT_OMA <> hdr.CLMHDR_TOT_CLAIM_AR_OMA)
     ) AS details

GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[INDEXED].[vw_OUTSTANDING_CLAIMS]', 'V') IS NOT NULL
  DROP VIEW [INDEXED].[vw_OUTSTANDING_CLAIMS]
GO

CREATE VIEW [INDEXED].vw_OUTSTANDING_CLAIMS AS 
SELECT TOP 100 PERCENT  a.ROWID, b.CLMHDR_BATCH_NBR, b.CLMHDR_CLAIM_NBR, b.CLMHDR_ADJ_OMA_CD, b.CLMHDR_ADJ_OMA_SUFF, b.CLMHDR_ADJ_ADJ_NBR, b.CLMHDR_BATCH_TYPE, b.CLMHDR_ADJ_CD_SUB_TYPE
                      , b.CLMHDR_DOC_NBR_OHIP, b.CLMHDR_DOC_SPEC_CD, b.CLMHDR_REFER_DOC_NBR, b.CLMHDR_DIAG_CD, b.CLMHDR_LOC, b.CLMHDR_HOSP, b.CLMHDR_AGENT_CD, b.CLMHDR_ADJ_CD
                      , b.CLMHDR_TAPE_SUBMIT_IND, b.CLMHDR_I_O_PAT_IND, b.CLMHDR_PAT_KEY_TYPE, b.CLMHDR_PAT_KEY_DATA, b.CLMHDR_PAT_ACRONYM6, b.CLMHDR_PAT_ACRONYM3
                      , b.CLMHDR_REFERENCE, b.CLMHDR_DATE_ADMIT, b.CLMHDR_DOC_DEPT, b.CLMHDR_MSG_NBR, b.CLMHDR_REPRINT_FLAG, b.CLMHDR_SUB_NBR, b.CLMHDR_AUTO_LOGOUT
                      , b.CLMHDR_FEE_COMPLEX, b.CLMHDR_CURR_PAYMENT, b.CLMHDR_DATE_PERIOD_END, b.CLMHDR_CYCLE_NBR, b.CLMHDR_DATE_SYS, b.CLMHDR_AMT_TECH_BILLED, b.CLMHDR_AMT_TECH_PAID
                      , b.CLMHDR_TOT_CLAIM_AR_OMA, b.CLMHDR_TOT_CLAIM_AR_OHIP, b.CLMHDR_MANUAL_AND_TAPE_PAYMENTS, b.CLMHDR_STATUS_OHIP, b.CLMHDR_MANUAL_REVIEW, b.CLMHDR_SUBMIT_DATE
                      , b.CLMHDR_CONFIDENTIAL_FLAG, b.CLMHDR_SERV_DATE, b.CLMHDR_ELIG_ERROR, b.CLMHDR_ELIG_STATUS, b.CLMHDR_SERV_ERROR, b.CLMHDR_SERV_STATUS, b.CLMHDR_ORIG_BATCH_NBR
                      , b.CLMHDR_ORIG_CLAIM_NBR, b.KEY_CLM_TYPE, b.KEY_CLM_BATCH_NBR, b.KEY_CLM_CLAIM_NBR, b.KEY_CLM_SERV_CODE, b.KEY_CLM_ADJ_NBR
                      , b.KEY_P_CLM_TYPE, b.KEY_P_CLM_DATA
                      , c.ICONST_CLINIC_NBR_1_2, c.ICONST_CLINIC_NBR, c.ICONST_CLINIC_NAME, c.ICONST_CLINIC_CYCLE_NBR, c.ICONST_DATE_PERIOD_END_YY, c.ICONST_DATE_PERIOD_END_MM, c.ICONST_DATE_PERIOD_END_DD
                      , c.ICONST_CLINIC_ADDR_L1, c.ICONST_CLINIC_ADDR_L2, c.ICONST_CLINIC_ADDR_L3, c.ICONST_CLINIC_CARD_COLOUR, c.ICONST_CLINIC_OVER_LIM1
                      , c.ICONST_CLINIC_UNDER_LIM2, c.ICONST_CLINIC_UNDER_LIM3, c.ICONST_CLINIC_OVER_LIM4, c.ICONST_CLINIC_BATCH_NBR, c.ICONST_REDUCTION_FACTOR, c.ICONST_OVERPAY_FACTOR
                      , c.ICONSTPEDNUMBERWITHINFISCALYEAR, c.ICONST_DATE_PERIOD_END_1, c.ICONST_DATE_PERIOD_END_2, c.ICONST_DATE_PERIOD_END_3, c.ICONST_DATE_PERIOD_END_4
                      , c.ICONST_DATE_PERIOD_END_5, c.ICONST_DATE_PERIOD_END_6, c.ICONST_DATE_PERIOD_END_7, c.ICONST_DATE_PERIOD_END_8, c.ICONST_DATE_PERIOD_END_9, c.ICONST_DATE_PERIOD_END_10
                      , c.ICONST_DATE_PERIOD_END_11, c.ICONST_DATE_PERIOD_END_12, c.ICONST_DATE_PERIOD_END_13, c.ICONST_CLINIC_PAY_BATCH_NBR, c.ICONST_MONTHEND
                      , d.DOC_NBR, d.DOC_DEPT, d.DOC_OHIP_NBR, d.DOC_SIN_123, d.DOC_SIN_456, d.DOC_SIN_789, d.DOC_SPEC_CD, d.DOC_HOSP_NBR, d.DOC_NAME, d.DOC_NAME_SOUNDEX
                      , d.DOC_INIT1, d.DOC_INIT2, d.DOC_INIT3, d.DOC_ADDR_OFFICE_1, d.DOC_ADDR_OFFICE_2, d.DOC_ADDR_OFFICE_3, d.DOC_ADDR_OFFICE_PC1, d.DOC_ADDR_OFFICE_PC2
                      , d.DOC_ADDR_OFFICE_PC3, d.DOC_ADDR_OFFICE_PC4, d.DOC_ADDR_OFFICE_PC5, d.DOC_ADDR_OFFICE_PC6, d.DOC_ADDR_HOME_1, d.DOC_ADDR_HOME_2, d.DOC_ADDR_HOME_3
                      , d.DOC_ADDR_HOME_PC1, d.DOC_ADDR_HOME_PC2, d.DOC_ADDR_HOME_PC3, d.DOC_ADDR_HOME_PC4, d.DOC_ADDR_HOME_PC5, d.DOC_ADDR_HOME_PC6, d.DOC_FULL_PART_IND
                      , d.DOC_BANK_NBR, d.DOC_BANK_BRANCH, d.DOC_BANK_ACCT, d.DOC_DATE_FAC_START_YY, d.DOC_DATE_FAC_START_MM, d.DOC_DATE_FAC_START_DD, d.DOC_DATE_FAC_TERM_YY
                      , d.DOC_DATE_FAC_TERM_MM, d.DOC_DATE_FAC_TERM_DD, d.DOC_YTDGUA, d.DOC_YTDGUB, d.DOC_YTDGUC, d.DOC_YTDGUD, d.DOC_YTDCEA, d.DOC_YTDCEX, d.DOC_YTDEAR
                      , d.DOC_YTDINC, d.DOC_YTDEFT, d.DOC_TOTINC_G, d.DOC_EP_DATE_DEPOSIT, d.DOC_TOTINC, d.DOC_EP_CEIEXP, d.DOC_ADJCEA, d.DOC_ADJCEX, d.DOC_CEICEA
                      , d.DOC_CEICEX, d.CEICEA_PRT_FORMAT, d.CEICEX_PRT_FORMAT, d.YTDCEA_PRT_FORMAT, d.YTDCEX_PRT_FORMAT, d.DOC_SPEC_CD_2, d.DOC_SPEC_CD_3, d.DOC_YTDINC_G
                      , d.DOC_RMA_EXPENSE_PERCENT_MISC, d.DOC_AFP_PAYM_GROUP, d.DOC_DEPT_2, d.DOC_IND_PAYS_GST, d.DOC_NX_AVAIL_BATCH, d.DOC_NX_AVAIL_BATCH_2, d.DOC_NX_AVAIL_BATCH_3
                      , d.DOC_NX_AVAIL_BATCH_4, d.DOC_NX_AVAIL_BATCH_5, d.DOC_NX_AVAIL_BATCH_6, d.DOC_YRLY_CEILING_COMPUTED, d.DOC_YRLY_EXPENSE_COMPUTED, d.DOC_RMA_EXPENSE_PERCENT_REG
                      , d.DOC_SUB_SPECIALTY, d.DOC_PAYEFT, d.DOC_YTDDED, d.DOC_DEPT_EXPENSE_PERCENT_MISC, d.DOC_DEPT_EXPENSE_PERCENT_REG, d.DOC_EP_PED, d.DOC_EP_PAY_CODE, d.DOC_EP_PAY_SUB_CODE
                      , d.DOC_PARTNERSHIP, d.DOC_IND_HOLDBACK_ACTIVE, d.GROUP_REGULAR_SERVICE, d.GROUP_OVER_SERVICED, d.DOC_LOC_1_S1, d.DOC_LOC_1_S2, d.DOC_LOC_1_S3, d.DOC_LOC_2_S1
                      , d.DOC_LOC_2_S2, d.DOC_LOC_2_S3, d.DOC_LOC_3_S1, d.DOC_LOC_3_S2, d.DOC_LOC_3_S3, d.DOC_LOC_4_S1, d.DOC_LOC_4_S2, d.DOC_LOC_4_S3, d.DOC_LOC_5_S1, d.DOC_LOC_5_S2
                      , d.DOC_LOC_5_S3, d.DOC_LOC_6_S1, d.DOC_LOC_6_S2, d.DOC_LOC_6_S3, d.DOC_LOC_7_S1, d.DOC_LOC_7_S2, d.DOC_LOC_7_S3, d.DOC_LOC_8_S1, d.DOC_LOC_8_S2, d.DOC_LOC_8_S3
                      , d.DOC_LOC_9_S1, d.DOC_LOC_9_S2, d.DOC_LOC_9_S3, d.DOC_LOC_10_S1, d.DOC_LOC_10_S2, d.DOC_LOC_10_S3, d.DOC_LOC_11_S1, d.DOC_LOC_11_S2, d.DOC_LOC_11_S3, d.DOC_LOC_12_S1, d.DOC_LOC_12_S2
                      , d.DOC_LOC_12_S3, d.DOC_LOC_13_S1, d.DOC_LOC_13_S2, d.DOC_LOC_13_S3, d.DOC_LOC_14_S1, d.DOC_LOC_14_S2, d.DOC_LOC_14_S3, d.DOC_LOC_15_S1, d.DOC_LOC_15_S2, d.DOC_LOC_15_S3
                      , d.DOC_LOC_16_S1, d.DOC_LOC_16_S2, d.DOC_LOC_16_S3, d.DOC_LOC_17_S1, d.DOC_LOC_17_S2, d.DOC_LOC_17_S3, d.DOC_LOC_18_S1, d.DOC_LOC_18_S2, d.DOC_LOC_18_S3, d.DOC_LOC_19_S1
                      , d.DOC_LOC_19_S2, d.DOC_LOC_19_S3, d.DOC_LOC_20_S1, d.DOC_LOC_20_S2, d.DOC_LOC_20_S3, d.DOC_LOC_21_S1, d.DOC_LOC_21_S2, d.DOC_LOC_21_S3, d.DOC_LOC_22_S1, d.DOC_LOC_22_S2
                      , d.DOC_LOC_22_S3, d.DOC_LOC_23_S1, d.DOC_LOC_23_S2, d.DOC_LOC_23_S3, d.DOC_LOC_24_S1, d.DOC_LOC_24_S2, d.DOC_LOC_24_S3, d.DOC_LOC_25_S1, d.DOC_LOC_25_S2, d.DOC_LOC_25_S3
                      , d.DOC_LOC_26_S1, d.DOC_LOC_26_S2, d.DOC_LOC_26_S3, d.DOC_LOC_27_S1, d.DOC_LOC_27_S2, d.DOC_LOC_27_S3, d.DOC_LOC_28_S1, d.DOC_LOC_28_S2, d.DOC_LOC_28_S3
                      , d.DOC_LOC_29_S1, d.DOC_LOC_29_S2, d.DOC_LOC_29_S3, d.DOC_LOC_30_S1, d.DOC_LOC_30_S2, d.DOC_LOC_30_S3
FROM INDEXED.F002_OUTSTANDINg a
INNER JOIN INDEXED.F002_CLAIMS_MSTR_HDR b ON a.KEY_CLM_TYPE = b.KEY_CLM_TYPE AND 
                                             a.KEY_CLM_BATCH_NBR = b.KEY_CLM_BATCH_NBR AND 
                                             a.KEY_CLM_CLAIM_NBR = b.KEY_CLM_CLAIM_NBR AND 
                                             b.KEY_CLM_TYPE = 'B' AND 
                                             b.KEY_CLM_SERV_CODE = '00000' AND
                                             b.KEY_CLM_ADJ_NBR = 0 
INNER JOIN INDEXED.ICONST_MSTR_REC c ON SUBSTRING(a.KEY_CLM_BATCH_NBR, 1, 2) = c.ICONST_CLINIC_NBR_1_2
INNER JOIN INDEXED.F020_DOCTOR_MSTR d ON SUBSTRING(a.KEY_CLM_BATCH_NBR, 3, 3) = d.doc_nbr
WHERE (c.ICONST_CLINIC_NBR_1_2 = '22' OR c.ICONST_CLINIC_NBR_1_2 = '23' OR c.ICONST_CLINIC_NBR_1_2 = '24' OR c.ICONST_CLINIC_NBR_1_2 = '25' OR c.ICONST_CLINIC_NBR_1_2 = '26')
OR (ICONST_CLINIC_CARD_COLOUR = 'Y' AND  d.DOC_AFP_PAYM_GROUP <> ' ' AND (c.ICONST_CLINIC_NBR_1_2 < '71' OR c.ICONST_CLINIC_NBR_1_2> '75'))
ORDER BY d.DOC_NBR
