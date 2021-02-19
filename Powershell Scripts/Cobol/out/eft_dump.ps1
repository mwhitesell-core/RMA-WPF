#-------------------------------------------------------------------------------
# File 'eft_dump.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'eft_dump'
#-------------------------------------------------------------------------------

# program: eft_convert_copy_to_hp
# Purpose:
#    convert the CIBC bank payroll file into a fixed length 1464 byte record 
#    file with 'cr'and 'lf' at the end of every record. The file is then ftp'd
#    to the CSU's HP where it is copied onto tape
#
# 2016/Jun/23   MC1     run in production directory

#MC1

Set-Location $application_root\production

#MC1 - end

clear
echo ""
echo "WARNING - this macro MUST be run from the 'rma' account"
echo "otherwise it can't log onto the HP"
echo ""
echo "Hit NEWLINE to continue ..."
echo ""
$garbage = Read-Host

# CONVERSION WARNING; EBCDIC conversion.
# rm eft_ebcdic.tmp                      1>/dev/null 2>&1
Remove-Item eft_ascii.tmp  > $null
Remove-Item eft_ascii.tmp2  > $null

# CONVERSION WARNING; EBCDIC conversion.
# dd conv=ebcdic < eft_tape > eft_ebcdic.tmp

# convert back to ascii adding 'lf' at end of every 1464 bytes
# CONVERSION WARNING; EBCDIC conversion.
# dd ibs=1464 obs=1465 cbs=1464 conv=sync,ascii < eft_ebcdic.tmp > eft_ascii.tmp

# pad out each line to 1464 bytes (plus the 'lf' character aleady in record)

# currently ascii file is transferred to hp and ebcdic translation done there
Get-Content eft_ascii.tmp | awk++ $cmd\pad_to_1464_bytes.awk  > eft_ascii.tmp2
Get-Content eft_ascii.tmp2 | awk++ $cmd\fix_eft.awk  > efttape

echo ""
echo "Please record the 'number of records' from the 2nd 'records in' value"
echo "and record in the Operators Audit log book and then "
echo "press NEWLINE to continue ..."
echo ""
$garbage = Read-Host

###awk -f $cmd/pad_to_1464_bytes.awk < eft_ascii.tmp  > eft_ascii.tmp2
#### convert to ebcdic format
###dd conv=ebcdic < eft_ascii.tmp2 > efttape

# 2007/11/16 b.e. no longer ftptp CSU's HP machine
## ftp the file to CSU's hp computer
##!/bin/ksh
#TERM=vt100; export TERM
#
## ftp file onto CSU's HP
#ftp -v CsuHpFtp << E_O_F
#put efttape efttape;rec=-1464,1,f,ascii;disc=10000
#quit
#E_O_F
