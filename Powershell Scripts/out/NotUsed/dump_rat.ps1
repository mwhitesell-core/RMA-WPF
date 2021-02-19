#-------------------------------------------------------------------------------
# File 'dump_rat.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'dump_rat'
#-------------------------------------------------------------------------------

# input file is raw stream of data containing logical 79 byte
# records with no end of record mark (ie. no 'cr' or 'lf')
#
# CONVERSION ERROR (expected, #4): EBCDIC.
# dd conv=ebcdic < ohip_rat_ascii > ohip_rat.tmp

# convert back to ascii adding 'lf' at end of every 1464 bytes
# CONVERSION ERROR (expected, #7): Hardware blocks management.
# dd ibs=79 obs=80 cbs=79 conv=sync,ascii < ohip_rat.tmp > ohip_rat_ascii.dump
# delete temp files
Remove-Item ohip_rat.tmp
