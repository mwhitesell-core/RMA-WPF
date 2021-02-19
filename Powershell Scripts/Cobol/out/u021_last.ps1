#-------------------------------------------------------------------------------
# File 'u021_last.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u021_last'
#-------------------------------------------------------------------------------

# u021_part2
# 2003/nov/21 b.e. - selection now based upon category of error messages
# 2006/aug/17 M.C. - add the execution of $obj/r021a.qzu
# 2006/sep/07 M.C. - add/change sel if condition when generating r021ba and r021bb reports
# 2006/nov/22 M.C. - add/change sel if condition when generating r021ba and 
#                    and add a new execution of r021bc for stale dated claims for regular rejects only 
# 2011/May/17 M.C. - change from length 63 to 60 for canon printer lpc

$pipedInput = @"
exec $obj/u021a
"@

$pipedInput | qtp++  >> u021_ph.log  2>&1


$pipedInput = @"
use  $obj/r021a.qzu 
exec $obj/r021b.qzc
exec $obj/r021b.qzc nogo
set rep dev disc name r021ba
set page length 60 width  80
set formfeed
set noblank
and select 	&
    if clmhdr-serv-error of tmp-serv-err-claim = 'Y' &
   and clmhdr-status-ohip of tmp-serv-err-claim <> 'R ' &
   and x-stale-days < 150

       
;if     ohip-err-cat-code of f093-hdr-1 = "S"	&
;   or ohip-err-cat-code of f093-hdr-2 = "S"	&
;   or ohip-err-cat-code of f093-hdr-3 = "S"	&
;   or ohip-err-cat-code of f093-hdr-4 = "S"	&
;   or ohip-err-cat-code of f093-hdr-5 = "S"	&
;   or ohip-err-cat-code of f093-dtl-1 = "S"	&
;   or ohip-err-cat-code of f093-dtl-2 = "S"	&
;   or ohip-err-cat-code of f093-dtl-3 = "S"	&
;   or ohip-err-cat-code of f093-dtl-4 = "S"	&
;   or ohip-err-cat-code of f093-dtl-5 = "S"	
;if     rat-rmb-error-t-cd-1 <> 'EH1' 		&
;   and rat-rmb-error-t-cd-2 <> 'EH1' 		&
;   and rat-rmb-error-t-cd-3 <> 'EH1' 		&
;   and rat-rmb-error-t-cd-4 <> 'EH1' 		&
;   and rat-rmb-error-t-cd-5 <> 'EH1' 		&
;   and rat-rmb-error-h-cd-1 <> 'EH1'  		&
;   and rat-rmb-error-h-cd-2 <> 'EH1'  		&
;   and rat-rmb-error-h-cd-3 <> 'EH1'  		&
;   and rat-rmb-error-h-cd-4 <> 'EH1'  		&
;   and rat-rmb-error-h-cd-5 <> 'EH1'  		&
;   and rat-rmb-error-t-cd-1 <> 'EH2' 		&
;   and rat-rmb-error-t-cd-2 <> 'EH2' 		&
;   and rat-rmb-error-t-cd-3 <> 'EH2' 		&
;   and rat-rmb-error-t-cd-4 <> 'EH2' 		&
;   and rat-rmb-error-t-cd-5 <> 'EH2' 		&
;   and rat-rmb-error-h-cd-1 <> 'EH2'  		&
;   and rat-rmb-error-h-cd-2 <> 'EH2'  		&
;   and rat-rmb-error-h-cd-3 <> 'EH2'  		&
;   and rat-rmb-error-h-cd-4 <> 'EH2'  		&
;   and rat-rmb-error-h-cd-5 <> 'EH2'  		&
;   and rat-rmb-error-t-cd-1 <> 'EH4' 		&
;   and rat-rmb-error-t-cd-2 <> 'EH4' 		&
;   and rat-rmb-error-t-cd-3 <> 'EH4' 		&
;   and rat-rmb-error-t-cd-4 <> 'EH4' 		&
;   and rat-rmb-error-t-cd-5 <> 'EH4' 		&
;   and rat-rmb-error-h-cd-1 <> 'EH4'  		&
;   and rat-rmb-error-h-cd-2 <> 'EH4'  		&
;   and rat-rmb-error-h-cd-3 <> 'EH4'  		&
;   and rat-rmb-error-h-cd-4 <> 'EH4'  		&
;   and rat-rmb-error-h-cd-5 <> 'EH4'  		&
;   and rat-rmb-error-t-cd-1 <> 'EH5' 		&
;   and rat-rmb-error-t-cd-2 <> 'EH5' 		&
;   and rat-rmb-error-t-cd-3 <> 'EH5' 		&
;   and rat-rmb-error-t-cd-4 <> 'EH5' 		&
;   and rat-rmb-error-t-cd-5 <> 'EH5' 		&
;   and rat-rmb-error-h-cd-1 <> 'EH5'  		&
;   and rat-rmb-error-h-cd-2 <> 'EH5'  		&
;   and rat-rmb-error-h-cd-3 <> 'EH5'  		&
;   and rat-rmb-error-h-cd-4 <> 'EH5'  		&
;   and rat-rmb-error-h-cd-5 <> 'EH5'  		&
;   and rat-rmb-error-t-cd-1 <> 'VH4' 		&
;   and rat-rmb-error-t-cd-2 <> 'VH4' 		&
;   and rat-rmb-error-t-cd-3 <> 'VH4' 		&
;   and rat-rmb-error-t-cd-4 <> 'VH4' 		&
;   and rat-rmb-error-t-cd-5 <> 'VH4' 		&
;   and rat-rmb-error-h-cd-1 <> 'VH4'  		&
;   and rat-rmb-error-h-cd-2 <> 'VH4'  		&
;   and rat-rmb-error-h-cd-3 <> 'VH4'  		&
;   and rat-rmb-error-h-cd-4 <> 'VH4'  		&
;   and rat-rmb-error-h-cd-5 <> 'VH4'  		&
;   and rat-rmb-error-t-cd-1 <> 'VH8' 		&
;   and rat-rmb-error-t-cd-2 <> 'VH8' 		&
;   and rat-rmb-error-t-cd-3 <> 'VH8' 		&
;   and rat-rmb-error-t-cd-4 <> 'VH8' 		&
;   and rat-rmb-error-t-cd-5 <> 'VH8' 		&
;   and rat-rmb-error-h-cd-1 <> 'VH8'  		&
;   and rat-rmb-error-h-cd-2 <> 'VH8'  		&
;   and rat-rmb-error-h-cd-3 <> 'VH8'  		&
;   and rat-rmb-error-h-cd-4 <> 'VH8'  		&
;   and rat-rmb-error-h-cd-5 <> 'VH8'  		&
;   and rat-rmb-error-t-cd-1 <> 'VH9' 		&
;   and rat-rmb-error-t-cd-2 <> 'VH9' 		&
;   and rat-rmb-error-t-cd-3 <> 'VH9' 		&
;   and rat-rmb-error-t-cd-4 <> 'VH9' 		&
;   and rat-rmb-error-t-cd-5 <> 'VH9' 		&
;   and rat-rmb-error-h-cd-1 <> 'VH9'  		&
;   and rat-rmb-error-h-cd-2 <> 'VH9'  		&
;   and rat-rmb-error-h-cd-3 <> 'VH9'  		&
;   and rat-rmb-error-h-cd-4 <> 'VH9'  		&
;   and rat-rmb-error-h-cd-5 <> 'VH9'  
       
