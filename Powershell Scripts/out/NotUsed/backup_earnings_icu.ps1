#-------------------------------------------------------------------------------
# File 'backup_earnings_icu.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_earnings_icu'
#-------------------------------------------------------------------------------

# EARNINGS_BACKUP.CLI
# parameters: $1 contains the EP being run

# 2000/11/13  yas backup disk files *Z daily and monthend onto tape 

Set-Location $pb_data
Get-Date
echo ""
echo "performing additional backup to TAPE ..."
Get-Location

Get-ChildItem *.Z > backup_earnings_icu.ls
echo ""
Get-Date
# CONVERSION ERROR (expected, #15): tape device is involved.
# cat backup_earnings_icu.ls  |cpio -ocuvB > /dev/rmt/0
echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #20): tape device is involved.
# mt -f /dev/rmt/0 rewind
