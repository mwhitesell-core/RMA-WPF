#-------------------------------------------------------------------------------
# File 'fix_u022.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'fix_u022'
#-------------------------------------------------------------------------------

&$env:QTP u022

Move-Item -Force u020_tp.sf u022_tp.sf
Move-Item -Force u020_tp.sfd u022_tp.sfd
