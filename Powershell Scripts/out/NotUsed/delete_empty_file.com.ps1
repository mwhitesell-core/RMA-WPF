#-------------------------------------------------------------------------------
# File 'delete_empty_file.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_empty_file.com'
#-------------------------------------------------------------------------------

Get-ChildItem $1 *> $null
if ((Get-Item $1).length -eq 0)
{
   echo "deleting $1"
   Remove-Item $1
}
