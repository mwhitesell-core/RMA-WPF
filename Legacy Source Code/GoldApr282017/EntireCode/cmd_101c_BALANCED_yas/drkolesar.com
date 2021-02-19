# 10/Sep/08  yas - to run drkolesar.qts                                         
echo
date
echo

cd /alpha/rmabill/rmabill101c/src/yas

rm kolesar.sf*  
rm kolesar.ps*

qutil << qutil_EXIT
create file tmp-counters
create file tmp-counters-alpha
qutil_EXIT

qtp << qtp_EXIT
exe $obj/drkolesar.qtc
qtp_EXIT

#quiz << QUIZ_EXIT
#execute $obj/drkolesar.qzs
#QUIZ_EXIT

echo
date
echo
