identification division.     
program-id. createfiles.     
author. dyad systems inc.     
installation. rma.     
date-written. 98/01/09.     
date-compiled.     
security.     
*
*
* 2000/may/17 B.E.	- added f011-pat-mstr-elig-history
* 2003/jan/20 M.C.	- added f123-company-mstr 
* 2003/nov/05 b.e.	- alpha doctor number     
* 2005/jan/05 b.e.	- f027-contacts-mstr
*			- f028-contacts-info-mstr
*			- open/closed files in 2 sections as the original
*			  code opened too many files at one time.
* 2005/feb/03 b.e.	- added f029-followup-events and f020-doctor-extra
* 2005/may/19 M.C.	- cannot add f029-followup-events in cobol because
*			  powerhouse has defined date segment as descending order
*			  as part of the key and Cobol cannot be done
*			- they have been commented out 
* 2011/may/17 M.C.	- added f201-sli-oma-code-suff mstr
* 2011/may/24 M.C.	- comment out f020-doctor-extra, Cobol does not use it
* 2015/Mar/17 MC2       - added f040-dtl

environment division.     
input-output section.     
file-control.     

    copy "eft_logical_rec_file.slr".
    copy "f001_batch_control_file.slr".

    select claims-extra-mstr
*       assign index to "F002_CLAIMS_EXTRA.00.IDX"
*mf     assign data  to "F002_CLAIMS_EXTRA.DB"
        assign to disk "$pb_data/f002_claims_extra"
        organization is indexed
        access mode is dynamic
        record key is clmhdr-rma-clm-nbr
        status is status-cobol-claims-extra.

    copy "f002_claim_shadow.slr".
    copy "f002_claim_shadow_new.slr".
    copy "f002_claims_mstr.slr".
    copy "f002_claims_mstr_new.slr".
    copy "f002_suspend_address.slr".
    copy "f002_suspend_dtl.slr".
    copy "f002_suspend_hdr.slr".
    copy "f002_suspend_desc.slr".

******    copy "f010_new_patient_file.slr".
    copy "f010_new_patient_mstr.slr".

    copy "f011_pat_mstr_elig_history.slr".

    copy "f020_doctor_mstr.slr".
* 2011/05/24 - MC - comment out
*    copy "f020_doctor_extra_mstr.slr".
    copy "f027_contacts_mstr.slr".
    copy "f028_contacts_info_mstr.slr".
**  copy "f029_followup_events_mstr.slr".
    copy "f030_locations_mstr.slr".
    copy "f040_oma_fee_mstr.slr".
    copy "f050_doc_revenue_mstr.slr".
    copy "f050tp_doc_revenue_mstr.slr".
    copy "f051_doc_cash_mstr.slr".
    copy "f051tp_doc_cash_mstr.slr".

    copy "f060_cheque_reg_mstr.slr".
    copy "f070_dept_mstr.slr".
    copy "f071_client_rma_claim_nbr.slr".
    copy "f072_client_mstr.slr".
    copy "f073_client_doc_mstr.slr".
    copy "f080_bank_mstr.slr".
    copy "f085_rejected_claims.slr".
    copy "f090_constants_mstr.slr".
    copy "f091_diagnostic_codes.slr".
    copy "f094_msg_sub_mstr.slr".
    copy "f096_ohip_pay_code.slr".
    copy "f200_oscar_provider.slr".

    copy "r051_docrev_work_mstr.slr".

* 2003/01/20 - MC
    copy "f123_company_mstr.slr".  
* 2003/01/20 - end

* 2011/05/17 - MC
    copy "f201_sli_oma_code_suff.slr".
* 2011/05/17 - end

* MC2
    copy "f040_dtl.slr".
* MC2 - end

select corrected-pat     
	assign        to "f086_pat_id.dat"     
        file status   is status-corrected-pat.     

*
* The default file format only allows 65K duplicates within a key
* The IDXFORMAT"4" format allows  up to 4M duplicatesS
* $SET IDXFORMAT"4"
*    copy "f010_new_patient_file.slr".
*    copy "f010_new_patient_mstr.slr".

