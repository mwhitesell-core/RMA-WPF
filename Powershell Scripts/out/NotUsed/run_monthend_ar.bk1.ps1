#-------------------------------------------------------------------------------
# File 'run_monthend_ar.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_ar.bk1'
#-------------------------------------------------------------------------------

Remove-Item ar.ls *> $null
&$env:cmd\accounts_receivable *> ar.ls
