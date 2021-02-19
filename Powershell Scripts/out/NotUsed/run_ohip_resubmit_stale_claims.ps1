#-------------------------------------------------------------------------------
# File 'run_ohip_resubmit_stale_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_ohip_resubmit_stale_claims'
#-------------------------------------------------------------------------------

#Macro: run_ohip_resubmit_stale_claims

echo "Running run_ohip_resubmit_stale_claims ..."

Remove-Item u020_tapeout_file*, u020*sf* 2> $null

&$env:cmd\u022 0 0
echo ""
echo ""
echo ""

Get-Content u022_tp.sf | Set-Content u020_tapeout_file | Set-Content $null
Get-Content sd_u022.sf | Add-Content u020_tapeout_file | Set-Content $null

echo "Converting submission data to EDI format"
&$env:cmd\convert_submit_tape_to_edi_format

echo ""
Get-Date
echo ""
