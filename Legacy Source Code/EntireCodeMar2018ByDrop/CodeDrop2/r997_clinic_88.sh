cd $application_production/88

# recopy back backup file before executing reports
cp u997_good_srt_bkp.sf u997_good_srt.sf

rm r997*_summ.txt
quiz << quiz_exit
exec $obj/r997f_summ.qzc
exec $obj/r997g_summ.qzc
exec $obj/r997k_summ.qzc
quiz_exit
#lp r997f_summ.txt
#lp r997g_summ.txt
lp r997k_summ.txt
