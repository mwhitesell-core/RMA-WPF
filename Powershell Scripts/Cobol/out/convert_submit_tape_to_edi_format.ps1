#-------------------------------------------------------------------------------
# File 'convert_submit_tape_to_edi_format.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'convert_submit_tape_to_edi_format'
#-------------------------------------------------------------------------------

# input file is raw stream of data containing logical 79 byte
# records with no end of record mark (ie. no 'cr' or 'lf')
#
# CONVERSION WARNING; EBCDIC conversion.
# dd conv=ebcdic < u020_tapeout_file > u020_tapeout_file_edi.tmp

# convert back to ascii adding 'lf' at end of every 1464 bytes
# CONVERSION WARNING; Hardware blocks management.
# dd ibs=79 obs=80 cbs=79 conv=sync,ascii < u020_tapeout_file_edi.tmp > u020_tapeout_file_edi.tmp2

# convert to 79 bytes records with CR + LF at end of each line
Get-Content u020_tapeout_file_edi.tmp2 | awk++ $cmd\format_ohip_submission_file.awk  > ohiptape.edi

# delete temp files
#rm u020_tapeout_file_edi.tmp u020_tapeout_file_edi.tmp2
