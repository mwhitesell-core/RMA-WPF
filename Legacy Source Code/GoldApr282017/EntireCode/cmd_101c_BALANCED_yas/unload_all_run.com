# unload_all_compile.com
# This script is used to run the QUIZ/QTS unload programs that create the 
# portable subfiles needed to reload into the test system.

quiz << QUIZ_EXIT
exec $obj/unlocontractdtl  
exec $obj/unlocontractmstr 
exec $obj/unlof001
exec $obj/unlof002shadow
exec $obj/unlof010
exec $obj/unlof020
exec $obj/unlof020hist
exec $obj/unlof020extra   
exec $obj/unlof021
exec $obj/unlof022
exec $obj/unlof023 
exec $obj/unlof024 
exec $obj/unlof026
exec $obj/unlof030
exec $obj/unlof040

;exec $obj/unlof050

;exec $obj/unlof050hist

;exec $obj/unlof05tp

;exec $obj/unlof050tphist

;f051_doc_cash_mstr
;f051tp_doc_cash_mstr

;f070_dept_mstr
;f071_client_rma_claim_nbr
;f072_client_mstr
;f073_client_doc_mstr
;f080_bank_mstr
;f085_rejected_claims
;f087-man-rejected-claims-hist

exec $obj/unlof090_1
exec $obj/unlof090_2
exec $obj/unlof090_3
exec $obj/unlof090_4
exec $obj/unlof090_5
exec $obj/unlof090_6
exec $obj/unlof090_iconst

;f091_diagnostic_codes
;f094_msg_sub_mstr
;f096_ohip_pay_code

;f097-spec-cd-mstr
;f098-equiv-oma-code-mstr
;f099-group-claim-mstr


exec $obj/unlof110
exec $obj/unlof110hist
exec $obj/unlof112
exec $obj/unlof112hist
exec $obj/unlof113
exec $obj/unlof113hist

;f119_doctor_ytd

exec $obj/unlof119hst

exec $obj/unlof190
exec $obj/unlof191 

;f198-user-defined-totals

exec $obj/unlof199

;f085_rejected_claims

exec $obj/unlosoc

;f095_text_lines

QUIZ_EXIT
 
#qtp << QTP_EXIT
#exec $obj/unlof002
#QTP_EXIT
