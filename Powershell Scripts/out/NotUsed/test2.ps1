#-------------------------------------------------------------------------------
# File 'test2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'test2'
#-------------------------------------------------------------------------------

#find /alpha/rmabill/rmabill101c/data                            \
Get-ChildItem -Exclude "f010_pat_mstr", "f010_pat_mstr.dat", "f010_pat_mstr.idx", "f002_claims_mstr", `
  "f002_claims_mstr.dat", "f002_claims_mstr.idx" . | Select -ExpandProperty FullName > test2.out
Get-Content test2.out
