identification division.     
program-id. createpatid.     
author. dyad systems inc.     
installation. rma.     
date-written. 98/03/19.     
date-compiled.     
security.     
environment division.     
input-output section.     
file-control.     

select corrected-pat     
	assign        to "f086_pat_id.dat"     
        file status   is status-corrected-pat.     

data division.     
file section.     
    copy "f086_pat_id.fd".     

working-storage section.     
77  status-corrected-pat			pic xx    	value zero.     

procedure division.     
main-line section.     
mainline.     
     
	open i-o	corrected-pat.     

    stop run.
 
