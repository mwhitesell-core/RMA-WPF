#-------------------------------------------------------------------------------
# File 'doc_rev_cash_yearly_roll.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doc_rev_cash_yearly_roll'
#-------------------------------------------------------------------------------

Remove-Item roll.ls
#batch << BATCH_EXIT
$rcmd = $env:QTP + "purge_f050_f051"
Invoke-Expression $rcmd *> roll.ls

Get-ChildItem roll.ls

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content roll.ls | Out-Printer -Name $env:networkprinter
}

echo "Done!" >> roll.ls


#BATCH_EXIT
