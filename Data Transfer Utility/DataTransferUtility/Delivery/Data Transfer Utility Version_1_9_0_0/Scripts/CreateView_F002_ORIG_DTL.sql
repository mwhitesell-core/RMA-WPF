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