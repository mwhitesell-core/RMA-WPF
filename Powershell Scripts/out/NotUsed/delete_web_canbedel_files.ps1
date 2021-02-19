#-------------------------------------------------------------------------------
# File 'delete_web_canbedel_files.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_web_canbedel_files'
#-------------------------------------------------------------------------------

# 2013/May/15  - created by Moira Chan 
#               - delete files in sub directory of canbedel for all webs 


echo "This program will delete files in webs canbedel sub-directories after $env:cmd\Backup_web_pricing is done"
echo ""
echo ""
echo "**** Hit new line to continue ****"
 $garbage = Read-Host

Set-Location $env:application_production
Remove-Item -Recurse web*\canbedel\*


echo "Deletion of files in webs canbedel subdirectories are done!"
