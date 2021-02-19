#-------------------------------------------------------------------------------
# File 'costing_old.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'costing_old.com'
#-------------------------------------------------------------------------------

# costing.com
# 00/jul/14 B.E. added costing7.qtc and costing10.qzc
# 00/jul/31 B.E. added costing11.qzc
# 00/jul/26 b.e. - added recreation of tmp-counters-alpha
# 12/Jun/04 yas. - Run costing_f119hist.qts for Leena import into excel 
echo ""
Get-Date
echo ""

#####cd $application_production/yasemin

Set-Location $Env:root\charly\purge\costing

###rm costingf119.ps*
###qtp auto=$obj/costing_f119hist.qtc

Remove-Item costing*sf*
&$env:QTP costing1
&$env:QTP costing2

$pipedInput = @"
create file doc-totals-tmp 
create file tmp-counters
create file tmp-counters-alpha
"@

$pipedInput | qutil++

&$env:QTP costing3
&$env:QTP costing4
&$env:QTP costing5
&$env:QTP costing6
&$env:QTP costing7

&$env:QUIZ costing1
&$env:QUIZ costing6a
&$env:QUIZ costing10
&$env:QUIZ costing11

echo ""
Get-Date
echo ""
