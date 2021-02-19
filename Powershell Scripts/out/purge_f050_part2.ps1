#-------------------------------------------------------------------------------
# File 'purge_f050_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_f050_part2'
#-------------------------------------------------------------------------------

#  PURGE f050_history file part2
#

Set-Location $env:pb_data

echo "--- create files ---"
<#$pipedInput = @"
create file f050-doc-revenue-mstr-history
create file f050tp-doc-revenue-mstr-history
"@

$pipedInput | qutil++#>
$rcmd = $env:TRUNCATE+ "f110_compensation_history"
Invoke-Expression $rcmd

# 2009/10/28 - move the new empty files to /charly and create the link
Move-Item -Force f050*doc_revenue_mstr_history* $Env:root\charly\rmabill\rmabill101c\data
# CONVERSION ERROR (expected, #14): Symbolic link creation.
# ln -s /charly/rmabill/rmabill101c/data/f050_doc_revenue_mstr_history.dat    f050_doc_revenue_mstr_history.dat
# CONVERSION ERROR (expected, #15): Symbolic link creation.
# ln -s /charly/rmabill/rmabill101c/data/f050_doc_revenue_mstr_history.idx    f050_doc_revenue_mstr_history.idx
# CONVERSION ERROR (expected, #16): Symbolic link creation.
# ln -s /charly/rmabill/rmabill101c/data/f050tp_doc_revenue_mstr_history.dat  f050tp_doc_revenue_mstr_history.dat
# CONVERSION ERROR (expected, #17): Symbolic link creation.
# ln -s /charly/rmabill/rmabill101c/data/f050tp_doc_revenue_mstr_history.idx  f050tp_doc_revenue_mstr_history.idx

#-----------------------------

Set-Location $Env:root\charly\purge

$rcmd = $env:QTP + "purge_relof050_history"
Invoke-Expression $rcmd >>$env:pb_prod\purgef050.log 2> $env:pb_prod\purgef050.log


echo "Purge f050-history - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')""
Invoke-Expression $rcmd >>purgef050.log
