#-------------------------------------------------------------------------------
# File 'u132.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u132.com'
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2,
  [string] $3
)

#file:  u132.com
# 2004/sep/20 b.e. - original
# 2007/jan/09 b.e. - add additional parameter to this macro to indicate type of payment
# 2008/dec/16 b.e. - dec ltd file from R Bank had blank after each $ value - added sed command to remove blank

clear
echo "Running `'processing of Payroll Transactions Upload `'"
echo ""
echo "Entering `'upload`' directory"
Set-Location $env:application_upl ; Get-Location

# rename file being processed and then run thur sed editor to remove blank
Move-Item -Force $2 $2.bk
# CONVERSION ERROR (unexpected, #15): Unknown command.
# sed 's/ \,/\,/' < $2.bk > $2

$seqnbr = "$1"
$filename = "$2"
#CORE - CHANGED TO USE QTP RATHER THAN AWK SCRIPT
<#echo "Running r132.qzc"
&$env:QUIZ r132 $1 $2 > u132.log

#Core - Added to rename report according to quiz file
Get-Content r132.txt > r132_awk.txt

# CONVERSION ERROR (unexpected, #25): Unsupported chmod 'x'.
# chmod +x r132_awk.txt
echo "Running r132.awk.txt"
# CONVERSION ERROR (unexpected, #27): Unknown command.
# ./r132_awk.txt#>
$rcmd = $env:QTP + "LOAD_U132DAT $1 $2 $3"
Invoke-Expression $rcmd

echo "Backing up f114 file before update ..."
<#Set-Location ..\data
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
Get-Location#>

#CORE - Changed to QTP

$rcmd = $env:QTP + "copy_f114 CASCADE SILENT"
Invoke-Expression $rcmd

echo "Found Transaction Type of \[$3\]..."
echo ""
if ("$3" -eq "DC")
{
  echo "running u132_dc"
  $rcmd = $env:QTP + "u132_dc"
  Invoke-Expression $rcmd

} else {
if ("$3" -eq "SP")
{
  if ("$env:clinic_nbr" -eq "99")
  {
    echo "running u132_sp_mp"
    $rcmd = $env:QTP + "u132_sp_mp"
    Invoke-Expression $rcmd

  } else {
    echo "running u132_sp"
    $rcmd = $env:QTP + "u132_sp"
    Invoke-Expression $rcmd

  }
} else {
    echo "`a`a`a`a`a`aFATAL ERROR - this path should never be executed!!!`a`a`a`a"
}
}


Remove-Item r133.txt *> $null
echo "Running audit report - the report MUST BE ZERO LENGTH or Errors!"
$rcmd = $env:QUIZ + "r133"
Invoke-Expression $rcmd
echo "The report MUST BE ZERO LENGTH or there are Errors!"
echo "hit New-line to display the report"
$garbage = Read-Host
Get-Content r133.txt 2> $null


echo "renaming processed file as: $filename.done"
Move-Item -Force $2 "${filename}.done"

Set-Location $env:application_production

echo ""
#echo Done!
