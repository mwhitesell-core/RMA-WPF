#-------------------------------------------------------------------------------
# File 'call_backup_mthly_sub81.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'call_backup_mthly_sub81'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

#  CALL_BACKUP_MTHLY_SUB81
echo ""
echo ""
echo ""
if (${1} -eq "jun")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE JUN\JUL\AUG\SEP\OCT\NOV TAPE!!"
} else {
if (${1} -eq "jul")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE JUN\JUL\AUG\SEP\OCT\NOV TAPE!!"
} else {
if (${1} -eq "aug")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE JUN\JUL\AUG\SEP\OCT\NOV TAPE!!"
} else {
if (${1} -eq "sep")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE JUN\JUL\AUG\SEP\OCT\NOV TAPE!!"
} else {
if (${1} -eq "oct")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE JUN\JUL\AUG\SEP\OCT\NOV TAPE!!"
} else {
if (${1} -eq "nov")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE JUN\JUL\AUG\SEP\OCT\NOV TAPE!!"
} else {
if (${1} -eq "dec")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE DEC\JAN\FEB\MAR\APR\MAY TAPE!!"
} else {
if (${1} -eq "jan")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE DEC\JAN\FEB\MAR\APR\MAY TAPE!!"
} else {
if (${1} -eq "feb")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE DEC\JAN\FEB\MAR\APR\MAY TAPE!!"
} else {
if (${1} -eq "mar")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE DEC\JAN\FEB\MAR\APR\MAY TAPE!!"
} else {
if (${1} -eq "apr")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE DEC\JAN\FEB\MAR\APR\MAY TAPE!!"
} else {
if (${1} -eq "may")
 {
  echo "ENSURE THAT THE TAPE MOUNTED IS THE DEC\JAN\FEB\MAR\APR\MAY TAPE!!"
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

Set-Location $env:application_production\81
Get-ChildItem claims_subfile_81_${1}.sf* > subfile81.ls
# CONVERSION ERROR (expected, #72): tape device is involved.
# cat $application_production/81/subfile81.ls |cpio -ocuvB |dd of=/dev/rmt/1


echo "BACKUP FINISH ..."
