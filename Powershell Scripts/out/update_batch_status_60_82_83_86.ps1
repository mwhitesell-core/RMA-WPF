#-------------------------------------------------------------------------------
# File 'update_batch_status_60_82_83_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'update_batch_status_60_82_83_86'
#-------------------------------------------------------------------------------

Get-Date
Push-Location
&$env:cmd\update_batch_status_60
&$env:cmd\update_batch_status_82
&$env:cmd\update_batch_status_86
&$env:cmd\update_batch_status_70
Pop-Location
Get-Date
