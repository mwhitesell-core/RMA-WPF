# 99/dec/15 B.E. changed deleted to ignore errors, alignment changes
# 05/jul/07 M.C. include r004btp_portal.txt in the run                    
# 05/aug/10 M.C. undo    r004btp_portal.txt in the run                    


cd $application_production/60
echo
date
echo
1>/dev/null 2>&1
rm utl0006.txt utl0006a.txt utl0007.txt			   1>/dev/null 2>&1
rm r004atp.sf* r004btp.txt r004ctp.txt r004dtp.txt	   1>/dev/null 2>&1
rm r004tp                            			   1>/dev/null 2>&1
rm r004diska.ps* r004diskb.ps* r004diska.sf* r004diskb.sf* 1>/dev/null 2>&1
rm r005atp.txt r005btp.txt r005ctp.txt r005dtp.txt	   1>/dev/null 2>&1
rm r005tp						   1>/dev/null 2>&1
rm r006atp.txt r006btp.txt r006ctp.txt r006dtp.txt	   1>/dev/null 2>&1
rm r006tp						   1>/dev/null 2>&1
rm r007tp.ps* r007tp.sf*				   1>/dev/null 2>&1
rm r011a.txt r011b.txt r011c.txt			   1>/dev/null 2>&1
rm r011							   1>/dev/null 2>&1
rm r012atp.txt r012btp.txt r012ctp.txt			   1>/dev/null 2>&1
rm r012tp						   1>/dev/null 2>&1
rm r013atp.txt r013btp.txt r013ctp.txt		   	   1>/dev/null 2>&1
rm r013tp						   1>/dev/null 2>&1
rm r015atp.txt r015btp.txt r015ctp.txt			   1>/dev/null 2>&1
rm r015tp						   1>/dev/null 2>&1
rm r051caatp.txt r051cabtp.txt r051cactp.txt r051cbatp.txt\
   r051cbbtp.txt r051cbctp.txt				   1>/dev/null 2>&1
rm r051ca r051cb					   1>/dev/null 2>&1
rm r051*tp*						   1>/dev/null 2>&1
rm r070atp.sf* r070btp.sf* r070ctp.txt r070dtp.txt	   1>/dev/null 2>&1
rm r070tp_60					           1>/dev/null 2>&1
rm divide.ls

date
echo
quiz auto=$obj/stage40tp.qzu
echo
cat r004ctp.txt r004dtp.txt >>r004btp.txt
cat r005btp.txt r005ctp.txt r005dtp.txt >> r005atp.txt
cat r006btp.txt r006ctp.txt r006dtp.txt >> r006atp.txt
cat r011b.txt r011c.txt >> r011a.txt
cat r012btp.txt r012ctp.txt >> r012atp.txt
cat r013btp.txt r013ctp.txt >> r013atp.txt
cat r015btp.txt r015ctp.txt >> r015atp.txt
cat r051cabtp.txt r051cactp.txt >> r051caatp.txt
cat r051cbbtp.txt r051cbctp.txt >> r051cbatp.txt
cat r070dtp.txt >> r070ctp.txt
echo
echo
mv r004btp.txt     r004tp
mv r005atp.txt     r005tp
mv r006atp.txt     r006tp
mv r011a.txt       r011
mv r012atp.txt     r012tp
mv r013atp.txt     r013tp
mv r015atp.txt     r015tp
mv r051caatp.txt   r051ca
mv r051cbatp.txt   r051cb
mv r070ctp.txt     r070tp_60
echo
#lp r051b_tp_per.txt
lp utl0006.txt
lp utl0006a.txt
lp utl0007.txt
lp r006tp
lp r012tp
#lp r004tp
lp r005tp
lp r006tp
#lp r011
#lp r012tp
#lp r013tp
#lp r015tp
#lp r051ca
#lp r051cb
lp r070tp_60
echo
date
