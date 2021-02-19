#-------------------------------------------------------------------------------
# File 'chg_dump.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'chg_dump'
#-------------------------------------------------------------------------------

# program: eft_convert_copy_to_hp
# Purpose:
#    convert the CIBC bank payroll file into a fixed length 1464 byte record 
#    file with 'cr'and 'lf' at the end of every record. The file will then be 
#       download onto kathy/yas's computer so that they can upload to banks
#
clear
echo ""
echo "Hit NEWLINE to continue ..."
echo ""
$garbage = Read-Host

# CONVERSION WARNING; EBCDIC conversion.
# rm chg_ebcdic.tmp                      1>/dev/null 2>&1
Remove-Item chg_ascii.tmp  -EA SilentlyContinue
Remove-Item chg_ascii.tmp2  -EA SilentlyContinue

#dd conv=ebcdic < eft_tape > eft_ebcdic.tmp
# CONVERSION WARNING; EBCDIC conversion.
# dd conv=ebcdic < eft_tape_r153 > chg_ebcdic.tmp

# convert back to ascii adding 'lf' at end of every 1464 bytes
# CONVERSION WARNING; EBCDIC conversion.
# dd ibs=1464 obs=1465 cbs=1464 conv=sync,ascii < chg_ebcdic.tmp > chg_ascii.tmp
&$env:cmd/add_line_feed.awk.ps1 $env:pb_prod/eft_tape_r153.txt $env:pb_prod/chg_ascii.tmp

# pad out each line to 1464 bytes (plus the 'lf' character aleady in record)

# currently ascii file is transferred to hp and ebcdic translation done there
&$env:cmd\pad_to_1464_bytes.awk.ps1  $env:pb_prod/chg_ascii.tmp $env:pb_prod/chg_ascii.tmp2
&$env:cmd\fix_eft.awk.ps1  $env:pb_prod/chg_ascii.tmp2 $env:pb_prod/eft_tape_r153_for_bank

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