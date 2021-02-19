#-------------------------------------------------------------------------------
# File 'drkolesar_analysis.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'drkolesar_analysis.com'
#-------------------------------------------------------------------------------

# 2013/Jul/30  MC - run Dr Kolesar analysis for service date >= 2011/Jul/01
#                 - there are 3 passes to be executed - drkolesar.qts, drkolesar_doc.qts & drkolesar_yr.qts
#                 - drkolesar.qts have catered for next 5 years, modify accordingly if needed
#                 - drkolesar_doc.qts & drkolesar_yr.qts have the 6 doctors exclusion, modify accordingly if needed
#                 - the first pass (drkolesar.qts) should not need to rerun as data should not have changed for previous year
#                   except the recent one
#                 - second(drkolesar_doc.qts) & third (drkolesar_yr.qts) passes can be rerun separately if needed 
#                   but tmp-counter-dup must be recreated via qutil before running because tmp-counters-dup is for
#                   median calculation purpose

echo ""
Get-Date
echo ""

Set-Location $Env:root\alpha\rmabill\rmabill101c\src\yas

Remove-Item kolesar*.sf*
Remove-Item kolesar*.ps*

$pipedInput = @"
create file tmp-counters-dup
"@

$pipedInput | qutil++

&$env:QTP drkolesar
&$env:QTP drkolesar_doc
&$env:QTP drkolesar_yr

echo ""
Get-Date
echo ""
