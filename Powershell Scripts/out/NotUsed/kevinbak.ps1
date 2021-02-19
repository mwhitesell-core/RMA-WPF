#-------------------------------------------------------------------------------
# File 'kevinbak.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'kevinbak'
#-------------------------------------------------------------------------------

echo "BACKUP_DAILY"
echo ""
echo ""
Get-Date
echo ""

Set-Location $pb_data

# CONVERSION ERROR (expected, #9): piping to cpio.
# /bin/ls 1>/dev/null 2>&1        \        f002_claim_shadow*      \        f002_claims_extra*      \      | cpio -ocuvBL > $pb_data/kevin.cpio
echo ""
Get-Date
echo ""

#mt -f /dev/rmt/1 rewind
