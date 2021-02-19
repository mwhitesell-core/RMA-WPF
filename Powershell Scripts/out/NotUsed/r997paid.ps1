#-------------------------------------------------------------------------------
# File 'r997paid.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r997paid'
#-------------------------------------------------------------------------------

Get-Content u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
&$env:QUIZ r997_paid

Remove-Item u030_tape_145_file.dat *> $null
Copy-Item u030_tape_145_file_bkp.dat u030_tape_145_file.dat
