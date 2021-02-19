rm check_susp_dtl.txt 1>/dev/null 2>&1  


quiz << QUIZ_EXIT
execute $obj/check_susp_dtl
QUIZ_EXIT

lp check_susp_dtl.txt   
