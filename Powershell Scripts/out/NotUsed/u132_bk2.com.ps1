#-------------------------------------------------------------------------------
# File 'u132_bk2.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u132_bk2.com'
#-------------------------------------------------------------------------------

#file:  u132.com
# 04/sep/20 b.e. - original
# 07/jan/09 b.e. - add additional parameter to this macro to indicate type of payment

clear
echo "Running `'processing of Payroll Transactions Upload `'"
echo ""
echo "Entering `'upload`' directory"
Set-Location $application_upl ; Get-Location

$seqnbr = "$1"
$filename = "$2"
echo "Running r132.qzc"
&$env:QUIZ r132 $1 $2 > u132.log

# CONVERSION ERROR (unexpected, #20): Unsupported chmod 'x'.
# chmod +x r132_awk.txt
echo "Running r132.awk.txt"
# CONVERSION ERROR (unexpected, #22): Unknown command.
# ./r132_awk.txt

echo "Backing up f114 file before update ..."
Set-Location ..\data
Get-Location
Get-ChildItem f114*
Move-Item -Force f114_special_payments_bk4.idx f114_special_payments_bk5.idx
Move-Item -Force f114_special_payments_bk3.idx f114_special_payments_bk4.idx
Move-Item -Force f114_special_payments_bk2.idx f114_special_payments_bk3.idx
Move-Item -Force f114_special_payments_bk1.idx f114_special_payments_bk2.idx
Copy-Item f114_special_payments.idx f114_special_payments_bk1.idx

Move-Item -Force f114_special_payments_bk4.dat f114_special_payments_bk5.dat
Move-Item -Force f114_special_payments_bk3.dat f114_special_payments_bk4.dat
Move-Item -Force f114_special_payments_bk2.dat f114_special_payments_bk3.dat
Move-Item -Force f114_special_payments_bk1.dat f114_special_payments_bk2.dat
Copy-Item f114_special_payments.dat f114_special_payments_bk1.dat

Set-Location ..\upload
Get-Location

echo "Found Transaction Type of \[$3\]..."
echo ""
if ("$3" -eq "DC")
{
  echo "running u132_dc"
  &$env:QTP u132_dc
} else {
if ("$3" -eq "SP")
{
  echo "running u132_sp"
  &$env:QTP u132_sp
} else {
  echo "`a`a`a`a`a`aFATAL ERROR - this path should never be executed!!!`a`a`a`a"
}
}


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
