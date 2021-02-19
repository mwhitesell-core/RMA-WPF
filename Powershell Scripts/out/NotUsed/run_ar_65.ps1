#-------------------------------------------------------------------------------
# File 'run_ar_65.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_ar_65'
#-------------------------------------------------------------------------------

Remove-Item ar.ls *> $null
&$env:cmd\acc_65 *> ar.ls
