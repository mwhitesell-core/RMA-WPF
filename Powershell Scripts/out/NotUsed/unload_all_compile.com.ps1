#-------------------------------------------------------------------------------
# File 'unload_all_compile.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'unload_all_compile.com'
#-------------------------------------------------------------------------------

# unload_all_compile.com
# RMA Physician Other QUIZ compile.
# This script is used to compile the QUIZ/QTS unload programs that create the 
# portable subfiles needed to reload into the test system.

&$env:QUIZ unlocontractdtl
&$env:QUIZ unlocontractmstr
&$env:QUIZ unlof001
&$env:QUIZ unlof002shadow ;f002_claims_extra  ";f002_suspend_address - empty" ";f002_suspend_dtl - empty" `
  ";f002_suspend_hdr - empty"
&$env:QUIZ unlof010
&$env:QUIZ unlof020
&$env:QUIZ unlof020hist
&$env:QUIZ unlof020extra
&$env:QUIZ unlof021  ;f023_alternative_doctor_nbr ;f024_referring_doctor  ";f026_doctor_options - empty"  `
  ;f030_locations_mstr
&$env:QUIZ unlof040
&$env:QUIZ unlof050
&$env:QUIZ unlof050hist  ";use $src/unlof05tp nol"
&$env:QUIZ unlof050tphist  ;f051_doc_cash_mstr ;f051tp_doc_cash_mstr  ;f070_dept_mstr ;f071_client_rma_claim_nbr `
  ;f072_client_mstr ;f073_client_doc_mstr ;f080_bank_mstr ;f085_rejected_claims ;f087-man-rejected-claims-hist
&$env:QUIZ unlof090_1
&$env:QUIZ unlof090_2
&$env:QUIZ unlof090_3
&$env:QUIZ unlof090_4
&$env:QUIZ unlof090_5
&$env:QUIZ unlof090_6
&$env:QUIZ unlof090_iconst  ;f091_diagnostic_codes ;f094_msg_sub_mstr ;f096_ohip_pay_code  ;f097-spec-cd-mstr `
  ;f098-equiv-oma-code-mstr ;f099-group-claim-mstr
&$env:QUIZ unlof110
&$env:QUIZ unlof110hist
&$env:QUIZ unlof112
&$env:QUIZ unlof112hist
&$env:QUIZ unlof113
&$env:QUIZ unlof113hist  ;f119_doctor_ytd
&$env:QUIZ unlof119hst
&$env:QUIZ unlof190
&$env:QUIZ unlof191  ;f198-user-defined-totals
&$env:QUIZ unlof199  ;f085_rejected_claims
&$env:QUIZ unlosoc  ;f095_text_lines

&$env:QTP unlof002
