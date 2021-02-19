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
