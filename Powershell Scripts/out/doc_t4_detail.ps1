#-------------------------------------------------------------------------------
# File 'doc_t4_detail.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_t4_detail'
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2,
  [string] $3,
  [string] $4
  )
  
echo ' '
echo 'Enter EP date 1: '
$1 = Read-Host
echo ' '
echo 'Enter EP date 2: '
$2 = Read-Host
echo ' '
echo 'Enter EP date 3: '
$3 = Read-Host
echo ' '
echo 'Enter EP date 4: '
$4 = Read-Host
echo ' '
  

echo ""
echo "Create Doctor T4 Reports"
echo ""

Set-Location $env:application_production
Remove-Item r150*.sf* *> $null

$rcmd = $env:QTP + "r150a_detail $1 $2 $3 $4"
Invoke-Expression $rcmd

$rcmd= $env:QUIZ + "r150d_detail__pass1 DISC_r150d_dtl_1.rf"
Invoke-Expression $rcmd

$rcmd= $env:QUIZ + "r150d_detail__pass2 DISC_r150d_dtl_2.rf"
Invoke-Expression $rcmd

$rcmd= $env:QUIZ + "r150d_detail__pass3 DISC_r150d_dtl_3.rf"
Invoke-Expression $rcmd

$rcmd= $env:QUIZ + "r150d_detail__pass4 DISC_r150d_dtl_4.rf"
Invoke-Expression $rcmd

$rcmd= $env:QUIZ + "r150d_detail__pass5 DISC_r150d_dtl_5.rf"
Invoke-Expression $rcmd

$rcmd= $env:QUIZ + "r150d_detail__pass6 DISC_r150d_dtl_6.rf"
Invoke-Expression $rcmd

$rcmd= $env:QUIZ + "r150d_detail__pass7 DISC_r150d_dtl_7.rf"
Invoke-Expression $rcmd

$rcmd= $env:QUIZ + "r150d_detail__pass8 DISC_r150d_dtl_8.rf"
Invoke-Expression $rcmd

$rcmd= $env:QUIZ + "r150d_detail__pass9 DISC_r150d_dtl_9.rf"
Invoke-Expression $rcmd

$rcmd= $env:QUIZ + "r150d_detail__pass10 DISC_r150d_dtl_10.rf"
Invoke-Expression $rcmd

$rcmd= $env:QUIZ + "r150d_detail__pass11 DISC_r150d_dtl_11.rf"
Invoke-Expression $rcmd