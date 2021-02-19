#-------------------------------------------------------------------------------
# File 'u021_rerun.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u021_rerun'
#-------------------------------------------------------------------------------

&$env:QUIZ ";use  $obj/r021a.qzu" >> u021_ph.log 2> u021_ph.log
&$env:QUIZ r021b >> u021_ph.log 2>> u021_ph.log
&$env:QUIZ r021b `
  "and select 	&     if clmhdr-serv-error of tmp-serv-err-claim = 'Y' &    and clmhdr-status-ohip of tmp-serv-err-claim <> 'R ' &    and x-stale-days < 150 " `
   >> u021_ph.log 2>> u021_ph.log
&$env:QUIZ r021b `
  "and select					&     if clmhdr-serv-error of tmp-serv-err-claim = 'Y' &    and clmhdr-status-ohip of tmp-serv-err-claim = 'R ' " `
   >> u021_ph.log 2>> u021_ph.log
&$env:QUIZ r021b `
  "and select					&     if clmhdr-serv-error of tmp-serv-err-claim = 'Y' &    and clmhdr-status-ohip of tmp-serv-err-claim <> 'R ' &    and x-stale-days >= 150" `
   >> u021_ph.log 2>> u021_ph.log
&$env:QUIZ r021c >> u021_ph.log 2>> u021_ph.log
