#-------------------------------------------------------------------------------
# File 'r004_portal.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r004_portal'
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2
)


Remove-Item r004*portal*, r004*sf*

$rcmd = $env:QUIZ + "r004a $1"
Invoke-Expression $rcmd > r004_portal.log
$rcmd = $env:QUIZ + "r004b"
Invoke-Expression $rcmd >> r004_portal.log
$rcmd = $env:QUIZ + "r004c"
Invoke-Expression $rcmd >> r004_portal.log
$rcmd = $env:QUIZ + "r004d"
Invoke-Expression $rcmd >> r004_portal.log
$rcmd = $env:QUIZ + "r004c_portal"
Invoke-Expression $rcmd >> r004_portal.log
$rcmd = $env:QUIZ + "r004c_portal_ss DISC_r004c_portal_ss.rf"
Invoke-Expression $rcmd >> r004_portal.log

#CORE - RDL fix
(Get-Content r004c_portal_ss.txt).replace('^', "`t") | Set-Content r004c_portal_ss.txt
Move-Item -Force r004c_portal.txt r004c_portal_${2}.txt

# be 2013/apr/22
#mv r004c_portal_ss.txt r004c_portal_ss_${2}.csv
##awk -f $cmd/remove_rpt_heading.awk r004c_portal_ss.txt r004c_portal_ss_${2}.csv

Move-Item -Force r004c_portal_ss.txt r004c_portal_ss_${2}.csv
