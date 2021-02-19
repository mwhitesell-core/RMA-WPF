identification division.     
program-id. createfiles.     
author. dyad systems inc.     
installation. rma.     
date-written. 98/01/09.     
date-compiled.     
security.     
environment division.     
input-output section.     
file-control.     

    copy "eft_logical_rec_file.slr".
    copy "f001_batch_control_file.slr".

    copy "f020_doctor_mstr.slr".
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

    copy "r051_docrev_work_mstr.slr".

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

    copy "f020_doctor_mstr.fd".
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



working-storage section.     
     
77  password-input				pic x(3).     
77  status-common				pic x(11).     
77  status-batctrl-file				pic x(11)       value zero.     
77  status-cobol-batctrl-file			pic  xx 	value zero.     
77  status-claims-mstr				pic x(11)	value zero.     
77  status-cobol-claims-mstr			pic  xx 	value zero.     
77  status-cobol-claims-mstr-new                pic  xx         value zero.
77  status-cobol-suspend-hdr                    pic  xx         value zero.  
77  status-cobol-suspend-addr                   pic  xx         value zero.  
77  status-cobol-suspend-dtl                    pic  xx         value zero.
77  status-cobol-client-mstr			pic  xx		value zero.
77  status-cobol-client-rma-nbr			pic  xx		value zero.
77  status-cobol-client-doc-mstr		pic  xx		value zero.
77  status-pat-mstr				pic x(11)	value zero.     
77  status-cobol-pat-mstr			pic  xx 	value zero.     
77  status-cobol-new-pat-file			pic  xx 	value zero.     
77  status-pat-mstr-hc				pic x(11)	value zero.     
77  status-pat-mstr-od				pic x(11)	value zero.     
77  status-pat-mstr-chrt			pic x(11)	value zero.     
77  status-pat-mstr-acr 			pic x(11)	value zero.     
77  status-cobol-pat-mstr-hc  			pic xx   	value zero.     
77  status-cobol-pat-mstr-od  			pic xx   	value zero.     
77  status-cobol-pat-mstr-chrt			pic xx   	value zero.     
77  status-cobol-pat-mstr-acr 			pic xx   	value zero.     
77  status-corrected-pat			pic xx    	value zero.     
77  status-doc-mstr				pic x(11)	value zero.     
77  status-cobol-doc-mstr			pic  xx 	value zero.     
77  status-oma-mstr				pic x(11)	value zero.     
77  status-cobol-oma-mstr			pic  xx 	value zero.     
77  status-iconst-mstr				pic x(11)	value zero.     
77  status-cobol-iconst-mstr			pic  xx 	value zero.     
77  status-diag-mstr				pic x(11)	value zero.     
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

procedure division.     
main-line section.     
mainline.     
*    open i-o	eft-logical-rec-file
    open i-o	
		doc-mstr
		iconst-mstr     .
