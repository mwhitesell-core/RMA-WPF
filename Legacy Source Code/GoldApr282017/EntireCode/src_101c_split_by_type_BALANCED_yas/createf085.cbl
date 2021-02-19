identification division.     
program-id. createf085.      
author. dyad systems inc.     
installation. rma.     
date-written. 98/03/19.     
date-compiled.     
security.     
environment division.     
input-output section.     
file-control.     

    copy "f085_rejected_claims.slr".


data division.     
file section.     
    
    copy "f085_rejected_claims.fd".


working-storage section.     
77  status-cobol-rejected-claims		pic xx    	value zero.     

procedure division.     
main-line section.     
mainline.     
     
	open i-o	rejected-claims.     

    stop run.
 
