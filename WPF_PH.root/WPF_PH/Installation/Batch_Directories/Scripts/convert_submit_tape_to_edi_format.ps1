#-------------------------------------------------------------------------------
# File 'convert_submit_tape_to_edi_format.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'convert_submit_tape_to_edi_format'
#-------------------------------------------------------------------------------

# input file is raw stream of data containing logical 79 byte
# records with no end of record mark (ie. no 'cr' or 'lf')
#
# CONVERSION ERROR (expected, #4): EBCDIC.
# dd conv=ebcdic < u020_tapeout_file > u020_tapeout_file_edi.tmp
$path = Convert-Path .
#CORE -  awk processing unneeded
#&$env:cmd/add_line_feed_edi.awk $path/u020_tapeout_file $path/u020_tapeout_file_edi.tmp

# convert back to ascii adding 'lf' at end of every 1464 bytes
# CONVERSION ERROR (expected, #7): Hardware blocks management.
# dd ibs=79 obs=80 cbs=79 conv=sync,ascii < u020_tapeout_file_edi.tmp > u020_tapeout_file_edi.tmp2

# convert to 79 bytes records with CR + LF at end of each line
# CONVERSION ERROR (expected, #10): awk.
# awk -f $cmd/format_ohip_submission_file.awk     \    < u020_tapeout_file_edi.tmp2                \    > ohiptape.edi
#&$env:cmd/format_ohip_submission_file.awk $path/u020_tapeout_file $path/ohiptape.edi
$rcmd = "\\$env:root/util/awk_util.exe pad_to_79_bytes $env:pb_prod/u020_tapeout_file $env:pb_prod/ohiptape.edi"
Invoke-Expression $rcmd
# delete temp files
#rm u020_tapeout_file_edi.tmp u020_tapeout_file_edi.tmp2
