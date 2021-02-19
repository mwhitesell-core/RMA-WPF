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

Remove-Item RU703*  -EA SilentlyContinue
Remove-Item ru701*  -EA SilentlyContinue
Remove-Item suspdtl.txt  -EA SilentlyContinue
Remove-Item r709a.txt  -EA SilentlyContinue
Remove-Item r709b.txt  -EA SilentlyContinue
Remove-Item suspdtl*.sf*  -EA SilentlyContinue
Remove-Item *bg2215*  -EA SilentlyContinue
Remove-Item submit*  -EA SilentlyContinue
Remove-Item r711.txt  -EA SilentlyContinue
Remove-Item r712.txt  -EA SilentlyContinue
Remove-Item r715.txt  -EA SilentlyContinue
Remove-Item ru703a  -EA SilentlyContinue
Remove-Item ru703b  -EA SilentlyContinue
Remove-Item ru703c  -EA SilentlyContinue
Remove-Item r707.txt  -EA SilentlyContinue
Remove-Item submit_disk_pat_in.sf*  -EA SilentlyContinue
Remove-Item submit_disk_pat_new  -EA SilentlyContinue
Remove-Item submit_disk_pat_out  -EA SilentlyContinue
Remove-Item u706*.sf*  -EA SilentlyContinue
Remove-Item u708*.sf*  -EA SilentlyContinue
Remove-Item dump_tech.txt  -EA SilentlyContinue
Remove-Item check_susp.txt  -EA SilentlyContinue
Remove-Item check_susp_dtl.txt  -EA SilentlyContinue
Remove-Item suspend_status.txt  -EA SilentlyContinue
Remove-Item suspend_suffix.txt  -EA SilentlyContinue
Remove-Item suspend_desc.txt  -EA SilentlyContinue
Remove-Item dump_tech.sf*  -EA SilentlyContinue
