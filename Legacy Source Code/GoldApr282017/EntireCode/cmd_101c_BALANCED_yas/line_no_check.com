# line_no_check.com
echo zero line number check programs

quiz auto=$obj/fix_lineno_3.qzc

qtp << QTP_EXIT
exec auto=$obj/fix_lineno_4.qtc
exec auto=$obj/fix_lineno_6.qtc
exec auto=$obj/fix_lineno_7.qtc
QTP_EXIT

quiz auto=$obj/fix_lineno_8.qzc

#qutil << QUTIL_EXIT
#create file tmp-counters-alpha
#QUTIL_EXIT

#qtp auto=$obj/fix_lineno_8.qtc
