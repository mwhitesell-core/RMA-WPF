#-------------------------------------------------------------------------------
# File 'consolidate_u030_paid_amt_subfile.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'consolidate_u030_paid_amt_subfile'
#-------------------------------------------------------------------------------

Set-Location $env:pb_prod
Get-Location

Get-Content 31\u030_paid_amt.sf, 32\u030_paid_amt.sf, 33\u030_paid_amt.sf, 34\u030_paid_amt.sf, 35\u030_paid_amt.sf, 36\u030_paid_amt.sf, 41\u030_paid_amt.sf, 42\u030_paid_amt.sf, 43\u030_paid_amt.sf, 44\u030_paid_amt.sf, 45\u030_paid_amt.sf, 48\u030_paid_amt.sf `
  > ..\upload\u030_paid_amt.sf

Get-Content 31\u030_paid_amt.sfd > ..\upload\u030_paid_amt.sfd
