#-------------------------------------------------------------------------------
# File 'u132_bk1.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u132_bk1.com'
#-------------------------------------------------------------------------------

#file:  u132.com
# 04/sep/20 b.e. - original

clear
echo "Running `'processing of Payroll Transactions Upload `'"
echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

$seqnbr = "$1"
$filename = "$2"
echo "Running r132.qzc"
&$env:QUIZ r132 $1 $2 > u132.log

# CONVERSION ERROR (unexpected, #19): Unsupported chmod 'x'.
# chmod +x r132_awk.txt
echo "Running r132.awk.txt"
# CONVERSION ERROR (unexpected, #21): Unknown command.
# ./r132_awk.txt

echo "running u132"
&$env:QTP u132

Remove-Item r133.txt *> $null
echo "Running audit report - the report MUST BE ZERO LENGTH or Errors!"
&$env:QUIZ r133
echo "The report MUST BE ZERO LENGTH or there are Errors!"
echo "hit New-line to display the report"
$garbage = Read-Host
Get-Content r133.txt 2> $null


echo "renaming processed file as: $filename.done"
Move-Item -Force u132.dat $filename.done

Set-Location $production

echo ""
#echo Done!