data division.     
file section.     
    copy "eft_logical_rec_file.fd".
    copy "f001_batch_control_file.fd".

fd  claims-extra-mstr
*mf     index block contains 11 characters
*mf     data  block contains 22 characters
* 2003/12/08 - MC
*              block contains 22 characters
*        record      contains 22 characters .
              block contains 21 characters
        record      contains 21 characters .
* 2003/12/08 - end
*mf     feedback is feedback-claims-extra.
 
01  claims-extra-mstr-rec.
    05  clmhdr-rma-clm-nbr.
*!        10  clmhdr-rma-batch-nbr        pic 9(9).
        10  clmhdr-rma-batch-nbr        pic x(8).
        10  clmhdr-rma-claim-nbr        pic 99.
    05  clmhdr-ohip-clm-nbr             pic x(11).

    copy "f002_claim_shadow.fd".
    copy "f002_claim_shadow_new.fd".
    copy "f002_claims_mstr.fd".
    copy "f002_claims_mstr_new.fd".
    copy "f002_suspend_address.fd".
    copy "f002_suspend_dtl.fd".
    copy "f002_suspend_hdr.fd".
    copy "f002_suspend_desc.fd".

*****    copy "f010_new_patient_file.fd".
    copy "f010_patient_mstr.fd".

    copy "f011_pat_mstr_elig_history.fd".

    copy "f020_doctor_mstr.fd".
* 2011/05/24 - MC - comment out
*    copy "f020_doctor_extra_mstr.fd".
    copy "f027_contacts_mstr.fd".
    copy "f028_contacts_info_mstr.fd".
**  copy "f029_followup_events_mstr.fd".
    copy "f030_locations_mstr.fd".
    copy "f040_oma_fee_mstr.fd".
    copy "f050_doc_revenue_mstr.fd".
    copy "f050tp_doc_revenue_mstr.fd".
    copy "f051_doc_cash_mstr.fd".
    copy "f051tp_doc_cash_mstr.fd".
    copy "f060_cheque_reg_mstr.fd".
    copy "f070_dept_mstr.fd".
    copy "f071_client_rma_claim_nbr.fd".
    copy "f072_client_mstr.fd".
    copy "f073_client_doc_mstr.fd".
    copy "f080_bank_mstr.fd".
    copy "f085_rejected_claims.fd".
    copy "f086_pat_id.fd".
    copy "f090_constants_mstr.fd".
    copy "f091_diagnostic_codes.fd".
    copy "f094_msg_sub_mstr.fd".
    copy "f096_ohip_pay_code.fd".
    copy "r051_docrev_work_mstr.fd".
    copy "f123_company_mstr.fd".          
    copy "f200_oscar_provider.fd".
    copy "f201_sli_oma_code_suff.fd".

* MC2
    copy "f040_dtl.fd".
* MC2 - end

working-storage section.     
     
