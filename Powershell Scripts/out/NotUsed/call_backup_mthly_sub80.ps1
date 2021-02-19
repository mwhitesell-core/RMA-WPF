#-------------------------------------------------------------------------------
# File 'call_backup_mthly_sub80.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'call_backup_mthly_sub80'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

#  CALL_BACKUP_MTHLY_SUB80
echo ""
echo ""
echo ""
if (${1} -eq "apr")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "may")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "jun")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "jul")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "aug")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "sep")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "oct")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE OCT\NOV\DEC\JAN\FEB\MAR TAPE!!"
} else {
if (${1} -eq "nov")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE OCT\NOV\DEC\JAN\FEB\MAR TAPE!!"
} else {
if (${1} -eq "dec")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE OCT\NOV\DEC\JAN\FEB\MAR TAPE!!"
} else {
if (${1} -eq "jan")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE OCT\NOV\DEC\JAN\FEB\MAR TAPE!!"
} else {
if (${1} -eq "feb")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE OCT\NOV\DEC\JAN\FEB\MAR TAPE!!"
} else {
if (${1} -eq "mar")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE OCT\NOV\DEC\JAN\FEB\MAR TAPE!!"
}
}
}
}
}
}
}
}
}
}
}
}

echo "HIT `"NEWLINE`" TO START BACKUP"
$garbage = Read-Host
echo ""
echo "BACKUP COMMENCING..."

Set-Location $env:application_production\80
Get-ChildItem claims_subfile_80_${1}.sf* > subfile80.ls

# CONVERSION ERROR (expected, #73): tape device is involved.
# cat $application_production/80/subfile80.ls |cpio -ocuvB |dd of=/dev/rmt/1

echo "BACKUP FINISH ..."
