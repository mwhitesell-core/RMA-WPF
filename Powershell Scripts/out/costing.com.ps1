#-------------------------------------------------------------------------------
# File 'costing.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'costing.com'
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

Set-Location \\$Env:root\charly\purge\costing

###rm costingf119.ps*
###qtp auto=$obj/costing_f119hist.qtc

Remove-Item costing*sf*
$rcmd = $env:QTP + "costing1"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "costing2"
Invoke-Expression $rcmd

<#$pipedInput = @"
create file doc-totals-tmp 
create file tmp-counters
create file tmp-counters-alpha
"@

$pipedInput | qutil++#>
$rcmd = $env:TRUNCATE+ "doc_totals_tmp"
Invoke-Expression $rcmd
$rcmd = $env:TRUNCATE+ "tmp_counters"
Invoke-Expression $rcmd
$rcmd = $env:TRUNCATE+ "tmp_counters_alpha"
Invoke-Expression $rcmd

$rcmd =$env:QTP + "costing3"
Invoke-Expression $rcmd
$rcmd =$env:QTP + "costing4"
Invoke-Expression $rcmd
$rcmd =$env:QTP + "costing5"
Invoke-Expression $rcmd
$rcmd =$env:QTP + "costing6"
Invoke-Expression $rcmd
$rcmd =$env:QTP + "costing7"
Invoke-Expression $rcmd

$rcmd =$env:QUIZ + "costing1 DISC_costing1.rf"
Invoke-Expression $rcmd
$rcmd =$env:QUIZ + "costing6a DISC_costing6a.rf"
Invoke-Expression $rcmd
$rcmd =$env:QUIZ + "costing10 DISC_costing10.rf"
Invoke-Expression $rcmd
$rcmd =$env:QUIZ + "costing11"
Invoke-Expression $rcmd

echo ""
Get-Date
echo ""
