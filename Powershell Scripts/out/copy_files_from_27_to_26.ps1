#-------------------------------------------------------------------------------
# File 'copy_files_from_27_to_26.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_files_from_27_to_26'
#-------------------------------------------------------------------------------

#
#  $cmd/copy_files_from_27_to_26
#
#  Make sure to double check to copy files from the directory wanted;  anything not copy should be commented out with '#'

echo "Copy Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

########################

# copy every files from $data of /alpha & /charly

#cd /alpha/rmabill/rmabill101c/data
#find . -print | cpio -oc | rsh dgux2 'cd /alpha/rmabill/rmabill101c/data; cpio -icvdm'

#cd /charly/rmabill/rmabill101c/data
#find . -print | cpio -oc | rsh dgux2 'cd /charly/rmabill/rmabill101c/data; cpio -icvdm'

########################

# copy P* files (RAT files)  from $data

#cd /alpha/rmabill/rmabill101c/data
#find P* -print | cpio -oc | rsh dgux2 'cd /alpha/rmabill/rmabill101c/data; cpio -icvdm'

########################

# copy files from Moira dvlp directory

#cd /alpha/rmabill/rmabill101c/dvlp/moira
#find . -print | cpio -oc | rsh dgux2 'cd /alpha/rmabill/rmabill101c/dvlp/moira; cpio -icdm'

########################

# copy files from /charly/backup_transfer_area

#cd /charly/backup_transfer_area  
#find . -print | cpio -oc | rsh dgux2 'cd /charly/backup_transfer_area; cpio -icudm'
#find *part*  -print | cpio -oc | rsh dgux2 'cd /charly/backup_transfer_area; cpio -icuvdm'
#find backup*f010*  -print | cpio -oc | rsh dgux2 'cd /charly/backup_transfer_area; cpio -icudm'

########################

# copy files from web directory 

#cd /alpha/rmabill/rmabill101c/production/web3
#find  ru701*  -print | cpio -oc | rsh dgux2 'cd /alpha/rmabill/rmabill101c/production/web3; cpio -icdm'

########################

# copy files from $obj 

#cd /alpha/rmabill/rmabillmp/obj    
#find . -print | cpio -oc | rsh dgux2 'cd /alpha/rmabill/rmabillmp/obj;    cpio -icudm'
#cd /alpha/rmabill/rmabill101/obj    
#find  r137*          -print | cpio -oc | rsh dgux2 'cd /alpha/rmabill/rmabill101/obj;    cpio -icudm'
Set-Location $Env:root\alpha\rmabill\rmabill101c\obj
# CONVERSION ERROR (expected, #57): piping to cpio.
# find  r120.qtc        -print | cpio -oc | rsh dgux2 'cd /alpha/rmabill/rmabill101c/obj;    cpio -icudm'

########################

# copy rat files u030*dat from each clinic directory and production

#cd /alpha/rmabill/rmabill101c/production
#find  u030*dat  -print | cpio -oc | rsh dgux2 'cd /alpha/rmabill/rmabill101c/production; cpio -icvdm'
#find  ??/u030*dat  -print | cpio -oc | rsh dgux2 'cd /alpha/rmabill/rmabill101c/production; cpio -icvdm'

########################

# copy backup_ohip_tape2.ls from production 

#cd /alpha/rmabill/rmabill101c/production
#cat backup_ohip_tape2.ls | cpio -oc | rsh dgux2 'cd /alpha/rmabill/rmabill101c/production; cpio -icvdm'

########################

echo "Copy Finish Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
