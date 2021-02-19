#-------------------------------------------------------------------------------
# File 'backup_22to48_reports_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_22to48_reports_to_disk'
#-------------------------------------------------------------------------------

echo "backup 80, 84 and 91 to 96 reports TO DISK"
echo ""
echo "Hit NEW-LINE to commence backup of monthend reports."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""

Set-Location $env:application_root
echo "Preparing list of file to be backed up ..."
Get-Location
Get-ChildItem production\r004*, production\r005*, production\r011*, production\r012*, production\r013*, `
  production\r051*, production\r123*, production\r111b*, production\r120*, production\r119*, production\r121*, `
  production\r124*, production\r210*, production\r211*, production\r070*, production\31\r004*, production\31\r005*, `
  production\31\r011*, production\31\r012*, production\31\r013*, production\31\r051*, production\31\r123*, `
  production\31\r111b*, production\31\r120*, production\31\r119*, production\31\r121*, production\31\r124*, `
  production\31\r210*, production\31\r211*, production\31\r070*, production\32\r004*, production\32\r005*, `
  production\32\r011*, production\32\r012*, production\32\r013*, production\32\r051*, production\32\r123*, `
  production\32\r111b*, production\32\r120*, production\32\r119*, production\32\r121*, production\32\r124*, `
  production\32\r210*, production\32\r211*, production\32\r070*, production\33\r004*, production\33\r005*, `
  production\33\r011*, production\33\r012*, production\33\r013*, production\33\r051*, production\33\r123*, `
  production\33\r111b*, production\33\r120*, production\33\r119*, production\33\r121*, production\33\r124*, `
  production\33\r210*, production\33\r211*, production\33\r070*, production\34\r004*, production\34\r005*, `
  production\34\r011*, production\34\r012*, production\34\r013*, production\34\r051*, production\34\r123*, `
  production\34\r111b*, production\34\r120*, production\34\r119*, production\34\r121*, production\34\r124*, `
  production\34\r210*, production\34\r211*, production\34\r070*, production\35\r004*, production\35\r005*, `
  production\35\r011*, production\35\r012*, production\35\r013*, production\35\r051*, production\35\r123*, `
  production\35\r111b*, production\35\r120*, production\35\r119*, production\35\r121*, production\35\r124*, `
  production\35\r210*, production\35\r211*, production\35\r070*, production\36\r004*, production\36\r005*, `
  production\36\r011*, production\36\r012*, production\36\r013*, production\36\r051*, production\36\r123*, `
  production\36\r111b*, production\36\r120*, production\36\r119*, production\36\r121*, production\36\r124*, `
  production\36\r210*, production\36\r211*, production\36\r070*, production\41\r004*, production\41\r005*, `
  production\41\r011*, production\41\r012*, production\41\r013*, production\41\r051*, production\41\r123*, `
  production\41\r111b*, production\41\r120*, production\41\r119*, production\41\r121*, production\41\r124*, `
  production\41\r210*, production\41\r211*, production\41\r070*, production\42\r004*, production\42\r005*, `
  production\42\r011*, production\42\r012*, production\42\r013*, production\42\r051*, production\42\r123*, `
  production\42\r111b*, production\42\r120*, production\42\r119*, production\42\r121*, production\42\r124*, `
  production\42\r210*, production\42\r211*, production\42\r070*, production\43\r004*, production\43\r005*, `
  production\43\r011*, production\43\r012*, production\43\r013*, production\43\r051*, production\43\r123*, `
  production\43\r111b*, production\43\r120*, production\43\r119*, production\43\r121*, production\43\r124*, `
  production\43\r210*, production\43\r211*, production\43\r070*, production\44\r004*, production\44\r005*, `
  production\44\r011*, production\44\r012*, production\44\r013*, production\44\r051*, production\44\r123*, `
  production\44\r111b*, production\44\r120*, production\44\r119*, production\44\r121*, production\44\r124*, `
  production\44\r210*, production\44\r211*, production\44\r070*, production\45\r004*, production\45\r005*, `
  production\45\r011*, production\45\r012*, production\45\r013*, production\45\r051*, production\45\r123*, `
  production\45\r111b*, production\45\r120*, production\45\r119*, production\45\r121*, production\45\r124*, `
  production\45\r210*, production\45\r211*, production\45\r070*, production\46\r004*, production\46\r005*, `
  production\46\r011*, production\46\r012*, production\46\r013*, production\46\r051*, production\46\r123*, `
  production\46\r111b*, production\46\r120*, production\46\r119*, production\46\r121*, production\46\r124*, `
  production\46\r210*, production\46\r211*, production\46\r070*, production\48\r004*, production\48\r005*, `
  production\48\r011*, production\48\r012*, production\48\r013*, production\48\r051*, production\48\r123*, `
  production\48\r111b*, production\48\r120*, production\48\r119*, production\48\r121*, production\48\r124*, `
  production\48\r210*, production\48\r211*, production\48\r070*, production\98\r004*, production\98\r005*, `
  production\98\r011*, production\98\r012*, production\98\r013*, production\98\r051*, production\98\r123*, `
  production\98\r111b*, production\98\r120*, production\98\r119*, production\98\r121*, production\98\r124*, `
  production\98\r210*, production\98\r211*, production\98\r070* > production\backup_22to48.ls


echo ""
echo "Now begining backup to DISK  ..."
Get-Date
# CONVERSION ERROR (expected, #247): piping to cpio.
# cat production/backup_22to48.ls  | cpio -ocuvB > /charly/backup_transfer_area/backup_22to48_reports.cpio
echo ""
Get-Location
echo "Starting VERIFY of the DISK backup ..."
echo ""
echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
Get-Date
# CONVERSION ERROR (expected, #257): cpio.
# cpio -itcvB < /charly/backup_transfer_area/backup_22to48_reports.cpio > production/backup_22to48_reports.log 
echo ""
Get-Date
echo ""
echo "Comparing lines in the .ls vs .log"
echo ""
Get-ChildItem production\backup_22to48.ls, production\backup_22to48_reports.log

echo ""
Get-Content production\backup_22to48.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content production\backup_22to48_reports.log | Measure-Object -Line | Select -ExpandProperty Lines

Get-Date
echo "DONE!"
