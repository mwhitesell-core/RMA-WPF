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
