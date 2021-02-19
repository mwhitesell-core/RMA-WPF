# 2011/aug/24	MC	check_term_doc.com

#  Step 1 - execute 101c/src/fixup/check_term_doc.qzs
#         - this program will select the terminated doctors from f021-avail-doctor-mstr that do not have records found
#	    in f119-doctor-ytd-history file in 101c
#         - termdoc.sf will be created for the selection

rmabill 101c
fixup

quiz << quiz_exit
use  check_term_doc.qzs nol
exit
quiz_exit

#  Step 2 - copy termdoc.sf* files from 101c/src/fixup to mp/src/fixup
#	  - execute check_mp_term_doc.qzs from mp/src/fixup
#	  - mptermdoc.sf will be created for the selection

cp  termdoc.sf*   /alpha/rmabill/rmabillmp/src/fixup 

rmabill mp
fixup

quiz << quiz_exit
use  check_mp_term_doc.qzs nol
exit
quiz_exit


#  Step 3 - copy mptermdoc.sf* files from mp/src/fixup to solo/src/fixup 
#	  - execute check_solo_term_doc_from_mp.qzs  from  solo/src/fixup
#	  - solotermdoc_mp.sf* will be created for the selection

cp  mptermdoc.sf*  /alpha/rmabill/rmabillsolo/src/fixup 

rmabill solo
fixup

quiz << quiz_exit
use check_solo_term_doc_from_mp.qzs nol
exit
quiz_exit

lp solotermdoc_mp.txt

echo done checking terminated doctor
echo go to the printer to get the report solotermdoc_mp.txt
