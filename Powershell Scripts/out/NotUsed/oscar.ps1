#-------------------------------------------------------------------------------
# File 'oscar.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'oscar'
#-------------------------------------------------------------------------------

&$env:cmd\recreate_clean_suspense
Copy-Item HF012056.001_012056.rma.enc.n85 f002_submit_disk_012056.in
# CONVERSION ERROR (unexpected, #3): Not all keywords are ready for output.
&$env:cmd/u701oscar 012056 
Move-Item -Force HF012056.001_012056.rma.enc.n85 HF012056.001_012056.rma.enc.n85.done
