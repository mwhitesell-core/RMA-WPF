CREATE VIEW [INDEXED].[EXTF002HDR] AS 
SELECT KEY_CLM_TYPE, KEY_CLM_BATCH_NBR, KEY_CLM_CLAIM_NBR, CLMHDR_SERV_DATE, CLMHDR_AMT_TECH_BILLED, CLMHDR_TOT_CLAIM_AR_OHIP, CLMHDR_TOT_CLAIM_AR_OMA, CLMHDR_AGENT_CD
FROM [INDEXED].[F002_CLAIMS_MSTR_HDR]
WHERE KEY_CLM_TYPE = 'B' 
AND KEY_CLM_SERV_CODE = '00000'
AND KEY_CLM_ADJ_NBR = '0'
AND CLMHDR_BATCH_TYPE = 'C'