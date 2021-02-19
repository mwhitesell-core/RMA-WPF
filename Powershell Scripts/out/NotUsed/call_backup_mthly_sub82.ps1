#-------------------------------------------------------------------------------
# File 'call_backup_mthly_sub82.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'call_backup_mthly_sub82'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

#  CALL_BACKUP_MTHLY_SUB82
echo ""
echo ""
echo ""
if (${1} -eq "apr")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\YR\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "may")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\YR\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "jun")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\YR\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "yr")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\YR\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "jul")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\YR\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "aug")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "sep")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE APR\MAY\JUN\YR\JUL\AUG\SEP TAPE!!"
} else {
if (${1} -eq "oct")
 {
  echo "ensure that the tape mounted is the OCT\NOV\DEC\JAN\FEB\MAR TAPE!!"
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
}

echo "HIT `"NEWLINE`" TO START BACKUP"
$garbage = Read-Host
echo ""
echo "BACKUP COMMENCING..."

Set-Location $env:application_production\82
Get-ChildItem claims_subfile_82_${1}.sf* > subfile82.ls

# CONVERSION ERROR (expected, #78): tape device is involved.
# cat $application_production/82/subfile82.ls |cpio -ocuvB |dd of=/dev/rmt/1

echo "BACKUP FINISH ..."
