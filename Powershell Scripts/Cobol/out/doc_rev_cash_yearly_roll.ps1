#-------------------------------------------------------------------------------
# File 'doc_rev_cash_yearly_roll.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'doc_rev_cash_yearly_roll'
#-------------------------------------------------------------------------------

Remove-Item roll.ls
#batch << BATCH_EXIT
$pipedInput = @"
exe $obj/purge_f050_f051
"@

$pipedInput | qtp++  > roll.ls  2>&1

Get-ChildItem roll.ls
Get-Contents roll.ls| Out-Printer


echo "Done!"  >> roll.ls


#BATCH_EXIT
