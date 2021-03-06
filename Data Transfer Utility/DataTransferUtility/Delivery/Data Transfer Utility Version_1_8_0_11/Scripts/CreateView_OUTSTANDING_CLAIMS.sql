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
                      , d.DOC_PARTNERSHIP, d.DOC_IND_HOLDBACK_ACTIVE, d.GROUP_REGULAR_SERVICE, d.GROUP_OVER_SERVICED
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
