#-------------------------------------------------------------------------------
# File 'costing.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
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

Set-Location $root\charly\purge\costing

###rm costingf119.ps*
###qtp auto=$obj/costing_f119hist.qtc

Remove-Item costing*sf*
$pipedInput = @"
exe $obj/costing1.qtc
exe $obj/costing2.qtc
"@

$pipedInput | qtp++

$pipedInput = @"
create file doc-totals-tmp 
create file tmp-counters
create file tmp-counters-alpha
"@

$pipedInput | qutil++

$pipedInput = @"
exe $obj/costing3.qtc
exe $obj/costing4.qtc
exe $obj/costing5.qtc
exe $obj/costing6.qtc
exe $obj/costing7.qtc
"@

$pipedInput | qtp++

$pipedInput = @"
execute $obj/costing1.qzc
execute $obj/costing6a.qzc
execute $obj/costing10.qzc
execute $obj/costing11.qzc
"@

$pipedInput | quiz++

echo ""
Get-Date
echo ""
