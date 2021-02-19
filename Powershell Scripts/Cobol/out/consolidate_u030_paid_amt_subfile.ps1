#-------------------------------------------------------------------------------
# File 'consolidate_u030_paid_amt_subfile.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'consolidate_u030_paid_amt_subfile'
#-------------------------------------------------------------------------------

Set-Location $pb_prod
Get-Location

Get-Content 31, $root\u030_paid_amt.sf, 32, $root\u030_paid_amt.sf, 33, $root\u030_paid_amt.sf, 34, $root\u030_paid_amt.sf, 35, $root\u030_paid_amt.sf, 36, $root\u030_paid_amt.sf, 41, $root\u030_paid_amt.sf, 42, $root\u030_paid_amt.sf, 43, $root\u030_paid_amt.sf, 44, $root\u030_paid_amt.sf, 45, $root\u030_paid_amt.sf, 48, $root\u030_paid_amt.sf  > ..\upload\u030_paid_amt.sf

Get-Content 31, $root\u030_paid_amt.sfd  > ..\upload\u030_paid_amt.sfd
