#-------------------------------------------------------------------------------
# File 'other_file_create.qus.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'other_file_create.qus'
#-------------------------------------------------------------------------------

# OTHER_FILE_CREATE.QUS
# This program is used to create the files that get unloaded from
# production and reloaded into test. (Physician Other)
# Created by S. Bachmann on Feb. 03, 1999

$pipedInput = @"
create file f021-avail-doctor-mstr
create file f022-deleted-doc-mstr
create file f119-doctor-ytd-history  
"@

$pipedInput | qutil++
