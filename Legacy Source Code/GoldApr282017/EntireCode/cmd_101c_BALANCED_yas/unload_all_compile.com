# unload_all_compile.com
# RMA Physician Other QUIZ compile.
# This script is used to compile the QUIZ/QTS unload programs that create the 
# portable subfiles needed to reload into the test system.

quiz << QUIZ_EXIT
use $src/unlocontractdtl  nol
use $src/unlocontractmstr nol
use $src/unlof001 nol

use $src/unlof002shadow 
;f002_claims_extra

;f002_suspend_address - empty
;f002_suspend_dtl - empty 
;f002_suspend_hdr - empty

use $src/unlof010 nol
use $src/unlof020 nol
use $src/unlof020hist nol
use $src/unlof020extra nol
use $src/unlof021 nol

;f023_alternative_doctor_nbr 
;f024_referring_doctor

;f026_doctor_options - empty

;f030_locations_mstr 

use $src/unlof040 nol

use $src/unlof050 nol

use $src/unlof050hist		

;use $src/unlof05tp nol

use $src/unlof050tphist	

;f051_doc_cash_mstr
;f051tp_doc_cash_mstr

;f070_dept_mstr
;f071_client_rma_claim_nbr
;f072_client_mstr
;f073_client_doc_mstr
;f080_bank_mstr
;f085_rejected_claims
;f087-man-rejected-claims-hist

use $src/unlof090_1.qzs nol
use $src/unlof090_2.qzs nol
use $src/unlof090_3.qzs nol
use $src/unlof090_4.qzs nol
use $src/unlof090_5.qzs nol
use $src/unlof090_6.qzs nol
use $src/unlof090_iconst.qzs nol

;f091_diagnostic_codes
;f094_msg_sub_mstr
;f096_ohip_pay_code

;f097-spec-cd-mstr
;f098-equiv-oma-code-mstr
;f099-group-claim-mstr


use $src/unlof110 nol
use $src/unlof110hist nol
use $src/unlof112 nol
use $src/unlof112hist nol
use $src/unlof113 nol
use $src/unlof113hist nol

;f119_doctor_ytd

use $src/unlof119hst nol

use $src/unlof190 nol
use $src/unlof191 noL

;f198-user-defined-totals

use $src/unlof199 nol

;f085_rejected_claims

use $src/unlosoc nol

;f095_text_lines

QUIZ_EXIT
 
qtp << QTP_EXIT
use $src/unlof002 nol
QTP_EXIT
