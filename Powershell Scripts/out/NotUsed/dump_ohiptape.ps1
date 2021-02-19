#-------------------------------------------------------------------------------
# File 'dump_ohiptape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'dump_ohiptape'
#-------------------------------------------------------------------------------

# input file is one 159 byte physical rec containing 2 79 byutes logical records
#

# CONVERSION ERROR (expected, #4): awk.
# awk -f $cmd/split_ohiptape.awk < ohiptape > ohiptape.dump

# input file is raw stream of data containing logical 79 byte
# records with no end of record mark (ie. no 'cr' or 'lf')
#
#dd conv=ebcdic < ohiptape > ohiptape.tmp
# convert back to ascii adding 'lf' at end of every 1464 bytes
#dd ibs=79 obs=80 cbs=79 conv=sync,ascii < ohiptape.tmp > ohiptape.dump
# delete temp files
#rm ohiptape.tmp
