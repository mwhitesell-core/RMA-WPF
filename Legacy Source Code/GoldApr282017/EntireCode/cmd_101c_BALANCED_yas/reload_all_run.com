# reload_all_run.com
# This script is used to run the QUIZ/QTS reload programs that create the 
# portable subfiles needed to reload into the test system.

qtp << QTP_EXIT
;exec $obj/relocontractdtl  
;exec $obj/relocontractmstr 
exec $obj/relof001
exec $obj/relof002shadow
exec $obj/relof010
exec $obj/relof020
exec $obj/relof020hist
exec $obj/relof020extra   
exec $obj/relof021
;exec $obj/relof022
;exec $obj/relof023 
;exec $obj/relof024 
;exec $obj/relof026
;exec $obj/relof030
exec $obj/relof040

;exec $obj/relof050

exec $obj/relof050hist

;exec $obj/relof05tp

exec $obj/relof050tphist

;f051_doc_cash_mstr
;f051tp_doc_cash_mstr

;f070_dept_mstr
;f071_client_rma_claim_nbr
;f072_client_mstr
;f073_client_doc_mstr
;f080_bank_mstr
;f085_rejected_claims

exec $obj/relof086

;f087-man-rejected-claims-hist

exec $obj/relof090_1
exec $obj/relof090_2
exec $obj/relof090_3
exec $obj/relof090_4
exec $obj/relof090_5
exec $obj/relof090_6
exec $obj/relof090_iconst

;f091_diagnostic_codes
;f094_msg_sub_mstr
;f096_ohip_pay_code

;f097-spec-cd-mstr
;f098-equiv-oma-code-mstr
;f099-group-claim-mstr


exec $obj/relof110
exec $obj/relof110hst
exec $obj/relof112
exec $obj/relof112hst
exec $obj/relof113
exec $obj/relof113hst

exec $obj/relof119a
exec $obj/relof119b

exec $obj/relof119hst

exec $obj/relof190
exec $obj/relof191 

;f198-user-defined-totals

exec $obj/relof199

;f085_rejected_claims

exec $obj/relosoc

;f095_text_lines

exec $obj/relof002
QTP_EXIT
