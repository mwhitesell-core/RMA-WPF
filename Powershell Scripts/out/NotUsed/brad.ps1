#-------------------------------------------------------------------------------
# File 'brad.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'brad'
#-------------------------------------------------------------------------------

if ((Test-Path brad.flg) -and ((Get-Item brad.flg ).Length -gt 0 ))
{
  echo "<> 0 "
} else {
 echo "  =0 "
}
