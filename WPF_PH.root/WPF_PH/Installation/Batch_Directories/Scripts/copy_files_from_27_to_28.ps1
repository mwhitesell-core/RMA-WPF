#-------------------------------------------------------------------------------
# File 'copy_files_from_27_to_28.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_files_from_27_to_28'
#-------------------------------------------------------------------------------

#cd /alpha/rmabill/rmabill101c/dvlp/moira
#find . -print | cpio -oc | rsh dgux1 'cd /alpha/rmabill/rmabill101c/dvlp/moira; cpio -icdm'

Set-Location $Env:root\charly\backup_transfer_area
#find . -print | cpio -oc | rsh dgux1 'cd /charly/backup_transfer_area; cpio -icudm'
# CONVERSION ERROR (expected, #6): piping to cpio.
# find *part*  -print | cpio -oc | rsh dgux1 'cd /charly/backup_transfer_area; cpio -icudm'

#cd /alpha/rmabill/rmabill101c/data
#find . -print | cpio -oc | rsh dgux1 'cd /alpha/rmabill/rmabill101c/data; cpio -icdm'
