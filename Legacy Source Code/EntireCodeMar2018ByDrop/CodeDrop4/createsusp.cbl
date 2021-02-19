identification division.     
program-id. createsusp.      
author. dyad systems inc.     
installation. rma.     
date-written. 98/07/16.     
date-compiled.     
security.     
environment division.     
input-output section.     
file-control.     

    copy "f002_suspend_address.slr".
    copy "f002_suspend_dtl.slr".
    copy "f002_suspend_hdr.slr".
    copy "f002_suspend_desc.slr".

data division.     
file section.     
    copy "f002_suspend_address.fd".
    copy "f002_suspend_dtl.fd".
    copy "f002_suspend_hdr.fd".
    copy "f002_suspend_desc.fd".


working-storage section.     
     
77  password-input				pic x(3).     
77  status-common				pic x(11).     
77  status-cobol-suspend-hdr                    pic  xx         value zero.  
77  status-cobol-suspend-addr                   pic  xx         value zero.  
77  status-cobol-suspend-dtl                    pic  xx         value zero.
77  status-cobol-suspend-desc                   pic  xx         value zero.

procedure division.     
main-line section.     
mainline.     
    open i-o	
		suspend-address
		suspend-dtl
		suspend-hdr
		suspend-desc.

    stop run.
