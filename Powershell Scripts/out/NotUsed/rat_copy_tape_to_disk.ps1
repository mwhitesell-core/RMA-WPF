#-------------------------------------------------------------------------------
# File 'rat_copy_tape_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_copy_tape_to_disk'
#-------------------------------------------------------------------------------

# Program: "rat_copy_tape_to_disk:
# Purpose: originally this macro copied the file from tape to disk
#          and converted it from ebcdic to ascii
#          Now the file is already on disk on the CSU HP in ascii
#          and must be copied to this machine and converted from
#          into a fixed length 79 byte record file.
#

echo "rat_copy_tape_to_disk"
echo "make sure you are loged under rma's operator username"

echo "HIT  `"NEWLINE`"  TO CONTINUE ..."
 $garbage = Read-Host

echo ""
echo ""

# ftp the file to CSU's hp computer
#echo "ftping file to CSU's hp computer ..."
#TERM=vt100; export TERM
#. /etc/profile
#. /alpha/home/rma/.profile

# CONVERSION ERROR (unexpected, #26): Unknown command.
# ftp -v csuhpftp << E_O_F
echo ""
echo "DONE !"

Move-Item -Force rattape ohip_rat_ascii
