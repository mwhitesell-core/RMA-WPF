cd $application_production/70
echo
date
echo
1>/dev/null 2>&1
rm utl0006_70.txt utl0006a_70.txt utl0007_70.txt utl0007a_70.txt   1>/dev/null 2>&1
rm r004atp_70.sf* r004btp_70.txt r004ctp_70.txt r004dtp_70.txt	   1>/dev/null 2>&1
rm r004tp_70                            			   1>/dev/null 2>&1
rm r005atp_70.txt r005btp_70.txt r005ctp_70.txt r005dtp_70.txt	   1>/dev/null 2>&1
rm r005tp_70						           1>/dev/null 2>&1
rm r006atp_70.txt r006btp_70.txt r006ctp_70.txt r006dtp_70.txt	   1>/dev/null 2>&1
rm r006tp_70           						   1>/dev/null 2>&1
rm r007tp_70.ps* r007tp_70.sf*				           1>/dev/null 2>&1
rm r011a_70.txt r011b_70.txt r011c_70.txt			   1>/dev/null 2>&1
rm r011_70 							   1>/dev/null 2>&1
rm r012atp_70.txt r012btp_70.txt r012ctp_70.txt			   1>/dev/null 2>&1
rm r012tp_70           						   1>/dev/null 2>&1
rm r013atp_70.txt r013btp_70.txt r013ctp_70.txt		   	   1>/dev/null 2>&1
rm r013tp_70     						   1>/dev/null 2>&1
rm r015atp_70.txt r015btp_70.txt r015ctp_70.txt			   1>/dev/null 2>&1
rm r015tp_70    						   1>/dev/null 2>&1
rm r051caatp_70.txt r051cabtp_70.txt r051cactp_70.txt r051cbatp_70.txt\
   r051cbbtp_70.txt r051cbctp_70.txt				   1>/dev/null 2>&1
rm r051ca_70 r051cb_70  					   1>/dev/null 2>&1
rm r051*tp*70*                  				   1>/dev/null 2>&1
rm r070atp_70.sf* r070btp_70.sf* r070ctp_70.txt r070dtp_70.txt	   1>/dev/null 2>&1
rm r070tp_70					                   1>/dev/null 2>&1
rm divide.ls

date
echo
quiz auto=$obj/stage40tp_70.qzu
echo
cat r004ctp_70.txt r004dtp_70.txt >>r004btp_70.txt
cat r005btp_70.txt r005ctp_70.txt r005dtp_70.txt >> r005atp_70.txt
cat r006btp_70.txt r006ctp_70.txt r006dtp_70.txt >> r006atp_70.txt
cat r011b_70.txt r011c_70.txt >> r011a_70.txt
cat r012btp_70.txt r012ctp_70.txt >> r012atp_70.txt
cat r013btp_70.txt r013ctp_70.txt >> r013atp_70.txt
cat r015btp_70.txt r015ctp_70.txt >> r015atp_70.txt
cat r051cabtp_70.txt r051cactp_70.txt >> r051caatp_70.txt
cat r051cbbtp_70.txt r051cbctp_70.txt >> r051cbatp_70.txt
cat r070dtp_70.txt >> r070ctp_70.txt
echo
echo
mv r004btp_70.txt     r004tp_70
mv r005atp_70.txt     r005tp_70
mv r006atp_70.txt     r006tp_70
mv r011a_70.txt       r011_70
mv r012atp_70.txt     r012tp_70
mv r013atp_70.txt     r013tp_70
mv r015atp_70.txt     r015tp_70
mv r051caatp_70.txt   r051ca_70
mv r051cbatp_70.txt   r051cb_70
mv r070ctp_70.txt     r070tp_70
echo
lp utl0006_70.txt
lp utl0006a_70.txt
lp utl0007_70.txt
lp utl0007a_70.txt
lp r006tp_70
lp r012tp_70
#lp r004tp_70
lp r005tp_70
lp r006tp_70
#lp r011_70
#lp r012tp_70
#lp r013tp_70
#lp r015tp_70
#lp r051ca_70
#lp r051cb_70
lp r070tp_70
echo
date
