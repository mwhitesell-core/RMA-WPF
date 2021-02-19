#-------------------------------------------------------------------------------
# File 'reload_all_run.com.WASRUN.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_all_run.com.WASRUN'
#-------------------------------------------------------------------------------

# reload_all_compile.com
# This script is used to run the QUIZ/QTS reload programs that create the 
# portable subfiles needed to reload into the test system.

&$env:QTP ";exec $obj/relocontractdtl" ";exec $obj/relocontractmstr"
&$env:QTP relof001
&$env:QTP relof002shadow
&$env:QTP relof010
&$env:QTP relof020
&$env:QTP relof020hist
&$env:QTP relof020extra
&$env:QTP relof021
&$env:QTP relof022
&$env:QTP relof023
&$env:QTP relof024
&$env:QTP relof026
&$env:QTP relof030
&$env:QTP relof040  ";exec $obj/relof050"
&$env:QTP relof050hist  ";exec $obj/relof05tp"
&$env:QTP relof050tphist  ;f051_doc_cash_mstr ;f051tp_doc_cash_mstr  ;f070_dept_mstr ;f071_client_rma_claim_nbr `
  ;f072_client_mstr ;f073_client_doc_mstr ;f080_bank_mstr ;f085_rejected_claims ;f087-man-rejected-claims-hist
&$env:QTP relof090_5
&$env:QTP relof090_6
&$env:QTP relof090_iconst  ;f091_diagnostic_codes ;f094_msg_sub_mstr ;f096_ohip_pay_code  ;f097-spec-cd-mstr `
  ;f098-equiv-oma-code-mstr ;f099-group-claim-mstr
&$env:QTP relof110
&$env:QTP relof110hst
&$env:QTP relof112
&$env:QTP relof112hst
&$env:QTP relof113
&$env:QTP relof113hst  ;f119_doctor_ytd
&$env:QTP relof119hst
&$env:QTP relof190
&$env:QTP relof191  ;f198-user-defined-totals
&$env:QTP relof199  ;f085_rejected_claims
&$env:QTP relosoc  ;f095_text_lines  QUIZ_EXIT  "qtp << QTP_EXIT"
&$env:QTP relof002
