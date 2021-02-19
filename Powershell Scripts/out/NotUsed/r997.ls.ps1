#-------------------------------------------------------------------------------
# File 'r997.ls.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r997.ls'
#-------------------------------------------------------------------------------

Remove-Item r997.txt, r997*.sf*, u997*.sf* *> $null
echo "Running RA reports"
&$env:QTP u997

# r997 exculudes 35's
#quiz auto=$obj/r997.qzu

# r997 includes 35's
&$env:QUIZ r997_35

Get-Content r997f.txt | Add-Content r997.txt
Get-Content r997g.txt | Add-Content r997.txt
Get-Content r997h.txt | Add-Content r997.txt
Get-Content r997i.txt | Add-Content r997.txt
Get-Content r997j.txt | Add-Content r997.txt
Get-Content r997k.txt | Add-Content r997.txt

Get-Content u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat

&$env:QUIZ r997_total
Get-Content r997_total.txt | Add-Content r997.txt

&$env:QUIZ r997_paid

Remove-Item u030_tape_145_file.dat *> $null
Copy-Item u030_tape_145_file_bkp.dat u030_tape_145_file.dat
