#-------------------------------------------------------------------------------
# File 'u021_last_rerun.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u021_last_rerun'
#-------------------------------------------------------------------------------

# u021_part2
# 2003/nov/21 b.e. - selection now based upon category of error messages
# 2006/aug/17 M.C. - add the execution of $obj/r021a.qzu



&$env:QUIZ r021b >> u021_ph.log 2> u021_ph.log
&$env:QUIZ r021b `
  "and select 	&     if clmhdr-serv-error of tmp-serv-err-claim = 'Y'          ;if     ohip-err-cat-code of f093-hdr-1 = `"S`"	& ;   or ohip-err-cat-code of f093-hdr-2 = `"S`"	& ;   or ohip-err-cat-code of f093-hdr-3 = `"S`"	& ;   or ohip-err-cat-code of f093-hdr-4 = `"S`"	& ;   or ohip-err-cat-code of f093-hdr-5 = `"S`"	& ;   or ohip-err-cat-code of f093-dtl-1 = `"S`"	& ;   or ohip-err-cat-code of f093-dtl-2 = `"S`"	& ;   or ohip-err-cat-code of f093-dtl-3 = `"S`"	& ;   or ohip-err-cat-code of f093-dtl-4 = `"S`"	& ;   or ohip-err-cat-code of f093-dtl-5 = `"S`"	 ;if     rat-rmb-error-t-cd-1 <> 'EH1' 		& ;   and rat-rmb-error-t-cd-2 <> 'EH1' 		& ;   and rat-rmb-error-t-cd-3 <> 'EH1' 		& ;   and rat-rmb-error-t-cd-4 <> 'EH1' 		& ;   and rat-rmb-error-t-cd-5 <> 'EH1' 		& ;   and rat-rmb-error-h-cd-1 <> 'EH1'  		& ;   and rat-rmb-error-h-cd-2 <> 'EH1'  		& ;   and rat-rmb-error-h-cd-3 <> 'EH1'  		& ;   and rat-rmb-error-h-cd-4 <> 'EH1'  		& ;   and rat-rmb-error-h-cd-5 <> 'EH1'  		& ;   and rat-rmb-error-t-cd-1 <> 'EH2' 		& ;   and rat-rmb-error-t-cd-2 <> 'EH2' 		& ;   and rat-rmb-error-t-cd-3 <> 'EH2' 		& ;   and rat-rmb-error-t-cd-4 <> 'EH2' 		& ;   and rat-rmb-error-t-cd-5 <> 'EH2' 		& ;   and rat-rmb-error-h-cd-1 <> 'EH2'  		& ;   and rat-rmb-error-h-cd-2 <> 'EH2'  		& ;   and rat-rmb-error-h-cd-3 <> 'EH2'  		& ;   and rat-rmb-error-h-cd-4 <> 'EH2'  		& ;   and rat-rmb-error-h-cd-5 <> 'EH2'  		& ;   and rat-rmb-error-t-cd-1 <> 'EH4' 		& ;   and rat-rmb-error-t-cd-2 <> 'EH4' 		& ;   and rat-rmb-error-t-cd-3 <> 'EH4' 		& ;   and rat-rmb-error-t-cd-4 <> 'EH4' 		& ;   and rat-rmb-error-t-cd-5 <> 'EH4' 		& ;   and rat-rmb-error-h-cd-1 <> 'EH4'  		& ;   and rat-rmb-error-h-cd-2 <> 'EH4'  		& ;   and rat-rmb-error-h-cd-3 <> 'EH4'  		& ;   and rat-rmb-error-h-cd-4 <> 'EH4'  		& ;   and rat-rmb-error-h-cd-5 <> 'EH4'  		& ;   and rat-rmb-error-t-cd-1 <> 'EH5' 		& ;   and rat-rmb-error-t-cd-2 <> 'EH5' 		& ;   and rat-rmb-error-t-cd-3 <> 'EH5' 		& ;   and rat-rmb-error-t-cd-4 <> 'EH5' 		& ;   and rat-rmb-error-t-cd-5 <> 'EH5' 		& ;   and rat-rmb-error-h-cd-1 <> 'EH5'  		& ;   and rat-rmb-error-h-cd-2 <> 'EH5'  		& ;   and rat-rmb-error-h-cd-3 <> 'EH5'  		& ;   and rat-rmb-error-h-cd-4 <> 'EH5'  		& ;   and rat-rmb-error-h-cd-5 <> 'EH5'  		& ;   and rat-rmb-error-t-cd-1 <> 'VH4' 		& ;   and rat-rmb-error-t-cd-2 <> 'VH4' 		& ;   and rat-rmb-error-t-cd-3 <> 'VH4' 		& ;   and rat-rmb-error-t-cd-4 <> 'VH4' 		& ;   and rat-rmb-error-t-cd-5 <> 'VH4' 		& ;   and rat-rmb-error-h-cd-1 <> 'VH4'  		& ;   and rat-rmb-error-h-cd-2 <> 'VH4'  		& ;   and rat-rmb-error-h-cd-3 <> 'VH4'  		& ;   and rat-rmb-error-h-cd-4 <> 'VH4'  		& ;   and rat-rmb-error-h-cd-5 <> 'VH4'  		& ;   and rat-rmb-error-t-cd-1 <> 'VH8' 		& ;   and rat-rmb-error-t-cd-2 <> 'VH8' 		& ;   and rat-rmb-error-t-cd-3 <> 'VH8' 		& ;   and rat-rmb-error-t-cd-4 <> 'VH8' 		& ;   and rat-rmb-error-t-cd-5 <> 'VH8' 		& ;   and rat-rmb-error-h-cd-1 <> 'VH8'  		& ;   and rat-rmb-error-h-cd-2 <> 'VH8'  		& ;   and rat-rmb-error-h-cd-3 <> 'VH8'  		& ;   and rat-rmb-error-h-cd-4 <> 'VH8'  		& ;   and rat-rmb-error-h-cd-5 <> 'VH8'  		& ;   and rat-rmb-error-t-cd-1 <> 'VH9' 		& ;   and rat-rmb-error-t-cd-2 <> 'VH9' 		& ;   and rat-rmb-error-t-cd-3 <> 'VH9' 		& ;   and rat-rmb-error-t-cd-4 <> 'VH9' 		& ;   and rat-rmb-error-t-cd-5 <> 'VH9' 		& ;   and rat-rmb-error-h-cd-1 <> 'VH9'  		& ;   and rat-rmb-error-h-cd-2 <> 'VH9'  		& ;   and rat-rmb-error-h-cd-3 <> 'VH9'  		& ;   and rat-rmb-error-h-cd-4 <> 'VH9'  		& ;   and rat-rmb-error-h-cd-5 <> 'VH9'          " `
   >> u021_ph.log 2>> u021_ph.log
