# 2011/Aug/24 	MC 	check_true_term_doc.com

#  After users have assigned to re-use the doctors from Doctor Assignment Sub-screen (option 5/3) from menu
#         - execute check_true_term_doc.qzs to confirm same doctor records count to be expected for reassignment in 101c 
#	  - true_term_doc.sf will be created and true_term_doc.txt will be printed from the printer for a list of doctor records

rmabill 101c
fixup

quiz  << quiz_exit
use check_true_term_doc.qzs nol
exit
quiz_exit

lp  true_term_doc.txt


#  	- copy true_term_doc.sf* from 101c/src/fixup to mp/src/fixup
#	- execute check_true_term_doc_in_mp.qzs to see how many doctors to be deleted at the later stage 


cp  true_term_doc.sf*  /alpha/rmabill/rmabillmp/src/fixup

rmabill mp
fixup

quiz  << quiz_exit
use check_true_term_doc_in_mp.qzs nol
exit
quiz_exit

lp  true_term_doc_mp.txt

#  	- since 101c & solo share the same src/fixup, we do not need to copy true_term_doc.sf
#	- execute check_true_term_doc_in_solo.qzs to see how many doctors to be deleted at the later stage 

rmabill solo
fixup

quiz  << quiz_exit
use check_true_term_doc_in_solo.qzs nol
exit
quiz_exit

lp  true_term_doc_solo.txt


echo done checking true terminated doctor

