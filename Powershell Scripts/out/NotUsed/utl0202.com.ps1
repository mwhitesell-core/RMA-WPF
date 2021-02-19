#-------------------------------------------------------------------------------
# File 'utl0202.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0202.com'
#-------------------------------------------------------------------------------

# program: utl0202.com
# 2016/nov/23 B.E.  original
clear
echo "utl0202.com - verify all doctors with payments have all required bank info"
echo ""

echo ""
echo "running utl0202.qzc  $time"
Remove-Item utl0202.txt *> $null
&$env:QUIZ utl0202

echo ""
echo ""


if ((Test-Path utl0202.txt) -and ((Get-Item utl0202.txt ).Length -gt 0 ))
{
        Get-ChildItem utl0202.txt
        echo ""
        echo ""
        echo ""
        echo "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
        echo "THERE ARE ERRORS - Give report to Accounting!"
        echo "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
        echo ""
        echo ""
        Get-Content utl0202.txt | Out-Printer
}
echo "Done!  $time"
