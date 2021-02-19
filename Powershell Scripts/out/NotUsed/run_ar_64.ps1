#-------------------------------------------------------------------------------
# File 'run_ar_64.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_ar_64'
#-------------------------------------------------------------------------------

Remove-Item ar.ls *> $null
&$env:cmd\acc_64 *> ar.ls
