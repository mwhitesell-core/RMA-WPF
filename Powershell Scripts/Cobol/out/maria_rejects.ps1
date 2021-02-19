#-------------------------------------------------------------------------------
# File 'maria_rejects.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'maria_rejects'
#-------------------------------------------------------------------------------

# maria_rejects access the old f087-manual rejects
#quiz auto=$obj/maria_rejects.qzc
# maria_rejects1 to 3  access the new f087-submitted rejects
qtp++ $obj\maria_rejects1
qtp++ $obj\maria_rejects2
quiz++ $obj\maria_rejects3
