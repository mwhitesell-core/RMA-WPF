#-------------------------------------------------------------------------------
# File 'run_stage_40.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_stage_40'
#-------------------------------------------------------------------------------

echo " --- r004a (COBOL) --- "
$rcmd = $env:COBOL + "r004a 22 Y"
Invoke-Expression $rcmd

echo " --- r004b (COBOL) --- "
$rcmd = $env:COBOL + "r004b"
Invoke-Expression $rcmd

echo " --- r004c (COBOL) --- "
$rcmd = $env:COBOL + "r004c Y"
Invoke-Expression $rcmd

#lp r004

echo " --- r005 (COBOL) --- "
$rcmd = $env:COBOL + "r005 22 Y"
Invoke-Expression $rcmd

#lp r005

echo " --- r011 (COBOL) --- "
$rcmd = $env:COBOL + "r011 22 Y"
Invoke-Expression $rcmd

#lp r011

echo " --- r011mohr (QUIZ) --- "
$rcmd = $env:QUIZ + "r011mohr 22@"
Invoke-Expression $rcmd

#lp r011mohr.txt

echo " --- r012 (COBOL) --- "
$rcmd = $env:COBOL + "r012 22 Y"
Invoke-Expression $rcmd

#lp r012

echo " --- r013 (COBOL) --- "
$rcmd = $env:COBOL + "r013 22 Y"
Invoke-Expression $rcmd

#lp r013

echo " --- r051a (COBOL) --- "
$rcmd = $env:COBOL + "r051a 22 Y"
Invoke-Expression $rcmd

echo " --- r051b (COBOL) --- "
$rcmd = $env:COBOL + "r051b"
Invoke-Expression $rcmd
echo " --- r051c (COBOL) --- "
$rcmd = $env:COBOL + "r051c"
Invoke-Expression $rcmd

#lp r051ca

echo " --- r051b (COBOL) --- "
$rcmd = $env:COBOL + "r051b"
Invoke-Expression $rcmd
echo " --- r051c (COBOL) --- "
$rcmd = $env:COBOL + "r051c"
Invoke-Expression $rcmd

#lp r051cb"

#echo NOW RUNNING $cmd/r004_ph_portal_22to48
#$cmd/r004_ph_portal_22to48
