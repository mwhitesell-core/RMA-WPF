#-------------------------------------------------------------------------------
# File 'add_doc_to_avail_doc_mstr.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'add_doc_to_avail_doc_mstr'
#-------------------------------------------------------------------------------

# 
#    add the deleted doctor number from f020-doctor-mstr to the
#    end of f021-avail-doctor-mstr.

setdict++ $obj\rma
&$env:QTP u914 ${1} ${2} *> $null
