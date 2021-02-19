#-------------------------------------------------------------------------------
# File 'run_claims_subfile.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_claims_subfile'
#-------------------------------------------------------------------------------

Remove-Item subfile.ls
#batch << BATCH_EXIT
&$env:cmd\claims_subfile *> subfile.ls
#BATCH_EXIT
