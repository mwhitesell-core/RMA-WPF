#-------------------------------------------------------------------------------
# File 'dump_ohip_submit_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'dump_ohip_submit_tape'
#-------------------------------------------------------------------------------

# input file is raw stream of data containing logical 79 byte
# records with no end of record mark (ie. no 'cr' or 'lf')
#
# CONVERSION ERROR (expected, #4): EBCDIC.
# dd conv=ebcdic < u020_tapeout_file > u020_tapeout_file.tmp

# convert back to ascii adding 'lf' at end of every 1464 bytes
# CONVERSION ERROR (expected, #7): Hardware blocks management.
# dd ibs=79 obs=80 cbs=79 conv=sync,ascii < u020_tapeout_file.tmp > u020_tapeout_file.dump
# delete temp files
Remove-Item u020_tapeout_file.tmp
