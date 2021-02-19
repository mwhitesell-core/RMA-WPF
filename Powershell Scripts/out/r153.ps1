#-------------------------------------------------------------------------------
# File 'r153.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r153'
#-------------------------------------------------------------------------------

$pipedInput = "'
LIVE RUN
001
017
135
017
151
Y
N

99
2017
05
19
Y
'"

$rcmd = $env:COBOL + "r153a $pipedInput"
invoke-expression $rcmd  > r153a.log  2>&1

$pipedInput = @"
99
"@

$rcmd = $env:COBOL + "r153b $pipedInput"
invoke-expression $rcmd  > r153b.log  2>&1

#R153_EXIT
echo ""
echo ""
echo "Ensure the below logs are zero length files!"
Get-Content r153ef| Out-Printer
Get-Content r153ef| Out-Printer

echo ""
Get-ChildItem r153?.log