&$env:QUIZ r021b `
  "and select					& if    rat-rmb-error-t-cd-1  =  'EQ6' 		&    or rat-rmb-error-t-cd-2  =  'EQ6' 		&    or rat-rmb-error-t-cd-3  =  'EQ6' 		&    or rat-rmb-error-t-cd-4  =  'EQ6' 		&    or rat-rmb-error-t-cd-5  =  'EQ6' 		&    or rat-rmb-error-h-cd-1  =  'EQ6'  		&    or rat-rmb-error-h-cd-2  =  'EQ6'  		&    or rat-rmb-error-h-cd-3  =  'EQ6'  		&    or rat-rmb-error-h-cd-4  =  'EQ6'  		&    or rat-rmb-error-h-cd-5  =  'EQ6'  		&    or rat-rmb-error-t-cd-1  =  'AC4' 		&    or rat-rmb-error-t-cd-2  =  'AC4' 		&    or rat-rmb-error-t-cd-3  =  'AC4' 		&    or rat-rmb-error-t-cd-4  =  'AC4' 		&    or rat-rmb-error-t-cd-5  =  'AC4' 		&    or rat-rmb-error-h-cd-1  =  'AC4'  		&    or rat-rmb-error-h-cd-2  =  'AC4'  		&    or rat-rmb-error-h-cd-3  =  'AC4'  		&    or rat-rmb-error-h-cd-4  =  'AC4'  		&    or rat-rmb-error-h-cd-5  =  'AC4'  		&    or rat-rmb-error-t-cd-1  =  'ERF' 		&    or rat-rmb-error-t-cd-2  =  'ERF' 		&    or rat-rmb-error-t-cd-3  =  'ERF' 		&    or rat-rmb-error-t-cd-4  =  'ERF' 		&    or rat-rmb-error-t-cd-5  =  'ERF' 		&    or rat-rmb-error-h-cd-1  =  'ERF'  		&    or rat-rmb-error-h-cd-2  =  'ERF'  		&    or rat-rmb-error-h-cd-3  =  'ERF'  		&    or rat-rmb-error-h-cd-4  =  'ERF'  		&    or rat-rmb-error-h-cd-5  =  'ERF'  		 " `
   >> u021_ph.log 2>> u021_ph.log
&$env:QUIZ r021c >> u021_ph.log 2>> u021_ph.log