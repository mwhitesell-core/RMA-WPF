#-------------------------------------------------------------------------------
# File 'verify_daily_bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'verify_daily_bk1'
#-------------------------------------------------------------------------------

echo "verify_daily"
echo ""

Set-Location $env:application_root
Get-Location
echo "Starting VERIFY of the tape ..."

# CONVERSION ERROR (expected, #8): tape device is involved.
# cpio -itcuvB < /dev/rmt/1 > data/backup_daily.log

echo "Done verify ..."

Get-ChildItem data\backup_daily.log
Get-ChildItem data\backup_daily.ls, data\rmadir.ls, data\webdir.ls, data\web1dir.ls, data\web2dir.ls, data\web3dir.ls, `
  data\web4dir.ls, data\web5dir.ls, data\web6dir.ls, data\web7dir.ls, data\web8dir.ls, data\web9dir.ls, `
  data\web10dir.ls, data\diskettedir.ls, data\diskette1dir.ls, data\stonedir.ls, data\mumcdir.ls, data\suspend.ls, `
  data\kathydir.ls, data\f086.ls

echo ""

Get-Content data\backup_daily.log | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content data\backup_daily.ls, data\rmadir.ls, data\webdir.ls, data\web1dir.ls, data\web2dir.ls, data\web3dir.ls, `
  data\web4dir.ls, data\web5dir.ls, data\web6dir.ls, data\web7dir.ls, data\web8dir.ls, data\web9dir.ls, `
  data\web10dir.ls, data\diskettedir.ls, data\diskette1dir.ls, data\stonedir.ls, data\mumcdir.ls, data\suspend.ls, `
  data\kathydir.ls, data\f086.ls | Measure-Object -line | Select -ExpandProperty Lines

Get-Date
echo "DONE!"


#  ***** IF NEW BACKUP ADDED UPDATE backup_daily_to_disk  ALSO
#  *****                            reload_daily
#  *****                            reload_daily_from_disk

echo ""
Get-Date
echo ""

echo "rewinding tape .."
# CONVERSION ERROR (expected, #71): tape device is involved.
# mt -f /dev/rmt/1 rewind
