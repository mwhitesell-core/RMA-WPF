#-------------------------------------------------------------------------------
# File 'drkolesar.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'drkolesar.com'
#-------------------------------------------------------------------------------

# 10/Sep/08  yas - to run drkolesar.qts                                         
echo ""
Get-Date
echo ""

Set-Location $Env:root\alpha\rmabill\rmabill101c\src\yas

Remove-Item kolesar.sf*
Remove-Item kolesar.ps*

$pipedInput = @"
create file tmp-counters
create file tmp-counters-alpha
"@

$pipedInput | qutil++

&$env:QTP drkolesar

#quiz << QUIZ_EXIT
#execute $obj/drkolesar.qzs
#QUIZ_EXIT

echo ""
Get-Date
echo ""
