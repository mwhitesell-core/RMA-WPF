#-------------------------------------------------------------------------------
# File 'run_ra_report.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'run_ra_report'
#-------------------------------------------------------------------------------

Remove-Item r997*, r997*.sf*, u997*.sf* *> $null
echo "Running RA reports"
$rcmd = $env:QTP + "u997"
invoke-expression $rcmd

# r997 exculudes 35's
#quiz auto=$obj/r997.qzu

# r997 includes 35's
$rcmd = $env:QUIZ + "r997a"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997b"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997c"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997d"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997e"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997f"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997g"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997h"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997i"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997j"
invoke-expression $rcmd
$rcmd = $env:QUIZ + "r997k"
invoke-expression $rcmd

Get-Content r997f.txt >> r997.txt
Get-Content r997g.txt >> r997.txt
Get-Content r997h.txt >> r997.txt
Get-Content r997i.txt >> r997.txt
Get-Content r997j.txt >> r997.txt
Get-Content r997k.txt >> r997.txt

#Get-Content u030_tape_rmb_file.dat >> u030_tape_145_file.dat
#Get-Content u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat -NoNewline
Get-Content u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat

$rcmd = $env:QUIZ + "r997_total"
invoke-expression $rcmd
Get-Content r997_total.txt >> r997.txt

$rcmd = $env:QUIZ + "r997_paid"
invoke-expression $rcmd

Remove-Item u030_tape_145_file.dat *> $null
Copy-Item u030_tape_145_file_bkp.dat u030_tape_145_file.dat
