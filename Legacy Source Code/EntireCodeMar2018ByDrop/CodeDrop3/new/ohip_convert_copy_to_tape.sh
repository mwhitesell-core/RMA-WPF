#!/bin/ksh 
# program: ohip_convert_copy_to_tape
# Purpose: (Originally this macro converted the ascii ohip tape into ebcdic 
#	   and copied it to mag tape attached to the MV1500.)
#          Now this macro will:
#	     1) use 'dd' command to massage file to convert it into
#	        a 79 byte fixed length file with 'cr'and 'lf' to end each rec
#	     2) runs U888 cobol program to change the 59 byte records into
#		158 byte records
#	     3) edi format of file is created for upload to PC and modem trans
#		transfer to OHIP. Step 4 below remains only in case of error
#		and tape file must be processed.
#	     4) ftp the converted file to the CSU's HP computer where RMA
#		staff run a macro that converts the file to ebcdic as it
#		copies it to mag tape.
# 2003/feb/19 b.e. added edi file creation
#
rm ohip_ebcdic.tmp               1>/dev/null 2>&1
rm ohip_tape_converted_to_ebcdic 1>/dev/null 2>&1
rm ohip_ascii.tmp                1>/dev/null 2>&1
rm ohip_ascii.tmp2               1>/dev/null 2>&1
rm ohiptape                      1>/dev/null 2>&1

#KM filter/c=macro_convert_ohip_tape   into   ohip_tape_converted_to_ebcdic

echo "OHIP Tape: prepare for processing on CSU's HP"
echo
echo "running u888 to convert 79 byte record file into 158 byte file ..."
cobrun $obj/u888

echo 
echo "temporarily converting ascii file to ebcdic ..."
#brad dd conv=ebcdic < u020_tapeout_file > ohip_ebcdic.tmp
dd conv=ebcdic < u020_tapeout_file2 > ohip_ebcdic.tmp

# convert back to ascii adding 'lf' at end of every record ie. 158 bytes
echo "converting back to fixed length 79 byte ascii file adding 'lf'"
#brad dd ibs=79 obs=80 cbs=79 conv=sync,ascii < ohip_ebcdic.tmp > ohip_ascii.tmp
dd ibs=158 obs=158 cbs=158 conv=sync,ascii < ohip_ebcdic.tmp > ohip_ascii.tmp
echo " "

# ensure that file is fixed length - 158 bytes plus 'lf' and 'cr'
# pad out each line to 158 bytes plus a 'cr' (plus the 'lf' character aleady in record)
# currently the file is passed to the hp in ascii format and converted there
echo "adding 'cr' to each record so that HP can process file ..."
#brad awk  -f $cmd/pad_to_79_bytes.awk < ohip_ascii.tmp > ohiptape79
awk  -f $cmd/pad_to_158_bytes.awk < ohip_ascii.tmp > ohiptape
echo 

###echo "moving two 79 byte records into 1 168 byte record ... "
#brad cobrun $obj/u888
###echo " "

#### awk -f $cmd/pad_to_79_bytes.awk < ohip_ascii.tmp > ohip_ascii.tmp2
#### convert to final 79 byte record to ebcdic format
#### dd conv=ebcdic < ohip_ascii.tmp2 > ohiptape


# 2003/feb/19 b.e. added routine to create 'edi' format of file
echo
echo Creating 'edi' format of file ...
$cmd/convert_submit_tape_to_edi_format


# ftp the file to CSU's hp computer
#!/bin/ksh
echo "ftping file to CSU's hp computer ..."
echo  'HIT  "NEWLINE"  TO CONTINUE ...'
 read garbage

TERM=vt100; export TERM
. /etc/profile
. /alpha/home/rma/.profile

# before 158 byte record: put ohiptape tapeohip;rec=-79,1,f,ascii;disc=100000
# ftp file onto CSU's HP
ftp -v CsuHpFtp << E_O_F
put ohiptape ohiptape;rec=-158,1,f,ascii;disc=100000
quit
E_O_F
echo " "
echo "DONE!"
