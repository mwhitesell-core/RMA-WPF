#-------------------------------------------------------------------------------
# File 'john.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'john'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\yasemin
Remove-Item john.ls *> $null
Remove-Item john1.sf* *> $null
Remove-Item john3doc.txt* *> $null
Remove-Item john1dept.sf* *> $null
Remove-Item johndept.txt* *> $null
#batch << BATCH_EXIT
&$env:cmd\john1 *> john.ls
#BATCH_EXIT
