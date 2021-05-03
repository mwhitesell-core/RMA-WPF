#-------------------------------------------------------------------------------
# File 'verify_adj_file.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'verify_adj_file'
#-------------------------------------------------------------------------------

# 1267  2014-oct-14     be1     - correct test for zero length file

echo "Runningverify_adj_file"
echo ""
echo "This program will verify the contents of the adj_claim_file"
echo "before the Cycle commences ..."
echo ""

Set-Location $env:application_root\production

echo "Running r990 ..."
Remove-Item r990.txt
$rcmd = $env:QUIZ+ "r990"
Invoke-Expression $rcmd

#be1 if [ -s r990.txt > 0 ] 
if ((Test-Path r990.txt) -and ((Get-Item r990.txt ).Length -gt 0 ))
{
        echo ""
        echo ""
        echo ""
        echo "`a`a`a`a`a`a`a`a`a`a`a"
        echo "ERROR   Printing R990 report of bad transactions in adj_claim_file"
        echo "        FIX THEM BEFORE continuing the Cycle run"
        echo ""
        echo ""
        echo ""

        if ( $env:networkprinter -ne 'null'  )
        {
           Get-Content r990.txt | Out-Printer -Name $env:networkprinter
        }

        echo ""
        echo ""
        echo "The report is now on the line printer"
        echo "`a`a`a`a`a`a`a`a`a`a`a"
        echo ""
        echo ""
        echo ""
} else {
        echo ""
        echo ""
        echo ""
        echo "No problems with file - you can continue the Cycle run now"
        echo ""
        echo ""
        echo ""
}
