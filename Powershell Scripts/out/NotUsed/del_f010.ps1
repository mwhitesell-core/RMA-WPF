#-------------------------------------------------------------------------------
# File 'del_f010.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'del_f010'
#-------------------------------------------------------------------------------

echo "DELETE F010_PAT_MSTR"
Set-Location $pb_data
Remove-Item f010_pat_mstr*
