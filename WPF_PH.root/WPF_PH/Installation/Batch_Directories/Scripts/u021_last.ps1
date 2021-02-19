#-------------------------------------------------------------------------------
# File 'u021_last.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u021_last'
#-------------------------------------------------------------------------------

# u021_part2
# 2003/nov/21 b.e. - selection now based upon category of error messages
# 2006/aug/17 M.C. - add the execution of $obj/r021a.qzu
# 2006/sep/07 M.C. - add/change sel if condition when generating r021ba and r021bb reports
# 2006/nov/22 M.C. - add/change sel if condition when generating r021ba and 
#                    and add a new execution of r021bc for stale dated claims for regular rejects only 
# 2011/May/17 M.C. - change from length 63 to 60 for canon printer lpc

$rcmd = $env:QTP + "u021a" 
Invoke-Expression $rcmd >> u021_ph.log 


$rcmd = $env:QUIZ + "r021a_1"
Invoke-Expression $rcmd 2>&1 >> u021_ph.log 
$rcmd = $env:QUIZ + "r021a_2"
Invoke-Expression $rcmd 2>&1 >> u021_ph.log 
$rcmd = $env:QUIZ + "r021a_3"
Invoke-Expression $rcmd 2>&1 >> u021_ph.log

#Core - Added to rename report according to quiz file
Get-Content r021a_3.txt > r021a.txt

