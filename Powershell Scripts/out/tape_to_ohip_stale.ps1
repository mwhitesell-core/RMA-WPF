#-------------------------------------------------------------------------------
# File 'tape_to_ohip_stale.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'tape_to_ohip_stale'
#-------------------------------------------------------------------------------

# 2016/Sep/22   MC      clone from $cmd/tape_to_ohip, this is create tape from stale claim subfile   

Set-Location $env:application_root\production

Get-Content u022_tp_stale.sf | Set-Content u020_tapeout_file | Set-Content $null

. $env:cmd\ohip_convert_copy_to_tape
