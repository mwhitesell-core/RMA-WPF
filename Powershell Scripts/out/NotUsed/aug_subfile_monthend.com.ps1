#-------------------------------------------------------------------------------
# File 'aug_subfile_monthend.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'aug_subfile_monthend.com'
#-------------------------------------------------------------------------------


echo ""
echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP unlof002_aug_claim ${1}

echo ""
echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
