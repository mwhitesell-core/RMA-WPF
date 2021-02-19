#-------------------------------------------------------------------------------
# File 'cleanup_diskettes.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'cleanup_diskettes'
#-------------------------------------------------------------------------------



echo "This program will delete all of the subfiles  reports"
echo ""
echo "make sure **view_suspense** is **empty** before pressing newline"
echo ""
echo "**** Hit new line to continue ****"
 $garbage = Read-Host

Remove-Item RU703*  > $null
Remove-Item ru701*  > $null
Remove-Item suspdtl.txt  > $null
Remove-Item r709a.txt  > $null
Remove-Item r709b.txt  > $null
Remove-Item suspdtl*.sf*  > $null
Remove-Item *bg2215*  > $null
Remove-Item submit*  > $null
Remove-Item r711.txt  > $null
Remove-Item r712.txt  > $null
Remove-Item r715.txt  > $null
Remove-Item ru703a  > $null
Remove-Item ru703b  > $null
Remove-Item ru703c  > $null
Remove-Item r707.txt  > $null
Remove-Item submit_disk_pat_in.sf*  > $null
Remove-Item submit_disk_pat_new  > $null
Remove-Item submit_disk_pat_out  > $null
Remove-Item u706*.sf*  > $null
Remove-Item u708*.sf*  > $null
Remove-Item dump_tech.txt  > $null
Remove-Item check_susp.txt  > $null
Remove-Item check_susp_dtl.txt  > $null
Remove-Item suspend_status.txt  > $null
Remove-Item suspend_suffix.txt  > $null
Remove-Item suspend_desc.txt  > $null
Remove-Item dump_tech.sf*  > $null