77  password-input				pic x(3).     
77  status-cobol-batctrl-file			pic  xx 	value zero.     
77  status-cobol-claims-mstr			pic  xx 	value zero.     
77  status-cobol-claims-mstr-new                pic  xx         value zero.
77  status-cobol-suspend-hdr                    pic  xx         value zero.  
77  status-cobol-suspend-addr                   pic  xx         value zero.  
77  status-cobol-suspend-dtl                    pic  xx         value zero.
77  status-cobol-suspend-desc                   pic  xx         value zero.
77  status-cobol-client-mstr			pic  xx		value zero.
77  status-cobol-client-rma-nbr			pic  xx		value zero.
77  status-cobol-client-doc-mstr		pic  xx		value zero.
77  status-followup-events-mstr			pic  xx		value zero.
77  status-cobol-pat-mstr			pic  xx 	value zero.     
77  status-cobol-pat-elig-history		pic  xx 	value zero.     
77  status-cobol-new-pat-file			pic  xx 	value zero.     
77  status-cobol-pat-mstr-hc  			pic xx   	value zero.     
77  status-cobol-pat-mstr-od  			pic xx   	value zero.     
77  status-cobol-pat-mstr-chrt			pic xx   	value zero.     
77  status-cobol-pat-mstr-acr 			pic xx   	value zero.     
77  status-corrected-pat			pic xx    	value zero.     
77  status-cobol-doc-extra-mstr			pic xx		value zero.
77  status-cobol-doc-mstr			pic xx 		value zero.     
77  status-cobol-oma-mstr			pic  xx 	value zero.     
77  status-cobol-iconst-mstr			pic  xx 	value zero.     
77  status-cobol-diag-mstr			pic  xx 	value zero.     
77  status-cobol-msg-sub-mstr			pic xx 		value zero.
77  status-cobol-clm-shadow-mstr		pic xx		value zero.
77  status-cobol-shadow-mstr-new                pic xx          value zero.
77  status-cobol-rejected-claims		pic xx		value zero.
77  status-cobol-claims-extra			pic xx		value zero.
77  status-cobol-dept-mstr			pic xx 		value zero.
77  status-cobol-loc-mstr			pic xx		value zero.
77  status-cobol-docrev-mstr			pic xx		value zero.
77  status-cobol-docrevtp-mstr			pic xx		value zero.
77  status-cobol-docash-mstr			pic xx		value zero.
77  status-cobol-docashtp-mstr			pic xx		value zero.
77  status-cobol-chq-reg-mstr			pic xx		value zero.
77  status-cobol-bank-mstr			pic xx		value zero.
77  status-cobol-pay-code-mstr			pic xx		value zero.
77  status-cobol-company-mstr			pic xx		value zero.
77  status-cobol-contacts-mstr			pic xx		value zero.
77  status-cobol-contacts-info			pic xx		value zero.
77  status-cobol-oscar-provider		 	pic xx		value zero.
77  status-cobol-sli-oma-mstr			pic xx		value zero.

* MC2
77  status-cobol-f040-dtl                       pic xx          value zero.
* MC2 - end

procedure division.     
main-line section.     
mainline.     
    open i-o	batch-ctrl-file     
		claims-mstr        
		claims-mstr-new
		claims-extra-mstr
		claim-shadow-mstr
		claim-shadow-mstr-new
		suspend-address
		suspend-dtl
		suspend-hdr
		suspend-desc
  		pat-mstr
		pat-elig-history
		doc-mstr
* 2011/05/24 - MC
*		doc-extra-mstr
		loc-mstr
    	        oma-fee-mstr     
		docrev-mstr
		docrevtp-mstr
		oscar-provider
* MC2
                f040-dtl
* MC2 - end
		sli-oma-code-suff-mstr.


    close   	batch-ctrl-file     
		claims-mstr        
		claims-mstr-new
		claims-extra-mstr
		claim-shadow-mstr
		claim-shadow-mstr-new
		suspend-address
		suspend-dtl
		suspend-hdr
		suspend-desc
  		pat-mstr
		pat-elig-history
		doc-mstr
* 2011/05/24 - MC
*		doc-extra-mstr
		loc-mstr
    	        oma-fee-mstr     
		docrev-mstr
		docrevtp-mstr
		oscar-provider
* MC2
                f040-dtl
* MC2 - end
		sli-oma-code-suff-mstr.

    open i-o	docash-mstr
		docashtp-mstr
		cheque-reg-mstr
		dept-mstr
		bank-mstr
		rejected-claims
		iconst-mstr     
		diag-mstr     
		msg-sub-mstr
		pay-code-mstr
		r051-work-file
  		client-mstr
		client-rma-claim-nbr
		client-doc-mstr
		company-mstr
		contacts-mstr
		contacts-info-mstr
**followup-events-mstr
*		(sequential file)
		corrected-pat.
    close    docash-mstr
		docashtp-mstr
		cheque-reg-mstr
		dept-mstr
		bank-mstr
		rejected-claims
		iconst-mstr     
		diag-mstr     
		msg-sub-mstr
		pay-code-mstr
		r051-work-file
  		client-mstr
		client-rma-claim-nbr
		client-doc-mstr
		company-mstr
		contacts-mstr
		contacts-info-mstr
**f0llowup-events-mstr
*		(sequential file)
		corrected-pat.

    stop run.
 
