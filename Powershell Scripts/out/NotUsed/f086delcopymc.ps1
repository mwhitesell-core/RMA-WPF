#-------------------------------------------------------------------------------
# File 'f086delcopymc.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'f086delcopymc'
#-------------------------------------------------------------------------------

# f086delcopy
# 00/oct/16 B.E. - added code to keep 5 backups of files


Remove-Item f086_pat_id.dat
Remove-Item f086_pat_id.d001
Remove-Item f086_pat_id.d003

&$env:COBOL createpatid
Copy-Item f086_pat_id.dat f086_pat_id.d003
Copy-Item f086_pat_id.dat f086_pat_id.d001

Get-Item f086_pat_id.dat | % {$_.isreadonly = $false}
Get-Item f086_pat_id.d001 | % {$_.isreadonly = $false}
Get-Item f086_pat_id.d003 | % {$_.isreadonly = $false}
