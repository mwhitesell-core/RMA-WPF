#-------------------------------------------------------------------------------
# File 'truncate_f072_client_doc_mstr.ps1'
#-------------------------------------------------------------------------------



Remove-Item costing*sf*
$rcmd = $env:QTP + "backup_earnings_daily 1 backup_f073_client_doc_mstr"
Invoke-Expression $rcmd

$rcmd = $env:TRUNCATE+ "f073_client_doc_mstr"
Invoke-Expression $rcmd
