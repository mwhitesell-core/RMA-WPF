# reload_all_compile.com
# RMA Physician Other QTP compile.
# This script is used to compile the QUIZ/QTS reload programs that create the 
# portable subfiles needed to reload into the test system.

qtp << QTP_EXIT
;use $src/relocontractdtl  nol   ; - new
;use $src/relocontractmstr nol   ; - new
use $src/relof001 nol

use $src/relof002shadow 	; - new
;f002_claims_extra

;f002_suspend_address - empty
;f002_suspend_dtl - empty 
;f002_suspend_hdr - empty

use $src/relof010 nol
use $src/relof020 nol
use $src/relof020hist nol
use $src/relof020extra nol     ; - new
use $src/relof021 nol

;f023_alternative_doctor_nbr 
;f024_referring_doctor

;f026_doctor_options - empty

;f030_locations_mstr 

use $src/relof040 nol

;use $src/relof050 nol

use $src/relof050hist		; -new

;use $src/relof05tp nol

use $src/relof050tphist		; - new

;f051_doc_cash_mstr
;f051tp_doc_cash_mstr

;f070_dept_mstr
;f071_client_rma_claim_nbr
;f072_client_mstr
;f073_client_doc_mstr
;f080_bank_mstr
;f085_rejected_claims

use $src/relof086 nol

;f087-man-rejected-claims-hist

use $src/relof090_1.qts nol
use $src/relof090_2.qts nol
use $src/relof090_3.qts nol
use $src/relof090_4.qts nol
use $src/relof090_5.qts nol
use $src/relof090_6.qts nol
use $src/relof090_iconst.qts nol

;f091_diagnostic_codes
;f094_msg_sub_mstr
;f096_ohip_pay_code

;f097-spec-cd-mstr
;f098-equiv-oma-code-mstr
;f099-group-claim-mstr


use $src/relof110 nol
use $src/relof110hst nol
use $src/relof112 nol
use $src/relof112hst nol
use $src/relof113 nol
use $src/relof113hst nol

use $src/relof119 nol

use $src/relof119hst nol

use $src/relof190 nol
use $src/relof191 noL

;f198-user-defined-totals

use $src/relof199 nol

;f085_rejected_claims

use $src/relosoc nol

;f095_text_lines

use $src/relof002 nol
QTP_EXIT
