# input file is raw stream of data containing logical 79 byte
# records with no end of record mark (ie. no 'cr' or 'lf')
#
dd conv=ebcdic < u020_tapeout_file > u020_tapeout_file_edi.tmp

# convert back to ascii adding 'lf' at end of every 1464 bytes
dd ibs=79 obs=80 cbs=79 conv=sync,ascii < u020_tapeout_file_edi.tmp > u020_tapeout_file_edi.tmp2

# convert to 79 bytes records with CR + LF at end of each line
awk -f $cmd/format_ohip_submission_file.awk 	\
    < u020_tapeout_file_edi.tmp2 		\
    > ohiptape.edi

# delete temp files
#rm u020_tapeout_file_edi.tmp u020_tapeout_file_edi.tmp2
