#-------------------------------------------------------------------------------
# File 'backupdaily_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backupdaily_1'
#-------------------------------------------------------------------------------

echo "BACKUPDAILY_1"
echo ""

echo "BACKUP OF:"
echo "----------!  f002   - claims mstr"
echo "----------!  f002   - claims extra"
echo ""
echo ""

echo "HIT   `"NEWLINE`"   TO COMMENCE BACKUP ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""

echo ""
Get-Date
echo ""

Set-Location $pb_data
# CONVERSION ERROR (unexpected, #22): \  not identifiers or numbers.
# /bin/ls f002_claims_mstr*  \ 
# CONVERSION ERROR (unexpected, #23): Unknown command.
#         f002_claims_extra* \        > backupdaily_1.ls

# CONVERSION ERROR (expected, #26): tape device is involved.
# cat backupdaily_1.ls | cpio -ocuvB |dd of=/dev/rmt/1

echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #32): tape device is involved.
# mt -f /dev/rmt/1 rewind
