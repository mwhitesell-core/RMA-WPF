#-------------------------------------------------------------------------------
# File 'u132.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
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
Set-Location $application_upl; Get-Location

# rename file being processed and then run thur sed editor to remove blank
Move-Item $2 $2.bk
# CONVERSION ERROR
# sed 's/ \,/\,/' < $2.bk > $2
# Can't convert; Unknown command.

$seqnbr = "$1"
$filename = "$2"
echo "Running r132.qzc"
$pipedInput = @"
$1 
$2
"@

$pipedInput | quiz++ $obj\r132  > u132.log

# CONVERSION ERROR
# chmod +x r132_awk.txt
# Can't convert; Unsupported chmod 'x'.
echo "Running r132.awk.txt"
# CONVERSION ERROR
# ./r132_awk.txt
# Can't convert; Unknown command.

echo "Backing up f114 file before update ..."
Set-Location ..\data
Get-Location
Get-ChildItem f114*
Move-Item f114_special_payments_bk4.idx f114_special_payments_bk5.idx
Move-Item f114_special_payments_bk3.idx f114_special_payments_bk4.idx
Move-Item f114_special_payments_bk2.idx f114_special_payments_bk3.idx
Move-Item f114_special_payments_bk1.idx f114_special_payments_bk2.idx
Copy-Item f114_special_payments.idx f114_special_payments_bk1.idx

Move-Item f114_special_payments_bk4.dat f114_special_payments_bk5.dat
Move-Item f114_special_payments_bk3.dat f114_special_payments_bk4.dat
Move-Item f114_special_payments_bk2.dat f114_special_payments_bk3.dat
Move-Item f114_special_payments_bk1.dat f114_special_payments_bk2.dat
Copy-Item f114_special_payments.dat f114_special_payments_bk1.dat

Set-Location ..\upload
Get-Location

echo "Found Transaction Type of \[$3\]..."
echo ""
if ("$3" -eq "DC")
{
  echo "running u132_dc"
  qtp++ $obj\u132_dc
} else {
if ("$3" -eq "SP")
{
  if ("$clinic_nbr" -eq "99")
  {
    echo "running u132_sp_mp"
    qtp++ $obj\u132_sp_mp
  } else {
    echo "running u132_sp"
    qtp++ $obj\u132_sp
  }
} else {
    echo "`a`a`a`a`a`aFATAL ERROR - this path should never be executed!!!`a`a`a`a"
}
}


Remove-Item r133.txt  > $null
echo "Running audit report - the report MUST BE ZERO LENGTH or Errors!"
quiz++ $obj\r133
echo "The report MUST BE ZERO LENGTH or there are Errors!"
echo "hit New-line to display the report"
$garbage = Read-Host
Get-Contents r133.txt | Out-Host -paging


echo "renaming processed file as: $filename.done"
Move-Item u132.dat $filename.done

Set-Location $production

echo ""
#echo Done!
