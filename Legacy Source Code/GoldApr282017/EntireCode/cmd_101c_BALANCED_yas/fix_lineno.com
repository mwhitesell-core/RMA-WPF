#!/bin/ksh
quiz auto=$obj/fix_lineno_3.qzc

qtp << qtp_EOJ
exe $obj/fix_lineno_4.qtc
exe $obj/fix_lineno_6.qtc
exe $obj/fix_lineno_7.qtc
qtp_EOJ

qutil << qutil_EOJ
create file tmp-counters-alpha
qutil_EOJ

qtp << qtp_EOJ
exe $obj/fix_lineno_8.qtc
;exe $obj/fix_lineno_9.qtc
qtp_EOJ



