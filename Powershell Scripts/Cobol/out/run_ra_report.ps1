#-------------------------------------------------------------------------------
# File 'run_ra_report.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_ra_report'
#-------------------------------------------------------------------------------

Remove-Item r997*, r997*.sf*, u997*.sf*  > $null
echo "Running RA reports"
qtp++ $obj\u997

# r997 exculudes 35's
#quiz auto=$obj/r997.qzu

# r997 includes 35's
quiz++ $obj\r997_35

Get-Content r997f.txt  >> r997.txt
Get-Content r997g.txt  >> r997.txt
Get-Content r997h.txt  >> r997.txt
Get-Content r997i.txt  >> r997.txt
Get-Content r997j.txt  >> r997.txt
Get-Content r997k.txt  >> r997.txt

Get-Content u030_tape_rmb_file.dat  >> u030_tape_145_file.dat

quiz++ $obj\r997_total
Get-Content r997_total.txt  >> r997.txt

quiz++ $obj\r997_paid

Remove-Item u030_tape_145_file.dat  > $null
Copy-Item u030_tape_145_file_bkp.dat u030_tape_145_file.dat