go

exec $obj/r021b.qzc nogo
set rep dev disc name r021bb
set page length 60 width  80
set formfeed
set noblank
and select					&
    if clmhdr-serv-error of tmp-serv-err-claim = 'Y' &
   and clmhdr-status-ohip of tmp-serv-err-claim = 'R '


; 2006/09/07 - MC - comment out the followings
;if    rat-rmb-error-t-cd-1  =  'EQ6' 		&
;  or rat-rmb-error-t-cd-2  =  'EQ6' 		&
;  or rat-rmb-error-t-cd-3  =  'EQ6' 		&
;  or rat-rmb-error-t-cd-4  =  'EQ6' 		&
;  or rat-rmb-error-t-cd-5  =  'EQ6' 		&
;  or rat-rmb-error-h-cd-1  =  'EQ6'  		&
;  or rat-rmb-error-h-cd-2  =  'EQ6'  		&
;  or rat-rmb-error-h-cd-3  =  'EQ6'  		&
;  or rat-rmb-error-h-cd-4  =  'EQ6'  		&
;  or rat-rmb-error-h-cd-5  =  'EQ6'  		&
;  or rat-rmb-error-t-cd-1  =  'AC4' 		&
;  or rat-rmb-error-t-cd-2  =  'AC4' 		&
;  or rat-rmb-error-t-cd-3  =  'AC4' 		&
;  or rat-rmb-error-t-cd-4  =  'AC4' 		&
;  or rat-rmb-error-t-cd-5  =  'AC4' 		&
;  or rat-rmb-error-h-cd-1  =  'AC4'  		&
;  or rat-rmb-error-h-cd-2  =  'AC4'  		&
;  or rat-rmb-error-h-cd-3  =  'AC4'  		&
;  or rat-rmb-error-h-cd-4  =  'AC4'  		&
;  or rat-rmb-error-h-cd-5  =  'AC4'  		&
;  or rat-rmb-error-t-cd-1  =  'ERF' 		&
;  or rat-rmb-error-t-cd-2  =  'ERF' 		&
;  or rat-rmb-error-t-cd-3  =  'ERF' 		&
;  or rat-rmb-error-t-cd-4  =  'ERF' 		&
;  or rat-rmb-error-t-cd-5  =  'ERF' 		&
;  or rat-rmb-error-h-cd-1  =  'ERF'  		&
;  or rat-rmb-error-h-cd-2  =  'ERF'  		&
;  or rat-rmb-error-h-cd-3  =  'ERF'  		&
;  or rat-rmb-error-h-cd-4  =  'ERF'  		&
;  or rat-rmb-error-h-cd-5  =  'ERF'  		
; 2006/09/07 - end

go

exec $obj/r021b.qzc nogo
set rep dev disc name r021bc
set page length 60 width  80
set formfeed
set noblank
and select					&
    if clmhdr-serv-error of tmp-serv-err-claim = 'Y' &
   and clmhdr-status-ohip of tmp-serv-err-claim <> 'R ' &
   and x-stale-days >= 150
go

exec $obj/r021c.qzc 
"@

$pipedInput | quiz++  >> u021_ph.log  2>&1

qtp++ $obj\u021f  >> u021_ph.log
