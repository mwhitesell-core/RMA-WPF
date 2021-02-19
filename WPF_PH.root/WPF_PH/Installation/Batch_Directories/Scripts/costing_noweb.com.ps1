#-------------------------------------------------------------------------------
# File 'costing_noweb.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'costing_noweb.com'
#-------------------------------------------------------------------------------

# costing_noweb.com
# 00/jul/14 B.E. added costing7.qtc and costing10.qzc
# 00/jul/31 B.E. added costing11.qzc
# 02/sep/06 yas  this is run instead of costing.com to print out physicians 
#                costing amounts only in manual billing if physician bills
#                web and manual               
# 15/Jul/22 MC1  do not need to run costing11.qzc because it is run is $cmd/costing.com

#####cd $application_production/yasemin/noweb

Set-Location $Env:root\charly\purge\costing\noweb

Remove-Item costing*sf*
&$env:QTP costing1_noweb
&$env:QTP costing2_noweb

$pipedInput = @"
create file doc-totals-tmp 
create file tmp-counters
create file tmp-counters-alpha
"@

$pipedInput | qutil++

&$env:QTP costing3
&$env:QTP costing4
&$env:QTP costing5_noweb
&$env:QTP costing6_noweb
&$env:QTP costing7

&$env:QUIZ costing1
&$env:QUIZ costing6a
&$env:QUIZ costing10 "select if x-billing-source <> 'W' and x-billing-source <> 'D'" `
  "; MC1 - execute $obj/costing11.qzc"
