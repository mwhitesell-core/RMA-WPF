#-------------------------------------------------------------------------------
# File 'dump_r070.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'dump_r070'
#-------------------------------------------------------------------------------

# input file is raw stream of data containing logical 108 bytes
# records with no end of record mark (ie. no 'cr' or 'lf')
#
# CONVERSION ERROR (expected, #4): EBCDIC.
# dd conv=ebcdic <  r070_work_mstr_80 >  r070_work_mstr_80.tmp

# convert back to ascii adding 'lf' at end of every record
# CONVERSION ERROR (unexpected, #7): Unknown command.
# dd ibs=108 obs=109 cbs=108 conv=sync,ascii < r070_work_mstr_80.tmp >r070_work_mstr_80.dump
# delete temp files
Remove-Item r070_work_mstr_80.tmp
