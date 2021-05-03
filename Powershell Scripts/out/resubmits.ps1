#-------------------------------------------------------------------------------
# File 'resubmits.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'resubmits'
#-------------------------------------------------------------------------------

# file: check_for_resubmits  -- alias resubmits
# purpose: update status of suspended claim to "R"esubmit
#          if accounting number already on f071
#          print report of resubmitted claims

echo "Select resubmit claims"
echo ""
$rcmd = $env:QTP + "u714"
Invoke-Expression $rcmd

echo ""
echo "Report selected resubmit claims"
echo ""
Remove-Item r715.txt *> $null
$rcmd = $env:QUIZ + "r715"
Invoke-Expression $rcmd

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r715.txt | Out-Printer -Name $env:networkprinter
}
