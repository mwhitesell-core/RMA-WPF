#-------------------------------------------------------------------------------
# File 'maria_rejects.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'maria_rejects'
#-------------------------------------------------------------------------------

# maria_rejects access the old f087-manual rejects
#quiz auto=$obj/maria_rejects.qzc
# maria_rejects1 to 3  access the new f087-submitted rejects
&$env:QTP maria_rejects1
&$env:QTP maria_rejects2
&$env:QUIZ maria_rejects3
