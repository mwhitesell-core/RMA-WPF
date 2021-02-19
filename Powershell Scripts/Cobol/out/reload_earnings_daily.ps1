#-------------------------------------------------------------------------------
# File 'reload_earnings_daily.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'reload_earnings_daily'
#-------------------------------------------------------------------------------

# reload_earnings_daily 
# parameters: $1 contains the EP being run

# 1999/sep/16 B.E. - original
# 2000/nov/13 B.E. - changed reload to NOT use the -E option and instead
#                    reload EVERYTHING on the backup file

Set-Location $pb_data

echo ""
echo "Uncompress backup files on disk ..."
# CONVERSION WARNING; compress+cpio is involved.
# uncompress backup_earnings_daily${1}.cpio
echo ""

Get-Date
echo "Reloading files ..."
# CONVERSION ERROR
# cpio -iucvB  < backup_earnings_daily${1}.cpio
# Can't convert; Unknown command.
#cpio -iucvB -E  reload_earnings_daily.reload  < backup_earnings_daily${1}.cpio
echo ""
Get-Date
echo ""

echo "Re-compress backup files ... "
# CONVERSION WARNING; compress+cpio is involved.
# compress backup_earnings_daily${1}.cpio
echo ""
Get-Date
echo ""

Set-Location $pb_prod

echo "DONE !"