$rcmd = $env:QUIZ + "r021b"
Invoke-Expression $rcmd 2>&1 >> u021_ph.log 
$rcmd = $env:QUIZ + "r021b DISC_R021BA A"
Invoke-Expression $rcmd 2>&1 >> u021_ph.log 
#"and select $rcmd =  if clmhdr-serv-error of tmp-serv-err-claim = 'Y' $rcmd =  and clmhdr-status-ohip of tmp-serv-err-claim <> 'R ' $rcmd =  and x-stale-days < 150 ;if ohip-err-cat-code of f093-hdr-1 = `"S`"	$rcmd =  ; or ohip-err-cat-code of f093-hdr-2 = `"S`"	$rcmd =  ; or ohip-err-cat-code of f093-hdr-3 = `"S`"	$rcmd =  ; or ohip-err-cat-code of f093-hdr-4 = `"S`" $rcmd =  ; or ohip-err-cat-code of f093-hdr-5 = `"S`" $rcmd =  ; or ohip-err-cat-code of f093-dtl-1 = `"S`" $rcmd =  ; or ohip-err-cat-code of f093-dtl-2 = `"S`"	$rcmd =  ;   or ohip-err-cat-code of f093-dtl-3 = `"S`"	$rcmd =  ;   or ohip-err-cat-code of f093-dtl-4 = `"S`"	$rcmd =  ;   or ohip-err-cat-code of f093-dtl-5 = `"S`"	 ;if     rat-rmb-error-t-cd-1 <> 'EH1' 		$rcmd =  ;   and rat-rmb-error-t-cd-2 <> 'EH1' 		$rcmd =  ;   and rat-rmb-error-t-cd-3 <> 'EH1' 		$rcmd =  ;   and rat-rmb-error-t-cd-4 <> 'EH1' 		$rcmd =  ;   and rat-rmb-error-t-cd-5 <> 'EH1' 		$rcmd =  ;   and rat-rmb-error-h-cd-1 <> 'EH1'  		$rcmd =  ;   and rat-rmb-error-h-cd-2 <> 'EH1'  		$rcmd =  ;   and rat-rmb-error-h-cd-3 <> 'EH1'  		$rcmd =  ;   and rat-rmb-error-h-cd-4 <> 'EH1'  		$rcmd =  ;   and rat-rmb-error-h-cd-5 <> 'EH1'  		$rcmd =  ;   and rat-rmb-error-t-cd-1 <> 'EH2' 		$rcmd =  ;   and rat-rmb-error-t-cd-2 <> 'EH2' 		$rcmd =  ;   and rat-rmb-error-t-cd-3 <> 'EH2' 		$rcmd =  ;   and rat-rmb-error-t-cd-4 <> 'EH2' 		$rcmd =  ;   and rat-rmb-error-t-cd-5 <> 'EH2' 		$rcmd =  ;   and rat-rmb-error-h-cd-1 <> 'EH2'  		$rcmd =  ;   and rat-rmb-error-h-cd-2 <> 'EH2'  		$rcmd =  ;   and rat-rmb-error-h-cd-3 <> 'EH2'  		$rcmd =  ;   and rat-rmb-error-h-cd-4 <> 'EH2'  		$rcmd =  ;   and rat-rmb-error-h-cd-5 <> 'EH2'  		$rcmd =  ;   and rat-rmb-error-t-cd-1 <> 'EH4' 		$rcmd =  ;   and rat-rmb-error-t-cd-2 <> 'EH4' 		$rcmd =  ;   and rat-rmb-error-t-cd-3 <> 'EH4' 		$rcmd =  ;   and rat-rmb-error-t-cd-4 <> 'EH4' 		$rcmd =  ;   and rat-rmb-error-t-cd-5 <> 'EH4' 		$rcmd =  ;   and rat-rmb-error-h-cd-1 <> 'EH4'  		$rcmd =  ;   and rat-rmb-error-h-cd-2 <> 'EH4'  		$rcmd =  ;   and rat-rmb-error-h-cd-3 <> 'EH4'  		$rcmd =  ;   and rat-rmb-error-h-cd-4 <> 'EH4'  		$rcmd =  ;   and rat-rmb-error-h-cd-5 <> 'EH4'  		$rcmd =  ;   and rat-rmb-error-t-cd-1 <> 'EH5' 		$rcmd =  ;   and rat-rmb-error-t-cd-2 <> 'EH5' 		$rcmd =  ;   and rat-rmb-error-t-cd-3 <> 'EH5' 		$rcmd =  ;   and rat-rmb-error-t-cd-4 <> 'EH5' 		$rcmd =  ;   and rat-rmb-error-t-cd-5 <> 'EH5' 		$rcmd =  ;   and rat-rmb-error-h-cd-1 <> 'EH5'  		$rcmd =  ;   and rat-rmb-error-h-cd-2 <> 'EH5'  		$rcmd =  ;   and rat-rmb-error-h-cd-3 <> 'EH5'  		$rcmd =  ;   and rat-rmb-error-h-cd-4 <> 'EH5'  		$rcmd =  ;   and rat-rmb-error-h-cd-5 <> 'EH5'  		$rcmd =  ;   and rat-rmb-error-t-cd-1 <> 'VH4' 		$rcmd =  ;   and rat-rmb-error-t-cd-2 <> 'VH4' 		$rcmd =  ;   and rat-rmb-error-t-cd-3 <> 'VH4' 		$rcmd =  ;   and rat-rmb-error-t-cd-4 <> 'VH4' 		$rcmd =  ;   and rat-rmb-error-t-cd-5 <> 'VH4' 		$rcmd =  ;   and rat-rmb-error-h-cd-1 <> 'VH4'  		$rcmd =  ;   and rat-rmb-error-h-cd-2 <> 'VH4'  		$rcmd =  ;   and rat-rmb-error-h-cd-3 <> 'VH4'  		$rcmd =  ;   and rat-rmb-error-h-cd-4 <> 'VH4'  		$rcmd =  ;   and rat-rmb-error-h-cd-5 <> 'VH4'  		$rcmd =  ;   and rat-rmb-error-t-cd-1 <> 'VH8' 		$rcmd =  ;   and rat-rmb-error-t-cd-2 <> 'VH8' 		$rcmd =  ;   and rat-rmb-error-t-cd-3 <> 'VH8' 		$rcmd =  ;   and rat-rmb-error-t-cd-4 <> 'VH8' 		$rcmd =  ;   and rat-rmb-error-t-cd-5 <> 'VH8' 		$rcmd =  ;   and rat-rmb-error-h-cd-1 <> 'VH8'  		$rcmd =  ;   and rat-rmb-error-h-cd-2 <> 'VH8'  		$rcmd =  ;   and rat-rmb-error-h-cd-3 <> 'VH8'  		$rcmd =  ;   and rat-rmb-error-h-cd-4 <> 'VH8'  		$rcmd =  ;   and rat-rmb-error-h-cd-5 <> 'VH8'  		$rcmd =  ;   and rat-rmb-error-t-cd-1 <> 'VH9' 		$rcmd =  ;   and rat-rmb-error-t-cd-2 <> 'VH9' 		$rcmd =  ;   and rat-rmb-error-t-cd-3 <> 'VH9' 		$rcmd =  ;   and rat-rmb-error-t-cd-4 <> 'VH9' 		$rcmd =  ;   and rat-rmb-error-t-cd-5 <> 'VH9' 		$rcmd =  ;   and rat-rmb-error-h-cd-1 <> 'VH9'  		$rcmd =  ;   and rat-rmb-error-h-cd-2 <> 'VH9'  		$rcmd =  ;   and rat-rmb-error-h-cd-3 <> 'VH9'  		$rcmd =  ;   and rat-rmb-error-h-cd-4 <> 'VH9'  		$rcmd =  ;   and rat-rmb-error-h-cd-5 <> 'VH9'          " `
$rcmd = $env:QUIZ + "r021b DISC_R021BB B"   
Invoke-Expression $rcmd 2>&1 >> u021_ph.log 
#"and select $rcmd =  if clmhdr-serv-error of tmp-serv-err-claim = 'Y' $rcmd =  and clmhdr-status-ohip of tmp-serv-err-claim = 'R ' ; 2006/09/07 - MC - comment out the followings ; if rat-rmb-error-t-cd-1 = 'EQ6' $rcmd =  ; or rat-rmb-error-t-cd-2 = 'EQ6' $rcmd =  ; or rat-rmb-error-t-cd-3 = 'EQ6' $rcmd =  ; or rat-rmb-error-t-cd-4 = 'EQ6' $rcmd =  ; or rat-rmb-error-t-cd-5 = 'EQ6' $rcmd =  ; or rat-rmb-error-h-cd-1 = 'EQ6' $rcmd =  ; or rat-rmb-error-h-cd-2 = 'EQ6' $rcmd =  ; or rat-rmb-error-h-cd-3  =  'EQ6'  		$rcmd =  ;  or rat-rmb-error-h-cd-4  =  'EQ6'  		$rcmd =  ;  or rat-rmb-error-h-cd-5  =  'EQ6'  		$rcmd =  ;  or rat-rmb-error-t-cd-1  =  'AC4' 		$rcmd =  ;  or rat-rmb-error-t-cd-2  =  'AC4' 		$rcmd =  ;  or rat-rmb-error-t-cd-3  =  'AC4' 		$rcmd =  ;  or rat-rmb-error-t-cd-4  =  'AC4' 		$rcmd =  ;  or rat-rmb-error-t-cd-5  =  'AC4' 		$rcmd =  ;  or rat-rmb-error-h-cd-1  =  'AC4'  		$rcmd =  ;  or rat-rmb-error-h-cd-2  =  'AC4'  		$rcmd =  ;  or rat-rmb-error-h-cd-3  =  'AC4'  		$rcmd =  ;  or rat-rmb-error-h-cd-4  =  'AC4'  		$rcmd =  ;  or rat-rmb-error-h-cd-5  =  'AC4'  		$rcmd =  ;  or rat-rmb-error-t-cd-1  =  'ERF' 		$rcmd =  ;  or rat-rmb-error-t-cd-2  =  'ERF' 		$rcmd =  ;  or rat-rmb-error-t-cd-3  =  'ERF' 		$rcmd =  ;  or rat-rmb-error-t-cd-4  =  'ERF' 		$rcmd =  ;  or rat-rmb-error-t-cd-5  =  'ERF' 		$rcmd =  ;  or rat-rmb-error-h-cd-1  =  'ERF'  		$rcmd =  ;  or rat-rmb-error-h-cd-2  =  'ERF'  		$rcmd =  ;  or rat-rmb-error-h-cd-3  =  'ERF'  		$rcmd =  ;  or rat-rmb-error-h-cd-4  =  'ERF'  		$rcmd =  ;  or rat-rmb-error-h-cd-5  =  'ERF'  		 ; 2006/09/07 - end " `
$rcmd = $env:QUIZ + "r021b DISC_R021BC C"
Invoke-Expression $rcmd 2>&1 >> u021_ph.log 
#"and select					$rcmd =      if clmhdr-serv-error of tmp-serv-err-claim = 'Y' $rcmd =     and clmhdr-status-ohip of tmp-serv-err-claim <> 'R ' $rcmd =     and x-stale-days >= 150" `
$rcmd = $env:QUIZ + "r021c"
Invoke-Expression $rcmd 2>&1 >> u021_ph.log 

$rcmd = $env:QTP + "u021f"
Invoke-Expression $rcmd 2>&1 >> u021_ph.log
